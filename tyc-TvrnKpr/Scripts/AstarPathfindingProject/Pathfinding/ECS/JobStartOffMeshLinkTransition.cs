using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Entities;
using Unity.Mathematics;

namespace Pathfinding.ECS
{
	public struct JobStartOffMeshLinkTransition
	{
		[CompilerGenerated]
		private sealed class _003CDefaultOnTraverseOffMeshLink_003Ed__1 : IEnumerable<object>, IEnumerable, IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private AgentOffMeshLinkTraversalContext ctx;

			public AgentOffMeshLinkTraversalContext _003C_003E3__ctx;

			private OffMeshLinks.OffMeshLinkTracer _003ClinkInfo_003E5__2;

			private quaternion _003Crot_003E5__3;

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
			public _003CDefaultOnTraverseOffMeshLink_003Ed__1(int _003C_003E1__state)
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
			IEnumerator<object> IEnumerable<object>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public EntityCommandBuffer commandBuffer;

		[IteratorStateMachine(typeof(_003CDefaultOnTraverseOffMeshLink_003Ed__1))]
		public static IEnumerable<object> DefaultOnTraverseOffMeshLink(AgentOffMeshLinkTraversalContext ctx)
		{
			return null;
		}
	}
}
