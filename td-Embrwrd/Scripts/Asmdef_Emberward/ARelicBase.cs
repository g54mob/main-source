using UnityEngine;

public abstract class ARelicBase : MonoBehaviour
{
	protected RelicManager manager;

	protected eItemType itemType;

	protected RelicSettingData settingData;

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

	public void Setup(RelicManager manager, eItemType itemType)
	{
	}

	public virtual string ExtraTooltip()
	{
		return null;
	}
}
