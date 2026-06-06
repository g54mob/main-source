using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Brewery.Networking
{
	[DefaultExecutionOrder(-500)]
	public class SceneHashPatcher : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CRetryPatch_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneHashPatcher _003C_003E4__this;

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
			public _003CRetryPatch_003Ed__10(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CWaitForNetworkManagerAndPatch_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public SceneHashPatcher _003C_003E4__this;

			private float _003Ctimeout_003E5__2;

			private float _003Celapsed_003E5__3;

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
			public _003CWaitForNetworkManagerAndPatch_003Ed__6(int _003C_003E1__state)
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

		[Header("Settings")]
		[SerializeField]
		private bool enablePatcher;

		[SerializeField]
		private bool showDebugLogs;

		[Header("Editor Only")]
		[Tooltip("Only enable in Unity Editor (disable in builds)")]
		[SerializeField]
		private bool editorOnly;

		private static SceneHashPatcher s_Instance;

		private bool hasPatched;

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForNetworkManagerAndPatch_003Ed__6))]
		private IEnumerator WaitForNetworkManagerAndPatch()
		{
			return null;
		}

		private void OnServerStarted()
		{
		}

		private void OnClientStarted()
		{
		}

		private void TryPatchHashTables()
		{
		}

		[IteratorStateMachine(typeof(_003CRetryPatch_003Ed__10))]
		private IEnumerator RetryPatch()
		{
			return null;
		}

		private void PatchHashTables()
		{
		}

		private FieldInfo FindField(Type type, Type fieldType, params string[] possibleNames)
		{
			return null;
		}

		private List<uint> GeneratePossibleHashes(string scenePath, string sceneName)
		{
			return null;
		}

		private uint ComputeXXHash(string input)
		{
			return 0u;
		}

		private static uint XXHash32(byte[] buf, uint seed)
		{
			return 0u;
		}

		private static uint Round(uint acc, uint input)
		{
			return 0u;
		}

		private static uint RotateLeft(uint value, int count)
		{
			return 0u;
		}

		private void OnDestroy()
		{
		}

		[ContextMenu("Debug: Print Current Hash Tables")]
		public void DebugPrintHashTables()
		{
		}

		[ContextMenu("Debug: Force Patch Now")]
		public void DebugForcePatch()
		{
		}
	}
}
