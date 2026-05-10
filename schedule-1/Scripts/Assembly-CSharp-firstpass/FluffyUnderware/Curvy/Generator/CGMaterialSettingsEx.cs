using System;
using JetBrains.Annotations;

namespace FluffyUnderware.Curvy.Generator
{
	[Serializable]
	public class CGMaterialSettingsEx : CGMaterialSettings
	{
		[Obsolete("This field is not used anymore, will get remove in a future update")]
		[UsedImplicitly]
		public int MaterialID;
	}
}
