namespace UniJSON
{
	public interface IJsonSchemaValidator
	{
		void Merge(IJsonSchemaValidator rhs);

		bool FromJsonSchema(IFileSystemAccessor fs, string key, ListTreeNode<JsonValue> value);

		void ToJsonSchema(IFormatter f);

		JsonSchemaValidationException Validate<T>(JsonSchemaValidationContext context, T value);

		void Serialize<T>(IFormatter f, JsonSchemaValidationContext context, T value);

		void Deserialize<T, U>(ListTreeNode<T> src, ref U dst) where T : IListTreeItem, IValue<T>;
	}
}
