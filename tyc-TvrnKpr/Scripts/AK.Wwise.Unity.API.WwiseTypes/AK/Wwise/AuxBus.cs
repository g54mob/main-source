using System;

namespace AK.Wwise
{
	[Serializable]
	public class AuxBus : BaseType
	{
		public WwiseAuxBusReference WwiseObjectReference;

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
	}
}
