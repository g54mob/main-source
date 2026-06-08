namespace CsvHelper.Configuration.Attributes
{
	public interface IParameterMapper
	{
		void ApplyTo(ParameterMap parameterMap);
	}
}
