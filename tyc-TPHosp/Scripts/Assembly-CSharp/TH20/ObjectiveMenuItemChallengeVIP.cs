using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class ObjectiveMenuItemChallengeVIP : ObjectiveMenuItemBase
	{
		[SerializeField]
		private GameObject _root;

		[SerializeField]
		private TMP_Text _titleText;

		[SerializeField]
		private TMP_Text _objectiveStatusText;

		[SerializeField]
		private TMP_Text _vipActionText;

		[SerializeField]
		private Image _vipActionImage;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		private ChallengeVIP _challenge;

		private VIPChallengeConfig _config;

		public override void Initialise(Level level, Objective objective)
		{
			base.Initialise(level, objective);
			_challenge = objective as ChallengeVIP;
			_config = _challenge.GetConfig<VIPChallengeConfig>();
			_titleText.text = _config.ChallengeDisplayNameLoc.Translation;
			GameObjectUtils.SetActive(_vipActionImage.gameObject, isActive: false);
			_vipActionText.text = string.Empty;
			_objectiveStatusText.text = string.Empty;
			Refresh();
		}

		private void Refresh()
		{
			switch (_challenge.ChallengeStatus)
			{
			case Challenge.ChallengeState.WaitingToStart:
				GameObjectUtils.SetActive(_vipActionImage.gameObject, isActive: false);
				_vipActionText.text = string.Empty;
				_objectiveStatusText.text = LocalisedString.GetTranslationPlural("Challenges/ArrivingInDays_CS", _challenge.DaysUntilStartingChallenge);
				_objectiveStatusText.text = string.Format(_objectiveStatusText.text, _challenge.DaysUntilStartingChallenge);
				_progressBar.SetProgressSmooth(0f);
				break;
			case Challenge.ChallengeState.InProgress:
			{
				if (_challenge.VIP == null)
				{
					GameObjectUtils.SetActive(_vipActionImage.gameObject, isActive: false);
					_vipActionText.text = string.Empty;
					_objectiveStatusText.text = ScriptLocalization.Challenges.Travelling_CS;
					break;
				}
				string gUIActionText = _challenge.VIP.GetGUIActionText();
				if (gUIActionText.IsNullOrEmpty())
				{
					GameObjectUtils.SetActive(_vipActionImage.gameObject, isActive: false);
					_vipActionText.text = string.Empty;
					_objectiveStatusText.text = ScriptLocalization.Challenges.Travelling_CS;
				}
				else
				{
					Sprite statusSprite = _challenge.VIP.GetStatusSprite();
					_vipActionImage.overrideSprite = statusSprite;
					GameObjectUtils.SetActive(_vipActionImage.gameObject, statusSprite != null);
					if (statusSprite != null)
					{
						_objectiveStatusText.text = string.Empty;
						_vipActionText.text = gUIActionText;
					}
					else
					{
						_vipActionText.text = string.Empty;
						_objectiveStatusText.text = gUIActionText;
					}
				}
				VIPComponent component = _challenge.VIP.GetComponent<VIPComponent>();
				if (component != null)
				{
					float progressSmooth = (float)component.RoomsVisited / (float)component.RoomsWantsToVisit;
					_progressBar.SetProgressSmooth(progressSmooth);
				}
				else
				{
					_progressBar.SetProgressSmooth(0f);
				}
				break;
			}
			case Challenge.ChallengeState.WaitingToIssueDebrief:
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
				break;
			default:
				GameObjectUtils.SetActive(base.gameObject, isActive: false);
				break;
			}
		}

		private void Update()
		{
			Refresh();
		}
	}
}
