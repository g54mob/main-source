using System;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class StatsLayout : MonoBehaviour
	{
		public Action onResize;

		private VerticalLayoutGroup _verticalLayout;

		private RectTransform _rect;

		[SerializeField]
		private float _paddingTop = 60f;

		[SerializeField]
		private float _paddingBottom = 80f;

		[SerializeField]
		private RectTransform _rectToResize;

		private void Awake()
		{
			if (_rect == null)
			{
				_rect = GetComponent<RectTransform>();
			}
			if (_verticalLayout == null)
			{
				_verticalLayout = GetComponent<VerticalLayoutGroup>();
			}
		}

		public void SetSizeFromChildCount()
		{
			if (_rect == null)
			{
				_rect = GetComponent<RectTransform>();
			}
			if (_verticalLayout == null)
			{
				_verticalLayout = GetComponent<VerticalLayoutGroup>();
			}
			float num = 0f;
			bool flag = false;
			num += _paddingTop;
			for (int i = 0; i < _rect.childCount; i++)
			{
				if (_rect.GetChild(i).gameObject.activeSelf)
				{
					if (flag)
					{
						num += _verticalLayout.spacing;
					}
					num += _rect.GetChild(i).GetComponent<RectTransform>().sizeDelta.y;
					flag = true;
				}
			}
			num += _paddingBottom;
			_rectToResize.sizeDelta = new Vector2(_rectToResize.sizeDelta.x, num);
			onResize?.Invoke();
		}
	}
}
