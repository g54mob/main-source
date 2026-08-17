using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Coherence.Cloud;
using Cpp2ILInjected;
using UnityEngine;

namespace VampireSurvivors;

public static class CoherenceLoginModule
{
	private sealed class _003C_003Ec__DisplayClass0_0
	{
		public Action<bool> onComplete;

		internal void _003CLogin_003Eb__0(LoginOperation loginOp)
		{
			OnCompleteLogin(loginOp, onComplete);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CLeaveExistingLobbies_003Ed__2 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public LoginOperation loginResponse;

		private IEnumerator<string> _003C_003E7__wrap1;

		private TaskAwaiter<LobbySession> _003C_003Eu__1;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_088d: Expected O, but got Ref
			//IL_013f: Expected O, but got I4
			//IL_013a: Expected native int or pointer, but got O
			//IL_0151: Expected I4, but got I8
			//IL_014c: Expected native int or pointer, but got O
			//IL_015e: Expected O, but got I8
			//IL_0163: Expected I, but got O
			//IL_0196: Expected O, but got I4
			//IL_0191: Expected native int or pointer, but got O
			//IL_01a8: Expected I4, but got I8
			//IL_01a3: Expected native int or pointer, but got O
			//IL_01b5: Expected O, but got I8
			//IL_0733: Expected O, but got Ref
			//IL_07b5: Expected I4, but got I8
			//IL_022e: Expected O, but got I4
			//IL_07c5: Expected O, but got Ref
			//IL_0977: Expected native int or pointer, but got O
			//IL_0765: Expected O, but got Ref
			//IL_05d2: Expected O, but got I
			//IL_0089: Expected O, but got Ref
			//IL_00a5: Expected O, but got Ref
			//IL_04d2: Expected O, but got I
			//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
			//IL_00cf: Expected O, but got Unknown
			//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
			//IL_00eb: Expected O, but got Unknown
			//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fd: Expected O, but got Unknown
			//IL_0106: Unknown result type (might be due to invalid IL or missing references)
			//IL_010b: Expected O, but got Unknown
			//IL_098f: Expected O, but got I4
			//IL_099f: Unknown result type (might be due to invalid IL or missing references)
			//IL_09a4: Expected O, but got Unknown
			//IL_02a7: Expected O, but got I
			//IL_0515: Expected O, but got I
			//IL_054d: Expected O, but got I4
			//IL_0555: Unknown result type (might be due to invalid IL or missing references)
			//IL_055a: Expected O, but got Unknown
			//IL_05e0: Expected native int or pointer, but got O
			//IL_05ed: Expected native int or pointer, but got O
			//IL_034b: Expected O, but got I
			//IL_0925: Unknown result type (might be due to invalid IL or missing references)
			//IL_092a: Expected O, but got Unknown
			//IL_039d: Expected I, but got O
			//IL_0615: Expected O, but got Ref
			//IL_0647: Expected O, but got Ref
			//IL_03fb: Expected O, but got I4
			//IL_0403: Unknown result type (might be due to invalid IL or missing references)
			//IL_0408: Expected O, but got Unknown
			//IL_041e: Expected I, but got O
			//IL_06a2: Expected native int or pointer, but got O
			//IL_06af: Expected native int or pointer, but got O
			//IL_06bd: Unknown result type (might be due to invalid IL or missing references)
			//IL_06c2: Expected O, but got Unknown
			//IL_094d: Expected O, but got Ref
			//IL_06d9: Expected O, but got Ref
			bool flag = _003C_003E1__state <= 1;
			_003CLeaveExistingLobbies_003Ed__2 obj = (_003CLeaveExistingLobbies_003Ed__2)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			if (!flag)
			{
				if (loginResponse == null)
				{
					throw new NullReferenceException();
				}
				IReadOnlyList<string> lobbyIds = loginResponse.LobbyIds;
				if (lobbyIds == null)
				{
					goto IL_07a6;
				}
				IReadOnlyList<string> lobbyIds2 = loginResponse.LobbyIds;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				IEnumerator<string> enumerator = default(IEnumerator<string>);
				_003C_003E7__wrap1 = enumerator;
				object obj2 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 40));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18996C9E0]");
				bool flag2 = (nint)0 == 0;
				obj = (_003CLeaveExistingLobbies_003Ed__2)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				if (!flag2)
				{
					object obj3 = obj2 >> 12;
					object obj4 = obj3 & 0x1FFFFF;
					object obj5 = obj4 >> 6;
					object obj6 = obj5 * 8;
					object obj7 = 6603577472L + obj6;
					object obj8 = obj4 & 0x3F;
					nint num2;
					do
					{
						object obj9 = 1 << (int)obj8;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v51+462E0]");
						obj = (_003CLeaveExistingLobbies_003Ed__2)(0 | obj9);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v51+462E0]");
						nint num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v51+462E0]");
						if (num == 0)
						{
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v51+462E0]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v136 @ rdx_v51+462E0]");
					}
					while (num2 != 0);
				}
			}
			object obj10 = default(object);
			Task task;
			_003CLeaveExistingLobbies_003Ed__2 obj11 = default(_003CLeaveExistingLobbies_003Ed__2);
			if (obj10 == null)
			{
				task = (Task)obj11._003C_003Eu__1;
				System.Runtime.CompilerServices.Unsafe.Write(&((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003Eu__1, (TaskAwaiter<LobbySession>)0);
				((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003E1__state = -1;
				obj10 = 4294967295L;
				nint num3 = unchecked((nint)null);
				goto IL_042c;
			}
			if ((nint)obj10 != 1)
			{
				goto IL_01c8;
			}
			System.Runtime.CompilerServices.Unsafe.Write(&((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003Eu__2, (TaskAwaiter<bool>)0);
			((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003E1__state = -1;
			obj10 = 4294967295L;
			Task task2 = (Task)obj11._003C_003Eu__2;
			goto IL_0571;
			IL_042c:
			if (task != null)
			{
				int num4 = task.m_stateFlags & 0x11000000;
				if (num4 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v3 (System.Threading.Tasks.Task)+50]");
				bool flag3 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v3 (System.Threading.Tasks.Task)+50]");
				nint num3 = 0;
				if (!flag3)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v340 @ rbx_v3 (System.Threading.Tasks.Task)+50]");
					Task<bool> task3 = ((LobbySession)0).LeaveLobbyAsync();
					if (task3 == null)
					{
						throw new NullReferenceException();
					}
					if (task3 != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1381 @ rax_v22 (System.Threading.Tasks.Task`1<System.Boolean>)+38]");
						object obj12 = (nint)0 & (nint)0x1600000;
						bool flag4 = obj12 == null;
						bool flag5 = (nint)obj12 < 0;
						bool flag6 = !flag5;
						object obj13 = !flag6;
						object obj14 = obj13 | flag4;
						task2 = task3;
						if (obj14 == null)
						{
							goto IL_0571;
						}
						((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003E1__state = 1;
						System.Runtime.CompilerServices.Unsafe.Write(&((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003Eu__2, (TaskAwaiter<bool>)task3);
						AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)(obj11 + 8);
						Task<bool> awaiter = default(Task<bool>);
						((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref *(TaskAwaiter<bool>*)(&awaiter), ref *(_003CLeaveExistingLobbies_003Ed__2*)obj11);
						object obj15 = (object)(&obj10);
						if ((nint)obj15 < 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
							object obj16 = (object)(&obj10);
							object obj17 = obj16;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1578 @ rax_v33+28]");
							if ((nint)0 != 0)
							{
								Type typeFromHandle = typeof(IDisposable);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1578 @ rax_v33+28]");
								((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)null)->AwaitUnsafeOnCompleted(ref *(TaskAwaiter<bool>*)typeFromHandle, ref *(_003CLeaveExistingLobbies_003Ed__2*)null);
							}
						}
						return;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_01c8:
			if (obj11._003C_003E7__wrap1 != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
				object obj18 = default(object);
				if (obj18 != null)
				{
					bool flag7 = obj11._003C_003E7__wrap1 == null;
					obj = (_003CLeaveExistingLobbies_003Ed__2)0;
					if (!flag7)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						if (obj11.loginResponse != null)
						{
							object result = ((CloudOperation<object, object>)(object)obj11.loginResponse).Result;
							if (result != null)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ rax_v73 (System.Object)+28]");
								object obj19 = 0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1238 @ rax_v73 (System.Object)+28]");
								if ((nint)0 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ rax_v74+20]");
									nint num3 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1020 @ rax_v74+20]");
									if ((nint)0 != 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1128 @ rcx_v64 (Il2CppClass<System.Threading.Tasks.Task>)+30]");
										bool flag8 = (nint)0 == 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1128 @ rcx_v64 (Il2CppClass<System.Threading.Tasks.Task>)+30]");
										num3 = 0;
										if (!flag8)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1128 @ rcx_v64 (Il2CppClass<System.Threading.Tasks.Task>)+30]");
											string lobbyId = default(string);
											Task<LobbySession> activeLobbySessionForLobbyId = ((LobbiesService)0).GetActiveLobbySessionForLobbyId(lobbyId);
											bool flag9 = activeLobbySessionForLobbyId == null;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1128 @ rcx_v64 (Il2CppClass<System.Threading.Tasks.Task>)+30]");
											num3 = 0;
											if (!flag9)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
												TaskAwaiter<LobbySession> taskAwaiter = default(TaskAwaiter<LobbySession>);
												bool flag10 = (object)taskAwaiter == null;
												num3 = (nint)activeLobbySessionForLobbyId;
												if (!flag10)
												{
													int num5 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
													bool flag11 = num5 == 0;
													bool flag12 = num5 < 0;
													bool flag13 = !flag12;
													object obj20 = !flag13;
													object obj21 = obj20 | flag11;
													task = (Task)taskAwaiter;
													num3 = (nint)typeof(Task);
													if (obj21 == null)
													{
														goto IL_042c;
													}
													((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003E1__state = 0;
													System.Runtime.CompilerServices.Unsafe.Write(&((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003Eu__1, taskAwaiter);
													AsyncTaskMethodBuilder asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder)(obj11 + 8);
													TaskAwaiter<LobbySession> awaiter2 = default(TaskAwaiter<LobbySession>);
													((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter2, ref *(_003CLeaveExistingLobbies_003Ed__2*)obj11);
													object obj22 = (object)(&obj10);
													if ((nint)obj22 < 0)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
														object obj23 = (object)(&obj10);
														object obj24 = obj23;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1633 @ rax_v86+28]");
														if ((nint)0 != 0)
														{
															Type typeFromHandle2 = typeof(IDisposable);
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1633 @ rax_v86+28]");
															((AsyncTaskMethodBuilder*)null)->AwaitUnsafeOnCompleted(ref *(TaskAwaiter<LobbySession>*)typeFromHandle2, ref *(_003CLeaveExistingLobbies_003Ed__2*)null);
														}
													}
													return;
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
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				object obj25 = (object)(&obj10);
				if ((nint)obj25 < 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"psrldq xmm0,8\"");
					object obj26 = (object)(&obj10);
					object obj27 = obj26;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1078 @ rax_v69+28]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180004820");
					}
				}
				System.Runtime.CompilerServices.Unsafe.Write(&((_003CLeaveExistingLobbies_003Ed__2*)(nint)obj11)->_003C_003E7__wrap1, null);
				goto IL_07a6;
			}
			throw new NullReferenceException();
			IL_07a6:
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder3)->SetResult();
			return;
			IL_0571:
			if (task2 != null)
			{
				int num6 = task2.m_stateFlags & 0x11000000;
				if (num6 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
				}
				obj = (_003CLeaveExistingLobbies_003Ed__2)0;
				goto IL_01c8;
			}
			throw new NullReferenceException();
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		private unsafe void SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//IL_0010: Expected O, but got Ref
			AsyncTaskMethodBuilder asyncTaskMethodBuilder = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder)->SetStateMachine(stateMachine);
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003COnCompleteLogin_003Ed__1 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public LoginOperation loginOperation;

		public Action<bool> onComplete;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_030c: Expected I4, but got I8
			//IL_0317: Expected O, but got Ref
			//IL_0116: Expected O, but got I4
			//IL_011e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0123: Expected O, but got Unknown
			//IL_01cf: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
				goto IL_0139;
			}
			if (loginOperation != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1540");
				object obj = default(object);
				if (obj == null)
				{
					Debug.Log("<CoherenceLoginModule.OnCompleteLogin> login to coherence succeeded");
					AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
					_003CLeaveExistingLobbies_003Ed__2 stateMachine = default(_003CLeaveExistingLobbies_003Ed__2);
					asyncTaskMethodBuilder.Start(ref stateMachine);
					Task<System.Threading.Tasks.VoidTaskResult> task2 = ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
					TaskAwaiter awaiter = ((Task)task2).GetAwaiter();
					int num = ((Task)awaiter).m_stateFlags & 0x1600000;
					bool flag = num == 0;
					bool flag2 = num < 0;
					bool flag3 = !flag2;
					object obj2 = !flag3;
					object obj3 = obj2 | flag;
					task = (Task)awaiter;
					if (obj3 == null)
					{
						goto IL_0139;
					}
					_003C_003E1__state = 0;
					_003C_003Eu__1 = awaiter;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter2 = default(TaskAwaiter);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					return;
				}
			}
			bool flag4 = loginOperation == null;
			string text = null;
			if (!flag4)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AA1540");
				object obj4 = default(object);
				bool flag5 = obj4 == null;
				text = null;
				if (!flag5)
				{
					object obj5 = obj4;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v374 @ rdx_v16+168] (should have been resolved before IL gen)");
					string text2 = default(string);
					text = text2;
				}
			}
			string message = "Failed to login with coherence: " + text;
			Debug.LogError(message);
			Action<bool> action = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v445 @ rcx_v19 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
			goto IL_02fd;
			IL_0139:
			int num2 = task.m_stateFlags & 0x11000000;
			if (num2 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Action<bool> action2 = onComplete;
			if (onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v239 @ rcx_v9 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
			goto IL_02fd;
			IL_02fd:
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

	public static void Login(Action<bool> onComplete)
	{
		_003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass0_0();
		CS_0024_003C_003E8__locals4.onComplete = onComplete;
		if ((object)PlayerAccount.main != null && !PlayerAccount.main.Equals(null))
		{
			Action<bool> onComplete2 = CS_0024_003C_003E8__locals4.onComplete;
			if (CS_0024_003C_003E8__locals4.onComplete != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v321 @ rax_v19 (System.Action`1<System.Boolean>)+18] (should have been resolved before IL gen)");
			}
		}
		else
		{
			SystemPlatform sInstance = SystemPlatform.sInstance;
			Action<LoginOperation> coherenceLoginOperation = delegate(LoginOperation loginOp)
			{
				OnCompleteLogin(loginOp, CS_0024_003C_003E8__locals4.onComplete);
			};
			sInstance.m_CurrentSystem.LoginWithCoherence(coherenceLoginOperation);
		}
	}

	private static void OnCompleteLogin(LoginOperation loginOperation, Action<bool> onComplete)
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003COnCompleteLogin_003Ed__1 stateMachine = default(_003COnCompleteLogin_003Ed__1);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private unsafe static Task LeaveExistingLobbies(LoginOperation loginResponse)
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CLeaveExistingLobbies_003Ed__2 stateMachine = default(_003CLeaveExistingLobbies_003Ed__2);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}
}
