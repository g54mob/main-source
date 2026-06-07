namespace Brewery.Items
{
	public abstract class CatalyzedBeverageItem : BeverageItem
	{
		protected override void OnEnable()
		{
		}

		public override bool RequiresMetadata()
		{
			return false;
		}
	}
}
