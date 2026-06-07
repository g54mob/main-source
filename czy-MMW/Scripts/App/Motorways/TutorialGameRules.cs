using Factory;
using FixMath;
using Motorways.Models;
using Motorways.Processes;
using Motorways.Views;

namespace Motorways
{
	public class TutorialGameRules : GameRules
	{
		private static readonly Fix64 PinTimerSlowdownStart = (Fix64)0.75f;

		private static readonly Fix64 PinTimerSlowdownFinish = (Fix64)0.95f;

		private static readonly Fix64 PinTimerSlowdownLength = PinTimerSlowdownFinish - PinTimerSlowdownStart;

		[Dependency]
		private ClockModel _clock;

		[Dependency]
		private ActivePlayer _player;

		[Dependency]
		private TutorialProgressionProcess _tutorialProcess;

		[Dependency]
		private GameUIScreen _gameUI;

		public override int GetMaximumDemandForDestination(DestinationModel destinationModel)
		{
			int generatedDemandLimitForDestination = _tutorialProcess.GetGeneratedDemandLimitForDestination(destinationModel.TutorialIdentifier);
			if (generatedDemandLimitForDestination != -1)
			{
				return generatedDemandLimitForDestination;
			}
			if (_tutorialProcess.LastReachedMarker < TutorialProgressionProcess.TutorialMarker.BigPinsAllowed)
			{
				return 5;
			}
			return base.GetMaximumDemandForDestination(destinationModel);
		}

		public override StringId GetUpgradeScreenDescriptionUpgrades(int optionCount = 2)
		{
			if (_clock.Day < 23)
			{
				return StringId.Tutorial_SecondUpgrade;
			}
			return base.GetUpgradeScreenDescriptionUpgrades(optionCount);
		}

		public override StringId GetNoConcreteErrorMessage(DeviceInputType type)
		{
			if (_tutorialProcess.LastReachedMarker < TutorialProgressionProcess.TutorialMarker.BasicsLearnt)
			{
				switch (type)
				{
				case DeviceInputType.Touch:
					return StringId.Tutorial_Error_EarlyDeleteMode_Touch_MouseToggle;
				case DeviceInputType.Mouse:
					if (_player.IsDrawModeToggleEnabled)
					{
						return StringId.Tutorial_Error_EarlyDeleteMode_Touch_MouseToggle;
					}
					return StringId.Tutorial_Error_EarlyDeleteMode_Mouse;
				case DeviceInputType.Remote:
					return StringId.Tutorial_Error_EarlyDeleteMode_Remote;
				case DeviceInputType.Controller:
					if (_player.IsTapDrawEnabled)
					{
						return StringId.Tutorial_Error_EarlyDeleteMode_ControllerTap;
					}
					return StringId.Tutorial_Error_EarlyDeleteMode_Controller;
				}
			}
			else
			{
				switch (type)
				{
				case DeviceInputType.Touch:
					return StringId.Tutorial_Error_DeleteRoads_Touch_MouseToggle;
				case DeviceInputType.Mouse:
					if (_player.IsDrawModeToggleEnabled)
					{
						return StringId.Tutorial_Error_DeleteRoads_Touch_MouseToggle;
					}
					return StringId.Tutorial_Error_DeleteRoads_Mouse;
				case DeviceInputType.Remote:
					return StringId.Tutorial_Error_DeleteRoads_Remote;
				case DeviceInputType.Controller:
					if (_player.IsTapDrawEnabled)
					{
						return StringId.Tutorial_Error_DeleteRoads_ControllerTap;
					}
					return StringId.Tutorial_Error_EarlyDeleteMode_Controller;
				}
			}
			return base.GetNoConcreteErrorMessage(type);
		}

		public override StringId GetGameOverLineOne()
		{
			return StringId.GameOver_TutorialLate_LineOne;
		}

		public override StringId GetGameOverLineTwo()
		{
			return StringId.GameOver_TutorialLate_LineThree;
		}

		public override Fix64 GetClockSpeedMultiplier()
		{
			if (!_gameUI.IsClockVisible)
			{
				return _tutorialProcess.ClockSpeedMultiplier;
			}
			return base.GetClockSpeedMultiplier();
		}

		public override Fix64 GetOvercrowdingSpeedMultiplier(Fix64 currentTimerProgress)
		{
			Fix64 overcrowdingSpeedMultiplier = base.GetOvercrowdingSpeedMultiplier(currentTimerProgress);
			if (_tutorialProcess.CurrentStageShortName == "E")
			{
				if (currentTimerProgress < PinTimerSlowdownStart)
				{
					return overcrowdingSpeedMultiplier * (Fix64)0.25;
				}
				return overcrowdingSpeedMultiplier;
			}
			if (currentTimerProgress < PinTimerSlowdownStart)
			{
				return overcrowdingSpeedMultiplier;
			}
			if (currentTimerProgress < PinTimerSlowdownFinish)
			{
				return overcrowdingSpeedMultiplier * (PinTimerSlowdownFinish - currentTimerProgress) / PinTimerSlowdownLength;
			}
			return Fix64.Zero;
		}

		public override int GetNumberOfUpgradeOptionsPerWeek()
		{
			return 0;
		}

		public override bool ShouldShowNewUpgradeIconDescriptionForType(UpgradeType type)
		{
			return false;
		}

		public override bool UIStartVisible()
		{
			return false;
		}

		public override bool SupportsLeaderboards()
		{
			return false;
		}

		public override bool CanSave()
		{
			return false;
		}

		public override bool ShowDisconnectedBuildingsUI()
		{
			return false;
		}

		public override bool ShouldUseUpgradeScreenOffsets()
		{
			return _clock.Week <= 5;
		}

		public override bool ShowNoConcreteErrorNotification()
		{
			return _tutorialProcess.ShowNoConcreteErrorMessage;
		}

		public override bool ShowCannotConnectToCarparkErrorNotification()
		{
			return _tutorialProcess.LastReachedMarker >= TutorialProgressionProcess.TutorialMarker.DemandCollectedFromNewHouseColor;
		}

		public override bool SupportsChallenges()
		{
			return false;
		}

		public override bool RecordsGameStatistics()
		{
			return false;
		}
	}
}
