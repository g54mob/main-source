using System;
using PajamaLlama.Flotsam.World;
using UnityEngine;

[Serializable]
public struct LandmarkBehaviourProviderReference : ILandmarkBehaviourProvider
{
	public enum Type
	{
		LandmarkBehaviour = 0,
		LandmarkBehaviourCollection = 1
	}

	[SerializeField]
	private Type _type;

	[SerializeField]
	[ConditionalEnumHide("_type", 0, true)]
	private LandmarkBehaviour _landmarkBehaviour;

	[SerializeField]
	[ConditionalEnumHide("_type", 1, true)]
	private LandmarkBehaviourCollection _landmarkBehaviourCollection;

	public string Name
	{
		get
		{
			if (!TryGet(out var landmarkBehaviourProvider))
			{
				return "NULL";
			}
			return landmarkBehaviourProvider.Name;
		}
	}

	public string EditorName
	{
		get
		{
			if (!TryGet(out var landmarkBehaviourProvider))
			{
				return "NULL";
			}
			return landmarkBehaviourProvider.EditorName;
		}
	}

	public Sprite EditorIcon
	{
		get
		{
			if (!TryGet(out var landmarkBehaviourProvider))
			{
				return null;
			}
			return landmarkBehaviourProvider.EditorIcon;
		}
	}

	public float Radius
	{
		get
		{
			if (!TryGet(out var landmarkBehaviourProvider))
			{
				return 0f;
			}
			return landmarkBehaviourProvider.Radius;
		}
	}

	public LandmarkBehaviour ReturnLandmarkBehaviour(WorldRegionType region)
	{
		if (!TryGet(out var landmarkBehaviourProvider))
		{
			return null;
		}
		return landmarkBehaviourProvider.ReturnLandmarkBehaviour(region);
	}

	public MooringPointBase[] ReturnMooringPoints()
	{
		if (!TryGet(out var landmarkBehaviourProvider))
		{
			return null;
		}
		return landmarkBehaviourProvider.ReturnMooringPoints();
	}

	public bool ReturnIsInteractable()
	{
		if (!TryGet(out var landmarkBehaviourProvider))
		{
			return false;
		}
		return landmarkBehaviourProvider.ReturnIsInteractable();
	}

	public bool ReturnHasLandmarkActionReference<T>() where T : LandmarkAction
	{
		if (!TryGet(out var landmarkBehaviourProvider))
		{
			return false;
		}
		return landmarkBehaviourProvider.ReturnHasLandmarkActionReference<T>();
	}

	public bool ReturnIsLandmarkBehaviour(LandmarkBehaviour behaviour)
	{
		if (!TryGet(out var landmarkBehaviourProvider))
		{
			return false;
		}
		return landmarkBehaviourProvider.ReturnIsLandmarkBehaviour(behaviour);
	}

	public override string ToString()
	{
		switch (_type)
		{
		case Type.LandmarkBehaviour:
			if (!_landmarkBehaviour)
			{
				return "NULL";
			}
			return _landmarkBehaviour.name;
		case Type.LandmarkBehaviourCollection:
			if (!_landmarkBehaviourCollection)
			{
				return "NULL";
			}
			return _landmarkBehaviourCollection.name;
		default:
			Debug.LogException(new NotImplementedException());
			return "NULL";
		}
	}

	private bool TryGet(out ILandmarkBehaviourProvider landmarkBehaviourProvider)
	{
		landmarkBehaviourProvider = null;
		switch (_type)
		{
		case Type.LandmarkBehaviour:
			landmarkBehaviourProvider = _landmarkBehaviour;
			break;
		case Type.LandmarkBehaviourCollection:
			landmarkBehaviourProvider = _landmarkBehaviourCollection;
			break;
		}
		return landmarkBehaviourProvider != null;
	}
}
