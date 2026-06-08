using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using Dorfromantik;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class TooltipTarget : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Serializable]
	protected class ReplacementInfo
	{
		public string stringToReplace;

		public InformationType replacement;
	}

	protected enum InformationType
	{
		questValues = 0,
		elementGroup_elementCount = 3,
		tile_fittingEdges = 4,
		tileStack_count = 5
	}

	public enum TooltipLevel
	{
		Detailed = 0,
		Basic = 1,
		None = 2
	}

	private sealed class _003CHoveringOverTooltipTarget_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public TooltipTarget _003C_003E4__this;

		private float _003Ctimer_003E5__2;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CHoveringOverTooltipTarget_003Ed__18(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			TooltipTarget tooltipTarget = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003Ctimer_003E5__2 = 0f;
				break;
			case 1:
				_003C_003E1__state = -1;
				_003Ctimer_003E5__2 += Time.deltaTime;
				if (!tooltipTarget.hovering)
				{
					return false;
				}
				break;
			}
			if (_003Ctimer_003E5__2 <= tooltipTarget.hoverDuration)
			{
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			tooltipTarget.UpdateText();
			if (!string.IsNullOrWhiteSpace(tooltipTarget.descriptionText.text))
			{
				tooltipTarget.appearTween = TweenSettingsExtensions.From(ShortcutExtensions.DOScale(tooltipTarget.tooltip.transform, Vector3.one, 0.2f), Vector3.zero);
			}
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private string tooltipKey;

	[SerializeField]
	private float hoverDuration;

	[SerializeField]
	private TooltipLevel tooltipLevel;

	[SerializeField]
	protected ReplacementInfo replacementInfo;

	[SerializeField]
	private bool appendInputMapping;

	[SerializeField]
	private InputActionReference inputAction;

	[SerializeField]
	private string controlScheme = "Keyboard";

	private UIManagerTooltip tooltip;

	private TextMeshProUGUI descriptionText;

	private TooltipManager tooltipManager;

	private Animator tooltipAnimator;

	private bool hovering;

	private Tween appearTween;

	private bool tooltipActive;

	protected virtual void Start()
	{
		if (!(Singleton<MainMenuUi>.Instance == null))
		{
			tooltipManager = Singleton<MainMenuUi>.Instance.TooltipManager;
			tooltip = tooltipManager.tooltip;
			descriptionText = tooltipManager.GetComponentInChildren<TextMeshProUGUI>();
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		if (Singleton<InputManager>.Instance.CurrentInputDevice == Dorfromantik.InputDevice.MouseKeyboard && tooltip != null && Singleton<MainMenuUi>.Instance.SettingsRouter.TooltipLevel <= (int)tooltipLevel)
		{
			tooltipManager.allowUpdating = true;
			tooltipManager.UpdateTooltipPos();
			hovering = true;
			StartCoroutine(HoveringOverTooltipTarget());
		}
	}

	private void UpdateText()
	{
		descriptionText.font = LocalizationManager.Instance.GetFont(LocalizedFontStyle.SemiBold);
		descriptionText.horizontalAlignment = ((!LocalizationManager.Instance.IsCurrentLanguageRightToLeft) ? HorizontalAlignmentOptions.Left : HorizontalAlignmentOptions.Right);
		string text = GetTooltipText();
		if (text.Length > 50)
		{
			string[] array = text.Split(' ');
			string text2 = array[0];
			int num = text2.Length;
			for (int i = 1; i < array.Length; i++)
			{
				if (num + array[i].Length > 50)
				{
					text2 += "\n";
					num = 0;
				}
				text2 = text2 + " " + array[i];
				num += array[i].Length + 1;
			}
			text = text2;
		}
		if (appendInputMapping)
		{
			string bindingString = KeyBindingUtility.GetBindingString(inputAction.action, InputBinding.MaskByGroup(Singleton<InputManager>.Instance.CurrentControlScheme));
			string richTextAttributeForBinding = KeyBindingUtility.GetRichTextAttributeForBinding(bindingString);
			text = text + " [" + (string.IsNullOrEmpty(richTextAttributeForBinding) ? bindingString : richTextAttributeForBinding) + "]";
		}
		descriptionText.text = text;
	}

	protected virtual string GetTooltipText()
	{
		if (string.IsNullOrWhiteSpace(tooltipKey))
		{
			return "";
		}
		string text = LocalizationManager.Instance.GetLocalizedValue(tooltipKey, useFallbackText: true);
		if (!string.IsNullOrWhiteSpace(replacementInfo.stringToReplace))
		{
			int num = -1;
			if (replacementInfo.replacement == InformationType.tileStack_count)
			{
				TileStack componentInParent = GetComponentInParent<TileStack>();
				if ((bool)componentInParent)
				{
					num = (componentInParent.IsInfinite ? int.MaxValue : componentInParent.RawHeight);
				}
			}
			if (num >= 0)
			{
				text = text.Replace(replacementInfo.stringToReplace, (num == int.MaxValue) ? "∞" : num.ToString());
				text = LocalizationManager.Instance.ApplySpecificLanguageNumberingGrammar(text, num);
			}
		}
		return text;
	}

	private IEnumerator HoveringOverTooltipTarget()
	{
		return new _003CHoveringOverTooltipTarget_003Ed__18(0)
		{
			_003C_003E4__this = this
		};
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		if (tooltip != null && hovering)
		{
			hovering = false;
			Tween tween = appearTween;
			if (tween != null)
			{
				TweenExtensions.Kill(tween);
			}
			ShortcutExtensions.DOScale(tooltip.transform, Vector3.zero, 0.1f);
			tooltipManager.allowUpdating = false;
		}
	}

	private void OnDisable()
	{
		OnPointerExit(null);
	}
}
