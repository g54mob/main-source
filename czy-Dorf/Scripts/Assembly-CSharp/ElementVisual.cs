using System;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using Dorfromantik;
using UnityEngine;

public class ElementVisual : MonoBehaviour, IRecyclable, IInstanceable
{
	[Serializable]
	private sealed class _003C_003Ec
	{
		public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

		public static Func<KeyValuePair<Biome, float>, Debug_BiomeInfluence> _003C_003E9__74_0;

		internal Debug_BiomeInfluence _003CApplyBiomeConfiguration_003Eb__74_0(KeyValuePair<Biome, float> x)
		{
			return new Debug_BiomeInfluence(x.Key, x.Value);
		}
	}

	[SerializeField]
	private RecyclableType recyclableID;

	[SerializeField]
	public bool setTileStackMaterialParameter;

	[SerializeField]
	private bool isDecoration;

	[SerializeField]
	public bool instancingEnabled;

	[SerializeField]
	private ElementType elementType;

	[SerializeField]
	public bool useUniformScale;

	[SerializeField]
	public Vector3 randomMinScale = Vector3.one;

	[SerializeField]
	public Vector3 randomMaxScale = Vector3.one;

	[SerializeField]
	private List<CustomInstanceTexture> customTextures;

	public bool setSizeSeed;

	[SerializeField]
	public bool softBiomeTransitionsEnabled;

	[SerializeField]
	public SettingsRouter settingsRouter;

	[SerializeField]
	private bool drawnInstanced;

	[SerializeField]
	private bool viableForInstancing;

	[SerializeField]
	private Vector2Int instanceIndex;

	[SerializeField]
	private Vector3 randomScaleAlpha = Vector3.one;

	[SerializeField]
	private TileState currentTileState;

	[SerializeField]
	private List<Debug_BiomeInfluence> affectingBiomes;

	[SerializeField]
	private Mesh mesh;

	[SerializeField]
	private Vector3 debug_instancePos;

	[SerializeField]
	private Vector3 debug_instanceRot;

	[SerializeField]
	private List<FloatOption> debug_floatParameters;

	private Biome _003CBiome_003Ek__BackingField;

	private Matrix4x4 _003CTransformMatrix_003Ek__BackingField;

	private bool _003CIsHighlighted_003Ek__BackingField;

	private List<Renderer> elementRenderers = new List<Renderer>();

	private Material[] sharedMaterials;

	private bool usingMaterialInstance;

	private Tween fadeTween;

	private Element element;

	public bool isSetup;

	private bool areRenderersSetup;

	private int highlightShaderPropertyId = -1;

	public GameObject GameObject => base.gameObject;

	public RecyclableType RecyclableId
	{
		get
		{
			return recyclableID;
		}
		set
		{
			recyclableID = value;
		}
	}

	public bool IsDecoration => isDecoration;

	public List<CustomInstanceTexture> CustomTextures
	{
		get
		{
			List<CustomInstanceTexture> list = new List<CustomInstanceTexture>(customTextures);
			if ((bool)Biome && Enumerable.Count(Biome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == ElementType) > 0)
			{
				list.AddRange(Enumerable.First(Biome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == ElementType).textures);
			}
			return list;
		}
	}

	public MeshRenderer MeshRenderer => GetComponentInChildren<MeshRenderer>();

	public Material InstancedMaterial => ElementType.instancingInfo.instancedMaterial;

	public Instanceable ReferenceInstanceable => null;

	public List<CustomInstanceInt> CustomInts => new List<CustomInstanceInt>();

	public Mesh Mesh => mesh;

	public Biome Biome
	{
		get
		{
			return _003CBiome_003Ek__BackingField;
		}
		private set
		{
			_003CBiome_003Ek__BackingField = value;
		}
	}

	public Matrix4x4 TransformMatrix
	{
		get
		{
			return _003CTransformMatrix_003Ek__BackingField;
		}
		private set
		{
			_003CTransformMatrix_003Ek__BackingField = value;
		}
	}

	public bool IsHighlighted
	{
		get
		{
			return _003CIsHighlighted_003Ek__BackingField;
		}
		private set
		{
			_003CIsHighlighted_003Ek__BackingField = value;
		}
	}

	public ElementType ElementType => elementType;

	public int Seed => element.Seed;

	public event Action<int> OnSetup;

	public event Action<int> OnLayerChanged;

	private void OnEnable()
	{
		if (elementRenderers.Count == 0)
		{
			Debug.Log($"{this} has no elementRenderer");
		}
	}

	protected virtual void Awake()
	{
		if (!areRenderersSetup)
		{
			SetupRenderers();
		}
	}

	private void SetupRenderers()
	{
		elementRenderers = new List<Renderer>();
		elementRenderers.AddRange(GetComponentsInChildren<MeshRenderer>(includeInactive: true));
		elementRenderers.AddRange(GetComponentsInChildren<SkinnedMeshRenderer>(includeInactive: true));
		sharedMaterials = new Material[elementRenderers.Count];
		for (int i = 0; i < sharedMaterials.Length; i++)
		{
			sharedMaterials[i] = elementRenderers[i].sharedMaterial;
		}
		highlightShaderPropertyId = Shader.PropertyToID("_Highlight");
		areRenderersSetup = true;
	}

	public virtual void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
	{
		if (!areRenderersSetup)
		{
			SetupRenderers();
		}
		affectingBiomes = Enumerable.ToList(Enumerable.Select(biomeConfiguration.biomeInfluence, (KeyValuePair<Biome, float> x) => new Debug_BiomeInfluence(x.Key, x.Value)));
		if (instancingEnabled && settingsRouter.instancingEnabled && elementType != null && base.gameObject.layer == 10 && biomeConfiguration.biomeInfluence.Count > 0 && (!softBiomeTransitionsEnabled || biomeConfiguration.biomeInfluence.Count == 1))
		{
			if (softBiomeTransitionsEnabled)
			{
				Biome = Enumerable.First(biomeConfiguration.biomeInfluence.Keys);
			}
			else
			{
				UnityEngine.Random.InitState(Seed);
				Biome = Randomizer.SelectWeightedRandom(biomeConfiguration.biomeInfluence);
				Randomizer.RandomizeSeed();
			}
			viableForInstancing = true;
			usingMaterialInstance = true;
			if (currentTileState == TileState.placed && base.gameObject.activeInHierarchy)
			{
				AddGPUInstance();
			}
			for (int num = 0; num < elementRenderers.Count; num++)
			{
				elementRenderers[num].sharedMaterial = elementType.instancingInfo.instancedMaterial;
				elementRenderers[num].material.SetFloat("_BiomeCoordinate", Biome.biomeInstancingTextureCoordinate);
				ApplyBiomeEffectValues(biomeConfiguration);
				SetCustomTextures(elementRenderers[num].material);
				if (Biome.biomeFloatOptions != null)
				{
					foreach (FloatOption biomeFloatOption in Biome.biomeFloatOptions)
					{
						ChangeMaterialFloat(elementRenderers[num], biomeFloatOption.propertyName, biomeFloatOption.value);
					}
				}
				sharedMaterials[num] = elementType.instancingInfo.instancedMaterial;
			}
			return;
		}
		if (viableForInstancing)
		{
			for (int num2 = 0; num2 < elementRenderers.Count; num2++)
			{
				elementRenderers[num2].material = elementType.instancingInfo.nonInstancedMaterial;
				sharedMaterials[num2] = elementType.instancingInfo.nonInstancedMaterial;
				ApplyBiomeEffectValues(biomeConfiguration);
				SetCustomTextures(elementRenderers[num2].material);
			}
			viableForInstancing = false;
		}
		debug_floatParameters.Clear();
		ApplyBiomeEffectValues(biomeConfiguration);
	}

	private void ApplyBiomeEffectValues(BiomeObjectConfiguration biomeConfiguration)
	{
		foreach (BiomeEffectValue biomeEffectValue in biomeConfiguration.biomeEffectValues)
		{
			foreach (int rendererIndex in biomeEffectValue.rendererIndices)
			{
				if (rendererIndex == -1)
				{
					foreach (Renderer elementRenderer in elementRenderers)
					{
						if (biomeEffectValue.value is Color color)
						{
							ChangeMaterialColor(elementRenderer, biomeEffectValue.key, color);
						}
						else if (biomeEffectValue.value is Texture2D newTexture)
						{
							ChangeMaterialTexture(elementRenderer, biomeEffectValue.key, newTexture);
						}
						else if (biomeEffectValue.value is float targetFloat)
						{
							ChangeMaterialFloat(elementRenderer, biomeEffectValue.key, targetFloat);
						}
					}
				}
				else if (rendererIndex >= elementRenderers.Count)
				{
					Debug.LogError($"{base.name} doesn't have enough elementRenderer {elementRenderers.Count}, looking for index {rendererIndex}");
				}
				else if (biomeEffectValue.value is Color color2)
				{
					ChangeMaterialColor(elementRenderers[rendererIndex], biomeEffectValue.key, color2);
				}
				else if (biomeEffectValue.value is Texture2D newTexture2)
				{
					ChangeMaterialTexture(elementRenderers[rendererIndex], biomeEffectValue.key, newTexture2);
				}
				else if (biomeEffectValue.value is float targetFloat2)
				{
					ChangeMaterialFloat(elementRenderers[rendererIndex], biomeEffectValue.key, targetFloat2);
				}
			}
			usingMaterialInstance = true;
		}
		if (setSizeSeed)
		{
			ChangeMaterialFloat(elementRenderers[0], "_SizeSeed", base.transform.localScale.x);
		}
	}

	private void SetCustomTextures(Material targetMaterial)
	{
		foreach (CustomInstanceTexture customTexture in customTextures)
		{
			targetMaterial.SetTexture(customTexture.propertyName, customTexture.texture);
		}
		if (Enumerable.Count(Biome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == ElementType) > 0)
		{
			CustomInstanceTexture[] textures = Enumerable.First(Biome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == ElementType).textures;
			foreach (CustomInstanceTexture customInstanceTexture in textures)
			{
				targetMaterial.SetTexture(customInstanceTexture.propertyName, customInstanceTexture.texture);
			}
		}
	}

	private void ChangeMaterialColor(Renderer targetRenderer, string propertyName, Color color)
	{
		Material[] materials = targetRenderer.materials;
		for (int i = 0; i < materials.Length; i++)
		{
			materials[i].SetColor(propertyName, color);
		}
		targetRenderer.materials = materials;
	}

	private void ChangeMaterialTexture(Renderer targetRenderer, string propertyName, Texture2D newTexture)
	{
		Material[] materials = targetRenderer.materials;
		for (int i = 0; i < materials.Length; i++)
		{
			materials[i].SetTexture(propertyName, newTexture);
		}
		targetRenderer.materials = materials;
	}

	private void ChangeMaterialFloat(Renderer targetRenderer, string propertyName, float targetFloat)
	{
		debug_floatParameters.Add(new FloatOption
		{
			propertyName = propertyName,
			value = targetFloat
		});
		Material[] materials = targetRenderer.materials;
		for (int i = 0; i < materials.Length; i++)
		{
			materials[i].SetFloat(propertyName, targetFloat);
		}
		targetRenderer.materials = materials;
	}

	public virtual void SetLayer(int targetLayer)
	{
		if (!areRenderersSetup)
		{
			SetupRenderers();
		}
		base.gameObject.layer = targetLayer;
		foreach (Renderer elementRenderer in elementRenderers)
		{
			if (setTileStackMaterialParameter)
			{
				elementRenderer.material.SetFloat("_tilestack", (targetLayer == 9) ? 1 : 0);
			}
			elementRenderer.gameObject.layer = targetLayer;
		}
		this.OnLayerChanged?.Invoke(targetLayer);
	}

	private void ToggleHighlighted()
	{
		Highlight(!IsHighlighted);
	}

	public virtual void Highlight(bool newHighlight)
	{
		if (drawnInstanced && IsHighlighted != newHighlight)
		{
			OverwritingSingleton<InstanceDrawer>.Instance.RemoveInstance(this, Biome, instanceIndex, IsHighlighted);
			instanceIndex = OverwritingSingleton<InstanceDrawer>.Instance.AddInstance(this, null, Biome, TransformMatrix, newHighlight);
			IsHighlighted = newHighlight;
			return;
		}
		for (int i = 0; i < elementRenderers.Count; i++)
		{
			int num = i;
			if (!elementRenderers[i].sharedMaterial.HasProperty(highlightShaderPropertyId))
			{
				continue;
			}
			Tween tween = fadeTween;
			if (tween != null)
			{
				TweenExtensions.Kill(tween);
			}
			if (newHighlight)
			{
				elementRenderers[i].material.SetFloat(highlightShaderPropertyId, 0.7f);
				continue;
			}
			if (elementRenderers != null && elementRenderers.Count != 0 && sharedMaterials != null)
			{
				Material[] array = sharedMaterials;
				if (array == null || array.Length != 0)
				{
					if (!usingMaterialInstance)
					{
						elementRenderers[num].sharedMaterial = sharedMaterials[num];
					}
					else
					{
						elementRenderers[i].material.SetFloat(highlightShaderPropertyId, 0f);
					}
					continue;
				}
			}
			Debug.LogError($"{elementRenderers}, {sharedMaterials}", this);
			Debug.LogError($"{elementRenderers.Count} elementRenderers, {sharedMaterials.Length} shared materials", this);
		}
		IsHighlighted = newHighlight;
	}

	private void OnDisable()
	{
		Tween tween = fadeTween;
		if (tween != null)
		{
			TweenExtensions.Kill(tween, complete: true);
		}
		foreach (Renderer elementRenderer in elementRenderers)
		{
			if (elementRenderer == null || elementRenderer.sharedMaterial == null)
			{
				Debug.LogError($"{base.name} has no elementRenderer {elementRenderer} or shared material", this);
			}
			if (!drawnInstanced && elementRenderer.sharedMaterial.HasProperty(highlightShaderPropertyId))
			{
				elementRenderer.material.SetFloat(highlightShaderPropertyId, 0f);
			}
		}
		IsHighlighted = false;
		isSetup = false;
	}

	private void TestRandomValues(int seed = -1)
	{
		if (seed == -1)
		{
			Randomizer.RandomizeSeed();
		}
		else
		{
			UnityEngine.Random.InitState(seed);
		}
		Debug.Log($"{UnityEngine.Random.value}, {UnityEngine.Random.value}, {UnityEngine.Random.value}");
	}

	public void Setup(Element element)
	{
		this.element = element;
		if (instancingEnabled)
		{
			UnityEngine.Random.InitState(element.Seed);
			randomScaleAlpha.x = UnityEngine.Random.value;
			randomScaleAlpha.y = UnityEngine.Random.value;
			randomScaleAlpha.z = UnityEngine.Random.value;
			if (useUniformScale)
			{
				randomScaleAlpha.y = randomScaleAlpha.x;
				randomScaleAlpha.z = randomScaleAlpha.x;
			}
			Randomizer.RandomizeSeed();
			Vector3 localScale = base.transform.localScale;
			localScale = new Vector3(Mathf.Lerp(randomMinScale.x, randomMaxScale.x, randomScaleAlpha.x), Mathf.Lerp(randomMinScale.y, randomMaxScale.y, randomScaleAlpha.y), Mathf.Lerp(randomMinScale.z, randomMaxScale.z, randomScaleAlpha.z));
			base.transform.localScale = localScale;
			if (base.name.Contains("Ice_Cluster") && randomScaleAlpha.y > 0.5f)
			{
				Debug.LogError(base.name + " random scale.y > 0.5", this);
			}
		}
		currentTileState = element.CurrentTileState;
		isSetup = true;
		this.OnSetup?.Invoke(element.Seed);
	}

	private void OnValidate()
	{
		if ((bool)GetComponentInChildren<MeshFilter>())
		{
			mesh = GetComponentInChildren<MeshFilter>().sharedMesh;
		}
		else
		{
			Debug.LogWarning("OnValidate: " + base.name + " can't find MeshFilter in children");
		}
	}

	public void ChangeTileState(TileState targetState)
	{
		currentTileState = targetState;
		if (targetState == TileState.placed && viableForInstancing && base.gameObject.activeInHierarchy)
		{
			TransformMatrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.localScale);
			AddGPUInstance();
		}
		if (drawnInstanced && targetState == TileState.placementPreview)
		{
			RemoveGPUInstance(enableRenderers: true);
		}
	}

	private void AddGPUInstance()
	{
		if (drawnInstanced)
		{
			Debug.LogError("wants to draw " + base.name + " instanced twice!", this);
		}
		else
		{
			if (!base.gameObject.activeInHierarchy)
			{
				return;
			}
			TransformMatrix = Matrix4x4.TRS(base.transform.position, base.transform.rotation, base.transform.localScale);
			debug_instancePos = base.transform.position;
			debug_instanceRot = base.transform.rotation.eulerAngles;
			foreach (Renderer elementRenderer in elementRenderers)
			{
				elementRenderer.enabled = false;
			}
			instanceIndex = OverwritingSingleton<InstanceDrawer>.Instance.AddInstance(this, null, Biome, TransformMatrix, IsHighlighted);
			drawnInstanced = true;
		}
	}

	public void RemoveGPUInstance(bool enableRenderers = false)
	{
		if (!drawnInstanced)
		{
			return;
		}
		if (enableRenderers)
		{
			foreach (Renderer elementRenderer in elementRenderers)
			{
				elementRenderer.enabled = true;
			}
		}
		OverwritingSingleton<InstanceDrawer>.Instance.RemoveInstance(this, Biome, instanceIndex, IsHighlighted);
		drawnInstanced = false;
	}

	public void SetAnimationsRunning(bool animationsRunning)
	{
		if (animationsRunning && drawnInstanced)
		{
			RemoveGPUInstance(enableRenderers: true);
		}
		else if (!animationsRunning && !drawnInstanced && viableForInstancing)
		{
			AddGPUInstance();
		}
	}

	public void Show(bool newVisible)
	{
		if (!newVisible && drawnInstanced)
		{
			RemoveGPUInstance();
		}
		if (newVisible && !drawnInstanced && viableForInstancing)
		{
			AddGPUInstance();
		}
	}

	public void EnableSoftBiomeTransitions(bool enableSoftBiomeTransitions)
	{
		softBiomeTransitionsEnabled = enableSoftBiomeTransitions;
	}

	private bool _003Cget_CustomTextures_003Eb__30_0(CustomElementTypeTextures x)
	{
		return x.elementType == ElementType;
	}

	private bool _003Cget_CustomTextures_003Eb__30_1(CustomElementTypeTextures x)
	{
		return x.elementType == ElementType;
	}

	private bool _003CSetCustomTextures_003Eb__76_0(CustomElementTypeTextures x)
	{
		return x.elementType == ElementType;
	}

	private bool _003CSetCustomTextures_003Eb__76_1(CustomElementTypeTextures x)
	{
		return x.elementType == ElementType;
	}
}
