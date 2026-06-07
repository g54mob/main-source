using System.Collections;
using Assets.Nimbatus.GUI.MainScene.Scripts;
using Assets.Nimbatus.Scripts.Common.LevelTransition;
using Assets.Nimbatus.Scripts.GalaxyMap.Locations;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Boss
{
	public abstract class BossfightManager : WaitForLoadBehaviour
	{
		[HideInInspector]
		public BossFight Settings;

		[Header("General")]
		public ShowBossfightStarted StartPanel;

		public ShowBossfightCompleted CompletePanel;

		[HideInInspector]
		public static BossfightManager Instance { get; private set; }

		protected virtual void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
			}
			Settings = ((BossfightLocationData)SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation).Fight;
			RuntimeGlobals.IsMovementBlocked = true;
		}

		public override void WakeUp()
		{
			RuntimeGlobals.IsMovementBlocked = false;
			Init();
			StartCoroutine(ShowStart());
		}

		public abstract void Init();

		private IEnumerator ShowStart()
		{
			if (!(StartPanel == null))
			{
				while (RuntimeGlobals.IsGameLoading)
				{
					yield return null;
				}
				StartPanel.Activate(Settings);
			}
		}

		public void GameOver()
		{
			if (CompletePanel != null)
			{
				CompletePanel.Activate(Settings, false);
			}
		}

		public void FinishBossfight()
		{
			StartCoroutine(Finish());
		}

		private IEnumerator Finish()
		{
			((BossfightLocationData)SerializableMonobehaviour<GalaxyMapManager, GalaxyMapSaveData>.Instance.CurrentLocation).SetBossfightCompleted();
			if (CompletePanel != null)
			{
				CompletePanel.Activate(Settings, true);
			}
			yield return new WaitForSeconds(3f);
			NimbatusSceneManager.SetReturnScene("MissionRewardScene", "MissionControlScene");
			NimbatusSceneManager.LoadScene("MissionRewardScene");
		}
	}
}
