using UnityEngine;

namespace InteractionSystem
{
	public class VehicleSeatVisualSync : MonoBehaviour
	{
		private struct AnimatorParam
		{
			public int Hash;

			public AnimatorControllerParameterType Type;
		}

		private Animator sourceAnimator;

		private Animator targetAnimator;

		private AnimatorParam[] cachedParameters;

		public void Initialize(Animator source, Animator target)
		{
		}

		private void LateUpdate()
		{
		}

		private void SyncParameters()
		{
		}

		private void SyncLayerWeights()
		{
		}
	}
}
