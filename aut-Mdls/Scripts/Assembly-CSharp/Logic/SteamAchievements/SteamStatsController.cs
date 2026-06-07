using Data.FactoryFloor.Resources;
using Data.Shapes;
using Events.FactoryFloor;
using Events.SteamAchievements;
using UnityEngine;

namespace Logic.SteamAchievements
{
	[CreateAssetMenu(menuName = "Steam Achievements/SteamStatsController", fileName = "SteamStatsController", order = 0)]
	public class SteamStatsController : ScriptableObject
	{
		[SerializeField]
		private IncrementSteamStatEvent _incrementSteamStatEvent;

		[SerializeField]
		private ResourceCreatedEventSO _resourceCreatedEvent;

		[SerializeField]
		private ResourceScrappedEvent _resourceScrappedEvent;

		[SerializeField]
		private SteamAchievementConstants.SteamStatNames _cubeCreatedStatName;

		[SerializeField]
		private SteamAchievementConstants.SteamStatNames _resourcesScrappedStatName;

		[SerializeField]
		private ShapeDataSO _cubeShapeDataSO;

		private int _cubesProducedAmount;

		private int _previousCubesProducedAmount;

		private int _resourcesScrappedAmount;

		private int _previousResourcesScrappedAmount;

		public void Init(int currentCubesProduced, int currentResourcesScrapped)
		{
			_cubesProducedAmount = currentCubesProduced;
			_previousCubesProducedAmount = currentCubesProduced;
			_resourcesScrappedAmount = currentResourcesScrapped;
			_previousResourcesScrappedAmount = currentResourcesScrapped;
			_resourceCreatedEvent.RegisterInline(HandleResourceCreated);
			_resourceScrappedEvent.RegisterInline(HandleResourceScrapped);
		}

		public void UnInit()
		{
			_resourceCreatedEvent.UnRegisterInline(HandleResourceCreated);
			_resourceScrappedEvent.UnRegisterInline(HandleResourceScrapped);
		}

		private void HandleResourceScrapped(Resource resource)
		{
			if (resource != null)
			{
				_resourcesScrappedAmount++;
			}
		}

		private void HandleResourceCreated(Resource resource)
		{
			if (resource is ShapeResource shapeResource && shapeResource.ShapeData.GetShapeHash() == _cubeShapeDataSO.Data.GetShapeHash())
			{
				_cubesProducedAmount++;
			}
		}

		public void Update()
		{
			UpdateCubesProducedStat();
			UpdateResourcesScrappedStat();
		}

		private void UpdateResourcesScrappedStat()
		{
			if (_resourcesScrappedAmount > _previousResourcesScrappedAmount)
			{
				_incrementSteamStatEvent.Fire((_resourcesScrappedStatName.ToString(), _resourcesScrappedAmount));
				_previousResourcesScrappedAmount = _resourcesScrappedAmount;
			}
		}

		private void UpdateCubesProducedStat()
		{
			if (_cubesProducedAmount > _previousCubesProducedAmount)
			{
				_incrementSteamStatEvent.Fire((_cubeCreatedStatName.ToString(), _cubesProducedAmount));
				_previousCubesProducedAmount = _cubesProducedAmount;
			}
		}
	}
}
