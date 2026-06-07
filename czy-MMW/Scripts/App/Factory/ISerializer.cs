using System.Collections.Generic;

namespace Factory
{
	public interface ISerializer
	{
		bool CanNestObjects { get; }

		bool Serialize(object obj, ExportContext context);

		object Deserialize(object existingObj, ImportContext context);

		IEnumerable<object> GetNestedObjects(object obj);
	}
}
