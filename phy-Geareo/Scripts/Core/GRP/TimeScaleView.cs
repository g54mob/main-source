using Rhizomatic.MemberBinding;
using Rhizomatic.Reactive;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP
{
	public class TimeScaleView : View<TimeScaleViewable>
	{
		public SliderAdapter timeScale;

		public AudioSource audioSource;

		public AudioClip slideClip;

		public AudioClip resetClip;

		public AnimationCurve pitchOverValue;

		public Vector2 range;

		public RectTransform otherValue;

		public RectTransform fillValue;

		public Transform turner;

		public float turnerSpeed;

		public float moveSpeed;

		public float fadeIn;

		public float fadeOut;

		private bool isMoving;

		private float movingTo;

		private bool isChanging;

		private float lastValue;

		protected override void OnViewCreated()
		{
		}

		protected override void OnRender()
		{
		}

		protected override void Update()
		{
		}

		protected override void LateUpdate()
		{
		}

		public void MoveTo(float value)
		{
		}

		[Member]
		public void Reset()
		{
		}

		public void OnDisable()
		{
		}
	}
}
