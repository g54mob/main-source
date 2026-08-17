using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence;
using Coherence.Cloud;
using Coherence.Common;
using Coherence.Connection;
using Coherence.Log;
using Coherence.Toolkit;
using Coherence.Toolkit.ReplicationServer;
using Cpp2ILInjected;
using I2.Loc;
using PlayFab.Party;
using SuperTiled2Unity;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VampireSurvivors.App.Scripts.Framework.Adventures;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.DLC;
using VampireSurvivors.Objects;
using Zenject;

namespace VampireSurvivors.UI;

public class RoomSelectionPage : BaseUIPage
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__57_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CShowConnectionLostPopup_003Eb__57_0()
		{
			GameManager core = GM.Core;
			if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
			{
				GM.Core.ResetGameToMenu();
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v11+10]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
					CoherenceBridge coherenceBridge = default(CoherenceBridge);
					if (coherenceBridge.IsConnected)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
						CoherenceBridge coherenceBridge2 = default(CoherenceBridge);
						coherenceBridge2.Disconnect();
					}
				}
			}
			SceneManager.LoadScene("ScenePreloader", LoadSceneMode.Additive);
		}
	}

	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public string lobbyTag;

		public RoomSelectionPage _003C_003E4__this;

		internal void _003CJoinRoom_003Eb__1(bool result)
		{
			_003C_003E4__this.OnLoggedInWithCoherenceAfterJoin(lobbyTag, result);
		}
	}

	private sealed class _003C_003Ec__DisplayClass73_0
	{
		public long ready;

		internal unsafe void _003CUpdateReadyState_003Eb__0(RequestResponse<bool> response)
		{
			//IL_0063: Expected I4, but got I8
			//IL_0077: Expected O, but got I
			//IL_00c0: Expected O, but got Ref
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			long num = default(long);
			object arg = (RequestStatus)num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [response @ rdx (Coherence.Cloud.RequestResponse`1<System.Boolean>)+8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [response @ rdx (Coherence.Cloud.RequestResponse`1<System.Boolean>)+8]");
			object obj3 = default(object);
			if ((nint)0 != 0)
			{
				object obj2 = obj;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v69 @ rdx_v8+188] (should have been resolved before IL gen)");
				if (obj3 != null)
				{
					goto IL_009c;
				}
			}
			obj3 = "No Exception";
			goto IL_009c;
			IL_009c:
			object arg2 = default(object);
			System.ParamsArray paramsArray = new System.ParamsArray(arg2, arg, obj3);
			object obj4 = default(object);
			string message = string.FormatHelper((IFormatProvider)null, "Set Player Ready to {0}. Response: {1}. Exception: {2}", (System.ParamsArray)(&obj4));
			Debug.Log(message);
		}
	}

	private sealed class _003C_003Ec__DisplayClass86_0
	{
		public MessagesReceived messages;

		internal unsafe bool _003COnP2PFailedMessageReceived_003Eb__0(LobbyPlayer p)
		{
			//IL_0165: Expected O, but got I
			//IL_00e9: Expected I8, but got I
			//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f7: Expected Ref, but got Unknown
			PlayerAccountId id = ((LobbyPlayer*)p)->Id;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18997FE90]");
			if ((nint)0 == 0)
			{
				_ = 1;
			}
			bool flag = (object)id == null;
			PlayerAccountId playerAccountId = "";
			if (!flag)
			{
				playerAccountId = id;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.RoomSelectionPage+<>c__DisplayClass86_0)+18]");
			object obj = 0;
			PlayerAccountId playerAccountId2 = playerAccountId;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.RoomSelectionPage+<>c__DisplayClass86_0)+18]");
			if ((object)playerAccountId2 != null)
			{
				if ((object)playerAccountId != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.RoomSelectionPage+<>c__DisplayClass86_0)+18]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v6 (Coherence.Cloud.PlayerAccountId)+10]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v81 @ rdx_v2+10]");
						if (num == 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (VampireSurvivors.UI.RoomSelectionPage+<>c__DisplayClass86_0)+18]");
							ref byte second = ref *(byte*)((nint)0 + (nint)20);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v6 (Coherence.Cloud.PlayerAccountId)+10]");
							nint num2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ rcx_v6 (Coherence.Cloud.PlayerAccountId)+10]");
							ulong length = (ulong)(num2 + 0);
							return System.SpanHelpers.SequenceEqual(ref *(byte*)(playerAccountId + 20), ref second, length);
						}
					}
				}
				return false;
			}
			return true;
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CCreateLobby_003Ed__94 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public RoomSelectionPage _003C_003E4__this;

		private TaskAwaiter<LobbyResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_016d: Expected O, but got I
			//IL_020e: Expected I4, but got I8
			//IL_0219: Expected O, but got Ref
			//IL_00b7: Expected O, but got I4
			//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
			//IL_00c4: Expected O, but got Unknown
			//IL_01bb: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<LobbyResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				AsyncTaskMethodBuilder<LobbyResult> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<LobbyResult>);
				LobbiesManager._003CCreateNewLobby_003Ed__15 stateMachine = default(LobbiesManager._003CCreateNewLobby_003Ed__15);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<LobbyResult> task2 = asyncTaskMethodBuilder.Task;
				((AsyncTaskMethodBuilder<LobbyResult>*)task2)->Start(ref *(LobbiesManager._003CCreateNewLobby_003Ed__15*)null);
				TaskAwaiter<LobbyResult> taskAwaiter = default(TaskAwaiter<LobbyResult>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<LobbyResult> awaiter = default(TaskAwaiter<LobbyResult>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				_003C_003E4__this.OnCreatedLobby();
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rbx_v7 (System.Threading.Tasks.Task)+58]");
				OnlineErrorManager.ShowError(OnlineErrorType.CreateGame, (string)0);
				_003C_003E4__this.ChangeButtonsState(active: true);
			}
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private sealed class _003CFireUiSignalCoroutine_003Ed__101(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public RoomSelectionPage _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_00da: Expected I4, but got I8
			//IL_03ff: Expected I4, but got O
			//IL_00a4: Expected O, but got I
			//IL_0492: Expected I, but got O
			//IL_0231: Expected O, but got I
			//IL_0260: Expected O, but got I
			//IL_02da: Expected O, but got I
			//IL_02ea: Expected O, but got I
			//IL_0364: Expected O, but got I
			object obj = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				Debug.Log("Fire UI Signal");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
				object obj2 = default(object);
				if (obj2 != null)
				{
					Action<CoherenceClientConnection> value = _003C_003E4__this.OnClientDisconnected;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v80+80]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v232 @ rax_v80+80]");
						((CoherenceClientConnectionManager)0).OnDestroyed += value;
						goto IL_04f0;
					}
				}
				goto IL_03f1;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_03be;
			}
			_003C_003E1__state = -1;
			goto IL_04f0;
			IL_03be:
			return false;
			IL_03f1:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_04f0:
			OnlineStageManager instance = OnlineStageManager._instance;
			if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
			{
				HostPlayerOptions hostPlayerOptions = HostPlayerOptions._003CInstance_003Ek__BackingField;
				if ((object)HostPlayerOptions._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)hostPlayerOptions).m_CachedPtr != (IntPtr)0)
				{
					nint num = (nint)typeof(HostPlayerOptions);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v29 (Il2CppClass<VampireSurvivors.HostPlayerOptions>)+B8]");
					nint num2 = 0;
					HostPlayerOptions hostPlayerOptions2 = HostPlayerOptions._003CInstance_003Ek__BackingField;
					if ((object)HostPlayerOptions._003CInstance_003Ek__BackingField == null)
					{
						goto IL_03f1;
					}
					if (hostPlayerOptions2._003CIsReady_003Ek__BackingField)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
						object obj3 = default(object);
						if (obj3 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v31+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
								object obj4 = default(object);
								if (obj4 != null)
								{
									Action<CoherenceClientConnection> value2 = _003C_003E4__this.OnClientDisconnected;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v38+80]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v349 @ rax_v38+80]");
										((CoherenceClientConnectionManager)0).OnDestroyed -= value2;
										if ((object)_003C_003E4__this != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+1A8]");
											object obj5 = 0;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+1A8]");
											if ((nint)0 != 0)
											{
												Action<LobbySession, LobbyPlayer, string> value3 = new Action<object, LobbyPlayer, object>(_003C_003E4__this.OnPlayerLeft);
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rax_v42+10]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v352 @ rax_v42+10]");
													((LobbySession)0).OnPlayerLeft -= value3;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+1A8]");
													object obj6 = 0;
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rdi_v1 (System.Object)+1A8]");
													if ((nint)0 != 0)
													{
														Action<LobbySession, LobbyPlayer> value4 = _003C_003E4__this.OnLobbyOwnerChanged;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v46+10]");
														if ((nint)0 != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v354 @ rax_v46+10]");
															((LobbySession)0).OnLobbyOwnerChanged -= value4;
															_ = 0;
															_003C_003E4__this.FireUiSignal();
															GameObject gameObject = _003C_003E4__this.gameObject;
															if ((object)gameObject != null)
															{
																gameObject.SetActive(value: false);
																goto IL_03be;
															}
														}
													}
												}
											}
										}
									}
								}
								goto IL_03f1;
							}
						}
					}
				}
			}
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
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

	private sealed class _003CInitializeOnlineModules_003Ed__67(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public RoomSelectionPage _003C_003E4__this;

		private bool _003CprovidersInitialized_003E5__2;

		private float _003Ctime_003E5__3;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private unsafe bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0323: Expected I4, but got I8
			//IL_0868: Expected O, but got F4
			//IL_0811: Expected O, but got I4
			//IL_0270: Expected F4, but got I4
			//IL_0497: Expected O, but got I4
			//IL_08b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_08b7: Expected I4, but got Unknown
			//IL_0489: Expected O, but got I4
			//IL_07d3->IL0138: Incompatible stack heights: 1 vs 0
			//IL_0808->IL0242: Incompatible stack heights: 1 vs 0
			//IL_077c->IL085a: Incompatible stack heights: 3 vs 0
			RoomSelectionPage roomSelectionPage = _003C_003E4__this;
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			float num;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				roomSelectionPage._preCharacterSelectionLobby.SetActive(value: false);
				roomSelectionPage.ChangeUiState(activate: false, "Loading");
				bool flag = roomSelectionPage._cloudProvider != null;
				Delegate obj = null;
				if (!flag)
				{
					CloudNetworkProvider cloudNetworkProvider = null;
					cloudNetworkProvider._003CIsReady_003Ek__BackingField = true;
					cloudNetworkProvider._logger = roomSelectionPage._logger;
					roomSelectionPage._cloudProvider = cloudNetworkProvider;
					CloudNetworkProvider cloudProvider = roomSelectionPage._cloudProvider;
					Action b = roomSelectionPage.OnJoinError;
					Delegate obj2 = Delegate.Combine(cloudProvider._003COnJoinError_003Ek__BackingField, b);
					bool flag2 = (object)obj2 == null;
					Delegate obj3 = null;
					if (!flag2)
					{
						bool flag3 = (object)obj2.GetType() != typeof(Action);
						obj3 = null;
						if (!flag3)
						{
							obj3 = obj2;
						}
						bool flag4 = (object)obj3 == null;
					}
					cloudProvider._003COnJoinError_003Ek__BackingField = (Action)obj3;
					roomSelectionPage._activeProvider = roomSelectionPage._cloudProvider;
					obj = null;
				}
				if (roomSelectionPage._p2pProvider == null)
				{
					SteamNetworkProvider steamNetworkProvider = null;
					steamNetworkProvider._logger = roomSelectionPage._logger;
					bool flag5 = steamNetworkProvider.CheckLoginStatus();
					roomSelectionPage._p2pProvider = steamNetworkProvider;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					Action b2 = roomSelectionPage.OnJoinError;
					Delegate a = default(Delegate);
					Delegate obj4 = Delegate.Combine(a, b2);
					bool flag6 = (object)obj4 == null;
					obj = null;
					if (!flag6)
					{
						bool flag7 = (object)obj4.GetType() != typeof(Action);
						obj = null;
						if (!flag7)
						{
							obj = obj4;
						}
						bool flag8 = (object)obj == null;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				}
				object obj5 = Application.internetReachability;
				if (obj5 == null)
				{
					(string, object)[] args = Array.Empty<(string, object)>();
					roomSelectionPage._logger.Error("No internet connection available", args);
					string translation = LocalizationManager.GetTranslation("onlineLang/ErrorOnlineNotAvailableDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
					OnlineErrorManager.ShowError(OnlineErrorType.Login, translation);
					goto IL_02e4;
				}
				_003CprovidersInitialized_003E5__2 = false;
				num = 0f;
			}
			else
			{
				if (_003C_003E1__state != 1)
				{
					goto IL_02e4;
				}
				_003C_003E1__state = -1;
				object obj6 = Time.deltaTime;
				object obj7 = default(object);
				num = (float)obj7 + _003Ctime_003E5__3;
			}
			_003Ctime_003E5__3 = num;
			bool flag9;
			object obj10;
			if (!_003CprovidersInitialized_003E5__2 && 15f > num)
			{
				_003CprovidersInitialized_003E5__2 = true;
				CloudNetworkProvider cloudProvider2 = roomSelectionPage._cloudProvider;
				if (cloudProvider2._003CIsReady_003Ek__BackingField)
				{
					flag9 = true;
				}
				else
				{
					string text = cloudProvider2._003CInitializationError_003Ek__BackingField;
					flag9 = ((cloudProvider2._003CInitializationError_003Ek__BackingField != null && text._stringLength > 0) ? true : false);
				}
				_003CprovidersInitialized_003E5__2 = flag9;
				if (roomSelectionPage._p2pProvider != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj8 = default(object);
					if (obj8 == null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						object obj9 = default(object);
						if (obj9 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1464 @ rax_v74+10]");
							if ((nint)0 > (nint)0)
							{
								goto IL_048e;
							}
						}
						obj10 = 0;
						goto IL_08aa;
					}
				}
				goto IL_048e;
			}
			if (num < 15f)
			{
				if (roomSelectionPage._cloudProvider != null)
				{
					CloudNetworkProvider cloudProvider3 = roomSelectionPage._cloudProvider;
					string text2 = cloudProvider3._003CInitializationError_003Ek__BackingField;
					if (cloudProvider3._003CInitializationError_003Ek__BackingField != null && text2._stringLength > 0)
					{
						goto IL_05da;
					}
				}
				if (roomSelectionPage._p2pProvider != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj11 = default(object);
					if (obj11 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v903 @ rax_v65+10]");
						if ((nint)0 > (nint)0)
						{
							goto IL_05da;
						}
					}
				}
				roomSelectionPage.ChangeUiState(activate: true, "Network Providers Initialized");
				roomSelectionPage.UpdateLobbyState();
				return false;
			}
			goto IL_05da;
			IL_02e4:
			return false;
			IL_08aa:
			bool flag10 = (byte)((flag9 & obj10) ? 1 : 0) != 0;
			_003CprovidersInitialized_003E5__2 = flag10;
			_003C_003E2__current = null;
			_003C_003E1__state = 1;
			return true;
			IL_048e:
			obj10 = 1;
			goto IL_08aa;
			IL_05da:
			(string, object)[] array = new(string, object)[4];
			CloudNetworkProvider cloudProvider4 = roomSelectionPage._cloudProvider;
			(string, object) tuple = ("Cloud Error", cloudProvider4._003CInitializationError_003Ek__BackingField);
			_ = 0;
			(string, object) item = default((string, object));
			if (roomSelectionPage._p2pProvider != null)
			{
				System.Runtime.CompilerServices.Unsafe.Write((void*)4, (ValueTuple<string, object>)((string)(object)typeof(INetworkProvider), roomSelectionPage._p2pProvider));
			}
			else
			{
				item = ((string, object))"No P2P Provider";
			}
			(string, object) tuple2 = ("P2P Error", item);
			bool flag11 = array.Length <= 1;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item2 = default(object);
			(string, object) tuple3 = ("Time", item2);
			bool flag12 = array.Length <= 2;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
			object item3 = default(object);
			(string, object) tuple4 = ("Timeout", item3);
			bool flag13 = array.Length <= 3;
			_ = 0;
			roomSelectionPage._logger.Error("Failed to initialize online providers", array);
			string translation2 = LocalizationManager.GetTranslation("onlineLang/ErrorOnlineNotAvailableDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			OnlineErrorManager.ShowError(OnlineErrorType.Login, translation2);
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

	[StructLayout((LayoutKind)3)]
	private struct _003CJoinLobby_003Ed__61 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public RoomSelectionPage _003C_003E4__this;

		public string lobbyTag;

		private TaskAwaiter<LobbyResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_00aa: Expected O, but got I4
			//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
			//IL_00b7: Expected O, but got Unknown
			//IL_0216: Expected O, but got Ref
			//IL_0170: Expected I4, but got O
			//IL_019d: Expected I4, but got O
			//IL_0269: Expected I4, but got I8
			//IL_0274: Expected O, but got Ref
			//IL_01dd: Expected I4, but got O
			//IL_01dd: Expected I4, but got O
			RoomSelectionPage CS_0024_003C_003E8__locals4 = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<LobbyResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Task<LobbyResult> task2 = CS_0024_003C_003E8__locals4._lobbiesManager.JoinLobby(lobbyTag);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<LobbyResult> taskAwaiter = default(TaskAwaiter<LobbyResult>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = (Task)taskAwaiter;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<LobbyResult> awaiter = default(TaskAwaiter<LobbyResult>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				CS_0024_003C_003E8__locals4.OnJoinedLobby();
			}
			else
			{
				string text = OnlineErrorManager.TypeToString(OnlineErrorType.JoinGame);
				string term = "onlineLang/" + text;
				object obj3 = default(object);
				GameObject gameObject = default(GameObject);
				string overrideLanguage = default(string);
				bool allowLocalizedParameters = default(bool);
				string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)obj3 != 0, gameObject, overrideLanguage, allowLocalizedParameters);
				string translation2 = LocalizationManager.GetTranslation("onlineLang/ErrorGameFullDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, (byte)(int)obj3 != 0, gameObject, overrideLanguage, allowLocalizedParameters);
				Action callback = delegate
				{
					CS_0024_003C_003E8__locals4.ChangeButtonsState(active: true);
					CS_0024_003C_003E8__locals4._joinButton.Select();
				};
				PopupManager.CreateOnlineErrorPopup(OnlineErrorManager.OnlineErrorPopupID, translation, translation2, callback, (byte)(int)obj3 != 0, (byte)(int)gameObject != 0);
			}
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CLeaveLobby_003Ed__111 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public RoomSelectionPage _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_003e: Expected O, but got I
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0637: Expected I4, but got I8
			//IL_0642: Expected O, but got Ref
			//IL_0078: Expected O, but got I
			//IL_00a8: Expected O, but got I
			//IL_0563: Expected O, but got I
			//IL_00db: Expected O, but got I
			//IL_00eb: Expected O, but got I
			//IL_057e: Expected O, but got I
			//IL_011e: Expected O, but got I
			//IL_012e: Expected O, but got I
			//IL_05c6: Expected O, but got I
			//IL_0161: Expected O, but got I
			//IL_0171: Expected O, but got I
			//IL_01a4: Expected O, but got I
			//IL_01b4: Expected O, but got I
			//IL_01e7: Expected O, but got I
			//IL_01f7: Expected O, but got I
			//IL_020c: Expected O, but got I
			//IL_0219: Expected O, but got Ref
			//IL_0229: Expected O, but got I
			//IL_0285: Expected O, but got Ref
			//IL_02a2: Expected O, but got I
			//IL_02ef: Expected O, but got I
			//IL_0304: Expected O, but got I
			//IL_0311: Expected O, but got Ref
			//IL_0321: Expected O, but got I
			//IL_037d: Expected O, but got Ref
			//IL_039a: Expected O, but got I
			//IL_0441: Expected O, but got I
			//IL_0412: Expected O, but got I
			//IL_04a9: Expected O, but got I4
			//IL_04b1: Unknown result type (might be due to invalid IL or missing references)
			//IL_04b6: Expected O, but got Unknown
			//IL_0610: Expected O, but got Ref
			object obj = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rax_v71+10]");
				if ((nint)0 == 0)
				{
					goto IL_0628;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+180]");
				object obj3 = 0;
				(string, object)[] array = Array.Empty<(string, object)>();
				object obj4 = obj3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v551 @ r9_v26+1E8] (should have been resolved before IL gen)");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				object obj5 = 0;
				Action<LobbySession, LobbyPlayer> value = ((RoomSelectionPage)obj).OnPlayerJoined;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v557 @ rax_v75+10]");
				((LobbySession)0).OnPlayerJoined -= value;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				object obj6 = 0;
				Action<LobbySession, LobbyPlayer, string> value2 = new Action<object, LobbyPlayer, object>(((RoomSelectionPage)obj).OnPlayerLeft);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v932 @ rax_v79+10]");
				((LobbySession)0).OnPlayerLeft -= value2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				object obj7 = 0;
				Action<LobbySession, LobbyPlayer> value3 = ((RoomSelectionPage)obj).OnLobbyOwnerChanged;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1178 @ rax_v83+10]");
				((LobbySession)0).OnLobbyOwnerChanged -= value3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				object obj8 = 0;
				Action<LobbySession, MessagesReceived> value4 = ((RoomSelectionPage)obj).OnStartGameMessageReceived;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1076 @ rax_v87+10]");
				((LobbySession)0).OnMessageReceived -= value4;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				object obj9 = 0;
				Action<LobbySession, MessagesReceived> value5 = ((RoomSelectionPage)obj).OnP2PFailedMessageReceived;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v961 @ rax_v91+10]");
				((LobbySession)0).OnMessageReceived -= value5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				object obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v836 @ rax_v95+10]");
				object obj11 = 0;
				object obj13 = default(object);
				object obj12 = (object)(&obj13);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+18]");
				obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+78]");
				_ = 0;
				object obj14 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj13, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+98]");
				obj14 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+B8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v761 @ rax_v96+D8]");
				_ = 0;
				string lobbyID = default(string);
				OnlinePlatformSupport.OnLobbyClosed(lobbyID);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				object obj15 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v707 @ rax_v99+10]");
				object obj16 = 0;
				object obj17 = (object)(&obj13);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+18]");
				obj17 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+78]");
				_ = 0;
				object obj18 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj13, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+98]");
				obj18 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+B8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v624 @ rax_v100+D8]");
				_ = 0;
				OnlinePlatformSupport.OnEndOnlineSession(lobbyID, null);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1B0]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1B0]");
					((MonoBehaviour)obj).StopCoroutine((Coroutine)0);
					_ = 0;
				}
				((RoomSelectionPage)obj).ChangeButtonsState(false);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+1A8]");
				Task<bool> task2 = ((LobbiesManager)0).LeaveLobby();
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj19 = !flag3;
				object obj20 = obj19 | flag;
				task = (Task)taskAwaiter;
				if (obj20 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			if (PopupManager.PopupExists("HostStartingGame"))
			{
				PopupManager.ClosePopup("HostStartingGame");
			}
			((RoomSelectionPage)obj).ChangeButtonsState(true);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+170]");
			object obj21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v739 @ rax_v58+38]");
			((GameObject)0).SetActive(value: false);
			((RoomSelectionPage)obj).SwitchLobbyState(false);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v85 @ rbx_v24 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v40 @ rdi_v1 (System.Object)+180]");
				object obj22 = 0;
				(string, object)[] array2 = Array.Empty<(string, object)>();
				object obj23 = obj22;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1176 @ r9_v24+1E8] (should have been resolved before IL gen)");
			}
			goto IL_0628;
			IL_0628:
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CSendStartGameMessage_003Ed__91 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public RoomSelectionPage _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_007f: Expected O, but got I4
			//IL_0266: Expected I4, but got I8
			//IL_0271: Expected O, but got Ref
			//IL_00dd: Expected O, but got I4
			//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
			//IL_00ea: Expected O, but got Unknown
			//IL_015e: Expected O, but got Ref
			RoomSelectionPage roomSelectionPage = _003C_003E4__this;
			if (_003C_003E1__state != 0)
			{
				goto IL_002e;
			}
			_003C_003Eu__1 = (TaskAwaiter)0;
			_003C_003E1__state = -1;
			Task task = (Task)_003C_003Eu__1;
			goto IL_0100;
			IL_002e:
			LobbiesManager lobbiesManager = roomSelectionPage._lobbiesManager;
			LobbySession activeLobby = lobbiesManager._activeLobby;
			string text = LobbySession.lobbiesResolveEndpoint + "/" + (string)activeLobby.lobbyData + "/messages";
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18048BEA0");
			object obj = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) > System.Runtime.CompilerServices.Unsafe.As<TimeSpan, UIntPtr>(ref TimeSpan.Zero))
			{
				Task task2 = Task.Delay(1, (CancellationToken)0);
				int num = task2.m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj2 = !flag3;
				object obj3 = obj2 | flag;
				task = task2;
				if (obj3 == null)
				{
					goto IL_0100;
				}
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (TaskAwaiter)task2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				TaskAwaiter awaiter = default(TaskAwaiter);
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
				return;
			}
			List<LobbyPlayer> messageRecipients = roomSelectionPage.GetMessageRecipients();
			LobbiesManager lobbiesManager2 = roomSelectionPage._lobbiesManager;
			List<string> list = new List<string>();
			int version = list._version + 1;
			list._version = version;
			string[] items = list._items;
			if (list._size >= items.Length)
			{
				((List<object>)(object)list).AddWithResize((object)LobbyAttributeKeys.StartGameMessagePrefix);
			}
			else
			{
				int size = list._size + 1;
				list._size = size;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			}
			lobbiesManager2._activeLobby.SendMessage(list, null, messageRecipients);
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
			return;
			IL_0100:
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			goto IL_002e;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CStartGameBasedOnNetworkType_003Ed__60 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public RoomSelectionPage _003C_003E4__this;

		public NetworkType networkType;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_00a4: Expected O, but got Ref
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_00d3: Expected O, but got I4
			//IL_00dc: Expected O, but got I4
			//IL_00e4: Expected O, but got Ref
			//IL_0175: Expected O, but got I4
			//IL_017d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0182: Expected O, but got Unknown
			//IL_018b: Expected O, but got I4
			//IL_0194: Expected O, but got I4
			//IL_0244: Expected O, but got Ref
			//IL_036c: Expected O, but got I
			//IL_0375: Unknown result type (might be due to invalid IL or missing references)
			//IL_037a: Expected O, but got Unknown
			//IL_03e1: Expected O, but got I
			//IL_0536: Expected O, but got I4
			//IL_03fb: Expected I, but got O
			//IL_03cc: Expected O, but got I8
			//IL_059a: Expected I4, but got I8
			//IL_05a5: Expected O, but got Ref
			//IL_0433: Expected O, but got I
			//IL_0557: Expected O, but got I4
			//IL_04a6: Expected O, but got I4
			//IL_04bc: Expected O, but got I
			//IL_04d8: Expected O, but got I
			RoomSelectionPage roomSelectionPage = _003C_003E4__this;
			Task task;
			bool flag4 = default(bool);
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				bool flag = (nint)roomSelectionPage._p2pProvider < 0;
				bool flag2 = roomSelectionPage._p2pProvider == null;
				bool flag3 = !flag;
				flag4 = !flag2;
				flag4 &= flag3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
				object arg = default(object);
				System.ParamsArray paramsArray = new System.ParamsArray(arg);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				string message = string.FormatHelper((IFormatProvider)null, "StartGameBasedOnNetworkType, p2p provider exists? {0}", (System.ParamsArray)(&paramsArray2));
				Debug.Log(message);
				bool flag5 = roomSelectionPage._activeProvider == null;
				object obj = 0;
				object obj2 = 0;
				System.ParamsArray paramsArray3 = (System.ParamsArray)(&paramsArray2);
				System.ParamsArray paramsArray4 = paramsArray;
				if (flag5)
				{
					goto IL_01f0;
				}
				paramsArray3 = (System.ParamsArray)roomSelectionPage._activeProvider;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
				TaskAwaiter taskAwaiter = default(TaskAwaiter);
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag6 = num == 0;
				bool flag7 = num < 0;
				bool flag8 = !flag7;
				object obj3 = !flag8;
				object obj4 = obj3 | flag6;
				obj = 0;
				obj2 = 0;
				paramsArray4 = paramsArray;
				task = (Task)taskAwaiter;
				if (obj4 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter = default(TaskAwaiter);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			goto IL_01f0;
			IL_01f0:
			INetworkProvider activeProvider = ((this.networkType != NetworkType.Cloud) ? roomSelectionPage._p2pProvider : roomSelectionPage._cloudProvider);
			roomSelectionPage._activeProvider = activeProvider;
			(string, object)[] args = new(string, object)[2];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object item = (flag4 ? NetworkProviders.PlayFab : NetworkProviders.Coherence);
			(string, object) tuple = ("Provider", item);
			NetworkType networkType = default(NetworkType);
			object item2 = networkType;
			(string, object) tuple2 = ("Type", item2);
			roomSelectionPage._logger.Info("Starting Online Game", args);
			roomSelectionPage.StartReplicationServerIfP2P();
			INetworkProvider activeProvider2 = roomSelectionPage._activeProvider;
			LobbiesManager lobbiesManager = roomSelectionPage._lobbiesManager;
			Action<bool, string, Dictionary<string, string>> action = null;
			nint num3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ r9_v20 (Il2CppMethodInfo)+8]");
			_ = 0;
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ r9_v20 (Il2CppMethodInfo)+4C]");
			object obj5 = (nint)0 >> 4;
			object obj6 = obj5 & 1;
			object obj7;
			if (obj6 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v749 @ r9_v20 (Il2CppMethodInfo)+52]");
				if ((nint)0 == 3)
				{
					obj7 = 6447777168L;
					goto IL_052d;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ rax_v44 (System.Action`3<System.Boolean, System.String, System.Collections.Generic.Dictionary`2<System.String, System.String>>)+10]");
			obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1142 @ rax_v44 (System.Action`3<System.Boolean, System.String, System.Collections.Generic.Dictionary`2<System.String, System.String>>)+20]");
			_ = 0;
			goto IL_052d;
			IL_0581:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1336 @ r9_v22] (should have been resolved before IL gen)");
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
			return;
			IL_052d:
			object obj8 = 24;
			_ = 6447777024L;
			nint num4 = (nint)activeProvider2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ r9_v21 (Il2CppClass<VampireSurvivors.INetworkProvider>)+12E]");
			if ((nint)0 >= (nint)0)
			{
				goto IL_0473;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ r9_v21 (Il2CppClass<VampireSurvivors.INetworkProvider>)+B0]");
			object obj9 = 0;
			int num5 = 0;
			while (true)
			{
				object obj10 = num5 + num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ r8_v26+v1276 @ rax_v60*8]");
				if (0 == (nint)typeof(INetworkProvider))
				{
					break;
				}
				num5++;
				int num6 = num5;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1258 @ r9_v21 (Il2CppClass<VampireSurvivors.INetworkProvider>)+12E]");
				if ((nint)num6 < (nint)0)
				{
					continue;
				}
				goto IL_0473;
			}
			object obj11 = num5 + num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1271 @ r8_v26+8+v1329 @ rcx_v37*8]");
			object obj12 = (nint)0 + (nint)14;
			object obj13 = obj12 << 4;
			object obj14 = num4 + 312;
			object obj15 = obj14 + obj13;
			goto IL_0581;
			IL_0473:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
			object obj16 = default(object);
			obj15 = obj16;
			goto IL_0581;
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CUpdateLobbyAttributes_003Ed__83 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public RoomSelectionPage _003C_003E4__this;

		public List<CloudAttribute> attributes;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0034: Expected O, but got I
			//IL_0049: Expected O, but got I
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_005e: Expected O, but got I
			//IL_01cd: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_00da: Expected O, but got I
			//IL_0111: Expected O, but got I
			//IL_0120: Expected I4, but got I8
			//IL_012b: Expected O, but got Ref
			//IL_0097: Expected O, but got I4
			//IL_00a2: Expected O, but got Ref
			RequestResponse<bool> req = (RequestResponse<bool>)_003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				_003C_003E1__state = -1;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rsi_v1 (Coherence.Cloud.RequestResponse`1<System.Boolean>)+1A8]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ rax_v6+10]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v157 @ rcx_v5+F0]");
			object obj3 = 0;
			string lobbiesResolveEndpoint = LobbyOwnerSession.lobbiesResolveEndpoint;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rbx_v4+10]");
			string text = lobbiesResolveEndpoint + "/" + (string)0 + "/attrs";
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18048BEA0");
			object obj4 = default(object);
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj4) > System.Runtime.CompilerServices.Unsafe.As<TimeSpan, UIntPtr>(ref TimeSpan.Zero))
			{
				_003C_003E1__state = 0;
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				YieldAwaitable.YieldAwaiter awaiter = default(YieldAwaitable.YieldAwaiter);
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ rsi_v1 (Coherence.Cloud.RequestResponse`1<System.Boolean>)+1A8]");
			object obj5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v424 @ rax_v25+10]");
			object obj6 = 0;
			Action<RequestResponse<bool>> action = null;
			((RoomSelectionPage)(object)action).OnAttributesAdded(req);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v450 @ rcx_v16+F0]");
			((LobbyOwnerSession)0).AddOrUpdateLobbyAttributes(attributes, action);
			_003C_003E1__state = -2;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CUpdateReadyState_003Ed__73 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public long ready;

		public RoomSelectionPage _003C_003E4__this;

		private _003C_003Ec__DisplayClass73_0 _003C_003E8__1;

		private YieldAwaitable.YieldAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_005e: Expected I, but got I8
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_002d: Expected I, but got O
			//IL_0256: Expected I4, but got I8
			//IL_026d: Expected O, but got Ref
			//IL_00fe: Expected O, but got Ref
			//IL_0201: Expected O, but got I4
			//IL_0213: Expected O, but got Ref
			//IL_014d: Expected O, but got I4
			//IL_0158: Expected O, but got Ref
			RoomSelectionPage roomSelectionPage = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
				_003C_003E1__state = -1;
				nint num = (nint)typeof(YieldAwaitable.YieldAwaiter);
			}
			else
			{
				_003C_003Ec__DisplayClass73_0 obj = new _003C_003Ec__DisplayClass73_0();
				_003C_003E8__1 = obj;
				_003C_003Ec__DisplayClass73_0 obj2 = _003C_003E8__1;
				nint num = (nint)ready;
				obj2.ready = ready;
			}
			LobbiesManager lobbiesManager = roomSelectionPage._lobbiesManager;
			if (lobbiesManager._activeLobby != null)
			{
				LobbySession activeLobby = lobbiesManager._activeLobby;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18048BC20");
				YieldAwaitable.YieldAwaiter awaiter = default(YieldAwaitable.YieldAwaiter);
				object arg = (PlayerAccountId)awaiter;
				System.ParamsArray paramsArray = new System.ParamsArray(activeLobby.lobbyData, arg);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				string text = string.FormatHelper((IFormatProvider)null, "/{0}/players/{1}/attrs", (System.ParamsArray)(&paramsArray2));
				string text2 = LobbySession.lobbiesResolveEndpoint + text;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18048BEA0");
				object obj3 = default(object);
				if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj3) > System.Runtime.CompilerServices.Unsafe.As<TimeSpan, UIntPtr>(ref TimeSpan.Zero))
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (YieldAwaitable.YieldAwaiter)0;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			LobbiesManager lobbiesManager2 = roomSelectionPage._lobbiesManager;
			if (lobbiesManager2._activeLobby != null)
			{
				LobbySession activeLobby2 = lobbiesManager2._activeLobby;
				if (!activeLobby2._003CIsDisposed_003Ek__BackingField)
				{
					List<CloudAttribute> list = new List<CloudAttribute>();
					_003C_003Ec__DisplayClass73_0 obj4 = _003C_003E8__1;
					CloudAttribute cloudAttribute = new CloudAttribute(LobbyAttributeKeys.PlayerReady, obj4.ready, (bool?)(object)257);
					CloudAttribute cloudAttribute2 = default(CloudAttribute);
					list.Add((CloudAttribute)(&cloudAttribute2));
					Action<RequestResponse<bool>> action = null;
					((_003C_003Ec__DisplayClass73_0)(object)action)._003CUpdateReadyState_003Eb__0((RequestResponse<bool>)_003C_003E8__1);
					activeLobby2.AddOrUpdateMyAttributes(list, action);
				}
			}
			_003C_003E1__state = -2;
			_003C_003E8__1 = null;
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			if (asyncVoidMethodBuilder2.m_synchronizationContext != null)
			{
				((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->NotifySynchronizationContextOfCompletion();
			}
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private GameObject _roomSelection;

	private LabeledInputUI _lobbyIdInput;

	private Button _joinButton;

	private Button _createRoomButton;

	private Button _startButton;

	private Button _leaveButton;

	private Button _adventuresButton;

	private Button _collectionsButton;

	private Button _powerUpsButton;

	private CoherenceSyncConfig _onlineStageManagerPrefab;

	private CoherenceSyncConfig _hostPlayerOptions;

	private CoherenceSyncConfig _lobbyCharacterData;

	private TextMeshProUGUI _infoText;

	private GameObject _initContainer;

	private PlayFabMultiplayerManager _playFabPrefab;

	private GameObject _preCharacterSelectionLobby;

	private TextMeshProUGUI _lobbyIdText;

	private List<TextMeshProUGUI> _lobbyPlayerNames;

	private OnlineDLCSection _OnlineDLCSection;

	private List<DlcType> _AvailableDLCs;

	private Coherence.Log.Logger _logger;

	private INetworkProvider _activeProvider;

	private INetworkProvider _p2pProvider;

	private CloudNetworkProvider _cloudProvider;

	private DiContainer _diContainer;

	private LobbiesManager _lobbiesManager;

	private Coroutine _fireUiSignalRoutine;

	private PlayerOptions _playerOptions;

	private AdventureManager _adventureManager;

	private SignalBus _signalBus;

	private IReplicationServer _replicationServer;

	private bool _isStartingGame;

	private static RoomSelectionPage _003CInstance_003Ek__BackingField;

	private static Dictionary<SystemPlatformTypes, NetworkProviders> _platformToProvider;

	private const int ClientHostingDisconnectTimeout = 2147483647;

	private const float OnlineInitTimeout = 15f;

	private static bool hasOnEnablerunOnce;

	public LobbiesManager LobbiesManager => _lobbiesManager;

	public DiContainer DiContainer => _diContainer;

	public IReplicationServer ReplicationServer => _replicationServer;

	public static RoomSelectionPage Instance
	{
		get
		{
			return _003CInstance_003Ek__BackingField;
		}
		private set
		{
			_003CInstance_003Ek__BackingField = value;
		}
	}

	public bool IsInLobby
	{
		get
		{
			//IL_0088: Expected I4, but got O
			LobbiesManager lobbiesManager = _lobbiesManager;
			if (_lobbiesManager != null)
			{
				if (lobbiesManager._activeLobby == null)
				{
					return false;
				}
				LobbySession activeLobby = lobbiesManager._activeLobby;
				return !activeLobby._003CIsDisposed_003Ek__BackingField;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public INetworkProvider ActiveProvider => _activeProvider;

	private void Construct(SignalBus signalBus, DiContainer diContainer, MultiplayerManager multiplayerManager, LobbiesManager lobbiesManager, PlayerOptions playerOptions, AdventureManager adventureManager)
	{
		_signalBus = signalBus;
		_diContainer = diContainer;
		LobbiesManager lobbiesManager2 = default(LobbiesManager);
		_lobbiesManager = lobbiesManager2;
		PlayerOptions playerOptions2 = default(PlayerOptions);
		_playerOptions = playerOptions2;
		AdventureManager adventureManager2 = default(AdventureManager);
		_adventureManager = adventureManager2;
		multiplayerManager.AllowPlayerJoining = false;
		multiplayerManager.ClearAllExtraPlayers();
	}

	public void LeaveGame()
	{
		LeaveLobby();
	}

	public unsafe void StartGame()
	{
		//IL_0064: Expected O, but got Ref
		//IL_00d9: Expected O, but got I
		//IL_0162: Expected O, but got Ref
		//IL_01cb: Expected O, but got Ref
		//IL_01e8: Expected O, but got I
		//IL_026b: Expected O, but got I4
		LobbiesManager lobbiesManager = _lobbiesManager;
		bool flag = default(bool);
		string term;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			if (activeLobby.lobbyOwnerSession != null)
			{
				object obj2 = default(object);
				object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
				_ = activeLobby.lobbyData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+78]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+98]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+B8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v119 @ rcx_v9 (Coherence.Cloud.LobbySession)+D8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj3 = default(object);
				if ((nint)obj3 >= 2)
				{
					LobbiesManager lobbiesManager2 = _lobbiesManager;
					LobbySession activeLobby2 = lobbiesManager2._activeLobby;
					object obj4 = (object)(&obj2);
					obj4 = activeLobby2.lobbyData;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+28]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+48]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+58]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+68]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+78]");
					_ = 0;
					object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+88]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+98]");
					obj5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+A8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+B8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+C8]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v19 (Coherence.Cloud.LobbySession)+D8]");
					_ = 0;
					string lobbyID = default(string);
					OnlinePlatformSupport.OnLobbyClosed(lobbyID);
					NetworkType networkType = GetNetworkType();
					ChangeButtonsState(active: false);
					StartGameBasedOnNetworkType(networkType);
					PopupManager.CreateAccountBlockingPopup("HostStartingGame", "", "", textisLocalizationTerm: false, (Action)flag);
					return;
				}
				term = "onlineLang/ErrorNotEnoughPlayersDesc";
				goto IL_02b0;
			}
		}
		term = "onlineLang/ErrorNoLobbyDesc";
		goto IL_02b0;
		IL_02b0:
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation(term, FixForRTL: true, 0, ignoreRTLnumbers: true, flag, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		OnlineErrorManager.ShowError(OnlineErrorType.StartGame, translation);
	}

	public void CreateRoom()
	{
		//IL_0029: Expected I4, but got O
		ChangeButtonsState(active: false);
		Action<bool> action = null;
		((RoomSelectionPage)(object)action)._003CCreateRoom_003Eb__52_0((byte)(int)this != 0);
		OnlinePlatformSupport.CheckHasInternetConnection(action);
	}

	private void OnLoggedInWithCoherenceAfterCreate(bool result)
	{
		//IL_0044: Expected O, but got I
		//IL_007e: Expected O, but got I
		if (result)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AA36A0");
			Action value = OnConnectionLostWithCoherence;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v79 @ rax_v10+28]");
			((CloudService)0).OnConnectionLost -= value;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AA36A0");
			Action value2 = OnConnectionLostWithCoherence;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v146 @ rax_v16+28]");
			((CloudService)0).OnConnectionLost += value2;
			(string, object)[] args = Array.Empty<(string, object)>();
			_logger.Info("Logged in with Coherence", args);
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003CCreateLobby_003Ed__94 stateMachine = default(_003CCreateLobby_003Ed__94);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}
		else
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("onlineLang/ErrorOnlineNotAvailableDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			OnlineErrorManager.ShowError(OnlineErrorType.Login, translation);
			ChangeButtonsState(active: true);
		}
	}

	public void JoinRoom(string _lobbyID)
	{
		//IL_003b: Expected I4, but got O
		LabeledInputUI lobbyIdInput = _lobbyIdInput;
		lobbyIdInput._Input.SetText(_lobbyID, true);
		Action<bool> action = null;
		((RoomSelectionPage)(object)action)._003CJoinRoom_003Eb__56_0((byte)(int)this != 0);
		OnlinePlatformSupport.CheckHasInternetConnection(action);
	}

	protected override void OnShowStart(GameObject g)
	{
		base.OnShowStart(g);
		LobbiesManager lobbiesManager = _lobbiesManager;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			if (!activeLobby._003CIsDisposed_003Ek__BackingField && (nint)activeLobby.lobbyOwnerSession > 0)
			{
				return;
			}
		}
		_adventureManager.ExitAdventureMode();
	}

	public void JoinRoom()
	{
		//IL_0015: Expected I4, but got O
		Action<bool> action = null;
		((RoomSelectionPage)(object)action)._003CJoinRoom_003Eb__56_0((byte)(int)this != 0);
		OnlinePlatformSupport.CheckHasInternetConnection(action);
	}

	private static void ShowConnectionLostPopup()
	{
		if (OnlinePlatformSupport.OnlinePlatformSupportInstance != null)
		{
			OnlinePlatformSupport.OnlinePlatformSupportInstance.OnConnectionError();
		}
		Action callback = _003C_003Ec._003C_003E9__57_0;
		if (_003C_003Ec._003C_003E9__57_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__57_0 = delegate
			{
				GameManager core = GM.Core;
				if ((object)GM.Core != null && ((UnityEngine.Object)core).m_CachedPtr != (IntPtr)0)
				{
					GM.Core.ResetGameToMenu();
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
					object obj = default(object);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v167 @ rax_v11+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
							CoherenceBridge coherenceBridge = default(CoherenceBridge);
							if (coherenceBridge.IsConnected)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
								CoherenceBridge coherenceBridge2 = default(CoherenceBridge);
								coherenceBridge2.Disconnect();
							}
						}
					}
					SceneManager.LoadScene("ScenePreloader", LoadSceneMode.Additive);
				}
			});
		}
		bool titleIsLocalizationTerm = default(bool);
		bool descriptionIsLocalizationTerm = default(bool);
		PopupManager.CreateWarningPopup("InternetConnectionLost", "Connection Lost", "Connection to internet lost, returning to main menu", callback, titleIsLocalizationTerm, descriptionIsLocalizationTerm);
	}

	private void OnLoggedInWithCoherenceAfterJoin(string lobbyTag, bool result)
	{
		//IL_0044: Expected O, but got I
		if (result)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AA36A0");
			Action value = OnConnectionLostWithCoherence;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rax_v11+28]");
			((CloudService)0).OnConnectionLost += value;
			(string, object)[] args = Array.Empty<(string, object)>();
			_logger.Info("Logged in with Coherence", args);
			JoinLobby(lobbyTag);
		}
		else
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("onlineLang/ErrorOnlineNotAvailableDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			OnlineErrorManager.ShowError(OnlineErrorType.Login, translation);
			ChangeButtonsState(active: true);
		}
	}

	public unsafe static EndpointData GetLocalEndpoint()
	{
		//IL_00ef: Expected native int or pointer, but got O
		//IL_00f9: Expected native int or pointer, but got O
		//IL_0107: Expected native int or pointer, but got O
		//IL_011a: Expected I8, but got I4
		//IL_0115: Expected native int or pointer, but got O
		//IL_011f: Expected native int or pointer, but got O
		//IL_0129: Expected native int or pointer, but got O
		//IL_0137: Expected native int or pointer, but got O
		//IL_003d: Expected native int or pointer, but got O
		//IL_004a: Expected native int or pointer, but got O
		//IL_0057: Expected native int or pointer, but got O
		//IL_0064: Expected native int or pointer, but got O
		//IL_0076: Expected native int or pointer, but got O
		//IL_0083: Expected native int or pointer, but got O
		//IL_0090: Expected native int or pointer, but got O
		//IL_00a2: Expected I4, but got O
		EndpointData endpointData = default(EndpointData);
		System.Runtime.CompilerServices.Unsafe.Write(&((EndpointData*)(nint)endpointData)->host, null);
		System.Runtime.CompilerServices.Unsafe.Write(&((EndpointData*)(nint)endpointData)->authToken, null);
		((EndpointData*)(nint)endpointData)->roomId = 0;
		((EndpointData*)(nint)endpointData)->worldId = 0uL;
		System.Runtime.CompilerServices.Unsafe.Write(&((EndpointData*)(nint)endpointData)->schemaId, null);
		System.Runtime.CompilerServices.Unsafe.Write(&((EndpointData*)(nint)endpointData)->roomSecret, null);
		((EndpointData*)(nint)endpointData)->customLocalToken = false;
		RuntimeSettings instance = PreloadedSingleton<RuntimeSettings>.Instance;
		RuntimeSettings instance2 = PreloadedSingleton<RuntimeSettings>.Instance;
		RuntimeSettings instance3 = PreloadedSingleton<RuntimeSettings>.Instance;
		System.Runtime.CompilerServices.Unsafe.Write(&((EndpointData*)(nint)endpointData)->host, instance.localHost);
		string authToken = default(string);
		System.Runtime.CompilerServices.Unsafe.Write(&((EndpointData*)(nint)endpointData)->authToken, authToken);
		ushort roomId = default(ushort);
		((EndpointData*)(nint)endpointData)->roomId = roomId;
		ulong worldId = default(ulong);
		((EndpointData*)(nint)endpointData)->worldId = worldId;
		System.Runtime.CompilerServices.Unsafe.Write(&((EndpointData*)(nint)endpointData)->schemaId, instance3.schemaID);
		string roomSecret = default(string);
		System.Runtime.CompilerServices.Unsafe.Write(&((EndpointData*)(nint)endpointData)->roomSecret, roomSecret);
		bool customLocalToken = default(bool);
		((EndpointData*)(nint)endpointData)->customLocalToken = customLocalToken;
		EndpointData endpointData2 = default(EndpointData);
		(bool, string) tuple = endpointData2.Validate((byte)(int)endpointData != 0);
		if ((object)tuple != null)
		{
			return endpointData;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
		string text = default(string);
		string message = "Invalid EndpointData: " + text;
		Exception ex = new Exception(message);
		throw ex;
	}

	private void StartGameBasedOnNetworkType(NetworkType networkType)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CStartGameBasedOnNetworkType_003Ed__60 stateMachine = default(_003CStartGameBasedOnNetworkType_003Ed__60);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void JoinLobby(string lobbyTag)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CJoinLobby_003Ed__61 stateMachine = default(_003CJoinLobby_003Ed__61);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	protected override void Awake()
	{
		base.Awake();
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D98110");
		Settings settings = Log.GetSettings();
		settings.LogStackTrace = true;
	}

	private void OnEnable()
	{
		//IL_0087: Expected O, but got I4
		//IL_00bc: Expected O, but got I4
		//IL_01a2: Expected O, but got I
		//IL_01dc: Expected O, but got I
		//IL_01fb: Expected O, but got I
		//IL_010e: Expected O, but got I
		//IL_0244: Expected O, but got I
		//IL_0244: Expected O, but got I
		//IL_0148: Expected O, but got I
		//IL_0156: Expected O, but got I4
		//IL_0263: Expected O, but got I
		//IL_0296: Expected O, but got I
		Coherence.Log.Logger logger = Log.GetLogger<RoomSelectionPage>(this);
		_logger = logger;
		if (hasOnEnablerunOnce)
		{
			(string, object)[] args = Array.Empty<(string, object)>();
			_logger.Info("OnEnable", args);
			_003CInitializeOnlineModules_003Ed__67 obj = null;
			obj._003C_003E1__state = 0;
			obj._003C_003E4__this = this;
			Coroutine coroutine = StartCoroutine(obj);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AA36A0");
			PlayerAccount playerAccount = default(PlayerAccount);
			bool flag = (object)playerAccount == null;
			_003CInitializeOnlineModules_003Ed__67 obj2 = obj;
			object obj3 = 0;
			Action action = (Action)(object)obj;
			if (!flag)
			{
				bool flag2 = playerAccount.Equals(null);
				obj2 = obj;
				obj3 = 0;
				action = null;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AA36A0");
					Action value = OnConnectionLostWithCoherence;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v320 @ rax_v47+28]");
					((CloudService)0).OnConnectionLost -= value;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AA36A0");
					Action action2 = OnConnectionLostWithCoherence;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v322 @ rax_v51+28]");
					((CloudService)0).OnConnectionLost += action2;
					obj2 = null;
					obj3 = 0;
					action = action2;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			Action<CoherenceClientConnectionManager> value2 = ShowOnlineLobby;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v324 @ rax_v23+80]");
			((CoherenceClientConnectionManager)0).OnSynced -= value2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			Action<CoherenceClientConnectionManager> value3 = ShowOnlineLobby;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v326 @ rax_v27+80]");
			((CoherenceClientConnectionManager)0).OnSynced += value3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v328 @ rax_v31+F8]");
			object obj4 = 0;
			UnityAction<CoherenceBridge, ConnectionException> unityAction = OnConnectionError;
			MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v300 @ rsi_v8+10]");
			nint num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v721 @ rax_v32 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+20]");
			((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v37+F8]");
			object obj5 = 0;
			UnityAction<CoherenceBridge, ConnectionException> action3 = OnConnectionError;
			UnityEngine.Events.BaseInvokableCall baseInvokableCall = UnityEvent<CoherenceBridge, ConnectionException>.GetDelegate(action3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v175 @ rdi_v9+10]");
			object obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A5D0D0");
			_ = 1;
		}
		hasOnEnablerunOnce = true;
	}

	private void OnDisable()
	{
		//IL_0084: Expected O, but got I
		if ((object)PlayerAccount.main != null && !PlayerAccount.main.Equals(null))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182AA36A0");
			Action value = OnConnectionLostWithCoherence;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rax_v11+28]");
			((CloudService)0).OnConnectionLost -= value;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 158 Invalid \"Jump target not found in method: 0x186D736A0\"");
		throw new NullReferenceException();
	}

	private void RemoveConnectionListeners()
	{
		//IL_006e: Expected O, but got I
		//IL_006e: Expected O, but got I
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionException> onConnectionError = masterBridge.onConnectionError;
		UnityAction<CoherenceBridge, ConnectionException> unityAction = OnConnectionError;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v102 @ rsi_v2 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ rax_v9 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+20]");
		((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
	}

	private IEnumerator InitializeOnlineModules()
	{
		_003CInitializeOnlineModules_003Ed__67 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private unsafe void UpdateLobbyState()
	{
		//IL_017c: Expected O, but got I4
		//IL_017c: Expected I8, but got I4
		//IL_0129: Expected O, but got Ref
		LobbiesManager lobbiesManager = _lobbiesManager;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			if (!activeLobby._003CIsDisposed_003Ek__BackingField)
			{
				LobbiesManager lobbiesManager2 = _lobbiesManager;
				if (lobbiesManager2._activeLobby != null)
				{
					LobbySession activeLobby2 = lobbiesManager2._activeLobby;
					if (!activeLobby2._003CIsDisposed_003Ek__BackingField && (nint)activeLobby2.lobbyOwnerSession > 0)
					{
						OnCreatedLobby();
						LobbiesManager lobbiesManager3 = _lobbiesManager;
						LobbySession activeLobby3 = lobbiesManager3._activeLobby;
						List<CloudAttribute> list = new List<CloudAttribute>();
						CloudAttribute cloudAttribute = new CloudAttribute(LobbyAttributeKeys.IsGameStarted, 0L, (bool?)(object)257);
						object obj = default(object);
						list.Add((CloudAttribute)(&obj));
						activeLobby3.lobbyOwnerSession.AddOrUpdateLobbyAttributes(list, null);
						return;
					}
				}
				OnJoinedLobby();
				return;
			}
		}
		SwitchLobbyState(activate: false);
	}

	private void OnJoinError()
	{
		if (_activeProvider != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		}
		StopReplicationServer();
		LeaveLobby();
	}

	private void ChangeUiState(bool activate, string infoText)
	{
		bool active = (byte)((activate ? 1u : 0u) ^ 1u) != 0;
		_initContainer.SetActive(active);
		_roomSelection.SetActive(activate);
		TextMeshProUGUI infoText2 = _infoText;
		infoText2.text = infoText;
		(string, object)[] args = new(string, object)[2];
		(string, object) tuple = ("Info", infoText);
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object item = default(object);
		(string, object) tuple2 = ("Activate", item);
		_ = 0;
		_logger.Info("Changing Ui State", args);
		Button button = (activate ? _joinButton : _startButton);
		button.Select();
	}

	private void SwitchLobbyState(bool activate)
	{
		bool active = (byte)((activate ? 1u : 0u) ^ 1u) != 0;
		_roomSelection.SetActive(active);
		_preCharacterSelectionLobby.SetActive(activate);
		Selectable right = default(Selectable);
		Component instance;
		Selectable origin;
		if (!activate)
		{
			Selectable component = _joinButton.GetComponent<Selectable>();
			component.Select();
			Selectable component2 = _lobbyIdInput.GetComponent<Selectable>();
			ForceBackButtonNavigation(null, component2, null, right);
			instance = BackButtonController.Instance;
			origin = component2;
		}
		else
		{
			_startButton.Select();
			ForceBackButtonNavigation(null, _startButton, null, right);
			Selectable component3 = BackButtonController.Instance.GetComponent<Selectable>();
			SetNavigationUp(_startButton, component3);
			origin = _leaveButton;
			instance = BackButtonController.Instance;
		}
		Selectable component4 = instance.GetComponent<Selectable>();
		SetNavigationUp(origin, component4);
	}

	private unsafe void OnJoinedLobby()
	{
		//IL_0063: Expected O, but got Ref
		//IL_00d8: Expected O, but got I
		//IL_05ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_05cf: Expected O, but got Unknown
		//IL_0273: Expected O, but got I4
		//IL_03d8: Expected O, but got Ref
		//IL_044d: Expected O, but got I
		//IL_04c7: Expected O, but got Ref
		//IL_0530: Expected O, but got Ref
		//IL_054d: Expected O, but got I
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Joined Lobby successfully", args);
		ChangeButtonsState(active: true);
		SwitchLobbyState(activate: true);
		LobbiesManager lobbiesManager = _lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		object obj2 = default(object);
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = activeLobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+98]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v179 @ rax_v11 (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		string text = default(string);
		_lobbyIdText.text = text;
		LobbiesManager lobbiesManager2 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer> value = OnPlayerJoined;
		lobbiesManager2._activeLobby.OnPlayerJoined -= value;
		LobbiesManager lobbiesManager3 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer> value2 = OnPlayerJoined;
		lobbiesManager3._activeLobby.OnPlayerJoined += value2;
		LobbiesManager lobbiesManager4 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer, string> value3 = new Action<object, LobbyPlayer, object>(OnPlayerLeft);
		lobbiesManager4._activeLobby.OnPlayerLeft -= value3;
		LobbiesManager lobbiesManager5 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer, string> value4 = new Action<object, LobbyPlayer, object>(OnPlayerLeft);
		lobbiesManager5._activeLobby.OnPlayerLeft += value4;
		LobbiesManager lobbiesManager6 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer> value5 = OnLobbyOwnerChanged;
		lobbiesManager6._activeLobby.OnLobbyOwnerChanged -= value5;
		LobbiesManager lobbiesManager7 = _lobbiesManager;
		LobbySession activeLobby2 = lobbiesManager7._activeLobby;
		Action<LobbySession, LobbyPlayer> b = OnLobbyOwnerChanged;
		Delegate obj3 = activeLobby2.OnLobbyOwnerChanged;
		object obj4 = activeLobby2 + 344;
		object obj7 = default(object);
		while (true)
		{
			Delegate obj5 = Delegate.Combine(obj3, b);
			object obj6;
			if ((object)obj5 == null)
			{
				obj6 = 0;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
				bool flag = obj7 == null;
				obj6 = obj7;
				if (flag)
				{
					break;
				}
			}
			bool flag2 = obj3 == obj4;
			Delegate obj8;
			if (obj3 == obj4)
			{
				obj4 = obj6;
				obj8 = obj3;
			}
			else
			{
				obj8 = (Delegate)obj4;
			}
			Delegate obj9 = obj3;
			if (!flag2)
			{
				obj9 = obj8;
			}
			bool flag3 = (object)obj9 != obj3;
			obj3 = obj9;
			if (!flag3)
			{
				LobbiesManager lobbiesManager8 = _lobbiesManager;
				Action<LobbySession, MessagesReceived> value6 = OnStartGameMessageReceived;
				lobbiesManager8._activeLobby.OnMessageReceived -= value6;
				LobbiesManager lobbiesManager9 = _lobbiesManager;
				Action<LobbySession, MessagesReceived> value7 = OnStartGameMessageReceived;
				lobbiesManager9._activeLobby.OnMessageReceived += value7;
				UpdatePlayerNames();
				UpdateAvailableDLC();
				LobbiesManager lobbiesManager10 = _lobbiesManager;
				LobbySession activeLobby3 = lobbiesManager10._activeLobby;
				object obj10 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
				_ = activeLobby3.lobbyData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+78]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+98]");
				obj10 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+B8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v198 @ rax_v55 (Coherence.Cloud.LobbySession)+D8]");
				_ = 0;
				if (OnlinePlatformSupport.OnlinePlatformSupportInstance == null)
				{
					OnlinePlatformSupport.Setup();
				}
				OnlinePlatformSupport.OnlinePlatformSupportInstance.OnLobbyOpen(text);
				LobbiesManager lobbiesManager11 = _lobbiesManager;
				LobbySession activeLobby4 = lobbiesManager11._activeLobby;
				object obj11 = (object)(&obj2);
				obj11 = activeLobby4.lobbyData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+78]");
				_ = 0;
				object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+98]");
				obj12 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+B8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v201 @ rax_v64 (Coherence.Cloud.LobbySession)+D8]");
				_ = 0;
				OnlinePlatformSupport.OnJoinedOnlineSession(text, null);
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 743 Invalid \"Jump target not found in method: 0x186D74760\"");
				throw new NullReferenceException();
			}
		}
		throw new InvalidCastException();
	}

	private void UpdateReadyState(long ready)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CUpdateReadyState_003Ed__73 stateMachine = default(_003CUpdateReadyState_003Ed__73);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void ChangeButtonsState(bool active)
	{
		bool isStartingGame = (byte)((active ? 1u : 0u) ^ 1u) != 0;
		_isStartingGame = isStartingGame;
		_createRoomButton.interactable = active;
		_joinButton.interactable = active;
		_leaveButton.interactable = active;
		UpdateStartButtonState(active);
		if (!active)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0C30");
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0B80");
		}
	}

	private unsafe void UpdateStartButtonState(bool active)
	{
		//IL_01eb: Expected O, but got I4
		//IL_00af: Expected O, but got Ref
		//IL_0118: Expected O, but got Ref
		//IL_0135: Expected O, but got I
		//IL_026b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0270: Expected O, but got Unknown
		LobbiesManager lobbiesManager = _lobbiesManager;
		bool flag;
		if (lobbiesManager._activeLobby == null)
		{
			flag = false;
		}
		else
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			bool flag2 = (nint)activeLobby.lobbyOwnerSession < 0;
			bool flag3 = activeLobby.lobbyOwnerSession == null;
			bool flag4 = !flag2;
			bool flag5 = !flag3;
			flag = flag5 & flag4;
		}
		bool flag7;
		if (flag)
		{
			LobbySession activeLobby2 = lobbiesManager._activeLobby;
			object obj2 = default(object);
			object obj = (object)(&obj2);
			obj = activeLobby2.lobbyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+68]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+78]");
			_ = 0;
			object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+88]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+98]");
			obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+A8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+B8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v104 @ rax_v20 (Coherence.Cloud.LobbySession)+D8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj4 = default(object);
			if ((nint)obj4 > 1)
			{
				bool flag6 = _lobbiesManager.ArePlayersReadyToStartGame();
				flag7 = flag6;
				goto IL_01c2;
			}
		}
		flag7 = false;
		goto IL_01c2;
		IL_01c2:
		bool interactable = flag7 & active;
		_startButton.interactable = interactable;
		object obj5 = active & flag7;
		bool flag8 = obj5 == null;
		bool interactable2 = false;
		if (!flag8)
		{
			PlayerOptionsData config = _playerOptions.Config;
			List<ItemType> list = config._003CCollectedItems_003Ek__BackingField;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v123 @ rcx_v12 (System.Collections.Generic.List`1<VampireSurvivors.Data.ItemType>)+18]");
			bool flag9 = (nint)0 == 0;
			interactable2 = false;
			if (!flag9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
				object obj7 = default(object);
				object obj6 = obj7 - -1;
				bool flag10 = obj6 == null;
				interactable2 = !flag10;
			}
		}
		_adventuresButton.interactable = interactable2;
		_collectionsButton.interactable = flag;
		_powerUpsButton.interactable = flag;
	}

	private unsafe void OnStartGameMessageReceived(LobbySession lobby, MessagesReceived messages)
	{
		//IL_0008: Expected O, but got Ref
		//IL_00f0: Expected O, but got Ref
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Expected O, but got Unknown
		//IL_0176: Expected O, but got I
		//IL_01bb: Expected O, but got I
		//IL_01ce: Expected O, but got Ref
		//IL_0232: Unknown result type (might be due to invalid IL or missing references)
		//IL_0237: Expected O, but got Unknown
		//IL_0254: Expected O, but got I
		//IL_0b89: Expected O, but got Ref
		//IL_0312: Expected O, but got Ref
		//IL_0329: Expected O, but got Ref
		//IL_033c: Expected native int or pointer, but got O
		//IL_0361: Expected O, but got Ref
		//IL_0373: Expected O, but got Ref
		//IL_0386: Expected native int or pointer, but got O
		//IL_041f: Expected I, but got O
		//IL_043b: Expected I8, but got O
		//IL_08ea: Expected O, but got Ref
		//IL_08f8: Expected I4, but got O
		//IL_091d: Expected O, but got Ref
		//IL_09b0: Expected O, but got Ref
		//IL_09be: Expected I4, but got O
		//IL_09e3: Expected O, but got Ref
		//IL_0a34: Expected O, but got I
		//IL_0a6e: Expected O, but got I
		//IL_058c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0591: Expected Ref, but got Unknown
		//IL_05a8: Expected I8, but got I4
		//IL_05b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_05b7: Expected Ref, but got Unknown
		//IL_0a85: Expected I, but got O
		//IL_06fa: Expected O, but got I4
		//IL_0b10: Expected O, but got I4
		//IL_0b1e: Expected I, but got O
		//IL_0abd: Expected O, but got I
		//IL_0ac6: Expected O, but got I4
		//IL_0b46: Expected O, but got I
		//IL_0c97: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c9c: Expected O, but got Unknown
		//IL_0ca4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ca9: Expected O, but got Unknown
		//IL_0ad4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ad9: Expected O, but got Unknown
		//IL_07a4: Expected O, but got I4
		//IL_0801: Expected I, but got O
		//IL_088a: Expected O, but got I4
		//IL_0898: Expected I, but got O
		//IL_0839: Expected O, but got I
		//IL_0842: Expected O, but got I4
		//IL_08cf: Expected O, but got I
		//IL_0850: Unknown result type (might be due to invalid IL or missing references)
		//IL_0855: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		List<string> messages2 = messages.Messages;
		if (messages2._size <= 0)
		{
			goto IL_0b68;
		}
		string[] items = messages2._items;
		if (items[0].StartsWith(LobbyAttributeKeys.ErrorP2PMessagePrefix))
		{
			return;
		}
		ChangeButtonsState(active: false);
		if (!PopupManager.PopupExists("HostStartingGame"))
		{
			Action onClose = default(Action);
			PopupManager.CreateAccountBlockingPopup("HostStartingGame", "", "", textisLocalizationTerm: false, onClose);
		}
		LobbiesManager lobbiesManager = _lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		obj3 = activeLobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		object obj4 = obj3 + 128;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+98]");
		obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v178 @ rax_v31 (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-38]");
		OnlinePlatformSupport.OnLobbyClosed((string)0);
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		obj5 = lobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		object obj6 = obj5 + 128;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+98]");
		obj6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		string key = (string)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 80));
		LobbyData lobbyData = default(LobbyData);
		CloudAttribute? attribute = lobbyData.GetAttribute(key);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1193 @ rax_v38 (System.Nullable`1<Coherence.Cloud.CloudAttribute>)+20]");
		_ = 0;
		nint num3;
		object obj15;
		string lobbyId2;
		INetworkProvider activeProvider2;
		string text2;
		if (attribute != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
			long longValue = ((CloudAttribute*)(&lobbyData))->GetLongValue();
			INetworkProvider activeProvider = ((longValue != 0) ? _p2pProvider : _cloudProvider);
			_activeProvider = activeProvider;
			Coherence.Log.Logger logger = _logger;
			(string, object)[] args = new(string, object)[3];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			IntPtr intPtr = default(IntPtr);
			string item = ((Enum)(&intPtr)).ToString();
			(string, object) tuple = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 112));
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple, (ValueTuple<string, object>)("Provider", item));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-70]");
			_ = 0;
			string item2 = ((Enum)(&intPtr)).ToString();
			(string, object) tuple2 = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 96));
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple2, (ValueTuple<string, object>)("Type", item2));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-60]");
			_ = 0;
			List<string> messages3 = messages.Messages;
			if (messages3._size > 0)
			{
				string[] items2 = messages3._items;
				(string, object) tuple3 = ("Message", items2[0]);
				_ = 0;
				nint num = (nint)logger;
				logger.Info("Received Start Game Message", args);
				ulong num2 = (ulong)(long)_activeProvider;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj7 = default(object);
				bool flag = (nint)obj7 != 1;
				System.ParamsArray lobbyId = (System.ParamsArray)messages.LobbyId;
				if (!flag)
				{
					lobbyId2 = messages.LobbyId;
					List<string> messages4 = messages.Messages;
					if (messages4._size <= 0)
					{
						goto IL_0b68;
					}
					string[] items3 = messages4._items;
					string text = items3[0];
					string joinP2PMessagePrefix = LobbyAttributeKeys.JoinP2PMessagePrefix;
					if ((object)items3[0] == LobbyAttributeKeys.JoinP2PMessagePrefix)
					{
						goto IL_05f2;
					}
					bool flag2 = items3[0] == null;
					lobbyId = (System.ParamsArray)messages.LobbyId;
					if (!flag2)
					{
						bool flag3 = LobbyAttributeKeys.JoinP2PMessagePrefix == null;
						lobbyId = (System.ParamsArray)messages.LobbyId;
						if (!flag3)
						{
							bool flag4 = text._stringLength != joinP2PMessagePrefix._stringLength;
							lobbyId = (System.ParamsArray)messages.LobbyId;
							if (!flag4)
							{
								ref byte first = ref *(byte*)(items3[0] + 20);
								num2 = (ulong)(text._stringLength + text._stringLength);
								bool flag5 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)(LobbyAttributeKeys.JoinP2PMessagePrefix + 20), num2);
								bool flag6 = !flag5;
								lobbyId = (System.ParamsArray)messages.LobbyId;
								if (!flag6)
								{
									goto IL_05f2;
								}
							}
						}
					}
				}
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
				object arg = (NetworkType)obj8;
				lobbyId = new System.ParamsArray(arg);
				string message = string.FormatHelper((IFormatProvider)null, "Starting game with {0} network type, unsubscribing from P2P events", (System.ParamsArray)(&tuple3));
				Debug.Log(message);
				Action<LobbySession, LobbyPlayer> value = OnPlayerJoined;
				lobby.OnPlayerJoined -= value;
				Action<LobbySession, MessagesReceived> value2 = OnStartGameMessageReceived;
				lobby.OnMessageReceived -= value2;
				Action<LobbySession, MessagesReceived> value3 = OnP2PFailedMessageReceived;
				lobby.OnMessageReceived -= value3;
				object obj9 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 192));
				object arg2 = (NetworkType)obj9;
				System.ParamsArray paramsArray = new System.ParamsArray(arg2);
				System.ParamsArray paramsArray2 = default(System.ParamsArray);
				string message2 = string.FormatHelper((IFormatProvider)null, "Starting game with {0} network type, joining game", (System.ParamsArray)(&paramsArray2));
				Debug.Log(message2);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
				Action<CoherenceClientConnectionManager> value4 = ShowOnlineLobby;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v83+80]");
				((CoherenceClientConnectionManager)0).OnSynced -= value4;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
				Action<CoherenceClientConnectionManager> value5 = ShowOnlineLobby;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v189 @ rax_v87+80]");
				((CoherenceClientConnectionManager)0).OnSynced += value5;
				activeProvider2 = _activeProvider;
				num3 = (nint)activeProvider2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1997 @ r9_v18 (Il2CppClass<VampireSurvivors.INetworkProvider>)+12E]");
				if ((nint)0 >= (nint)0)
				{
					goto IL_0afd;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1997 @ r9_v18 (Il2CppClass<VampireSurvivors.INetworkProvider>)+B0]");
				object obj10 = 0;
				object obj11 = 0;
				while (true)
				{
					object obj12 = obj11 + obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1969 @ r8_v46+v1972 @ rax_v94*8]");
					if (0 == (nint)typeof(INetworkProvider))
					{
						break;
					}
					obj11++;
					object obj13 = obj11;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1997 @ r9_v18 (Il2CppClass<VampireSurvivors.INetworkProvider>)+12E]");
					if ((nint)obj13 < 0)
					{
						continue;
					}
					goto IL_0afd;
				}
				object obj14 = obj11 + obj11;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1969 @ r8_v46+8+v2045 @ rcx_v77*8]");
				obj15 = (nint)0 + (nint)13;
				text2 = null;
				lobbyId2 = null;
				goto IL_0c80;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new IndexOutOfRangeException();
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		throw new IndexOutOfRangeException();
		IL_0ce5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
		goto IL_089d;
		IL_0879:
		string text3 = default(string);
		text2 = text3;
		object obj16 = 12;
		nint num4 = (nint)typeof(INetworkProvider);
		goto IL_0ce5;
		IL_0afd:
		text2 = null;
		lobbyId2 = null;
		obj16 = 13;
		num4 = (nint)typeof(INetworkProvider);
		goto IL_0ce5;
		IL_05f2:
		LobbiesManager lobbiesManager2 = _lobbiesManager;
		Action<LobbySession, MessagesReceived> value6 = OnP2PFailedMessageReceived;
		lobbiesManager2._activeLobby.OnMessageReceived += value6;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj17 = default(object);
		if (obj17 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v109+10]");
			if ((nint)0 > (nint)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				string errorMessage = default(string);
				OnP2PSessionError(errorMessage);
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1150");
		Action<string> value7 = OnP2PSessionError;
		Delegate obj19 = default(Delegate);
		Delegate obj18 = Delegate.Remove(obj19, value7);
		if ((object)obj18 == null)
		{
			object obj20 = 0;
			Delegate obj21 = obj19;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj20 = default(object);
			bool flag7 = obj20 == null;
			Delegate obj21 = obj18;
			if (flag7)
			{
				throw new InvalidCastException();
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA10C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1150");
		Action<string> b = OnP2PSessionError;
		Delegate obj23 = default(Delegate);
		Delegate obj22 = Delegate.Combine(obj23, b);
		if ((object)obj22 == null)
		{
			object obj24 = 0;
			Delegate obj25 = obj23;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj24 = default(object);
			bool flag8 = obj24 == null;
			Delegate obj25 = obj22;
			if (flag8)
			{
				throw new InvalidCastException();
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA10C0");
		activeProvider2 = _activeProvider;
		num3 = (nint)activeProvider2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1997 @ r9_v18 (Il2CppClass<VampireSurvivors.INetworkProvider>)+12E]");
		if ((nint)0 >= (nint)0)
		{
			goto IL_0879;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1997 @ r9_v18 (Il2CppClass<VampireSurvivors.INetworkProvider>)+B0]");
		object obj26 = 0;
		object obj27 = 0;
		while (true)
		{
			object obj28 = obj27 + obj27;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1860 @ r8_v63+v1865 @ rax_v125*8]");
			if (0 == (nint)typeof(INetworkProvider))
			{
				break;
			}
			obj27++;
			object obj29 = obj27;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1997 @ r9_v18 (Il2CppClass<VampireSurvivors.INetworkProvider>)+12E]");
			if ((nint)obj29 < 0)
			{
				continue;
			}
			goto IL_0879;
		}
		object obj30 = obj27 + obj27;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1860 @ r8_v63+8+v1986 @ rcx_v96*8]");
		obj15 = (nint)0 + (nint)12;
		text2 = text3;
		goto IL_0c80;
		IL_0b68:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_089d:
		Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v2003 @ rax_v99] (should have been resolved before IL gen)");
		return;
		IL_0c80:
		object obj31 = obj15 << 4;
		object obj32 = obj31 + 312;
		object obj33 = obj32 + num3;
		goto IL_089d;
	}

	private void OnP2PSessionError(string errorMessage)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1150");
		Action<string> value = OnP2PSessionError;
		Delegate obj2 = default(Delegate);
		Delegate obj = Delegate.Remove(obj2, value);
		bool flag = (object)obj == null;
		Delegate obj3 = obj;
		Delegate obj4 = obj2;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			bool flag2 = (object)obj3 == null;
			obj4 = obj;
			if (flag2)
			{
				throw new InvalidCastException();
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA10C0");
		string item = LobbyAttributeKeys.ErrorP2PMessagePrefix + errorMessage;
		string message = "P2P Session Error: " + errorMessage + ", sending error message to lobby";
		Debug.LogError(message);
		LobbiesManager lobbiesManager = _lobbiesManager;
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)item);
		}
		else
		{
			int size = list._size + 1;
			list._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		lobbiesManager._activeLobby.SendMessage(list, null);
	}

	private void OnLobbyOwnerChanged(LobbySession lobby, LobbyPlayer player)
	{
		LeaveLobby();
	}

	private unsafe void UpdatePlayerNames()
	{
		//IL_001a: Expected O, but got I
		//IL_002a: Expected O, but got I
		//IL_0033: Expected O, but got I4
		//IL_005c: Expected O, but got Ref
		//IL_00c5: Expected O, but got Ref
		//IL_00e2: Expected O, but got I
		//IL_0175: Expected O, but got Ref
		//IL_01de: Expected O, but got Ref
		//IL_01fb: Expected O, but got I
		//IL_0404: Expected O, but got Ref
		//IL_02f8: Expected I, but got O
		//IL_044f: Expected O, but got Ref
		List<TextMeshProUGUI>.Enumerator enumerator = default(List<TextMeshProUGUI>.Enumerator);
		if (enumerator.MoveNext())
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v527 @ rax_v66+B8]");
			object obj2 = 0;
			object obj3 = 0;
			throw new NullReferenceException();
		}
		LobbiesManager lobbiesManager = _lobbiesManager;
		int num = 0;
		int num2 = 0;
		object obj5 = default(object);
		IReadOnlyCollection<LobbyPlayer> readOnlyCollection = default(IReadOnlyCollection<LobbyPlayer>);
		LobbyPlayer lobbyPlayer2 = default(LobbyPlayer);
		string text = default(string);
		CloudAttribute cloudAttribute = default(CloudAttribute);
		Component component = default(Component);
		while (true)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			object obj4 = (object)(&obj5);
			obj4 = activeLobby.lobbyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+68]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+78]");
			_ = 0;
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj5, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+88]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+98]");
			obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+A8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+B8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v184 @ rax_v18 (Coherence.Cloud.LobbySession)+D8]");
			_ = 0;
			int count = readOnlyCollection.Count;
			if (num < count)
			{
				LobbiesManager lobbiesManager2 = _lobbiesManager;
				LobbySession activeLobby2 = lobbiesManager2._activeLobby;
				object obj7 = (object)(&obj5);
				obj7 = activeLobby2.lobbyData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+78]");
				_ = 0;
				object obj8 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj5, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+98]");
				obj8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+B8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v187 @ rax_v23 (Coherence.Cloud.LobbySession)+D8]");
				_ = 0;
				LobbyPlayer lobbyPlayer = ((IReadOnlyList<LobbyPlayer>)readOnlyCollection).get_Item(num2);
				CloudAttribute? attribute = lobbyPlayer2.GetAttribute((string)(&text));
				if (attribute == null)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
				string stringValue = cloudAttribute.GetStringValue();
				List<TextMeshProUGUI> lobbyPlayerNames = _lobbyPlayerNames;
				if (num2 < lobbyPlayerNames._size)
				{
					TextMeshProUGUI[] items = lobbyPlayerNames._items;
					TextMeshProUGUI textMeshProUGUI = items[num2];
					bool flag = stringValue == null;
					string text2 = "";
					if (!flag)
					{
						text2 = stringValue;
					}
					nint num3 = (nint)textMeshProUGUI;
					textMeshProUGUI.text = text2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
					GameObject gameObject = component.gameObject;
					OnlinePlayerProfileButton component2 = gameObject.GetComponent<OnlinePlayerProfileButton>();
					CloudAttribute? attribute2 = lobbyPlayer2.GetAttribute((string)(&text));
					if (attribute2 == null)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
					string stringValue2 = cloudAttribute.GetStringValue();
					component2.SetPlayerID(stringValue2);
					num2++;
					lobbiesManager = _lobbiesManager;
					num = num2;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				break;
			}
			return;
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
	}

	private unsafe void UpdateAvailableDLC()
	{
		//IL_005a: Expected I, but got O
		//IL_0b17: Expected O, but got I
		//IL_0110: Expected O, but got I
		//IL_01d0: Expected O, but got I
		//IL_01fd: Expected O, but got Ref
		//IL_020d: Expected O, but got I
		//IL_0287: Expected O, but got I
		//IL_0298: Expected O, but got I
		//IL_02a9: Expected O, but got I
		//IL_02ba: Expected O, but got I
		//IL_0183: Expected O, but got I
		//IL_0325: Expected O, but got I
		//IL_0344: Expected I, but got O
		//IL_0b02: Expected O, but got I
		//IL_0362: Expected O, but got I
		//IL_0381: Expected I, but got O
		//IL_08b6: Expected O, but got I
		//IL_08b6: Expected O, but got I
		//IL_0397: Expected O, but got Ref
		//IL_03a7: Expected O, but got I
		//IL_0421: Expected O, but got I
		//IL_0432: Expected O, but got I
		//IL_0443: Expected O, but got I
		//IL_0454: Expected O, but got I
		//IL_096e: Expected O, but got Ref
		//IL_09b6: Expected I, but got O
		//IL_0a0d: Expected I, but got O
		//IL_0a15: Expected I, but got O
		//IL_04f0: Expected O, but got I
		//IL_0500: Expected O, but got I
		//IL_0780: Expected O, but got Ref
		//IL_07aa: Expected I, but got O
		//IL_06f5: Expected I, but got O
		//IL_0725: Expected O, but got I4
		//IL_072d: Expected I, but got O
		//IL_0644: Expected I8, but got I4
		//IL_064e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0653: Expected Ref, but got Unknown
		//IL_0665: Unknown result type (might be due to invalid IL or missing references)
		//IL_066a: Expected Ref, but got Unknown
		//IL_0690: Expected O, but got I8
		//IL_06a1: Expected O, but got I8
		//IL_06a9: Expected O, but got Ref
		//IL_0823: Expected I, but got O
		List<DlcType> list = new List<DlcType>();
		Dictionary<LobbyPlayer, List<DlcType>> dictionary = null;
		EqualityComparer<LobbyPlayer> equalityComparer = EqualityComparer<LobbyPlayer>.Default;
		if (equalityComparer != null)
		{
			_ = 0;
		}
		nint num = (nint)typeof(DlcSystem);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v216 @ rax_v14 (Il2CppClass<VampireSurvivors.Framework.DLC.DlcSystem>)+B8]");
		nint num2 = 0;
		DlcCatalog dlcCatalog = DlcSystem._dlcCatalog;
		if ((object)DlcSystem._dlcCatalog != null && dlcCatalog._DlcData != null)
		{
			Dictionary<DlcType, DlcData>.Enumerator enumerator = default(Dictionary<DlcType, DlcData>.Enumerator);
			while (enumerator.MoveNext())
			{
				bool flag = list == null;
				num2 = (nint)(&enumerator);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+1C]");
					_ = (nint)0 + (nint)1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
					num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+10]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						if (0 >= (nint)DlcSystem._loadingManager)
						{
							((List<System.Int32Enum>)(object)list).AddWithResize((System.Int32Enum)0);
							continue;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						object obj2 = (nint)0 + (nint)1;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ rax_v4 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+18]");
						if (0 < (nint)DlcSystem._loadingManager)
						{
							_ = 0;
							continue;
						}
						throw new IndexOutOfRangeException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			int num3 = 0;
			Dictionary<LobbyPlayer, List<DlcType>> playerOwnedDLCs = dictionary;
			num2 = (nint)(&enumerator);
			object obj6 = default(object);
			IReadOnlyCollection<LobbyPlayer> readOnlyCollection = default(IReadOnlyCollection<LobbyPlayer>);
			LobbyPlayer lobbyPlayer2 = default(LobbyPlayer);
			string text = default(string);
			CloudAttribute cloudAttribute = default(CloudAttribute);
			StringSplitOptions options = default(StringSplitOptions);
			string text4 = default(string);
			List<DlcType>.Enumerator enumerator2 = default(List<DlcType>.Enumerator);
			object obj12 = default(object);
			List<DlcType>.Enumerator enumerator3 = default(List<DlcType>.Enumerator);
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ stack_8+1A8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ stack_8+1A8]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ rax_v40+10]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v612 @ rax_v40+10]");
				if ((nint)0 == 0)
				{
					break;
				}
				object obj5 = (object)(&obj6);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+18]");
				obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+78]");
				_ = 0;
				num2 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj6, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+98]");
				DlcSystem._dlcCatalog = (DlcCatalog)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+A8]");
				DlcSystem._licenseManager = (LicenseManager)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+B8]");
				DlcSystem._updateManager = (UpdateManager)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+C8]");
				DlcSystem._dlcSelection = (DLCSelection)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v601 @ rax_v41+D8]");
				_ = 0;
				if (readOnlyCollection == null)
				{
					break;
				}
				int count = readOnlyCollection.Count;
				if (num3 < count)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ stack_8+1A8]");
					object obj7 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ stack_8+1A8]");
					bool flag2 = (nint)0 == 0;
					num2 = (nint)readOnlyCollection;
					if (flag2)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v66+10]");
					object obj8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v603 @ rax_v66+10]");
					bool flag3 = (nint)0 == 0;
					num2 = (nint)readOnlyCollection;
					if (flag3)
					{
						break;
					}
					object obj9 = (object)(&obj6);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+18]");
					obj9 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+28]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+38]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+48]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+58]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+68]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+78]");
					_ = 0;
					num2 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj6, 128));
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+88]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+98]");
					DlcSystem._dlcCatalog = (DlcCatalog)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+A8]");
					DlcSystem._licenseManager = (LicenseManager)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+B8]");
					DlcSystem._updateManager = (UpdateManager)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+C8]");
					DlcSystem._dlcSelection = (DLCSelection)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v604 @ rax_v67+D8]");
					_ = 0;
					if (readOnlyCollection == null)
					{
						break;
					}
					LobbyPlayer lobbyPlayer = ((IReadOnlyList<LobbyPlayer>)readOnlyCollection).get_Item(num3);
					CloudAttribute? attribute = lobbyPlayer2.GetAttribute((string)(&text));
					if (attribute != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
						string stringValue = cloudAttribute.GetStringValue();
						List<DlcType> list2 = new List<DlcType>();
						bool flag4 = stringValue == null;
						num2 = (nint)list2;
						if (flag4)
						{
							break;
						}
						bool flag5 = "," != null;
						string separator = ",";
						if (!flag5)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
							object obj10 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1838 @ rax_v116+B8]");
							object obj11 = 0;
							separator = (string)obj11;
						}
						string[] array = stringValue.SplitInternal(separator, (string[])null, 2147483647, options);
						bool flag6 = array == null;
						int i = 0;
						int num4 = 2147483647;
						string[] array2 = null;
						nint num5 = (nint)stringValue;
						num2 = (nint)stringValue;
						if (flag6)
						{
							break;
						}
						for (; i < array.Length; i++)
						{
							bool flag7 = i >= array.Length;
							num2 = num5;
							if (!flag7)
							{
								string text2 = array[i];
								if (array[i] == null)
								{
									continue;
								}
								string text3 = "";
								bool flag8 = (object)array[i] == "";
								separator = "";
								if (flag8)
								{
									continue;
								}
								bool flag9 = "" == null;
								int num6 = num4;
								string[] array3 = array2;
								if (!flag9)
								{
									bool flag10 = text2._stringLength != text3._stringLength;
									num6 = num4;
									array3 = array2;
									if (!flag10)
									{
										ulong num7 = (ulong)(text2._stringLength + text2._stringLength);
										ref byte reference = ref *(byte*)("" + 20);
										ref byte reference2 = ref *(byte*)(array[i] + 20);
										bool flag11 = System.SpanHelpers.SequenceEqual(ref reference2, ref reference, num7);
										num6 = 0;
										array3 = (string[])num7;
										num4 = 0;
										array2 = (string[])num7;
										separator = (string)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
										num5 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference2);
										if (flag11)
										{
											continue;
										}
									}
								}
								int num8 = StringExtensions.ToInt(array[i]);
								bool flag12 = list2 == null;
								num2 = (nint)array[i];
								if (flag12)
								{
									goto end_IL_0b07;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
								num4 = num6;
								array2 = array3;
								separator = (string)num8;
								num5 = (nint)list2;
								continue;
							}
							throw new IndexOutOfRangeException();
						}
						bool flag13 = dictionary == null;
						num2 = num5;
						if (flag13)
						{
							break;
						}
						bool flag14 = ((Dictionary<LobbyPlayer, object>)(object)dictionary).TryInsert((LobbyPlayer)(&text4), (object)list2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
						List<DlcType> list3 = new List<DlcType>();
						bool flag15 = list == null;
						num2 = (nint)list3;
						if (flag15)
						{
							break;
						}
						while (enumerator2.MoveNext())
						{
							bool flag16 = list2 == null;
							num2 = (nint)(&enumerator2);
							if (!flag16)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A99BA0");
								if (obj12 == null)
								{
									bool flag17 = list3 == null;
									num2 = (nint)list2;
									if (flag17)
									{
										throw new NullReferenceException();
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
								}
								continue;
							}
							throw new NullReferenceException();
						}
						bool flag18 = list3 == null;
						num2 = (nint)(&enumerator2);
						if (flag18)
						{
							break;
						}
						while (enumerator3.MoveNext())
						{
							bool flag19 = ((List<System.Int32Enum>)(object)list).Remove((System.Int32Enum)0);
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1921 @ rax_v86 (System.Collections.Generic.List`1<VampireSurvivors.Data.DlcType>)+1C]");
						_ = (nint)0 + (nint)1;
						_ = 0;
						num3++;
						playerOwnedDLCs = dictionary;
						num2 = (nint)(&enumerator3);
						continue;
					}
					System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ stack_8+178]");
				DlcSystem.OnlineAvaliableDlcTypes = (List<DlcType>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ stack_8+170]");
				if ((nint)0 == 0)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ stack_8+170]");
				nint num9 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1087 @ stack_8+178]");
				((OnlineDLCSection)num9).UpdateUI((List<DlcType>)0, playerOwnedDLCs);
				return;
				continue;
				end_IL_0b07:
				break;
			}
		}
		throw new NullReferenceException();
	}

	private unsafe List<DlcType> GetDLCStringAsTypes(string dlcString)
	{
		//IL_0262: Expected O, but got I4
		//IL_0279: Expected O, but got I4
		//IL_003f: Expected O, but got I
		//IL_004f: Expected O, but got I
		//IL_0218: Unknown result type (might be due to invalid IL or missing references)
		//IL_021d: Expected O, but got Unknown
		//IL_0165: Unknown result type (might be due to invalid IL or missing references)
		//IL_016a: Expected Ref, but got Unknown
		//IL_0181: Expected I8, but got I4
		//IL_018b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0190: Expected Ref, but got Unknown
		//IL_01b6: Expected O, but got I8
		//IL_01c7: Expected O, but got I8
		List<DlcType> result = new List<DlcType>();
		bool flag = "," != null;
		string separator = ",";
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v21+B8]");
			object obj2 = 0;
			separator = (string)obj2;
		}
		StringSplitOptions options = default(StringSplitOptions);
		string[] array = dlcString.SplitInternal(separator, (string[])null, 2147483647, options);
		object obj3 = 0;
		int num = 2147483647;
		string[] array2 = null;
		object obj4 = 0;
		while (true)
		{
			if ((nint)obj4 < array.Length)
			{
				if ((nint)obj3 >= array.Length)
				{
					break;
				}
				string text = array[obj3];
				if (array[obj3] != null)
				{
					string text2 = "";
					bool flag2 = (object)array[obj3] == "";
					separator = "";
					if (!flag2)
					{
						bool flag3 = "" == null;
						int num2 = num;
						string[] array3 = array2;
						if (!flag3)
						{
							bool flag4 = text._stringLength != text2._stringLength;
							num2 = num;
							array3 = array2;
							if (!flag4)
							{
								ref byte first = ref *(byte*)(array[obj3] + 20);
								ulong num3 = (ulong)(text._stringLength + text._stringLength);
								bool flag5 = System.SpanHelpers.SequenceEqual(ref first, ref *(byte*)("" + 20), num3);
								num2 = 0;
								array3 = (string[])num3;
								num = 0;
								array2 = (string[])num3;
								if (flag5)
								{
									goto IL_020f;
								}
							}
						}
						int num4 = StringExtensions.ToInt(array[obj3]);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A993B0");
						num = num2;
						array2 = array3;
					}
				}
				goto IL_020f;
			}
			return result;
			IL_020f:
			obj3++;
			obj4 = obj3;
		}
		return (List<DlcType>)(object)new IndexOutOfRangeException();
	}

	private unsafe void OnGameReady(bool result, string errorMessage, Dictionary<string, string> networkAttributes)
	{
		//IL_0070: Expected O, but got I4
		//IL_0096: Expected O, but got I4
		//IL_00b3: Expected O, but got I4
		//IL_00b3: Expected I8, but got I4
		//IL_00f4: Expected O, but got Ref
		//IL_0101: Expected O, but got Ref
		//IL_0143: Expected O, but got I4
		//IL_0166: Expected O, but got I
		//IL_01df: Expected O, but got I
		//IL_01c4: Expected O, but got Ref
		//IL_0229: Expected O, but got I
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_023e: Expected O, but got Unknown
		bool flag = _activeProvider == null;
		List<CloudAttribute> list = (List<CloudAttribute>)(object)this;
		if (!flag)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if ((nint)obj == 1 && !result)
			{
				StopReplicationServer();
				OnlineErrorManager.ShowError(OnlineErrorType.CreateGame, errorMessage);
				ChangeButtonsState(active: true);
				return;
			}
			list = (List<CloudAttribute>)1;
			if (_activeProvider != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				long value = default(long);
				CloudAttribute cloudAttribute = new CloudAttribute(LobbyAttributeKeys.NetworkType, value, (bool?)(object)257);
				CloudAttribute cloudAttribute2 = new CloudAttribute(LobbyAttributeKeys.IsGameStarted, 1L, (bool?)(object)257);
				List<CloudAttribute> list2 = new List<CloudAttribute>();
				bool flag2 = list2 == null;
				list = list2;
				if (!flag2)
				{
					CloudAttribute cloudAttribute3 = default(CloudAttribute);
					list2.Add((CloudAttribute)(&cloudAttribute3));
					list2.Add((CloudAttribute)(&cloudAttribute3));
					bool flag3 = networkAttributes == null;
					list = list2;
					if (!flag3)
					{
						Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
						string value2 = default(string);
						CloudAttribute cloudAttribute4 = default(CloudAttribute);
						while (enumerator.MoveNext())
						{
							cloudAttribute3 = new CloudAttribute(null, value2, (bool?)(object)257);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v18 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+1C]");
							_ = (nint)0 + (nint)1;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v18 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+10]");
							list = (List<CloudAttribute>)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v18 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v18 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
								nint num = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v3 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
								if (num >= 0)
								{
									list2.AddWithResize((CloudAttribute)(&cloudAttribute4));
									continue;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v18 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
								object obj2 = (nint)0 + (nint)1;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v18 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
								nint num2 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v325 @ rcx_v3 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
								if (num2 < 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v18 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
									object obj3 = (nint)0 * (nint)4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v524 @ rax_v18 (System.Collections.Generic.List`1<Coherence.Cloud.CloudAttribute>)+18]");
									object obj4 = 0 + obj3;
									_ = 0;
									_ = 0;
									continue;
								}
								throw new IndexOutOfRangeException();
							}
							throw new NullReferenceException();
						}
						UpdateLobbyAttributes(list2);
						return;
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void UpdateLobbyAttributes(List<CloudAttribute> attributes)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CUpdateLobbyAttributes_003Ed__83 stateMachine = default(_003CUpdateLobbyAttributes_003Ed__83);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void OnAttributesAdded(RequestResponse<bool> req)
	{
		if ((object)req != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj = default(object);
			if (obj != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Action value = OnP2PSessionReady;
				Delegate source = default(Delegate);
				Delegate obj2 = Delegate.Remove(source, value);
				bool flag = (object)obj2 == null;
				Delegate obj3 = null;
				if (!flag)
				{
					bool flag2 = (object)obj2.GetType() != typeof(Action);
					obj3 = null;
					if (!flag2)
					{
						obj3 = obj2;
					}
					if ((object)obj3 == null)
					{
						goto IL_0470;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Action b = OnP2PSessionReady;
				Delegate a = default(Delegate);
				Delegate obj4 = Delegate.Combine(a, b);
				bool flag3 = (object)obj4 == null;
				Delegate obj5 = null;
				if (!flag3)
				{
					bool flag4 = (object)obj4.GetType() != typeof(Action);
					obj5 = null;
					if (!flag4)
					{
						obj5 = obj4;
					}
					if ((object)obj5 == null)
					{
						goto IL_047c;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1150");
				Action<string> value2 = OnP2PSessionError;
				Delegate obj7 = default(Delegate);
				Delegate obj6 = Delegate.Remove(obj7, value2);
				bool flag5 = (object)obj6 == null;
				Delegate obj8 = obj6;
				Delegate obj9 = obj7;
				if (!flag5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag6 = (object)obj8 == null;
					obj9 = obj6;
					if (flag6)
					{
						InvalidCastException ex = new InvalidCastException();
						goto IL_047c;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA10C0");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1150");
				Action<string> b2 = OnP2PSessionError;
				Delegate obj11 = default(Delegate);
				Delegate obj10 = Delegate.Combine(obj11, b2);
				bool flag7 = (object)obj10 == null;
				Delegate obj12 = obj10;
				Delegate obj13 = obj11;
				if (!flag7)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
					bool flag8 = (object)obj12 == null;
					obj13 = obj10;
					if (flag8)
					{
						throw new InvalidCastException();
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA10C0");
				LobbiesManager lobbiesManager = _lobbiesManager;
				Action<LobbySession, MessagesReceived> value3 = OnP2PFailedMessageReceived;
				lobbiesManager._activeLobby.OnMessageReceived -= value3;
				LobbiesManager lobbiesManager2 = _lobbiesManager;
				Action<LobbySession, MessagesReceived> value4 = OnP2PFailedMessageReceived;
				lobbiesManager2._activeLobby.OnMessageReceived += value4;
				List<LobbyPlayer> messageRecipients = GetMessageRecipients();
				LobbiesManager lobbiesManager3 = _lobbiesManager;
				List<string> list = new List<string>();
				list.Add(LobbyAttributeKeys.JoinP2PMessagePrefix);
				Action<RequestResponse<bool>> action = null;
				((RoomSelectionPage)(object)action).OnStartGameMessageSent((RequestResponse<bool>)this);
				lobbiesManager3._activeLobby.SendMessage(list, action, messageRecipients);
			}
			else
			{
				StartHostingCoherenceGame();
			}
		}
		else
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("onlineLang/ErrorStartGameIssueDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			OnlineErrorManager.ShowError(OnlineErrorType.StartGame, translation);
			ChangeButtonsState(active: true);
		}
		return;
		IL_0470:
		throw new InvalidCastException();
		IL_047c:
		InvalidCastException ex2 = new InvalidCastException();
		goto IL_0470;
	}

	private unsafe List<LobbyPlayer> GetMessageRecipients()
	{
		//IL_0044: Expected O, but got Ref
		//IL_00ad: Expected O, but got Ref
		//IL_00ca: Expected O, but got I
		//IL_00e7: Expected O, but got I
		//IL_0104: Expected O, but got I
		//IL_014d: Expected O, but got Ref
		//IL_0156: Expected O, but got I4
		//IL_019a: Expected O, but got I4
		//IL_01e8: Expected O, but got I
		//IL_01f1: Expected O, but got I4
		//IL_024f: Expected O, but got I
		//IL_0357: Expected O, but got I
		//IL_0360: Unknown result type (might be due to invalid IL or missing references)
		//IL_0365: Expected O, but got Unknown
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0204: Expected O, but got Unknown
		//IL_0284: Expected O, but got I
		//IL_02a9: Expected I, but got O
		//IL_02b9: Expected O, but got I
		//IL_0301: Expected O, but got Ref
		//IL_030f: Expected I, but got O
		//IL_031f: Expected O, but got I
		List<LobbyPlayer> list = new List<LobbyPlayer>();
		LobbiesManager lobbiesManager = _lobbiesManager;
		bool flag = _lobbiesManager == null;
		List<LobbyPlayer> list2 = list;
		if (!flag)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			bool flag2 = lobbiesManager._activeLobby == null;
			list2 = list;
			if (!flag2)
			{
				object obj2 = default(object);
				object obj = (object)(&obj2);
				obj = activeLobby.lobbyData;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+28]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+38]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+48]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+58]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+68]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+78]");
				_ = 0;
				list2 = (List<LobbyPlayer>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+88]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+98]");
				list2 = (List<LobbyPlayer>)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+A8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+B8]");
				object obj3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+B8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+C8]");
				LobbyPlayer lobbyPlayer = (LobbyPlayer)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+C8]");
				_ = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v69 @ rax_v18 (Coherence.Cloud.LobbySession)+D8]");
				_ = 0;
				object obj4 = default(object);
				if (obj4 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					object obj6 = default(object);
					object obj5 = (object)(&obj6);
					PlayerAccountId playerAccountId = (PlayerAccountId)0;
					object obj7 = default(object);
					object obj17 = default(object);
					LobbyPlayer lobbyPlayer2 = default(LobbyPlayer);
					LobbyPlayer lobbyPlayer3 = default(LobbyPlayer);
					object obj18 = default(object);
					while (true)
					{
						object obj16;
						if (obj6 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
							if (obj7 != null)
							{
								bool flag3 = obj6 == null;
								playerAccountId = (PlayerAccountId)0;
								if (!flag3)
								{
									object obj8 = obj6;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r10_v7+12E]");
									if ((nint)0 >= (nint)0)
									{
										goto IL_0228;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r10_v7+B0]");
									object obj9 = 0;
									object obj10 = 0;
									while (true)
									{
										object obj11 = obj10 + obj10;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ r8_v19+v544 @ rcx_v32*8]");
										if (0 == (nint)typeof(IEnumerator<LobbyPlayer>))
										{
											break;
										}
										obj10++;
										object obj12 = obj10;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ r10_v7+12E]");
										if ((nint)obj12 < 0)
										{
											continue;
										}
										goto IL_0228;
									}
									object obj13 = obj10 + obj10;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v539 @ r8_v19+8+v598 @ rcx_v34*8]");
									object obj14 = (nint)0 << 4;
									object obj15 = obj14 + 312;
									obj16 = obj15 + obj8;
									goto IL_04a2;
								}
								throw new NullReferenceException();
							}
							if (obj5 != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
							}
							break;
						}
						throw new NullReferenceException();
						IL_0228:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
						obj16 = obj17;
						goto IL_04a2;
						IL_04a2:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v603 @ r8_v12] (should have been resolved before IL gen)");
						playerAccountId = (PlayerAccountId)_lobbiesManager;
						if (_lobbiesManager != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rcx_v6 (Coherence.Cloud.PlayerAccountId)+10]");
							playerAccountId = (PlayerAccountId)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rcx_v6 (Coherence.Cloud.PlayerAccountId)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rcx_v6 (Coherence.Cloud.PlayerAccountId)+118]");
								lobbyPlayer = (LobbyPlayer)0;
								PlayerAccountId id = lobbyPlayer2.Id;
								PlayerAccountId id2 = lobbyPlayer3.Id;
								bool flag4 = id != id2;
								nint num = (nint)typeof(IEnumerator<LobbyPlayer>);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v441 @ rcx_v6 (Coherence.Cloud.PlayerAccountId)+128]");
								obj3 = 0;
								playerAccountId = id;
								if (flag4)
								{
									bool flag5 = list == null;
									playerAccountId = id;
									if (flag5)
									{
										throw new NullReferenceException();
									}
									list.Add((LobbyPlayer)(&lobbyPlayer2));
									num = (nint)typeof(IEnumerator<LobbyPlayer>);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v247 @ rax_v29+10]");
									obj3 = 0;
									lobbyPlayer = (LobbyPlayer)obj18;
									playerAccountId = (PlayerAccountId)list;
								}
								continue;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					return list;
				}
			}
		}
		throw new NullReferenceException();
	}

	private unsafe void OnP2PFailedMessageReceived(LobbySession lobby, MessagesReceived messages)
	{
		//IL_0008: Expected O, but got Ref
		//IL_003e: Expected O, but got I
		//IL_007b: Expected O, but got I
		//IL_009b: Expected O, but got I
		//IL_00f1: Expected O, but got Ref
		//IL_0155: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Expected O, but got Unknown
		//IL_0177: Expected O, but got I
		//IL_01eb: Expected O, but got I
		//IL_01f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f9: Expected O, but got Unknown
		//IL_0260: Expected O, but got I
		//IL_071d: Expected O, but got I4
		//IL_073a: Expected O, but got Ref
		//IL_0757: Expected O, but got Ref
		//IL_0764: Expected O, but got Ref
		//IL_02b6: Expected O, but got I
		//IL_024b: Expected O, but got I8
		//IL_079d: Expected O, but got I
		//IL_02f8: Expected O, but got I
		//IL_030d: Expected O, but got I
		//IL_03c4: Expected O, but got Ref
		//IL_03d7: Expected native int or pointer, but got O
		//IL_041d: Expected I, but got O
		//IL_0478: Expected O, but got Ref
		//IL_04dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_04e1: Expected O, but got Unknown
		//IL_04fe: Expected O, but got I
		//IL_0803: Expected O, but got Ref
		//IL_0811: Expected O, but got Ref
		//IL_0624: Expected I, but got O
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_003C_003Ec__DisplayClass86_0 obj3 = new _003C_003Ec__DisplayClass86_0();
		obj3.messages = (MessagesReceived)messages.LobbyId;
		_ = messages.Time;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (VampireSurvivors.UI.RoomSelectionPage+<>c__DisplayClass86_0)+28]");
		object obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v18+18]");
		if ((nint)0 <= (nint)0)
		{
			goto IL_0702;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v149 @ rax_v18+10]");
		object obj5 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v160 @ rcx_v14+20]");
		if (!((string)0).StartsWith(LobbyAttributeKeys.ErrorP2PMessagePrefix))
		{
			return;
		}
		PopupManager.ClosePopup("HostStartingGame");
		LobbiesManager lobbiesManager = _lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
		obj6 = activeLobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		object obj7 = obj6 + 128;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+98]");
		obj7 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ rax_v26 (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		Func<LobbyPlayer, bool> func = null;
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r10_v9 (Il2CppMethodInfo)+8]");
		_ = 0;
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r10_v9 (Il2CppMethodInfo)+4C]");
		object obj8 = (nint)0 >> 4;
		object obj9 = obj8 & 1;
		object obj10;
		if (obj9 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v120 @ r10_v9 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				obj10 = 6447980672L;
				goto IL_0714;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v28 (System.Func`2<Coherence.Cloud.LobbyPlayer, System.Boolean>)+10]");
		obj10 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v987 @ rax_v28 (System.Func`2<Coherence.Cloud.LobbyPlayer, System.Boolean>)+20]");
		_ = 0;
		goto IL_0714;
		IL_0714:
		object obj11 = 24;
		_ = 6447980544L;
		object obj12 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 120));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182FF43B0");
		LobbyPlayer lobbyPlayer = (LobbyPlayer)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 120));
		CloudAttribute cloudAttribute = default(CloudAttribute);
		CloudAttribute? attribute = ((LobbyPlayer*)lobbyPlayer)->GetAttribute((string)(&cloudAttribute));
		object obj13 = attribute;
		string text;
		if (attribute != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
			string stringValue = cloudAttribute.GetStringValue();
			CloudAttribute cloudAttribute2 = default(CloudAttribute);
			cloudAttribute = cloudAttribute2;
			object obj14 = default(object);
			obj13 = obj14;
			text = stringValue;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
			cloudAttribute = (CloudAttribute)0;
			text = null;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ rax_v2 (VampireSurvivors.UI.RoomSelectionPage+<>c__DisplayClass86_0)+28]");
		object obj15 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v43+18]");
		if ((nint)0 <= (nint)0)
		{
			goto IL_0702;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v43+10]");
		object obj16 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v162 @ rcx_v29+20]");
		string text2 = (string)0;
		string errorP2PMessagePrefix = LobbyAttributeKeys.ErrorP2PMessagePrefix;
		int length = text2._stringLength - errorP2PMessagePrefix._stringLength;
		string text3 = text2.Substring(errorP2PMessagePrefix._stringLength, length);
		if (text == null)
		{
			text = "Unknown Player";
		}
		string text4 = "P2P Error from " + text + ": " + text3;
		LobbiesManager lobbiesManager2 = _lobbiesManager;
		Action<LobbySession, MessagesReceived> value = OnP2PFailedMessageReceived;
		lobbiesManager2._activeLobby.OnMessageReceived -= value;
		Coherence.Log.Logger logger = _logger;
		(string, object)[] array = new(string, object)[1];
		(string, object) tuple = ((string, object))System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 120));
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write((void*)(nint)tuple, (ValueTuple<string, object>)("Message", text4));
		if (array.Length > 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-78]");
			_ = 0;
			nint num2 = (nint)logger;
			logger.Error("Received P2P Error Message", array);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			StopReplicationServer();
			LobbiesManager lobbiesManager3 = _lobbiesManager;
			LobbySession activeLobby2 = lobbiesManager3._activeLobby;
			object obj17 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			obj17 = activeLobby2.lobbyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+68]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+78]");
			_ = 0;
			object obj18 = obj17 + 128;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+88]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+98]");
			obj18 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+A8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+B8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v809 @ rax_v60 (Coherence.Cloud.LobbySession)+D8]");
			_ = 0;
			string key = (string)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 16));
			LobbyData lobbyData = (LobbyData)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 72));
			CloudAttribute? attribute2 = ((LobbyData*)lobbyData)->GetAttribute(key);
			if (attribute2 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
				long longValue = cloudAttribute.GetLongValue();
				if (longValue != 1)
				{
					OnlineErrorManager.ShowError(OnlineErrorType.StartGame, text4);
					ChangeButtonsState(active: true);
					return;
				}
				LobbiesManager lobbiesManager4 = _lobbiesManager;
				if (lobbiesManager4._activeLobby == null)
				{
					return;
				}
				LobbySession activeLobby3 = lobbiesManager4._activeLobby;
				if (activeLobby3._003CIsDisposed_003Ek__BackingField || (nint)activeLobby3.lobbyOwnerSession <= 0)
				{
					return;
				}
				Coherence.Log.Logger logger2 = _logger;
				(string, object)[] args = Array.Empty<(string, object)>();
				nint num3 = (nint)logger2;
				logger2.Info("P2P Session Error. Fallbacking to coherence Cloud", args);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Action value2 = OnP2PSessionReady;
				Delegate source = default(Delegate);
				Delegate obj19 = Delegate.Remove(source, value2);
				bool flag = (object)obj19 == null;
				Delegate obj20 = null;
				if (!flag)
				{
					bool flag2 = (object)obj19.GetType() != typeof(Action);
					obj20 = null;
					if (!flag2)
					{
						obj20 = obj19;
					}
					if ((object)obj20 == null)
					{
						goto IL_087f;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				StopReplicationServer();
				StartGameBasedOnNetworkType(NetworkType.Cloud);
				return;
			}
			System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
			throw new NullReferenceException();
		}
		IndexOutOfRangeException ex = new IndexOutOfRangeException();
		goto IL_087f;
		IL_0702:
		System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
		return;
		IL_087f:
		throw new InvalidCastException();
	}

	private void FallbackToCoherenceCloud()
	{
		//IL_000d: Expected I, but got O
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args = Array.Empty<(string, object)>();
		if (_logger != null)
		{
			nint num = (nint)logger;
			_logger.Info("P2P Session Error. Fallbacking to coherence Cloud", args);
			if (_activeProvider != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Action value = OnP2PSessionReady;
				Delegate source = default(Delegate);
				Delegate obj = Delegate.Remove(source, value);
				bool flag = (object)obj == null;
				Delegate obj2 = null;
				if (!flag)
				{
					bool flag2 = (object)obj.GetType() != typeof(Action);
					obj2 = null;
					if (!flag2)
					{
						obj2 = obj;
					}
					if ((object)obj2 == null)
					{
						goto IL_0153;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				StopReplicationServer();
				StartGameBasedOnNetworkType(NetworkType.Cloud);
				return;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_0153;
		IL_0153:
		throw new InvalidCastException();
	}

	private void OnP2PSessionReady()
	{
		//IL_000d: Expected I, but got O
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args = Array.Empty<(string, object)>();
		if (_logger != null)
		{
			nint num = (nint)logger;
			_logger.Info("P2P Session Ready. Starting Game", args);
			if (_activeProvider != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				Action value = OnP2PSessionReady;
				Delegate source = default(Delegate);
				Delegate obj = Delegate.Remove(source, value);
				bool flag = (object)obj == null;
				Delegate obj2 = null;
				if (!flag)
				{
					bool flag2 = (object)obj.GetType() != typeof(Action);
					obj2 = null;
					if (!flag2)
					{
						obj2 = obj;
					}
					if ((object)obj2 == null)
					{
						goto IL_014b;
					}
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003870");
				Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 134 Invalid \"Jump target not found in method: 0x186D79150\"");
			}
		}
		NullReferenceException ex = new NullReferenceException();
		goto IL_014b;
		IL_014b:
		throw new InvalidCastException();
	}

	private void StartHostingCoherenceGame()
	{
		//IL_006e: Expected O, but got I
		//IL_006e: Expected O, but got I
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge> onConnected = masterBridge.onConnected;
		UnityAction<CoherenceBridge> unityAction = OnStartedHosting;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ rsi_v2 (UnityEngine.Events.UnityEvent`1<Coherence.Toolkit.CoherenceBridge>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ rax_v9 (UnityEngine.Events.UnityAction`1<Coherence.Toolkit.CoherenceBridge>)+20]");
		((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		UnityAction<CoherenceBridge> call = OnStartedHosting;
		masterBridge2.onConnected.AddListener(call);
		CoherenceBridge masterBridge3 = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnectionManager> value = InstantiateLobbyEntities;
		masterBridge3._003CClientConnections_003Ek__BackingField.OnSynced -= value;
		CoherenceBridge masterBridge4 = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnectionManager> value2 = InstantiateLobbyEntities;
		masterBridge4._003CClientConnections_003Ek__BackingField.OnSynced += value2;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
	}

	private void OnStartedHosting(CoherenceBridge _)
	{
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Started Hosting Game. Sending Message To The Lobby.", args);
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CSendStartGameMessage_003Ed__91 stateMachine = default(_003CSendStartGameMessage_003Ed__91);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void SendStartGameMessage()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CSendStartGameMessage_003Ed__91 stateMachine = default(_003CSendStartGameMessage_003Ed__91);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void OnStartGameMessageSent(RequestResponse<bool> req)
	{
		if ((object)req == null)
		{
			bool applyParameters = default(bool);
			GameObject localParametersRoot = default(GameObject);
			string overrideLanguage = default(string);
			bool allowLocalizedParameters = default(bool);
			string translation = LocalizationManager.GetTranslation("onlineLang/ErrorStartGameIssueDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
			OnlineErrorManager.ShowError(OnlineErrorType.StartGame, translation);
			ChangeButtonsState(active: true);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
	}

	private unsafe NetworkType GetNetworkType()
	{
		//IL_001f: Expected O, but got Ref
		//IL_0088: Expected O, but got Ref
		//IL_00a5: Expected O, but got I
		//IL_0670: Expected O, but got Ref
		//IL_0684: Expected O, but got I
		//IL_011b: Expected I4, but got I8
		//IL_0140: Expected O, but got Ref
		//IL_0180: Expected O, but got Ref
		//IL_01e9: Expected O, but got Ref
		//IL_0206: Expected O, but got I
		//IL_0223: Expected O, but got I
		//IL_0240: Expected O, but got I
		//IL_0271: Expected O, but got Ref
		//IL_0282: Expected O, but got I4
		//IL_058c: Expected I4, but got I8
		//IL_0315: Expected O, but got I
		//IL_031e: Expected O, but got I4
		//IL_05bd: Expected O, but got I
		//IL_06ef: Expected O, but got Ref
		//IL_0703: Expected O, but got I
		//IL_05cf: Expected O, but got I4
		//IL_052d: Expected O, but got I
		//IL_0536: Unknown result type (might be due to invalid IL or missing references)
		//IL_053b: Expected O, but got Unknown
		//IL_032c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0331: Expected O, but got Unknown
		//IL_07aa: Expected I4, but got I8
		//IL_07ce: Expected O, but got Ref
		//IL_042e: Expected O, but got I4
		//IL_0437: Expected O, but got I4
		//IL_046d: Expected O, but got I4
		//IL_0476: Expected O, but got I4
		//IL_04ab: Expected O, but got I4
		//IL_04b4: Expected O, but got I4
		LobbiesManager lobbiesManager = _lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		object obj2 = default(object);
		object obj = (object)(&obj2);
		obj = activeLobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+98]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v56 @ rax_v16 (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		IReadOnlyList<LobbyPlayer> readOnlyList = default(IReadOnlyList<LobbyPlayer>);
		LobbyPlayer lobbyPlayer = readOnlyList.get_Item(0);
		LobbyPlayer lobbyPlayer2 = default(LobbyPlayer);
		string text = default(string);
		CloudAttribute? attribute = lobbyPlayer2.GetAttribute((string)(&text));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v605 @ rax_v23 (System.Nullable`1<Coherence.Cloud.CloudAttribute>)+20]");
		object obj4 = 0;
		if (attribute != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
			CloudAttribute cloudAttribute = default(CloudAttribute);
			long longValue = cloudAttribute.GetLongValue();
			long num = default(long);
			object arg = (SystemPlatformTypes)num;
			System.ParamsArray paramsArray = new System.ParamsArray(arg);
			System.ParamsArray paramsArray2 = default(System.ParamsArray);
			string message = string.FormatHelper((IFormatProvider)null, "Host Platform: {0}", (System.ParamsArray)(&paramsArray2));
			Debug.Log(message);
			LobbiesManager lobbiesManager2 = _lobbiesManager;
			LobbySession activeLobby2 = lobbiesManager2._activeLobby;
			object obj5 = (object)(&obj2);
			obj5 = activeLobby2.lobbyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+68]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+78]");
			_ = 0;
			object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+88]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+98]");
			obj6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+A8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+B8]");
			System.ParamsArray paramsArray3 = (System.ParamsArray)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+B8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+C8]");
			object obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v32 (Coherence.Cloud.LobbySession)+D8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj9 = default(object);
			object obj8 = (object)(&obj9);
			LobbyPlayer lobbyPlayer3 = (LobbyPlayer)paramsArray;
			object obj10 = 0;
			object obj11 = null;
			object obj12 = default(object);
			object obj24 = default(object);
			CloudAttribute cloudAttribute2 = default(CloudAttribute);
			object obj25 = default(object);
			System.ParamsArray paramsArray4 = default(System.ParamsArray);
			object obj26 = default(object);
			while (obj9 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj21;
				if (obj12 != null)
				{
					bool flag = obj9 == null;
					obj11 = null;
					if (flag)
					{
						goto IL_0633;
					}
					object obj13 = obj9;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r10_v12+12E]");
					if ((nint)0 >= (nint)0)
					{
						goto IL_0355;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r10_v12+B0]");
					object obj14 = 0;
					object obj15 = 0;
					while (true)
					{
						object obj16 = obj15 + obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v979 @ r8_v31+v984 @ rcx_v63*8]");
						if (0 == (nint)typeof(IEnumerator<LobbyPlayer>))
						{
							break;
						}
						obj15++;
						object obj17 = obj15;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ r10_v12+12E]");
						if ((nint)obj17 < 0)
						{
							continue;
						}
						goto IL_0355;
					}
					object obj18 = obj15 + obj15;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v979 @ r8_v31+8+v1052 @ rcx_v65*8]");
					object obj19 = (nint)0 << 4;
					object obj20 = obj19 + 312;
					obj21 = obj20 + obj13;
					goto IL_077c;
				}
				if (obj8 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
				}
				Dictionary<SystemPlatformTypes, NetworkProviders> platformToProvider = _platformToProvider;
				int num2 = _platformToProvider.FindEntry((SystemPlatformTypes)longValue);
				if (num2 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v161 @ rbx_v14 (System.Collections.Generic.Dictionary`2<VampireSurvivors.App.Scripts.Framework.Platforms.SystemPlatformTypes, VampireSurvivors.NetworkProviders>)+18]");
					object obj22 = 0;
					object obj23 = num2 + num2;
					Debug.Log("P2P Available, selecting P2P");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v186 @ rcx_v37+2C+v1173 @ rax_v51*8]");
					if ((nint)0 != 0)
					{
						return NetworkType.P2P;
					}
				}
				Debug.Log("Fallbacking to Cloud");
				goto IL_0625;
				IL_0625:
				return NetworkType.Cloud;
				IL_0633:
				throw new NullReferenceException();
				IL_077c:
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1057 @ r8_v21] (should have been resolved before IL gen)");
				CloudAttribute? attribute2 = lobbyPlayer3.GetAttribute((string)(&obj24));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1099 @ rax_v66 (System.Nullable`1<Coherence.Cloud.CloudAttribute>)+20]");
				obj4 = 0;
				if (attribute2 != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"unpckhpd xmm2,xmm2\"");
					long longValue2 = cloudAttribute2.GetLongValue();
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18997FD5C]");
					if ((nint)0 == 0)
					{
						_ = 1;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					bool flag2 = obj25 == null;
					object arg2 = "";
					if (!flag2)
					{
						arg2 = obj25;
					}
					object arg3 = (SystemPlatformTypes)num;
					paramsArray = new System.ParamsArray(arg2, arg3);
					string message2 = string.FormatHelper((IFormatProvider)null, "Player {0} Platform: {1}", (System.ParamsArray)(&paramsArray4));
					Debug.Log(message2);
					if (longValue2 == 2 || longValue2 == 3)
					{
						bool flag3 = longValue == 2;
						lobbyPlayer3 = (LobbyPlayer)paramsArray;
						obj10 = 0;
						obj7 = 0;
						paramsArray3 = paramsArray;
						if (flag3)
						{
							continue;
						}
						bool flag4 = longValue == 3;
						lobbyPlayer3 = (LobbyPlayer)paramsArray;
						obj10 = 0;
						obj7 = 0;
						paramsArray3 = paramsArray;
						if (flag4)
						{
							continue;
						}
					}
					bool flag5 = longValue2 == longValue;
					lobbyPlayer3 = (LobbyPlayer)paramsArray;
					obj10 = 0;
					obj7 = 0;
					paramsArray3 = paramsArray;
					if (flag5)
					{
						continue;
					}
					Debug.Log("Platform doesn't match, selecting Cloud");
					if (obj8 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
					goto IL_0625;
				}
				System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
				obj11 = null;
				goto IL_0633;
				IL_0355:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AC0A30");
				obj21 = obj26;
				goto IL_077c;
			}
			throw new NullReferenceException();
		}
		System.ThrowHelper.ThrowInvalidOperationException_InvalidOperation_NoValue();
		NetworkType result = default(NetworkType);
		return result;
	}

	private void CreateLobby()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CCreateLobby_003Ed__94 stateMachine = default(_003CCreateLobby_003Ed__94);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private unsafe void OnCreatedLobby()
	{
		//IL_0025: Expected O, but got Ref
		//IL_009a: Expected O, but got I
		//IL_0242: Expected I8, but got I4
		//IL_0270: Expected O, but got Ref
		//IL_02d9: Expected O, but got Ref
		//IL_02f6: Expected O, but got I
		SwitchLobbyState(activate: true);
		ChangeButtonsState(active: true);
		LobbiesManager lobbiesManager = _lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		object obj2 = default(object);
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = activeLobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+98]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v63 @ rax_v7 (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		string text = default(string);
		_lobbyIdText.text = text;
		Button componentInParent = _lobbyIdText.GetComponentInParent<Button>();
		componentInParent.m_OnClick.RemoveAllListeners();
		Button componentInParent2 = _lobbyIdText.GetComponentInParent<Button>();
		UnityAction call = delegate
		{
			//IL_001f: Expected O, but got Ref
			//IL_0088: Expected O, but got Ref
			//IL_00a5: Expected O, but got I
			LobbiesManager lobbiesManager7 = _lobbiesManager;
			LobbySession activeLobby3 = lobbiesManager7._activeLobby;
			object obj6 = default(object);
			object obj5 = (object)(&obj6);
			obj5 = activeLobby3.lobbyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+68]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+78]");
			_ = 0;
			object obj7 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj6, 128));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+88]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+98]");
			obj7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+A8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+B8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+D8]");
			_ = 0;
			string systemCopyBuffer = default(string);
			GUIUtility.systemCopyBuffer = systemCopyBuffer;
		};
		componentInParent2.m_OnClick.AddListener(call);
		UpdatePlayerNames();
		UpdateAvailableDLC();
		LobbiesManager lobbiesManager2 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer> value = OnPlayerJoined;
		lobbiesManager2._activeLobby.OnPlayerJoined -= value;
		LobbiesManager lobbiesManager3 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer> value2 = OnPlayerJoined;
		lobbiesManager3._activeLobby.OnPlayerJoined += value2;
		LobbiesManager lobbiesManager4 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer, string> value3 = new Action<object, LobbyPlayer, object>(OnPlayerLeft);
		lobbiesManager4._activeLobby.OnPlayerLeft -= value3;
		LobbiesManager lobbiesManager5 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer, string> value4 = new Action<object, LobbyPlayer, object>(OnPlayerLeft);
		lobbiesManager5._activeLobby.OnPlayerLeft += value4;
		UpdateReadyState(1L);
		LobbiesManager lobbiesManager6 = _lobbiesManager;
		LobbySession activeLobby2 = lobbiesManager6._activeLobby;
		object obj3 = (object)(&obj2);
		obj3 = activeLobby2.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+98]");
		obj4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v141 @ rax_v36 (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		OnlinePlatformSupport.OnJoinedOnlineSession(text, null);
	}

	private void OnConnectionLostWithCoherence()
	{
		PlayerAccount main = PlayerAccount.main;
		Action value = OnConnectionLostWithCoherence;
		main.services.OnConnectionLost -= value;
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("onlineLang/ErrorLostConnectionDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		OnlineErrorManager.ShowError(OnlineErrorType.Login, translation);
		ChangeButtonsState(active: true);
	}

	private unsafe void OnPlayerLeft(LobbySession lobby, LobbyPlayer player, string reason)
	{
		//IL_002f: Expected O, but got Ref
		//IL_00a4: Expected O, but got I
		UpdatePlayerNames();
		ChangeButtonsState(active: true);
		UpdateAvailableDLC();
		object obj2 = default(object);
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = lobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+98]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		if (OnlinePlatformSupport.OnlinePlatformSupportInstance == null)
		{
			OnlinePlatformSupport.Setup();
		}
		string lobbyID = default(string);
		OnlinePlatformSupport.OnlinePlatformSupportInstance.OnPlayerLeftOnlineSession(lobbyID, null);
		_startButton.Select();
	}

	private unsafe void OnPlayerJoined(LobbySession lobby, LobbyPlayer player)
	{
		//IL_002f: Expected O, but got Ref
		//IL_00a4: Expected O, but got I
		UpdatePlayerNames();
		ChangeButtonsState(active: true);
		UpdateAvailableDLC();
		object obj2 = default(object);
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		_ = lobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+98]");
		obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [lobby @ rdx (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		if (OnlinePlatformSupport.OnlinePlatformSupportInstance == null)
		{
			OnlinePlatformSupport.Setup();
		}
		string lobbyID = default(string);
		OnlinePlatformSupport.OnlinePlatformSupportInstance.OnRemotePlayerJoinedRoom(lobbyID, null);
		_startButton.Select();
	}

	private void InstantiateLobbyEntities(CoherenceClientConnectionManager _)
	{
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Info("Instantiating Lobby Entities", args);
		Scene activeScene = SceneManager.GetActiveScene();
		CoherenceSync instance = _onlineStageManagerPrefab.GetInstance(activeScene);
		Scene activeScene2 = SceneManager.GetActiveScene();
		CoherenceSync instance2 = _hostPlayerOptions.GetInstance(activeScene2);
		Scene activeScene3 = SceneManager.GetActiveScene();
		CoherenceSync instance3 = _lobbyCharacterData.GetInstance(activeScene3);
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnectionManager> value = InstantiateLobbyEntities;
		masterBridge._003CClientConnections_003Ek__BackingField.OnSynced -= value;
	}

	private void ShowOnlineLobby(CoherenceClientConnectionManager _)
	{
		//IL_000d: Expected I, but got O
		//IL_0208: Expected I, but got O
		Coherence.Log.Logger logger = _logger;
		(string, object)[] args = Array.Empty<(string, object)>();
		nint num = (nint)logger;
		logger.Info("Starting to show Online Lobby", args);
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			HostPlayerOptions hostPlayerOptions = HostPlayerOptions._003CInstance_003Ek__BackingField;
			if ((object)HostPlayerOptions._003CInstance_003Ek__BackingField != null && ((UnityEngine.Object)hostPlayerOptions).m_CachedPtr != (IntPtr)0)
			{
				nint num2 = (nint)typeof(HostPlayerOptions);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v684 @ rax_v51 (Il2CppClass<VampireSurvivors.HostPlayerOptions>)+B8]");
				nint num3 = 0;
				HostPlayerOptions hostPlayerOptions2 = HostPlayerOptions._003CInstance_003Ek__BackingField;
				if (hostPlayerOptions2._003CIsReady_003Ek__BackingField)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D466E0");
					object obj = default(object);
					if (obj != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v690 @ rax_v53+10]");
						if ((nint)0 != 0)
						{
							FireUiSignal();
							goto IL_0149;
						}
					}
				}
			}
		}
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		_003CFireUiSignalCoroutine_003Ed__101 obj2 = null;
		obj2._003C_003E1__state = 0;
		obj2._003C_003E4__this = this;
		Coroutine fireUiSignalRoutine = StartCoroutine(obj2);
		_fireUiSignalRoutine = fireUiSignalRoutine;
		goto IL_0149;
		IL_0149:
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnectionManager> value = ShowOnlineLobby;
		masterBridge._003CClientConnections_003Ek__BackingField.OnSynced -= value;
	}

	private IEnumerator FireUiSignalCoroutine()
	{
		_003CFireUiSignalCoroutine_003Ed__101 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	private void OnClientDisconnected(CoherenceClientConnection clientConn)
	{
		//IL_00ec: Expected O, but got I
		OnlineStageManager instance = OnlineStageManager._instance;
		if ((object)OnlineStageManager._instance != null && ((UnityEngine.Object)instance).m_CachedPtr != (IntPtr)0)
		{
			OnlineStageManager instance2 = OnlineStageManager._instance;
			CoherenceClientConnection coherenceClientConnection = default(CoherenceClientConnection);
			if ((nint)coherenceClientConnection._003CClientId_003Ek__BackingField != (int)instance2._firstSeat || OnlineStageManager._instance.IsHost)
			{
				return;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182B07B50");
		Action<CoherenceClientConnection> value = OnClientDisconnected;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v278 @ rax_v16+80]");
		((CoherenceClientConnectionManager)0).OnDestroyed -= value;
		if (_fireUiSignalRoutine != null)
		{
			StopCoroutine(_fireUiSignalRoutine);
			_fireUiSignalRoutine = null;
		}
		UpdateLobbyState();
	}

	private void FireUiSignal()
	{
		//IL_0107: Expected I8, but got I4
		UpdateReadyState(0L);
		ChangeButtonsState(active: true);
		LobbiesManager lobbiesManager = _lobbiesManager;
		Action<LobbySession, LobbyPlayer> value = OnPlayerJoined;
		lobbiesManager._activeLobby.OnPlayerJoined -= value;
		LobbiesManager lobbiesManager2 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer, string> value2 = new Action<object, LobbyPlayer, object>(OnPlayerLeft);
		lobbiesManager2._activeLobby.OnPlayerLeft -= value2;
		LobbiesManager lobbiesManager3 = _lobbiesManager;
		Action<LobbySession, LobbyPlayer> value3 = OnLobbyOwnerChanged;
		lobbiesManager3._activeLobby.OnLobbyOwnerChanged -= value3;
		LobbiesManager lobbiesManager4 = _lobbiesManager;
		Action<LobbySession, MessagesReceived> value4 = OnStartGameMessageReceived;
		lobbiesManager4._activeLobby.OnMessageReceived -= value4;
		RemoveConnectionListeners();
		Debug.Log("Pre ShowOnlineLobby signal");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA0490");
	}

	private unsafe void StartReplicationServerIfP2P()
	{
		//IL_009c: Expected I, but got O
		//IL_00a4: Expected I, but got O
		//IL_00b4: Expected O, but got I
		//IL_00fd: Expected O, but got I
		//IL_0501: Expected O, but got Ref
		//IL_02be: Expected I, but got O
		//IL_02d4: Expected O, but got I
		//IL_02dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e2: Expected O, but got Unknown
		//IL_0385: Expected I, but got O
		//IL_0522: Expected O, but got I4
		//IL_052b: Expected O, but got I4
		//IL_0542: Expected I, but got I8
		//IL_036e: Expected I, but got I8
		//IL_0334: Expected I, but got I8
		//IL_0400: Expected I, but got O
		//IL_0416: Expected O, but got I
		//IL_041f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0424: Expected O, but got Unknown
		//IL_048d: Expected I, but got O
		//IL_055e: Expected I, but got I8
		//IL_0476: Expected I, but got I8
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			return;
		}
		LogHandler logHandler;
		nint num5;
		if (_replicationServer == null)
		{
			ReplicationServerConfig config = GetConfig();
			INetworkProvider activeProvider = _activeProvider;
			bool flag = _activeProvider == null;
			HostAuthority hostAuthority = config.HostAuthority;
			if (!flag)
			{
				nint num = (nint)typeof(LocalNetworkProvider);
				nint num2 = (nint)activeProvider;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rdx_v29 (Il2CppClass<VampireSurvivors.LocalNetworkProvider>)+130]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ r8_v34 (Il2CppClass<VampireSurvivors.INetworkProvider>)+130]");
				nint num3 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v413 @ rdx_v29 (Il2CppClass<VampireSurvivors.LocalNetworkProvider>)+130]");
				bool flag2 = num3 < 0;
				hostAuthority = config.HostAuthority;
				if (!flag2)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v414 @ r8_v34 (Il2CppClass<VampireSurvivors.INetworkProvider>)+C8]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ rax_v96+FFFFFFF8+v415 @ rax_v95*8]");
					bool flag3 = 0 != (nint)typeof(LocalNetworkProvider);
					hostAuthority = config.HostAuthority;
					if (!flag3)
					{
						hostAuthority = (HostAuthority)config.SendFrequency;
					}
				}
			}
			Settings settings = Log.GetSettings();
			settings.LogStackTrace = true;
			Settings settings2 = Log.GetSettings();
			settings2.FileLogLevel = LogLevel.Debug;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			object obj4 = default(object);
			string additionalArguments;
			if (obj4 == null)
			{
				string consoleLogPath = Application.consoleLogPath;
				string directoryName = Path.GetDirectoryName(consoleLogPath);
				string text = Path.Combine(directoryName, "coherence-server");
				if (File.Exists(text))
				{
					File.Delete(text);
				}
				Settings settings3 = Log.GetSettings();
				settings3.LogFilePath = text;
				string text2 = "--log-file \"" + text + "\"";
				additionalArguments = text2;
			}
			else
			{
				additionalArguments = null;
			}
			object obj5 = default(object);
			IReplicationServer replicationServer = Launcher.Create((ReplicationServerConfig)(&obj5), additionalArguments);
			_replicationServer = replicationServer;
			logHandler = null;
			nint num4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v5 (Il2CppMethodInfo)+8]");
			((Delegate)logHandler).method_ptr = (IntPtr)0;
			((Delegate)logHandler).method = (nint)__ldftn(RoomSelectionPage.ReplicationServer_OnLog);
			((Delegate)logHandler).m_target = this;
			((Delegate)logHandler).method_code = (IntPtr)logHandler;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v5 (Il2CppMethodInfo)+4C]");
			object obj6 = (nint)0 >> 4;
			object obj7 = obj6 & 1;
			if (obj7 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 != 1)
				{
					goto IL_0373;
				}
				num5 = unchecked((nint)6447148272L);
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ r9_v5 (Il2CppMethodInfo)+52]");
				if ((nint)0 != 0)
				{
					goto IL_0373;
				}
				num5 = unchecked((nint)6447148224L);
			}
			goto IL_0519;
		}
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Warning("The replication server is already running", args);
		return;
		IL_0519:
		object obj8 = 24;
		object obj9 = 24;
		((Delegate)logHandler).extra_arg = unchecked((nint)6447148128L);
		_replicationServer.OnLog += logHandler;
		IReplicationServer replicationServer2 = _replicationServer;
		ExitHandler exitHandler = null;
		nint num6 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r9_v7 (Il2CppMethodInfo)+8]");
		((Delegate)exitHandler).method_ptr = (IntPtr)0;
		((Delegate)exitHandler).method = (nint)__ldftn(RoomSelectionPage.ReplicationServer_OnExit);
		((Delegate)exitHandler).m_target = this;
		((Delegate)exitHandler).method_code = (IntPtr)exitHandler;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r9_v7 (Il2CppMethodInfo)+4C]");
		object obj10 = (nint)0 >> 4;
		object obj11 = obj10 & 1;
		nint num7;
		if (obj11 != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v84 @ r9_v7 (Il2CppMethodInfo)+52]");
			if ((nint)0 == 1)
			{
				num7 = unchecked((nint)6442485696L);
				goto IL_0547;
			}
		}
		((Delegate)exitHandler).method_code = (IntPtr)((Delegate)exitHandler).m_target;
		num7 = ((Delegate)exitHandler).method_ptr;
		goto IL_0547;
		IL_0373:
		((Delegate)logHandler).method_code = (IntPtr)((Delegate)logHandler).m_target;
		num5 = ((Delegate)logHandler).method_ptr;
		goto IL_0519;
		IL_0547:
		((Delegate)exitHandler).extra_arg = unchecked((nint)6442485600L);
		_replicationServer.OnExit += exitHandler;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
	}

	private unsafe ReplicationServerConfig GetConfig()
	{
		//IL_02b0: Expected native int or pointer, but got O
		//IL_02be: Expected native int or pointer, but got O
		//IL_02ce: Expected native int or pointer, but got O
		//IL_02d8: Expected native int or pointer, but got O
		//IL_02e6: Expected native int or pointer, but got O
		//IL_01ce: Expected native int or pointer, but got O
		//IL_01dc: Expected native int or pointer, but got O
		//IL_01ec: Expected native int or pointer, but got O
		//IL_01f6: Expected native int or pointer, but got O
		//IL_0204: Expected native int or pointer, but got O
		//IL_0224: Expected native int or pointer, but got O
		//IL_0232: Expected native int or pointer, but got O
		//IL_0240: Expected native int or pointer, but got O
		//IL_024e: Expected native int or pointer, but got O
		//IL_025c: Expected native int or pointer, but got O
		//IL_027c: Expected native int or pointer, but got O
		//IL_0318: Expected native int or pointer, but got O
		//IL_0294: Expected O, but got I4
		//IL_028f: Expected native int or pointer, but got O
		//IL_029d: Expected native int or pointer, but got O
		//IL_00b4: Expected native int or pointer, but got O
		//IL_00c2: Expected native int or pointer, but got O
		//IL_00d2: Expected native int or pointer, but got O
		//IL_00dc: Expected native int or pointer, but got O
		//IL_00ea: Expected native int or pointer, but got O
		//IL_010a: Expected native int or pointer, but got O
		//IL_0118: Expected native int or pointer, but got O
		//IL_0126: Expected native int or pointer, but got O
		//IL_0134: Expected native int or pointer, but got O
		//IL_0142: Expected native int or pointer, but got O
		//IL_0162: Expected native int or pointer, but got O
		//IL_0306: Expected native int or pointer, but got O
		//IL_017a: Expected O, but got I4
		//IL_0175: Expected native int or pointer, but got O
		ReplicationServerConfig replicationServerConfig = default(ReplicationServerConfig);
		((ReplicationServerConfig*)(nint)replicationServerConfig)->UseLite = false;
		((ReplicationServerConfig*)(nint)replicationServerConfig)->SendFrequency = 0;
		_ = 0;
		System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->PersistenceStoragePath, null);
		System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->LogTargets, null);
		((ReplicationServerConfig*)(nint)replicationServerConfig)->HostAuthority = (HostAuthority)0;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		object obj = default(object);
		if (obj == null)
		{
			string consoleLogPath = Application.consoleLogPath;
			string directoryName = Path.GetDirectoryName(consoleLogPath);
			string text = Path.Combine(directoryName, "coherence-server-dbg");
			LogTargetConfig[] array = new LogTargetConfig[1];
			if (array.Length <= 0)
			{
				goto IL_02f0;
			}
			_ = 1;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->UseLite = false;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->SendFrequency = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->PersistenceStoragePath, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->LogTargets, null);
			((ReplicationServerConfig*)(nint)replicationServerConfig)->HostAuthority = (HostAuthority)0;
			RuntimeSettings instance = PreloadedSingleton<RuntimeSettings>.Instance;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->APIPort = (ushort)instance.worldsAPIPort;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->UDPPort = 32001;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->SendFrequency = 60;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->ReceiveFrequency = 20;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->DisableThrottling = true;
			RuntimeSettings instance2 = PreloadedSingleton<RuntimeSettings>.Instance;
			System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->Token, instance2.replicationServerToken);
			System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->LogTargets, array);
			((ReplicationServerConfig*)(nint)replicationServerConfig)->DisconnectTimeout = (uint?)(object)1;
		}
		else
		{
			LogTargetConfig[] array2 = new LogTargetConfig[1];
			if (array2.Length <= 0)
			{
				goto IL_02f0;
			}
			_ = 0;
			_ = 0;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->UseLite = false;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->SendFrequency = 0;
			_ = 0;
			System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->PersistenceStoragePath, null);
			System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->LogTargets, null);
			((ReplicationServerConfig*)(nint)replicationServerConfig)->HostAuthority = (HostAuthority)0;
			RuntimeSettings instance3 = PreloadedSingleton<RuntimeSettings>.Instance;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->APIPort = (ushort)instance3.worldsAPIPort;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->UDPPort = 32001;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->SendFrequency = 60;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->ReceiveFrequency = 20;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->DisableThrottling = true;
			RuntimeSettings instance4 = PreloadedSingleton<RuntimeSettings>.Instance;
			System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->Token, instance4.replicationServerToken);
			System.Runtime.CompilerServices.Unsafe.Write(&((ReplicationServerConfig*)(nint)replicationServerConfig)->LogTargets, array2);
			((ReplicationServerConfig*)(nint)replicationServerConfig)->DisconnectTimeout = (uint?)(object)1;
			((ReplicationServerConfig*)(nint)replicationServerConfig)->UseLite = true;
		}
		return replicationServerConfig;
		IL_02f0:
		return (ReplicationServerConfig)new IndexOutOfRangeException();
	}

	private void OnConnectionError(CoherenceBridge _, ConnectionException e)
	{
		//IL_0088: Expected O, but got I
		//IL_0098: Expected O, but got I
		string message = e.Message;
		(string, object)[] args = Array.Empty<(string, object)>();
		_logger.Error(message, args);
		bool applyParameters = default(bool);
		GameObject localParametersRoot = default(GameObject);
		string overrideLanguage = default(string);
		bool allowLocalizedParameters = default(bool);
		string translation = LocalizationManager.GetTranslation("onlineLang/ErrorStartGameIssueDesc", FixForRTL: true, 0, ignoreRTLnumbers: true, applyParameters, localParametersRoot, overrideLanguage, allowLocalizedParameters);
		OnlineErrorManager.ShowError(OnlineErrorType.StartGame, translation);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996AF00]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v13+B8]");
		object infoText = 0;
		ChangeUiState(activate: true, (string)infoText);
		if (_activeProvider != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		}
		StopReplicationServer();
		LeaveLobby();
	}

	private void OnDestroy()
	{
		//IL_00aa: Expected O, but got I
		//IL_00aa: Expected O, but got I
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186D98110");
		CoherenceBridge masterBridge = CoherenceBridgeStore.masterBridge;
		Action<CoherenceClientConnectionManager> value = ShowOnlineLobby;
		masterBridge._003CClientConnections_003Ek__BackingField.OnSynced -= value;
		CoherenceBridge masterBridge2 = CoherenceBridgeStore.masterBridge;
		UnityEvent<CoherenceBridge, ConnectionException> onConnectionError = masterBridge2.onConnectionError;
		UnityAction<CoherenceBridge, ConnectionException> unityAction = OnConnectionError;
		MethodInfo methodImpl = ((MulticastDelegate)unityAction).GetMethodImpl();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rdi_v3 (UnityEngine.Events.UnityEvent`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+10]");
		nint num = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v284 @ rax_v18 (UnityEngine.Events.UnityAction`2<Coherence.Toolkit.CoherenceBridge, Coherence.Connection.ConnectionException>)+20]");
		((UnityEngine.Events.InvokableCallList)num).RemoveListener(0, methodImpl);
	}

	public void UpdateActiveProvider()
	{
		if (_activeProvider != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
	}

	protected override void Update()
	{
		base.Update();
		if (_activeProvider != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
		}
		_OnlineDLCSection.UpdateDlcInfoPanel();
		LobbiesManager lobbiesManager = _lobbiesManager;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			if (!activeLobby._003CIsDisposed_003Ek__BackingField && (nint)activeLobby.lobbyOwnerSession > 0)
			{
				bool active = !_isStartingGame;
				UpdateStartButtonState(active);
			}
		}
	}

	private void ShutDown()
	{
		if (_activeProvider != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		}
		StopReplicationServer();
		LeaveLobby();
	}

	private void LeaveLobby()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CLeaveLobby_003Ed__111 stateMachine = default(_003CLeaveLobby_003Ed__111);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private unsafe void OnApplicationQuit()
	{
		//IL_004c: Expected O, but got Ref
		//IL_00c1: Expected O, but got I
		LobbiesManager lobbiesManager = _lobbiesManager;
		if (lobbiesManager._activeLobby != null)
		{
			LobbySession activeLobby = lobbiesManager._activeLobby;
			object obj2 = default(object);
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
			_ = activeLobby.lobbyData;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+38]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+48]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+58]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+68]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+78]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+88]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+98]");
			obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+A8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+B8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+C8]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v33 @ rax_v10 (Coherence.Cloud.LobbySession)+D8]");
			_ = 0;
			string lobbyID = default(string);
			OnlinePlatformSupport.OnEndOnlineSession(lobbyID, null);
		}
		if (_activeProvider != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		}
		StopReplicationServer();
		LeaveLobby();
	}

	private void StopReplicationServer()
	{
		if (_replicationServer != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800061F0");
			_replicationServer = null;
		}
	}

	private void ReplicationServer_OnLog(string log)
	{
		string message = "RS: " + log;
		Debug.Log(message);
	}

	private unsafe void ReplicationServer_OnExit(int code)
	{
		//IL_0046: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_box\"");
		object arg = default(object);
		System.ParamsArray paramsArray = new System.ParamsArray(arg);
		object obj = default(object);
		string message = string.FormatHelper((IFormatProvider)null, "Replication server exited with code {0}.", (System.ParamsArray)(&obj));
		Debug.Log(message);
		_replicationServer = null;
	}

	public void GoBackOnline()
	{
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		Debug.Log("GoBackOnline");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B0AC10");
		object obj2 = default(object);
		object obj = obj2 + 32;
		Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_reflection_get_type_object\"");
		Type signalType = default(Type);
		bool requireDeclaration = default(bool);
		_signalBus.InternalFire(signalType, (object)null, (object)null, requireDeclaration);
		Action b = GoBackOnline;
		BackButtonController.TryRemoveListener(b);
		BackButtonController.IgnoreNextAdditionalListner = false;
	}

	public void ShowBestiary()
	{
		Action b = GoBackOnline;
		BackButtonController.AddListener(b);
		BackButtonController.IgnoreNextAdditionalListner = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FCE0");
	}

	public void ShowOptions()
	{
		Action b = GoBackOnline;
		BackButtonController.AddListener(b);
		BackButtonController.IgnoreNextAdditionalListner = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FAD0");
	}

	public void ShowPowerUps()
	{
		Action b = GoBackOnline;
		BackButtonController.AddListener(b);
		BackButtonController.IgnoreNextAdditionalListner = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FB80");
	}

	public void ShowAchievements()
	{
		Action b = GoBackOnline;
		BackButtonController.AddListener(b);
		BackButtonController.IgnoreNextAdditionalListner = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9F970");
	}

	public void ShowCollections()
	{
		Action b = GoBackOnline;
		BackButtonController.AddListener(b);
		BackButtonController.IgnoreNextAdditionalListner = true;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FA20");
	}

	public unsafe void ShowAdventuresView()
	{
		//IL_007d: Expected O, but got I4
		//IL_007d: Expected I8, but got I4
		//IL_0038: Expected O, but got Ref
		LobbiesManager lobbiesManager = _lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		List<CloudAttribute> list = new List<CloudAttribute>();
		CloudAttribute cloudAttribute = new CloudAttribute(LobbyAttributeKeys.IsGameStarted, 1L, (bool?)(object)257);
		object obj = default(object);
		list.Add((CloudAttribute)(&obj));
		activeLobby.lobbyOwnerSession.AddOrUpdateLobbyAttributes(list, null);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9FD90");
	}

	private unsafe void ChangeLobbyOpenState(bool open)
	{
		//IL_0073: Expected I8, but got I4
		//IL_008a: Expected O, but got I4
		//IL_003d: Expected O, but got Ref
		LobbiesManager lobbiesManager = _lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		List<CloudAttribute> list = null;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180003990");
		long value = (open ? 1 : 0) ^ 1;
		CloudAttribute cloudAttribute = new CloudAttribute(LobbyAttributeKeys.IsGameStarted, value, (bool?)(object)257);
		object obj = default(object);
		list.Add((CloudAttribute)(&obj));
		activeLobby.lobbyOwnerSession.AddOrUpdateLobbyAttributes(list, null);
	}

	public RoomSelectionPage()
	{
		List<DlcType> availableDLCs = new List<DlcType>();
		_AvailableDLCs = availableDLCs;
		base._002Ector();
	}

	static RoomSelectionPage()
	{
		Dictionary<SystemPlatformTypes, NetworkProviders> dictionary = new Dictionary<SystemPlatformTypes, NetworkProviders>();
		bool flag = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)dictionary).TryInsert((System.Int32Enum)5, (System.Int32Enum)2, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag2 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)dictionary).TryInsert((System.Int32Enum)6, (System.Int32Enum)3, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag3 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)dictionary).TryInsert((System.Int32Enum)8, (System.Int32Enum)5, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		bool flag4 = ((Dictionary<System.Int32Enum, System.Int32Enum>)(object)dictionary).TryInsert((System.Int32Enum)7, (System.Int32Enum)1, System.Collections.Generic.InsertionBehavior.ThrowOnExisting);
		_platformToProvider = dictionary;
		hasOnEnablerunOnce = false;
	}

	private void _003CCreateRoom_003Eb__52_0(bool hasInternetConnection)
	{
		//IL_001f: Expected I4, but got O
		if (!hasInternetConnection)
		{
			ShowConnectionLostPopup();
			return;
		}
		Action<bool> action = null;
		((RoomSelectionPage)(object)action).OnLoggedInWithCoherenceAfterCreate((byte)(int)this != 0);
		CoherenceLoginModule.Login(action);
	}

	private void _003CJoinRoom_003Eb__56_0(bool hasInternetConnection)
	{
		//IL_00ff: Expected I4, but got O
		if (!hasInternetConnection)
		{
			ShowConnectionLostPopup();
			return;
		}
		_003C_003Ec__DisplayClass56_0 obj = new _003C_003Ec__DisplayClass56_0();
		obj._003C_003E4__this = this;
		LabeledInputUI lobbyIdInput = _lobbyIdInput;
		TMP_InputField input = lobbyIdInput._Input;
		string text = input.m_Text;
		if (input.m_Text != null && text._stringLength > 0)
		{
			LabeledInputUI lobbyIdInput2 = _lobbyIdInput;
			TMP_InputField input2 = lobbyIdInput2._Input;
			string lobbyTag = input2.m_Text.ToUpperInvariant();
			obj.lobbyTag = lobbyTag;
			ChangeButtonsState(active: false);
			Action<bool> action = null;
			((_003C_003Ec__DisplayClass56_0)(object)action)._003CJoinRoom_003Eb__1((byte)(int)obj != 0);
			CoherenceLoginModule.Login(action);
		}
	}

	private void _003CJoinLobby_003Eb__61_0()
	{
		ChangeButtonsState(active: true);
		_joinButton.Select();
	}

	private unsafe void _003COnCreatedLobby_003Eb__95_0()
	{
		//IL_001f: Expected O, but got Ref
		//IL_0088: Expected O, but got Ref
		//IL_00a5: Expected O, but got I
		LobbiesManager lobbiesManager = _lobbiesManager;
		LobbySession activeLobby = lobbiesManager._activeLobby;
		object obj2 = default(object);
		object obj = (object)(&obj2);
		obj = activeLobby.lobbyData;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+28]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+38]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+48]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+58]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+68]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+78]");
		_ = 0;
		object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 128));
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+88]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+98]");
		obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+A8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+B8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+C8]");
		_ = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v41 @ rax_v5 (Coherence.Cloud.LobbySession)+D8]");
		_ = 0;
		string systemCopyBuffer = default(string);
		GUIUtility.systemCopyBuffer = systemCopyBuffer;
	}
}
