using System;
using FluentAssertions.Common;
using FluentAssertions.Equivalency;

namespace FluentAssertions.Configuration
{
	public class GlobalEquivalencyOptions
	{
		private EquivalencyOptions defaults = new EquivalencyOptions();

		public EquivalencyPlan Plan { get; } = new EquivalencyPlan();

		public void Modify(Func<EquivalencyOptions, EquivalencyOptions> configureOptions)
		{
			Guard.ThrowIfArgumentIsNull(configureOptions, "configureOptions");
			defaults = configureOptions(defaults);
		}

		public EquivalencyOptions<T> CloneDefaults<T>()
		{
			return new EquivalencyOptions<T>(defaults);
		}
	}
}
