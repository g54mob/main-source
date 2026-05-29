using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

namespace cakeslice
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(Camera))]
	public class OutlineEffect : MonoBehaviour
	{
		private readonly LinkedSet<Outline> outlines;

		[Range(1f, 6f)]
		public float lineThickness;

		[Range(0f, 10f)]
		public float lineIntensity;

		[Range(0f, 1f)]
		public float fillAmount;

		public Color lineColor0;

		public Color lineColor1;

		public Color lineColor2;

		public bool additiveRendering;

		public bool backfaceCulling;

		public Color fillColor;

		public bool useFillColor;

		[Header("These settings can affect performance!")]
		public bool cornerOutlines;

		public bool addLinesBetweenColors;

		[Header("Advanced settings")]
		public bool scaleWithScreenSize;

		[Range(0f, 1f)]
		public float alphaCutoff;

		public bool flipY;

		public Camera sourceCamera;

		public bool autoEnableOutlines;

		[HideInInspector]
		public Camera outlineCamera;

		private Material outline1Material;

		private Material outline2Material;

		private Material outline3Material;

		private Material outlineEraseMaterial;

		private Shader outlineShader;

		private Shader outlineBufferShader;

		[HideInInspector]
		public Material outlineShaderMaterial;

		[HideInInspector]
		public RenderTexture renderTexture;

		[HideInInspector]
		public RenderTexture extraRenderTexture;

		private CommandBuffer commandBuffer;

		private List<Material> materialBuffer;

		private bool RenderTheNextFrame;

		public static OutlineEffect Instance { get; private set; }

		private Material GetMaterialFromID(int ID)
		{
			return null;
		}

		private Material CreateMaterial(Color emissionColor)
		{
			return null;
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		public void OnPreRender()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDestroy()
		{
		}

		[ImageEffectOpaque]
		private void OnRenderImage(RenderTexture source, RenderTexture destination)
		{
		}

		private void CreateMaterialsIfNeeded()
		{
		}

		private void DestroyMaterials()
		{
		}

		public void UpdateMaterialsPublicProperties()
		{
		}

		private void UpdateOutlineCameraFromSource()
		{
		}

		public void AddOutline(Outline outline)
		{
		}

		public void RemoveOutline(Outline outline)
		{
		}
	}
}
