using UnityEngine;
using UnityEngine.UI;

namespace Presentation.FactoryFloor.Toolbar
{
	public class CategoryLayoutView : MonoBehaviour
	{
		[SerializeField]
		private Image _icon;

		public void Setup(Sprite categoryIcon)
		{
			_icon.sprite = categoryIcon;
		}

		public void RearrangeIcon()
		{
			_icon.rectTransform.SetAsLastSibling();
		}
	}
}
