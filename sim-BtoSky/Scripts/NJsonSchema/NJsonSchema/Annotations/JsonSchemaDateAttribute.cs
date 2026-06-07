namespace NJsonSchema.Annotations
{
	public class JsonSchemaDateAttribute : JsonSchemaAttribute
	{
		public JsonSchemaDateAttribute()
			: base(JsonObjectType.String)
		{
			base.Format = "date";
		}
	}
}
