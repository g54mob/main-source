using System.Collections.Generic;
using ModApi;
using UnityEngine;
using UnityEngine.Rendering;
using Vectrosity;

namespace Assets.Scripts.Tools.ObjectTransform
{
	public class RotateGizmoAxisScript : GizmoAxisScript
	{
		private Color _defaultColor;

		private MeshCollider _hitCollider;

		private RotateGizmo _rotateTool;

		private Color _selectedColor;

		private Color _unSelectedColor;

		private VectorLine _vectorLine;

		private MeshRenderer _vectorLineRenderer;

		public Utilities.UnityTransform.TransformAxis Axis { get; set; }

		public static RotateGizmoAxisScript Create(RotateGizmo rotateGizmo, Transform parent, Utilities.UnityTransform.TransformAxis axis, Color color, float lineSize)
		{
			string text = axis.ToString();
			VectorLine vectorLine = new VectorLine("Rotate gizmo line - " + text, new List<Vector3>(100), lineSize);
			vectorLine.MakeCircle(Vector3.zero, 0f);
			vectorLine.Draw3DAuto();
			vectorLine.layer = 10;
			GameObject gameObject = new GameObject(text);
			gameObject.transform.SetParent(parent, worldPositionStays: false);
			RotateGizmoAxisScript rotateGizmoAxisScript = gameObject.AddComponent<RotateGizmoAxisScript>();
			rotateGizmoAxisScript.Axis = axis;
			rotateGizmoAxisScript._vectorLine = vectorLine;
			rotateGizmoAxisScript._vectorLineRenderer = vectorLine.rectTransform.gameObject.GetComponent<MeshRenderer>();
			GameObject gameObject2 = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
			gameObject2.name = "Collider";
			gameObject2.transform.SetParent(gameObject.transform, worldPositionStays: false);
			Object.DestroyImmediate(gameObject2.GetComponent<CapsuleCollider>());
			rotateGizmoAxisScript._hitCollider = gameObject2.gameObject.AddComponent<MeshCollider>();
			rotateGizmoAxisScript._hitCollider.convex = true;
			rotateGizmoAxisScript._hitCollider.isTrigger = true;
			rotateGizmoAxisScript._hitCollider.transform.localScale = new Vector3(1.1f, 0.1f, 1.1f);
			Object.Destroy(gameObject2.GetComponent<MeshRenderer>());
			color = color.linear;
			rotateGizmoAxisScript._vectorLineRenderer.material = Game.Instance.ResourceLoader.Load<Material>("Design/Materials/RotateToolLines");
			rotateGizmoAxisScript._vectorLineRenderer.shadowCastingMode = ShadowCastingMode.Off;
			rotateGizmoAxisScript._vectorLineRenderer.material.SetColor("_Color", color);
			rotateGizmoAxisScript._vectorLineRenderer.material.SetColor("_BlendColor", new Color32(65, 65, 65, byte.MaxValue));
			rotateGizmoAxisScript._defaultColor = color;
			rotateGizmoAxisScript._selectedColor = color * 1.25f;
			rotateGizmoAxisScript._unSelectedColor = new Color(0.4f, 0.5f, 0.6f);
			rotateGizmoAxisScript._rotateTool = rotateGizmo;
			Utilities.SetLayerRecursive(rotateGizmoAxisScript.gameObject, 10);
			return rotateGizmoAxisScript;
		}

		public void UpdateGizmo(Vector3 position, Vector3 direction, float scale, float cameraDist)
		{
			_vectorLine.MakeCircle(position, direction, scale);
			_vectorLineRenderer.material.SetFloat("_ClipDist", cameraDist);
			base.transform.up = direction;
			base.transform.localScale = Vector3.one * scale * 2f;
		}

		protected virtual void OnDestroy()
		{
			VectorLine.Destroy(ref _vectorLine);
		}

		protected virtual void Update()
		{
			RotateGizmoAxisScript rotateGizmoBeingDragged = _rotateTool.RotateGizmoBeingDragged;
			if (rotateGizmoBeingDragged == null)
			{
				_vectorLineRenderer.material.SetColor("_Color", _defaultColor);
			}
			else if (rotateGizmoBeingDragged == this)
			{
				_vectorLineRenderer.material.SetColor("_Color", _selectedColor);
			}
			else
			{
				_vectorLineRenderer.material.SetColor("_Color", _unSelectedColor);
			}
		}
	}
}
