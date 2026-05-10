using System;
using System.Collections.Generic;
using UnityEngine;
using __Project__.Scripts.Data;
using __Project__.Scripts.WallPaintSystem;

namespace __Project__.Scripts.Managers
{
	public class CategorySignManager : NoktaSingleton<CategorySignManager>
	{
		private List<CategorySign> m_CategorySigns;

		private List<CategorySignData> m_CategorySignDatas;

		private CategorySign m_CurrentCategorySign;

		public List<ColorData> categorySignBackgroundColorDataList;

		public List<ColorData> categorySignTextColorDataList;

		public Action onCategorySignPlaced;

		[Header("Sounds")]
		[SerializeField]
		private AudioSource m_NameChangedSound;

		public List<CategorySignData> Data
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public CategorySign CurrentCategorySign
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		private void Awake()
		{
		}

		private void LoadSaveProgress()
		{
		}

		private void SetupCategorySigns()
		{
		}

		private void LoadCategorySigns()
		{
		}

		public void AddCategorySign(CategorySign categorySign)
		{
		}

		public void RemoveCategorySign(CategorySign categorySign)
		{
		}

		public void ChangeSignName(string signName, bool isFinalChoice, CategorySign sign)
		{
		}

		public void AutoTextSize(string signName, CategorySign sign)
		{
		}

		internal void ChangeIcon(Vector2Int index, bool isFinalChoice, CategorySign sign)
		{
		}

		public void ChangeSignTextColor(int index, CategorySign sign)
		{
		}

		public void ChangeSignTextColor(int index, bool isFinalized, CategorySign sign)
		{
		}

		public void ChangeSignBackgroundColor(int index, CategorySign sign)
		{
		}

		public void ChangeSignBackgroundColor(int index, bool isFinalized, CategorySign sign)
		{
		}

		public Material GetCurrentMaterial(bool isBackground)
		{
			return null;
		}

		private void SwitchBackgroundMaterialData(MeshRenderer categorySignRenderer, Material material, int materialIndex)
		{
		}

		public ColorData GetColorDataFromList(int colorIndex, bool isBackground)
		{
			return default(ColorData);
		}

		public void PlayShopNameSound()
		{
		}

		public void NetworkCategorySignEditedBroadcast(int displayViewId, CategorySign sign)
		{
		}

		public void NetworkCategorySignEdited(CategorySignData categorySignData, int displayViewId)
		{
		}

		public void NetworkCategorySignLoad(CategorySign categorySign)
		{
		}

		public void NetworkChangeSignName(string signName, CategorySign changedCategorySign)
		{
		}

		public void NetworkChangeSignTextColor(int index, CategorySign changedCategorySign)
		{
		}

		public void NetworkChangeSignBackgroundColor(int index, CategorySign changedCategorySign)
		{
		}

		internal void NetworkChangeIcon(Vector2Int index, CategorySign changedCategorySign)
		{
		}

		public void SwitchCategorySignBackgroundColor(CategorySign categorySign)
		{
		}
	}
}
