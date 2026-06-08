namespace Moq
{
	public interface IMock<out T> where T : class
	{
		T Object { get; }

		MockBehavior Behavior { get; }

		bool CallBase { get; set; }

		DefaultValue DefaultValue { get; set; }
	}
}
