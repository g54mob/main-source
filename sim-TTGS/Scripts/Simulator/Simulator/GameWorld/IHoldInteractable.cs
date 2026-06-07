namespace Simulator.GameWorld
{
	public interface IHoldInteractable
	{
		bool CanMainHoldInteractBy(Character character);

		void OnMainHoldInteractStartBy(Character character);

		void OnMainHoldInteractStopBy(Character character);

		bool CanSecondHoldInteractBy(Character character);

		bool OnSecondHoldInteractStartBy(Character character);

		bool OnSecondHoldInteractStopBy(Character character);
	}
}
