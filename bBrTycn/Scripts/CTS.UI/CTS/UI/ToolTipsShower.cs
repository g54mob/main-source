using CTS.Core;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Localization;

namespace CTS.UI
{
	public class ToolTipsShower : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[SerializeField]
		public bool _useTextLocalisation = true;

		[SerializeField]
		[ShowIf("HasTarget")]
		private bool _hideOnDisable;

		private string _fixedText;

		private string _fixedTitle;

		public string InsertedText;

		private bool _onPointer;

		[field: SerializeField]
		public LocalizedString Title { get; private set; }

		[field: SerializeField]
		public LocalizedString Text { get; private set; }

		[field: SerializeField]
		public GameObject Target { get; private set; }

		[field: SerializeField]
		public TooltipsShowingInfo TooltipsShowing { get; private set; }

		public bool HasTarget()
		{
			return Target;
		}

		private void OnDisable()
		{
			if (_hideOnDisable && (bool)Target && MonoSingleton<TooltipsManager>.InstanceExists())
			{
				MonoSingleton<TooltipsManager>.Instance.HideIfIsTarget(Target);
			}
		}

		private void OnDestroy()
		{
			if ((bool)Target && MonoSingleton<TooltipsManager>.InstanceExists())
			{
				MonoSingleton<TooltipsManager>.Instance.HideIfIsTarget(Target);
			}
		}

		public void SetTootipsInfoStaticString(string title, string text = null, GameObject p_target = null)
		{
			_fixedTitle = title;
			_fixedText = text;
			Target = p_target;
			if (_onPointer)
			{
				MonoSingleton<TooltipsManager>.Instance.Show(_fixedTitle, InsertedText + _fixedText, Target, TooltipsShowing);
			}
		}

		public void SetTootipsInfo(LocalizedString localizedTitle, LocalizedString localizedText = null, GameObject p_target = null)
		{
			Title = localizedTitle;
			Text = localizedText;
			Target = p_target;
			if (_onPointer)
			{
				MonoSingleton<TooltipsManager>.Instance.Show(Title.GetLocalizedStringSafe(), InsertedText + ((Text != null) ? Text.GetLocalizedStringSafe() : ""), Target, TooltipsShowing);
			}
		}

		public void SetTootipsInfo(LocalizedString localizedTitle, string text, GameObject p_target = null)
		{
			Title = localizedTitle;
			_fixedText = text;
			Target = p_target;
			if (_onPointer)
			{
				MonoSingleton<TooltipsManager>.Instance.Show(Title.GetLocalizedStringSafe(), InsertedText + _fixedText, Target, TooltipsShowing);
			}
		}

		public void SetTootipsInfo(LocalizedString localizedTitle, LocalizedString localizedText, TooltipsShowingInfo p_tooltipsShowingInfo, GameObject p_target = null)
		{
			Title = localizedTitle;
			Text = localizedText;
			TooltipsShowing = p_tooltipsShowingInfo;
			Target = p_target;
			if (_onPointer)
			{
				MonoSingleton<TooltipsManager>.Instance.Show(Title.GetLocalizedStringSafe(), InsertedText + (_useTextLocalisation ? Text.GetLocalizedString() : _fixedText), Target, TooltipsShowing);
			}
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			if (Target != null)
			{
				MonoSingleton<TooltipsManager>.Instance.HideIfIsTarget(Target);
			}
			else
			{
				MonoSingleton<TooltipsManager>.Instance.Hide();
			}
			_onPointer = false;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_onPointer = true;
			if (Title != null)
			{
				MonoSingleton<TooltipsManager>.Instance.Show(Title.GetLocalizedStringSafe(), InsertedText + (_useTextLocalisation ? Text.GetLocalizedStringSafe() : _fixedText), Target, TooltipsShowing);
			}
		}
	}
}
