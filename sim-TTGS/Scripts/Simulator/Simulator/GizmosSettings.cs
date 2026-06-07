using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Settings("Editor/Gizmos", Scope.User)]
	public class GizmosSettings : CustomSettings<GizmosSettings>
	{
		[Header("World Singletons")]
		[SerializeField]
		private EnabledValue<Color> m_playerStart;

		[SerializeField]
		private EnabledValue<Color> m_deliverySystem;

		[Header("Navigation")]
		[SerializeField]
		private EnabledValue<Color> m_spawnPoints;

		[SerializeField]
		private EnabledValue<Color> m_startSpawnPoints;

		[SerializeField]
		private EnabledValue<Color> m_doorPoints;

		[SerializeField]
		private EnabledValue<Color> m_standPoints;

		[Header("Furnitures")]
		[SerializeField]
		private EnabledValue<Color> m_furnitureBounds;

		[Header("Preview 3D")]
		[SerializeField]
		private EnabledValue<Color> m_layoutBounds;

		[Header("Object Stack")]
		[SerializeField]
		private EnabledValue<Color> m_objectStackBounds;

		[Header("Mesh Drawer")]
		[SerializeField]
		private EnabledValue<Color> m_meshDrawer;

		public static bool DrawPlayerStart(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_playerStart.IsEnabled(out color);
		}

		public static bool DrawDeliverySystem(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_deliverySystem.IsEnabled(out color);
		}

		public static bool DrawSpawnPoints(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_spawnPoints.IsEnabled(out color);
		}

		public static bool DrawStartSpawnPoints(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_startSpawnPoints.IsEnabled(out color);
		}

		public static bool DrawDoorPoints(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_doorPoints.IsEnabled(out color);
		}

		public static bool DrawStandPoints(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_standPoints.IsEnabled(out color);
		}

		public static bool DrawFurnitureBounds(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_furnitureBounds.IsEnabled(out color);
		}

		public static bool DrawPreview3DLayoutBounds(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_layoutBounds.IsEnabled(out color);
		}

		public static bool DrawObjectStackBounds(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_objectStackBounds.IsEnabled(out color);
		}

		public static bool DrawMesh(out Color color)
		{
			return CustomSettings<GizmosSettings>.I.m_meshDrawer.IsEnabled(out color);
		}
	}
}
