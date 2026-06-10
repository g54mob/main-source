using NaughtyAttributes;
using UnityEngine;

public class SubObjectPlacement : MonoBehaviour
{
	[OnValueChanged("OnClassChanged")]
	[Header("Setup")]
	public SubObjectClassPreset preset;

	public FurniturePreset.SubObjectOwnership belongsTo;

	public int security;

	[Header("Components")]
	public TextMesh text;

	public Transform spawnedObject;

	public MeshRenderer mainObject;

	public void OnClassChanged()
	{
	}

	[Button("Random Direction", EButtonEnableMode.Always)]
	public void RandomDir()
	{
	}

	[Button("Random Object", EButtonEnableMode.Always)]
	public void SpawnRandomObject()
	{
	}

	[Button("Remove Random Object", EButtonEnableMode.Always)]
	public void RemoveRandomObject()
	{
	}
}
