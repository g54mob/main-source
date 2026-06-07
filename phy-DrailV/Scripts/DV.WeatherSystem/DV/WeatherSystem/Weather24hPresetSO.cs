using System;
using System.Collections.Generic;
using UnityEngine;

namespace DV.WeatherSystem
{
	[CreateAssetMenu(menuName = "DV/Weather 24h Preset")]
	public class Weather24hPresetSO : ScriptableObject
	{
		public Weather24hPresetSO highZoneVariant;

		public List<WeatherSnapshot> snapshots = new List<WeatherSnapshot>();

		[NonSerialized]
		public static List<string> warnings = new List<string>();

		[Header("Tweaks")]
		public bool absoluteOffset;

		public Vector2 manualOffset = Vector2.zero;

		public bool HasHighZone => highZoneVariant != null;

		public Weather24hPresetSO HighZoneOrDefault
		{
			get
			{
				if (!(highZoneVariant != null))
				{
					return this;
				}
				return highZoneVariant;
			}
		}

		[ContextMenu("Upgrade fog (to log scale)")]
		public void UpgradeFog()
		{
			for (int i = 0; i < snapshots.Capacity; i++)
			{
				snapshots[i].fogDensity = WeatherSnapshot.ConvertDisplayToStorageFog(snapshots[i].fogDensity);
				snapshots[i].fogDistanceDensity = WeatherSnapshot.ConvertDisplayToStorageFog(snapshots[i].fogDistanceDensity);
				snapshots[i].fogHeightDensity = WeatherSnapshot.ConvertDisplayToStorageFog(snapshots[i].fogHeightDensity);
			}
			Debug.Log("Conversion done.");
		}

		private void Warn(string message)
		{
			message = base.name + ": " + message;
			warnings.Add(message);
			Debug.LogWarning(message);
		}

		public int InsertSnapshot(float time)
		{
			if (time < 0f || Mathf.Approximately(time, 0f) || time > 1f || Mathf.Approximately(time, 1f))
			{
				Warn($"Invalid time ({time}), will not insert");
				return -1;
			}
			if (snapshots.Count == 0)
			{
				snapshots.Add(new WeatherSnapshot());
				RebuildCaches();
				return 0;
			}
			for (int i = 1; i < snapshots.Count; i++)
			{
				WeatherSnapshot weatherSnapshot = snapshots[i];
				if (Mathf.Approximately(weatherSnapshot.startTime, time))
				{
					Warn($"Already have snapshot at that exact time ({time}), will not insert");
					return -1;
				}
				if (weatherSnapshot.startTime > time || i == snapshots.Count - 1)
				{
					WeatherSnapshot weatherSnapshot2 = snapshots[i - 1].Clone();
					weatherSnapshot2.startTime = time;
					snapshots.Insert(i, weatherSnapshot2);
					RebuildCaches();
					return i + 1;
				}
			}
			Warn(string.Format("Unhandled case in {0} for time {1}", "InsertSnapshot", time));
			return -1;
		}

		public void RemoveSnapshot(int index)
		{
			if (index == 0)
			{
				Warn("Removing snapshot at index 0 is not allowed");
				return;
			}
			if (index <= 0 || index >= snapshots.Count)
			{
				Warn($"Invalid index passed ({index}), not removing");
				return;
			}
			snapshots.RemoveAt(index);
			RebuildCaches();
		}

		public void ValidateSnapshots()
		{
			if (snapshots == null)
			{
				snapshots = new List<WeatherSnapshot>();
				snapshots.Add(new WeatherSnapshot());
			}
			else if (snapshots.Count == 0)
			{
				Warn("Preset has no snapshots, adding one dummy snapshot to avoid errors");
				snapshots.Add(new WeatherSnapshot());
			}
			snapshots.Sort(new SnapshotComparer());
			WeatherSnapshot weatherSnapshot = snapshots[0];
			if (weatherSnapshot.startTime != 0f)
			{
				Warn($"First snapshot start time must be 0 (it's {weatherSnapshot.startTime}), setting it to 0 automatically");
				weatherSnapshot.startTime = 0f;
			}
			WeatherSnapshot weatherSnapshot2 = snapshots[snapshots.Count - 1];
			if (weatherSnapshot2.startTime >= 1f)
			{
				Warn($"Last snapshot start time should be < 1 (it's {weatherSnapshot2.startTime})");
			}
			for (int i = 1; i < snapshots.Count; i++)
			{
				WeatherSnapshot weatherSnapshot3 = snapshots[i];
				if (Mathf.Approximately(snapshots[i - 1].startTime, weatherSnapshot3.startTime))
				{
					weatherSnapshot3.startTime += 0.01f;
					Warn($"Changed snapshot {i} start time to {weatherSnapshot3.startTime} because it had identical value to previous snapshot");
				}
			}
			if (highZoneVariant != null && highZoneVariant.highZoneVariant != null)
			{
				Warn("This preset (" + base.name + ") has a high zone (" + highZoneVariant.name + ") that itself also has a high zone (" + highZoneVariant.highZoneVariant.name + "), this shouldn't happen, links are supposed to go 1-deep at max");
			}
			RebuildCaches();
		}

		public (WeatherSnapshot a, WeatherSnapshot b) GetPairForTime(float timeOfDay)
		{
			if (timeOfDay < 0f || timeOfDay > 1f)
			{
				Debug.LogWarning($"Got time of day {timeOfDay}, it will be clamped to 0-1");
				timeOfDay = Mathf.Clamp01(timeOfDay);
			}
			WeatherSnapshot weatherSnapshot = snapshots[0];
			WeatherSnapshot weatherSnapshot2 = snapshots[snapshots.Count - 1];
			if (snapshots.Count == 1)
			{
				return (a: weatherSnapshot, b: weatherSnapshot);
			}
			if (timeOfDay >= weatherSnapshot2.startTime)
			{
				return (a: weatherSnapshot2, b: weatherSnapshot);
			}
			for (int i = 0; i < snapshots.Count - 1; i++)
			{
				WeatherSnapshot weatherSnapshot3 = snapshots[i];
				WeatherSnapshot weatherSnapshot4 = snapshots[i + 1];
				if (timeOfDay >= weatherSnapshot3.startTime && timeOfDay < weatherSnapshot4.startTime)
				{
					return (a: weatherSnapshot3, b: weatherSnapshot4);
				}
			}
			Debug.LogWarning(string.Format("Couldn't {0}({1}), returning (first, first)", "GetPairForTime", timeOfDay));
			return (a: weatherSnapshot, b: weatherSnapshot);
		}

		public (WeatherSnapshot snapshot, int index) GetSnapshotForTime(float timeOfDay)
		{
			if (timeOfDay < 0f || timeOfDay > 1f)
			{
				Debug.LogWarning($"Got time of day {timeOfDay}, it will be clamped to 0-1");
				timeOfDay = Mathf.Clamp01(timeOfDay);
			}
			for (int i = 1; i <= snapshots.Count; i++)
			{
				if (i == snapshots.Count || snapshots[i].startTime > timeOfDay)
				{
					return (snapshot: snapshots[i - 1], index: i - 1);
				}
			}
			Debug.LogWarning(string.Format("Weather Preset '{0}' couldn't {1}({2}), returning first", base.name, "GetSnapshotForTime", timeOfDay));
			return (snapshot: snapshots[0], index: 0);
		}

		public int GetNeighborSnapshotIndex(int currentIndex, bool next)
		{
			int num = currentIndex + (next ? 1 : (-1));
			if (num < 0)
			{
				return snapshots.Count - 1;
			}
			if (num >= snapshots.Count)
			{
				return 0;
			}
			return num;
		}

		public WeatherSnapshot GetNeighborSnapshot(int currentIndex, bool next)
		{
			return snapshots[GetNeighborSnapshotIndex(currentIndex, next)];
		}

		private void RebuildCaches()
		{
		}
	}
}
