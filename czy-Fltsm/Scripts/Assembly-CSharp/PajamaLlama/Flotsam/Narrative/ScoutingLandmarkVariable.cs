using System;
using PajamaLlama.Flotsam.World;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class ScoutingLandmarkVariable : QuestLandmarkVariableBase
	{
		public enum Mode
		{
			SpecificLandmark = 0,
			RegionType = 1,
			CurrentRegion = 2,
			LandmarkVariableRegion = 3
		}

		[SerializeField]
		private Mode _mode;

		[SerializeField]
		[ConditionalEnumHide("_mode", 0, true)]
		private LandmarkBehaviourProviderReference _specificLandmark;

		[SerializeField]
		[ConditionalEnumHide("_mode", 1, true)]
		private WorldRegionType _regionType;

		[SerializeField]
		[ConditionalEnumHide("_mode", 3, true)]
		[QuestVariable(QuestVariableType.Landmark)]
		private int _landmarkVariable;

		[NonSerialized]
		private LandmarkSpawner _scoutingLandmark;

		[NonSerialized]
		private float _distanceToScoutingLandmark;

		public ScoutingLandmarkVariable()
		{
		}

		public ScoutingLandmarkVariable(ScoutingLandmarkVariable other)
			: base(other)
		{
			_mode = other._mode;
			_specificLandmark = other._specificLandmark;
			_regionType = other._regionType;
			_landmarkVariable = other._landmarkVariable;
		}

		protected override LandmarkSpawner GetLandmarkSpawner()
		{
			Vector3 townheartWorldPosition = GameManager.WorldManager.World.TownheartWorldPosition;
			IWorldRegion currentRegion = GameManager.WorldManager.CurrentRegion;
			_scoutingLandmark = null;
			_distanceToScoutingLandmark = float.MaxValue;
			switch (_mode)
			{
			case Mode.SpecificLandmark:
				InitializeSpecificLandmark(_specificLandmark, townheartWorldPosition, currentRegion);
				break;
			case Mode.RegionType:
				InitializeRegionType(_regionType, townheartWorldPosition, currentRegion);
				break;
			case Mode.CurrentRegion:
				InitializeCurrentRegion(currentRegion);
				break;
			case Mode.LandmarkVariableRegion:
				base.OwningQuest.GetVariableValue<LandmarkSpawner>(_landmarkVariable)?.Region.TryReturnScoutingLandmark(out _scoutingLandmark);
				break;
			}
			return _scoutingLandmark;
		}

		private void InitializeSpecificLandmark(ILandmarkBehaviourProvider specificLandmark, Vector3 townheartPosition, IWorldRegion currentRegion)
		{
			using ListPool<LandmarkSpawner>.List list = ListPool<LandmarkSpawner>.Get();
			GameManager.WorldManager.World.GetAllScoutingLandmarks(list);
			foreach (LandmarkSpawner item in list)
			{
				if (specificLandmark == null || specificLandmark.ReturnIsLandmarkBehaviour(item.LandmarkBehaviour))
				{
					TrySetTargetLandmark(item, townheartPosition, currentRegion);
				}
			}
		}

		private void InitializeRegionType(WorldRegionType regionType, Vector3 townheartPosition, IWorldRegion currentRegion)
		{
			using ListPool<LandmarkSpawner>.List list = ListPool<LandmarkSpawner>.Get();
			GameManager.WorldManager.World.GetAllScoutingLandmarks(list);
			foreach (LandmarkSpawner item in list)
			{
				if (item.RegionType == regionType)
				{
					TrySetTargetLandmark(item, townheartPosition, currentRegion);
				}
			}
		}

		private void InitializeCurrentRegion(IWorldRegion currentRegion)
		{
			currentRegion.TryReturnScoutingLandmark(out _scoutingLandmark);
		}

		private bool TrySetTargetLandmark(LandmarkSpawner landmark, Vector3 townheartPosition, IWorldRegion currentRegion)
		{
			Vector3 vector = landmark.WorldPosition - townheartPosition;
			if (vector.x < 0f && landmark.Region != currentRegion)
			{
				return false;
			}
			float sqrMagnitude = vector.sqrMagnitude;
			if (sqrMagnitude < _distanceToScoutingLandmark)
			{
				_distanceToScoutingLandmark = sqrMagnitude;
				_scoutingLandmark = landmark;
				return true;
			}
			return false;
		}

		public override bool ConditionsAreMet(QuestProperties questProperties)
		{
			Debug.LogException(new NotImplementedException());
			return true;
		}

		public override object Clone()
		{
			return new ScoutingLandmarkVariable(this);
		}
	}
}
