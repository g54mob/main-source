using Assets.Nimbatus.GUI.Common.Scripts;
using Assets.Nimbatus.Scripts.Persistence;
using I2.Loc;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.GalaxyMap.Tournaments.UI
{
	public class StartTournamentButton : MonoBehaviour
	{
		public Color NormalColor;

		public Color HoverColor;

		public Color DisabledColor;

		public UILabel Label;

		private bool _enabled;

		private TournamentUI _manager;

		private bool _hover;

		public void Init(TournamentUI manager)
		{
			_manager = manager;
		}

		public void OnClick()
		{
			if (_enabled)
			{
				StartCoroutine(_manager.StartTournament());
			}
		}

		public void Enable(bool enable)
		{
			_enabled = enable;
		}

		public void OnTooltip(bool show)
		{
			if (show)
			{
				if (!_enabled)
				{
					NimbatusToolTip.Show(LocalizationManager.GetTermTranslation("Tournaments/SelectDrone"));
				}
			}
			else
			{
				NimbatusToolTip.Show(null);
			}
		}

		public void Update()
		{
			if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament != null)
			{
				if (!_enabled)
				{
					Label.color = DisabledColor;
				}
				else
				{
					Label.color = (_hover ? HoverColor : NormalColor);
				}
				if (GlobalSerializableMonobehaviour<TournamentManager, TournamentManagerSaveData>.Instance.ActiveTournament.IsTournamentRunning())
				{
					Label.text = LocalizationManager.GetTermTranslation("Tournaments/ContinueTournament");
				}
				else
				{
					Label.text = LocalizationManager.GetTermTranslation("Tournaments/EnterTournament");
				}
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
