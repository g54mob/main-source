using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Authentication;

namespace VampireSurvivors.UI
{
	public class AccountInformation
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CFetch_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AccountInformation _003C_003E4__this;

			private TaskAwaiter<string> _003C_003Eu__1;

			private TaskAwaiter<IPlayerProfile> _003C_003Eu__2;

			private void MoveNext()
			{
			}

			void IAsyncStateMachine.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				this.MoveNext();
			}

			[DebuggerHidden]
			private void SetStateMachine(IAsyncStateMachine stateMachine)
			{
			}

			void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
			{
				//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
				this.SetStateMachine(stateMachine);
			}
		}

		private static readonly AccountInformation _accountInformation;

		private IPlayerProfile PlayerProfile { get; set; }

		private string AccountEmailAddress { get; set; }

		private AccountInformation()
		{
		}

		public static AccountInformation Instance()
		{
			return null;
		}

		public IPlayerProfile GetPlayerProfile()
		{
			return null;
		}

		public string GetAccountEmailAddress()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CFetch_003Ed__13))]
		public Task Fetch()
		{
			return null;
		}

		public void Clear()
		{
		}

		private bool HasAccountEmailAddress()
		{
			return false;
		}

		private bool HasPlayerProfile()
		{
			return false;
		}
	}
}
