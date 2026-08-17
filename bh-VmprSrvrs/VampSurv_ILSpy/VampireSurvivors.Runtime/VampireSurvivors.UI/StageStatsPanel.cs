using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Cpp2ILInjected;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.App.Objects;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Stage;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI;

public class StageStatsPanel : MonoBehaviour
{
	private sealed class _003CWaitAndCheckPages_003Ed__24(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public StageStatsPanel _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_02b7: Expected I4, but got O
			//IL_0175: Unknown result type (might be due to invalid IL or missing references)
			//IL_017a: Expected I4, but got Unknown
			StageStatsPanel stageStatsPanel = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					StageStatUI description = stageStatsPanel._Description;
					if (stageStatsPanel._Description != null && (object)description.Value != null)
					{
						description.Value.ForceMeshUpdate();
						StageStatUI description2 = stageStatsPanel._Description;
						if (stageStatsPanel._Description != null && (object)description2.Name != null)
						{
							TMP_TextInfo textInfo = description2.Name.textInfo;
							if (textInfo != null)
							{
								int num = _003C_003E4__this + 160;
								stageStatsPanel._pageCount = textInfo.pageCount;
								string text = ((int*)num)->ToString();
								string message = "Page Count : " + text;
								Debug.Log(message);
								if (stageStatsPanel._pageCount > 1)
								{
									goto IL_02a3;
								}
								if ((object)stageStatsPanel._PreviousPage != null)
								{
									GameObject gameObject = stageStatsPanel._PreviousPage.gameObject;
									if ((object)gameObject != null)
									{
										gameObject.SetActive(value: false);
										if ((object)stageStatsPanel._NextPage != null)
										{
											GameObject gameObject2 = stageStatsPanel._NextPage.gameObject;
											if ((object)gameObject2 != null)
											{
												gameObject2.SetActive(value: false);
												goto IL_02a3;
											}
										}
									}
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_02a3;
			IL_02a3:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private StageStatUI _TimeLimit;

	private StageStatUI _ClockSpeed;

	private StageStatUI _MoveSpeed;

	private StageStatUI _GoldBonus;

	private StageStatUI _LuckBonus;

	private StageStatUI _EnemyHealth;

	private StageStatUI _Description;

	private StageStatUI _XPBonus;

	private GameObject _DescriptionPage;

	private Button _PreviousPage;

	private Button _NextPage;

	private StageData _currentStage;

	private StageType _currentType;

	private bool _hyperSelected;

	private bool _hurrySelected;

	private bool _inverseSelected;

	private Color _darkRed;

	private PlayerOptions _playerOptions;

	private int _pageCount;

	public void SetHyper(bool b)
	{
		_hyperSelected = b;
	}

	public void SetHurry(bool b)
	{
		_hurrySelected = b;
	}

	public void SetInverse(bool b)
	{
		_inverseSelected = b;
	}

	public void SetPlayerOptions(PlayerOptions playerOptions)
	{
		_playerOptions = playerOptions;
	}

	public void Refresh()
	{
		//IL_00b3: Expected O, but got I4
		SetTimeLimit();
		SetClockSpeed();
		SetMoveSpeed();
		SetGoldBonus();
		SetLuckBonus();
		SetEnemyHealth();
		SetDescription();
		SetXPBonus();
		List<StageStatUI> list = new List<StageStatUI>();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1250");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1250");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1250");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1250");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1250");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1250");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1250");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1250");
		List<StageStatUI>.Enumerator enumerator = default(List<StageStatUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private IEnumerator WaitAndCheckPages()
	{
		_003CWaitAndCheckPages_003Ed__24 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private bool ShowHyperInfo()
	{
		//IL_00af: Expected I4, but got O
		StageData currentStage = _currentStage;
		if (_currentStage != null)
		{
			StageModifiers stageModifiers = currentStage._003Chyper_003Ek__BackingField;
			if (currentStage._003Chyper_003Ek__BackingField != null)
			{
				if (stageModifiers._003Cunlocked_003Ek__BackingField)
				{
					bool flag = !_hyperSelected;
					return !flag;
				}
				return false;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public void SetStage(StageData stage, StageType t, PlayerOptions playerOptions)
	{
		PlayerOptionsData config = playerOptions.Config;
		_hurrySelected = config._003CSelectedHurry_003Ek__BackingField;
		PlayerOptionsData config2 = playerOptions.Config;
		_hyperSelected = config2._003CSelectedHyper_003Ek__BackingField;
		PlayerOptionsData config3 = playerOptions.Config;
		_inverseSelected = config3._003CSelectedInverse_003Ek__BackingField;
		_currentStage = stage;
		_currentType = t;
	}

	private unsafe void SetTimeLimit()
	{
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Expected O, but got Unknown
		//IL_0138: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Expected O, but got Unknown
		//IL_0171: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Expected O, but got Unknown
		//IL_01a2: Expected O, but got I8
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d9: Expected O, but got Unknown
		//IL_01e2: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Expected I4, but got Unknown
		//IL_01ff: Expected O, but got Ref
		//IL_021a: Expected O, but got Ref
		//IL_025a: Expected O, but got Ref
		//IL_028c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0291: Expected O, but got Unknown
		//IL_029e: Expected I4, but got O
		//IL_02b7: Expected O, but got Ref
		StageData currentStage = _currentStage;
		if (currentStage._003Cunlocked_003Ek__BackingField)
		{
			StageModifiers stageModifiers = currentStage._003Chyper_003Ek__BackingField;
			if (stageModifiers._003Cunlocked_003Ek__BackingField && _hyperSelected)
			{
				if ((object)stageModifiers._003CTimeLimit_003Ek__BackingField == null)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					throw new NullReferenceException();
				}
			}
			else
			{
				StageModifiers stageModifiers2 = currentStage._003Cmods_003Ek__BackingField;
				if ((object)stageModifiers2._003CTimeLimit_003Ek__BackingField == null)
				{
					goto IL_0351;
				}
			}
			StageModifiers stageModifiers3 = currentStage._003Cmods_003Ek__BackingField;
			if ((object)stageModifiers3._003CTimeLimit_003Ek__BackingField != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvttss2si ebx,dword ptr [rsp+64h]\"");
				object obj2 = default(object);
				object obj = obj2 * 1000;
				object obj3 = 922337203685477L + obj;
				if ((long)obj3 <= 1844674407370954L)
				{
					StageStatUI timeLimit = _TimeLimit;
					object obj4 = obj * 10000;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul rbx\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul rdi\"");
					object obj5 = 1844674407370954L + 27487790;
					object obj6 = obj5 >> 5;
					object obj7 = obj6 >> 63;
					object obj8 = obj6 + obj7;
					object obj9 = obj8 * 60;
					int value = 27487790 - obj9;
					object obj10 = default(object);
					string text = System.Number.FormatInt32(value, (ReadOnlySpan<char>)(&obj10), null);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul rbx\"");
					object obj11 = (ref *(_003F*)obj4) + (ref *(_003F*)(&obj10));
					object obj12 = obj11 >> 23;
					object obj13 = obj12 >> 63;
					object obj14 = obj12 + obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"imul rdi\"");
					object obj15 = (ref *(_003F*)(&obj10)) + (ref *(_003F*)obj14);
					object obj16 = obj15 >> 5;
					object obj17 = obj16 >> 63;
					object obj18 = obj16 + obj17;
					object obj19 = obj18 * 60;
					int value2 = obj14 - obj19;
					if ("00" != null)
					{
					}
					string text2 = System.Number.FormatInt32(value2, (ReadOnlySpan<char>)(&obj10), null);
					string text3 = text + ":" + text2;
					timeLimit.Value.text = text3;
					return;
				}
				ArgumentOutOfRangeException ex = new ArgumentOutOfRangeException(null, "TimeSpan overflowed because the duration is too long.");
				ex._002Ector(null, "TimeSpan overflowed because the duration is too long.");
				throw ex;
			}
			goto IL_0351;
		}
		StageStatUI timeLimit2 = _TimeLimit;
		timeLimit2.Value.text = "--:--";
		return;
		IL_0351:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private unsafe void SetClockSpeed()
	{
		//IL_02bd: Expected O, but got Ref
		//IL_00e4: Expected O, but got I4
		//IL_00d6: Expected O, but got I4
		//IL_018b: Invalid comparison between F4 and I4
		//IL_01b4: Expected O, but got I4
		//IL_01f5: Expected O, but got Ref
		//IL_022c: Invalid comparison between F4 and I4
		//IL_0255: Expected O, but got I4
		//IL_027c: Expected O, but got I4
		//IL_0297: Expected O, but got Ref
		StageData currentStage = _currentStage;
		object obj3 = default(object);
		if (currentStage._003Cunlocked_003Ek__BackingField)
		{
			StageModifiers stageModifiers = currentStage._003Chyper_003Ek__BackingField;
			float? num;
			if (stageModifiers._003Cunlocked_003Ek__BackingField && _hyperSelected)
			{
				num = stageModifiers._003CClockSpeed_003Ek__BackingField;
			}
			else
			{
				StageModifiers stageModifiers2 = currentStage._003Cmods_003Ek__BackingField;
				num = stageModifiers2._003CClockSpeed_003Ek__BackingField;
			}
			if (_hurrySelected)
			{
				num = (float?)(((object)num == null) ? ((object)0) : ((object)1));
			}
			StageStatUI clockSpeed = _ClockSpeed;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189984D76]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			float num2 = default(float);
			string text = (((object)num == null) ? "" : num2.ToString());
			string text2 = "x" + text;
			clockSpeed.Value.text = text2;
			StageStatUI clockSpeed2 = _ClockSpeed;
			bool flag = num2 < 1f;
			float num3 = num2 - 1f;
			bool flag2 = num3 == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			object obj = flag4 & flag3;
			object obj2 = (object?)num & obj;
			if (obj2 != null)
			{
			}
			clockSpeed2.Value.color = (Color)(&obj3);
			StageStatUI clockSpeed3 = _ClockSpeed;
			bool flag5 = num2 < 1f;
			float num4 = num2 - 1f;
			bool flag6 = num4 == 0f;
			bool flag7 = !flag5;
			bool flag8 = !flag6;
			object obj4 = flag8 & flag7;
			object obj5 = (object?)num & obj4;
			bool flag9 = obj5 == null;
			object obj6 = !flag9;
			if (obj6 == null)
			{
			}
			clockSpeed3.Name.color = (Color)(&obj3);
		}
		else
		{
			StageStatUI clockSpeed4 = _ClockSpeed;
			clockSpeed4.Value.color = (Color)(&obj3);
			StageStatUI clockSpeed5 = _ClockSpeed;
			clockSpeed5.Value.text = "--";
		}
	}

	private void SetMoveSpeed()
	{
		//IL_0229: Invalid comparison between F4 and I4
		StageData currentStage = _currentStage;
		if (currentStage._003Cunlocked_003Ek__BackingField)
		{
			StageModifiers stageModifiers = currentStage._003Cmods_003Ek__BackingField;
			float num2 = default(float);
			float num = (((object)stageModifiers._003CPlayerPxSpeed_003Ek__BackingField == null) ? 1f : num2);
			if (_hyperSelected)
			{
				StageData currentStage2 = _currentStage;
				StageModifiers stageModifiers2 = currentStage2._003Chyper_003Ek__BackingField;
				if (stageModifiers2._003Cunlocked_003Ek__BackingField && (object)stageModifiers2._003CPlayerPxSpeed_003Ek__BackingField != null)
				{
					if ((object)stageModifiers2._003CPlayerPxSpeed_003Ek__BackingField == null)
					{
						goto IL_02b4;
					}
					float num3 = num2 + num;
					num = num3;
				}
			}
			if (_inverseSelected)
			{
				StageData currentStage3 = _currentStage;
				if (currentStage3._003Cinverse_003Ek__BackingField != null)
				{
					StageModifiers stageModifiers3 = currentStage3._003Cinverse_003Ek__BackingField;
					if (stageModifiers3._003Cunlocked_003Ek__BackingField && (object)stageModifiers3._003CPlayerPxSpeed_003Ek__BackingField != null)
					{
						if ((object)stageModifiers3._003CPlayerPxSpeed_003Ek__BackingField == null)
						{
							goto IL_02b4;
						}
						num += num2;
					}
				}
			}
			StageStatUI moveSpeed = _MoveSpeed;
			float num4 = num - 1f;
			float num5 = num4 * 100f;
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			string text = System.Number.FormatSingle(num5, null, currentInfo);
			string text2 = "+" + text + "%";
			moveSpeed.Value.text = text2;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp short 0000000186DADCDBh\"");
			if (num5 != 0f)
			{
				return;
			}
		}
		StageStatUI moveSpeed2 = _MoveSpeed;
		moveSpeed2.Value.text = "--";
		return;
		IL_02b4:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private unsafe void SetGoldBonus()
	{
		//IL_043d: Expected O, but got Ref
		//IL_046e: Expected F4, but got I
		//IL_04f5: Expected O, but got Ref
		//IL_021e: Expected O, but got I4
		//IL_0278: Expected O, but got I4
		//IL_02a5: Expected O, but got I
		//IL_02ca: Expected O, but got I4
		//IL_0322: Expected F4, but got I
		//IL_0511: Expected O, but got Ref
		//IL_03f5: Expected F4, but got I
		StageData currentStage = _currentStage;
		float num;
		if (currentStage._003Cunlocked_003Ek__BackingField)
		{
			StageModifiers stageModifiers = currentStage._003Cmods_003Ek__BackingField;
			float num2 = default(float);
			num = (((object)stageModifiers._003CGoldMultiplier_003Ek__BackingField == null) ? 1f : num2);
			if (_hyperSelected)
			{
				StageData currentStage2 = _currentStage;
				StageModifiers stageModifiers2 = currentStage2._003Chyper_003Ek__BackingField;
				if (stageModifiers2._003Cunlocked_003Ek__BackingField && (object)stageModifiers2._003CGoldMultiplier_003Ek__BackingField != null)
				{
					if ((object)stageModifiers2._003CGoldMultiplier_003Ek__BackingField == null)
					{
						goto IL_04c0;
					}
					float num3 = num2 + num;
					num = num3;
				}
			}
			if (_inverseSelected)
			{
				StageData currentStage3 = _currentStage;
				if (currentStage3._003Cinverse_003Ek__BackingField != null)
				{
					StageModifiers stageModifiers3 = currentStage3._003Cinverse_003Ek__BackingField;
					if (stageModifiers3._003Cunlocked_003Ek__BackingField && (object)stageModifiers3._003CGoldMultiplier_003Ek__BackingField != null)
					{
						if ((object)stageModifiers3._003CGoldMultiplier_003Ek__BackingField == null)
						{
							goto IL_04c0;
						}
						num += num2;
					}
				}
			}
			int playerCount = MultiplayerManager.s_instance.GetPlayerCount();
			PlayerOptions s_instance;
			object obj;
			if (playerCount <= 1)
			{
				bool isOnlineMultiplayer = MultiplayerManager.s_instance.IsOnlineMultiplayer;
				bool flag = !isOnlineMultiplayer;
				obj = 0;
				s_instance = (PlayerOptions)(object)MultiplayerManager.s_instance;
				if (flag)
				{
					goto IL_04cb;
				}
			}
			s_instance = _playerOptions;
			PlayerOptionsData config = _playerOptions.Config;
			bool flag2 = config._003CSelectedSharePassives_003Ek__BackingField;
			obj = 0;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18695F8A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v38+20]");
				object obj2 = 0;
				float num4 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v132 @ rax_v39+B4]");
				num = num4 + 0f;
				obj = 0;
			}
			goto IL_04cb;
		}
		StageStatUI goldBonus = _GoldBonus;
		goldBonus.Value.text = "--";
		StageStatUI goldBonus2 = _GoldBonus;
		float num5 = default(float);
		goldBonus2.Value.color = (Color)(&num5);
		StageStatUI goldBonus3 = _GoldBonus;
		TextMeshProUGUI textMeshProUGUI = goldBonus3.Name;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
		num5 = 0f;
		goto IL_04e8;
		IL_04cb:
		TextMeshProUGUI value;
		float num6;
		if (!(num > 1f))
		{
			StageStatUI goldBonus4 = _GoldBonus;
			goldBonus4.Value.text = "--";
			StageStatUI goldBonus5 = _GoldBonus;
			value = goldBonus5.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			num6 = 0f;
		}
		else
		{
			float num7 = num - 1f;
			float num8 = num7 * 100f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
			StageStatUI goldBonus6 = _GoldBonus;
			NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
			float value2 = default(float);
			string text = System.Number.FormatSingle(value2, null, currentInfo);
			string text2 = "+" + text + "%";
			goldBonus6.Value.text = text2;
			StageStatUI goldBonus7 = _GoldBonus;
			value = goldBonus7.Value;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12030]");
			num6 = 0f;
		}
		value.color = (Color)(&num5);
		StageStatUI goldBonus8 = _GoldBonus;
		textMeshProUGUI = goldBonus8.Name;
		num5 = num6;
		goto IL_04e8;
		IL_04c0:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		return;
		IL_04e8:
		textMeshProUGUI.color = (Color)(&num5);
	}

	private unsafe void SetLuckBonus()
	{
		//IL_030c: Expected O, but got Ref
		//IL_033d: Expected F4, but got I
		//IL_03c9: Expected O, but got Ref
		//IL_03a8: Invalid comparison between F4 and I4
		//IL_0215: Expected F4, but got I
		//IL_03e5: Expected O, but got Ref
		//IL_02c4: Expected F4, but got I
		StageData currentStage = _currentStage;
		float num5 = default(float);
		TextMeshProUGUI textMeshProUGUI;
		if (currentStage._003Cunlocked_003Ek__BackingField)
		{
			StageModifiers stageModifiers = currentStage._003Cmods_003Ek__BackingField;
			float num2 = default(float);
			float num = (((object)stageModifiers._003CLuckBonus_003Ek__BackingField == null) ? 1f : num2);
			if (_hyperSelected)
			{
				StageData currentStage2 = _currentStage;
				StageModifiers stageModifiers2 = currentStage2._003Chyper_003Ek__BackingField;
				if (stageModifiers2._003Cunlocked_003Ek__BackingField && (object)stageModifiers2._003CLuckBonus_003Ek__BackingField != null)
				{
					if ((object)stageModifiers2._003CLuckBonus_003Ek__BackingField == null)
					{
						goto IL_038f;
					}
					float num3 = num2 + num;
					num = num3;
				}
			}
			if (_inverseSelected)
			{
				StageData currentStage3 = _currentStage;
				if (currentStage3._003Cinverse_003Ek__BackingField != null)
				{
					StageModifiers stageModifiers3 = currentStage3._003Cinverse_003Ek__BackingField;
					if (stageModifiers3._003Cunlocked_003Ek__BackingField && (object)stageModifiers3._003CLuckBonus_003Ek__BackingField != null)
					{
						if ((object)stageModifiers3._003CLuckBonus_003Ek__BackingField == null)
						{
							goto IL_038f;
						}
						num += num2;
					}
				}
			}
			StageStatUI luckBonus = _LuckBonus;
			TextMeshProUGUI value;
			float num4;
			if (!(num > 0f))
			{
				luckBonus.Value.text = "--";
				StageStatUI luckBonus2 = _LuckBonus;
				value = luckBonus2.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				num4 = 0f;
			}
			else
			{
				float value2 = num * 100f;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				string text = System.Number.FormatSingle(value2, null, currentInfo);
				string text2 = "+" + text + "%";
				luckBonus.Value.text = text2;
				StageStatUI luckBonus3 = _LuckBonus;
				value = luckBonus3.Value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12030]");
				num4 = 0f;
			}
			value.color = (Color)(&num5);
			StageStatUI luckBonus4 = _LuckBonus;
			textMeshProUGUI = luckBonus4.Name;
			num5 = num4;
		}
		else
		{
			StageStatUI luckBonus5 = _LuckBonus;
			luckBonus5.Value.text = "--";
			StageStatUI luckBonus6 = _LuckBonus;
			luckBonus6.Value.color = (Color)(&num5);
			StageStatUI luckBonus7 = _LuckBonus;
			textMeshProUGUI = luckBonus7.Name;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			num5 = 0f;
		}
		textMeshProUGUI.color = (Color)(&num5);
		return;
		IL_038f:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private unsafe void SetEnemyHealth()
	{
		//IL_0339: Expected O, but got Ref
		//IL_036a: Expected F4, but got I
		//IL_03f6: Expected O, but got Ref
		//IL_0205: Expected O, but got Ref
		//IL_0236: Expected F4, but got I
		//IL_02c6: Expected O, but got Ref
		//IL_02f1: Expected F4, but got O
		StageData currentStage = _currentStage;
		float num4 = default(float);
		TextMeshProUGUI textMeshProUGUI;
		if (currentStage._003Cunlocked_003Ek__BackingField)
		{
			StageModifiers stageModifiers = currentStage._003Cmods_003Ek__BackingField;
			float num2 = default(float);
			float num = (((object)stageModifiers._003CEnemyHealthMultiplier_003Ek__BackingField == null) ? 1f : num2);
			if (_hyperSelected)
			{
				StageData currentStage2 = _currentStage;
				StageModifiers stageModifiers2 = currentStage2._003Chyper_003Ek__BackingField;
				if (stageModifiers2._003Cunlocked_003Ek__BackingField && (object)stageModifiers2._003CEnemyHealthMultiplier_003Ek__BackingField != null)
				{
					if ((object)stageModifiers2._003CEnemyHealthMultiplier_003Ek__BackingField == null)
					{
						goto IL_03bc;
					}
					float num3 = num2 + num;
					num = num3;
				}
			}
			if (_inverseSelected)
			{
				StageData currentStage3 = _currentStage;
				if (currentStage3._003Cinverse_003Ek__BackingField != null)
				{
					StageModifiers stageModifiers3 = currentStage3._003Cinverse_003Ek__BackingField;
					if (stageModifiers3._003Cunlocked_003Ek__BackingField && (object)stageModifiers3._003CEnemyHealthMultiplier_003Ek__BackingField != null)
					{
						if ((object)stageModifiers3._003CEnemyHealthMultiplier_003Ek__BackingField == null)
						{
							goto IL_03bc;
						}
						num += num2;
					}
				}
			}
			StageStatUI enemyHealth = _EnemyHealth;
			if (!(num > 1f))
			{
				enemyHealth.Value.text = "--";
				StageStatUI enemyHealth2 = _EnemyHealth;
				enemyHealth2.Value.color = (Color)(&num4);
				StageStatUI enemyHealth3 = _EnemyHealth;
				textMeshProUGUI = enemyHealth3.Name;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
				num4 = 0f;
			}
			else
			{
				float num5 = num - 1f;
				float value = num5 * 100f;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				string text = System.Number.FormatSingle(value, null, currentInfo);
				string text2 = "+" + text + "%";
				enemyHealth.Value.text = text2;
				StageStatUI enemyHealth4 = _EnemyHealth;
				enemyHealth4.Value.color = (Color)(&num4);
				StageStatUI enemyHealth5 = _EnemyHealth;
				textMeshProUGUI = enemyHealth5.Name;
				num4 = (float)_darkRed;
			}
		}
		else
		{
			StageStatUI enemyHealth6 = _EnemyHealth;
			enemyHealth6.Value.text = "--";
			StageStatUI enemyHealth7 = _EnemyHealth;
			enemyHealth7.Value.color = (Color)(&num4);
			StageStatUI enemyHealth8 = _EnemyHealth;
			textMeshProUGUI = enemyHealth8.Name;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A12500]");
			num4 = 0f;
		}
		textMeshProUGUI.color = (Color)(&num4);
		return;
		IL_03bc:
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private unsafe void SetDescription()
	{
		//IL_0518: Unknown result type (might be due to invalid IL or missing references)
		//IL_051d: Expected Ref, but got Unknown
		//IL_0534: Expected I8, but got I4
		//IL_053d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0542: Expected Ref, but got Unknown
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_0655: Expected Ref, but got Unknown
		//IL_066c: Expected I8, but got I4
		//IL_067a: Unknown result type (might be due to invalid IL or missing references)
		//IL_067f: Expected Ref, but got Unknown
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected Ref, but got Unknown
		//IL_01a8: Expected I8, but got I4
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b6: Expected Ref, but got Unknown
		//IL_02c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c9: Expected Ref, but got Unknown
		//IL_02e0: Expected I8, but got I4
		//IL_02ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_02f3: Expected Ref, but got Unknown
		StageData currentStage = _currentStage;
		string Translation;
		string text;
		string Translation2;
		string text2;
		if (currentStage._003Cunlocked_003Ek__BackingField)
		{
			StageModifiers stageModifiers = currentStage._003Chyper_003Ek__BackingField;
			bool ignoreRTLnumbers = default(bool);
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			if (stageModifiers._003Cunlocked_003Ek__BackingField && _hyperSelected)
			{
				string localizedTips = _currentStage.GetLocalizedTips(_currentType);
				if (LocalizationManager.TryGetTranslation(localizedTips, out Translation, FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage))
				{
					object obj = "";
					if ((object)Translation == "")
					{
						goto IL_01ec;
					}
					bool flag = Translation == null;
					text = Translation;
					if (!flag)
					{
						bool flag2 = "" == null;
						text = Translation;
						if (!flag2)
						{
							int stringLength = Translation._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rsi_v7+10]");
							bool flag3 = (nint)stringLength != 0;
							text = Translation;
							if (!flag3)
							{
								ref byte second = ref *(byte*)("" + 20);
								ulong length = (ulong)(Translation._stringLength + Translation._stringLength);
								bool flag4 = System.SpanHelpers.SequenceEqual(ref *(byte*)(Translation + 20), ref second, length);
								bool flag5 = !flag4;
								text = Translation;
								if (!flag5)
								{
									goto IL_01ec;
								}
							}
						}
					}
					goto IL_074f;
				}
			}
			else
			{
				string localizedTips2 = _currentStage.GetLocalizedTips(_currentType);
				if (LocalizationManager.TryGetTranslation(localizedTips2, out Translation2, FixForRTL: true, 0, ignoreRTLnumbers, applyParameters, localParametersRoot, overrideLanguage))
				{
					object obj2 = "";
					if ((object)Translation2 == "")
					{
						goto IL_0578;
					}
					bool flag6 = Translation2 == null;
					text2 = Translation2;
					if (!flag6)
					{
						bool flag7 = "" == null;
						text2 = Translation2;
						if (!flag7)
						{
							int stringLength2 = Translation2._stringLength;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rsi_v6+10]");
							bool flag8 = (nint)stringLength2 != 0;
							text2 = Translation2;
							if (!flag8)
							{
								ref byte second2 = ref *(byte*)("" + 20);
								ulong length2 = (ulong)(Translation2._stringLength + Translation2._stringLength);
								bool flag9 = System.SpanHelpers.SequenceEqual(ref *(byte*)(Translation2 + 20), ref second2, length2);
								bool flag10 = !flag9;
								text2 = Translation2;
								if (!flag10)
								{
									goto IL_0578;
								}
							}
						}
					}
					goto IL_075f;
				}
			}
		}
		goto IL_03df;
		IL_03b4:
		string text3;
		if (text3.Contains("Missing Translation"))
		{
			goto IL_03df;
		}
		return;
		IL_0578:
		StageData currentStage2 = _currentStage;
		bool flag11 = currentStage2._003Ctips_003Ek__BackingField == null;
		Translation2 = "--";
		text2 = "--";
		if (!flag11)
		{
			string text4 = currentStage2._003Ctips_003Ek__BackingField;
			bool flag12 = (object)currentStage2._003Ctips_003Ek__BackingField == "";
			Translation2 = "--";
			text2 = "--";
			if (!flag12)
			{
				if ("" != null)
				{
					int stringLength3 = text4._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rsi_v6+10]");
					if ((nint)stringLength3 == 0)
					{
						ref byte second3 = ref *(byte*)("" + 20);
						ulong length3 = (ulong)(text4._stringLength + text4._stringLength);
						bool flag13 = System.SpanHelpers.SequenceEqual(ref *(byte*)(currentStage2._003Ctips_003Ek__BackingField + 20), ref second3, length3);
						Translation2 = "--";
						text2 = "--";
						if (flag13)
						{
							goto IL_075f;
						}
					}
				}
				string localizedTips3 = _currentStage.GetLocalizedTips(_currentType);
				string message = "Missing Translation: " + localizedTips3 + ". Defaulting to EN from StageData";
				Debug.LogWarning(message);
				StageData currentStage3 = _currentStage;
				text2 = currentStage3._003Ctips_003Ek__BackingField;
				Translation2 = currentStage3._003Ctips_003Ek__BackingField;
			}
		}
		goto IL_075f;
		IL_03df:
		StageStatUI description = _Description;
		description.Name.text = "--";
		return;
		IL_075f:
		StageStatUI description2 = _Description;
		description2.Name.text = text2;
		text3 = Translation2;
		goto IL_03b4;
		IL_01ec:
		StageData currentStage4 = _currentStage;
		bool flag14 = currentStage4._003Ctips_003Ek__BackingField == null;
		text = "--";
		Translation = "--";
		if (!flag14)
		{
			string text5 = currentStage4._003Ctips_003Ek__BackingField;
			bool flag15 = (object)currentStage4._003Ctips_003Ek__BackingField == "";
			text = "--";
			Translation = "--";
			if (!flag15)
			{
				if ("" != null)
				{
					int stringLength4 = text5._stringLength;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ rsi_v7+10]");
					if ((nint)stringLength4 == 0)
					{
						ref byte second4 = ref *(byte*)("" + 20);
						ulong length4 = (ulong)(text5._stringLength + text5._stringLength);
						bool flag16 = System.SpanHelpers.SequenceEqual(ref *(byte*)(currentStage4._003Ctips_003Ek__BackingField + 20), ref second4, length4);
						text = "--";
						Translation = "--";
						if (flag16)
						{
							goto IL_074f;
						}
					}
				}
				string localizedTips4 = _currentStage.GetLocalizedTips(_currentType);
				string message2 = "Missing Translation: " + localizedTips4 + ". Defaulting to EN from StageData";
				Debug.LogWarning(message2);
				StageData currentStage5 = _currentStage;
				text = currentStage5._003Ctips_003Ek__BackingField;
				Translation = currentStage5._003Ctips_003Ek__BackingField;
			}
		}
		goto IL_074f;
		IL_074f:
		StageStatUI description3 = _Description;
		description3.Name.text = text;
		text3 = Translation;
		goto IL_03b4;
	}

	private unsafe void SetXPBonus()
	{
		//IL_0066: Expected F4, but got I4
		//IL_006f: Expected F4, but got I4
		//IL_034e: Expected O, but got Ref
		//IL_0295: Expected O, but got Ref
		//IL_02f4: Expected O, but got Ref
		StageData currentStage = _currentStage;
		if (currentStage._003Cunlocked_003Ek__BackingField)
		{
			float num;
			float num2;
			if (_hurrySelected)
			{
				num = 0.25f;
				num2 = 0.25f;
			}
			else
			{
				num = 0f;
				num2 = 0f;
			}
			StageModifiers stageModifiers = currentStage._003Cmods_003Ek__BackingField;
			if ((object)stageModifiers._003CXpBonus_003Ek__BackingField != null)
			{
				StageData currentStage2 = _currentStage;
				StageModifiers stageModifiers2 = currentStage2._003Cmods_003Ek__BackingField;
				if ((object)stageModifiers2._003CXpBonus_003Ek__BackingField == null)
				{
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					return;
				}
				object obj = default(object);
				num = (float)obj + num2;
			}
			StageStatUI xPBonus = _XPBonus;
			xPBonus.Value.text = "--";
			TextMeshProUGUI value;
			string text;
			string text2;
			if (!(1f > num))
			{
				if (!(num > 1f))
				{
					goto IL_0389;
				}
				StageStatUI xPBonus2 = _XPBonus;
				float num3 = num - 1f;
				value = xPBonus2.Value;
				float value2 = num3 * 100f;
				NumberFormatInfo currentInfo = NumberFormatInfo.CurrentInfo;
				text = System.Number.FormatSingle(value2, null, currentInfo);
				text2 = "+";
			}
			else
			{
				StageStatUI xPBonus3 = _XPBonus;
				float num4 = 1f - num;
				value = xPBonus3.Value;
				float value3 = num4 * 100f;
				NumberFormatInfo currentInfo2 = NumberFormatInfo.CurrentInfo;
				text = System.Number.FormatSingle(value3, null, currentInfo2);
				text2 = "-";
			}
			string text3 = text2 + text + "%";
			value.text = text3;
			goto IL_0389;
		}
		StageStatUI xPBonus4 = _XPBonus;
		xPBonus4.Value.text = "--";
		StageStatUI xPBonus5 = _XPBonus;
		TextMeshProUGUI textMeshProUGUI = xPBonus5.Value;
		float num5 = default(float);
		Color color = (Color)(&num5);
		goto IL_03f4;
		IL_03f4:
		textMeshProUGUI.color = color;
		return;
		IL_03cf:
		string hex;
		Color color2 = ColourHelper.HexToColor(hex);
		StageStatUI xPBonus6;
		xPBonus6.Value.color = (Color)(&num5);
		StageStatUI xPBonus7 = _XPBonus;
		TextMeshProUGUI textMeshProUGUI2 = xPBonus7.Name;
		bool flag = _hurrySelected;
		string hex2 = "0x00ffff";
		if (!flag)
		{
			hex2 = "0xffffff";
		}
		Color color3 = ColourHelper.HexToColor(hex2);
		color = (Color)(&num5);
		textMeshProUGUI = textMeshProUGUI2;
		goto IL_03f4;
		IL_0389:
		xPBonus6 = _XPBonus;
		if (_hurrySelected)
		{
			StageData currentStage3 = _currentStage;
			StageModifiers stageModifiers3 = currentStage3._003Chyper_003Ek__BackingField;
			bool flag2 = stageModifiers3._003Cunlocked_003Ek__BackingField;
			hex = "0x00ffff";
			if (flag2)
			{
				goto IL_03cf;
			}
		}
		hex = "0xffffff";
		goto IL_03cf;
	}

	public StageStatsPanel()
	{
		//IL_0012: Expected O, but got I
		//IL_0027: Expected I, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [188A11F90]");
		_darkRed = (Color)0;
		nint num = (nint)typeof(UnityEngine.Object);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rcx_v2 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
		}
	}
}
