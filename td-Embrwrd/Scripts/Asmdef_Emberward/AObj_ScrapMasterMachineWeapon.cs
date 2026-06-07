using UnityEngine;

[SelectionBase]
public abstract class AObj_ScrapMasterMachineWeapon : MonoBehaviour
{
	[SerializeField]
	private eScrapMasterSkillType weaponType;

	[SerializeField]
	private bool doShowAimRing;

	protected Obj_ScrapMasterMachine parentMachine;

	protected bool isInControl;

	protected float shootTimer;

	private float overchargeTimer;

	public eScrapMasterSkillType WeaponType => default(eScrapMasterSkillType);

	public bool DoShowAimRing => false;

	protected float OverchargeTimer => 0f;

	public void RegisterParentMachine(Obj_ScrapMasterMachine parentMachine)
	{
	}

	protected virtual void OnControlStateChanged(bool isInControl)
	{
	}

	protected virtual void Update()
	{
	}

	protected virtual void OnControlStateChangedProc(bool isInControl)
	{
	}

	public void Overcharge()
	{
	}

	protected abstract void OverchargeProc();

	protected bool IsOvercharge()
	{
		return false;
	}
}
