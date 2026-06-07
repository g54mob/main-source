using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Cinemachine
{
	[SaveDuringPlay]
	public class CinemachineTriggerAction : MonoBehaviour
	{
		[Serializable]
		public struct ActionSettings
		{
			public enum Mode
			{
				Custom = 0,
				PriorityBoost = 1,
				Activate = 2,
				Deactivate = 3,
				Enable = 4,
				Disable = 5,
				Play = 6,
				Stop = 7
			}

			[Serializable]
			public class TriggerEvent : UnityEvent
			{
			}

			public enum TimeMode
			{
				FromStart = 0,
				FromEnd = 1,
				BeforeNow = 2,
				AfterNow = 3
			}

			public Mode m_Action;

			public UnityEngine.Object m_Target;

			public int m_BoostAmount;

			public float m_StartTime;

			public TimeMode m_Mode;

			public TriggerEvent m_Event;

			public ActionSettings(Mode action)
			{
				m_Action = default(Mode);
				m_Target = null;
				m_BoostAmount = 0;
				m_StartTime = 0f;
				m_Mode = default(TimeMode);
				m_Event = null;
			}

			public void Invoke()
			{
			}
		}

		public LayerMask m_LayerMask;

		[TagField]
		public string m_WithTag;

		[TagField]
		public string m_WithoutTag;

		[NoSaveDuringPlay]
		public int m_SkipFirst;

		public bool m_Repeating;

		public ActionSettings m_OnObjectEnter;

		public ActionSettings m_OnObjectExit;

		private HashSet<GameObject> m_ActiveTriggerObjects;

		private bool Filter(GameObject other)
		{
			return false;
		}

		private void InternalDoTriggerEnter(GameObject other)
		{
		}

		private void InternalDoTriggerExit(GameObject other)
		{
		}

		private void OnTriggerEnter(Collider other)
		{
		}

		private void OnTriggerExit(Collider other)
		{
		}

		private void OnCollisionEnter(Collision other)
		{
		}

		private void OnCollisionExit(Collision other)
		{
		}

		private void OnTriggerEnter2D(Collider2D other)
		{
		}

		private void OnTriggerExit2D(Collider2D other)
		{
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
		}

		private void OnCollisionExit2D(Collision2D other)
		{
		}

		private void OnEnable()
		{
		}
	}
}
