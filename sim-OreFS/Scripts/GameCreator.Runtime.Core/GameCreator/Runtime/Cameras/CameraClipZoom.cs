using System;
using System.Collections.Generic;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[Title("Zoom In")]
	[Category("Zoom In")]
	[Image(typeof(IconZoom), ColorTheme.Type.Blue)]
	[Description("Zooms in until there is no obstacle between the target and the camera")]
	public class CameraClipZoom : TCameraClip
	{
		private static readonly Color GIZMOS_COLOR = new Color(0f, 1f, 0f, 0.5f);

		private const int GIZMOS_DIVISIONS = 5;

		private const int RAY_CAST_BUFFER_SIZE = 50;

		[SerializeField]
		protected LayerMask m_LayerMask = -5;

		[SerializeField]
		protected float m_Radius = 0.4f;

		[SerializeField]
		protected float m_MinDistance;

		[SerializeField]
		protected float m_SmoothTime = 0.5f;

		[NonSerialized]
		private readonly RaycastHit[] m_HitBuffer;

		[NonSerialized]
		private float m_CurrentDistance;

		[NonSerialized]
		private float m_Velocity;

		public LayerMask LayerMask
		{
			get
			{
				return m_LayerMask;
			}
			set
			{
				m_LayerMask = value;
			}
		}

		public float Radius
		{
			get
			{
				return m_Radius;
			}
			set
			{
				m_Radius = value;
			}
		}

		public float MinDistance
		{
			get
			{
				return m_MinDistance;
			}
			set
			{
				m_MinDistance = value;
			}
		}

		public CameraClipZoom()
		{
			m_HitBuffer = new RaycastHit[50];
			m_CurrentDistance = m_MinDistance + m_Radius;
			m_Velocity = 0f;
		}

		public override Vector3 Update(TCamera camera, Vector3 point, Transform[] ignore)
		{
			if (!camera.Transition.CurrentShotCamera.AvoidClipping)
			{
				return camera.transform.position;
			}
			if (camera.transform.position == point)
			{
				return camera.transform.position;
			}
			Vector3 vector = Vector3.MoveTowards(point, camera.transform.position, m_MinDistance + m_Radius);
			Vector3 vector2 = camera.transform.position - vector;
			float num = Mathf.Max(vector2.magnitude, m_MinDistance);
			int num2 = RayCast(vector, vector2.normalized * num, m_Radius, m_LayerMask);
			float num3 = num;
			for (int i = 0; i < num2; i++)
			{
				RaycastHit raycastHit = m_HitBuffer[i];
				if (!IsChild(raycastHit.transform, ignore) && raycastHit.distance < num3)
				{
					num3 = raycastHit.distance;
				}
			}
			if (m_CurrentDistance > num3)
			{
				m_CurrentDistance = num3;
				m_Velocity = 0f;
			}
			else
			{
				float deltaTime = camera.Time.DeltaTime;
				m_CurrentDistance = ((deltaTime > float.Epsilon) ? Mathf.SmoothDamp(m_CurrentDistance, num3, ref m_Velocity, m_SmoothTime, float.PositiveInfinity, deltaTime) : m_CurrentDistance);
			}
			return Vector3.MoveTowards(vector, camera.transform.position, m_CurrentDistance);
		}

		private int RayCast(Vector3 origin, Vector3 direction, float radius, LayerMask layerMask)
		{
			if (radius <= float.Epsilon)
			{
				return Physics.RaycastNonAlloc(origin, direction.normalized, m_HitBuffer, direction.magnitude, layerMask, QueryTriggerInteraction.Ignore);
			}
			return Physics.SphereCastNonAlloc(origin, radius, direction.normalized, m_HitBuffer, direction.magnitude, layerMask, QueryTriggerInteraction.Ignore);
		}

		private bool IsChild(Transform hit, IEnumerable<Transform> ignoreList)
		{
			foreach (Transform ignore in ignoreList)
			{
				if (!(ignore == null) && hit.IsChildOf(ignore))
				{
					return true;
				}
			}
			return false;
		}

		public override void OnDrawGizmos(TCamera camera)
		{
			Gizmos.color = GIZMOS_COLOR;
			GizmosExtension.Octahedron(camera.transform.position, camera.transform.rotation, m_Radius);
		}
	}
}
