using System.Collections.Generic;
using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct COutfitSelector : IApplianceProperty, IAttachableProperty, IComponentData
	{
		public static List<PlayerOutfit> Outfits = new List<PlayerOutfit>
		{
			PlayerOutfit.Chef,
			PlayerOutfit.Waiter,
			PlayerOutfit.Apron
		};

		public PlayerOutfit OutfitID;

		public COutfitSelector Next()
		{
			for (int i = 0; i < Outfits.Count; i++)
			{
				if (Outfits[i] == OutfitID)
				{
					int index = (i + 1) % Outfits.Count;
					return new COutfitSelector
					{
						OutfitID = Outfits[index]
					};
				}
			}
			return new COutfitSelector
			{
				OutfitID = PlayerOutfit.Chef
			};
		}
	}
}
