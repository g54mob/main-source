using System;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using Assets.Nimbatus.Scripts.World.Terrain.TerrainSettings;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Tutorial.TutorialScenes
{
	public abstract class GenericTutorialLogic : MonoBehaviour
	{
		[HideInInspector]
		public bool TutorialFinished;

		[HideInInspector]
		public bool IsDroneDead;

		[HideInInspector]
		public bool IsTargetDestroyed;

		public Transform TargetCursor;

		private float _cursorTime;

		public static GenericTutorialLogic Instance { get; private set; }

		public void OnEnable()
		{
			Instance = this;
		}

		public void OnDisable()
		{
			Instance = null;
		}

		public void Start()
		{
			RuntimeGlobals.ResetToDefault();
			RuntimeGlobals.RunningMode = ERunningMode.Tutorial;
			WorldController.TerrainSettings.Gravity = EGravity.None;
			WorldController.TerrainSettings.TestSimulationAirResistance = EAirResistance.Normal;
			Debug.Log("Initialized Tutorial Mode");
		}

		public abstract bool IsCompleted();

		public abstract string TutorialLabel();

		public abstract Vector3 CursorPosition();

		public abstract bool IsCursorVisible();

		public abstract void OnUpdate();

		protected void Update()
		{
			OnUpdate();
			if (TargetCursor != null)
			{
				TargetCursor.gameObject.SetActive(IsCursorVisible());
			}
			if (TargetCursor != null)
			{
				Vector3 to = CursorPosition() - RuntimeGlobals.NimbatusPlayer.transform.position;
				float num = 5f;
				float num2 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0.5f, 1f, RuntimeGlobals.Camera.Camera.transform.position.z)).y - RuntimeGlobals.NimbatusPlayer.transform.position.y - num;
				float num3 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, RuntimeGlobals.Camera.Camera.transform.position.z)).y - RuntimeGlobals.NimbatusPlayer.transform.position.y + num;
				float num4 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(1f, 0.5f, RuntimeGlobals.Camera.Camera.transform.position.z)).x - RuntimeGlobals.NimbatusPlayer.transform.position.x - num;
				float num5 = RuntimeGlobals.Camera.Camera.ViewportToWorldPoint(new Vector3(0f, 0.5f, RuntimeGlobals.Camera.Camera.transform.position.z)).x - RuntimeGlobals.NimbatusPlayer.transform.position.x + num;
				float num6 = Vector3.SignedAngle(Vector3.right, to, Vector3.forward);
				float num7 = Mathf.Min(num4, CursorPosition().x - RuntimeGlobals.NimbatusPlayer.transform.position.x) / Mathf.Cos(num6 * ((float)Math.PI / 180f));
				float num8 = Mathf.Max(num5, CursorPosition().x - RuntimeGlobals.NimbatusPlayer.transform.position.x) / Mathf.Cos(num6 * ((float)Math.PI / 180f));
				float num9 = Mathf.Min(num2, CursorPosition().y - RuntimeGlobals.NimbatusPlayer.transform.position.y) / Mathf.Sin(num6 * ((float)Math.PI / 180f));
				float num10 = Mathf.Max(num3, CursorPosition().y - RuntimeGlobals.NimbatusPlayer.transform.position.y) / Mathf.Sin(num6 * ((float)Math.PI / 180f));
				num6 = Mathf.Atan2(to.y, to.x) * 57.29578f;
				float num11 = Mathf.Atan2(num3, num4) * 57.29578f;
				float num12 = Mathf.Atan2(num2, num4) * 57.29578f;
				float num13 = Mathf.Atan2(num2, num5) * 57.29578f;
				float num14 = Mathf.Atan2(num3, num5) * 57.29578f;
				Debug.DrawRay(RuntimeGlobals.NimbatusPlayer.transform.position, new Vector2(num4, num3), Color.green);
				Debug.DrawRay(RuntimeGlobals.NimbatusPlayer.transform.position, new Vector2(num4, num2), Color.green);
				Debug.DrawRay(RuntimeGlobals.NimbatusPlayer.transform.position, new Vector2(num5, num2), Color.green);
				Debug.DrawRay(RuntimeGlobals.NimbatusPlayer.transform.position, new Vector2(num5, num3), Color.green);
				num6 = Mathf.Repeat(num6 + 360f, 360f);
				num11 = Mathf.Repeat(num11 + 360f, 360f);
				num12 = Mathf.Repeat(num12 + 360f, 360f);
				num13 = Mathf.Repeat(num13 + 360f, 360f);
				num14 = Mathf.Repeat(num14 + 360f, 360f);
				float num15 = 0f;
				if (num6 >= 0f)
				{
					num15 = num7;
				}
				if (num6 >= num12)
				{
					num15 = num9;
				}
				if (num6 >= num13)
				{
					num15 = num8;
				}
				if (num6 >= num14)
				{
					num15 = num10;
				}
				if (num6 >= num11)
				{
					num15 = num7;
				}
				Debug.DrawLine(CursorPosition(), RuntimeGlobals.NimbatusPlayer.transform.position, Color.white);
				Debug.DrawRay(RuntimeGlobals.NimbatusPlayer.transform.position, to.normalized * num15, Color.red);
				num15 += (Mathf.Sin(Time.time * 6.5f) - 1f) / 2f * 5f;
				TargetCursor.position = RuntimeGlobals.NimbatusPlayer.transform.position + to.normalized * num15;
				float num16 = Mathf.Atan2(to.y, to.x);
				TargetCursor.eulerAngles = new Vector3(0f, 0f, num16 * 57.29578f);
			}
			if (IsCompleted() && !TutorialFinished)
			{
				FinishTutorial();
			}
		}

		public void FinishTutorial()
		{
			TutorialFinished = true;
			RuntimeGlobals.IsGameOver = true;
			RuntimeGlobals.IsMovementBlocked = true;
		}

		public void BackToWorkshop(bool retry)
		{
			RuntimeGlobals.IsGameOver = false;
			RuntimeGlobals.IsGamePaused = false;
			if (TutorialFinished)
			{
				if (retry)
				{
					TutorialFinished = false;
					GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.SaveTutorial();
				}
				else if (GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.HasNextSubtutorial())
				{
					GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.StartSubtutorial();
				}
				else
				{
					TutorialFinished = false;
					GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.SaveTutorial();
				}
			}
			NimbatusSceneManager.LoadScene("DroneWorkshopScene");
		}

		public void BackToMenu()
		{
			RuntimeGlobals.IsGameOver = false;
			RuntimeGlobals.IsGamePaused = false;
			if (TutorialFinished)
			{
				GlobalSerializableMonobehaviour<TutorialManager, TutorialSaveData>.Instance.TutorialSuccessful();
			}
			NimbatusSceneManager.LoadScene("MainMenuScene");
		}
	}
}
