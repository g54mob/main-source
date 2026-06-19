using System.Collections.Generic;
using Aggro.Core;
using Unity.Collections;
using UnityEngine;

public class DyingBehaviour : EntityBehaviourBase
{
	private List<IDyingBehaviour> _dyings = new List<IDyingBehaviour>();

	private List<IDyingBehaviour> _stillDying = new List<IDyingBehaviour>();

	private DeathContext _context;

	private void Awake()
	{
		GetComponentsInChildren(_dyings);
	}

	public void StartDying(DeathContext context)
	{
		_stillDying.Clear();
		_context = context;
		_stillDying.AddRangeNoGarbage(_dyings);
		for (int i = 0; i < _dyings.Count; i++)
		{
			_dyings[i].StartDying(context);
		}
	}

	public void UpdateDying()
	{
		for (int i = 0; i < _stillDying.Count; i++)
		{
			IDyingBehaviour dyingBehaviour = _stillDying[i];
			if (!((MonoBehaviour)dyingBehaviour).isActiveAndEnabled)
			{
				dyingBehaviour.UpdateDying(_context);
			}
		}
	}

	public bool IsDoneDying()
	{
		for (int i = 0; i < _stillDying.Count; i++)
		{
			IDyingBehaviour dyingBehaviour = _stillDying[i];
			if (!((MonoBehaviour)dyingBehaviour).isActiveAndEnabled || dyingBehaviour.IsDoneDying(_context))
			{
				_stillDying.RemoveAtSwapBack(i--);
			}
		}
		if (_stillDying.Count > 0)
		{
			return false;
		}
		for (int j = 0; j < _dyings.Count; j++)
		{
			_dyings[j].FinishedDying(_context);
		}
		return true;
	}
}
