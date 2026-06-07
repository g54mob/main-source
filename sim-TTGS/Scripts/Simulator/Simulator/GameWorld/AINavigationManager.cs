using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class AINavigationManager : WorldManager
	{
		[SerializeField]
		private NavMeshSurface m_navSurface;

		private NavigationPoint m_shopDoorOutsidePoint;

		private NavigationPoint m_shopDoorInsidePoint;

		private List<NavigationPoint> m_spawnPoints = new List<NavigationPoint>();

		private NavigationPoint m_lastUsedSpawnPoint;

		private List<NavigationPoint> m_startSpawnPoints = new List<NavigationPoint>();

		private Queue<NavigationPoint> m_startSpawnPointsQueue;

		protected override void OnEnable()
		{
			base.OnEnable();
			ShopExtensionSystem.ShopStructureModified += OnShopStructureModified;
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			ShopExtensionSystem.ShopStructureModified -= OnShopStructureModified;
		}

		public void Register(NavigationPoint point)
		{
			switch (point.PointType)
			{
			case ENavigationPointType.SPAWN:
				m_spawnPoints.Add(point);
				break;
			case ENavigationPointType.START_SPAWN:
				m_startSpawnPoints.Add(point);
				break;
			case ENavigationPointType.SHOP_DOOR_OUTSIDE:
				m_shopDoorOutsidePoint = point;
				break;
			case ENavigationPointType.SHOP_DOOR_INSIDE:
				m_shopDoorInsidePoint = point;
				break;
			case ENavigationPointType.RESERVE:
			case ENavigationPointType.STAND:
				break;
			}
		}

		public NavigationPoint GetShopDoorOutsidePoint()
		{
			return m_shopDoorOutsidePoint;
		}

		public NavigationPoint GetShopDoorInsidePoint()
		{
			return m_shopDoorInsidePoint;
		}

		public NavigationPoint GetRandomSpawnPoint()
		{
			int index = Random.Range(0, m_spawnPoints.Count);
			NavigationPoint navigationPoint = m_spawnPoints[index];
			m_spawnPoints.RemoveAt(index);
			if (m_lastUsedSpawnPoint != null)
			{
				m_spawnPoints.Add(m_lastUsedSpawnPoint);
			}
			m_lastUsedSpawnPoint = navigationPoint;
			return navigationPoint;
		}

		public void PrepareStartSpawnPoints()
		{
			m_startSpawnPointsQueue = new Queue<NavigationPoint>();
			List<int> list = new List<int>();
			for (int i = 0; i < m_startSpawnPoints.Count; i++)
			{
				list.Add(i);
			}
			while (list.Count > 0)
			{
				int index = Random.Range(0, list.Count);
				m_startSpawnPointsQueue.Enqueue(m_startSpawnPoints[list[index]]);
				list.RemoveAt(index);
			}
		}

		public NavigationPoint GetRandomStartSpawnPoint()
		{
			NavigationPoint navigationPoint = m_startSpawnPointsQueue.Dequeue();
			m_startSpawnPointsQueue.Enqueue(navigationPoint);
			return navigationPoint;
		}

		protected virtual void OnShopStructureModified()
		{
			m_navSurface.BuildNavMesh();
		}
	}
}
