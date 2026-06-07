using System;
using UnityEngine;

namespace Mystery.Graphing
{
	public abstract class IGraphConsoleRenderer : MonoBehaviour
	{
		public Vector2 Size = Vector2.one;

		[Range(0f, 1f)]
		public float Zoom;

		[Range(-1f, 1f)]
		public float Pan;

		public Material Material;

		private IGraphConsole graphConsole;

		private void OnValidate()
		{
			RefreshGraph();
		}

		private void OnEnable()
		{
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Combine(Camera.onPostRender, new Camera.CameraCallback(OnCameraRender));
			if (Material == null)
			{
				Material = BuiltInGraphShader.GetLineMaterial();
			}
		}

		private void OnDisable()
		{
			Camera.onPostRender = (Camera.CameraCallback)Delegate.Remove(Camera.onPostRender, new Camera.CameraCallback(OnCameraRender));
		}

		private void InitGraph()
		{
			if (graphConsole == null)
			{
				RefreshGraph();
			}
		}

		public void RefreshGraph()
		{
			graphConsole = LoadGraph();
		}

		protected abstract IGraphConsole LoadGraph();

		private Matrix4x4 GetTransformMatrix()
		{
			return base.transform.localToWorldMatrix * Matrix4x4.Scale(Size);
		}

		private Matrix4x4 GetTransformMatrix(RectTransform rectTransform)
		{
			return GetTransformMatrix() * Matrix4x4.Scale(new Vector3(rectTransform.rect.width, rectTransform.rect.height, 1f));
		}

		private void OnCameraRender(Camera camera)
		{
			Render(camera, pixelMatrix: false);
		}

		private void OnDrawGizmos()
		{
			if (Material == null)
			{
				Material = BuiltInGraphShader.GetLineMaterial();
			}
			Render(Camera.current, pixelMatrix: false);
			Gizmos.matrix = GetTransformMatrix();
			Gizmos.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(1f, 0f, 0f));
			Gizmos.DrawLine(new Vector3(0f, 1f, 0f), new Vector3(1f, 1f, 0f));
			Gizmos.DrawLine(new Vector3(0f, 0f, 0f), new Vector3(0f, 1f, 0f));
			Gizmos.DrawLine(new Vector3(1f, 0f, 0f), new Vector3(1f, 1f, 0f));
			Gizmos.matrix = Matrix4x4.identity;
		}

		private void Render(Camera camera, bool pixelMatrix)
		{
			InitGraph();
			if (graphConsole != null)
			{
				graphConsole.Zoom = Zoom;
				graphConsole.Pan = Pan;
				if (Material != null)
				{
					Material.SetPass(0);
				}
				GL.PushMatrix();
				if (pixelMatrix)
				{
					GL.LoadPixelMatrix();
					GL.MultMatrix(GetTransformMatrix(GetComponent<RectTransform>()));
				}
				else
				{
					GL.LoadProjectionMatrix(camera.projectionMatrix);
					GL.MultMatrix(GetTransformMatrix());
				}
				graphConsole.PlotGLLines();
				GL.PopMatrix();
			}
		}
	}
}
