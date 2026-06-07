using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kamgam.LocalizationForSettings.UIElements
{
	public abstract class LocalizeVisualElement : LocalizeBase
	{
		public static string LocalizationClassNamePrefix = "loc_";

		public string BindingClass;

		protected UIDocument _document;

		protected VisualElement _visualElement;

		public UIDocument Document
		{
			get
			{
				if (_document == null)
				{
					_document = base.transform.GetComponentInParent<UIDocument>();
				}
				return _document;
			}
		}

		public VisualElement VisualElement
		{
			get
			{
				if (_visualElement == null && !string.IsNullOrEmpty(BindingClass) && Document != null)
				{
					VisualElement bindingClassElement = GetBindingClassElement();
					_visualElement = getFinalElement(bindingClassElement);
					if (_visualElement != null)
					{
						_visualElement.RegisterCallback<DetachFromPanelEvent>(detachFromPanel);
					}
					else
					{
						Debug.LogWarning("No element with binding class '" + BindingClass + "' found.");
					}
				}
				return _visualElement;
			}
		}

		public static bool HasLocalizationClass(VisualElement element)
		{
			return GetLocalizationClassName(element) != null;
		}

		public static string GetLocalizationClassName(VisualElement element)
		{
			foreach (string @class in element.GetClasses())
			{
				if (@class.StartsWith(LocalizationClassNamePrefix))
				{
					return @class;
				}
			}
			return null;
		}

		public abstract Type GetElementType();

		public VisualElement GetBindingClassElement()
		{
			return Document.rootVisualElement.Q(null, BindingClass);
		}

		protected virtual void detachFromPanel(DetachFromPanelEvent evt)
		{
			resetUIElements();
			if (this != null && base.isActiveAndEnabled)
			{
				StartCoroutine(RefreshDelayedAsync());
			}
		}

		protected virtual IEnumerator RefreshDelayedAsync()
		{
			yield return null;
			Localize();
		}

		protected virtual VisualElement getFinalElement(VisualElement ele)
		{
			if (ele == null)
			{
				return null;
			}
			Type elementType = GetElementType();
			if (ele.GetType() == elementType)
			{
				return ele;
			}
			foreach (VisualElement item in ele.Query<VisualElement>().Build())
			{
				if (item.GetType() == elementType)
				{
					return item;
				}
			}
			return ele;
		}

		public virtual void BindTo(VisualElement element)
		{
			_document = null;
			_visualElement = null;
			if (element == null)
			{
				BindingClass = null;
				return;
			}
			element.GetClasses();
			BindingClass = GetLocalizationClassName(element);
			if (BindingClass != null)
			{
				Term = GetText();
			}
		}

		public virtual void Unbind()
		{
			resetUIElements();
			BindingClass = null;
		}

		public override void OnDisable()
		{
			resetUIElements();
			base.OnDisable();
		}

		protected virtual void resetUIElements()
		{
			_document = null;
			if (_visualElement != null)
			{
				_visualElement.UnregisterCallback<DetachFromPanelEvent>(detachFromPanel);
			}
			_visualElement = null;
		}

		public void OnDestroy()
		{
			Unbind();
		}
	}
}
