using System;
using System.Collections.Generic;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Landmarks/LandmarkBehaviourCollection")]
public class LandmarkBehaviourCollection : ScriptableObject, ILandmarkBehaviourProvider
{
	[SerializeField]
	private LandmarkBehaviour[] _landmarkBehaviours;

	[SerializeField]
	private Sprite _editorIcon;

	private readonly List<LandmarkBehaviour> _behavioursToDistribute = new List<LandmarkBehaviour>();

	public string Name => base.name;

	public string EditorName => base.name + " [Collection]";

	public Sprite EditorIcon => _editorIcon;

	public float Radius { get; private set; }

	private void OnEnable()
	{
		UpdateRadius();
	}

	public LandmarkBehaviour ReturnRandom()
	{
		return _landmarkBehaviours[UnityEngine.Random.Range(0, _landmarkBehaviours.Length)];
	}

	public LandmarkBehaviour ReturnNext()
	{
		if (_behavioursToDistribute.Count == 0)
		{
			for (int i = 0; i < _landmarkBehaviours.Length; i++)
			{
				_behavioursToDistribute.Add(_landmarkBehaviours[i]);
			}
		}
		int index = UnityEngine.Random.Range(0, _behavioursToDistribute.Count);
		LandmarkBehaviour result = _behavioursToDistribute[index];
		_behavioursToDistribute.RemoveAt(index);
		return result;
	}

	public LandmarkBehaviour ReturnLandmarkBehaviour(WorldRegionType region)
	{
		if (!Application.isPlaying)
		{
			return _landmarkBehaviours[0];
		}
		return ReturnNext();
	}

	public MooringPointBase[] ReturnMooringPoints()
	{
		throw new NotImplementedException();
	}

	public bool ReturnIsInteractable()
	{
		LandmarkBehaviour[] landmarkBehaviours = _landmarkBehaviours;
		for (int i = 0; i < landmarkBehaviours.Length; i++)
		{
			if (landmarkBehaviours[i].ReturnIsInteractable())
			{
				return true;
			}
		}
		return false;
	}

	public bool ReturnHasLandmarkActionReference<T>() where T : LandmarkAction
	{
		LandmarkBehaviour[] landmarkBehaviours = _landmarkBehaviours;
		for (int i = 0; i < landmarkBehaviours.Length; i++)
		{
			if (landmarkBehaviours[i].ReturnHasLandmarkActionReference<T>())
			{
				return true;
			}
		}
		return false;
	}

	private void UpdateRadius()
	{
		using ListPool<Vector2>.List list = ListPool<Vector2>.Get();
		Radius = 0f;
		LandmarkBehaviour[] landmarkBehaviours = _landmarkBehaviours;
		foreach (LandmarkBehaviour landmarkBehaviour in landmarkBehaviours)
		{
			if ((bool)landmarkBehaviour)
			{
				landmarkBehaviour.ReturnLandmarkPrefabPolygon().PopulateVertices(list);
			}
		}
		foreach (Vector2 item in list)
		{
			if (Radius < item.magnitude)
			{
				Radius = item.magnitude;
			}
		}
	}

	public bool ReturnIsLandmarkBehaviour(LandmarkBehaviour behaviour)
	{
		if (behaviour == null)
		{
			return false;
		}
		LandmarkBehaviour[] landmarkBehaviours = _landmarkBehaviours;
		foreach (LandmarkBehaviour landmarkBehaviour in landmarkBehaviours)
		{
			if (behaviour.LandmarkPrefabGameObject == landmarkBehaviour.LandmarkPrefabGameObject)
			{
				return true;
			}
		}
		return false;
	}
}
