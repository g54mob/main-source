using System.Collections.Generic;
using UnityEngine.Events;

public abstract class BuildableExtendableBase : SceneBehaviour, IBuildableExtendable
{
	private List<PlaceableAlertProperties> _malfunctions = new List<PlaceableAlertProperties>();

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public event UnityAction MalfunctionsUpdated;

	public virtual void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
	}

	public virtual void Activate()
	{
		Active = true;
	}

	public virtual void Deactivate()
	{
		Active = false;
	}

	public virtual bool CanBeDeconstructed()
	{
		return true;
	}

	public virtual bool CanBeSalvaged()
	{
		return true;
	}

	public virtual void Finish(bool restored = false)
	{
	}

	public virtual bool IsEnabled()
	{
		if (base.enabled)
		{
			return Active;
		}
		return false;
	}

	public virtual void OnDeconstruct()
	{
	}

	public virtual void Remove()
	{
	}

	public virtual string ReturnDescription(string text)
	{
		return text;
	}

	public virtual float ReturnWeight()
	{
		return 0f;
	}

	public virtual float ReturnWeightModifier()
	{
		return 1f;
	}

	public virtual void Shutdown()
	{
	}

	public virtual void ShutdownImmediately()
	{
	}

	public virtual void Upgrade(Buildable buildable)
	{
	}

	public void AddMalfunction(PlaceableAlertProperties malfunction)
	{
		if (_malfunctions.AddUnique(malfunction))
		{
			UpdateMalfunctions();
		}
	}

	public void RemoveMalfunction(PlaceableAlertProperties malfunction)
	{
		if (_malfunctions.Remove(malfunction))
		{
			UpdateMalfunctions();
		}
	}

	public void RemoveAllMalfunctions()
	{
		_malfunctions.Clear();
		UpdateMalfunctions();
	}

	protected void UpdateMalfunctions()
	{
		this.MalfunctionsUpdated?.Invoke();
	}

	public virtual void PopulateMalfunctions(List<PlaceableAlertProperties> malfunctions, PlaceableAlertProperties.AlertType minimumAlertType = PlaceableAlertProperties.AlertType.Minor)
	{
		foreach (PlaceableAlertProperties malfunction in _malfunctions)
		{
			if (minimumAlertType <= malfunction.Alert)
			{
				malfunctions.AddUnique(malfunction);
			}
		}
	}

	public virtual IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return null;
	}

	public virtual void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public virtual void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public virtual void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}
}
