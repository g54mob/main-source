using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Milestone", menuName = "Milestone/Module Deal Damage/Create New")]
public class MilestoneModuleDealDamage : Milestone
{
	private Module moduleTarget;

	private float moduleStartHealAmount;

	[field: SerializeField]
	[field: Tooltip("If you leave this field empty (Set to None), this milestone will count damage dealt from every module.")]
	public EnhancementModule ModuleSO { get; private set; }

	protected override void OnInitialize()
	{
		base.OnInitialize();
		base.Type = MilestoneTypes.ModuleDealDamage;
		moduleTarget = null;
		if (!(ModuleSO != null))
		{
			return;
		}
		foreach (Module module in Train.Instance.Modules)
		{
			if ((bool)module && module.Enhancement == ModuleSO)
			{
				moduleTarget = module;
				moduleStartHealAmount = moduleTarget.startHealAmount;
				break;
			}
		}
		if (moduleTarget != null)
		{
			CombatManager.Instance.HealthChanged += AddProgress;
		}
		else
		{
			UpgradeManager.Instance.OnAddEnhancementModule += CheckForTargetModule;
		}
	}

	public void AddProgress(HealthChangeInfo info)
	{
		if (!(info.Target == null) && !(info.Target.GetComponent<Unit>() == null) && info.HealthChange != moduleStartHealAmount && info != null && info.source != null && info.source is Object obj && obj != null && (bool)obj.GetComponent<Module>() && obj.GetComponent<Module>().Enhancement == moduleTarget.Enhancement)
		{
			base.Progress += Mathf.Abs(info.HealthChange);
			UpdateProgress();
			if (base.Progress >= Goal)
			{
				Complete();
			}
		}
	}

	public void CountInAllDamageDealt(HealthChangeInfo info)
	{
		if (info.HealthChange != moduleStartHealAmount && info != null && info.source != null && info.source is Object obj && obj != null && (bool)obj.GetComponent<Module>())
		{
			base.Progress += Mathf.Abs(info.HealthChange);
			if (base.Progress >= Goal)
			{
				Complete();
			}
		}
	}

	public void CheckForTargetModule(EnhancementModule newModule)
	{
		if (newModule.ModulePrefab.GetComponent<Module>().Enhancement == ModuleSO)
		{
			moduleTarget = newModule.ModulePrefab.GetComponent<Module>();
			moduleStartHealAmount = moduleTarget.startHealAmount;
			CombatManager.Instance.HealthChanged += AddProgress;
			UpgradeManager.Instance.OnAddEnhancementModule -= CheckForTargetModule;
		}
	}

	public override void Complete()
	{
		if (ModuleSO != null)
		{
			UpgradeManager.Instance.OnAddEnhancementModule -= CheckForTargetModule;
			CombatManager.Instance.HealthChanged -= AddProgress;
		}
		else
		{
			CombatManager.Instance.HealthChanged -= CountInAllDamageDealt;
		}
		base.Complete();
	}
}
