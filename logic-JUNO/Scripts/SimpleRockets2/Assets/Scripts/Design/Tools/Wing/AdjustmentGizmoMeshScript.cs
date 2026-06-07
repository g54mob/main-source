using System.Collections.Generic;
using DG.Tweening;
using ModApi;
using UnityEngine;
using UnityEngine.Rendering;
using Vectrosity;

namespace Assets.Scripts.Design.Tools.Wing
{
	public class AdjustmentGizmoMeshScript : MonoBehaviour
	{
		private float _animatedScale;

		private VectorLine _connectingLine;

		private GameObject _gizmoBase;

		private GameObject _gizmoPrefab;

		private Color _initialColor;

		private bool _isSelected;

		private GameObject _scaledObjectsContainer;

		[SerializeField]
		private bool _screenSizeConstant = true;

		private Camera _screenSizeConstantCamera;

		private bool _visible = true;

		public Vector3 GizmoFlyoutDirection { get; set; }

		public bool IsSelected
		{
			get
			{
				return _isSelected;
			}
			set
			{
				if (value != _isSelected)
				{
					_isSelected = value;
					MeshRenderer mesh = Mesh;
					if (value)
					{
						mesh.material.color = new Color32(247, byte.MaxValue, 109, byte.MaxValue);
					}
					else
					{
						mesh.material.color = _initialColor;
					}
				}
			}
		}

		public bool ScreenSizeConstant
		{
			get
			{
				return _screenSizeConstant;
			}
			set
			{
				_screenSizeConstant = value;
			}
		}

		private Vector3 StartingPosition { get; set; }

		private float FlyoutDistance { get; set; }

		private MeshRenderer Mesh { get; set; }

		public static AdjustmentGizmoMeshScript Create(Transform parent, Vector3 gizmoFlyoutDirection, float gizmoFlyoutDistance, bool screenSizeConstant, Camera screenSizeConstantCamera, Color color)
		{
			Transform transform = new GameObject("Gizmo").transform;
			transform.SetParent(parent);
			transform.localPosition = Vector3.zero;
			GameObject gameObject = Object.Instantiate(Resources.Load("Design/Tools/NudgeGizmo")) as GameObject;
			MeshRenderer componentInChildren = gameObject.GetComponentInChildren<MeshRenderer>();
			componentInChildren.receiveShadows = false;
			componentInChildren.shadowCastingMode = ShadowCastingMode.Off;
			if (Device.IsMobileBuild)
			{
				componentInChildren.gameObject.AddComponent<BoxCollider>().size = new Vector3(2f, 2f, 3f);
			}
			else
			{
				componentInChildren.gameObject.AddComponent<MeshCollider>().convex = true;
			}
			GameObject gameObject2 = new GameObject("ScaledObjectsContainer");
			gameObject2.transform.SetParent(transform);
			gameObject2.transform.localPosition = Vector3.zero;
			gameObject.transform.SetParent(gameObject2.transform, worldPositionStays: false);
			gameObject.transform.forward = gizmoFlyoutDirection;
			gameObject.GetComponentInChildren<Renderer>().material.color = color;
			AdjustmentGizmoMeshScript adjustmentGizmoMeshScript = transform.gameObject.AddComponent<AdjustmentGizmoMeshScript>();
			adjustmentGizmoMeshScript.GizmoFlyoutDirection = gizmoFlyoutDirection;
			adjustmentGizmoMeshScript._gizmoPrefab = gameObject;
			adjustmentGizmoMeshScript.ScreenSizeConstant = screenSizeConstant;
			adjustmentGizmoMeshScript._screenSizeConstantCamera = screenSizeConstantCamera;
			adjustmentGizmoMeshScript.FlyoutDistance = gizmoFlyoutDistance;
			adjustmentGizmoMeshScript.transform.localPosition = Vector3.zero;
			adjustmentGizmoMeshScript._scaledObjectsContainer = gameObject2;
			adjustmentGizmoMeshScript.Mesh = componentInChildren;
			adjustmentGizmoMeshScript._gizmoBase = GameObject.CreatePrimitive(PrimitiveType.Sphere);
			adjustmentGizmoMeshScript._gizmoBase.GetComponent<MeshRenderer>().shadowCastingMode = ShadowCastingMode.Off;
			adjustmentGizmoMeshScript._gizmoBase.transform.localScale = new Vector3(0.125f, 0.125f, 0.125f);
			adjustmentGizmoMeshScript._gizmoBase.transform.parent = gameObject2.transform;
			adjustmentGizmoMeshScript._gizmoBase.GetComponent<Renderer>().material.color = color;
			adjustmentGizmoMeshScript._gizmoBase.transform.localPosition = Vector3.zero;
			Object.DestroyImmediate(adjustmentGizmoMeshScript._gizmoBase.GetComponent<SphereCollider>());
			Utilities.ChangeLayersOfGameObjectAndChildrenRecursive(transform.gameObject, 10);
			return adjustmentGizmoMeshScript;
		}

		public void OnDestroy()
		{
			if (_connectingLine != null)
			{
				_connectingLine.StopDrawing3DAuto();
				VectorLine.Destroy(ref _connectingLine);
			}
		}

		public void SetVisibility(bool visible)
		{
			if (_visible != visible)
			{
				_visible = visible;
				base.gameObject.SetActive(visible);
				if (_connectingLine != null)
				{
					_connectingLine.active = visible;
				}
				if (visible)
				{
					UpdateConnectingLine();
				}
			}
		}

		public void Start()
		{
			StartingPosition = Mesh.transform.position;
			_initialColor = Mesh.material.color;
			float num = (Device.IsMobileBuild ? 1.25f : 1f);
			float num2 = 0.5f * num;
			float endValue = 0.35f * num;
			_animatedScale = num2;
			Mesh.transform.localScale = new Vector3(num2, num2, num2);
			ScaleContainer();
			_gizmoPrefab.transform.DOLocalMove(_gizmoPrefab.transform.localPosition + FlyoutDistance * GizmoFlyoutDirection.normalized, 0.6f).SetEase(Ease.OutExpo);
			DOTween.To(() => _animatedScale, delegate(float x)
			{
				_animatedScale = x;
			}, endValue, 1f).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
		}

		public void Update()
		{
			if (_visible)
			{
				if (_connectingLine == null)
				{
					_connectingLine = new VectorLine("ConnectingLine", new List<Vector3>(2)
					{
						Vector3.zero,
						Vector3.zero
					}, null, 2f);
					_connectingLine.color = Color.white;
					_connectingLine.rectTransform.gameObject.layer = 0;
					_connectingLine.rectTransform.transform.SetParent(base.transform, worldPositionStays: true);
					_connectingLine.layer = 10;
					_connectingLine.Draw3DAuto();
				}
				UpdateConnectingLine();
				Mesh.transform.localScale = new Vector3(_animatedScale, _animatedScale, _animatedScale);
				ScaleContainer();
			}
		}

		private void ScaleContainer()
		{
			if (ScreenSizeConstant)
			{
				float num = 0.05f * Game.UiScale;
				float num2 = Vector3.Distance(_screenSizeConstantCamera.transform.position, base.transform.position);
				float num3 = _screenSizeConstantCamera.fieldOfView / 60f;
				float num4 = num * num2 * num3;
				_scaledObjectsContainer.transform.localScale = new Vector3(num4, num4, num4);
			}
			else
			{
				_scaledObjectsContainer.transform.localScale = Vector3.one;
			}
		}

		private void UpdateConnectingLine()
		{
			if (_connectingLine != null)
			{
				_connectingLine.points3[0] = _gizmoBase.transform.position;
				_connectingLine.points3[1] = Mesh.transform.position;
			}
		}
	}
}
