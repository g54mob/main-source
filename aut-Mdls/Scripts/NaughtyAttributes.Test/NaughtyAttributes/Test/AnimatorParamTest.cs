using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class AnimatorParamTest : MonoBehaviour
	{
		public Animator animator0;

		[AnimatorParam("animator0")]
		public int hash0;

		[AnimatorParam("animator0")]
		public string name0;

		public AnimatorParamNest1 nest1;

		[Button("Log 'hash0' and 'name0'", EButtonEnableMode.Always)]
		private void TestLog()
		{
			Debug.Log($"hash0 = {hash0}");
			Debug.Log("name0 = " + name0);
			Debug.Log($"Animator.StringToHash(name0) = {Animator.StringToHash(name0)}");
		}
	}
}
