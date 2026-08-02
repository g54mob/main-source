using System;
using Polarith.AI.Move;
using UnityEngine;

namespace Polarith.AI.Package
{
	[AddComponentMenu("Polarith AI » Move » Package/Seek Ground")]
	[HelpURL("http://docs.polarith.com/ai/component-aimp-seekground.html")]
	[RequireComponent(typeof(AIMRadiusSteeringBehaviour))]
	public sealed class SeekGround : MonoBehaviour
	{
		[Tooltip("Behaviour to compute the values. Make sure to drag the behaviour component directly into the field. Recommended behaviours are 'AIMSeek' (for danger) and 'AIMFlee' (for interest).")]
		[SerializeField]
		private AIMRadiusSteeringBehaviour radiusSteering;

		[Tooltip("Reference rigidbody that is used to project the position on the ground.")]
		[SerializeField]
		private Rigidbody body;

		[Tooltip("Time in seconds to predict the projected position using the rigidbody's velocity.")]
		[SerializeField]
		private float predictionTime;

		[Tooltip("Enable gizmos to see the direction and projected hit point on the ground. Note that the ray starts with an offset of 'RadiusSteeringBehaviour.InnerRadius'. The hit point on the ground is marked by a sphere half the size of the 'RadiusSteeringBehaviour.InnerRadius'. Possible self-intersections result in a sphere on the agent's collider.")]
		[SerializeField]
		private bool enableGizmos;

		private Vector3 point;

		private Vector3 origin;

		private Vector3 dir;

		private RaycastHit hit;

		private GameObject ground;

		private RadiusSteeringBehaviour rsb;

		private float diff;

		public AIMRadiusSteeringBehaviour RadiusSteering
		{
			get
			{
				return radiusSteering;
			}
			set
			{
				radiusSteering = value;
			}
		}

		public Rigidbody Body
		{
			get
			{
				return body;
			}
			set
			{
				body = value;
			}
		}

		public float PredictionTime
		{
			get
			{
				return predictionTime;
			}
			set
			{
				predictionTime = value;
			}
		}

		public bool EnableGizmos
		{
			get
			{
				return enableGizmos;
			}
			set
			{
				enableGizmos = value;
			}
		}

		private void Start()
		{
			try
			{
				body.IsSleeping();
			}
			catch (NullReferenceException exception)
			{
				Debug.Log("No rigidbody has been set.");
				Debug.LogException(exception, this);
			}
			point = body.transform.position;
			point.y = 0f;
			ground = new GameObject();
			ground.hideFlags = HideFlags.HideInHierarchy;
			ground.SetActive(value: false);
			radiusSteering.GameObjects.Add(ground);
			rsb = radiusSteering.RadiusSteeringBehaviour;
		}

		private void Update()
		{
			dir = rsb.Context.DecidedDirection;
			dir.y = 0f;
			dir.Normalize();
			point = Body.transform.position + dir * body.velocity.magnitude * predictionTime;
			origin = body.transform.position + dir * rsb.InnerRadius;
			diff = (body.transform.position - point).magnitude;
			if (diff < rsb.InnerRadius)
			{
				point.y -= diff;
			}
			if (Physics.Raycast(point, Vector3.down, out hit, rsb.OuterRadius))
			{
				ground.SetActive(value: true);
				ground.transform.position = hit.point;
			}
		}

		private void OnDrawGizmos()
		{
			if (enableGizmos && ground != null && (ground.transform.position - body.transform.position).magnitude < rsb.OuterRadius)
			{
				Gizmos.color = Color.yellow;
				Gizmos.DrawLine(origin, ground.transform.position);
				Gizmos.color = Color.red;
				Gizmos.DrawSphere(ground.transform.position, rsb.InnerRadius * 0.5f);
			}
		}
	}
}
