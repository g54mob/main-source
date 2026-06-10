using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

public class ObjectPhotoCaptureController : MonoBehaviour
{
	[Header("Components")]
	public Transform spawnParent;

	public GameObject spawnedObject;

	public Camera captureCam;

	[Header("Settings")]
	public int resolution;

	[ShowAssetPreview(64, 64)]
	[InfoBox("Don't forget to turn film grain off before capturing, unless you want it featured", EInfoBoxType.Normal)]
	[Header("Capture")]
	public Sprite captured;

	[ShowAssetPreview(64, 64)]
	public Sprite icon;

	public InteractablePreset prefabOverrideObject;

	public GameObject prefabOverride;

	[Range(0.1f, 3f)]
	public float scale;

	[ReadOnly]
	public Vector3 itemPos;

	[ReadOnly]
	public Vector3 itemEuler;

	[Space(7f)]
	public Vector2 captureIndex;

	public InteractablePreset captureSingle;

	[Button(null, EButtonEnableMode.Always)]
	public void LoadIndex()
	{
	}

	private List<InteractablePreset> GetValidPresets()
	{
		return null;
	}

	[Button(null, EButtonEnableMode.Always)]
	public void LoadSingle()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void UpdatePositions()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void NextIndex()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void PreviousIndex()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CaptureSingle()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	public void CaptureAllSpawnableInteractables()
	{
	}
}
