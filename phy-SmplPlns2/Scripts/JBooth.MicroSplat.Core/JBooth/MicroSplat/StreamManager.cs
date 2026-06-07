using System.Collections.Generic;
using UnityEngine;

namespace JBooth.MicroSplat
{
	public class StreamManager : MonoBehaviour
	{
		public class UpdateBuffer
		{
			public Material updateMat;

			public int width;

			public int height;

			public virtual void Init(int w, int h)
			{
			}

			public virtual void Disable()
			{
			}

			public virtual void BlitA()
			{
			}

			public virtual void BlitB()
			{
			}

			public virtual RenderTexture GetCurrent()
			{
				return null;
			}
		}

		public class SRPBuffers : UpdateBuffer
		{
			public CustomRenderTexture buffer0;

			public CustomRenderTexture buffer1;

			public CustomRenderTexture currentBuffer;

			public override void BlitA()
			{
				updateMat.SetTexture("_MainTex", buffer0);
				buffer1.Update();
				currentBuffer = buffer1;
			}

			public override void BlitB()
			{
				updateMat.SetTexture("_MainTex", buffer1);
				buffer0.Update();
				currentBuffer = buffer0;
			}

			public override RenderTexture GetCurrent()
			{
				return currentBuffer;
			}

			public override void Init(int w, int h)
			{
				width = w;
				height = h;
				updateMat = new Material(Shader.Find("Hidden/MicroSplat/StreamUpdateSRP"));
				buffer0 = new CustomRenderTexture(w, h, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				buffer1 = new CustomRenderTexture(w, h, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				buffer0.initializationMode = CustomRenderTextureUpdateMode.OnDemand;
				buffer1.initializationMode = CustomRenderTextureUpdateMode.OnDemand;
				buffer0.updateMode = CustomRenderTextureUpdateMode.OnDemand;
				buffer1.updateMode = CustomRenderTextureUpdateMode.OnDemand;
				buffer0.initializationSource = CustomRenderTextureInitializationSource.TextureAndColor;
				buffer1.initializationSource = CustomRenderTextureInitializationSource.TextureAndColor;
				buffer0.initializationTexture = Texture2D.blackTexture;
				buffer1.initializationTexture = Texture2D.blackTexture;
				buffer0.depth = 0;
				buffer1.depth = 0;
				buffer0.material = updateMat;
				buffer1.material = updateMat;
				buffer0.Create();
				buffer1.Create();
				buffer0.Initialize();
				buffer1.Initialize();
			}

			public override void Disable()
			{
				buffer0.Release();
				buffer1.Release();
				Object.DestroyImmediate(buffer0);
				Object.DestroyImmediate(buffer1);
				Object.DestroyImmediate(updateMat);
				buffer0 = null;
				buffer1 = null;
				updateMat = null;
			}
		}

		public class StandardBuffers : UpdateBuffer
		{
			public RenderTexture buffer0;

			public RenderTexture buffer1;

			public RenderTexture currentBuffer;

			public override void BlitA()
			{
				Graphics.Blit(buffer0, buffer1, updateMat);
				currentBuffer = buffer1;
			}

			public override void BlitB()
			{
				Graphics.Blit(buffer1, buffer0, updateMat);
				currentBuffer = buffer0;
			}

			public override RenderTexture GetCurrent()
			{
				return currentBuffer;
			}

			public override void Init(int w, int h)
			{
				width = w;
				height = h;
				updateMat = new Material(Shader.Find("Hidden/MicroSplat/StreamUpdate"));
				buffer0 = new RenderTexture(w, h, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				buffer1 = new RenderTexture(w, h, 0, RenderTextureFormat.ARGB32, RenderTextureReadWrite.Linear);
				Graphics.Blit(Texture2D.blackTexture, buffer0);
				Graphics.Blit(Texture2D.blackTexture, buffer1);
			}

			public override void Disable()
			{
				buffer0.Release();
				buffer1.Release();
				Object.DestroyImmediate(buffer0);
				Object.DestroyImmediate(buffer1);
				Object.DestroyImmediate(updateMat);
				buffer0 = null;
				buffer1 = null;
				updateMat = null;
			}
		}

		private MicroSplatObject msObject;

		private bool onBuffer0 = true;

		public UpdateBuffer updateBuffer;

		private Vector4[] spawnBuffer = new Vector4[64];

		private Vector4[] colliderBuffer = new Vector4[64];

		public Vector2 evaporation = new Vector2(0.01f, 0.01f);

		public Vector2 strength = new Vector2(1f, 1f);

		public Vector2 speed = new Vector2(1f, 1f);

		public Vector2 resistance = new Vector2(0.1f, 0.1f);

		public float wetnessEvaporation = 0.01f;

		public float burnEvaporation = 0.01f;

		private List<StreamEmitter> emitters = new List<StreamEmitter>(16);

		private List<StreamCollider> colliders = new List<StreamCollider>(16);

		private double timeSinceWetnessEvap;

		private double timeSinceBurnEvap;

		private double timeSinceEvapX;

		private double timeSinceEvapY;

		private Vector2 evapAmount = new Vector2(0f, 0f);

		private static Vector2 WorldToTerrain(MicroSplatObject ter, Vector3 point, int width, int height)
		{
			Bounds bounds = ter.GetBounds();
			point = ter.transform.worldToLocalMatrix.MultiplyPoint(point);
			float x = point.x / bounds.size.x * (float)width;
			float y = point.z / bounds.size.z * (float)height;
			return new Vector2(x, y);
		}

		public void Register(StreamEmitter e)
		{
			emitters.Add(e);
		}

		public void Unregister(StreamEmitter e)
		{
			emitters.Remove(e);
		}

		public void Register(StreamCollider e)
		{
			colliders.Add(e);
		}

		public void Unregister(StreamCollider e)
		{
			colliders.Remove(e);
		}

		private void Awake()
		{
			msObject = GetComponent<MicroSplatObject>();
		}

		private void OnEnable()
		{
			MicroSplatObject.TerrainDescriptor terrainDescriptor = msObject.GetTerrainDescriptor();
			if (terrainDescriptor.heightMap == null)
			{
				Debug.LogError("Terrain doesn't have height descriptor");
				return;
			}
			if (msObject.keywordSO == null)
			{
				Debug.LogError("Terrain does not have keywords");
				return;
			}
			bool flag = false;
			foreach (string keyword in msObject.keywordSO.keywords)
			{
				if (keyword.StartsWith("_MSRENDERLOOP_UNITYURP") || keyword.StartsWith("_MSRENDERLOOP_UNITYHDRP"))
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				updateBuffer = new SRPBuffers();
			}
			else
			{
				updateBuffer = new StandardBuffers();
			}
			updateBuffer.Init(terrainDescriptor.heightMap.width, terrainDescriptor.heightMap.height);
		}

		private void OnDisable()
		{
			onBuffer0 = false;
			updateBuffer.Disable();
			updateBuffer = null;
		}

		private void Update()
		{
			if (msObject == null)
			{
				return;
			}
			MicroSplatObject.TerrainDescriptor terrainDescriptor = msObject.GetTerrainDescriptor();
			if (terrainDescriptor.heightMap == null)
			{
				return;
			}
			_ = emitters.Count;
			_ = 64;
			_ = colliders.Count;
			_ = 64;
			int num = 0;
			for (int i = 0; i < emitters.Count; i++)
			{
				StreamEmitter streamEmitter = emitters[i];
				if (streamEmitter == null)
				{
					continue;
				}
				Vector2 a = WorldToTerrain(msObject, streamEmitter.transform.position, updateBuffer.width, updateBuffer.height);
				if (a.x >= 0f && a.x < (float)updateBuffer.width && a.y >= 0f && a.y < (float)updateBuffer.height)
				{
					Vector3 point = streamEmitter.transform.position + Vector3.left * streamEmitter.transform.lossyScale.x;
					Vector2 b = WorldToTerrain(msObject, point, updateBuffer.width, updateBuffer.height);
					float num2 = Vector2.Distance(a, b);
					if (num2 < 1f)
					{
						num2 = 1f;
					}
					num2 *= streamEmitter.strength;
					Vector4 vector = new Vector4(a.x, a.y, 0f, 0f);
					if (streamEmitter.emitterType == StreamEmitter.EmitterType.Water)
					{
						vector.z = num2;
					}
					else
					{
						vector.w = num2;
					}
					spawnBuffer[num] = vector;
					num++;
				}
			}
			int num3 = 0;
			for (int j = 0; j < colliders.Count; j++)
			{
				StreamCollider streamCollider = colliders[j];
				Vector2 a2 = WorldToTerrain(msObject, streamCollider.transform.position, updateBuffer.width, updateBuffer.height);
				if (a2.x >= 0f && a2.x < (float)updateBuffer.width && a2.y >= 0f && a2.y < (float)updateBuffer.height)
				{
					Vector3 point2 = streamCollider.transform.position + Vector3.left * streamCollider.transform.lossyScale.x;
					Vector2 b2 = WorldToTerrain(msObject, point2, updateBuffer.width, updateBuffer.height);
					float num4 = Vector2.Distance(a2, b2);
					Vector4 vector2 = new Vector4(a2.x, a2.y, 0f, 0f);
					if (streamCollider.colliderType != StreamCollider.ColliderType.Lava)
					{
						vector2.z = num4;
					}
					if (streamCollider.colliderType != StreamCollider.ColliderType.Water)
					{
						vector2.w = num4;
					}
					colliderBuffer[num3] = vector2;
					num3++;
				}
			}
			updateBuffer.updateMat.SetVectorArray("_Positions", spawnBuffer);
			updateBuffer.updateMat.SetVectorArray("_Colliders", colliderBuffer);
			updateBuffer.updateMat.SetInt("_PositionsCount", num);
			updateBuffer.updateMat.SetInt("_CollidersCount", num3);
			updateBuffer.updateMat.SetVector("_SpawnStrength", strength);
			updateBuffer.updateMat.SetTexture("_TerrainHeight", terrainDescriptor.heightMap);
			updateBuffer.updateMat.SetVector("_TerrainHeightmapScale", terrainDescriptor.heightMapScale);
			updateBuffer.updateMat.SetFloat("_DeltaTime", Time.smoothDeltaTime);
			updateBuffer.updateMat.SetVector("_Speed", speed * Time.timeScale);
			updateBuffer.updateMat.SetVector("_Resistance", resistance);
			if (onBuffer0)
			{
				if (evaporation.x > 0f)
				{
					float num5 = 1f / evaporation.x / 255f;
					if (timeSinceEvapX > (double)num5)
					{
						timeSinceEvapX = 0.0;
						evapAmount.x = 0.004f;
					}
					else
					{
						evapAmount.x = 0f;
					}
				}
				if (evaporation.y > 0f)
				{
					float num6 = 1f / evaporation.y / 255f;
					if (timeSinceEvapY > (double)num6)
					{
						timeSinceEvapY = 0.0;
						evapAmount.y = 0.004f;
					}
					else
					{
						evapAmount.y = 0f;
					}
				}
				updateBuffer.updateMat.SetVector("_Evaporation", evapAmount);
				if (wetnessEvaporation > 0f)
				{
					float num7 = 1f / wetnessEvaporation / 255f;
					if (timeSinceWetnessEvap > (double)num7)
					{
						updateBuffer.updateMat.SetFloat("_WetnessEvaporation", 0.004f);
						timeSinceWetnessEvap = 0.0;
					}
					else
					{
						updateBuffer.updateMat.SetFloat("_WetnessEvaporation", 0f);
					}
				}
				if (burnEvaporation > 0f)
				{
					float num8 = 1f * burnEvaporation / 255f;
					if (timeSinceBurnEvap > (double)num8)
					{
						updateBuffer.updateMat.SetFloat("_BurnEvaporation", 0.004f);
						timeSinceBurnEvap = 0.0;
					}
					else
					{
						updateBuffer.updateMat.SetFloat("_BurnEvaporation", 0f);
					}
				}
				updateBuffer.BlitA();
			}
			else
			{
				updateBuffer.updateMat.SetInt("_PositionsCount", 0);
				updateBuffer.updateMat.SetVector("_Evaporation", Vector2.zero);
				updateBuffer.updateMat.SetFloat("_WetnessEvaporation", 0f);
				updateBuffer.updateMat.SetFloat("_BurnEvaporation", 0f);
				updateBuffer.BlitB();
			}
			onBuffer0 = !onBuffer0;
			float deltaTime = Time.deltaTime;
			timeSinceEvapX += deltaTime;
			timeSinceEvapY += deltaTime;
			timeSinceWetnessEvap += deltaTime;
			timeSinceBurnEvap += deltaTime;
			msObject.matInstance.SetTexture("_DynamicStreamControl", updateBuffer.GetCurrent());
		}
	}
}
