using KitchenData;
using Unity.Entities;

namespace Kitchen
{
	public struct CPlayerCosmetics : IComponentData
	{
		public PlayerOutfit OutfitID;

		public PlayerShoe Shoe;

		public DataObjectList Cosmetics;

		public PlayerCosmetic Get(CosmeticType type)
		{
			foreach (int cosmetic in Cosmetics)
			{
				if (GameData.Main.TryGet<PlayerCosmetic>(cosmetic, out var output) && output.CosmeticType == type)
				{
					return output;
				}
			}
			return null;
		}

		public void Set(CosmeticType type, int id)
		{
			Cosmetics = Set(Cosmetics, type, id);
		}

		public static DataObjectList Set(DataObjectList cosmetics, CosmeticType type, int id)
		{
			bool flag = false;
			for (int i = 0; i < cosmetics.Count; i++)
			{
				int id2 = cosmetics[i];
				if (GameData.Main.TryGet<PlayerCosmetic>(id2, out var output) && output.CosmeticType == type)
				{
					cosmetics[i] = id;
					flag = true;
				}
			}
			if (!flag)
			{
				cosmetics.Add(id);
			}
			for (int num = cosmetics.Count - 1; num >= 0; num--)
			{
				if (cosmetics[num] == 0 || !GameData.Main.TryGet<PlayerCosmetic>(cosmetics[num], out var _))
				{
					cosmetics.RemoveAt(num);
				}
			}
			return cosmetics;
		}
	}
}
