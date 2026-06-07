using System;
using System.Collections.Generic;
using UnityEngine;

namespace RotaryHeart.Lib.UnityGLDebug
{
	[RequireComponent(typeof(Camera))]
	public class GLDebug : MonoBehaviour
	{
		private struct Line
		{
			public Vector3 start;

			public Vector3 end;

			public Color color;

			public float startTime;

			public float duration;

			public bool depthTest;

			public Line(Vector3 start, Vector3 end, Color color, float startTime, float duration, bool depthTest)
			{
				this.start = start;
				this.end = end;
				this.color = color;
				this.startTime = startTime;
				this.duration = duration;
				this.depthTest = depthTest;
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

		private static GLDebug m_INSTANCE = null;

		private static Material m_MATZON = null;

		private static Material m_MATZOFF = null;

		private List<Line> m_lines;

		public bool displayLines = true;

		public Shader zOnShader;

		public Shader zOffShader;

		public static GLDebug Instance
		{
			get
			{
				if (m_INSTANCE == null)
				{
					Camera main = Camera.main;
					if (main == null)
					{
						throw new Exception("Couldn't find any main camera to attach the GLDebug script. System will not work");
					}
					m_INSTANCE = main.gameObject.AddComponent<GLDebug>();
				}
				return m_INSTANCE;
			}
		}

		private void Awake()
		{
			SetMaterial();
			m_lines = new List<Line>();
			if (m_INSTANCE == null)
			{
				m_INSTANCE = this;
			}
			else if (m_INSTANCE != this)
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		private void SetMaterial()
		{
			if (m_MATZON == null)
			{
				if (zOnShader == null)
				{
					Shader shader = Shader.Find("Debug/GLlineZOn");
					m_MATZON = new Material(shader);
				}
				else
				{
					m_MATZON = new Material(zOnShader);
				}
				m_MATZON.hideFlags = HideFlags.HideAndDontSave;
				m_MATZON.shader.hideFlags = HideFlags.HideAndDontSave;
			}
			if (m_MATZOFF == null)
			{
				if (zOffShader == null)
				{
					Shader shader2 = Shader.Find("Debug/GLlineZOff");
					m_MATZOFF = new Material(shader2);
				}
				else
				{
					m_MATZOFF = new Material(zOffShader);
				}
				m_MATZOFF.hideFlags = HideFlags.HideAndDontSave;
				m_MATZOFF.shader.hideFlags = HideFlags.HideAndDontSave;
			}
		}

		private void OnPostRender()
		{
			if (!displayLines)
			{
				return;
			}
			m_MATZON.SetPass(0);
			GL.Begin(1);
			for (int num = m_lines.Count - 1; num >= 0; num--)
			{
				if (m_lines[num].depthTest && m_lines[num].DurationElapsed(drawLine: true))
				{
					m_lines.RemoveAt(num);
				}
			}
			GL.End();
			m_MATZOFF.SetPass(0);
			GL.Begin(1);
			for (int num2 = m_lines.Count - 1; num2 >= 0; num2--)
			{
				if (!m_lines[num2].depthTest && m_lines[num2].DurationElapsed(drawLine: true))
				{
					m_lines.RemoveAt(num2);
				}
			}
			GL.End();
		}

		private static void _DrawLine(Vector3 start, Vector3 end, Color color, float duration, bool depthTest)
		{
			if ((duration != 0f || Instance.displayLines) && !(start == end))
			{
				Instance.m_lines.Add(new Line(start, end, color, Time.time, duration, depthTest));
			}
		}

		public static void DrawLine(Vector3 start, Vector3 end, Color? color = null, float duration = 0f, bool depthTest = false)
		{
			_DrawLine(start, end, color ?? Color.white, duration, depthTest);
		}

		public static void DrawRay(Vector3 start, Vector3 dir, Color? color = null, float duration = 0f, bool depthTest = false)
		{
			if (!(dir == Vector3.zero))
			{
				DrawLine(start, start + dir, color, duration, depthTest);
			}
		}
	}
}
