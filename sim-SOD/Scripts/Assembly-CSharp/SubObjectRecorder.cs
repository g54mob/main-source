using NaughtyAttributes;
using UnityEngine;

public class SubObjectRecorder : MonoBehaviour
{
	public FurniturePreset furniturePreset;

	[Button(null, EButtonEnableMode.Always)]
	public void RecordSubObjectPlacements()
	{
	}
}
