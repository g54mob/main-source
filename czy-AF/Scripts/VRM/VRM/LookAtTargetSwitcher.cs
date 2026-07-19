using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRM
{
	public class LookAtTargetSwitcher : MonoBehaviour
	{
		[SerializeField]
		private List<Transform> m_targets = new List<Transform>();

		[SerializeField]
		[Range(0f, 90f)]
		private float m_thresholdDegrees = 60f;

		[SerializeField]
		private VRMLookAtHead m_lookAtHead;

		[SerializeField]
		private Blinker m_blinker;

		private Transform m_lastTarget;

		private void Reset()
		{
			m_lookAtHead = UnityEngine.Object.FindObjectOfType<VRMLookAtHead>();
			m_blinker = UnityEngine.Object.FindObjectOfType<Blinker>();
		}

		private float CalcScore(Transform target)
		{
			return Vector3.Dot(m_lookAtHead.Head.forward, target.position - m_lookAtHead.Head.position);
		}

		private Transform ChooseTarget()
		{
			Transform result = null;
			float num = 0f;
			double num2 = Math.Cos(m_thresholdDegrees * (MathF.PI / 180f));
			foreach (Transform target in m_targets)
			{
				float num3 = CalcScore(target);
				if ((double)num3 > num2 && num3 > num)
				{
					num = num3;
					result = target;
				}
			}
			return result;
		}

		private void Update()
		{
			if (m_targets != null && m_targets.Count != 0)
			{
				Transform transform = ChooseTarget();
				if (transform != m_lastTarget)
				{
					m_lastTarget = transform;
					m_blinker.Request = true;
				}
				Vector3 vector = ((!(transform == null)) ? transform.position : (m_lookAtHead.Head.position + m_lookAtHead.Head.forward * 20f));
				base.transform.position += (vector - base.transform.position) * 0.5f;
			}
		}
	}
}
