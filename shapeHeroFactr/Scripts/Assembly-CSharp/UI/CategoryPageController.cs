using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace UI
{
	public class CategoryPageController : MonoBehaviour
	{
		[Serializable]
		private struct Category
		{
			public CategoryButton categoryButton;

			public GameObject content;
		}

		[Header("初期化時にアクティブにするカテゴリの番号")]
		[SerializeField]
		private int defaultActive;

		[Header("カテゴリボタンとコンテンツ")]
		[SerializeField]
		private List<Category> categoryButtons;

		private int selectedNumber;

		private bool isInitialized;

		public int SelectedNumber => 0;

		public event Action<int> OnSelectCategory
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

		public void Awake()
		{
		}

		public void Init()
		{
		}

		public void SelectCategory(int num)
		{
		}

		public void SelectCategoryClick(int num)
		{
		}

		private void UpdateCategoryButtons()
		{
		}

		public void OpenDefaultPage()
		{
		}
	}
}
