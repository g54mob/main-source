using UnityEngine;

namespace MG_BlocksEngine2.Environment
{
	public class BE2_Canvas : MonoBehaviour
	{
		private Canvas _canvas;

		public Canvas Canvas
		{
			get
			{
				if (!_canvas)
				{
					_canvas = GetComponent<Canvas>();
				}
				return _canvas;
			}
		}
	}
}
