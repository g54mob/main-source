namespace Assets.Source.World
{
	internal class CraftingProcessSlot
	{
		public readonly string WorldName;

		public readonly bool HandCrafted;

		public float TimeLeft;

		public CraftingProcessSlot(string worldName, bool handCrafted, float cooldown)
		{
			WorldName = worldName;
			HandCrafted = handCrafted;
			TimeLeft = cooldown;
		}
	}
}
