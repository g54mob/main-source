public class RoadCrude : Floor
{
	public override void RegisterClass()
	{
		base.RegisterClass();
		ModelManager.Instance.AddModel("Models/Buildings/Floors/RoadCrude2", ObjectType.RoadCrude, true);
		ModelManager.Instance.AddModel("Models/Buildings/Floors/RoadCrude3", ObjectType.RoadCrude, true);
	}

	public override void Restart()
	{
		base.Restart();
		SetDimensions(new TileCoord(0, 0), new TileCoord(0, 0), new TileCoord(0, 0));
	}
}
