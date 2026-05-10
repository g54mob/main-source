using UnityEngine;

namespace RootMotion.FinalIK
{
	public class TwistRelaxer : MonoBehaviour
	{
		public IK ik;

		[Tooltip("If using multiple solvers, add them in inverse hierarchical order - first forearm roll bone, then forearm bone and upper arm bone.")]
		public TwistSolver[] twistSolvers;

		public void Start()
		{
		}

		private void Update()
		{
		}

		private void OnPostUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
