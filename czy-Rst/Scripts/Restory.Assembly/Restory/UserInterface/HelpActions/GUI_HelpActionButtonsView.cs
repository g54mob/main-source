using System.Collections.Generic;
using Restory.Data.GUIControllerElements;
using Restory.ObjectPools;
using Restory.UserInterface.HelpActions.Sorters;
using Restory.UserInterface.HelpActions.Validators;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.HelpActions
{
	public sealed class GUI_HelpActionButtonsView : MonoBehaviour, IHelpActionButtonsView
	{
		private static class Style
		{
			public const string Validator = "Validator";

			public const string Sorter = "Sorter";
		}

		[SerializeField]
		private GUI_BaseHelpActionButtonValidatorSO overrideValidatorSO;

		[SerializeField]
		private GUI_BaseHelpActionButtonValidatorMonoBehaviour overrideValidatorMono;

		[SerializeField]
		private GUI_BaseHelpActionButtonSorterSO overrideSorterSO;

		[SerializeField]
		private GUI_BaseHelpActionButtonSorterMonoBehaviour overrideSorterMono;

		[SerializeField]
		private GUI_HelpActionButtonView prefabActionButtonView;

		[SerializeField]
		private GuiControllerTemplateList controllerTemplateList;

		[SerializeField]
		private RectTransform container;

		private IHelpActionButtonValidator validator;

		private IHelpActionButtonSorter sorter;

		private readonly GUI_DefaultHelpActionButtonValidator defaultValidator = new GUI_DefaultHelpActionButtonValidator();

		private readonly Dictionary<HelpAction, GUI_HelpActionButtonView> views = new Dictionary<HelpAction, GUI_HelpActionButtonView>();

		private readonly List<HelpAction> buttons = new List<HelpAction>();

		private readonly Queue<GUI_HelpActionButtonView> pool = new Queue<GUI_HelpActionButtonView>();

		private HelpActionButtonsService helpActionButtonsService;

		private GlobalObjectPool objectPool;

		public IReadOnlyList<HelpAction> Buttons => buttons;

		public IHelpActionButtonValidator Validator
		{
			get
			{
				return validator;
			}
			set
			{
				validator = value ?? defaultValidator;
			}
		}

		public IHelpActionButtonSorter Sorter
		{
			get
			{
				return sorter;
			}
			set
			{
				sorter = value;
			}
		}

		[Inject]
		private void Construct(HelpActionButtonsService helpActionButtonsService, GlobalObjectPool objectPool)
		{
			this.helpActionButtonsService = helpActionButtonsService;
			this.objectPool = objectPool;
			if (base.isActiveAndEnabled)
			{
				helpActionButtonsService.AddButtonsView(this);
			}
		}

		private void Awake()
		{
			IHelpActionButtonValidator helpActionButtonValidator2;
			if (!(overrideValidatorSO == null))
			{
				IHelpActionButtonValidator helpActionButtonValidator = overrideValidatorSO;
				helpActionButtonValidator2 = helpActionButtonValidator;
			}
			else
			{
				IHelpActionButtonValidator helpActionButtonValidator = overrideValidatorMono;
				helpActionButtonValidator2 = helpActionButtonValidator;
			}
			Validator = helpActionButtonValidator2;
			IHelpActionButtonSorter helpActionButtonSorter2;
			if (!(overrideSorterSO == null))
			{
				IHelpActionButtonSorter helpActionButtonSorter = overrideSorterSO;
				helpActionButtonSorter2 = helpActionButtonSorter;
			}
			else
			{
				IHelpActionButtonSorter helpActionButtonSorter = overrideSorterMono;
				helpActionButtonSorter2 = helpActionButtonSorter;
			}
			Sorter = helpActionButtonSorter2;
		}

		private void OnEnable()
		{
			if (helpActionButtonsService != null)
			{
				helpActionButtonsService.AddButtonsView(this);
			}
		}

		private void OnDisable()
		{
			if (helpActionButtonsService != null)
			{
				helpActionButtonsService.RemoveButtonsView(this);
			}
		}

		public void AddButtons(GameObject parent, IReadOnlyList<HelpAction> actionButtons)
		{
			foreach (HelpAction actionButton in actionButtons)
			{
				private_AddButton(parent, actionButton);
			}
			Sort();
		}

		public bool AddButton(GameObject parent, HelpAction actionButton)
		{
			if (!private_AddButton(parent, actionButton))
			{
				return false;
			}
			Sort();
			return true;
		}

		private bool private_AddButton(GameObject parent, HelpAction actionButton)
		{
			if (!validator.ValidateButton(this, parent, actionButton))
			{
				return false;
			}
			buttons.Add(actionButton);
			GUI_HelpActionButtonView newHelpActionButtonView = GetNewHelpActionButtonView();
			newHelpActionButtonView.SetControllerTemplateList(controllerTemplateList);
			newHelpActionButtonView.SetHelpActionButton(actionButton);
			views.Add(actionButton, newHelpActionButtonView);
			return true;
		}

		public void RemoveButtons(IReadOnlyList<HelpAction> actionButtons)
		{
			foreach (HelpAction actionButton in actionButtons)
			{
				RemoveButton(actionButton);
			}
		}

		public bool RemoveButton(HelpAction actionButton)
		{
			if (!views.TryGetValue(actionButton, out var value))
			{
				return false;
			}
			buttons.Remove(actionButton);
			views.Remove(actionButton);
			ClearHelpActionButtonView(value);
			return true;
		}

		public bool ContainsButton(HelpAction actionButton)
		{
			return views.ContainsKey(actionButton);
		}

		public void ClearButtons()
		{
			foreach (GUI_HelpActionButtonView value in views.Values)
			{
				ClearHelpActionButtonView(value);
			}
			buttons.Clear();
			views.Clear();
		}

		private void Sort()
		{
			if (sorter != null)
			{
				sorter.Sort(this, buttons);
				for (int i = 0; i < buttons.Count; i++)
				{
					views[buttons[i]].transform.SetSiblingIndex(i);
				}
			}
		}

		private GUI_HelpActionButtonView GetNewHelpActionButtonView()
		{
			if (pool.Count > 0)
			{
				GUI_HelpActionButtonView gUI_HelpActionButtonView = pool.Dequeue();
				gUI_HelpActionButtonView.gameObject.SetActive(value: true);
				gUI_HelpActionButtonView.transform.SetAsFirstSibling();
				return gUI_HelpActionButtonView;
			}
			return objectPool.GetObject<GUI_HelpActionButtonView>(prefabActionButtonView.gameObject, container);
		}

		private void ClearHelpActionButtonView(GUI_HelpActionButtonView view)
		{
			view.gameObject.SetActive(value: false);
			pool.Enqueue(view);
		}
	}
}
