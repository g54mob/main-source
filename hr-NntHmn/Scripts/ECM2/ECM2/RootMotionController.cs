using UnityEngine;

namespace ECM2
{
	[RequireComponent(typeof(Animator))]
	public class RootMotionController : MonoBehaviour
	{
		protected Animator _animator;

		protected Vector3 _rootMotionDeltaPosition;

		protected Quaternion _rootMotionDeltaRotation;

		public virtual void FlushAccumulatedDeltas()
		{
		}

		public virtual Quaternion ConsumeRootMotionRotation()
		{
			return default(Quaternion);
		}

		public virtual Vector3 GetRootMotionVelocity(float deltaTime)
		{
			return default(Vector3);
		}

		public virtual Vector3 ConsumeRootMotionVelocity(float deltaTime)
		{
			return default(Vector3);
		}

		public virtual void Awake()
		{
		}

		public virtual void Start()
		{
		}

		public virtual void OnAnimatorMove()
		{
		}
	}
}
