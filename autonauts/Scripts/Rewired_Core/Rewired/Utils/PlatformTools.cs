namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal static class PlatformTools
	{
		public static bool IsSysVersionInRange(string min, string max)
		{
			bool flag = !string.IsNullOrEmpty(min);
			bool flag2 = !string.IsNullOrEmpty(max);
			if (!flag)
			{
				while (true)
				{
					int num = -1735252551;
					while (true)
					{
						switch (num ^ -1735252552)
						{
						case 2:
							break;
						case 1:
							goto IL_0035;
						default:
							return true;
						}
						break;
						IL_0035:
						if (flag2)
						{
							goto end_IL_0017;
						}
						num = -1735252552;
					}
					continue;
					end_IL_0017:
					break;
				}
			}
			bool result;
			if (UnityTools.isAndroidPlatform)
			{
				if (flag)
				{
					try
					{
						int num2 = int.Parse(min);
						int androidAPILevel = UnityTools.externalTools.GetAndroidAPILevel();
						if (androidAPILevel < num2)
						{
							result = false;
							while (true)
							{
								switch (-1735252551 ^ -1735252552)
								{
								case 2:
									break;
								default:
									goto end_IL_0067;
								case 0:
									goto end_IL_0067;
								case 1:
									goto IL_00f9;
								}
								continue;
								end_IL_0067:
								break;
							}
						}
					}
					catch
					{
						Logger.LogError("Error parsing minimum OS version.");
						flag = false;
					}
				}
				if (flag2)
				{
					try
					{
						int num3 = int.Parse(max);
						int androidAPILevel2 = UnityTools.externalTools.GetAndroidAPILevel();
						if (androidAPILevel2 > num3)
						{
							while (true)
							{
								switch (-1735252550 ^ -1735252552)
								{
								case 0:
									break;
								default:
									goto end_IL_00bc;
								case 2:
									result = false;
									goto IL_00f9;
								case 1:
									goto end_IL_00bc;
								}
								continue;
								end_IL_00bc:
								break;
							}
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
			IL_00f9:
			return result;
		}
	}
}
