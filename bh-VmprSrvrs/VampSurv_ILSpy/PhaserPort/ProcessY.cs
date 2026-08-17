using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;

public class ProcessY
{
	private static BaseBody body1;

	private static BaseBody body2;

	private static bool body1Pushable;

	private static bool body2Pushable;

	private static float body1MassImpact;

	private static float body2MassImpact;

	private static float body1FullImpact;

	private static float body2FullImpact;

	private static bool body1MovingUp;

	private static bool body1MovingDown;

	private static bool body1Stationary;

	private static bool body2MovingUp;

	private static bool body2MovingDown;

	private static bool body2Stationary;

	private static bool body1OnTop;

	private static bool body2OnTop;

	private static float overlap;

	public static int Set(BaseBody b1, BaseBody b2, float ov)
	{
		//IL_0592: Expected I4, but got O
		//IL_00bc: Invalid comparison between I4 and F4
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d5: Expected O, but got Unknown
		//IL_0145: Invalid comparison between F4 and I4
		//IL_0159: Invalid comparison between F4 and I4
		//IL_01ca: Invalid comparison between F4 and I4
		//IL_021a: Expected O, but got I
		//IL_027d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0282: Expected O, but got Unknown
		//IL_029f: Expected O, but got I
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Expected O, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected O, but got Unknown
		//IL_02d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Expected O, but got Unknown
		//IL_0344: Expected O, but got I
		//IL_03ce: Invalid comparison between I4 and F4
		//IL_03e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e7: Expected O, but got Unknown
		//IL_0457: Invalid comparison between F4 and I4
		//IL_046b: Invalid comparison between F4 and I4
		//IL_04dc: Invalid comparison between F4 and I4
		//IL_052c: Expected O, but got I
		//IL_0550: Unknown result type (might be due to invalid IL or missing references)
		//IL_0555: Expected F4, but got Unknown
		body1 = b1;
		body2 = b2;
		BaseBody baseBody = body1;
		if (body1 != null)
		{
			BaseBody baseBody2 = body2;
			if (body2 != null)
			{
				BaseBody baseBody3 = body1;
				body1Pushable = baseBody3._pushable;
				BaseBody baseBody4 = body1;
				if (body1 != null)
				{
					bool flag = 0f < baseBody4._dy;
					object obj = 0 - baseBody4._dy;
					bool flag2 = obj == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					bool flag5 = flag4 & flag3;
					body1MovingUp = flag5;
					BaseBody baseBody5 = body1;
					if (body1 != null)
					{
						bool flag6 = baseBody5._dy < 0f;
						bool flag7 = baseBody5._dy == 0f;
						bool flag8 = !flag6;
						bool flag9 = !flag7;
						bool flag10 = flag9 & flag8;
						body1MovingDown = flag10;
						BaseBody baseBody6 = body1;
						if (body1 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185002760h\"");
							bool flag11 = ((baseBody6._dy == 0f) ? true : false);
							body1Stationary = flag11;
							BaseBody baseBody7 = body1;
							if (body1 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v17 (BaseBody)+5C]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v261 @ rcx_v17 (BaseBody)+54]");
								object obj2 = num + 0;
								BaseBody baseBody8 = body2;
								if (body2 != null)
								{
									BaseBody baseBody9 = body2;
									if (body2 != null)
									{
										BaseBody baseBody10 = body1;
										if (body1 != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rcx_v18 (BaseBody)+54]");
											object obj3 = obj2 - 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v20 (BaseBody)+5C]");
											nint num2 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v20 (BaseBody)+54]");
											object obj4 = num2 + 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
											object obj5 = obj3 & 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v248 @ r8_v4 (BaseBody)+54]");
											object obj6 = obj4 - 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12890]");
											object obj7 = obj6 & 0;
											bool flag12 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj5);
											bool flag13 = !flag12;
											body1OnTop = flag13;
											BaseBody baseBody11 = body1;
											if (body1 != null)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v3 (BaseBody)+74]");
												nint num3 = 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v242 @ rdx_v11 (BaseBody)+88]");
												object obj8 = num3 * 0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v5 (BaseBody)+74]");
												float num4 = 0f - (float)obj8;
												body1FullImpact = num4;
												BaseBody baseBody12 = body2;
												if (body2 != null)
												{
													body2Pushable = baseBody12._pushable;
													BaseBody baseBody13 = body2;
													if (body2 != null)
													{
														bool flag14 = 0f < baseBody13._dy;
														object obj9 = 0 - baseBody13._dy;
														bool flag15 = obj9 == null;
														bool flag16 = !flag14;
														bool flag17 = !flag15;
														bool flag18 = flag17 & flag16;
														body2MovingUp = flag18;
														BaseBody baseBody14 = body2;
														if (body2 != null)
														{
															bool flag19 = baseBody14._dy < 0f;
															bool flag20 = baseBody14._dy == 0f;
															bool flag21 = !flag19;
															bool flag22 = !flag20;
															bool flag23 = flag22 & flag21;
															body2MovingDown = flag23;
															BaseBody baseBody15 = body2;
															if (body2 != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001850028E5h\"");
																bool flag24 = ((baseBody15._dy == 0f) ? true : false);
																body2Stationary = flag24;
																bool flag25 = !body1OnTop;
																body2OnTop = flag25;
																BaseBody baseBody16 = body2;
																if (body2 != null)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v200 @ rdx_v5 (BaseBody)+74]");
																	nint num5 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v246 @ rdx_v16 (BaseBody)+88]");
																	object obj10 = num5 * 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v3 (BaseBody)+74]");
																	float num6 = 0f - (float)obj10;
																	float num7 = ov & -2147483649L;
																	body2FullImpact = num6;
																	overlap = num7;
																	Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 512 Invalid \"Jump target not found in method: 0x185002980\"");
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static int BlockCheck()
	{
		//IL_044d: Expected I4, but got O
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Expected O, but got Unknown
		//IL_0095: Expected O, but got I4
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Expected O, but got Unknown
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Expected O, but got Unknown
		//IL_01b4: Expected O, but got I4
		//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c1: Expected O, but got Unknown
		//IL_0281: Unknown result type (might be due to invalid IL or missing references)
		//IL_0286: Expected O, but got Unknown
		//IL_02be: Expected O, but got I4
		//IL_02c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Expected O, but got Unknown
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a5: Expected O, but got Unknown
		//IL_03dd: Expected O, but got I4
		//IL_03e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Expected O, but got Unknown
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e4: Expected F4, but got Unknown
		//IL_0100: Expected O, but got I4
		//IL_020a: Expected O, but got I4
		//IL_0308: Unknown result type (might be due to invalid IL or missing references)
		//IL_030d: Expected F4, but got Unknown
		//IL_0329: Expected O, but got I4
		//IL_0433: Expected O, but got I4
		if (!body1MovingDown || !body1OnTop)
		{
			goto IL_0106;
		}
		BaseBody baseBody = body2;
		bool down = default(bool);
		if (body2 != null)
		{
			object obj = baseBody._blocked & 2;
			bool flag = obj == null;
			bool flag2 = (nint)obj < 0;
			bool flag3 = !flag2;
			object obj2 = !flag3;
			object obj3 = obj2 | flag;
			if (obj3 != null)
			{
				goto IL_0106;
			}
			if (body1 != null)
			{
				float num = overlap;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float y = num ^ 0;
				body1.processY(y, (float?)(object)1, up: false, down);
				return 1;
			}
		}
		goto IL_043f;
		IL_032f:
		if (!body2MovingUp || !body1OnTop)
		{
			goto IL_0439;
		}
		BaseBody baseBody2 = body1;
		if (body1 != null)
		{
			object obj4 = baseBody2._blocked & 1;
			bool flag4 = obj4 == null;
			bool flag5 = (nint)obj4 < 0;
			bool flag6 = !flag5;
			object obj5 = !flag6;
			object obj6 = obj5 | flag4;
			if (obj6 != null)
			{
				goto IL_0439;
			}
			if (body2 != null)
			{
				body2.processY(overlap, (float?)(object)1, up: true, down);
				return 2;
			}
		}
		goto IL_043f;
		IL_0439:
		return 0;
		IL_0210:
		if (!body2MovingDown || !body2OnTop)
		{
			goto IL_032f;
		}
		BaseBody baseBody3 = body1;
		if (body1 != null)
		{
			object obj7 = baseBody3._blocked & 2;
			bool flag7 = obj7 == null;
			bool flag8 = (nint)obj7 < 0;
			bool flag9 = !flag8;
			object obj8 = !flag9;
			object obj9 = obj8 | flag7;
			if (obj9 != null)
			{
				goto IL_032f;
			}
			if (body2 != null)
			{
				float num2 = overlap;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float y2 = num2 ^ 0;
				body2.processY(y2, (float?)(object)1, up: false, down);
				return 2;
			}
		}
		goto IL_043f;
		IL_0106:
		if (!body1MovingUp || !body2OnTop)
		{
			goto IL_0210;
		}
		BaseBody baseBody4 = body2;
		if (body2 != null)
		{
			object obj10 = baseBody4._blocked & 1;
			bool flag10 = obj10 == null;
			bool flag11 = (nint)obj10 < 0;
			bool flag12 = !flag11;
			object obj11 = !flag12;
			object obj12 = obj11 | flag10;
			if (obj12 != null)
			{
				goto IL_0210;
			}
			if (body1 != null)
			{
				body1.processY(overlap, (float?)(object)1, up: true, down);
				return 1;
			}
		}
		goto IL_043f;
		IL_043f:
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	public static bool Check()
	{
		//IL_0362: Expected I4, but got O
		//IL_0052: Expected O, but got I
		//IL_005f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Expected O, but got Unknown
		//IL_0071: Unknown result type (might be due to invalid IL or missing references)
		//IL_0076: Expected O, but got Unknown
		//IL_00a0: Expected O, but got I4
		//IL_00bb: Expected O, but got I8
		//IL_0104: Expected O, but got I
		//IL_0111: Unknown result type (might be due to invalid IL or missing references)
		//IL_0116: Expected O, but got Unknown
		//IL_0123: Unknown result type (might be due to invalid IL or missing references)
		//IL_0128: Expected O, but got Unknown
		//IL_0152: Expected O, but got I4
		//IL_016d: Expected O, but got I8
		BaseBody baseBody = body1;
		if (body1 != null)
		{
			BaseBody baseBody2 = body2;
			if (body2 != null)
			{
				BaseBody baseBody3 = body1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v3 (BaseBody)+74]");
				nint num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v3 (BaseBody)+74]");
				object obj = num * 0;
				object obj2 = obj * baseBody2._mass;
				object obj3 = obj2 / baseBody3._mass;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rdx_v3 (BaseBody)+74]");
				bool flag = (nint)0 > (nint)0;
				object obj4 = 1;
				if (!flag)
				{
					obj4 = 4294967295L;
				}
				BaseBody baseBody4 = body1;
				object obj5 = obj4 * obj3;
				if (body1 != null)
				{
					BaseBody baseBody5 = body2;
					if (body2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v1 (BaseBody)+74]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v1 (BaseBody)+74]");
						object obj6 = num2 * 0;
						object obj7 = obj6 * baseBody4._mass;
						object obj8 = obj7 / baseBody5._mass;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ rdx_v1 (BaseBody)+74]");
						bool flag2 = (nint)0 > (nint)0;
						object obj9 = 1;
						if (!flag2)
						{
							obj9 = 4294967295L;
						}
						BaseBody baseBody6 = body1;
						object obj10 = obj9 * obj8;
						object obj11 = obj10 + obj5;
						float num3 = (float)obj11 * 0.5f;
						if (body1 != null)
						{
							float num4 = (float)obj5 - num3;
							float num5 = num4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v77 @ rdx_v5 (BaseBody)+88]");
							float num6 = num5 * 0f;
							float num7 = num6 + num3;
							body1MassImpact = num7;
							BaseBody baseBody7 = body2;
							if (body2 != null)
							{
								float num8 = (float)obj10 - num3;
								float num9 = num8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v76 @ rdx_v6 (BaseBody)+88]");
								float num10 = num9 * 0f;
								float num11 = num10 + num3;
								body2MassImpact = num11;
								int side;
								if (body1MovingUp && body2OnTop)
								{
									side = 0;
								}
								else if (body2MovingUp && body1OnTop)
								{
									side = 1;
								}
								else if (body1MovingDown && body1OnTop)
								{
									side = 2;
								}
								else
								{
									if (!body2MovingDown || !body2OnTop)
									{
										return false;
									}
									side = 3;
								}
								return Run(side);
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public static bool Run(int side)
	{
		//IL_0943: Expected I4, but got O
		//IL_08f1: Expected O, but got I4
		//IL_09ef: Expected O, but got I4
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected F4, but got Unknown
		//IL_0231: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_0921: Expected F4, but got I4
		//IL_092a: Expected O, but got I4
		//IL_0869: Expected O, but got I4
		//IL_04a2: Expected O, but got I4
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected F4, but got Unknown
		//IL_0186: Expected O, but got I4
		//IL_0645: Unknown result type (might be due to invalid IL or missing references)
		//IL_064a: Expected F4, but got Unknown
		//IL_0665: Expected O, but got I4
		//IL_06d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_06d9: Expected F4, but got Unknown
		//IL_06f5: Expected O, but got I4
		//IL_0260: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected F4, but got Unknown
		//IL_00c7: Expected O, but got I4
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04de: Expected F4, but got Unknown
		//IL_04e7: Expected O, but got I4
		//IL_07af: Unknown result type (might be due to invalid IL or missing references)
		//IL_07b4: Expected F4, but got Unknown
		//IL_07d0: Expected O, but got I4
		//IL_0418: Expected O, but got I4
		//IL_069f: Expected O, but got I4
		//IL_0730: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_052f: Expected O, but got I4
		//IL_044f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0454: Expected F4, but got Unknown
		//IL_0465: Expected O, but got I4
		//IL_0828: Expected O, but got I4
		//IL_05d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d9: Expected F4, but got Unknown
		//IL_05f5: Expected O, but got I4
		//IL_062f: Expected O, but got I4
		bool down = default(bool);
		BaseBody baseBody;
		float y2;
		float? vy;
		BaseBody baseBody2;
		if (body1Pushable)
		{
			if (body2Pushable)
			{
				float num = overlap * 0.5f;
				overlap = num;
				if (side != 0 && side != 3)
				{
					if (body1 != null)
					{
						float num2 = overlap;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						float y = num2 ^ 0;
						body1.processY(y, (float?)(object)1, up: false, down);
						baseBody = body2;
						if (body2 != null)
						{
							y2 = overlap;
							vy = (float?)(object)1;
							goto IL_0961;
						}
					}
				}
				else if (body1 != null)
				{
					body1.processY(overlap, (float?)(object)1, up: false, down);
					baseBody = body2;
					if (body2 != null)
					{
						float num3 = overlap;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						y2 = num3 ^ 0;
						vy = (float?)(object)1;
						goto IL_0961;
					}
				}
				goto IL_0935;
			}
			if (body1Pushable)
			{
				if (!body2Pushable)
				{
					if (side != 0 && side != 3)
					{
						baseBody = body1;
						goto IL_098d;
					}
					baseBody2 = body1;
					goto IL_09c7;
				}
				if (body1Pushable)
				{
					goto IL_02fb;
				}
			}
		}
		if (!body2Pushable)
		{
			goto IL_02fb;
		}
		if (side != 0 && side != 3)
		{
			baseBody2 = body2;
			goto IL_09c7;
		}
		baseBody = body2;
		goto IL_098d;
		IL_098d:
		if (baseBody == null)
		{
			goto IL_0935;
		}
		float num4 = overlap;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		y2 = num4 ^ 0;
		vy = (float?)(object)1;
		goto IL_0961;
		IL_09aa:
		BaseBody baseBody3;
		float num5;
		if (baseBody3 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float y3 = num5 ^ 0;
			baseBody3.processY(y3, (float?)(object)1, up: false, down);
			if (body2 != null)
			{
				body2.processY(num5, (float?)(object)1, up: true, down);
				return true;
			}
		}
		goto IL_0935;
		IL_092f:
		return true;
		IL_09e4:
		bool flag;
		object obj = !flag;
		BaseBody baseBody4;
		float? num7;
		if (obj == null)
		{
			if (body2 != null && baseBody4 != null)
			{
				baseBody4.processY(num5, (float?)(object)1, up: true, down);
				baseBody = body2;
				if (body2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
					float num6 = num5 ^ 0;
					y2 = num6;
					num7 = (float?)(object)0;
					goto IL_0980;
				}
			}
		}
		else if (baseBody4 != null)
		{
			baseBody4.processY(num5, (float?)(object)1, up: true, down);
			baseBody = body2;
			if (body2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float num8 = num5 ^ 0;
				vy = (float?)(object)1;
				y2 = num8;
				goto IL_0961;
			}
		}
		goto IL_0935;
		IL_09c7:
		if (baseBody2 != null)
		{
			baseBody2.processY(overlap, (float?)(object)1, up: true, down);
			return true;
		}
		goto IL_0935;
		IL_02fb:
		num5 = overlap * 0.5f;
		if (side != 0)
		{
			if (side != 1)
			{
				if (side != 2)
				{
					if (side != 3)
					{
						goto IL_092f;
					}
					baseBody4 = body1;
					if (!body1Stationary)
					{
						flag = !body1MovingUp;
						goto IL_09e4;
					}
					if (body1 != null)
					{
						body1.processY(0f, (float?)(object)0, up: true, down);
						baseBody = body2;
						goto IL_098d;
					}
				}
				else
				{
					baseBody3 = body1;
					if (!body2Stationary)
					{
						if (body2MovingUp)
						{
							goto IL_09aa;
						}
						if (body2 != null && body1 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
							float y4 = num5 ^ 0;
							body1.processY(y4, (float?)(object)1, up: false, down);
							if (body2 != null)
							{
								body2.processY(num5, (float?)(object)0, up: true, down);
								return true;
							}
						}
					}
					else if (body1 != null)
					{
						float num9 = overlap;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						float y5 = num9 ^ 0;
						body1.processY(y5, (float?)(object)1, up: false, down);
						if (body2 != null)
						{
							body2.processY(0f, (float?)(object)0, up: true, down);
							return true;
						}
					}
				}
			}
			else
			{
				baseBody3 = body1;
				if (!body1Stationary)
				{
					if (body1MovingDown)
					{
						goto IL_09aa;
					}
					if (body1 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						float y6 = num5 ^ 0;
						body1.processY(y6, (float?)(object)0, up: false, down);
						if (body1 != null && body2 != null)
						{
							body2.processY(num5, (float?)(object)1, up: true, down);
							return true;
						}
					}
				}
				else if (body1 != null)
				{
					body1.processY(0f, (float?)(object)0, up: false, down);
					baseBody2 = body2;
					goto IL_09c7;
				}
			}
		}
		else
		{
			baseBody4 = body1;
			if (!body2Stationary)
			{
				flag = !body2MovingDown;
				goto IL_09e4;
			}
			if (body1 != null)
			{
				body1.processY(overlap, (float?)(object)1, up: true, down);
				baseBody = body2;
				if (body2 != null)
				{
					y2 = 0f;
					num7 = (float?)(object)0;
					goto IL_0980;
				}
			}
		}
		goto IL_0935;
		IL_0935:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0961:
		baseBody.processY(y2, vy, up: false, down);
		goto IL_092f;
		IL_0980:
		vy = num7;
		goto IL_0961;
	}

	public static void RunImmovableBody1(int blockedState)
	{
		//IL_007f: Expected O, but got I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected F4, but got Unknown
		//IL_0058: Expected O, but got I4
		//IL_00b5: Expected I, but got O
		//IL_00bd: Expected I, but got O
		//IL_00cd: Expected O, but got I
		//IL_014d: Expected O, but got I4
		//IL_0109: Expected O, but got I
		//IL_013f: Expected O, but got I4
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Expected O, but got Unknown
		//IL_01e1: Expected I, but got O
		//IL_01e9: Expected I, but got O
		//IL_01f9: Expected O, but got I
		//IL_0235: Expected O, but got I
		BaseBody baseBody;
		if (blockedState != 1)
		{
			bool down = default(bool);
			if (!body1OnTop)
			{
				float num = overlap;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float y = num ^ 0;
				body2.processY(y, (float?)(object)1, up: false, down);
				baseBody = null;
			}
			else
			{
				body2.processY(overlap, (float?)(object)1, up: true, down);
				baseBody = null;
			}
		}
		else
		{
			BaseBody baseBody2 = body2;
			_ = 0;
			baseBody = null;
		}
		BaseBody baseBody3 = body1;
		if (body1 == null)
		{
			return;
		}
		nint num2 = (nint)typeof(Body);
		nint num3 = (nint)baseBody3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v4 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v3 (Il2CppClass<BaseBody>)+130]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v4 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num4 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v3 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v15+FFFFFFF8+v210 @ rax_v7*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_02d4;
			}
		}
		obj3 = 0;
		goto IL_02d4;
		IL_02d4:
		if (obj3 != null)
		{
			baseBody = body1;
		}
		if (baseBody == null)
		{
			return;
		}
		BaseBody baseBody4 = body2;
		BaseBody baseBody5 = body1;
		float2 position = baseBody5._position;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (BaseBody)+C8]");
		object obj4 = position - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (BaseBody)+114]");
		object obj5 = obj4 * 0;
		float2 position2 = (float2)(obj5 + (object)baseBody4._position);
		baseBody4._position = position2;
		BaseBody baseBody6 = body2;
		nint num5 = (nint)typeof(Body);
		nint num6 = (nint)baseBody6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppClass<Body>)+130]");
		object obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r9_v5 (Il2CppClass<BaseBody>)+130]");
		nint num7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppClass<Body>)+130]");
		if (num7 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r9_v5 (Il2CppClass<BaseBody>)+C8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v12+FFFFFFF8+v282 @ rax_v11*8]");
			if (0 == (nint)typeof(Body))
			{
				float num8 = (float)baseBody6._position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r10_v4 (BaseBody)+C8]");
				float dx = num8 - 0f;
				baseBody6._dx = dx;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public static void RunImmovableBody2(int blockedState)
	{
		//IL_00ac: Expected I, but got O
		//IL_0044: Expected I, but got O
		//IL_00d7: Expected O, but got I4
		//IL_012e: Expected I, but got O
		//IL_0136: Expected I, but got O
		//IL_0146: Expected O, but got I
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0068: Expected F4, but got Unknown
		//IL_0084: Expected O, but got I4
		//IL_01c6: Expected O, but got I4
		//IL_0182: Expected O, but got I
		//IL_01b8: Expected O, but got I4
		//IL_01e2: Expected I, but got O
		//IL_021e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0223: Expected O, but got Unknown
		//IL_0233: Unknown result type (might be due to invalid IL or missing references)
		//IL_0238: Expected O, but got Unknown
		//IL_0248: Unknown result type (might be due to invalid IL or missing references)
		//IL_024d: Expected O, but got Unknown
		//IL_0287: Expected I, but got O
		//IL_028f: Expected I, but got O
		//IL_029f: Expected O, but got I
		//IL_02cb: Expected I, but got O
		//IL_02e9: Expected O, but got I
		//IL_0316: Expected I, but got O
		BaseBody baseBody;
		nint num;
		if (blockedState != 2)
		{
			bool down = default(bool);
			if (!body2OnTop)
			{
				bool flag = body1 == null;
				num = (nint)typeof(ProcessY);
				if (flag)
				{
					goto IL_0352;
				}
				float num2 = overlap;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float y = num2 ^ 0;
				body1.processY(y, (float?)(object)1, up: false, down);
				baseBody = null;
			}
			else
			{
				bool flag2 = body1 == null;
				num = (nint)typeof(ProcessY);
				if (flag2)
				{
					goto IL_0352;
				}
				body1.processY(overlap, (float?)(object)1, up: true, down);
				baseBody = null;
			}
		}
		else
		{
			BaseBody baseBody2 = body1;
			bool flag3 = body1 == null;
			IntPtr intPtr = default(IntPtr);
			num = intPtr;
			if (flag3)
			{
				goto IL_0352;
			}
			_ = 0;
			baseBody = null;
		}
		BaseBody baseBody3 = body2;
		if (body2 == null)
		{
			return;
		}
		nint num3 = (nint)typeof(Body);
		nint num4 = (nint)baseBody3;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v4 (Il2CppClass<Body>)+130]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v3 (Il2CppClass<BaseBody>)+130]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ r8_v4 (Il2CppClass<Body>)+130]");
		object obj3;
		if (num5 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v101 @ r10_v3 (Il2CppClass<BaseBody>)+C8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v19+FFFFFFF8+v210 @ rax_v11*8]");
			if (0 == (nint)typeof(Body))
			{
				obj3 = 1;
				goto IL_03c9;
			}
		}
		obj3 = 0;
		goto IL_03c9;
		IL_0352:
		throw new NullReferenceException();
		IL_03c9:
		if (obj3 != null)
		{
			baseBody = body2;
		}
		if (baseBody == null)
		{
			return;
		}
		num = (nint)body1;
		if (body1 != null)
		{
			BaseBody baseBody4 = body2;
			float2 position = baseBody4._position;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (BaseBody)+C8]");
			object obj4 = position - 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (BaseBody)+114]");
			object obj5 = obj4 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v280 @ rdx_v1 (Il2CppClass<ProcessY>)+50]");
			object obj6 = obj5 + 0;
			BaseBody baseBody5 = body1;
			if (body1 != null)
			{
				nint num6 = (nint)typeof(Body);
				nint num7 = (nint)baseBody5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppClass<Body>)+130]");
				object obj7 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r9_v5 (Il2CppClass<BaseBody>)+130]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppClass<Body>)+130]");
				bool flag4 = num8 < 0;
				num = (nint)typeof(Body);
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r9_v5 (Il2CppClass<BaseBody>)+C8]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v16+FFFFFFF8+v282 @ rax_v15*8]");
					bool flag5 = 0 != (nint)typeof(Body);
					num = (nint)typeof(Body);
					if (!flag5)
					{
						float num9 = (float)baseBody5._position;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r10_v4 (BaseBody)+C8]");
						float dx = num9 - 0f;
						baseBody5._dx = dx;
						return;
					}
				}
				throw new InvalidCastException();
			}
		}
		goto IL_0352;
	}
}
