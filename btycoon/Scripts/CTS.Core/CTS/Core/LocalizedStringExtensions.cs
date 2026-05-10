using System;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS.Core
{
	public static class LocalizedStringExtensions
	{
		public static string GetLocalizedStringSafe(this LocalizedString localizedString)
		{
			try
			{
				return localizedString.GetLocalizedString();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			return "LOCALIZATION STRING INVALID";
		}
	}
}
