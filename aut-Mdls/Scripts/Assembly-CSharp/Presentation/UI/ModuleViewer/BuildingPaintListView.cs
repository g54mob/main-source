using UnityEngine;
using UnityEngine.UI;

namespace Presentation.UI.ModuleViewer
{
	public class BuildingPaintListView : MonoBehaviour
	{
		[SerializeField]
		private Image _paintIcon;

		public void Show(Color color)
		{
			_paintIcon.color = color;
		}
	}
}
