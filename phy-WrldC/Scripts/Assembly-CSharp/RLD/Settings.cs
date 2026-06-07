using System;
using UnityEngine;

namespace RLD
{
	[Serializable]
	public abstract class Settings
	{
		[SerializeField]
		private bool _canBeDisplayed = true;

		[SerializeField]
		protected bool _isExpanded = true;

		private string _foldoutLabel = "Settings";

		public bool CanBeDisplayed
		{
			get
			{
				return _canBeDisplayed;
			}
			set
			{
				_canBeDisplayed = value;
			}
		}

		public bool UsesFoldout { get; set; }

		public string FoldoutLabel
		{
			get
			{
				return _foldoutLabel;
			}
			set
			{
				if (value != null)
				{
					_foldoutLabel = value;
				}
			}
		}

		public bool IsExpanded
		{
			get
			{
				return _isExpanded;
			}
			set
			{
				_isExpanded = value;
			}
		}
	}
}
