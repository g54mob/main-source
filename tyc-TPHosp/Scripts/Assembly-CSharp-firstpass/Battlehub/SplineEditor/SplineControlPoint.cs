using System;
using Battlehub.RTEditor;
using UnityEngine;

namespace Battlehub.SplineEditor
{
	[ExecuteInEditMode]
	public class SplineControlPoint : MonoBehaviour
	{
		private MeshRenderer m_renderer;

		private SplineBase m_spline;

		private Vector3 m_localPosition;

		private Quaternion m_rotation;

		private bool m_updateAngle = true;

		[SerializeField]
		[HideInInspector]
		private int m_index;

		public int Index
		{
			get
			{
				return m_index;
			}
			set
			{
				m_index = value;
				UpdateMaterial();
			}
		}

		private void OnEnable()
		{
			m_spline = GetComponentInParent<SplineBase>();
			if (!(m_spline == null))
			{
				m_spline.ControlPointTwistChanged -= OnControlPointTwistChanged;
				m_spline.ControlPointTwistChanged += OnControlPointTwistChanged;
				m_spline.ControlPointThicknessChanged -= OnControlPointThicknessChanged;
				m_spline.ControlPointThicknessChanged += OnControlPointThicknessChanged;
				m_spline.ControlPointModeChanged -= OnControlPointModeChanged;
				m_spline.ControlPointModeChanged += OnControlPointModeChanged;
				m_spline.ControlPointPositionChanged -= OnControlPointPositionChanged;
				m_spline.ControlPointPositionChanged += OnControlPointPositionChanged;
				m_spline.ControlPointConnectionChanged -= OnControlPointConnectionChanged;
				m_spline.ControlPointConnectionChanged += OnControlPointConnectionChanged;
				UpdateRenderersState();
			}
		}

		private void Start()
		{
			SplineRuntimeEditor.Created += OnRuntimeEditorCreated;
			SplineBase.ConvergingSplineChanged += OnIsConvergingChanged;
			CreateRuntimeComponents();
			if (m_spline == null)
			{
				m_spline = GetComponentInParent<SplineBase>();
				if (m_spline == null)
				{
					Debug.LogError("Is not a child of gameobject with Spline or MeshDeformer component");
					return;
				}
				m_spline.ControlPointTwistChanged -= OnControlPointTwistChanged;
				m_spline.ControlPointTwistChanged += OnControlPointTwistChanged;
				m_spline.ControlPointThicknessChanged -= OnControlPointThicknessChanged;
				m_spline.ControlPointThicknessChanged += OnControlPointThicknessChanged;
				m_spline.ControlPointModeChanged -= OnControlPointModeChanged;
				m_spline.ControlPointModeChanged += OnControlPointModeChanged;
				m_spline.ControlPointPositionChanged -= OnControlPointPositionChanged;
				m_spline.ControlPointPositionChanged += OnControlPointPositionChanged;
				m_spline.ControlPointConnectionChanged -= OnControlPointConnectionChanged;
				m_spline.ControlPointConnectionChanged += OnControlPointConnectionChanged;
			}
			m_localPosition = m_spline.GetControlPointLocal(m_index);
			base.transform.localPosition = m_localPosition;
			UpdateRenderersState();
			UpdateAngle(forceUpdateAngle: true);
			m_rotation = base.transform.rotation;
			Thickness thickness = m_spline.GetThickness(m_index);
			base.transform.localScale = thickness.Data;
			if (!m_spline.IsSelected)
			{
				base.gameObject.SetActive(value: false);
			}
		}

		protected void OnDestroy()
		{
			if (m_spline != null)
			{
				m_spline.ControlPointTwistChanged -= OnControlPointTwistChanged;
				m_spline.ControlPointThicknessChanged -= OnControlPointThicknessChanged;
				m_spline.ControlPointModeChanged -= OnControlPointModeChanged;
				m_spline.ControlPointPositionChanged -= OnControlPointPositionChanged;
				m_spline.ControlPointConnectionChanged -= OnControlPointConnectionChanged;
			}
			SplineBase.ConvergingSplineChanged -= OnIsConvergingChanged;
			SplineRuntimeEditor.Created -= OnRuntimeEditorCreated;
		}

		private void Update()
		{
			if (m_spline == null)
			{
				return;
			}
			if (base.transform.localPosition != m_localPosition)
			{
				if (m_spline.SetControlPointLocal(m_index, base.transform.localPosition))
				{
					m_localPosition = base.transform.localPosition;
				}
				else
				{
					base.transform.localPosition = m_localPosition;
				}
			}
			if (base.transform.rotation != m_rotation)
			{
				if (m_index % 3 == 0)
				{
					Vector3 vector = Vector3.back;
					int num = m_index - 1;
					if (num < 0)
					{
						num = m_index + 1;
						vector = Vector3.forward;
					}
					Vector3 controlPoint = m_spline.GetControlPoint(num);
					Vector3 controlPoint2 = m_spline.GetControlPoint(m_index);
					Vector3 vector2 = (base.transform.rotation * vector).normalized * (controlPoint2 - controlPoint).magnitude;
					Twist twist = m_spline.GetTwist(m_index);
					m_rotation = base.transform.rotation;
					twist.Data = base.transform.eulerAngles.z;
					m_updateAngle = false;
					m_spline.SetTwist(m_index, twist);
					m_spline.SetControlPoint(num, controlPoint2 + vector2);
					m_updateAngle = true;
				}
				else
				{
					base.transform.rotation = m_rotation;
				}
			}
			Thickness thickness = m_spline.GetThickness(m_index);
			Vector3 vector3 = thickness.Data;
			if (base.transform.localScale != vector3)
			{
				thickness.Data = base.transform.localScale;
				m_spline.SetThickness(m_index, thickness);
			}
		}

		private void OnControlPointThicknessChanged(int pointIndex)
		{
			if ((m_index + 1) / 3 == (pointIndex + 1) / 3)
			{
				base.transform.localScale = m_spline.GetThickness(pointIndex).Data;
			}
		}

		private void OnControlPointTwistChanged(int pointIndex)
		{
			if (m_updateAngle && (m_index + 1) % 3 == (pointIndex + 1) % 3)
			{
				UpdateAngle();
			}
		}

		private void OnRuntimeEditorCreated(object sender, EventArgs e)
		{
			CreateRuntimeComponents();
		}

		private void OnIsConvergingChanged(object sender, EventArgs e)
		{
			if (m_spline.IsSelected)
			{
				UpdateRenderersState();
			}
		}

		private void OnControlPointModeChanged(int pointIndex)
		{
			if (pointIndex == m_index)
			{
				UpdateRenderersState();
			}
		}

		private void OnControlPointPositionChanged(int pointIndex)
		{
			if (!(m_spline == null) && m_updateAngle)
			{
				if (pointIndex == m_index)
				{
					m_localPosition = m_spline.GetControlPointLocal(pointIndex);
					base.transform.localPosition = m_localPosition;
					UpdateAngle();
				}
				else if (pointIndex == m_index - 1 || pointIndex == m_index + 1)
				{
					UpdateAngle();
				}
			}
		}

		private void OnControlPointConnectionChanged(int pointIndex)
		{
			if (pointIndex == m_index)
			{
				UpdateRenderersState();
			}
		}

		public void UpdateAngle(bool forceUpdateAngle = false)
		{
			if (m_spline == null)
			{
				return;
			}
			Twist twist = m_spline.GetTwist(m_index);
			int num = m_index % 3;
			if (num == 0)
			{
				int num2 = m_index - 1;
				if (num2 > 0)
				{
					Vector3 controlPoint = m_spline.GetControlPoint(num2);
					Vector3 controlPoint2 = m_spline.GetControlPoint(m_index);
					m_rotation = Quaternion.AngleAxis(twist.Data, controlPoint2 - controlPoint) * Quaternion.LookRotation(controlPoint2 - controlPoint);
					base.transform.rotation = m_rotation;
				}
				else
				{
					int index = m_index + 1;
					Vector3 controlPoint3 = m_spline.GetControlPoint(m_index);
					Vector3 controlPoint4 = m_spline.GetControlPoint(index);
					m_rotation = Quaternion.AngleAxis(twist.Data, controlPoint4 - controlPoint3) * Quaternion.LookRotation(controlPoint4 - controlPoint3);
					base.transform.rotation = m_rotation;
				}
			}
			else if ((1u | (forceUpdateAngle ? 1u : 0u)) != 0)
			{
				if (num == 1)
				{
					int index2 = m_index - 1;
					Vector3 controlPoint5 = m_spline.GetControlPoint(index2);
					Vector3 controlPoint6 = m_spline.GetControlPoint(m_index);
					m_rotation = Quaternion.AngleAxis(twist.Data, controlPoint6 - controlPoint5) * Quaternion.LookRotation(controlPoint6 - controlPoint5);
					base.transform.rotation = m_rotation;
				}
				else
				{
					int index3 = m_index + 1;
					Vector3 controlPoint7 = m_spline.GetControlPoint(m_index);
					Vector3 controlPoint8 = m_spline.GetControlPoint(index3);
					m_rotation = Quaternion.AngleAxis(twist.Data, controlPoint8 - controlPoint7) * Quaternion.LookRotation(controlPoint8 - controlPoint7);
					base.transform.rotation = m_rotation;
				}
			}
		}

		private void UpdateRenderersState()
		{
			if (m_index == 0 || m_index == 1)
			{
				if (m_spline.PrevSpline != null)
				{
					if (m_renderer != null)
					{
						m_renderer.enabled = !m_spline.IsControlPointLocked(m_index);
					}
				}
				else if (m_renderer != null && !m_renderer.enabled)
				{
					m_renderer.enabled = true;
				}
			}
			else if (m_index == m_spline.ControlPointCount - 1 || m_index == m_spline.ControlPointCount - 2)
			{
				if (m_spline.NextSpline != null)
				{
					if (m_renderer != null)
					{
						m_renderer.enabled = !m_spline.IsControlPointLocked(m_index);
					}
				}
				else if (m_renderer != null && !m_renderer.enabled)
				{
					m_renderer.enabled = true;
				}
			}
			else if (m_renderer != null && !m_renderer.enabled)
			{
				m_renderer.enabled = true;
			}
			if ((bool)SplineBase.ConvergingSpline)
			{
				if (m_spline.Loop && (m_index == 0 || m_index == m_spline.ControlPointCount - 1) && m_renderer != null)
				{
					m_renderer.enabled = false;
				}
				if ((m_index % 3 != 0 || m_spline == SplineBase.ConvergingSpline) && m_renderer != null)
				{
					m_renderer.enabled = false;
				}
			}
			UpdateMaterial();
		}

		private void UpdateMaterial()
		{
			if (!(m_renderer != null))
			{
				return;
			}
			SplineRuntimeEditor instance = SplineRuntimeEditor.Instance;
			if (!(instance != null))
			{
				return;
			}
			if (m_index % 3 == 0)
			{
				if (m_spline.HasBranches(m_index))
				{
					m_renderer.sharedMaterial = instance.ConnectedMaterial;
				}
				else
				{
					m_renderer.sharedMaterial = instance.NormalMaterial;
				}
			}
			else if (m_index < m_spline.ControlPointCount)
			{
				switch (m_spline.GetControlPointMode(m_index))
				{
				case ControlPointMode.Mirrored:
					m_renderer.sharedMaterial = instance.MirroredModeMaterial;
					break;
				case ControlPointMode.Aligned:
					m_renderer.sharedMaterial = instance.AlignedModeMaterial;
					break;
				default:
					m_renderer.sharedMaterial = instance.FreeModeMaterial;
					break;
				}
			}
		}

		private void CreateRuntimeComponents()
		{
			SplineRuntimeEditor instance = SplineRuntimeEditor.Instance;
			if (instance != null)
			{
				m_renderer = GetComponent<MeshRenderer>();
				if (!m_renderer)
				{
					m_renderer = base.gameObject.AddComponent<MeshRenderer>();
				}
				MeshFilter meshFilter = GetComponent<MeshFilter>();
				if (!meshFilter)
				{
					meshFilter = base.gameObject.AddComponent<MeshFilter>();
				}
				if (!meshFilter.sharedMesh)
				{
					meshFilter.sharedMesh = instance.ControlPointMesh;
					UpdateMaterial();
				}
				if (!base.gameObject.GetComponent<ExposeToEditor>())
				{
					base.gameObject.AddComponent<ExposeToEditor>();
				}
			}
		}

		public void DestroyRuntimeComponents()
		{
			MeshRenderer component = GetComponent<MeshRenderer>();
			if ((bool)component)
			{
				UnityEngine.Object.DestroyImmediate(component);
			}
			MeshFilter component2 = GetComponent<MeshFilter>();
			if ((bool)component2)
			{
				UnityEngine.Object.DestroyImmediate(component2);
			}
			ExposeToEditor component3 = base.gameObject.GetComponent<ExposeToEditor>();
			if ((bool)component3)
			{
				UnityEngine.Object.DestroyImmediate(component3);
			}
		}
	}
}
