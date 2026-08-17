using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Unity.Mathematics;

public class ProcessX
{
	private static BaseBody body1;

	private static BaseBody body2;

	private static bool body1Pushable;

	private static bool body2Pushable;

	private static float body1MassImpact;

	private static float body2MassImpact;

	private static float body1FullImpact;

	private static float body2FullImpact;

	private static bool body1MovingLeft;

	private static bool body1MovingRight;

	private static bool body1Stationary;

	private static bool body2MovingLeft;

	private static bool body2MovingRight;

	private static bool body2Stationary;

	private static bool body1OnLeft;

	private static bool body2OnLeft;

	private static float overlap;

	public static int Set(BaseBody b1, BaseBody b2, float ov)
	{
		//IL_0572: Expected I4, but got O
		//IL_00ad: Invalid comparison between I4 and F4
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0136: Invalid comparison between F4 and I4
		//IL_014a: Invalid comparison between F4 and I4
		//IL_01bb: Invalid comparison between F4 and I4
		//IL_0254: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Expected O, but got Unknown
		//IL_02cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d0: Expected O, but got Unknown
		//IL_03b7: Invalid comparison between I4 and F4
		//IL_03cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d0: Expected O, but got Unknown
		//IL_0440: Invalid comparison between F4 and I4
		//IL_0454: Invalid comparison between F4 and I4
		//IL_04c5: Invalid comparison between F4 and I4
		//IL_0530: Unknown result type (might be due to invalid IL or missing references)
		//IL_0535: Expected F4, but got Unknown
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
					bool flag = 0f < baseBody4._dx;
					object obj = 0 - baseBody4._dx;
					bool flag2 = obj == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					bool flag5 = flag4 & flag3;
					body1MovingLeft = flag5;
					BaseBody baseBody5 = body1;
					if (body1 != null)
					{
						bool flag6 = baseBody5._dx < 0f;
						bool flag7 = baseBody5._dx == 0f;
						bool flag8 = !flag6;
						bool flag9 = !flag7;
						bool flag10 = flag9 & flag8;
						body1MovingRight = flag10;
						BaseBody baseBody6 = body1;
						if (body1 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000185001422h\"");
							bool flag11 = ((baseBody6._dx == 0f) ? true : false);
							body1Stationary = flag11;
							BaseBody baseBody7 = body1;
							if (body1 != null)
							{
								BaseBody baseBody8 = body2;
								if (body2 != null)
								{
									object obj2 = baseBody7._size + baseBody7._position;
									BaseBody baseBody9 = body2;
									object obj3 = obj2 - (object)baseBody8._position;
									object obj4 = obj3 & -2147483649L;
									if (body2 != null && body1 != null)
									{
										object obj5 = baseBody9._size + baseBody9._position;
										object obj6 = obj5 - (object)baseBody7._position;
										object obj7 = obj6 & -2147483649L;
										bool flag12 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4);
										bool flag13 = !flag12;
										body1OnLeft = flag13;
										BaseBody baseBody10 = body1;
										if (body1 != null)
										{
											object obj8 = baseBody._velocity * baseBody10._bounce;
											float num = (float)baseBody2._velocity - (float)obj8;
											body1FullImpact = num;
											BaseBody baseBody11 = body2;
											if (body2 != null)
											{
												body2Pushable = baseBody11._pushable;
												BaseBody baseBody12 = body2;
												if (body2 != null)
												{
													bool flag14 = 0f < baseBody12._dx;
													object obj9 = 0 - baseBody12._dx;
													bool flag15 = obj9 == null;
													bool flag16 = !flag14;
													bool flag17 = !flag15;
													bool flag18 = flag17 & flag16;
													body2MovingLeft = flag18;
													BaseBody baseBody13 = body2;
													if (body2 != null)
													{
														bool flag19 = baseBody13._dx < 0f;
														bool flag20 = baseBody13._dx == 0f;
														bool flag21 = !flag19;
														bool flag22 = !flag20;
														bool flag23 = flag22 & flag21;
														body2MovingRight = flag23;
														BaseBody baseBody14 = body2;
														if (body2 != null)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 000000018500158Fh\"");
															bool flag24 = ((baseBody14._dx == 0f) ? true : false);
															body2Stationary = flag24;
															bool flag25 = !body1OnLeft;
															body2OnLeft = flag25;
															BaseBody baseBody15 = body2;
															if (body2 != null)
															{
																object obj10 = baseBody2._velocity * baseBody15._bounce;
																float num2 = (float)baseBody._velocity - (float)obj10;
																float num3 = ov & -2147483649L;
																body2FullImpact = num2;
																overlap = num3;
																Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 495 Invalid \"Jump target not found in method: 0x185001610\"");
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
		if (!body1MovingRight || !body1OnLeft)
		{
			goto IL_0106;
		}
		BaseBody baseBody = body2;
		bool right = default(bool);
		if (body2 != null)
		{
			object obj = baseBody._blocked & 8;
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
				float x = num ^ 0;
				body1.processX(x, (float?)(object)1, left: false, right);
				return 1;
			}
		}
		goto IL_043f;
		IL_032f:
		if (!body2MovingLeft || !body1OnLeft)
		{
			goto IL_0439;
		}
		BaseBody baseBody2 = body1;
		if (body1 != null)
		{
			object obj4 = baseBody2._blocked & 4;
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
				body2.processX(overlap, (float?)(object)1, left: true, right);
				return 2;
			}
		}
		goto IL_043f;
		IL_0439:
		return 0;
		IL_0210:
		if (!body2MovingRight || !body2OnLeft)
		{
			goto IL_032f;
		}
		BaseBody baseBody3 = body1;
		if (body1 != null)
		{
			object obj7 = baseBody3._blocked & 8;
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
				float x2 = num2 ^ 0;
				body2.processX(x2, (float?)(object)1, left: false, right);
				return 2;
			}
		}
		goto IL_043f;
		IL_0106:
		if (!body1MovingLeft || !body2OnLeft)
		{
			goto IL_0210;
		}
		BaseBody baseBody4 = body2;
		if (body2 != null)
		{
			object obj10 = baseBody4._blocked & 4;
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
				body1.processX(overlap, (float?)(object)1, left: true, right);
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
		//IL_034a: Expected I4, but got O
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Expected O, but got Unknown
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0070: Expected O, but got Unknown
		//IL_0097: Expected O, but got I4
		//IL_00b2: Expected O, but got I8
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0107: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Expected O, but got Unknown
		//IL_0140: Expected O, but got I4
		//IL_015b: Expected O, but got I8
		BaseBody baseBody = body1;
		if (body1 != null)
		{
			BaseBody baseBody2 = body2;
			if (body2 != null)
			{
				BaseBody baseBody3 = body1;
				object obj = baseBody2._velocity * baseBody2._velocity;
				object obj2 = obj * baseBody2._mass;
				object obj3 = obj2 / baseBody3._mass;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
				bool flag = (nint)baseBody2._velocity > 0;
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
						object obj6 = baseBody._velocity * baseBody._velocity;
						object obj7 = obj6 * baseBody4._mass;
						object obj8 = obj7 / baseBody5._mass;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1850045F0");
						bool flag2 = (nint)baseBody._velocity > 0;
						object obj9 = 1;
						if (!flag2)
						{
							obj9 = 4294967295L;
						}
						BaseBody baseBody6 = body1;
						object obj10 = obj9 * obj8;
						object obj11 = obj10 + obj5;
						float num = (float)obj11 * 0.5f;
						if (body1 != null)
						{
							float num2 = (float)obj5 - num;
							float num3 = num2 * (float)baseBody6._bounce;
							float num4 = num3 + num;
							body1MassImpact = num4;
							BaseBody baseBody7 = body2;
							if (body2 != null)
							{
								float num5 = (float)obj10 - num;
								float num6 = num5 * (float)baseBody7._bounce;
								float num7 = num6 + num;
								body2MassImpact = num7;
								int side;
								if (body1MovingLeft && body2OnLeft)
								{
									side = 0;
								}
								else if (body2MovingLeft && body1OnLeft)
								{
									side = 1;
								}
								else if (body1MovingRight && body1OnLeft)
								{
									side = 2;
								}
								else
								{
									if (!body2MovingRight || !body2OnLeft)
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
		//IL_0961: Expected I4, but got O
		//IL_090f: Expected O, but got I4
		//IL_0223: Unknown result type (might be due to invalid IL or missing references)
		//IL_0228: Expected F4, but got Unknown
		//IL_0231: Expected O, but got I4
		//IL_0140: Expected O, but got I4
		//IL_093f: Expected F4, but got I4
		//IL_0948: Expected O, but got I4
		//IL_0491: Expected O, but got I4
		//IL_0858: Expected O, but got I4
		//IL_0178: Unknown result type (might be due to invalid IL or missing references)
		//IL_017d: Expected F4, but got Unknown
		//IL_0186: Expected O, but got I4
		//IL_04c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cd: Expected F4, but got Unknown
		//IL_04d6: Expected O, but got I4
		//IL_0634: Unknown result type (might be due to invalid IL or missing references)
		//IL_0639: Expected F4, but got Unknown
		//IL_0654: Expected O, but got I4
		//IL_06c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_06c8: Expected F4, but got Unknown
		//IL_06e4: Expected O, but got I4
		//IL_0260: Expected O, but got I4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected F4, but got Unknown
		//IL_00c7: Expected O, but got I4
		//IL_079e: Unknown result type (might be due to invalid IL or missing references)
		//IL_07a3: Expected F4, but got Unknown
		//IL_07bf: Expected O, but got I4
		//IL_0407: Expected O, but got I4
		//IL_068e: Expected O, but got I4
		//IL_071f: Expected O, but got I4
		//IL_0100: Expected O, but got I4
		//IL_051e: Expected O, but got I4
		//IL_043e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Expected F4, but got Unknown
		//IL_0454: Expected O, but got I4
		//IL_0817: Expected O, but got I4
		//IL_05c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c8: Expected F4, but got Unknown
		//IL_05e4: Expected O, but got I4
		//IL_061e: Expected O, but got I4
		bool right = default(bool);
		BaseBody baseBody;
		float x2;
		float? vx;
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
						float x = num2 ^ 0;
						body1.processX(x, (float?)(object)1, left: false, right);
						baseBody = body2;
						if (body2 != null)
						{
							x2 = overlap;
							vx = (float?)(object)1;
							goto IL_097f;
						}
					}
				}
				else if (body1 != null)
				{
					body1.processX(overlap, (float?)(object)1, left: false, right);
					baseBody = body2;
					if (body2 != null)
					{
						float num3 = overlap;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						x2 = num3 ^ 0;
						vx = (float?)(object)1;
						goto IL_097f;
					}
				}
				goto IL_0953;
			}
			if (body1Pushable)
			{
				if (!body2Pushable)
				{
					if (side != 0 && side != 3)
					{
						baseBody = body1;
						goto IL_09ab;
					}
					baseBody2 = body1;
					goto IL_09e5;
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
			goto IL_09e5;
		}
		baseBody = body2;
		goto IL_09ab;
		IL_0459:
		BaseBody baseBody3;
		float num4;
		if (baseBody3 != null)
		{
			baseBody3.processX(num4, (float?)(object)1, left: true, right);
			baseBody = body2;
			if (body2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float num5 = num4 ^ 0;
				vx = (float?)(object)1;
				x2 = num5;
				goto IL_097f;
			}
		}
		goto IL_0953;
		IL_097f:
		baseBody.processX(x2, vx, left: false, right);
		goto IL_094d;
		IL_09c8:
		BaseBody baseBody4;
		if (baseBody4 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
			float x3 = num4 ^ 0;
			baseBody4.processX(x3, (float?)(object)1, left: false, right);
			if (body2 != null)
			{
				body2.processX(num4, (float?)(object)1, left: true, right);
				return true;
			}
		}
		goto IL_0953;
		IL_0a02:
		float? num7;
		if (baseBody3 != null)
		{
			baseBody3.processX(num4, (float?)(object)1, left: true, right);
			baseBody = body2;
			if (body2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float num6 = num4 ^ 0;
				x2 = num6;
				num7 = (float?)(object)0;
				goto IL_099e;
			}
		}
		goto IL_0953;
		IL_09ab:
		if (baseBody == null)
		{
			goto IL_0953;
		}
		float num8 = overlap;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
		x2 = num8 ^ 0;
		vx = (float?)(object)1;
		goto IL_097f;
		IL_02fb:
		num4 = overlap * 0.5f;
		if (side != 0)
		{
			if (side != 1)
			{
				if (side != 2)
				{
					if (side != 3)
					{
						goto IL_094d;
					}
					baseBody3 = body1;
					if (!body1Stationary)
					{
						if (body1MovingLeft)
						{
							goto IL_0459;
						}
						if (body2 != null)
						{
							goto IL_0a02;
						}
					}
					else if (body1 != null)
					{
						body1.processX(0f, (float?)(object)0, left: true, right);
						baseBody = body2;
						goto IL_09ab;
					}
				}
				else
				{
					baseBody4 = body1;
					if (!body2Stationary)
					{
						if (body2MovingLeft)
						{
							goto IL_09c8;
						}
						if (body2 != null && body1 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
							float x4 = num4 ^ 0;
							body1.processX(x4, (float?)(object)1, left: false, right);
							if (body2 != null)
							{
								body2.processX(num4, (float?)(object)0, left: true, right);
								return true;
							}
						}
					}
					else if (body1 != null)
					{
						float num9 = overlap;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						float x5 = num9 ^ 0;
						body1.processX(x5, (float?)(object)1, left: false, right);
						if (body2 != null)
						{
							body2.processX(0f, (float?)(object)0, left: true, right);
							return true;
						}
					}
				}
			}
			else
			{
				baseBody4 = body1;
				if (!body1Stationary)
				{
					if (body1MovingRight)
					{
						goto IL_09c8;
					}
					if (body1 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
						float x6 = num4 ^ 0;
						body1.processX(x6, (float?)(object)0, left: false, right);
						if (body1 != null && body2 != null)
						{
							body2.processX(num4, (float?)(object)1, left: true, right);
							return true;
						}
					}
				}
				else if (body1 != null)
				{
					body1.processX(0f, (float?)(object)0, left: false, right);
					baseBody2 = body2;
					goto IL_09e5;
				}
			}
		}
		else
		{
			baseBody3 = body1;
			if (!body2Stationary)
			{
				if (body2MovingRight)
				{
					goto IL_0459;
				}
				if (body2 != null)
				{
					goto IL_0a02;
				}
			}
			else if (body1 != null)
			{
				body1.processX(overlap, (float?)(object)1, left: true, right);
				baseBody = body2;
				if (body2 != null)
				{
					x2 = 0f;
					num7 = (float?)(object)0;
					goto IL_099e;
				}
			}
		}
		goto IL_0953;
		IL_099e:
		vx = num7;
		goto IL_097f;
		IL_0953:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_09e5:
		if (baseBody2 != null)
		{
			baseBody2.processX(overlap, (float?)(object)1, left: true, right);
			return true;
		}
		goto IL_0953;
		IL_094d:
		return true;
	}

	public static void RunImmovableBody1(int blockedState)
	{
		//IL_00a5: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected F4, but got Unknown
		//IL_0058: Expected O, but got I4
		//IL_00bd: Expected I, but got O
		//IL_00c5: Expected I, but got O
		//IL_00d5: Expected O, but got I
		//IL_0155: Expected O, but got I4
		//IL_0111: Expected O, but got I
		//IL_0147: Expected O, but got I4
		//IL_019c: Expected O, but got I
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01e7: Expected I, but got O
		//IL_01ef: Expected I, but got O
		//IL_01ff: Expected O, but got I
		//IL_023b: Expected O, but got I
		BaseBody baseBody;
		if (blockedState != 1)
		{
			bool right = default(bool);
			if (!body1OnLeft)
			{
				float num = overlap;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float x = num ^ 0;
				body2.processX(x, (float?)(object)1, left: false, right);
				baseBody = null;
			}
			else
			{
				body2.processX(overlap, (float?)(object)1, left: true, right);
				baseBody = null;
			}
		}
		else
		{
			BaseBody baseBody2 = body2;
			baseBody2._velocity = (float2)0;
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
				goto IL_02dd;
			}
		}
		obj3 = 0;
		goto IL_02dd;
		IL_02dd:
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
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v7 (BaseBody)+54]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (BaseBody)+CC]");
		object obj4 = num5 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (BaseBody)+118]");
		object obj5 = obj4 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v5 (BaseBody)+54]");
		object obj6 = obj5 + 0;
		BaseBody baseBody6 = body2;
		nint num6 = (nint)typeof(Body);
		nint num7 = (nint)baseBody6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppClass<Body>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r9_v5 (Il2CppClass<BaseBody>)+130]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppClass<Body>)+130]");
		if (num8 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r9_v5 (Il2CppClass<BaseBody>)+C8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v12+FFFFFFF8+v282 @ rax_v11*8]");
			if (0 == (nint)typeof(Body))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r10_v4 (BaseBody)+54]");
				float num9 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r10_v4 (BaseBody)+CC]");
				float dy = num9 - 0f;
				baseBody6._dy = dy;
				return;
			}
		}
		throw new InvalidCastException();
	}

	public static void RunImmovableBody2(int blockedState)
	{
		//IL_00a5: Expected O, but got I4
		//IL_007f: Expected O, but got I4
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Expected F4, but got Unknown
		//IL_0058: Expected O, but got I4
		//IL_00bd: Expected I, but got O
		//IL_00c5: Expected I, but got O
		//IL_00d5: Expected O, but got I
		//IL_0155: Expected O, but got I4
		//IL_0111: Expected O, but got I
		//IL_0147: Expected O, but got I4
		//IL_019c: Expected O, but got I
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Expected O, but got Unknown
		//IL_01c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01c6: Expected O, but got Unknown
		//IL_01e7: Expected I, but got O
		//IL_01ef: Expected I, but got O
		//IL_01ff: Expected O, but got I
		//IL_023b: Expected O, but got I
		BaseBody baseBody;
		if (blockedState != 2)
		{
			bool right = default(bool);
			if (!body2OnLeft)
			{
				float num = overlap;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A128D0]");
				float x = num ^ 0;
				body1.processX(x, (float?)(object)1, left: false, right);
				baseBody = null;
			}
			else
			{
				body1.processX(overlap, (float?)(object)1, left: true, right);
				baseBody = null;
			}
		}
		else
		{
			BaseBody baseBody2 = body1;
			baseBody2._velocity = (float2)0;
			baseBody = null;
		}
		BaseBody baseBody3 = body2;
		if (body2 == null)
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
				goto IL_02dd;
			}
		}
		obj3 = 0;
		goto IL_02dd;
		IL_02dd:
		if (obj3 != null)
		{
			baseBody = body2;
		}
		if (baseBody == null)
		{
			return;
		}
		BaseBody baseBody4 = body1;
		BaseBody baseBody5 = body2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v382 @ rcx_v7 (BaseBody)+54]");
		nint num5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (BaseBody)+CC]");
		object obj4 = num5 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v135 @ rbx_v6 (BaseBody)+118]");
		object obj5 = obj4 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rdx_v5 (BaseBody)+54]");
		object obj6 = obj5 + 0;
		BaseBody baseBody6 = body1;
		nint num6 = (nint)typeof(Body);
		nint num7 = (nint)baseBody6;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppClass<Body>)+130]");
		object obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r9_v5 (Il2CppClass<BaseBody>)+130]");
		nint num8 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ rdx_v6 (Il2CppClass<Body>)+130]");
		if (num8 >= 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v226 @ r9_v5 (Il2CppClass<BaseBody>)+C8]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v12+FFFFFFF8+v282 @ rax_v11*8]");
			if (0 == (nint)typeof(Body))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r10_v4 (BaseBody)+54]");
				float num9 = 0f;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ r10_v4 (BaseBody)+CC]");
				float dy = num9 - 0f;
				baseBody6._dy = dy;
				return;
			}
		}
		throw new InvalidCastException();
	}
}
