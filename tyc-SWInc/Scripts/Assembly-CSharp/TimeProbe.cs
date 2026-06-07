using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class TimeProbe : MonoBehaviour
{
	public class TimerObject
	{
		public string Name;

		public Dictionary<string, float> Labels = new Dictionary<string, float>();

		public Dictionary<string, int> Counts = new Dictionary<string, int>();

		public TimerObject(string name)
		{
			Name = name;
		}

		public string GetOutput()
		{
			if (Labels.Count == 1)
			{
				return Name + " " + Labels.First().Value.SecondsToTime();
			}
			StringBuilder stringBuilder = new StringBuilder(Name);
			stringBuilder.Append(" ");
			stringBuilder.Append(Labels.SumSafe((KeyValuePair<string, float> x) => x.Value).SecondsToTime());
			stringBuilder.Append(" (");
			float num = Labels.SumSafe((KeyValuePair<string, float> x) => x.Value / (float)Counts[x.Key]);
			foreach (KeyValuePair<string, float> label in Labels)
			{
				stringBuilder.Append(label.Key);
				stringBuilder.Append(": ");
				stringBuilder.Append((label.Value / (float)Counts[label.Key] / num).ToPercent());
				stringBuilder.Append(", ");
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}
	}

	public static TimeProbe Instance;

	public Dictionary<string, TimerObject> Timers = new Dictionary<string, TimerObject>();

	public static void BeginTime(string timer, string label = "None")
	{
	}

	public static void FinalizeTime(string timer)
	{
	}

	public static void ClearTime(string timer)
	{
	}

	public static void EndTime(string timer)
	{
	}

	public static void QuickProbeStart()
	{
	}

	public static void QuickProbeEnd(string name)
	{
	}

	public static void QuickProbeStartRatio()
	{
	}

	public static void QuickProbeRatioCheck()
	{
	}

	public static void QuickProbeEndRatio(string name)
	{
	}
}
