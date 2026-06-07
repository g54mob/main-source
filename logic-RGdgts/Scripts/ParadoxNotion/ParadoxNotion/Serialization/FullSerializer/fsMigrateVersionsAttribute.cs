using System;

namespace ParadoxNotion.Serialization.FullSerializer
{
	public class fsMigrateVersionsAttribute : Attribute
	{
		public readonly Type[] previousTypes;

		public fsMigrateVersionsAttribute(params Type[] previousTypes)
		{
		}
	}
}
