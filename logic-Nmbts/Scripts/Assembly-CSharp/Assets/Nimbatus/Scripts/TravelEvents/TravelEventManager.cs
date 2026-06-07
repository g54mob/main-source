using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.DroneSelection.Scripts;
using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.Scripts.TravelEvents
{
	public class TravelEventManager : SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>
	{
		public class SequenceOrganiser
		{
			public List<TravelEventIntroduction> Sequence;

			public int Index;
		}

		[HideInInspector]
		public List<TravelEvent> TravelEvents = new List<TravelEvent>();

		[HideInInspector]
		public EMissionType ActiveMission;

		private readonly List<SequenceOrganiser> _activeSequences = new List<SequenceOrganiser>();

		private int _activeSequenceIndex;

		[HideInInspector]
		public List<BaseReceivable> Consequences;

		[HideInInspector]
		public List<BaseReceivable> MissionRewards;

		[HideInInspector]
		public List<BaseReceivable> MissionPenalties;

		[HideInInspector]
		public bool MissionCompleted;

		private int _timesSinceLastEvent;

		public TravelEvent ActiveEvent { get; private set; }

		[HideInInspector]
		public TravelEventIntroduction ActiveIntro
		{
			get
			{
				return _activeSequences[_activeSequenceIndex].Sequence[_activeSequences[_activeSequenceIndex].Index];
			}
		}

		internal override string Filename
		{
			get
			{
				return "TravelEventManager.xml";
			}
		}

		public void SetMissionCompleted()
		{
			if (ActiveMission != EMissionType.None && MissionRewards != null)
			{
				MissionRewards.ForEach(delegate(BaseReceivable r)
				{
					r.HandleReward();
				});
				MissionCompleted = true;
			}
		}

		public void SetMissionFailed()
		{
			if (ActiveMission != EMissionType.None && MissionPenalties != null)
			{
				MissionPenalties.ForEach(delegate(BaseReceivable r)
				{
					r.HandleReward();
				});
			}
		}

		public TravelEvent GetTravelEvent()
		{
			TravelEvent travelEventInternal = GetTravelEventInternal();
			_timesSinceLastEvent = ((travelEventInternal == null) ? (_timesSinceLastEvent + 1) : 0);
			return travelEventInternal;
		}

		internal TravelEvent GetTravelEventInternal()
		{
			if (RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				if (!(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel >= 80f))
				{
					return null;
				}
				return GetTravelEventOfType(ETravelEventType.CorpDamage);
			}
			PlanetLocationData planetLocationData;
			if ((planetLocationData = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.TargetLocation as PlanetLocationData) != null && planetLocationData.IsEndPlanet && !planetLocationData.IntroEventSeen)
			{
				planetLocationData.IntroEventSeen = true;
				return GetTravelEventOfType(ETravelEventType.FinalPlanet);
			}
			float threat = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel;
			if (RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat)
			{
				TravelEvent travelEventOfType = GetTravelEventOfType(ETravelEventType.CorpDamage);
				if (travelEventOfType == null)
				{
					throw new Exception("There is no corp damage event");
				}
				if (UnityEngine.Random.Range(float.Epsilon, 1f) <= travelEventOfType.ProbabilityByThreatLevel.Evaluate(threat))
				{
					return travelEventOfType;
				}
			}
			if (UnityEngine.Random.Range(0f, 16f) >= Mathf.Pow((float)_timesSinceLastEvent + 0.4f, 2f))
			{
				return null;
			}
			return TravelEvents.Where((TravelEvent t) => t.IsAllowed()).ToList().RandomItemProbability((TravelEvent e) => e.ProbabilityByThreatLevel.Evaluate(threat), new System.Random());
		}

		public TravelEvent GetTravelEventOfType(ETravelEventType type)
		{
			return TravelEvents.FirstOrDefault((TravelEvent e) => e.EventType == type);
		}

		public void StartTravelEvent(ETravelEventType eventType)
		{
			ActiveEvent = GetTravelEventOfType(eventType);
			if (ActiveEvent != null)
			{
				if (ActiveEvent.ResetRemainingThreatIncrease)
				{
					TravelManager.ThreatIncrease = 0f;
				}
				System.Random rng = new System.Random();
				_activeSequenceIndex = 0;
				_activeSequences.Clear();
				_activeSequences.Add(new SequenceOrganiser
				{
					Sequence = ActiveEvent.PossibleIntroSequences.RandomItemProbability((TravelEvent.IntroProbability s) => s.Probability, rng).Sequence
				});
			}
		}

		public void ResetTravelEvent()
		{
			ActiveEvent = null;
		}

		public bool NextIntro(bool positiveResult = true)
		{
			if (ActiveIntro.Type == ETravelEventIntroduction.Choice)
			{
				_activeSequences.Add(new SequenceOrganiser
				{
					Sequence = (positiveResult ? ActiveIntro.SubsequenceGood : ActiveIntro.SubsequenceBad)
				});
				_activeSequenceIndex++;
				return true;
			}
			if (_activeSequences[_activeSequenceIndex].Index < _activeSequences[_activeSequenceIndex].Sequence.Count - 1)
			{
				_activeSequences[_activeSequenceIndex].Index++;
				return true;
			}
			if (_activeSequenceIndex > 0)
			{
				_activeSequences.Remove(_activeSequences[_activeSequences.Count - 1]);
				_activeSequenceIndex--;
				if (_activeSequences[_activeSequenceIndex].Index < _activeSequences[_activeSequenceIndex].Sequence.Count - 1)
				{
					_activeSequences[_activeSequenceIndex].Index++;
					return true;
				}
			}
			return false;
		}

		public void ApplyEndAnimation()
		{
			TravelManager.OverrideOutroSpeed = ActiveIntro.OutroSpeedMultiplier;
			if (ActiveIntro.OverrideEndAnimation)
			{
				TravelManager.OverrideEndAnimation = ActiveIntro.EndAnimation;
				TravelManager.OverrideEndAnimationNimbatusSpeed = ActiveIntro.EndAnimationNimbatusSpeed;
				TravelManager.OverrideEndAnimationParticleSpeed = ActiveIntro.EndAnimationParticleSpeed;
			}
		}

		public void HandleConsequences()
		{
			if (Consequences == null)
			{
				Consequences = new List<BaseReceivable>();
			}
			else
			{
				Consequences.Clear();
			}
			System.Random random = new System.Random();
			bool flag = false;
			foreach (TravelEventConsequence consequence in ActiveIntro.Consequences)
			{
				BaseReceivable baseReceivable = consequence.CreateReward(random.Next());
				if (ReceivableHelper.IsAllowed(baseReceivable))
				{
					Consequences.Add(baseReceivable);
				}
				else
				{
					flag = true;
				}
			}
			if (flag && ActiveIntro.HasFallbackConsequences)
			{
				foreach (TravelEventConsequence fallbackConsequence in ActiveIntro.FallbackConsequences)
				{
					BaseReceivable baseReceivable2 = fallbackConsequence.CreateReward(random.Next());
					if (ReceivableHelper.IsAllowed(baseReceivable2))
					{
						Consequences.Add(baseReceivable2);
					}
				}
			}
			if (ActiveEvent.EventType == ETravelEventType.CorpDamage || ActiveEvent.EventType == ETravelEventType.LocationDamage)
			{
				Consequences.Add(new ThreatReceivable
				{
					Amount = 0f - SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel * 0.4f
				});
			}
			foreach (BaseReceivable consequence2 in Consequences)
			{
				consequence2.HandleReward();
			}
		}

		public void LoadMission()
		{
			if (ActiveEvent.HasMission)
			{
				System.Random randomGenerator = new System.Random();
				TravelEvent.TravelEventMissionSettings missionSettings = ActiveEvent.MissionSettings;
				InitMission(randomGenerator, missionSettings.Mission);
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.SetDroneSettings(missionSettings.DroneSettings.Settings);
				SerializableMonobehaviour<MissionManager, MissionData>.Instance.ClearLocalMissions();
				SerializableMonobehaviour<MissionManager, MissionData>.Instance.StartLocalMission(missionSettings.Mission, false);
				NimbatusSceneManager.BookmarkActiveScene();
				DroneSelectionManager.HideLaunchButton = false;
				DroneSelectionManager.HideBackButton = true;
				NimbatusSceneManager.SetReturnScene("DroneHangarScene", SceneManager.GetActiveScene().name);
				NimbatusSceneManager.LoadScene("DroneHangarScene");
			}
		}

		private void InitMission(System.Random randomGenerator, EMissionType missionType)
		{
			MissionCompleted = false;
			ActiveMission = missionType;
			NimbatusMission mission = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetMission(ActiveMission);
			if (ActiveMission == EMissionType.None || !(mission != null) || mission.NoRewards)
			{
				return;
			}
			MissionRewards = new List<BaseReceivable>();
			for (int i = 0; i < 3; i++)
			{
				MissionRewards.Add(SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomReward(randomGenerator.Next(), randomGenerator.Next(), ActiveMission));
			}
			MissionPenalties = new List<BaseReceivable>();
			for (int j = 0; j < 1; j++)
			{
				BaseReceivable randomPenalty = SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomPenalty(randomGenerator.Next(), ActiveMission);
				if (randomPenalty != null)
				{
					MissionPenalties.Add(randomPenalty);
				}
			}
		}

		public void LoadScene()
		{
			NimbatusSceneManager.LoadScene(ActiveEvent.MissionSettings.SceneName);
		}

		protected override void PreLoad()
		{
			TravelEvents = Resources.LoadAll<TravelEvent>("8_TravelEvents").ToList();
		}

		protected override void LoadFromFile(TravelEventManagerSaveData data)
		{
			_timesSinceLastEvent = data.TimesSinceLastEvent;
		}

		protected override TravelEventManagerSaveData SaveToFile()
		{
			return new TravelEventManagerSaveData
			{
				TimesSinceLastEvent = _timesSinceLastEvent
			};
		}
	}
}
