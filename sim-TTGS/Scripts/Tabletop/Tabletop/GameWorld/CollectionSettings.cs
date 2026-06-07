using System.Collections.Generic;
using Dhs5.Utility.Settings;
using I2.Loc;
using UnityEngine;

namespace Tabletop.GameWorld
{
	[Settings("Tabletop/Collection", Scope.Project)]
	public class CollectionSettings : CustomSettings<CollectionSettings>
	{
		[Header("Unpacking")]
		[SerializeField]
		private float m_unpackingBaseDelay = 5f;

		[SerializeField]
		private float m_unpackingSpeedDelay = 1f;

		[Header("Layout")]
		[SerializeField]
		private Vector2Int m_defaultLayout = new Vector2Int(5, 2);

		[SerializeField]
		private Vector2 m_defaultPageContainerSize;

		[SerializeField]
		private float m_defaultPageContainerY;

		[SerializeField]
		private float m_defaultFiltersContainerY;

		[SerializeField]
		private float m_defaultFooterContainerY;

		[SerializeField]
		private float m_defaultPageContainerGridHorSpace;

		[Space(10f)]
		[SerializeField]
		private Vector2Int m_smallLayout = new Vector2Int(5, 1);

		[SerializeField]
		private Vector2 m_smallPageContainerSize;

		[SerializeField]
		private float m_smallPageContainerY;

		[SerializeField]
		private float m_smallFiltersContainerY;

		[SerializeField]
		private float m_smallFooterContainerY;

		[SerializeField]
		private float m_smallPageContainerGridHorSpace;

		[Header("Pages")]
		[SerializeField]
		private Color m_undiscoveredColor;

		[Header("Sorts")]
		[SerializeField]
		private EnumValues<ECollectionSortType, int> m_baseSortOrder;

		[SerializeField]
		private EnumValues<ECollectionSortType, LocalizedString> m_sortTerms;

		[Header("Filters")]
		[SerializeField]
		private EnumValues<ECollectionFilterType, bool> m_defaultFilters;

		[SerializeField]
		private EnumValues<ECollectionFilterType, LocalizedString> m_filterTerms;

		[Header("Squad Selection")]
		[SerializeField]
		private int m_squadSlots = 10;

		public static float UnpackingBaseDelay => CustomSettings<CollectionSettings>.I.m_unpackingBaseDelay;

		public static float UnpackingSpeedDelay => CustomSettings<CollectionSettings>.I.m_unpackingSpeedDelay;

		public static Vector2Int DefaultLayout => CustomSettings<CollectionSettings>.I.m_defaultLayout;

		public static Vector2 DefaultPageContainerSize => CustomSettings<CollectionSettings>.I.m_defaultPageContainerSize;

		public static float DefaultFiltersContainerY => CustomSettings<CollectionSettings>.I.m_defaultFiltersContainerY;

		public static float DefaultPageContainerY => CustomSettings<CollectionSettings>.I.m_defaultPageContainerY;

		public static float DefaultFooterContainerY => CustomSettings<CollectionSettings>.I.m_defaultFooterContainerY;

		public static float DefaultPageContainerGridHorSpace => CustomSettings<CollectionSettings>.I.m_defaultPageContainerGridHorSpace;

		public static Vector2Int SmallLayout => CustomSettings<CollectionSettings>.I.m_smallLayout;

		public static Vector2 SmallPageContainerSize => CustomSettings<CollectionSettings>.I.m_smallPageContainerSize;

		public static float SmallPageContainerY => CustomSettings<CollectionSettings>.I.m_smallPageContainerY;

		public static float SmallFiltersContainerY => CustomSettings<CollectionSettings>.I.m_smallFiltersContainerY;

		public static float SmallFooterContainerY => CustomSettings<CollectionSettings>.I.m_smallFooterContainerY;

		public static float SmallPageContainerGridHorSpace => CustomSettings<CollectionSettings>.I.m_smallPageContainerGridHorSpace;

		public static Color UndiscoveredColor => CustomSettings<CollectionSettings>.I.m_undiscoveredColor;

		public static int SquadSlots => CustomSettings<CollectionSettings>.I.m_squadSlots;

		public static List<ECollectionSortType> GetBaseSortOrder()
		{
			List<ECollectionSortType> list = new List<ECollectionSortType>();
			foreach (var (item, _) in CustomSettings<CollectionSettings>.I.m_baseSortOrder)
			{
				list.Add(item);
			}
			list.Sort((ECollectionSortType e1, ECollectionSortType e2) => CustomSettings<CollectionSettings>.I.m_baseSortOrder[e1].CompareTo(CustomSettings<CollectionSettings>.I.m_baseSortOrder[e2]));
			return list;
		}

		public static ECollectionSortType GetSortTypeByIndex(int index)
		{
			return GetBaseSortOrder()[index];
		}

		public static string GetSortTypeTerm(ECollectionSortType sortType)
		{
			return CustomSettings<CollectionSettings>.I.m_sortTerms[sortType].mTerm;
		}

		public static bool GetDefaultFilterState(ECollectionFilterType filterType)
		{
			return CustomSettings<CollectionSettings>.I.m_defaultFilters[filterType];
		}

		public static string GetFilterTypeTerm(ECollectionFilterType filterType)
		{
			return CustomSettings<CollectionSettings>.I.m_filterTerms[filterType].mTerm;
		}
	}
}
