using System;
using System.Collections.Generic;
using Mandragora.PWS;
using Restory.Constants;
using Restory.Data.Equipment;
using Restory.Gameplay.Elements;
using Restory.Gameplay.Soldering;
using Unity.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class CleanerBrush : MonoBehaviour, IInitializable, IDisposable
	{
		public enum CalculationType
		{
			CPU = 0,
			ComputeShader = 1
		}

		private const int CLEANING_RESULT_FLOAT_TO_INT_MULTIPLIER = 1000;

		[SerializeField]
		private LayerMask layerMask = -1;

		[SerializeField]
		private float maxDistance = 3f;

		[SerializeField]
		[Tooltip("Time delay for continues coloring process")]
		private float continuesApplyDelayTime = 0.02f;

		[SerializeField]
		private CalculationType calculationType = CalculationType.ComputeShader;

		[SerializeField]
		private ComputeShader brushComputeShader;

		[SerializeField]
		private ComputeShader colorChannelsClearComputeShader;

		[SerializeField]
		private int raycastRingsCount = 3;

		[SerializeField]
		private int raysIncrementPerRing = 8;

		private Camera mainCamera;

		private int brushComputeShaderAddToStrokeKernel;

		private int brushComputeShaderCommitStrokeKernel;

		private int brushComputeShaderMicroColorsBufferInitKernel;

		private int clearChannelsShaderKernel;

		private float previousApplyBrushTime;

		private CommandBuffer commandBuffer;

		private RenderTexture workRenderTexture;

		private RenderTexture strokeBufferTexture;

		private RenderTexture microColorsBufferTexture;

		private Texture2D lastProcessedTexture;

		private int rayHitsCount;

		private RaycastHit[] raysHits;

		private ComputeBuffer raysHitsTextureCoordinatesBuffer;

		private Vector2Int[] raysHitsTextureCoordinates = new Vector2Int[0];

		private readonly int[] cleaningResultBufferData = new int[3];

		private readonly int[] clearCleaningResultData = new int[3];

		private ComputeBuffer cleaningResultBuffer;

		private Texture2D brushTexture;

		private readonly RaycastHit[] resultHits = new RaycastHit[8];

		private Transform targetTransform;

		private TextureMaskHolder colorApplier;

		private CleaningToolInfo currentBrushSettings;

		private SolderingToolInfo currentSolderingSettings;

		private Color currentTotalCleaningPowerColor = Color.white;

		public int LastPassRaysHitsCount => rayHitsCount;

		public IReadOnlyList<RaycastHit> LastPassRaysHits => raysHits;

		public CleaningToolInfo CurrentBrushSettings => currentBrushSettings;

		public SolderingToolInfo CurrentSolderingSettings => currentSolderingSettings;

		public event Action OnExecute;

		public event Action OnExecuteSoldering;

		[Inject]
		private void Construct([Inject(Id = "GameCamera")] Camera gameCamera)
		{
			mainCamera = gameCamera;
		}

		public void Initialize()
		{
			if (brushComputeShader != null)
			{
				brushComputeShaderAddToStrokeKernel = brushComputeShader.FindKernel("CSAddToStroke");
				brushComputeShaderCommitStrokeKernel = brushComputeShader.FindKernel("CSCommitStroke");
				brushComputeShaderMicroColorsBufferInitKernel = brushComputeShader.FindKernel("CSInitHighPrecisionColorsBuffer");
			}
			if (colorChannelsClearComputeShader != null)
			{
				clearChannelsShaderKernel = colorChannelsClearComputeShader.FindKernel("CSMain");
			}
			commandBuffer = new CommandBuffer();
			commandBuffer.name = "BrushApplyBuffer";
			int maxRaysCount = GetMaxRaysCount();
			raysHitsTextureCoordinates = new Vector2Int[maxRaysCount];
			raysHits = new RaycastHit[maxRaysCount];
			raysHitsTextureCoordinatesBuffer = new ComputeBuffer(maxRaysCount, 8);
			raysHitsTextureCoordinatesBuffer.name = "BrushHitsCoordinatesComputeBuffer";
			cleaningResultBuffer = new ComputeBuffer(64, 12);
			cleaningResultBuffer.name = "CleaningResultsBuffer";
		}

		public void Dispose()
		{
			if (commandBuffer != null)
			{
				commandBuffer.Release();
				commandBuffer = null;
			}
			if (workRenderTexture != null)
			{
				workRenderTexture.Release();
				workRenderTexture = null;
			}
			if (strokeBufferTexture != null)
			{
				strokeBufferTexture.Release();
				strokeBufferTexture = null;
			}
			if (microColorsBufferTexture != null)
			{
				microColorsBufferTexture.Release();
				microColorsBufferTexture = null;
			}
			if (raysHitsTextureCoordinatesBuffer != null)
			{
				raysHitsTextureCoordinatesBuffer.Release();
				raysHitsTextureCoordinatesBuffer = null;
			}
			if (cleaningResultBuffer != null)
			{
				cleaningResultBuffer.Release();
				cleaningResultBuffer = null;
			}
		}

		public void SetTarget(ElementBase target)
		{
			colorApplier = target.transform.GetComponentInChildren<TextureMaskHolder>();
			if ((bool)colorApplier)
			{
				targetTransform = target.transform;
			}
			else
			{
				Debug.LogError("Target " + target.name + " doesn't have TextureMaskHolder component.");
			}
			ClearCleaningResultBufferData();
		}

		public void SetBrushSettings(CleaningToolInfo cleaningToolInfo)
		{
			currentBrushSettings = cleaningToolInfo;
			currentTotalCleaningPowerColor = new Color(cleaningToolInfo.RedCleanPower, cleaningToolInfo.GreenCleanPower, cleaningToolInfo.BlueCleanPower, cleaningToolInfo.AlphaCleanPower);
			UpdateBrushTexture();
		}

		public void SetSolderingSettings(SolderingToolInfo solderingToolInfo)
		{
			currentSolderingSettings = solderingToolInfo;
		}

		public void ResetTarget()
		{
			targetTransform = null;
			colorApplier = null;
			ClearCleaningResultBufferData();
		}

		public void ClearWholeTargetTexture()
		{
			if (!targetTransform)
			{
				Debug.LogError("Try to clear texture without target.");
				return;
			}
			switch (calculationType)
			{
			case CalculationType.CPU:
				ClearWholeTextureCpu();
				break;
			case CalculationType.ComputeShader:
				ClearWholeTextureComputeShader();
				break;
			}
		}

		public void Execute(Vector3 screenPosition)
		{
			if (!targetTransform)
			{
				Debug.LogError("[CleanerBrush] tried to execute brush without target.");
			}
			else if (!(Time.time - previousApplyBrushTime < continuesApplyDelayTime))
			{
				UpdateBrushSize();
				ExecuteMultiRaycastCleanOperation(screenPosition);
				previousApplyBrushTime = Time.time;
				this.OnExecute?.Invoke();
			}
		}

		public void ExecuteSoldering(Vector3 screenPosition)
		{
			if (!targetTransform)
			{
				Debug.LogError("[CleanerBrush] tried to execute soldering without target.");
				return;
			}
			int num = Physics.RaycastNonAlloc(mainCamera.ScreenPointToRay(screenPosition), resultHits, maxDistance, ProjectConstants.Layers.SolderingMask);
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit = resultHits[i];
				if (raycastHit.collider.TryGetComponent<SolderPoint>(out var component))
				{
					component.ApplySolderingTool();
				}
			}
			this.OnExecuteSoldering?.Invoke();
		}

		public void ClearSingleColorChannel(AffectedColorChannels colorChannelsToClear)
		{
			switch (calculationType)
			{
			case CalculationType.CPU:
				ClearSpecificColorChannelsInTextureCpu(colorChannelsToClear.Red, colorChannelsToClear.Green, colorChannelsToClear.Blue);
				break;
			case CalculationType.ComputeShader:
				ClearSpecificColorChannelsInTextureComputeShader(colorApplier.WorkTexture, colorChannelsToClear.Red, colorChannelsToClear.Green, colorChannelsToClear.Blue);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		public bool TryToGetLastPassCleanedValues(out float redChannelCleanedAmount, out float greenChannelCleanedAmount, out float blueChannelCleanedAmount)
		{
			redChannelCleanedAmount = (float)cleaningResultBufferData[0] / 1000f;
			greenChannelCleanedAmount = (float)cleaningResultBufferData[1] / 1000f;
			blueChannelCleanedAmount = (float)cleaningResultBufferData[2] / 1000f;
			return redChannelCleanedAmount + greenChannelCleanedAmount + blueChannelCleanedAmount > 0f;
		}

		private void ExecuteMultiRaycastCleanOperation(Vector3 screenPosition)
		{
			rayHitsCount = 0;
			Ray ray = mainCamera.ScreenPointToRay(screenPosition);
			if (TryToGetTextureCoordinateWhereRayHits(ray, colorApplier.WorkTexture, out var hitTextureCoordinate, out var rayCastHit))
			{
				raysHitsTextureCoordinates[rayHitsCount] = hitTextureCoordinate;
				raysHits[rayHitsCount] = rayCastHit;
				rayHitsCount++;
			}
			for (int i = 1; i <= raycastRingsCount; i++)
			{
				float radius = (float)i * currentBrushSettings.BrushRaycastRingsSpacing;
				int num = raysIncrementPerRing * i;
				for (int j = 0; j < num; j++)
				{
					float angle = (float)j / (float)num * MathF.PI * 2f;
					Ray ray2 = (currentBrushSettings.AreBrushRaysCastParallelInWorldSpace ? GetParallelRay(angle, radius, ray) : GetRayFromScreenPoint(angle, radius, screenPosition));
					if (TryToGetTextureCoordinateWhereRayHits(ray2, colorApplier.WorkTexture, out var hitTextureCoordinate2, out var rayCastHit2))
					{
						raysHitsTextureCoordinates[rayHitsCount] = hitTextureCoordinate2;
						raysHits[rayHitsCount] = rayCastHit2;
						rayHitsCount++;
					}
				}
			}
			switch (calculationType)
			{
			case CalculationType.CPU:
				ApplyMultiBrushCpu(colorApplier.WorkTexture, raysHitsTextureCoordinates, rayHitsCount);
				break;
			case CalculationType.ComputeShader:
				ApplyMultiBrushComputeShader(colorApplier.WorkTexture, raysHitsTextureCoordinates, rayHitsCount);
				break;
			default:
				throw new NotImplementedException();
			}
		}

		private Ray GetRayFromScreenPoint(float angle, float radius, Vector3 center)
		{
			Vector2 vector = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * radius;
			float brushRaycastRayMaxRandomDeviation = currentBrushSettings.BrushRaycastRayMaxRandomDeviation;
			Vector3 pos = center + new Vector3(vector.x + UnityEngine.Random.Range(0f - brushRaycastRayMaxRandomDeviation, brushRaycastRayMaxRandomDeviation), vector.y + UnityEngine.Random.Range(0f - brushRaycastRayMaxRandomDeviation, brushRaycastRayMaxRandomDeviation), 0f);
			return mainCamera.ScreenPointToRay(pos);
		}

		private Ray GetParallelRay(float angle, float radius, Ray centralRay)
		{
			Transform obj = mainCamera.transform;
			Vector3 right = obj.right;
			Vector3 up = obj.up;
			float brushRaycastRayMaxRandomDeviation = currentBrushSettings.BrushRaycastRayMaxRandomDeviation;
			Vector3 vector = (right * Mathf.Cos(angle) + up * Mathf.Sin(angle)) * radius;
			Vector3 vector2 = right * UnityEngine.Random.Range(0f - brushRaycastRayMaxRandomDeviation, brushRaycastRayMaxRandomDeviation) + up * UnityEngine.Random.Range(0f - brushRaycastRayMaxRandomDeviation, brushRaycastRayMaxRandomDeviation);
			return new Ray(centralRay.origin + vector + vector2, centralRay.direction);
		}

		private bool TryToGetTextureCoordinateWhereRayHits(Ray ray, Texture2D dirtyMaskTexture, out Vector2Int hitTextureCoordinate, out RaycastHit rayCastHit)
		{
			int num = Physics.RaycastNonAlloc(ray, resultHits, maxDistance, layerMask);
			if (num == 0)
			{
				hitTextureCoordinate = Vector2Int.zero;
				rayCastHit = default(RaycastHit);
				return false;
			}
			RaycastHit raycastHit = new RaycastHit
			{
				distance = float.MaxValue
			};
			for (int i = 0; i < num; i++)
			{
				RaycastHit raycastHit2 = resultHits[i];
				if (raycastHit2.collider.gameObject.layer == ProjectConstants.Layers.Soldering && raycastHit2.collider.TryGetComponent<SolderPoint>(out var component))
				{
					component.ApplyCleaningTool();
				}
				if (raycastHit2.transform == targetTransform && raycastHit2.distance < raycastHit.distance)
				{
					raycastHit = raycastHit2;
				}
			}
			if (raycastHit.distance > maxDistance)
			{
				hitTextureCoordinate = Vector2Int.zero;
				rayCastHit = default(RaycastHit);
				return false;
			}
			hitTextureCoordinate = new Vector2Int(Mathf.FloorToInt(raycastHit.textureCoord.x * (float)dirtyMaskTexture.width), Mathf.FloorToInt(raycastHit.textureCoord.y * (float)dirtyMaskTexture.height));
			rayCastHit = raycastHit;
			return true;
		}

		private void ClearCleaningResultBufferData()
		{
			for (int i = 0; i < cleaningResultBufferData.Length; i++)
			{
				cleaningResultBufferData[i] = 0;
			}
		}

		private void OnCleaningResultReadback(AsyncGPUReadbackRequest request)
		{
			if (!request.hasError)
			{
				NativeArray<int> data = request.GetData<int>();
				cleaningResultBufferData[0] = data[0];
				cleaningResultBufferData[1] = data[1];
				cleaningResultBufferData[2] = data[2];
			}
		}

		private void ApplyBrush(Texture2D dirtyMaskTexture, Vector2 textureCoord)
		{
			switch (calculationType)
			{
			case CalculationType.CPU:
				ApplyBrushCpu(dirtyMaskTexture, textureCoord);
				break;
			case CalculationType.ComputeShader:
				ApplyBrushComputeShader(dirtyMaskTexture, textureCoord);
				break;
			}
		}

		private void ApplyBrushComputeShader(Texture2D dirtyMaskTexture, Vector2 textureCoord)
		{
		}

		private void ApplyBrushCpu(Texture2D dirtyMaskTexture, Vector2 textureCoord)
		{
			Vector2Int brushSize = currentBrushSettings.BrushSize;
			int num = (int)(textureCoord.x * (float)dirtyMaskTexture.width);
			int num2 = (int)(textureCoord.y * (float)dirtyMaskTexture.height);
			int pixelXOffset = num - brushSize.x / 2;
			int pixelYOffset = num2 - brushSize.y / 2;
			SetTexturePixelWithoutApplying(dirtyMaskTexture, brushSize.x, brushSize.y, pixelXOffset, pixelYOffset);
			dirtyMaskTexture.Apply();
		}

		private void ApplyMultiBrushComputeShader(Texture2D dirtyMaskTexture, Vector2Int[] textureCoords, int validCoordsCount)
		{
			if (validCoordsCount <= 0)
			{
				return;
			}
			Vector2Int brushSize = currentBrushSettings.BrushSize;
			bool flag = false;
			if (lastProcessedTexture != dirtyMaskTexture)
			{
				PrepareWorkRenderTexture(dirtyMaskTexture);
				PrepareMicroColorsBufferTexture(dirtyMaskTexture);
				lastProcessedTexture = dirtyMaskTexture;
				flag = true;
			}
			else
			{
				if (!workRenderTexture || workRenderTexture.width != dirtyMaskTexture.width || workRenderTexture.height != dirtyMaskTexture.height)
				{
					PrepareWorkRenderTexture(dirtyMaskTexture);
					flag = true;
				}
				if (!microColorsBufferTexture || microColorsBufferTexture.width != dirtyMaskTexture.width || microColorsBufferTexture.height != dirtyMaskTexture.height)
				{
					PrepareMicroColorsBufferTexture(dirtyMaskTexture);
					flag = true;
				}
			}
			PrepareStrokeBufferTexture(dirtyMaskTexture);
			cleaningResultBuffer.SetData(clearCleaningResultData);
			raysHitsTextureCoordinatesBuffer.SetData(textureCoords);
			commandBuffer.Clear();
			if (flag)
			{
				Graphics.CopyTexture(dirtyMaskTexture, workRenderTexture);
				commandBuffer.SetComputeTextureParam(brushComputeShader, brushComputeShaderMicroColorsBufferInitKernel, "WorkTexture", workRenderTexture);
				commandBuffer.SetComputeTextureParam(brushComputeShader, brushComputeShaderMicroColorsBufferInitKernel, "HighPrecisionColorsBuffer", microColorsBufferTexture);
				commandBuffer.SetComputeVectorParam(brushComputeShader, "TextureSize", new Vector4(dirtyMaskTexture.width, dirtyMaskTexture.height, 0f, 0f));
				int threadGroupsX = Mathf.CeilToInt((float)dirtyMaskTexture.width / 8f);
				int threadGroupsY = Mathf.CeilToInt((float)dirtyMaskTexture.height / 8f);
				commandBuffer.DispatchCompute(brushComputeShader, brushComputeShaderMicroColorsBufferInitKernel, threadGroupsX, threadGroupsY, 1);
			}
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushComputeShaderAddToStrokeKernel, "BrushTexture", brushTexture);
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushComputeShaderAddToStrokeKernel, "StrokeBuffer", strokeBufferTexture);
			commandBuffer.SetComputeVectorParam(brushComputeShader, "BrushPowerChannels", currentTotalCleaningPowerColor);
			commandBuffer.SetComputeBufferParam(brushComputeShader, brushComputeShaderAddToStrokeKernel, "TextureCoords", raysHitsTextureCoordinatesBuffer);
			commandBuffer.SetComputeIntParam(brushComputeShader, "CoordsCount", validCoordsCount);
			commandBuffer.SetComputeVectorParam(brushComputeShader, "BrushSize", new Vector4(brushSize.x, brushSize.y, 0f, 0f));
			int threadGroupsX2 = Mathf.CeilToInt((float)brushSize.x / 8f);
			int threadGroupsY2 = Mathf.CeilToInt((float)brushSize.y / 8f);
			commandBuffer.DispatchCompute(brushComputeShader, brushComputeShaderAddToStrokeKernel, threadGroupsX2, threadGroupsY2, 1);
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushComputeShaderCommitStrokeKernel, "WorkTexture", workRenderTexture);
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushComputeShaderCommitStrokeKernel, "HighPrecisionColorsBuffer", microColorsBufferTexture);
			commandBuffer.SetComputeTextureParam(brushComputeShader, brushComputeShaderCommitStrokeKernel, "StrokeBuffer", strokeBufferTexture);
			commandBuffer.SetComputeBufferParam(brushComputeShader, brushComputeShaderCommitStrokeKernel, "CleaningResult", cleaningResultBuffer);
			commandBuffer.SetComputeIntParam(brushComputeShader, "CleaningResultMultiplier", 1000);
			int threadGroupsX3 = Mathf.CeilToInt((float)dirtyMaskTexture.width / 8f);
			int threadGroupsY3 = Mathf.CeilToInt((float)dirtyMaskTexture.height / 8f);
			commandBuffer.DispatchCompute(brushComputeShader, brushComputeShaderCommitStrokeKernel, threadGroupsX3, threadGroupsY3, 1);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			AsyncGPUReadback.Request(cleaningResultBuffer, OnCleaningResultReadback);
			Graphics.CopyTexture(workRenderTexture, dirtyMaskTexture);
		}

		private void PrepareWorkRenderTexture(Texture2D dirtyMaskTexture)
		{
			if ((bool)workRenderTexture)
			{
				workRenderTexture.Release();
			}
			workRenderTexture = new RenderTexture(dirtyMaskTexture.width, dirtyMaskTexture.height, 0, RenderTextureFormat.ARGB32);
			workRenderTexture.enableRandomWrite = true;
			workRenderTexture.Create();
		}

		private void PrepareMicroColorsBufferTexture(Texture2D dirtyMaskTexture)
		{
			if ((bool)microColorsBufferTexture)
			{
				microColorsBufferTexture.Release();
			}
			microColorsBufferTexture = new RenderTexture(dirtyMaskTexture.width, dirtyMaskTexture.height, 0, RenderTextureFormat.ARGBFloat)
			{
				enableRandomWrite = true
			};
			microColorsBufferTexture.Create();
		}

		private void PrepareStrokeBufferTexture(Texture2D dirtyMaskTexture)
		{
			if (!strokeBufferTexture || strokeBufferTexture.width != workRenderTexture.width || strokeBufferTexture.height != workRenderTexture.height)
			{
				strokeBufferTexture = new RenderTexture(dirtyMaskTexture.width, dirtyMaskTexture.height, 0, RenderTextureFormat.ARGBFloat)
				{
					enableRandomWrite = true
				};
				strokeBufferTexture.Create();
				RenderTexture.active = strokeBufferTexture;
				GL.Clear(clearDepth: true, clearColor: true, new Color(0f, 0f, 0f, 0f));
				RenderTexture.active = null;
			}
			else
			{
				RenderTexture.active = strokeBufferTexture;
				GL.Clear(clearDepth: true, clearColor: true, new Color(0f, 0f, 0f, 0f));
				RenderTexture.active = null;
			}
		}

		private void ApplyMultiBrushCpu(Texture2D dirtyMaskTexture, Vector2Int[] textureCoordinates, int validTextureCoordinatesCount)
		{
			Vector2Int brushSize = currentBrushSettings.BrushSize;
			for (int i = 0; i < validTextureCoordinatesCount; i++)
			{
				int pixelXOffset = textureCoordinates[i].x - brushSize.x / 2;
				int pixelYOffset = textureCoordinates[i].y - brushSize.y / 2;
				SetTexturePixelWithoutApplying(dirtyMaskTexture, brushSize.x, brushSize.y, pixelXOffset, pixelYOffset);
			}
			dirtyMaskTexture.Apply();
		}

		private void SetTexturePixelWithoutApplying(Texture2D dirtyMaskTexture, int widthInPixels, int heightInPixels, int pixelXOffset, int pixelYOffset)
		{
			for (int i = 0; i < widthInPixels; i++)
			{
				for (int j = 0; j < heightInPixels; j++)
				{
					Color pixel = brushTexture.GetPixel(i, j);
					if (pixel.a > 0f)
					{
						int x = WrapTextureCoordinate(pixelXOffset + i, dirtyMaskTexture.width);
						int y = WrapTextureCoordinate(pixelYOffset + j, dirtyMaskTexture.height);
						Color pixel2 = dirtyMaskTexture.GetPixel(x, y);
						float num = currentTotalCleaningPowerColor.r * pixel.a;
						float num2 = currentTotalCleaningPowerColor.g * pixel.a;
						float num3 = currentTotalCleaningPowerColor.b * pixel.a;
						float num4 = currentTotalCleaningPowerColor.a * pixel.a;
						pixel2.r = Mathf.Clamp01(pixel2.r - num);
						pixel2.g = Mathf.Clamp01(pixel2.g - num2);
						pixel2.b = Mathf.Clamp01(pixel2.b - num3);
						pixel2.a = Mathf.Clamp01(pixel2.a - num4);
						dirtyMaskTexture.SetPixel(x, y, pixel2);
					}
				}
			}
		}

		private int WrapTextureCoordinate(int value, int maxValue)
		{
			return (value % maxValue + maxValue) % maxValue;
		}

		private void UpdateBrushSize()
		{
			Vector2Int brushSize = currentBrushSettings.BrushSize;
			if (brushTexture.width != brushSize.x || brushTexture.height != brushSize.y)
			{
				TextureScaler.Scale(brushTexture, brushSize.x, brushSize.y);
			}
		}

		private void ClearWholeTextureComputeShader()
		{
			if (colorApplier == null || colorApplier.WorkTexture == null)
			{
				Debug.LogError("Target texture is not set for ComputeShader clear operation.");
				return;
			}
			Texture2D workTexture = colorApplier.WorkTexture;
			if (workRenderTexture != null)
			{
				workRenderTexture.Release();
			}
			workRenderTexture = new RenderTexture(workTexture.width, workTexture.height, 0, RenderTextureFormat.ARGB32)
			{
				enableRandomWrite = true
			};
			workRenderTexture.Create();
			commandBuffer.Clear();
			commandBuffer.SetRenderTarget(workRenderTexture);
			commandBuffer.ClearRenderTarget(clearDepth: true, clearColor: true, Color.clear);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			Graphics.CopyTexture(workRenderTexture, workTexture);
		}

		private void ClearWholeTextureCpu()
		{
			if (colorApplier == null || colorApplier.WorkTexture == null)
			{
				Debug.LogError("Target texture is not set for CPU clear operation.");
				return;
			}
			Texture2D workTexture = colorApplier.WorkTexture;
			Color clear = Color.clear;
			Color[] array = new Color[workTexture.width * workTexture.height];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = clear;
			}
			workTexture.SetPixels(array);
			workTexture.Apply();
		}

		private void ClearSpecificColorChannelsInTextureCpu(bool clearRed, bool clearGreen, bool clearBlue)
		{
			if (colorApplier == null || colorApplier.WorkTexture == null)
			{
				Debug.LogError("Target texture is not set for CPU clear operation.");
				return;
			}
			Texture2D workTexture = colorApplier.WorkTexture;
			Color[] pixels = workTexture.GetPixels();
			for (int i = 0; i < pixels.Length; i++)
			{
				Color color = pixels[i];
				pixels[i] = new Color(clearRed ? 0f : color.r, clearGreen ? 0f : color.g, clearBlue ? 0f : color.b, color.a);
			}
			workTexture.SetPixels(pixels);
			workTexture.Apply();
		}

		private void ClearSpecificColorChannelsInTextureComputeShader(Texture2D dirtyMaskTexture, bool clearRed, bool clearGreen, bool clearBlue)
		{
			if (workRenderTexture == null || workRenderTexture.width != dirtyMaskTexture.width || workRenderTexture.height != dirtyMaskTexture.height)
			{
				if (workRenderTexture != null)
				{
					workRenderTexture.Release();
				}
				workRenderTexture = new RenderTexture(dirtyMaskTexture.width, dirtyMaskTexture.height, 0, RenderTextureFormat.ARGB32)
				{
					enableRandomWrite = true
				};
				workRenderTexture.Create();
			}
			commandBuffer.Clear();
			commandBuffer.SetComputeTextureParam(colorChannelsClearComputeShader, clearChannelsShaderKernel, "WorkTexture", workRenderTexture);
			commandBuffer.SetComputeFloatParam(colorChannelsClearComputeShader, "ClearRed", clearRed ? 1f : 0f);
			commandBuffer.SetComputeFloatParam(colorChannelsClearComputeShader, "ClearGreen", clearGreen ? 1f : 0f);
			commandBuffer.SetComputeFloatParam(colorChannelsClearComputeShader, "ClearBlue", clearBlue ? 1f : 0f);
			int num = 8;
			int threadGroupsX = Mathf.CeilToInt((float)workRenderTexture.width / (float)num);
			int threadGroupsY = Mathf.CeilToInt((float)workRenderTexture.height / (float)num);
			commandBuffer.DispatchCompute(colorChannelsClearComputeShader, clearChannelsShaderKernel, threadGroupsX, threadGroupsY, 1);
			commandBuffer.CopyTexture(workRenderTexture, dirtyMaskTexture);
			Graphics.ExecuteCommandBuffer(commandBuffer);
		}

		private void UpdateBrushTexture()
		{
			Vector2Int brushSize = currentBrushSettings.BrushSize;
			Texture2D sourceTexture = currentBrushSettings.BrushTexture;
			brushTexture = TextureScaler.Scaled(sourceTexture, brushSize.x, brushSize.y);
		}

		private int GetMaxRaysCount()
		{
			int num = 1;
			for (int i = 1; i <= raycastRingsCount; i++)
			{
				num += i * raysIncrementPerRing;
			}
			return num;
		}
	}
}
