using System;
using System.Collections.Generic;
using MalbersAnimations.Events;
using UnityEngine;
using UnityEngine.Events;

namespace MalbersAnimations
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/ai/ai-target")]
	[AddComponentMenu("Malbers/AI/AI Target")]
	[SelectionBase]
	public class AITarget : MonoBehaviour, IAITargeterTarget, IAITarget
	{
		public WayPointType pointType;

		public ICharacterAction character;

		[Tooltip("Distance for AI driven animals to stop when arriving to this gameobject. When is set as the AI Target.")]
		[Min(0f)]
		public float stoppingDistance = 1f;

		[Tooltip("Distance for AI driven animals to start slowing its speed when arriving to this gameobject. If its set to zero or lesser than the Stopping distance, the Slowing Movement Logic will be ignored")]
		[Min(0f)]
		public float slowingDistance;

		[Tooltip("Offset to correct the Position of the Target")]
		[SerializeField]
		private Vector3 center;

		[Tooltip("Default Height for the Waypoints")]
		[SerializeField]
		private float m_height = 0.5f;

		[Tooltip(" When the AI  arrives to this target, The character will rotate in place to  looks at the center of the AI Target?")]
		[SerializeField]
		private bool m_arriveLookAt = true;

		[Min(0f)]
		[Tooltip("How many AI character can target this gameObject at the same time. Zero means infinite targets")]
		public int m_TargetLimit;

		[Tooltip("Distance for AI driven animals to stop when arriving to this gameobject. When is set as the AI Target.")]
		[Hide("m_TargetLimit", true)]
		[Min(0f)]
		public float m_targeterStopDistance = 0.2f;

		[Hide("m_TargetLimit", true)]
		[Tooltip("Distance the AI has to wait if all the spots on this Target are ocupied")]
		[Min(0f)]
		public float m_WaitTargeterDistance = 4f;

		private int targeters;

		public IAIControl[] TargetersObjects;

		public List<IAIControl> TargetersWaiting;

		[Space]
		public GameObjectEvent OnTargetArrived = new GameObjectEvent();

		public float TargeterStopDistance
		{
			get
			{
				return m_targeterStopDistance;
			}
			set
			{
				m_targeterStopDistance = value;
			}
		}

		public int Targeters
		{
			get
			{
				return targeters;
			}
			set
			{
				targeters = value;
				FullTargeters = value >= m_TargetLimit;
			}
		}

		public int TargetsLimits
		{
			get
			{
				return m_TargetLimit;
			}
			set
			{
				m_TargetLimit = value;
			}
		}

		public bool FullTargeters { get; set; }

		public bool ArriveLookAt => m_arriveLookAt;

		public float Height => m_height * base.transform.localScale.y;

		public Action<WayPointType> TargetTypeChanged { get; set; } = delegate
		{
		};

		public UnityEvent TargetersRefresh { get; set; }

		public WayPointType TargetType
		{
			get
			{
				return pointType;
			}
			set
			{
				if (pointType != value)
				{
					pointType = value;
					TargetTypeChanged(value);
				}
			}
		}

		public Vector3 Center
		{
			get
			{
				return base.transform.TransformPoint(center);
			}
			private set
			{
				center = value;
			}
		}

		public float WaitTargeterDistance
		{
			get
			{
				return m_WaitTargeterDistance + StopDistance();
			}
			private set
			{
				m_WaitTargeterDistance = value;
			}
		}

		Transform IAITarget.transform => base.transform;

		private void OnEnable()
		{
			character = this.FindInterface<ICharacterAction>();
			if (TargetsLimits > 0)
			{
				TargetersObjects = new IAIControl[TargetsLimits];
				TargetersWaiting = new List<IAIControl>();
			}
			if (character != null)
			{
				ICharacterAction characterAction = character;
				characterAction.OnState = (Action<int>)Delegate.Combine(characterAction.OnState, new Action<int>(OnStateChanged));
			}
			if (TargetersRefresh == null)
			{
				UnityEvent unityEvent = (TargetersRefresh = new UnityEvent());
			}
		}

		private void OnDisable()
		{
			if (character != null)
			{
				ICharacterAction characterAction = character;
				characterAction.OnState = (Action<int>)Delegate.Remove(characterAction.OnState, new Action<int>(OnStateChanged));
			}
		}

		private void OnStateChanged(int state)
		{
			if (state == StateEnum.UnderWater)
			{
				TargetType = WayPointType.Underwater;
			}
			else if (state == StateEnum.Fly)
			{
				TargetType = WayPointType.Air;
			}
			else if (state == StateEnum.Swim)
			{
				TargetType = WayPointType.Water;
			}
			else
			{
				TargetType = WayPointType.Ground;
			}
		}

		public void TargetArrived(GameObject target)
		{
			OnTargetArrived.Invoke(target);
		}

		public void SetLocalCenter(Vector3 localCenter)
		{
			center = localCenter;
		}

		public virtual Vector3 GetCenterPosition(int index)
		{
			return TargeterPosition(index);
		}

		public virtual Vector3 GetCenterPosition()
		{
			return Center;
		}

		public virtual Vector3 GetCenterY()
		{
			return Center + base.transform.up * Height;
		}

		public float StopDistance()
		{
			return stoppingDistance * base.transform.localScale.y;
		}

		public float SlowDistance()
		{
			return slowingDistance * base.transform.localScale.y;
		}

		public virtual void AddTargeter(IAIControl targeter)
		{
			if (TargetsLimits == 0)
			{
				return;
			}
			bool flag = false;
			for (int i = 0; i < TargetsLimits; i++)
			{
				if (TargetersObjects[i] == targeter)
				{
					return;
				}
				if (TargetersObjects[i] == null)
				{
					TargetersObjects[i] = targeter;
					targeter.Index = i;
					flag = true;
					Targeters++;
					break;
				}
			}
			if (!flag && !TargetersWaiting.Contains(targeter))
			{
				TargetersWaiting.Add(targeter);
				targeter.IsWaitingOnTarget = true;
				targeter.Index = Targeters + TargetersWaiting.Count - 1;
			}
			TargetersRefresh.Invoke();
		}

		public virtual void RemoveTargeter(IAIControl targeter)
		{
			if (TargetsLimits == 0)
			{
				return;
			}
			int num = Array.IndexOf(TargetersObjects, targeter);
			if (num >= 0)
			{
				if (TargetersWaiting.Count > 0)
				{
					TargetersObjects[num] = TargetersWaiting[0];
					TargetersObjects[num].Index = num;
					TargetersWaiting[0].IsWaitingOnTarget = false;
					TargetersWaiting.RemoveAt(0);
				}
				else
				{
					TargetersObjects[num].Index = -1;
					TargetersObjects[num] = null;
					Targeters--;
				}
			}
			else if (TargetersWaiting.Contains(targeter))
			{
				targeter.IsWaitingOnTarget = false;
				TargetersWaiting.Remove(targeter);
			}
			TargetersRefresh.Invoke();
		}

		private Vector3 TargeterPosition(int index)
		{
			if (TargetsLimits == 0 || Targeters == 1)
			{
				return Center;
			}
			if (index > TargetsLimits - 1)
			{
				return Center;
			}
			int num = Mathf.Min(Targeters, TargetsLimits);
			float num2 = 360f / (float)num * (float)index;
			if (float.IsNaN(num2) || float.IsInfinity(num2))
			{
				num2 = 0f;
			}
			Quaternion quaternion = Quaternion.Euler(0f, num2, 0f);
			Vector3 forward = Vector3.forward;
			forward = quaternion * forward;
			return Center + forward * StopDistance();
		}

		public bool TargeterIsWaiting(int index)
		{
			if (TargetsLimits == 0)
			{
				return false;
			}
			return index > TargetsLimits - 1;
		}

		public float GetTargeterStoppingDistance(int index)
		{
			if (TargetsLimits == 0 || Targeters == 1)
			{
				return StopDistance();
			}
			if (index <= TargetsLimits - 1)
			{
				return TargeterStopDistance;
			}
			return WaitTargeterDistance;
		}

		public void SetGrounded()
		{
			TargetType = WayPointType.Ground;
		}

		public void SetAir()
		{
			TargetType = WayPointType.Air;
		}

		public void SetWater()
		{
			TargetType = WayPointType.Water;
		}
	}
}
