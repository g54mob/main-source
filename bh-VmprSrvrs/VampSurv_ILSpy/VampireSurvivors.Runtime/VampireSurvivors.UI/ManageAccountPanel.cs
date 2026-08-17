using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.Framework.Saves;

namespace VampireSurvivors.UI;

public class ManageAccountPanel : BaseAccountPagePanel
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__11_0;

		public static Action _003C_003E9__14_4;

		public static Action _003C_003E9__15_1;

		public static Action _003C_003E9__17_1;

		public static Action _003C_003E9__17_3;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CAddAccountAndEnvInfo_003Eb__11_0()
		{
			string accountId = BackendFacade.GetAccountId();
			GUIUtility.systemCopyBuffer = accountId;
		}

		internal void _003CShowAlreadyLinkedPopup_003Eb__14_4()
		{
		}

		internal void _003CShowSaveDataConflictChoicePopup_003Eb__15_1()
		{
		}

		internal void _003CHandleUnlink_003Eb__17_1()
		{
		}

		internal void _003CHandleUnlink_003Eb__17_3()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass14_0
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public bool confirm;

			public _003C_003Ec__DisplayClass14_0 _003C_003E4__this;

			private TaskAwaiter<ForceLinkResponse> _003C_003Eu__1;

			private TaskAwaiter<int> _003C_003Eu__2;

			private TaskAwaiter _003C_003Eu__3;

			private unsafe void MoveNext()
			{
				//IL_0039: Expected O, but got I8
				//IL_008e: Expected O, but got Ref
				//IL_0070: Expected O, but got I8
				//IL_1678: Expected I4, but got I8
				//IL_1683: Expected O, but got Ref
				//IL_00e7: Expected O, but got I4
				//IL_0103: Expected O, but got I4
				//IL_011e: Expected O, but got I4
				//IL_01a5: Expected O, but got Ref
				//IL_022b: Expected O, but got I4
				//IL_0233: Unknown result type (might be due to invalid IL or missing references)
				//IL_0238: Expected O, but got Unknown
				//IL_13bb: Expected O, but got Ref
				//IL_0263: Expected I, but got O
				//IL_13e5: Expected O, but got I4
				//IL_02c4: Expected O, but got I
				//IL_0376: Expected I, but got O
				//IL_0384: Expected I, but got O
				//IL_0394: Expected O, but got I
				//IL_0415: Expected O, but got I4
				//IL_1707: Expected O, but got I4
				//IL_03d1: Expected O, but got I
				//IL_10ac: Expected I4, but got O
				//IL_10ac: Expected O, but got I4
				//IL_042a: Expected O, but got I
				//IL_0407: Expected O, but got I4
				//IL_043d: Expected I, but got O
				//IL_044d: Expected O, but got I
				//IL_04cd: Expected O, but got I4
				//IL_0489: Expected O, but got I
				//IL_1147: Expected O, but got I4
				//IL_114f: Unknown result type (might be due to invalid IL or missing references)
				//IL_1154: Expected O, but got Unknown
				//IL_04e2: Expected O, but got I
				//IL_04bf: Expected O, but got I4
				//IL_1366: Expected O, but got Ref
				//IL_138c: Expected I, but got O
				//IL_0538: Expected O, but got I4
				//IL_05d8: Expected O, but got I4
				//IL_05e0: Unknown result type (might be due to invalid IL or missing references)
				//IL_05e5: Expected O, but got Unknown
				//IL_101a: Expected O, but got Ref
				//IL_104c: Expected O, but got I4
				//IL_0618: Expected I, but got O
				//IL_1275: Expected O, but got I
				//IL_131f: Expected O, but got I4
				//IL_1328: Expected O, but got I4
				//IL_1341: Expected O, but got I4
				//IL_1856: Expected O, but got I4
				//IL_06c6: Expected O, but got I4
				//IL_0c8c: Expected I4, but got O
				//IL_0c8c: Expected O, but got I4
				//IL_0d37: Expected O, but got I4
				//IL_0d3f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0d44: Expected O, but got Unknown
				//IL_0fc2: Expected O, but got Ref
				//IL_0ff0: Expected I, but got O
				//IL_0d77: Expected I, but got O
				//IL_0db5: Expected I, but got O
				//IL_0e03: Expected O, but got I4
				//IL_0e36: Expected I, but got O
				//IL_07be: Expected O, but got I4
				//IL_07c6: Unknown result type (might be due to invalid IL or missing references)
				//IL_07cb: Expected O, but got Unknown
				//IL_0be8: Expected O, but got Ref
				//IL_0e69: Expected I, but got O
				//IL_0c16: Expected I, but got O
				//IL_07fe: Expected I, but got O
				//IL_0eb8: Expected I, but got O
				//IL_0ef3: Expected I, but got O
				//IL_08b1: Expected I4, but got O
				//IL_08b1: Expected O, but got I4
				//IL_0f9d: Expected O, but got I4
				//IL_0b5b: Expected O, but got I4
				//IL_0f55: Unknown result type (might be due to invalid IL or missing references)
				//IL_0f5a: Expected I, but got Unknown
				//IL_095c: Expected O, but got I4
				//IL_0964: Unknown result type (might be due to invalid IL or missing references)
				//IL_0969: Expected O, but got Unknown
				//IL_0b90: Expected O, but got Ref
				//IL_0bbe: Expected I, but got O
				//IL_0a0e: Expected O, but got I4
				//IL_0b3c: Expected O, but got I4
				if (_003C_003E1__state > 5 && !confirm)
				{
					goto IL_1669;
				}
				object obj = 6442450944L;
				object obj2 = default(object);
				if ((nint)obj2 <= 5)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v95 @ r15_v4+76200CC+v86 @ stack_18_v4*4]");
					object obj3 = 0 + 6442450944L;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v113 @ rax_v342 (should have been resolved before IL gen)");
				}
				Task CS_0024_003C_003E8__locals57 = default(Task);
				bool flag = CS_0024_003C_003E8__locals57 == null;
				_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed obj4 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				object obj8;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
				if (!flag)
				{
					string accountTranslation = AccountPage.GetAccountTranslation("manage_account_merge_check_loading");
					bool flag2 = CS_0024_003C_003E8__locals57.m_taskId == 0;
					obj4 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)"manage_account_merge_check_loading";
					if (!flag2)
					{
						((BaseAccountPagePanel)CS_0024_003C_003E8__locals57.m_taskId).ShowLoading(accountTranslation);
						bool flag3 = CS_0024_003C_003E8__locals57 == null;
						obj4 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)CS_0024_003C_003E8__locals57.m_taskId;
						if (!flag3)
						{
							obj4 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)CS_0024_003C_003E8__locals57.m_taskId;
							if (CS_0024_003C_003E8__locals57.m_taskId != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ rcx_v5 (VampireSurvivors.UI.ManageAccountPanel+<>c__DisplayClass14_0+<<ShowAlreadyLinkedPopup>b__0>d)+20]");
								if ((nint)0 != 0)
								{
									AsyncTaskMethodBuilder<object> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<object>);
									AccountLinkService._003CPrepareForForceLink_003Ed__0 stateMachine = default(AccountLinkService._003CPrepareForForceLink_003Ed__0);
									asyncTaskMethodBuilder.Start(ref stateMachine);
									Task<object> task = asyncTaskMethodBuilder.Task;
									bool flag4 = task == null;
									obj4 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)(&asyncTaskMethodBuilder);
									if (!flag4)
									{
										((AsyncTaskMethodBuilder<ForceLinkResponse>*)task)->Start(ref *(AccountLinkService._003CPrepareForForceLink_003Ed__0*)null);
										TaskAwaiter<ForceLinkResponse> taskAwaiter = default(TaskAwaiter<ForceLinkResponse>);
										if ((object)taskAwaiter != null)
										{
											int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
											bool flag5 = num == 0;
											bool flag6 = num < 0;
											bool flag7 = !flag6;
											object obj5 = !flag7;
											object obj6 = obj5 | flag5;
											if (obj6 == null)
											{
												bool flag8 = (object)taskAwaiter == null;
												nint num2 = (nint)typeof(Task);
												if (!flag8)
												{
													int num3 = ((Task)taskAwaiter).m_stateFlags & 0x11000000;
													if (num3 != 16777216)
													{
														TaskAwaiter.HandleNonSuccessAndDebuggerNotification((Task)taskAwaiter);
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v41 (System.Runtime.CompilerServices.TaskAwaiter`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkResponse>)+50]");
													ForceLinkConflictResponse forceLinkConflictResponse = (ForceLinkConflictResponse)0;
													bool flag9 = CS_0024_003C_003E8__locals57 == null;
													num2 = 0;
													if (!flag9)
													{
														num2 = CS_0024_003C_003E8__locals57.m_taskId;
														if (CS_0024_003C_003E8__locals57.m_taskId != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1155 @ rcx_v33 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
															if ((nint)0 != 0)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
																if ((nint)0 == 0)
																{
																	_ = 1;
																}
																PopupManager.ClosePopup("account-loading");
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v41 (System.Runtime.CompilerServices.TaskAwaiter`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkResponse>)+50]");
																if ((nint)0 == 0)
																{
																	goto IL_1056;
																}
																nint num4 = (nint)forceLinkConflictResponse;
																nint num5 = (nint)typeof(ForceLinkErrorResponse);
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1415 @ rdx_v55 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkErrorResponse>)+130]");
																string text = (string)0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1414 @ r8_v47 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkConflictResponse>)+130]");
																nint num6 = 0;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1415 @ rdx_v55 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkErrorResponse>)+130]");
																if (num6 >= 0)
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1414 @ r8_v47 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkConflictResponse>)+C8]");
																	object obj7 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1473 @ rax_v316+FFFFFFF8+v1416 @ rax_v123 (System.String)*8]");
																	if (0 == (nint)typeof(ForceLinkErrorResponse))
																	{
																		obj8 = 1;
																		goto IL_16ef;
																	}
																}
																obj8 = 0;
																goto IL_16ef;
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											_003C_003E1__state = 0;
											_003C_003Eu__1 = taskAwaiter;
											AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
											TaskAwaiter<ForceLinkResponse> awaiter = default(TaskAwaiter<ForceLinkResponse>);
											((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
											asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
											obj4 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)0;
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
				IL_16ef:
				bool flag10 = obj8 == null;
				_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed obj9 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)0;
				if (!flag10)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v41 (System.Runtime.CompilerServices.TaskAwaiter`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkResponse>)+50]");
					obj9 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)0;
				}
				object obj11;
				if ((object)obj9 == null)
				{
					nint num7 = (nint)typeof(ForceLinkConflictResponse);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1622 @ rdx_v59 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkConflictResponse>)+130]");
					string text2 = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1414 @ r8_v47 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkConflictResponse>)+130]");
					nint num8 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1622 @ rdx_v59 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkConflictResponse>)+130]");
					if (num8 >= 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1414 @ r8_v47 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkConflictResponse>)+C8]");
						object obj10 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1731 @ rax_v312+FFFFFFF8+v1623 @ rax_v132 (System.String)*8]");
						if (0 == (nint)typeof(ForceLinkConflictResponse))
						{
							obj11 = 1;
							goto IL_1715;
						}
					}
					obj11 = 0;
					goto IL_1715;
				}
				throw new NullReferenceException();
				IL_1715:
				bool flag11 = obj11 == null;
				ForceLinkConflictResponse forceLinkConflictResponse2 = null;
				if (!flag11)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v968 @ rax_v41 (System.Runtime.CompilerServices.TaskAwaiter`1<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service.ForceLinkResponse>)+50]");
					forceLinkConflictResponse2 = (ForceLinkConflictResponse)0;
				}
				if (forceLinkConflictResponse2 == null)
				{
					goto IL_1056;
				}
				if (CS_0024_003C_003E8__locals57 != null)
				{
					if (CS_0024_003C_003E8__locals57.m_taskId != 0)
					{
						Task<int> task2 = ((ManageAccountPanel)CS_0024_003C_003E8__locals57.m_taskId).ShowSaveDataConflictChoicePopup(forceLinkConflictResponse2);
						if (task2 != null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
							TaskAwaiter<int> taskAwaiter2 = default(TaskAwaiter<int>);
							bool flag12 = (object)taskAwaiter2 == null;
							obj9 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)taskAwaiter2;
							if (!flag12)
							{
								int num9 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
								bool flag13 = num9 == 0;
								bool flag14 = num9 < 0;
								bool flag15 = !flag14;
								object obj12 = !flag15;
								object obj13 = obj12 | flag13;
								Task task3;
								if (obj13 == null)
								{
									bool flag16 = (object)taskAwaiter2 == null;
									task3 = (Task)taskAwaiter2;
									nint num10 = (nint)typeof(Task);
									if (!flag16)
									{
										int num11 = ((Task)taskAwaiter2).m_stateFlags & 0x11000000;
										if (num11 != 16777216)
										{
											TaskAwaiter.HandleNonSuccessAndDebuggerNotification((Task)taskAwaiter2);
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2176 @ rax_v142 (System.Runtime.CompilerServices.TaskAwaiter`1<System.Int32>)+50]");
										BaseAccountPagePanel baseAccountPagePanel;
										Action action;
										string text3;
										if ((nint)0 != 0)
										{
											bool flag17 = CS_0024_003C_003E8__locals57 == null;
											task3 = (Task)taskAwaiter2;
											nint num12 = 0;
											if (flag17)
											{
												throw new NullReferenceException();
											}
											task3 = (Task)CS_0024_003C_003E8__locals57.m_taskId;
											bool flag18 = CS_0024_003C_003E8__locals57.m_taskId == 0;
											num12 = 0;
											if (flag18)
											{
												throw new NullReferenceException();
											}
											AsyncTaskMethodBuilder asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder);
											_003CAcceptMergeConflict_003Ed__16 stateMachine2 = default(_003CAcceptMergeConflict_003Ed__16);
											asyncTaskMethodBuilder2.Start(ref stateMachine2);
											Task<System.Threading.Tasks.VoidTaskResult> task4 = ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder2))->Task;
											bool flag19 = task4 == null;
											num12 = (nint)(&asyncTaskMethodBuilder2);
											if (flag19)
											{
												throw new NullReferenceException();
											}
											TaskAwaiter awaiter2 = ((Task)task4).GetAwaiter();
											bool flag20 = (object)awaiter2 == null;
											task3 = (Task)awaiter2;
											if (flag20)
											{
												throw new NullReferenceException();
											}
											int num13 = ((Task)awaiter2).m_stateFlags & 0x1600000;
											bool flag21 = num13 == 0;
											bool flag22 = num13 < 0;
											bool flag23 = !flag22;
											object obj14 = !flag23;
											object obj15 = obj14 | flag21;
											if (obj15 != null)
											{
												_003C_003E1__state = 3;
												_003C_003Eu__3 = awaiter2;
												AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
												TaskAwaiter awaiter3 = default(TaskAwaiter);
												((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder3)->AwaitUnsafeOnCompleted(ref awaiter3, ref this);
												asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter3, ref this);
												task3 = (Task)awaiter2;
												num12 = unchecked((nint)null);
												return;
											}
											bool flag24 = (object)awaiter2 == null;
											task3 = (Task)awaiter2;
											nint num14 = (nint)typeof(Task);
											if (flag24)
											{
												throw new NullReferenceException();
											}
											int num15 = ((Task)awaiter2).m_stateFlags & 0x11000000;
											if (num15 != 16777216)
											{
												TaskAwaiter.HandleNonSuccessAndDebuggerNotification((Task)awaiter2);
											}
											bool flag25 = CS_0024_003C_003E8__locals57 == null;
											task3 = (Task)awaiter2;
											if (flag25)
											{
												throw new NullReferenceException();
											}
											bool flag26 = CS_0024_003C_003E8__locals57.m_taskId == 0;
											task3 = (Task)awaiter2;
											if (flag26)
											{
												throw new NullReferenceException();
											}
											Task task5 = ((ManageAccountPanel)CS_0024_003C_003E8__locals57.m_taskId).DoForceLink((AccountDetailsType)CS_0024_003C_003E8__locals57.m_action);
											bool flag27 = task5 == null;
											task3 = (Task)awaiter2;
											if (flag27)
											{
												throw new NullReferenceException();
											}
											TaskAwaiter awaiter4 = task5.GetAwaiter();
											bool flag28 = (object)awaiter4 == null;
											task3 = (Task)awaiter4;
											if (flag28)
											{
												throw new NullReferenceException();
											}
											int num16 = ((Task)awaiter4).m_stateFlags & 0x1600000;
											bool flag29 = num16 == 0;
											bool flag30 = num16 < 0;
											bool flag31 = !flag30;
											object obj16 = !flag31;
											object obj17 = obj16 | flag29;
											if (obj17 != null)
											{
												_003C_003E1__state = 4;
												_003C_003Eu__3 = awaiter4;
												AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
												TaskAwaiter awaiter5 = default(TaskAwaiter);
												((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter5, ref this);
												asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter5, ref this);
												task3 = (Task)awaiter4;
												num14 = unchecked((nint)null);
												return;
											}
											bool flag32 = (object)awaiter4 == null;
											task3 = (Task)awaiter4;
											if (flag32)
											{
												throw new NullReferenceException();
											}
											int num17 = ((Task)awaiter4).m_stateFlags & 0x11000000;
											if (num17 != 16777216)
											{
												TaskAwaiter.HandleNonSuccessAndDebuggerNotification((Task)awaiter4);
											}
											bool flag33 = CS_0024_003C_003E8__locals57 == null;
											task3 = (Task)awaiter4;
											if (flag33)
											{
												throw new NullReferenceException();
											}
											baseAccountPagePanel = (BaseAccountPagePanel)CS_0024_003C_003E8__locals57.m_taskId;
											string[] array = new string[1];
											bool flag34 = CS_0024_003C_003E8__locals57 == null;
											task3 = (Task)(object)array;
											if (flag34)
											{
												throw new NullReferenceException();
											}
											bool flag35 = array == null;
											task3 = (Task)(object)array;
											if (flag35)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											string accountTranslation2 = AccountPage.GetAccountTranslation("manage_account_migrate_and_link_success", array);
											if (CS_0024_003C_003E8__locals57 == null)
											{
												task3 = CS_0024_003C_003E8__locals57;
												throw new NullReferenceException();
											}
											action = (Action)(object)CS_0024_003C_003E8__locals57.m_parent;
											if (CS_0024_003C_003E8__locals57.m_parent == null)
											{
												Action action2 = delegate
												{
													ManageAccountPanel manageAccountPanel = ((_003C_003Ec__DisplayClass14_0)(object)CS_0024_003C_003E8__locals57)._003C_003E4__this;
													AccountPage accountPage = ((BaseAccountPagePanel)manageAccountPanel)._accountPage;
													accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
													accountPage.ClearAndBuild();
												};
												if (CS_0024_003C_003E8__locals57 == null)
												{
													throw new NullReferenceException();
												}
												CS_0024_003C_003E8__locals57.m_parent = (Task)(object)action2;
												action = action2;
											}
											text3 = accountTranslation2;
											object obj18 = 0;
										}
										else
										{
											bool flag36 = CS_0024_003C_003E8__locals57 == null;
											task3 = (Task)taskAwaiter2;
											num10 = 0;
											if (flag36)
											{
												throw new NullReferenceException();
											}
											bool flag37 = CS_0024_003C_003E8__locals57.m_taskId == 0;
											task3 = (Task)taskAwaiter2;
											if (flag37)
											{
												throw new NullReferenceException();
											}
											Task task6 = ((ManageAccountPanel)CS_0024_003C_003E8__locals57.m_taskId).DoForceLink((AccountDetailsType)CS_0024_003C_003E8__locals57.m_action);
											bool flag38 = task6 == null;
											task3 = (Task)taskAwaiter2;
											if (flag38)
											{
												throw new NullReferenceException();
											}
											TaskAwaiter awaiter6 = task6.GetAwaiter();
											bool flag39 = (object)awaiter6 == null;
											task3 = (Task)awaiter6;
											if (flag39)
											{
												throw new NullReferenceException();
											}
											int num18 = ((Task)awaiter6).m_stateFlags & 0x1600000;
											bool flag40 = num18 == 0;
											bool flag41 = num18 < 0;
											bool flag42 = !flag41;
											object obj19 = !flag42;
											object obj20 = obj19 | flag40;
											if (obj20 != null)
											{
												_003C_003E1__state = 2;
												_003C_003Eu__3 = awaiter6;
												AsyncVoidMethodBuilder asyncVoidMethodBuilder5 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
												TaskAwaiter awaiter7 = default(TaskAwaiter);
												((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder5)->AwaitUnsafeOnCompleted(ref awaiter7, ref this);
												asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter7, ref this);
												task3 = (Task)awaiter6;
												num10 = unchecked((nint)null);
												return;
											}
											bool flag43 = (object)awaiter6 == null;
											task3 = (Task)awaiter6;
											nint num12 = (nint)typeof(Task);
											if (flag43)
											{
												throw new NullReferenceException();
											}
											int num19 = ((Task)awaiter6).m_stateFlags & 0x11000000;
											bool flag44 = num19 == 16777216;
											num12 = (nint)typeof(Task);
											if (!flag44)
											{
												TaskAwaiter.HandleNonSuccessAndDebuggerNotification((Task)awaiter6);
											}
											bool flag45 = CS_0024_003C_003E8__locals57 == null;
											task3 = (Task)awaiter6;
											if (flag45)
											{
												throw new NullReferenceException();
											}
											baseAccountPagePanel = (BaseAccountPagePanel)CS_0024_003C_003E8__locals57.m_taskId;
											string[] array2 = new string[1];
											bool flag46 = CS_0024_003C_003E8__locals57 == null;
											task3 = (Task)(object)array2;
											num12 = (nint)typeof(string[]);
											if (flag46)
											{
												throw new NullReferenceException();
											}
											bool flag47 = array2 == null;
											task3 = (Task)(object)array2;
											num12 = (nint)typeof(string[]);
											if (flag47)
											{
												throw new NullReferenceException();
											}
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											string accountTranslation3 = AccountPage.GetAccountTranslation("manage_account_link_success", array2);
											bool flag48 = CS_0024_003C_003E8__locals57 == null;
											task3 = CS_0024_003C_003E8__locals57;
											num12 = unchecked((nint)"manage_account_link_success");
											if (flag48)
											{
												throw new NullReferenceException();
											}
											action = (Action)(object)CS_0024_003C_003E8__locals57.m_taskScheduler;
											bool flag49 = CS_0024_003C_003E8__locals57.m_taskScheduler != null;
											num12 = unchecked((nint)"manage_account_link_success");
											if (!flag49)
											{
												Action action3 = delegate
												{
													ManageAccountPanel manageAccountPanel = ((_003C_003Ec__DisplayClass14_0)(object)CS_0024_003C_003E8__locals57)._003C_003E4__this;
													AccountPage accountPage = ((BaseAccountPagePanel)manageAccountPanel)._accountPage;
													accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
													accountPage.ClearAndBuild();
												};
												bool flag50 = CS_0024_003C_003E8__locals57 == null;
												task3 = CS_0024_003C_003E8__locals57;
												if (flag50)
												{
													throw new NullReferenceException();
												}
												CS_0024_003C_003E8__locals57.m_taskScheduler = (TaskScheduler)(object)action3;
												num12 = (nint)(CS_0024_003C_003E8__locals57 + 40);
												action = action3;
											}
											bool flag51 = baseAccountPagePanel == null;
											task3 = CS_0024_003C_003E8__locals57;
											if (flag51)
											{
												throw new NullReferenceException();
											}
											text3 = accountTranslation3;
											object obj18 = 0;
										}
										baseAccountPagePanel.ShowOkPopupForSuccess(text3, action);
										object obj21 = 0;
										Action action4 = action;
										string text4 = text3;
										goto IL_1843;
									}
									throw new NullReferenceException();
								}
								_003C_003E1__state = 1;
								_003C_003Eu__2 = taskAwaiter2;
								AsyncVoidMethodBuilder asyncVoidMethodBuilder6 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
								TaskAwaiter<int> awaiter8 = default(TaskAwaiter<int>);
								((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder6)->AwaitUnsafeOnCompleted(ref awaiter8, ref this);
								asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter8, ref this);
								task3 = (Task)taskAwaiter2;
								_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed obj22 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)0;
								return;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_1843:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876200F0");
				obj4 = (_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed)0;
				goto IL_1669;
				IL_1056:
				if (CS_0024_003C_003E8__locals57 != null)
				{
					if (CS_0024_003C_003E8__locals57.m_taskId != 0)
					{
						Task task7 = ((ManageAccountPanel)CS_0024_003C_003E8__locals57.m_taskId).DoForceLink((AccountDetailsType)CS_0024_003C_003E8__locals57.m_action);
						if (task7 != null)
						{
							TaskAwaiter awaiter9 = task7.GetAwaiter();
							if ((object)awaiter9 != null)
							{
								int num20 = ((Task)awaiter9).m_stateFlags & 0x1600000;
								bool flag52 = num20 == 0;
								bool flag53 = num20 < 0;
								bool flag54 = !flag53;
								object obj23 = !flag54;
								object obj24 = obj23 | flag52;
								if (obj24 == null)
								{
									if ((object)awaiter9 != null)
									{
										int num21 = ((Task)awaiter9).m_stateFlags & 0x11000000;
										if (num21 != 16777216)
										{
											TaskAwaiter.HandleNonSuccessAndDebuggerNotification((Task)awaiter9);
										}
										if (CS_0024_003C_003E8__locals57 != null)
										{
											string[] array3 = new string[1];
											if (CS_0024_003C_003E8__locals57 != null)
											{
												if (array3 != null)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													string accountTranslation4 = AccountPage.GetAccountTranslation("manage_account_link_success", array3);
													if (CS_0024_003C_003E8__locals57 != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ stack_20_v4 (System.Threading.Tasks.Task)+38]");
														Action action5 = (Action)0;
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v89 @ stack_20_v4 (System.Threading.Tasks.Task)+38]");
														if ((nint)0 == 0)
														{
															Action action6 = delegate
															{
																ManageAccountPanel manageAccountPanel = ((_003C_003Ec__DisplayClass14_0)(object)CS_0024_003C_003E8__locals57)._003C_003E4__this;
																AccountPage accountPage = ((BaseAccountPagePanel)manageAccountPanel)._accountPage;
																accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
																accountPage.ClearAndBuild();
															};
															if (CS_0024_003C_003E8__locals57 == null)
															{
																throw new NullReferenceException();
															}
															action5 = action6;
														}
														if (CS_0024_003C_003E8__locals57.m_taskId != 0)
														{
															((BaseAccountPagePanel)CS_0024_003C_003E8__locals57.m_taskId).ShowOkPopupForSuccess(accountTranslation4, action5);
															object obj21 = 0;
															Action action4 = action5;
															string text4 = accountTranslation4;
															object obj18 = 0;
															goto IL_1843;
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
								_003C_003E1__state = 5;
								_003C_003Eu__3 = awaiter9;
								AsyncVoidMethodBuilder asyncVoidMethodBuilder7 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
								TaskAwaiter awaiter10 = default(TaskAwaiter);
								((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder7)->AwaitUnsafeOnCompleted(ref awaiter10, ref this);
								asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter10, ref this);
								nint num2 = unchecked((nint)null);
								return;
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
				IL_1669:
				_003C_003E1__state = -2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder8 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				if (asyncVoidMethodBuilder8.m_synchronizationContext != null)
				{
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder8)->NotifySynchronizationContextOfCompletion();
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

		public ManageAccountPanel _003C_003E4__this;

		public AccountDetailsType platform;

		public string platformAsString;

		public Action _003C_003E9__2;

		public Action _003C_003E9__3;

		public Action _003C_003E9__1;

		internal void _003CShowAlreadyLinkedPopup_003Eb__0(bool confirm)
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed stateMachine = default(_003C_003CShowAlreadyLinkedPopup_003Eb__0_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}

		internal void _003CShowAlreadyLinkedPopup_003Eb__2()
		{
			ManageAccountPanel manageAccountPanel = _003C_003E4__this;
			AccountPage accountPage = ((BaseAccountPagePanel)manageAccountPanel)._accountPage;
			accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
			accountPage.ClearAndBuild();
		}

		internal void _003CShowAlreadyLinkedPopup_003Eb__3()
		{
			ManageAccountPanel manageAccountPanel = _003C_003E4__this;
			AccountPage accountPage = ((BaseAccountPagePanel)manageAccountPanel)._accountPage;
			accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
			accountPage.ClearAndBuild();
		}

		internal void _003CShowAlreadyLinkedPopup_003Eb__1()
		{
			ManageAccountPanel manageAccountPanel = _003C_003E4__this;
			AccountPage accountPage = ((BaseAccountPagePanel)manageAccountPanel)._accountPage;
			accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
			accountPage.ClearAndBuild();
		}
	}

	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public TaskCompletionSource<int> t;

		internal void _003CShowSaveDataConflictChoicePopup_003Eb__0(int i)
		{
			TaskCompletionSource<int> taskCompletionSource = t;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1804D1C60");
			object obj = default(object);
			if (obj == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1806DA140");
			}
		}
	}

	private sealed class _003C_003Ec__DisplayClass17_0
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CHandleUnlink_003Eb__0_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public bool confirm;

			public _003C_003Ec__DisplayClass17_0 _003C_003E4__this;

			private TaskAwaiter<bool> _003C_003Eu__1;

			private TaskAwaiter _003C_003Eu__2;

			private unsafe void MoveNext()
			{
				//IL_004f: Expected O, but got I4
				//IL_005e: Expected I4, but got I8
				//IL_0070: Expected O, but got Ref
				//IL_0b94: Expected I4, but got I8
				//IL_0b9f: Expected O, but got Ref
				//IL_00a5: Expected O, but got I4
				//IL_00b4: Expected I4, but got I8
				//IL_00c7: Expected O, but got Ref
				//IL_057e: Expected O, but got I
				//IL_05b9: Expected I, but got O
				//IL_0875: Expected I, but got O
				//IL_01b6: Expected O, but got I
				//IL_08a0: Expected I, but got O
				//IL_01e3: Expected O, but got I
				//IL_0642: Expected O, but got I
				//IL_069a: Expected I, but got O
				//IL_08fa: Expected I, but got O
				//IL_06c5: Expected I, but got O
				//IL_0925: Expected I, but got O
				//IL_070c: Expected I, but got O
				//IL_026d: Expected O, but got Ref
				//IL_0c34: Expected I, but got O
				//IL_072a: Expected O, but got I
				//IL_049e: Expected I, but got O
				//IL_07bd: Expected O, but got I
				//IL_09a0: Expected O, but got I
				//IL_0c6e: Expected I, but got O
				//IL_0cca: Expected O, but got I4
				//IL_0783: Expected I, but got O
				//IL_04fc: Expected O, but got I4
				//IL_0504: Unknown result type (might be due to invalid IL or missing references)
				//IL_0509: Expected O, but got Unknown
				//IL_051b: Expected O, but got I4
				//IL_0529: Expected I, but got O
				//IL_02f3: Expected O, but got I4
				//IL_02fb: Unknown result type (might be due to invalid IL or missing references)
				//IL_0300: Expected O, but got Unknown
				//IL_0311: Expected O, but got I4
				//IL_031f: Expected I, but got O
				//IL_07f7: Expected O, but got Ref
				//IL_09dd: Expected O, but got Ref
				//IL_081d: Expected I, but got O
				//IL_0a03: Expected I, but got O
				if (_003C_003E1__state > 1 && !confirm)
				{
					goto IL_0b85;
				}
				object obj = default(object);
				Task task;
				Task task2;
				object CS_0024_003C_003E8__locals12 = default(object);
				AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = default(AsyncVoidMethodBuilder);
				_003C_003CHandleUnlink_003Eb__0_003Ed typeFromHandle;
				nint num2;
				if (obj == null)
				{
					_003C_003Eu__1 = (TaskAwaiter<bool>)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
					nint num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				}
				else
				{
					AsyncVoidMethodBuilder asyncVoidMethodBuilder;
					if ((nint)obj == 1)
					{
						_003C_003Eu__2 = (TaskAwaiter)0;
						_003C_003E1__state = -1;
						task2 = (Task)_003C_003Eu__2;
						asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)(&obj);
						num2 = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
						goto IL_0537;
					}
					if (CS_0024_003C_003E8__locals12 == null)
					{
						throw new NullReferenceException();
					}
					string[] array = new string[1];
					bool flag = CS_0024_003C_003E8__locals12 == null;
					typeFromHandle = (_003C_003CHandleUnlink_003Eb__0_003Ed)typeof(string[]);
					if (flag)
					{
						throw new NullReferenceException();
					}
					bool flag2 = array == null;
					typeFromHandle = (_003C_003CHandleUnlink_003Eb__0_003Ed)typeof(string[]);
					if (flag2)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string accountTranslation = AccountPage.GetAccountTranslation("manage_account_unlink_loading", array);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
					bool flag3 = (nint)0 == 0;
					typeFromHandle = (_003C_003CHandleUnlink_003Eb__0_003Ed)"manage_account_unlink_loading";
					if (flag3)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
					((BaseAccountPagePanel)0).ShowLoading(accountTranslation);
					if (CS_0024_003C_003E8__locals12 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1495 @ rcx_v18 (System.Runtime.CompilerServices.AsyncTaskMethodBuilder`1<System.Boolean>)+20]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<bool>);
					AccountLinkService._003CCanUnlink_003Ed__1 stateMachine = default(AccountLinkService._003CCanUnlink_003Ed__1);
					asyncTaskMethodBuilder2.Start(ref stateMachine);
					Task<bool> task3 = asyncTaskMethodBuilder2.Task;
					bool flag4 = task3 == null;
					asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)(&asyncTaskMethodBuilder2);
					if (flag4)
					{
						throw new NullReferenceException();
					}
					((AsyncTaskMethodBuilder<bool>*)task3)->Start(ref *(AccountLinkService._003CCanUnlink_003Ed__1*)null);
					TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
					if ((object)taskAwaiter == null)
					{
						throw new NullReferenceException();
					}
					int num3 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag5 = num3 == 0;
					bool flag6 = num3 < 0;
					bool flag7 = !flag6;
					object obj2 = !flag7;
					object obj3 = obj2 | flag5;
					task = (Task)taskAwaiter;
					asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)0;
					nint num = (nint)typeof(Task);
					if (obj3 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						asyncVoidMethodBuilder3.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						num = unchecked((nint)null);
						return;
					}
				}
				if (task != null)
				{
					int num4 = task.m_stateFlags & 0x11000000;
					if (num4 != 16777216)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rbx_v39 (System.Threading.Tasks.Task)+50]");
					if ((nint)0 != 0)
					{
						bool flag8 = CS_0024_003C_003E8__locals12 == null;
						nint num5 = 0;
						if (!flag8)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
							num5 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1590 @ rcx_v26 (Il2CppClass<System.Runtime.CompilerServices.TaskAwaiter`1<System.Boolean>>)+20]");
								if ((nint)0 != 0)
								{
									AsyncTaskMethodBuilder asyncTaskMethodBuilder3 = default(AsyncTaskMethodBuilder);
									AccountLinkService._003CTryToUnlinkSpecificPlatform_003Ed__2 stateMachine2 = default(AccountLinkService._003CTryToUnlinkSpecificPlatform_003Ed__2);
									asyncTaskMethodBuilder3.Start(ref stateMachine2);
									Task<System.Threading.Tasks.VoidTaskResult> task4 = ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder3))->Task;
									bool flag9 = task4 == null;
									num2 = (nint)(&asyncTaskMethodBuilder3);
									if (!flag9)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
										TaskAwaiter taskAwaiter2 = default(TaskAwaiter);
										bool flag10 = (object)taskAwaiter2 == null;
										num2 = (nint)task4;
										if (!flag10)
										{
											int num6 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
											bool flag11 = num6 == 0;
											bool flag12 = num6 < 0;
											bool flag13 = !flag12;
											object obj4 = !flag13;
											object obj5 = obj4 | flag11;
											task2 = (Task)taskAwaiter2;
											AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)0;
											num2 = (nint)typeof(Task);
											if (obj5 == null)
											{
												goto IL_0537;
											}
											_003C_003E1__state = 1;
											_003C_003Eu__2 = taskAwaiter2;
											AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
											TaskAwaiter awaiter2 = default(TaskAwaiter);
											((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
											asyncVoidMethodBuilder3.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
											num2 = unchecked((nint)null);
											return;
										}
										throw new NullReferenceException();
									}
									num5 = num2;
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					bool flag14 = CS_0024_003C_003E8__locals12 == null;
					nint num = 0;
					if (!flag14)
					{
						string[] array2 = new string[1];
						bool flag15 = CS_0024_003C_003E8__locals12 == null;
						num = (nint)typeof(string[]);
						if (!flag15)
						{
							bool flag16 = array2 == null;
							num = (nint)typeof(string[]);
							if (!flag16)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
								string accountTranslation2 = AccountPage.GetAccountTranslation("manage_account_cant_unlink_title", array2);
								string[] array3 = new string[1];
								bool flag17 = CS_0024_003C_003E8__locals12 == null;
								num = (nint)typeof(string[]);
								if (!flag17)
								{
									bool flag18 = array3 == null;
									nint num5 = (nint)typeof(string[]);
									if (!flag18)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										string accountTranslation3 = AccountPage.GetAccountTranslation("manage_account_cant_unlink_message", array3);
										Action action = _003C_003Ec._003C_003E9__17_1;
										bool flag19 = _003C_003Ec._003C_003E9__17_1 != null;
										num5 = (nint)typeof(_003C_003Ec);
										if (!flag19)
										{
											Action action2 = (_003C_003Ec._003C_003E9__17_1 = delegate
											{
											});
											nint num7 = (nint)typeof(_003C_003Ec);
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2333 @ rax_v124 (Il2CppClass<VampireSurvivors.UI.ManageAccountPanel+<>c>)+B8]");
											num5 = (nint)0 + (nint)32;
											action = action2;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
											((BaseAccountPagePanel)0).ShowOkPopup(accountTranslation2, accountTranslation3, action);
											Action action3 = action;
											Action action4 = (Action)(object)accountTranslation3;
											string text = accountTranslation2;
											goto IL_0cb7;
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
				IL_0cb7:
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1876200F0");
				typeFromHandle = (_003C_003CHandleUnlink_003Eb__0_003Ed)0;
				goto IL_0b85;
				IL_0537:
				if (task2 != null)
				{
					int num8 = task2.m_stateFlags & 0x11000000;
					bool flag20 = num8 == 16777216;
					Task task5 = (Task)num2;
					if (!flag20)
					{
						TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task2);
						task5 = task2;
					}
					bool flag21 = CS_0024_003C_003E8__locals12 == null;
					num2 = (nint)task5;
					if (!flag21)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
						num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1337 @ rcx_v31 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
							bool flag22 = (nint)0 == 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1337 @ rcx_v31 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
							num2 = 0;
							if (!flag22)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1337 @ rcx_v31 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
								((AccountPage)0).SetLoggedInStatus();
								bool flag23 = CS_0024_003C_003E8__locals12 == null;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1337 @ rcx_v31 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
								num2 = 0;
								if (!flag23)
								{
									string[] array4 = new string[1];
									bool flag24 = CS_0024_003C_003E8__locals12 == null;
									num2 = (nint)typeof(string[]);
									if (!flag24)
									{
										bool flag25 = array4 == null;
										num2 = (nint)typeof(string[]);
										if (!flag25)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
											string accountTranslation4 = AccountPage.GetAccountTranslation("manage_account_unlink_success", array4);
											bool flag26 = CS_0024_003C_003E8__locals12 == null;
											num2 = unchecked((nint)"manage_account_unlink_success");
											if (!flag26)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+28]");
												Action action5 = (Action)0;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+28]");
												if ((nint)0 == 0)
												{
													Action action6 = delegate
													{
														ManageAccountPanel manageAccountPanel = ((_003C_003Ec__DisplayClass17_0)CS_0024_003C_003E8__locals12)._003C_003E4__this;
														AccountPage accountPage = ((BaseAccountPagePanel)manageAccountPanel)._accountPage;
														accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
														accountPage.ClearAndBuild();
													};
													bool flag27 = CS_0024_003C_003E8__locals12 == null;
													num2 = (nint)action6;
													if (flag27)
													{
														throw new NullReferenceException();
													}
													action5 = action6;
												}
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v91 @ stack_20_v4 (System.Object)+10]");
												((BaseAccountPagePanel)0).ShowOkPopupForSuccess(accountTranslation4, action5);
												Action action3 = null;
												Action action4 = action5;
												string text = accountTranslation4;
												goto IL_0cb7;
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
				IL_0b85:
				_003C_003E1__state = -2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder5 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				if (asyncVoidMethodBuilder5.m_synchronizationContext != null)
				{
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder5)->NotifySynchronizationContextOfCompletion();
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

		public ManageAccountPanel _003C_003E4__this;

		public string platformAsString;

		public AccountDetailsType platform;

		public bool isCurrentPlatform;

		public Action _003C_003E9__2;

		internal void _003CHandleUnlink_003Eb__0(bool confirm)
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CHandleUnlink_003Eb__0_003Ed stateMachine = default(_003C_003CHandleUnlink_003Eb__0_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}

		internal void _003CHandleUnlink_003Eb__2()
		{
			ManageAccountPanel manageAccountPanel = _003C_003E4__this;
			AccountPage accountPage = ((BaseAccountPagePanel)manageAccountPanel)._accountPage;
			accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
			accountPage.ClearAndBuild();
		}
	}

	private sealed class _003C_003Ec__DisplayClass4_0
	{
		public ManageAccountPanel _003C_003E4__this;

		public AccountPage accountPage;

		internal void _003C_002Ector_003Eb__0()
		{
			ManageAccountPanel manageAccountPanel = _003C_003E4__this;
			SecretObscurer secretObscurer = manageAccountPanel._secretObscurer;
			bool shouldObscure = !secretObscurer._shouldObscure;
			secretObscurer._shouldObscure = shouldObscure;
			ManageAccountPanel manageAccountPanel2 = _003C_003E4__this;
			((BaseAccountPagePanel)manageAccountPanel2)._accountPage.Clear();
			manageAccountPanel2.Build();
			accountPage.ReAddSpecialButtonNavigation();
		}
	}

	private sealed class _003C_003Ec__DisplayClass9_0
	{
		[StructLayout((LayoutKind)3)]
		private struct _003C_003CBuildAccountDetailsForPlatform_003Eb__1_003Ed : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public _003C_003Ec__DisplayClass9_0 _003C_003E4__this;

			private TaskAwaiter _003C_003Eu__1;

			private unsafe void MoveNext()
			{
				//IL_0010: Expected O, but got I4
				//IL_001f: Expected I4, but got I8
				//IL_0194: Expected I4, but got I8
				//IL_019f: Expected O, but got Ref
				//IL_00ac: Expected O, but got I4
				//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
				//IL_00b9: Expected O, but got Unknown
				//IL_0141: Expected O, but got Ref
				_003C_003Ec__DisplayClass9_0 obj = _003C_003E4__this;
				Task task;
				if (_003C_003E1__state == 0)
				{
					_003C_003Eu__1 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
				}
				else
				{
					Task task2 = obj._003C_003E4__this.LinkPlatform(obj.platform, obj.platformAsString);
					int num = task2.m_stateFlags & 0x1600000;
					bool flag = num == 0;
					bool flag2 = num < 0;
					bool flag3 = !flag2;
					object obj2 = !flag3;
					object obj3 = obj2 | flag;
					task = task2;
					if (obj3 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = (TaskAwaiter)task2;
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

		public ManageAccountPanel _003C_003E4__this;

		public AccountDetailsType platform;

		public string platformAsString;

		internal void _003CBuildAccountDetailsForPlatform_003Eb__0()
		{
			_003C_003E4__this.HandleUnlink(platform);
		}

		internal void _003CBuildAccountDetailsForPlatform_003Eb__1()
		{
			SynchronizationContext.CurrentNoFlow?.OperationStarted();
			AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
			_003C_003CBuildAccountDetailsForPlatform_003Eb__1_003Ed stateMachine = default(_003C_003CBuildAccountDetailsForPlatform_003Eb__1_003Ed);
			asyncVoidMethodBuilder.Start(ref stateMachine);
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CAcceptMergeConflict_003Ed__16 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ManageAccountPanel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_01f1: Expected I, but got O
			//IL_035d: Expected I4, but got I8
			//IL_0298: Expected O, but got Ref
			//IL_00f1: Expected O, but got Ref
			//IL_012d: Expected O, but got I
			//IL_0165: Expected O, but got I4
			//IL_016d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0172: Expected O, but got Unknown
			//IL_0188: Expected I, but got O
			//IL_025d: Expected O, but got Ref
			//IL_0283: Expected I, but got O
			object obj = default(object);
			Task task;
			nint num = default(nint);
			AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder3 = default(AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>);
			if (obj == null)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_migrate_loading");
				BaseAccountPagePanel baseAccountPagePanel = default(BaseAccountPagePanel);
				bool flag = baseAccountPagePanel == null;
				string text = "manage_account_migrate_loading";
				if (flag)
				{
					throw new NullReferenceException();
				}
				baseAccountPagePanel.ShowLoading(accountTranslation);
				if (baseAccountPagePanel == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ stack_-A8_v2 (VampireSurvivors.UI.BaseAccountPagePanel)+20]");
				if ((nint)0 == 0)
				{
					throw new NullReferenceException();
				}
				AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
				AccountLinkService._003CAcceptMergeConflict_003Ed__4 stateMachine = default(AccountLinkService._003CAcceptMergeConflict_003Ed__4);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<System.Threading.Tasks.VoidTaskResult> task2 = ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
				bool flag2 = task2 == null;
				text = (string)(&asyncTaskMethodBuilder);
				if (flag2)
				{
					throw new NullReferenceException();
				}
				num = 0;
				nint num2 = (nint)(&asyncTaskMethodBuilder);
				if (task2 == null)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v760 @ rax_v44 (System.Threading.Tasks.Task`1<System.Threading.Tasks.VoidTaskResult>)+38]");
				object obj2 = (nint)0 & (nint)0x1600000;
				bool flag3 = obj2 == null;
				bool flag4 = (nint)obj2 < 0;
				bool flag5 = !flag4;
				object obj3 = !flag5;
				object obj4 = obj3 | flag3;
				task = task2;
				num2 = (nint)typeof(Task);
				if (obj4 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter)task2;
					nint num3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v289 @ rbx_v12 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
					}
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					Task<System.Threading.Tasks.VoidTaskResult> awaiter = default(Task<System.Threading.Tasks.VoidTaskResult>);
					((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref *(TaskAwaiter*)(&awaiter), ref this);
					asyncTaskMethodBuilder3.AwaitUnsafeOnCompleted(ref *(TaskAwaiter*)(&awaiter), ref this);
					num2 = unchecked((nint)null);
					return;
				}
			}
			if (task != null)
			{
				int num4 = task.m_stateFlags & 0x11000000;
				if (num4 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					num = unchecked((nint)null);
				}
				((AsyncTaskMethodBuilder*)(&asyncTaskMethodBuilder3))->Start(ref *(AccountLinkService._003CAcceptMergeConflict_003Ed__4*)num);
				_003C_003E1__state = -2;
				AsyncTaskMethodBuilder asyncTaskMethodBuilder4 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder4)->SetResult();
				return;
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
	private struct _003CBuild_003Ed__5 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public ManageAccountPanel _003C_003E4__this;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0310: Expected I4, but got I8
			//IL_031b: Expected O, but got Ref
			//IL_00e6: Expected O, but got I4
			//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f3: Expected O, but got Unknown
			//IL_0371: Expected O, but got Ref
			ManageAccountPanel CS_0024_003C_003E8__locals13 = _003C_003E4__this;
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_title");
				AccountPage accountPage = ((BaseAccountPagePanel)CS_0024_003C_003E8__locals13)._accountPage;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
				AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
				_003CLoadAccountDetail_003Ed__7 stateMachine = default(_003CLoadAccountDetail_003Ed__7);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<bool> task2 = asyncTaskMethodBuilder.Task;
				((AsyncTaskMethodBuilder<bool>*)task2)->Start(ref *(_003CLoadAccountDetail_003Ed__7*)null);
				TaskAwaiter<bool> taskAwaiter = default(TaskAwaiter<bool>);
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
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v93 @ rbx_v8 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				CS_0024_003C_003E8__locals13.AddAccountAndEnvInfo();
				bool flag4 = CS_0024_003C_003E8__locals13._accountDetails.IsPlatformLinked(AccountDetailsType.Email);
				bool flag5 = !flag4;
				string plaintext = "";
				if (!flag5)
				{
					AccountDetails accountDetails = CS_0024_003C_003E8__locals13._accountDetails;
					object obj3 = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).get_Item((System.Int32Enum)0);
					plaintext = (string)obj3;
				}
				CS_0024_003C_003E8__locals13._secretObscurer.AddSecret(Secret.Email, plaintext);
				string[] args = new string[1];
				string text = CS_0024_003C_003E8__locals13._secretObscurer.Get(Secret.Email);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string accountTranslation2 = AccountPage.GetAccountTranslation("manage_account_email_label", args);
				((BaseAccountPagePanel)CS_0024_003C_003E8__locals13)._accountPage.AddLabel(accountTranslation2);
				CS_0024_003C_003E8__locals13.BuildAccountDetailsForPlatform(AccountDetailsType.Steam);
				string accountTranslation3 = AccountPage.GetAccountTranslation("advanced_settings_button");
				Action callback = delegate
				{
					AccountPage accountPage2 = ((BaseAccountPagePanel)CS_0024_003C_003E8__locals13)._accountPage;
					accountPage2.accountPageState.ChangeStateTo(UIState.ADVANCED_SETTINGS);
					accountPage2.ClearAndBuild();
				};
				bool textIsLocalizationTerm = default(bool);
				bool isEnabledByDefault = default(bool);
				LabeledButtonUI labeledButtonUI = ((BaseAccountPagePanel)CS_0024_003C_003E8__locals13)._accountPage.AddLabeledButton("", accountTranslation3, callback, textIsLocalizationTerm, isEnabledByDefault);
				CS_0024_003C_003E8__locals13.AddBackButtonListener();
				((BaseAccountPagePanel)CS_0024_003C_003E8__locals13)._accountPage.GenerateNavigation();
				((BaseAccountPagePanel)CS_0024_003C_003E8__locals13)._accountPage.SelectFirstSelectable();
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
	private struct _003CDoForceLink_003Ed__13 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public AccountDetailsType platform;

		public ManageAccountPanel _003C_003E4__this;

		private TaskAwaiter<ILinkResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0080: Expected I, but got O
			//IL_0037: Expected O, but got I4
			//IL_0046: Expected I4, but got I8
			//IL_0026: Expected I, but got O
			//IL_00c7: Expected I, but got O
			//IL_0223: Expected I, but got O
			//IL_036f: Expected I4, but got I8
			//IL_02cf: Expected O, but got Ref
			//IL_0192: Expected O, but got I4
			//IL_019a: Unknown result type (might be due to invalid IL or missing references)
			//IL_019f: Expected O, but got Unknown
			//IL_01a4: Expected I, but got O
			//IL_01ba: Expected I, but got O
			//IL_0294: Expected O, but got Ref
			//IL_02ba: Expected I, but got O
			bool flag = _003C_003E1__state == 0;
			string text = null;
			if (!flag)
			{
				string text2 = HumanReadablePlatform.Get(platform);
				text = text2;
				nint num = unchecked((nint)null);
			}
			object obj = default(object);
			Task task;
			if (obj == null)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILinkResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				string[] array = new string[1];
				bool flag2 = array == null;
				nint num2 = (nint)typeof(string[]);
				if (flag2)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_link_loading", array);
				BaseAccountPagePanel baseAccountPagePanel = default(BaseAccountPagePanel);
				bool flag3 = baseAccountPagePanel == null;
				num2 = unchecked((nint)"manage_account_link_loading");
				if (flag3)
				{
					throw new NullReferenceException();
				}
				baseAccountPagePanel.ShowLoading(accountTranslation);
				Task<ILinkResult> task2 = BackendFacade.LinkAccount(force: true);
				bool flag4 = task2 == null;
				num2 = 1;
				if (flag4)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				Task task3 = default(Task);
				if (task3 == null)
				{
					throw new NullReferenceException();
				}
				int num3 = task3.m_stateFlags & 0x1600000;
				bool flag5 = num3 == 0;
				bool flag6 = num3 < 0;
				bool flag7 = !flag6;
				object obj2 = !flag7;
				object obj3 = obj2 | flag5;
				nint num = unchecked((nint)null);
				task = task3;
				nint num4 = (nint)typeof(Task);
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<ILinkResult>)task3;
					nint num5 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v313 @ rbx_v12 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
					}
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILinkResult> awaiter = default(TaskAwaiter<ILinkResult>);
					((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>);
					asyncTaskMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					num4 = unchecked((nint)null);
					return;
				}
			}
			if (task != null)
			{
				int num6 = task.m_stateFlags & 0x11000000;
				if (num6 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					nint num = unchecked((nint)null);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
				_003C_003E1__state = -2;
				AsyncTaskMethodBuilder asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder3)->SetResult();
				return;
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
	private struct _003CDoLink_003Ed__12 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public AccountDetailsType platform;

		public ManageAccountPanel _003C_003E4__this;

		private TaskAwaiter<ILinkResult> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_007b: Expected I, but got O
			//IL_0032: Expected O, but got I4
			//IL_0041: Expected I4, but got I8
			//IL_00c2: Expected I, but got O
			//IL_0104: Expected I, but got O
			//IL_0376: Expected I, but got O
			//IL_025c: Expected O, but got I
			//IL_026a: Expected I, but got O
			//IL_027a: Expected O, but got I
			//IL_02fa: Expected O, but got I4
			//IL_049c: Expected I4, but got I8
			//IL_047f: Expected I, but got O
			//IL_02b6: Expected O, but got I
			//IL_03e5: Expected O, but got Ref
			//IL_0500: Expected I, but got O
			//IL_0189: Expected O, but got I4
			//IL_0191: Unknown result type (might be due to invalid IL or missing references)
			//IL_0196: Expected O, but got Unknown
			//IL_019b: Expected I, but got O
			//IL_01b1: Expected I, but got O
			//IL_02ec: Expected O, but got I4
			//IL_033c: Expected I, but got O
			//IL_03aa: Expected O, but got Ref
			//IL_03d0: Expected I, but got O
			bool flag = _003C_003E1__state == 0;
			string text = null;
			if (!flag)
			{
				string text2 = HumanReadablePlatform.Get(platform);
				text = text2;
			}
			object obj = default(object);
			Task task;
			nint num4;
			nint num3;
			if (obj == null)
			{
				_003C_003Eu__1 = (TaskAwaiter<ILinkResult>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				string[] array = new string[1];
				bool flag2 = array == null;
				nint num = (nint)typeof(string[]);
				if (flag2)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_link_loading", array);
				BaseAccountPagePanel baseAccountPagePanel = default(BaseAccountPagePanel);
				bool flag3 = baseAccountPagePanel == null;
				num = unchecked((nint)"manage_account_link_loading");
				if (flag3)
				{
					throw new NullReferenceException();
				}
				baseAccountPagePanel.ShowLoading(accountTranslation);
				Task<ILinkResult> task2 = BackendFacade.LinkAccount();
				bool flag4 = task2 == null;
				num = unchecked((nint)null);
				if (flag4)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<ILinkResult> taskAwaiter = default(TaskAwaiter<ILinkResult>);
				if ((object)taskAwaiter == null)
				{
					throw new NullReferenceException();
				}
				int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag5 = num2 == 0;
				bool flag6 = num2 < 0;
				bool flag7 = !flag6;
				object obj2 = !flag7;
				object obj3 = obj2 | flag5;
				num3 = unchecked((nint)null);
				task = (Task)taskAwaiter;
				num4 = (nint)typeof(Task);
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<ILinkResult> awaiter = default(TaskAwaiter<ILinkResult>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<bool>);
					asyncTaskMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					num4 = unchecked((nint)null);
					return;
				}
			}
			object obj7;
			if (task != null)
			{
				int num5 = task.m_stateFlags & 0x11000000;
				if (num5 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v9 (System.Threading.Tasks.Task)+50]");
				nint num6 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v9 (System.Threading.Tasks.Task)+50]");
				if ((nint)0 == 0)
				{
					goto IL_0367;
				}
				object obj4 = num6;
				nint num7 = (nint)typeof(PlayFabLinkAborted);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r8_v13 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLinkAborted>)+130]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ r9_v10+130]");
				nint num8 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v427 @ r8_v13 (Il2CppClass<VampireSurvivors.App.Scripts.Framework.Platforms.Backend.PlayFab.PlayFabLinkAborted>)+130]");
				if (num8 >= 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v443 @ r9_v10+C8]");
					object obj6 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v575 @ rax_v40+FFFFFFF8+v428 @ rax_v34*8]");
					if (0 == (nint)typeof(PlayFabLinkAborted))
					{
						obj7 = 1;
						goto IL_046b;
					}
				}
				obj7 = 0;
				goto IL_046b;
			}
			throw new NullReferenceException();
			IL_048d:
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			bool result;
			((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder3)->SetResult(result);
			return;
			IL_0367:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
			num4 = unchecked((nint)null);
			result = true;
			goto IL_048d;
			IL_046b:
			bool flag8 = obj7 == null;
			nint num9 = unchecked((nint)null);
			if (!flag8)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v139 @ rbx_v9 (System.Threading.Tasks.Task)+50]");
				num9 = 0;
			}
			bool flag9 = num9 == 0;
			num3 = (nint)typeof(PlayFabLinkAborted);
			if (!flag9)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v442 @ rsi_v13 (Il2CppClass<System.Threading.Tasks.Task>)+10]");
				bool flag10 = (nint)0 != 0;
				num3 = (nint)typeof(PlayFabLinkAborted);
				if (!flag10)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
					result = false;
					goto IL_048d;
				}
			}
			goto IL_0367;
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
	private struct _003CLinkPlatform_003Ed__10 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder _003C_003Et__builder;

		public ManageAccountPanel _003C_003E4__this;

		public AccountDetailsType platform;

		public string platformAsString;

		private TaskAwaiter<bool> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_02c5: Expected I4, but got I8
			//IL_0248: Expected O, but got Ref
			//IL_00d6: Expected O, but got I4
			//IL_00de: Unknown result type (might be due to invalid IL or missing references)
			//IL_00e3: Expected O, but got Unknown
			//IL_022a: Expected O, but got Ref
			Task task;
			if (_003C_003E1__state == 0)
			{
				_003C_003Eu__1 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				if (_003C_003E4__this == null)
				{
					throw new NullReferenceException();
				}
				AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
				_003CDoLink_003Ed__12 stateMachine = default(_003CDoLink_003Ed__12);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<bool> task2 = asyncTaskMethodBuilder.Task;
				((AsyncTaskMethodBuilder<bool>*)task2)->Start(ref *(_003CDoLink_003Ed__12*)null);
				Task task3 = default(Task);
				int num = task3.m_stateFlags & 0x1600000;
				bool flag = num == 0;
				bool flag2 = num < 0;
				bool flag3 = !flag2;
				object obj = !flag3;
				object obj2 = obj | flag;
				task = task3;
				if (obj2 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter<bool>)task3;
					nint num2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v698 @ rbx_v14 (Il2CppMethodInfo)+38]");
					if ((nint)0 == 0)
					{
					}
					AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult> asyncTaskMethodBuilder2 = (AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter = default(TaskAwaiter<bool>);
					((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)asyncTaskMethodBuilder2)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					return;
				}
			}
			int num3 = task.m_stateFlags & 0x11000000;
			if (num3 != 16777216)
			{
				TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rbx_v6 (System.Threading.Tasks.Task)+50]");
			if ((nint)0 != 0)
			{
				string[] args = new string[1];
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_link_success", args);
				Action callback = delegate
				{
					AccountPage accountPage = ((BaseAccountPagePanel)_003C_003E4__this)._accountPage;
					accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
					accountPage.ClearAndBuild();
				};
				_003C_003E4__this.ShowOkPopupForSuccess(accountTranslation, callback);
			}
			_003C_003E1__state = -2;
			AsyncTaskMethodBuilder asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			((AsyncTaskMethodBuilder*)asyncTaskMethodBuilder3)->SetResult();
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
	private struct _003CLoadAccountDetail_003Ed__7 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncTaskMethodBuilder<bool> _003C_003Et__builder;

		public ManageAccountPanel _003C_003E4__this;

		private TaskAwaiter<AccountDetails> _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_0010: Expected O, but got I4
			//IL_001f: Expected I4, but got I8
			//IL_0027: Expected O, but got I
			//IL_011e: Expected O, but got I4
			//IL_0126: Unknown result type (might be due to invalid IL or missing references)
			//IL_012b: Expected O, but got Unknown
			//IL_0149: Expected I, but got O
			//IL_02fb: Expected I4, but got I8
			//IL_022f: Expected O, but got Ref
			//IL_026a: Expected O, but got Ref
			//IL_0255: Expected I, but got O
			object obj = default(object);
			Task task;
			BaseAccountPagePanel baseAccountPagePanel = default(BaseAccountPagePanel);
			if (obj == null)
			{
				_003C_003Eu__1 = (TaskAwaiter<AccountDetails>)0;
				_003C_003E1__state = -1;
				IntPtr intPtr = default(IntPtr);
				string text = (string)(nint)intPtr;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_account_details_loading");
				bool flag = baseAccountPagePanel == null;
				string text2 = "manage_account_account_details_loading";
				if (flag)
				{
					throw new NullReferenceException();
				}
				baseAccountPagePanel.ShowLoading(accountTranslation);
				Task<AccountDetails> accountDetails = BackendFacade.GetAccountDetails();
				bool flag2 = accountDetails == null;
				text2 = null;
				if (flag2)
				{
					throw new NullReferenceException();
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180482670");
				TaskAwaiter<AccountDetails> taskAwaiter = default(TaskAwaiter<AccountDetails>);
				if ((object)taskAwaiter == null)
				{
					throw new NullReferenceException();
				}
				int num = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
				bool flag3 = num == 0;
				bool flag4 = num < 0;
				bool flag5 = !flag4;
				object obj2 = !flag5;
				object obj3 = obj2 | flag3;
				string text = accountTranslation;
				task = (Task)taskAwaiter;
				nint num2 = (nint)typeof(Task);
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = taskAwaiter;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<AccountDetails> awaiter = default(TaskAwaiter<AccountDetails>);
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder2 = default(AsyncTaskMethodBuilder<bool>);
					asyncTaskMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					num2 = unchecked((nint)null);
					return;
				}
			}
			if (task != null)
			{
				int num3 = task.m_stateFlags & 0x11000000;
				if (num3 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					string text = null;
				}
				bool flag6 = baseAccountPagePanel == null;
				nint num2 = 0;
				if (!flag6)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ rbx_v7 (System.Threading.Tasks.Task)+50]");
					_ = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
					_003C_003E1__state = -2;
					AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder3 = (AsyncTaskMethodBuilder<bool>)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					((AsyncTaskMethodBuilder<bool>*)asyncTaskMethodBuilder3)->SetResult(result: true);
					return;
				}
				throw new NullReferenceException();
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
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @184CF4FC0");
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	private AccountDetails _accountDetails;

	private readonly AccountLinkService _accountLinkService;

	private readonly AccountDeletionService _accountDeletionService;

	private readonly SecretObscurer _secretObscurer;

	public ManageAccountPanel(AccountPage accountPage)
	{
		_003C_003Ec__DisplayClass4_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass4_0
		{
			accountPage = accountPage
		};
		base._002Ector(CS_0024_003C_003E8__locals7.accountPage);
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		AccountLinkService accountLinkService = new AccountLinkService();
		_accountLinkService = accountLinkService;
		AccountDeletionService accountDeletionService = new AccountDeletionService();
		_accountDeletionService = accountDeletionService;
		SecretObscurer secretObscurer = new SecretObscurer();
		_secretObscurer = secretObscurer;
		AccountPage accountPage2 = CS_0024_003C_003E8__locals7.accountPage;
		Action action = delegate
		{
			ManageAccountPanel manageAccountPanel = CS_0024_003C_003E8__locals7._003C_003E4__this;
			SecretObscurer secretObscurer2 = manageAccountPanel._secretObscurer;
			bool shouldObscure = !secretObscurer2._shouldObscure;
			secretObscurer2._shouldObscure = shouldObscure;
			ManageAccountPanel manageAccountPanel2 = CS_0024_003C_003E8__locals7._003C_003E4__this;
			((BaseAccountPagePanel)manageAccountPanel2)._accountPage.Clear();
			manageAccountPanel2.Build();
			CS_0024_003C_003E8__locals7.accountPage.ReAddSpecialButtonNavigation();
		};
		CS_0024_003C_003E8__locals7.accountPage.EnableSpecialButton(action, accountPage2._showHideSprite);
	}

	public override void Build()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CBuild_003Ed__5 stateMachine = default(_003CBuild_003Ed__5);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void BuildAccountDetailsForCurrentPlatform()
	{
		BuildAccountDetailsForPlatform(AccountDetailsType.Steam);
	}

	private Task<bool> LoadAccountDetail()
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CLoadAccountDetail_003Ed__7 stateMachine = default(_003CLoadAccountDetail_003Ed__7);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	private void BuildAccountDetailsForEmail()
	{
		bool flag = _accountDetails.IsPlatformLinked(AccountDetailsType.Email);
		bool flag2 = !flag;
		string plaintext = "";
		if (!flag2)
		{
			AccountDetails accountDetails = _accountDetails;
			object obj = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).get_Item((System.Int32Enum)0);
			plaintext = (string)obj;
		}
		_secretObscurer.AddSecret(Secret.Email, plaintext);
		string[] args = new string[1];
		string text = _secretObscurer.Get(Secret.Email);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string accountTranslation = AccountPage.GetAccountTranslation("manage_account_email_label", args);
		base._accountPage.AddLabel(accountTranslation);
	}

	private void BuildAccountDetailsForPlatform(AccountDetailsType platform)
	{
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0314: Expected O, but got Unknown
		//IL_0323: Expected I4, but got O
		//IL_033b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0340: Expected O, but got Unknown
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_0089: Expected O, but got Unknown
		//IL_009c: Expected I4, but got O
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Expected O, but got Unknown
		//IL_016b: Expected I4, but got O
		//IL_0183: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ca: Expected O, but got Unknown
		//IL_01d9: Expected I4, but got O
		//IL_01f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01f6: Expected O, but got Unknown
		_003C_003Ec__DisplayClass9_0 obj = new _003C_003Ec__DisplayClass9_0();
		obj._003C_003E4__this = this;
		obj.platform = platform;
		bool flag = _accountDetails.IsPlatformLinked(platform);
		string platformAsString = HumanReadablePlatform.Get(obj.platform);
		obj.platformAsString = platformAsString;
		AccountDetails accountDetails = _accountDetails;
		object obj3 = default(object);
		string detail;
		Action action;
		nint method = default(nint);
		if (!flag)
		{
			object obj2 = obj3 + 64;
			_ = obj.platform;
			object o = (AccountDetailsType)obj2;
			_ = typeof(AccountDetailsType);
			object o2 = obj3 - 40;
			_ = -1;
			_ = 5;
			if (!ValueType.DefaultEquals(o2, o))
			{
				string accountTranslation = AccountPage.GetAccountTranslation("manage_account_not_linked");
				detail = accountTranslation;
			}
			else
			{
				string accountTranslation2 = AccountPage.GetAccountTranslation("manage_account_not_linked");
				string accountTranslation3 = AccountPage.GetAccountTranslation("manage_account_link");
				action = new Action(obj, method);
				method = 0;
				detail = accountTranslation2;
			}
			goto IL_02cd;
		}
		object obj4 = obj3 + 64;
		_ = 3;
		object o3 = (AccountDetailsType)obj4;
		_ = typeof(AccountDetailsType);
		object o4 = obj3 - 40;
		_ = -1;
		_ = obj.platform;
		object plaintext;
		if (!ValueType.DefaultEquals(o4, o3))
		{
			object obj5 = obj3 + 64;
			_ = 5;
			object o5 = (AccountDetailsType)obj5;
			_ = typeof(AccountDetailsType);
			object o6 = obj3 - 40;
			_ = -1;
			_ = obj.platform;
			if (!ValueType.DefaultEquals(o6, o5))
			{
				object obj6 = obj3 + 64;
				_ = 1;
				object o7 = (AccountDetailsType)obj6;
				_ = typeof(AccountDetailsType);
				object o8 = obj3 - 40;
				_ = -1;
				_ = obj.platform;
				bool flag2 = ValueType.DefaultEquals(o8, o7);
				plaintext = "";
				goto IL_024a;
			}
		}
		plaintext = ((Dictionary<System.Int32Enum, object>)(object)accountDetails.PlatformAccounts).get_Item((System.Int32Enum)obj.platform);
		goto IL_024a;
		IL_02cd:
		string buttonText = default(string);
		Action callback = default(Action);
		base._accountPage.AddAccountDetail(flag, obj.platformAsString, detail, buttonText, callback);
		return;
		IL_024a:
		_secretObscurer.AddSecret(Secret.AccountDetail, (string)plaintext);
		string text = _secretObscurer.Get(Secret.AccountDetail);
		bool flag3 = text._stringLength <= 0;
		detail = text;
		if (!flag3)
		{
			string text2 = "(" + text + ")";
			detail = text2;
		}
		string accountTranslation4 = AccountPage.GetAccountTranslation("manage_account_unlink");
		action = null;
		method = 0;
		goto IL_02cd;
	}

	private unsafe Task LinkPlatform(AccountDetailsType platform, string platformAsString)
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CLinkPlatform_003Ed__10 stateMachine = default(_003CLinkPlatform_003Ed__10);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	private void AddAccountAndEnvInfo()
	{
		string accountId = BackendFacade.GetAccountId();
		_secretObscurer.AddSecret(Secret.PlayFabAccountId, accountId);
		string[] args = new string[1];
		string text = _secretObscurer.Get(Secret.PlayFabAccountId);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string accountTranslation = AccountPage.GetAccountTranslation("settings_account_id", args);
		string[] args2 = new string[1];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string accountTranslation2 = AccountPage.GetAccountTranslation("settings_env", args2);
		string labelText = accountTranslation + "\n" + accountTranslation2;
		string accountTranslation3 = AccountPage.GetAccountTranslation("manage_copy_to_clipboard");
		Action callback = _003C_003Ec._003C_003E9__11_0;
		if (_003C_003Ec._003C_003E9__11_0 == null)
		{
			callback = (_003C_003Ec._003C_003E9__11_0 = delegate
			{
				string accountId2 = BackendFacade.GetAccountId();
				GUIUtility.systemCopyBuffer = accountId2;
			});
		}
		bool textIsLocalizationTerm = default(bool);
		bool isEnabledByDefault = default(bool);
		LabeledButtonUI labeledButtonUI = base._accountPage.AddLabeledButton(labelText, accountTranslation3, callback, textIsLocalizationTerm, isEnabledByDefault);
	}

	private Task<bool> DoLink(AccountDetailsType platform)
	{
		AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
		_003CDoLink_003Ed__12 stateMachine = default(_003CDoLink_003Ed__12);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return asyncTaskMethodBuilder.Task;
	}

	private unsafe Task DoForceLink(AccountDetailsType platform)
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CDoForceLink_003Ed__13 stateMachine = default(_003CDoForceLink_003Ed__13);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	private void ShowAlreadyLinkedPopup(AccountDetailsType platform)
	{
		//IL_00bf: Expected I4, but got O
		_003C_003Ec__DisplayClass14_0 obj = new _003C_003Ec__DisplayClass14_0();
		obj._003C_003E4__this = this;
		obj.platform = platform;
		string platformAsString = HumanReadablePlatform.Get(platform);
		obj.platformAsString = platformAsString;
		string[] args = new string[1];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string accountTranslation = AccountPage.GetAccountTranslation("manage_account_already_linked_title", args);
		string[] args2 = new string[1];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string accountTranslation2 = AccountPage.GetAccountTranslation("manage_account_already_linked_message", args2);
		Action<bool> action = null;
		((_003C_003Ec__DisplayClass14_0)(object)action)._003CShowAlreadyLinkedPopup_003Eb__0((byte)(int)obj != 0);
		bool textIsLocalizationTerm = default(bool);
		PopupManager.CreateOKCancelPopup("already-linked", accountTranslation, accountTranslation2, action, textIsLocalizationTerm);
	}

	private Task<int> ShowSaveDataConflictChoicePopup(ForceLinkConflictResponse conflictResponse)
	{
		//IL_00f4: Expected I4, but got O
		//IL_0160: Expected O, but got I
		_003C_003Ec__DisplayClass15_0 obj = new _003C_003Ec__DisplayClass15_0();
		TaskCompletionSource<int> t = null;
		object obj2 = null;
		_ = 33555456;
		if (obj != null)
		{
			obj.t = t;
			List<SaveSummary> list = new List<SaveSummary>();
			if (conflictResponse != null)
			{
				SaveSummary saveSummary = SaveUtils.GetSaveSummary(conflictResponse.CurrentAccountSaveData);
				if (list != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A992A0");
					SaveSummary saveSummary2 = SaveUtils.GetSaveSummary(conflictResponse.LinkingAccountSaveData);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A992A0");
					string accountTranslation = AccountPage.GetAccountTranslation("manage_account_conflict_title");
					string accountTranslation2 = AccountPage.GetAccountTranslation("manage_account_conflict_message");
					Action<int> action = null;
					((_003C_003Ec__DisplayClass15_0)(object)action)._003CShowSaveDataConflictChoicePopup_003Eb__0((int)obj);
					if (_003C_003Ec._003C_003E9__15_1 == null)
					{
						Action action2 = delegate
						{
						};
						_003C_003Ec._003C_003E9__15_1 = action2;
					}
					object callback = default(object);
					bool textIsLocalizationTerm = default(bool);
					bool hasCancelButton = default(bool);
					Action onCancel = default(Action);
					PopupManager.CreateSaveFileComparison("link-account-conflict", accountTranslation, accountTranslation2, list, (Action<int>)callback, textIsLocalizationTerm, hasCancelButton, onCancel);
					TaskCompletionSource<int> t2 = obj.t;
					if (obj.t != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v263 @ rax_v29 (System.Threading.Tasks.TaskCompletionSource`1<System.Int32>)+10]");
						return (Task<int>)0;
					}
				}
			}
		}
		return (Task<int>)(object)new NullReferenceException();
	}

	private unsafe Task AcceptMergeConflict()
	{
		AsyncTaskMethodBuilder asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder);
		_003CAcceptMergeConflict_003Ed__16 stateMachine = default(_003CAcceptMergeConflict_003Ed__16);
		asyncTaskMethodBuilder.Start(ref stateMachine);
		return ((AsyncTaskMethodBuilder<System.Threading.Tasks.VoidTaskResult>*)(&asyncTaskMethodBuilder))->Task;
	}

	private unsafe void HandleUnlink(AccountDetailsType platform)
	{
		//IL_004e: Expected I4, but got O
		//IL_005f: Expected O, but got Ref
		//IL_00c9: Expected I4, but got O
		_003C_003Ec__DisplayClass17_0 obj = new _003C_003Ec__DisplayClass17_0();
		obj._003C_003E4__this = this;
		obj.platform = platform;
		string platformAsString = HumanReadablePlatform.Get(platform);
		obj.platformAsString = platformAsString;
		object obj2 = default(object);
		object o = (AccountDetailsType)obj2;
		IntPtr intPtr = default(IntPtr);
		bool isCurrentPlatform = ValueType.DefaultEquals((object)(&intPtr), o);
		obj.isCurrentPlatform = isCurrentPlatform;
		string accountTranslation = AccountPage.GetAccountTranslation("common_are_you_sure");
		string[] args = new string[1];
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string accountTranslation2 = AccountPage.GetAccountTranslation("manage_account_unlink_confirm", args);
		Action<bool> action = null;
		((_003C_003Ec__DisplayClass17_0)(object)action)._003CHandleUnlink_003Eb__0((byte)(int)obj != 0);
		bool textIsLocalizationTerm = default(bool);
		PopupManager.CreateOKCancelPopup("confirm-unlink", accountTranslation, accountTranslation2, action, textIsLocalizationTerm);
	}

	private void _003CBuild_003Eb__5_0()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.ADVANCED_SETTINGS);
		accountPage.ClearAndBuild();
	}

	private void _003CLinkPlatform_003Eb__10_0()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
		accountPage.ClearAndBuild();
	}

	private void _003CLinkPlatform_003Eb__10_1()
	{
		AccountPage accountPage = base._accountPage;
		accountPage.accountPageState.ChangeStateTo(UIState.MANAGE_ACCOUNT);
		accountPage.ClearAndBuild();
	}
}
