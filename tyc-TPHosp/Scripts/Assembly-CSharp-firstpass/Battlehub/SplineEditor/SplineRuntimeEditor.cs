using System;
using System.Linq;
using Battlehub.RTEditor;
using Battlehub.RTHandles;
using UnityEngine;

namespace Battlehub.SplineEditor
{
	[ExecuteInEditMode]
	public class SplineRuntimeEditor : MonoBehaviour
	{
		public Camera Camera;

		public float SelectionMargin = 20f;

		public static readonly Color MirroredModeColor = Color.red;

		public static readonly Color AlignedModeColor = Color.blue;

		public static readonly Color FreeModeColor = Color.yellow;

		public static readonly Color ControlPointLineColor = Color.gray;

		private Material m_connectedMaterial;

		private Material m_normalMaterial;

		private Material m_mirroredModeMaterial;

		private Material m_alignedModeMaterial;

		private Material m_freeModeMaterial;

		private Mesh m_controlPointMesh;

		private bool m_isApplicationQuit;

		private static SplineRuntimeEditor m_instance;

		public Mesh ControlPointMesh => m_controlPointMesh;

		public Material ConnectedMaterial => m_connectedMaterial;

		public Material MirroredModeMaterial => m_mirroredModeMaterial;

		public Material AlignedModeMaterial => m_alignedModeMaterial;

		public Material FreeModeMaterial => m_freeModeMaterial;

		public Material NormalMaterial => m_normalMaterial;

		public static SplineRuntimeEditor Instance => m_instance;

		public static event EventHandler Created;

		public static event EventHandler Destroyed;

		private void Awake()
		{
			if (Camera == null)
			{
				Camera = Camera.main;
				if (Camera.main == null)
				{
					Debug.LogError("Add Camera with MainCamera Tag");
				}
			}
			if (m_instance != null)
			{
				Debug.LogWarning("Another instance of SplineEditorSettings already exist");
			}
			if (m_mirroredModeMaterial == null)
			{
				Shader shader = Shader.Find("Battlehub/SplineEditor/SSBillboard");
				m_mirroredModeMaterial = new Material(shader);
				m_mirroredModeMaterial.name = "MirroredModeMaterial";
				m_mirroredModeMaterial.color = MirroredModeColor;
				m_mirroredModeMaterial.SetInt("_Cull", 0);
				m_mirroredModeMaterial.SetInt("_ZWrite", 1);
				m_mirroredModeMaterial.SetInt("_ZTest", 8);
			}
			if (m_alignedModeMaterial == null)
			{
				m_alignedModeMaterial = UnityEngine.Object.Instantiate(m_mirroredModeMaterial);
				m_alignedModeMaterial.name = "AlignedModeMaterial";
				m_alignedModeMaterial.color = AlignedModeColor;
			}
			if (m_freeModeMaterial == null)
			{
				m_freeModeMaterial = UnityEngine.Object.Instantiate(m_mirroredModeMaterial);
				m_freeModeMaterial.name = "FreeModeMaterial";
				m_freeModeMaterial.color = FreeModeColor;
			}
			if (m_normalMaterial == null)
			{
				m_normalMaterial = UnityEngine.Object.Instantiate(m_mirroredModeMaterial);
				m_normalMaterial.name = "SplineMaterial";
				m_normalMaterial.color = Color.green;
			}
			if (m_connectedMaterial == null)
			{
				m_connectedMaterial = UnityEngine.Object.Instantiate(m_mirroredModeMaterial);
				m_connectedMaterial.name = "BranchMaterial";
				m_connectedMaterial.color = new Color32(165, 0, byte.MaxValue, byte.MaxValue);
			}
			if (m_controlPointMesh == null)
			{
				m_controlPointMesh = new Mesh();
				m_controlPointMesh.name = "control point mesh";
				m_controlPointMesh.vertices = new Vector3[4]
				{
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 0f, 0f),
					new Vector3(0f, 0f, 0f)
				};
				m_controlPointMesh.triangles = new int[6] { 0, 1, 2, 0, 2, 3 };
				m_controlPointMesh.uv = new Vector2[4]
				{
					new Vector2(-1f, -1f),
					new Vector2(1f, -1f),
					new Vector2(1f, 1f),
					new Vector2(-1f, 1f)
				};
				m_controlPointMesh.RecalculateBounds();
			}
			m_instance = this;
			EnableRuntimeEditing();
			RuntimeSelection.SelectionChanged += OnRuntimeSelectionChanged;
		}

		private void Start()
		{
			if (SplineRuntimeEditor.Created != null)
			{
				SplineRuntimeEditor.Created(this, EventArgs.Empty);
			}
		}

		private void OnApplicationQuit()
		{
			m_isApplicationQuit = true;
		}

		private void OnDestroy()
		{
			if (!Application.isPlaying)
			{
				DisableRuntimeEditing();
			}
			bool flag = false;
			if (!m_isApplicationQuit && !flag)
			{
				SplineControlPoint[] array = Resources.FindObjectsOfTypeAll<SplineControlPoint>();
				foreach (SplineControlPoint splineControlPoint in array)
				{
					if (splineControlPoint != null)
					{
						splineControlPoint.DestroyRuntimeComponents();
					}
				}
			}
			if (SplineRuntimeEditor.Destroyed != null)
			{
				SplineRuntimeEditor.Destroyed(this, EventArgs.Empty);
			}
			RuntimeSelection.SelectionChanged -= OnRuntimeSelectionChanged;
			m_instance = null;
		}

		private void DisableRuntimeEditing()
		{
			if (Camera != null)
			{
				GLCamera component = Camera.GetComponent<GLCamera>();
				if (component != null)
				{
					UnityEngine.Object.DestroyImmediate(component);
				}
			}
		}

		private void EnableRuntimeEditing()
		{
			if (!(Camera == null) && !Camera.GetComponent<GLCamera>())
			{
				Camera.gameObject.AddComponent<GLCamera>();
			}
		}

		private void LateUpdate()
		{
			if (!(m_instance == null))
			{
				return;
			}
			m_instance = this;
			SplineBase[] array = UnityEngine.Object.FindObjectsOfType<SplineBase>();
			foreach (SplineBase splineBase in array)
			{
				if (splineBase.IsSelected)
				{
					splineBase.Select();
				}
			}
		}

		private void OnRuntimeSelectionChanged(UnityEngine.Object[] unselected)
		{
			SplineBase splineBase = null;
			int minIndex = -1;
			float num = float.PositiveInfinity;
			if (unselected != null)
			{
				GameObject[] array = unselected.OfType<GameObject>().ToArray();
				foreach (GameObject gameObject in array)
				{
					if (gameObject == null)
					{
						continue;
					}
					SplineBase componentInParent = gameObject.GetComponentInParent<SplineBase>();
					if (!(componentInParent == null))
					{
						componentInParent.Select();
						float resultDistance = num;
						SplineBase resultSpline;
						int num2 = HitTestRecursive(componentInParent.Root, num, out resultSpline, out resultDistance);
						if (resultDistance < num && num2 != -1)
						{
							num = resultDistance;
							minIndex = num2;
							splineBase = resultSpline;
						}
						componentInParent.Unselect();
					}
				}
				if (splineBase != null)
				{
					SplineControlPoint splineControlPoint = (from p in splineBase.GetSplineControlPoints()
						where p.Index == minIndex
						select p).FirstOrDefault();
					if (splineControlPoint != null)
					{
						RuntimeSelection.activeObject = splineControlPoint.gameObject;
					}
					splineBase.Select();
					return;
				}
			}
			if (RuntimeSelection.gameObjects == null)
			{
				return;
			}
			GameObject[] gameObjects = RuntimeSelection.gameObjects;
			if (gameObjects == null)
			{
				return;
			}
			for (int num3 = 0; num3 < gameObjects.Length; num3++)
			{
				SplineBase componentInParent2 = gameObjects[num3].GetComponentInParent<SplineBase>();
				if (componentInParent2 != null)
				{
					componentInParent2.Select();
				}
			}
		}

		private int HitTestRecursive(SplineBase spline, float distance, out SplineBase resultSpline, out float resultDistance)
		{
			resultSpline = null;
			resultDistance = float.MaxValue;
			int result = -1;
			float minDistance;
			int num = HitTest(spline, out minDistance);
			if (num > -1 && minDistance < distance)
			{
				resultSpline = spline;
				resultDistance = minDistance;
				distance = minDistance;
				result = num;
			}
			if (spline.Children != null)
			{
				for (int i = 0; i < spline.Children.Length; i++)
				{
					SplineBase spline2 = spline.Children[i];
					SplineBase resultSpline2;
					float resultDistance2;
					int num2 = HitTestRecursive(spline2, distance, out resultSpline2, out resultDistance2);
					if (num2 > -1)
					{
						resultSpline = resultSpline2;
						resultDistance = resultDistance2;
						distance = minDistance;
						result = num2;
					}
				}
			}
			return result;
		}

		private int HitTest(SplineBase spline, out float minDistance)
		{
			minDistance = float.PositiveInfinity;
			if (Camera == null)
			{
				Debug.LogError("Camera is null");
				return -1;
			}
			if (RuntimeSelection.gameObjects == null)
			{
				return -1;
			}
			Vector3[] array = new Vector3[spline.ControlPointCount];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = spline.GetControlPoint(i);
			}
			minDistance = SelectionMargin * SelectionMargin;
			int result = -1;
			Vector2 vector = Input.mousePosition;
			for (int j = 0; j < array.Length; j++)
			{
				Vector3 position = array[j];
				if (!spline.IsControlPointLocked(j))
				{
					float sqrMagnitude = ((Vector2)Camera.WorldToScreenPoint(position) - vector).sqrMagnitude;
					if (sqrMagnitude < minDistance)
					{
						minDistance = sqrMagnitude;
						result = j;
					}
				}
			}
			return result;
		}

		public void OnClosed()
		{
			if (RuntimeSelection.gameObjects == null)
			{
				return;
			}
			GameObject[] array = RuntimeSelection.gameObjects.OfType<GameObject>().ToArray();
			foreach (GameObject gameObject in array)
			{
				if (!(gameObject == null))
				{
					SplineBase componentInParent = gameObject.GetComponentInParent<SplineBase>();
					if (!(componentInParent == null))
					{
						componentInParent.Unselect();
					}
				}
			}
		}

		public void OnOpened()
		{
		}
	}
}
