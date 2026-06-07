using System;
using Rewired.Utils.Attributes;

namespace Rewired.Data.Mapping
{
	[Serializable]
	[Preserve]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class ControllerTemplateSpecialElementMapping
	{
		public ControllerTemplateSpecialElementMapping()
		{
		}
	}
}
