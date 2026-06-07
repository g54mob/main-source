using System;
using UnityEngine;

namespace AK.Wwise
{
	[Serializable]
	public class RTPC : BaseType
	{
		public WwiseRtpcReference WwiseObjectReference;

		public override WwiseObjectReference ObjectReference
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override WwiseObjectType WwiseObjectType => default(WwiseObjectType);

		public void SetValue(GameObject gameObject, float value)
		{
		}

		public float GetValue(GameObject gameObject)
		{
			return 0f;
		}

		public void SetGlobalValue(float value)
		{
		}

		public float GetGlobalValue()
		{
			return 0f;
		}
	}
}
