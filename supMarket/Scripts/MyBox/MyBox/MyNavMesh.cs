using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

namespace MyBox
{
	public static class MyNavMesh
	{
		[CompilerGenerated]
		private sealed class _003CGetPointsOnPath_003Ed__3 : IEnumerable<Vector3>, IEnumerable, IEnumerator<Vector3>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Vector3 _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private NavMeshPath path;

			public NavMeshPath _003C_003E3__path;

			private float distance;

			public float _003C_003E3__distance;

			private float _003CpieceTraversedDistance_003E5__2;

			private int _003Ci_003E5__3;

			private Vector3 _003Cfrom_003E5__4;

			private Vector3 _003Cto_003E5__5;

			private float _003CpieceLength_003E5__6;

			Vector3 IEnumerator<Vector3>.Current
			{
				[DebuggerHidden]
				get
				{
					return default(Vector3);
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
			public _003CGetPointsOnPath_003Ed__3(int _003C_003E1__state)
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
			IEnumerator<Vector3> IEnumerable<Vector3>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static float GetLength(this NavMeshPath path)
		{
			return 0f;
		}

		public static float GetTimeToPass(this NavMeshPath path, float speed)
		{
			return 0f;
		}

		public static Vector3 GetPointOnPath(this NavMeshPath path, float rate)
		{
			return default(Vector3);
		}

		[IteratorStateMachine(typeof(_003CGetPointsOnPath_003Ed__3))]
		public static IEnumerable<Vector3> GetPointsOnPath(this NavMeshPath path, float distance = 1f)
		{
			return null;
		}
	}
}
