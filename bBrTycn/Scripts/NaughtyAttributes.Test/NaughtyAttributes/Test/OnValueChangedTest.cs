using UnityEngine;

namespace NaughtyAttributes.Test
{
	public class OnValueChangedTest : MonoBehaviour
	{
		[OnValueChanged("OnValueChangedMethod1")]
		[OnValueChanged("OnValueChangedMethod2")]
		public int int0;

		public OnValueChangedNest1 nest1;

		private void OnValueChangedMethod1()
		{
			Debug.LogFormat("int0: {0}", int0);
		}

		private void OnValueChangedMethod2()
		{
			Debug.LogFormat("int0: {0}", int0);
		}
	}
}
