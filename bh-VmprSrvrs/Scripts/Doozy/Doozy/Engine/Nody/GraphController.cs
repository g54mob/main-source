using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody
{
	[AddComponentMenu("Doozy/Nody/Graph Controller", 13)]
	[DefaultExecutionOrder(-100)]
	public class GraphController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CActivateStartOrEnterNodeEnumerator_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GraphController _003C_003E4__this;

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
			public _003CActivateStartOrEnterNodeEnumerator_003Ed__34(int _003C_003E1__state)
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

		private const string DEFAULT_CONTROLLER_NAME = "";

		private const bool DEFAULT_DONT_DESTROY_CONTROLLER_ON_LOAD = true;

		public static readonly List<GraphController> Database;

		public bool DebugMode;

		public string ControllerName;

		public bool DontDestroyControllerOnLoad;

		[SerializeField]
		private Graph m_graphModel;

		private Graph m_graph;

		private static UILanguagePack UILabels => null;

		public Graph Graph => null;

		public Graph GraphModel => null;

		public bool Initialized { get; private set; }

		private bool DebugComponent => false;

		private void Reset()
		{
		}

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public virtual void OnDestroy()
		{
		}

		private void Update()
		{
		}

		private void FixedUpdate()
		{
		}

		private void LateUpdate()
		{
		}

		public void GoToNode(Node node)
		{
		}

		public void GoToNodeByName(string nodeName)
		{
		}

		public void GoToNodeById(string nodeId)
		{
		}

		private void InitializeGraph(bool reset = true)
		{
		}

		private void ResetController()
		{
		}

		[IteratorStateMachine(typeof(_003CActivateStartOrEnterNodeEnumerator_003Ed__34))]
		private IEnumerator ActivateStartOrEnterNodeEnumerator()
		{
			return null;
		}

		public static GraphController AddToScene(bool selectGameObjectAfterCreation = false)
		{
			return null;
		}

		public static GraphController Get(string controllerName)
		{
			return null;
		}
	}
}
