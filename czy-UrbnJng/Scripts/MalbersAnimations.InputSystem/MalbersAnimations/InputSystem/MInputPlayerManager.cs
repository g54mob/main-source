using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MalbersAnimations.InputSystem
{
	[AddComponentMenu("Malbers/Input/MInput Player Manager")]
	public class MInputPlayerManager : MonoBehaviour
	{
		public PlayerInputManager Manager;

		[SerializeField]
		private List<LayerMask> playerLayers;

		public List<PlayerInput> players;

		public List<Transform> SpawnPoints = new List<Transform>();

		private int NextPoint;

		public PlayerInputManager.PlayerJoinedEvent OnPlayerJoined = new PlayerInputManager.PlayerJoinedEvent();

		public PlayerInputManager.PlayerJoinedEvent OnPlayerLeft = new PlayerInputManager.PlayerJoinedEvent();

		private void OnEnable()
		{
			if (Manager == null)
			{
				Manager = Object.FindFirstObjectByType<PlayerInputManager>();
			}
			if (Manager != null)
			{
				Manager.onPlayerJoined += PlayerJoined;
				Manager.onPlayerLeft += PlayerLeft;
			}
		}

		private void OnDisable()
		{
			if (Manager != null)
			{
				Manager.onPlayerJoined -= PlayerJoined;
				Manager.onPlayerLeft -= PlayerLeft;
			}
		}

		public void PlayerJoined(PlayerInput player)
		{
			Debug.Log("Player Joined " + player.name);
			players.Add(player);
			player.transform.position = SpawnPoints[NextPoint].position;
			CameraLayerSettings(player);
			NextPoint = (NextPoint + 1) % SpawnPoints.Count;
			OnPlayerJoined.Invoke(player);
		}

		private void CameraLayerSettings(PlayerInput player)
		{
			player.name += $"[{player.playerIndex}]";
			int num = (int)Mathf.Log(playerLayers[NextPoint].value, 2f);
			CinemachineVirtualCameraBase[] componentsInChildren = player.transform.root.GetComponentsInChildren<CinemachineVirtualCameraBase>();
			CinemachineVirtualCameraBase[] array = componentsInChildren;
			foreach (CinemachineVirtualCameraBase obj in array)
			{
				obj.gameObject.SetActive(value: false);
				obj.name += $"[{player.playerIndex}]";
				obj.gameObject.SetLayer(num);
			}
			Camera camera = player.FindComponent<Camera>();
			camera.name += $"[{player.playerIndex}]";
			int num2 = camera.cullingMask;
			foreach (LayerMask playerLayer in playerLayers)
			{
				if ((int)playerLayer != 1 << num)
				{
					num2 &= ~(int)playerLayer;
				}
			}
			camera.cullingMask = num2;
			array = componentsInChildren;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].gameObject.SetActive(value: true);
			}
		}

		public void PlayerLeft(PlayerInput input)
		{
			OnPlayerLeft.Invoke(input);
		}
	}
}
