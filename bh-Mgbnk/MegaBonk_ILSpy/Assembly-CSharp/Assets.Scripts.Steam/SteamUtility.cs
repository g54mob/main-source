using System;
using Steamworks;
using UnityEngine;

namespace Assets.Scripts.Steam;

public class SteamUtility
{
	public unsafe static Texture2D LoadAvatar(ulong steamId, int quality = 0)
	{
		//IL_0089: Expected O, but got I8
		//IL_0013: Expected O, but got I4
		//IL_006f: Expected O, but got I8
		//IL_02ff: Expected O, but got I4
		//IL_0055: Expected O, but got I8
		//IL_00c4: Expected O, but got I4
		//IL_00d2: Expected I4, but got O
		//IL_01f4: Expected I4, but got O
		//IL_018b: Expected O, but got I4
		//IL_0194: Unknown result type (might be due to invalid IL or missing references)
		//IL_0199: Expected I4, but got Unknown
		//IL_01ae: Expected O, but got Ref
		bool flag = quality == 0;
		int iImage;
		if (!flag)
		{
			object obj = quality - 1;
			if (!flag)
			{
				if ((nint)obj != 1)
				{
					iImage = 0;
				}
				else
				{
					int largeFriendAvatar = SteamFriends.GetLargeFriendAvatar((CSteamID)steamId);
					iImage = largeFriendAvatar;
				}
			}
			else
			{
				int mediumFriendAvatar = SteamFriends.GetMediumFriendAvatar((CSteamID)steamId);
				iImage = mediumFriendAvatar;
			}
		}
		else
		{
			int smallFriendAvatar = SteamFriends.GetSmallFriendAvatar((CSteamID)steamId);
			iImage = smallFriendAvatar;
		}
		bool imageSize = SteamUtils.GetImageSize(iImage, out var pnWidth, out var pnHeight);
		int num3;
		if (pnWidth != 0 && pnHeight != 0)
		{
			object obj2 = pnHeight * pnWidth;
			int num = obj2 << 2;
			byte[] array = new byte[num];
			bool imageRGBA = SteamUtils.GetImageRGBA(iImage, array, num);
			bool mipChain = default(bool);
			Texture2D texture2D = new Texture2D((int)pnWidth, (int)pnHeight, TextureFormat.RGBA32, mipChain);
			if ((object)texture2D == null)
			{
				return (Texture2D)(object)new NullReferenceException();
			}
			texture2D.LoadRawTextureData(array);
			texture2D.Apply();
			int width = texture2D.width;
			int height = texture2D.height;
			Texture2D texture2D2 = new Texture2D(width, height);
			int width2 = texture2D.width;
			int height2 = texture2D.height;
			float r = default(float);
			for (int i = 0; i < width2; i++)
			{
				int num2 = 0;
				while (num2 < height2)
				{
					Color pixel = texture2D.GetPixel(i, num2);
					object obj3 = height2 - num2;
					int y = obj3 - 1;
					texture2D2.SetPixel(i, y, (Color)(&r));
					num2++;
					r = pixel.r;
				}
			}
			texture2D2.Apply();
			num3 = (int)texture2D2;
		}
		else
		{
			num3 = 0;
		}
		return (Texture2D)num3;
	}

	public unsafe static Texture2D FlipTexture(Texture2D original)
	{
		//IL_008e: Expected O, but got I4
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Expected I4, but got Unknown
		//IL_00b1: Expected O, but got Ref
		Texture2D texture2D;
		if ((object)original != null)
		{
			int width = original.width;
			int height = original.height;
			texture2D = new Texture2D(width, height);
			int width2 = original.width;
			int height2 = original.height;
			if (width2 <= 0)
			{
				goto IL_0114;
			}
			int num = 0;
			float r = default(float);
			while (true)
			{
				bool flag = height2 <= 0;
				int num2 = 0;
				if (!flag)
				{
					while (true)
					{
						Color pixel = original.GetPixel(num, num2);
						if ((object)texture2D == null)
						{
							break;
						}
						object obj = height2 - num2;
						int y = obj - 1;
						texture2D.SetPixel(num, y, (Color)(&r));
						num2++;
						bool flag2 = num2 < height2;
						r = pixel.r;
						if (flag2)
						{
							continue;
						}
						goto IL_00ea;
					}
					break;
				}
				goto IL_00ea;
				IL_00ea:
				num++;
				if (num < width2)
				{
					continue;
				}
				goto IL_0114;
			}
		}
		goto IL_013f;
		IL_0114:
		if ((object)texture2D != null)
		{
			texture2D.Apply();
			return texture2D;
		}
		goto IL_013f;
		IL_013f:
		return (Texture2D)(object)new NullReferenceException();
	}
}
