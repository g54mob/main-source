using NSMedieval.Model;

namespace NSMedieval.BuildingComponents
{
	internal readonly struct TooltipResourcesInfo
	{
		public string SpriteFormatted { get; }

		public int Amount { get; }

		public string ResourceNameLocalized { get; }

		public Resource Blueprint { get; }

		public TooltipResourcesInfo(string spriteFormatted, int amount, string resourceNameLocalized, Resource blueprint)
		{
			SpriteFormatted = spriteFormatted;
			Amount = amount;
			ResourceNameLocalized = resourceNameLocalized;
			Blueprint = blueprint;
		}
	}
}
