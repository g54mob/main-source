using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

public static class CookeryVolumeTracker
{
	private class VolumeUpdater : SingletonBehaviour<VolumeUpdater>
	{
		private List<CookeryLightVolumeRenderer> _allVolumes = new List<CookeryLightVolumeRenderer>();

		private int index;

		private float minDist = float.MaxValue;

		private CookeryLightVolumeRenderer closest;

		public CookeryLightVolumeRenderer CurrentVolume { get; private set; }

		public bool InsideVolume { get; private set; }

		public IReadOnlyList<CookeryLightVolumeRenderer> AllVolumes => _allVolumes;

		public new static string AllowAutoCreate()
		{
			return "[Cookery volume tracker]";
		}

		public void RegisterVolume(CookeryLightVolumeRenderer volume)
		{
			_allVolumes.Add(volume);
		}

		public void UnregisterVolume(CookeryLightVolumeRenderer volume)
		{
			_allVolumes.Remove(volume);
		}

		private void Update()
		{
			if (Camera.main != null)
			{
				Vector3 position = Camera.main.transform.position;
				if (AllVolumes.Count > 0)
				{
					if (index >= AllVolumes.Count)
					{
						CurrentVolume = closest;
						index = 0;
						minDist = float.MaxValue;
						closest = null;
					}
					if (AllVolumes[index].EffectEnabled && AllVolumes[index].largeScale)
					{
						float num = Vector3.SqrMagnitude(position - AllVolumes[index].transform.position);
						if (num < minDist)
						{
							closest = AllVolumes[index];
							minDist = num;
						}
					}
					index++;
				}
				if (CurrentVolume != null)
				{
					Vector3 vector = CurrentVolume.transform.InverseTransformPoint(position);
					InsideVolume = vector.x >= -0.5f && vector.y >= -0.5f && vector.z >= -0.5f && vector.x <= 0.5f && vector.y <= 0.5f && vector.z <= 0.5f;
				}
				else
				{
					InsideVolume = false;
				}
			}
			else
			{
				CurrentVolume = null;
				InsideVolume = false;
			}
		}
	}

	private static readonly List<CookeryLightVolumeRenderer> dummyList = new List<CookeryLightVolumeRenderer>();

	public static CookeryLightVolumeRenderer CurrentVolume
	{
		get
		{
			if (!UnloadWatcher.isUnloading)
			{
				return SingletonBehaviour<VolumeUpdater>.Instance.CurrentVolume;
			}
			return null;
		}
	}

	public static bool InsideVolume
	{
		get
		{
			if (!UnloadWatcher.isUnloading)
			{
				return SingletonBehaviour<VolumeUpdater>.Instance.InsideVolume;
			}
			return false;
		}
	}

	public static IReadOnlyList<CookeryLightVolumeRenderer> AllVolumes
	{
		get
		{
			if (!UnloadWatcher.isUnloading)
			{
				return SingletonBehaviour<VolumeUpdater>.Instance.AllVolumes;
			}
			return dummyList;
		}
	}

	public static void RegisterVolume(CookeryLightVolumeRenderer volume)
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<VolumeUpdater>.Instance.RegisterVolume(volume);
		}
	}

	public static void UnregisterVolume(CookeryLightVolumeRenderer volume)
	{
		if (!UnloadWatcher.isUnloading)
		{
			SingletonBehaviour<VolumeUpdater>.Instance.UnregisterVolume(volume);
		}
	}
}
