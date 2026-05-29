using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Libs;
using UnityEngine;

namespace UI
{
	public class LoadScreenController : SingletonMonoBehaviour<LoadScreenController>
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		private struct _003CCreateAndInitLoadScreen_003Ed__8 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public LoadScreenController _003C_003E4__this;

			private TaskAwaiter<GameObject> _003C_003Eu__1;

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

		private const string PrefabPath = "Assets/Prefabs/UI/LoadScreenCanvas";

		private GameObject screenObj;

		private bool screenActive;

		private bool isCreated;

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void Start()
		{
		}

		private bool IsUseScreenPlatform()
		{
			return false;
		}

		[AsyncStateMachine(typeof(_003CCreateAndInitLoadScreen_003Ed__8))]
		private void CreateAndInitLoadScreen()
		{
		}

		public void Set()
		{
		}

		public void Unset()
		{
		}

		private void SetScreenActive(bool active)
		{
		}
	}
}
