using System;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Packages.DevConsole
{
	[Serializable]
	public class LogEntryColors
	{
		[SerializeField]
		private Color _errorColor;

		[SerializeField]
		private Color _errorColorHighlight;

		private ColorBlock _errorColors;

		[SerializeField]
		private Color _messageColor;

		[SerializeField]
		private Color _messageColorHighlight;

		private ColorBlock _messageColors;

		[SerializeField]
		private Color _warningColor;

		[SerializeField]
		private Color _warningColorHighlight;

		private ColorBlock _warningColors;

		public Color ErrorColor
		{
			get
			{
				return _errorColor;
			}
			set
			{
				_errorColor = value;
			}
		}

		public Color ErrorColorHighlight
		{
			get
			{
				return _errorColorHighlight;
			}
			set
			{
				_errorColorHighlight = value;
			}
		}

		public Color MessageColor
		{
			get
			{
				return _messageColor;
			}
			set
			{
				_messageColor = value;
			}
		}

		public Color MessageColorHighlight
		{
			get
			{
				return _messageColorHighlight;
			}
			set
			{
				_messageColorHighlight = value;
			}
		}

		public Color WarningColor
		{
			get
			{
				return _warningColor;
			}
			set
			{
				_warningColor = value;
			}
		}

		public Color WarningColorHighlight
		{
			get
			{
				return _warningColorHighlight;
			}
			set
			{
				_warningColorHighlight = value;
			}
		}

		internal ColorBlock ErrorColors
		{
			get
			{
				return _errorColors;
			}
			set
			{
				_errorColors = value;
			}
		}

		internal ColorBlock MessageColors
		{
			get
			{
				return _messageColors;
			}
			set
			{
				_messageColors = value;
			}
		}

		internal ColorBlock WarningColors
		{
			get
			{
				return _warningColors;
			}
			set
			{
				_warningColors = value;
			}
		}

		internal void Initialize()
		{
			MessageColors = new ColorBlock
			{
				normalColor = MessageColor,
				highlightedColor = MessageColorHighlight,
				pressedColor = MessageColorHighlight,
				colorMultiplier = 1f,
				fadeDuration = 0.1f
			};
			WarningColors = new ColorBlock
			{
				normalColor = WarningColor,
				highlightedColor = WarningColorHighlight,
				pressedColor = WarningColorHighlight,
				colorMultiplier = 1f,
				fadeDuration = 0.1f
			};
			ErrorColors = new ColorBlock
			{
				normalColor = ErrorColor,
				highlightedColor = ErrorColorHighlight,
				pressedColor = ErrorColorHighlight,
				colorMultiplier = 1f,
				fadeDuration = 0.1f
			};
		}
	}
}
