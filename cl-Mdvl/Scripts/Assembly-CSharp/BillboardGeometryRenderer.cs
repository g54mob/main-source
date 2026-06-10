using FoxyVoxel.Logging;
using NSEipix.Base;
using NSMedieval.Controllers;
using UnityEngine;

public class BillboardGeometryRenderer : MonoBehaviour
{
	[SerializeField]
	private Camera renderCamera;

	[SerializeField]
	private Camera photoCamera;

	[SerializeField]
	private Shader geometryShader;

	[SerializeField]
	private Texture2D sprite;

	[SerializeField]
	private Vector2 size = Vector2.one;

	[SerializeField]
	private float sizeMultiplier = 1f;

	[SerializeField]
	private Color color = new Color(1f, 1f, 1f, 1f);

	[SerializeField]
	private float alphaMultiplier = 1f;

	[SerializeField]
	private float depthClip;

	[SerializeField]
	private float particlesFadeIn = 2f;

	[SerializeField]
	private float particlesFadeOut = 10f;

	[SerializeField]
	private float particlesFadeZOffset;

	[SerializeField]
	private bool alphaFromEdgeFrameDistance;

	[SerializeField]
	private float alphaEdgeFrameDistanceFadeIn;

	[SerializeField]
	[Range(0f, 2f)]
	[Tooltip("Orientation 0 = static, 1 = Cylindrical, 2 = Sphecrical")]
	private int orientation = 2;

	private ParticleGeometryGenerator geometryGenerator;

	private Material material;

	private Color renderColor = Color.white;

	private void OnRenderObject()
	{
		if (!base.enabled || !MonoSingleton<LoadingController>.IsInstantiated() || !LoadingController.IsLoadingComplete || MonoSingleton<LoadingController>.IsApplicationIsQuitting() || (renderCamera != null && renderCamera != Camera.current && photoCamera != null && photoCamera != Camera.current))
		{
			return;
		}
		renderColor.a = color.a * alphaMultiplier;
		if (!(renderColor.a <= 0.001f))
		{
			LazyInit();
			if (geometryGenerator == null)
			{
				Log.Error("geometryGenerator is NULL", "C:\\GIT\\dev\\Assets\\Scripts\\BillboardGeometryRenderer.cs");
				return;
			}
			renderColor.r = color.r;
			renderColor.g = color.g;
			renderColor.b = color.b;
			geometryGenerator.Dispatch();
			material.SetPass(0);
			material.SetColor("_Color", renderColor);
			material.SetBuffer("buf_Points", geometryGenerator.OutputBuffer);
			material.SetTexture("_Sprite", sprite);
			material.SetVector("_Size", size * sizeMultiplier);
			material.SetInt("_ParticleOrientation", orientation);
			material.SetFloat("_DepthClip", depthClip);
			material.SetFloat("_ParticlesFadeIn", particlesFadeIn);
			material.SetFloat("_ParticlesFadeOut", particlesFadeOut);
			material.SetFloat("_ParticlesFadeZOffset", particlesFadeZOffset);
			material.SetInt("_AlphaFromEdgeFrameDistance", alphaFromEdgeFrameDistance ? 1 : 0);
			material.SetFloat("_AlphaEdgeFrameDistanceFadeIn", alphaEdgeFrameDistanceFadeIn);
			Graphics.DrawProceduralNow(MeshTopology.Points, geometryGenerator.OutputBuffer.count);
		}
	}

	public void SetAlphaMultiplier(float alphaMultiplier)
	{
		this.alphaMultiplier = alphaMultiplier;
	}

	public void SetSizeMultiplier(float sizeMultiplier)
	{
		this.sizeMultiplier = sizeMultiplier;
	}

	public void SetColor(Color color)
	{
		this.color = color;
	}

	private void LazyInit()
	{
		if (material == null)
		{
			material = new Material(geometryShader);
		}
		if (geometryGenerator == null)
		{
			geometryGenerator = base.gameObject.GetComponent<ParticleGeometryGenerator>();
			if (geometryGenerator == null)
			{
				Log.Error("GeometryGenerator is null, nothing to draw.", "C:\\GIT\\dev\\Assets\\Scripts\\BillboardGeometryRenderer.cs");
			}
		}
	}

	private void OnDestroy()
	{
		if (material != null)
		{
			Object.DestroyImmediate(material);
		}
	}
}
