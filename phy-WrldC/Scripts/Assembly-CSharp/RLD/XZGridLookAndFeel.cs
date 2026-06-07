using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class XZGridLookAndFeel : Settings
	{
		[SerializeField]
		private Color _lineColor = RTSystemValues.GridLineColor;

		[SerializeField]
		private bool _useCellFading = true;

		public Color LineColor
		{
			get
			{
				return _lineColor;
			}
			set
			{
				_lineColor = value;
			}
		}

		public bool UseCellFading
		{
			get
			{
				return _useCellFading;
			}
			set
			{
				_useCellFading = value;
			}
		}
	}
}
