using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP
{
	public class ProjectFileItemViewable : Viewable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadThumbnail_003Ed__13 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public ProjectFileItemViewable _003C_003E4__this;

			private TaskAwaiter<byte[]> _003C_003Eu__1;

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

		[TextCrew]
		public string name;

		public Texture2D thumbnail;

		private Context context;

		private bool disposed;

		public ProjectFileDefinition manifest { get; set; }

		public ProjectContainer container { get; set; }

		public ProjectFileItemViewable(Context context, ProjectContainer container, ProjectFileDefinition manifest)
		{
		}

		[AsyncStateMachine(typeof(_003CLoadThumbnail_003Ed__13))]
		private void LoadThumbnail()
		{
		}

		public void Dispose()
		{
		}

		[CrewMethod]
		public void Load()
		{
		}

		[CrewMethod]
		public void Rename()
		{
		}

		[CrewMethod]
		public void Delete()
		{
		}

		[CrewMethod]
		public void Merge()
		{
		}

		[CrewMethod]
		public void SaveBuiltin()
		{
		}
	}
}
