using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using _Code.Characters;
using _Code.Characters.DialogSystem;
using _Code.Infrastructure.CloseUps.Views.Phone;
using _Code.Infrastructure.Consumables;
using _Code.Infrastructure.Locations;
using _Code.Infrastructure.Sound;
using _Code.Infrastructure._NINAH__Dream;
using _Code.Menues.HUD.Animations;
using _Code.Rooms;

namespace _Code.DialogSystem
{
	public sealed class MockDialogManager : IDialogManager
	{
		public bool IsOpened { get; }

		public bool IsOpenedSubtitle { get; }

		public bool EverRudeToFema { get; }

		public event Action DialogStarted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action SubtitleStarted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<bool, bool> DialogEnded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action GunShowed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action GunHidden
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action GunShot
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action FakedShot
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action EnergyConsumed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<string, Camera> Dead
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ERoom> RoomKilled
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action EndingTriggered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action CutsceneTriggered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action ShowedAura
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action GivenPovistka
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action FedCat
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<float> FadedIn
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<float> FadedOut
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Func<bool> HasCompletedMushroomCheck
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ELocation> WentToLocation
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action CultistsBegun
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action CatPet
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action CatTaken
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<EPhoneSubscriber> UnlockedPhoneSubscriber
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Func<EPhoneSubscriber, string> GotPhoneNumber
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Func<bool> CouldOrderCourier
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<EConsumable, int> OrderedCourier
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ESound> StartedWindowNoise
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action ProphetDontCheckConditionMet
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ECharacterType, ERoomPeopleState> PoseChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<ECharacterType, ERoomPeopleState> PoseChangedTomorrow
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Func<int> GotEnergy
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<bool> SetFridgeActivity
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action BaseDialogLineShowed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action ButtonsDialogLineShowed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Func<ECharacterSign, bool> PlayerSignShowed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action ArmpitsWashed
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action PlayerRevealedByVigilante
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action CultistsSaved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action UnlockedDeathEnding
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<EHUDAnimation> PlayedAnimation
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action UnlockedMushroomEnding
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action UnlockedKillerEnding
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action IntroSkipped
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Func<EDream, bool> HadSeenDream
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void AddOnDialogEndedAction(Action action)
		{
		}

		public void RunDialog(CharacterSOData character, string nodeName, EDialogOverlayType overlayType = EDialogOverlayType.None, Camera camera = null, DialogViewData viewData = null, bool hideCharacter = false)
		{
		}

		public int GetCurrentDialogIndexForCharacter(CharacterSOData character)
		{
			return 0;
		}

		public void AddTalk(ECharacterType characterType)
		{
		}

		public void ShowSubtitle(string dialogName, Camera camera = null, EDialogOverlayType overlay = EDialogOverlayType.None, bool autoskip = false)
		{
		}

		public void ShowSubtitlePopup(EInfoMessageType messageType, float f)
		{
		}

		public void ShowSubtitlePopup(string message)
		{
		}

		public void HideSubtitle()
		{
		}

		public void AddActionForNextDialogEnded(Action temporaryDialogAction)
		{
		}

		public void CompleteShotAnimation()
		{
		}

		public void UpdateTalksCount()
		{
		}

		public void SetToLastTalk(ECharacterType character)
		{
		}

		public void RefreshSignChecks()
		{
		}

		public void InitializeProphetCondition(Func<int, bool> condition)
		{
		}

		public void InitializeMushroomeaterCondition(Func<int, bool> condition)
		{
		}

		public void InitializePriestCondition(Func<int, bool> condition)
		{
		}

		public void InitializeGetDay(Func<int> func)
		{
		}

		public bool IsNodeVisited(string nodeName)
		{
			return false;
		}
	}
}
