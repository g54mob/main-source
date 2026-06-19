using System;
using System.Collections.Generic;
using System.Linq;
using Battlehub.RTEditor;
using Battlehub.RTHandles;
using UnityEngine;

namespace Battlehub.SplineEditor
{
	[ExecuteInEditMode]
	public class SplineBase : MonoBehaviour, IGL
	{
		private static readonly Color SplineColor = Color.green;

		private static float Smoothness = 5f;

		private static Material m_splineMaterial;

		private static SplineBase m_convergingSpline;

		private static SplineBase m_activeSpline;

		private static int m_activeControlPointIndex = -1;

		[SerializeField]
		[HideInInspector]
		private ControlPointMode[] m_modes;

		[SerializeField]
		[HideInInspector]
		private Vector3[] m_points;

		[SerializeField]
		[HideInInspector]
		private ControlPointSetting[] m_settings;

		[SerializeField]
		[HideInInspector]
		private bool m_loop;

		private bool m_isSelected;

		[SerializeField]
		[HideInInspector]
		private SplineBase m_prevSpline;

		[SerializeField]
		[HideInInspector]
		private int m_prevControlPointIndex;

		[SerializeField]
		[HideInInspector]
		private SplineBase m_nextSpline;

		[SerializeField]
		[HideInInspector]
		private int m_nextControlPointIndex;

		[SerializeField]
		[HideInInspector]
		private SplineBase[] m_branches;

		[SerializeField]
		[HideInInspector]
		private SplineBase m_parent;

		[SerializeField]
		[HideInInspector]
		private SplineBase[] m_children;

		private bool m_isApplicationQuit;

		public static SplineBase ActiveSpline
		{
			get
			{
				return m_activeSpline;
			}
			set
			{
				m_activeSpline = value;
			}
		}

		public static int ActiveControlPointIndex
		{
			get
			{
				return m_activeControlPointIndex;
			}
			set
			{
				m_activeControlPointIndex = value;
			}
		}

		public static SplineBase ConvergingSpline
		{
			get
			{
				return m_convergingSpline;
			}
			set
			{
				if (m_convergingSpline != value)
				{
					m_convergingSpline = value;
					if (SplineBase.ConvergingSplineChanged != null)
					{
						SplineBase.ConvergingSplineChanged(null, EventArgs.Empty);
					}
				}
			}
		}

		public static Material SplineMaterial => m_splineMaterial;

		public static bool SplineMaterialZTest
		{
			get
			{
				return PlayerPrefs.GetInt("Battehub.SplineEditor.SplineMaterialZTest", 0) == 1;
			}
			set
			{
				if (SplineMaterial != null)
				{
					SetSplieMaterialZTest(value);
				}
				PlayerPrefs.SetInt("Battehub.SplineEditor.SplineMaterialZTest", value ? 1 : 0);
			}
		}

		public int NextControlPointIndex => m_nextControlPointIndex;

		public SplineBase NextSpline => m_nextSpline;

		public int PrevControlPointIndex => m_prevControlPointIndex;

		public SplineBase PrevSpline => m_prevSpline;

		public bool IsSelected => m_isSelected;

		public virtual bool Loop
		{
			get
			{
				return m_loop;
			}
			set
			{
				m_loop = value;
				if (m_loop)
				{
					Disconnect(0);
					Disconnect(ControlPointCount - 1);
					if (PrevSpline != null)
					{
						PrevSpline.Disconnect(this, isInbound: false);
					}
					if (NextSpline != null)
					{
						NextSpline.Disconnect(this, isInbound: true);
					}
					ControlPointSetting controlPointSetting = m_settings[m_settings.Length - 1];
					m_settings[0] = new ControlPointSetting(controlPointSetting.Twist, controlPointSetting.Thickness, m_settings[0].Branches);
					m_modes[m_modes.Length - 1] = m_modes[0];
					RaiseControlPointModeChanged(m_modes.Length - 1);
					_SetControlPointLocalUnchecked(m_points.Length - 1, m_points[0]);
				}
			}
		}

		public int CurveCount => (m_points.Length - 1) / 3;

		public int ControlPointCount => m_points.Length;

		public SplineBase Root
		{
			get
			{
				SplineBase splineBase = this;
				while (splineBase.Parent != null)
				{
					splineBase = splineBase.Parent;
				}
				return splineBase;
			}
		}

		public SplineBase Parent => m_parent;

		public SplineBase[] Children => m_children;

		public static event EventHandler ConvergingSplineChanged;

		public event ControlPointChanged ControlPointPositionChanged;

		public event ControlPointChanged ControlPointModeChanged;

		public event ControlPointChanged ControlPointConnectionChanged;

		public event ControlPointChanged ControlPointThicknessChanged;

		public event ControlPointChanged ControlPointTwistChanged;

		private static void SetSplieMaterialZTest(bool value)
		{
			if (value)
			{
				SplineMaterial.SetInt("_ZTest", 4);
			}
			else
			{
				SplineMaterial.SetInt("_ZTest", 8);
			}
		}

		private static void InitSplineMaterial()
		{
			m_splineMaterial = new Material(Shader.Find("Battlehub/SplineEditor/Spline"));
			m_splineMaterial.name = "SplineMaterial";
			m_splineMaterial.color = SplineColor;
			SetSplieMaterialZTest(SplineMaterialZTest);
			if (UnityEngine.Object.FindObjectOfType<GLRenderer>() == null)
			{
				GameObject obj = new GameObject();
				obj.name = "GLRenderer";
				obj.AddComponent<GLRenderer>();
			}
		}

		void IGL.Draw()
		{
			if (m_points.Length < 2)
			{
				return;
			}
			if (m_splineMaterial == null)
			{
				InitSplineMaterial();
			}
			m_splineMaterial.SetPass(0);
			GL.PushMatrix();
			GL.MultMatrix(base.transform.localToWorldMatrix);
			GL.Begin(1);
			Vector3 v = m_points[0];
			for (int i = 1; i < m_points.Length; i += 3)
			{
				Vector3 v2 = m_points[i];
				Vector3 v3 = m_points[i + 1];
				Vector3 vector = m_points[i + 2];
				if (!ConvergingSpline)
				{
					GL.Color(SplineRuntimeEditor.ControlPointLineColor);
					GL.Vertex(v);
					GL.Vertex(v2);
					GL.Color(SplineRuntimeEditor.ControlPointLineColor);
					GL.Vertex(v3);
					GL.Vertex(vector);
				}
				v = vector;
			}
			GL.End();
			GL.Begin(1);
			GL.Color(SplineColor);
			v = m_points[0];
			for (int j = 1; j < m_points.Length; j += 3)
			{
				Vector3 vector2 = m_points[j];
				Vector3 vector3 = m_points[j + 1];
				Vector3 vector4 = m_points[j + 2];
				float num = (v - vector2).magnitude + (vector2 - vector3).magnitude + (vector3 - vector4).magnitude;
				int num2 = Mathf.CeilToInt(Smoothness * num);
				if (num2 <= 0)
				{
					num2 = 1;
				}
				for (int k = 0; k < num2; k++)
				{
					float t = (float)k / (float)num2;
					GL.Vertex(CurveUtils.GetPoint(v, vector2, vector3, vector4, t));
					t = ((float)k + 1f) / (float)num2;
					GL.Vertex(CurveUtils.GetPoint(v, vector2, vector3, vector4, t));
				}
				v = vector4;
			}
			ShowTwistAngles();
			GL.End();
			GL.PopMatrix();
		}

		protected virtual void ShowTwistAngles()
		{
			GL.Color(SplineRuntimeEditor.ControlPointLineColor);
			int num = GetStepsPerCurve() * CurveCount;
			for (int i = 0; i <= num; i++)
			{
				DrawTwistAngle(i, num);
			}
			if (m_activeSpline == this && m_activeControlPointIndex > -1 && m_activeControlPointIndex < m_activeSpline.ControlPointCount)
			{
				GL.Color(SplineColor);
				int val = (m_activeControlPointIndex + 1) / 3;
				val = Math.Min(val, CurveCount - 1);
				num = GetStepsPerCurve() * 5;
				Twist twist = GetTwist(m_activeControlPointIndex);
				int num2 = Mathf.CeilToInt(twist.T1 * (float)num);
				int num3 = Mathf.CeilToInt(twist.T2 * (float)num);
				for (int j = num2; j <= num3; j++)
				{
					DrawTwistAngle(val, j, num);
				}
			}
		}

		private void DrawTwistAngle(int i, int steps)
		{
			float t = (float)i / (float)steps;
			Vector3 direction = GetDirection(t);
			Vector3 pointLocal = GetPointLocal(t);
			float twist = GetTwist(t);
			Vector3 upVector = GetUpVector();
			Vector3 forward = ((!(Math.Abs(Vector3.Dot(direction, upVector)) < 1f)) ? Vector3.Cross(direction, GetSideVector()).normalized : Vector3.Cross(direction, upVector).normalized);
			if (!(direction == Vector3.zero))
			{
				GL.Vertex(pointLocal);
				GL.Vertex(pointLocal + Quaternion.AngleAxis(twist, direction) * Quaternion.LookRotation(forward, upVector) * Vector3.forward * 0.5f);
			}
		}

		private void DrawTwistAngle(int curveIndex, int i, int steps)
		{
			float t = (float)i / (float)steps;
			Vector3 direction = GetDirection(t, curveIndex);
			Vector3 pointLocal = GetPointLocal(t, curveIndex);
			float twist = GetTwist(t, curveIndex);
			Vector3 upVector = GetUpVector();
			Vector3 forward = ((!(Math.Abs(Vector3.Dot(direction, upVector)) < 1f)) ? Vector3.Cross(direction, GetSideVector()).normalized : Vector3.Cross(direction, upVector).normalized);
			if (!(direction == Vector3.zero))
			{
				GL.Vertex(pointLocal);
				GL.Vertex(pointLocal + Quaternion.AngleAxis(twist, direction) * Quaternion.LookRotation(forward, upVector) * Vector3.forward * 0.5f);
			}
		}

		protected virtual int GetStepsPerCurve()
		{
			return 5;
		}

		protected virtual Vector3 GetUpVector()
		{
			return Vector3.up;
		}

		protected virtual Vector3 GetSideVector()
		{
			return Vector3.forward;
		}

		private void RaiseControlPointThicknessChanged(int index)
		{
			if (this.ControlPointThicknessChanged != null)
			{
				this.ControlPointThicknessChanged(index);
			}
		}

		private void RaisControlPointTwistChanged(int index)
		{
			if (this.ControlPointTwistChanged != null)
			{
				this.ControlPointTwistChanged(index);
			}
		}

		private void RaiseControlPointChanged(int index)
		{
			if (this.ControlPointPositionChanged != null)
			{
				this.ControlPointPositionChanged(index);
			}
		}

		private void RaiseControlPointModeChanged(int modeIndex)
		{
			if (this.ControlPointModeChanged != null)
			{
				int num = modeIndex * 3 - 1;
				this.ControlPointModeChanged(num);
				this.ControlPointModeChanged(num + 1);
				this.ControlPointModeChanged(num + 2);
			}
		}

		private void RaiseControlPointConnectionChanged(int index)
		{
			if (this.ControlPointConnectionChanged != null)
			{
				this.ControlPointConnectionChanged(index);
			}
		}

		private void Awake()
		{
			if (m_splineMaterial == null)
			{
				InitSplineMaterial();
			}
			if (m_branches == null)
			{
				m_branches = new SplineBase[0];
			}
			UpdateChildrenAndParent();
			SplineRuntimeEditor.Created += OnRuntimeEditorCreated;
			SplineRuntimeEditor.Destroyed += OnRuntimeEditorDestroyed;
			if (SplineRuntimeEditor.Instance != null && !GetComponent<ExposeToEditor>())
			{
				base.gameObject.AddComponent<ExposeToEditor>();
			}
			SyncArrays();
			AwakeOverride();
		}

		private void OnApplicationQuit()
		{
			m_isApplicationQuit = true;
		}

		private void OnDestroy()
		{
			SplineRuntimeEditor.Created -= OnRuntimeEditorCreated;
			SplineRuntimeEditor.Destroyed -= OnRuntimeEditorDestroyed;
			bool flag = false;
			if (!m_isApplicationQuit && !flag)
			{
				UnselectRecursive(Root);
				if (m_prevSpline != null)
				{
					m_prevSpline.Disconnect(this);
				}
				if (m_nextSpline != null)
				{
					m_nextSpline.Disconnect(this);
				}
			}
			OnDestroyOverride();
		}

		private void OnEnable()
		{
			if (m_isSelected && GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Add(this);
			}
			OnEnableOverride();
		}

		private void OnDisable()
		{
			if (GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Remove(this);
			}
			OnDisableOverride();
		}

		private void Start()
		{
			StartOverride();
			if (PrevSpline != null && (PrevSpline.m_branches == null || !PrevSpline.m_branches.Contains(this)))
			{
				PrevSpline.Connect(this, PrevControlPointIndex, isInbound: false);
			}
			if (NextSpline != null && (NextSpline.m_branches == null || !NextSpline.m_branches.Contains(this)))
			{
				NextSpline.Connect(this, NextControlPointIndex, isInbound: true);
			}
		}

		private void OnTransformChildrenChanged()
		{
			UpdateChildrenAndParent();
		}

		private void OnTransformParentChanged()
		{
			UpdateChildrenAndParent();
		}

		private void Update()
		{
			UpdateOverride();
		}

		private void Reset()
		{
			SplineBase[] branches = m_branches;
			SplineBase nextSpline = m_nextSpline;
			SplineBase prevSpline = m_prevSpline;
			if (branches != null)
			{
				foreach (SplineBase splineBase in branches)
				{
					if (splineBase != null)
					{
						splineBase.Disconnect(this);
					}
				}
			}
			if (nextSpline != null)
			{
				nextSpline.Disconnect(this);
			}
			if (prevSpline != null)
			{
				prevSpline.Disconnect(this);
			}
			m_branches = new SplineBase[0];
			m_nextSpline = null;
			m_nextControlPointIndex = -1;
			m_prevSpline = null;
			m_prevControlPointIndex = -1;
			m_points = new Vector3[4]
			{
				new Vector3(0f, 0f, 0f),
				new Vector3(1f / 3f * GetMag(), 0f, 0f),
				new Vector3(2f / 3f * GetMag(), 0f, 0f),
				new Vector3(1f * GetMag(), 0f, 0f)
			};
			m_settings = new ControlPointSetting[2]
			{
				new ControlPointSetting(new Twist(0f, 0f, 1f), new Thickness(Vector3.one, 0f, 1f), new SplineBranch[0]),
				new ControlPointSetting(new Twist(0f, 0f, 1f), new Thickness(Vector3.one, 0f, 1f), new SplineBranch[0])
			};
			m_modes = new ControlPointMode[2];
			ResetOverride();
			SyncCtrlPoints();
		}

		protected virtual float GetMag()
		{
			return 1f;
		}

		protected virtual void AwakeOverride()
		{
		}

		protected virtual void OnDestroyOverride()
		{
		}

		protected virtual void OnEnableOverride()
		{
		}

		protected virtual void OnDisableOverride()
		{
		}

		protected virtual void StartOverride()
		{
		}

		protected virtual void UpdateOverride()
		{
		}

		protected virtual void ResetOverride()
		{
		}

		private void OnRuntimeEditorCreated(object sender, EventArgs e)
		{
			if (m_isSelected && GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Add(this);
			}
			if ((bool)this && !GetComponent<ExposeToEditor>())
			{
				base.gameObject.AddComponent<ExposeToEditor>();
			}
		}

		private void OnRuntimeEditorDestroyed(object sender, EventArgs e)
		{
			if (GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Remove(this);
			}
			if ((bool)this)
			{
				ExposeToEditor component = GetComponent<ExposeToEditor>();
				if ((bool)component)
				{
					UnityEngine.Object.DestroyImmediate(component);
				}
			}
		}

		private void SyncArrays()
		{
			if (m_points == null || m_points.Length == 0)
			{
				return;
			}
			int num = m_points.Length / 3 + 1;
			if (m_modes.Length != num)
			{
				Debug.Log("Synchronize modes");
				Array.Resize(ref m_modes, num);
			}
			if (m_settings == null)
			{
				m_settings = new ControlPointSetting[0];
			}
			if (m_settings.Length != num)
			{
				Debug.Log("Synchronize settings");
				int num2 = m_settings.Length;
				Array.Resize(ref m_settings, num);
				for (int i = num2; i < m_settings.Length; i++)
				{
					m_settings[i].Thickness = new Thickness(Vector3.one, 0f, 1f);
					m_settings[i].Twist = new Twist(0f, 0f, 1f);
				}
			}
		}

		public void Select()
		{
			if (!m_isSelected)
			{
				SelectRecursive(Root);
			}
		}

		private void SelectRecursive(SplineBase spline)
		{
			if (GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Add(spline);
			}
			SplineControlPoint[] splineControlPoints = spline.GetSplineControlPoints();
			for (int i = 0; i < splineControlPoints.Length; i++)
			{
				splineControlPoints[i].gameObject.SetActive(value: true);
			}
			spline.m_isSelected = true;
			for (int j = 0; j < spline.m_children.Length; j++)
			{
				SelectRecursive(spline.m_children[j]);
			}
		}

		public void Unselect()
		{
			if (m_isSelected)
			{
				UnselectRecursive(Root);
			}
		}

		private void UnselectRecursive(SplineBase spline)
		{
			if (GLRenderer.Instance != null)
			{
				GLRenderer.Instance.Remove(spline);
			}
			SplineControlPoint[] splineControlPoints = spline.GetSplineControlPoints();
			foreach (SplineControlPoint splineControlPoint in splineControlPoints)
			{
				if ((bool)splineControlPoint)
				{
					splineControlPoint.gameObject.SetActive(value: false);
				}
			}
			spline.m_isSelected = false;
			for (int j = 0; j < spline.m_children.Length; j++)
			{
				UnselectRecursive(spline.m_children[j]);
			}
		}

		public Vector3 GetPoint(float t, int curveIndex)
		{
			curveIndex *= 3;
			return base.transform.TransformPoint(CurveUtils.GetPoint(m_points[curveIndex], m_points[curveIndex + 1], m_points[curveIndex + 2], m_points[curveIndex + 3], t));
		}

		public Vector3 GetPointLocal(float t, int curveIndex)
		{
			curveIndex *= 3;
			return CurveUtils.GetPoint(m_points[curveIndex], m_points[curveIndex + 1], m_points[curveIndex + 2], m_points[curveIndex + 3], t);
		}

		public int ToCurveIndex(ref float t)
		{
			int num;
			if (t >= 1f)
			{
				t = 1f;
				num = (m_points.Length - 1) / 3 - 1;
			}
			else
			{
				t = Mathf.Clamp01(t) * (float)CurveCount;
				num = (int)t;
				t -= num;
			}
			return num;
		}

		public int ToCurveIndex(float t)
		{
			int num;
			if (t >= 1f)
			{
				t = 1f;
				num = (m_points.Length - 1) / 3 - 1;
			}
			else
			{
				t = Mathf.Clamp01(t) * (float)CurveCount;
				num = (int)t;
				t -= (float)num;
			}
			return num;
		}

		public Vector3 GetPoint(float t)
		{
			int curveIndex = ToCurveIndex(ref t);
			return GetPoint(t, curveIndex);
		}

		public Vector3 GetPointLocal(float t)
		{
			int curveIndex = ToCurveIndex(ref t);
			return GetPointLocal(t, curveIndex);
		}

		public float GetTwist(float t, int curveIndex)
		{
			Twist twist = m_settings[curveIndex].Twist;
			Twist twist2 = m_settings[curveIndex + 1].Twist;
			float num = Mathf.Clamp01(twist.T1);
			float num2 = Mathf.Clamp01(twist.T2);
			t = ((t <= num) ? 0f : ((!(t >= num2)) ? Mathf.Clamp01((t - num) / (num2 - num)) : 1f));
			return Mathf.Lerp(twist.Data, twist2.Data, t);
		}

		public float GetTwist(float t)
		{
			int curveIndex = ToCurveIndex(ref t);
			return GetTwist(t, curveIndex);
		}

		public Vector3 GetThickness(float t, int curveIndex)
		{
			Thickness thickness = m_settings[curveIndex].Thickness;
			Thickness thickness2 = m_settings[curveIndex + 1].Thickness;
			float num = Mathf.Clamp01(thickness.T1);
			float num2 = Mathf.Clamp01(thickness.T2);
			t = ((t <= num) ? 0f : ((!(t >= num2)) ? Mathf.Clamp01((t - num) / (num2 - num)) : 1f));
			return Vector3.Lerp(thickness.Data, thickness2.Data, t);
		}

		public Vector3 GetThickness(float t)
		{
			int curveIndex = ToCurveIndex(ref t);
			return GetThickness(t, curveIndex);
		}

		public Vector3 GetControlPoint(int index)
		{
			return base.transform.TransformPoint(m_points[index]);
		}

		public Vector3 GetControlPointLocal(int index)
		{
			return m_points[index];
		}

		public ControlPointSetting GetSetting(int index)
		{
			return m_settings[(index + 1) / 3];
		}

		public SplineBranch[] GetBranches(int index)
		{
			return m_settings[(index + 1) / 3].Branches;
		}

		public bool HasBranches(int index)
		{
			int num = (index + 1) / 3;
			if (num >= m_settings.Length || num < 0)
			{
				return false;
			}
			ControlPointSetting controlPointSetting = m_settings[num];
			if (controlPointSetting.Branches == null)
			{
				return false;
			}
			return controlPointSetting.Branches.Length != 0;
		}

		public SplineBase BranchToSpline(SplineBranch branch)
		{
			return m_branches[branch.SplineIndex];
		}

		public Twist GetTwist(int index)
		{
			return m_settings[(index + 1) / 3].Twist;
		}

		public Thickness GetThickness(int index)
		{
			return m_settings[(index + 1) / 3].Thickness;
		}

		public void SetTwist(int index, Twist twist)
		{
			SetValue(index, twist, delegate(int i, Twist val, bool r)
			{
				int num2 = (index + 1) / 3;
				m_settings[num2].Twist = val;
			}, delegate(int i, Twist val, SplineBase branch, bool r)
			{
				branch.SetTwist(i, val);
			}, GetTwist);
			if (m_loop)
			{
				int num = (index + 1) / 3;
				if (num == m_settings.Length - 1)
				{
					ControlPointSetting controlPointSetting = m_settings[m_settings.Length - 1];
					m_settings[0] = new ControlPointSetting(controlPointSetting.Twist, controlPointSetting.Thickness, m_settings[0].Branches);
				}
				else if (num == 0)
				{
					ControlPointSetting controlPointSetting2 = m_settings[0];
					m_settings[m_settings.Length - 1] = new ControlPointSetting(controlPointSetting2.Twist, controlPointSetting2.Thickness, m_settings[m_settings.Length - 1].Branches);
				}
			}
			RaisControlPointTwistChanged(index);
			OnCurveChanged(index, Math.Max(0, (index - 1) / 3));
		}

		public void SetThickness(int index, Thickness thickness)
		{
			SetValue(index, thickness, delegate(int i, Thickness val, bool r)
			{
				int num2 = (index + 1) / 3;
				m_settings[num2].Thickness = val;
			}, delegate(int i, Thickness val, SplineBase branch, bool r)
			{
				branch.SetThickness(i, val);
			}, GetThickness);
			if (m_loop)
			{
				int num = (index + 1) / 3;
				if (num == m_settings.Length - 1)
				{
					ControlPointSetting controlPointSetting = m_settings[m_settings.Length - 1];
					m_settings[0] = new ControlPointSetting(controlPointSetting.Twist, controlPointSetting.Thickness, m_settings[0].Branches);
				}
				else if (num == 0)
				{
					ControlPointSetting controlPointSetting2 = m_settings[0];
					m_settings[m_settings.Length - 1] = new ControlPointSetting(controlPointSetting2.Twist, controlPointSetting2.Thickness, m_settings[m_settings.Length - 1].Branches);
				}
			}
			RaiseControlPointThicknessChanged(index);
			OnCurveChanged(index, Math.Max(0, (index - 1) / 3));
		}

		public bool SetControlPoint(int index, Vector3 point)
		{
			return SetControlPointLocal(index, base.transform.InverseTransformPoint(point));
		}

		private bool _SetControlPointUnchecked(int index, Vector3 point)
		{
			return _SetControlPointLocalUnchecked(index, base.transform.InverseTransformPoint(point));
		}

		public bool SetControlPointLocal(int index, Vector3 point)
		{
			if (IsControlPointLocked(index))
			{
				return false;
			}
			return _SetControlPointLocalUnchecked(index, point);
		}

		private bool _SetControlPointLocalUnchecked(int index, Vector3 point)
		{
			if (index % 3 == 0)
			{
				Vector3 delta = point - m_points[index];
				if (m_loop)
				{
					if (index == 0)
					{
						JustChangeControlPointValue(1, delta);
						RaiseControlPointChanged(1);
						JustChangeControlPointValue(m_points.Length - 2, delta);
						RaiseControlPointChanged(m_points.Length - 2);
						SetControlPointValue(m_points.Length - 1, point);
						RaiseControlPointChanged(m_points.Length - 1);
					}
					else if (index == m_points.Length - 1)
					{
						SetControlPointValue(0, point);
						RaiseControlPointChanged(0);
						JustChangeControlPointValue(1, delta);
						RaiseControlPointChanged(1);
						JustChangeControlPointValue(index - 1, delta);
						RaiseControlPointChanged(index - 1);
					}
					else
					{
						JustChangeControlPointValue(index - 1, delta);
						RaiseControlPointChanged(index - 1);
						JustChangeControlPointValue(index + 1, delta);
						RaiseControlPointChanged(index + 1);
					}
				}
				else
				{
					if (index > 0)
					{
						JustChangeControlPointValue(index - 1, delta);
						RaiseControlPointChanged(index - 1);
					}
					if (index + 1 < m_points.Length)
					{
						JustChangeControlPointValue(index + 1, delta);
						RaiseControlPointChanged(index + 1);
					}
				}
			}
			SetControlPointValue(index, point);
			RaiseControlPointChanged(index);
			EnforceMode(index);
			OnCurveChanged(index, Math.Max(0, (index - 1) / 3));
			return true;
		}

		public ControlPointMode GetControlPointMode(int index)
		{
			return m_modes[(index + 1) / 3];
		}

		public void SetControlPointMode(ControlPointMode mode)
		{
			SetControlPointModeRecursive(this, mode);
		}

		private void SetControlPointModeRecursive(SplineBase spline, ControlPointMode mode)
		{
			for (int i = 0; i <= spline.CurveCount; i++)
			{
				spline.SetControlPointMode(i * 3, mode);
			}
			if (spline.Children != null)
			{
				for (int j = 0; j < spline.Children.Length; j++)
				{
					SetControlPointModeRecursive(spline.Children[j], mode);
				}
			}
		}

		public void SetControlPointMode(int index, ControlPointMode mode, bool raiseCurveChanged = true)
		{
			SetControlPointModeValue(index, mode, raiseCurveChanged);
			int num = (index + 1) / 3;
			RaiseControlPointModeChanged(num);
			if (m_loop)
			{
				if (num == 0)
				{
					SetControlPointModeValue(ControlPointCount - 1, mode, raiseCurveChanged);
					RaiseControlPointModeChanged(m_modes.Length - 1);
				}
				else if (num == m_modes.Length - 1)
				{
					SetControlPointModeValue(0, mode, raiseCurveChanged);
					RaiseControlPointModeChanged(0);
				}
			}
			EnforceMode(index);
			if (raiseCurveChanged)
			{
				OnCurveChanged(index, Math.Max(0, (index - 1) / 3));
			}
		}

		private void SetControlPointModeValue(int index, ControlPointMode mode, bool raiseCurveChanged)
		{
			int num = (index + 1) / 3;
			if (m_modes[num] != mode)
			{
				m_modes[num] = mode;
				SetBranchControlPointModes(index, mode, raiseCurveChanged);
			}
		}

		private void SetBranchControlPointModes(int index, ControlPointMode mode, bool raiseCurveChanged)
		{
			int num = (index + 1) / 3;
			SplineBranch[] branches = m_settings[num].Branches;
			if (branches != null)
			{
				for (int i = 0; i < branches.Length; i++)
				{
					SplineBranch splineBranch = branches[i];
					SplineBase splineBase = m_branches[splineBranch.SplineIndex];
					if (splineBase != null)
					{
						if (splineBranch.Inbound)
						{
							splineBase.SetControlPointMode(splineBase.ControlPointCount - 1, mode, raiseCurveChanged);
						}
						else
						{
							splineBase.SetControlPointMode(0, mode, raiseCurveChanged);
						}
					}
				}
			}
			if (num == 0 && PrevSpline != null)
			{
				PrevSpline.SetControlPointMode(PrevControlPointIndex, mode, raiseCurveChanged);
			}
			if (num == m_settings.Length - 1 && NextSpline != null)
			{
				NextSpline.SetControlPointMode(NextControlPointIndex, mode, raiseCurveChanged);
			}
		}

		public Vector3 GetVelocity(float t, int curveIndex)
		{
			int num = curveIndex * 3;
			return base.transform.TransformVector(CurveUtils.GetFirstDerivative(m_points[num], m_points[num + 1], m_points[num + 2], m_points[num + 3], t));
		}

		public Vector3 GetVelocity(float t)
		{
			int num;
			if (t >= 1f)
			{
				t = 1f;
				num = (m_points.Length - 1) / 3 - 1;
			}
			else
			{
				t = Mathf.Clamp01(t) * (float)CurveCount;
				num = (int)t;
				t -= (float)num;
			}
			return GetVelocity(t, num);
		}

		public Vector3 GetDirection(float t, int curveIndex)
		{
			return GetVelocity(t, curveIndex).normalized;
		}

		public Vector3 GetDirection(float t)
		{
			return GetVelocity(t).normalized;
		}

		public virtual SplineControlPoint[] GetSplineControlPoints()
		{
			List<SplineControlPoint> list = new List<SplineControlPoint>(base.transform.childCount);
			foreach (Transform item in base.transform)
			{
				SplineControlPoint component = item.GetComponent<SplineControlPoint>();
				if (component != null)
				{
					list.Add(component);
				}
			}
			return list.ToArray();
		}

		public void AlignWithNextSpline()
		{
			if (!(NextSpline == null))
			{
				if (m_nextControlPointIndex == 0)
				{
					NextSpline.AlignWithBeginning(m_points, (m_nextControlPointIndex - 1) / 3, GetMag());
				}
				else
				{
					NextSpline.AlignWithBeginning(m_points, (m_nextControlPointIndex - 1) / 3, GetMag(), 1f);
				}
				for (int i = 0; i < m_points.Length; i++)
				{
					m_points[i] = base.transform.InverseTransformPoint(NextSpline.transform.TransformPoint(m_points[i]));
				}
				EnforceMode(ControlPointCount - 1);
			}
		}

		public void AlignWithPrevSpline()
		{
			if (!(PrevSpline == null))
			{
				if (m_prevControlPointIndex == 0)
				{
					PrevSpline.AlignWithEnding(m_points, (m_prevControlPointIndex - 1) / 3, GetMag(), 0f);
				}
				else
				{
					PrevSpline.AlignWithEnding(m_points, (m_prevControlPointIndex - 1) / 3, GetMag());
				}
				for (int i = 0; i < m_points.Length; i++)
				{
					m_points[i] = base.transform.InverseTransformPoint(PrevSpline.transform.TransformPoint(m_points[i]));
				}
				EnforceMode(0);
			}
		}

		public bool IsControlPointLocked(int index)
		{
			if (index >= 2 && index <= ControlPointCount - 3)
			{
				return false;
			}
			if (index % 3 != 0 && GetControlPointMode(index) == ControlPointMode.Free)
			{
				return false;
			}
			if (PrevSpline != null)
			{
				if (PrevControlPointIndex == PrevSpline.ControlPointCount - 1)
				{
					SplineBranch[] branches = PrevSpline.GetBranches(PrevControlPointIndex);
					SplineBase splineBase = null;
					for (int i = 0; i < branches.Length; i++)
					{
						if (!branches[i].Inbound)
						{
							splineBase = PrevSpline.BranchToSpline(branches[i]);
						}
					}
					if (splineBase == this)
					{
						if (index < 1)
						{
							return true;
						}
						if (Loop && index > ControlPointCount - 2)
						{
							return true;
						}
					}
					else
					{
						if (index < 2)
						{
							return true;
						}
						if (Loop && index > ControlPointCount - 3)
						{
							return true;
						}
					}
				}
				else
				{
					if (index < 2)
					{
						return true;
					}
					if (Loop && index > ControlPointCount - 3)
					{
						return true;
					}
				}
			}
			if (NextSpline != null)
			{
				if (NextControlPointIndex == 0)
				{
					SplineBranch[] branches2 = NextSpline.GetBranches(NextControlPointIndex);
					SplineBase splineBase2 = null;
					for (int j = 0; j < branches2.Length; j++)
					{
						if (branches2[j].Inbound)
						{
							splineBase2 = NextSpline.BranchToSpline(branches2[j]);
						}
					}
					if (splineBase2 == this)
					{
						if (index > ControlPointCount - 2)
						{
							return true;
						}
						if (Loop && index < 1)
						{
							return true;
						}
					}
					else
					{
						if (index > ControlPointCount - 3)
						{
							return true;
						}
						if (Loop && index < 2)
						{
							return true;
						}
					}
				}
				else
				{
					if (index > ControlPointCount - 3)
					{
						return true;
					}
					if (Loop && index < 2)
					{
						return true;
					}
				}
			}
			return false;
		}

		public void SetBranch(SplineBase branch, int connectionPointIndex, bool isInbound)
		{
			if (branch == this)
			{
				throw new InvalidOperationException("branch == this");
			}
			if (branch.Loop)
			{
				throw new InvalidOperationException("Unable to connect branch. Branch has loop");
			}
			SplineBranch[] branches = GetBranches(connectionPointIndex);
			SplineBranch[] branches2 = branch.GetBranches(isInbound ? (branch.ControlPointCount - 1) : 0);
			if (branches != null && branches2 != null)
			{
				for (int i = 0; i < branches.Length; i++)
				{
					SplineBase splineBase = m_branches[branches[i].SplineIndex];
					for (int j = 0; j < branches2.Length; j++)
					{
						if (branch.m_branches[branches2[j].SplineIndex] == splineBase)
						{
							Debug.LogError("Unable to connect branch. Connection will lead to illegal structure");
							return;
						}
					}
				}
			}
			connectionPointIndex = (connectionPointIndex + 1) / 3 * 3;
			Vector3 controlPoint = GetControlPoint(connectionPointIndex);
			branch.transform.SetParent(base.transform, worldPositionStays: true);
			Vector3 vector = branch.transform.InverseTransformPoint(controlPoint);
			Thickness thickness = GetThickness(connectionPointIndex);
			thickness.T1 = 0f;
			thickness.T2 = 1f;
			Twist twist = GetTwist(connectionPointIndex);
			twist.T1 = 0f;
			twist.T2 = 1f;
			if (isInbound)
			{
				branch.SetThickness(branch.ControlPointCount - 1, thickness);
				branch.SetTwist(branch.ControlPointCount - 1, twist);
				branch.SetControlPointValue(branch.ControlPointCount - 1, vector);
				branch.RaiseControlPointChanged(branch.ControlPointCount - 1);
				ControlPointMode controlPointMode = GetControlPointMode(connectionPointIndex);
				if (controlPointMode == ControlPointMode.Free || (connectionPointIndex == 0 && controlPointMode != ControlPointMode.Mirrored))
				{
					Vector3 delta = vector - branch.GetControlPointLocal(branch.ControlPointCount - 1);
					branch.ChangeControlPointValue(branch.ControlPointCount - 2, delta);
					branch.RaiseControlPointChanged(branch.ControlPointCount - 2);
				}
				else if (controlPointMode == ControlPointMode.Aligned)
				{
					branch.SetControlPointValue(branch.ControlPointCount - 2, branch.transform.InverseTransformPoint(GetControlPoint(connectionPointIndex - 1)));
					branch.RaiseControlPointChanged(branch.ControlPointCount - 2);
				}
			}
			else
			{
				branch.SetThickness(0, thickness);
				branch.SetTwist(0, twist);
				branch.SetControlPointValue(0, vector);
				branch.RaiseControlPointChanged(0);
				ControlPointMode controlPointMode2 = GetControlPointMode(connectionPointIndex);
				if (controlPointMode2 == ControlPointMode.Free || (connectionPointIndex == ControlPointCount - 1 && controlPointMode2 != ControlPointMode.Mirrored))
				{
					Vector3 delta2 = vector - branch.GetControlPointLocal(0);
					branch.ChangeControlPointValue(1, delta2);
					branch.RaiseControlPointChanged(1);
				}
				else if (controlPointMode2 == ControlPointMode.Aligned)
				{
					branch.SetControlPointValue(1, branch.transform.InverseTransformPoint(GetControlPoint(connectionPointIndex + 1)));
					branch.RaiseControlPointChanged(1);
				}
			}
			Reconnect(branch, connectionPointIndex, isInbound);
			if (isInbound)
			{
				branch.SetControlPointMode(branch.ControlPointCount - 1, GetControlPointMode(connectionPointIndex));
			}
			else
			{
				branch.SetControlPointMode(0, GetControlPointMode(connectionPointIndex));
			}
			if (m_isSelected)
			{
				branch.Select();
			}
		}

		private void Reconnect(SplineBase branch, int connectionPointIndex, bool isInbound)
		{
			if (isInbound)
			{
				if (branch.m_nextSpline != null)
				{
					branch.m_nextSpline.Disconnect(branch, isInbound);
				}
				branch.m_nextSpline = this;
				branch.m_nextControlPointIndex = connectionPointIndex;
			}
			else
			{
				if (branch.m_prevSpline != null)
				{
					branch.m_prevSpline.Disconnect(branch, isInbound);
				}
				branch.m_prevSpline = this;
				branch.m_prevControlPointIndex = connectionPointIndex;
			}
			Connect(branch, connectionPointIndex, isInbound);
			EnforceBranchModes(connectionPointIndex);
		}

		private void Connect(SplineBase branch, int connectionPointIndex, bool isInbound)
		{
			int num = Array.IndexOf(m_branches, branch);
			if (num < 0)
			{
				Array.Resize(ref m_branches, m_branches.Length + 1);
				num = m_branches.Length - 1;
				m_branches[num] = branch;
			}
			int num2 = (connectionPointIndex + 1) / 3;
			ControlPointSetting controlPointSetting = m_settings[num2];
			if (controlPointSetting.Branches == null)
			{
				controlPointSetting.Branches = new SplineBranch[1];
			}
			else
			{
				Array.Resize(ref controlPointSetting.Branches, controlPointSetting.Branches.Length + 1);
			}
			controlPointSetting.Branches[controlPointSetting.Branches.Length - 1] = new SplineBranch(num, isInbound);
			m_settings[num2] = controlPointSetting;
			RaiseControlPointConnectionChanged(connectionPointIndex);
			if (isInbound)
			{
				branch.RaiseControlPointConnectionChanged(branch.ControlPointCount - 1);
				branch.RaiseControlPointConnectionChanged(branch.ControlPointCount - 2);
			}
			else
			{
				branch.RaiseControlPointConnectionChanged(0);
				branch.RaiseControlPointConnectionChanged(1);
			}
		}

		public void Disconnect(int index)
		{
			SplineBranch[] branches = GetBranches(index);
			if (branches != null && branches.Length != 0)
			{
				for (int num = branches.Length - 1; num >= 0; num--)
				{
					SplineBranch splineBranch = branches[num];
					SplineBase branch = m_branches[splineBranch.SplineIndex];
					Disconnect(branch, splineBranch.Inbound);
				}
			}
		}

		public void Disconnect(SplineBase spline)
		{
			Disconnect(spline, isInbound: true);
			Disconnect(spline, isInbound: false);
		}

		public void Disconnect(SplineBase branch, bool isInbound)
		{
			int num = Array.IndexOf(m_branches, branch);
			if (num < 0)
			{
				return;
			}
			int num2;
			if (isInbound)
			{
				num2 = (branch.m_nextControlPointIndex + 1) / 3;
				branch.m_nextSpline = null;
				branch.m_nextControlPointIndex = -1;
			}
			else
			{
				num2 = (branch.m_prevControlPointIndex + 1) / 3;
				branch.m_prevSpline = null;
				branch.m_prevControlPointIndex = -1;
			}
			if (num2 >= m_settings.Length)
			{
				return;
			}
			ControlPointSetting controlPointSetting = m_settings[num2];
			int num3 = -1;
			for (int i = 0; i < controlPointSetting.Branches.Length; i++)
			{
				SplineBranch splineBranch = controlPointSetting.Branches[i];
				if (splineBranch.SplineIndex == num && splineBranch.Inbound == isInbound)
				{
					num3 = i;
				}
			}
			if (num3 >= 0)
			{
				for (int j = num3; j < controlPointSetting.Branches.Length - 1; j++)
				{
					controlPointSetting.Branches[j] = controlPointSetting.Branches[j + 1];
				}
				Array.Resize(ref controlPointSetting.Branches, controlPointSetting.Branches.Length - 1);
				m_settings[num2] = controlPointSetting;
			}
			if (branch.m_nextSpline == null && branch.m_prevSpline == null)
			{
				for (int k = num; k < m_branches.Length - 1; k++)
				{
					m_branches[k] = m_branches[k + 1];
				}
				Array.Resize(ref m_branches, m_branches.Length - 1);
				CleanupSplineConnections(num);
			}
			RaiseControlPointConnectionChanged(num2 * 3);
			if (isInbound)
			{
				branch.RaiseControlPointConnectionChanged(branch.ControlPointCount - 1);
				branch.RaiseControlPointConnectionChanged(branch.ControlPointCount - 2);
			}
			else
			{
				branch.RaiseControlPointConnectionChanged(0);
				branch.RaiseControlPointConnectionChanged(1);
			}
		}

		private void UpdateChildrenAndParent()
		{
			if (base.transform.parent != null)
			{
				m_parent = base.transform.parent.GetComponentInParent<SplineBase>();
			}
			else
			{
				m_parent = null;
			}
			List<SplineBase> list = new List<SplineBase>();
			foreach (Transform item in base.transform)
			{
				SplineBase component = item.GetComponent<SplineBase>();
				if (component != null)
				{
					list.Add(component);
				}
			}
			m_children = list.ToArray();
		}

		private void ShiftConnectionIndices(int settingIndex, int offset)
		{
			for (int i = 0; i < m_branches.Length; i++)
			{
				SplineBase splineBase = m_branches[i];
				if (splineBase.PrevSpline == this && splineBase.m_prevControlPointIndex >= settingIndex * 3)
				{
					splineBase.m_prevControlPointIndex += offset;
				}
				if (splineBase.NextSpline == this && splineBase.m_nextControlPointIndex >= settingIndex * 3)
				{
					splineBase.m_nextControlPointIndex += offset;
				}
			}
		}

		private void CleanupSplineConnections(int splineIndex)
		{
			for (int i = 0; i < m_settings.Length; i++)
			{
				ControlPointSetting controlPointSetting = m_settings[i];
				if (controlPointSetting.Branches == null)
				{
					continue;
				}
				for (int j = 0; j < controlPointSetting.Branches.Length; j++)
				{
					SplineBranch splineBranch = controlPointSetting.Branches[j];
					if (splineBranch.SplineIndex == splineIndex)
					{
						throw new InvalidOperationException("connection.SplineIndex == splineIndex. SplineConnection with index " + splineIndex + " should be removed");
					}
					if (splineBranch.SplineIndex > splineIndex)
					{
						splineBranch.SplineIndex--;
						controlPointSetting.Branches[j] = splineBranch;
					}
				}
				m_settings[i] = controlPointSetting;
			}
		}

		public void Smooth()
		{
			Vector3 vector = m_points[0];
			ShiftPoints(-vector);
			int num = m_points.Length / 3;
			float[] array = new float[num];
			float[] array2 = new float[num];
			float[] array3 = new float[num];
			Vector3[] array4 = new Vector3[num];
			array[0] = 0f;
			array2[0] = 2f;
			array3[0] = 1f;
			array4[0] = m_points[0] + 2f * m_points[3];
			for (int i = 1; i < num - 1; i++)
			{
				array[i] = 1f;
				array2[i] = 4f;
				array3[i] = 1f;
				array4[i] = 4f * m_points[i * 3] + 2f * m_points[(i + 1) * 3];
			}
			array[num - 1] = 2f;
			array2[num - 1] = 7f;
			array3[num - 1] = 0f;
			array4[num - 1] = 8f * m_points[(num - 1) * 3] + m_points[num * 3];
			for (int j = 1; j < num; j++)
			{
				float num2 = array[j] / array2[j - 1];
				array2[j] -= num2 * array3[j - 1];
				array4[j] -= num2 * array4[j - 1];
			}
			m_points[(num - 1) * 3 + 1] = array4[num - 1] / array2[num - 1];
			for (int num3 = num - 2; num3 >= 0; num3--)
			{
				m_points[num3 * 3 + 1] = (array4[num3] - array3[num3] * m_points[(num3 + 1) * 3 + 1]) / array2[num3];
			}
			for (int k = 0; k < num - 1; k++)
			{
				m_points[k * 3 + 2] = 2f * m_points[(k + 1) * 3] - m_points[(k + 1) * 3 + 1];
			}
			m_points[(num - 1) * 3 + 2] = 0.5f * (m_points[num * 3] + m_points[(num - 1) * 3 + 1]);
			ShiftPoints(vector);
			if (Loop)
			{
				EnforceMode(m_points.Length - 2);
			}
			SyncCtrlPoints();
			OnCurveChanged();
			if (Children != null)
			{
				for (int l = 0; l < Children.Length; l++)
				{
					Children[l].Smooth();
				}
			}
			EnforceModeRecursive();
		}

		private void EnforceModeRecursive()
		{
			EnforceMode(1);
			if (Children != null)
			{
				for (int i = 0; i < Children.Length; i++)
				{
					Children[i].EnforceModeRecursive();
				}
			}
		}

		private void ShiftPoints(Vector3 offset)
		{
			for (int i = 0; i < m_points.Length; i++)
			{
				m_points[i] += offset;
			}
		}

		public float EvalDistance(int curveIndex)
		{
			Vector3 point = GetPoint(0f, curveIndex);
			return (GetPoint(1f, curveIndex) - point).magnitude;
		}

		public float EvalDistance()
		{
			Vector3 point = GetPoint(0f);
			return (GetPoint(1f) - point).magnitude;
		}

		public float EvalCurveLength(int curveIndex, int steps = 4)
		{
			if (steps < 1)
			{
				steps = 1;
			}
			float num = 0f;
			Vector3 vector = GetPoint(0f, curveIndex);
			for (int i = 1; i <= steps; i++)
			{
				float num2 = i;
				num2 /= 3f;
				Vector3 point = GetPoint(num2, curveIndex);
				num += (point - vector).magnitude;
				vector = point;
			}
			return num;
		}

		public float EvalSplineLength(int steps = 4)
		{
			if (steps < 1)
			{
				steps = 1;
			}
			float num = 0f;
			for (int i = 0; i < CurveCount; i++)
			{
				num += EvalCurveLength(i, steps);
			}
			return num;
		}

		public virtual SplineSnapshot Save()
		{
			return new SplineSnapshot(m_points, m_settings, m_modes, m_loop);
		}

		public virtual void Load(SplineSnapshot snapshot)
		{
			LoadSpline(snapshot);
		}

		protected void LoadSpline(SplineSnapshot settings)
		{
			m_points = settings.Points;
			m_settings = settings.ControlPointSettings;
			m_modes = settings.Modes;
			m_loop = settings.Loop;
			SyncCtrlPoints();
		}

		protected void SetPoints(int curveIndex, Vector3[] points, ControlPointMode mode, bool raiseCurveChanged)
		{
			int num = curveIndex * 3;
			for (int i = 0; i < points.Length; i++)
			{
				SetControlPointValue(num, points[i]);
				RaiseControlPointChanged(num);
				SetControlPointMode(num, mode, raiseCurveChanged);
				num++;
			}
			EnforceMode(num);
			if (raiseCurveChanged)
			{
				OnCurveChanged(num, Math.Max(0, (num - 1) / 3));
			}
		}

		private void JustChangeControlPointValue(int index, Vector3 delta)
		{
			m_points[index] += delta;
		}

		private void ChangeControlPointValue(int index, Vector3 delta)
		{
			SetControlPointValue(index, m_points[index] + delta);
		}

		private void JustSetControlPointValue(int index, Vector3 point)
		{
			m_points[index] = point;
		}

		private void SetControlPointValue(int index, Vector3 point)
		{
			if (!(m_points[index] == point))
			{
				m_points[index] = point;
				SetBranchControlPoints(index, point);
			}
		}

		private void SetBranchControlPoints(int index, Vector3 point)
		{
			int num = (index + 1) / 3;
			int num2 = num * 3;
			SplineBranch[] branches = m_settings[num].Branches;
			if (branches == null)
			{
				return;
			}
			for (int i = 0; i < branches.Length; i++)
			{
				SplineBranch splineBranch = branches[i];
				SplineBase splineBase = m_branches[splineBranch.SplineIndex];
				if (!(splineBase != null))
				{
					continue;
				}
				if (splineBranch.Inbound)
				{
					if ((splineBase.m_nextControlPointIndex + 1) / 3 == num)
					{
						if (index == num2)
						{
							splineBase._SetControlPointUnchecked(splineBase.ControlPointCount - 1, base.transform.TransformPoint(point));
						}
						else if (index == num2 - 1 && GetControlPointMode(index) != ControlPointMode.Free)
						{
							splineBase._SetControlPointUnchecked(splineBase.ControlPointCount - 2, base.transform.TransformPoint(point));
						}
					}
				}
				else if ((splineBase.m_prevControlPointIndex + 1) / 3 == num)
				{
					if (index == num2)
					{
						splineBase._SetControlPointUnchecked(0, base.transform.TransformPoint(point));
					}
					else if (index == num2 + 1 && GetControlPointMode(index) != ControlPointMode.Free)
					{
						splineBase._SetControlPointUnchecked(1, base.transform.TransformPoint(point));
					}
				}
			}
		}

		private void EnforceMode(int index)
		{
			int num = (index + 1) / 3;
			ControlPointMode controlPointMode = m_modes[num];
			bool flag = num == 0 || num == m_modes.Length - 1;
			if (controlPointMode == ControlPointMode.Free || (!m_loop && flag))
			{
				if (flag)
				{
					EnforceBranchModes(index);
				}
				return;
			}
			int num2 = num * 3;
			int num3;
			int num4;
			if (index <= num2)
			{
				num3 = num2 - 1;
				if (num3 < 0)
				{
					num3 = m_points.Length - 2;
				}
				num4 = num2 + 1;
				if (num4 >= m_points.Length)
				{
					num4 = 1;
				}
			}
			else
			{
				num3 = num2 + 1;
				if (num3 >= m_points.Length)
				{
					num3 = 1;
				}
				num4 = num2 - 1;
				if (num4 < 0)
				{
					num4 = m_points.Length - 2;
				}
			}
			Vector3 vector = m_points[num2];
			Vector3 vector2 = vector - m_points[num3];
			if (controlPointMode == ControlPointMode.Aligned)
			{
				vector2 = vector2.normalized * Vector3.Distance(vector, m_points[num4]);
			}
			SetControlPointValue(num4, vector + vector2);
			RaiseControlPointChanged(num4);
			if (flag)
			{
				EnforceBranchModes(index);
				EnforceBranchModes(num4);
			}
		}

		private void EnforceBranchModes(int index)
		{
			int num = (index + 1) / 3;
			ControlPointMode controlPointMode = m_modes[num];
			if (controlPointMode == ControlPointMode.Free)
			{
				return;
			}
			ControlPointSetting controlPointSetting = m_settings[num];
			if (controlPointSetting.Branches == null)
			{
				return;
			}
			int num2 = num * 3;
			for (int i = 0; i < controlPointSetting.Branches.Length; i++)
			{
				SplineBranch splineBranch = controlPointSetting.Branches[i];
				SplineBase splineBase = m_branches[splineBranch.SplineIndex];
				int fixedIndex;
				int enforcedIndex;
				if (splineBranch.Inbound)
				{
					fixedIndex = num2 + 1;
					enforcedIndex = splineBase.ControlPointCount - 2;
				}
				else
				{
					fixedIndex = num2 - 1;
					enforcedIndex = 1;
				}
				EnforceBranchMode(controlPointMode, num2, splineBase, fixedIndex, enforcedIndex);
			}
			if (num == 0)
			{
				if (PrevSpline != null)
				{
					EnforceBranchMode(controlPointMode, num2, PrevSpline, num2 + 1, m_prevControlPointIndex - 1);
				}
				else if (NextSpline != null && Loop)
				{
					int num3 = (m_modes.Length - 1) * 3;
					EnforceBranchMode(controlPointMode, num3, NextSpline, num3 - 1, m_nextControlPointIndex + 1);
				}
			}
			else if (num == m_modes.Length - 1)
			{
				if (NextSpline != null)
				{
					EnforceBranchMode(controlPointMode, num2, NextSpline, num2 - 1, m_nextControlPointIndex + 1);
				}
				else if (PrevSpline != null && Loop)
				{
					int num4 = 0;
					EnforceBranchMode(controlPointMode, num4, PrevSpline, num4 + 1, m_prevControlPointIndex - 1);
				}
			}
		}

		private void EnforceBranchMode(ControlPointMode mode, int middleIndex, SplineBase branch, int fixedIndex, int enforcedIndex)
		{
			if (fixedIndex < 0 || fixedIndex >= m_points.Length)
			{
				fixedIndex = ((fixedIndex < 0) ? 1 : (m_points.Length - 2));
				Vector3 vector = branch.transform.InverseTransformPoint(base.transform.TransformPoint(m_points[fixedIndex]));
				if (branch.m_points[enforcedIndex] != vector)
				{
					branch._SetControlPointLocalUnchecked(enforcedIndex, vector);
				}
				return;
			}
			if (enforcedIndex < 0 || enforcedIndex >= branch.m_points.Length)
			{
				enforcedIndex = ((enforcedIndex < 0) ? 1 : (branch.m_points.Length - 2));
				Vector3 vector2 = branch.transform.InverseTransformPoint(base.transform.TransformPoint(m_points[fixedIndex]));
				if (branch.m_points[enforcedIndex] != vector2)
				{
					branch._SetControlPointLocalUnchecked(enforcedIndex, vector2);
				}
				return;
			}
			Vector3 vector3 = m_points[middleIndex];
			Vector3 vector4 = vector3 - m_points[fixedIndex];
			if (mode == ControlPointMode.Aligned)
			{
				Vector3 b = base.transform.InverseTransformPoint(branch.transform.TransformPoint(branch.m_points[enforcedIndex]));
				vector4 = vector4.normalized * Vector3.Distance(vector3, b);
			}
			Vector3 vector5 = branch.transform.InverseTransformPoint(base.transform.TransformPoint(vector3 + vector4));
			if (branch.m_points[enforcedIndex] != vector5)
			{
				branch._SetControlPointLocalUnchecked(enforcedIndex, vector5);
			}
		}

		protected void AlignCurve(int curveIndex, float length, bool toLast = true)
		{
			int num = curveIndex * 3;
			int num2 = num + 3;
			Vector3 vector = m_points[num2];
			Vector3 vector2 = m_points[num];
			Vector3 vector3 = ((!toLast) ? base.transform.InverseTransformDirection(GetDirection(0f, curveIndex)) : base.transform.InverseTransformDirection(GetDirection(1f, curveIndex)));
			if (toLast)
			{
				for (int num3 = num2 - 1; num3 >= num; num3--)
				{
					vector -= vector3 * length / 3f;
					SetControlPointValue(num3, vector);
					RaiseControlPointChanged(num3);
				}
				Vector3 vector4 = vector2 - m_points[num];
				for (int num4 = num - 1; num4 >= 0; num4--)
				{
					ChangeControlPointValue(num4, -vector4);
					RaiseControlPointChanged(num4);
				}
			}
			else
			{
				for (int i = num + 1; i <= num2; i++)
				{
					vector2 += vector3 * length / 3f;
					SetControlPointValue(i, vector2);
					RaiseControlPointChanged(i);
				}
				Vector3 vector5 = vector - m_points[num2];
				for (int j = num2 + 1; j < m_points.Length; j++)
				{
					ChangeControlPointValue(j, -vector5);
					RaiseControlPointChanged(j);
				}
			}
			EnforceMode(num - 1);
			EnforceMode(num2 + 1);
		}

		protected bool RemoveCurve(int curveIndex)
		{
			if (m_points.Length <= 4)
			{
				return false;
			}
			if (curveIndex >= CurveCount || curveIndex < 0)
			{
				throw new ArgumentOutOfRangeException("curveIndex");
			}
			if (curveIndex == 0)
			{
				if (m_prevSpline != null)
				{
					m_prevSpline.Disconnect(this, isInbound: false);
				}
			}
			else if (curveIndex == CurveCount - 1 && m_nextSpline != null)
			{
				m_nextSpline.Disconnect(this, isInbound: true);
			}
			int num = curveIndex * 3;
			bool flag = true;
			if (curveIndex == CurveCount - 1)
			{
				flag = false;
				num += 3;
			}
			for (int i = num; i < m_points.Length - 3; i++)
			{
				JustSetControlPointValue(i, m_points[i + 3]);
			}
			if (curveIndex == 0)
			{
				Disconnect(0);
				ShiftConnectionIndices(0, -3);
			}
			if (curveIndex == CurveCount - 1)
			{
				int num2 = curveIndex + 1;
				Disconnect(num2 * 3);
			}
			else
			{
				Disconnect(curveIndex * 3);
				ShiftConnectionIndices(curveIndex * 3, -3);
			}
			for (int j = (num + 1) / 3; j < m_modes.Length - 1; j++)
			{
				m_settings[j] = m_settings[j + 1];
				m_modes[j] = m_modes[j + 1];
				RaiseControlPointModeChanged(j);
			}
			Array.Resize(ref m_points, m_points.Length - 3);
			Array.Resize(ref m_settings, m_settings.Length - 1);
			Array.Resize(ref m_modes, m_modes.Length - 1);
			if (flag)
			{
				EnforceMode(num + 1);
			}
			if (m_loop)
			{
				SetControlPointValue(m_points.Length - 1, m_points[0]);
				ControlPointSetting controlPointSetting = m_settings[m_settings.Length - 1];
				m_settings[0] = new ControlPointSetting(controlPointSetting.Twist, controlPointSetting.Thickness, m_settings[0].Branches);
				m_modes[m_modes.Length - 1] = m_modes[0];
				RaiseControlPointModeChanged(m_modes.Length - 1);
				EnforceMode(1);
			}
			SyncCtrlPoints();
			return true;
		}

		protected void Subdivide(int firstCurveIndex, int lastCurveIndex, int curveCount)
		{
			int num = firstCurveIndex * 3;
			int num2 = lastCurveIndex * 3 + 3;
			int num3 = m_points.Length;
			int num4 = num2 - num - 1;
			int num5 = curveCount * 3 - 1;
			int num6 = num5 - num4;
			Vector3[] array = new Vector3[num5];
			Vector3 a = m_points[num];
			Vector3 b = m_points[num2];
			ControlPointSetting controlPointSetting = m_settings[(num + 1) / 3];
			ControlPointSetting controlPointSetting2 = new ControlPointSetting(controlPointSetting.Twist, controlPointSetting.Thickness);
			ControlPointMode controlPointMode = m_modes[(num + 1) / 3];
			float num7 = 1f / (float)(num5 + 1);
			float num8 = 0f;
			for (int i = 0; i < num5; i++)
			{
				num8 += num7;
				array[i] = Vector3.Lerp(a, b, num8);
			}
			if (num6 > 0)
			{
				Array.Resize(ref m_points, m_points.Length + num6);
				Array.Resize(ref m_settings, m_settings.Length + num6 / 3);
				Array.Resize(ref m_modes, m_modes.Length + num6 / 3);
				for (int num9 = num3 - 1; num9 >= num2; num9--)
				{
					SetControlPointValue(num9 + num6, m_points[num9]);
				}
				for (int num10 = num3 / 3; num10 >= (num2 + 1) / 3; num10--)
				{
					m_settings[num10 + num6 / 3] = m_settings[num10];
					m_modes[num10 + num6 / 3] = m_modes[num10];
					RaiseControlPointModeChanged(num10 + num6 / 3);
				}
			}
			else if (num6 < 0)
			{
				for (int j = num2; j < num3; j++)
				{
					SetControlPointValue(j + num6, m_points[j]);
				}
				for (int k = (num2 + 1) / 3; k < (num3 + 1) / 3; k++)
				{
					m_settings[k + num6 / 3] = m_settings[k];
					m_modes[k + num6 / 3] = m_modes[k];
					RaiseControlPointModeChanged(k + num6 / 3);
				}
				Array.Resize(ref m_points, m_points.Length + num6);
				Array.Resize(ref m_settings, m_settings.Length + num6 / 3);
				Array.Resize(ref m_modes, m_modes.Length + num6 / 3);
			}
			for (int l = 0; l < num5; l++)
			{
				SetControlPointValue(num + l + 1, array[l]);
			}
			for (int m = 0; m < num5 / 3; m++)
			{
				m_settings[(num + 1) / 3 + m + 1] = controlPointSetting2;
				m_modes[(num + 1) / 3 + m + 1] = controlPointMode;
				RaiseControlPointModeChanged((num + 1) / 3 + m + 1);
			}
			int num11 = num - 1;
			int num12 = num + num5 + 2;
			if (m_loop)
			{
				if (num11 == -1)
				{
					num11 = m_points.Length - 1;
				}
				if (num12 == m_points.Length)
				{
					num12 = 0;
				}
			}
			if (num12 < m_points.Length)
			{
				EnforceMode(num12);
			}
			if (num11 >= 0)
			{
				EnforceMode(num11);
			}
			SyncCtrlPoints();
		}

		private void InsertCurve(Vector3[] points, ControlPointSetting setting, ControlPointMode mode, int curveIndex, float length, bool enforceNeighbour, bool shrinkPreceding)
		{
			if (curveIndex == 0 && shrinkPreceding)
			{
				curveIndex = ((!Loop) ? 1 : CurveCount);
			}
			int num = curveIndex * 3;
			int num2 = curveIndex - 1;
			int num3 = num2 * 3;
			Array.Resize(ref m_points, m_points.Length + points.Length);
			Array.Resize(ref m_settings, m_settings.Length + points.Length / 3);
			Array.Resize(ref m_modes, m_modes.Length + points.Length / 3);
			int num4 = (num + 1) / 3;
			ShiftConnectionIndices(num4, points.Length);
			for (int num5 = m_modes.Length - 1; num5 >= num4 + points.Length / 3; num5--)
			{
				m_settings[num5] = m_settings[num5 - points.Length / 3];
				m_modes[num5] = m_modes[num5 - points.Length / 3];
			}
			for (int num6 = m_points.Length - 1; num6 >= num + points.Length; num6--)
			{
				JustSetControlPointValue(num6, m_points[num6 - points.Length]);
			}
			if (shrinkPreceding)
			{
				float num7 = points.Length + 3;
				for (int num8 = points.Length - 1; num8 >= 0; num8--)
				{
					points[num8] = GetPointLocal((float)(num8 + 4) / num7, num2);
				}
				Vector3[] array = new Vector3[3];
				for (int num9 = 2; num9 >= 0; num9--)
				{
					array[num9] = GetPointLocal((float)(num9 + 1) / num7, num2);
				}
				for (int num10 = num; num10 >= num - 2; num10--)
				{
					SetControlPointValue(num10, array[2 + num10 - num]);
				}
			}
			for (int num11 = m_modes.Length - 1; num11 >= num4 + points.Length / 3; num11--)
			{
				RaiseControlPointModeChanged(num11);
			}
			for (int i = num4; i < num4 + points.Length / 3; i++)
			{
				m_settings[i] = setting;
				m_modes[i] = mode;
			}
			if (shrinkPreceding)
			{
				for (int j = num; j < num + points.Length; j++)
				{
					SetControlPointValue(j + 1, points[j - num]);
				}
			}
			else
			{
				for (int k = num; k < num + points.Length; k++)
				{
					SetControlPointValue(k, points[k - num]);
				}
				Vector3 vector = base.transform.InverseTransformDirection(GetDirection(0f, curveIndex));
				for (int num12 = num - 1; num12 >= 0; num12--)
				{
					ChangeControlPointValue(num12, -vector * length);
				}
			}
			for (int l = num4; l < num4 + points.Length / 3; l++)
			{
				RaiseControlPointModeChanged(l);
			}
			if (shrinkPreceding)
			{
				EnforceMode(num + points.Length + 1);
				EnforceMode(num - 1);
				EnforceMode(num3 - 1);
			}
			else if (enforceNeighbour)
			{
				EnforceMode(num + points.Length + 1);
			}
			else
			{
				EnforceMode(num + points.Length - 1);
			}
			if (m_loop)
			{
				ControlPointSetting controlPointSetting = m_settings[m_settings.Length - 1];
				m_settings[0] = new ControlPointSetting(controlPointSetting.Twist, controlPointSetting.Thickness, m_settings[0].Branches);
				m_modes[m_modes.Length - 1] = m_modes[0];
				SetControlPointValue(m_points.Length - 1, m_points[0]);
				RaiseControlPointModeChanged(m_modes.Length - 1);
				EnforceMode(1);
			}
			SyncCtrlPoints();
		}

		protected void PrependCurve(Vector3[] points, int curveIndex, float length, bool enforceNeighbour, bool shrinkPreceding)
		{
			if (m_prevSpline != null && curveIndex == 0)
			{
				throw new InvalidOperationException("Can't prepend curve to the connected end of the spline. Previous spline " + m_prevSpline.name);
			}
			ControlPointSetting setting = GetSetting(curveIndex * 3);
			setting.Branches = new SplineBranch[0];
			InsertCurve(points, setting, GetControlPointMode(curveIndex * 3), curveIndex, length, enforceNeighbour, shrinkPreceding);
		}

		protected void AppendCurve(Vector3[] points, bool enforceNeighbour)
		{
			ControlPointSetting setting = GetSetting(m_points.Length - 1);
			AppendCurve(points, new ControlPointSetting(setting.Twist, setting.Thickness), GetControlPointMode(m_points.Length - 1), enforceNeighbour);
		}

		private void AppendCurve(Vector3[] points, ControlPointSetting setting, ControlPointMode mode, bool enforceNeighbour)
		{
			if (m_nextSpline != null)
			{
				throw new InvalidOperationException("Can't append curve to the connected end of the spline. Next spline " + m_nextSpline.name);
			}
			Array.Resize(ref m_points, m_points.Length + points.Length);
			Array.Resize(ref m_settings, m_settings.Length + points.Length / 3);
			Array.Resize(ref m_modes, m_modes.Length + points.Length / 3);
			for (int i = 0; i < points.Length / 3; i++)
			{
				m_settings[m_settings.Length - points.Length / 3 + i] = setting;
				m_modes[m_modes.Length - points.Length / 3 + i] = mode;
			}
			for (int j = 0; j < points.Length; j++)
			{
				SetControlPointValue(m_points.Length - points.Length + j, points[j]);
			}
			for (int k = 0; k < points.Length / 3; k++)
			{
				RaiseControlPointModeChanged(m_modes.Length - points.Length / 3 + k);
			}
			if (enforceNeighbour)
			{
				EnforceMode(m_points.Length - points.Length - 2);
			}
			else
			{
				EnforceMode(m_points.Length - points.Length);
			}
			if (m_loop)
			{
				ControlPointSetting controlPointSetting = m_settings[m_settings.Length - 1];
				m_settings[0] = new ControlPointSetting(controlPointSetting.Twist, controlPointSetting.Thickness, m_settings[0].Branches);
				m_modes[0] = m_modes[m_modes.Length - 1];
				SetControlPointValue(0, m_points[m_points.Length - 1]);
				RaiseControlPointModeChanged(0);
				EnforceMode(m_points.Length - 1);
			}
			SyncCtrlPoints();
		}

		protected void AlignWithEnding(Vector3[] points, int curveIndex, float mag, float offset = 1f)
		{
			if (points.Length != 0)
			{
				Vector3 vector = base.transform.InverseTransformDirection(GetDirection(offset, curveIndex));
				Vector3 pointLocal = GetPointLocal(offset, curveIndex);
				float num = 1f / 3f;
				float num2 = num;
				if (points.Length % 2 == 0)
				{
					num2 = 0f;
				}
				for (int i = 0; i < points.Length; i++)
				{
					points[i] = pointLocal + vector * mag * num2;
					num2 += num;
				}
			}
		}

		protected void AlignWithBeginning(Vector3[] points, int curveIndex, float mag, float offset = 0f)
		{
			if (points.Length != 0)
			{
				Vector3 direction = GetDirection(offset, curveIndex);
				Vector3 pointLocal = GetPointLocal(offset, curveIndex);
				direction = base.transform.InverseTransformDirection(direction);
				float num = 1f / 3f;
				float num2 = 1f;
				for (int i = 0; i < points.Length; i++)
				{
					points[i] = pointLocal - direction * mag * num2;
					num2 -= num;
				}
			}
		}

		protected virtual void OnCurveChanged(int pointIndex, int curveIndex)
		{
		}

		protected virtual void OnCurveChanged()
		{
		}

		protected virtual void AddControlPointComponent(GameObject ctrlPoint)
		{
			ctrlPoint.AddComponent<SplineControlPoint>();
		}

		private void SyncCtrlPoints(bool silent = false)
		{
			SplineRuntimeEditor instance = SplineRuntimeEditor.Instance;
			SplineControlPoint[] splineControlPoints = GetSplineControlPoints();
			int num = ControlPointCount - splineControlPoints.Length;
			if (num > 0)
			{
				for (int i = 0; i < num; i++)
				{
					GameObject gameObject = new GameObject();
					gameObject.SetActive(m_isSelected);
					gameObject.transform.parent = base.transform;
					gameObject.transform.rotation = Quaternion.identity;
					gameObject.transform.localScale = Vector3.one;
					if (instance != null)
					{
						MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
						gameObject.AddComponent<MeshFilter>().sharedMesh = instance.ControlPointMesh;
						meshRenderer.sharedMaterial = instance.NormalMaterial;
						meshRenderer.enabled = true;
					}
					gameObject.name = "ctrl point";
					AddControlPointComponent(gameObject);
				}
				splineControlPoints = GetSplineControlPoints();
			}
			else if (num < 0)
			{
				num = -num;
				for (int j = 0; j < num; j++)
				{
					SplineControlPoint splineControlPoint = splineControlPoints[j];
					if (splineControlPoint.gameObject != null)
					{
						UnityEngine.Object.DestroyImmediate(splineControlPoint.gameObject);
					}
				}
				splineControlPoints = GetSplineControlPoints();
			}
			for (int k = 0; k < ControlPointCount; k++)
			{
				splineControlPoints[k].Index = k;
				RaiseControlPointChanged(k);
				RaiseControlPointModeChanged(k);
			}
		}

		private void SetValue<T>(int controlPointIndex, T value, Action<int, T, bool> setter, Action<int, T, SplineBase, bool> branchSetter, Func<int, T> getter, bool raiseCurveChanged = true)
		{
			if (!getter(controlPointIndex).Equals(value))
			{
				setter(controlPointIndex, value, raiseCurveChanged);
				SetBranchValues(controlPointIndex, value, branchSetter, raiseCurveChanged);
			}
		}

		private void SetBranchValues<T>(int controlPointIndex, T value, Action<int, T, SplineBase, bool> branchSetter, bool raiseCurveChanged)
		{
			int num = (controlPointIndex + 1) / 3;
			SplineBranch[] branches = m_settings[num].Branches;
			if (branches != null)
			{
				for (int i = 0; i < branches.Length; i++)
				{
					SplineBranch splineBranch = branches[i];
					SplineBase splineBase = m_branches[splineBranch.SplineIndex];
					if (splineBase != null)
					{
						if (splineBranch.Inbound)
						{
							branchSetter(splineBase.ControlPointCount - 1, value, splineBase, raiseCurveChanged);
						}
						else
						{
							branchSetter(0, value, splineBase, raiseCurveChanged);
						}
					}
				}
			}
			if (num == 0 && PrevSpline != null)
			{
				branchSetter(PrevControlPointIndex, value, PrevSpline, raiseCurveChanged);
			}
			if (num == m_settings.Length - 1 && NextSpline != null)
			{
				branchSetter(NextControlPointIndex, value, NextSpline, raiseCurveChanged);
			}
		}
	}
}
