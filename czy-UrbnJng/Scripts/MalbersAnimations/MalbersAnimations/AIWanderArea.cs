using UnityEngine;

namespace MalbersAnimations
{
	[HelpURL("https://malbersanimations.gitbook.io/animal-controller/main-components/ai/wander-area")]
	[AddComponentMenu("Malbers/AI/AI Wander Area")]
	public class AIWanderArea : MWayPoint
	{
		public enum AreaType
		{
			Circle = 0,
			Box = 1
		}

		[Tooltip("Type of Area to wander")]
		public AreaType m_AreaType;

		[Min(0f)]
		public float radius = 5f;

		public Vector3 BoxArea = new Vector3(10f, 1f, 10f);

		[Range(0f, 1f)]
		[Tooltip("Probability of keep wandering on this WayPoint Area")]
		public float WanderWeight = 1f;

		private Transform currentNextTarget;

		[SerializeField]
		private AIWanderArea MainArea;

		[SerializeField]
		private AIWanderArea[] ChildWanderAreas;

		[HideInInspector]
		[SerializeField]
		private bool ShowRadius;

		public Vector3 Destination { get; internal set; }

		private bool IsChild => MainArea != this;

		protected override void OnEnable()
		{
			base.OnEnable();
			FindWanderAreas();
			if (!IsChild)
			{
				GetNextDestination();
			}
			currentNextTarget = MainArea.transform;
		}

		private void FindWanderAreas()
		{
			MainArea = ((base.transform.parent != null) ? base.transform.parent.GetComponentInParent<AIWanderArea>() : this);
			if (MainArea == null)
			{
				MainArea = this;
			}
			ChildWanderAreas = null;
			if (IsChild)
			{
				return;
			}
			ChildWanderAreas = GetComponentsInChildren<AIWanderArea>();
			if (ChildWanderAreas != null)
			{
				AIWanderArea[] childWanderAreas = ChildWanderAreas;
				foreach (AIWanderArea obj in childWanderAreas)
				{
					obj.DebugColor = DebugColor;
					obj.stoppingDistance = stoppingDistance;
				}
			}
		}

		public Vector3 GetNextDestination()
		{
			if (!IsChild && ChildWanderAreas != null && ChildWanderAreas.Length > 1)
			{
				return ChildWanderAreas[Random.Range(0, ChildWanderAreas.Length)].GetNextDestinationArea();
			}
			return GetNextDestinationArea();
		}

		private Vector3 GetNextDestinationArea()
		{
			switch (m_AreaType)
			{
			case AreaType.Circle:
			{
				Vector2 vector = Random.insideUnitCircle * radius;
				Destination = base.transform.TransformPoint(new Vector3(vector.x, 0f, vector.y));
				break;
			}
			case AreaType.Box:
				Destination = base.transform.TransformPoint(RandomPointInBox(BoxArea));
				break;
			default:
				Destination = base.transform.position;
				break;
			}
			MainArea.Destination = Destination;
			MDebug.DrawWireSphere(Destination, Color.red, 0.1f, 2f);
			return MainArea.Destination;
		}

		public override Vector3 GetCenterPosition(int Index)
		{
			return GetNextDestination();
		}

		public override float StopDistance()
		{
			return MainArea.stoppingDistance;
		}

		public override float SlowDistance()
		{
			return MainArea.slowingDistance;
		}

		public override Transform NextTarget()
		{
			return MainArea.FindNextTarget();
		}

		public override void TargetArrived(GameObject target)
		{
			MainArea.OnTargetArrived.Invoke(target);
			FindNextTarget();
		}

		private Transform FindNextTarget()
		{
			if (base.NextTargets != null && base.NextTargets.Count > 0)
			{
				float num = Random.Range(0f, 1f);
				if (WanderWeight != 0f && num <= WanderWeight)
				{
					GetNextDestination();
					currentNextTarget = MainArea.transform;
				}
				else
				{
					currentNextTarget = base.NextTargets[Random.Range(0, base.NextTargets.Count)];
				}
			}
			else
			{
				currentNextTarget = MainArea.transform;
			}
			return currentNextTarget;
		}

		private Vector3 RandomPointInBox(Vector3 size)
		{
			return new Vector3((Random.value - 0.5f) * size.x, (Random.value - 0.5f) * size.y, (Random.value - 0.5f) * size.z);
		}

		private void Reset()
		{
			DebugColor.a = 0.2f;
		}

		private void OnValidate()
		{
			FindWanderAreas();
			if (BoxArea.x < 0f)
			{
				BoxArea.x = 0f;
			}
			if (BoxArea.y < 0f)
			{
				BoxArea.y = 0f;
			}
			if (BoxArea.z < 0f)
			{
				BoxArea.z = 0f;
			}
		}
	}
}
