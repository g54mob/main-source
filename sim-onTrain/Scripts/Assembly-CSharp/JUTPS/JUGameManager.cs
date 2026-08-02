using UnityEngine;

namespace JUTPS
{
	[AddComponentMenu("JU TPS/Gameplay/Game/Game Manager")]
	public class JUGameManager : MonoBehaviour
	{
		[HideInInspector]
		public static JUCharacterController InstancedPlayer;

		public static bool IsMobile;

		[SerializeField]
		private bool SimulateMobileDevice;

		private bool isInitialized;

		private void OnEnable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		}

		private void OnDisable()
		{
			Singleton<TSNetworkObjetManager>.Instance?.OnServerInitialize.RemoveListener(Initialize);
		}

		private void Initialize(TSPlayerController tsPlayer)
		{
			if (isInitialized)
			{
				isInitialized = true;
				return;
			}
			if (InstancedPlayer == null)
			{
				GameObject gameObject = tsPlayer.gameObject;
				InstancedPlayer = ((gameObject != null) ? gameObject.GetComponent<JUCharacterController>() : null);
			}
			IsMobile = SimulateMobileDevice || SystemInfo.deviceType == DeviceType.Handheld;
		}

		private void OnDestroy()
		{
			InstancedPlayer = null;
		}
	}
}
