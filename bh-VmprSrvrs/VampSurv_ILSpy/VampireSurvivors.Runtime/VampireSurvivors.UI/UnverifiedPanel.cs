using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Util;

namespace VampireSurvivors.UI;

public class UnverifiedPanel : BaseAccountPagePanel
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9;

		public static Action _003C_003E9__3_0;

		public static Action _003C_003E9__3_1;

		public static Action _003C_003E9__3_2;

		public static Action _003C_003E9__4_1;

		public static Action _003C_003E9__4_2;

		public static Action _003C_003E9__4_3;

		public static Action _003C_003E9__4_4;

		public static Action _003C_003E9__4_0;

		static _003C_003Ec()
		{
			_003C_003Ec obj = new _003C_003Ec();
			_003C_003E9 = obj;
		}

		internal void _003CTryLogin_003Eb__3_0()
		{
		}

		internal void _003CTryLogin_003Eb__3_1()
		{
		}

		internal void _003CTryLogin_003Eb__3_2()
		{
		}

		internal void _003CResendVerificationEmail_003Eb__4_1()
		{
		}

		internal void _003CResendVerificationEmail_003Eb__4_2()
		{
		}

		internal void _003CResendVerificationEmail_003Eb__4_3()
		{
		}

		internal void _003CResendVerificationEmail_003Eb__4_4()
		{
		}

		internal void _003CResendVerificationEmail_003Eb__4_0()
		{
		}
	}

	private sealed class _003C_003Ec__DisplayClass1_0
	{
		public UnverifiedPanel _003C_003E4__this;

		public AccountPage accountPage;

		internal void _003C_002Ector_003Eb__0()
		{
			UnverifiedPanel unverifiedPanel = _003C_003E4__this;
			SecretObscurer secretObscurer = unverifiedPanel._secretObscurer;
			bool shouldObscure = !secretObscurer._shouldObscure;
			secretObscurer._shouldObscure = shouldObscure;
			UnverifiedPanel unverifiedPanel2 = _003C_003E4__this;
			((BaseAccountPagePanel)unverifiedPanel2)._accountPage.Clear();
			unverifiedPanel2.Build();
			accountPage.ReAddSpecialButtonNavigation();
		}
	}

	[StructLayout((LayoutKind)3)]
	private struct _003CResendVerificationEmail_003Ed__4 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public UnverifiedPanel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private string _003CaccountEmailAddress_003E5__2;

		private TaskAwaiter<bool> _003C_003Eu__2;

		private unsafe void MoveNext()
		{
			//IL_09b0: Expected O, but got Ref
			//IL_0571: Expected O, but got I4
			//IL_0580: Expected I4, but got I8
			//IL_0593: Expected O, but got Ref
			//IL_059b: Expected I, but got O
			//IL_0030: Expected O, but got I4
			//IL_003f: Expected I4, but got I8
			//IL_07db: Expected I, but got O
			//IL_0246: Expected I, but got O
			//IL_0215: Expected I, but got O
			//IL_0121: Expected I, but got O
			//IL_09c6: Expected O, but got I
			//IL_0278: Expected I, but got O
			//IL_067c: Expected O, but got Ref
			//IL_028e: Expected I, but got O
			//IL_017f: Expected O, but got I4
			//IL_0187: Unknown result type (might be due to invalid IL or missing references)
			//IL_018c: Expected O, but got Unknown
			//IL_0196: Expected I, but got O
			//IL_01ac: Expected I, but got O
			//IL_02d4: Expected I, but got O
			//IL_0bd9: Expected I, but got O
			//IL_0bef: Expected O, but got I
			//IL_043c: Expected O, but got Ref
			//IL_0303: Expected I, but got O
			//IL_0462: Expected I, but got O
			//IL_033b: Expected I, but got O
			//IL_0702: Expected O, but got I4
			//IL_070a: Unknown result type (might be due to invalid IL or missing references)
			//IL_070f: Expected O, but got Unknown
			//IL_0721: Expected O, but got I4
			//IL_072f: Expected I, but got O
			//IL_086f: Expected O, but got Ref
			//IL_0aa2: Expected I4, but got I8
			//IL_0aad: Expected O, but got Ref
			//IL_036a: Expected I, but got O
			//IL_0895: Expected I, but got O
			//IL_03b5: Expected I, but got O
			//IL_0a5b: Expected I, but got O
			//IL_040d: Expected I, but got O
			bool flag = _003C_003E1__state == 1;
			DateTime dateTime = (DateTime)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
			object obj = default(object);
			AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
			if (!flag)
			{
				Task task;
				BaseAccountPagePanel baseAccountPagePanel = default(BaseAccountPagePanel);
				nint num;
				string text;
				IFormatProvider formatProvider;
				if (obj == null)
				{
					_003C_003Eu__1 = (TaskAwaiter)0;
					_003C_003E1__state = -1;
					task = (Task)_003C_003Eu__1;
					num = (nint)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
				}
				else
				{
					string accountTranslation = AccountPage.GetAccountTranslation("loading_checking_status");
					bool flag2 = baseAccountPagePanel == null;
					text = "loading_checking_status";
					if (flag2)
					{
						throw new NullReferenceException();
					}
					baseAccountPagePanel.ShowLoading(accountTranslation);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
					AccountInformation accountInformation = default(AccountInformation);
					bool flag3 = accountInformation == null;
					text = (string)(object)typeof(AccountInformation);
					if (flag3)
					{
						throw new NullReferenceException();
					}
					Task task2 = accountInformation.Fetch();
					bool flag4 = task2 == null;
					text = (string)(object)accountInformation;
					if (flag4)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182A52EA0");
					TaskAwaiter taskAwaiter = default(TaskAwaiter);
					bool flag5 = (object)taskAwaiter == null;
					num = (nint)task2;
					if (flag5)
					{
						text = (string)num;
						throw new NullReferenceException();
					}
					int num2 = ((Task)taskAwaiter).m_stateFlags & 0x1600000;
					bool flag6 = num2 == 0;
					bool flag7 = num2 < 0;
					bool flag8 = !flag7;
					object obj2 = !flag8;
					object obj3 = obj2 | flag6;
					formatProvider = null;
					nint num3 = unchecked((nint)null);
					task = (Task)taskAwaiter;
					num = (nint)typeof(Task);
					if (obj3 != null)
					{
						_003C_003E1__state = 0;
						_003C_003Eu__1 = taskAwaiter;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						TaskAwaiter awaiter = default(TaskAwaiter);
						((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
						asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
						num = unchecked((nint)null);
						return;
					}
				}
				if (task == null)
				{
					throw new NullReferenceException();
				}
				int num4 = task.m_stateFlags & 0x11000000;
				if (num4 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task);
					nint num3 = unchecked((nint)null);
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
				AccountInformation accountInformation2 = default(AccountInformation);
				bool flag9 = accountInformation2 == null;
				num = (nint)typeof(AccountInformation);
				if (flag9)
				{
					throw new NullReferenceException();
				}
				IPlayerProfile playerProfile = accountInformation2.GetPlayerProfile();
				bool flag10 = playerProfile == null;
				num = (nint)playerProfile;
				if (flag10)
				{
					throw new NullReferenceException();
				}
				nint num5 = (nint)playerProfile;
				if (playerProfile.IsContactEmailAddressVerified())
				{
					bool flag11 = baseAccountPagePanel == null;
					num = (nint)playerProfile;
					if (!flag11)
					{
						bool flag12 = (object)baseAccountPagePanel._accountPage == null;
						num = (nint)baseAccountPagePanel._accountPage;
						if (!flag12)
						{
							baseAccountPagePanel._accountPage.SetLoggedInStatus();
							bool flag13 = baseAccountPagePanel == null;
							num = (nint)baseAccountPagePanel._accountPage;
							if (!flag13)
							{
								bool flag14 = (object)baseAccountPagePanel._accountPage == null;
								num = (nint)baseAccountPagePanel._accountPage;
								if (!flag14)
								{
									baseAccountPagePanel._accountPage.GoHome();
									string accountTranslation2 = AccountPage.GetAccountTranslation("verification_registration_complete_heading");
									string accountTranslation3 = AccountPage.GetAccountTranslation("verification_verified_message");
									nint num6 = (nint)typeof(_003C_003Ec);
									Action callback = _003C_003Ec._003C_003E9__4_1;
									if (_003C_003Ec._003C_003E9__4_1 == null)
									{
										Action action = (_003C_003Ec._003C_003E9__4_1 = delegate
										{
										});
										nint num7 = (nint)typeof(_003C_003Ec);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2344 @ rax_v165 (Il2CppClass<VampireSurvivors.UI.UnverifiedPanel+<>c>)+B8]");
										num6 = (nint)0 + (nint)32;
										callback = action;
									}
									bool flag15 = baseAccountPagePanel == null;
									num = num6;
									if (!flag15)
									{
										baseAccountPagePanel.ShowOkPopup(accountTranslation2, accountTranslation3, callback);
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
										num = unchecked((nint)null);
										goto IL_0a93;
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
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
				ResendVerificationEmailAllowedService resendVerificationEmailAllowedService = new ResendVerificationEmailAllowedService();
				bool flag16 = resendVerificationEmailAllowedService == null;
				text = (string)(object)resendVerificationEmailAllowedService;
				if (flag16)
				{
					throw new NullReferenceException();
				}
				string userSpecificKey = PlatformUserPlayerPrefs.GetUserSpecificKey(resendVerificationEmailAllowedService.key);
				string text2 = PlayerPrefs.GetString(userSpecificKey, "");
				bool flag17 = text2 == null;
				formatProvider = null;
				dateTime = (DateTime)userSpecificKey;
				if (!flag17)
				{
					bool flag18 = text2._stringLength <= 0;
					formatProvider = null;
					dateTime = (DateTime)userSpecificKey;
					if (!flag18)
					{
						ref DateTime result = default(ref DateTime);
						bool flag19 = DateTime.TryParseExact(text2, "O", null, DateTimeStyles.None, out result);
						bool flag20 = !flag19;
						DateTimeStyles dateTimeStyles = DateTimeStyles.None;
						formatProvider = null;
						dateTime = (DateTime)text2;
						if (!flag20)
						{
							DateTime now = DateTime.Now;
							DateTime dateTime2 = default(DateTime);
							bool flag21 = dateTime2 < now;
							bool flag22 = !flag21;
							dateTimeStyles = DateTimeStyles.None;
							formatProvider = null;
							dateTime = dateTime2;
							if (flag22)
							{
								string accountTranslation4 = AccountPage.GetAccountTranslation("verification_email_resend_throttle_heading");
								string accountTranslation5 = AccountPage.GetAccountTranslation("verification_email_resend_throttle_message");
								Action callback2 = _003C_003Ec._003C_003E9__4_0;
								if (_003C_003Ec._003C_003E9__4_0 == null)
								{
									callback2 = (_003C_003Ec._003C_003E9__4_0 = delegate
									{
									});
								}
								baseAccountPagePanel.ShowOkPopup(accountTranslation4, accountTranslation5, callback2);
								goto IL_0a93;
							}
						}
					}
				}
			}
			Task task3;
			BaseAccountPagePanel baseAccountPagePanel2 = default(BaseAccountPagePanel);
			if ((nint)obj == 1)
			{
				_003C_003Eu__2 = (TaskAwaiter<bool>)0;
				_003C_003E1__state = -1;
				task3 = (Task)_003C_003Eu__2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)(&obj);
				nint num8 = (nint)dateTime;
			}
			else
			{
				string accountTranslation6 = AccountPage.GetAccountTranslation("verification_sending_email");
				bool flag23 = baseAccountPagePanel2 == null;
				string text3 = "verification_sending_email";
				if (flag23)
				{
					throw new NullReferenceException();
				}
				baseAccountPagePanel2.ShowLoading(accountTranslation6);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
				AccountInformation accountInformation3 = default(AccountInformation);
				bool flag24 = accountInformation3 == null;
				text3 = (string)(object)typeof(AccountInformation);
				if (flag24)
				{
					throw new NullReferenceException();
				}
				string accountEmailAddress = accountInformation3.GetAccountEmailAddress();
				_003CaccountEmailAddress_003E5__2 = accountEmailAddress;
				AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = default(AsyncTaskMethodBuilder<bool>);
				BackendFacade._003CResendAccountVerificationEmail_003Ed__18 stateMachine = default(BackendFacade._003CResendAccountVerificationEmail_003Ed__18);
				asyncTaskMethodBuilder.Start(ref stateMachine);
				Task<bool> task4 = asyncTaskMethodBuilder.Task;
				bool flag25 = task4 == null;
				text3 = (string)(&asyncTaskMethodBuilder);
				if (flag25)
				{
					throw new NullReferenceException();
				}
				((AsyncTaskMethodBuilder<bool>*)task4)->Start(ref *(BackendFacade._003CResendAccountVerificationEmail_003Ed__18*)null);
				TaskAwaiter<bool> taskAwaiter2 = default(TaskAwaiter<bool>);
				if ((object)taskAwaiter2 == null)
				{
					throw new NullReferenceException();
				}
				int num9 = ((Task)taskAwaiter2).m_stateFlags & 0x1600000;
				bool flag26 = num9 == 0;
				bool flag27 = num9 < 0;
				bool flag28 = !flag27;
				object obj4 = !flag28;
				object obj5 = obj4 | flag26;
				task3 = (Task)taskAwaiter2;
				AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)0;
				nint num8 = (nint)typeof(Task);
				if (obj5 != null)
				{
					_003C_003E1__state = 1;
					_003C_003Eu__2 = taskAwaiter2;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder4 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter<bool> awaiter2 = default(TaskAwaiter<bool>);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder4)->AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter2, ref this);
					num8 = unchecked((nint)null);
					return;
				}
			}
			if (task3 != null)
			{
				int num10 = task3.m_stateFlags & 0x11000000;
				if (num10 != 16777216)
				{
					TaskAwaiter.HandleNonSuccessAndDebuggerNotification(task3);
				}
				string accountTranslation7 = AccountPage.GetAccountTranslation("verification_email_sent_heading");
				string[] array = new string[1];
				bool flag29 = array == null;
				nint num8 = (nint)typeof(string[]);
				if (!flag29)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
					string accountTranslation8 = AccountPage.GetAccountTranslation("verification_email_sent_message", array);
					Action callback3 = _003C_003Ec._003C_003E9__4_3;
					bool flag30 = _003C_003Ec._003C_003E9__4_3 != null;
					string title = accountTranslation7;
					string text = (string)(object)typeof(_003C_003Ec);
					if (!flag30)
					{
						Action action2 = (_003C_003Ec._003C_003E9__4_3 = delegate
						{
						});
						nint num11 = (nint)typeof(_003C_003Ec);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2041 @ rax_v58 (Il2CppClass<VampireSurvivors.UI.UnverifiedPanel+<>c>)+B8]");
						text = (string)((nint)0 + (nint)48);
						title = accountTranslation7;
						callback3 = action2;
					}
					if (baseAccountPagePanel2 != null)
					{
						baseAccountPagePanel2.ShowOkPopup(title, accountTranslation8, callback3);
						_003CaccountEmailAddress_003E5__2 = null;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
						string text3 = null;
						goto IL_0a93;
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
			IL_0a93:
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

	[StructLayout((LayoutKind)3)]
	private struct _003CTryLogin_003Ed__3 : IAsyncStateMachine
	{
		public int _003C_003E1__state;

		public AsyncVoidMethodBuilder _003C_003Et__builder;

		public UnverifiedPanel _003C_003E4__this;

		private TaskAwaiter _003C_003Eu__1;

		private unsafe void MoveNext()
		{
			//IL_04be: Expected O, but got I
			//IL_00aa: Expected I, but got O
			//IL_0060: Expected O, but got I4
			//IL_006f: Expected I4, but got I8
			//IL_0137: Expected O, but got I4
			//IL_013f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0144: Expected O, but got Unknown
			//IL_015a: Expected I, but got O
			//IL_03fd: Expected O, but got Ref
			//IL_0423: Expected I, but got O
			//IL_05dd: Expected I4, but got I8
			//IL_05e8: Expected O, but got Ref
			//IL_0566: Expected I, but got O
			bool flag = _003C_003E1__state == 0;
			IntPtr intPtr = default(IntPtr);
			string text = (string)(nint)intPtr;
			if (!flag)
			{
				string accountTranslation = AccountPage.GetAccountTranslation("loading_checking_status");
				_003C_003E4__this.ShowLoading(accountTranslation);
				text = accountTranslation;
			}
			object obj = default(object);
			Task task;
			if (obj == null)
			{
				_003C_003Eu__1 = (TaskAwaiter)0;
				_003C_003E1__state = -1;
				task = (Task)_003C_003Eu__1;
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C6A8E0");
				AccountInformation accountInformation = default(AccountInformation);
				bool flag2 = accountInformation == null;
				nint num = (nint)typeof(AccountInformation);
				if (flag2)
				{
					throw new NullReferenceException();
				}
				Task task2 = accountInformation.Fetch();
				if (task2 == null)
				{
					throw new NullReferenceException();
				}
				if (task2 == null)
				{
					throw new NullReferenceException();
				}
				int num2 = task2.m_stateFlags & 0x1600000;
				bool flag3 = num2 == 0;
				bool flag4 = num2 < 0;
				bool flag5 = !flag4;
				object obj2 = !flag5;
				object obj3 = obj2 | flag3;
				task = task2;
				nint num3 = (nint)typeof(Task);
				if (obj3 != null)
				{
					_003C_003E1__state = 0;
					_003C_003Eu__1 = (TaskAwaiter)task2;
					AsyncVoidMethodBuilder asyncVoidMethodBuilder = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
					TaskAwaiter awaiter = default(TaskAwaiter);
					((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder)->AwaitUnsafeOnCompleted(ref awaiter, ref this);
					AsyncVoidMethodBuilder asyncVoidMethodBuilder2 = default(AsyncVoidMethodBuilder);
					asyncVoidMethodBuilder2.AwaitUnsafeOnCompleted(ref awaiter, ref this);
					num3 = unchecked((nint)null);
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
				if (AccountInformation._accountInformation != null)
				{
					IPlayerProfile playerProfile = AccountInformation._accountInformation.GetPlayerProfile();
					if (playerProfile != null)
					{
						BaseAccountPagePanel baseAccountPagePanel = default(BaseAccountPagePanel);
						if (playerProfile.IsContactEmailAddressVerified())
						{
							bool flag6 = baseAccountPagePanel == null;
							IPlayerProfile playerProfile2 = playerProfile;
							if (flag6)
							{
								throw new NullReferenceException();
							}
							bool flag7 = (object)baseAccountPagePanel._accountPage == null;
							playerProfile2 = (IPlayerProfile)(object)baseAccountPagePanel._accountPage;
							if (flag7)
							{
								throw new NullReferenceException();
							}
							baseAccountPagePanel._accountPage.SetLoggedInStatus();
							bool flag8 = baseAccountPagePanel == null;
							playerProfile2 = (IPlayerProfile)(object)baseAccountPagePanel._accountPage;
							if (flag8)
							{
								throw new NullReferenceException();
							}
							if ((object)baseAccountPagePanel._accountPage == null)
							{
								throw new NullReferenceException();
							}
							baseAccountPagePanel._accountPage.GoHome();
							string accountTranslation2 = AccountPage.GetAccountTranslation("registration_success_heading");
							string accountTranslation3 = AccountPage.GetAccountTranslation("verification_verified_message");
							Action callback = _003C_003Ec._003C_003E9__3_1;
							if (_003C_003Ec._003C_003E9__3_1 == null)
							{
								callback = (_003C_003Ec._003C_003E9__3_1 = delegate
								{
								});
							}
							if (baseAccountPagePanel == null)
							{
								throw new NullReferenceException();
							}
							baseAccountPagePanel.ShowOkPopup(accountTranslation2, accountTranslation3, callback);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
							nint num = unchecked((nint)null);
						}
						else
						{
							string accountTranslation4 = AccountPage.GetAccountTranslation("verification_error_heading");
							string accountTranslation5 = AccountPage.GetAccountTranslation("verification_not_verified_message");
							string accountTranslation6 = AccountPage.GetAccountTranslation("verification_check_inbox_message");
							bool flag9 = _003C_003Ec._003C_003E9__3_0 != null;
							string title = accountTranslation4;
							if (!flag9)
							{
								Action action = delegate
								{
								};
								_003C_003Ec._003C_003E9__3_0 = action;
								title = accountTranslation4;
							}
							if (baseAccountPagePanel == null)
							{
								throw new NullReferenceException();
							}
							Action callback2 = default(Action);
							baseAccountPagePanel.ShowAccountErrorPopup(title, accountTranslation5, accountTranslation6, callback2);
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @186C3F7D0");
							IPlayerProfile playerProfile2 = null;
						}
						_003C_003E1__state = -2;
						AsyncVoidMethodBuilder asyncVoidMethodBuilder3 = (AsyncVoidMethodBuilder)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
						if (asyncVoidMethodBuilder3.m_synchronizationContext != null)
						{
							((AsyncVoidMethodBuilder*)asyncVoidMethodBuilder3)->NotifySynchronizationContextOfCompletion();
						}
						return;
					}
					throw new NullReferenceException();
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

	private readonly SecretObscurer _secretObscurer;

	public UnverifiedPanel(AccountPage accountPage)
	{
		_003C_003Ec__DisplayClass1_0 CS_0024_003C_003E8__locals7 = new _003C_003Ec__DisplayClass1_0
		{
			accountPage = accountPage
		};
		base._002Ector(CS_0024_003C_003E8__locals7.accountPage);
		CS_0024_003C_003E8__locals7._003C_003E4__this = this;
		SecretObscurer secretObscurer = new SecretObscurer();
		_secretObscurer = secretObscurer;
		AccountPage accountPage2 = CS_0024_003C_003E8__locals7.accountPage;
		Action action = delegate
		{
			UnverifiedPanel unverifiedPanel = CS_0024_003C_003E8__locals7._003C_003E4__this;
			SecretObscurer secretObscurer2 = unverifiedPanel._secretObscurer;
			bool shouldObscure = !secretObscurer2._shouldObscure;
			secretObscurer2._shouldObscure = shouldObscure;
			UnverifiedPanel unverifiedPanel2 = CS_0024_003C_003E8__locals7._003C_003E4__this;
			((BaseAccountPagePanel)unverifiedPanel2)._accountPage.Clear();
			unverifiedPanel2.Build();
			CS_0024_003C_003E8__locals7.accountPage.ReAddSpecialButtonNavigation();
		};
		CS_0024_003C_003E8__locals7.accountPage.EnableSpecialButton(action, accountPage2._showHideSprite);
	}

	public override void Build()
	{
		string accountTranslation = AccountPage.GetAccountTranslation("logged_in_title");
		AccountPage accountPage = base._accountPage;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18634B7A0");
		string accountTranslation2 = AccountPage.GetAccountTranslation("verification_required_message");
		base._accountPage.AddLabel(accountTranslation2);
		string accountEmailAddress = AccountInformation._accountInformation.GetAccountEmailAddress();
		if (accountEmailAddress == null)
		{
			Debug.Log("email address is null");
		}
		_secretObscurer.AddSecret(Secret.Email, accountEmailAddress);
		string[] args = new string[1];
		string text = _secretObscurer.Get(Secret.Email);
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		string accountTranslation3 = AccountPage.GetAccountTranslation("manage_account_email_label", args);
		base._accountPage.AddLabel(accountTranslation3);
		string accountTranslation4 = AccountPage.GetAccountTranslation("verification_player_declaration_resend_email");
		string accountTranslation5 = AccountPage.GetAccountTranslation("verification_player_declaration_resend_email_button");
		Action callback = ResendVerificationEmail;
		bool textIsLocalizationTerm = default(bool);
		bool isEnabledByDefault = default(bool);
		LabeledButtonUI labeledButtonUI = base._accountPage.AddLabeledButton(accountTranslation4, accountTranslation5, callback, textIsLocalizationTerm, isEnabledByDefault);
		string accountTranslation6 = AccountPage.GetAccountTranslation("verification_player_declaration_verified");
		string accountTranslation7 = AccountPage.GetAccountTranslation("verification_player_declaration_verified_button");
		Action callback2 = TryLogin;
		LabeledButtonUI labeledButtonUI2 = base._accountPage.AddLabeledButton(accountTranslation6, accountTranslation7, callback2, textIsLocalizationTerm, isEnabledByDefault);
		AddLogoutButton();
		base._accountPage.GenerateNavigation();
		base._accountPage.SelectFirstSelectable();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A2E6D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		PopupManager.ClosePopup("account-loading");
	}

	private void TryLogin()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CTryLogin_003Ed__3 stateMachine = default(_003CTryLogin_003Ed__3);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}

	private void ResendVerificationEmail()
	{
		SynchronizationContext.CurrentNoFlow?.OperationStarted();
		AsyncVoidMethodBuilder asyncVoidMethodBuilder = default(AsyncVoidMethodBuilder);
		_003CResendVerificationEmail_003Ed__4 stateMachine = default(_003CResendVerificationEmail_003Ed__4);
		asyncVoidMethodBuilder.Start(ref stateMachine);
	}
}
