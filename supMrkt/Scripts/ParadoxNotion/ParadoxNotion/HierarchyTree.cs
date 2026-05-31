using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ParadoxNotion
{
	public class HierarchyTree
	{
		public class Element
		{
			[CompilerGenerated]
			private sealed class _003CGetAllChildrenReferencesOfType_003Ed__15<T> : IEnumerable<T>, IEnumerable, IEnumerator<T>, IEnumerator, IDisposable
			{
				private int _003C_003E1__state;

				private T _003C_003E2__current;

				private int _003C_003El__initialThreadId;

				public Element _003C_003E4__this;

				private int _003Ci_003E5__2;

				private Element _003Celement_003E5__3;

				private IEnumerator<T> _003C_003E7__wrap3;

				T IEnumerator<T>.Current
				{
					[DebuggerHidden]
					get
					{
						return default(T);
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
				public _003CGetAllChildrenReferencesOfType_003Ed__15(int _003C_003E1__state)
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
				IEnumerator<T> IEnumerable<T>.GetEnumerator()
				{
					return null;
				}

				[DebuggerHidden]
				IEnumerator IEnumerable.GetEnumerator()
				{
					return null;
				}
			}

			private object _reference;

			private Element _parent;

			private List<Element> _children;

			public object reference => null;

			public Element parent => null;

			public IEnumerable<Element> children => null;

			public Element(object reference)
			{
			}

			public Element AddChild(Element child)
			{
				return null;
			}

			public void RemoveChild(Element child)
			{
			}

			public Element GetRoot()
			{
				return null;
			}

			public Element FindReferenceElement(object target)
			{
				return null;
			}

			public T GetFirstParentReferenceOfType<T>()
			{
				return default(T);
			}

			[IteratorStateMachine(typeof(_003CGetAllChildrenReferencesOfType_003Ed__15<>))]
			public IEnumerable<T> GetAllChildrenReferencesOfType<T>()
			{
				return null;
			}
		}
	}
}
