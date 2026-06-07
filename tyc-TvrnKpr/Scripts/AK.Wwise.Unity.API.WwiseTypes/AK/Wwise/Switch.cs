using System;
using UnityEngine;

namespace AK.Wwise
{
	[Serializable]
	public class Switch : BaseGroupType
	{
		public WwiseSwitchReference WwiseObjectReference;

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

		public override WwiseObjectType WwiseObjectGroupType => default(WwiseObjectType);

		public void SetValue(GameObject gameObject)
		{
		}
	}
}
