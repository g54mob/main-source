using System.Collections;
using CTS.Core;
using CTS.Core.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;

public class UI_ConstructionFeedback : MonoSingleton<UI_ConstructionFeedback>
{
	[SerializeField]
	private Vector3 _textPositionOffset;

	[SerializeField]
	private TMP_Text _feedbackText;

	[SerializeField]
	private LocalizedString _notEnoughtMoneyKey;

	[SerializeField]
	private LocalizedString _noMinimumSizeKey;

	[SerializeField]
	private LocalizedString _noMinimumCellCountKey;

	[SerializeField]
	private LocalizedString _tooNearKey;

	[SerializeField]
	private LocalizedString _invalideKey;

	[SerializeField]
	private LocalizedString _newBuildKey;

	[SerializeField]
	private LocalizedString _extensionKey;

	[SerializeField]
	private LocalizedString _removeKey;

	[SerializeField]
	private string _normalColorHex;

	[SerializeField]
	private string _failColorHex;

	[SerializeField]
	private RectTransform _backgroundRect;

	private Vector2 _targetTextSize;

	private Canvas _canvas;

	private Coroutine _spawnRoutine;

	protected override void OnSingletonDestroy()
	{
		ConstructionSystem.OnConstructionModeChanged -= ConstructionSystem_OnConstructionModeChanged;
	}

	protected override void SingletonAwake()
	{
		ConstructionSystem.OnConstructionModeChanged += ConstructionSystem_OnConstructionModeChanged;
		_canvas = GetComponentInParent<Canvas>();
	}

	private void Update()
	{
		_backgroundRect.transform.position = Input.mousePosition + _textPositionOffset;
		_feedbackText.transform.position = Input.mousePosition + _textPositionOffset;
		UpdateFeedback();
	}

	private void ConstructionSystem_OnConstructionModeChanged()
	{
		base.gameObject.SetActive(MonoSingleton<ConstructionSystem>.Instance.CurrentMode != EConstructionMode.None);
	}

	public void UpdateFeedback()
	{
		if (!Cursor.visible)
		{
			_backgroundRect.gameObject.SetActive(value: false);
			_feedbackText.text = "";
			return;
		}
		string text = "";
		switch (MonoSingleton<ConstructionSystem>.Instance.CursorConstructionMode)
		{
		case ECursorConstructionMode.Extension:
			text = ToColorString(_extensionKey.GetLocalizedString(), _normalColorHex);
			break;
		case ECursorConstructionMode.NewBuild:
			text = ToColorString(_newBuildKey.GetLocalizedString(), _normalColorHex);
			break;
		case ECursorConstructionMode.Remove:
			text = ToColorString(_removeKey.GetLocalizedString(), _normalColorHex);
			break;
		}
		foreach (ConstructionFeedBackResult feedback in ConstructionFeedback.FeedbackList)
		{
			if (feedback.ConstructionResult != 0)
			{
				if (feedback.ConstructionResult.HasFlagNonAlloc(EConstructionResult.NotEnoughtMoney))
				{
					text += ToColorString(_notEnoughtMoneyKey.GetLocalizedString(), _failColorHex);
				}
				if (feedback.ConstructionResult.HasFlagNonAlloc(EConstructionResult.NoMinimumSize))
				{
					text += ToColorString(_noMinimumSizeKey.GetLocalizedString() + " " + MonoSingleton<ConstructionParams>.Instance.InteriorMinimumZoneLenght + "x" + MonoSingleton<ConstructionParams>.Instance.InteriorMinimumZoneLenght, _failColorHex);
				}
				if (feedback.ConstructionResult.HasFlagNonAlloc(EConstructionResult.NoMinimumCellCount))
				{
					text += ToColorString(_noMinimumCellCountKey.GetLocalizedString() + feedback.param.ToString() + " / " + MonoSingleton<ConstructionParams>.Instance.InteriorMinimumCellCount + " m\ufffd", _failColorHex);
				}
				if (feedback.ConstructionResult.HasFlagNonAlloc(EConstructionResult.TooNear))
				{
					text += ToColorString(_tooNearKey.GetLocalizedString(), _failColorHex);
				}
				if (feedback.ConstructionResult.HasFlagNonAlloc(EConstructionResult.HaveInvalideCells))
				{
					text += ToColorString(_invalideKey.GetLocalizedString(), _failColorHex);
				}
			}
		}
		_backgroundRect.gameObject.SetActive(!string.IsNullOrWhiteSpace(text));
		if (_feedbackText.text != text)
		{
			_feedbackText.text = text;
			if (_spawnRoutine != null)
			{
				StopCoroutine(_spawnRoutine);
			}
			_spawnRoutine = StartCoroutine(Spawn());
		}
	}

	private IEnumerator Spawn()
	{
		yield return null;
		_backgroundRect.sizeDelta = RefreshSize() / _canvas.transform.localScale;
		yield return null;
		_feedbackText.color = Color.white;
		_spawnRoutine = null;
	}

	private Vector2 RefreshSize()
	{
		_targetTextSize = (string.IsNullOrWhiteSpace(_feedbackText.text) ? Vector2.zero : (_feedbackText.GetRenderedValues(onlyVisibleCharacters: true) * _canvas.transform.localScale));
		return _targetTextSize;
	}

	private string ToColorString(string text, string hexColor, bool backLine = true)
	{
		return "<color=#" + hexColor + ">" + text + "</color> " + (backLine ? "\n" : "");
	}
}
