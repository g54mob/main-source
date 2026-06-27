using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	[ExecuteInEditMode]
	[RequireComponent(typeof(RectTransform))]
	public abstract class GUI_BaseNavigation : UIBehaviour, IDisposable
	{
		protected static List<GUI_BaseNavigation> allNavigations = new List<GUI_BaseNavigation>();

		[SerializeField]
		private GUI_BaseNavigationValidatorSO overrideValidator;

		[SerializeField]
		private GUI_BaseNavigationValidatorMonoBehaviour overrideValidatorMono;

		[SerializeField]
		private GUI_BaseNavigationFinderSO overrideFinder;

		[SerializeField]
		private GUI_BaseNavigationFinderMonoBehaviour overrideFinderMono;

		protected RectTransform rectTransform;

		protected INavigationValidator validator;

		protected INavigationFinder finder;

		protected GUI_DefaultNavigationValidator defaultValidator = new GUI_DefaultNavigationValidator();

		protected GUI_DefaultNavigationFinder defaultFinder = new GUI_DefaultNavigationFinder();

		public static IReadOnlyList<GUI_BaseNavigation> AllNavigations => allNavigations;

		public RectTransform RectTransform
		{
			get
			{
				if (!(rectTransform != null))
				{
					return rectTransform = base.transform as RectTransform;
				}
				return rectTransform;
			}
		}

		public INavigationValidator Validator
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

		public INavigationFinder Finder
		{
			get
			{
				return finder;
			}
			set
			{
				finder = value ?? defaultFinder;
			}
		}

		[Inject]
		private void Construct(DisposableManager disposableManager)
		{
			disposableManager.Add(this);
		}

		protected override void Awake()
		{
			base.Awake();
			InitializeNonSerializedFields();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			allNavigations.Add(this);
		}

		protected override void OnDisable()
		{
			base.OnDisable();
			allNavigations.Remove(this);
		}

		private void InitializeNonSerializedFields()
		{
			rectTransform = base.transform as RectTransform;
			INavigationValidator navigationValidator2;
			if (!(overrideValidator == null))
			{
				INavigationValidator navigationValidator = overrideValidator;
				navigationValidator2 = navigationValidator;
			}
			else
			{
				INavigationValidator navigationValidator = overrideValidatorMono;
				navigationValidator2 = navigationValidator;
			}
			Validator = navigationValidator2;
			INavigationFinder navigationFinder2;
			if (!(overrideFinder == null))
			{
				INavigationFinder navigationFinder = overrideFinder;
				navigationFinder2 = navigationFinder;
			}
			else
			{
				INavigationFinder navigationFinder = overrideFinderMono;
				navigationFinder2 = navigationFinder;
			}
			Finder = navigationFinder2;
		}

		public abstract bool IsInteractable();

		protected void Navigate(AxisEventData eventData, GUI_BaseNavigation sel)
		{
			if (sel != null && sel.isActiveAndEnabled)
			{
				eventData.selectedObject = sel.gameObject;
			}
		}

		public abstract GUI_BaseNavigation GetSelectableOnLeft();

		public abstract GUI_BaseNavigation GetSelectableOnRight();

		public abstract GUI_BaseNavigation GetSelectableOnUp();

		public abstract GUI_BaseNavigation GetSelectableOnDown();

		public void Select()
		{
			if (!(EventSystem.current == null) && !EventSystem.current.alreadySelecting)
			{
				EventSystem.current.SetSelectedGameObject(base.gameObject);
			}
		}

		public virtual void Dispose()
		{
			validator = null;
			finder = null;
		}
	}
}
