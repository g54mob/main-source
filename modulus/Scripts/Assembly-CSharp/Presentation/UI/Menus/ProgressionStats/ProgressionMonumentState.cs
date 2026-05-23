using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus.ProgressionStats
{
	public class ProgressionMonumentState : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI _titleText;

		[SerializeField]
		private TextMeshProUGUI _statusText;

		[SerializeField]
		private GameObject _statusSuccessObject;

		[SerializeField]
		private Image _monumentImage;

		[SerializeField]
		private Image _background;

		[SerializeField]
		private Image _border;

		[SerializeField]
		private Color _textColorIncomplete;

		[SerializeField]
		private Color _textColorCompleted;

		[SerializeField]
		private Color _borderColorIncomplete;

		[SerializeField]
		private Color _borderColorCompleted;

		[SerializeField]
		private Color _backgroundColorIncomplete;

		[SerializeField]
		private Color _backgroundColorCompleted;

		[SerializeField]
		private Color _monumentColorIncomplete;

		[SerializeField]
		private Color _monumentColorUnderConstruction;

		[SerializeField]
		private Color _monumentColorCompleted;

		[SerializeField]
		private Sprite _monumentCompletedSprite;

		[SerializeField]
		[LocaKey]
		private string _statusLocaKeyMissing;

		[SerializeField]
		[LocaKey]
		private string _statusLocaKeyUnderConstruction;

		[SerializeField]
		[LocaKey]
		private string _statusLocaKeyCompleted;

		private string _currentStatusLoca;

		private void SetText()
		{
			_statusText.text = LocalizationUtility.GetLocalizedText(_currentStatusLoca);
		}

		public void SetStateDefault()
		{
			_currentStatusLoca = _statusLocaKeyMissing;
			SetText();
			SetStyle(isComplete: false);
		}

		public void SetStateUnderConstruction()
		{
			_currentStatusLoca = _statusLocaKeyUnderConstruction;
			SetText();
			SetStyle(isComplete: false, underConstruction: true);
		}

		public void SetStateCompleted()
		{
			_currentStatusLoca = _statusLocaKeyCompleted;
			SetText();
			SetStyle(isComplete: true);
		}

		private void SetStyle(bool isComplete, bool underConstruction = false)
		{
			_monumentImage.overrideSprite = ((isComplete || underConstruction) ? _monumentCompletedSprite : null);
			_monumentImage.color = (underConstruction ? _monumentColorUnderConstruction : (isComplete ? _monumentColorCompleted : _monumentColorIncomplete));
			_statusText.color = (isComplete ? _textColorCompleted : _textColorIncomplete);
			_background.color = (isComplete ? _backgroundColorCompleted : _backgroundColorIncomplete);
			_border.color = (isComplete ? _borderColorCompleted : _borderColorIncomplete);
			_statusSuccessObject.SetActive(isComplete);
		}
	}
}
