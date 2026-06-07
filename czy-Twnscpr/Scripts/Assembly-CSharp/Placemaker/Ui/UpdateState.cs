using System;
using UnityEngine;
using UnityEngine.UI;

namespace Placemaker.Ui
{
	[Serializable]
	public class UpdateState
	{
		public enum Axis : byte
		{
			X = 1,
			Y = 2,
			Z = 4,
			XY = 3,
			XZ = 5,
			YZ = 6
		}

		[SerializeField]
		private float _current;

		[SerializeField]
		private float _target;

		[SerializeField]
		public bool isUpdating;

		public Action<float> onValueChanged;

		public Action<float> onTargetChange;

		public Action onStart;

		public Action onStop;

		public float speed;

		public bool targetBool
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool currentBool
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float current
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float target
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public UpdateState()
		{
		}

		public UpdateState(float value)
		{
		}

		public UpdateState SnapTo(float newValue)
		{
			return null;
		}

		public UpdateState Follow(float newValue)
		{
			return null;
		}

		public UpdateState Snap()
		{
			return null;
		}

		public UpdateState PushValue()
		{
			return null;
		}

		public void SetCurrentOrTarget(float value)
		{
		}

		public void Update()
		{
		}

		private void CheckUpdating()
		{
		}

		public UpdateState Subscribe(Action<float> action)
		{
			return null;
		}

		public UpdateState SubscribeTick(GameObject gameObject)
		{
			return null;
		}

		public UpdateState SubscribeToTarget(Action<float> action)
		{
			return null;
		}

		public UpdateState SubscribeToTarget(MonoBehaviour monoBehaviour)
		{
			return null;
		}

		public UpdateState Subscribe(CanvasGroup canvasGroup)
		{
			return null;
		}

		public UpdateState Subscribe(Graphic graphic)
		{
			return null;
		}

		public UpdateState Subscribe(AudioSource audioSource)
		{
			return null;
		}

		public UpdateState SubscribeScale(Transform transform, Axis axis = Axis.XY, float scale0 = 0f, float scale1 = 1f)
		{
			return null;
		}
	}
}
