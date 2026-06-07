using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Platforms.Saves;
using VampireSurvivors.Objects;

namespace VampireSurvivors.Framework.Saves
{
	public static class Migrator
	{
		private class MigratorLoadingState
		{
			public bool loadedOldSave;

			public bool showedDialog;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass2_0
		{
			public MigratorLoadingState state;

			public Action<StorageResult> _003C_003E9__0;

			internal void _003CTryLoadingFromLocations_003Eb__0(StorageResult result)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass5_0
		{
			public byte[] data;

			public PlayerOptions playerOptions;

			public Action<StorageResult> onComplete;

			public bool done;

			internal void _003CTryLoadFromBytes_003Eb__0(byte[] resolvedData)
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CAttemptMigration_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerOptions playerOptions;

			private byte[] _003CcurrentData_003E5__2;

			private List<string> _003CdirectoriesToTry_003E5__3;

			private MigratorLoadingState _003Cstate_003E5__4;

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
			public _003CAttemptMigration_003Ed__1(int _003C_003E1__state)
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
		private sealed class _003CTryLoadFromBytes_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public byte[] data;

			public PlayerOptions playerOptions;

			public Action<StorageResult> onComplete;

			public byte[] currentData;

			private _003C_003Ec__DisplayClass5_0 _003C_003E8__1;

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
			public _003CTryLoadFromBytes_003Ed__5(int _003C_003E1__state)
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
		private sealed class _003CTryLoadFromPath_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string filePath;

			public Action<StorageResult> onComplete;

			public byte[] currentData;

			public PlayerOptions playerOptions;

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
			public _003CTryLoadFromPath_003Ed__4(int _003C_003E1__state)
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
		private sealed class _003CTryLoadingFromLocations_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public MigratorLoadingState state;

			public List<string> directoriesToTry;

			public string filename;

			public byte[] currentData;

			public PlayerOptions playerOptions;

			private _003C_003Ec__DisplayClass2_0 _003C_003E8__1;

			private int _003Ci_003E5__2;

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
			public _003CTryLoadingFromLocations_003Ed__2(int _003C_003E1__state)
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

		[IteratorStateMachine(typeof(_003CAttemptMigration_003Ed__1))]
		public static IEnumerator AttemptMigration(PlayerOptions playerOptions)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTryLoadingFromLocations_003Ed__2))]
		private static IEnumerator TryLoadingFromLocations(List<string> directoriesToTry, byte[] currentData, PlayerOptions playerOptions, MigratorLoadingState state, string filename = "SaveData.sav")
		{
			return null;
		}

		private static byte[] SerializeCurrentData(PlayerOptionsData currentData)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTryLoadFromPath_003Ed__4))]
		private static IEnumerator TryLoadFromPath(string filePath, byte[] currentData, PlayerOptions playerOptions, Action<StorageResult> onComplete)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CTryLoadFromBytes_003Ed__5))]
		private static IEnumerator TryLoadFromBytes(byte[] data, byte[] currentData, PlayerOptions playerOptions, Action<StorageResult> onComplete)
		{
			return null;
		}

		private static bool DoDirectLoad(byte[] data, PlayerOptions playerOptions)
		{
			return false;
		}

		private static string GetPlatformSpecificParentPath()
		{
			return null;
		}
	}
}
