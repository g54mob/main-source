namespace TH20
{
	public class PlainEntity : Entity
	{
		public PlainEntity(EntityDefinition definition, Level level)
			: base(definition, level)
		{
			InitializeComponents();
		}
	}
}
