using System;
using System.Collections;
using UnityEngine;

namespace MalbersAnimations
{
	[RequireComponent(typeof(MFreeLookCamera))]
	[AddComponentMenu("Malbers/Utilities/Camera/Camera Wall Stop")]
	public class CameraWallStop : MonoBehaviour
	{
		public class RayHitComparer : IComparer
		{
			public int Compare(object x, object y)
			{
				return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
			}
		}

		public float clipMoveTime = 0.05f;

		public float returnTime = 0.4f;

		public float sphereCastRadius = 0.15f;

		public bool visualiseInEditor;

		public float closestDistance = 0.5f;

		public LayerMask dontClip = 1048576;

		private Transform m_Cam;

		private Transform m_Pivot;

		[SerializeField]
		private float m_OriginalDist;

		private float m_MoveVelocity;

		private float m_CurrentDist;

		private Ray m_Ray;

		private RaycastHit[] hits;

		private RayHitComparer m_RayHitComparer;

		private MFreeLookCamera M_FreeLookCamera;

		public bool protecting { get; private set; }

		private void Start()
		{
			M_FreeLookCamera = GetComponent<MFreeLookCamera>();
			ResetWithState();
			m_RayHitComparer = new RayHitComparer();
			M_FreeLookCamera.OnStateChange.AddListener(SetOriginalDist);
		}

		public virtual void ResetWithState()
		{
			m_Cam = M_FreeLookCamera.CamT;
			m_Pivot = M_FreeLookCamera.Pivot;
			m_OriginalDist = m_Cam.localPosition.magnitude;
			m_CurrentDist = m_OriginalDist;
		}

		public virtual void SetOriginalDist()
		{
			ResetWithState();
		}

		private void LateUpdate()
		{
			float num = m_OriginalDist;
			m_Ray.origin = m_Pivot.position + m_Pivot.forward * sphereCastRadius;
			m_Ray.direction = -m_Pivot.forward;
			Collider[] array = Physics.OverlapSphere(m_Ray.origin, sphereCastRadius);
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (!array[i].isTrigger && !MTools.CollidersLayer(array[i], dontClip))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				m_Ray.origin += m_Pivot.forward * sphereCastRadius;
				hits = Physics.RaycastAll(m_Ray, m_OriginalDist - sphereCastRadius);
			}
			else
			{
				hits = Physics.SphereCastAll(m_Ray, sphereCastRadius, m_OriginalDist + sphereCastRadius);
			}
			Array.Sort(hits, m_RayHitComparer);
			float num2 = float.PositiveInfinity;
			for (int j = 0; j < hits.Length; j++)
			{
				if (hits[j].distance < num2 && !hits[j].collider.isTrigger && !MTools.CollidersLayer(hits[j].collider, dontClip))
				{
					num2 = hits[j].distance;
					num = 0f - m_Pivot.InverseTransformPoint(hits[j].point).z;
					flag2 = true;
				}
			}
			if (flag2)
			{
				Debug.DrawRay(m_Ray.origin, -m_Pivot.forward * (num + sphereCastRadius), Color.red);
			}
			protecting = flag2;
			m_CurrentDist = Mathf.SmoothDamp(m_CurrentDist, num, ref m_MoveVelocity, (m_CurrentDist > num) ? clipMoveTime : returnTime);
			m_CurrentDist = Mathf.Clamp(m_CurrentDist, closestDistance, m_OriginalDist);
			m_Cam.localPosition = -Vector3.forward * m_CurrentDist;
		}
	}
}
