#define ENABLE_DEBUG_LOGS
using System.Collections.Generic;
using Events;
using Events.SteamAchievements;
using Logic.SteamAchievements.SteamAchievementValidators;
using Steamworks;
using UnityEngine;
using Utils;

namespace Logic.SteamAchievements
{
	[CreateAssetMenu(menuName = "Steam Achievements/Controller", fileName = "SteamAchievementsController", order = 0)]
	public class SteamAchievementsController : ScriptableObject
	{
		[SerializeField]
		private string _validatorSOPath = "Assets/ScriptableObjects/Systems/SteamAchievements/Validators/";

		[SerializeField]
		private UnlockAchievementEvent _unlockAchievementEvent;

		[SerializeField]
		private List<AbstractSteamAchievementValidator> _steamAchievementsValidators;

		[SerializeField]
		private BaseEvent _greyBotInPainterEvent;

		private List<AbstractSteamAchievementValidator> _activeAchievementValidators = new List<AbstractSteamAchievementValidator>();

		public void Init()
		{
			_activeAchievementValidators = new List<AbstractSteamAchievementValidator>();
			foreach (AbstractSteamAchievementValidator steamAchievementsValidator in _steamAchievementsValidators)
			{
				if (SteamUserStats.GetAchievement(steamAchievementsValidator.SteamAchievementName.ToString(), out var pbAchieved) && !pbAchieved)
				{
					this.Log("Track achievement: " + steamAchievementsValidator.SteamAchievementName, "Init", 37);
					_activeAchievementValidators.Add(steamAchievementsValidator);
					steamAchievementsValidator.Initialize();
				}
				else
				{
					this.Log("Not Tracking achievement: " + steamAchievementsValidator.SteamAchievementName, "Init", 43);
				}
			}
			if (SteamUserStats.GetAchievement(SteamAchievementConstants.SteamAchievementNames.LOCAL_BOT_IN_PAINTER.ToString(), out var pbAchieved2) && !pbAchieved2)
			{
				_greyBotInPainterEvent.Register(HandleGreyBotInPainter);
			}
		}

		public void UnInit()
		{
			foreach (AbstractSteamAchievementValidator steamAchievementsValidator in _steamAchievementsValidators)
			{
				steamAchievementsValidator.UnInitialize();
			}
			_greyBotInPainterEvent.UnRegister(HandleGreyBotInPainter);
		}

		public void Update()
		{
			for (int num = _activeAchievementValidators.Count - 1; num >= 0; num--)
			{
				AbstractSteamAchievementValidator abstractSteamAchievementValidator = _activeAchievementValidators[num];
				if (abstractSteamAchievementValidator.IsSteamAchievementReached())
				{
					_unlockAchievementEvent.Fire(abstractSteamAchievementValidator.SteamAchievementName.ToString());
					_activeAchievementValidators.Remove(abstractSteamAchievementValidator);
					abstractSteamAchievementValidator.UnInitialize();
				}
			}
		}

		private void HandleGreyBotInPainter()
		{
			_greyBotInPainterEvent.UnRegister(HandleGreyBotInPainter);
			_unlockAchievementEvent.Fire(SteamAchievementConstants.SteamAchievementNames.LOCAL_BOT_IN_PAINTER.ToString());
		}
	}
}
