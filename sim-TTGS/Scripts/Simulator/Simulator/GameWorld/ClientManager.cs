using System.Collections.Generic;
using System.Linq;
using Dhs5.Utility.Updates;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ClientManager : WorldManager
	{
		[Header("Containers")]
		[SerializeField]
		private Transform m_behavioursContainer;

		private Dictionary<int, AIClientBehaviour> m_clientsByID = new Dictionary<int, AIClientBehaviour>();

		private Dictionary<AIClientBehaviour, ClientCharacter> m_activeClients = new Dictionary<AIClientBehaviour, ClientCharacter>();

		private float m_timeSinceLastUpdate;

		private float m_spawnScore;

		private int m_lastClientGameID;

		public bool EnableSpawn { get; private set; }

		public float EnteringShopPercentage => ScoreSettings.EnteringShopPercentageOnScoreChanged.GetComputedValue(AIClientSettings.EnterShopPercentage);

		public AIClientBehaviour GetClientByID(int gameID)
		{
			if (m_clientsByID.TryGetValue(gameID, out var value))
			{
				return value;
			}
			return null;
		}

		public ClientCharacter GetAIBehaviourCharacter(AIClientBehaviour behaviour)
		{
			if (m_activeClients.TryGetValue(behaviour, out var value))
			{
				return value;
			}
			return null;
		}

		public ClientCharacter GetAIBehaviourCharacter(int gameID)
		{
			if (m_clientsByID.TryGetValue(gameID, out var value) && m_activeClients.TryGetValue(value, out var value2))
			{
				return value2;
			}
			return null;
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			Updater.RegisterChannelCallback(register: true, EUpdateChannel.AI, OnUpdate);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			Updater.RegisterChannelCallback(register: false, EUpdateChannel.AI, OnUpdate);
		}

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.LOADING_PHASE1:
				LoadPhase1();
				break;
			case EWorldEvent.LOADING_PHASE2:
				LoadPhase2();
				break;
			case EWorldEvent.INITIALISATION:
				InitPostLoad();
				break;
			case EWorldEvent.SAVE:
				Save();
				break;
			case EWorldEvent.PREPARE_QUIT:
				EnableSpawn = false;
				break;
			case EWorldEvent.START:
			case EWorldEvent.PAUSE:
			case EWorldEvent.UNPAUSE:
				break;
			}
		}

		protected override void OnGameEvent(EGameEvent gameEvent)
		{
			base.OnGameEvent(gameEvent);
			switch (gameEvent)
			{
			case EGameEvent.DAY_START:
				EnableSpawn = true;
				m_timeSinceLastUpdate = 0f;
				SpawnDayStartClients(AIClientSettings.StartSpawnScore / AIClientSettings.SpawnScoreGoal);
				m_spawnScore = AIClientSettings.StartSpawnScore % AIClientSettings.SpawnScoreGoal;
				break;
			case EGameEvent.NIGHT:
				EnableSpawn = false;
				break;
			case EGameEvent.DAY_CLEANUP:
				CleanUp();
				break;
			}
		}

		private void LoadPhase1()
		{
			m_lastClientGameID = 0;
			EnableSpawn = SaveManager.CurrentSave.clients.enableSpawn;
			bool flag = SaveManager.CurrentSave.clients.spawnScore == 0;
			m_spawnScore = (flag ? SaveManager.CurrentSave.clients.spawnScoreFloat : ((float)SaveManager.CurrentSave.clients.spawnScore));
			foreach (SaveClass_Clients.ClientState clientState in SaveManager.CurrentSave.GetClientStates())
			{
				LoadClient(clientState);
			}
		}

		private void LoadPhase2()
		{
			foreach (SaveClass_Clients.ClientState clientState in SaveManager.CurrentSave.GetClientStates())
			{
				if (m_clientsByID.TryGetValue(clientState.gameID, out var value))
				{
					value.Load(2, clientState);
				}
			}
		}

		private void InitPostLoad()
		{
			foreach (SaveClass_Clients.ClientState clientState in SaveManager.CurrentSave.GetClientStates())
			{
				if (m_clientsByID.TryGetValue(clientState.gameID, out var value))
				{
					value.InitPostLoad();
				}
			}
		}

		private void Save()
		{
			SaveManager.CurrentSave.StartClientSaveProcess();
			SaveManager.CurrentSave.clients.enableSpawn = EnableSpawn;
			SaveManager.CurrentSave.clients.spawnScoreFloat = m_spawnScore;
			foreach (var (client, character) in m_activeClients)
			{
				SaveManager.CurrentSave.SaveClient(client, character);
			}
		}

		private void OnUpdate(float deltaTime)
		{
			if (EnableSpawn)
			{
				m_timeSinceLastUpdate += deltaTime;
				if (m_timeSinceLastUpdate >= 1f)
				{
					m_timeSinceLastUpdate -= 1f;
					IncrementSpawnScore();
				}
			}
		}

		private void IncrementSpawnScore()
		{
			m_spawnScore = ScoreSettings.SpawnScoreOnScoreChanged.GetComputedValue(m_spawnScore);
			m_spawnScore += GetSpawnScoreIncrementation();
			if (m_spawnScore >= (float)AIClientSettings.SpawnScoreGoal)
			{
				SpawnNewClient(World.AINavigation.GetRandomSpawnPoint());
				m_spawnScore -= AIClientSettings.SpawnScoreGoal;
			}
		}

		protected virtual int GetSpawnScoreIncrementation()
		{
			float randomSpawnIncrement = AIClientSettings.GetRandomSpawnIncrement();
			float num = (TimeController.IsDay ? AIClientSettings.SpawnScoreDayMultiplier : 0.1f);
			if (World.Shop.Open)
			{
				num += AIClientSettings.SpawnScoreAttractionMultiplier * (float)GameState.AttractionScore;
			}
			return Mathf.FloorToInt(randomSpawnIncrement * num);
		}

		protected int GetUniqueGameID()
		{
			m_lastClientGameID++;
			return m_lastClientGameID;
		}

		private void SpawnNewClient(NavigationPoint spawnPoint)
		{
			if (SpawnClient(spawnPoint.Position, spawnPoint.Rotation, out var behaviour, out var _))
			{
				behaviour.Init(GetUniqueGameID());
				m_clientsByID.Add(behaviour.GameID, behaviour);
			}
		}

		private void SpawnDayStartClients(int count)
		{
			World.AINavigation.PrepareStartSpawnPoints();
			for (int i = 0; i < count; i++)
			{
				SpawnNewClient(World.AINavigation.GetRandomStartSpawnPoint());
			}
		}

		private void LoadClient(SaveClass_Clients.ClientState state)
		{
			if (SpawnClient(state.position, state.rotation, out var behaviour, out var _, state.modelIndex))
			{
				behaviour.Load(1, state);
				m_clientsByID.Add(state.gameID, behaviour);
			}
			if (state.gameID > m_lastClientGameID)
			{
				m_lastClientGameID = state.gameID;
			}
		}

		protected bool SpawnClient(Vector3 position, Quaternion rotation, out AIClientBehaviour behaviour, out ClientCharacter character, int modelIndex = -1)
		{
			behaviour = Object.Instantiate(AIClientSettings.ClientControllerPrefab, position, rotation, m_behavioursContainer).GetComponent<AIClientBehaviour>();
			character = Object.Instantiate(AIClientSettings.GetClientCharacterPrefab(modelIndex), position, rotation).GetComponent<ClientCharacter>();
			if (behaviour != null && character != null)
			{
				m_activeClients.Add(behaviour, character);
				if (!behaviour.TakeControlOfCharacter(character))
				{
					DestroyClient(behaviour);
				}
				return true;
			}
			return false;
		}

		public void DestroyClient(AIClientBehaviour behaviour)
		{
			if (m_activeClients.TryGetValue(behaviour, out var value))
			{
				m_clientsByID.Remove(behaviour.GameID);
				m_activeClients.Remove(behaviour);
				Object.Destroy(value.gameObject);
			}
			Object.Destroy(behaviour.gameObject);
		}

		private void CleanUp()
		{
			foreach (AIClientBehaviour item in m_activeClients.Keys.ToList())
			{
				DestroyClient(item);
			}
		}
	}
}
