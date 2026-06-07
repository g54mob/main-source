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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("The Custom Controller element.")]
		private CustomControllerElementSelector _element = new CustomControllerElementSelector
		{
			elementType = CustomControllerElementSelector.ElementType.Axis
		};

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ValueRange _valueRange;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		[Tooltip("Should the final value be positive or negative?")]
		private Pole _valueContribution;

		[Tooltip("Should the final value be inverted?")]
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _invert;

		public CustomControllerElementSelector element
		{
			get
			{
				return _element;
			}
		}

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
				goto IL_0008;
			}
			goto IL_0032;
			IL_0008:
			int num = -500645916;
			goto IL_000d;
			IL_000d:
			switch (num ^ -500645915)
			{
			case 3:
				break;
			default:
				return;
			case 1:
				return;
			case 2:
				goto IL_0032;
			case 0:
				return;
			}
			goto IL_0008;
			IL_0032:
			_element.ClearCache();
			num = -500645915;
			goto IL_000d;
		}
	}
}
