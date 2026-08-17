using System;
using System.Collections;
using System.Collections.Generic;
using Cpp2ILInjected;
using Doozy.Engine.Nody.Models;
using Doozy.Engine.Settings;
using Doozy.Engine.Utils;
using UnityEngine;

namespace Doozy.Engine.Nody;

public class GraphController : MonoBehaviour
{
	private sealed class _003CActivateStartOrEnterNodeEnumerator_003Ed__34(int _003C_003E1__state) : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state = _003C_003E1__state;

		private object _003C_003E2__current;

		public GraphController _003C_003E4__this;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0062: Expected I4, but got I8
			//IL_0201: Expected I4, but got O
			GraphController graphController = _003C_003E4__this;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
			if (_003C_003E1__state == 1)
			{
				_003C_003E1__state = -1;
				if ((object)_003C_003E4__this != null)
				{
					graphController._003CInitialized_003Ek__BackingField = (byte)_003C_003E1__state != 0;
					Graph graphModel = graphController.m_graphModel;
					if ((object)graphController.m_graphModel != null)
					{
						Node node = graphModel._003CActiveNode_003Ek__BackingField;
						if ((object)graphModel._003CActiveNode_003Ek__BackingField != null && ((UnityEngine.Object)node).m_CachedPtr != (IntPtr)0)
						{
							goto IL_022d;
						}
						Graph graphModel2 = graphController.m_graphModel;
						if ((object)graphController.m_graphModel != null)
						{
							graphModel2._003CPreviousActiveNode_003Ek__BackingField = null;
							Node node2 = ((!graphModel2.m_isSubGraph) ? graphController.m_graphModel.GetStartNode() : graphController.m_graphModel.GetEnterNode());
							graphModel2._003CActiveNode_003Ek__BackingField = node2;
							Node node3 = graphModel2._003CActiveNode_003Ek__BackingField;
							if ((object)graphModel2._003CActiveNode_003Ek__BackingField != null)
							{
								node3.m_activeGraph = graphController.m_graphModel;
								if ((object)graphModel2._003CActiveNode_003Ek__BackingField != null)
								{
									graphModel2._003CActiveNode_003Ek__BackingField.OnEnter(null, null);
									goto IL_022d;
								}
							}
						}
					}
				}
				NullReferenceException ex = new NullReferenceException();
				return (byte)(int)ex != 0;
			}
			goto IL_022d;
			IL_022d:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			NotSupportedException ex = new NotSupportedException();
			throw ex;
		}
	}

	private const string DEFAULT_CONTROLLER_NAME = "";

	private const bool DEFAULT_DONT_DESTROY_CONTROLLER_ON_LOAD = true;

	public static readonly List<GraphController> Database;

	private bool _003CInitialized_003Ek__BackingField = false;

	public bool DebugMode;

	public string ControllerName;

	public bool DontDestroyControllerOnLoad;

	private Graph m_graphModel;

	private Graph m_graph;

	private static UILanguagePack UILabels => UILanguagePack.Instance;

	public Graph Graph => m_graphModel;

	public Graph GraphModel => m_graphModel;

	public bool Initialized
	{
		get
		{
			return _003CInitialized_003Ek__BackingField;
		}
		private set
		{
			_003CInitialized_003Ek__BackingField = value;
		}
	}

	private bool DebugComponent
	{
		get
		{
			//IL_0063: Expected I4, but got O
			if (DebugMode)
			{
				return true;
			}
			DoozySettings instance = DoozySettings.Instance;
			if ((object)instance != null)
			{
				return instance.DebugGraphController;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	private void Reset()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [189980B09]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		ControllerName = "";
		DontDestroyControllerOnLoad = true;
	}

	private void Awake()
	{
		Graph graphModel = m_graphModel;
		string message2;
		if ((object)m_graphModel != null && ((UnityEngine.Object)graphModel).m_CachedPtr != (IntPtr)0)
		{
			List<Node> nodes = m_graphModel.Nodes;
			if (nodes._size != 0)
			{
				if (!DebugMode)
				{
					DoozySettings instance = DoozySettings.Instance;
					if (!instance.DebugGraphController)
					{
						goto IL_0343;
					}
				}
				UILanguagePack instance2 = UILanguagePack.Instance;
				string text = ((UnityEngine.Object)m_graphModel).GetName();
				string message = instance2.LoadedGraph + ": " + text;
				DDebug.Log(message);
				goto IL_0343;
			}
			string[] array = new string[7];
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			string text2 = ((UnityEngine.Object)m_graphModel).GetName();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UILanguagePack instance3 = UILanguagePack.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			UILanguagePack instance4 = UILanguagePack.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
			message2 = string.Concat(array);
		}
		else
		{
			UILanguagePack instance5 = UILanguagePack.Instance;
			UILanguagePack instance6 = UILanguagePack.Instance;
			message2 = instance5.NoGraphReferenced + ". " + instance6.ComponentDisabled + ".";
		}
		GameObject context = base.gameObject;
		DDebug.LogError(message2, context);
		base.enabled = false;
		return;
		IL_0343:
		List<object> database = (List<object>)(object)Database;
		int version = database._version + 1;
		database._version = version;
		object[] items = database._items;
		if (database._size >= items.Length)
		{
			database.AddWithResize((object)this);
		}
		else
		{
			int size = database._size + 1;
			database._size = size;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		InitializeGraph();
		if (DontDestroyControllerOnLoad)
		{
			GameObject target = base.gameObject;
			UnityEngine.Object.DontDestroyOnLoad(target);
		}
	}

	private void OnEnable()
	{
		Graph graphModel = m_graphModel;
		if ((object)m_graphModel != null && ((UnityEngine.Object)graphModel).m_CachedPtr != (IntPtr)0)
		{
			m_graphModel.Enabled = true;
		}
	}

	private void OnDisable()
	{
		Graph graphModel = m_graphModel;
		if ((object)m_graphModel != null && ((UnityEngine.Object)graphModel).m_CachedPtr != (IntPtr)0)
		{
			m_graphModel.Enabled = false;
		}
	}

	public virtual void OnDestroy()
	{
		bool flag = ((List<object>)(object)Database).Remove((object)this);
	}

	private void Update()
	{
		Graph graphModel = m_graphModel;
		if ((object)m_graphModel != null && ((UnityEngine.Object)graphModel).m_CachedPtr != (IntPtr)0)
		{
			m_graphModel.Update();
		}
	}

	private void FixedUpdate()
	{
		Graph graphModel = m_graphModel;
		if ((object)m_graphModel != null && ((UnityEngine.Object)graphModel).m_CachedPtr != (IntPtr)0)
		{
			m_graphModel.FixedUpdate();
		}
	}

	private void LateUpdate()
	{
		Graph graphModel = m_graphModel;
		if ((object)m_graphModel != null && ((UnityEngine.Object)graphModel).m_CachedPtr != (IntPtr)0)
		{
			m_graphModel.LateUpdate();
		}
	}

	public void GoToNode(Node node)
	{
		Graph graphModel = m_graphModel;
		if ((object)m_graphModel == null || ((UnityEngine.Object)graphModel).m_CachedPtr == (IntPtr)0 || (object)node == null || ((UnityEngine.Object)node).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		List<Node> nodes = m_graphModel.Nodes;
		if (nodes == null)
		{
			return;
		}
		List<Node> nodes2 = m_graphModel.Nodes;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049D500");
		object obj = default(object);
		if (obj == null)
		{
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGraphController)
			{
				goto IL_0124;
			}
		}
		string message = "GoTo Node: " + node.m_name;
		DDebug.Log(message, this);
		goto IL_0124;
		IL_0124:
		m_graphModel.SetActiveNode(node);
	}

	public void GoToNodeByName(string nodeName)
	{
		Graph graphModel = m_graphModel;
		if ((object)m_graphModel == null || ((UnityEngine.Object)graphModel).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Node nodeByName = m_graphModel.GetNodeByName(nodeName);
		if ((object)nodeByName == null || ((UnityEngine.Object)nodeByName).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGraphController)
			{
				goto IL_00f2;
			}
		}
		string message = "GoTo Node by Name: " + nodeName;
		DDebug.Log(message, this);
		goto IL_00f2;
		IL_00f2:
		m_graphModel.SetActiveNode(nodeByName);
	}

	public void GoToNodeById(string nodeId)
	{
		Graph graphModel = m_graphModel;
		if ((object)m_graphModel == null || ((UnityEngine.Object)graphModel).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Node nodeById = m_graphModel.GetNodeById(nodeId);
		if ((object)nodeById == null || ((UnityEngine.Object)nodeById).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		if (!DebugMode)
		{
			DoozySettings instance = DoozySettings.Instance;
			if (!instance.DebugGraphController)
			{
				goto IL_00f2;
			}
		}
		string message = "GoTo Node by Id: " + nodeId;
		DDebug.Log(message, this);
		goto IL_00f2;
		IL_00f2:
		m_graphModel.SetActiveNode(nodeById);
	}

	private void InitializeGraph(bool reset = true)
	{
		//IL_0311: Expected O, but got F4
		Graph graphModel = m_graphModel;
		object obj = Time.realtimeSinceStartup;
		List<Node> activatedNodesHistory = graphModel.m_activatedNodesHistory;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm1,xmm0\"");
		graphModel.m_infiniteLoopTimerStart = 0.0;
		int version = activatedNodesHistory._version + 1;
		activatedNodesHistory._version = version;
		activatedNodesHistory._size = 0;
		if (activatedNodesHistory._size > 0)
		{
			Array.Clear(activatedNodesHistory._items, 0, activatedNodesHistory._size);
		}
		if (reset)
		{
			_003CInitialized_003Ek__BackingField = false;
			m_graphModel.SetActiveNode(null);
			m_graphModel.DeactivateGlobalNodes();
		}
		if (_003CInitialized_003Ek__BackingField)
		{
			return;
		}
		Graph graphModel2 = m_graphModel;
		UnityEngine.Object context;
		object message;
		if ((object)m_graphModel != null && ((UnityEngine.Object)graphModel2).m_CachedPtr != (IntPtr)0)
		{
			List<Node> nodes = m_graphModel.Nodes;
			bool flag = nodes._size == 0;
			UnityEngine.Object graphModel3 = m_graphModel;
			string text;
			string text2;
			if (!flag)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ rcx_v21 (UnityEngine.Object)+90]");
				Node node = (((nint)0 == 0) ? m_graphModel.GetStartNode() : m_graphModel.GetEnterNode());
				if ((object)node != null && ((UnityEngine.Object)node).m_CachedPtr != (IntPtr)0)
				{
					_003CActivateStartOrEnterNodeEnumerator_003Ed__34 obj2 = null;
					obj2._003C_003E1__state = 0;
					obj2._003C_003E4__this = this;
					Coroutine coroutine = StartCoroutine(obj2);
					return;
				}
				text = ((UnityEngine.Object)m_graphModel).GetName();
				text2 = "No start node has been set for the '";
			}
			else
			{
				text = ((UnityEngine.Object)m_graphModel).GetName();
				text2 = "No nodes have been added to the '";
			}
			string text3 = text2 + text + "' Graph.";
			context = this;
			message = text3;
		}
		else
		{
			context = this;
			message = "Missing Graph reference...";
		}
		DDebug.LogError(message, context);
	}

	private void ResetController()
	{
		_003CInitialized_003Ek__BackingField = false;
		m_graphModel.SetActiveNode(null);
		m_graphModel.DeactivateGlobalNodes();
	}

	private IEnumerator ActivateStartOrEnterNodeEnumerator()
	{
		_003CActivateStartOrEnterNodeEnumerator_003Ed__34 obj = null;
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	public static GraphController AddToScene(bool selectGameObjectAfterCreation = false)
	{
		return DoozyUtils.AddToScene<GraphController>("Graph Controller", isSingleton: false, selectGameObjectAfterCreation);
	}

	public static GraphController Get(string controllerName)
	{
		if (controllerName != null && controllerName._stringLength > 0)
		{
			List<GraphController> database = Database;
			if (Database == null)
			{
				goto IL_01cb;
			}
			if (database._size != 0)
			{
				if (Database == null)
				{
					goto IL_01cb;
				}
				List<GraphController>.Enumerator enumerator = default(List<GraphController>.Enumerator);
				if (enumerator.MoveNext())
				{
					GraphController graphController = null;
					throw new NullReferenceException();
				}
			}
		}
		return null;
		IL_01cb:
		return (GraphController)(object)new NullReferenceException();
	}

	static GraphController()
	{
		List<GraphController> database = new List<GraphController>();
		Database = database;
	}
}
