using System;
using UnityEngine;

namespace Battlehub.SplineEditor
{
	[Serializable]
	public struct SplineSnapshot
	{
		[SerializeField]
		private Vector3SerialziableArray m_points;

		[SerializeField]
		private ControlPointSetting[] m_controlPointSettings;

		[SerializeField]
		private ControlPointMode[] m_modes;

		[SerializeField]
		private bool m_loop;

		public int CurveCount => (m_points.Count - 1) / 3;

		public Vector3SerialziableArray Points => m_points;

		public ControlPointSetting[] ControlPointSettings => m_controlPointSettings;

		public ControlPointMode[] Modes => m_modes;

		public bool Loop => m_loop;

		public SplineSnapshot(Vector3[] points, ControlPointSetting[] settings, ControlPointMode[] modes, bool loop)
		{
			int num = (points.Length - 1) / 3;
			int num2 = (points.Length - 1) / 2;
			int num3 = num * 3 + 1;
			num++;
			if (num < 1)
			{
				throw new ArgumentException("too few points. at least 4 required");
			}
			m_points = points;
			if (num3 != m_points.Count)
			{
				Array.Resize(ref points, num3);
			}
			m_controlPointSettings = settings;
			if (num2 != m_controlPointSettings.Length)
			{
				Array.Resize(ref settings, num2);
			}
			m_modes = modes;
			if (num != m_modes.Length)
			{
				Array.Resize(ref m_modes, num);
			}
			m_loop = loop;
		}
	}
}
