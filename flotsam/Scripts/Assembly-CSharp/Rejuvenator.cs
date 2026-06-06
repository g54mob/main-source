using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(Construction))]
public class Rejuvenator : MonoBehaviour, IBuildableExtendable, IPersistentReference
{
	public enum Stage
	{
		Idle = 0,
		Rejuvenating = 1,
		WaitingToStart = 2
	}

	[SerializeField]
	private RejuvenatorProperties _properties;

	[SerializeField]
	[FormerlySerializedAs("Slots")]
	private AttachableSlots _slots;

	public Stage CurrentStage { get; private set; }

	public RejuvenatorProperties Properties => _properties;

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public bool Reserved { get; set; }

	public int PersistentIndex { get; set; } = -1;

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
		Buildable.Community.AddRejuvenator(this);
	}

	public void Finish(bool restored = false)
	{
	}

	public void Remove()
	{
		Buildable.Community.RemoveRejuvenator(this);
	}

	public void AddAgent(Agent agent)
	{
		_slots.Attach(agent.transform);
	}

	public void RemoveAgent(Agent patient, Transform newParent)
	{
		_slots.Detach(patient.transform, newParent);
	}

	public IEnumerator RejuvenateCoroutine(Agent agent)
	{
		float timer = 0f;
		while (GameManager.TimeManager.CurrentDay.DayTime == _properties.Time || timer <= _properties.MinimumTime)
		{
			timer += TimeManager.GetDeltaTime();
			yield return null;
		}
		if (!Buildable.TryReturnBuildableExtendable<ModuleManager>(out var buildableExtendable))
		{
			yield break;
		}
		RejuvenatorProperties.ModuleRejuvenator[] moduleRejuvenators = _properties.ModuleRejuvenators;
		for (int i = 0; i < moduleRejuvenators.Length; i++)
		{
			RejuvenatorProperties.ModuleRejuvenator moduleRejuvenator = moduleRejuvenators[i];
			if (buildableExtendable.IsActiveModule(moduleRejuvenator.Module))
			{
				ApplyModuleRejuvenator(agent, moduleRejuvenator);
			}
		}
	}

	public void SetCurrentStage(Stage stage)
	{
		if (stage != CurrentStage)
		{
			CurrentStage = stage;
			switch (CurrentStage)
			{
			case Stage.Idle:
				Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 0);
				break;
			case Stage.Rejuvenating:
				Buildable.BuildableAnimator.Animator.SetInteger("IsWorking", 1);
				break;
			}
		}
	}

	public bool RejuvenatesVital(VitalType vital)
	{
		return vital == _properties.Vital;
	}

	private void ApplyModuleRejuvenator(Agent agent, RejuvenatorProperties.ModuleRejuvenator moduleRejuvenator)
	{
		if (moduleRejuvenator.Vital == VitalType.Pollution)
		{
			agent.Vitals.Pollution.Decrease(moduleRejuvenator.Module.ModifierValue);
		}
		else
		{
			Debug.LogException(new NotImplementedException());
		}
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public bool CanBeSalvaged()
	{
		return CurrentStage == Stage.Idle;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return new RejuvenatorPersistentData(this);
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void OnDeconstruct()
	{
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public string ReturnDescription(string text)
	{
		return text;
	}

	public float ReturnWeight()
	{
		return 0f;
	}
}
