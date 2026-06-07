using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;

public class ConveyorFlow : MonoBehaviour
{
	public class FlowNode
	{
		public Vector3 Position;

		public List<FlowNode> Connections = new List<FlowNode>();

		public FlowNode(Vector3 p)
		{
			Position = p;
		}
	}

	public static ConveyorFlow Instance;

	public Mesh FlowMesh;

	public Material FlowMat;

	public float Width = 1f;

	public float UVSpeed = 1f;

	[NonSerialized]
	private Matrix4x4[] _transforms = new Matrix4x4[512];

	[NonSerialized]
	private float[] _uvs;

	[NonSerialized]
	private MaterialPropertyBlock _props;

	[NonSerialized]
	private int _count;

	private float _uvPos;

	private bool _dirty = true;

	private bool _running;

	private int _lastFloor;

	private float _offTimer = -1f;

	private void Awake()
	{
		_props = new MaterialPropertyBlock();
		_uvs = new float[_transforms.Length];
		Instance = this;
	}

	private void OnDestroy()
	{
		FlowMat.mainTextureOffset = Vector2.zero;
		Instance.FlowMat.SetFloat("_Alpha", 1f);
	}

	public static void Toggle(bool on)
	{
		if (Instance != null)
		{
			if (on)
			{
				Instance.enabled = on;
				Instance._offTimer = -1f;
				Instance.FlowMat.SetFloat("_Alpha", 1f);
			}
			else if (Instance._offTimer < 0f)
			{
				Instance._offTimer = 4f;
			}
		}
	}

	public static void CreateFlow(ConveyorFlow parent, List<Conveyor> conveyors)
	{
		lock (parent)
		{
			parent._running = true;
		}
		Dictionary<Conveyor, FlowNode> dictionary = new Dictionary<Conveyor, FlowNode>();
		HashSet<FlowNode> hashSet = new HashSet<FlowNode>();
		for (int i = 0; i < conveyors.Count; i++)
		{
			CreateNode(conveyors[i], dictionary);
		}
		if (dictionary.Count == 0)
		{
			lock (parent._transforms)
			{
				parent._count = 0;
			}
		}
		else
		{
			foreach (KeyValuePair<Conveyor, FlowNode> item in dictionary)
			{
				hashSet.Clear();
				Straighten(item.Value, 0, null, hashSet);
			}
			int num = 0;
			foreach (KeyValuePair<Conveyor, FlowNode> item2 in dictionary)
			{
				for (int j = 0; j < item2.Value.Connections.Count; j++)
				{
					FlowNode flowNode = item2.Value.Connections[j];
					Vector3 pos = (flowNode.Position + item2.Value.Position) * 0.5f;
					Vector3 vector = flowNode.Position - item2.Value.Position;
					Quaternion q = Quaternion.LookRotation(vector);
					float magnitude = vector.magnitude;
					pos -= vector / magnitude * parent.Width * 0.5f;
					lock (parent._transforms)
					{
						parent._transforms[num] = Matrix4x4.TRS(pos, q, new Vector3(parent.Width, parent.Width, magnitude));
						parent._uvs[num] = magnitude;
						num = (parent._count = num + 1);
						if (num >= parent._transforms.Length)
						{
							break;
						}
					}
				}
				if (num >= parent._transforms.Length)
				{
					break;
				}
			}
			if (num == 0)
			{
				lock (parent._transforms)
				{
					parent._count = 0;
				}
			}
		}
		lock (parent)
		{
			parent._running = false;
		}
	}

	public static void SetFlowDirty()
	{
		if (Instance != null)
		{
			Instance.SetDirty();
		}
	}

	public void SetDirty()
	{
		_dirty = true;
	}

	private void OnEnable()
	{
		SetDirty();
	}

	private void Update()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		if (_offTimer >= 0f)
		{
			_offTimer -= Time.deltaTime;
			Instance.FlowMat.SetFloat("_Alpha", Mathf.Min(1f, _offTimer));
			if (_offTimer < 0f)
			{
				base.enabled = false;
				return;
			}
		}
		_uvPos -= Time.deltaTime * UVSpeed;
		if (_uvPos < 0f)
		{
			_uvPos = 1f + _uvPos;
		}
		FlowMat.mainTextureOffset = new Vector2(0f, _uvPos);
		if (_dirty)
		{
			bool running;
			lock (this)
			{
				running = _running;
			}
			if (running)
			{
				return;
			}
			_lastFloor = GameSettings.Instance.ActiveFloor;
			_dirty = false;
			ThreadPool.QueueUserWorkItem(delegate(object o)
			{
				CreateFlow((ConveyorFlow)o, GameSettings.Instance.sRoomManager.AllFurniture.WhereSelect((Furniture x) => x.HasConveyor && x.GetFloor() == _lastFloor, (Furniture x) => x.Conveyor).ToList());
			}, this);
		}
		else if (_lastFloor != GameSettings.Instance.ActiveFloor)
		{
			SetDirty();
		}
	}

	private void OnPreCull()
	{
		lock (_transforms)
		{
			if (_count <= 0)
			{
				return;
			}
			if (SystemInfo.supportsInstancing)
			{
				_props.SetFloatArray("_Offset", _uvs);
				Graphics.DrawMeshInstanced(FlowMesh, 0, FlowMat, _transforms, _count, _props, ShadowCastingMode.Off);
				return;
			}
			for (int i = 0; i < _count; i++)
			{
				_props.SetFloat("_Offset", _uvs[i]);
				Graphics.DrawMesh(FlowMesh, _transforms[i], FlowMat, 0, CameraScript.Instance.mainCam, 0, _props, ShadowCastingMode.Off);
			}
		}
	}

	private static bool Straighten(FlowNode n, int p, FlowNode from, HashSet<FlowNode> visited)
	{
		if (from == null || visited.Add(n))
		{
			if (from != null)
			{
				bool result = false;
				if (from.Connections[p] != n)
				{
					Vector3 normalized = (from.Connections[p].Position - from.Position).normalized;
					Vector3 normalized2 = (n.Position - from.Connections[p].Position).normalized;
					if (!(Vector3.Angle(normalized, normalized2) < 5f))
					{
						return false;
					}
					from.Connections.RemoveAt(p);
					from.Connections.Add(n);
					p = from.Connections.Count - 1;
					result = true;
				}
				for (int i = 0; i < n.Connections.Count; i++)
				{
					if (Straighten(n.Connections[i], p, from, visited))
					{
						n.Connections.RemoveAt(i);
						result = true;
						break;
					}
				}
				return result;
			}
			for (int j = 0; j < n.Connections.Count; j++)
			{
				Straighten(n.Connections[j], j, n, visited);
			}
		}
		return false;
	}

	private static FlowNode CreateNode(Conveyor c, Dictionary<Conveyor, FlowNode> nodes)
	{
		FlowNode value = null;
		if (c.AllowFlow && !nodes.TryGetValue(c, out value))
		{
			value = (nodes[c] = new FlowNode(c.CachedConnectionPos));
			for (int i = 0; i < c.OutputLength; i++)
			{
				Conveyor output = c.GetOutput(i);
				if (output != null && output.AllowFlow)
				{
					value.Connections.Add(CreateNode(output, nodes));
				}
			}
		}
		return value;
	}
}
