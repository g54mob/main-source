using System;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.NumberTypes;
using Zenject;

namespace VampireSurvivors.Objects.Characters;

public class C1_Ghost : CharacterController
{
	public override bool GetDamaged(float damageAmount)
	{
		//IL_0077: Invalid comparison between I4 and F4
		//IL_0099: Invalid comparison between F4 and I4
		//IL_0775: Expected O, but got I4
		//IL_07b5: Expected I4, but got O
		//IL_00e4: Invalid comparison between F4 and I4
		//IL_06d2: Expected O, but got I4
		//IL_01be: Expected O, but got I4
		//IL_0400: Invalid comparison between F4 and I4
		//IL_0498: Unknown result type (might be due to invalid IL or missing references)
		//IL_049d: Expected O, but got Unknown
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04cc: Expected O, but got Unknown
		//IL_05a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Expected O, but got Unknown
		//IL_0519: Invalid comparison between F4 and I4
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Expected O, but got Unknown
		_isInvul = true;
		if (_receivingDamage || _isInvul || base._isDead || base.IsDisconnectedFromOnlinePlay || !(0f < base._currentHp))
		{
			goto IL_0703;
		}
		object obj = default(object);
		float num;
		SignalBus signalBus;
		C1_Ghost c1_Ghost;
		float num10;
		bool flag8;
		object obj4;
		if (!(Barrier_Number > 0f))
		{
			PlayerModifierStats playerStats = _playerStats;
			if (_playerStats != null)
			{
				if (!(playerStats._003CShields_003Ek__BackingField > 0f))
				{
					GameManager core = GM.Core;
					if ((object)GM.Core != null)
					{
						Stage stage = core._stage;
						if ((object)core._stage != null)
						{
							StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
							if (stage._003CStageMods_003Ek__BackingField != null)
							{
								bool flag = (nint)obj < 0;
								bool flag2 = obj == null;
								bool flag3 = !flag;
								bool flag4 = !flag2;
								object obj2 = flag4 & flag3;
								object obj3 = (object?)stageModifiers._003CEndCycles_003Ek__BackingField & obj2;
								bool flag5 = obj3 == null;
								num = damageAmount;
								if (flag5)
								{
									goto IL_07b5;
								}
								GameManager core2 = GM.Core;
								if ((object)GM.Core != null)
								{
									Stage stage2 = core2._stage;
									if ((object)core2._stage != null && stage2._003CStageMods_003Ek__BackingField != null)
									{
										if ((object)stageModifiers._003CEndCycles_003Ek__BackingField == null)
										{
											goto IL_077a;
										}
										float num2 = (float)obj * 0.25f;
										float num3 = num2 + 1f;
										float num4 = num3 * damageAmount;
										float num5 = base.MaxHp();
										bool flag6 = !(num4 > num4);
										num = num4;
										if (!flag6)
										{
											float num6 = base.MaxHp();
											float num7 = num4 - 1f;
											bool flag7 = 10f > num7;
											num = 10f;
											if (!flag7)
											{
												num = num7;
											}
										}
										goto IL_07b5;
									}
								}
							}
						}
					}
				}
				else if (_playerStats != null)
				{
					float num8 = --playerStats._003CShields_003Ek__BackingField;
					float num9 = base.PShieldTime();
					base.OnGetDamaged("#ffffbb", num8, playDamageFx: false);
					signalBus = _signalBus;
					c1_Ghost = this;
					num10 = num8;
					flag8 = false;
					obj4 = 0;
					goto IL_06d7;
				}
			}
			goto IL_07a7;
		}
		float num11 = --Barrier_Number;
		float num12 = base.PShieldTime();
		base.OnGetDamaged("#ffffbb", num11, playDamageFx: false);
		signalBus = _signalBus;
		c1_Ghost = this;
		num10 = num11;
		flag8 = false;
		obj4 = 0;
		goto IL_06d7;
		IL_07a7:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_077a:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		goto IL_07a7;
		IL_0815:
		float num13;
		num -= num13;
		if (1f > num)
		{
			num = 1f;
		}
		goto IL_07fd;
		IL_06d7:
		if (signalBus != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AB1980");
			goto IL_0703;
		}
		goto IL_07a7;
		IL_07fd:
		TakeDamage(num);
		return true;
		IL_07b5:
		PlayerModifierStats playerStats2 = _playerStats;
		if (_playerStats != null)
		{
			GameManager core3 = GM.Core;
			if ((object)GM.Core != null)
			{
				Stage stage3 = core3._stage;
				if ((object)core3._stage != null)
				{
					StageModifiers stageModifiers2 = stage3._003CStageMods_003Ek__BackingField;
					if (stage3._003CStageMods_003Ek__BackingField != null)
					{
						if ((object)stageModifiers2._003CEndCycles_003Ek__BackingField == null)
						{
							goto IL_077a;
						}
						float num14 = playerStats2._003CShroud_003Ek__BackingField - (float)obj;
						if (num14 > 0f && num > num14)
						{
							num = num14;
						}
						if (_playerStats != null)
						{
							EggFloat eggFloat = playerStats2._003CArmor_003Ek__BackingField;
							if (playerStats2._003CArmor_003Ek__BackingField != null)
							{
								float num15 = eggFloat._eggVal + eggFloat._val;
								object obj5 = num15 & -2147483649L;
								if ((nint)obj5 != 2139095040)
								{
									object obj6 = num15 & -2147483649L;
									if ((nint)obj6 <= 2139095040)
									{
										bool flag9 = num15 == -1f / 0f;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875D700Bh\"");
										if (flag9 || !(num15 > 0f))
										{
											goto IL_07fd;
										}
									}
								}
								if (_playerStats != null)
								{
									EggFloat eggFloat2 = playerStats2._003CArmor_003Ek__BackingField;
									if (playerStats2._003CArmor_003Ek__BackingField != null)
									{
										num13 = eggFloat2._eggVal + eggFloat2._val;
										object obj7 = num13 & -2147483649L;
										if ((nint)obj7 != 2139095040)
										{
											object obj8 = num13 & -2147483649L;
											if ((nint)obj8 <= 2139095040)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 00000001875D7067h\"");
												if (num13 == -1f / 0f)
												{
													num13 = -3.4028235E+38f;
												}
												goto IL_0815;
											}
										}
										num13 = 3.4028235E+38f;
										goto IL_0815;
									}
								}
							}
						}
					}
				}
			}
		}
		goto IL_07a7;
		IL_0703:
		return false;
	}

	protected override void OnStop()
	{
		if (_wiggleTween != null)
		{
			_wiggleTween.Pause();
		}
		base.angle = 0f;
	}

	protected override void OnUpdate()
	{
		//IL_0043: Expected F4, but got I4
		//IL_0089: Expected F4, but got I4
		//IL_00fc: Invalid comparison between F4 and O
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_011f: Expected O, but got Unknown
		base.OnUpdate();
		PlayerModifierStats playerStats = _playerStats;
		EggFloat eggFloat = playerStats._003CPower_003Ek__BackingField;
		float val = ((0 > 2139095040) ? 3.4028235E+38f : 0f);
		eggFloat._val = val;
		PlayerModifierStats playerStats2 = _playerStats;
		EggFloat eggFloat2 = playerStats2._003CPower_003Ek__BackingField;
		bool flag = 0 <= 2139095040;
		float eggVal = 0f;
		if (!flag)
		{
			eggVal = 3.4028235E+38f;
		}
		eggFloat2._eggVal = eggVal;
		if (!base._isDead && !base.IsDisconnectedFromOnlinePlay)
		{
			GameManager core = GM.Core;
			Stage stage = core._stage;
			StageModifiers stageModifiers = stage._003CStageMods_003Ek__BackingField;
			float num = core._003CSurvivedSeconds_003Ek__BackingField;
			object obj = default(object);
			bool flag2 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj);
			bool flag3 = !flag2;
			object obj2 = (_003F?)stageModifiers._003CTimeLimit_003Ek__BackingField & flag3;
			if (obj2 != null)
			{
				PlayerModifierStats playerStats3 = _playerStats;
				playerStats3._003CRevivals_003Ek__BackingField.Val = 0.0;
				Die();
			}
		}
	}

	public override bool ShouldCollideWithWalls()
	{
		return false;
	}
}
