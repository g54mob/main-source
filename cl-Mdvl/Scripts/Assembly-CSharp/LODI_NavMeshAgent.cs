using System;
using FIMSpace.FOptimizing;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public sealed class LODI_NavMeshAgent : ILODInstance
{
	internal int index = -1;

	internal string LODName = "";

	[HideInInspector]
	public bool SetDisabled;

	[HideInInspector]
	[SerializeField]
	private bool _Locked;

	[SerializeField]
	[HideInInspector]
	private NavMeshAgent cmp;

	[Space(4f)]
	[Range(0f, 1f)]
	public float Priority = 1f;

	public ObstacleAvoidanceType Quality = ObstacleAvoidanceType.HighQualityObstacleAvoidance;

	public int Index
	{
		get
		{
			return index;
		}
		set
		{
			index = value;
		}
	}

	public string Name
	{
		get
		{
			return LODName;
		}
		set
		{
			LODName = value;
		}
	}

	public bool CustomEditor => false;

	public bool Disable
	{
		get
		{
			return SetDisabled;
		}
		set
		{
			SetDisabled = value;
		}
	}

	public bool DrawDisableOption => true;

	public bool SupportingTransitions => true;

	public bool DrawLowererSlider => false;

	public float QualityLowerer
	{
		get
		{
			return 1f;
		}
		set
		{
			new NotImplementedException();
		}
	}

	public string HeaderText => "NavMeshAgent LOD Settings";

	public float ToCullDelay => 0f;

	public bool SupportVersions => false;

	public int DrawingVersion
	{
		get
		{
			return 1;
		}
		set
		{
			new NotImplementedException();
		}
	}

	public bool LockSettings
	{
		get
		{
			return _Locked;
		}
		set
		{
			_Locked = value;
		}
	}

	public Texture Icon => null;

	public Component TargetComponent => cmp;

	public void SetSameValuesAsComponent(Component component)
	{
		if (component == null)
		{
			Debug.LogError("[Custom OPTIMIZERS] Given component is null instead of NavMeshAgent!");
		}
		NavMeshAgent navMeshAgent = component as NavMeshAgent;
		if (navMeshAgent != null)
		{
			Priority = navMeshAgent.avoidancePriority;
			Quality = navMeshAgent.obstacleAvoidanceType;
			cmp = navMeshAgent;
		}
	}

	public void ApplySettingsToTheComponent(Component component, ILODInstance initialSettingsRef)
	{
		LODI_NavMeshAgent lODI_NavMeshAgent = initialSettingsRef as LODI_NavMeshAgent;
		NavMeshAgent navMeshAgent = component as NavMeshAgent;
		if (lODI_NavMeshAgent == null || navMeshAgent == null)
		{
			Debug.Log("[Custom OPTIMIZERS] Target LOD is not NavMeshAgent LOD or is null");
			return;
		}
		navMeshAgent.avoidancePriority = (int)Mathf.Clamp(lODI_NavMeshAgent.Priority * Priority, 0f, 99f);
		navMeshAgent.obstacleAvoidanceType = Quality;
		FLOD.ApplyEnableDisableState(this, navMeshAgent);
	}

	public void AssignAutoSettingsAsForLODLevel(int lodIndex, int lodCount, Component component)
	{
		if (component as NavMeshAgent == null)
		{
			Debug.LogError("[Custom OPTIMIZERS] Given component for reference values is null or is not NavMeshAgent Component!");
		}
		float num = (Priority = FLOD.GetValueForLODLevel(1f, 0f, lodIndex, lodCount));
		int quality = (int)Quality;
		quality = (int)((float)quality * num);
		Quality = (ObstacleAvoidanceType)quality;
		Name = "LOD" + (lodIndex + 2);
	}

	public void AssignSettingsAsForCulled(Component component)
	{
		FLOD.AssignDefaultCulledParams(this);
		Priority = 0f;
		Quality = ObstacleAvoidanceType.NoObstacleAvoidance;
	}

	public void AssignSettingsAsForNearest(Component component)
	{
		FLOD.AssignDefaultNearestParams(this);
		Priority = 1f;
		Quality = ObstacleAvoidanceType.HighQualityObstacleAvoidance;
	}

	public void AssignSettingsAsForHidden(Component component)
	{
		FLOD.AssignDefaultHiddenParams(this);
		Priority = 0.2f;
		Quality = ObstacleAvoidanceType.LowQualityObstacleAvoidance;
	}

	public ILODInstance GetCopy()
	{
		return MemberwiseClone() as ILODInstance;
	}

	public void InterpolateBetween(ILODInstance lodA, ILODInstance lodB, float transitionToB)
	{
		FLOD.DoBaseInterpolation(this, lodA, lodB, transitionToB);
		LODI_NavMeshAgent lODI_NavMeshAgent = lodA as LODI_NavMeshAgent;
		LODI_NavMeshAgent lODI_NavMeshAgent2 = lodB as LODI_NavMeshAgent;
		Priority = Mathf.Lerp(lODI_NavMeshAgent.Priority, lODI_NavMeshAgent2.Priority, transitionToB);
		ObstacleAvoidanceType quality = lODI_NavMeshAgent.Quality;
		int quality2 = (int)lODI_NavMeshAgent2.Quality;
		int quality3 = (int)Mathf.Lerp((float)quality, quality2, transitionToB);
		Quality = (ObstacleAvoidanceType)quality3;
	}
}
