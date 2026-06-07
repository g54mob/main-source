using System;

namespace AK.Wwise
{
	[Serializable]
	public class State : BaseGroupType
	{
		public WwiseStateReference WwiseObjectReference;

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

		public void SetValue()
		{
		}
	}
}
