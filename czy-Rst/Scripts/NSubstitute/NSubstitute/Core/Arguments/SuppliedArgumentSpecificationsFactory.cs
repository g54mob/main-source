using System.Collections.Generic;

namespace NSubstitute.Core.Arguments
{
	public class SuppliedArgumentSpecificationsFactory : ISuppliedArgumentSpecificationsFactory
	{
		public SuppliedArgumentSpecificationsFactory(IArgumentSpecificationCompatibilityTester argumentSpecificationCompatTester)
		{
			_003CargumentSpecificationCompatTester_003EP = argumentSpecificationCompatTester;
			base._002Ector();
		}

		public ISuppliedArgumentSpecifications Create(IEnumerable<IArgumentSpecification> argumentSpecifications)
		{
			return new SuppliedArgumentSpecifications(_003CargumentSpecificationCompatTester_003EP, argumentSpecifications);
		}
	}
}
