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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		[Tooltip("The Custom Controller element.")]
		private CustomControllerElementSelector _element;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ValueRange _valueRange;

		[CustomObfuscation(rename = false)]
		[Tooltip("Should the final value be positive or negative?")]
		[SerializeField]
		private Pole _valueContribution;

		[SerializeField]
		[Tooltip("Should the final value be inverted?")]
		[CustomObfuscation(rename = false)]
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
