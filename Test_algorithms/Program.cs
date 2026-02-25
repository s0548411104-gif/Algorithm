
//שולמית קצנלבוגן s0548411104@gmail.com
//שאלה 1
using System;
using System.Collections.Generic;
public class Program
{
    // שאלה 1: מציאת תת-מערך עם סכום מקסימלי
    // זמן ריצה: O(n), זיכרון: O(n)
    static void ex1(int[] arr)
    {
        int[] a = new int[arr.Length];
        int max = arr[0];
        int end = 0;
        int start = 0;
        int bestStart = 0;
        a[0] = arr[0];
        for (int i = 1; i < arr.Length; i++)
        {
            if (a[i - 1] + arr[i] > arr[i])

                a[i] = arr[i] + a[i - 1];

            else
            {
                a[i] = arr[i];
                start = i;
            }
            if (a[i] > max)
            {
                max = a[i];
                end = i;
                bestStart = start;
            }
        }
        for (int j = bestStart; j <= end; j++)
            Console.WriteLine(arr[j] + " ");
    }

    /*שאלה 2
    מבנה הנתונים:
    טבלת גיבוב תשמור בכל תא את הערך עצמו וחותמת זמן שבה הוכנס
    משתנים גלובלים:
     Timeמונה שמתחיל ב 0 וגדל ב 1 כל פעולת עדכון.
     setAll_timeשומר את המונה של  setAllהאחרון.
    setAll_value הערך שבפונקצית setAll האחרונה.
    הפעולות:
     Set(key, val)מקדמים את time ב-1 מכיניסים רגיל לטבלת גיבוב O(1) עם חותמת הזמן
    זמן ריצה O(1) הכנסה לטבלת גיבוב
    Get(key) הולכים לתא ולוקחים את חותמת הזמן ולוקחים גם את setAll_time ובודקים מי גדול יותר
    מי שגדול יותר הוא יהיה הערך המוחזר.O(1) -לא עוברת על הכל רק למפתח הספציפי.
    אם לא קיים בתא ערך בודקים האם setAll_time>0 אם כן נחזיר את הערך של setAll_value אחרת נחזיר null
    זמן ריצה O(1) שליפה מטבלת גיבוב והשוואת שתי מספרים
    SetAll(val)  מקדמים את  Time ב-1. מעדכנים את setAll_value להיות ה-val שקיבלנו, ושומרים ב-setAll_time את הזמן הנוכחי
    זמן ריצה: O(1) פעולות השמה פשוטות למשתנים.*/

    public class SmartStructure
    {
        private Dictionary<int, (int value, int timestamp)> data = new Dictionary<int, (int, int)>();
        private int time = 0;
        private int setAllTime = -1;
        private int setAllValue = 0;

        public void Set(int key, int val)
        {
            time++;
            data[key] = (val, time);
        }
        public void SetAll(int val)
        {
            time++;
            setAllTime = time;
            setAllValue = val;
        }
        public int? Get(int key)
        {
            if (data.TryGetValue(key, out var entry))
            {
                if (entry.timestamp > setAllTime)
                {
                    return entry.value;
                }
            }
            if (setAllTime != -1)
            {
                return setAllValue;
            }
            return null;
        }
    }




    // שאלה 3: מציאת כמות הסרות מינימלית לסדרה לא-יורדת
    // זמן ריצה: O(n log n)עובר על כל הרשימה ועושה חיפוש בינארי.
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }
    static int MinRemovals(ListNode L)
    {
        if (L == null) return 0;
        List<int> a = new List<int>();
        ListNode curr = L;
        while (curr != null)
        {
            a.Add(curr.val);
            curr = curr.next;
        }
        int n = a.Count;
        List<int> temp = new List<int>();
        foreach (int x in a)
        {
            int y = Up(temp, x);
            if (y == temp.Count)
                temp.Add(x);
            else
                temp[y] = x;
        }
        return n - temp.Count;
    }
    static int Up(List<int> tails, int target)
    {
        int low = 0, high = tails.Count;
        while (low < high)
        {
            int mid = low + (high - low) / 2;
            if (tails[mid] <= target)
                low = mid + 1;
            else
                high = mid;

        }
        return low;
    }

    // שאלה 4: ספירת תת-מערכים שסכומם בדיוק X
    // זמן ריצה: O(n) בעזרת טבלת גיבוב
    static int CountSubarraysWithSumX(int[] arr, int x)
    {
        int count = 0;
        int currentSum = 0;
        Dictionary<int, int> prefixSums = new Dictionary<int, int>();
        prefixSums[0] = 1;
        foreach (int num in arr)
        {
            currentSum += num;
            if (prefixSums.ContainsKey(currentSum - x))
            {
                count += prefixSums[currentSum - x];
            }
            if (prefixSums.ContainsKey(currentSum))
            {
                prefixSums[currentSum]++;
            }
            else
            {
                prefixSums[currentSum] = 1;
            }
        }
        return count;
    }

    // שאלה 5: הבטחת קבלת צעצוע ומדבקה
    static int func5(int N, int S, int T)
    {
        return Math.Max(N - T, N - S) + 1;
    }
}