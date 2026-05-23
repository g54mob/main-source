using NJsonSchema.References;

namespace NJsonSchema.Visitors
{
	public abstract class JsonSchemaVisitorBase : JsonReferenceVisitorBase
	{
		protected abstract JsonSchema VisitSchema(JsonSchema schema, string path, string typeNameHint);

		protected override IJsonReference VisitJsonReference(IJsonReference reference, string path, string typeNameHint)
		{
			if (reference is JsonSchema schema)
			{
				return VisitSchema(schema, path, typeNameHint);
			}
			return reference;
		}
	}
}
