using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine;

namespace GRP
{
	public class ProjectFilePickerItemViewable : Viewable
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CLoadImage_003Ed__11 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ProjectFilePickerItemViewable _003C_003E4__this;

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

		[RawImageCrew]
		public Texture2D image;

		[GameObjectCrew]
		public bool isFile;

		[GameObjectCrew]
		public bool isFolder;

		public string name;

		private ProjectFilePickerPage page;

		private ProjectFileDefinition file;

		private ProjectFolderDefinition folder;

		private bool disposed;

		public ProjectFilePickerItemViewable(ProjectFilePickerPage page, ProjectFileDefinition file)
		{
		}

		public ProjectFilePickerItemViewable(ProjectFilePickerPage page, ProjectFolderDefinition folder)
		{
		}

		[CrewMethod]
		public void Select()
		{
		}

		[AsyncStateMachine(typeof(_003CLoadImage_003Ed__11))]
		public Task LoadImage()
		{
			return null;
		}

		public void Dispose()
		{
		}
	}
}
