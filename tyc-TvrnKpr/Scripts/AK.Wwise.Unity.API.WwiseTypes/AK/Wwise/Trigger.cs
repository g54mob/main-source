using System;
using UnityEngine;

namespace AK.Wwise
{
	[Serializable]
	public class Trigger : BaseType
	{
		public WwiseTriggerReference WwiseObjectReference;

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

		public void Post(GameObject gameObject)
		{
		}
	}
}
