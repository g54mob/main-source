using System.Collections;
using System.Globalization;
using System.Linq;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.SumoArena
{
	public class SumoArenaManager : WaitForLoadBehaviour
	{
		public float CurrentRadius;

		public float BattleTime;

		public float StartDelay = 1f;

		public string WarmUpSFX;

		public string EndgameSFX;

		public string BattleMusic;

		public string WinSFX;

		public AnimationCurve RadiusModificationCurve;

		public bool TestSimulationMode;

		[HideInInspector]
		public float CurrentTime;

		public NimbatusDrone RightDrone;

		public NimbatusDrone LeftDrone;

		public SumoArenaCircle Circle;

		public UILabel TimeDisplay;

		public UILabel WinDisplay;

		public UITexture WinTexture;

		public Color InsideColor;

		public Color OutsideColor;

		private bool _fightOver;

		[HideInInspector]
		public static SumoArenaManager Instance { get; private set; }

		protected void Awake()
		{
			if (TestSimulationMode)
			{
				LeftDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.ActiveDrone);
			}
			else
			{
				LeftDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(0));
				RightDrone.InitDrone(SerializableMonobehaviour<DroneManager, DroneManagerData>.Instance.GetActiveDrone(1));
				RightDrone.RootDronePart.transform.Rotate(Vector3.forward, 180f);
				foreach (DronePart item in RightDrone.RootDronePart.Children.Where((DronePart c) => c.GetComponent<DronePart>()))
				{
					item.ApplyRotation();
				}
				LeftDrone.RootDronePart.ValidateDroneRecursive();
				RightDrone.RootDronePart.ValidateDroneRecursive();
			}
			if (Instance == null)
			{
				Instance = this;
			}
		}

		public void Start()
		{
			if (RuntimeGlobals.Camera != null)
			{
				RuntimeGlobals.Camera.FocusTarget = true;
				if (TestSimulationMode)
				{
					RuntimeGlobals.Camera.AddPlayer(LeftDrone.RootDronePart.transform, true, false, true);
				}
				else
				{
					RuntimeGlobals.Camera.AddPlayer(RightDrone.RootDronePart.transform, true, false, false);
					RuntimeGlobals.Camera.AddPlayer(LeftDrone.RootDronePart.transform, true, false, true);
				}
			}
			RuntimeGlobals.IsMovementBlocked = true;
			StartCoroutine(StartBattle());
			Circle.Init(this);
			Circle.SetColor(InsideColor);
			CurrentRadius = Circle.transform.localScale.x / 2f;
		}

		public override void WakeUp()
		{
			if (!TestSimulationMode)
			{
				RightDrone.ActivatePhysics();
			}
			LeftDrone.ActivatePhysics();
		}

		private void InitWinner(NimbatusDrone drone)
		{
			if (!_fightOver)
			{
				AudioController.StopCategory("Music");
				AudioController.PlayMusic(WinSFX);
				RuntimeGlobals.TimeScale = 0.025f;
				WinDisplay.text = drone.DroneData.DroneName + " " + LocalizationManager.GetTermTranslation("Racing/Wins");
				WinTexture.mainTexture = drone.DroneData.Image;
				_fightOver = true;
				GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.StoreMatchStatistics(drone == LeftDrone, LeftDrone, RightDrone, CurrentTime);
			}
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (!_fightOver && !TestSimulationMode && !GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining)
			{
				GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.StoreMatchStatistics(false, LeftDrone, RightDrone, CurrentTime);
			}
		}

		public void ExitRace()
		{
			if (!_fightOver && !TestSimulationMode && !GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining)
			{
				GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.StoreMatchStatistics(false, LeftDrone, RightDrone, CurrentTime);
			}
			NimbatusSceneManager.GoToBookmarkedScene();
		}

		private IEnumerator StartBattle()
		{
			AudioController.PlayMusic(WarmUpSFX);
			yield return new WaitForSeconds(StartDelay);
			AudioObject audioObject = AudioController.Play(BattleMusic);
			if (audioObject != null)
			{
				AudioController.PlayAfter(EndgameSFX, audioObject);
			}
			RuntimeGlobals.IsMovementBlocked = false;
			CurrentTime = BattleTime;
			while (true)
			{
				if (!TestSimulationMode)
				{
					if (!_fightOver && RuntimeGlobals.IsGameOver)
					{
						if (LeftDrone.RootDronePart.HealthPool.IsDead)
						{
							InitWinner(RightDrone);
						}
						else if (RightDrone.RootDronePart.HealthPool.IsDead)
						{
							InitWinner(LeftDrone);
						}
					}
				}
				else if (!_fightOver && RuntimeGlobals.IsGameOver && LeftDrone.RootDronePart.HealthPool.IsDead)
				{
					RuntimeGlobals.TimeScale = 0.05f;
					_fightOver = true;
				}
				yield return true;
				if (_fightOver)
				{
					if (TestSimulationMode)
					{
						yield return new WaitForSecondsRealtime(0.1f);
						RuntimeGlobals.IsGameOver = true;
					}
					else
					{
						yield return new WaitForSecondsRealtime(1f);
						RuntimeGlobals.IsGameOver = true;
					}
					continue;
				}
				CurrentTime = Mathf.Max(0f, CurrentTime - Time.deltaTime);
				TimeDisplay.text = CurrentTime.ToString("F2", CultureInfo.InvariantCulture);
				float num = RadiusModificationCurve.Evaluate(BattleTime - CurrentTime);
				Circle.SetRadius(num);
				CurrentRadius = num;
				if (CurrentTime <= 0f)
				{
					break;
				}
			}
			if (!TestSimulationMode)
			{
				WinDisplay.text = LocalizationManager.GetTermTranslation("Tournaments/Draw");
				RuntimeGlobals.TimeScale = 0.05f;
			}
			RuntimeGlobals.TimeScale = 0.05f;
			RuntimeGlobals.IsGameOver = true;
		}

		public void TriggerCircleCollision(Collider other)
		{
			if (_fightOver)
			{
				return;
			}
			if (TestSimulationMode)
			{
				if (other.gameObject == LeftDrone.RootDronePart.gameObject)
				{
					Circle.SetColor(OutsideColor);
					RuntimeGlobals.TimeScale = 0.05f;
					_fightOver = true;
				}
				return;
			}
			if (other.gameObject == LeftDrone.RootDronePart.gameObject)
			{
				Circle.SetColor(OutsideColor);
				InitWinner(RightDrone);
			}
			if (other.gameObject == RightDrone.RootDronePart.gameObject)
			{
				Circle.SetColor(OutsideColor);
				InitWinner(LeftDrone);
			}
		}

		public Vector2 GetOpponentPosition(NimbatusDrone rootDrone)
		{
			if (TestSimulationMode)
			{
				return Vector3.zero;
			}
			if (rootDrone == LeftDrone)
			{
				return RightDrone.RootDronePart.transform.position;
			}
			if (rootDrone == RightDrone)
			{
				return LeftDrone.RootDronePart.transform.position;
			}
			return Vector3.zero;
		}
	}
}
