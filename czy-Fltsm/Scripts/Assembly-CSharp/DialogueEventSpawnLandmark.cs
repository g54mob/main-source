using System;
using TNRD;
using UnityEngine;

[Serializable]
public class DialogueEventSpawnLandmark : IDialogueEvent
{
	[SerializeField]
	[HideInInspector]
	private string _name = "Spawn Landmark";

	[SerializeField]
	private SerializableInterface<ILandmarkBehaviourProvider> _landmark;

	[SerializeField]
	private LandmarkPicker.Settings _landmarkPickerSettings;

	void IDialogueEvent.TriggerEvent(Dialogue dialogue)
	{
		if (_landmark.Value == null || !_landmarkPickerSettings.Spawn(_landmark.Value))
		{
			Debug.LogException(new ArgumentException($"Failed to spawn landmark {_landmark.Value}!"));
		}
	}
}
