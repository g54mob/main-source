using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class PrefabPreviewLookAndFeel : Settings
	{
		private static readonly float _minBkAlpha = 0.004f;

		[SerializeField]
		private Color _bkColor = new Color(0.32156864f, 0.32156864f, 0.32156864f, 0.2588f);

		[SerializeField]
		private int _previewWidth = 90;

		[SerializeField]
		private int _previewHeight = 90;

		[SerializeField]
		private float _lightIntensity = 1f;

		public Color BkColor
		{
			get
			{
				return _bkColor;
			}
			set
			{
				_bkColor = value;
				_bkColor.a = Mathf.Max(_minBkAlpha, _bkColor.a);
			}
		}

		public int PreviewWidth
		{
			get
			{
				return _previewWidth;
			}
			set
			{
				_previewWidth = Mathf.Max(4, value);
			}
		}

		public int PreviewHeight
		{
			get
			{
				return _previewHeight;
			}
			set
			{
				_previewHeight = Mathf.Max(4, value);
			}
		}

		public float LightIntensity
		{
			get
			{
				return _lightIntensity;
			}
			set
			{
				_lightIntensity = Mathf.Max(0.0001f, value);
			}
		}
	}
}
