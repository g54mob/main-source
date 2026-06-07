using System;

[Serializable]
public class MstSoundGroupEntities
{
	public eSoundGroupId id;

	public eSoundGroupCategory category;

	public string groupName;

	public bool isHDR;

	public bool is3D;

	public int hdrRatio;

	public int attackTime;

	public int holdTime;

	public int releaseTime;

	public float delay;

	public bool allowDuplicate;
}
