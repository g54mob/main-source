using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class OnValueChangedNest1
	{
		[OnValueChanged("OnValueChangedMethod")]
		[AllowNesting]
		public int int1;

		public OnValueChangedNest2 nest2;

		private void OnValueChangedMethod()
		{
			Debug.LogFormat("int1: {0}", int1);
		}
	}
}
