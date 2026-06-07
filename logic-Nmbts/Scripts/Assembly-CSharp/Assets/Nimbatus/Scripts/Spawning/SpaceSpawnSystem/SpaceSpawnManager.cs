using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Characters.Player;
using Assets.Nimbatus.Scripts.Missions;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.World;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Spawning.SpaceSpawnSystem
{
	public class SpaceSpawnManager : MonoBehaviour
	{
		public ArrangeStartPosition PositionArranger;

		private System.Random _randomGenerator;

		public bool GameOverOnMissionFail;

		public IEnumerator Start()
		{
			RuntimeGlobals.IsGameLoading = true;
			PositionArranger.Arrange();
			System.Random random = new System.Random(WorldController.Seed);
			yield return StartSpawn(random);
			SerializableMonobehaviour<MissionManager, MissionData>.Instance.InitMissions();
			RuntimeGlobals.IsGameLoading = false;
		}

		public void OnEnable()
		{
			MissionManager.OnMissionFailed += MissionManager_MissionFailed;
		}

		public void OnDisable()
		{
			MissionManager.OnMissionFailed -= MissionManager_MissionFailed;
		}

		private void MissionManager_MissionFailed(NimbatusMission obj)
		{
			if (GameOverOnMissionFail)
			{
				RuntimeGlobals.IsGameOver = true;
			}
		}

		public IEnumerator StartSpawn(System.Random random)
		{
			_randomGenerator = random;
			if (SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission != null)
			{
				yield return StartCoroutine(DoSpawn(SerializableMonobehaviour<MissionManager, MissionData>.Instance.ActiveMission.SpaceSpawnSettings));
			}
		}

		private IEnumerator DoSpawn(List<SpaceSpawnSetting> spawnsettings)
		{
			if (spawnsettings != null && spawnsettings.Count > 0)
			{
				foreach (SpaceSpawnSetting spawnsetting in spawnsettings)
				{
					spawnsetting.Init(_randomGenerator);
				}
				foreach (SpaceSpawnSetting spawnsetting2 in spawnsettings)
				{
					spawnsetting2.TryToSpawn();
					yield return true;
				}
			}
			yield return true;
		}
	}
}
