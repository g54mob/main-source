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
			while (true)
			{
				int num = 1252034481;
				while (true)
				{
					switch (num ^ 0x4AA087B0)
					{
					case 0:
						break;
					case 1:
						if (!flag)
						{
							goto IL_0035;
						}
						goto IL_0041;
					default:
						{
							if (!flag2)
							{
								return true;
							}
							goto IL_0041;
						}
						IL_0041:
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
										return false;
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
									while (true)
									{
										switch (0x4AA087B1 ^ 0x4AA087B0)
										{
										case 2:
											break;
										default:
											goto end_IL_0091;
										case 1:
											if (androidAPILevel2 > num3)
											{
												return false;
											}
											goto end_IL_0091;
										case 0:
											goto end_IL_0091;
										}
										continue;
										end_IL_0091:
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
					break;
					IL_0035:
					num = 1252034482;
				}
			}
		}
	}
}
