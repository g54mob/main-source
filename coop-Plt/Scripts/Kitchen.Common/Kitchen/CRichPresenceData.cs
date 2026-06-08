using KitchenData;
using MessagePack;
using Platforms;
using Sirenix.Utilities;
using Unity.Entities;

namespace Kitchen
{
	[MessagePackObject(false)]
	public struct CRichPresenceData : IComponentData
	{
		[Key(0)]
		public bool IsInGame;

		[Key(1)]
		public int Day;

		[Key(2)]
		public bool IsMultiplayer;

		[Key(3)]
		public int Players;

		public RichPresenceData Convert()
		{
			RichPresenceData result = new RichPresenceData
			{
				IsInGame = IsInGame,
				Day = Day,
				IsMultiplayer = IsMultiplayer,
				Players = Players
			};
			if (GameInfo.CurrentlyAvailableDishes.Count > 0 && GameData.Main.TryGet<Dish>(GameInfo.CurrentlyAvailableDishes[0].ID, out var output))
			{
				result.MainDishImageKey = (output.ImageKey.IsNullOrWhitespace() ? null : output.ImageKey);
				result.MainDishName = output.Name;
			}
			return result;
		}
	}
}
