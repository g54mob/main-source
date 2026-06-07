using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

namespace Assets.Code.Story.Objectives
{
	public class LandmarkSpawnerBearingUpdater : QuestObjectiveBase
	{
		[SerializeField]
		private WorldMapScoutingId _scoutingIds;

		[SerializeField]
		private BearingFeatures _bearingFeatures;

		[SerializeField]
		[QuestVariable(QuestVariableType.Landmark)]
		private int _landmarkVariable;

		public LandmarkSpawnerBearingUpdater()
		{
		}

		public LandmarkSpawnerBearingUpdater(LandmarkSpawnerBearingUpdater other)
			: base(other)
		{
			_scoutingIds = other._scoutingIds;
			_bearingFeatures = other._bearingFeatures;
			_landmarkVariable = other._landmarkVariable;
		}

		public override void SetActive(bool active)
		{
			base.SetActive(active);
			if (IsCompleted())
			{
				return;
			}
			if (base.Quest.TryGetVariableValue<LandmarkSpawner>(this, _landmarkVariable, out var value))
			{
				foreach (LandmarkSpawner landmark in value.Region.Landmarks)
				{
					if ((landmark.ScoutingId & _scoutingIds) != WorldMapScoutingId.None)
					{
						landmark.SetBearingFeatures(_bearingFeatures);
					}
				}
			}
			SetCompleted(completed: true);
		}

		public override object Clone()
		{
			return new LandmarkSpawnerBearingUpdater(this);
		}
	}
}
