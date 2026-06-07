namespace UMA
{
	public interface IDynamicExpression
	{
		void Initialize(UMAData umadata);

		void PreProcess(UMAData umadata);

		void Process(UMAData umadata);
	}
}
