using System;
using System.Collections.Generic;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public class EditorToolbarTab
	{
		[SerializeField]
		private string _tooltip = "";

		[SerializeField]
		private string _text = "";

		[NonSerialized]
		private EditorToolbar _targetToolbar;

		[NonSerialized]
		private List<Settings> _targetSettings = new List<Settings>();

		public string Tooltip
		{
			get
			{
				return _tooltip;
			}
			set
			{
				if (value != null)
				{
					_tooltip = value;
				}
			}
		}

		public string Text
		{
			get
			{
				return _text;
			}
			set
			{
				if (value != null)
				{
					_text = value;
				}
			}
		}

		public EditorToolbar TargetToolbar
		{
			get
			{
				return _targetToolbar;
			}
			set
			{
				if (value != null)
				{
					_targetToolbar = value;
				}
			}
		}

		public int NumTargetSettings => _targetSettings.Count;

		public EditorToolbarTab(string text, string tooltip)
		{
			Text = text;
			Tooltip = tooltip;
		}

		public void AddTargetSettings(Settings targetSettings)
		{
			if (!_targetSettings.Contains(targetSettings))
			{
				_targetSettings.Add(targetSettings);
			}
		}
	}
}
