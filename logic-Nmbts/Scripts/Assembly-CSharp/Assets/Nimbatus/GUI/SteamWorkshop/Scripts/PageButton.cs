using UnityEngine;

namespace Assets.Nimbatus.GUI.SteamWorkshop.Scripts
{
	public class PageButton : MonoBehaviour
	{
		public UILabel Label;

		public bool IgnoreLabel;

		private PageControl _pageControl;

		private uint _pageNumber;

		public Color NormalColor;

		public Color HoverColor;

		public Color SelectedColor;

		private bool _hover;

		public void Init(PageControl control, uint pageNumber)
		{
			_pageNumber = pageNumber;
			_pageControl = control;
			if (!IgnoreLabel)
			{
				Label.text = pageNumber.ToString();
			}
		}

		public void OnClick()
		{
			_pageControl.SetPage(_pageNumber);
		}

		public void Update()
		{
			if (_pageControl.CurrentPage == _pageNumber && !IgnoreLabel)
			{
				Label.color = SelectedColor;
			}
			else
			{
				Label.color = (_hover ? HoverColor : NormalColor);
			}
		}

		public void OnHover(bool isOver)
		{
			_hover = isOver;
		}
	}
}
