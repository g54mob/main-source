using System;
using System.Runtime.CompilerServices;

namespace VampireSurvivors.UI
{
	public static class PreloaderEvents
	{
		public static event Action<string> UpdateText
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action<string> UpdateExtraText
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static void FireUpdateText(string text)
		{
		}

		public static void FireUpdateExtraText(string text)
		{
		}
	}
}
