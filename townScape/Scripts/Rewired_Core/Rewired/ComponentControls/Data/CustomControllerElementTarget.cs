using System;
using UnityEngine;

namespace Rewired.ComponentControls.Data
{
	[Serializable]
	[CustomClassObfuscation]
	public class CustomControllerElementTarget
	{
		[CustomObfuscation]
		internal enum ValueRange
		{
			[CustomObfuscation]
			Full = 0,
			[CustomObfuscation]
			Positive = 1,
			[CustomObfuscation]
			Negative = 2
		}

		[CustomObfuscation]
		[SerializeField]
		private CustomControllerElementSelector _element;

		[SerializeField]
		[CustomObfuscation]
		private ValueRange _valueRange;

		[CustomObfuscation]
		[SerializeField]
		private Pole _valueContribution;

		[SerializeField]
		[CustomObfuscation]
		private bool _invert;

		public CustomControllerElementSelector element => null;

		public Pole valueContribution
		{
			get
			{
				return default(Pole);
			}
			set
			{
			}
		}

		internal ValueRange valueRange
		{
			get
			{
				return default(ValueRange);
			}
			set
			{
			}
		}

		public bool invert
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		internal CustomControllerElementTarget()
		{
		}

		internal CustomControllerElementTarget(CustomControllerElementSelector selector)
		{
		}

		internal void ClearElementCaches()
		{
		}
	}
}
