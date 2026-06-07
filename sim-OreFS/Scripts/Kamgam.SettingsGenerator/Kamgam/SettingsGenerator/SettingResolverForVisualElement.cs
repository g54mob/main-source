using System.Collections;
using System.Text.RegularExpressions;
using UnityEngine.UIElements;

namespace Kamgam.SettingsGenerator
{
	public abstract class SettingResolverForVisualElement : SettingResolver, ISettingResolver
	{
		public static string SettingsClassNamePrefix = "set_";

		public static string SettingsClassNameSeparator = "__";

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
					_visualElement = Document.rootVisualElement.Q(null, BindingClass);
					if (_visualElement != null)
					{
						_visualElement.RegisterCallback<DetachFromPanelEvent>(detachFromPanel);
					}
					else
					{
						Logger.LogWarning("No element with binding class '" + BindingClass + "' found.");
					}
				}
				return _visualElement;
			}
			set
			{
				_visualElement = value;
				if (value == null)
				{
					BindingClass = null;
				}
			}
		}

		public static bool HasSettingClass(VisualElement element)
		{
			return GetSettingClassName(element) != null;
		}

		public static string GetSettingClassName(VisualElement element)
		{
			foreach (string @class in element.GetClasses())
			{
				if (@class.StartsWith(SettingsClassNamePrefix))
				{
					return @class;
				}
			}
			return null;
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
			Refresh();
		}

		public void BindTo(VisualElement element)
		{
			_document = null;
			_visualElement = null;
			if (element == null)
			{
				BindingClass = null;
				return;
			}
			foreach (string @class in element.GetClasses())
			{
				if (@class.StartsWith(SettingsClassNamePrefix))
				{
					string[] array = Regex.Split(@class, SettingsClassNameSeparator);
					if (array.Length != 0)
					{
						ID = array[0].Substring(SettingsClassNamePrefix.Length);
					}
					BindingClass = @class;
					break;
				}
			}
		}

		public void Unbind()
		{
			resetUIElements();
			BindingClass = null;
		}

		public override void OnDisable()
		{
			resetUIElements();
			StopAllCoroutines();
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

		public override void OnDestroy()
		{
			Unbind();
			StopAllCoroutines();
			base.OnDestroy();
		}
	}
}
