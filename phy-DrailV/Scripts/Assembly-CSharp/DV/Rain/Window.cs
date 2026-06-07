using System;
using System.Collections.Generic;
using DV.Debugging;
using DV.Utils;
using DV.VFX;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

namespace DV.Rain
{
	[ExecuteAfter(typeof(DefaultOrder))]
	public class Window : MonoBehaviour
	{
		public struct Droplet
		{
			public Vector2 position;

			public float size;

			public Vector2 velocity;
		}

		public struct WiperStruct
		{
			public Matrix4x4 UVToWiper;

			public Matrix4x4 WiperToUV;

			public float releaseDroplets;

			public float velocity;

			public Vector3 cornerA;

			public Vector3 cornerB;

			public Vector3 cornerC;

			public Vector3 cornerD;

			public Vector3 releaseDirection;
		}

		public struct ColliderStruct
		{
			public Vector2 cornerA;

			public Vector2 cornerB;

			public float checkDistance;

			public float power;

			public float shouldRedirectDroplets;
		}

		public const float ROOF_DETECTION_MINIMUM_DISTANCE = 3f;

		public const int HIGH_MATERIAL_INDEX = 3;

		public const int MED_MATERIAL_INDEX = 2;

		private readonly int _timeStepID = Shader.PropertyToID("timeStep");

		private readonly int _timeID = Shader.PropertyToID("time");

		private readonly int _respawnRate = Shader.PropertyToID("respawnRate");

		private readonly int _rainAmountID = Shader.PropertyToID("rainAmount");

		private readonly int _minDropletSizeID = Shader.PropertyToID("minDropletSize");

		private readonly int _maxDropletSizeID = Shader.PropertyToID("maxDropletSize");

		private readonly int _velocityMultiplierID = Shader.PropertyToID("velocityMultiplier");

		private readonly int _dropletFadeAmountID = Shader.PropertyToID("dropletFadeAmount");

		private readonly int _mistFadeAmountID = Shader.PropertyToID("mistFadeAmount");

		private readonly int _dropletCountID = Shader.PropertyToID("dropletCount");

		private readonly int _externalVelocityID = Shader.PropertyToID("externalVelocity");

		private readonly int _WorldToWindowID = Shader.PropertyToID("WorldToWindow");

		private readonly int _windowSizeID = Shader.PropertyToID("windowSize");

		private readonly int _ResultSizeIDX = Shader.PropertyToID("ResultSizeX");

		private readonly int _ResultSizeIDY = Shader.PropertyToID("ResultSizeY");

		private readonly int _pixelsPerMeterID = Shader.PropertyToID("pixelsPerMeter");

		private readonly int _DropletSimulationA = Shader.PropertyToID("DropletSimulationA");

		private readonly int _SimulationTextureSizeX = Shader.PropertyToID("SimulationTextureSizeX");

		private readonly int _SimulationTextureSizeY = Shader.PropertyToID("SimulationTextureSizeY");

		private readonly int _SimTex = Shader.PropertyToID("_SimTex");

		private readonly int _Wipers = Shader.PropertyToID("Wipers");

		private readonly int _wipersLength = Shader.PropertyToID("wipersLength");

		private readonly int _Droplets = Shader.PropertyToID("Droplets");

		private readonly int _Colliders = Shader.PropertyToID("Colliders");

		private readonly int _Perlin = Shader.PropertyToID("Perlin");

		private readonly int _WiperNoise = Shader.PropertyToID("WiperNoise");

		private readonly int _Noise = Shader.PropertyToID("Noise");

		private readonly int _sampleMult = Shader.PropertyToID("sampleMult");

		private readonly int _shouldRespawn = Shader.PropertyToID("shouldRespawn");

		private readonly int _directionalScale = Shader.PropertyToID("_DirectionalScale");

		private readonly int _useBakedUVs = Shader.PropertyToID("_useBakedUVs");

		public bool simulate;

		public MeshRenderer[] visuals;

		public Wiper[] wipers;

		public Window[] duplicates;

		public Transform[] windowEdges;

		public Vector2 sizeInMeters;

		public bool useBakedUVs;

		public bool mirrorX;

		public bool mirrorY;

		public RenderTexture dropletRenderingTexture;

		public Rigidbody rb;

		[NonSerialized]
		public bool textureOverride;

		private ComputeShader shader;

		private ComputeBuffer dropletsBuffer;

		private ComputeBuffer wipersBuffer;

		private ComputeBuffer collidersBuffer;

		private WiperStruct[] wiperStructs;

		private ColliderStruct[] colliderStructs;

		private int DropletRenderKernel;

		private int CopyOverRenderTextureKernel;

		private int DropletRenderClearKernel;

		private int DropletSimulationKernel;

		private float timeSinceLastWrite;

		private float mistAmount;

		private int mistFadeAmount;

		private int dropletFadeAmount;

		private WindowDropletsGrabPass grabPass;

		private WindowSimulationManager simulationManager;

		private WindowSettings windowSettings;

		private CeilingDetection ceilingDetection;

		private bool materialJustChanged;

		private bool debugDisable;

		private bool isInTunnel;

		private float directionalLightInfluence = 1f;

		[NonSerialized]
		public MaterialPropertyBlock propertyBlock;

		private void Awake()
		{
			if ((bool)SingletonBehaviour<CeilingDetection>.Instance)
			{
				ceilingDetection = SingletonBehaviour<CeilingDetection>.Instance;
			}
			if ((bool)SingletonBehaviour<WindowSimulationManager>.Instance)
			{
				simulationManager = SingletonBehaviour<WindowSimulationManager>.Instance;
			}
			if ((bool)SingletonBehaviour<WindowSettings>.Instance)
			{
				windowSettings = SingletonBehaviour<WindowSettings>.Instance;
			}
			if (!simulationManager || !windowSettings)
			{
				Debug.LogError("Missing instance of script, destroying script!");
				UnityEngine.Object.Destroy(this);
				return;
			}
			CreatePropBlock();
			Window[] array = duplicates;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].CreatePropBlock();
			}
			if (simulate)
			{
				SetupSimulation();
				simulationManager.windows?.Add(this);
				TrainCar.Resolve(base.gameObject).OnAwakeFromPool += delegate
				{
					ResetDropletsPosition();
					SetMistAmount(0f);
				};
			}
			Wiper[] array2 = wipers;
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i].windows.Add(this);
			}
			Transform[] array3 = windowEdges;
			for (int i = 0; i < array3.Length; i++)
			{
				UnityEngine.Object.Destroy(array3[i].gameObject);
			}
			windowEdges = null;
			UpdateMaterialsOnSelf(3);
		}

		private void CreatePropBlock()
		{
			if (propertyBlock == null)
			{
				propertyBlock = new MaterialPropertyBlock();
			}
		}

		private void Start()
		{
			if (simulate)
			{
				SetMistAmount(0f);
				GamePreferences.RegisterToPreferenceUpdated(Preferences.RainQualityIndex, QualityChanged);
				SingletonBehaviour<EffectsTogglerDebug>.Instance.SubscribeChanged(EffectsTogglerDebug.EffectType.WindowDropletsRendering, OnDebugChanged);
			}
		}

		private void OnEnable()
		{
			if (simulate)
			{
				if ((bool)simulationManager)
				{
					simulationManager.windows?.Add(this);
				}
				CheckRenderTexture(ref dropletRenderingTexture, GraphicsFormat.R8G8B8A8_UNorm, "DropletSimulationB", copyOld: true);
				if (grabPass == null)
				{
					grabPass = TrainCar.Resolve(base.transform).GetComponentInChildren<WindowDropletsGrabPass>();
				}
				if (grabPass != null)
				{
					grabPass.AddWindow(this);
				}
			}
		}

		private void OnDisable()
		{
			if (simulate)
			{
				if ((bool)simulationManager)
				{
					simulationManager.windows?.Remove(this);
				}
				if (dropletRenderingTexture != null)
				{
					dropletRenderingTexture.Release();
				}
				dropletRenderingTexture = null;
				if (grabPass != null)
				{
					grabPass.RemoveWindow(this);
				}
			}
			MeshRenderer[] array = visuals;
			foreach (MeshRenderer obj in array)
			{
				propertyBlock.SetVector(_windowSizeID, Vector2.zero);
				obj.SetPropertyBlock(propertyBlock);
			}
			Window[] array2 = duplicates;
			foreach (Window window in array2)
			{
				array = window.visuals;
				foreach (MeshRenderer obj2 in array)
				{
					window.propertyBlock.SetVector(_windowSizeID, Vector2.zero);
					obj2.SetPropertyBlock(window.propertyBlock);
				}
			}
		}

		private void OnDestroy()
		{
			if (simulate)
			{
				collidersBuffer?.Dispose();
				dropletsBuffer?.Dispose();
				wipersBuffer?.Dispose();
				GamePreferences.UnregisterFromPreferenceUpdated(Preferences.RainQualityIndex, QualityChanged);
				if ((bool)SingletonBehaviour<EffectsTogglerDebug>.Instance)
				{
					SingletonBehaviour<EffectsTogglerDebug>.Instance.UnsubscribeChanged(EffectsTogglerDebug.EffectType.WindowDropletsRendering, OnDebugChanged);
				}
			}
			if (windowSettings != null)
			{
				MeshRenderer[] array = visuals;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].sharedMaterial = windowSettings.lowQualityWindowMaterial;
				}
			}
		}

		private void CreateWindowEdges()
		{
			List<Transform> edges = new List<Transform>();
			CreateNew(0.5f * new Vector2(sizeInMeters.x, sizeInMeters.y));
			CreateNew(0.5f * new Vector2(sizeInMeters.x, 0f - sizeInMeters.y));
			CreateNew(0.5f * new Vector2(0f - sizeInMeters.x, 0f - sizeInMeters.y));
			CreateNew(0.5f * new Vector2(0f - sizeInMeters.x, sizeInMeters.y));
			windowEdges = edges.ToArray();
			void CreateNew(Vector2 localPos)
			{
				GameObject gameObject = new GameObject("window edge");
				gameObject.transform.parent = base.transform;
				gameObject.transform.localRotation = Quaternion.identity;
				gameObject.transform.localPosition = localPos;
				edges.Add(gameObject.transform);
			}
		}

		private void QualityChanged()
		{
			int index = GamePreferences.Get<int>(Preferences.RainQualityIndex);
			if (debugDisable)
			{
				index = 0;
			}
			UpdateMaterialsOnSelf(index);
			Window[] array = duplicates;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].UpdateMaterialsOnSelf(index);
			}
		}

		private void OnDebugChanged(bool on)
		{
			debugDisable = !on;
			QualityChanged();
		}

		public void UpdateMaterialsOnSelf(int index)
		{
			Material material = ((index >= 3) ? windowSettings.highQualityWindowMaterial : ((index >= 2) ? windowSettings.medQualityWindowMaterial : windowSettings.lowQualityWindowMaterial));
			MeshRenderer[] array = visuals;
			foreach (MeshRenderer meshRenderer in array)
			{
				if (!meshRenderer)
				{
					Debug.LogError("MeshRenderer doesn't exist!", base.gameObject);
					continue;
				}
				if (!meshRenderer.sharedMaterial)
				{
					Debug.LogError("MeshRenderer material doesn't exist!", base.gameObject);
					continue;
				}
				if (meshRenderer.sharedMaterial != material)
				{
					materialJustChanged = true;
				}
				meshRenderer.sharedMaterial = material;
				propertyBlock.SetInt(_useBakedUVs, useBakedUVs ? 1 : 0);
				meshRenderer.SetPropertyBlock(propertyBlock);
			}
		}

		private void RefreshTunnelState()
		{
			isInTunnel = false;
			if ((bool)ceilingDetection)
			{
				CeilingDetection.WorldPositionedArray worldPositionedArray = ceilingDetection.worldPositionedArray;
				int index = worldPositionedArray.GetIndex(base.transform.position);
				if (index >= 0 && ceilingDetection.copiedResults[index].point.y > base.transform.position.y + 3f)
				{
					isInTunnel = true;
				}
			}
		}

		private void SetMistAmount(float value)
		{
			mistAmount = value;
			propertyBlock.SetFloat(WindowSimulationManager._mistAmount, mistAmount);
			MeshRenderer[] array = visuals;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetPropertyBlock(propertyBlock);
			}
			Window[] array2 = duplicates;
			foreach (Window window in array2)
			{
				window.propertyBlock.SetFloat(WindowSimulationManager._mistAmount, mistAmount);
				array = window.visuals;
				for (int j = 0; j < array.Length; j++)
				{
					array[j].SetPropertyBlock(window.propertyBlock);
				}
			}
		}

		public void Simulate(float deltaTime)
		{
			RefreshTunnelState();
			bool flag = IsVisible();
			if (flag)
			{
				float num = 1f + (rb ? rb.velocity.magnitude : 0f);
				num *= (isInTunnel ? (-1f) : 1f);
				directionalLightInfluence = Mathf.Clamp01(directionalLightInfluence + deltaTime * num);
				propertyBlock.SetFloat(_directionalScale, directionalLightInfluence);
				MeshRenderer[] array = visuals;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].SetPropertyBlock(propertyBlock);
				}
				Window[] array2 = duplicates;
				foreach (Window window in array2)
				{
					window.propertyBlock.SetFloat(_directionalScale, directionalLightInfluence);
					array = window.visuals;
					for (int j = 0; j < array.Length; j++)
					{
						array[j].SetPropertyBlock(window.propertyBlock);
					}
				}
			}
			else
			{
				directionalLightInfluence = (isInTunnel ? 0f : 1f);
			}
			float rainAmount = simulationManager.rainAmount;
			float num2 = Mathf.Max(Mathf.Max(windowSettings.timeToFadeDropletMinRain, windowSettings.timeToFadeDropletMaxRain), Mathf.Max(windowSettings.timeToFadeMistMinRain, windowSettings.timeToFadeMistMaxRain));
			float num3 = (isInTunnel ? Mathf.Min(mistAmount, simulationManager.mistAmount) : simulationManager.mistAmount);
			if (num3 != mistAmount)
			{
				SetMistAmount(num3);
			}
			if (rainAmount == 0f && num3 == 0f && !IsAnyWiperMoving())
			{
				if (timeSinceLastWrite > num2)
				{
					return;
				}
				timeSinceLastWrite += deltaTime;
			}
			else
			{
				timeSinceLastWrite = 0f;
			}
			Vector2Int resolution = GetResolution();
			dropletFadeAmount += simulationManager.dropletFadeAmount;
			mistFadeAmount += simulationManager.mistFadeAmount;
			dropletFadeAmount = Mathf.Min(dropletFadeAmount, 255);
			mistFadeAmount = Mathf.Min(mistFadeAmount, 255);
			if (flag && resolution.x != 1)
			{
				CheckRenderTexture(ref dropletRenderingTexture, GraphicsFormat.R8G8B8A8_UNorm, "DropletSimulationB", copyOld: true);
				if (!textureOverride)
				{
					RenderTexture simTexture = simulationManager.GetSimTexture(resolution);
					shader.SetTexture(DropletRenderKernel, _DropletSimulationA, simTexture);
					shader.SetInt(_SimulationTextureSizeX, resolution.x);
					shader.SetInt(_SimulationTextureSizeY, resolution.y);
					shader.SetFloat(_timeStepID, deltaTime);
					shader.SetFloat(_timeID, Time.time);
					shader.SetFloat(_respawnRate, Mathf.Lerp(windowSettings.respawnRateMinRain, windowSettings.respawnRateMaxRain, simulationManager.rainAmount));
					shader.SetFloat(_rainAmountID, simulationManager.rainAmount);
					shader.SetFloat(_minDropletSizeID, windowSettings.minDropletSize);
					shader.SetFloat(_maxDropletSizeID, windowSettings.maxDropletSize);
					shader.SetFloat(_velocityMultiplierID, Mathf.Lerp(windowSettings.velocityMultiplierAtMinRain, windowSettings.velocityMultiplierAtMaxRain, simulationManager.rainAmount));
					shader.SetInt(_dropletFadeAmountID, dropletFadeAmount);
					shader.SetInt(_mistFadeAmountID, mistFadeAmount);
					shader.SetBool(_shouldRespawn, !isInTunnel);
					Vector2 vector = TransformVelocityToWindowSpace(Physics.gravity);
					if ((bool)rb)
					{
						vector += TransformVelocityToWindowSpace(-rb.velocity * 0.3f);
					}
					shader.SetVector(_externalVelocityID, vector);
					Matrix4x4 windowMatrix = GetWindowMatrix();
					Matrix4x4 inverse = windowMatrix.inverse;
					for (int k = 0; k < wipers.Length * 2; k++)
					{
						ColliderStruct colliderStruct = colliderStructs[k];
						colliderStruct.power -= deltaTime * 2000f;
						colliderStruct.power = Mathf.Max(colliderStruct.power, 0f);
						colliderStructs[k] = colliderStruct;
					}
					for (int l = 0; l < wipers.Length; l++)
					{
						WiperStruct wiperStruct = wiperStructs[l];
						Wiper wiper = wipers[l];
						Vector3 vector2 = inverse.MultiplyPoint3x4(wiper.start.position);
						Vector3 vector3 = inverse.MultiplyPoint3x4(wiper.end.position);
						vector2.z = 0f;
						vector3.z = 0f;
						Vector3 vector4 = wiper.lastStart;
						Vector3 vector5 = wiper.lastEnd;
						if (Vector3.SqrMagnitude(vector4 - vector2) > windowSettings.wiperEdgeMaxDistance)
						{
							vector4 = vector2;
							vector5 = vector3;
						}
						windowMatrix.MultiplyPoint3x4(vector4);
						Vector3 vector6 = windowMatrix.MultiplyPoint3x4(vector5);
						Vector3 vector7 = windowMatrix.MultiplyPoint3x4(vector2);
						Vector3 vector8 = windowMatrix.MultiplyPoint3x4(vector3);
						float num4 = (vector8 - vector6).magnitude / deltaTime;
						int num5 = 10;
						wiper.velocity += (num4 - wiper.velocity) / (float)(num5 + 1);
						Vector3 vector9 = (vector8 - vector6) / deltaTime;
						int num6 = 5;
						wiper.currentDirection += (vector9 - wiper.currentDirection) / (num6 + 1);
						float num7 = Vector3.Distance(vector8, vector6);
						float z = Vector3.SignedAngle(vector8 - vector7, base.transform.up, -base.transform.forward);
						num7 = 0.11f;
						Matrix4x4 matrix4x = Matrix4x4.TRS(vector7, base.transform.rotation * Quaternion.Euler(0f, 0f, z), new Vector3(num7, Vector3.Distance(vector7, vector8), 1f));
						wiperStruct.UVToWiper = matrix4x.inverse * windowMatrix;
						wiperStruct.WiperToUV = wiperStruct.UVToWiper.inverse;
						wiperStruct.cornerA = vector2;
						wiperStruct.cornerB = vector3;
						wiperStruct.cornerC = vector4;
						wiperStruct.cornerD = vector5;
						wiperStruct.releaseDroplets = (wiper.releaseDroplets ? 1 : (wiper.disableCollision ? (-1) : 0));
						float x = matrix4x.inverse.MultiplyVector(wiper.currentDirection).x;
						float num8 = Mathf.Sign(x);
						int num9 = ((x > 0f) ? 1 : 0);
						wiperStruct.velocity = wiper.velocity * 0.1f * num7 * num8;
						Vector3 value = wiperStruct.WiperToUV.MultiplyPoint3x4(new Vector3(1f, 0f, 0f));
						Vector3 vector10 = wiperStruct.WiperToUV.MultiplyPoint3x4(new Vector3(0f, 0f, 0f));
						value.z = 0f;
						vector10.z = 0f;
						value -= vector10;
						wiperStruct.releaseDirection = Vector3.Normalize(value) * num8;
						wiperStructs[l] = wiperStruct;
						if (wiperStruct.releaseDroplets == 1f)
						{
							if (colliderStructs[l * 2 + num9].checkDistance == 0f)
							{
								Vector3 vector11 = wiperStruct.WiperToUV.MultiplyPoint3x4(new Vector3(0f, 1f, 0f));
								Vector3 vector12 = wiperStruct.WiperToUV.MultiplyPoint3x4(new Vector3(0f, 0f, 0f));
								Vector2 cornerA = new Vector2(vector11.x, vector11.y);
								Vector2 cornerB = new Vector2(vector12.x, vector12.y);
								colliderStructs[l * 2 + num9] = new ColliderStruct
								{
									cornerA = cornerA,
									cornerB = cornerB,
									checkDistance = 0.01f * sizeInMeters.x * num8,
									power = 1000f,
									shouldRedirectDroplets = 1f
								};
							}
							else
							{
								Vector3 vector13 = wiperStruct.WiperToUV.MultiplyPoint3x4(new Vector3(0f, 1f, 0f));
								Vector3 vector14 = wiperStruct.WiperToUV.MultiplyPoint3x4(new Vector3(0f, 0f, 0f));
								Vector2 cornerA2 = new Vector2(vector13.x, vector13.y);
								Vector2 cornerB2 = new Vector2(vector14.x, vector14.y);
								colliderStructs[l * 2 + num9] = new ColliderStruct
								{
									cornerA = cornerA2,
									cornerB = cornerB2,
									checkDistance = 0.01f * sizeInMeters.x * num8,
									power = 1000f,
									shouldRedirectDroplets = 1f
								};
							}
						}
						wiper.lastStart = vector2;
						wiper.lastEnd = vector3;
					}
					wipersBuffer.SetData(wiperStructs);
					collidersBuffer.SetData(colliderStructs);
					int num10 = (int)((float)dropletsBuffer.count * simulationManager.rainAmount * (float)simulationManager.dropletCountMultiplier);
					shader.SetInt(_dropletCountID, num10);
					RenderTexture active = RenderTexture.active;
					RenderTexture.active = simTexture;
					GL.Clear(clearDepth: true, clearColor: true, Color.clear);
					if (num10 != 0)
					{
						shader.Dispatch(DropletSimulationKernel, Mathf.CeilToInt((float)num10 / 128f), 1, 1);
					}
					if (num10 != 0)
					{
						shader.Dispatch(DropletRenderKernel, Mathf.CeilToInt((float)num10 / 128f), 1, 1);
					}
					Material copyStepMaterial = windowSettings.copyStepMaterial;
					copyStepMaterial.SetTexture(_SimTex, dropletRenderingTexture);
					copyStepMaterial.SetBuffer(_Wipers, wipersBuffer);
					copyStepMaterial.SetInt(_wipersLength, wipers.Length);
					copyStepMaterial.SetInt(_dropletFadeAmountID, dropletFadeAmount);
					copyStepMaterial.SetInt(_mistFadeAmountID, mistFadeAmount);
					copyStepMaterial.SetFloat(_rainAmountID, simulationManager.rainAmount);
					copyStepMaterial.SetVector(_sampleMult, new Vector2((float)simTexture.width / (float)dropletRenderingTexture.width, (float)simTexture.height / (float)dropletRenderingTexture.height));
					Graphics.Blit(dropletRenderingTexture, simTexture, copyStepMaterial, 0);
					copyStepMaterial.SetVector(_sampleMult, new Vector2((float)dropletRenderingTexture.width / (float)simTexture.width, (float)dropletRenderingTexture.height / (float)simTexture.height));
					Graphics.Blit(simTexture, dropletRenderingTexture, copyStepMaterial, 1);
					RenderTexture.active = active;
					mistFadeAmount = 0;
					dropletFadeAmount = 0;
				}
			}
			for (int m = 0; m < wipers.Length; m++)
			{
				wipers[m].releaseDroplets = false;
				Window[] array2 = duplicates;
				for (int i = 0; i < array2.Length; i++)
				{
					Wiper[] array3 = array2[i].wipers;
					for (int j = 0; j < array3.Length; j++)
					{
						array3[j].releaseDroplets = false;
					}
				}
			}
		}

		public void UpdateWindowMatrix()
		{
			MeshRenderer[] array = visuals;
			foreach (MeshRenderer obj in array)
			{
				propertyBlock.SetMatrix(_WorldToWindowID, GetWindowMatrix().inverse);
				propertyBlock.SetVector(_windowSizeID, sizeInMeters);
				obj.SetPropertyBlock(propertyBlock);
			}
			Window[] array2 = duplicates;
			foreach (Window window in array2)
			{
				array = window.visuals;
				foreach (MeshRenderer obj2 in array)
				{
					window.propertyBlock.SetMatrix(_WorldToWindowID, window.GetWindowMatrix().inverse);
					window.propertyBlock.SetVector(_windowSizeID, sizeInMeters);
					obj2.SetPropertyBlock(window.propertyBlock);
				}
			}
		}

		public bool IsAnyWiperMoving()
		{
			Wiper[] array = wipers;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i].driver.speed != 0f)
				{
					return true;
				}
			}
			return false;
		}

		public bool IsVisible()
		{
			for (int i = 0; i < visuals.Length; i++)
			{
				if (visuals[i].isVisible)
				{
					return true;
				}
			}
			Window[] array = duplicates;
			foreach (Window window in array)
			{
				for (int k = 0; k < window.visuals.Length; k++)
				{
					if (window.visuals[k].isVisible)
					{
						return true;
					}
				}
			}
			return false;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.matrix = Matrix4x4.identity;
			if (windowEdges != null)
			{
				for (int i = 0; i < windowEdges.Length; i++)
				{
					Transform transform = windowEdges[i];
					Transform transform2 = windowEdges[(i + 1) % windowEdges.Length];
					if ((bool)transform && (bool)transform2)
					{
						Gizmos.DrawLine(transform.position, transform2.position);
					}
				}
			}
			Gizmos.matrix = GetWindowMatrix();
			Gizmos.DrawWireCube(new Vector3(0.5f, 0.5f, 0f), Vector3.one);
		}

		private void CheckRenderTexture(ref RenderTexture tex, GraphicsFormat format, string materialTextureName, bool copyOld = false)
		{
			if (textureOverride)
			{
				if (tex != null && tex != simulationManager.overrideTexture)
				{
					tex.Release();
					tex = simulationManager.overrideTexture;
					MeshRenderer[] array = visuals;
					foreach (MeshRenderer obj in array)
					{
						propertyBlock.SetTexture(materialTextureName, tex);
						propertyBlock.SetVector(_windowSizeID, sizeInMeters);
						obj.SetPropertyBlock(propertyBlock);
					}
					Window[] array2 = duplicates;
					foreach (Window window in array2)
					{
						array = window.visuals;
						foreach (MeshRenderer obj2 in array)
						{
							window.propertyBlock.SetTexture(materialTextureName, tex);
							window.propertyBlock.SetVector(_windowSizeID, sizeInMeters);
							obj2.SetPropertyBlock(window.propertyBlock);
						}
					}
					SetRenderTextureToShader(materialTextureName, tex);
				}
			}
			else if (tex == simulationManager.overrideTexture)
			{
				tex = null;
			}
			Vector2Int resolution = GetResolution();
			if (tex == null || tex.width != resolution.x || tex.height != resolution.y)
			{
				RenderTexture renderTexture = tex;
				tex = new RenderTexture(resolution.x, resolution.y, 0, format);
				tex.enableRandomWrite = true;
				tex.Create();
				if (renderTexture != null && copyOld && tex.width != 1)
				{
					Graphics.Blit(renderTexture, tex);
				}
				if (renderTexture != null)
				{
					renderTexture.Release();
				}
				SetRenderTextureToShader(materialTextureName, tex);
			}
			if (materialJustChanged)
			{
				SetRenderTextureToShader(materialTextureName, tex);
			}
		}

		private void SetupSimulation()
		{
			shader = UnityEngine.Object.Instantiate(windowSettings.computeShader);
			DropletRenderKernel = shader.FindKernel("DropletRendering");
			DropletRenderClearKernel = shader.FindKernel("DropletRenderingClear");
			DropletSimulationKernel = shader.FindKernel("DropletSimulation");
			CopyOverRenderTextureKernel = shader.FindKernel("CopyOverRenderTexture");
			CheckRenderTexture(ref dropletRenderingTexture, GraphicsFormat.R8G8B8A8_UNorm, "DropletSimulationB", copyOld: true);
			colliderStructs = new ColliderStruct[Mathf.Max(1, windowEdges.Length + wipers.Length * 2)];
			Matrix4x4 inverse = GetWindowMatrix().inverse;
			Array.Sort(windowEdges, delegate(Transform a, Transform b)
			{
				float num4 = Vector3.SignedAngle(base.transform.position - a.position, base.transform.up, base.transform.forward);
				return (Vector3.SignedAngle(base.transform.position - b.position, base.transform.up, base.transform.forward) > num4) ? 1 : (-1);
			});
			for (int num = 0; num < windowEdges.Length; num++)
			{
				Transform transform = windowEdges[num];
				Transform transform2 = windowEdges[(num + 1) % windowEdges.Length];
				Vector3 vector = inverse.MultiplyPoint3x4(transform.position);
				Vector3 vector2 = inverse.MultiplyPoint3x4(transform2.position);
				colliderStructs[num + wipers.Length * 2] = new ColliderStruct
				{
					cornerA = new Vector2(vector.x, vector.y),
					cornerB = new Vector2(vector2.x, vector2.y),
					checkDistance = 0.03f,
					power = 1000f
				};
			}
			for (int num2 = 0; num2 < wipers.Length * 2; num2++)
			{
				colliderStructs[num2] = new ColliderStruct
				{
					cornerA = new Vector2(0f, 0f),
					cornerB = new Vector2(1f, 0f),
					checkDistance = 0f,
					power = 1000f
				};
			}
			if (colliderStructs.Length == 1)
			{
				colliderStructs[0] = new ColliderStruct
				{
					cornerA = new Vector2(0f, 0f),
					cornerB = new Vector2(1f, 0f),
					checkDistance = 0f,
					power = 1000f
				};
			}
			collidersBuffer = new ComputeBuffer(Mathf.Max(1, windowEdges.Length + wipers.Length * 2), 28);
			dropletsBuffer = new ComputeBuffer(Mathf.Max(1, (int)((float)windowSettings.maxDropletCountPerSquareMeter * sizeInMeters.x * sizeInMeters.y) / 8 * 8), 20);
			wipersBuffer = new ComputeBuffer(Mathf.Max(1, wipers.Length), 196);
			ResetDropletsPosition();
			wiperStructs = new WiperStruct[Mathf.Max(1, wipers.Length)];
			for (int num3 = 0; num3 < wipers.Length; num3++)
			{
				Matrix4x4 identity = Matrix4x4.identity;
				wiperStructs[num3] = new WiperStruct
				{
					UVToWiper = identity,
					WiperToUV = identity.inverse,
					releaseDroplets = 0f
				};
			}
			if (wipers.Length == 0)
			{
				wiperStructs[0] = new WiperStruct
				{
					UVToWiper = Matrix4x4.TRS(Vector3.zero, Quaternion.identity, Vector3.zero),
					WiperToUV = Matrix4x4.identity,
					releaseDroplets = -1f
				};
			}
			SetStuff(DropletRenderClearKernel);
			SetStuff(DropletSimulationKernel);
			SetStuff(DropletRenderKernel);
			SetStuff(CopyOverRenderTextureKernel);
			shader.SetFloat(_minDropletSizeID, windowSettings.minDropletSize);
			shader.SetFloat(_maxDropletSizeID, windowSettings.maxDropletSize);
			shader.SetVector(_windowSizeID, sizeInMeters);
			if (!rb)
			{
				rb = TrainCar.Resolve(base.transform.parent)?.rb;
			}
		}

		private void ResetDropletsPosition()
		{
			Droplet[] array = new Droplet[dropletsBuffer.count];
			for (int i = 0; i < dropletsBuffer.count; i++)
			{
				array[i] = new Droplet
				{
					position = Vector2.zero,
					velocity = Vector2.zero,
					size = UnityEngine.Random.Range(0f, 1f)
				};
			}
			dropletsBuffer.SetData(array);
		}

		private Matrix4x4 GetWindowMatrix()
		{
			return Matrix4x4.TRS(base.transform.TransformPoint(new Vector3((0f - sizeInMeters.x) * 0.5f * (float)((!mirrorX) ? 1 : (-1)), (0f - sizeInMeters.y) * 0.5f * (float)((!mirrorY) ? 1 : (-1)), 0f)), base.transform.rotation * Quaternion.Euler(mirrorY ? 180 : 0, mirrorX ? 180 : 0, 0f), new Vector3(sizeInMeters.x, sizeInMeters.y, 0.1f));
		}

		private void SetStuff(int kernelID)
		{
			shader.SetBuffer(kernelID, _Droplets, dropletsBuffer);
			shader.SetBuffer(kernelID, _Wipers, wipersBuffer);
			shader.SetBuffer(kernelID, _Colliders, collidersBuffer);
			shader.SetTexture(kernelID, _Perlin, windowSettings.perlinTexture);
			shader.SetTexture(kernelID, _WiperNoise, windowSettings.wiperNoiseTexture);
			shader.SetTexture(kernelID, _Noise, windowSettings.noiseTexture);
		}

		private void SetRenderTextureToShader(string destination, Texture texture)
		{
			MeshRenderer[] array = visuals;
			foreach (MeshRenderer obj in array)
			{
				propertyBlock.SetTexture(destination, texture);
				propertyBlock.SetVector(_windowSizeID, sizeInMeters);
				obj.SetPropertyBlock(propertyBlock);
			}
			Window[] array2 = duplicates;
			foreach (Window window in array2)
			{
				array = window.visuals;
				foreach (MeshRenderer obj2 in array)
				{
					window.propertyBlock.SetTexture(destination, texture);
					window.propertyBlock.SetVector(_windowSizeID, sizeInMeters);
					obj2.SetPropertyBlock(window.propertyBlock);
				}
			}
			shader.SetTexture(DropletRenderClearKernel, destination, texture);
			shader.SetTexture(DropletSimulationKernel, destination, texture);
			shader.SetTexture(DropletRenderKernel, destination, texture);
			shader.SetTexture(CopyOverRenderTextureKernel, destination, texture);
			shader.SetInt(_ResultSizeIDX, texture.width);
			shader.SetInt(_ResultSizeIDY, texture.height);
			shader.SetInt(_pixelsPerMeterID, (int)((float)windowSettings.pixelsPerMeter * GetResolutionMultiplier()));
		}

		private float GetResolutionMultiplier()
		{
			float num = 1f;
			float distance = GetDistance();
			for (int i = 0; i < windowSettings.resolutionMultiplierLOD.Length; i++)
			{
				Vector2 vector = windowSettings.resolutionMultiplierLOD[i];
				if (distance < vector.x || i == windowSettings.resolutionMultiplierLOD.Length - 1)
				{
					num = vector.y;
					break;
				}
			}
			return num * simulationManager.windowResolutionMultiplier;
		}

		private float GetDistance()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			float num = float.MaxValue;
			if (!activeCamera)
			{
				return num;
			}
			Window[] array = duplicates;
			foreach (Window window in array)
			{
				num = Mathf.Min(Vector3.Distance(activeCamera.transform.position, window.transform.position), num);
			}
			return Mathf.Min(num, Vector3.Distance(activeCamera.transform.position, base.transform.position));
		}

		private Vector2Int GetResolution()
		{
			if (textureOverride && (bool)simulationManager)
			{
				return simulationManager.overrideTextureSize;
			}
			float resolutionMultiplier = GetResolutionMultiplier();
			return new Vector2Int(Mathf.Min(Mathf.Max(1, (int)(sizeInMeters.x * (float)windowSettings.pixelsPerMeter * resolutionMultiplier) / 8 * 8), windowSettings.maxWindowResolution.x), Mathf.Min(Mathf.Max(1, (int)(sizeInMeters.y * (float)windowSettings.pixelsPerMeter * resolutionMultiplier) / 8 * 8), windowSettings.maxWindowResolution.y));
		}

		public Vector2 TransformVelocityToWindowSpace(Vector3 velocity)
		{
			Vector3 vector = base.transform.InverseTransformDirection(velocity);
			return new Vector2(vector.x, vector.y);
		}
	}
}
