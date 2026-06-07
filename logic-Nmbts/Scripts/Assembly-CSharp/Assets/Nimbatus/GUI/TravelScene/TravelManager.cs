using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.GUI.TravelEvents;
using Assets.Nimbatus.Scripts.GalaxyMap;
using Assets.Nimbatus.Scripts.GalaxyMap.Shops;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.TravelEvents;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using Spine.Unity;
using UnityEngine;

namespace Assets.Nimbatus.GUI.TravelScene
{
	public class TravelManager : MonoBehaviour
	{
		public TravelEventUi TravelEventUi;

		public GameObject ProgressDisplay;

		public UISprite TravelProgressSprite;

		public Transform SpaceShip;

		public UILabel TravelDescriptionLabel;

		public ParticleSystem TravelParticles;

		public float TravelSpeed;

		public SkeletonAnimation SkeletonAnimation;

		public static bool IsLocationEvent;

		public static TravelEvent LocationEvent;

		public static bool ContinueFromEvent;

		public static float ThreatIncrease;

		public static string OverrideEndAnimation;

		public static float OverrideEndAnimationNimbatusSpeed;

		public static float OverrideEndAnimationParticleSpeed;

		public static float OverrideOutroSpeed = 1f;

		public IEnumerator Start()
		{
			ShopInventoryHelper.SetCurrentShop(null);
			if (IsLocationEvent)
			{
				ProgressDisplay.SetActive(false);
				if (LocationEvent != null)
				{
					StartTravelEvent(LocationEvent);
					yield break;
				}
				TravelEvent travelEventOfType = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.GetTravelEventOfType(ETravelEventType.LocationNormal);
				StartTravelEvent(travelEventOfType);
			}
			else if (ContinueFromEvent)
			{
				TravelProgressSprite.fillAmount = 0.5f;
				SkeletonAnimation.AnimationState.ClearTracks();
				SkeletonAnimation.AnimationState.Data.DefaultMix = 0f;
				StartCoroutine(EndTravel());
			}
			else
			{
				TravelProgressSprite.fillAmount = 0f;
				StartCoroutine(Travel());
			}
		}

		private IEnumerator Travel()
		{
			ContinueFromEvent = false;
			TravelProgressSprite.fillAmount = 0f;
			TravelParticles.Play();
			TravelDescriptionLabel.text = "";
			SpaceShip.localPosition = new Vector3(TravelProgressSprite.transform.localPosition.x, TravelProgressSprite.transform.localPosition.y, SpaceShip.localPosition.z);
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.ClearLocalMissions();
			SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ClearActiveDrones();
			SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ResetTravelEvent();
			string translation = LocalizationManager.GetTermTranslation("GalaxyMap/TravellingTo");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { 
			{
				"Location",
				LabelHelper.Orange + SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.TargetLocation.Name + LabelHelper.White
			} });
			TravelDescriptionLabel.text = translation;
			TravelEventUi.NimbatusSpeedAnimation.OverrideSpeed(1f);
			TravelEventUi.NimbatusSpeedAnimation.OverrideParticleSpeed(1f);
			yield return StartCoroutine(StartTravelAnimation());
			TravelEvent travelEvent = SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.GetTravelEvent();
			if (travelEvent != null)
			{
				ContinueFromEvent = true;
				StartTravelEvent(travelEvent);
			}
			else
			{
				StartCoroutine(EndTravel());
			}
		}

		private IEnumerator StartTravelAnimation()
		{
			SetAnimation("travel_normal_intro");
			yield return StartCoroutine(UpdateTravelProgress(0.5f));
			yield return new WaitForSeconds(0.5f);
			SetAnimation("travel_normal_loop", true);
		}

		public void ContinueTravel()
		{
			if (IsLocationEvent)
			{
				ExitFromLocationEvent();
				return;
			}
			ProgressDisplay.SetActive(true);
			StartCoroutine(EndTravel());
		}

		private void StartTravelEvent(TravelEvent travelEvent)
		{
			ProgressDisplay.SetActive(false);
			SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.StartTravelEvent(travelEvent.EventType);
			TravelEventUi.Init(this);
		}

		public void VisitTravelEvent()
		{
			SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.LoadMission();
		}

		private void ExitFromLocationEvent()
		{
			IsLocationEvent = false;
			LocationEvent = null;
			SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ResetTravelEvent();
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.LoadGameplayScene();
		}

		private IEnumerator EndTravel()
		{
			EndTravelAnimation();
			TravelParticles.Play();
			string translation = LocalizationManager.GetTermTranslation("GalaxyMap/TravellingTo");
			LocalizationManager.ApplyLocalizationParams(ref translation, new Dictionary<string, string> { 
			{
				"Location",
				LabelHelper.Orange + SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.TargetLocation.Name + LabelHelper.White
			} });
			TravelDescriptionLabel.text = translation;
			SerializableMonobehaviour<TravelEventManager, TravelEventManagerSaveData>.Instance.ResetTravelEvent();
			yield return StartCoroutine(UpdateTravelProgress(1f));
			TravelParticles.Stop();
			NimbatusSpeedAnimation.IsOverwritten = false;
			NimbatusSpeedAnimation.IsParticleOverwritten = false;
			ResetStaticFields();
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.ReachTargetLocation();
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.ApplyLocationSettings();
			SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation.LoadLocationScene();
		}

		private void EndTravelAnimation()
		{
			if (string.IsNullOrEmpty(OverrideEndAnimation))
			{
				SetAnimation("travel_normal_end");
				return;
			}
			SetAnimation(OverrideEndAnimation);
			OverrideEndAnimation = "";
			TravelEventUi.NimbatusSpeedAnimation.OverrideSpeed(OverrideEndAnimationNimbatusSpeed);
			TravelEventUi.NimbatusSpeedAnimation.OverrideParticleSpeed(OverrideEndAnimationParticleSpeed);
			NimbatusSpeedAnimation.IsOverwritten = true;
			NimbatusSpeedAnimation.IsParticleOverwritten = true;
			OverrideEndAnimationNimbatusSpeed = 1f;
			OverrideEndAnimationParticleSpeed = 1f;
		}

		public static void ResetStaticFields()
		{
			IsLocationEvent = false;
			LocationEvent = null;
			ContinueFromEvent = false;
			ThreatIncrease = 0f;
			OverrideEndAnimation = "";
			OverrideEndAnimationNimbatusSpeed = 1f;
			OverrideEndAnimationParticleSpeed = 1f;
			OverrideOutroSpeed = 1f;
		}

		private IEnumerator UpdateTravelProgress(float progress)
		{
			float initThreat = SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.CurrentThreatLevel;
			float targetThreat = initThreat + ThreatIncrease * 0.5f;
			if (RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat)
			{
				SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentGalaxy.SetThreat(targetThreat);
			}
			while (TravelProgressSprite.fillAmount + TravelSpeed * Time.deltaTime < progress)
			{
				float num = ((TravelProgressSprite.fillAmount > 0.5f) ? OverrideOutroSpeed : 1f);
				TravelProgressSprite.fillAmount += TravelSpeed * Time.deltaTime * num;
				if (RuntimeGlobals.GameModeSettings.NimbatusHealthAndThreat)
				{
					float t = ((TravelProgressSprite.fillAmount > 0.5f) ? ((TravelProgressSprite.fillAmount - 0.5f) * 2f) : (TravelProgressSprite.fillAmount * 2f));
					float threatLevel = Mathf.Lerp(initThreat, targetThreat, t);
					TravelEventUi.ThreatDisplay.UpdateBar(threatLevel);
				}
				SpaceShip.localPosition = new Vector3(TravelProgressSprite.transform.localPosition.x + TravelProgressSprite.fillAmount * (float)TravelProgressSprite.width, TravelProgressSprite.transform.localPosition.y, SpaceShip.localPosition.z);
				yield return true;
			}
			TravelEventUi.ThreatDisplay.UpdateBar(targetThreat);
			TravelProgressSprite.fillAmount = progress;
			SpaceShip.localPosition = new Vector3(TravelProgressSprite.transform.localPosition.x + TravelProgressSprite.fillAmount * (float)TravelProgressSprite.width, TravelProgressSprite.transform.localPosition.y, SpaceShip.localPosition.z);
			yield return new WaitForSecondsRealtime(0.1f);
		}

		private void SetAnimation(string animationName, bool looping = false)
		{
			SkeletonAnimation.AnimationState.SetAnimation(0, animationName, looping);
		}
	}
}
