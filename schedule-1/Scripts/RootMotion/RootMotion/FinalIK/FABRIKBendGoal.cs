using UnityEngine;

namespace RootMotion.FinalIK
{
	public class FABRIKBendGoal : MonoBehaviour
	{
		public FABRIK ik;

		[Range(0f, 1f)]
		public float weight;

		private void Start()
		{
		}

		private void OnPreIteration(int it)
		{
		}

		private void OnDestroy()
		{
		}
	}
}
