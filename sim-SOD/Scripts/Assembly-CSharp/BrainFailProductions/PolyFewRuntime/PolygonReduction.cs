using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BrainFailProductions.PolyFewRuntime
{
	public class PolygonReduction : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CShowMessage_003Ed__40 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public string message;

			public PolygonReduction _003C_003E4__this;

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
			public _003CShowMessage_003Ed__40(int _003C_003E1__state)
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
		private sealed class _003CUpdateProgress_003Ed__42 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PolygonReduction _003C_003E4__this;

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
			public _003CUpdateProgress_003Ed__42(int _003C_003E1__state)
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

		public Slider reductionStrength;

		public Slider preservationStrength;

		public Toggle preserveUVFoldover;

		public Toggle preserveUVSeams;

		public Toggle preserveBorders;

		public Toggle enableSmartLinking;

		public Toggle preserveFace;

		public Toggle recalculateNormals;

		public Toggle regardCurvature;

		public InputField trianglesCount;

		public Text message;

		public Text progress;

		public Button exportButton;

		public Button importFromFileSystem;

		public Button importFromWeb;

		public Slider progressSlider;

		public GameObject uninteractivePanel;

		public GameObject targetObject;

		public Transform preservationSphere;

		public EventSystem eventSystem;

		private PolyfewRuntime.ObjectMeshPairs objectMeshPairs;

		private bool didApplyLosslessLast;

		private bool disableTemporary;

		private GameObject barabarianRef;

		private PolyfewRuntime.ReferencedNumeric<float> downloadProgress;

		private bool isImportingFromNetwork;

		private bool isWebGL;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void OnReductionChange(float value)
		{
		}

		public void SimplifyLossless()
		{
		}

		public void ImportOBJ()
		{
		}

		public void ImportOBJFromNetwork()
		{
		}

		public void ExportGameObjectToOBJ()
		{
		}

		public void OnToggleStateChanged(bool isOn)
		{
		}

		public void OnPreservationStrengthChange(float value)
		{
		}

		public void Reset()
		{
		}

		public static void OnSliderSelect()
		{
		}

		public static void OnSliderDeselect()
		{
		}

		private bool IsMouseOverUI(RectTransform uiElement)
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CShowMessage_003Ed__40))]
		private IEnumerator ShowMessage(string message)
		{
			return null;
		}

		private void ResetSettings()
		{
		}

		[IteratorStateMachine(typeof(_003CUpdateProgress_003Ed__42))]
		private IEnumerator UpdateProgress()
		{
			return null;
		}

		private void AssignMeshesFromPairs()
		{
		}
	}
}
