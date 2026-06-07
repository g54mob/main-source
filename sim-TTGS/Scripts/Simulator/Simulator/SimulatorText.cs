using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Simulator
{
	[RequireComponent(typeof(TextMeshProUGUI), typeof(Localize))]
	public class SimulatorText : MonoBehaviour, ITooltipDisplayer, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[Header("UI Components")]
		[SerializeField]
		private TextMeshProUGUI m_text;

		[SerializeField]
		private Localize m_localize;

		[SerializeField]
		[TermsPopup("")]
		private string m_term;

		[SerializeField]
		private bool m_hasTooltip;

		[SerializeField]
		[TermsPopup("")]
		private string m_tooltipTerm;

		private bool m_registered;

		public TextMeshProUGUI Text => m_text;

		public Localize Localize => m_localize;

		public RectTransform RectTransform
		{
			get
			{
				if (!m_text)
				{
					return null;
				}
				return m_text.rectTransform;
			}
		}

		private void OnEnable()
		{
			RegisterToLocalizationCallback(register: true);
		}

		private void OnDisable()
		{
			RegisterToLocalizationCallback(register: false);
		}

		private void RegisterToLocalizationCallback(bool register)
		{
			if (m_registered != register && !(m_localize == null))
			{
				m_registered = register;
				if (register)
				{
					m_localize.LocalizeEvent.AddListener(OnLocalize);
				}
				else
				{
					m_localize.LocalizeEvent.RemoveListener(OnLocalize);
				}
			}
		}

		public bool TryGetTooltipTerm(out string tooltipTerm)
		{
			tooltipTerm = m_tooltipTerm;
			return m_hasTooltip;
		}

		private void ApplyTerm(string term, string prefix = null, string suffix = null)
		{
			RegisterToLocalizationCallback(register: true);
			m_term = term;
			if (m_localize != null)
			{
				if (!string.IsNullOrEmpty(prefix) || !string.IsNullOrEmpty(suffix))
				{
					m_localize.SetTerm(term, prefix, suffix);
				}
				else
				{
					m_localize.SetTerm(term);
				}
			}
		}

		public virtual void SetTerm(string term)
		{
			ApplyTerm(term);
		}

		public virtual void SetTerm(string term, string prefix, string suffix)
		{
			ApplyTerm(term, prefix, suffix);
		}

		public virtual void SetTerm(string term, string tooltipTerm)
		{
			ApplyTerm(term);
			m_tooltipTerm = tooltipTerm;
		}

		public virtual void RefreshTerm()
		{
			RegisterToLocalizationCallback(register: true);
			m_localize.OnLocalize(Force: true);
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			TooltipManager.PrepareTooltip(this);
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			TooltipManager.CancelTooltip(this);
		}

		protected virtual void OnLocalize()
		{
			if (string.IsNullOrEmpty(Localize.MainTranslation))
			{
				return;
			}
			HashSet<string> hashSet = (from Match m in Regex.Matches(Localize.MainTranslation, "\\{([^{}]+)\\}")
				select m.Groups[1].Value).ToHashSet();
			if (!hashSet.IsValid())
			{
				return;
			}
			foreach (string item in hashSet)
			{
				if (LocaVariableDatabase.TryGetVariableLiteralValue(item, out var value))
				{
					Localize.MainTranslation = Localize.MainTranslation.Replace("{" + item + "}", value);
				}
			}
		}
	}
}
