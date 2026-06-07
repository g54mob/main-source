using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using UnityEngine.Localization.Tables;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Brewery.Localization
{
	public static class Loc
	{
		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CGetAsync_003Ed__15 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder<string> _003C_003Et__builder;

			public string table;

			public string key;

			private TaskAwaiter<StringTable> _003C_003Eu__1;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CLoadTableAsync_003Ed__23 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public string tableName;

			private AsyncOperationHandle<StringTable> _003Cop_003E5__2;

			private TaskAwaiter<StringTable> _003C_003Eu__1;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CPreloadAllTablesAsync_003Ed__24 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			private TaskAwaiter<LocalizationSettings> _003C_003Eu__1;

			private string[] _003C_003E7__wrap1;

			private int _003C_003E7__wrap2;

			private string _003CtableName_003E5__4;

			private AsyncOperationHandle<StringTable> _003Cop_003E5__5;

			private TaskAwaiter<StringTable> _003C_003Eu__2;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CPreloadTable_003Ed__16 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public string tableName;

			private TaskAwaiter<StringTable> _003C_003Eu__1;

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

		[StructLayout(LayoutKind.Auto)]
		[CompilerGenerated]
		private struct _003CPreloadTables_003Ed__17 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public string[] tableNames;

			private TaskAwaiter _003C_003Eu__1;

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

		private static readonly Dictionary<string, StringTable> _tableCache;

		private static bool _initialized;

		private static bool _tablesReady;

		private static readonly HashSet<string> _loadingTables;

		public static bool TablesReady => false;

		public static Locale CurrentLocale => null;

		public static event Action OnLocaleChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public static event Action OnTablesReady
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
		private static void AutoInit()
		{
		}

		public static string Get(string table, string key)
		{
			return null;
		}

		public static string Get(string table, string key, params (string name, object value)[] args)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CGetAsync_003Ed__15))]
		public static Task<string> GetAsync(string table, string key)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CPreloadTable_003Ed__16))]
		public static Task PreloadTable(string tableName)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CPreloadTables_003Ed__17))]
		public static Task PreloadTables(params string[] tableNames)
		{
			return null;
		}

		public static void SetLocale(string localeCode)
		{
		}

		public static bool HasKey(string table, string key)
		{
			return false;
		}

		private static StringTable GetTable(string tableName)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CLoadTableAsync_003Ed__23))]
		private static void LoadTableAsync(string tableName)
		{
		}

		[AsyncStateMachine(typeof(_003CPreloadAllTablesAsync_003Ed__24))]
		private static void PreloadAllTablesAsync()
		{
		}

		private static string FallbackMissing(string table, string key)
		{
			return null;
		}
	}
}
