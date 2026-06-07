using System;
using System.Collections.Generic;
using Kamgam.LocalizationForSettings;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kamgam.SettingsGenerator
{
	public class UIDocumentSettingsResolver : MonoBehaviour
	{
		public delegate SettingResolverForVisualElement CreateResolverDelegate(UIDocumentSettingsResolver documentResolver, VisualElement element, List<string> uniqueClassNames);

		public SettingsProvider SettingsProvider;

		public LocalizationProvider LocalizationProvider;

		[NonSerialized]
		public CreateResolverDelegate CustomCreateResolverMethod;

		protected UIDocument _document;

		public UIDocument Document
		{
			get
			{
				if (_document == null)
				{
					_document = GetComponentInParent<UIDocument>();
				}
				return _document;
			}
		}

		public void CreateOrUpdateResolvers()
		{
			Logger.Log("Creating resolver on UIDocument.");
			if (Document == null)
			{
				Logger.LogError("No UIDocument found: There is no UIDocument Component on the selected object -> aborting.");
				return;
			}
			SettingResolverForVisualElement[] componentsInChildren = Document.transform.GetComponentsInChildren<SettingResolverForVisualElement>();
			for (int num = componentsInChildren.Length - 1; num >= 0; num--)
			{
				UnityEngine.Object.Destroy(componentsInChildren[num].gameObject);
			}
			int num2 = 0;
			List<string> uniqueClassNames = new List<string>();
			num2 += createOrUpdateResolvers<Toggle, ToggleUIElementResolver>(uniqueClassNames);
			num2 += createOrUpdateResolvers<DropdownField, DropdownFieldUIElementResolver>(uniqueClassNames);
			num2 += createOrUpdateResolvers<Slider, SliderUIElementResolver>(uniqueClassNames);
			num2 += createOrUpdateResolvers<TextField, TextFieldUIElementResolver>(uniqueClassNames);
			if (CustomCreateResolverMethod != null)
			{
				num2 += createOrUpdateCustomResolvers(uniqueClassNames);
			}
			Logger.LogMessage("Created " + num2 + " resolvers on UIDocument.");
			if (num2 == 0)
			{
				Logger.LogWarning("Please add a class name starting with '" + SettingResolverForVisualElement.SettingsClassNamePrefix + "' to each element that you wish to mark as a setting.\nDon't forget to assign Settings IDs to the resolvers afterwards.");
			}
		}

		public static UIDocumentSettingsResolver GetOrCreateResolversRoot(GameObject gameObjectWithUIDocument)
		{
			UIDocument component = gameObjectWithUIDocument.GetComponent<UIDocument>();
			if (component == null)
			{
				return null;
			}
			string n = "SettingResolvers";
			Transform transform = gameObjectWithUIDocument.transform.Find(n);
			if (transform == null)
			{
				GameObject obj = new GameObject(n);
				obj.transform.SetParent(component.gameObject.transform);
				obj.transform.rotation = Quaternion.identity;
				obj.transform.localPosition = Vector3.zero;
				transform = obj.transform;
			}
			UIDocumentSettingsResolver uIDocumentSettingsResolver = transform.GetComponentInChildren<UIDocumentSettingsResolver>();
			if (uIDocumentSettingsResolver == null)
			{
				uIDocumentSettingsResolver = transform.gameObject.AddComponent<UIDocumentSettingsResolver>();
			}
			return uIDocumentSettingsResolver;
		}

		private int createOrUpdateResolvers<TVisualElement, TResolver>(List<string> uniqueClassNames) where TVisualElement : VisualElement where TResolver : SettingResolverForVisualElement
		{
			if (Document == null || Document.rootVisualElement == null)
			{
				Logger.LogWarning("No root for document found. Maybe it's disabled or you are in PrefabMode?");
				return 0;
			}
			UQueryState<TVisualElement> uQueryState = Document.rootVisualElement.Query<TVisualElement>().Build();
			int num = 0;
			foreach (TVisualElement item in uQueryState)
			{
				if (SettingResolverForVisualElement.HasSettingClass(item))
				{
					string settingClassName = SettingResolverForVisualElement.GetSettingClassName(item);
					if (uniqueClassNames.Contains(settingClassName))
					{
						Logger.LogError("The class name '" + settingClassName + "' on '" + item.name + "' has already been used. Skipping '" + item.name + "'.");
					}
					else
					{
						uniqueClassNames.Add(settingClassName);
						CreateGameObjectWithResolver<TVisualElement, TResolver>(item);
						num++;
					}
				}
			}
			return num;
		}

		private int createOrUpdateCustomResolvers(List<string> uniqueClassNames)
		{
			if (CustomCreateResolverMethod == null)
			{
				return 0;
			}
			UQueryState<VisualElement> uQueryState = Document.rootVisualElement.Query<VisualElement>().Build();
			int num = 0;
			foreach (VisualElement item in uQueryState)
			{
				if (CustomCreateResolverMethod(this, item, uniqueClassNames) != null)
				{
					num++;
				}
			}
			return num;
		}

		public TResolver CreateGameObjectWithResolver<TVisualElement, TResolver>(TVisualElement element) where TVisualElement : VisualElement where TResolver : SettingResolverForVisualElement
		{
			GameObject obj = new GameObject(typeof(TResolver).Name + " (" + SettingResolverForVisualElement.GetSettingClassName(element) + ")");
			obj.transform.SetParent(base.transform);
			obj.transform.rotation = Quaternion.identity;
			obj.transform.localPosition = Vector3.zero;
			TResolver val = obj.AddComponent<TResolver>();
			val.BindTo(element);
			if (SettingsProvider != null)
			{
				val.SettingsProvider = SettingsProvider;
			}
			if (LocalizationProvider != null)
			{
				val.LocalizationProvider = LocalizationProvider;
			}
			return val;
		}
	}
}
