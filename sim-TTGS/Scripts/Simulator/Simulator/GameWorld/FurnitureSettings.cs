using System.Collections.Generic;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator.GameWorld
{
	[Settings("Shop/Furnitures", Scope.Project)]
	public class FurnitureSettings : CustomSettings<FurnitureSettings>
	{
		[Header("Placement")]
		[SerializeField]
		private float m_floorY;

		[SerializeField]
		private float m_ceilingY;

		[SerializeField]
		private float m_step;

		[SerializeField]
		private float m_maxX;

		[SerializeField]
		private float m_maxZ;

		[Space(15f)]
		[SerializeField]
		[Layer]
		private int m_phantomLayer;

		[SerializeField]
		[Layer]
		private int m_spaceIndicatorLayer;

		[SerializeField]
		private LayerMask m_groundFurniturePhantomMask;

		[SerializeField]
		private LayerMask m_wallsFurniturePhantomMask;

		[SerializeField]
		private LayerMask m_ceilingFurniturePhantomMask;

		[Header("Visuals")]
		[SerializeField]
		private Material m_spaceIndicatorMaterial;

		[SerializeField]
		private Material m_validPhantomMaterial;

		[SerializeField]
		private Material m_invalidPhantomMaterial;

		[Header("Defaults")]
		[SerializeField]
		private List<SaveClass_Furnitures.FurnitureState> m_defaultFurnitures;

		[Header("Sale")]
		[SerializeField]
		[Range(0f, 1f)]
		private float m_resellPricePercentage = 0.5f;

		public static float FloorY => CustomSettings<FurnitureSettings>.I.m_floorY;

		public static float CeilingY => CustomSettings<FurnitureSettings>.I.m_ceilingY;

		public static float Step => CustomSettings<FurnitureSettings>.I.m_step;

		public static float MaxX => CustomSettings<FurnitureSettings>.I.m_maxX;

		public static float MaxZ => CustomSettings<FurnitureSettings>.I.m_maxZ;

		public static int PhantomLayer => CustomSettings<FurnitureSettings>.I.m_phantomLayer;

		public static int SpaceIndicatorLayer => CustomSettings<FurnitureSettings>.I.m_spaceIndicatorLayer;

		public static int GroundFurniturePhantomMask => CustomSettings<FurnitureSettings>.I.m_groundFurniturePhantomMask;

		public static int WallsFurniturePhantomMask => CustomSettings<FurnitureSettings>.I.m_wallsFurniturePhantomMask;

		public static int CeilingFurniturePhantomMask => CustomSettings<FurnitureSettings>.I.m_ceilingFurniturePhantomMask;

		public static Material SpaceIndicatorMaterial => CustomSettings<FurnitureSettings>.I.m_spaceIndicatorMaterial;

		public static Material ValidPhantomMaterial => CustomSettings<FurnitureSettings>.I.m_validPhantomMaterial;

		public static Material InvalidPhantomMaterial => CustomSettings<FurnitureSettings>.I.m_invalidPhantomMaterial;

		public static List<SaveClass_Furnitures.FurnitureState> DefaultFurnitures => new List<SaveClass_Furnitures.FurnitureState>(CustomSettings<FurnitureSettings>.I.m_defaultFurnitures);

		public static float ResellPricePercentage => CustomSettings<FurnitureSettings>.I.m_resellPricePercentage;
	}
}
