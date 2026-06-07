using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	[AddComponentMenu("")]
	[DefaultExecutionOrder(1)]
	public abstract class TCamera : MonoBehaviour
	{
		private enum RunMode
		{
			MainUpdate = 0,
			FixedUpdate = 1
		}

		[SerializeField]
		private TimeMode m_TimeMode;

		[SerializeField]
		private RunMode m_RunIn;

		[SerializeField]
		private CameraViewport m_Viewport = new CameraViewport();

		[SerializeField]
		private CameraTransition m_Transition = new CameraTransition();

		[SerializeReference]
		private TCameraClip m_Clip = new CameraClipNone();

		private readonly CameraShakeSustain m_ShakeSustain = new CameraShakeSustain();

		private readonly CameraShakeBurst m_ShakeBurst = new CameraShakeBurst();

		public CameraViewport Viewport => m_Viewport;

		public CameraTransition Transition => m_Transition;

		public TimeMode Time
		{
			get
			{
				return m_TimeMode;
			}
			set
			{
				m_TimeMode = value;
			}
		}

		public event Action<ShotCamera> EventCut;

		public event Action<ShotCamera, float, Easing.Type> EventTransition;

		public event Action EventBeforeUpdate;

		public event Action EventAfterUpdate;

		protected virtual void Awake()
		{
			m_Transition.EventCut += this.EventCut;
			m_Transition.EventTransition += this.EventTransition;
			Transition.OnAwake(this);
		}

		private void Start()
		{
			Transition.OnStart(this);
		}

		private void OnEnable()
		{
			Viewport.OnEnable(this);
		}

		private void OnDisable()
		{
			Viewport.OnDisable(this);
		}

		private void LateUpdate()
		{
			this.EventBeforeUpdate?.Invoke();
			if (m_RunIn == RunMode.MainUpdate)
			{
				Transition.NormalUpdate();
				Transform obj = base.transform;
				obj.position = Transition.Position;
				obj.rotation = Transition.Rotation;
			}
			UpdateShakeEffect();
			UpdateAvoidClipping();
			this.EventAfterUpdate?.Invoke();
		}

		private void FixedUpdate()
		{
			if (m_RunIn == RunMode.FixedUpdate)
			{
				Transition.FixedUpdate();
				Transform obj = base.transform;
				obj.position = Transition.Position;
				obj.rotation = Transition.Rotation;
			}
		}

		private void UpdateShakeEffect()
		{
			m_ShakeSustain.Update(this);
			m_ShakeBurst.Update(this);
			Vector3 vector = m_ShakeSustain.AdditivePosition * 1f + m_ShakeBurst.AdditivePosition * 1f;
			Vector3 vector2 = m_ShakeSustain.AdditiveRotation * 25f + m_ShakeBurst.AdditiveRotation * 25f;
			Transform obj = base.transform;
			obj.localPosition += vector;
			obj.localEulerAngles += vector2;
		}

		private void UpdateAvoidClipping()
		{
			if (!(Transition.CurrentShotCamera == null) && Transition.CurrentShotCamera.HasTarget)
			{
				Vector3 target = Transition.CurrentShotCamera.Target;
				Transform[] ignore = Transition.CurrentShotCamera.Ignore;
				base.transform.position = m_Clip.Update(this, target, ignore);
			}
		}

		public void AddSustainShake(int layer, float delay, float transition, ShakeEffect shakeEffect)
		{
			m_ShakeSustain.AddSustain(layer, delay, transition, shakeEffect);
		}

		public void RemoveSustainShake(int layer, float delay, float transition)
		{
			m_ShakeSustain.RemoveSustain(layer, delay, transition);
		}

		public void AddBurstShake(float delay, float duration, ShakeEffect shakeEffect)
		{
			m_ShakeBurst.AddBurst(delay, duration, shakeEffect);
		}

		public void StopBurstShakes(float delay, float transition)
		{
			m_ShakeBurst.RemoveBursts(delay, transition);
		}

		public void Sync()
		{
			m_Transition.Sync();
		}

		private void OnDrawGizmosSelected()
		{
			m_Clip?.OnDrawGizmos(this);
		}
	}
}
