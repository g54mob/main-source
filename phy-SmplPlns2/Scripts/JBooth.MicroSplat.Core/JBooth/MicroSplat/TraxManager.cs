using UnityEngine;

namespace JBooth.MicroSplat
{
	[ExecuteInEditMode]
	public class TraxManager : MonoBehaviour
	{
		public enum Precision
		{
			Half = 0,
			Full = 1
		}

		public Precision precision = Precision.Full;

		public int bufferSize = 1024;

		public float worldSize = 128f;

		public LayerMask layerMask;

		public bool useTime;

		public float repairDelay;

		public float repairRate;

		public float repairTotal;

		public float bufferBlend = 0.5f;

		public float collsionDistance = 1f;

		public float sinkStrength = 0.5f;

		public int bufferBlits = 1;

		[HideInInspector]
		public Camera cam;

		private RenderTexture depthRT;

		private RenderTexture bufferA;

		private RenderTexture bufferB;

		private bool bufferBActive;

		private Material bufferCopyMat;

		private Vector3 lastPosition = Vector3.zero;

		private Texture2D bufferFetch;

		public void Setup()
		{
			TearDown();
			RenderTextureDescriptor desc;
			if (precision == Precision.Full)
			{
				depthRT = new RenderTexture(bufferSize, bufferSize, 32, RenderTextureFormat.Depth, RenderTextureReadWrite.Linear)
				{
					name = "rtTraxDepth"
				};
				desc = ((!useTime || (!(repairTotal > 0f) && !(repairDelay > 0f))) ? new RenderTextureDescriptor(bufferSize, bufferSize, RenderTextureFormat.RFloat, 0) : new RenderTextureDescriptor(bufferSize, bufferSize, RenderTextureFormat.RGFloat, 0));
			}
			else
			{
				depthRT = new RenderTexture(bufferSize, bufferSize, 16, RenderTextureFormat.Depth, RenderTextureReadWrite.Linear)
				{
					name = "rtTraxDepth"
				};
				desc = ((!useTime) ? new RenderTextureDescriptor(bufferSize, bufferSize, RenderTextureFormat.RHalf, 0) : new RenderTextureDescriptor(bufferSize, bufferSize, RenderTextureFormat.RGFloat, 0));
			}
			bufferA = new RenderTexture(desc)
			{
				name = "rtTraxBufferA"
			};
			bufferB = new RenderTexture(desc)
			{
				name = "rtTraxBufferB"
			};
			if (cam == null)
			{
				GameObject gameObject = new GameObject("Trax Camera");
				gameObject.hideFlags = HideFlags.HideAndDontSave;
				cam = gameObject.AddComponent<Camera>();
			}
			cam.orthographic = true;
			cam.orthographicSize = worldSize;
			cam.transform.forward = Vector3.up;
			cam.orthographicSize = worldSize;
			cam.nearClipPlane = 0f;
			cam.farClipPlane = 2000f;
			cam.cullingMask = layerMask;
			cam.clearFlags = CameraClearFlags.Depth;
			bufferCopyMat = new Material(Shader.Find("Hidden/MicroSplat/TraxBuffer"));
			cam.transform.position = new Vector3(0f, -99999f, 0f);
			RenderTexture.active = bufferA;
			GL.Clear(clearDepth: true, clearColor: true, new Color(99999f, 0f, 0f));
			RenderTexture.active = bufferB;
			GL.Clear(clearDepth: true, clearColor: true, new Color(99999f, 0f, 0f));
			RenderTexture.active = depthRT;
			GL.Clear(clearDepth: true, clearColor: true, new Color(99999f, 0f, 0f));
		}

		public void TearDown()
		{
			RenderTexture.active = null;
			if (cam != null)
			{
				cam.targetTexture = null;
				Object.DestroyImmediate(cam.gameObject);
			}
			DisposeRenderTexture(ref depthRT);
			DisposeRenderTexture(ref bufferA);
			DisposeRenderTexture(ref bufferB);
			if (bufferCopyMat != null)
			{
				Object.DestroyImmediate(bufferCopyMat);
			}
			bufferCopyMat = null;
			cam = null;
		}

		private void DisposeRenderTexture(ref RenderTexture rt)
		{
			if (!(rt == null))
			{
				rt.Release();
				Object.DestroyImmediate(rt);
				rt = null;
			}
		}

		public float GetBufferAtPosition(Vector3 terrainPosition)
		{
			if (bufferA == null)
			{
				return 99999f;
			}
			if (bufferFetch == null)
			{
				bufferFetch = new Texture2D(1, 1, TextureFormat.RGBAFloat, mipChain: false, linear: true);
			}
			RenderTexture renderTexture = (bufferBActive ? bufferB : bufferA);
			Vector2 vector = (new Vector2(terrainPosition.x, terrainPosition.z) - new Vector2(base.transform.position.x, base.transform.position.z) + new Vector2(worldSize * 0.5f, worldSize * 0.5f)) / worldSize * renderTexture.width;
			int num = (int)vector.x;
			int num2 = (int)vector.y;
			if (num > renderTexture.width || num2 > renderTexture.height || num < 0 || num2 < 0)
			{
				return 99999f;
			}
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = renderTexture;
			bufferFetch.ReadPixels(new Rect(num, num2, 1f, 1f), 0, 0);
			bufferFetch.Apply();
			Color pixel = bufferFetch.GetPixel(0, 0);
			RenderTexture.active = active;
			return pixel.r;
		}

		private void OnEnable()
		{
			Setup();
		}

		private void OnDisable()
		{
			TearDown();
		}

		private float SnapToPixel(float v, int textureSize, float orthoSize)
		{
			float num = orthoSize * 2f / (float)textureSize;
			v = (int)(v / num);
			v *= num;
			return v;
		}

		private void LateUpdate()
		{
			Vector3 vector = base.transform.position + Vector3.up;
			vector.x = SnapToPixel(vector.x, bufferSize, worldSize);
			vector.z = SnapToPixel(vector.z, bufferSize, worldSize);
			vector.y -= 1000f;
			cam.transform.position = vector;
			Vector3 vector2 = lastPosition - vector;
			vector2.x = SnapToPixel(vector2.x, bufferSize, worldSize);
			vector2.z = SnapToPixel(vector2.z, bufferSize, worldSize);
			vector2.x /= worldSize;
			vector2.z /= worldSize;
			vector2.x *= 0.5f;
			vector2.z *= 0.5f;
			bufferCopyMat.SetVector(ShaderID._Offset, new Vector2(vector2.x, vector2.z));
			cam.targetTexture = depthRT;
			bufferCopyMat.SetTexture(ShaderID._DepthRT, depthRT);
			bufferCopyMat.SetFloat(ShaderID._RepairDelay, repairDelay);
			bufferCopyMat.SetFloat(ShaderID._RepairRate, 1f / Mathf.Max(0.001f, repairRate));
			bufferCopyMat.SetFloat(ShaderID._UseTime, useTime ? 1 : 0);
			bufferCopyMat.SetFloat(ShaderID._RepairTotal, repairTotal);
			bufferCopyMat.SetFloat(ShaderID._BufferBlend, bufferBlend);
			bufferCopyMat.SetFloat(ShaderID._SinkStrength, sinkStrength);
			bufferCopyMat.SetFloat(ShaderID._CamCaptureHeight, vector.y);
			bufferCopyMat.SetFloat(ShaderID._CamFarClipPlane, cam.farClipPlane);
			RenderTexture a = bufferA;
			RenderTexture b = bufferB;
			if (bufferBActive)
			{
				Swap(ref a, ref b);
			}
			Graphics.Blit(a, b, bufferCopyMat);
			bufferBActive = !bufferBActive;
			bufferCopyMat.SetVector(ShaderID._Offset, new Vector2(0f, 0f));
			bufferCopyMat.SetFloat(ShaderID._UseTime, 0f);
			Shader.SetGlobalTexture(ShaderID._GMSTraxBuffer, b);
			for (int i = 0; i < bufferBlits; i++)
			{
				Graphics.Blit(b, a, bufferCopyMat);
				bufferBActive = !bufferBActive;
				Shader.SetGlobalTexture(ShaderID._GMSTraxBuffer, a);
				Swap(ref a, ref b);
			}
			Shader.SetGlobalVector(ShaderID._GMSTraxBufferPosition, vector);
			Shader.SetGlobalFloat(ShaderID._GMSTraxBufferWorldSize, worldSize);
			Shader.SetGlobalFloat(ShaderID._GMSTraxFudgeFactor, collsionDistance);
			lastPosition = vector;
		}

		private void Swap<T>(ref T a, ref T b)
		{
			T val = a;
			a = b;
			b = val;
		}
	}
}
