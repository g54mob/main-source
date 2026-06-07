using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Nimbatus.GUI.Common.Scripts
{
	public class SegmentedUiBar : MonoBehaviour
	{
		public UISprite SegmentSprite;

		public float DividerWidth = 5f;

		public Color SegmentActiveColor;

		public Color SegmentInactiveColor;

		private int _maxSegments;

		private List<UISprite> _segments = new List<UISprite>();

		private bool _initialized;

		private int _maxWidth;

		public void Init(int maxSegments, int active)
		{
			if (_initialized)
			{
				_segments.Where((UISprite s) => s != SegmentSprite).ToList().ForEach(delegate(UISprite s)
				{
					Object.Destroy(s.gameObject);
				});
				SegmentSprite.width = _maxWidth;
				_segments.Clear();
			}
			_maxWidth = SegmentSprite.width;
			_maxSegments = maxSegments;
			float num = ((float)_maxWidth - (float)(_maxSegments - 1) * DividerWidth) / (float)_maxSegments;
			SegmentSprite.width = (int)num;
			_segments.Add(SegmentSprite);
			for (int num2 = 1; num2 < _maxSegments; num2++)
			{
				UISprite uISprite = Object.Instantiate(SegmentSprite, base.transform);
				uISprite.transform.localPosition = _segments[num2 - 1].transform.localPosition + new Vector3(num + DividerWidth, 0f, 0f);
				_segments.Add(uISprite);
			}
			_initialized = true;
			UpdateSegments(active);
		}

		public void UpdateSegments(int active)
		{
			for (int i = 0; i < _maxSegments; i++)
			{
				if (i < active)
				{
					_segments[i].color = SegmentActiveColor;
				}
				else
				{
					_segments[i].color = SegmentInactiveColor;
				}
			}
		}
	}
}
