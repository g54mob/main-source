namespace NSMedieval.Map
{
	public interface IMapObjectElevation
	{
		float GetElevation();

		void HideMapObject(float elevationLevel);

		void ShowMapObject(float elevationLevel);

		void RemoveFromCache();
	}
}
