using UnityEngine;

public abstract class APerkBase : MonoBehaviour
{
	protected PerkManager manager;

	protected eItemType itemType;

	protected bool doHaveDuration;

	protected int totalDuration;

	protected int currentDuration;

	protected PerkSettingData settingData;

	public eItemType ItemType => default(eItemType);

	public PerkSettingData SettingData => null;

	private void OnEnable()
	{
	}

	protected virtual void OnEnableProc()
	{
	}

	private void OnDisable()
	{
	}

	protected virtual void OnDisableProc()
	{
	}

	public void Setup(PerkManager manager, PerkSettingData settingData)
	{
	}

	protected virtual void AfterSetupProc()
	{
	}

	public virtual string ExtraTooltip()
	{
		return null;
	}

	public bool UpdateDuration()
	{
		return false;
	}

	public int GetDurationLeft()
	{
		return 0;
	}
}
