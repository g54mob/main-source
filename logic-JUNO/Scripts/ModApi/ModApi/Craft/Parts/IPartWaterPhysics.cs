namespace ModApi.Craft.Parts
{
	public interface IPartWaterPhysics : IWaterPhysics<IPartWaterPhysics>
	{
		bool Enabled { get; set; }

		IPartScript PartScript { get; }
	}
}
