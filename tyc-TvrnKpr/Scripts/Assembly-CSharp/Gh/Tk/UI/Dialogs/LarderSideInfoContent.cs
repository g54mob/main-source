using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Gh.Tk.UI.Dialogs
{
	public class LarderSideInfoContent : MonoBehaviour
	{
		[SerializeField]
		protected Container3DUIView _containerView;

		[SerializeField]
		private GameObject _ingredientUIElementPrefab;

		[SerializeField]
		private GameObject _craftableUIElementPrefab;

		[SerializeField]
		protected Button3DUIView _sortingMethodButton;

		[SerializeField]
		private GameObject _sortingMethodNameIcon;

		[SerializeField]
		private GameObject _sortingMethodStarsIcon;

		[SerializeField]
		private GameObject _sortingMethodAmountIcon;

		[SerializeField]
		protected Button3DUIView _foodButton;

		[SerializeField]
		protected Button3DUIView _drinksButton;

		[SerializeField]
		protected Button3DUIView _ingredientsButton;

		[SerializeField]
		protected Button3DUIView _othersButton;

		[SerializeField]
		protected Container3DUIView _categoryContainer;

		private Dictionary<string, GameItemUIElement> _gameItemUIElements;

		protected string _currentSorting;

		protected bool _ascending;

		protected string _currentCategory;

		private ScrollRect _scrollRect;

		public event EventHandler LayoutUpdated
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected virtual void Awake()
		{
		}

		protected void InitSortingButton()
		{
		}

		protected void OnPreLoadEvent(object sender, EventArgs e)
		{
		}

		protected virtual void ClearUIElements()
		{
		}

		private void OnStockChanged(object sender, GameItemTemplateEventArgs e)
		{
		}

		protected void OnLayoutUpdated(object sender, EventArgs e)
		{
		}

		protected void Start()
		{
		}

		protected void SetCategory(string category)
		{
		}

		protected void SetSorting(string sortBy, bool ascending)
		{
		}

		protected void UpdateSortingIcon()
		{
		}

		public virtual void UpdateInfo()
		{
		}

		private void OnEnable()
		{
		}

		protected void UpdateButtonStates()
		{
		}

		protected virtual bool IsOthersKnown()
		{
			return false;
		}

		protected virtual bool IsIngredientKnown()
		{
			return false;
		}

		protected virtual bool IsFoodKnown()
		{
			return false;
		}

		public void ScrollTo(float scrollPosition, float duration = 0f, Action callback = null)
		{
		}
	}
}
