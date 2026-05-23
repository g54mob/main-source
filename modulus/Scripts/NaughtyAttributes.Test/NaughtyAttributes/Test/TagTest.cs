using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class TagTest : MonoBehaviour
	{
		[Tag]
		public string tag0;

		public TagNest1 nest1;

		[Button(null, EButtonEnableMode.Always)]
		private void LogTag0()
		{
			Debug.Log(tag0);
		}
	}
}
