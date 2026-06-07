using System;
using System.Collections;
using CTS.Core;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.UI;

namespace CTS.UI
{
	public class TooltipsManager : MonoSingleton<TooltipsManager>
	{
		[Flags]
		public enum EPivotPosition
		{
			Top = 2,
			Left = 4,
			Right = 8,
			Bottom = 0x10,
			Center = 0x20
		}

		[SerializeField]
		private GameObject _anchor;

		private RectTransform _anchorRect;

		private TooltipsSetText _currentTooltips;

		private Vector3 _tmpPositionValue;

		private GameObject _target;

		private Image _background;

		private Coroutine _resizeCoroutine;

		protected override void SingletonAwake()
		{
			_anchorRect = _anchor.GetComponent<RectTransform>();
			_currentTooltips = _anchor.GetComponent<TooltipsSetText>();
			_background = _anchor.GetComponent<Image>();
			LocalizationSettings.SelectedLocaleChanged += LocalizationSettings_SelectedLocaleChanged;
		}

		protected override void OnSingletonDestroy()
		{
			LocalizationSettings.SelectedLocaleChanged -= LocalizationSettings_SelectedLocaleChanged;
		}

		private void LocalizationSettings_SelectedLocaleChanged(Locale obj)
		{
			Hide();
		}

		public void Hide()
		{
			_anchor.SetActive(value: false);
		}

		public void HideIfIsTarget(GameObject p_target)
		{
			if (!(_target != p_target))
			{
				_currentTooltips.HideWhenPointerOut(hideValue: true);
				_target = null;
			}
		}

		public void Show(string p_Title, string p_Text, GameObject p_target, TooltipsShowingInfo p_tooltipsShowingInfo, string p_bottom = "")
		{
			if (!p_tooltipsShowingInfo._useDefaultSize)
			{
				Show(p_Title, p_Text, p_tooltipsShowingInfo._ToolTipPosition.position, p_tooltipsShowingInfo._pivot, p_target, p_bottom);
			}
			else
			{
				Show(p_Title, p_Text, p_tooltipsShowingInfo._ToolTipPosition.position, p_tooltipsShowingInfo._pivot, p_tooltipsShowingInfo._size, p_target, p_bottom);
			}
		}

		private void Show(string p_Title, string p_Text, Vector3 p_ToolTipPosition, EPivotPosition p_pivot, GameObject p_target, string p_bottom = "")
		{
			_target = p_target;
			_anchorRect.pivot = GetAnchor(p_pivot);
			_tmpPositionValue = p_ToolTipPosition;
			_currentTooltips.HideWhenPointerOut(hideValue: false);
			_currentTooltips.titleString = p_Title;
			_currentTooltips.textString = p_Text;
			_currentTooltips.bottomString = p_bottom;
			_anchorRect.sizeDelta = new Vector2(1000f, 1000f);
			_currentTooltips.RefreshComponenets();
			_anchor.SetActive(value: true);
			if (_resizeCoroutine != null)
			{
				StopCoroutine(_resizeCoroutine);
			}
			_resizeCoroutine = StartCoroutine(Resize());
		}

		private void Show(string p_Title, string p_Text, Vector3 p_ToolTipPosition, EPivotPosition p_pivot, Vector2 p_size, GameObject p_target, string p_bottom = "")
		{
			_target = p_target;
			_anchorRect.sizeDelta = p_size;
			_anchorRect.pivot = GetAnchor(p_pivot);
			_tmpPositionValue = p_ToolTipPosition;
			_anchor.transform.position = _tmpPositionValue;
			_currentTooltips.HideWhenPointerOut(hideValue: false);
			_currentTooltips.titleString = p_Title;
			_currentTooltips.textString = p_Text;
			_currentTooltips.bottomString = p_bottom;
			_currentTooltips.RefreshComponenets();
			_anchor.SetActive(value: true);
		}

		private Vector2 GetAnchor(EPivotPosition p_pivot)
		{
			return new Vector2(p_pivot.HasFlag(EPivotPosition.Left) ? 0f : (p_pivot.HasFlag(EPivotPosition.Right) ? 1f : 0.5f), p_pivot.HasFlag(EPivotPosition.Bottom) ? 0f : (p_pivot.HasFlag(EPivotPosition.Top) ? 1f : 0.5f));
		}

		private IEnumerator Resize()
		{
			_anchor.transform.position = Vector3.zero;
			_currentTooltips.SetVisibleText(visible: false);
			_anchorRect.sizeDelta = Vector2.zero;
			yield return null;
			_anchorRect.sizeDelta = _currentTooltips.RefreshSize();
			_currentTooltips.SetVisibleText(visible: true);
			_resizeCoroutine = null;
			_anchor.transform.position = _tmpPositionValue;
		}
	}
}
