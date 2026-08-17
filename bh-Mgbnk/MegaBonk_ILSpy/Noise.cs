using System;
using Cpp2ILInjected;
using UnityEngine;

public static class Noise
{
	public static float[,] GenerateNoiseMap(int mapWidth, int mapHeight, int seed, float scale, int octaves, float persistance, float lacunarity, float blend, float blendStrength, Vector2 offset)
	{
		//IL_003c: Expected I, but got O
		//IL_00d5: Invalid comparison between I4 and F4
		//IL_063b: Expected I4, but got I8
		//IL_0656: Expected I4, but got I8
		//IL_06ef: Expected F4, but got I4
		//IL_03ee: Expected O, but got I
		//IL_0408: Expected O, but got I4
		//IL_041e: Expected O, but got I
		//IL_0426: Unknown result type (might be due to invalid IL or missing references)
		//IL_042b: Expected I, but got Unknown
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B10");
		ConsistentRandom consistentRandom = new ConsistentRandom(seed);
		Vector2[] array = new Vector2[(object)offset];
		bool flag = (nint)offset <= 0;
		int num = 0;
		nint num2 = (nint)typeof(Vector2[]);
		int num3 = seed;
		if (flag)
		{
			goto IL_00cc;
		}
		float num7 = default(float);
		if (consistentRandom != null)
		{
			object obj = default(object);
			object obj2 = default(object);
			while (true)
			{
				int num4 = consistentRandom.Next(-100000, 100000);
				int num5 = consistentRandom.Next(-100000, 100000);
				if (array == null)
				{
					break;
				}
				float num6 = (float)num4 + (float)obj;
				num7 = (float)num5 + (float)obj2;
				num3 = 0 + 1;
				bool flag2 = num3 < (nint)offset;
				num = 100000;
				if (flag2)
				{
					continue;
				}
				goto IL_00cc;
			}
		}
		goto IL_0616;
		IL_0616:
		return (float[,])(object)new NullReferenceException();
		IL_04b6:
		int num8 = 0;
		while (mapWidth <= 0)
		{
			num8++;
			if (num8 < mapHeight)
			{
				continue;
			}
			goto IL_05f4;
		}
		float[,] array2 = default(float[,]);
		bool flag3 = array2 == null;
		float num9 = num7;
		if (!flag3)
		{
			throw new IndexOutOfRangeException();
		}
		goto IL_0616;
		IL_05f4:
		return array2;
		IL_00cc:
		float num10 = default(float);
		bool flag4 = 0f < num10;
		float num11 = num10;
		if (!flag4)
		{
			num11 = 0.0001f;
		}
		float num12 = (float)mapWidth * 0.5f;
		float num13 = (float)mapHeight * 0.5f;
		if (mapHeight <= 0)
		{
			goto IL_05f4;
		}
		object obj4 = default(object);
		object obj3 = obj4;
		object obj6 = default(object);
		object obj5 = obj6;
		float num14 = -3.4028235E+38f;
		float num15 = 3.4028235E+38f;
		int num16 = 0;
		float num17 = default(float);
		float num19 = default(float);
		while (true)
		{
			bool flag5 = mapWidth <= 0;
			num17 = num17;
			float num18 = num19;
			object obj7 = obj3;
			object obj8 = obj5;
			float num20 = num14;
			float num21 = num7;
			float num22 = num15;
			int num23 = num;
			int num24 = num3;
			if (!flag5)
			{
				while (true)
				{
					bool flag6 = (nint)offset <= 0;
					float num6 = 0f;
					if (!flag6)
					{
						if (array == null)
						{
							break;
						}
						int num25 = 0;
						bool flag7;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm1,r14d\"");
							float num26 = 1f * (float)obj7;
							float num27 = 0f - num13;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm3,ebp\"");
							float num28 = num27 / num11;
							float num29 = 0f - num12;
							float num30 = num28 * num26;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,r14d\"");
							float num31 = num30;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v5 (UnityEngine.Vector2[])+24+v604 @ rbx_v11 (System.Int32)*8]");
							float num32 = num31 + 0f;
							float num33 = 0f - num13;
							float num34 = num29 / num11;
							float num35 = num32 * (float)obj8;
							float num36 = num33 / num11;
							float num37 = num36 * 1f;
							float num38 = num37;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v5 (UnityEngine.Vector2[])+24+v604 @ rbx_v11 (System.Int32)*8]");
							float num39 = num38 + 0f;
							num18 = num35 + num39;
							float num40 = 1f * (float)obj7;
							float num41 = num34 * num40;
							float num42 = num41;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v5 (UnityEngine.Vector2[])+20+v604 @ rbx_v11 (System.Int32)*8]");
							float num43 = num42 + 0f;
							float num44 = num43 * (float)obj8;
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm2,ebp\"");
							float num45 = 0f - num12;
							float num46 = num45 / num11;
							float num47 = num46 * 1f;
							float num48 = num47;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rax_v5 (UnityEngine.Vector2[])+20+v604 @ rbx_v11 (System.Int32)*8]");
							float num49 = num48 + 0f;
							num17 = num44 + num49;
							float num50 = Mathf.PerlinNoise(num17, num18);
							float num51 = num50 + num50;
							num24 = num25 + 1;
							float num52 = num51 - 1f;
							num21 = num52 * 1f;
							num6 = 0f + num21;
							flag7 = num24 < (nint)offset;
							obj7 = obj4;
							obj8 = obj6;
							num23 = 0;
						}
						while (flag7);
					}
					if (!(num6 > num20))
					{
						if (num22 > num6)
						{
							num22 = num6;
						}
					}
					else
					{
						num20 = num6;
					}
					if (array2 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rax_v2 (System.Single[2])+10]");
					object obj9 = 0;
					object obj10 = 0 + 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v596 @ rax_v16+10]");
					object obj11 = (nint)0 * (nint)0;
					num2 = (nint)(obj11 + num16);
					bool flag8 = (nint)obj10 < mapWidth;
					num19 = num18;
					obj3 = obj7;
					obj5 = obj8;
					num14 = num20;
					num7 = num21;
					num15 = num22;
					num = num23;
					num3 = num24;
					if (flag8)
					{
						continue;
					}
					goto IL_048c;
				}
				break;
			}
			goto IL_048c;
			IL_048c:
			num16++;
			if (num16 < mapHeight)
			{
				continue;
			}
			goto IL_04b6;
		}
		goto IL_0616;
	}
}
