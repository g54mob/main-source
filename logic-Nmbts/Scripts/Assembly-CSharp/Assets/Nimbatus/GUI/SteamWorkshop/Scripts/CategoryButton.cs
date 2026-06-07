using Assets.Nimbatus.Scripts.Common.Helpers;
using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class CategoryButton : MonoBehaviour
	{
		public UILabel Title;

		public UITexture Background;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		private DroneBrowserManager _manager;

		private EWorkshopCategory _category;

		private bool _hover;

		public void Init(DroneBrowserManager manager, EWorkshopCategory category)
		{
			_category = category;
			_manager = manager;
			Title.text = category.ToLocalizationString();
		}

		public void OnClick()
		{
			_manager.TriggerQuery(_category);
		}

		public void Update()
		{
			if (_manager.SelectedCategory == _category)
			{
				Background.color = (_hover ? HoverColor : SelectedColor);
			}
			else
			{
				Background.color = (_hover ? HoverColor : NormalColor);
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
