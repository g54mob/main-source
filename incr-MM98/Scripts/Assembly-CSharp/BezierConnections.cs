using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasRenderer))]
public class BezierConnections : Graphic
{
	private class Connection
	{
		public readonly ConnectionNode From;

		public readonly ConnectionNode To;

		public readonly List<Pulse> Pulses = new List<Pulse>();

		public Connection(ConnectionNode from, ConnectionNode to)
		{
			From = from;
			To = to;
		}

		public void AddPulse(float speed, float length)
		{
			Pulses.Add(new Pulse(speed, length));
		}
	}

	private class ConnectionNode
	{
		public readonly Datacenter Datacenter;

		public readonly RectTransform RectTransform;

		public DatacenterState State;

		public Vector3 Position => RectTransform.position;

		public ConnectionNode(DatacenterVisualizer visualizer)
		{
			Datacenter = visualizer.datacenter;
			RectTransform = visualizer.GetComponent<RectTransform>();
			State = Database.State.Datacenters.GetState(Datacenter);
		}
	}

	private class Pulse
	{
		public float Progress;

		public readonly float Speed;

		public readonly float Length;

		public Pulse(float speed, float length)
		{
			Progress = 0f;
			Speed = speed;
			Length = length;
		}
	}

	[SerializeField]
	private int curveResolution = 32;

	[SerializeField]
	private float curveHeight = 80f;

	[SerializeField]
	private float lineThickness = 4f;

	[SerializeField]
	private bool dashedLine;

	[SerializeField]
	private Color pulseColor = Color.yellow;

	private readonly Dictionary<Datacenter, ConnectionNode> _nodes = new Dictionary<Datacenter, ConnectionNode>();

	private readonly List<Connection> _connections = new List<Connection>();

	protected override void Awake()
	{
		base.Awake();
		if (!material)
		{
			material = Graphic.defaultGraphicMaterial;
		}
	}

	private void Update()
	{
		bool flag = false;
		foreach (Connection connection in _connections)
		{
			for (int num = connection.Pulses.Count - 1; num >= 0; num--)
			{
				Pulse pulse = connection.Pulses[num];
				pulse.Progress += pulse.Speed * Time.deltaTime;
				if (pulse.Progress > 1f)
				{
					connection.Pulses.RemoveAt(num);
					flag = true;
				}
				else
				{
					connection.Pulses[num] = pulse;
					flag = true;
				}
			}
		}
		if (flag)
		{
			SetVerticesDirty();
		}
	}

	private void Redraw()
	{
		SetVerticesDirty();
	}

	public void SendRandomPulse(float speed = 0.5f, float length = 0.1f)
	{
		_connections[Random.Range(0, _connections.Count)].AddPulse(speed, length);
	}

	public void AddConnection(DatacenterVisualizer from, DatacenterVisualizer to)
	{
		ConnectionNode orCreateNode = GetOrCreateNode(from);
		ConnectionNode orCreateNode2 = GetOrCreateNode(to);
		_connections.Add(new Connection(orCreateNode, orCreateNode2));
		SetVerticesDirty();
	}

	public void UpdateState(Datacenter datacenter, DatacenterState state)
	{
		_nodes[datacenter].State = state;
		SetVerticesDirty();
	}

	protected override void OnPopulateMesh(VertexHelper vh)
	{
		vh.Clear();
		if (_connections.Count == 0 || curveResolution < 2)
		{
			return;
		}
		foreach (Connection connection in _connections)
		{
			DrawConnection(vh, connection);
		}
	}

	private void DrawConnection(VertexHelper vh, Connection connection)
	{
		DatacenterState state = connection.From.State;
		if (state == DatacenterState.Unprovisioned || state == DatacenterState.Construction)
		{
			state = connection.To.State;
			if (state == DatacenterState.Unprovisioned || state == DatacenterState.Construction)
			{
				return;
			}
		}
		Vector2 start = WorldToLocal(connection.From.Position);
		Vector2 end = WorldToLocal(connection.To.Position);
		Color a = connection.From.State.Value();
		Color b = connection.To.State.Value();
		Vector2 control = CalculateControlPoint(start, end);
		Vector2 start2 = EvaluateBezier(0f, start, control, end);
		for (int i = 1; i < curveResolution; i++)
		{
			float t = (float)i / (float)(curveResolution - 1);
			Vector2 vector = EvaluateBezier(t, start, control, end);
			if (!dashedLine || i % 2 == 0)
			{
				AddLineSegment(vh, start2, vector, Color.Lerp(a, b, t));
			}
			start2 = vector;
		}
		foreach (Pulse pulse in connection.Pulses)
		{
			DrawPulse(vh, start, control, end, pulse);
		}
	}

	private void DrawPulse(VertexHelper vh, Vector2 start, Vector2 control, Vector2 end, Pulse pulse)
	{
		float num = Mathf.Max(0f, pulse.Progress - pulse.Length);
		float progress = pulse.Progress;
		int num2 = Mathf.Max(2, Mathf.RoundToInt((float)curveResolution * pulse.Length));
		Vector2 start2 = EvaluateBezier(num, start, control, end);
		for (int i = 1; i < num2; i++)
		{
			Vector2 vector = EvaluateBezier(Mathf.Lerp(num, progress, (float)i / (float)(num2 - 1)), start, control, end);
			AddLineSegment(vh, start2, vector, pulseColor);
			start2 = vector;
		}
	}

	private Vector2 WorldToLocal(Vector3 worldPosition)
	{
		RectTransformUtility.ScreenPointToLocalPointInRectangle(base.rectTransform, RectTransformUtility.WorldToScreenPoint(null, worldPosition), null, out var localPoint);
		return localPoint;
	}

	private Vector2 CalculateControlPoint(Vector2 start, Vector2 end)
	{
		Vector2 vector = (start + end) * 0.5f;
		Vector2 normalized = (end - start).normalized;
		Vector2 vector2 = new Vector2(0f - normalized.y, normalized.x);
		if (vector2.y < 0f)
		{
			vector2 = -vector2;
		}
		return vector + vector2 * curveHeight;
	}

	private static Vector2 EvaluateBezier(float t, Vector2 start, Vector2 control, Vector2 end)
	{
		float num = 1f - t;
		return num * num * start + 2f * num * t * control + t * t * end;
	}

	private void AddLineSegment(VertexHelper vh, Vector2 start, Vector2 end, Color lineColor)
	{
		Vector2 normalized = (end - start).normalized;
		Vector2 vector = new Vector2(0f - normalized.y, normalized.x) * (lineThickness * 0.5f);
		Vector2 vector2 = start + vector;
		Vector2 vector3 = start - vector;
		Vector2 vector4 = end - vector;
		Vector2 vector5 = end + vector;
		int currentVertCount = vh.currentVertCount;
		vh.AddVert(vector2, lineColor, Vector2.zero);
		vh.AddVert(vector3, lineColor, Vector2.zero);
		vh.AddVert(vector4, lineColor, Vector2.zero);
		vh.AddVert(vector5, lineColor, Vector2.zero);
		vh.AddTriangle(currentVertCount, currentVertCount + 1, currentVertCount + 2);
		vh.AddTriangle(currentVertCount, currentVertCount + 2, currentVertCount + 3);
	}

	private ConnectionNode GetOrCreateNode(DatacenterVisualizer visualizer)
	{
		if (_nodes.TryGetValue(visualizer.datacenter, out var value))
		{
			return value;
		}
		value = new ConnectionNode(visualizer);
		_nodes.Add(visualizer.datacenter, value);
		return value;
	}
}
