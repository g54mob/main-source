using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using UnityEngine;

namespace Assets.Scripts.Menu.Shop.Rank;

public static class Ranks
{
	public const int maxRank = 240;

	public const int numRankTiers = 6;

	public const int numRanksPerTier = 40;

	public unsafe static void GetRankTextures(int rank, out Texture frame, out Texture rankIcon, out Color rankColor, out Color frameColor)
	{
		//IL_00ba: Expected O, but got F4
		//IL_010b: Expected Ref, but got F4
		int num;
		if (rank >= 241)
		{
			num = 240;
		}
		else
		{
			bool flag = rank >= 0;
			num = rank;
			if (!flag)
			{
				num = 0;
			}
		}
		IconManager instance = IconManager.Instance;
		Texture[] rankIcons = instance.rankIcons;
		int num2 = num % rankIcons.Length;
		ref Texture reference = ref *(Texture*)rankIcons[num2];
		IconManager instance2 = IconManager.Instance;
		ref Texture reference2 = ref *(Texture*)instance2.rankFrameIcon;
		Color rankColor2 = MyColorUtility.GetRankColor(num);
		object obj = rankColor2.r;
		float num3 = 1f - rankColor2.r;
		float num4 = num3 * 0.6f;
		float num5 = num4 + rankColor2.r;
		object obj2 = default(object);
		float num6 = 1f - (float)obj2;
		ref Color reference3 = ref *(Color*)num5;
		float num7 = 1f - (float)obj2;
		float num8 = num6 * 0.6f;
		float num9 = 1f - (float)obj2;
		float num10 = num8 + (float)obj2;
		float num11 = num7 * 0.6f;
		float num12 = num9 * 0.6f;
		float num13 = num11 + (float)obj2;
		float num14 = num12 + (float)obj2;
	}
}
