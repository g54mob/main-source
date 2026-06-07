namespace DV.Customization
{
	public class StorageShedCustomization : StaticParentCustomization<StorageShedCustomization>
	{
		public const string KEY = ":storage:";

		public override string GetIdentificationKey()
		{
			return ":storage:";
		}
	}
}
