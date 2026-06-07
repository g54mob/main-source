using System.Collections;
using Assets.Nimbatus.GUI.RacingTrack.Scripts;
using Assets.Nimbatus.Scripts.Common.Helpers;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using I2.Loc;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Race
{
	public class BaseRaceManager : WaitForLoadBehaviour
	{
		public float StartDelay;

		public bool HasCountdown = true;

		[ShowIf("HasCountdown", true)]
		public RaceCountdown CountdownPrefab;

		public UILabel TimeDisplay;

		public UILabel WinDisplay;

		public UILabel WinTimeDisplay;

		public UITexture WinTexture;

		public string MusicIntro;

		public string MusicLoop;

		public string MusicOutro;

		[HideInInspector]
		public float CurrentTime;

		[HideInInspector]
		public bool RaceRunning;

		[HideInInspector]
		public static BaseRaceManager Instance { get; private set; }

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			if (TimeDisplay != null)
			{
				TimeDisplay.text = 0f.ToTimeString();
			}
			RuntimeGlobals.IsMovementBlocked = true;
			StartCoroutine(InitRace());
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (Instance == this)
			{
				Instance = null;
			}
		}

		public override void WakeUp()
		{
		}

		private IEnumerator InitRace()
		{
			RaceRunning = true;
			if (!string.IsNullOrEmpty(MusicIntro) && RuntimeGlobals.RunningMode != ERunningMode.TestFlight)
			{
				AudioController.PlayMusic(MusicIntro);
			}
			if (HasCountdown)
			{
				if (CountdownPrefab != null)
				{
					CountdownPrefab.StartCountdown();
					while (!CountdownPrefab.CountdownPlayed)
					{
						yield return null;
					}
				}
				StartCoroutine(StartRace());
			}
			else
			{
				if (CountdownPrefab != null)
				{
					CountdownPrefab.HideCountdown();
				}
				yield return new WaitForSeconds(StartDelay);
				StartCoroutine(StartRace());
			}
		}

		private IEnumerator StartRace()
		{
			if (!string.IsNullOrEmpty(MusicLoop) && RuntimeGlobals.RunningMode != ERunningMode.TestFlight)
			{
				AudioController.PlayMusic(MusicLoop);
			}
			RuntimeGlobals.IsMovementBlocked = false;
			OnRaceStarted();
			while (RaceRunning)
			{
				CurrentTime += Time.deltaTime;
				if (TimeDisplay != null)
				{
					TimeDisplay.text = CurrentTime.ToTimeString();
				}
				yield return null;
			}
		}

		public void FinishRace(NimbatusDrone drone, bool success = true, bool singleplayer = false)
		{
			if (!RaceRunning)
			{
				return;
			}
			RaceRunning = false;
			AudioController.StopCategory("Music");
			if (!string.IsNullOrEmpty(MusicOutro) && RuntimeGlobals.RunningMode != ERunningMode.TestFlight)
			{
				AudioController.PlayMusic(MusicOutro);
			}
			OnRaceEnded(drone, success);
			if (success)
			{
				if (singleplayer)
				{
					WinDisplay.text = LocalizationManager.GetTermTranslation("Racing/YourTime") + " ";
					WinTimeDisplay.text = CurrentTime.ToTimeString();
				}
				else
				{
					WinDisplay.text = drone.DroneData.DroneName + " " + LocalizationManager.GetTermTranslation("Racing/Wins");
					WinTexture.mainTexture = drone.DroneData.Image;
				}
			}
			else if (singleplayer)
			{
				WinDisplay.text = " ";
				WinTimeDisplay.text = LocalizationManager.GetTermTranslation("Racing/DroneDestroyed");
			}
			else
			{
				WinDisplay.text = LocalizationManager.GetTermTranslation("Racing/NoWinner");
			}
			RuntimeGlobals.IsGameOver = true;
		}

		public virtual void OnRaceStarted()
		{
		}

		public virtual void OnRaceEnded(NimbatusDrone drone, bool success)
		{
		}
	}
}
