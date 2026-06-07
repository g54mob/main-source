using System;

namespace NJsonSchema
{
	public class JsonSchemaAppender
	{
		private readonly ITypeNameGenerator _typeNameGenerator;

		public object RootObject { get; }

		protected JsonSchema RootSchema => (JsonSchema)RootObject;

		public JsonSchemaAppender(object rootObject, ITypeNameGenerator typeNameGenerator)
		{
			RootObject = rootObject;
			_typeNameGenerator = typeNameGenerator;
		}

		public virtual void AppendSchema(JsonSchema schema, string typeNameHint)
		{
			if (schema == null)
			{
				throw new ArgumentNullException("schema");
			}
			if (schema != RootObject && !RootSchema.Definitions.Values.Contains(schema))
			{
				string text = _typeNameGenerator.Generate(schema, typeNameHint, RootSchema.Definitions.Keys);
				if (!string.IsNullOrEmpty(text) && !RootSchema.Definitions.ContainsKey(text))
				{
					RootSchema.Definitions[text] = schema;
				}
				else
				{
					RootSchema.Definitions["ref_" + Guid.NewGuid().ToString().Replace("-", "_")] = schema;
				}
			}
		}
	}
}
