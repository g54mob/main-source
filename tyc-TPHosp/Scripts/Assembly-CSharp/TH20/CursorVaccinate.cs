using System.Collections.Generic;

namespace TH20
{
	public class CursorVaccinate : CursorMode
	{
		private Level _level;

		public CursorVaccinate(CursorManager cursorManager, Level level)
			: base(cursorManager)
		{
			_level = level;
		}

		public override void OnBecomeActive()
		{
			_cursorManager.SetCursorVisible(visible: true);
			_cursorManager.SetCursorIcon(CursorIcon.Vaccinate);
		}

		public override void CursorUpdate(InputManager inputManager)
		{
			ChallengeEpidemic challengeEpidemic = GetChallengeEpidemic();
			if (challengeEpidemic == null)
			{
				base.Manager.PopMode<CursorVaccinate>();
				return;
			}
			Character characterAtCursor = CursorSelectionHelpers.GetCharacterAtCursor(_level.CharacterManager);
			if (characterAtCursor != null && ChallengeEpidemic.IsInfectableEver(characterAtCursor))
			{
				_level.HighlightManager.HighlightObject(characterAtCursor);
				if (inputManager.GetMouseQuickOnScene(MouseButton.Left))
				{
					challengeEpidemic.VaccinateCharacter(characterAtCursor);
				}
			}
			if (inputManager.GetMouseQuickOnScene(MouseButton.Right))
			{
				base.Manager.PopMode<CursorVaccinate>();
			}
		}

		private ChallengeEpidemic GetChallengeEpidemic()
		{
			List<ChallengeEpidemic> activeChallengesOfType = _level.ChallengeManager.GetActiveChallengesOfType<ChallengeEpidemic>();
			if (activeChallengesOfType.Count == 1)
			{
				return activeChallengesOfType[0];
			}
			return null;
		}
	}
}
