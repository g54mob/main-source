using Simulator.GameWorld;
using UnityEngine;

namespace Tabletop.GameWorld
{
	public class TabletopWorld : World
	{
		private static TabletopHUDPopup _tabletopHUDPopup;

		private static TabletopGameState _tabletopGameState;

		private static TabletopClientManager _tabletopClientManager;

		private static TabletopProductFactory _tabletopProductFactory;

		private static TabletopScoreManager _tabletopScoreManager;

		public static TabletopHUDPopup TabletopHUDPopup
		{
			get
			{
				if (_tabletopHUDPopup == null)
				{
					_tabletopHUDPopup = World.HUDPopup as TabletopHUDPopup;
				}
				return _tabletopHUDPopup;
			}
		}

		public static TabletopGameState TabletopGameState
		{
			get
			{
				if (_tabletopGameState == null)
				{
					_tabletopGameState = World.GameState as TabletopGameState;
				}
				return _tabletopGameState;
			}
		}

		public static TabletopClientManager TabletopClientManager
		{
			get
			{
				if (_tabletopClientManager == null)
				{
					_tabletopClientManager = World.ClientManager as TabletopClientManager;
				}
				return _tabletopClientManager;
			}
		}

		public static WargameManager WargameManager { get; private set; }

		public static TabletopDayScoreTracker TabletopDayScoreTracker { get; private set; }

		public static TabletopGameScoreTracker TabletopGameScoreTracker { get; private set; }

		public static TabletopProductFactory TabletopProductFactory
		{
			get
			{
				if (_tabletopProductFactory == null)
				{
					_tabletopProductFactory = World.ProductFactory as TabletopProductFactory;
				}
				return _tabletopProductFactory;
			}
		}

		public static TabletopScoreManager TabletopScoreManager
		{
			get
			{
				if (_tabletopScoreManager == null)
				{
					_tabletopScoreManager = World.ScoreManager as TabletopScoreManager;
				}
				return _tabletopScoreManager;
			}
		}

		protected override void LoadStaticSystems()
		{
			base.LoadStaticSystems();
			Collection.Load();
			TabletopPriceManager.Load();
		}

		protected override void SaveStaticSystems()
		{
			base.SaveStaticSystems();
			Collection.Save();
			TabletopPriceManager.Save();
		}

		protected override void ClearStaticSystems()
		{
			base.ClearStaticSystems();
			Collection.Clear();
			TabletopPriceManager.Clear();
		}

		protected override bool NeedsPreview3D()
		{
			return true;
		}

		protected override void RegisterSingleton(MonoBehaviour monoBehaviour)
		{
			base.RegisterSingleton(monoBehaviour);
			if (monoBehaviour is WargameManager wargameManager)
			{
				WargameManager = wargameManager;
			}
		}

		protected override DayScoreTracker CreateDayScoreTracker()
		{
			TabletopDayScoreTracker = new TabletopDayScoreTracker();
			return TabletopDayScoreTracker;
		}

		protected override GameScoreTracker CreateGameScoreTracker()
		{
			TabletopGameScoreTracker = new TabletopGameScoreTracker();
			return TabletopGameScoreTracker;
		}
	}
}
