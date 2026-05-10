using ScheduleOne.Audio;
using ScheduleOne.PlayerTasks;
using UnityEngine;
using UnityEngine.Events;

namespace ScheduleOne.StationFramework
{
	public class SporeSyringeStationItem : StationItem
	{
		public const float MaxAngleDifferenceForInjection = 35f;

		public const float PlungerPushSpeed = 0.8f;

		public const float PlungerDragDistanceMultiplier = 2f;

		[SerializeField]
		private GameObject _capHighlight;

		[SerializeField]
		private Transform _capContainer;

		[SerializeField]
		private Clickable _capClickable;

		[SerializeField]
		private Draggable _syringeDraggable;

		[SerializeField]
		private GameObject _plungerHighlight;

		[SerializeField]
		private Transform _plungerTransform;

		[SerializeField]
		private Transform _plungerExtendedPosition;

		[SerializeField]
		private Transform _plungerCompressedPosition;

		[SerializeField]
		private Transform _liquidTransform;

		[SerializeField]
		private Clickable _plungerClickable;

		[SerializeField]
		private AudioSourceController _plungerSound;

		private Collider _injectionPortCollider;

		public UnityEvent onCapRemoved;

		public UnityEvent onInserted;

		public UnityEvent<float> onPlungerMoved;

		private bool _capRemoved;

		private Vector3 _initialPlungerHitPoint;

		private float timeOnPlungerClickStart;

		public float PlungerPosition { get; private set; }

		protected override void Awake()
		{
		}

		private void LateUpdate()
		{
		}

		public void SetCapInteractable(bool interactable)
		{
		}

		public void SetInjectionPortCollider(Collider collider)
		{
		}

		private void RemoveCap()
		{
		}

		public void SetSyringeDraggable(bool draggable)
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		private void InsertSyringe()
		{
		}

		public void SetPlungerInteractable(bool interactable)
		{
		}

		private void SetPlungerPosition(float position)
		{
		}

		private void OnPlungerClickStart(RaycastHit hit)
		{
		}

		private void OnPlungerClickEnd()
		{
		}

		private Vector3 GetPlungerPlaneHit()
		{
			return default(Vector3);
		}
	}
}
