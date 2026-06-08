using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class CustomControllerElementTarget
	{
		[CustomObfuscation(rename = false)]
		internal enum ValueRange
		{
			[CustomObfuscation(rename = false)]
			Full = 0,
			[CustomObfuscation(rename = false)]
			Positive = 1,
			[CustomObfuscation(rename = false)]
			Negative = 2
		}

		[Tooltip("The Custom Controller element.")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CustomControllerElementSelector _element = new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Axis
		};

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueRange _valueRange;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should the final value be positive or negative?")]
		[SerializeField]
		private Pole _valueContribution;

		[Tooltip("Should the final value be inverted?")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _invert;

		public CustomControllerElementSelector element => _element;

		public Pole valueContribution
		{
			get
			{
				return _valueContribution;
			}
			set
			{
				_valueContribution = value;
			}
		}

		internal ValueRange valueRange
		{
			get
			{
				return _valueRange;
			}
			set
			{
				_valueRange = value;
			}
		}

		public bool invert
		{
			get
			{
				return _invert;
			}
			set
			{
				_invert = value;
			}
		}

		internal CustomControllerElementTarget()
		{
		}

		internal CustomControllerElementTarget(CustomControllerElementSelector selector)
		{
			_element = selector;
		}

		internal void ClearElementCaches()
		{
			if (_element == null)
			{
				while (true)
				{
					switch (-657676307 ^ -657676305)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			_element.ClearCache();
		}
	}
}
