using UnityEngine;
using UnityEngine.UI;

namespace VampireSurvivors.UI
{
	public class CenterGridLayoutGroup : MonoBehaviour
	{
		[SerializeField]
		private bool _ForceXPosition;

		[SerializeField]
		private float _XPosition;

		[SerializeField]
		private bool _ForceYPosition;

		[SerializeField]
		private float _YPosition;

		[SerializeField]
		private float _MaxWidth;

		private GridLayoutGroup _grid;

		private LayoutElement _layout;

		private RectTransform _rTrans;

		private void Awake()
		{
		}

		private void Update()
		{
		}

		public void Refresh()
		{
		}

		public void SetMaxWidth(float width)
		{
		}
	}
}
