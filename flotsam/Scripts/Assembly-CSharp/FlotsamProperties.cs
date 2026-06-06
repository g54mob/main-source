using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Flotsam/Flotsam Properties")]
public class FlotsamProperties : PersistentProperties
{
	[Header("General")]
	[Tooltip("Game prefab to use for this flotsam.")]
	public Flotsam FlotsamPrefab;

	[Space]
	[Tooltip("This flotsam is a static object in the world.")]
	public bool Static;

	[Tooltip("Radius to set to target component for this flotsam. (Will be automatically calculated for static objects on their obstacle radius.)")]
	[ConditionalHide("Static", Inverse = true)]
	public float TargetRadius = 1f;

	[Header("Physics")]
	[Tooltip("Physics properties to use for this flotsam.")]
	public PhysicsProperties PhysicsProperties;

	[Header("Visuals")]
	[Tooltip("Visual prefab components for this flotsam.")]
	public List<VisualPrefab> VisualPrefabs = new List<VisualPrefab>();

	[Header("Audio")]
	[Tooltip("Audio properties for this item.")]
	public AudioClipProperties HaulingAudio;

	[Tooltip("Sound for selecting for this item.")]
	public AudioClipProperties SelectionAudio;

	[Header("Transfer")]
	public Activity SalvageActivity = Activity.ItemTaking;

	public int AnimationCycles = 1;

	public override Types Type => Types.FlotsamProperties;

	public VisualPrefab ReturnRandomVisualPrefab(out int index)
	{
		return FlotsamGame.Random(VisualPrefabs, out index);
	}

	public VisualPrefab ReturnVisualPrefab(int index)
	{
		if (-1 < index && index < VisualPrefabs.Count)
		{
			return VisualPrefabs[index];
		}
		return FlotsamGame.Random(VisualPrefabs);
	}

	public Quaternion ReturnVisualPrefabRotation(int index)
	{
		if (-1 < index && index < VisualPrefabs.Count)
		{
			return VisualPrefabs[index].ReturnRandomRotation();
		}
		return Quaternion.identity;
	}
}
