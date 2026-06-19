using System;

namespace TH20
{
	public class HasFireExtinguisherComponent : EntityComponent
	{
		protected override Type ValidEntityType()
		{
			return typeof(Character);
		}
	}
}
