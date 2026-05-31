using UnityEngine;
using UnityEngine.SceneManagement;

namespace Photon.Pun.Demo.PunBasics
{
	public class PlayerManager : MonoBehaviourPunCallbacks, IPunObservable
	{
		[Tooltip("The current Health of our player")]
		public float Health;

		[Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
		public static GameObject LocalPlayerInstance;

		[Tooltip("The Player's UI GameObject Prefab")]
		[SerializeField]
		private GameObject playerUiPrefab;

		[Tooltip("The Beams GameObject to control")]
		[SerializeField]
		private GameObject beams;

		private bool IsFiring;

		private bool leavingRoom;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public override void OnDisable()
		{
		}

		public void Update()
		{
		}

		public override void OnLeftRoom()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerStay(Collider other)
		{
		}

		private void CalledOnLevelWasLoaded(int level)
		{
		}

		private void OnSceneLoaded(Scene scene, LoadSceneMode loadingMode)
		{
		}

		private void ProcessInputs()
		{
		}

		public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
		{
		}
	}
}
