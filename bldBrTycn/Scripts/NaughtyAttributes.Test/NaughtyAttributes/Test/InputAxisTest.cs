using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class InputAxisTest : MonoBehaviour
	{
		[InputAxis]
		public string inputAxis0;

		public InputAxisNest1 nest1;

		[Button(null, EButtonEnableMode.Always)]
		private void LogInputAxis0()
		{
			Debug.Log(inputAxis0);
		}
	}
}
