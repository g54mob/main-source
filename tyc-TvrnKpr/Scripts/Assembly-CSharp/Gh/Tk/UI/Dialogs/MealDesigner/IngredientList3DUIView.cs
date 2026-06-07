using System.Collections.Generic;
using Gh.UI;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.MealDesigner
{
	public class IngredientList3DUIView : MonoBehaviour
	{
		[SerializeField]
		private GameObject _ingredientOptionPrefab;

		[SerializeField]
		private GameObject _noIngredientsAvailablePrefab;

		[SerializeField]
		private Container3DUIView _listContainer;

		[SerializeField]
		private Button3DUIView _sortByNameButton;

		[SerializeField]
		private Button3DUIView _sortByStarButton;

		[SerializeField]
		private Button3DUIView _sortByAmountButton;

		protected string _currentSorting;

		protected bool _ascending;

		private readonly List<GameObject> _ingredientOptions;

		private IngredientSlot3DUIView _slot;

		[SerializeField]
		private ScrollableUIView _scrollView;

		[SerializeField]
		private Animator _animator;

		public void SetSlot(IngredientSlot3DUIView slot)
		{
		}

		private void UpdateContent()
		{
		}

		public void Clear()
		{
		}

		private void Awake()
		{
		}

		private void SetSorting(string sortBy)
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}
	}
}
