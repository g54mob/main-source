using System;
using UnityEngine;
using UnityEngine.Events;

namespace HQFPSTemplate
{
	public class InteractiveObject : MonoBehaviour
	{
		[Serializable]
		protected struct InteractionAudio
		{
			public SoundPlayer RaycastStartAudio;

			public SoundPlayer RaycastEndAudio;

			public SoundPlayer InteractionStartAudio;

			public SoundPlayer InteractionEndAudio;
		}

		public readonly Value<float> InteractionProgress = new Value<float>();

		public readonly Value<string> InteractionText = new Value<string>();

		[BHeader("Interaction", true)]
		[SerializeField]
		private bool m_InteractionEnabled = true;

		[SerializeField]
		[Multiline]
		private string m_InteractionText = string.Empty;

		[SerializeField]
		private InteractionAudio m_InteractionAudio;

		[Space(3f)]
		[SerializeField]
		private UnityEvent m_InteractionEvent;

		private float m_InteractStart;

		public bool InteractionEnabled
		{
			get
			{
				return m_InteractionEnabled;
			}
			set
			{
				m_InteractionEnabled = value;
			}
		}

		public virtual void OnRaycastStart(Humanoid humanoid)
		{
			m_InteractionAudio.RaycastStartAudio.Play2D();
		}

		public virtual void OnRaycastUpdate(Humanoid humanoid)
		{
		}

		public virtual void OnRaycastEnd(Humanoid humanoid)
		{
			m_InteractionAudio.RaycastEndAudio.Play2D();
		}

		public virtual void OnInteractionStart(Humanoid humanoid)
		{
			m_InteractionEvent.Invoke();
			m_InteractionAudio.InteractionStartAudio.Play2D();
			m_InteractStart = Time.time;
		}

		public virtual void OnInteractionUpdate(Humanoid humanoid)
		{
			InteractionProgress.Set(Time.time - m_InteractStart);
		}

		public virtual void OnInteractionEnd(Humanoid humanoid)
		{
			InteractionProgress.Set(0f);
			m_InteractionAudio.InteractionEndAudio.Play2D();
		}

		protected virtual void Awake()
		{
			InteractionText.Set(m_InteractionText);
		}
	}
}
