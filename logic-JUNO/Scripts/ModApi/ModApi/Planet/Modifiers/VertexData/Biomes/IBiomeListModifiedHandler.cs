namespace ModApi.Planet.Modifiers.VertexData.Biomes
{
	public interface IBiomeListModifiedHandler
	{
		void OnBiomeAdded(int index);

		void OnBiomeDeleted(int index);
	}
}
