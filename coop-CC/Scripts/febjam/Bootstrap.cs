using System.Collections;
using Aggro.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bootstrap : MonoBehaviour
{
	public enum BootstrapType
	{
		Gym = 0,
		Lobby = 1,
		Tutorial = 2
	}

	public BootstrapType type;

	private void Start()
	{
		if (!GameSettings.hasSettings && SceneManager.GetActiveScene() == base.gameObject.scene)
		{
			StartCoroutine(BootstrapCo());
		}
	}

	private IEnumerator BootstrapCo()
	{
		if (!SceneUtil.IsSceneLoaded("scene-game"))
		{
			yield return SceneManager.LoadSceneAsync("scene-game", LoadSceneMode.Additive);
		}
		yield return null;
		GameSettings gameSettings = default(GameSettings);
		switch (type)
		{
		case BootstrapType.Gym:
			gameSettings.loadType = GameLoadType.Gym;
			gameSettings.networkType = NetworkType.SinglePlayer;
			gameSettings.scene = base.gameObject.scene.name;
			break;
		case BootstrapType.Lobby:
			gameSettings.loadType = GameLoadType.Lobby;
			gameSettings.networkType = NetworkType.Host;
			gameSettings.port = 7777;
			gameSettings.allowFriends = true;
			break;
		case BootstrapType.Tutorial:
			gameSettings.loadType = GameLoadType.Tutorial;
			break;
		default:
			throw new InvalidEnumException();
		}
		GameSettings.Set(gameSettings);
	}
}
