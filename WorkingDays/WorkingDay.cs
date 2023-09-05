///////////////////////////////////////////////////////////////////////////////////////////
//
// Working Days Summary Class
// The Working Days Summary class is used to summarize a week working days with different
// time slots into a single simple sentence. This summarized sentence can be used for
// printing, on a website, or anywhere else that is visible to the general audience.
// [WorkingDay.cs]
// (c) Sep 2023, Younes Jafari
// 
///////////////////////////////////////////////////////////////////////////////////////////

using System.Collections.Generic;
using System.Linq;

namespace WorkingDaySummary
{
    class WorkingDay
    {
        public int WeekIndex { get; set; }
        public string Day { get; set; }
        public string TimeSlots { get; set; }
        public int Repeated { get; set; }

        public WorkingDay(int weekIndex, string day, params string[] timeSlots)
        {
            WeekIndex = weekIndex;
            Day = day;
            TimeSlots = string.Join(" & ", timeSlots.Select(x => x.Replace(":00", "").TrimStart('0')));
            Repeated = 1;
        }

        public WorkingDay(WorkingDay workingDay)
        {
            WeekIndex = workingDay.WeekIndex;
            Day = workingDay.Day;
            TimeSlots = workingDay.TimeSlots;
            Repeated = 1;
        }

        public static int FindIndex(WorkingDay workDay, List<WorkingDay> list)
        {
            int r = -1;
            for (int i = 0; i < list.Count; i++)
            {
                var item = list[i];
                if (item.TimeSlots == workDay.TimeSlots)
                {
                    r = i;
                    break;
                }
            }
            return r;
        }

        /// <summary>
        /// Generates a summary of working days with their time slots. It categorizes the days into several groups:
        /// 1. If all days have the same time slots and there are at least 6 days with the same time slots, it summarizes as "All days (TimeSlots)".
        /// 2. If either even days or odd days have the same time slots for at least 3 days, it summarizes them separately as "Even days (TimeSlots)" and/or "Odd days (TimeSlots)".
        /// 3. If there are other working day combinations (neither all the same nor even/odd with 3 days), it lists them individually with their respective time slots.
        /// </summary>
        /// <param name="workingDays">A List of WorkingDay objects</param>
        /// <returns>A string summary of working days</returns>
        public static string GetWorkdaysSummary(List<WorkingDay> workingDays)
        {
            string summary = "";

            List<WorkingDay> allDays = new List<WorkingDay>();
            List<WorkingDay> evenDays = new List<WorkingDay>();
            List<WorkingDay> oddDays = new List<WorkingDay>();

            int seqCounter = 0;
            for (int i = 0; i < workingDays.Count; i++)
            {
                WorkingDay wd = workingDays[i];
                int indx1 = WorkingDay.FindIndex(wd, allDays);
                if (indx1 == -1)
                    allDays.Add(new WorkingDay(wd));
                else
                {
                    allDays[indx1].Day += " & " + wd.Day;
                    allDays[indx1].Repeated++;
                }
                if (wd.WeekIndex % 2 == 0)
                {
                    int indx2 = WorkingDay.FindIndex(wd, evenDays);
                    if (indx2 == -1)
                        evenDays.Add(new WorkingDay(wd));
                    else
                    {
                        evenDays[indx2].Day += " & " + wd.Day;
                        evenDays[indx2].Repeated++;
                    }
                }
                else
                {
                    int indx3 = WorkingDay.FindIndex(wd, oddDays);
                    if (indx3 == -1)
                        oddDays.Add(new WorkingDay(wd));
                    else
                    {
                        oddDays[indx3].Day += " & " + wd.Day;
                        oddDays[indx3].Repeated++;
                    }
                }

                if (i == 0)
                    seqCounter++;
                else if (workingDays[i].WeekIndex == workingDays[i - 1].WeekIndex + 1)
                    seqCounter++;
            }

            if (allDays.Count == 1 && allDays[0].Repeated >= 6)
                summary = "All days (" + allDays[0].TimeSlots + ")";
            else if (allDays.Count == 1 && allDays[0].Repeated > 2 && allDays[0].Repeated == seqCounter)
                summary = workingDays[0].Day + " to " + workingDays[workingDays.Count - 1].Day + " (" + allDays[0].TimeSlots + ")";
            else
            {
                if ((evenDays.Count == 1 && evenDays[0].Repeated >= 3) || (oddDays.Count == 1 && oddDays[0].Repeated == 3))
                {
                    if (evenDays.Count == 1 && evenDays[0].Repeated >= 3)
                        summary = "Even days (" + evenDays[0].TimeSlots + ")";
                    if (oddDays.Count == 1 && oddDays[0].Repeated == 3)
                    {
                        summary += (summary == "") ? "" : ", ";
                        summary += "Odd days (" + oddDays[0].TimeSlots + ")";
                    }
                    if (evenDays.Count > 1 || (evenDays.Count == 1 && evenDays[0].Repeated >= 1 && evenDays[0].Repeated < 3))
                    {
                        summary += (summary == "") ? "" : ", ";
                        summary += string.Join(", ", evenDays.Select(x => x.Day + " (" + x.TimeSlots + ")"));
                    }
                    if (oddDays.Count > 1 || oddDays.Count == 1 && oddDays[0].Repeated >= 1 && oddDays[0].Repeated < 3)
                    {
                        summary += (summary == "") ? "" : ", ";
                        summary += string.Join(", ", oddDays.Select(x => x.Day + " (" + x.TimeSlots + ")"));
                    }
                }
                else
                {
                    if (allDays.Count >= 1)
                        summary = string.Join(", ", allDays.Select(x => x.Day + " (" + x.TimeSlots + ")"));
                }
            }

            return summary;
        }

        public override string ToString()
        {
            return WeekIndex + " - " + Day + " (" + TimeSlots + ")";
        }
    }
}
