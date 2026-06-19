using UnityEngine;
using UnityEngine.Events;

namespace Battlehub.SplineEditor
{
	public class SplineFollow : MonoBehaviour
	{
		public float Speed = 5f;

		public SplineBase Spline;

		public float Offset;

		public bool IsRunning = true;

		public bool IsLoop;

		public ForkEvent Fork;

		public UnityEvent Completed;

		private SplineBase m_spline;

		private bool m_isRunning;

		private bool m_isCompleted;

		private float m_t;

		private int m_curveIndex;

		private void Start()
		{
			if (!Spline)
			{
				Debug.LogError("Set Spline Field!");
				base.enabled = false;
			}
			else
			{
				m_isCompleted = true;
			}
		}

		private void Update()
		{
			if (IsRunning != m_isRunning)
			{
				if (m_isCompleted)
				{
					Restart();
				}
				m_isRunning = IsRunning;
			}
			if (IsRunning)
			{
				Move();
			}
		}

		private void Restart()
		{
			m_spline = Spline;
			m_t = Offset % 1f;
			m_curveIndex = Spline.ToCurveIndex(m_t);
			m_isCompleted = false;
			IsRunning = true;
		}

		private void Move()
		{
			int num = m_spline.ToCurveIndex(m_t);
			if (m_curveIndex != num || m_t >= 1f)
			{
				CheckBranches(num);
			}
			float t = m_t;
			UpdatePosition(t);
			float magnitude = m_spline.GetVelocity(t).magnitude;
			magnitude *= (float)m_spline.CurveCount;
			if (m_t >= 1f)
			{
				if (m_spline.NextSpline != null)
				{
					int nextControlPointIndex = m_spline.NextControlPointIndex;
					m_curveIndex = nextControlPointIndex / 3;
					m_spline = m_spline.NextSpline;
					if (m_spline.NextControlPointIndex > 0)
					{
						m_t = (float)m_curveIndex / (float)m_spline.CurveCount;
						m_curveIndex++;
					}
					else
					{
						m_t = (float)m_curveIndex / (float)m_spline.CurveCount;
					}
					Debug.Log("Next Spline " + m_curveIndex);
					CheckBranches(m_curveIndex);
					return;
				}
				m_t = m_t - 1f + Time.deltaTime * Speed / magnitude;
				if (!m_spline.Loop && !IsLoop)
				{
					m_t = 1f;
					m_isCompleted = true;
					IsRunning = false;
					m_isRunning = false;
					Completed.Invoke();
				}
				if (IsLoop && m_spline != Spline)
				{
					Restart();
				}
			}
			else
			{
				m_t += Time.deltaTime * Speed / magnitude;
			}
		}

		private void CheckBranches(int curveIndex)
		{
			int num = curveIndex * 3;
			if (m_t >= 1f)
			{
				num += 3;
			}
			m_curveIndex = curveIndex;
			if (m_spline.HasBranches(num))
			{
				ForkEventArgs e = new ForkEventArgs(m_spline, num);
				Fork.Invoke(e);
				if (e.SelectBranchIndex > -1 && e.SelectBranchIndex < e.Branches.Length)
				{
					Debug.Log("CurveIndex " + m_curveIndex);
					Debug.Log("Selected Branch " + e.SelectBranchIndex);
					m_spline = e.Branches[e.SelectBranchIndex];
					m_t = 0f;
					m_curveIndex = 0;
				}
			}
		}

		private void UpdatePosition(float t)
		{
			Vector3 point = m_spline.GetPoint(t);
			Vector3 direction = m_spline.GetDirection(t);
			float twist = m_spline.GetTwist(t);
			base.transform.position = point;
			base.transform.LookAt(point + direction);
			base.transform.RotateAround(point, direction, twist);
		}
	}
}
