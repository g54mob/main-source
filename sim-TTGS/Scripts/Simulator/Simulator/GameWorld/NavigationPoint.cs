using UnityEngine;

namespace Simulator.GameWorld
{
	public class NavigationPoint : MonoBehaviour
	{
		[Header("Navigation Point")]
		[SerializeField]
		private ENavigationPointType m_pointType;

		[SerializeField]
		[ReadOnly(true, false)]
		private bool m_register;

		[Header("Point Properties")]
		[SerializeField]
		[Range(0f, 5f)]
		private float m_radius;

		[Tooltip("Whether the character should ensure the same rotation as this navigation point")]
		[SerializeField]
		private bool m_ensureRotation;

		public ENavigationPointType PointType => m_pointType;

		public Vector3 Position => base.transform.position;

		public Vector3 Forward => base.transform.forward;

		public Quaternion Rotation => base.transform.rotation;

		public float Radius => m_radius;

		public bool EnsureRotation => m_ensureRotation;

		private void OnEnable()
		{
			if (m_register)
			{
				EventManager.OnWorldEvent += OnWorldEvent;
			}
		}

		private void OnDisable()
		{
			if (m_register)
			{
				EventManager.OnWorldEvent -= OnWorldEvent;
			}
		}

		private void OnWorldEvent(EWorldEvent worldEvent)
		{
			if (worldEvent == EWorldEvent.INITIALISATION)
			{
				World.AINavigation.Register(this);
			}
		}
	}
}
