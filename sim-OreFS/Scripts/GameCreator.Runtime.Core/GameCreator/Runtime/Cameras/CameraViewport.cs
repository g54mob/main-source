using System;
using GameCreator.Runtime.Common;
using UnityEngine;

namespace GameCreator.Runtime.Cameras
{
	[Serializable]
	public class CameraViewport
	{
		private const float EPSILON = 0.001f;

		[NonSerialized]
		private TCamera m_Camera;

		public bool Projection
		{
			get
			{
				return m_Camera.Get<Camera>().orthographic;
			}
			private set
			{
				m_Camera.Get<Camera>().orthographic = value;
			}
		}

		public float FieldOfView
		{
			get
			{
				return m_Camera.Get<Camera>().fieldOfView;
			}
			private set
			{
				m_Camera.Get<Camera>().fieldOfView = value;
			}
		}

		public float OrthographicSize
		{
			get
			{
				return m_Camera.Get<Camera>().orthographicSize;
			}
			private set
			{
				m_Camera.Get<Camera>().orthographicSize = value;
			}
		}

		public float ClipPlaneNear
		{
			get
			{
				return m_Camera.Get<Camera>().nearClipPlane;
			}
			private set
			{
				m_Camera.Get<Camera>().nearClipPlane = Math.Max(value, 0.001f);
			}
		}

		public float ClipPlaneFar
		{
			get
			{
				return m_Camera.Get<Camera>().farClipPlane;
			}
			private set
			{
				m_Camera.Get<Camera>().farClipPlane = Math.Max(value, 0.001f);
			}
		}

		internal void OnEnable(TCamera camera)
		{
			m_Camera = camera;
			camera.Transition.EventCut -= OnChangeShot;
			camera.Transition.EventTransition -= OnChangeShot;
			camera.Transition.EventCut += OnChangeShot;
			camera.Transition.EventTransition += OnChangeShot;
		}

		internal void OnDisable(TCamera camera)
		{
			camera.Transition.EventCut -= OnChangeShot;
			camera.Transition.EventTransition -= OnChangeShot;
		}

		public void SetProjection(bool isOrthographic)
		{
			Projection = isOrthographic;
		}

		public void SetFieldOfView(float value, float duration, Easing.Type easing)
		{
			if (duration <= 0.001f)
			{
				FieldOfView = value;
				return;
			}
			ITweenInput input = new TweenInput<float>(FieldOfView, value, duration, delegate(float a, float b, float t)
			{
				FieldOfView = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(TCamera), "projection"), easing, m_Camera.Time.UpdateTime);
			Tween.To(m_Camera.gameObject, input);
		}

		public void SetOrthographicSize(float value, float duration, Easing.Type easing)
		{
			if (duration <= 0.001f)
			{
				OrthographicSize = value;
				return;
			}
			ITweenInput input = new TweenInput<float>(OrthographicSize, value, duration, delegate(float a, float b, float t)
			{
				OrthographicSize = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(TCamera), "orthographicSize"), easing, m_Camera.Time.UpdateTime);
			Tween.To(m_Camera.gameObject, input);
		}

		public void SetClipPlaneNear(float value, float duration, Easing.Type easing)
		{
			if (duration <= 0.001f)
			{
				ClipPlaneNear = value;
				return;
			}
			ITweenInput input = new TweenInput<float>(ClipPlaneNear, value, duration, delegate(float a, float b, float t)
			{
				ClipPlaneNear = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(TCamera), "clip-plane-near"), easing, m_Camera.Time.UpdateTime);
			Tween.To(m_Camera.gameObject, input);
		}

		public void SetClipPlaneFar(float value, float duration, Easing.Type easing)
		{
			if (duration <= 0.001f)
			{
				ClipPlaneFar = value;
				return;
			}
			ITweenInput input = new TweenInput<float>(ClipPlaneFar, value, duration, delegate(float a, float b, float t)
			{
				ClipPlaneFar = Mathf.Lerp(a, b, t);
			}, Tween.GetHash(typeof(TCamera), "clip-plane-far"), easing, m_Camera.Time.UpdateTime);
			Tween.To(m_Camera.gameObject, input);
		}

		private void OnChangeShot(ShotCamera shotCamera)
		{
			OnChangeShot(shotCamera, 0f, Easing.Type.Linear);
		}

		private void OnChangeShot(ShotCamera shotCamera, float duration, Easing.Type easing)
		{
			if (shotCamera.ShotType.GetSystem(ShotSystemViewport.ID) is ShotSystemViewport shotSystemViewport)
			{
				if (shotSystemViewport.ChangeProjection)
				{
					SetProjection(shotSystemViewport.Projection);
				}
				if (shotSystemViewport.ChangeFieldOfView)
				{
					SetFieldOfView(shotSystemViewport.FieldOfView, duration, easing);
				}
				if (shotSystemViewport.ChangeOrthographicSize)
				{
					SetOrthographicSize(shotSystemViewport.OrthographicSize, duration, easing);
				}
				if (shotSystemViewport.ChangeClipPlaneNear)
				{
					SetClipPlaneNear(shotSystemViewport.ClipPlaneNear, duration, easing);
				}
				if (shotSystemViewport.ChangeClipPlaneFar)
				{
					SetClipPlaneFar(shotSystemViewport.ClipPlaneFar, duration, easing);
				}
			}
		}
	}
}
