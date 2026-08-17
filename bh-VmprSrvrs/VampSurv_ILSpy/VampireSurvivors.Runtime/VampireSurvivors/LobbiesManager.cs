using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Cloud;
using Coherence.Log;
using Coherence.Runtime;
using Cpp2ILInjected;
using I2.Loc;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Framework.Platforms;
using Zenject;

namespace VampireSurvivors;

public class LobbiesManager : IInitializable, IDisposable
{
	private struct PingResult(bool isDone, long time)
	{
		public bool isDone = isDone;

		public long time = time;
	}

	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Func<char, char> _003C_003E9__22_0;

		public static Func<char, int> _003C_003E9__22_1;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal char _003CGenerateLobbyCode_003Eb__22_0(char c)
		{
			//IL_0090: Expected O, but got I4
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A3BB5]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			object obj = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2+10]");
			object obj2 = UnityEngine.Random.RandomRangeInt(0, 0);
			object obj3 = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v4+10]");
			bool flag = (nint)obj2 >= 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ r8_v4+14+v59 @ rax_v12*2]");
			return '\0';
		}

		internal int _003CGenerateLobbyCode_003Eb__22_1(char c)
		{
			//IL_0006: Expected O, but got I
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ rax_v2 (should have been resolved before IL gen)");
			Cpp2ILHelpers.NoteDecompilerIssue("Warning: Method ends with non empty stack (-28), the output could be wrong!");
			/*Error: End of method reached without returning.*/;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CCreateNewLobby_003Ed__15 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LobbyResult> _003C_003Et__builder;

		public LobbiesManager _003C_003E4__this;

		private string _003CbestRegion_003E5__2;

		private List<CloudAttribute> _003ClobbyAttributes_003E5__3;

		private List<CloudAttribute> _003CplayerAttributes_003E5__4;

		private TaskAwaiter<string> _003C_003Eu__1;

		private Task<LobbySession> _003Ctask_003E5__5;

		private int _003C_003E7__wrap5;

		private TaskAwaiter<LobbySession> _003C_003Eu__2;

		private TaskAwaiter _003C_003Eu__3;

		private unsafe void MoveNext()
		{
			//IL_02d0: Expected O, but got I4
			//IL_02df: Expected I4, but got I8
			//IL_002b: Expected O, but got I4
			//IL_0297: Expected O, but got I4
			//IL_02b4: Expected O, but got I8
			//IL_0344: Expected O, but got I
			//IL_0237: Expected O, but got I4
			//IL_0246: Expected I4, but got I8
			//IL_0251: Expected O, but got I4
			//IL_026e: Expected O, but got I8
			//IL_027b: Expected I4, but got I8
			//IL_0796: Expected O, but got I4
			//IL_07a5: Expected I4, but got I8
			//IL_07b2: Expected I4, but got I8
			//IL_07f0: Expected O, but got I
			//IL_0828: Expected O, but got I4
			//IL_0830: Unknown result type (might be due to invalid IL or missing references)
			//IL_0835: Expected O, but got Unknown
			//IL_098b: Expected O, but got I4
			//IL_0993: Unknown result type (might be due to invalid IL or missing references)
			//IL_0998: Expected O, but got Unknown
			//IL_08b8: Expected O, but got Ref
			//IL_0398: Expected O, but got Ref
			//IL_03b3: Expected O, but got I4
			//IL_03b3: Expected I8, but got I4
			//IL_0d99: Expected O, but got I4
			//IL_0da1: Unknown result type (might be due to invalid IL or missing references)
			//IL_0da6: Expected O, but got Unknown
			//IL_091e: Expected O, but got I
			//IL_1303: Expected I8, but got I4
			//IL_03d1: Expected O, but got Ref
			//IL_0146: Expected O, but got Ref
			//IL_050a: Expected O, but got Ref
			//IL_11c1: Expected I4, but got I8
			//IL_0402: Expected O, but got I
			//IL_0a2f: Expected O, but got I4
			//IL_0a37: Unknown result type (might be due to invalid IL or missing references)
			//IL_0a3c: Expected O, but got Unknown
			//IL_0f6b: Expected O, but got I4
			//IL_0f6b: Expected I4, but got O
			//IL_131f: Expected O, but got I4
			//IL_131f: Expected I8, but got I4
			//IL_0e3d: Expected O, but got I4
			//IL_0e45: Unknown result type (might be due to invalid IL or missing references)
			//IL_0e4a: Expected O, but got Unknown
			//IL_058e: Expected O, but got Ref
			//IL_0555: Expected O, but got I4
			//IL_047f: Expected O, but got I
			//IL_01b4: Expected O, but got I4
			//IL_01bc: Unknown result type (might be due to invalid IL or missing references)
			//IL_01c1: Expected O, but got Unknown
			//IL_01db: Expected O, but got I8
			//IL_01e5: Expected O, but got I4
			//IL_0fd7: Expected O, but got Ref
			//IL_0fe4: Expected O, but got Ref
			//IL_05a3: Expected O, but got I
			//IL_0462: Expected O, but got Ref
			//IL_04c9: Expected O, but got I
			//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
			//IL_04de: Expected O, but got Unknown
			//IL_0a98: Expected I, but got O
			//IL_0aa6: Expected I, but got O
			//IL_0ab6: Expected O, but got I
			//IL_0b36: Expected O, but got I4
			//IL_0219: Expected O, but got Ref
			//IL_0af2: Expected O, but got I
			//IL_05d6: Expected O, but got I4
			//IL_0eeb: Expected O, but got I4
			//IL_0ef3: Unknown result type (might be due to invalid IL or missing references)
			//IL_0ef8: Expected O, but got Unknown
			//IL_05e8: Expected O, but got Ref
			//IL_0600: Expected O, but got I4
			//IL_0600: Expected I8, but got I4
			//IL_0b28: Expected O, but got I4
			//IL_0612: Expected O, but got Ref
			//IL_063d: Expected O, but got I4
			//IL_064f: Expected O, but got Ref
			//IL_067d: Expected O, but got I4
			//IL_068a: Expected O, but got Ref
			//IL_06cb: Expected O, but got I8
			//IL_12cf: Expected I, but got O
			//IL_0c43: Expected O, but got I4
			//IL_0ca1: Expected O, but got I4
			//IL_0ca9: Unknown result type (might be due to invalid IL or missing references)
			//IL_0cae: Expected O, but got Unknown
			//IL_0d2c: Expected O, but got Ref
			LobbiesManager lobbiesManager = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			double value;
			object obj;
			int num = default(int);
			Task task;
			bool flag2 = default(bool);
			GameObject gameObject = default(GameObject);
			string text = default(string);
			bool flag3 = default(bool);
			Task task3;
			Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
			if (!flag)
			{
				AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<object>)(_003C_003E1__state - 1);
				if (flag)
				{
					enumerator = (Dictionary<DlcType, BundleManifestData>.Enumerator)0;
					value = 1.100000023841858;
					obj = 2147483648L;
					num = _003C_003E1__state;
					goto IL_11e7;
				}
				if ((nint)asyncTaskMethodBuilder == 1)
				{
					_003C_003Eu__3 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					enumerator = (Dictionary<DlcType, BundleManifestData>.Enumerator)0;
					value = 1.100000023841858;
					obj = 2147483648L;
					num = -1;
					task = (Task)_003C_003Eu__3;
					goto IL_0cc4;
				}
				if (_003C_003E4__this == null)
				{
					throw new NullReferenceException();
				}
				if (lobbiesManager._activeLobby != null)
				{
					LobbySession activeLobby = lobbiesManager._activeLobby;
					if (!activeLobby._003CIsDisposed_003Ek__BackingField)
					{
						string translation = LocalizationManager.GetTranslation("onlineLang/ErrorAlreadyInGameDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, flag2, gameObject, text, flag3);
						goto IL_11b2;
					}
				}
				AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<object>);
				_003CGetBestRegion_003Ed__23 stateMachine = default(_003CGetBestRegion_003Ed__23);
				asyncTaskMethodBuilder2.Start(ref stateMachine);
				Task<object> task2 = asyncTaskMethodBuilder2.Task;
				bool flag4 = task2 == null;
				asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<object>)(&asyncTaskMethodBuilder2);
				if (flag4)
				{
					throw new NullReferenceException();
				}
				((AsyncTaskMethodBuilder<string>*)task2)->Start(ref *(_003CGetBestRegion_003Ed__23*)null);
				TaskAwaiter<string> taskAwaiter = default(TaskAwaiter<string>);
				int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag5 = num2 == 0;
				bool flag6 = num2 < 0;
				bool flag7 = !flag6;
				object obj2 = !flag5;
				object obj3 = flag7 & obj2;
				task3 = (Task)taskAwaiter;
				stateMachine = (_003CGetBestRegion_003Ed__23)4294967295L;
				asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)0;
				if (obj3 == null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<LobbyResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<string> awaiter = default(TaskAwaiter<string>);
					((AsyncTaskMethodBuilder<LobbyResult>*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			else
			{
				_003C_003Eu__1 = (TaskAwaiter<string>)0;
				_003C_003E1__state = -1;
				task3 = (Task)_003C_003Eu__1;
			}
			int num3 = task3.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task3);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v125 @ rbx_v15 (System.Threading.Tasks.Task)+50]");
			_003CbestRegion_003E5__2 = (string)0;
			List<CloudAttribute> list = new List<CloudAttribute>();
			_003ClobbyAttributes_003E5__3 = list;
			Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
			IntPtr intPtr = default(IntPtr);
			CloudAttribute cloudAttribute;
			CloudAttribute cloudAttribute3 = default(CloudAttribute);
			while (enumerator.MoveNext())
			{
				List<CloudAttribute> list2 = _003ClobbyAttributes_003E5__3;
				string key = ((Enum)(&intPtr)).ToString();
				cloudAttribute = new CloudAttribute(key, 1L, (bool?)(object)257);
				bool flag8 = _003ClobbyAttributes_003E5__3 == null;
				CloudAttribute cloudAttribute2 = (CloudAttribute)(&cloudAttribute);
				if (!flag8)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rbx_v23 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rbx_v23 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+10]");
					AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<object>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rbx_v23 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rbx_v23 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ rcx_v40 (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Object>)+18]");
						if (num4 >= 0)
						{
							_003ClobbyAttributes_003E5__3.AddWithResize((CloudAttribute)(&cloudAttribute3));
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rbx_v23 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
						object obj4 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rbx_v23 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
						nint num5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v837 @ rcx_v40 (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Object>)+18]");
						if (num5 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rbx_v23 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
							object obj5 = (nint)0 * (nint)4;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v819 @ rbx_v23 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
							object obj6 = 0 + obj5;
							_ = 0;
							_ = 0;
							continue;
						}
						throw new IndexOutOfRangeException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			cloudAttribute = new CloudAttribute(LobbyAttributeKeys.PlayerPlatform, (long)SystemPlatform.Platform, IntAttributeIndex.n1, flag2 ? IntAggregator.Sum : IntAggregator.None, gameObject);
			_003ClobbyAttributes_003E5__3.Add((CloudAttribute)(&cloudAttribute3));
			bool flag10;
			if (SystemPlatform.Platform != SystemPlatformTypes.PS4 && SystemPlatform.Platform != SystemPlatformTypes.PS5)
			{
				object obj7 = SystemPlatform.Platform - 5;
				bool flag9 = obj7 == null;
				flag10 = flag9;
			}
			else
			{
				flag10 = true;
			}
			cloudAttribute = new CloudAttribute(LobbyAttributeKeys.FallbackToCoherenceCloud, flag10 ? 1 : 0, (bool?)(object)257);
			CloudAttribute cloudAttribute4 = default(CloudAttribute);
			_003ClobbyAttributes_003E5__3.Add((CloudAttribute)(&cloudAttribute4));
			List<CloudAttribute> list3 = null;
			list3.Add((CloudAttribute)0);
			SystemPlatform sInstance = SystemPlatform.sInstance;
			IBaseAccount currentSystem = sInstance.m_CurrentSystem;
			CloudAttribute cloudAttribute5 = new CloudAttribute(LobbyAttributeKeys.PlayerName, currentSystem.m_Name, (bool?)(object)257);
			list3.Add((CloudAttribute)(&cloudAttribute4));
			CloudAttribute cloudAttribute6 = new CloudAttribute(LobbyAttributeKeys.PlayerPlatform, (long)SystemPlatform.Platform, (bool?)(object)257);
			list3.Add((CloudAttribute)(&cloudAttribute4));
			string currentlyLoadedDLCAsString = _003C_003E4__this.GetCurrentlyLoadedDLCAsString();
			CloudAttribute cloudAttribute7 = new CloudAttribute(LobbyAttributeKeys.PlayerLoadedDLCS, currentlyLoadedDLCAsString, (bool?)(object)257);
			list3.Add((CloudAttribute)(&cloudAttribute4));
			SystemPlatform sInstance2 = SystemPlatform.sInstance;
			string uniqueAccountID = sInstance2.m_CurrentSystem.UniqueAccountID;
			cloudAttribute3 = new CloudAttribute(LobbyAttributeKeys.PlayerPlatformID, uniqueAccountID, (bool?)(object)257);
			list3.Add((CloudAttribute)(&cloudAttribute4));
			_003CplayerAttributes_003E5__4 = list3;
			value = 1.100000023841858;
			obj = 2147483648L;
			flag2 = flag2;
			goto IL_06dd;
			IL_0cc4:
			int num6 = task.m_stateFlags & 0x11000000;
			if (num6 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			goto IL_06dd;
			IL_11e7:
			Task task4;
			if (num == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter<LobbySession>)0;
				_003C_003E1__state = -1;
				num = -1;
				task4 = (Task)_003C_003Eu__2;
			}
			else
			{
				Task<LobbySession> task5 = _003Ctask_003E5__5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v704 @ rax_v160 (System.Threading.Tasks.Task`1<Coherence.Cloud.LobbySession>)+38]");
				object obj8 = (nint)0 & (nint)0x1600000;
				bool flag11 = obj8 == null;
				bool flag12 = (nint)obj8 < 0;
				bool flag13 = !flag12;
				object obj9 = !flag13;
				object obj10 = obj9 | flag11;
				task4 = task5;
				if (obj10 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (TaskAwaiter<LobbySession>)task5;
					AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<LobbyResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<LobbySession> awaiter2 = default(TaskAwaiter<LobbySession>);
					((AsyncTaskMethodBuilder<LobbyResult>*)asyncTaskMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
			}
			int num7 = task4.m_stateFlags & 0x11000000;
			if (num7 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task4);
			}
			Task task6 = _003Ctask_003E5__5;
			if (_003C_003E7__wrap5 != 1)
			{
				int num8 = task6.m_stateFlags & 0x11000000;
				LobbySession activeLobby2 = default(LobbySession);
				if (num8 != 16777216)
				{
					((AsyncTaskMethodBuilder<string>*)task6)->Start(ref *(_003CGetBestRegion_003Ed__23*)1);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1901 @ rcx_v45 (System.Threading.Tasks.Task)+50]");
					activeLobby2 = (LobbySession)0;
				}
				lobbiesManager._activeLobby = activeLobby2;
				goto IL_11b2;
			}
			int num9 = task6.m_stateFlags & 0x200000;
			bool flag14 = num9 == 0;
			bool flag15 = num9 < 0;
			bool flag16 = !flag15;
			object obj11 = !flag16;
			object obj12 = obj11 | flag14;
			AggregateException exceptions2;
			object obj17;
			if (obj12 == null)
			{
				AggregateException exceptions = task6.GetExceptions(false);
				if (exceptions != null)
				{
					Task task7 = _003Ctask_003E5__5;
					int num10 = task7.m_stateFlags & 0x200000;
					bool flag17 = num10 == 0;
					bool flag18 = num10 < 0;
					bool flag19 = !flag18;
					object obj13 = !flag19;
					object obj14 = obj13 | flag17;
					if (obj14 != null)
					{
						throw new NullReferenceException();
					}
					exceptions2 = task7.GetExceptions(false);
					Exception innerException = ((Exception)exceptions2)._innerException;
					if (((Exception)exceptions2)._innerException != null)
					{
						nint num11 = (nint)innerException;
						nint num12 = (nint)typeof(RequestException);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3886 @ rdx_v39 (Il2CppClass<Coherence.Runtime.RequestException>)+130]");
						object obj15 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ r9_v12 (Il2CppClass<System.Exception>)+130]");
						nint num13 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3886 @ rdx_v39 (Il2CppClass<Coherence.Runtime.RequestException>)+130]");
						if (num13 >= 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v659 @ r9_v12 (Il2CppClass<System.Exception>)+C8]");
							object obj16 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6048 @ rax_v141+FFFFFFF8+v5941 @ rax_v93*8]");
							if (0 == (nint)typeof(RequestException))
							{
								obj17 = 1;
								goto IL_1295;
							}
						}
						obj17 = 0;
						goto IL_1295;
					}
				}
			}
			goto IL_0d3f;
			IL_0d3f:
			Task task8 = _003Ctask_003E5__5;
			int num14 = task8.m_stateFlags & 0x200000;
			bool flag20 = num14 == 0;
			bool flag21 = num14 < 0;
			bool flag22 = !flag21;
			object obj18 = !flag22;
			object obj19 = obj18 | flag20;
			if (obj19 == null)
			{
				AggregateException exceptions3 = task8.GetExceptions(false);
				if (exceptions3 != null)
				{
					Task task9 = _003Ctask_003E5__5;
					int num15 = task9.m_stateFlags & 0x200000;
					bool flag23 = num15 == 0;
					bool flag24 = num15 < 0;
					bool flag25 = !flag24;
					object obj20 = !flag25;
					object obj21 = obj20 | flag23;
					if (obj21 != null)
					{
						throw new NullReferenceException();
					}
					AggregateException exceptions4 = task9.GetExceptions(false);
					if (((Exception)exceptions4)._innerException != null)
					{
						Task task10 = _003Ctask_003E5__5;
						int num16 = task10.m_stateFlags & 0x200000;
						bool flag26 = num16 == 0;
						bool flag27 = num16 < 0;
						bool flag28 = !flag27;
						object obj22 = !flag28;
						object obj23 = obj22 | flag26;
						if (obj23 == null)
						{
							AggregateException exceptions5 = task10.GetExceptions(false);
							string message = ((Exception)exceptions5)._innerException.Message;
							goto IL_11b2;
						}
						throw new NullReferenceException();
					}
				}
			}
			bool flag29 = LocalizationManager.TryGetTranslation("onlineLang/ErrorCreateGameFailedDesc", out var Translation, FixForRTL: true, 0, flag2, (byte)(int)gameObject != 0, (GameObject)(object)text, (string)flag3);
			if (Translation != null && Translation._stringLength > 0)
			{
			}
			goto IL_11b2;
			IL_11b2:
			_003C_003E1__state = -2;
			_003CbestRegion_003E5__2 = null;
			_003ClobbyAttributes_003E5__3 = null;
			_003CplayerAttributes_003E5__4 = null;
			AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder5 = (AsyncTaskMethodBuilder<LobbyResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			LobbySession lobbySession = default(LobbySession);
			((AsyncTaskMethodBuilder<LobbyResult>*)asyncTaskMethodBuilder5)->SetResult((LobbyResult)(&lobbySession));
			return;
			IL_06dd:
			string text2 = _003C_003E4__this.GenerateLobbyCode();
			PlayerAccount main = PlayerAccount.main;
			CloudService services = main.services;
			CloudRooms cloudRooms = services._003CRooms_003Ek__BackingField;
			CreateLobbyOptions createLobbyOptions = new CreateLobbyOptions();
			createLobbyOptions.MaxPlayers = 4;
			createLobbyOptions.Tag = text2;
			createLobbyOptions.Name = text2;
			createLobbyOptions.LobbyAttributes = _003ClobbyAttributes_003E5__3;
			createLobbyOptions.PlayerAttributes = _003CplayerAttributes_003E5__4;
			createLobbyOptions.Region = _003CbestRegion_003E5__2;
			Task<LobbySession> task11 = cloudRooms.lobbyService.CreateLobbyAsync(createLobbyOptions);
			_003Ctask_003E5__5 = task11;
			_003C_003E7__wrap5 = 0;
			goto IL_11e7;
			IL_1295:
			bool flag30 = obj17 == null;
			Exception ex = null;
			if (!flag30)
			{
				ex = ((Exception)exceptions2)._innerException;
			}
			if (ex != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3951 @ rax_v96 (System.Exception)+94]");
				if ((nint)0 == 27)
				{
					TimeSpan timeSpan = TimeSpan.Interval(value, 1000);
					nint num17 = (nint)typeof(TimeSpan);
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2sd xmm0,rbx\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"mulsd xmm0,xmm7\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,xmm8\"");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2562 @ rcx_v71 (Il2CppClass<System.TimeSpan>)+E4]");
					if ((nint)0 <= (nint)0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm6,xmm0\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2562 @ rcx_v71 (Il2CppClass<System.TimeSpan>)+E4]");
						if ((nint)0 <= (nint)0 && 1 <= (nint)obj)
						{
							Task task12 = Task.Delay(0, (CancellationToken)0);
							int num18 = task12.m_stateFlags & 0x1600000;
							bool flag31 = num18 == 0;
							bool flag32 = num18 < 0;
							bool flag33 = !flag32;
							object obj24 = !flag33;
							object obj25 = obj24 | flag31;
							task = task12;
							if (obj25 == null)
							{
								goto IL_0cc4;
							}
							_003C_003E1__state = 2;
							_003C_003Eu__3 = (TaskAwaiter)task12;
							AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder6 = (AsyncTaskMethodBuilder<LobbyResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
							TaskAwaiter awaiter3 = default(TaskAwaiter);
							((AsyncTaskMethodBuilder<LobbyResult>*)asyncTaskMethodBuilder6)->AwaitUnsafeOnCompleted(ref awaiter3, ref this);
							return;
						}
					}
					ArgumentOutOfRangeException ex2 = new ArgumentOutOfRangeException("delay", "The value needs to translate in milliseconds to -1 (signifying an infinite timeout), 0 or a positive integer less than or equal to Int32.MaxValue.");
					throw ex2;
				}
			}
			goto IL_0d3f;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CGetBestRegion_003Ed__23 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

		public LobbiesManager _003C_003E4__this;

		private string _003CbestRegion_003E5__2;

		private long _003CbestRtt_003E5__3;

		private PingResult _003CresultEu_003E5__4;

		private PingResult _003CresultUs_003E5__5;

		private PingResult _003CresultUsw_003E5__6;

		private TaskAwaiter<PingResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_01d9: Expected O, but got I4
			//IL_01e8: Expected I4, but got I8
			//IL_0015: Expected O, but got I4
			//IL_01b0: Expected O, but got I4
			//IL_01bf: Expected I4, but got I8
			//IL_024c: Expected O, but got I
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0031: Expected O, but got Unknown
			//IL_0187: Expected O, but got I4
			//IL_0196: Expected I4, but got I8
			//IL_0341: Expected O, but got I
			//IL_015e: Expected O, but got I4
			//IL_016d: Expected I4, but got I8
			//IL_0436: Expected O, but got I
			//IL_02c9: Expected O, but got I4
			//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
			//IL_02d6: Expected O, but got Unknown
			//IL_03be: Expected O, but got I4
			//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
			//IL_03cb: Expected O, but got Unknown
			//IL_084f: Expected O, but got Ref
			//IL_04b3: Expected O, but got I4
			//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
			//IL_04c0: Expected O, but got Unknown
			//IL_0812: Expected O, but got Ref
			//IL_077a: Expected I4, but got I8
			//IL_00f8: Expected O, but got I4
			//IL_0100: Unknown result type (might be due to invalid IL or missing references)
			//IL_0105: Expected O, but got Unknown
			//IL_07d5: Expected O, but got Ref
			//IL_0796: Expected O, but got Ref
			//IL_059e: Expected I8, but got I
			//IL_0633: Expected I8, but got I
			//IL_0140: Expected O, but got Ref
			//IL_06c8: Expected I8, but got I
			bool flag = _003C_003E1__state == 0;
			Task task;
			Task task2;
			Task task3;
			Task task4;
			TaskAwaiter<PingResult> awaiter = default(TaskAwaiter<PingResult>);
			if (!flag)
			{
				object obj = _003C_003E1__state - 1;
				if (flag)
				{
					_003C_003Eu__1 = (TaskAwaiter<PingResult>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					goto IL_02ec;
				}
				object obj2 = obj - 1;
				if (flag)
				{
					_003C_003Eu__1 = (TaskAwaiter<PingResult>)0;
					_003C_003E1__state = -1;
					task2 = (Task)_003C_003Eu__1;
					goto IL_03e1;
				}
				if ((nint)obj2 == 1)
				{
					_003C_003Eu__1 = (TaskAwaiter<PingResult>)0;
					_003C_003E1__state = -1;
					task3 = (Task)_003C_003Eu__1;
					goto IL_04d6;
				}
				_003CbestRegion_003E5__2 = "eu";
				_003CbestRtt_003E5__3 = 9223372036854775807L;
				Task<PingResult> rTTForRegion = _003C_003E4__this.GetRTTForRegion("eu");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<PingResult> taskAwaiter = default(TaskAwaiter<PingResult>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag2 = num == 0;
				bool flag3 = num < 0;
				bool flag4 = !flag3;
				object obj3 = !flag2;
				object obj4 = flag4 & obj3;
				task4 = (Task)taskAwaiter;
				if (obj4 == null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			else
			{
				_003C_003Eu__1 = (TaskAwaiter<PingResult>)0;
				_003C_003E1__state = -1;
				task4 = (Task)_003C_003Eu__1;
			}
			int num2 = task4.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task4);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ rbx_v1 (System.Threading.Tasks.Task)+50]");
			_003CresultEu_003E5__4 = (PingResult)0;
			Task<PingResult> rTTForRegion2 = _003C_003E4__this.GetRTTForRegion("us");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			TaskAwaiter<PingResult> taskAwaiter2 = default(TaskAwaiter<PingResult>);
			int num3 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
			bool flag5 = num3 == 0;
			bool flag6 = num3 < 0;
			bool flag7 = !flag6;
			object obj5 = !flag7;
			object obj6 = obj5 | flag5;
			task = (Task)taskAwaiter2;
			if (obj6 == null)
			{
				goto IL_02ec;
			}
			_003C_003E1__state = 1;
			_003C_003Eu__1 = taskAwaiter2;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
			return;
			IL_02ec:
			int num4 = task.m_stateFlags & 0x11000000;
			if (num4 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rbx_v22 (System.Threading.Tasks.Task)+50]");
			_003CresultUs_003E5__5 = (PingResult)0;
			Task<PingResult> rTTForRegion3 = _003C_003E4__this.GetRTTForRegion("usw");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			TaskAwaiter<PingResult> taskAwaiter3 = default(TaskAwaiter<PingResult>);
			int num5 = ((Task)taskAwaiter3).m_stateFlags & 0x1600000;
			bool flag8 = num5 == 0;
			bool flag9 = num5 < 0;
			bool flag10 = !flag9;
			object obj7 = !flag10;
			object obj8 = obj7 | flag8;
			task2 = (Task)taskAwaiter3;
			if (obj8 == null)
			{
				goto IL_03e1;
			}
			_003C_003E1__state = 2;
			_003C_003Eu__1 = taskAwaiter3;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
			return;
			IL_03e1:
			int num6 = task2.m_stateFlags & 0x11000000;
			if (num6 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v258 @ rbx_v20 (System.Threading.Tasks.Task)+50]");
			_003CresultUsw_003E5__6 = (PingResult)0;
			Task<PingResult> rTTForRegion4 = _003C_003E4__this.GetRTTForRegion("ap");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
			TaskAwaiter<PingResult> taskAwaiter4 = default(TaskAwaiter<PingResult>);
			int num7 = ((Task)taskAwaiter4).m_stateFlags & 0x1600000;
			bool flag11 = num7 == 0;
			bool flag12 = num7 < 0;
			bool flag13 = !flag12;
			object obj9 = !flag13;
			object obj10 = obj9 | flag11;
			task3 = (Task)taskAwaiter4;
			if (obj10 == null)
			{
				goto IL_04d6;
			}
			_003C_003E1__state = 3;
			_003C_003Eu__1 = taskAwaiter4;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
			return;
			IL_04d6:
			int num8 = task3.m_stateFlags & 0x11000000;
			if (num8 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task3);
			}
			if ((object)_003CresultEu_003E5__4 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,qword ptr [rdi+40h]\"");
				if (0 > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.LobbiesManager+<GetBestRegion>d__23)+40]");
					if (0 < _003CbestRtt_003E5__3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.LobbiesManager+<GetBestRegion>d__23)+40]");
						_003CbestRtt_003E5__3 = 0L;
						_003CbestRegion_003E5__2 = "eu";
					}
				}
			}
			if ((object)_003CresultUs_003E5__5 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,qword ptr [rdi+50h]\"");
				if (0 > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.LobbiesManager+<GetBestRegion>d__23)+50]");
					if (0 < _003CbestRtt_003E5__3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.LobbiesManager+<GetBestRegion>d__23)+50]");
						_003CbestRtt_003E5__3 = 0L;
						_003CbestRegion_003E5__2 = "us";
					}
				}
			}
			if ((object)_003CresultUsw_003E5__6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,qword ptr [rdi+60h]\"");
				if (0 > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.LobbiesManager+<GetBestRegion>d__23)+60]");
					if (0 < _003CbestRtt_003E5__3)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.LobbiesManager+<GetBestRegion>d__23)+60]");
						_003CbestRtt_003E5__3 = 0L;
						_003CbestRegion_003E5__2 = "usw";
					}
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rbx_v18 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm2,8\"");
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsi2ss xmm0,rax\"");
				if (0 > 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ rbx_v18 (System.Threading.Tasks.Task)+50]");
					if (0 < _003CbestRtt_003E5__3)
					{
						_003CbestRegion_003E5__2 = "ap";
					}
				}
			}
			_003C_003E1__state = -2;
			_003CbestRegion_003E5__2 = null;
			AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder5 = (AsyncTaskMethodBuilder<object>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<object>*)asyncTaskMethodBuilder5)->SetResult(_003CbestRegion_003E5__2);
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CGetRTTForRegion_003Ed__24 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<PingResult> _003C_003Et__builder;

		public string region;

		public LobbiesManager _003C_003E4__this;

		private Ping _003Cping_003E5__2;

		private float _003Ctimeout_003E5__3;

		private TaskAwaiter<IPHostEntry> _003C_003Eu__1;

		private TaskAwaiter _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005c: Expected O, but got I4
			//IL_006b: Expected I4, but got I8
			//IL_0075: Expected O, but got I4
			//IL_0193: Expected O, but got I
			//IL_0720: Expected O, but got F4
			//IL_01a8: Expected O, but got I
			//IL_01b6: Expected O, but got I4
			//IL_00e4: Expected O, but got I
			//IL_011c: Expected O, but got I4
			//IL_0124: Unknown result type (might be due to invalid IL or missing references)
			//IL_0129: Expected O, but got Unknown
			//IL_0336: Invalid comparison between F4 and O
			//IL_0697: Expected O, but got Ref
			//IL_01f2: Expected O, but got I
			//IL_06ed: Expected O, but got I4
			//IL_05df: Unknown result type (might be due to invalid IL or missing references)
			//IL_05e4: Expected O, but got Unknown
			//IL_07ae: Expected I4, but got I8
			//IL_0366: Expected O, but got I4
			//IL_0375: Expected I, but got O
			//IL_065f: Expected O, but got Ref
			//IL_066c: Expected O, but got Ref
			//IL_03ca: Expected O, but got I4
			//IL_03d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_03d7: Expected O, but got Unknown
			//IL_03e1: Expected O, but got F4
			//IL_0755: Expected O, but got I4
			//IL_0463: Expected O, but got Ref
			//IL_02df: Expected I, but got O
			//IL_0300: Expected O, but got I4
			//IL_078b: Expected O, but got I4
			//IL_0790->IL079f: Incompatible stack heights: 5 vs 0
			LobbiesManager lobbiesManager = _003C_003E4__this;
			Task task;
			object obj;
			Task task2;
			nint num;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<IPHostEntry>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E1__state == 1)
				{
					_003C_003Eu__2 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					obj = 0;
					task2 = (Task)_003C_003Eu__2;
					goto IL_03f8;
				}
				string hostNameOrAddress = _regionUrls.get_Item(region);
				Task<IPHostEntry> hostEntryAsync = Dns.GetHostEntryAsync(hostNameOrAddress);
				Task<IPHostEntry> task3 = hostEntryAsync;
				num = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1822 @ rax_v225 (System.Threading.Tasks.Task`1<System.Net.IPHostEntry>)+38]");
				object obj2 = (nint)0 & (nint)0x1600000;
				bool flag = obj2 == null;
				bool flag2 = (nint)obj2 < 0;
				bool flag3 = !flag2;
				object obj3 = !flag3;
				object obj4 = obj3 | flag;
				task = hostEntryAsync;
				if (obj4 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<IPHostEntry>)hostEntryAsync;
					AsyncTaskMethodBuilder<PingResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<PingResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<IPHostEntry> awaiter = default(TaskAwaiter<IPHostEntry>);
					((AsyncTaskMethodBuilder<PingResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rbx_v46 (System.Threading.Tasks.Task)+50]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v514 @ rdx_v82+20]");
			object obj6 = 0;
			CancellationToken cancellationToken = (CancellationToken)0;
			while (true)
			{
				CancellationToken cancellationToken2 = cancellationToken;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rdx_v83+18]");
				if ((nint)cancellationToken2 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rdx_v83+20+v970 @ rax_v169 (System.Threading.CancellationToken)*8]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v973 @ rcx_v125+18]");
					if ((nint)0 == 0)
					{
						goto IL_021f;
					}
					cancellationToken = (CancellationToken)(cancellationToken + 1);
					continue;
				}
				break;
			}
			(string, object)[] args = new(string, object)[1];
			(string, object) tuple = ("Region", region);
			lobbiesManager._logger.Error("Failed to get IP address for region", args);
			goto IL_079f;
			IL_03f8:
			int num3 = task2.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			object obj8 = Time.deltaTime;
			(string, object) tuple2 = default((string, object));
			float num4 = _003Ctimeout_003E5__3 - (float)tuple2;
			_003Ctimeout_003E5__3 = num4;
			goto IL_0790;
			IL_0476:
			(string, object)[] args2 = new(string, object)[3];
			bool isDone = _003Cping_003E5__2.isDone;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item = default(object);
			(string, object) tuple3 = ("Finished successfully", item);
			(string, object) tuple4 = ("Region", region);
			object obj9 = _003Cping_003E5__2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2746 @ rcx_v18 (System.Object)+10]");
			bool flag4 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2746 @ rcx_v18 (System.Object)+10]");
			object obj10 = Ping.get_time_Injected((IntPtr)0);
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item2 = default(object);
			(string, object) tuple5 = ("Time", item2);
			bool flag5 = lobbiesManager._logger == null;
			lobbiesManager._logger.Info("Ping done", args2);
			bool flag6 = _003Cping_003E5__2 == null;
			bool isDone2 = _003Cping_003E5__2.isDone;
			object obj11 = _003Cping_003E5__2;
			bool flag7 = _003Cping_003E5__2 == null;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2148 @ rcx_v26 (System.Object)+10]");
			bool flag8 = (nint)0 == 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2148 @ rcx_v26 (System.Object)+10]");
			object obj12 = Ping.get_time_Injected((IntPtr)0);
			goto IL_079f;
			IL_079f:
			_003C_003E1__state = -2;
			_003Cping_003E5__2 = null;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,7\"");
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm1,8\"");
			AsyncTaskMethodBuilder<PingResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<PingResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			bool flag9 = default(bool);
			((AsyncTaskMethodBuilder<PingResult>*)asyncTaskMethodBuilder2)->SetResult((PingResult)(&flag9));
			return;
			IL_0790:
			Ping ping = _003Cping_003E5__2;
			if (ping.m_Ptr != (IntPtr)0)
			{
				object obj13 = Ping.Internal_IsDone_Injected(ping.m_Ptr);
				if (obj13 != null)
				{
					goto IL_0476;
				}
			}
			float num5 = _003Ctimeout_003E5__3;
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)num5) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
			{
				Task task4 = Task.Delay(1, (CancellationToken)0);
				num = unchecked((nint)null);
				int num6 = task4.m_stateFlags & 0x1600000;
				bool flag10 = num6 == 0;
				bool flag11 = num6 < 0;
				bool flag12 = !flag11;
				object obj14 = !flag12;
				object obj15 = obj14 | flag10;
				tuple2 = ((string, object))_003Ctimeout_003E5__3;
				task2 = task4;
				if (obj15 == null)
				{
					goto IL_03f8;
				}
				_003C_003E1__state = 1;
				_003C_003Eu__2 = (TaskAwaiter)task4;
				AsyncTaskMethodBuilder<PingResult> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<PingResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				TaskAwaiter awaiter2 = default(TaskAwaiter);
				((AsyncTaskMethodBuilder<PingResult>*)asyncTaskMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
				return;
			}
			goto IL_0476;
			IL_021f:
			Coherence.Log.Logger logger = lobbiesManager._logger;
			(string, object)[] array = new(string, object)[2];
			(string, object) tuple6 = ("Region", region);
			object obj16 = default(object);
			(string, object) tuple7 = ("ip", obj16);
			logger.Info("Starting Ping", array);
			string address = obj16.ToString();
			Ping ping2 = null;
			IntPtr ptr = Ping.Internal_Create(address);
			ping2.m_Ptr = ptr;
			_003Cping_003E5__2 = ping2;
			num = (nint)array;
			_003Ctimeout_003E5__3 = 2f;
			tuple2 = tuple7;
			obj = 0;
			goto IL_0790;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CJoinLobby_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<LobbyResult> _003C_003Et__builder;

		public LobbiesManager _003C_003E4__this;

		public string tag;

		private Task<IReadOnlyList<LobbyData>> _003Ctask_003E5__2;

		private Task<LobbySession> _003CjoinTask_003E5__3;

		private TaskAwaiter<IReadOnlyList<LobbyData>> _003C_003Eu__1;

		private TaskAwaiter<LobbySession> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_0287: Expected O, but got I4
			//IL_0274: Expected O, but got I4
			//IL_0240: Expected O, but got I4
			//IL_024f: Expected I4, but got I8
			//IL_025c: Expected I4, but got I8
			//IL_0891: Expected O, but got I4
			//IL_08a0: Expected I4, but got I8
			//IL_02da: Expected O, but got I
			//IL_0312: Expected O, but got I4
			//IL_031a: Unknown result type (might be due to invalid IL or missing references)
			//IL_031f: Expected O, but got Unknown
			//IL_0390: Expected O, but got I
			//IL_03cc: Expected O, but got I
			//IL_092d: Expected O, but got I4
			//IL_0935: Unknown result type (might be due to invalid IL or missing references)
			//IL_093a: Expected O, but got Unknown
			//IL_09a9: Expected O, but got I
			//IL_0ab3: Expected O, but got Ref
			//IL_09e5: Expected O, but got I
			//IL_0be9: Expected I4, but got I8
			//IL_0a2c: Expected O, but got Ref
			//IL_0144: Expected O, but got Ref
			//IL_041d: Expected O, but got I
			//IL_0462: Expected O, but got I
			//IL_0470: Expected I, but got O
			//IL_0ae2: Expected O, but got Ref
			//IL_0aef: Expected O, but got Ref
			//IL_0487: Expected O, but got Ref
			//IL_04eb: Expected O, but got Ref
			//IL_0508: Expected O, but got I
			//IL_0549: Expected O, but got Ref
			//IL_05ad: Expected O, but got Ref
			//IL_05ca: Expected O, but got I
			//IL_0611: Expected O, but got Ref
			//IL_0197: Expected O, but got I
			//IL_01ac: Expected O, but got I
			//IL_01e9: Expected O, but got Ref
			//IL_0210: Expected O, but got I
			//IL_0663: Expected O, but got I4
			//IL_0675: Expected O, but got Ref
			//IL_068d: Expected O, but got I4
			//IL_068d: Expected I8, but got I4
			//IL_069f: Expected O, but got Ref
			//IL_06ca: Expected O, but got I4
			//IL_06d7: Expected O, but got Ref
			//IL_070e: Expected O, but got I4
			//IL_071b: Expected O, but got Ref
			//IL_0738: Expected O, but got Ref
			//IL_074d: Expected O, but got I
			//IL_0762: Expected O, but got I
			//IL_076f: Expected O, but got Ref
			//IL_0777: Expected O, but got Ref
			//IL_07db: Expected O, but got Ref
			//IL_07f8: Expected O, but got I
			//IL_0815: Expected O, but got I
			//IL_0832: Expected O, but got I
			//IL_0866: Expected O, but got Ref
			//IL_0866: Expected O, but got I
			int num = _003C_003E1__state;
			LobbiesManager lobbiesManager = _003C_003E4__this;
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string text2 = default(string);
			if (_003C_003E1__state != 0)
			{
				if (_003C_003E1__state == 1)
				{
					LobbyFilter lobbyFilter = (LobbyFilter)0;
					string text = null;
					goto IL_0bfa;
				}
				if (lobbiesManager._activeLobby != null)
				{
					LobbySession activeLobby = lobbiesManager._activeLobby;
					if (!activeLobby._003CIsDisposed_003Ek__BackingField)
					{
						string translation = LocalizationManager.GetTranslation("onlineLang/ErrorAlreadyInGameDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
						goto IL_0bda;
					}
				}
				LobbyFilter lobbyFilter3 = default(LobbyFilter);
				LobbyFilter lobbyFilter2 = lobbyFilter3.WithFilterGroup(FilterGroupOperator.And);
				string logicOperator = lobbyFilter2.logicOperator;
				LobbyFilter values = (LobbyFilter)lobbyFilter2.values;
				List<string> list = new List<string>();
				list.Add(tag);
				LobbyFilter lobbyFilter4 = lobbyFilter3.WithTag(FilterOperator.Equals, list);
				LobbyFilter lobbyFilter5 = DisableCrossplay((LobbyFilter)(&text2));
				string text3 = default(string);
				object obj = (LobbyFilter)text3;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AD6810");
				object message = default(object);
				Debug.Log(message);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AA36A0");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2920 @ rax_v231+28]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2971 @ rcx_v142+20]");
				object obj3 = 0;
				FindLobbyOptions findLobbyOptions = new FindLobbyOptions();
				findLobbyOptions.Limit = 10;
				List<LobbyFilter> list2 = new List<LobbyFilter>();
				list2.Add((LobbyFilter)(&text3));
				findLobbyOptions.LobbyFilters = list2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3065 @ rax_v236+30]");
				Task<IReadOnlyList<LobbyData>> task = ((LobbiesService)0).FindLobbiesAsync(findLobbyOptions);
				_003Ctask_003E5__2 = task;
				List<CloudAttribute> list3 = null;
				List<string> list4 = list;
			}
			else
			{
				LobbyFilter values = (LobbyFilter)0;
				string logicOperator = null;
			}
			Task task2;
			if (num == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<IReadOnlyList<LobbyData>>)0;
				_003C_003E1__state = -1;
				num = -1;
				task2 = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<IReadOnlyList<LobbyData>> task3 = _003Ctask_003E5__2;
				if (_003Ctask_003E5__2 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v362 @ rax_v90 (System.Threading.Tasks.Task`1<System.Collections.Generic.IReadOnlyList`1<Coherence.Cloud.LobbyData>>)+38]");
				object obj4 = (nint)0 & (nint)0x1600000;
				bool flag = obj4 == null;
				bool flag2 = (nint)obj4 < 0;
				bool flag3 = !flag2;
				object obj5 = !flag3;
				object obj6 = obj5 | flag;
				task2 = _003Ctask_003E5__2;
				if (obj6 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<IReadOnlyList<LobbyData>>)_003Ctask_003E5__2;
					AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<LobbyResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<object> awaiter = default(TaskAwaiter<object>);
					((AsyncTaskMethodBuilder<LobbyResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task2.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
			}
			Task<IReadOnlyList<LobbyData>> task4 = _003Ctask_003E5__2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1279 @ rcx_v8 (System.Threading.Tasks.Task`1<System.Collections.Generic.IReadOnlyList`1<Coherence.Cloud.LobbyData>>)+38]");
			object obj7 = (nint)0 & (nint)0x11000000;
			if ((nint)obj7 != 16777216)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806F7870");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1279 @ rcx_v8 (System.Threading.Tasks.Task`1<System.Collections.Generic.IReadOnlyList`1<Coherence.Cloud.LobbyData>>)+50]");
				object obj8 = 0;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj9 = default(object);
			if (obj9 != null)
			{
				Task<IReadOnlyList<LobbyData>> task5 = _003Ctask_003E5__2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2538 @ rcx_v16 (System.Threading.Tasks.Task`1<System.Collections.Generic.IReadOnlyList`1<Coherence.Cloud.LobbyData>>)+38]");
				object obj10 = (nint)0 & (nint)0x11000000;
				if ((nint)obj10 != 16777216)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806F7870");
					nint num3 = 1;
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2538 @ rcx_v16 (System.Threading.Tasks.Task`1<System.Collections.Generic.IReadOnlyList`1<Coherence.Cloud.LobbyData>>)+50]");
					object obj11 = 0;
					nint num3 = (nint)typeof(IReadOnlyCollection<LobbyData>);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806C6930");
				object obj13 = default(object);
				object obj12 = (object)(&obj13);
				object obj14 = default(object);
				obj12 = obj14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+60]");
				_ = 0;
				object obj15 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj13, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+80]");
				obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+90]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+A0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+B0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+C0]");
				_ = 0;
				object obj17 = default(object);
				object obj16 = (object)(&obj17);
				obj16 = obj14;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+10]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+20]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+30]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+40]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+60]");
				_ = 0;
				object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj17, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+80]");
				obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+90]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+A0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+B0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2841 @ rax_v30+C0]");
				_ = 0;
				if (_003C_003E4__this.CheckAttributes((LobbyData)(&obj17), out var _))
				{
					List<CloudAttribute> list5 = new List<CloudAttribute>();
					IBaseAccount account = SystemPlatform.Account;
					CloudAttribute cloudAttribute = new CloudAttribute(LobbyAttributeKeys.PlayerName, account.m_Name, (bool?)(object)257);
					CloudAttribute cloudAttribute2 = default(CloudAttribute);
					list5.Add((CloudAttribute)(&cloudAttribute2));
					CloudAttribute cloudAttribute3 = new CloudAttribute(LobbyAttributeKeys.PlayerPlatform, (long)SystemPlatform.Platform, (bool?)(object)257);
					list5.Add((CloudAttribute)(&cloudAttribute2));
					string currentlyLoadedDLCAsString = _003C_003E4__this.GetCurrentlyLoadedDLCAsString();
					CloudAttribute cloudAttribute4 = new CloudAttribute(LobbyAttributeKeys.PlayerLoadedDLCS, currentlyLoadedDLCAsString, (bool?)(object)257);
					list5.Add((CloudAttribute)(&cloudAttribute2));
					IBaseAccount account2 = SystemPlatform.Account;
					string uniqueAccountID = account2.UniqueAccountID;
					CloudAttribute cloudAttribute5 = new CloudAttribute(LobbyAttributeKeys.PlayerPlatformID, uniqueAccountID, (bool?)(object)257);
					list5.Add((CloudAttribute)(&cloudAttribute2));
					((List<CloudAttribute>)(object)typeof(PlayerAccount)).Add((CloudAttribute)(&cloudAttribute2));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1820 @ rax_v69+28]");
					object obj19 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1512 @ rcx_v52+20]");
					object obj20 = 0;
					object obj21 = (object)(&obj17);
					object obj22 = (object)(&obj13);
					obj21 = obj22;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+10]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+20]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+30]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+40]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+60]");
					_ = 0;
					object obj23 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj17, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+70]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+80]");
					obj23 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+90]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+A0]");
					string text = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+A0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+B0]");
					LobbyFilter lobbyFilter = (LobbyFilter)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+B0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v3440 @ rax_v71+C0]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1275 @ rax_v70+30]");
					Task<LobbySession> task6 = ((LobbiesService)0).JoinLobbyAsync((LobbyData)(&obj17), list5);
					_003CjoinTask_003E5__3 = task6;
					List<CloudAttribute> list3 = list5;
					List<string> list4 = null;
					goto IL_0bfa;
				}
			}
			else
			{
				string translation2 = LocalizationManager.GetTranslation("onlineLang/ErrorNoGameWithIDDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			}
			goto IL_0bda;
			IL_0bfa:
			Task task7;
			if (num == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter<LobbySession>)0;
				_003C_003E1__state = -1;
				task7 = (Task)_003C_003Eu__2;
			}
			else
			{
				if (_003CjoinTask_003E5__3 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<object> taskAwaiter = default(TaskAwaiter<object>);
				int num4 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag4 = num4 == 0;
				bool flag5 = num4 < 0;
				bool flag6 = !flag5;
				object obj24 = !flag6;
				object obj25 = obj24 | flag4;
				task7 = (Task)taskAwaiter;
				if (obj25 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = (TaskAwaiter<LobbySession>)taskAwaiter;
					AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<LobbyResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<object> awaiter2 = default(TaskAwaiter<object>);
					((AsyncTaskMethodBuilder<LobbyResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
			}
			int num5 = task7.m_stateFlags & 0x11000000;
			if (num5 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task7);
			}
			Task<LobbySession> task8 = _003CjoinTask_003E5__3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v77 (System.Threading.Tasks.Task`1<Coherence.Cloud.LobbySession>)+38]");
			object obj26 = (nint)0 & (nint)0x11000000;
			LobbySession activeLobby2 = default(LobbySession);
			if ((nint)obj26 != 16777216)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806F7870");
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v451 @ rcx_v77 (System.Threading.Tasks.Task`1<Coherence.Cloud.LobbySession>)+50]");
				activeLobby2 = (LobbySession)0;
			}
			lobbiesManager._activeLobby = activeLobby2;
			goto IL_0bda;
			IL_0bda:
			_003C_003E1__state = -2;
			_003Ctask_003E5__2 = null;
			_003CjoinTask_003E5__3 = null;
			AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<LobbyResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<LobbyResult>*)asyncTaskMethodBuilder3)->SetResult((LobbyResult)(&text2));
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CLeaveLobby_003Ed__18 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public LobbiesManager _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0239: Expected O, but got I4
			//IL_0248: Expected I4, but got I8
			//IL_0459: Expected I4, but got I8
			//IL_0315: Expected O, but got I4
			//IL_031d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0322: Expected O, but got Unknown
			//IL_03e0: Expected O, but got Ref
			//IL_0080: Expected O, but got Ref
			//IL_00e9: Expected O, but got Ref
			//IL_0106: Expected O, but got I
			//IL_015d: Expected O, but got Ref
			//IL_01c6: Expected O, but got Ref
			//IL_01e3: Expected O, but got I
			//IL_03c2: Expected O, but got Ref
			LobbiesManager lobbiesManager = _003C_003E4__this;
			bool flag = _003C_003E1__state == 0;
			Task<bool> task = null;
			bool result;
			if (!flag)
			{
				if (lobbiesManager._activeLobby != null)
				{
					LobbySession activeLobby = lobbiesManager._activeLobby;
					if (!activeLobby._003CIsDisposed_003Ek__BackingField)
					{
						Task<bool> task2 = activeLobby.LeaveLobbyAsync();
						LobbySession activeLobby2 = lobbiesManager._activeLobby;
						object obj2 = default(object);
						object obj = (object)(&obj2);
						obj = activeLobby2.lobbyData;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+28]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+38]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+48]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+58]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+68]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+78]");
						_ = 0;
						object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+88]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+98]");
						obj3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+A8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+B8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+C8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v437 @ rax_v66 (Coherence.Cloud.LobbySession)+D8]");
						_ = 0;
						string lobbyID = default(string);
						OnlinePlatformSupport.OnLobbyClosed(lobbyID);
						LobbySession activeLobby3 = lobbiesManager._activeLobby;
						object obj4 = (object)(&obj2);
						obj4 = activeLobby3.lobbyData;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+28]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+38]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+48]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+58]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+68]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+78]");
						_ = 0;
						object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+88]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+98]");
						obj5 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+A8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+B8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+C8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v569 @ rax_v71 (Coherence.Cloud.LobbySession)+D8]");
						_ = 0;
						OnlinePlatformSupport.OnEndOnlineSession(lobbyID, null);
						task = task2;
						goto IL_0463;
					}
				}
				lobbiesManager._activeLobby = null;
				(string, object)[] args = Array.Empty<(string, object)>();
				lobbiesManager._logger.Error("No active Lobby to leave.", args);
				result = true;
				goto IL_044a;
			}
			goto IL_0463;
			IL_044a:
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->SetResult(result);
			return;
			IL_0463:
			Task task3;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task3 = (Task)_003C_003Eu__1;
			}
			else
			{
				if (task == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag2 = num == 0;
				bool flag3 = num < 0;
				bool flag4 = !flag3;
				object obj6 = !flag4;
				object obj7 = obj6 | flag2;
				task3 = (Task)taskAwaiter;
				if (obj7 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task3.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task3);
			}
			lobbiesManager._activeLobby = null;
			result = true;
			goto IL_044a;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private LobbySession _activeLobby;

	private readonly Coherence.Log.Logger _logger;

	private static Dictionary<string, string> _regionUrls;

	private static HashSet<SystemPlatformTypes> _specialPlatforms;

	private const string InviteCodeAlphabet = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";

	private const int InviteCodeLength = 6;

	public LobbySession ActiveLobby => _activeLobby;

	public bool IsPartOfLobby
	{
		get
		{
			if (_activeLobby == null)
			{
				return false;
			}
			LobbySession activeLobby = _activeLobby;
			return !activeLobby._003CIsDisposed_003Ek__BackingField;
		}
	}

	public bool IsHost
	{
		get
		{
			if (_activeLobby != null)
			{
				LobbySession activeLobby = _activeLobby;
				if (!activeLobby._003CIsDisposed_003Ek__BackingField)
				{
					bool flag = (nint)activeLobby.lobbyOwnerSession < 0;
					bool flag2 = activeLobby.lobbyOwnerSession == null;
					bool flag3 = !flag;
					bool flag4 = !flag2;
					return flag4 & flag3;
				}
			}
			return false;
		}
	}

	public void Initialize()
	{
	}

	public void Dispose()
	{
	}

	public Task<LobbyResult> CreateNewLobby()
	{
		AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<LobbyResult>);
		_003CCreateNewLobby_003Ed__15 stateMachine = default(_003CCreateNewLobby_003Ed__15);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public Task<LobbyResult> JoinLobby(string tag)
	{
		AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<LobbyResult>);
		_003CJoinLobby_003Ed__16 stateMachine = default(_003CJoinLobby_003Ed__16);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	private unsafe static LobbyFilter DisableCrossplay(LobbyFilter filter)
	{
		//IL_01f9: Expected native int or pointer, but got O
		//IL_0251: Expected native int or pointer, but got O
		//IL_00c3: Expected O, but got I4
		//IL_023a: Expected native int or pointer, but got O
		//IL_0098: Expected native int or pointer, but got O
		//IL_00aa: Expected native int or pointer, but got O
		//IL_0129: Expected native int or pointer, but got O
		//IL_013b: Expected native int or pointer, but got O
		//IL_016d: Expected native int or pointer, but got O
		//IL_017f: Expected native int or pointer, but got O
		//IL_01a3: Expected native int or pointer, but got O
		//IL_01b5: Expected native int or pointer, but got O
		List<object> values;
		LobbyFilter lobbyFilter9 = default(LobbyFilter);
		if (_specialPlatforms != null)
		{
			int value = default(int);
			if (_specialPlatforms.Contains(SystemPlatform.Platform))
			{
				LobbyFilter lobbyFilter3 = default(LobbyFilter);
				if (SystemPlatform.Platform <= SystemPlatformTypes.IOS)
				{
					LobbyFilter lobbyFilter = ((LobbyFilter*)filter)->WithFilterGroup(FilterGroupOperator.Or);
					LobbyFilter lobbyFilter2 = lobbyFilter3.WithIntAttribute(FilterOperator.Equals, IntAttributeIndex.n1, value);
					System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)filter)->logicOperator, lobbyFilter2.logicOperator);
					System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)filter)->values, lobbyFilter2.values);
				}
				else
				{
					object obj = SystemPlatform.Platform + -2;
					if ((nint)obj > 1)
					{
						goto IL_0220;
					}
					LobbyFilter lobbyFilter4 = ((LobbyFilter*)filter)->WithFilterGroup(FilterGroupOperator.Or);
					LobbyFilter lobbyFilter5 = lobbyFilter3.WithIntAttribute(FilterOperator.Equals, IntAttributeIndex.n1, value);
					System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)filter)->logicOperator, lobbyFilter5.logicOperator);
					System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)filter)->values, lobbyFilter5.values);
				}
				LobbyFilter lobbyFilter6 = ((LobbyFilter*)filter)->WithIntAttribute(FilterOperator.Equals, IntAttributeIndex.n1, value);
				System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)filter)->logicOperator, lobbyFilter6.logicOperator);
				System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)filter)->values, lobbyFilter6.values);
				LobbyFilter lobbyFilter7 = ((LobbyFilter*)filter)->End();
				System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)filter)->logicOperator, lobbyFilter7.logicOperator);
				System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)filter)->values, lobbyFilter7.values);
				goto IL_0220;
			}
			LobbyFilter lobbyFilter8 = ((LobbyFilter*)filter)->WithIntAttribute(FilterOperator.Equals, IntAttributeIndex.n1, value);
			values = lobbyFilter8.values;
			System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)lobbyFilter9)->logicOperator, lobbyFilter8.logicOperator);
			goto IL_0249;
		}
		return (LobbyFilter)new NullReferenceException();
		IL_0220:
		values = filter.values;
		System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)lobbyFilter9)->logicOperator, filter.logicOperator);
		goto IL_0249;
		IL_0249:
		System.Runtime.CompilerServices.Unsafe.Write(&((LobbyFilter*)(nint)lobbyFilter9)->values, values);
		return lobbyFilter9;
	}

	public Task<bool> LeaveLobby()
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CLeaveLobby_003Ed__18 stateMachine = default(_003CLeaveLobby_003Ed__18);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	public unsafe bool ArePlayersReadyToStartGame()
	{
		//IL_003c: Expected O, but got Ref
		//IL_00a5: Expected O, but got Ref
		//IL_00c7: Expected O, but got I
		//IL_00c2: Expected native int or pointer, but got O
		//IL_00dc: Expected O, but got I
		//IL_00d7: Expected native int or pointer, but got O
		//IL_00ec: Expected O, but got I
		//IL_0101: Expected O, but got I
		//IL_00fc: Expected native int or pointer, but got O
		//IL_0111: Expected O, but got I
		//IL_0142: Expected O, but got Ref
		//IL_014b: Expected O, but got I4
		//IL_018f: Expected O, but got I4
		//IL_01dd: Expected O, but got I
		//IL_01e6: Expected O, but got I4
		//IL_03d2: Expected O, but got Ref
		//IL_03ee: Expected O, but got I
		//IL_02f0: Expected O, but got I
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fe: Expected O, but got Unknown
		//IL_0285: Expected O, but got Ref
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		if (_activeLobby != null)
		{
			LobbySession activeLobby = _activeLobby;
			if (!activeLobby._003CIsDisposed_003Ek__BackingField)
			{
				object obj2 = default(object);
				object obj = (object)(&obj2);
				obj = activeLobby.lobbyData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+78]");
				_ = 0;
				CloudAttribute cloudAttribute = (CloudAttribute)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+98]");
				System.Runtime.CompilerServices.Unsafe.Write(&((CloudAttribute*)(nint)cloudAttribute)->key, (string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+A8]");
				((CloudAttribute*)(nint)cloudAttribute)->isPublic = (bool?)(object)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+B8]");
				string text = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+B8]");
				System.Runtime.CompilerServices.Unsafe.Write(&((CloudAttribute*)(nint)cloudAttribute)->aggregate, (string)0);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+C8]");
				CloudAttribute cloudAttribute2 = (CloudAttribute)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ rax_v5 (Coherence.Cloud.LobbySession)+D8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj4 = default(object);
				object obj3 = (object)(&obj4);
				CloudAttribute cloudAttribute3 = (CloudAttribute)0;
				object obj5 = default(object);
				object obj15 = default(object);
				LobbyPlayer lobbyPlayer = default(LobbyPlayer);
				object obj16 = default(object);
				CloudAttribute cloudAttribute5 = default(CloudAttribute);
				bool flag2;
				string text3 = default(string);
				CloudAttribute cloudAttribute6 = default(CloudAttribute);
				do
				{
					object obj14;
					if (obj4 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj5 != null)
						{
							bool flag = obj4 == null;
							cloudAttribute3 = (CloudAttribute)0;
							if (!flag)
							{
								object obj6 = obj4;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v6+12E]");
								if ((nint)0 >= (nint)0)
								{
									goto IL_021d;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v6+B0]");
								object obj7 = 0;
								object obj8 = 0;
								while (true)
								{
									object obj9 = obj8 + obj8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r8_v17+v460 @ rcx_v25*8]");
									if (0 == (nint)typeof(IEnumerator<LobbyPlayer>))
									{
										break;
									}
									obj8++;
									object obj10 = obj8;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ r10_v6+12E]");
									if ((nint)obj10 < 0)
									{
										continue;
									}
									goto IL_021d;
								}
								object obj11 = obj8 + obj8;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v455 @ r8_v17+8+v514 @ rcx_v27*8]");
								object obj12 = (nint)0 << 4;
								object obj13 = obj12 + 312;
								obj14 = obj13 + obj6;
								goto IL_0428;
							}
							throw new NullReferenceException();
						}
						if (obj3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
						}
						return true;
					}
					throw new NullReferenceException();
					IL_021d:
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
					obj14 = obj15;
					goto IL_0428;
					IL_0428:
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v520 @ r8_v10] (should have been resolved before IL gen)");
					CloudAttribute? attribute = lobbyPlayer.GetAttribute((string)(&obj16));
					string text2 = (string)attribute;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v561 @ rax_v26 (System.Nullable`1<Coherence.Cloud.CloudAttribute>)+10]");
					CloudAttribute cloudAttribute4 = (CloudAttribute)0;
					if (attribute == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
					long longValue = cloudAttribute5.GetLongValue();
					flag2 = longValue != 0;
					text2 = text3;
					cloudAttribute4 = cloudAttribute6;
					text = text3;
					cloudAttribute2 = cloudAttribute6;
					cloudAttribute3 = (CloudAttribute)(&cloudAttribute5);
				}
				while (flag2);
				if (obj3 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
			}
		}
		return false;
	}

	private unsafe bool CheckAttributes(LobbyData lobbyData, out string errorMessage)
	{
		//IL_01db: Expected O, but got I
		//IL_01eb: Expected O, but got I
		//IL_01cb: Expected I4, but got O
		//IL_0078: Expected O, but got Ref
		//IL_00d5: Expected O, but got Ref
		//IL_00f2: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2+B8]");
		object obj2 = 0;
		ref string reference = ref *(string*)obj2;
		if (lobbyData.players != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj3 = default(object);
			if (obj3 != null)
			{
				if (lobbyData.players == null)
				{
					goto IL_01bd;
				}
				object obj5 = default(object);
				object obj4 = (object)(&obj5);
				obj4 = lobbyData.Id;
				_ = lobbyData.Region;
				_ = lobbyData.MaxPlayers;
				_ = lobbyData.SimulatorSlug;
				_ = lobbyData.RoomData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbyData @ rdx (Coherence.Cloud.LobbyData)+50]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbyData @ rdx (Coherence.Cloud.LobbyData)+60]");
				_ = 0;
				object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj5, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbyData @ rdx (Coherence.Cloud.LobbyData)+70]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbyData @ rdx (Coherence.Cloud.LobbyData)+80]");
				obj6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbyData @ rdx (Coherence.Cloud.LobbyData)+90]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbyData @ rdx (Coherence.Cloud.LobbyData)+A0]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobbyData @ rdx (Coherence.Cloud.LobbyData)+B0]");
				_ = 0;
				_ = lobbyData.lobbyAttributes;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj7 = default(object);
				object obj8 = default(object);
				if (obj7 != obj8)
				{
					LobbyData lobbyData2 = default(LobbyData);
					CloudAttribute? attribute = lobbyData2.GetAttribute((string)lobbyData);
					if (attribute != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
						long longValue = ((CloudAttribute*)(&lobbyData2))->GetLongValue();
						if (longValue == 1)
						{
							reference = ref *(string*)"Game has already started. Aborting join.";
							goto IL_0193;
						}
					}
					return true;
				}
			}
			reference = ref *(string*)"Couldn't join game, it is either empty or full.";
			goto IL_0193;
		}
		goto IL_01bd;
		IL_01bd:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0193:
		return false;
	}

	private unsafe bool CheckHostDlcs(LobbyData lobbyData, out string errorMessage)
	{
		//IL_0010: Expected O, but got I
		//IL_0020: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v10 @ rax_v1+B8]");
		object obj2 = 0;
		ref string reference = ref *(string*)obj2;
		return true;
	}

	private unsafe string GenerateLobbyCode()
	{
		//IL_021b: Expected I4, but got O
		//IL_0040: Expected O, but got I
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Expected O, but got Unknown
		//IL_02c3: Expected I4, but got I8
		//IL_00d3: Expected O, but got I
		//IL_028f: Expected O, but got I4
		//IL_00a0: Expected O, but got I8
		System.Linq.Buffer<char> buffer = default(System.Linq.Buffer<char>);
		global::Interop.GetRandomBytes((byte*)(&buffer), 16);
		Guid guid = default(Guid);
		string source = guid.ToString("N", null);
		Func<char, char> selector = _003C_003Ec._003C_003E9__22_0;
		if (_003C_003Ec._003C_003E9__22_0 == null)
		{
			Func<char, char> func = null;
			char c = ((_003C_003Ec)(object)func)._003CGenerateLobbyCode_003Eb__22_0((char)(int)_003C_003Ec._003C_003E9);
			_003C_003Ec._003C_003E9__22_0 = func;
			selector = func;
		}
		IEnumerable<char> enumerable = Enumerable.Select(source, selector);
		Func<char, int> func2 = _003C_003Ec._003C_003E9__22_1;
		if (_003C_003Ec._003C_003E9__22_1 != null)
		{
			goto IL_00ef;
		}
		Func<char, int> func3 = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r9_v6 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		_ = _003C_003Ec._003C_003E9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r9_v6 (Il2CppMethodInfo)+4C]");
		object obj = (nint)0 >> 4;
		object obj2 = obj & 1;
		object obj3;
		if (obj2 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ r9_v6 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj3 = 6447984800L;
				goto IL_0286;
			}
		}
		else if (_003C_003Ec._003C_003E9 == null)
		{
			int num2 = ((_003C_003Ec)null)._003CGenerateLobbyCode_003Eb__22_1('\udce0');
			throw num2;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v57 (System.Func`2<System.Char, System.Int32>)+10]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v310 @ rax_v57 (System.Func`2<System.Char, System.Int32>)+20]");
		_ = 0;
		goto IL_0286;
		IL_0286:
		object obj4 = 24;
		_ = 6447984944L;
		_003C_003Ec._003C_003E9__22_1 = func3;
		func2 = func3;
		goto IL_00ef;
		IL_00ef:
		object obj5 = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @183A8DE30");
		if (obj5 != null)
		{
			IEnumerable<char> source2 = null;
			_ = 4294967294L;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184E7CF00");
			_ = 6;
			buffer = new System.Linq.Buffer<char>(source2);
			System.Linq.Buffer<char> buffer2 = default(System.Linq.Buffer<char>);
			char[] val = buffer2.ToArray();
			return ((string)null).CreateString(val);
		}
		Exception ex = System.Linq.Error.ArgumentNull("source");
		throw ex;
	}

	private Task<string> GetBestRegion()
	{
		AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
		_003CGetBestRegion_003Ed__23 stateMachine = default(_003CGetBestRegion_003Ed__23);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return (Task<string>)(object)asyncTaskMethodBuilder.Task;
	}

	private Task<PingResult> GetRTTForRegion(string region)
	{
		AsyncTaskMethodBuilder<PingResult> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<PingResult>);
		_003CGetRTTForRegion_003Ed__24 stateMachine = default(_003CGetRTTForRegion_003Ed__24);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	private unsafe bool TryGetFirstIPv4Address(IPAddress[] addressList, out IPAddress firstIPv4Address)
	{
		//IL_0009: Expected O, but got I4
		//IL_0012: Expected O, but got I4
		//IL_00bb: Expected I4, but got O
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Expected O, but got Unknown
		object obj = 0;
		object obj2 = 0;
		while (true)
		{
			ref IPAddress reference;
			if ((nint)obj < addressList.Length)
			{
				if ((nint)obj2 >= addressList.Length)
				{
					break;
				}
				IPAddress iPAddress = addressList[obj2];
				if (iPAddress._numbers != null)
				{
					obj2++;
					obj = obj2;
					continue;
				}
				reference = ref *(IPAddress*)iPAddress;
				return true;
			}
			reference = ref *(IPAddress*)null;
			return false;
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		return (byte)(int)ex != 0;
	}

	private unsafe string GetCurrentlyLoadedDLCAsString()
	{
		//IL_003f: Expected O, but got Ref
		Dictionary<DlcType, BundleManifestData> loadedDlc = DlcSystem.LoadedDlc;
		string text = "";
		Dictionary<DlcType, BundleManifestData>.Enumerator enumerator = default(Dictionary<DlcType, BundleManifestData>.Enumerator);
		object obj = default(object);
		while (enumerator.MoveNext())
		{
			string text2 = System.Number.FormatInt32(0, (ReadOnlySpan<char>)(&obj), null);
			string text3 = text + text2 + ",";
			text = text3;
		}
		return text;
	}

	public LobbiesManager()
	{
		Coherence.Log.Logger logger = Log.GetLogger<LobbiesManager>();
		_logger = logger;
	}

	static LobbiesManager()
	{
		Dictionary<string, string> dictionary = new Dictionary<string, string>();
		bool flag = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"us", (object)"ec2.us-east-1.amazonaws.com", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"usw", (object)"ec2.us-west-2.amazonaws.com", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"eu", (object)"ec2.eu-central-1.amazonaws.com", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<object, object>)(object)dictionary).TryInsert((object)"ap", (object)"ec2.ap-southeast-1.amazonaws.com", System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_regionUrls = dictionary;
		HashSet<SystemPlatformTypes> hashSet = (HashSet<SystemPlatformTypes>)(object)new HashSet<System.Int32Enum>();
		bool flag5 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)2);
		bool flag6 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)3);
		bool flag7 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)0);
		bool flag8 = ((HashSet<System.Int32Enum>)(object)hashSet).AddIfNotPresent((System.Int32Enum)1);
		_specialPlatforms = hashSet;
	}
}
