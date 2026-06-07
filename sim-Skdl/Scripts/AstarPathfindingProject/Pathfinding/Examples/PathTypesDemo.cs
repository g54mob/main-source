using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Pathfinding.Examples
{
	[HelpURL("http://arongranberg.com/astar/documentation/stable/class_pathfinding_1_1_examples_1_1_path_types_demo.php")]
	public class PathTypesDemo : MonoBehaviour
	{
		public enum DemoMode
		{
			ABPath = 0,
			MultiTargetPath = 1,
			RandomPath = 2,
			FleePath = 3,
			ConstantPath = 4,
			FloodPath = 5,
			FloodPathTracer = 6
		}

		[CompilerGenerated]
		private sealed class _003CDemoConstantPath_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PathTypesDemo _003C_003E4__this;

			private ConstantPath _003CconstPath_003E5__2;

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
			public _003CDemoConstantPath_003Ed__22(int _003C_003E1__state)
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
		private sealed class _003CDemoMultiTargetPath_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PathTypesDemo _003C_003E4__this;

			private MultiTargetPath _003Cmp_003E5__2;

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
			public _003CDemoMultiTargetPath_003Ed__21(int _003C_003E1__state)
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

		public DemoMode activeDemo;

		public Transform start;

		public Transform end;

		public Vector3 pathOffset;

		public Material lineMat;

		public Material squareMat;

		public float lineWidth;

		public int searchLength;

		public int spread;

		public float aimStrength;

		private Path lastPath;

		private FloodPath lastFloodPath;

		private List<GameObject> lastRender;

		private List<Vector3> multipoints;

		private void Update()
		{
		}

		public void OnGUI()
		{
		}

		public void OnPathComplete(Path p)
		{
		}

		private void ClearPrevious()
		{
		}

		private void OnDestroy()
		{
		}

		private void DemoPath()
		{
		}

		[IteratorStateMachine(typeof(_003CDemoMultiTargetPath_003Ed__21))]
		private IEnumerator DemoMultiTargetPath()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CDemoConstantPath_003Ed__22))]
		public IEnumerator DemoConstantPath()
		{
			return null;
		}
	}
}
