using System;
using System.Collections.Generic;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PajamaLlama.SurvivalGuide
{
	internal class TutorialButtonWidget : BaseWidget, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		internal class Parameters : BaseParameters
		{
			public TutorialID PageID;

			public Parameters(TutorialID tutorialPageID)
			{
				PageID = tutorialPageID;
			}
		}

		[SerializeField]
		private RectTransform _imageTransform;

		[SerializeField]
		private TextMeshProUGUI _text;

		[SerializeField]
		private float _imageHoverScale = 1.1f;

		[SerializeField]
		private float _textHoverScale = 1.05f;

		private TutorialID _tutorialPageID;

		private readonly Vector3 _defaultScale = Vector3.one;

		internal override void Initialize(BaseParameters parameters)
		{
			if (!(parameters is Parameters parameters2))
			{
				Debug.LogException(new NotImplementedException("Incorrect parameters provided to TutorialButtonWidget"));
				return;
			}
			_tutorialPageID = parameters2.PageID;
			_text.text = ((GameManager.UIManager.TryGetPanel(PanelID.TutorialPanel, out var panel) && panel is TutorialPanel tutorialPanel && tutorialPanel.TryGetTutorial(_tutorialPageID, out var tutorial)) ? tutorial.Title : new LocalizedString(_tutorialPageID.ToString()));
		}

		internal override BaseParameters CreateParameters(Dictionary<string, object> parameters)
		{
			return new Parameters(_tutorialPageID);
		}

		public void OpenTutorialPage()
		{
			GameManager.UIManager.ClosePanel(PanelID.SurvivalGuide);
			TutorialEvent.Dispatch(GameEventType.TutorialPanelPopup, _tutorialPageID);
			OnPointerExit();
		}

		public void OnPointerEnter(PointerEventData eventData = null)
		{
			if (eventData == null)
			{
				base.transform.localScale = Vector3.one * _textHoverScale;
			}
			else if (eventData.pointerEnter == _imageTransform.gameObject)
			{
				_imageTransform.localScale = Vector3.one * _imageHoverScale;
			}
			else
			{
				_text.transform.localScale = Vector3.one * _textHoverScale;
			}
		}

		public void OnPointerExit(PointerEventData eventData = null)
		{
			base.transform.localScale = _defaultScale;
			_imageTransform.localScale = _defaultScale;
			_text.transform.localScale = _defaultScale;
		}
	}
}
