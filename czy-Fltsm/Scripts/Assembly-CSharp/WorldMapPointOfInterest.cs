using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WorldMapPointOfInterest : MonoBehaviour
{
	private List<int> _deactivatedChildIndices;

	public ISpawner Spawner { get; protected set; }

	public bool IsActive { get; private set; }

	protected virtual void OnDestroy()
	{
		Spawner.UpdatedEvent.RemoveListener(OnSpawnerUpdated);
	}

	protected void Initialize(ISpawner spawner)
	{
		Spawner = spawner;
		if (Spawner.ScoutingState == ScoutingState.Scouted)
		{
			Activate();
			return;
		}
		Spawner.UpdatedEvent.AddListener(OnSpawnerUpdated);
		Deactivate();
	}

	protected virtual void OnSpawnerUpdated(ISpawner spawner)
	{
		if (!IsActive && Spawner.ScoutingState == ScoutingState.Scouted)
		{
			Activate();
		}
	}

	protected virtual void Activate()
	{
		if (_deactivatedChildIndices != null)
		{
			foreach (int deactivatedChildIndex in _deactivatedChildIndices)
			{
				base.transform.GetChild(deactivatedChildIndex).gameObject.SetActive(value: true);
			}
			_deactivatedChildIndices.Clear();
		}
		Spawner.UpdatedEvent.RemoveListener(OnSpawnerUpdated);
		IsActive = true;
	}

	private void Deactivate()
	{
		if (_deactivatedChildIndices == null)
		{
			_deactivatedChildIndices = new List<int>(3);
		}
		int childCount = base.transform.childCount;
		for (int i = 0; i < childCount; i++)
		{
			GameObject gameObject = base.transform.GetChild(i).gameObject;
			if (gameObject.activeSelf)
			{
				gameObject.SetActive(value: false);
				_deactivatedChildIndices.Add(i);
			}
		}
		IsActive = false;
	}

	public abstract bool InitializeReveal();

	public abstract IEnumerator RevealRoutine();
}
