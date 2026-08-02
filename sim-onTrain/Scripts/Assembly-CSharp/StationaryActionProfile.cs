using System;

[Serializable]
public struct StationaryActionProfile
{
	public EasyUpWeaponType weaponType;

	public int movingLayerIndex;

	public int stationaryLayerIndex;

	public string hitTrigger;
}
