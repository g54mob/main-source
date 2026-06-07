using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Kamgam.LocalizationForSettings.UIElements
{
	public class UIDocumentLocalizations : MonoBehaviour
	{
		public static int ParentLevelsToSearch = 3;

		public LocalizationProvider LocalizationProvider;

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

		public void CreateOrUpdateLocalizers()
		{
			Debug.Log("Creating localizations on UIDocument.");
			if (Document == null)
			{
				Debug.LogError("No UIDocument found: There is no UIDocument Component on the selected object -> aborting.");
				return;
			}
			LocalizeBase[] componentsInChildren = Document.transform.GetComponentsInChildren<LocalizeBase>();
			for (int num = componentsInChildren.Length - 1; num >= 0; num--)
			{
				Object.Destroy(componentsInChildren[num].gameObject);
			}
			int num2 = 0;
			List<string> uniqueClassNames = new List<string>();
			num2 += createOrUpdateLocalizer<Label, LocalizeLabel>(uniqueClassNames);
			Debug.Log("Created " + num2 + " localizer on UIDocument.");
			if (num2 == 0)
			{
				Debug.LogWarning("Please add a class name starting with '" + LocalizeVisualElement.LocalizationClassNamePrefix + "' to each element (or parent) that you wish to mark as localizable.\nDon't forget to assign a TERM to the localizer afterwards.");
			}
		}

		public static UIDocumentLocalizations GetOrCreateLocalizationsRoot(GameObject gameObjectWithUIDocument)
		{
			UIDocument component = gameObjectWithUIDocument.GetComponent<UIDocument>();
			if (component == null)
			{
				return null;
			}
			string n = "Localizations";
			Transform transform = gameObjectWithUIDocument.transform.Find(n);
			if (transform == null)
			{
				GameObject obj = new GameObject(n);
				obj.transform.SetParent(component.gameObject.transform);
				obj.transform.rotation = Quaternion.identity;
				obj.transform.localPosition = Vector3.zero;
				transform = obj.transform;
			}
			UIDocumentLocalizations uIDocumentLocalizations = transform.GetComponentInChildren<UIDocumentLocalizations>();
			if (uIDocumentLocalizations == null)
			{
				uIDocumentLocalizations = transform.gameObject.AddComponent<UIDocumentLocalizations>();
			}
			return uIDocumentLocalizations;
		}

		private int createOrUpdateLocalizer<TVisualElement, TLocalizer>(List<string> uniqueClassNames) where TVisualElement : VisualElement where TLocalizer : LocalizeVisualElement
		{
			UQueryState<VisualElement> uQueryState = Document.rootVisualElement.Query<VisualElement>().Build();
			int num = 0;
			foreach (VisualElement item in uQueryState)
			{
				if (LocalizeVisualElement.HasLocalizationClass(item))
				{
					string localizationClassName = LocalizeVisualElement.GetLocalizationClassName(item);
					if (uniqueClassNames.Contains(localizationClassName))
					{
						Debug.LogError("The class name '" + localizationClassName + "' on '" + item.name + "' has already been used. Skipping '" + item.name + "'.");
					}
					else
					{
						uniqueClassNames.Add(localizationClassName);
						CreateGameObjectWithLocalizer<TVisualElement, TLocalizer>(item);
						num++;
					}
				}
			}
			return num;
		}

		public TLocalizer CreateGameObjectWithLocalizer<TVisualElement, TLocalizer>(VisualElement element) where TVisualElement : VisualElement where TLocalizer : LocalizeVisualElement
		{
			GameObject obj = new GameObject(typeof(TLocalizer).Name + " (" + LocalizeVisualElement.GetLocalizationClassName(element) + ")");
			obj.transform.SetParent(base.transform);
			obj.transform.rotation = Quaternion.identity;
			obj.transform.localPosition = Vector3.zero;
			TLocalizer val = obj.AddComponent<TLocalizer>();
			val.BindTo(element);
			if (LocalizationProvider != null)
			{
				val.LocalizationProvider = LocalizationProvider;
			}
			return val;
		}
	}
}
