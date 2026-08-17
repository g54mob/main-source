using System;
using Cpp2ILInjected;
using UnityEngine;

namespace Doozy.Engine.UI.Animation;

[Serializable]
public class UIAnimation
{
	public AnimationType AnimationType;

	public Move Move;

	public Rotate Rotate;

	public Scale Scale;

	public Fade Fade;

	public bool Enabled
	{
		get
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 15 Invalid \"Jump target not found in method: 0x182BEB3CB\"");
			return (byte)AnimationType != 0;
		}
	}

	public float StartDelay
	{
		get
		{
			//IL_037d: Expected F4, but got I4
			//IL_02ab: Expected O, but got I4
			//IL_02bb: Expected O, but got I4
			//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
			//IL_02c9: Expected O, but got Unknown
			//IL_0323: Expected O, but got I4
			//IL_0468: Unknown result type (might be due to invalid IL or missing references)
			//IL_046d: Expected O, but got Unknown
			//IL_0477: Unknown result type (might be due to invalid IL or missing references)
			//IL_047c: Expected O, but got Unknown
			//IL_0486: Unknown result type (might be due to invalid IL or missing references)
			//IL_048b: Expected O, but got Unknown
			if (!Enabled)
			{
				goto IL_0374;
			}
			float[] array = new float[4];
			Move move = Move;
			float result;
			if (Move != null)
			{
				float num = ((!move.Enabled) ? 10000f : move.StartDelay);
				bool flag = array == null;
				float num2 = 10000f;
				if (!flag)
				{
					bool flag2 = array.Length <= 0;
					num2 = 10000f;
					if (!flag2)
					{
						array[0] = num;
						Rotate rotate = Rotate;
						bool flag3 = Rotate == null;
						num2 = 10000f;
						if (flag3)
						{
							goto IL_03b1;
						}
						float num3 = ((!rotate.Enabled) ? 10000f : rotate.StartDelay);
						bool flag4 = array.Length <= 1;
						num2 = 10000f;
						if (!flag4)
						{
							array[1] = num3;
							Scale scale = Scale;
							bool flag5 = Scale == null;
							num2 = 10000f;
							if (flag5)
							{
								goto IL_03b1;
							}
							float num4 = ((!scale.Enabled) ? 10000f : scale.StartDelay);
							bool flag6 = array.Length <= 2;
							num2 = 10000f;
							if (!flag6)
							{
								array[2] = num4;
								Fade fade = Fade;
								bool flag7 = Fade == null;
								num2 = 10000f;
								if (flag7)
								{
									goto IL_03b1;
								}
								bool flag8 = !fade.Enabled;
								num2 = 10000f;
								if (!flag8)
								{
									num2 = fade.StartDelay;
								}
								if (array.Length > 3)
								{
									array[3] = num2;
									if (array.Length == 0)
									{
										goto IL_0374;
									}
									if (array.Length > 0)
									{
										result = array[0];
										object obj = 1 - array.Length;
										object obj2 = 1 ^ array.Length;
										object obj3 = 1 ^ obj;
										object obj4 = obj2 & obj3;
										bool flag9 = (nint)obj4 < 0;
										bool flag10 = (nint)obj < 0;
										bool flag11 = 1 >= array.Length;
										num2 = array[0];
										object obj5 = 1;
										if (flag11)
										{
											goto IL_045a;
										}
										while (flag10 != flag9)
										{
											if (num2 > array[obj5])
											{
												num2 = array[obj5];
											}
											obj5++;
											object obj6 = obj5 - array.Length;
											object obj7 = obj5 ^ array.Length;
											object obj8 = obj5 ^ obj6;
											object obj9 = obj7 & obj8;
											flag9 = (nint)obj9 < 0;
											flag10 = (nint)obj6 < 0;
											if ((nint)obj5 >= array.Length)
											{
												return num2;
											}
										}
									}
								}
							}
						}
					}
					throw new IndexOutOfRangeException();
				}
			}
			goto IL_03b1;
			IL_0374:
			result = 0f;
			goto IL_045a;
			IL_045a:
			return result;
			IL_03b1:
			throw new NullReferenceException();
		}
	}

	public float TotalDuration
	{
		get
		{
			//IL_004e: Expected F4, but got I4
			//IL_00f9: Expected F4, but got I4
			//IL_0182: Expected F4, but got I4
			//IL_020b: Expected F4, but got I4
			//IL_023c: Expected F4, but got I4
			//IL_028e: Expected O, but got I4
			//IL_029e: Expected O, but got I4
			//IL_02a7: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ac: Expected O, but got Unknown
			//IL_02f4: Expected O, but got I4
			//IL_045e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0463: Expected O, but got Unknown
			//IL_046d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0472: Expected O, but got Unknown
			//IL_047c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0481: Expected O, but got Unknown
			float[] array = new float[4];
			Move move = Move;
			float result;
			if (Move != null)
			{
				float num = ((!move.Enabled) ? 0f : (move.Duration + move.StartDelay));
				if (array != null)
				{
					if (array.Length > 0)
					{
						Rotate rotate = Rotate;
						array[0] = num;
						if (Rotate == null)
						{
							goto IL_0384;
						}
						num = ((!rotate.Enabled) ? 0f : (rotate.Duration + rotate.StartDelay));
						if (array.Length > 1)
						{
							Scale scale = Scale;
							array[1] = num;
							if (Scale == null)
							{
								goto IL_0384;
							}
							num = ((!scale.Enabled) ? 0f : (scale.Duration + scale.StartDelay));
							if (array.Length > 2)
							{
								Fade fade = Fade;
								array[2] = num;
								if (Fade == null)
								{
									goto IL_0384;
								}
								num = ((!fade.Enabled) ? 0f : (fade.Duration + fade.StartDelay));
								if (array.Length > 3)
								{
									array[3] = num;
									bool flag = array.Length == 0;
									result = 0f;
									if (flag)
									{
										goto IL_037f;
									}
									if (array.Length > 0)
									{
										float num2 = array[0];
										object obj = 1 - array.Length;
										object obj2 = 1 ^ array.Length;
										object obj3 = 1 ^ obj;
										object obj4 = obj2 & obj3;
										bool flag2 = (nint)obj4 < 0;
										bool flag3 = (nint)obj < 0;
										bool flag4 = 1 >= array.Length;
										object obj5 = 1;
										result = array[0];
										if (flag4)
										{
											goto IL_037f;
										}
										while (flag3 != flag2)
										{
											num = array[obj5];
											if (array[obj5] > num2)
											{
												num2 = array[obj5];
											}
											obj5++;
											object obj6 = obj5 - array.Length;
											object obj7 = obj5 ^ array.Length;
											object obj8 = obj5 ^ obj6;
											object obj9 = obj7 & obj8;
											flag2 = (nint)obj9 < 0;
											flag3 = (nint)obj6 < 0;
											bool flag5 = (nint)obj5 < array.Length;
											result = num2;
											if (flag5)
											{
												continue;
											}
											goto IL_037f;
										}
									}
								}
							}
						}
					}
					throw new IndexOutOfRangeException();
				}
			}
			goto IL_0384;
			IL_0384:
			throw new NullReferenceException();
			IL_037f:
			return result;
		}
	}

	public UIAnimation(AnimationType animationType)
	{
		Reset(animationType);
	}

	public UIAnimation(AnimationType animationType, Move move, Rotate rotate, Scale scale, Fade fade)
	{
		Reset(animationType);
		Move = move;
		Rotate = rotate;
		Scale scale2 = default(Scale);
		Scale = scale2;
		Fade fade2 = default(Fade);
		Fade = fade2;
	}

	public void Reset(AnimationType animationType)
	{
		AnimationType = animationType;
		Move move = new Move(animationType);
		Move = move;
		Rotate rotate = new Rotate(animationType);
		Rotate = rotate;
		Scale scale = new Scale(animationType);
		Scale = scale;
		Fade fade = new Fade(animationType);
		Fade = fade;
	}

	public UIAnimation Copy()
	{
		UIAnimation uIAnimation = null;
		uIAnimation.Reset(AnimationType);
		if (uIAnimation != null)
		{
			uIAnimation.AnimationType = AnimationType;
			Move move = Move;
			if (Move != null)
			{
				Move move2 = new Move(move.AnimationType);
				if (move2 != null)
				{
					move2.AnimationType = move.AnimationType;
					move2.Enabled = move.Enabled;
					move2.From = move.From;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbp_v2 (Doozy.Engine.UI.Animation.Move)+20]");
					_ = 0;
					move2.To = move.To;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbp_v2 (Doozy.Engine.UI.Animation.Move)+2C]");
					_ = 0;
					move2.By = move.By;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbp_v2 (Doozy.Engine.UI.Animation.Move)+38]");
					_ = 0;
					move2.UseCustomFromAndTo = move.UseCustomFromAndTo;
					move2.Vibrato = move.Vibrato;
					move2.Elasticity = move.Elasticity;
					move2.NumberOfLoops = move.NumberOfLoops;
					move2.LoopType = move.LoopType;
					move2.Direction = move.Direction;
					move2.CustomPosition = move.CustomPosition;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rbp_v2 (Doozy.Engine.UI.Animation.Move)+5C]");
					_ = 0;
					move2.EaseType = move.EaseType;
					move2.Ease = move.Ease;
					if (move.AnimationCurve != null)
					{
						Keyframe[] keys = move.AnimationCurve.GetKeys();
						AnimationCurve animationCurve = new AnimationCurve();
						IntPtr ptr = AnimationCurve.Internal_Create(keys);
						animationCurve.m_Ptr = ptr;
						animationCurve.m_RequiresNativeCleanup = true;
						move2.AnimationCurve = animationCurve;
						move2.StartDelay = move.StartDelay;
						move2.Duration = move.Duration;
						uIAnimation.Move = move2;
						Rotate rotate = Rotate;
						if (Rotate != null)
						{
							Rotate rotate2 = new Rotate(rotate.AnimationType);
							if (rotate2 != null)
							{
								rotate2.AnimationType = rotate.AnimationType;
								rotate2.Enabled = rotate.Enabled;
								rotate2.From = rotate.From;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbp_v3 (Doozy.Engine.UI.Animation.Rotate)+20]");
								_ = 0;
								rotate2.To = rotate.To;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbp_v3 (Doozy.Engine.UI.Animation.Rotate)+2C]");
								_ = 0;
								rotate2.By = rotate.By;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rbp_v3 (Doozy.Engine.UI.Animation.Rotate)+38]");
								_ = 0;
								rotate2.UseCustomFromAndTo = rotate.UseCustomFromAndTo;
								rotate2.Vibrato = rotate.Vibrato;
								rotate2.Elasticity = rotate.Elasticity;
								rotate2.NumberOfLoops = rotate.NumberOfLoops;
								rotate2.LoopType = rotate.LoopType;
								rotate2.RotateMode = rotate.RotateMode;
								rotate2.EaseType = rotate.EaseType;
								rotate2.Ease = rotate.Ease;
								if (rotate.AnimationCurve != null)
								{
									Keyframe[] keys2 = rotate.AnimationCurve.GetKeys();
									AnimationCurve animationCurve2 = new AnimationCurve();
									IntPtr ptr2 = AnimationCurve.Internal_Create(keys2);
									animationCurve2.m_Ptr = ptr2;
									animationCurve2.m_RequiresNativeCleanup = true;
									rotate2.AnimationCurve = animationCurve2;
									rotate2.StartDelay = rotate.StartDelay;
									rotate2.Duration = rotate.Duration;
									uIAnimation.Rotate = rotate2;
									Scale scale = Scale;
									if (Scale != null)
									{
										Scale scale2 = new Scale(scale.AnimationType);
										if (scale2 != null)
										{
											scale2.AnimationType = scale.AnimationType;
											scale2.Enabled = scale.Enabled;
											scale2.From = scale.From;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbp_v4 (Doozy.Engine.UI.Animation.Scale)+20]");
											_ = 0;
											scale2.To = scale.To;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbp_v4 (Doozy.Engine.UI.Animation.Scale)+2C]");
											_ = 0;
											scale2.By = scale.By;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v98 @ rbp_v4 (Doozy.Engine.UI.Animation.Scale)+38]");
											_ = 0;
											scale2.UseCustomFromAndTo = scale.UseCustomFromAndTo;
											scale2.Vibrato = scale.Vibrato;
											scale2.Elasticity = scale.Elasticity;
											scale2.NumberOfLoops = scale.NumberOfLoops;
											scale2.LoopType = scale.LoopType;
											scale2.EaseType = scale.EaseType;
											scale2.Ease = scale.Ease;
											if (scale.AnimationCurve != null)
											{
												Keyframe[] keys3 = scale.AnimationCurve.GetKeys();
												AnimationCurve animationCurve3 = new AnimationCurve();
												IntPtr ptr3 = AnimationCurve.Internal_Create(keys3);
												animationCurve3.m_Ptr = ptr3;
												animationCurve3.m_RequiresNativeCleanup = true;
												scale2.AnimationCurve = animationCurve3;
												scale2.StartDelay = scale.StartDelay;
												scale2.Duration = scale.Duration;
												uIAnimation.Scale = scale2;
												Fade fade = Fade;
												if (Fade != null)
												{
													Fade fade2 = new Fade(fade.AnimationType);
													if (fade2 != null)
													{
														fade2.AnimationType = fade.AnimationType;
														fade2.Enabled = fade.Enabled;
														fade2.From = fade.From;
														fade2.To = fade.To;
														fade2.By = fade.By;
														fade2.UseCustomFromAndTo = fade.UseCustomFromAndTo;
														fade2.NumberOfLoops = fade.NumberOfLoops;
														fade2.LoopType = fade.LoopType;
														fade2.EaseType = fade.EaseType;
														fade2.Ease = fade.Ease;
														if (fade.AnimationCurve != null)
														{
															Keyframe[] keys4 = fade.AnimationCurve.GetKeys();
															AnimationCurve animationCurve4 = new AnimationCurve();
															IntPtr ptr4 = AnimationCurve.Internal_Create(keys4);
															animationCurve4.m_Ptr = ptr4;
															animationCurve4.m_RequiresNativeCleanup = true;
															fade2.AnimationCurve = animationCurve4;
															fade2.StartDelay = fade.StartDelay;
															fade2.Duration = fade.Duration;
															uIAnimation.Fade = fade2;
															return uIAnimation;
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
		return (UIAnimation)(object)new NullReferenceException();
	}
}
