namespace Simulator.GameWorld
{
	public interface IMainInteractable
	{
		bool CanMainInteract(Character character);

		protected void OnMainInteractedBy(Character character);

		bool TryMainInteract(Character character)
		{
			if (!CanMainInteract(character))
			{
				return false;
			}
			OnMainInteractedBy(character);
			return true;
		}
	}
}
