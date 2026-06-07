using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace TinyGiantStudio.Text.Example
{
	public class StatusToolTip : MonoBehaviour
	{
		[Serializable]
		public class Styles
		{
			public GameObject textPrefab;

			public Vector3 offsetMin;

			public Vector3 offsetMax;
		}

		[CompilerGenerated]
		private sealed class _003CDestroyObj_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float duration;

			public GameObject obj;

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
			public _003CDestroyObj_003Ed__12(int _003C_003E1__state)
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

		public List<Styles> styles;

		[Space]
		[Space]
		public float defaultDuration;

		[Tooltip("This uses itself as pool holder, not poolmanager like the text and the text prefabs MUST have unique names because that's what is used for pool key")]
		public bool pooling;

		public Dictionary<string, Queue<GameObject>> poolDictionary;

		public void ShowToolTip(string text, int style, Vector3 position, Quaternion rotation, bool worldPosition)
		{
		}

		public void ShowToolTip(string text, int style, Vector3 position, Quaternion rotation, bool worldPosition, float duration)
		{
		}

		private GameObject GetIObj(int style)
		{
			return null;
		}

		private GameObject GetNewObj(int style)
		{
			return null;
		}

		private void SetPosition(Transform objTransform, int style, Vector3 position, Quaternion rotation, bool worldPosition)
		{
		}

		private Vector3 RandomVector3(Vector3 min, Vector3 max)
		{
			return default(Vector3);
		}

		private void ApplyText(string text, GameObject obj)
		{
		}

		[IteratorStateMachine(typeof(_003CDestroyObj_003Ed__12))]
		private IEnumerator DestroyObj(GameObject obj, float duration)
		{
			return null;
		}
	}
}
