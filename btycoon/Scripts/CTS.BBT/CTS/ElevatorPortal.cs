using System;
using System.Collections;
using System.Collections.Generic;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;
using DG.Tweening;
using UnityEngine;

namespace CTS
{
	public class ElevatorPortal : MonoBehaviour, IContextActor
	{
		private static readonly Dictionary<int, List<ElevatorPortal>> List = new Dictionary<int, List<ElevatorPortal>>();

		[SerializeField]
		private Transform[] _doors;

		[SerializeField]
		private Vector3[] _doorsOpenPositions;

		private Vector3[] _doorsClosedPositions;

		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; }

		public ElevatorPortal UpperFloor { get; set; }

		public ElevatorPortal LowerFloor { get; set; }

		public ElevatorLine Line { get; set; }

		public BarVisualObject RoomData { get; private set; }

		public bool IsOpen { get; private set; }

		[field: SerializeField]
		public int Floor { get; private set; }

		public AudioSource AudioSource { get; private set; }

		public static event Action<ElevatorPortal> ElevatorDoorOpening;

		public static event Action<ElevatorPortal> ElevatorDoorClosing;

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
		private static void Initialization()
		{
			List.Clear();
		}

		private void Awake()
		{
			AudioSource = GetComponent<AudioSource>();
			RoomData = GetComponentInParent<BarVisualObject>();
			_doorsClosedPositions = new Vector3[_doors.Length];
			for (int i = 0; i < _doors.Length; i++)
			{
				_doorsClosedPositions[i] = _doors[i].localPosition;
			}
		}

		private void Start()
		{
			ContextualActions component = GetComponent<ContextualActions>();
			Floor[] floors = MonoSingleton<FloorsManager>.Instance.Floors;
			foreach (Floor targetFloor in floors)
			{
				ContextualActionChangeFloor contextualActionChangeFloor = new ContextualActionChangeFloor
				{
					TargetFloor = targetFloor
				};
				contextualActionChangeFloor.Setup();
				component.Actions.Add(contextualActionChangeFloor);
			}
		}

		private void OnEnable()
		{
			if (!List.ContainsKey(Floor))
			{
				List.Add(Floor, new List<ElevatorPortal>());
			}
			List[Floor].Add(this);
		}

		private void OnDisable()
		{
			if (List.ContainsKey(Floor))
			{
				List[Floor].Remove(this);
			}
		}

		public static bool TryGet(int p_startFloor, int p_targetFloor, out ElevatorPortal p_elevatorPortal, out int p_actualTarget)
		{
			p_elevatorPortal = null;
			p_actualTarget = p_targetFloor;
			if (!List.ContainsKey(p_startFloor) || List[p_startFloor].Count <= 0)
			{
				return false;
			}
			p_elevatorPortal = List[p_startFloor][0];
			return false;
		}

		public IEnumerator SetOpen()
		{
			if (!IsOpen)
			{
				StopAllCoroutines();
				ElevatorPortal.ElevatorDoorOpening?.Invoke(this);
				float num = 0.5f;
				for (int i = 0; i < _doors.Length; i++)
				{
					Transform target = _doors[i];
					target.DOKill();
					target.DOLocalMove(_doorsOpenPositions[i], num);
				}
				yield return new WaitForSeconds(num);
				IsOpen = true;
			}
		}

		public void Close()
		{
			StartCoroutine(SetClosed());
		}

		public IEnumerator SetClosed()
		{
			if (IsOpen)
			{
				IsOpen = false;
				ElevatorPortal.ElevatorDoorClosing?.Invoke(this);
				float num = 0.5f;
				for (int i = 0; i < _doors.Length; i++)
				{
					Transform target = _doors[i];
					target.DOKill();
					target.DOLocalMove(_doorsClosedPositions[i], num);
				}
				yield return new WaitForSeconds(num);
			}
		}

		private void OnDrawGizmosSelected()
		{
			if (_doorsOpenPositions != null)
			{
				for (int i = 0; i < _doorsOpenPositions.Length; i++)
				{
					Gizmos.DrawSphere(_doors[i].TransformPoint(_doorsOpenPositions[i]), 0.15f);
				}
			}
		}
	}
}
