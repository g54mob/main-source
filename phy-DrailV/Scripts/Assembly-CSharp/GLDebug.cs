using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GLDebug : MonoBehaviour
{
	private struct Line
	{
		public Vector3 start;

		public Vector3 end;

		public Color color;

		public float startTime;

		public float duration;

		public Line(Vector3 start, Vector3 end, Color color, float startTime, float duration)
		{
			this.start = start;
			this.end = end;
			this.color = color;
			this.startTime = startTime;
			this.duration = duration;
		}

		public bool DurationElapsed(bool drawLine)
		{
			if (drawLine)
			{
				GL.Color(color);
				GL.Vertex(start);
				GL.Vertex(end);
			}
			return Time.time - startTime >= duration;
		}
	}

	private static GLDebug _instance;

	private static Material matZOn;

	private static Material matZOff;

	public KeyCode toggleKey;

	public bool displayLines = true;

	private List<Line> linesZOn;

	private List<Line> linesZOff;

	private static GLDebug Instance
	{
		get
		{
			if (_instance == null)
			{
				_instance = Object.FindObjectOfType<GLDebug>();
			}
			if (_instance == null)
			{
				if (Camera.main == null)
				{
					Debug.LogError("Tried to auto-create GLDebug component but couldn't find a camera object to attach it to.");
					return null;
				}
				_instance = Camera.main.gameObject.AddComponent<GLDebug>();
			}
			return _instance;
		}
	}

	private void Awake()
	{
		if ((bool)_instance)
		{
			Object.DestroyImmediate(this);
			return;
		}
		_instance = this;
		GetMaterials();
		linesZOn = new List<Line>();
		linesZOff = new List<Line>();
	}

	private void GetMaterials()
	{
		matZOn = Resources.Load<Material>("GLDebugZOn");
		matZOff = Resources.Load<Material>("GLDebugZOff");
	}

	private void Update()
	{
		if (Input.GetKeyDown(toggleKey))
		{
			displayLines = !displayLines;
		}
		if (!displayLines)
		{
			linesZOn = linesZOn.Where((Line l) => !l.DurationElapsed(drawLine: false)).ToList();
			linesZOff = linesZOff.Where((Line l) => !l.DurationElapsed(drawLine: false)).ToList();
		}
	}

	private void OnPostRender()
	{
		if (displayLines)
		{
			matZOn.SetPass(0);
			GL.Begin(1);
			linesZOn = linesZOn.Where((Line l) => !l.DurationElapsed(drawLine: true)).ToList();
			GL.End();
			matZOff.SetPass(0);
			GL.Begin(1);
			linesZOff = linesZOff.Where((Line l) => !l.DurationElapsed(drawLine: true)).ToList();
			GL.End();
		}
	}

	private static void DrawLine(Vector3 start, Vector3 end, Color color, float duration = 0f, bool depthTest = false)
	{
		if ((duration != 0f || Instance.displayLines) && !(start == end))
		{
			if (depthTest)
			{
				Instance.linesZOn.Add(new Line(start, end, color, Time.time, duration));
			}
			else
			{
				Instance.linesZOff.Add(new Line(start, end, color, Time.time, duration));
			}
		}
	}

	public static void DrawLine(Vector3 start, Vector3 end, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		DrawLine(start, end, color ?? Color.white, duration, depthTest);
	}

	public static void DrawRay(Vector3 start, Vector3 dir, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		if (!(dir == Vector3.zero))
		{
			DrawLine(start, start + dir, color, duration, depthTest);
		}
	}

	public static void DrawLineArrow(Vector3 start, Vector3 end, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		DrawArrow(start, end - start, arrowHeadLength, arrowHeadAngle, color, duration, depthTest);
	}

	public static void DrawArrow(Vector3 start, Vector3 dir, float arrowHeadLength = 0.25f, float arrowHeadAngle = 20f, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		if (!(dir == Vector3.zero))
		{
			DrawRay(start, dir, color, duration, depthTest);
			Vector3 vector = Quaternion.LookRotation(dir) * Quaternion.Euler(0f, 180f + arrowHeadAngle, 0f) * Vector3.forward;
			Vector3 vector2 = Quaternion.LookRotation(dir) * Quaternion.Euler(0f, 180f - arrowHeadAngle, 0f) * Vector3.forward;
			DrawRay(start + dir, vector * arrowHeadLength, color, duration, depthTest);
			DrawRay(start + dir, vector2 * arrowHeadLength, color, duration, depthTest);
		}
	}

	public static void DrawSquare(Vector3 pos, Vector3? rot = null, Vector3? scale = null, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		DrawSquare(Matrix4x4.TRS(pos, Quaternion.Euler(rot ?? Vector3.zero), scale ?? Vector3.one), color, duration, depthTest);
	}

	public static void DrawSquare(Vector3 pos, Quaternion? rot = null, Vector3? scale = null, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		DrawSquare(Matrix4x4.TRS(pos, rot ?? Quaternion.identity, scale ?? Vector3.one), color, duration, depthTest);
	}

	public static void DrawSquare(Matrix4x4 matrix, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		Vector3 vector = matrix.MultiplyPoint3x4(new Vector3(0.5f, 0f, 0.5f));
		Vector3 vector2 = matrix.MultiplyPoint3x4(new Vector3(0.5f, 0f, -0.5f));
		Vector3 vector3 = matrix.MultiplyPoint3x4(new Vector3(-0.5f, 0f, -0.5f));
		Vector3 vector4 = matrix.MultiplyPoint3x4(new Vector3(-0.5f, 0f, 0.5f));
		DrawLine(vector, vector2, color, duration, depthTest);
		DrawLine(vector2, vector3, color, duration, depthTest);
		DrawLine(vector3, vector4, color, duration, depthTest);
		DrawLine(vector4, vector, color, duration, depthTest);
	}

	public static void DrawCube(Vector3 pos, Vector3? rot = null, Vector3? scale = null, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		DrawCube(Matrix4x4.TRS(pos, Quaternion.Euler(rot ?? Vector3.zero), scale ?? Vector3.one), color, duration, depthTest);
	}

	public static void DrawCube(Vector3 pos, Quaternion? rot = null, Vector3? scale = null, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		DrawCube(Matrix4x4.TRS(pos, rot ?? Quaternion.identity, scale ?? Vector3.one), color, duration, depthTest);
	}

	public static void DrawCube(Matrix4x4 matrix, Color? color = null, float duration = 0f, bool depthTest = false)
	{
		Vector3 vector = matrix.MultiplyPoint3x4(new Vector3(0.5f, -0.5f, 0.5f));
		Vector3 vector2 = matrix.MultiplyPoint3x4(new Vector3(0.5f, -0.5f, -0.5f));
		Vector3 vector3 = matrix.MultiplyPoint3x4(new Vector3(-0.5f, -0.5f, -0.5f));
		Vector3 vector4 = matrix.MultiplyPoint3x4(new Vector3(-0.5f, -0.5f, 0.5f));
		Vector3 vector5 = matrix.MultiplyPoint3x4(new Vector3(0.5f, 0.5f, 0.5f));
		Vector3 vector6 = matrix.MultiplyPoint3x4(new Vector3(0.5f, 0.5f, -0.5f));
		Vector3 vector7 = matrix.MultiplyPoint3x4(new Vector3(-0.5f, 0.5f, -0.5f));
		Vector3 vector8 = matrix.MultiplyPoint3x4(new Vector3(-0.5f, 0.5f, 0.5f));
		DrawLine(vector, vector2, color, duration, depthTest);
		DrawLine(vector2, vector3, color, duration, depthTest);
		DrawLine(vector3, vector4, color, duration, depthTest);
		DrawLine(vector4, vector, color, duration, depthTest);
		DrawLine(vector, vector5, color, duration, depthTest);
		DrawLine(vector2, vector6, color, duration, depthTest);
		DrawLine(vector3, vector7, color, duration, depthTest);
		DrawLine(vector4, vector8, color, duration, depthTest);
		DrawLine(vector5, vector6, color, duration, depthTest);
		DrawLine(vector6, vector7, color, duration, depthTest);
		DrawLine(vector7, vector8, color, duration, depthTest);
		DrawLine(vector8, vector5, color, duration, depthTest);
	}
}
