namespace ModApi.Craft
{
	public delegate void WaterPhysicsHandler<T>(T source) where T : IWaterPhysics<T>;
}
