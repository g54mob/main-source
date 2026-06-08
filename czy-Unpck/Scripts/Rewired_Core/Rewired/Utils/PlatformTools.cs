namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal static class PlatformTools
	{
		public static bool IsSysVersionInRange(string min, string max)
		{
			bool flag = !string.IsNullOrEmpty(min);
			bool flag2 = !string.IsNullOrEmpty(max);
			if (!flag && !flag2)
			{
				return true;
			}
			if (UnityTools.isAndroidPlatform)
			{
				if (flag)
				{
					try
					{
						int num = int.Parse(min);
						int androidAPILevel = UnityTools.externalTools.GetAndroidAPILevel();
						if (androidAPILevel < num)
						{
							while (true)
							{
								switch (0x7CD96004 ^ 0x7CD96005)
								{
								case 0:
									break;
								default:
									goto end_IL_0042;
								case 1:
									return false;
								case 2:
									goto end_IL_0042;
								}
								continue;
								end_IL_0042:
								break;
							}
						}
					}
					catch
					{
						while (true)
						{
							IL_0072:
							int num2 = 2094620679;
							while (true)
							{
								switch (num2 ^ 0x7CD96005)
								{
								case 0:
									break;
								default:
									goto end_IL_0077;
								case 2:
									Logger.LogError("Error parsing minimum OS version.");
									num2 = 2094620678;
									continue;
								case 3:
									flag = false;
									num2 = 2094620676;
									continue;
								case 1:
									goto end_IL_0077;
								}
								goto IL_0072;
								continue;
								end_IL_0077:
								break;
							}
							break;
						}
					}
				}
				if (flag2)
				{
					try
					{
						int num3 = int.Parse(max);
						int androidAPILevel2 = default(int);
						while (true)
						{
							IL_00bb:
							int num4 = 2094620676;
							while (true)
							{
								switch (num4 ^ 0x7CD96005)
								{
								case 0:
									break;
								default:
									goto end_IL_00c0;
								case 1:
									goto IL_00dd;
								case 3:
									if (androidAPILevel2 > num3)
									{
										return false;
									}
									goto end_IL_00c0;
								case 2:
									goto end_IL_00c0;
								}
								goto IL_00bb;
								IL_00dd:
								androidAPILevel2 = UnityTools.externalTools.GetAndroidAPILevel();
								num4 = 2094620678;
								continue;
								end_IL_00c0:
								break;
							}
							break;
						}
					}
					catch
					{
						Logger.LogError("Error parsing maximum OS version.");
						flag = false;
					}
				}
			}
			return true;
		}
	}
}
