using System;
using UnityEngine;

namespace NaughtyAttributes.Test
{
	[Serializable]
	public class OnValueChangedNest2
	{
		[OnValueChanged("OnValueChangedMethod")]
		[AllowNesting]
		public int int2;

		private void OnValueChangedMethod()
		{
			Debug.LogFormat("int2: {0}", int2);
		}
	}
}
