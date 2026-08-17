using System;
using System.Collections.Generic;
using System.Linq;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.DLC;

public class LicenseManager
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<KeyValuePair<DlcType, DlcData>, int> _003C_003E9__15_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal int _003CSortDlcLists_003Eb__15_0(KeyValuePair<DlcType, DlcData> p)
		{
			//IL_0022: Expected I4, but got O
			List<DlcType> sortedDlcTypes = DlcSorting.SortedDlcTypes;
			if (sortedDlcTypes != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				int result = default(int);
				return result;
			}
			NullReferenceException ex = new NullReferenceException();
			return (int)ex;
		}
	}

	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public LicenseManager _003C_003E4__this;

		public Action callback;

		internal unsafe void _003CCheckDlcLicenses_003Eb__0(List<DlcType> licensedDlc)
		{
			//IL_0626: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_0089: Expected O, but got Ref
			//IL_0217: Expected O, but got I
			//IL_0108: Expected O, but got I4
			//IL_0126: Expected O, but got I
			//IL_0136: Expected O, but got I
			//IL_0161: Expected O, but got I4
			//IL_0171: Expected O, but got I
			//IL_029e: Expected O, but got I
			//IL_05bc: Expected O, but got I4
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Expected O, but got Unknown
			//IL_03ed: Expected O, but got I
			//IL_0307: Expected O, but got I
			//IL_033f: Expected O, but got Ref
			//IL_04a5: Expected O, but got I
			_003C_003Ec__DisplayClass10_0 obj = this;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			IntPtr intPtr = default(IntPtr);
			object obj9 = default(object);
			nint num2 = default(nint);
			object obj11 = default(object);
			while (true)
			{
				if (obj2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+1C]");
					if (obj3 != null)
					{
						break;
					}
					object obj4 = obj5;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+18]");
					if ((nint)obj4 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+10]");
					object obj6 = 0;
					object obj7 = obj5 + 1;
					string text = ((Enum)(&intPtr)).ToString();
					string text2 = "User owns license for DLC: " + text;
					string message = "[DlcSystem] - " + text2;
					Debug.Log(message);
					LicenseManager licenseManager = _003C_003E4__this;
					List<DlcType> list = licenseManager._003COwnedDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					bool flag = (nint)0 == 0;
					object obj8 = obj9;
					nint num = num2;
					object obj10 = 0;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						obj8 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
						obj = (_003C_003Ec__DisplayClass10_0)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag2 = (nint)obj11 != -1;
						num = 0;
						obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						obj9 = 0;
						num2 = 0;
						obj5 = obj7;
						if (flag2)
						{
							continue;
						}
					}
					LicenseManager licenseManager2 = _003C_003E4__this;
					obj = (_003C_003Ec__DisplayClass10_0)(object)licenseManager2._003COwnedDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					obj9 = obj8;
					num2 = num;
					obj5 = obj7;
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag3 = obj2 == null;
			obj = (_003C_003Ec__DisplayClass10_0)0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+1C]");
				if (obj3 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+18]");
					object obj12 = (nint)0 + (nint)1;
					LicenseManager licenseManager3 = _003C_003E4__this;
					List<DlcType> list2 = licenseManager3._003CIncludedDlc_003Ek__BackingField;
					object obj13 = obj12;
					object obj15 = default(object);
					object obj18 = default(object);
					object obj19 = default(object);
					object obj21 = default(object);
					IntPtr intPtr2 = default(IntPtr);
					while (true)
					{
						object obj14 = obj13;
						while (true)
						{
							if (obj15 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+1C]");
								if (obj3 == null)
								{
									object obj16 = obj14;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+18]");
									if ((nint)obj16 < 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+10]");
										object obj17 = 0;
										obj14++;
										LicenseManager licenseManager4 = _003C_003E4__this;
										List<DlcType> list3 = licenseManager4._003COwnedDlc_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
										if ((nint)0 != 0)
										{
											break;
										}
										continue;
									}
								}
								if (obj15 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+1C]");
									if (obj3 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
										bool flag4 = (nint)0 == 0;
										bool flag5 = false;
										if (!flag4)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
											list2 = (List<DlcType>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
											bool flag6 = (nint)obj18 == -1;
											flag5 = false;
											if (!flag6)
											{
												bool flag7 = _003C_003E4__this.IsFreeDlcActivated(DlcType.Emeralds);
												flag5 = false;
												if (!flag7)
												{
													_003C_003E4__this.SetFreeDlcActivated(DlcType.Emeralds);
													list2 = null;
													flag5 = true;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
												list2 = (List<DlcType>)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
												bool flag8 = (nint)obj19 == -1;
												flag5 = false;
												if (!flag8)
												{
													bool flag9 = _003C_003E4__this.IsFreeDlcActivated(DlcType.Lemon);
													flag5 = false;
													if (!flag9)
													{
														_003C_003E4__this.SetFreeDlcActivated(DlcType.Lemon);
														list2 = null;
														flag5 = true;
													}
												}
											}
										}
										_003C_003E4__this.AddIncludedDlc();
										Action action = callback;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v162.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
										return;
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
									object obj20 = 0;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						list2 = (List<DlcType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag10 = (nint)obj21 == -1;
						obj13 = obj14;
						if (!flag10)
						{
							string text3 = ((Enum)(&intPtr2)).ToString();
							string message2 = "removing " + text3 + " from owned DLC list ";
							Debug.Log(message2);
							LicenseManager licenseManager5 = _003C_003E4__this;
							List<DlcType> list4 = licenseManager5._003COwnedDlc_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rax_v85+20+v758 @ rdx_v27*4]");
							bool flag11 = ((List<System.Int32Enum>)(object)list4).Remove((System.Int32Enum)0);
							list2 = null;
							obj13 = obj14;
						}
					}
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj = null;
			}
			throw new NullReferenceException();
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public LicenseManager _003C_003E4__this;

		public Action callback;

		internal unsafe void _003CCheckAvailableDlc_003Eb__0(List<DlcType> availableDlc)
		{
			//IL_000f: Expected I, but got O
			//IL_0072: Expected O, but got I
			//IL_0226: Expected I, but got O
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			//IL_008e: Expected O, but got Ref
			//IL_010a: Expected O, but got I4
			//IL_0113: Expected O, but got I4
			//IL_01b4: Expected I, but got O
			//IL_0131: Expected O, but got I
			//IL_016c: Expected O, but got I4
			//IL_0182: Expected O, but got I
			nint num = unchecked((nint)null);
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			IntPtr intPtr = default(IntPtr);
			nint num3 = default(nint);
			object obj9 = default(object);
			while (true)
			{
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+1C]");
					if (obj2 != null)
					{
						break;
					}
					object obj3 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+18]");
					if ((nint)obj3 >= 0)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+10]");
					object obj5 = 0;
					object obj6 = obj4 + 1;
					string text = ((Enum)(&intPtr)).ToString();
					string text2 = "DLC: " + text + " is available to user.";
					string message = "[DlcSystem] - " + text2;
					Debug.Log(message);
					LicenseManager licenseManager = _003C_003E4__this;
					List<DlcType> list = licenseManager._003CAvailableDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					bool flag = (nint)0 == 0;
					nint num2 = num3;
					object obj7 = 0;
					object obj8 = 0;
					object obj10;
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						obj7 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag2 = (nint)obj9 != -1;
						num2 = 0;
						obj8 = 0;
						num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						obj10 = 0;
						obj4 = obj6;
						if (flag2)
						{
							continue;
						}
					}
					LicenseManager licenseManager2 = _003C_003E4__this;
					num = (nint)licenseManager2._003CAvailableDlc_003Ek__BackingField;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					num3 = num2;
					obj10 = obj7;
					obj4 = obj6;
					continue;
				}
				throw new NullReferenceException();
			}
			bool flag3 = obj == null;
			num = 0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+1C]");
				if (obj2 == null)
				{
					Action action = callback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v112.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				num = unchecked((nint)null);
			}
			throw new NullReferenceException();
		}
	}

	private const string _freeDlcActivatedKey = "freedlcactivated";

	private readonly List<DlcType> _003COwnedDlc_003Ek__BackingField;

	private readonly List<DlcType> _003CIncludedDlc_003Ek__BackingField;

	private readonly List<DlcType> _003CAvailableDlc_003Ek__BackingField;

	public List<DlcType> OwnedDlc => _003COwnedDlc_003Ek__BackingField;

	public List<DlcType> IncludedDlc => _003CIncludedDlc_003Ek__BackingField;

	public List<DlcType> AvailableDlc => _003CAvailableDlc_003Ek__BackingField;

	public unsafe void CheckDlcLicenses(Action callback)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals14 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals14._003C_003E4__this = this;
		CS_0024_003C_003E8__locals14.callback = callback;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		Action<List<DlcType>> onComplete = delegate
		{
			//IL_0626: Expected O, but got I
			//IL_006d: Expected O, but got I
			//IL_007b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0080: Expected O, but got Unknown
			//IL_0089: Expected O, but got Ref
			//IL_0217: Expected O, but got I
			//IL_0108: Expected O, but got I4
			//IL_0126: Expected O, but got I
			//IL_0136: Expected O, but got I
			//IL_0161: Expected O, but got I4
			//IL_0171: Expected O, but got I
			//IL_029e: Expected O, but got I
			//IL_05bc: Expected O, but got I4
			//IL_02ac: Unknown result type (might be due to invalid IL or missing references)
			//IL_02b1: Expected O, but got Unknown
			//IL_03ed: Expected O, but got I
			//IL_0307: Expected O, but got I
			//IL_033f: Expected O, but got Ref
			//IL_04a5: Expected O, but got I
			_003C_003Ec__DisplayClass10_0 obj = CS_0024_003C_003E8__locals14;
			object obj2 = default(object);
			object obj3 = default(object);
			object obj5 = default(object);
			IntPtr intPtr = default(IntPtr);
			object obj9 = default(object);
			nint num2 = default(nint);
			object obj11 = default(object);
			while (true)
			{
				if (obj2 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+1C]");
				if (obj3 != null)
				{
					break;
				}
				object obj4 = obj5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+18]");
				if ((nint)obj4 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+10]");
				object obj6 = 0;
				object obj7 = obj5 + 1;
				string text = ((Enum)(&intPtr)).ToString();
				string text2 = "User owns license for DLC: " + text;
				string message = "[DlcSystem] - " + text2;
				Debug.Log(message);
				LicenseManager licenseManager = CS_0024_003C_003E8__locals14._003C_003E4__this;
				List<DlcType> list = licenseManager._003COwnedDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				bool flag = (nint)0 == 0;
				object obj8 = obj9;
				nint num = num2;
				object obj10 = 0;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
					obj = (_003C_003Ec__DisplayClass10_0)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag2 = (nint)obj11 != -1;
					num = 0;
					obj10 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v687 @ rcx_v62 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					obj9 = 0;
					num2 = 0;
					obj5 = obj7;
					if (flag2)
					{
						continue;
					}
				}
				LicenseManager licenseManager2 = CS_0024_003C_003E8__locals14._003C_003E4__this;
				obj = (_003C_003Ec__DisplayClass10_0)(object)licenseManager2._003COwnedDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
				obj9 = obj8;
				num2 = num;
				obj5 = obj7;
			}
			bool flag3 = obj2 == null;
			obj = (_003C_003Ec__DisplayClass10_0)0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+1C]");
				if (obj3 == null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ stack_-60_v21+18]");
					object obj12 = (nint)0 + (nint)1;
					LicenseManager licenseManager3 = CS_0024_003C_003E8__locals14._003C_003E4__this;
					List<DlcType> list2 = licenseManager3._003CIncludedDlc_003Ek__BackingField;
					object obj13 = obj12;
					object obj15 = default(object);
					object obj18 = default(object);
					object obj19 = default(object);
					object obj21 = default(object);
					IntPtr intPtr2 = default(IntPtr);
					while (true)
					{
						object obj14 = obj13;
						while (true)
						{
							if (obj15 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+1C]");
								if (obj3 == null)
								{
									object obj16 = obj14;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+18]");
									if ((nint)obj16 < 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+10]");
										object obj17 = 0;
										obj14++;
										LicenseManager licenseManager4 = CS_0024_003C_003E8__locals14._003C_003E4__this;
										List<DlcType> list3 = licenseManager4._003COwnedDlc_003Ek__BackingField;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
										if ((nint)0 != 0)
										{
											break;
										}
										continue;
									}
								}
								if (obj15 != null)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ stack_-60_v23+1C]");
									if (obj3 == null)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
										bool flag4 = (nint)0 == 0;
										bool flag5 = false;
										if (!flag4)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
											list2 = (List<DlcType>)0;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
											bool flag6 = (nint)obj18 == -1;
											flag5 = false;
											if (!flag6)
											{
												bool flag7 = CS_0024_003C_003E8__locals14._003C_003E4__this.IsFreeDlcActivated(DlcType.Emeralds);
												flag5 = false;
												if (!flag7)
												{
													CS_0024_003C_003E8__locals14._003C_003E4__this.SetFreeDlcActivated(DlcType.Emeralds);
													list2 = null;
													flag5 = true;
												}
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
											if ((nint)0 != 0)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [licensedDlc @ rdx (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
												list2 = (List<DlcType>)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
												bool flag8 = (nint)obj19 == -1;
												flag5 = false;
												if (!flag8)
												{
													bool flag9 = CS_0024_003C_003E8__locals14._003C_003E4__this.IsFreeDlcActivated(DlcType.Lemon);
													flag5 = false;
													if (!flag9)
													{
														CS_0024_003C_003E8__locals14._003C_003E4__this.SetFreeDlcActivated(DlcType.Lemon);
														list2 = null;
														flag5 = true;
													}
												}
											}
										}
										CS_0024_003C_003E8__locals14._003C_003E4__this.AddIncludedDlc();
										Action callback2 = CS_0024_003C_003E8__locals14.callback;
										Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v162.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
										return;
									}
									System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
									object obj20 = 0;
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v923 @ r10_v23 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						list2 = (List<DlcType>)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
						bool flag10 = (nint)obj21 == -1;
						obj13 = obj14;
						if (!flag10)
						{
							string text3 = ((Enum)(&intPtr2)).ToString();
							string message2 = "removing " + text3 + " from owned DLC list ";
							Debug.Log(message2);
							LicenseManager licenseManager5 = CS_0024_003C_003E8__locals14._003C_003E4__this;
							List<DlcType> list4 = licenseManager5._003COwnedDlc_003Ek__BackingField;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v767 @ rax_v85+20+v758 @ rdx_v27*4]");
							bool flag11 = ((List<System.Int32Enum>)(object)list4).Remove((System.Int32Enum)0);
							list2 = null;
							obj13 = obj14;
						}
					}
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				obj = null;
			}
			throw new NullReferenceException();
		};
		sInstance.m_CurrentSystem.GetLicensedDlc(onComplete);
	}

	public unsafe void AddIncludedDlc()
	{
		//IL_0046: Expected O, but got Ref
		//IL_008c: Expected O, but got I
		//IL_00ab: Expected O, but got Ref
		//IL_0234: Expected O, but got Ref
		//IL_0283: Expected O, but got I
		//IL_0198: Expected O, but got Ref
		DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
		DlcDataDictionary dlcData = dlcCatalog._DlcData;
		Dictionary<DlcType, DlcData>.Enumerator enumerator = default(Dictionary<DlcType, DlcData>.Enumerator);
		object obj = default(object);
		object obj3 = default(object);
		string text2 = default(string);
		IntPtr intPtr = default(IntPtr);
		IntPtr intPtr2 = default(IntPtr);
		object obj7 = default(object);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				return;
			}
			bool flag = obj == null;
			Dictionary<DlcType, DlcData>.Enumerator enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)(&enumerator);
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ stack_-38+99]");
				if ((nint)0 != 0)
				{
					continue;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ stack_-38+90]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ stack_-38+90]");
				bool flag2 = (nint)0 == 0;
				enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)(&enumerator);
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v477 @ rax_v17+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ stack_-38+98]");
						bool flag3 = (nint)0 == 0;
						string text = text2;
						if (!flag3)
						{
							bool flag4 = IsFreeDlcActivated(DlcType.Moonspell);
							bool flag5 = !flag4;
							text = null;
							text2 = null;
							if (flag5)
							{
								goto IL_01e8;
							}
						}
						if (_003CIncludedDlc_003Ek__BackingField == null)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
						bool flag6 = obj3 != null;
						text2 = text;
						if (!flag6)
						{
							string text3 = ((Enum)(&intPtr)).ToString();
							string message = "adding " + text3 + " to included DLC list ";
							Debug.Log(message);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
							text2 = " to included DLC list ";
							dlcData = null;
							continue;
						}
					}
					goto IL_01e8;
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_01e8:
			string[] array = new string[8];
			bool flag7 = array == null;
			enumerator2 = (Dictionary<DlcType, DlcData>.Enumerator)typeof(string[]);
			if (!flag7)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string text4 = ((Enum)(&intPtr2)).ToString();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ stack_-38+90]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ stack_-38+90]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v741 @ rax_v35+10]");
						bool flag8 = (nint)0 == 0;
						object obj5 = "False";
						if (!flag8)
						{
							obj5 = "True";
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ stack_-38+98]");
						bool flag9;
						if ((nint)0 == 0)
						{
							flag9 = true;
						}
						else
						{
							bool flag10 = IsFreeDlcActivated(DlcType.Moonspell);
							flag9 = flag10;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
						if ((nint)0 == 0)
						{
							_ = 1;
						}
						bool flag11 = !flag9;
						object obj6 = "False";
						if (!flag11)
						{
							obj6 = "True";
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						if (_003CIncludedDlc_003Ek__BackingField != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18998A2F7]");
							if ((nint)0 == 0)
							{
								_ = 1;
							}
							bool flag12 = obj7 != null;
							text2 = "False";
							if (!flag12)
							{
								text2 = "True";
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
							string message2 = string.Concat(array);
							Debug.Log(message2);
							continue;
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public unsafe bool IsFreeDlcActivated(DlcType dlcType)
	{
		//IL_0107: Expected O, but got Ref
		//IL_00ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Expected Ref, but got Unknown
		//IL_00c9: Expected I8, but got I4
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected Ref, but got Unknown
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string key = "freedlcactivated" + text;
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		string text2 = PlayerPrefs.GetString(userSpecificKey, "0");
		object obj2 = "1";
		if ((object)text2 != "1")
		{
			if (text2 != null && "1" != null)
			{
				int stringLength = text2._stringLength;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rdx_v5+10]");
				if ((nint)stringLength == 0)
				{
					ref byte first = ref *(byte*)(text2 + 20);
					ulong length = (ulong)(text2._stringLength + text2._stringLength);
					return System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("1" + 20), length);
				}
			}
			return false;
		}
		return true;
	}

	public unsafe void SetFreeDlcActivated(DlcType dlcType, bool activated = true)
	{
		//IL_0021: Expected O, but got Ref
		object obj = default(object);
		string text = ((Enum)(&obj)).ToString();
		string key = "freedlcactivated" + text;
		string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(key);
		PlayerPrefs.SetString(userSpecificKey, "1");
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: Type: Il2CppMethodInfo (should have been resolved before IL gen)");
		Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-48), the output could be wrong!");
		/*Error: End of method reached without returning.*/;
	}

	public unsafe void CheckAvailableDlc(Action callback)
	{
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals5 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals5._003C_003E4__this = this;
		CS_0024_003C_003E8__locals5.callback = callback;
		SystemPlatform sInstance = SystemPlatform.sInstance;
		Action<List<DlcType>> onComplete = delegate
		{
			//IL_000f: Expected I, but got O
			//IL_0072: Expected O, but got I
			//IL_0226: Expected I, but got O
			//IL_0080: Unknown result type (might be due to invalid IL or missing references)
			//IL_0085: Expected O, but got Unknown
			//IL_008e: Expected O, but got Ref
			//IL_010a: Expected O, but got I4
			//IL_0113: Expected O, but got I4
			//IL_01b4: Expected I, but got O
			//IL_0131: Expected O, but got I
			//IL_016c: Expected O, but got I4
			//IL_0182: Expected O, but got I
			nint num = unchecked((nint)null);
			object obj = default(object);
			object obj2 = default(object);
			object obj4 = default(object);
			IntPtr intPtr = default(IntPtr);
			nint num3 = default(nint);
			object obj9 = default(object);
			while (true)
			{
				if (obj == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+1C]");
				if (obj2 != null)
				{
					break;
				}
				object obj3 = obj4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+18]");
				if ((nint)obj3 >= 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+10]");
				object obj5 = 0;
				object obj6 = obj4 + 1;
				string text = ((Enum)(&intPtr)).ToString();
				string text2 = "DLC: " + text + " is available to user.";
				string message = "[DlcSystem] - " + text2;
				Debug.Log(message);
				LicenseManager licenseManager = CS_0024_003C_003E8__locals5._003C_003E4__this;
				List<DlcType> list = licenseManager._003CAvailableDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
				bool flag = (nint)0 == 0;
				nint num2 = num3;
				object obj7 = 0;
				object obj8 = 0;
				object obj10;
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
					num = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
					bool flag2 = (nint)obj9 != -1;
					num2 = 0;
					obj8 = 0;
					num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v548 @ rcx_v29 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					obj10 = 0;
					obj4 = obj6;
					if (flag2)
					{
						continue;
					}
				}
				LicenseManager licenseManager2 = CS_0024_003C_003E8__locals5._003C_003E4__this;
				num = (nint)licenseManager2._003CAvailableDlc_003Ek__BackingField;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
				num3 = num2;
				obj10 = obj7;
				obj4 = obj6;
			}
			bool flag3 = obj == null;
			num = 0;
			if (!flag3)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ stack_-38_v12+1C]");
				if (obj2 == null)
				{
					Action callback2 = CS_0024_003C_003E8__locals5.callback;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v112.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
					return;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_EnumFailedVersion();
				num = unchecked((nint)null);
			}
			throw new NullReferenceException();
		};
		sInstance.m_CurrentSystem.GetAvailableDlc(onComplete);
	}

	public unsafe void SortDlcLists()
	{
		//IL_00b3: Expected O, but got Ref
		//IL_0407: Expected I, but got O
		//IL_048d: Expected O, but got I
		//IL_04ac: Expected O, but got Ref
		//IL_0146: Expected O, but got I
		//IL_014f: Expected O, but got I4
		//IL_01c5: Expected I, but got O
		//IL_01cd: Expected O, but got Ref
		//IL_02f6: Expected O, but got I
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0304: Expected O, but got Unknown
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_01f2: Expected O, but got Ref
		//IL_0289: Expected I, but got O
		//IL_02ce: Expected I, but got O
		List<DlcType> list = (List<DlcType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003COwnedDlc_003Ek__BackingField);
		List<DlcType> list2 = (List<DlcType>)(object)new List<System.Int32Enum>((IEnumerable<System.Int32Enum>)_003CIncludedDlc_003Ek__BackingField);
		((List<System.Int32Enum>)(object)list2)._002Ector((IEnumerable<System.Int32Enum>)_003CIncludedDlc_003Ek__BackingField);
		List<DlcType> list3 = _003COwnedDlc_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v70 @ rdx_v3 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<DlcType> list4 = _003CIncludedDlc_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rdx_v5 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
		Func<KeyValuePair<DlcType, DlcData>, int> keySelector = _003C_003Ec._003C_003E9__15_0;
		if (_003C_003Ec._003C_003E9__15_0 == null)
		{
			Func<KeyValuePair<DlcType, DlcData>, int> func = (_003C_003Ec._003C_003E9__15_0 = delegate
			{
				//IL_0022: Expected I4, but got O
				List<DlcType> sortedDlcTypes = DlcSorting.SortedDlcTypes;
				if (sortedDlcTypes == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (int)ex;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				int result = default(int);
				return result;
			});
			nint num = unchecked((nint)null);
			keySelector = func;
		}
		IOrderedEnumerable<KeyValuePair<DlcType, DlcData>> orderedEnumerable = Enumerable.OrderBy(dlcCatalog._DlcData, keySelector);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj2 = default(object);
		object obj = (object)(&obj2);
		List<DlcType> list5 = null;
		object obj3 = default(object);
		object obj13 = default(object);
		object obj15 = default(object);
		object obj16 = default(object);
		object obj17 = default(object);
		while (true)
		{
			object obj12;
			if (obj2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				if (obj3 != null)
				{
					bool flag = obj2 == null;
					list5 = null;
					if (!flag)
					{
						object obj4 = obj2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r10_v6+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_0186;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r10_v6+B0]");
						object obj5 = 0;
						object obj6 = 0;
						while (true)
						{
							object obj7 = obj6 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ r8_v18+v597 @ rax_v49*8]");
							if (0 == (nint)typeof(IEnumerator<KeyValuePair<DlcType, DlcData>>))
							{
								break;
							}
							obj6++;
							object obj8 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v426 @ r10_v6+12E]");
							if ((nint)obj8 < 0)
							{
								continue;
							}
							goto IL_0186;
						}
						object obj9 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v594 @ r8_v18+8+v657 @ rcx_v38*8]");
						object obj10 = (nint)0 << 4;
						object obj11 = obj10 + 312;
						obj12 = obj11 + obj4;
						goto IL_0473;
					}
					throw new NullReferenceException();
				}
				if (obj != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				return;
			}
			throw new NullReferenceException();
			IL_0186:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			obj12 = obj13;
			goto IL_0473;
			IL_0473:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v663 @ r8_v13] (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ rax_v29+8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v679 @ rax_v29+8]");
			bool flag2 = (nint)0 == 0;
			list5 = (List<DlcType>)(&obj15);
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v438 @ rax_v30+99]");
				bool flag3 = (nint)0 != 0;
				nint num = (nint)typeof(IEnumerator<KeyValuePair<DlcType, DlcData>>);
				list5 = (List<DlcType>)(&obj15);
				if (flag3)
				{
					continue;
				}
				bool flag4 = list == null;
				list5 = (List<DlcType>)(&obj15);
				if (!flag4)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
					if (obj16 != null)
					{
						list5 = _003COwnedDlc_003Ek__BackingField;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
					}
					if (list2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
						bool flag5 = obj17 == null;
						num = (nint)typeof(IEnumerator<KeyValuePair<DlcType, DlcData>>);
						if (!flag5)
						{
							if (_003CIncludedDlc_003Ek__BackingField == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
							num = (nint)typeof(IEnumerator<KeyValuePair<DlcType, DlcData>>);
						}
						continue;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	public LicenseManager()
	{
		List<DlcType> list = new List<DlcType>();
		_003COwnedDlc_003Ek__BackingField = list;
		List<DlcType> list2 = new List<DlcType>();
		_003CIncludedDlc_003Ek__BackingField = list2;
		List<DlcType> list3 = new List<DlcType>();
		_003CAvailableDlc_003Ek__BackingField = list3;
	}
}
