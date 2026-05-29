using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FishNet.Managing.Scened
{
	public class DefaultSceneProcessor : SceneProcessorBase
	{
		[CompilerGenerated]
		private sealed class _003CAsyncsIsDone_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DefaultSceneProcessor _003C_003E4__this;

			private bool _003CnotDone_003E5__2;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CAsyncsIsDone_003Ed__14(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		protected List<AsyncOperation> LoadingAsyncOperations;

		protected List<Scene> Scenes;

		protected AsyncOperation CurrentAsyncOperation;

		public override void LoadStart(LoadQueueData queueData)
		{
		}

		public override void LoadEnd(LoadQueueData queueData)
		{
		}

		private void ResetValues()
		{
		}

		public override void UnloadStart(UnloadQueueData queueData)
		{
		}

		public override void BeginLoadAsync(string sceneName, LoadSceneParameters parameters)
		{
		}

		public override void BeginUnloadAsync(Scene scene)
		{
		}

		public override bool IsPercentComplete()
		{
			return false;
		}

		public override float GetPercentComplete()
		{
			return 0f;
		}

		public override void AddLoadedScene(Scene scene)
		{
		}

		public override List<Scene> GetLoadedScenes()
		{
			return null;
		}

		public override void ActivateLoadedScenes()
		{
		}

		[IteratorStateMachine(typeof(_003CAsyncsIsDone_003Ed__14))]
		public override IEnumerator AsyncsIsDone()
		{
			return null;
		}
	}
}
