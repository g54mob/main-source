using System.Collections.Generic;
using Restory.Data.GUIControllerElements;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.HelpActions
{
	public class GUI_HelpActionButtonView : MonoBehaviour
	{
		private static class Style
		{
			public const string Data = "Data";

			public const string Gui = "GUI";
		}

		private class ElementComponents
		{
			public GUI_HelpActionElementView View;

			public IInitializable[] Initializables;
		}

		[SerializeField]
		private HelpAction helpActionButton;

		[SerializeField]
		private GuiControllerTemplateList controllerTemplateList;

		[SerializeField]
		private RectTransform elementViewsContainer;

		[SerializeField]
		private GUI_HelpActionElementView elementViewPrefab;

		[SerializeField]
		private GUI_LocalisedText localisedText;

		private readonly List<ElementComponents> activeElements = new List<ElementComponents>();

		private readonly Stack<ElementComponents> elementsPool = new Stack<ElementComponents>();

		private DiContainer diContainer;

		private bool isDirty = true;

		public HelpAction HelpActionButton
		{
			get
			{
				return helpActionButton;
			}
			set
			{
				SetHelpActionButton(value);
			}
		}

		public GuiControllerTemplateList ControllerTemplateList
		{
			get
			{
				return controllerTemplateList;
			}
			set
			{
				SetControllerTemplateList(value);
			}
		}

		[Inject]
		private void Construct(DiContainer diContainer)
		{
			this.diContainer = diContainer;
			if (base.isActiveAndEnabled)
			{
				SetDirty();
			}
		}

		private void Editor_OnControllerTemplateListChanged()
		{
			SetControllerTemplateList(controllerTemplateList);
		}

		private void Awake()
		{
			if (elementViewPrefab.transform.IsChildOf(base.transform))
			{
				elementViewPrefab.gameObject.SetActive(value: false);
			}
		}

		private void OnEnable()
		{
			if (helpActionButton != null)
			{
				SetDirty();
			}
		}

		private void LateUpdate()
		{
			if (isDirty)
			{
				isDirty = false;
				UpdateView();
			}
		}

		public void SetHelpActionButton(HelpAction helpActionButton)
		{
			this.helpActionButton = helpActionButton;
			if (base.isActiveAndEnabled)
			{
				SetDirty();
			}
		}

		public void SetControllerTemplateList(GuiControllerTemplateList controllerTemplateList)
		{
			this.controllerTemplateList = controllerTemplateList;
			foreach (ElementComponents activeElement in activeElements)
			{
				activeElement.View.SetСontrollerTemplateList(controllerTemplateList);
			}
		}

		private void SetLocalizationNameKey(string localizationNameKey)
		{
			if (localisedText != null)
			{
				localisedText.LocalizationID = localizationNameKey;
			}
		}

		private void SetDirty()
		{
			isDirty = true;
		}

		private void UpdateView()
		{
			if (helpActionButton.Button != null)
			{
				CreateElementViews(helpActionButton.Elements);
				SetLocalizationNameKey(helpActionButton.LocalizationNameKey);
			}
			else
			{
				ClearElementViews();
				SetLocalizationNameKey(string.Empty);
			}
		}

		private void CreateElementViews(IReadOnlyList<HelpActionElement> elements)
		{
			ClearElementViews();
			if (diContainer == null)
			{
				return;
			}
			foreach (HelpActionElement element in elements)
			{
				ElementComponents viewComponents = GetViewComponents();
				activeElements.Add(viewComponents);
				IInitializable[] initializables = viewComponents.Initializables;
				for (int i = 0; i < initializables.Length; i++)
				{
					initializables[i]?.Initialize();
				}
				GUI_HelpActionElementView view = viewComponents.View;
				view.SetHelpActionElement(element);
				view.SetСontrollerTemplateList(controllerTemplateList);
				view.gameObject.SetActive(value: true);
			}
			for (int j = 0; j < activeElements.Count; j++)
			{
				activeElements[j].View.transform.SetSiblingIndex(j);
			}
		}

		private ElementComponents GetViewComponents()
		{
			if (!elementsPool.TryPop(out var result))
			{
				return CreateElementComponents();
			}
			return result;
		}

		private void ClearElementViews()
		{
			foreach (ElementComponents activeElement in activeElements)
			{
				activeElement.View.gameObject.SetActive(value: false);
				activeElement.View.SetHelpActionElement(null);
				elementsPool.Push(activeElement);
			}
			activeElements.Clear();
		}

		private ElementComponents CreateElementComponents()
		{
			GameObject gameObject = diContainer.InstantiatePrefab(elementViewPrefab.gameObject, elementViewsContainer);
			return new ElementComponents
			{
				View = gameObject.GetComponent<GUI_HelpActionElementView>(),
				Initializables = gameObject.GetComponentsInChildren<IInitializable>()
			};
		}
	}
}
