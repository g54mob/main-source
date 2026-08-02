using UnityEngine;

public class WeaponModel : MonoBehaviour
{
	public CollectableItemData data;

	public EasyUpWeaponType weaponType;

	public EquipType equipAnimationType;

	public HoldType holdType;

	public bool useLeftHandIK = true;

	public bool useTpsRig = true;

	public Transform holdPoint;
}
