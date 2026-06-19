using System;
using System.Collections;
using PlayerState;
using PugPlatform;
using UnityEngine;

public class RichPresenceHandler : MonoBehaviour
{
	public RichPresenceSessionTypes sessionType;

	private string _lastSessionKey;

	private Biome _lastBiome;

	private int _lastNumberPlayers;

	private string _lastActivityString;

	private float _idleTime;

	private Vector3 _lastPlayerPosition;

	private void Awake()
	{
		if (RichPresence.Instance == null)
		{
			Debug.Log("no rich presence enabled, RichPresenceHandler disabled", base.gameObject);
			base.enabled = false;
		}
	}

	private void OnDestroy()
	{
		RichPresence.Instance?.EndSession();
	}

	private void Start()
	{
		RichPresence.Instance.StartSession(sessionType);
		if (sessionType == RichPresenceSessionTypes.InGame)
		{
			Manager.platform.forcePresenceJoinStringUpdate = true;
			StartCoroutine(UpdateRichPresenceInGameRoutine());
		}
	}

	private IEnumerator UpdateRichPresenceInGameRoutine()
	{
		string[] biomeNames = Enum.GetNames(typeof(Biome));
		while (true)
		{
			float deltaTime = 1f + UnityEngine.Random.value;
			yield return new WaitForSeconds(deltaTime);
			if (!(Manager.main.player == null) && Manager.ecs.ClientWorld != null)
			{
				string currentSessionID = Manager.networking.CurrentSessionID;
				if (_lastSessionKey != currentSessionID)
				{
					RichPresence.Instance.SetSessionKey(currentSessionID);
				}
				_lastSessionKey = currentSessionID;
				Biome biome = Manager.main.player.currentBiome;
				if (biome == Biome.None)
				{
					biome = _lastBiome;
				}
				if (_lastBiome != biome)
				{
					RichPresence.Instance.SetCurrentBiome(biomeNames[(int)biome]);
				}
				_lastBiome = biome;
				int numberPlayers = Manager.ecs.ClientWorld.GetExistingSystemManaged<WorldInfoSystem>().WorldInfo.numberPlayers;
				if (_lastNumberPlayers != numberPlayers)
				{
					RichPresence.Instance.SetPartySize(numberPlayers);
				}
				_lastNumberPlayers = numberPlayers;
				Vector3 worldPosition = Manager.main.player.WorldPosition;
				if (Vector3.SqrMagnitude(worldPosition - _lastPlayerPosition) < 1f)
				{
					_idleTime += deltaTime;
				}
				else
				{
					_lastPlayerPosition = worldPosition;
					_idleTime = 0f;
				}
				PlayerStateEnum level1State = EntityUtility.GetComponentData<PlayerStateCD>(Manager.main.player.entity, Manager.main.player.world).level1State;
				string text = (((level1State & PlayerStateEnum.Sleep) != PlayerStateEnum.Null) ? "Sleeping" : (((level1State & PlayerStateEnum.Fishing) != PlayerStateEnum.Null) ? "Fishing" : (((level1State & PlayerStateEnum.Death) == 0) ? ((_idleTime > 60f) ? "Idle" : "Exploring") : "Dying")));
				if (text != _lastActivityString)
				{
					RichPresence.Instance.SetCurrentTask(text);
				}
				_lastActivityString = text;
			}
		}
	}
}
