namespace CsvHelper.Configuration.Attributes
{
	public interface IParameterReferenceMapper
	{
		void ApplyTo(ParameterReferenceMap referenceMap);
	}
}
