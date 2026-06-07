using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using VampireSurvivors.Achievements;
using VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Service;
using VampireSurvivors.Objects;

namespace VampireSurvivors.UI
{
	public class LoadDataPanel : BaseAccountPagePanel
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CBuild_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LoadDataPanel _003C_003E4__this;

			private TaskAwaiter<string> _003C_003Eu__1;

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

		private PlayerOptions _playerOptions;

		private CloudDataService _cloudDataService;

		private AchievementManager _achievementManager;

		public LoadDataPanel(AccountPage accountPage, PlayerOptions playerOptions, AchievementManager achievementManager)
			: base(null)
		{
		}

		[AsyncStateMachine(typeof(_003CBuild_003Ed__4))]
		public override void Build()
		{
		}
	}
}
