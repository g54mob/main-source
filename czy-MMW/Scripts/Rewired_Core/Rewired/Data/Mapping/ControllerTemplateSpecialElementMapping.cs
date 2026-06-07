using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Preserve]
	[CustomObfuscation(rename = false)]
	internal abstract class ControllerTemplateSpecialElementMapping
	{
		public ControllerTemplateSpecialElementMapping()
		{
		}
	}
}
