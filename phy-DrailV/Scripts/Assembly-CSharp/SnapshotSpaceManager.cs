using DV.Utils;
using UnityEngine;

public class SnapshotSpaceManager : MonoBehaviour
{
	private void OnEnable()
	{
		ZoneDetector.ActiveCameraValueUpdated += UpdateSnapshot;
		UpdateSnapshot(0f, ZoneDetector.ZoneType.Underwater);
	}

	private void OnDisable()
	{
		ZoneDetector.ActiveCameraValueUpdated -= UpdateSnapshot;
	}

	private void UpdateSnapshot(float _, ZoneDetector.ZoneType __)
	{
		AudioManager.SnapshotSpace snapshotSpace = AudioManager.SnapshotSpace.Outside;
		float value2;
		float value3;
		float value4;
		if (ZoneDetector.GetValue(ZoneDetector.ZoneType.Underwater, out var value) && value > 0.5f)
		{
			snapshotSpace = AudioManager.SnapshotSpace.Underwater;
		}
		else if (ZoneDetector.GetValue(ZoneDetector.ZoneType.Tunnel, out value2) && value2 > 0.5f)
		{
			snapshotSpace = AudioManager.SnapshotSpace.Tunnel;
		}
		else if (ZoneDetector.GetValue(ZoneDetector.ZoneType.Depot, out value3) && value3 > 0.5f)
		{
			snapshotSpace = AudioManager.SnapshotSpace.Depot;
		}
		else if (ZoneDetector.GetValue(ZoneDetector.ZoneType.Indoors, out value4) && value4 > 0.5f)
		{
			snapshotSpace = AudioManager.SnapshotSpace.Indoors;
		}
		if (SingletonBehaviour<AudioManager>.Instance.Snapshot != snapshotSpace)
		{
			SingletonBehaviour<AudioManager>.Instance.Snapshot = snapshotSpace;
		}
	}
}
