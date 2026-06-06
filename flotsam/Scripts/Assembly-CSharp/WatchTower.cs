using System;
using System.Collections.Generic;
using UnityEngine;

public class WatchTower : SceneBehaviour, IBuildableExtendable, IPersistentReference
{
	private static List<WatchTower> _instances;

	public int PersistentIndex { get; set; }

	public Buildable Buildable { get; private set; }

	public bool Active { get; private set; }

	public static bool Enabled
	{
		get
		{
			if (_instances == null)
			{
				return false;
			}
			foreach (WatchTower instance in _instances)
			{
				if (instance.IsEnabled())
				{
					return true;
				}
			}
			return false;
		}
	}

	public void Initialize(Buildable buildable, bool restored = false)
	{
		Buildable = buildable;
	}

	private void OnDestroy()
	{
		if (_instances != null)
		{
			_instances.Remove(this);
		}
	}

	public void Activate()
	{
		Active = true;
		if (_instances == null)
		{
			_instances = new List<WatchTower>();
		}
		_instances.AddUnique(this);
	}

	public void Deactivate()
	{
		Active = false;
		if (_instances != null)
		{
			_instances.Remove(this);
		}
	}

	public bool CanBeDeconstructed()
	{
		return true;
	}

	public void Upgrade(Buildable buildable)
	{
	}

	public bool CanBeSalvaged()
	{
		return true;
	}

	public void Finish(bool restored = false)
	{
	}

	public bool IsEnabled()
	{
		if (Active)
		{
			return Buildable.BuildPhase == BuildPhase.Finished;
		}
		return false;
	}

	public void OnDeconstruct()
	{
	}

	public void PopulateReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void Remove()
	{
	}

	public void Restore(IBuildableExtendablePersistentData persistentData)
	{
	}

	public void RestoreReferences(IBuildableExtendablePersistentData persistentData)
	{
	}

	public IBuildableExtendablePersistentData ReturnPersistentData()
	{
		return null;
	}

	public void ShowResearchInfo(RectTransform parent)
	{
	}

	public void Shutdown()
	{
		Deactivate();
	}

	public void ShutdownImmediately()
	{
		throw new NotImplementedException();
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
