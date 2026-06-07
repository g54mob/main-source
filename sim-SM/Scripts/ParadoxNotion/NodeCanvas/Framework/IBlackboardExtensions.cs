using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ParadoxNotion.Design;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[SpoofAOT]
	public static class IBlackboardExtensions
	{
		[CompilerGenerated]
		private sealed class _003CGetAllParents_003Ed__1 : IEnumerable<IBlackboard>, IEnumerable, IEnumerator<IBlackboard>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private IBlackboard _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IBlackboard blackboard;

			public IBlackboard _003C_003E3__blackboard;

			private bool includeSelf;

			public bool _003C_003E3__includeSelf;

			private IBlackboard _003Ccurrent_003E5__2;

			IBlackboard IEnumerator<IBlackboard>.Current
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
			public _003CGetAllParents_003Ed__1(int _003C_003E1__state)
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

			[DebuggerHidden]
			IEnumerator<IBlackboard> IEnumerable<IBlackboard>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		[CompilerGenerated]
		private sealed class _003CGetVariables_003Ed__14 : IEnumerable<Variable>, IEnumerable, IEnumerator<Variable>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Variable _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IBlackboard blackboard;

			public IBlackboard _003C_003E3__blackboard;

			private Type ofType;

			public Type _003C_003E3__ofType;

			private IEnumerator<Variable> _003C_003E7__wrap1;

			private Dictionary<string, Variable>.Enumerator _003C_003E7__wrap2;

			Variable IEnumerator<Variable>.Current
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
			public _003CGetVariables_003Ed__14(int _003C_003E1__state)
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

			private void _003C_003Em__Finally2()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			[DebuggerHidden]
			IEnumerator<Variable> IEnumerable<Variable>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static IBlackboard GetRoot(this IBlackboard blackboard)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllParents_003Ed__1))]
		public static IEnumerable<IBlackboard> GetAllParents(this IBlackboard blackboard, bool includeSelf)
		{
			return null;
		}

		public static bool IsPartOf(this IBlackboard blackboard, IBlackboard child)
		{
			return false;
		}

		public static Variable<T> AddVariable<T>(this IBlackboard blackboard, string varName, T value)
		{
			return null;
		}

		public static Variable<T> AddVariable<T>(this IBlackboard blackboard, string varName)
		{
			return null;
		}

		public static Variable AddVariable(this IBlackboard blackboard, string varName, object value)
		{
			return null;
		}

		public static Variable AddVariable(this IBlackboard blackboard, string varName, Type type)
		{
			return null;
		}

		public static Variable RemoveVariable(this IBlackboard blackboard, string varName)
		{
			return null;
		}

		public static T GetVariableValue<T>(this IBlackboard blackboard, string varName)
		{
			return default(T);
		}

		public static Variable SetVariableValue(this IBlackboard blackboard, string varName, object value)
		{
			return null;
		}

		public static void InitializePropertiesBinding(this IBlackboard blackboard, Component target, bool callSetter)
		{
		}

		public static Variable<T> GetVariable<T>(this IBlackboard blackboard, string varName)
		{
			return null;
		}

		public static Variable GetVariable(this IBlackboard blackboard, string varName, Type ofType = null)
		{
			return null;
		}

		public static Variable GetVariableByID(this IBlackboard blackboard, string ID)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetVariables_003Ed__14))]
		public static IEnumerable<Variable> GetVariables(this IBlackboard blackboard, Type ofType = null)
		{
			return null;
		}

		public static Variable ChangeVariableType(this IBlackboard blackboard, Variable target, Type newType)
		{
			return null;
		}

		public static void OverwriteFrom(this IBlackboard blackboard, IBlackboard sourceBlackboard, bool removeMissingVariables = true)
		{
		}
	}
}
