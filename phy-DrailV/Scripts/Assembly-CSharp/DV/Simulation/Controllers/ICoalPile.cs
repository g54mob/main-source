namespace DV.Simulation.Controllers
{
	public interface ICoalPile
	{
		float CoalChunkMass();

		float CoalAvailable();

		float SpaceForCoal();

		float TryAddCoal(float coalAmount);

		float TryRemoveCoal(float coalAmount);
	}
}
