using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GRP
{
	public class ProjectSceneLoader : MonoBehaviour
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CHandleScene_003Ed__10 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ProjectSceneLoader _003C_003E4__this;

			private int _003CnewScene_003E5__2;

			private Awaitable.Awaiter _003C_003Eu__1;

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

		public Project project;

		public Scene loadedScene;

		private bool dirty;

		private bool dirtyLoading;

		private bool isLoading;

		public void Attach(ProjectContainer projectContainer)
		{
		}

		public void Detach(ProjectContainer projectContainer)
		{
		}

		public void Attach(Project project)
		{
		}

		public void OnChange()
		{
		}

		private void LateUpdate()
		{
		}

		[AsyncStateMachine(typeof(_003CHandleScene_003Ed__10))]
		public Task HandleScene()
		{
			return null;
		}
	}
}
