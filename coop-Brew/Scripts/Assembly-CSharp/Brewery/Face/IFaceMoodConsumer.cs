namespace Brewery.Face
{
	public interface IFaceMoodConsumer
	{
		bool UseExternalMoodSet { get; set; }

		void ApplyExternalMoodSet(FaceMoodSet set);
	}
}
