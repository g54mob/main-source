using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using Gh.Tk;
using LitJson;
using UnityEngine;

namespace Gh
{
	public class TavernLog : IPersistable
	{
		public abstract class LogEntry : IPersistable
		{
			public string logType;

			public float timestamp;

			protected LogEntry()
			{
			}

			protected LogEntry(string logType)
			{
			}
		}

		public class GenericLogEntry<T> : LogEntry
		{
			public T value;

			public GenericLogEntry()
			{
			}

			public GenericLogEntry(string logType, T value)
			{
			}
		}

		public class TransactionLogEntry : GenericLogEntry<int>
		{
			public int balance;

			public string category;

			public string reason;

			public TransactionLogEntry()
			{
			}

			public TransactionLogEntry(int value, int balance, string category, string reasonKey)
			{
			}
		}

		public class TavernEventLogEntry : GenericLogEntry<string>, IReferenceableObject
		{
			private int _contextId;

			[JsonIgnore]
			private WeakReference<GameObjectX> _contextTarget;

			private Vector3 _contextInitialPosition;

			[JsonIgnore]
			private bool _targetIsSet;

			public bool CausedByRandomEvent { get; set; }

			public TavernEventType EventType { get; set; }

			public int Id { get; private set; }

			protected TavernEventLogEntry()
			{
			}

			public TavernEventLogEntry(string value, TavernEventType type, GameObjectX context)
			{
			}

			private GameObjectX GetTarget()
			{
				return null;
			}

			public string GetDisplayString(bool includeTimestamp = false)
			{
				return null;
			}

			public bool IsTargetSet()
			{
				return false;
			}

			public bool IsTargetActive()
			{
				return false;
			}

			public void Focus()
			{
			}

			public bool CanGroupWith(TavernEventLogEntry other)
			{
				return false;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetDailyTransactionLogs_003Ed__12 : IEnumerable<TransactionLogEntry>, IEnumerable, IEnumerator<TransactionLogEntry>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private TransactionLogEntry _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private int daysAgo;

			public int _003C_003E3__daysAgo;

			public TavernLog _003C_003E4__this;

			private float _003CearliestTime_003E5__2;

			private List<LogEntry>.Enumerator _003C_003E7__wrap2;

			TransactionLogEntry IEnumerator<TransactionLogEntry>.Current
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
			public _003CGetDailyTransactionLogs_003Ed__12(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<TransactionLogEntry> IEnumerable<TransactionLogEntry>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		private static bool _isRandomEventScope;

		public List<LogEntry> AllLogs { get; private set; }

		public static bool IsRandomEventScope => false;

		public void LogTransaction(int money, int balance, string category, string reasonKey)
		{
		}

		public void LogVisitor(int id)
		{
		}

		public void AddTavernEventToLog(string value, TavernEventType eventType, GameObjectX context, bool causedByRandomEvent)
		{
		}

		public static void LogTavernEvent(string value, TavernEventType type, GameObjectX context, bool? causedByRandomEvent = null)
		{
		}

		[IteratorStateMachine(typeof(_003CGetDailyTransactionLogs_003Ed__12))]
		public IEnumerable<TransactionLogEntry> GetDailyTransactionLogs(int daysAgo)
		{
			return null;
		}

		public IEnumerable<IGrouping<int, TransactionLogEntry>> GetDailyTransactionLogsGroupedByDay(int dayRange)
		{
			return null;
		}

		public static IDisposable BeginRandomEventScope()
		{
			return null;
		}
	}
}
