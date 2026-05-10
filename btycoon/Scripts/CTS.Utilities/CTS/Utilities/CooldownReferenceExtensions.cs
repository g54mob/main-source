using System;
using CTS.Core.Utilities;
using UnityEngine;

namespace CTS.Utilities
{
	public static class CooldownReferenceExtensions
	{
		public static void StartCooldown(this CooldownManager manager, CooldownReference reference)
		{
			if ((object)reference == null)
			{
				Debug.LogException(new NullReferenceException("No reference set"));
			}
			else
			{
				manager.StartCooldown(reference.Key, reference.CooldownRange.RandomInRange(), reference.UseScaledTime);
			}
		}
	}
}
