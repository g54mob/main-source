using UnityEngine;

[CreateAssetMenu(fileName = "OverdriveCoal", menuName = "Upgrade/Overdrive/Coal")]
public class UpgradeOverdriveCoal : EnhancementUpgrade
{
	[SerializeField]
	[Range(0f, 1f)]
	private float coalPerSecNormalized = 0.05f;

	private bool isOverdriving;

	public override void ApplyUpgrade()
	{
		ModuleOverdrive moduleByType = Train.Instance.GetModuleByType<ModuleOverdrive>();
		if ((object)moduleByType != null)
		{
			moduleByType.OnOverdriveStart += OnOverdriveStart;
			moduleByType.OnOverdriveEnd += OnOverdriveEnd;
		}
	}

	public override void UpdateUpgrade()
	{
		base.UpdateUpgrade();
		if (isOverdriving)
		{
			Train.Instance.CoalSeconds += Train.Instance.CoalSecondsCapacity * coalPerSecNormalized * Time.deltaTime;
		}
	}

	private void OnOverdriveStart()
	{
		isOverdriving = true;
	}

	private void OnOverdriveEnd()
	{
		isOverdriving = false;
	}

	public override void OnRemove()
	{
		base.OnRemove();
		ModuleOverdrive moduleByType = Train.Instance.GetModuleByType<ModuleOverdrive>();
		if ((object)moduleByType != null)
		{
			moduleByType.OnOverdriveStart -= OnOverdriveStart;
			moduleByType.OnOverdriveEnd -= OnOverdriveEnd;
		}
	}
}
