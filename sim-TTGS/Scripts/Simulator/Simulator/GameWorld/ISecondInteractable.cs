namespace Simulator.GameWorld
{
	public interface ISecondInteractable
	{
		bool CanSecondInteract(Character character);

		protected void OnSecondInteractedBy(Character character);

		bool TrySecondInteract(Character character)
		{
			if (!CanSecondInteract(character))
			{
				return false;
			}
			OnSecondInteractedBy(character);
			return true;
		}
	}
}
