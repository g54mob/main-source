using Unity.Cinemachine;
using UnityEngine;

namespace Player.Cam
{
	public class PlayerCameraService : MonoBehaviour, ok
	{
		[SerializeField]
		private Camera m_defaultCamera;

		[SerializeField]
		private CinemachineCamera m_cinemachineCamera;

		[SerializeField]
		private CinemachineBrain m_cinemachineBrain;

		[SerializeField]
		private Transform m_pivot;

		[SerializeField]
		private CinemachinePanTilt m_panTilt;

		[SerializeField]
		private CinemachineInputAxisController m_inputAxisController;

		private bool qul;

		private float qum;

		private float qun;

		public Transform xcx => null;

		public Camera xcu => null;

		public CinemachineCamera xcv => null;

		public Transform xcw => null;

		public Vector3 xcz => default(Vector3);

		public Quaternion xcy => default(Quaternion);

		public CinemachinePanTilt xda => null;

		public CinemachineInputAxisController xdb => null;

		public float xdc
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		public void ftx(Transform a)
		{
		}

		public void fty()
		{
		}

		public void ftz()
		{
		}

		private Transform fuc()
		{
			return null;
		}

		private Vector3 fud()
		{
			return default(Vector3);
		}

		private Quaternion fue()
		{
			return default(Quaternion);
		}
	}
}
