using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Dreamteck.Splines
{
	public class SplineTracer : SplineUser
	{
		public class NodeConnection
		{
			public Node node;

			public int point;

			public NodeConnection(Node node, int point)
			{
			}
		}

		public enum PhysicsMode
		{
			Transform = 0,
			Rigidbody = 1,
			Rigidbody2D = 2
		}

		public delegate void JunctionHandler(List<NodeConnection> passed);

		[HideInInspector]
		public bool applyDirectionRotation;

		[HideInInspector]
		public bool useTriggers;

		[HideInInspector]
		public int triggerGroup;

		[SerializeField]
		[HideInInspector]
		protected Spline.Direction _direction;

		[SerializeField]
		[HideInInspector]
		protected bool _dontLerpDirection;

		[SerializeField]
		[HideInInspector]
		protected PhysicsMode _physicsMode;

		[SerializeField]
		[HideInInspector]
		protected TransformModule _motion;

		[SerializeField]
		[HideInInspector]
		protected Rigidbody targetRigidbody;

		[SerializeField]
		[HideInInspector]
		protected Rigidbody2D targetRigidbody2D;

		[SerializeField]
		[HideInInspector]
		protected Transform targetTransform;

		[SerializeField]
		[HideInInspector]
		protected SplineSample _result;

		[SerializeField]
		[HideInInspector]
		protected SplineSample _finalResult;

		private SplineTrigger[] triggerInvokeQueue;

		private List<NodeConnection> nodeConnectionQueue;

		private int addTriggerIndex;

		private const double MIN_DELTA = 1E-06;

		public PhysicsMode physicsMode
		{
			get
			{
				return default(PhysicsMode);
			}
			set
			{
			}
		}

		public TransformModule motion => null;

		public SplineSample result => default(SplineSample);

		public SplineSample modifiedResult => default(SplineSample);

		public bool dontLerpDirection
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public virtual Spline.Direction direction
		{
			get
			{
				return default(Spline.Direction);
			}
			set
			{
			}
		}

		public event JunctionHandler onNode
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event EmptySplineHandler onMotionApplied
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public virtual void SetPercent(double percent, bool checkTriggers = false, bool handleJunctions = false)
		{
		}

		public double GetPercent()
		{
			return 0.0;
		}

		public virtual void SetDistance(float distance, bool checkTriggers = false, bool handleJunctions = false)
		{
		}

		protected virtual Rigidbody GetRigidbody()
		{
			return null;
		}

		protected virtual Rigidbody2D GetRigidbody2D()
		{
			return null;
		}

		protected virtual Transform GetTransform()
		{
			return null;
		}

		protected void ApplyMotion()
		{
		}

		protected void CheckNodes(double from, double to)
		{
		}

		protected void InvokeNodes()
		{
		}

		protected void CheckTriggers(double from, double to)
		{
		}

		private NodeConnection GetJunction(int pointIndex)
		{
			return null;
		}

		protected void InvokeTriggers()
		{
		}

		protected void RefreshTargets()
		{
		}

		private void AddTriggerToQueue(SplineTrigger trigger)
		{
		}
	}
}
