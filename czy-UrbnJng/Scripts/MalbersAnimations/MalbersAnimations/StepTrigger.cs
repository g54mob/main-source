using System.Collections.Generic;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Utilities/Effects - Audio/Step Trigger")]
	public class StepTrigger : MonoBehaviour
	{
		[RequiredField]
		public StepsManager m_StepsManager;

		[Tooltip("Re Parent this GameObject to a new Bone on Awake")]
		public Transform parent;

		public AudioSource StepAudio;

		public SphereCollider m_Trigger;

		public Color DebugColor = Color.cyan;

		private WaitForSeconds wait;

		private bool waitrack;

		private LayerMask GroundLayer => m_StepsManager.GroundLayer.Value;

		private void Awake()
		{
			if (m_StepsManager == null)
			{
				m_StepsManager = base.transform.FindObjectCore().FindComponent<StepsManager>();
			}
			if (m_Trigger == null)
			{
				m_Trigger = GetComponent<SphereCollider>();
			}
			if (m_StepsManager == null)
			{
				Object.Destroy(base.gameObject);
				return;
			}
			if (parent != null)
			{
				base.transform.SetParent(parent, worldPositionStays: true);
			}
			m_Trigger.isTrigger = true;
			if (!m_StepsManager.Active)
			{
				base.gameObject.SetActive(value: false);
				return;
			}
			StepsManager stepsManager = m_StepsManager;
			if (stepsManager.Feet == null)
			{
				List<StepTrigger> list = (stepsManager.Feet = new List<StepTrigger>());
			}
			m_StepsManager.Feet.Add(this);
			SetAudio();
			wait = new WaitForSeconds(m_StepsManager.WaitNextStep);
		}

		private void SetAudio()
		{
			if (StepAudio == null && !TryGetComponent<AudioSource>(out StepAudio))
			{
				StepAudio = base.gameObject.AddComponent<AudioSource>();
			}
			StepAudio.spatialBlend = 1f;
			if ((bool)m_StepsManager)
			{
				StepAudio.volume = m_StepsManager.StepsVolume;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!other.isTrigger && MTools.CollidersLayer(other, GroundLayer) && !waitrack)
			{
				waitrack = true;
				this.Delay_Action(wait, delegate
				{
					waitrack = false;
				});
				m_StepsManager.EnterStep(this, other);
			}
		}

		[ContextMenu("Find Sphere Trigger")]
		private void GetTrigger()
		{
			m_Trigger = GetComponent<SphereCollider>();
			MTools.SetDirty(this);
		}

		private void OnValidate()
		{
			if (m_Trigger == null)
			{
				m_Trigger = GetComponent<SphereCollider>();
			}
		}

		[ContextMenu("Find Audio Source")]
		private void FindAudioSource()
		{
			StepAudio = GetComponent<AudioSource>();
			if ((bool)StepAudio)
			{
				StepAudio.spatialBlend = 1f;
				if ((bool)m_StepsManager)
				{
					StepAudio.volume = m_StepsManager.StepsVolume;
				}
				StepAudio.maxDistance = 5f;
				StepAudio.minDistance = 1f;
				StepAudio.playOnAwake = false;
			}
			MTools.SetDirty(StepAudio);
		}
	}
}
