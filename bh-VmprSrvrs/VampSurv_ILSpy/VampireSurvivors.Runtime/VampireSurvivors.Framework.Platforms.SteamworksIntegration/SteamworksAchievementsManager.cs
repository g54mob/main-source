using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using Steamworks;
using Steamworks.Data;
using UnityEngine;
using VampireSurvivors.Achievements;
using VampireSurvivors.Data;

namespace VampireSurvivors.Framework.Platforms.SteamworksIntegration;

public class SteamworksAchievementsManager : IPlatformAchievementsManager, ILastErrorProvider
{
	private ErroInfo m_LastError;

	private AchievementsManagerState m_State;

	private Dictionary<AchievementType, AchievementData> m_AchievementDefinitions;

	private bool m_storeStats;

	protected Action<bool, List<AchievementType>> m_onInitCompleteCallback;

	protected List<AchievementType> m_inout_Completed;

	public AchievementsManagerState State => m_State;

	public unsafe ErroInfo LastError
	{
		get
		{
			//IL_000f: Expected I4, but got O
			//IL_000a: Expected native int or pointer, but got O
			//IL_0024: Expected O, but got I
			//IL_001f: Expected native int or pointer, but got O
			ErroInfo erroInfo = default(ErroInfo);
			((ErroInfo*)(nint)erroInfo)->NativeErrorCode = (int)m_LastError;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (VampireSurvivors.Framework.Platforms.SteamworksIntegration.SteamworksAchievementsManager)+20]");
			System.Runtime.CompilerServices.Unsafe.Write(&((ErroInfo*)(nint)erroInfo)->Message, (string)0);
			return erroInfo;
		}
	}

	public void Close()
	{
		//IL_000e: Expected O, but got I4
		//IL_0050: Expected I, but got O
		//IL_0066: Expected O, but got I
		m_State = AchievementsManagerState.NonInitialized;
		Action<SteamId, Result> value = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99410");
		Delegate obj = SteamUserStats.OnUserStatsReceived;
		object obj4 = default(object);
		while (true)
		{
			Delegate obj2 = Delegate.Remove(obj, value);
			object obj3;
			if ((object)obj2 == null)
			{
				obj3 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag = obj4 == null;
				obj3 = obj4;
				if (flag)
				{
					break;
				}
			}
			nint num = (nint)typeof(SteamUserStats);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v154 @ rcx_v9 (Il2CppClass<Steamworks.SteamUserStats>)+B8]");
			object obj5 = (nint)0 + (nint)16;
			bool flag2 = obj == obj5;
			Delegate obj6;
			if (obj == obj5)
			{
				obj5 = obj3;
				obj6 = obj;
			}
			else
			{
				obj6 = (Delegate)obj5;
			}
			Delegate obj7 = obj;
			if (!flag2)
			{
				obj7 = obj6;
			}
			bool flag3 = (object)obj7 != obj;
			obj = obj7;
			if (!flag3)
			{
				return;
			}
		}
		throw new InvalidCastException();
	}

	public void InitAsync(Dictionary<AchievementType, AchievementData> readonly_achievementDefinitions, List<AchievementType> inout_Completed, Action<bool, List<AchievementType>> onComplete)
	{
		//IL_015f: Expected I4, but got I8
		//IL_016a: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_0090: Expected I, but got O
		//IL_00a6: Expected O, but got I
		if (m_State == AchievementsManagerState.NonInitialized)
		{
			Debug.Log("[Steamworks.NET] - Initializing AchievementManager");
			m_AchievementDefinitions = readonly_achievementDefinitions;
			m_State = AchievementsManagerState.Initializing;
			m_onInitCompleteCallback = onComplete;
			List<AchievementType> inout_Completed2 = default(List<AchievementType>);
			m_inout_Completed = inout_Completed2;
			bool flag = SteamUserStats.RequestCurrentStats();
			Action<SteamId, Result> b = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99410");
			Delegate obj = SteamUserStats.OnUserStatsReceived;
			object obj4 = default(object);
			while (true)
			{
				Delegate obj2 = Delegate.Combine(obj, b);
				object obj3;
				if ((object)obj2 == null)
				{
					obj3 = 0;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag2 = obj4 == null;
					obj3 = obj4;
					if (flag2)
					{
						break;
					}
				}
				nint num = (nint)typeof(SteamUserStats);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v583 @ rcx_v23 (Il2CppClass<Steamworks.SteamUserStats>)+B8]");
				object obj5 = (nint)0 + (nint)16;
				bool flag3 = obj == obj5;
				Delegate obj6;
				if (obj == obj5)
				{
					obj5 = obj3;
					obj6 = obj;
				}
				else
				{
					obj6 = (Delegate)obj5;
				}
				Delegate obj7 = obj;
				if (!flag3)
				{
					obj7 = obj6;
				}
				bool flag4 = (object)obj7 != obj;
				obj = obj7;
				if (!flag4)
				{
					return;
				}
			}
			throw new InvalidCastException();
		}
		if (m_State != AchievementsManagerState.ReadyToUse)
		{
			ErroInfo erroInfo = new ErroInfo(-1, "[Steamworks.NET] - AchievementsManager is currently initializing!?");
			m_LastError = (ErroInfo)0;
			_ = 0;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r9 (System.Action`2<System.Boolean, System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>>)+18] (should have been resolved before IL gen)");
			}
		}
		else if (onComplete != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [onComplete @ r9 (System.Action`2<System.Boolean, System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>>)+18] (should have been resolved before IL gen)");
		}
	}

	private unsafe void OnUserStatsReceived(SteamId steamId, Result result)
	{
		//IL_019f: Expected O, but got I4
		//IL_0187: Expected O, but got I4
		//IL_0039: Expected O, but got Ref
		//IL_005f: Expected I, but got O
		//IL_00bb: Expected I, but got O
		//IL_00dc: Expected O, but got Ref
		if (result == Result.OK)
		{
			Debug.Log("[Steamworks.NET] - Received steam user stats and achievements");
			Dictionary<AchievementType, AchievementData>.Enumerator enumerator = default(Dictionary<AchievementType, AchievementData>.Enumerator);
			IntPtr intPtr = default(IntPtr);
			bool pbAchieved = default(bool);
			IntPtr intPtr2 = default(IntPtr);
			while (enumerator.MoveNext())
			{
				string pchName = ((Enum)(&intPtr)).ToString();
				Steamworks.ISteamUserStats steamUserStats = SteamUserStats.Internal;
				bool flag = steamUserStats == null;
				nint num = unchecked((nint)null);
				if (!flag)
				{
					if (!steamUserStats.GetAchievement(pchName, ref pbAchieved))
					{
						string[] array = new string[5];
						bool flag2 = array == null;
						num = (nint)typeof(string[]);
						if (flag2)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						string text = ((Enum)(&intPtr2)).ToString();
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
						string message = string.Concat(array);
						Debug.LogWarning(message);
					}
					else if (pbAchieved)
					{
						if (m_inout_Completed == null)
						{
							throw new NullReferenceException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A994F0");
					}
					continue;
				}
				throw new NullReferenceException();
			}
			object obj = 2;
		}
		else
		{
			Debug.LogError("[Steamworks.NET] - Failed to load steam user stats!");
			object obj = 0;
		}
		m_State = AchievementsManagerState.ReadyToUse;
		Action<bool, List<AchievementType>> onInitCompleteCallback = m_onInitCompleteCallback;
		if (m_onInitCompleteCallback != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v181 @ rax_v8 (System.Action`2<System.Boolean, System.Collections.Generic.List`1<VampireSurvivors.Data.AchievementType>>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe void ReportProgressAsync(AchievementType id, float newprogress = 1f, Action<AchievementType, bool> onComplete = null)
	{
		//IL_02f7: Expected O, but got Ref
		//IL_002f: Expected O, but got Ref
		//IL_0362: Expected I4, but got I8
		//IL_0040: Expected O, but got Ref
		//IL_007e: Expected O, but got I4
		//IL_0109: Expected O, but got I4
		//IL_00b6: Expected O, but got I
		//IL_00bf: Expected O, but got I4
		//IL_029d: Expected O, but got I
		//IL_02a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ab: Expected O, but got Unknown
		//IL_00cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Expected O, but got Unknown
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Expected Ref, but got Unknown
		//IL_01dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e2: Expected Ref, but got Unknown
		//IL_01ff: Expected I8, but got I
		bool flag = m_AchievementDefinitions == null;
		if (!flag)
		{
			int num = ((Dictionary<System.Int32Enum, object>)(object)m_AchievementDefinitions).FindEntry((System.Int32Enum)id);
			if (!flag)
			{
				IntPtr intPtr = default(IntPtr);
				string text = ((Enum)(&intPtr)).ToString();
				SteamUserStats._003Cget_Achievements_003Ed__24 obj = null;
				obj._003C_003E1__state = -2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
				int num2 = default(int);
				obj._003C_003El__initialThreadId = num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				ref byte reference = default(ref byte);
				object obj2 = (object)(&(ref reference));
				ref byte reference2 = ref *(byte*)null;
				object obj3 = default(object);
				object obj13 = default(object);
				Achievement achievement = default(Achievement);
				Achievement achievement2 = default(Achievement);
				while (System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference) != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj5;
					object obj12;
					if (obj3 != null)
					{
						object obj4 = reference;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r10_v3+12E]");
						if ((nint)0 >= (nint)0)
						{
							goto IL_00f6;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r10_v3+B0]");
						obj5 = 0;
						object obj6 = 0;
						while (true)
						{
							object obj7 = obj6 + obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ r8_v11+v391 @ rax_v40*8]");
							if (0 == (nint)typeof(IEnumerator<Achievement>))
							{
								break;
							}
							obj6++;
							object obj8 = obj6;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ r10_v3+12E]");
							if ((nint)obj8 < 0)
							{
								continue;
							}
							goto IL_00f6;
						}
						object obj9 = obj6 + obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v271 @ r8_v11+8+v447 @ rcx_v32*8]");
						object obj10 = (nint)0 << 4;
						object obj11 = obj10 + 312;
						obj12 = obj11 + obj4;
						goto IL_03ec;
					}
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					return;
					IL_00f6:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj5 = 0;
					obj12 = obj13;
					goto IL_03ec;
					IL_03ec:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v452 @ rdx_v16] (should have been resolved before IL gen)");
					bool flag2 = (object)achievement == text;
					Action<AchievementType, bool> typeFromHandle = (Action<AchievementType, bool>)(object)typeof(IEnumerator<Achievement>);
					if (!flag2)
					{
						bool flag3 = (object)achievement == null;
						Action<AchievementType, bool> typeFromHandle2 = (Action<AchievementType, bool>)(object)typeof(IEnumerator<Achievement>);
						reference2 = ref reference;
						if (flag3)
						{
							continue;
						}
						bool flag4 = text == null;
						typeFromHandle2 = (Action<AchievementType, bool>)(object)typeof(IEnumerator<Achievement>);
						reference2 = ref reference;
						if (flag4)
						{
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v30 (Steamworks.Data.Achievement)+10]");
						reference2 = ref *(byte*)null;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v30 (Steamworks.Data.Achievement)+10]");
						bool flag5 = (nint)0 != text._stringLength;
						typeFromHandle2 = (Action<AchievementType, bool>)(object)typeof(IEnumerator<Achievement>);
						if (flag5)
						{
							continue;
						}
						reference2 = ref *(byte*)(achievement + 20);
						ref byte second = ref *(byte*)(text + 20);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v30 (Steamworks.Data.Achievement)+10]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v277 @ rax_v30 (Steamworks.Data.Achievement)+10]");
						ulong length = (ulong)(num3 + 0);
						bool flag6 = System.SpanHelpers.SequenceEqual(ref reference2, ref second, length);
						bool flag7 = !flag6;
						typeFromHandle = null;
						typeFromHandle2 = null;
						if (flag7)
						{
							continue;
						}
					}
					bool flag8 = achievement2.Trigger();
					if (obj2 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					return;
				}
				throw new NullReferenceException();
			}
		}
		IntPtr intPtr2 = default(IntPtr);
		string text2 = ((Enum)(&intPtr2)).ToString();
		string message = "[Steamworks.NET] - Cannot report achievement progress for achievement " + text2 + " as not found in achievements definitions!";
		Debug.LogWarning(message);
	}

	public SteamworksAchievementsManager()
	{
		//IL_0014: Expected I, but got O
		nint num = (nint)typeof(ErroInfo);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rax_v3 (Il2CppClass<VampireSurvivors.Framework.Platforms.ErroInfo>)+B8]");
		nint num2 = 0;
		m_LastError = ErroInfo.NonError;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v4 (Il2CppStaticFields<VampireSurvivors.Framework.Platforms.ErroInfo>)+10]");
		_ = 0;
	}
}
