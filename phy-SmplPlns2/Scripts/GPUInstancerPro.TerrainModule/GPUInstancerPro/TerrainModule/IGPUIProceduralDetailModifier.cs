namespace GPUInstancerPro.TerrainModule
{
	public interface IGPUIProceduralDetailModifier
	{
		bool IsReadTerrainDetails(int terrainDetailPrototypeIndex);

		void Execute(GPUITerrain gpuiTerrain);
	}
}
