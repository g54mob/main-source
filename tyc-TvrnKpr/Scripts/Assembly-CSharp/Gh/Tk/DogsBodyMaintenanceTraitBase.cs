namespace Gh.Tk
{
	public abstract class DogsBodyMaintenanceTraitBase : DogsbodyTraitBase
	{
		protected DogsBodyMaintenanceTraitBase()
		{
		}

		public DogsBodyMaintenanceTraitBase(Staff owner)
		{
		}

		public abstract void OnMaintenanceCompleting(Prop prop);
	}
}
