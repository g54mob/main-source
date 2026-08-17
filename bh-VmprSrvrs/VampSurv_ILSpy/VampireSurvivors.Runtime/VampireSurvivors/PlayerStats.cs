using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Extensions;
using VampireSurvivors.Data;
using VampireSurvivors.Data.PowerUp;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors;

public class PlayerStats : IInitializable, IDisposable
{
	private DataManager _dataManager;

	private PlayerOptions _playerOptions;

	private SignalBus _signalBus;

	private int _totalPowerUpCount;

	private readonly Dictionary<PowerUpType, PlayerStat> _stats;

	public unsafe double PowerUpMarkUp
	{
		get
		{
			//IL_0027: Expected F8, but got I4
			//IL_00ee: Invalid comparison between F8 and I4
			//IL_0035: Expected O, but got I4
			//IL_003d: Expected O, but got Ref
			//IL_00a5: Expected F8, but got I4
			PlayerOptionsData config = _playerOptions.Config;
			double num = 0.0;
			List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
			if (enumerator.MoveNext())
			{
				object obj = 0;
				List<PowerUpLevel>.Enumerator enumerator2 = (List<PowerUpLevel>.Enumerator)(&enumerator);
				throw new NullReferenceException();
			}
			if (num != 0.0)
			{
				double d = Math.Pow(1.100000023841858, num);
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A108A8h]\"");
				return Math.Floor(d);
			}
			return 0.0;
		}
	}

	public void Initialize()
	{
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptions.OnValueChanged b = Refresh;
		if (_playerOptions == null)
		{
			goto IL_01cd;
		}
		Delegate obj = playerOptions.PowerUpPurchased;
		object obj2 = _playerOptions + 24;
		while (true)
		{
			Delegate obj3 = Delegate.Combine(obj, b);
			bool flag = (object)obj3 == null;
			Delegate obj4 = null;
			if (!flag)
			{
				bool flag2 = (object)obj3.GetType() != typeof(PlayerOptions.OnValueChanged);
				obj4 = null;
				if (!flag2)
				{
					obj4 = obj3;
				}
				if ((object)obj4 == null)
				{
					break;
				}
			}
			bool flag3 = obj == obj2;
			Delegate obj5;
			if (obj == obj2)
			{
				obj2 = obj4;
				obj5 = obj;
			}
			else
			{
				obj5 = (Delegate)obj2;
			}
			Delegate obj6 = obj;
			if (!flag3)
			{
				obj6 = obj5;
			}
			bool flag4 = (object)obj6 != obj;
			obj = obj6;
			if (flag4)
			{
				continue;
			}
			goto IL_00c9;
		}
		goto IL_0326;
		IL_01cd:
		NullReferenceException ex = new NullReferenceException();
		goto IL_0332;
		IL_00c9:
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptions.OnValueChanged b2 = ResetPowerUps;
		if (_playerOptions == null)
		{
			goto IL_01cd;
		}
		Delegate obj7 = playerOptions2.PowerUpsRefunded;
		object obj8 = _playerOptions + 32;
		while (true)
		{
			Delegate obj9 = Delegate.Combine(obj7, b2);
			bool flag5 = (object)obj9 == null;
			Delegate obj10 = null;
			if (!flag5)
			{
				bool flag6 = (object)obj9.GetType() != typeof(PlayerOptions.OnValueChanged);
				obj10 = null;
				if (!flag6)
				{
					obj10 = obj9;
				}
				if ((object)obj10 == null)
				{
					break;
				}
			}
			bool flag7 = obj7 == obj8;
			Delegate obj11;
			if (obj7 == obj8)
			{
				obj8 = obj10;
				obj11 = obj7;
			}
			else
			{
				obj11 = (Delegate)obj8;
			}
			Delegate obj12 = obj7;
			if (!flag7)
			{
				obj12 = obj11;
			}
			bool flag8 = (object)obj12 != obj7;
			obj7 = obj12;
			if (!flag8)
			{
				return;
			}
		}
		goto IL_0332;
		IL_0332:
		InvalidCastException ex2 = new InvalidCastException();
		goto IL_0326;
		IL_0326:
		throw new InvalidCastException();
	}

	public void Dispose()
	{
		//IL_022e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0233: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		PlayerOptions playerOptions = _playerOptions;
		PlayerOptions.OnValueChanged value = Refresh;
		if (_playerOptions == null)
		{
			goto IL_01cd;
		}
		Delegate obj = playerOptions.PowerUpPurchased;
		object obj2 = _playerOptions + 24;
		while (true)
		{
			Delegate obj3 = Delegate.Remove(obj, value);
			bool flag = (object)obj3 == null;
			Delegate obj4 = null;
			if (!flag)
			{
				bool flag2 = (object)obj3.GetType() != typeof(PlayerOptions.OnValueChanged);
				obj4 = null;
				if (!flag2)
				{
					obj4 = obj3;
				}
				if ((object)obj4 == null)
				{
					break;
				}
			}
			bool flag3 = obj == obj2;
			Delegate obj5;
			if (obj == obj2)
			{
				obj2 = obj4;
				obj5 = obj;
			}
			else
			{
				obj5 = (Delegate)obj2;
			}
			Delegate obj6 = obj;
			if (!flag3)
			{
				obj6 = obj5;
			}
			bool flag4 = (object)obj6 != obj;
			obj = obj6;
			if (flag4)
			{
				continue;
			}
			goto IL_00c9;
		}
		goto IL_0326;
		IL_01cd:
		NullReferenceException ex = new NullReferenceException();
		goto IL_0332;
		IL_00c9:
		PlayerOptions playerOptions2 = _playerOptions;
		PlayerOptions.OnValueChanged value2 = ResetPowerUps;
		if (_playerOptions == null)
		{
			goto IL_01cd;
		}
		Delegate obj7 = playerOptions2.PowerUpsRefunded;
		object obj8 = _playerOptions + 32;
		while (true)
		{
			Delegate obj9 = Delegate.Remove(obj7, value2);
			bool flag5 = (object)obj9 == null;
			Delegate obj10 = null;
			if (!flag5)
			{
				bool flag6 = (object)obj9.GetType() != typeof(PlayerOptions.OnValueChanged);
				obj10 = null;
				if (!flag6)
				{
					obj10 = obj9;
				}
				if ((object)obj10 == null)
				{
					break;
				}
			}
			bool flag7 = obj7 == obj8;
			Delegate obj11;
			if (obj7 == obj8)
			{
				obj8 = obj10;
				obj11 = obj7;
			}
			else
			{
				obj11 = (Delegate)obj8;
			}
			Delegate obj12 = obj7;
			if (!flag7)
			{
				obj12 = obj11;
			}
			bool flag8 = (object)obj12 != obj7;
			obj7 = obj12;
			if (!flag8)
			{
				return;
			}
		}
		goto IL_0332;
		IL_0332:
		InvalidCastException ex2 = new InvalidCastException();
		goto IL_0326;
		IL_0326:
		throw new InvalidCastException();
	}

	public void InitStats()
	{
		//IL_008b: Expected O, but got I4
		_stats.Clear();
		_totalPowerUpCount = 0;
		Dictionary<PowerUpType, List<PowerUpData>> convertedPowerUpData = _dataManager.GetConvertedPowerUpData();
		Dictionary<PowerUpType, PowerUpLevel> boughtPowerUps = _playerOptions.GetBoughtPowerUps();
		Dictionary<PowerUpType, List<PowerUpData>>.Enumerator enumerator = default(Dictionary<PowerUpType, List<PowerUpData>>.Enumerator);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			bool flag = _stats == null;
			if (!flag)
			{
				int num = ((Dictionary<System.Int32Enum, object>)(object)_stats).FindEntry((System.Int32Enum)0);
				object obj = !flag;
				if (obj == null)
				{
					bool flag2 = boughtPowerUps == null;
					if (flag2)
					{
						break;
					}
					int num2 = ((Dictionary<System.Int32Enum, object>)(object)boughtPowerUps).FindEntry((System.Int32Enum)0);
					int level = 0;
					if (!flag2)
					{
						object obj2 = ((Dictionary<System.Int32Enum, object>)(object)boughtPowerUps).get_Item((System.Int32Enum)0);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v27 (System.Object)+14]");
						level = 0;
						int totalPowerUpCount = _totalPowerUpCount;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v440 @ rax_v27 (System.Object)+14]");
						int totalPowerUpCount2 = (int)((nint)totalPowerUpCount + (nint)0);
						_totalPowerUpCount = totalPowerUpCount2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm6,8\"");
					AddStat(PowerUpType.POWER, level, null);
				}
				continue;
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public float GetRefundAmount()
	{
		float totalPrice = GetTotalPrice();
		float totalMarkup = GetTotalMarkup();
		return totalMarkup + totalPrice;
	}

	public float GetPrice(PowerUpType t)
	{
		//IL_0106: Expected O, but got I
		//IL_004c: Expected O, but got I
		//IL_0143: Expected O, but got I
		//IL_0158: Expected O, but got I
		//IL_0089: Expected O, but got I
		//IL_016a: Expected F4, but got I
		//IL_009e: Expected O, but got I
		//IL_00c3: Expected O, but got I
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		object obj = ((Dictionary<System.Int32Enum, object>)(object)_stats).get_Item((System.Int32Enum)t);
		if (_totalPowerUpCount != 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v8 (System.Object)+18]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v11+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v57 @ rax_v11+10]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v8+20]");
				object obj4 = 0;
				double powerUpMarkUp = PowerUpMarkUp;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v8 (System.Object)+14]");
				object obj5 = (nint)0 + (nint)1;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rbx_v6+44]");
				object obj6 = obj5 * 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm0,xmm0\"");
				return (float)powerUpMarkUp + (float)obj6;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v8 (System.Object)+18]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v9+18]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ rax_v9+10]");
				object obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ rcx_v7+20]");
				object obj9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v10+44]");
				return 0f;
			}
		}
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		float result = default(float);
		return result;
	}

	public void Reset()
	{
		Dictionary<PowerUpType, PlayerStat>.Enumerator enumerator = default(Dictionary<PowerUpType, PlayerStat>.Enumerator);
		object obj = default(object);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj == null)
				{
					break;
				}
				_ = 0;
				continue;
			}
			return;
		}
		throw new NullReferenceException();
	}

	public Dictionary<PowerUpType, PlayerStat> GetOwnedPowerUps()
	{
		//IL_002d: Expected O, but got I4
		Dictionary<PowerUpType, PlayerStat> result = new Dictionary<PowerUpType, PlayerStat>();
		PlayerOptionsData config = _playerOptions.Config;
		List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
		return result;
	}

	public Dictionary<PowerUpType, PlayerStat> GetAllPowerUps()
	{
		return _stats;
	}

	private double ApplyMarkup(float value)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm6\"");
		double d = Math.Pow(1.100000023841858, 0.0);
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,qword ptr [188A108A8h]\"");
		return Math.Floor(d);
	}

	private unsafe float GetTotalMarkup()
	{
		//IL_027b: Expected F4, but got I4
		//IL_0042: Expected F4, but got I4
		//IL_007a: Expected F4, but got I4
		//IL_0091: Expected F4, but got I4
		//IL_009a: Expected F4, but got I4
		//IL_00b1: Expected F4, but got I8
		//IL_02c8: Invalid comparison between F4 and I4
		//IL_00bf: Expected O, but got I4
		//IL_00c7: Expected F4, but got O
		//IL_00cf: Expected O, but got Ref
		//IL_00fd: Expected F8, but got O
		bool flag = _playerOptions == null;
		float num = 0f;
		if (!flag)
		{
			PlayerOptionsData config = _playerOptions.Config;
			bool flag2 = config == null;
			num = 0f;
			if (!flag2)
			{
				List<PowerUpLevel> list = ClassUtils.Clone(config._003CBoughtPowerups_003Ek__BackingField);
				bool flag3 = list == null;
				num = 0f;
				if (!flag3)
				{
					float num2 = 0f;
					float num3 = 0f;
					List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
					object obj2 = default(object);
					object obj3 = default(object);
					while (true)
					{
						if (list._size > 0)
						{
							float num4 = 4.2949673E+09f;
							if (enumerator.MoveNext())
							{
								object obj = 0;
								num = (float)list;
								List<PowerUpLevel>.Enumerator enumerator2 = (List<PowerUpLevel>.Enumerator)(&enumerator);
								throw new NullReferenceException();
							}
							double num5;
							if (!(num4 > 0f))
							{
								num5 = (double)list;
								num2 = num3;
							}
							else
							{
								num5 = ApplyMarkup(num4);
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm0\"");
								num2 = num3;
							}
							int index = list._size - 1;
							list.RemoveAt(index);
							bool flag4 = obj2 == null;
							num = (float)num5;
							if (flag4)
							{
								break;
							}
							int index2 = list._size - 1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v20+14]");
							if ((nint)0 > (nint)1)
							{
								list.RemoveAt(index2);
								bool flag5 = obj3 == null;
								num = (float)num5;
								if (flag5)
								{
									break;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v22+14]");
								_ = -1;
								num3 = num2;
							}
							else
							{
								list.RemoveAt(index2);
								num3 = num2;
							}
							continue;
						}
						int version = list._version + 1;
						list._version = version;
						list._size = 0;
						if (list._size > 0)
						{
							Array.Clear(list._items, 0, list._size);
						}
						return num2;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private float GetTotalPrice()
	{
		//IL_0063: Expected F4, but got I4
		//IL_0084: Expected O, but got I4
		//IL_00fa: Expected O, but got I4
		//IL_01d6: Expected O, but got I
		//IL_01f9: Expected F4, but got I4
		//IL_0202: Expected F4, but got I4
		//IL_0257: Expected O, but got I
		//IL_0289: Unknown result type (might be due to invalid IL or missing references)
		//IL_028e: Expected O, but got Unknown
		//IL_029e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Expected O, but got Unknown
		if (_playerOptions != null)
		{
			PlayerOptionsData config = _playerOptions.Config;
			if (config != null)
			{
				List<PowerUpLevel> list = ClassUtils.Clone(config._003CBoughtPowerups_003Ek__BackingField);
				bool flag = list == null;
				float num2 = default(float);
				float num = num2;
				float num3 = 0f;
				if (!flag)
				{
					while (true)
					{
						float num5;
						if (list._size > 0)
						{
							object obj = list._size - 1;
							bool flag2 = (nint)obj >= list._size;
							num2 = num;
							if (!flag2)
							{
								PowerUpLevel[] items = list._items;
								bool flag3 = list._items == null;
								num2 = num;
								if (flag3)
								{
									break;
								}
								object obj2 = list._size - 1;
								bool flag4 = (nint)obj2 >= items.Length;
								num2 = num;
								if (!flag4)
								{
									PowerUpLevel powerUpLevel = items[obj2];
									bool flag5 = items[obj2] == null;
									num2 = num;
									if (flag5)
									{
										break;
									}
									bool flag6 = _stats == null;
									num2 = num;
									if (flag6)
									{
										break;
									}
									object obj3 = ((Dictionary<System.Int32Enum, object>)(object)_stats).get_Item((System.Int32Enum)powerUpLevel.PowerUp);
									bool flag7 = obj3 == null;
									num2 = num;
									if (flag7)
									{
										break;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v15 (System.Object)+14]");
									object obj4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v15 (System.Object)+14]");
									bool flag8 = (nint)0 <= (nint)0;
									float num4 = 0f;
									num5 = 0f;
									if (!flag8)
									{
										while (true)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v15 (System.Object)+18]");
											bool flag9 = (nint)0 == 0;
											num2 = num;
											if (flag9)
											{
												break;
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v86 @ rax_v15 (System.Object)+18]");
											PlayerStat playerStat = ((Dictionary<PowerUpType, PlayerStat>)0).get_Item(powerUpLevel.PowerUp);
											bool flag10 = playerStat == null;
											num2 = num;
											if (flag10)
											{
												break;
											}
											object obj5 = obj4 - 1;
											object obj6 = obj4;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rax_v19 (VampireSurvivors.PlayerStat)+44]");
											object obj7 = obj6 * 0;
											num4 += (float)obj7;
											bool flag11 = (nint)obj5 > 0;
											obj4 = obj5;
											num5 = num4;
											if (flag11)
											{
												continue;
											}
											goto IL_02df;
										}
										break;
									}
									goto IL_02df;
								}
								throw new IndexOutOfRangeException();
							}
							System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
							return num2;
						}
						int version = list._version + 1;
						list._version = version;
						list._size = 0;
						if (list._size > 0)
						{
							Array.Clear(list._items, 0, list._size);
						}
						return num3;
						IL_02df:
						int index = list._size - 1;
						num3 += num5;
						list.RemoveAt(index);
						num = num5;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void AddStat(PowerUpType type, int level, List<PowerUpData> data)
	{
		PlayerStat playerStat = new PlayerStat();
		playerStat._Type = type;
		playerStat._Level = level;
		playerStat._Data = data;
		bool flag = ((Dictionary<System.Int32Enum, object>)(object)_stats).TryInsert((System.Int32Enum)type, (object)playerStat, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
	}

	private void Refresh()
	{
		//IL_002d: Expected O, but got I4
		_totalPowerUpCount = 0;
		PlayerOptionsData config = _playerOptions.Config;
		List<PowerUpLevel>.Enumerator enumerator = default(List<PowerUpLevel>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			throw new NullReferenceException();
		}
	}

	private unsafe void ResetPowerUps()
	{
		//IL_0021: Expected O, but got Ref
		Dictionary<PowerUpType, PlayerStat>.Enumerator enumerator = default(Dictionary<PowerUpType, PlayerStat>.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			bool flag = obj == null;
			Dictionary<PowerUpType, PlayerStat>.Enumerator enumerator2 = (Dictionary<PowerUpType, PlayerStat>.Enumerator)(&enumerator);
			if (!flag)
			{
				_ = 0;
				continue;
			}
			throw new NullReferenceException();
		}
		_totalPowerUpCount = 0;
	}

	public PlayerStats()
	{
		Dictionary<PowerUpType, PlayerStat> stats = new Dictionary<PowerUpType, PlayerStat>();
		_stats = stats;
	}
}
