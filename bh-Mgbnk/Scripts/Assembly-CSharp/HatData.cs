using System.Collections.Generic;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts._Data.Hats;
using UnityEngine;

[CreateAssetMenu(menuName = "Me/Hat", order = 1)]
public class HatData : UnlockableBase
{
	[Header("Hat Data")]
	public EHat eHat;

	public Texture icon;

	public MyAchievement unlockRequirement;

	public bool useCharacterAltMesh;

	[Header("Hat Render")]
	public Mesh mesh;

	public Material material;

	public List<HatOrientation> orientations;

	public override Texture GetIcon()
	{
		return null;
	}

	public override MyAchievement GetUnlockRequirement()
	{
		return null;
	}

	public override UnlockableBase GetUnlockableRequirement()
	{
		return null;
	}

	public override string GetUnlockableTypeDisplayString()
	{
		return null;
	}

	public override string GetInternalName()
	{
		return null;
	}

	public override int CompareTo(UnlockableBase other)
	{
		return 0;
	}
}
