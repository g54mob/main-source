namespace NSubstitute.Core
{
	public interface ICallBaseConfiguration
	{
		bool CallBaseByDefault { get; set; }

		void Exclude(ICallSpecification callSpecification);

		void Include(ICallSpecification callSpecification);

		bool ShouldCallBase(ICall call);
	}
}
