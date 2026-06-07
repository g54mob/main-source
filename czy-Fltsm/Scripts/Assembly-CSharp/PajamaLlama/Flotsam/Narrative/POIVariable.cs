using System;
using PajamaLlama.Attributes;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class POIVariable : QuestVariableBase
	{
		public enum SpawnMode
		{
			Distance = 0,
			Triangulation = 1
		}

		[Serializable]
		private struct LandmarkBehaviourProviderReferenceArray
		{
			public LandmarkBehaviourProviderReference[] Array;
		}

		[SerializeField]
		private PointOfInterestProperties _poiProperties;

		[SerializeField]
		private SpawnMode _spawnMode;

		[Header("Spawn Settings")]
		[Tooltip("The distance from the town the Point of Interest will be spawned at on the X-Axis.")]
		[SerializeField]
		[ConditionalEnumHide("_spawnMode", 0, true)]
		[Min(0f)]
		private float _distanceX = 1500f;

		[Tooltip("The maximum distance the Point of Interest will be spawned at on the Y-Axis, relative to the town position")]
		[SerializeField]
		[ConditionalEnumHide("_spawnMode", 0, true)]
		[Min(0f)]
		private float _distanceY = 500f;

		[Tooltip("Landmarks used for triangulation.")]
		[SerializeField]
		[ConditionalEnumHide("_spawnMode", 1, true)]
		[Wrapper("Array")]
		private LandmarkBehaviourProviderReferenceArray _landmarks;

		[Tooltip("The radius in which a position will be generated relative to the position generated using Distance X and Distance Y")]
		[SerializeField]
		[Min(0f)]
		private float _radius = 250f;

		[NonSerialized]
		private PointOfInterestSpawner _spawner;

		public override QuestVariableType Type => QuestVariableType.PointOfInterest;

		public POIVariable()
		{
		}

		private POIVariable(POIVariable other)
			: base(other)
		{
			_poiProperties = other._poiProperties;
			_spawnMode = other._spawnMode;
			_distanceX = other._distanceX;
			_distanceY = other._distanceY;
			_landmarks = other._landmarks;
			_radius = other._radius;
		}

		public override object Clone()
		{
			return new POIVariable(this);
		}

		public override bool Initialize()
		{
			global::World world = GameManager.WorldManager.World;
			_spawner = world.GetNearestPOIOfType(_poiProperties);
			if (_spawner != null)
			{
				return true;
			}
			switch (_spawnMode)
			{
			case SpawnMode.Distance:
				return world.TrySpawnPointOfInterest(out _spawner, _poiProperties, _distanceX, _distanceY);
			case SpawnMode.Triangulation:
			{
				Vector3 zero = Vector3.zero;
				int num = 0;
				LandmarkBehaviourProviderReference[] array = _landmarks.Array;
				foreach (LandmarkBehaviourProviderReference landmarkBehaviourProviderReference in array)
				{
					if (TryGetLandmarkSpawner(out var landmarkSpawner, landmarkBehaviourProviderReference))
					{
						zero += landmarkSpawner.WorldPosition;
						num++;
					}
					else
					{
						Debug.LogException(new Exception($"Unable to find '{landmarkBehaviourProviderReference}' for POI triangulation"));
					}
				}
				if (0 < num)
				{
					return world.TrySpawnPointOfInterest(out _spawner, _poiProperties, zero / num);
				}
				return false;
			}
			default:
				Debug.LogException(new NotImplementedException());
				return false;
			}
		}

		public override bool Validate()
		{
			if (IsReferencedByActiveObjective())
			{
				if (_spawner != null)
				{
					return _spawner.WorldTile.IsActive;
				}
				return false;
			}
			return true;
		}

		protected override T Get<T>()
		{
			if (_spawner == null)
			{
				Initialize();
			}
			PointOfInterestSpawner spawner = _spawner;
			if (spawner is T)
			{
				return (T)(object)((spawner is T) ? spawner : null);
			}
			PointOfInterestProperties poiProperties = _poiProperties;
			if (poiProperties is T)
			{
				return (T)(object)((poiProperties is T) ? poiProperties : null);
			}
			return default(T);
		}

		public override bool ConditionsAreMet(QuestProperties questProperties)
		{
			if (_spawner == null)
			{
				Debug.LogError($"POI variable conditions for quest '{questProperties}' are not met, POI spawner is NULL!");
				return false;
			}
			return true;
		}

		private bool TryGetLandmarkSpawner(out LandmarkSpawner landmarkSpawner, LandmarkBehaviourProviderReference landmarkBehaviourReference)
		{
			landmarkSpawner = GameManager.WorldManager.World.GetNearestLandmarkOfType(landmarkBehaviourReference);
			return landmarkSpawner != null;
		}

		public override bool TryGetPersistentData(out IPersistentData persistentData)
		{
			persistentData = null;
			return false;
		}

		public override bool TryRestorePersistentData(IPersistentData persistentData)
		{
			return false;
		}
	}
}
