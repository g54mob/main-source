using System;
using UnityEngine;

public class BuildingDeletable : MonoBehaviour, IBuildableExtendable
{
	public bool Active { get; private set; }

	public Buildable Buildable { get; private set; }

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
	}

	public void Finish(bool restored = false)
	{
	}

	public void Remove()
	{
	}

	public void Activate()
	{
		Active = true;
	}

	public void Deactivate()
	{
		Active = false;
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return null;
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

	public void Upgrade(Buildable upgradedBuildable)
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
