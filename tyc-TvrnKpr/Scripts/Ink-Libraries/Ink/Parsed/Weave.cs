using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Ink.Runtime;

namespace Ink.Parsed
{
	public class Weave : Object
	{
		public class GatherPointToResolve
		{
			public Ink.Runtime.Divert divert;

			public Ink.Runtime.Object targetRuntimeObj;
		}

		public delegate void BadTerminationHandler(Object terminatingObj);

		[CompilerGenerated]
		private sealed class _003CContentThatFollowsWeavePoint_003Ed__29 : IEnumerable<Object>, IEnumerable, IEnumerator<Object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Object _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private IWeavePoint weavePoint;

			public IWeavePoint _003C_003E3__weavePoint;

			public Weave _003C_003E4__this;

			private Object _003Cobj_003E5__2;

			private Weave _003CparentWeave_003E5__3;

			private List<Object>.Enumerator _003C_003E7__wrap3;

			private int _003Ci_003E5__5;

			Object IEnumerator<Object>.Current
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
			public _003CContentThatFollowsWeavePoint_003Ed__29(int _003C_003E1__state)
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
			IEnumerator<Object> IEnumerable<Object>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public List<IWeavePoint> looseEnds;

		public List<GatherPointToResolve> gatherPointsToResolve;

		private IWeavePoint previousWeavePoint;

		private bool addContentToPreviousWeavePoint;

		private bool hasSeenChoiceInSection;

		private int _unnamedGatherCount;

		private int _choiceCount;

		private Container _rootContainer;

		private Dictionary<string, IWeavePoint> _namedWeavePoints;

		public Container rootContainer => null;

		private Container currentContainer { get; set; }

		public int baseIndentIndex { get; private set; }

		public Object lastParsedSignificantObject => null;

		public Weave(List<Object> cont, int indentIndex = -1)
		{
		}

		public void ResolveWeavePointNaming()
		{
		}

		private void ConstructWeaveHierarchyFromIndentation()
		{
		}

		public int DetermineBaseIndentationFromContent(List<Object> contentList)
		{
			return 0;
		}

		public override Ink.Runtime.Object GenerateRuntimeObject()
		{
			return null;
		}

		private void AddRuntimeForGather(Gather gather)
		{
		}

		private void AddRuntimeForWeavePoint(IWeavePoint weavePoint)
		{
		}

		public void AddRuntimeForNestedWeave(Weave nestedResult)
		{
		}

		private void AddGeneralRuntimeContent(Ink.Runtime.Object content)
		{
		}

		private void PassLooseEndsToAncestors()
		{
		}

		private void ReceiveLooseEnd(IWeavePoint childWeaveLooseEnd)
		{
		}

		public override void ResolveReferences(Story context)
		{
		}

		public IWeavePoint WeavePointNamed(string name)
		{
			return null;
		}

		private bool IsGlobalDeclaration(Object obj)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CContentThatFollowsWeavePoint_003Ed__29))]
		private IEnumerable<Object> ContentThatFollowsWeavePoint(IWeavePoint weavePoint)
		{
			return null;
		}

		public void ValidateTermination(BadTerminationHandler badTerminationHandler)
		{
		}

		private void BadNestedTerminationHandler(Object terminatingObj)
		{
		}

		private void ValidateFlowOfObjectsTerminates(IEnumerable<Object> objFlow, Object defaultObj, BadTerminationHandler badTerminationHandler)
		{
		}

		private bool WeavePointHasLooseEnd(IWeavePoint weavePoint)
		{
			return false;
		}

		private void CheckForWeavePointNamingCollisions()
		{
		}
	}
}
