using System;

namespace AK.Wwise
{
	[Serializable]
	public class AcousticTexture : BaseType
	{
		public WwiseAcousticTextureReference WwiseObjectReference;

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
