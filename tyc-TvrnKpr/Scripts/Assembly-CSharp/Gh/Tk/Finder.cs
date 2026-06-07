using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public static class Finder
	{
		[CompilerGenerated]
		private sealed class _003CGetAllChildren_003Ed__14 : IEnumerable<Transform>, IEnumerable, IEnumerator<Transform>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Transform _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Transform transform;

			public Transform _003C_003E3__transform;

			private IEnumerator<Transform> _003C_003E7__wrap1;

			private Transform _003Cchild_003E5__3;

			private IEnumerator<Transform> _003C_003E7__wrap3;

			Transform IEnumerator<Transform>.Current
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
			public _003CGetAllChildren_003Ed__14(int _003C_003E1__state)
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
			IEnumerator<Transform> IEnumerable<Transform>.GetEnumerator()
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
		private sealed class _003CGetChildren_003Ed__13 : IEnumerable<Transform>, IEnumerable, IEnumerator<Transform>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private Transform _003C_003E2__current;

			private int _003C_003El__initialThreadId;

			private Transform transform;

			public Transform _003C_003E3__transform;

			private IEnumerator _003C_003E7__wrap1;

			Transform IEnumerator<Transform>.Current
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
			public _003CGetChildren_003Ed__13(int _003C_003E1__state)
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
			IEnumerator<Transform> IEnumerable<Transform>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}
		}

		public static Transform GetTargetTransformWithinGameObjectX(GameObjectX gox, string gameItemVisualKey, Transform root = null)
		{
			return null;
		}

		public static Transform FindChildTransformByNameWithinGameObjectX(GameObjectX gox, Transform root, string name)
		{
			return null;
		}

		public static List<Transform> FindChildTransformsByNameWithinGameObjectX(GameObjectX gox, Transform root, string name)
		{
			return null;
		}

		private static void FindChildTransformsByNameWithinGameObjectX(GameObjectX gox, Transform root, string name, ref List<Transform> foundTransforms)
		{
		}

		public static Transform GetTargetTransform(Transform root, string gameItemVisualKey)
		{
			return null;
		}

		public static Transform GetChildTransformByName(Transform parent, string name, bool logErrorWhenNotFound = true)
		{
			return null;
		}

		public static Transform FindChildTransformByName(Transform parent, string name)
		{
			return null;
		}

		public static List<Transform> FindChildTransformsByName(Transform parent, string name)
		{
			return null;
		}

		private static void FindChildTransformsByName(Transform parent, string name, ref List<Transform> foundTransforms)
		{
		}

		public static List<Transform> FindChildTransformsWhereNameStartsWith(Transform parent, string name)
		{
			return null;
		}

		private static void FindChildTransformsWhereNameStartsWith(Transform parent, string name, ref List<Transform> foundTransforms)
		{
		}

		public static List<Transform> FindChildTransformsWhereNameEndsWith(Transform parent, string name)
		{
			return null;
		}

		private static void FindChildTransformsWhereNameEndsWith(Transform parent, string name, ref List<Transform> foundTransforms)
		{
		}

		[IteratorStateMachine(typeof(_003CGetChildren_003Ed__13))]
		public static IEnumerable<Transform> GetChildren(this Transform transform)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAllChildren_003Ed__14))]
		public static IEnumerable<Transform> GetAllChildren(this Transform transform)
		{
			return null;
		}

		public static List<Transform> FindChildTransform(Transform parent, Func<Transform, bool> filter)
		{
			return null;
		}

		public static bool IsAnyChildTransformMatchingFilterRecursiveWithinGox(GameObjectX gox, Func<Transform, bool> filter)
		{
			return false;
		}

		public static bool IsAnyChildTransformMatchingFilterRecursive(Transform parent, Func<Transform, bool> filter)
		{
			return false;
		}

		public static Transform FindParentTransformByName(Transform transform, string name)
		{
			return null;
		}

		public static T GetComponentInParent<T>(Transform transform) where T : MonoBehaviour
		{
			return null;
		}
	}
}
