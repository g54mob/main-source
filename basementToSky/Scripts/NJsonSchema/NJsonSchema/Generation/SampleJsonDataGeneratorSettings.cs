namespace NJsonSchema.Generation
{
	public class SampleJsonDataGeneratorSettings
	{
		public bool GenerateOptionalProperties { get; set; } = true;

		public int MaxRecursionLevel { get; set; } = 3;
	}
}
