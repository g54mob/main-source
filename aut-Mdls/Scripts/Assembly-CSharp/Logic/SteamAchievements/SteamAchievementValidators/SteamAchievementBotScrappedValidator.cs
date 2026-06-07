using System.Collections.Generic;
using Data.FactoryFloor.Resources;
using Events.FactoryFloor;
using UnityEngine;

namespace Logic.SteamAchievements.SteamAchievementValidators
{
	[CreateAssetMenu(menuName = "Steam Achievements/Validators/Bot Scrapped Validator", fileName = "SteamAchievementBotScrappedValidator", order = 0)]
	public class SteamAchievementBotScrappedValidator : AbstractSteamAchievementValidator
	{
		[SerializeField]
		private ResourceScrappedEvent _resourceScrappedEvent;

		[SerializeField]
		private List<NonShapeResourceDataSO> _allBotResources;

		private bool _wasAchieved;

		public override void Initialize()
		{
			_resourceScrappedEvent.RegisterInline(HandleResourceScrapped);
		}

		public override void UnInitialize()
		{
			_wasAchieved = false;
			_resourceScrappedEvent.UnRegisterInline(HandleResourceScrapped);
		}

		private void HandleResourceScrapped(Resource resource)
		{
			if (_wasAchieved)
			{
				return;
			}
			foreach (NonShapeResourceDataSO allBotResource in _allBotResources)
			{
				if (resource.Data == allBotResource)
				{
					_wasAchieved = true;
					break;
				}
			}
		}

		public override bool IsSteamAchievementReached()
		{
			return _wasAchieved;
		}
	}
}
