using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class LandmarkPersistentData : PersistentReference<Landmark>
{
	private int _behaviourIndex;

	private Vector3 _position;

	private Quaternion _rotation;

	private ILandmarkInteractablePersistentData[] _interactables;

	private LandmarkMooringPointPersistentData[] _mooringPoints;

	private LandmarkActionsBehaviourPersistentData _behaviour;

	[NonSerialized]
	private ActionsBehaviour _behaviourInstance;

	public int BehaviourIndex => _behaviourIndex;

	public Vector3 Position => _position;

	public Quaternion Rotation => _rotation;

	public ILandmarkInteractablePersistentData[] Interactables => _interactables;

	public LandmarkMooringPointPersistentData[] MooringPoints => _mooringPoints;

	public LandmarkActionsBehaviourPersistentData Behaviour => _behaviour;

	private LandmarkPersistentData(LandmarkBehaviour landmarkBehaviour)
		: base((landmarkBehaviour == null) ? null : landmarkBehaviour.Landmark)
	{
		if (landmarkBehaviour == null)
		{
			Debug.LogException(new Exception("No landmark behaviour!"));
		}
		_behaviourInstance = landmarkBehaviour as ActionsBehaviour;
		_behaviourIndex = GameManager.PersistenceManager.ReturnPropertiesIndex(landmarkBehaviour.Prefab);
		PopulateBehaviourData(landmarkBehaviour);
		PopulateLandmarkData(landmarkBehaviour.Landmark);
		PopulateInteractables(landmarkBehaviour.Landmark);
		PopulateMooringPoints(landmarkBehaviour.Landmark);
	}

	public void InitializePersistentReference()
	{
		if (-1 < PersistentIndex)
		{
			throw new NotSupportedException("The persistent index is already set and should not be overriden!");
		}
		if ((bool)_behaviourInstance)
		{
			Initialize(_behaviourInstance.Landmark);
		}
	}

	public void PopulateReferences()
	{
		if (_mooringPoints != null)
		{
			LandmarkMooringPointPersistentData[] mooringPoints = _mooringPoints;
			for (int i = 0; i < mooringPoints.Length; i++)
			{
				mooringPoints[i].PopulateReferences();
			}
		}
		if (_behaviour != null)
		{
			_behaviour.PopulateReferences();
		}
	}

	public void RestoreLandmark(LandmarkBehaviour landmarkBehaviour)
	{
		RestoreLandmark(landmarkBehaviour, _position, _rotation);
	}

	public void RestoreLandmark(LandmarkBehaviour landmarkBehaviour, Vector3 position, Quaternion rotation, Transform parent = null)
	{
		base.Instance = landmarkBehaviour.RestoreLandmark(this, position, rotation, parent);
		if (_mooringPoints != null)
		{
			LandmarkMooringPoint[] componentsInChildren = base.Instance.GetComponentsInChildren<LandmarkMooringPoint>();
			LandmarkMooringPointPersistentData[] mooringPoints = _mooringPoints;
			for (int i = 0; i < mooringPoints.Length; i++)
			{
				mooringPoints[i].Restore(componentsInChildren);
			}
		}
	}

	public void RestoreReferences()
	{
		if (_behaviour != null)
		{
			_behaviour.RestoreReferences();
		}
	}

	private void PopulateBehaviourData(LandmarkBehaviour behaviour)
	{
		ActionsBehaviour actionsBehaviour = behaviour as ActionsBehaviour;
		if (!(actionsBehaviour == null) && actionsBehaviour.Actions != null)
		{
			_behaviour = new LandmarkActionsBehaviourPersistentData(actionsBehaviour);
		}
	}

	private void PopulateLandmarkData(Landmark landmark)
	{
		if (!(landmark == null))
		{
			_position = landmark.transform.position;
			_rotation = landmark.transform.rotation;
		}
	}

	private void PopulateInteractables(Landmark landmark)
	{
		if (!(landmark == null))
		{
			List<ILandmarkInteractablePersistentData> list = ListPool<ILandmarkInteractablePersistentData>.Get();
			list.Add(new LandmarkSalvageablePersistentData(landmark));
			list.Add(new LandmarkScavengeablePersistentData(landmark));
			_interactables = list.ToArray();
		}
	}

	private void PopulateMooringPoints(Landmark landmark)
	{
		if (!landmark)
		{
			return;
		}
		using ListPool<LandmarkMooringPoint>.List list = ListPool<LandmarkMooringPoint>.Get();
		using ListPool<LandmarkMooringPointPersistentData>.List list2 = ListPool<LandmarkMooringPointPersistentData>.Get();
		landmark.GetComponentsInChildren(list);
		for (int i = 0; i < list.Count; i++)
		{
			LandmarkMooringPoint landmarkMooringPoint = list[i];
			if ((bool)landmarkMooringPoint && (bool)landmarkMooringPoint.MooredBoat)
			{
				list2.Add(new LandmarkMooringPointPersistentData(landmarkMooringPoint, i));
			}
		}
		_mooringPoints = (list2.IsNullOrEmpty() ? null : list2.ToArray());
	}

	public bool TryReturnLandmarkInteractablePersistentData<T>(out T persistentData) where T : ILandmarkInteractablePersistentData
	{
		persistentData = default(T);
		if (_interactables.IsNullOrEmpty())
		{
			return false;
		}
		ILandmarkInteractablePersistentData[] interactables = _interactables;
		for (int i = 0; i < interactables.Length; i++)
		{
			if (interactables[i] is T val)
			{
				persistentData = val;
				return true;
			}
		}
		return false;
	}

	public static bool TryReturnLandmarkPersistentData(out LandmarkPersistentData data, LandmarkBehaviour landmarkBehaviour)
	{
		if (landmarkBehaviour != null && landmarkBehaviour.RequiresPersistence())
		{
			data = new LandmarkPersistentData(landmarkBehaviour);
			return true;
		}
		data = null;
		return false;
	}
}
