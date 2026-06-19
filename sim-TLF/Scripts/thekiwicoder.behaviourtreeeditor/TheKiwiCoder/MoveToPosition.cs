using System;
using UnityEngine;
using UnityEngine.AI;

namespace TheKiwiCoder
{
	[Serializable]
	public class MoveToPosition : ActionNode
	{
		[Tooltip("How fast to move")]
		public NodeProperty<float> speed = new NodeProperty<float>
		{
			defaultValue = 5f
		};

		[Tooltip("Stop within this distance of the target")]
		public NodeProperty<float> stoppingDistance = new NodeProperty<float>
		{
			defaultValue = 0.1f
		};

		[Tooltip("Updates the agents rotation along the path")]
		public NodeProperty<bool> updateRotation = new NodeProperty<bool>
		{
			defaultValue = true
		};

		[Tooltip("Maximum acceleration when following the path")]
		public NodeProperty<float> acceleration = new NodeProperty<float>
		{
			defaultValue = 40f
		};

		[Tooltip("Returns success when the remaining distance is less than this amount")]
		public NodeProperty<float> tolerance = new NodeProperty<float>
		{
			defaultValue = 1f
		};

		[Tooltip("Target Position")]
		public NodeProperty<Vector3> targetPosition = new NodeProperty<Vector3>
		{
			defaultValue = Vector3.zero
		};

		protected override void OnStart()
		{
			if (context.agent != null)
			{
				context.agent.stoppingDistance = stoppingDistance.Value;
				context.agent.speed = speed.Value;
				context.agent.destination = targetPosition.Value;
				context.agent.updateRotation = updateRotation.Value;
				context.agent.acceleration = acceleration.Value;
				context.agent.isStopped = false;
			}
		}

		protected override void OnStop()
		{
			if (!(context.agent == null) && context.agent.enabled)
			{
				if (context.agent.pathPending)
				{
					context.agent.ResetPath();
				}
				if (context.agent.remainingDistance > tolerance.Value)
				{
					context.agent.isStopped = true;
				}
			}
		}

		protected override State OnUpdate()
		{
			if (context.agent == null)
			{
				Debug.Log("Game object " + context.gameObject.name + " is missing NavMeshAgent component");
				return State.Failure;
			}
			if (!context.agent.enabled)
			{
				Debug.Log("NavMeshAgent component on " + context.gameObject.name + " was disabled");
				return State.Failure;
			}
			if (context.agent.pathPending)
			{
				return State.Running;
			}
			if (context.agent.remainingDistance < tolerance.Value)
			{
				return State.Success;
			}
			if (context.agent.pathStatus == NavMeshPathStatus.PathInvalid)
			{
				return State.Failure;
			}
			return State.Running;
		}

		public override void OnDrawGizmos()
		{
			NavMeshAgent agent = context.agent;
			Transform transform = context.transform;
			Gizmos.color = Color.green;
			Gizmos.DrawLine(transform.position, transform.position + agent.velocity);
			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, transform.position + agent.desiredVelocity);
			Gizmos.color = Color.black;
			NavMeshPath path = agent.path;
			Vector3 vector = transform.position;
			Vector3[] corners = path.corners;
			foreach (Vector3 vector2 in corners)
			{
				Gizmos.DrawLine(vector, vector2);
				Gizmos.DrawSphere(vector2, 0.1f);
				vector = vector2;
			}
		}
	}
}
