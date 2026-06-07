using System;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.MissionControl.Scripts.Main;
using Assets.Nimbatus.GUI.MissionRewards.Scripts;
using Assets.Nimbatus.GUI.TravelScene;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Receivables;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainResources;
using Sirenix.Utilities;
using Spine;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Nimbatus.GUI.TravelEvents
{
	public class TravelEventUi : MonoBehaviour
	{
		public UILabel Title;

		public UILabel Description;

		public NimbatusHealthDisplay HealthDisplay;

		public ThreatLevelDisplay ThreatDisplay;

		public GameObject EventPanel;

		public GameObject DistressSignalPanel;

		public UIButton ContinueButton;

		public GameObject ChoicePanel;

		public UILabel ChoiceDescription;

		public ConfirmCostButton ConfirmButton;

		public ConfirmCostButton IgnoreButton;

		public GameObject RewardPanel;

		public UIGrid RewardGrid;

		public RewardChestItem ItemRewardPrefab;

		public string PositiveRewardSound;

		public string NegativeRewardSound;

		[Header("Animation")]
		public SkeletonAnimation SkeletonAnimation;

		public ParticleSystem DebrisParticleSystem;

		public NimbatusSpeedAnimation NimbatusSpeedAnimation;

		public BigHealthBarAnimation BigHealthBarAnimation;

		public PirateAnimation PirateAnimation;

		public GameObject DistressSignal;

		public GameObject LocationDistressSignal;

		public GameObject NebulaParticleEffect;

		public CivilCargoshipAnimation CivilCargoshipAnimation;

		public SpriteRenderer ShopIconRenderer;

		public Sprite GarageIcon;

		public UITexture LocationIcon;

		public GameObject CorpSearchDroidAnimation;

		public GameObject CorpSearchDroid;

		public ParticleSystem CorpSearchDroidExplosion;

		public string CorpSearchDroidExplosionSound;

		public NimbatusReentryAnimation NimbatusReentryAnimation;

		private TravelManager _manager;

		private string _audioLoop;

		private string _audioLoopOld;

		private AudioObject _nimbatusLoop;

		private float _numbatusLoopOriginalVolume;

		private float _numbatusLoopTargetVolume;

		public void Awake()
		{
			EventPanel.SetActive(true);
			RewardPanel.SetActive(false);
			ChangeActiveStatus(false);
			HealthDisplay.gameObject.SetActive(RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat);
			ThreatDisplay.gameObject.SetActive(RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat);
		}

		public void Start()
		{
			SkeletonAnimation.AnimationState.Event += AnimationStateOnEvent;
		}

		public void Update()
		{
			if (_audioLoop != _audioLoopOld)
			{
				if (_audioLoop.IsNullOrWhitespace())
				{
					if (!_audioLoopOld.IsNullOrWhitespace())
					{
						AudioController.Stop(_audioLoopOld);
					}
					_audioLoopOld = "";
				}
				else
				{
					if (!_audioLoopOld.IsNullOrWhitespace())
					{
						AudioController.Stop(_audioLoopOld);
					}
					AudioController.Play(_audioLoop);
					_audioLoopOld = _audioLoop;
				}
			}
			if ((bool)_nimbatusLoop)
			{
				_nimbatusLoop.volume = Mathf.Lerp(_nimbatusLoop.volume, _numbatusLoopTargetVolume * _numbatusLoopOriginalVolume, Time.deltaTime * 1f);
			}
		}

		public void OnDestroy()
		{
			SkeletonAnimation.AnimationState.Event -= AnimationStateOnEvent;
		}

		public void Init(TravelManager manager)
		{
			ChangeActiveStatus(true);
			_manager = manager;
			NextIntro();
		}

		public void Next(bool positiveResult = true)
		{
			RewardPanel.SetActive(false);
			if (!SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.NextIntro(positiveResult))
			{
				ChangeActiveStatus(false);
				if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.HasMission)
				{
					_manager.VisitTravelEvent();
				}
				else
				{
					_manager.ContinueTravel();
				}
			}
			else
			{
				NextIntro();
			}
		}

		public void PositiveChoice()
		{
			ItemPrice confirmCost = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveIntro.ConfirmCost;
			if (confirmCost != null)
			{
				SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.UseResources(confirmCost.Resource, confirmCost.Amount);
			}
			NextChoice(true);
		}

		public void NegativeChoice()
		{
			ItemPrice ignoreCost = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveIntro.IgnoreCost;
			if (ignoreCost != null)
			{
				SerializableMonobehaviour<NimbatusTerrainResourceManager, ResourceManagerData>.Instance.UseResources(ignoreCost.Resource, ignoreCost.Amount);
			}
			NextChoice(false);
		}

		private void NextChoice(bool positiveChoice)
		{
			float goodOutcomeProbability = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveIntro.GoodOutcomeProbability;
			bool positiveResult = UnityEngine.Random.Range(0f, 1f) > (positiveChoice ? (1f - goodOutcomeProbability) : (1f - (1f - goodOutcomeProbability)));
			Next(positiveResult);
		}

		public void Ignore()
		{
			ChangeActiveStatus(false);
			TravelManager.OverrideEndAnimation = "";
			_manager.ContinueTravel();
		}

		private void ChangeActiveStatus(bool status)
		{
			Title.gameObject.SetActive(status);
			Description.gameObject.SetActive(status);
			DeactivateAllButtons();
		}

		private void DeactivateAllButtons()
		{
			DistressSignalPanel.SetActive(false);
			ChoicePanel.SetActive(false);
			ContinueButton.gameObject.SetActive(false);
		}

		private void NextIntro()
		{
			DistressSignal.SetActive(false);
			TravelEventManager instance = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance;
			if (instance.ActiveIntro.Type == ETravelEventIntroduction.DistressSignal)
			{
				Title.text = "";
			}
			else
			{
				Title.text = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent.Title.GetTranslation();
			}
			if (instance.ActiveIntro.ShowDescription)
			{
				Description.text = instance.ActiveIntro.Description.GetTranslation();
			}
			else
			{
				Description.text = "";
			}
			DeactivateAllButtons();
			switch (instance.ActiveIntro.Type)
			{
			case ETravelEventIntroduction.DistressSignal:
				DistressSignalPanel.SetActive(true);
				DistressSignal.SetActive(true);
				break;
			case ETravelEventIntroduction.Text:
				ContinueButton.gameObject.SetActive(true);
				break;
			case ETravelEventIntroduction.Animation:
				StartAnimation(instance.ActiveIntro.AnimationName, instance.ActiveIntro.LoopAnimation);
				break;
			case ETravelEventIntroduction.Scene:
				NimbatusSceneManager.SetReturnScene(instance.ActiveIntro.LocationSceneName, SceneManager.GetActiveScene().name);
				NimbatusSceneManager.LoadScene(instance.ActiveIntro.LocationSceneName);
				break;
			case ETravelEventIntroduction.GiveConsequences:
				GiveConsequences();
				break;
			case ETravelEventIntroduction.Choice:
				ChoicePanel.SetActive(true);
				ChoiceDescription.text = instance.ActiveIntro.ChoiceDescription.GetTranslation();
				ConfirmButton.Init(instance.ActiveIntro.ConfirmButtonText.GetTranslation(), instance.ActiveIntro.ConfirmCost);
				IgnoreButton.Init(instance.ActiveIntro.IgnoreButtonText.GetTranslation(), instance.ActiveIntro.IgnoreCost);
				break;
			case ETravelEventIntroduction.EndAnimation:
				instance.ApplyEndAnimation();
				Next();
				break;
			}
		}

		private void GiveConsequences()
		{
			SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.HandleConsequences();
			List<BaseReceivable> consequences = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.Consequences;
			if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveEvent == null)
			{
				return;
			}
			if (SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ActiveIntro.SkipOutcomeDisplay || consequences.Count < 1)
			{
				Next();
				return;
			}
			RewardPanel.SetActive(true);
			RewardGrid.transform.DestroyAllChildren();
			bool flag = true;
			foreach (BaseReceivable item in consequences)
			{
				UnityEngine.Object.Instantiate(ItemRewardPrefab, RewardGrid.transform).Init(item);
				if (!item.IsPositive())
				{
					flag = false;
				}
			}
			if (flag)
			{
				if (!PositiveRewardSound.IsNullOrWhitespace())
				{
					AudioController.Play(PositiveRewardSound);
				}
			}
			else if (!NegativeRewardSound.IsNullOrWhitespace())
			{
				AudioController.Play(NegativeRewardSound);
			}
			RewardGrid.Reposition();
			ContinueButton.gameObject.SetActive(true);
		}

		private void StartAnimation(string animationName, bool looping)
		{
			if (looping)
			{
				SkeletonAnimation.AnimationState.SetAnimation(0, animationName, true);
				Next();
			}
			else
			{
				SkeletonAnimation.AnimationState.SetAnimation(0, animationName, false);
			}
		}

		private void AnimationStateOnEvent(TrackEntry trackentry, Spine.Event e)
		{
			try
			{
				string text = e.Data.Name;
				if (text == null)
				{
					return;
				}
				switch (text)
				{
				case "Next":
					Next();
					break;
				case "StartDebrisParticle":
				{
					ParticleSystem.EmissionModule emission2 = DebrisParticleSystem.emission;
					emission2.enabled = true;
					break;
				}
				case "StopDebrisParticle":
				{
					ParticleSystem.EmissionModule emission = DebrisParticleSystem.emission;
					emission.enabled = false;
					break;
				}
				case "StartCorpAnimation":
					BigHealthBarAnimation.gameObject.SetActive(true);
					BigHealthBarAnimation.Init(-1);
					StartCoroutine(BigHealthBarAnimation.StartHealthBarAnimation());
					break;
				case "StopCorpAnimation":
					BigHealthBarAnimation.gameObject.SetActive(false);
					StopCoroutine(BigHealthBarAnimation.StartHealthBarAnimation());
					break;
				case "FireCorpWeapon":
					StartCoroutine(BigHealthBarAnimation.ShootCorpWeapon());
					break;
				case "SetNimbatusSpeed":
					NimbatusSpeedAnimation.SetTargetSpeed(e.floatValue);
					NimbatusSpeedAnimation.SetLerpSpeed(e.intValue);
					break;
				case "SetParticleSpeed":
					NimbatusSpeedAnimation.SetParticleTargetSpeed(e.floatValue);
					NimbatusSpeedAnimation.SetParticleLerpSpeed(e.intValue);
					break;
				case "StopNimbatusImmediately":
					NimbatusSpeedAnimation.StopNimbatusImmediately();
					break;
				case "StopParticleImmediately":
					NimbatusSpeedAnimation.StopParticleImmediately();
					break;
				case "SetPirateShipState":
					PirateAnimation.SetPirateShipState(e.stringValue);
					break;
				case "StartNebulaParticle":
					NebulaParticleEffect.SetActive(true);
					break;
				case "CivilShipGood":
					CivilCargoshipAnimation.Thruster.SetActive(true);
					CivilCargoshipAnimation.CargoshipBrightnessTarget = 1f;
					CivilCargoshipAnimation.CargoshipAngleTarget = 1f;
					break;
				case "CivilShipBad":
					CivilCargoshipAnimation.CorpSignal.SetActive(true);
					CivilCargoshipAnimation.CargoshipBrightnessTarget = 1f;
					break;
				case "PlayAudio":
					if (!e.stringValue.IsNullOrWhitespace())
					{
						AudioController.Play(e.stringValue);
					}
					break;
				case "StopAudio":
					if (!e.stringValue.IsNullOrWhitespace())
					{
						AudioController.Stop(e.stringValue);
					}
					break;
				case "PlayAudioLoop":
					_audioLoop = e.stringValue;
					break;
				case "StopAudioLoop":
					_audioLoop = "";
					break;
				case "NimbatusAudioLoopFadeIn":
					if (_nimbatusLoop == null)
					{
						_nimbatusLoop = AudioController.Play("TravelEventNimbatusTravelLoopSFX");
						_numbatusLoopOriginalVolume = _nimbatusLoop.volume;
						_numbatusLoopTargetVolume = 1f;
					}
					else
					{
						_numbatusLoopTargetVolume = 1f;
					}
					break;
				case "NimbatusAudioLoopSetVolume":
					if ((bool)_nimbatusLoop)
					{
						_numbatusLoopTargetVolume = e.floatValue;
						break;
					}
					_nimbatusLoop = AudioController.Play("TravelEventNimbatusTravelLoopSFX");
					_numbatusLoopOriginalVolume = _nimbatusLoop.volume;
					_numbatusLoopTargetVolume = e.floatValue;
					break;
				case "ShopToGarage":
					ShopIconRenderer.sprite = GarageIcon;
					break;
				case "ShowCorpSearchDroid":
					CorpSearchDroidAnimation.SetActive(true);
					break;
				case "DestroyCorpSearchDroid":
					CorpSearchDroid.SetActive(false);
					CorpSearchDroidExplosion.Play();
					AudioController.Play(CorpSearchDroidExplosionSound);
					break;
				case "UpdatePlanetIcon":
					LocationIcon.mainTexture = ((SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.TargetLocation != null) ? SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.TargetLocation.GetPreviewImage() : SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.GetPreviewImage());
					break;
				case "SetReentryDuration":
					NimbatusReentryAnimation.SetDuration(e.intValue, e.floatValue);
					break;
				case "ShowLocationDistressSignal":
					LocationDistressSignal.SetActive(true);
					break;
				}
			}
			catch (Exception message)
			{
				Debug.LogError(message);
				Next();
			}
		}
	}
}
