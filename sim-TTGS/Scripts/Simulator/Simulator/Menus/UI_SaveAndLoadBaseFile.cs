using System;
using System.Globalization;
using System.IO;
using System.Text;
using DG.Tweening;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Simulator.Menus
{
	public class UI_SaveAndLoadBaseFile : NavBox
	{
		[Header("UI Components")]
		[SerializeField]
		private NavButton m_button;

		[SerializeField]
		private Image m_image;

		[SerializeField]
		private CanvasGroup m_normal;

		[SerializeField]
		private CanvasGroup m_hover;

		private RectTransform m_rectTransform;

		[Header("Text components")]
		[SerializeField]
		private TMP_Text[] m_nameTextComponents;

		[SerializeField]
		private TMP_Text m_infosTextComponent;

		[SerializeField]
		private TMP_Text m_dateDayTextComponent;

		[SerializeField]
		private TMP_Text m_dateTimeTextComponent;

		[SerializeField]
		private TMP_Text m_inGameTimeTextComponent;

		[SerializeField]
		private TMP_Text m_shopLevelTextComponent;

		[SerializeField]
		private TMP_Text m_moneyTextComponent;

		[Header("Localization")]
		[SerializeField]
		private EnumValues<ESaveType, string> m_saveType;

		[SerializeField]
		private Localize m_shopLevel;

		[SerializeField]
		private Localize m_inGameTime;

		private Sequence m_sequence;

		public SaveFileInfo Info { get; private set; }

		public Image Image => m_image;

		private static bool IsRenaming { get; set; }

		public event Action<FileInfo> OnClick;

		protected override void Awake()
		{
			base.Awake();
			m_rectTransform = GetComponent<RectTransform>();
		}

		protected override void Start()
		{
			base.Start();
			m_rectTransform.sizeDelta = new Vector2(m_rectTransform.sizeDelta.x, MenuSettings.SaveFileUnHoverHeight);
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			m_button.Button.onClick.AddListener(OnButtonClick);
			SelectElementEvent = (Action<RectTransform>)Delegate.Combine(SelectElementEvent, new Action<RectTransform>(OnSelectButton));
			DeselectElementEvent = (Action)Delegate.Combine(DeselectElementEvent, new Action(OnDeselectButton));
		}

		protected override void OnDisable()
		{
			m_sequence.Kill();
			base.OnDisable();
			m_button.Button.onClick.RemoveListener(OnButtonClick);
			SelectElementEvent = (Action<RectTransform>)Delegate.Remove(SelectElementEvent, new Action<RectTransform>(OnSelectButton));
			DeselectElementEvent = (Action)Delegate.Remove(DeselectElementEvent, new Action(OnDeselectButton));
		}

		public void SetInfo(SaveFileInfo saveFileInfo)
		{
			Info = saveFileInfo;
			UpdateContent();
		}

		private void UpdateContent()
		{
			string termTranslation = LocalizationManager.GetTermTranslation(m_saveType[Info.saveType], FixForRTL: false);
			TMP_Text[] nameTextComponents = m_nameTextComponents;
			for (int i = 0; i < nameTextComponents.Length; i++)
			{
				nameTextComponents[i].text = termTranslation;
			}
			DateTime lastWriteTime = Info.fileInfo.LastWriteTime;
			string text = lastWriteTime.ToShortDateString();
			string text2 = lastWriteTime.ToShortTimeString();
			string text3 = Info.shopLevel.ToString();
			string text4 = Info.moneyAmount.ToString(CultureInfo.InvariantCulture) + "$";
			string inGameTime = Info.inGameTime;
			m_dateDayTextComponent.text = text;
			m_dateTimeTextComponent.text = text2;
			m_shopLevel.TermSuffix = ": " + text3;
			m_shopLevel.OnLocalize(Force: true);
			m_inGameTime.TermSuffix = ": " + inGameTime;
			m_inGameTime.OnLocalize(Force: true);
			m_moneyTextComponent.text = text4;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(text);
			stringBuilder.Append(" - ");
			stringBuilder.Append(text2);
			stringBuilder.Append(" / ");
			stringBuilder.Append(m_shopLevel.GetMainTargetsText());
			stringBuilder.Append(" / ");
			stringBuilder.Append(text4);
			stringBuilder.Append(" / ");
			stringBuilder.Append(m_inGameTime.GetMainTargetsText());
			m_infosTextComponent.text = stringBuilder.ToString();
		}

		private void OnButtonClick()
		{
			this.OnClick?.Invoke(Info.fileInfo);
		}

		private void OnSelectButton(RectTransform _)
		{
			PlayTweenToHoverState();
		}

		protected virtual void OnDeselectButton()
		{
			PlayTweenToUnHoverState();
		}

		public override void OnPointerEnter(PointerEventData eventData)
		{
			base.OnPointerEnter(eventData);
			PlayTweenToHoverState();
		}

		public override void OnPointerExit(PointerEventData eventData)
		{
			base.OnPointerExit(eventData);
			PlayTweenToUnHoverState();
		}

		private void PlayTweenToXState(float height, bool isHover)
		{
			m_sequence.Kill(complete: true);
			m_sequence = DOTween.Sequence();
			m_sequence.SetUpdate(isIndependentUpdate: true);
			float saveFileHoverTweenDuration = MenuSettings.SaveFileHoverTweenDuration;
			m_sequence.Append(m_rectTransform.DOSizeDelta(new Vector2(m_rectTransform.sizeDelta.x, height), saveFileHoverTweenDuration));
			CanvasGroup from = (isHover ? m_normal : m_hover);
			CanvasGroup to = (isHover ? m_hover : m_normal);
			m_sequence.OnPlay(delegate
			{
				from.interactable = false;
				from.blocksRaycasts = false;
			});
			m_sequence.Join(from.DOFade(0f, saveFileHoverTweenDuration));
			m_sequence.Join(to.DOFade(1f, saveFileHoverTweenDuration));
			m_sequence.OnComplete(delegate
			{
				to.interactable = true;
				to.blocksRaycasts = true;
			});
			m_sequence.Play();
		}

		private void PlayTweenToUnHoverState()
		{
			PlayTweenToXState(MenuSettings.SaveFileUnHoverHeight, isHover: false);
		}

		private void PlayTweenToHoverState()
		{
			PlayTweenToXState(MenuSettings.SaveFileHoverHeight, isHover: true);
		}
	}
}
