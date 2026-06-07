using CTS.BBT.TechTree;
using CTS.Core.Utilities;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT
{
	[CreateAssetMenu(fileName = "New Furniture", menuName = "BBT/Furniture")]
	public class FurnitureSO : AbsInfluentBuyableItemSO, IRevert
	{
		[SerializeField]
		[BoxGroup("Furniture")]
		private bool _canBeUseByPlayer = true;

		[field: SerializeField]
		[field: BoxGroup("Furniture")]
		public EFurnitureTags Tags { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Furniture")]
		public Furniture Prefab { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Furniture")]
		public Material[] PossibleMaterials { get; private set; }

		[field: SerializeField]
		[field: BoxGroup("Furniture")]
		public EPose Posable { get; private set; }

		[field: SerializeField]
		public int OrderOffset { get; private set; }

		public bool HasPrefab => Prefab != null;

		public bool CanBeUseByPlayer => _canBeUseByPlayer;

		public void Initialize(string p_name, Furniture p_furniture)
		{
			base.Name = p_name;
			Prefab = p_furniture;
		}

		public bool HaveNewValues(FurnitureDataStruct p_data)
		{
			if (base.PurchasePrice != p_data.Price)
			{
				return true;
			}
			if (base.Influence != p_data.Influence)
			{
				return true;
			}
			if (base.PrestigePoint != p_data.PrestigePoint)
			{
				return true;
			}
			if (base.PrestigeByPrice != p_data.PrestigeByPrice)
			{
				return true;
			}
			return false;
		}

		public static FurnitureSO CreateCopyWithNewValues(FurnitureSO p_original, FurnitureDataStruct p_data)
		{
			FurnitureSO furnitureSO = ScriptableObject.CreateInstance<FurnitureSO>();
			furnitureSO.SetNewValues(p_data);
			return furnitureSO;
		}

		public void SetNewValues(FurnitureDataStruct p_data)
		{
			base.PurchasePrice = p_data.Price;
			base.Influence = p_data.Influence;
			base.PrestigePoint = p_data.PrestigePoint;
			base.PrestigeByPrice = p_data.PrestigeByPrice;
		}

		public void ImportData(FurnitureImportData data)
		{
			base.PurchasePrice = data.Price;
			base.Influence = data.Influence;
			base.PrestigePoint = data.PrestigePoint;
			base.PrestigeByPrice = data.PrestigeByPrice;
		}

		public float OrderByTagAndStyle()
		{
			float num = TagReorder(Tags);
			float num2 = StyleReorder(base.Style);
			return (float)(((object)TechTreeTechnologyRequiered != null) ? (TechTreeManager.FirstLevelHasBeenResearched(TechTreeTechnologyRequiered) ? 1 : 2) : 0) * 1000f + num * 100f + num2 + (float)OrderOffset;
		}

		public int OrderByTag()
		{
			return TagReorder(Tags);
		}

		public int OrderByStyle()
		{
			return StyleReorder(base.Style);
		}

		private static int StyleReorder(EBarStyle style)
		{
			return style switch
			{
				EBarStyle.Cheap => 1, 
				EBarStyle.Basic => 2, 
				EBarStyle.Industrial => 3, 
				EBarStyle.Vampire => 4, 
				EBarStyle.Kawaii => 5, 
				EBarStyle.Western => 6, 
				EBarStyle.Dark => 7, 
				EBarStyle.Cyberpunk => 8, 
				_ => 0, 
			};
		}

		private static int TagReorder(EFurnitureTags tag)
		{
			if (tag.HasFlagNonAlloc(EFurnitureTags.Pump))
			{
				return 1;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.BarItem))
			{
				return 2;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.HighTable))
			{
				return 3;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.HighChair))
			{
				return 4;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.Restroom))
			{
				return 5;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.Rug))
			{
				return 7;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.WallPlacement))
			{
				return 8;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.Decorative))
			{
				return 6;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.Fridge))
			{
				return 9;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.Shelve))
			{
				return 10;
			}
			if (tag.HasFlagNonAlloc(EFurnitureTags.Bloodwork))
			{
				return 11;
			}
			return 0;
		}
	}
}
