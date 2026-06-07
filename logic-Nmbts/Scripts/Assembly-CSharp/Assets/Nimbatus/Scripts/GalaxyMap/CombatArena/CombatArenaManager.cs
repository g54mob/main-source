using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Assets.Nimbatus.Scripts.Behaviours.Health;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.Tournaments;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts.Drones;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.CombatArena
{
	public class CombatArenaManager : WaitForLoadBehaviour
	{
		public float StartDelay = 1f;

		public float BattleTime;

		public float Overtime;

		public NimbatusDrone LeftDrone;

		public NimbatusDrone RightDrone;

		public UILabel TimeDisplay;

		public TweenPosition WinPanel;

		public UILabel WinDisplay;

		public UITexture WinTexture;

		public TweenPosition DrawPanel;

		public UILabel LeftDrawLabel;

		public UITexture LeftDrawTexture;

		public UITexture LeftDestroyedPartProgress;

		public UILabel LeftDestroyedPartsCounter;

		public UILabel RightDrawLabel;

		public UITexture RightDrawTexture;

		public UITexture RightDestroyedPartProgress;

		public UILabel RightDestroyedPartsCounter;

		public CombatHealthBar LeftDroneHealthBar;

		public CombatHealthBar RightDroneHealthBar;

		public GameObject DamageField;

		public float DamageFieldFadeIn;

		public string WarmUpSfx;

		public string BattleMusic;

		public string WinSfx;

		public string TimeOutSfx;

		public string DamageFieldSound;

		[HideInInspector]
		public float CurrentTime;

		[HideInInspector]
		public float LeftDroneDamage;

		[HideInInspector]
		public float RightDroneDamage;

		private bool _fightOver;

		private bool _overtimeStarted;

		[HideInInspector]
		public static CombatArenaManager Instance { get; private set; }

		protected void Awake()
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
				RuntimeGlobals.Camera.AddPlayer(RightDrone.RootDronePart.transform, true, false, false);
				RuntimeGlobals.Camera.AddPlayer(LeftDrone.RootDronePart.transform, true, false, true);
			}
			RuntimeGlobals.IsMovementBlocked = true;
			StartCoroutine(StartBattle());
		}

		public override void WakeUp()
		{
			RightDrone.ActivatePhysics();
			LeftDrone.ActivatePhysics();
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			if (!_fightOver && !GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining)
			{
				GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.StoreMatchStatistics(false, LeftDrone, RightDrone, CurrentTime);
			}
		}

		private IEnumerator StartBattle()
		{
			CurrentTime = BattleTime;
			TimeDisplay.text = CurrentTime.ToString("F2", CultureInfo.InvariantCulture);
			LeftDroneHealthBar.Init(LeftDrone);
			RightDroneHealthBar.Init(RightDrone);
			DamageField.SetActive(false);
			AudioController.PlayMusic(WarmUpSfx);
			yield return new WaitForSeconds(StartDelay);
			AudioController.Play(BattleMusic);
			RuntimeGlobals.IsMovementBlocked = false;
			while (true)
			{
				if (_fightOver)
				{
					yield return new WaitForSecondsRealtime(1f);
					RuntimeGlobals.TimeScale = 0.025f;
					RuntimeGlobals.IsGameOver = true;
				}
				else
				{
					CurrentTime = Mathf.Max(0f, CurrentTime - Time.deltaTime);
					TimeDisplay.text = CurrentTime.ToString("F2", CultureInfo.InvariantCulture);
					if (CurrentTime <= 0f && !_overtimeStarted)
					{
						StartCoroutine(DamageDrones());
						_overtimeStarted = true;
					}
					if (LeftDrone.RootDronePart.HealthPool.IsDead || RightDrone.RootDronePart.HealthPool.IsDead)
					{
						StartCoroutine(WaitForWinner());
					}
				}
				yield return true;
			}
		}

		private IEnumerator DamageDrones()
		{
			StartCoroutine(StartDamageField());
			AudioController.Play(TimeOutSfx);
			AudioController.Play(DamageFieldSound);
			List<DronePart> parts = Object.FindObjectsOfType<DronePart>().ToList();
			while (!_fightOver)
			{
				foreach (DronePart item in parts.ToList())
				{
					if (item == null || item.HealthPool == null || item.HealthPool.IsDead)
					{
						parts.Remove(item);
						continue;
					}
					float num = item.HealthPool.ActiveMaxHealth / Overtime;
					item.HealthPool.TakeDamageSimple(num * Time.deltaTime, EDamageReason.Environment);
				}
				yield return null;
			}
		}

		private IEnumerator StartDamageField()
		{
			DamageField.SetActive(true);
			Material mat = DamageField.GetComponent<Renderer>().material;
			mat.SetFloat("_FadeIn", 0f);
			float t = 0f;
			while (t < DamageFieldFadeIn)
			{
				t += Time.deltaTime;
				mat.SetFloat("_FadeIn", t / DamageFieldFadeIn);
				yield return null;
			}
			mat.SetFloat("_FadeIn", 1f);
		}

		private IEnumerator WaitForWinner()
		{
			if (_fightOver)
			{
				yield break;
			}
			_fightOver = true;
			AudioController.Stop(DamageFieldSound);
			yield return new WaitForEndOfFrame();
			if (LeftDrone.RootDronePart.HealthPool.IsDead && RightDrone.RootDronePart.HealthPool.IsDead)
			{
				NimbatusDrone winner = ((LeftDroneDamage > RightDroneDamage) ? LeftDrone : ((RightDroneDamage > LeftDroneDamage) ? RightDrone : null));
				if (winner != null)
				{
					LeftDrawLabel.text = LeftDrone.DroneData.DroneName;
					LeftDrawTexture.mainTexture = LeftDrone.DroneData.Image;
					RightDrawLabel.text = RightDrone.DroneData.DroneName;
					RightDrawTexture.mainTexture = RightDrone.DroneData.Image;
					LeftDestroyedPartProgress.fillAmount = 0f;
					LeftDestroyedPartsCounter.text = "0";
					RightDestroyedPartProgress.fillAmount = 0f;
					RightDestroyedPartsCounter.text = "0";
					DrawPanel.PlayForward();
					yield return new WaitForSecondsRealtime(DrawPanel.duration + 0.5f);
					float max = Mathf.Max(LeftDroneDamage, RightDroneDamage);
					float leftT = max / LeftDroneDamage;
					float rightT = max / RightDroneDamage;
					float t = 0f;
					while (t < 1f)
					{
						t += Time.unscaledDeltaTime / 2f;
						float value = Mathf.Lerp(0f, LeftDroneDamage, t * leftT);
						LeftDestroyedPartProgress.fillAmount = Mathf.InverseLerp(0f, max, value);
						LeftDestroyedPartsCounter.text = value.ToString("F0");
						float value2 = Mathf.Lerp(0f, RightDroneDamage, t * rightT);
						RightDestroyedPartProgress.fillAmount = Mathf.InverseLerp(0f, max, value2);
						RightDestroyedPartsCounter.text = value2.ToString("F0");
						yield return null;
					}
					LeftDestroyedPartProgress.fillAmount = Mathf.InverseLerp(0f, max, LeftDroneDamage);
					LeftDestroyedPartsCounter.text = LeftDroneDamage.ToString("F0");
					RightDestroyedPartProgress.fillAmount = Mathf.InverseLerp(0f, max, RightDroneDamage);
					RightDestroyedPartsCounter.text = RightDroneDamage.ToString("F0");
					yield return new WaitForSecondsRealtime(1f);
					InitWinner(winner);
				}
				else
				{
					InitWinner(null);
				}
			}
			else if (LeftDrone.RootDronePart.HealthPool.IsDead)
			{
				InitWinner(RightDrone);
			}
			else if (RightDrone.RootDronePart.HealthPool.IsDead)
			{
				InitWinner(LeftDrone);
			}
		}

		private void InitWinner(NimbatusDrone drone)
		{
			AudioController.StopCategory("Music");
			AudioController.PlayMusic(WinSfx);
			WinPanel.PlayForward();
			if (drone != null)
			{
				WinDisplay.text = drone.DroneData.DroneName + " " + LocalizationManager.GetTermTranslation("Racing/Wins");
				WinTexture.mainTexture = drone.DroneData.Image;
			}
			else
			{
				WinDisplay.text = LocalizationManager.GetTermTranslation("Tournaments/Draw");
			}
			GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.StoreMatchStatistics(drone == LeftDrone, LeftDrone, RightDrone, CurrentTime);
		}

		public void ExitRace()
		{
			if (!_fightOver && !GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.IsInTraining)
			{
				GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.StoreMatchStatistics(false, LeftDrone, RightDrone, CurrentTime);
			}
			NimbatusSceneManager.GoToBookmarkedScene();
		}

		public Vector2 GetOpponentPosition(NimbatusDrone rootDrone)
		{
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
