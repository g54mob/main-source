using Data.Variables;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.Menus.ProgressionStats
{
	public class ProgressionGNNGateState : MonoBehaviour
	{
		[SerializeField]
		private BoolVariableSO _GNNGateCompleted;

		[SerializeField]
		private IntVariableSO _GNNGateCurrentPhaseSO;

		[SerializeField]
		private IntVariableSO _GNNGateCurrentFloorSO;

		[SerializeField]
		private IntVariableSO _GNNGateCurrentMaxFloorSO;

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
		private Color _imageColorIncomplete;

		[SerializeField]
		private Color _imageColorCompleted;

		[SerializeField]
		private Sprite _imageCompletedSprite;

		[SerializeField]
		[LocaKey]
		private string _statusLocaKeyMissing;

		[SerializeField]
		[LocaKey]
		private string _statusLocaKeyCompleted;

		private const string _gnnGateCompletedLoca = "GeneralProgression.MonumentStatusCompleted";

		private const string _gnnGateProgressLoca = "GeneralProgression.GNNGateProgress";

		private const string _gnnGateProgressNoPhaseLoca = "GeneralProgression.GNNGateProgressNoPhase";

		private string _gnnGateProgressText;

		private string _gnnGateProgressNoPhaseText;

		private void Awake()
		{
			LocalizationUtility.OnLanguageUpdate += OnLanguageUpdate;
			OnLanguageUpdate();
		}

		private void OnDestroy()
		{
			LocalizationUtility.OnLanguageUpdate -= OnLanguageUpdate;
		}

		private void OnLanguageUpdate()
		{
			_gnnGateProgressText = LocalizationUtility.GetLocalizedText("GeneralProgression.GNNGateProgress");
			_gnnGateProgressNoPhaseText = LocalizationUtility.GetLocalizedText("GeneralProgression.GNNGateProgressNoPhase");
		}

		private void OnEnable()
		{
			SetState(_GNNGateCompleted.Value);
			UpdateText();
			_GNNGateCompleted.ValueChanged += SetState;
			_GNNGateCurrentPhaseSO.ValueChanged += UpdateText;
			_GNNGateCurrentFloorSO.ValueChanged += UpdateText;
			_GNNGateCurrentMaxFloorSO.ValueChanged += UpdateText;
		}

		private void OnDisable()
		{
			_GNNGateCompleted.ValueChanged -= SetState;
			_GNNGateCurrentPhaseSO.ValueChanged -= UpdateText;
			_GNNGateCurrentFloorSO.ValueChanged -= UpdateText;
			_GNNGateCurrentMaxFloorSO.ValueChanged -= UpdateText;
		}

		private void SetState(bool value)
		{
			if (value)
			{
				SetStateCompleted();
			}
			else
			{
				SetStateDefault();
			}
		}

		private void UpdateText(int _)
		{
			UpdateText();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void UpdateText()
		{
			int value = _GNNGateCurrentPhaseSO.Value;
			int value2 = _GNNGateCurrentFloorSO.Value;
			int value3 = _GNNGateCurrentMaxFloorSO.Value;
			_statusText.gameObject.SetActive(value > 0);
			value--;
			_statusText.text = ((value > 0) ? string.Format(_gnnGateProgressText, value, value2, value3) : string.Format(_gnnGateProgressNoPhaseText, value2, value3));
		}

		private void SetTextCompleted()
		{
			_statusText.text = LocalizationUtility.GetLocalizedText("GeneralProgression.GNNGateProgress");
		}

		private void SetStateDefault()
		{
			UpdateText();
			SetStyle(isComplete: false);
		}

		private void SetStateCompleted()
		{
			SetTextCompleted();
			SetStyle(isComplete: true);
		}

		private void SetStyle(bool isComplete, bool underConstruction = false)
		{
			_monumentImage.overrideSprite = ((isComplete || underConstruction) ? _imageCompletedSprite : null);
			_monumentImage.color = (isComplete ? _imageColorCompleted : _imageColorIncomplete);
			_statusText.color = (isComplete ? _textColorCompleted : _textColorIncomplete);
			_background.color = (isComplete ? _backgroundColorCompleted : _backgroundColorIncomplete);
			_border.color = (isComplete ? _borderColorCompleted : _borderColorIncomplete);
			_statusSuccessObject.SetActive(isComplete);
		}
	}
}
