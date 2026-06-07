using System.Collections.Generic;
using UI.Elements;
using UnityEngine;
using UnityEngine.UI;

namespace UI.SpriteEditor
{
	public class UIFont : MonoBehaviour
	{
		[SerializeField]
		private UIText fontBox;

		[SerializeField]
		private Image noFontImage;

		[SerializeField]
		private UIImage frame;

		private List<char> fontList;

		private string currentFont;

		public void Init()
		{
		}

		public void SetFontList(string fonts)
		{
		}

		public void ShowFont(int position)
		{
		}

		public void ClearBox()
		{
		}

		public void SetFont(int position)
		{
		}
	}
}
