using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using NSEipix.Base;
using NSEipix.Model;
using UnityEngine;

namespace NSMedieval.UI
{
	public class TooltipStyles : MonoSingleton<TooltipStyles>
	{
		[SerializeField]
		private List<Pair<JobPriorities>> jobPriorityStyles;

		public static string TooltipDefault => "TooltipDefault";

		public static string TooltipTitle => "TooltipTitle";

		public static string DefaultRed => "DefaultRed";

		public static string DefaultOrange => "DefaultOrange";

		public static string TooltipAttribute => "TooltipAttribute";

		public static string TooltipDescriptionLine => "TooltipDescriptionLine";

		public static string TooltipSubtitleLineStyle => "TooltipSubtitleLineStyle";

		public static string TooltipSign => "TooltipSign";

		public static string DefaultGrey => "DefaultGrey";

		public static string DefaultGreen => "DefaultGreen";

		public static string BulletPoint => "BulletPoint";

		public static string TooltipSpriteAsset => "TooltipSpriteAsset";

		public string GetStyleForPriority(JobPriorities priority)
		{
			return jobPriorityStyles.FirstOrDefault((Pair<JobPriorities> item) => item.Value == priority)?.GetID();
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public static string ApplyStyle(string line, string style)
		{
			return "<style=\"" + style + "\">" + line + "</style>";
		}
	}
}
