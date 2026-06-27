using UnityEngine;
using UnityEngine.Rendering;

namespace Mandragora.PWS
{
	public class CursorBrush : MonoBehaviour
	{
		public enum CalculationType
		{
			CPU = 0,
			ComputeShader = 1
		}

		[SerializeField]
		private LayerMask layerMask = -1;

		[SerializeField]
		private float maxDistance = 10f;

		[SerializeField]
		[Tooltip("Time delay for continues coloring process")]
		private float continuesApplyDelayTime = 0.02f;

		[SerializeField]
		private CalculationType calculationType = CalculationType.ComputeShader;

		[SerializeField]
		private BrushData brushData;

		[SerializeField]
		private Color overrideBrushColor = Color.white;

		[SerializeField]
		private ComputeShader brushComputeShader;

		private Camera mainCamera;

		private int computeShaderKernel;

		private float previousApplyBrushTime;

		private CommandBuffer commandBuffer;

		private RenderTexture workRenderTexture;

		private Texture2D lastProcessedTexture;

		private Texture2D brushTexture;

		private RaycastHit[] resultHits = new RaycastHit[1];

		private void Awake()
		{
			UpdateBrushTexture();
			if (brushComputeShader != null)
			{
				computeShaderKernel = brushComputeShader.FindKernel("CSMain");
			}
			commandBuffer = new CommandBuffer();
			commandBuffer.name = "BrushApplyBuffer";
		}

		private void OnDestroy()
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
		}

		private void Start()
		{
			if (!mainCamera)
			{
				mainCamera = Camera.main;
			}
		}

		private void Update()
		{
			float num = Time.time - previousApplyBrushTime;
			if (!mainCamera || !Input.GetMouseButton(0) || !(num > continuesApplyDelayTime))
			{
				return;
			}
			UpdateBrushSize();
			int num2 = Physics.RaycastNonAlloc(mainCamera.ScreenPointToRay(Input.mousePosition), resultHits, maxDistance, layerMask);
			for (int i = 0; i < num2; i++)
			{
				RaycastHit raycastHit = resultHits[i];
				if (raycastHit.transform.TryGetComponent<TextureMaskHolder>(out var component))
				{
					ApplyBrush(component.WorkTexture, raycastHit.textureCoord);
					previousApplyBrushTime = Time.time;
				}
			}
		}

		public void SetBrushData(BrushData brushData)
		{
			this.brushData = brushData;
			UpdateBrushTexture();
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
			Vector2Int brushSize = brushData.BrushSize;
			if (lastProcessedTexture != dirtyMaskTexture || workRenderTexture == null || workRenderTexture.width != dirtyMaskTexture.width || workRenderTexture.height != dirtyMaskTexture.height)
			{
				if (workRenderTexture != null)
				{
					workRenderTexture.Release();
				}
				workRenderTexture = new RenderTexture(dirtyMaskTexture.width, dirtyMaskTexture.height, 0, RenderTextureFormat.ARGB32);
				workRenderTexture.enableRandomWrite = true;
				workRenderTexture.Create();
				lastProcessedTexture = dirtyMaskTexture;
			}
			commandBuffer.Clear();
			commandBuffer.Blit(dirtyMaskTexture, workRenderTexture);
			Vector2Int vector2Int = new Vector2Int(Mathf.FloorToInt(textureCoord.x * (float)dirtyMaskTexture.width), Mathf.FloorToInt(textureCoord.y * (float)dirtyMaskTexture.height));
			commandBuffer.SetComputeTextureParam(brushComputeShader, computeShaderKernel, "BrushTexture", brushTexture);
			commandBuffer.SetComputeTextureParam(brushComputeShader, computeShaderKernel, "WorkTexture", workRenderTexture);
			commandBuffer.SetComputeVectorParam(brushComputeShader, "TextureCoord", new Vector4(vector2Int.x, vector2Int.y, 0f, 0f));
			commandBuffer.SetComputeVectorParam(brushComputeShader, "DirtyMaskTextureSize", new Vector4(dirtyMaskTexture.width, dirtyMaskTexture.height, 0f, 0f));
			commandBuffer.SetComputeVectorParam(brushComputeShader, "BrushSize", new Vector4(brushSize.x, brushSize.y, 0f, 0f));
			commandBuffer.SetComputeIntParam(brushComputeShader, "InvertRedChanel", brushData.InvertRed ? 1 : 0);
			commandBuffer.SetComputeIntParam(brushComputeShader, "InvertGreenChanel", brushData.InvertGreen ? 1 : 0);
			commandBuffer.SetComputeIntParam(brushComputeShader, "InvertBlueChanel", brushData.InvertBlue ? 1 : 0);
			commandBuffer.SetComputeIntParam(brushComputeShader, "InvertAlphaChanel", brushData.InvertAlpha ? 1 : 0);
			commandBuffer.SetComputeVectorParam(brushComputeShader, "OverrideBrushColor", overrideBrushColor);
			int threadGroupsX = Mathf.CeilToInt((float)brushSize.x / 8f);
			int threadGroupsY = Mathf.CeilToInt((float)brushSize.y / 8f);
			commandBuffer.DispatchCompute(brushComputeShader, computeShaderKernel, threadGroupsX, threadGroupsY, 1);
			Graphics.ExecuteCommandBuffer(commandBuffer);
			Graphics.CopyTexture(workRenderTexture, dirtyMaskTexture);
		}

		private void ApplyBrushCpu(Texture2D dirtyMaskTexture, Vector2 textureCoord)
		{
			Vector2Int brushSize = brushData.BrushSize;
			int num = (int)(textureCoord.x * (float)dirtyMaskTexture.width);
			int num2 = (int)(textureCoord.y * (float)dirtyMaskTexture.height);
			int num3 = num - brushSize.x / 2;
			int num4 = num2 - brushSize.y / 2;
			for (int i = 0; i < brushSize.x; i++)
			{
				for (int j = 0; j < brushSize.y; j++)
				{
					Color pixel = brushTexture.GetPixel(i, j);
					if (pixel.a > 0f)
					{
						int x = WrapTextureCoordinate(num3 + i, dirtyMaskTexture.width);
						int y = WrapTextureCoordinate(num4 + j, dirtyMaskTexture.height);
						Color pixel2 = dirtyMaskTexture.GetPixel(x, y);
						float num5 = overrideBrushColor.r * pixel.a;
						if (brushData.InvertRed)
						{
							num5 = 1f - num5;
						}
						float num6 = overrideBrushColor.g * pixel.a;
						if (brushData.InvertGreen)
						{
							num6 = 1f - num6;
						}
						float num7 = overrideBrushColor.b * pixel.a;
						if (brushData.InvertBlue)
						{
							num7 = 1f - num7;
						}
						float num8 = overrideBrushColor.a * pixel.a;
						if (brushData.InvertAlpha)
						{
							num8 = 1f - num8;
						}
						pixel2.r *= num5;
						pixel2.g *= num6;
						pixel2.b *= num7;
						pixel2.a *= num8;
						dirtyMaskTexture.SetPixel(x, y, pixel2);
					}
				}
			}
			dirtyMaskTexture.Apply();
		}

		private int WrapTextureCoordinate(int value, int maxValue)
		{
			return (value % maxValue + maxValue) % maxValue;
		}

		private void UpdateBrushSize()
		{
			Vector2Int brushSize = brushData.BrushSize;
			if (brushTexture.width != brushSize.x || brushTexture.height != brushSize.y)
			{
				TextureScaler.Scale(brushTexture, brushSize.x, brushSize.y);
			}
		}

		private void UpdateBrushTexture()
		{
			Vector2Int brushSize = brushData.BrushSize;
			Texture2D sourceTexture = brushData.BrushTexture;
			brushTexture = TextureScaler.Scaled(sourceTexture, brushSize.x, brushSize.y);
		}
	}
}
