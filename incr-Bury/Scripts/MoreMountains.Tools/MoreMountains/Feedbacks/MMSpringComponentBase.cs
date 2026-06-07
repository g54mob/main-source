using MoreMountains.Tools;
using UnityEngine.Events;

namespace MoreMountains.Feedbacks
{
	[MMRequiresConstantRepaintOnlyWhenPlaying]
	public abstract class MMSpringComponentBase : MMMonoBehaviour
	{
		public enum TimeScaleModes
		{
			Unscaled = 0,
			Scaled = 1
		}

		[MMInspectorGroup("Events", true, 16, true)]
		public UnityEvent OnEquilibriumReached;

		protected float _velocityLowThreshold = 0.001f;

		public virtual bool LowVelocity => false;

		public virtual void SetVelocityLowThreshold(float threshold)
		{
			_velocityLowThreshold = threshold;
		}

		protected virtual void Awake()
		{
			Initialization();
			base.enabled = false;
		}

		protected virtual void Update()
		{
			UpdateSpringValue();
			SelfDisable();
		}

		protected virtual void Activate()
		{
			base.enabled = true;
		}

		protected virtual void SelfDisable()
		{
			if (LowVelocity)
			{
				if (OnEquilibriumReached != null)
				{
					OnEquilibriumReached.Invoke();
				}
				Finish();
				base.enabled = false;
			}
		}

		public virtual void Stop()
		{
		}

		public virtual void Finish()
		{
		}

		public virtual void RestoreInitialValue()
		{
		}

		public virtual void ResetInitialValue()
		{
		}

		protected virtual void Initialization()
		{
		}

		protected virtual void GrabCurrentValue()
		{
		}

		protected virtual void UpdateSpringValue()
		{
		}

		protected virtual void TestMoveTo()
		{
		}

		protected virtual void TestMoveToAdditive()
		{
		}

		protected virtual void TestMoveToSubtractive()
		{
		}

		protected virtual void TestMoveToRandom()
		{
		}

		protected virtual void TestMoveToInstant()
		{
		}

		protected virtual void TestBump()
		{
		}

		protected virtual void TestBumpRandom()
		{
		}
	}
}
