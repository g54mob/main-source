using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Assets.Nimbatus.GUI.MissionControl.Scripts.Main;
using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Campaign;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Missions.Rewards;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.World.Terrain.ClimateZone;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Assets.Nimbatus.Scripts.WorldObjects.DronePerks;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using Sirenix.Utilities;
using Spine;
using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.GUI.EndOfGalaxy.Scripts
{
	public class EndOfGalaxyUi : MonoBehaviour
	{
		private enum EAnimationState
		{
			Approaching = 0,
			Waiting = 1
		}

		public NimbatusHealthDisplay HealthDisplay;

		public ThreatLevelDisplay ThreatDisplay;

		public UILabel DescriptionLabel;

		public TweenAlpha RewardsBlackout;

		public UIGrid RewardsGrid;

		public UIGrid RewardsGridMiddle;

		public SelectableReward RewardPrefab;

		public SelectableReward GuaranteedRewardPrefab;

		public RewardIcon RewardIconPrefab;

		public RewardIcon GuaranteedRewardIconPrefab;

		public UIButton ContinueButton;

		public string RewardSound;

		public ThreatLevelDisplay SecondaryThreatDisplay;

		[Header("Animation")]
		public SkeletonAnimation SkeletonAnimation;

		public NimbatusSpeedAnimation NimbatusSpeedAnimation;

		private bool _inTutorial;

		private bool _rewardSelectable;

		private LocationData _location;

		private List<SelectableReward> _selectableRewardsList;

		private EAnimationState _animationState;

		internal SelectableReward SelectedReward { get; private set; }

		internal SelectableReward GuaranteedReward { get; private set; }

		public void Awake()
		{
			_location = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation;
			HealthDisplay.gameObject.SetActive(RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat);
			ThreatDisplay.gameObject.SetActive(RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat);
			DescriptionLabel.text = LocalizationManager.GetTranslation("GalaxyMap/EndOfGalaxyDescription");
			DescriptionLabel.gameObject.SetActive(false);
			RewardsBlackout.gameObject.SetActive(false);
			RewardsGrid.gameObject.SetActive(false);
			RewardsGridMiddle.gameObject.SetActive(false);
			ContinueButton.gameObject.SetActive(false);
		}

		public void Start()
		{
			SkeletonAnimation.AnimationState.Event += AnimationStateOnEvent;
			RewardsGrid.transform.DestroyAllChildren();
			System.Random random = new System.Random(_location.UniqueId.GetHashCode());
			List<BaseReceivable> list = new List<BaseReceivable>();
			List<RewardPool> endOfGalaxyRewardPools = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.EndOfGalaxyRewardPools;
			if (RuntimeGlobals.GameModeSettings.InCampaignTutorial)
			{
				_inTutorial = true;
				int num = SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.MaxHealth - SerializableMonobehaviour<MothershipManager, MothershipSaveData>.Instance.CurrentHealth - 1;
				if (num != 0)
				{
					list.Add(new HealthReceivable
					{
						Amount = num
					});
				}
				int num2 = (int)((double)SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.ResourceSettings[ETerrainMaterial.CommonOre].GetStartingAmount() - SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetAvailableResources(ETerrainMaterial.CommonOre));
				if (num2 != 0)
				{
					list.Add(new OreReceivable
					{
						Amount = num2,
						Reward = ETerrainMaterial.CommonOre
					});
				}
				int amount = (int)((double)SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.ResourceSettings[ETerrainMaterial.RareOre].GetStartingAmount() - SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.GetAvailableResources(ETerrainMaterial.RareOre));
				list.Add(new OreReceivable
				{
					Amount = amount,
					Reward = ETerrainMaterial.RareOre
				});
			}
			else
			{
				try
				{
					for (int i = 0; i < 3; i++)
					{
						BaseReceivable item = ((endOfGalaxyRewardPools == null || endOfGalaxyRewardPools.Count <= 0) ? SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomReward(random.Next(), random.Next(), EMissionType.BlackBoxSignal) : SerializableMonobehaviour<MissionManager, MissionData>.Instance.GetRandomRewardFromPools(random.Next(), random.Next(), endOfGalaxyRewardPools));
						list.Add(item);
					}
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
					list = new List<BaseReceivable>
					{
						new HealthReceivable
						{
							Amount = 1
						},
						new OreReceivable
						{
							Amount = 200,
							Reward = ETerrainMaterial.CommonOre
						},
						new OreReceivable
						{
							Amount = 100,
							Reward = ETerrainMaterial.RareOre
						}
					};
				}
			}
			list = SerializableMonobehaviour<MissionManager, MissionData>.Instance.CleanRewards(list, endOfGalaxyRewardPools, random, EMissionComplexity.High, !_inTutorial);
			bool flag = false;
			if (SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.EndOfGalaxyRewards.ContainsKey(SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Level))
			{
				TravelEventConsequence travelEventConsequence = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.EndOfGalaxyRewards[SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.Level];
				if (travelEventConsequence != null)
				{
					list.Insert(0, travelEventConsequence.CreateReward(random.Next()));
					flag = true;
				}
			}
			_selectableRewardsList = new List<SelectableReward>();
			foreach (BaseReceivable item2 in list)
			{
				RewardIcon rewardIcon;
				SelectableReward selectableReward;
				if ((flag && GuaranteedReward == null) || _inTutorial)
				{
					rewardIcon = UnityEngine.Object.Instantiate(GuaranteedRewardIconPrefab, RewardsGridMiddle.transform);
					selectableReward = UnityEngine.Object.Instantiate(GuaranteedRewardPrefab, RewardsGrid.transform);
					if (flag && GuaranteedReward == null)
					{
						GuaranteedReward = selectableReward;
					}
					selectableReward.IsSmallCapsule = true;
				}
				else
				{
					rewardIcon = UnityEngine.Object.Instantiate(RewardIconPrefab, RewardsGridMiddle.transform);
					selectableReward = UnityEngine.Object.Instantiate(RewardPrefab, RewardsGrid.transform);
				}
				selectableReward.transform.localPosition = Vector3.zero;
				selectableReward.transform.localScale = Vector3.one;
				selectableReward.RewardIcon = rewardIcon;
				selectableReward.Init(this, item2);
				_selectableRewardsList.Add(selectableReward);
			}
			RewardsGrid.enabled = true;
			RewardsGrid.Reposition();
			RewardsGridMiddle.enabled = true;
			RewardsGridMiddle.Reposition();
			SkeletonAnimation.AnimationState.SetAnimation(0, "endofgalaxy_approach", false);
		}

		public void OnDestroy()
		{
			if (_inTutorial)
			{
				return;
			}
			SkeletonAnimation.AnimationState.Event -= AnimationStateOnEvent;
			if (_selectableRewardsList == null)
			{
				return;
			}
			foreach (SelectableReward selectableRewards in _selectableRewardsList)
			{
				if (selectableRewards.PerkCapsuleAnimation.AnimationState != null)
				{
					selectableRewards.PerkCapsuleAnimation.AnimationState.Event -= CapsuleAnimationStateOnEvent;
				}
			}
		}

		public void Continue()
		{
			if (!_rewardSelectable)
			{
				StartCoroutine(DisplayRewards());
			}
			else if (_inTutorial || !(SelectedReward == null))
			{
				_rewardSelectable = false;
			}
		}

		public void SelectReward(SelectableReward reward)
		{
			if (!(reward == GuaranteedReward))
			{
				SelectedReward = reward;
				DescriptionLabel.text = SelectedReward.Reward.GetTitle();
			}
		}

		private IEnumerator DisplayRewards()
		{
			AudioController.Play(RewardSound);
			DescriptionLabel.gameObject.SetActive(false);
			RewardsBlackout.gameObject.SetActive(true);
			RewardsBlackout.PlayForward();
			yield return new WaitForSeconds(RewardsBlackout.duration);
			RewardsGrid.gameObject.SetActive(true);
			RewardsGridMiddle.gameObject.SetActive(true);
			ContinueButton.gameObject.SetActive(true);
			if (!_inTutorial)
			{
				ContinueButton.GetComponentInChildren<UILabel>().text = LocalizationManager.GetTranslation("GalaxyMap/EndOfGalaxySelect");
			}
			if (_inTutorial)
			{
				foreach (SelectableReward selectableRewards in _selectableRewardsList)
				{
					Collider[] components = selectableRewards.GetComponents<Collider>();
					for (int i = 0; i < components.Length; i++)
					{
						components[i].enabled = false;
					}
				}
			}
			if (GuaranteedReward != null)
			{
				Collider[] components = GuaranteedReward.GetComponents<Collider>();
				for (int i = 0; i < components.Length; i++)
				{
					components[i].enabled = false;
				}
			}
			_rewardSelectable = true;
			while (_rewardSelectable)
			{
				bool buttonDisabled = false;
				while (!_inTutorial && SelectedReward == null)
				{
					ContinueButton.SetState(UIButtonColor.State.Disabled, true);
					buttonDisabled = true;
					yield return null;
				}
				if (buttonDisabled)
				{
					ContinueButton.SetState(UIButtonColor.State.Normal, true);
				}
				yield return null;
			}
			ContinueButton.gameObject.SetActive(false);
			foreach (SelectableReward selectableRewards2 in _selectableRewardsList)
			{
				selectableRewards2.PlayEndAnimation();
				selectableRewards2.PerkCapsuleAnimation.AnimationState.Event += CapsuleAnimationStateOnEvent;
			}
			yield return new WaitForSeconds(1.5f);
			RewardsGrid.gameObject.SetActive(false);
			RewardsGridMiddle.gameObject.SetActive(false);
			RewardsBlackout.PlayReverse();
			yield return new WaitForSeconds(RewardsBlackout.duration);
			RewardsBlackout.gameObject.SetActive(false);
			SkeletonAnimation.AnimationState.SetAnimation(0, "endofgalaxy_flytowormhole", false);
		}

		private IEnumerator DisplayThreatDecrease()
		{
			yield return new WaitForSeconds(0.5f);
			SecondaryThreatDisplay.gameObject.SetActive(true);
			float startThreat = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel;
			float targetThreat = (_inTutorial ? 0f : (startThreat * 0.2f));
			float maxTime = (startThreat - targetThreat) / 100f * 3f;
			yield return new WaitForSeconds(0.5f);
			AudioObject clip = AudioController.Play("TravelEventThreadReductionLoopSFX");
			StartCoroutine(SecondaryThreatDisplay.AnimateThreatBar(maxTime, startThreat, targetThreat));
			yield return StartCoroutine(ThreatDisplay.AnimateThreatBar(maxTime, startThreat, targetThreat));
			clip.Stop();
			yield return new WaitForSeconds(0.5f);
			if (_inTutorial)
			{
				_selectableRewardsList.ForEach(delegate(SelectableReward r)
				{
					r.HandleReward();
				});
				SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.Drones.ToList().ForEach(delegate(DroneData d)
				{
					SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.DeleteDrone(d);
				});
				SerializableMonobehaviour<DronePerkManager, DronePerkManagerData>.Instance.OverwritePerk();
			}
			else
			{
				SelectableReward guaranteedReward = GuaranteedReward;
				if ((object)guaranteedReward != null)
				{
					guaranteedReward.HandleReward();
				}
				SelectableReward selectedReward = SelectedReward;
				if ((object)selectedReward != null)
				{
					selectedReward.HandleReward();
				}
			}
			WormHoleLocationData wormHoleLocationData;
			if ((wormHoleLocationData = _location as WormHoleLocationData) != null)
			{
				wormHoleLocationData.TravelToNextGalaxy();
				yield break;
			}
			PlanetLocationData planetLocationData;
			if ((planetLocationData = _location as PlanetLocationData) != null && planetLocationData.IsEndPlanet)
			{
				planetLocationData.TravelToNextGalaxy();
				yield break;
			}
			throw new Exception("travel to next galaxy not possible");
		}

		private void AnimationStateOnEvent(TrackEntry trackentry, Spine.Event e)
		{
			if (e.Data.Name == "Next")
			{
				switch (_animationState)
				{
				case EAnimationState.Approaching:
					SkeletonAnimation.AnimationState.SetAnimation(0, "endofgalaxy_waiting", true);
					_animationState = EAnimationState.Waiting;
					if (!_inTutorial)
					{
						DescriptionLabel.gameObject.SetActive(true);
						ContinueButton.gameObject.SetActive(true);
					}
					else
					{
						Continue();
					}
					break;
				case EAnimationState.Waiting:
					StartCoroutine(DisplayThreatDecrease());
					break;
				}
			}
			else if (e.Data.Name == "SetNimbatusSpeed")
			{
				NimbatusSpeedAnimation.SetTargetSpeed(e.floatValue);
				NimbatusSpeedAnimation.SetLerpSpeed(e.intValue);
			}
			else if (e.Data.Name == "SetParticleSpeed")
			{
				NimbatusSpeedAnimation.SetParticleTargetSpeed(e.floatValue);
				NimbatusSpeedAnimation.SetParticleLerpSpeed(e.intValue);
			}
			else if (e.Data.Name == "StopNimbatusImmediately")
			{
				NimbatusSpeedAnimation.StopNimbatusImmediately();
			}
			else if (e.Data.Name == "StopParticleImmediately")
			{
				NimbatusSpeedAnimation.StopParticleImmediately();
			}
			else if (e.Data.Name == "PlayAudio" && !e.stringValue.IsNullOrWhitespace())
			{
				AudioController.Play(e.stringValue);
			}
		}

		private void CapsuleAnimationStateOnEvent(TrackEntry trackentry, Spine.Event e)
		{
			if (!(e.Data.Name == "TryPlayEffect"))
			{
				return;
			}
			foreach (SelectableReward selectableRewards in _selectableRewardsList)
			{
				selectableRewards.TryPlayEffect();
			}
		}
	}
}
