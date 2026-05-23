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
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CustomControllerElementSelector _element;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ValueRange _valueRange;

		[Tooltip("Should the final value be positive or negative?")]
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private Pole _valueContribution;

		[Tooltip("Should the final value be inverted?")]
		[SerializeField]
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

		internal CustomControllerElementTarget(CustomControllerElementSelector P_0)
		{
		}

		internal void ClearElementCaches()
		{
		}
	}
}
