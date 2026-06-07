using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class ObjectGrabLookAndFeel : Settings
	{
		[SerializeField]
		private bool _drawAnchorLines = true;

		[SerializeField]
		private Color _anchorLineColor = Color.green;

		[SerializeField]
		private bool _drawObjectPosTicks = true;

		[SerializeField]
		private bool _drawAnchorPosTick = true;

		[SerializeField]
		private Color _objectPosTickColor = Color.white;

		[SerializeField]
		private Color _anchorPosTickColor = ColorEx.FromByteValues(byte.MaxValue, 140, 0, byte.MaxValue);

		[SerializeField]
		private float _objectPosTickSize = 10f;

		[SerializeField]
		private float _anchorPosTickSize = 10f;

		[SerializeField]
		private bool _drawObjectBoxes = true;

		[SerializeField]
		private Color _objectBoxWireColor = Color.white.KeepAllButAlpha(0.3f);

		public bool DrawAnchorLines
		{
			get
			{
				return _drawAnchorLines;
			}
			set
			{
				_drawAnchorLines = value;
			}
		}

		public Color AnchorLineColor
		{
			get
			{
				return _anchorLineColor;
			}
			set
			{
				_anchorLineColor = value;
			}
		}

		public bool DrawObjectPosTicks
		{
			get
			{
				return _drawObjectPosTicks;
			}
			set
			{
				_drawObjectPosTicks = value;
			}
		}

		public bool DrawAnchorPosTick
		{
			get
			{
				return _drawAnchorPosTick;
			}
			set
			{
				_drawAnchorPosTick = value;
			}
		}

		public Color ObjectPosTickColor
		{
			get
			{
				return _objectPosTickColor;
			}
			set
			{
				_objectPosTickColor = value;
			}
		}

		public float ObjectPosTickSize
		{
			get
			{
				return _objectPosTickSize;
			}
			set
			{
				_objectPosTickSize = Mathf.Max(2f, value);
			}
		}

		public Color AnchorPosTickColor
		{
			get
			{
				return _anchorPosTickColor;
			}
			set
			{
				_anchorPosTickColor = value;
			}
		}

		public float AnchorPosTickSize
		{
			get
			{
				return _anchorPosTickSize;
			}
			set
			{
				_anchorPosTickSize = Mathf.Max(2f, value);
			}
		}

		public bool DrawObjectBoxes
		{
			get
			{
				return _drawObjectBoxes;
			}
			set
			{
				_drawObjectBoxes = value;
			}
		}

		public Color ObjectBoxWireColor
		{
			get
			{
				return _objectBoxWireColor;
			}
			set
			{
				_objectBoxWireColor = value;
			}
		}
	}
}
