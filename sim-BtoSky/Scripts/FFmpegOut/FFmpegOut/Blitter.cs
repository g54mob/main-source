using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace FFmpegOut
{
	internal sealed class Blitter : MonoBehaviour
	{
		private static Type[] _initialComponents = new Type[2]
		{
			typeof(Camera),
			typeof(Blitter)
		};

		private const int UILayer = 5;

		private Texture _sourceTexture;

		private Mesh _mesh;

		private Material _material;

		public static GameObject CreateInstance(Camera source)
		{
			GameObject obj = new GameObject("Blitter", _initialComponents)
			{
				hideFlags = HideFlags.HideInHierarchy
			};
			Camera component = obj.GetComponent<Camera>();
			component.cullingMask = 32;
			component.targetDisplay = source.targetDisplay;
			obj.GetComponent<Blitter>()._sourceTexture = source.targetTexture;
			return obj;
		}

		private void PreCull(Camera camera)
		{
			if (!(_mesh == null) && !(camera != GetComponent<Camera>()))
			{
				Graphics.DrawMesh(_mesh, base.transform.localToWorldMatrix, _material, 5, camera);
			}
		}

		private void BeginCameraRendering(ScriptableRenderContext context, Camera camera)
		{
			PreCull(camera);
		}

		private void Update()
		{
			if (_mesh == null)
			{
				_mesh = new Mesh();
				_mesh.vertices = new Vector3[3];
				_mesh.triangles = new int[3] { 0, 1, 2 };
				_mesh.bounds = new Bounds(Vector3.zero, Vector3.one);
				_mesh.UploadMeshData(markNoLongerReadable: true);
				Shader shader = Shader.Find("Hidden/FFmpegOut/Blitter");
				_material = new Material(shader);
				_material.SetTexture("_MainTex", _sourceTexture);
				RenderPipelineManager.beginCameraRendering += BeginCameraRendering;
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Combine(Camera.onPreCull, new Camera.CameraCallback(PreCull));
			}
		}

		private void OnDisable()
		{
			if (_mesh != null)
			{
				RenderPipelineManager.beginCameraRendering -= BeginCameraRendering;
				Camera.onPreCull = (Camera.CameraCallback)Delegate.Remove(Camera.onPreCull, new Camera.CameraCallback(PreCull));
				UnityEngine.Object.Destroy(_mesh);
				UnityEngine.Object.Destroy(_material);
				_mesh = null;
				_material = null;
			}
		}
	}
}
