using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[CustomObfuscation(rename = false)]
	[Preserve]
	internal abstract class ControllerTemplateSpecialElementMapping
	{
		public ControllerTemplateSpecialElementMapping()
		{
		}
	}
}
