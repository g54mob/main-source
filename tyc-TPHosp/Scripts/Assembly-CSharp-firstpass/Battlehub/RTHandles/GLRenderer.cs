using System.Collections.Generic;
using UnityEngine;

namespace Battlehub.RTHandles
{
	[ExecuteInEditMode]
	public class GLRenderer : MonoBehaviour
	{
		private static GLRenderer m_instance;

		private List<IGL> m_renderObjects;

		public static GLRenderer Instance => m_instance;

		public void Add(IGL gl)
		{
			if (!m_renderObjects.Contains(gl))
			{
				m_renderObjects.Add(gl);
			}
		}

		public void Remove(IGL line)
		{
			m_renderObjects.Remove(line);
		}

		private void Awake()
		{
			if (m_instance != null)
			{
				Debug.LogWarning("Another instance of GLLinesRenderer aleready exist");
			}
			m_instance = this;
			m_renderObjects = new List<IGL>();
		}

		private void OnDestroy()
		{
			m_instance = null;
		}

		public void Draw()
		{
			if (m_renderObjects == null)
			{
				return;
			}
			GL.PushMatrix();
			try
			{
				for (int i = 0; i < m_renderObjects.Count; i++)
				{
					m_renderObjects[i].Draw();
				}
			}
			finally
			{
				GL.PopMatrix();
			}
		}
	}
}
