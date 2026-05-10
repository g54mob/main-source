using UnityEngine;

namespace RootMotion.FinalIK
{
	public class CCDBendGoal : MonoBehaviour
	{
		public CCDIK ik;

		[Range(0f, 1f)]
		public float weight;

		private void Start()
		{
		}

		private void BeforeIK()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
