using System.Collections.Generic;

namespace Factory
{
	public abstract class PrimitiveSerializer : ISerializer
	{
		public bool CanNestObjects => false;

		public abstract object Deserialize(object existingObj, ImportContext context);

		public abstract bool Serialize(object obj, ExportContext context);

		public IEnumerable<object> GetNestedObjects(object obj)
		{
			yield break;
		}
	}
}
