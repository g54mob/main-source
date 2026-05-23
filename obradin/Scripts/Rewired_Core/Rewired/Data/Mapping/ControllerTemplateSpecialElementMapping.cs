using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[Preserve]
	internal abstract class ControllerTemplateSpecialElementMapping
	{
		public ControllerTemplateSpecialElementMapping()
		{
		}
	}
}
