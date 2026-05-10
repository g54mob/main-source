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
		}

		private void OnValueChangedMethod2()
		{
		}
	}
}
