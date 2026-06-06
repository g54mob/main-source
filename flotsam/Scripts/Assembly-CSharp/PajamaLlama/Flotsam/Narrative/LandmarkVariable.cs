using System;
using UnityEngine;

namespace PajamaLlama.Flotsam.Narrative
{
	[Serializable]
	public class LandmarkVariable : QuestLandmarkVariableBase
	{
		public enum Mode
		{
			FindOrPick = 0,
			FindOnWorldTile = 1
		}

		[SerializeField]
		private LandmarkBehaviourProviderReference _landmark;

		[SerializeField]
		private Mode _mode;

		[SerializeField]
		[ConditionalEnumHide("_mode", 0, true)]
		private bool _tryToFindLandmark = true;

		[Header("Spawning")]
		[SerializeReference]
		[ConditionalEnumHide("_mode", 0, true)]
		[SubclassSelector]
		private ILandmarkPickerSettings _spawnSettings = new LandmarkPicker.Settings();

		[SerializeField]
		[ConditionalEnumHide("_mode", 1, true)]
		[QuestVariable(QuestVariableType.WorldTile)]
		private int _worldTileVariable;

		public LandmarkVariable()
		{
		}

		public LandmarkVariable(LandmarkVariable other)
			: base(other)
		{
			_landmark = other._landmark;
			_mode = other._mode;
			_tryToFindLandmark = other._tryToFindLandmark;
			_spawnSettings = other._spawnSettings;
			_worldTileVariable = other._worldTileVariable;
		}

		public override void SetOwningQuest(Quest owningQuest)
		{
			base.SetOwningQuest(owningQuest);
			_spawnSettings.SetOwningQuest(owningQuest);
		}

		protected override LandmarkSpawner GetLandmarkSpawner()
		{
			switch (_mode)
			{
			case Mode.FindOrPick:
			{
				LandmarkSpawner landmarkSpawner;
				if (_tryToFindLandmark)
				{
					landmarkSpawner = GameManager.WorldManager.World.GetNearestLandmarkOfType(_landmark);
					if (landmarkSpawner != null)
					{
						return landmarkSpawner;
					}
				}
				if (_spawnSettings.Spawn(out landmarkSpawner, _landmark))
				{
					return landmarkSpawner;
				}
				break;
			}
			case Mode.FindOnWorldTile:
			{
				if (!base.OwningQuest.TryGetVariableValue<WorldTile>(_worldTileVariable, out var value))
				{
					break;
				}
				foreach (LandmarkSpawner landmark in value.Landmarks)
				{
					if (_landmark.ReturnIsLandmarkBehaviour(landmark.LandmarkBehaviour))
					{
						return landmark;
					}
				}
				break;
			}
			}
			Debug.LogException(new Exception("Unable to initialize Landmark variable '" + base.Name + "'"));
			return null;
		}

		public override bool ConditionsAreMet(QuestProperties questProperties)
		{
			return _spawnSettings.CanSpawn();
		}

		public override object Clone()
		{
			return new LandmarkVariable(this);
		}
	}
}
