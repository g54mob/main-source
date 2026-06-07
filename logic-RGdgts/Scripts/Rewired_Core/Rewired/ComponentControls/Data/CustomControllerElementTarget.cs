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

		[CustomObfuscation]
		[SerializeField]
		private ValueRange _valueRange;

		[SerializeField]
		[CustomObfuscation]
		private Pole _valueContribution;

		[CustomObfuscation]
		[SerializeField]
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

		internal CustomControllerElementTarget(CustomControllerElementSelector P_0)
		{
		}

		internal void ClearElementCaches()
		{
		}
	}
}
