using System;

namespace FuryStudios.FurySDK.Utils.Attributes
{
	public class TableAlias : Attribute
	{
		public string[] aliases;

		public TableAlias(params string[] aliases)
		{
		}
	}
}
