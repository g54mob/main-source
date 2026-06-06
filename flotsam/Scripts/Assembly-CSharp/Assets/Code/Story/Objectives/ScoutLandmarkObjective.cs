using System;
using PajamaLlama.Flotsam.Narrative;
using UnityEngine;

namespace Assets.Code.Story.Objectives
{
	[Serializable]
	public class ScoutLandmarkObjective : QuestObjectiveBase
	{
		[SerializeField]
		[QuestVariable(QuestVariableType.Landmark)]
		private int _landmarkVariable;

		[SerializeField]
		private SpawnerObjectiveBearing _landmarkObjectiveBearing;

		[NonSerialized]
		private LandmarkSpawner _landmark;

		public ScoutLandmarkObjective()
		{
		}

		private ScoutLandmarkObjective(ScoutLandmarkObjective other)
			: base(other)
		{
			_landmarkVariable = other._landmarkVariable;
		}

		public override void Initialize()
		{
			if (base.Quest.TryGetVariableValue<LandmarkSpawner>(this, _landmarkVariable, out _landmark))
			{
				if (_landmark.ScoutingState == ScoutingState.Scouted)
				{
					SetCompleted(completed: true);
				}
				else
				{
					_landmark.UpdatedEvent.AddListener(OnLandmarkUpdated);
				}
			}
			else
			{
				Debug.LogException(new Exception("Unable to initialize ScoutLandmarkObjective"));
				SetCompleted(completed: true);
			}
		}

		public override void Uninitialize()
		{
			_landmark?.UpdatedEvent.RemoveListener(OnLandmarkUpdated);
		}

		public override object Clone()
		{
			return new ScoutLandmarkObjective(this);
		}

		private void OnLandmarkUpdated(ISpawner spawner)
		{
			if (spawner.ScoutingState == ScoutingState.Scouted)
			{
				SetCompleted(completed: true);
			}
		}
	}
}
