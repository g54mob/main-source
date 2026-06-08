using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	[Serializable]
	public class InstanceableVisual : IBiomeAffectedObject, IInstanceable
	{
		[Serializable]
		private sealed class _003C_003Ec
		{
			public static readonly _003C_003Ec _003C_003E9 = new _003C_003Ec();

			public static Func<KeyValuePair<Biome, float>, Debug_BiomeInfluence> _003C_003E9__92_0;

			internal Debug_BiomeInfluence _003CApplyBiomeConfiguration_003Eb__92_0(KeyValuePair<Biome, float> x)
			{
				return new Debug_BiomeInfluence(x.Key, x.Value);
			}
		}

		public bool isInitialized;

		public ElementType elementType;

		public ElementSubType elementSubType;

		public Instanceable referenceInstanceable;

		public ElementVisual referenceElementVisual;

		[SerializeField]
		public Vector3 localPosition;

		[SerializeField]
		public Quaternion localRotation = Quaternion.identity;

		[SerializeField]
		private Vector3 localScale = Vector3.one;

		[SerializeField]
		private bool useScaleMultipler;

		[SerializeField]
		private float scaleMultiplier = 1f;

		[SerializeField]
		private bool highlighted;

		[SerializeField]
		private bool viableForInstancing;

		[SerializeField]
		private Vector2Int instanceIndex;

		[SerializeField]
		private RecyclableType instancedType;

		[SerializeField]
		private Vector3 randomScaleAlpha = Vector3.one;

		[SerializeField]
		private List<Debug_BiomeInfluence> affectingBiomes;

		[SerializeField]
		private Biome currentBiome;

		[SerializeField]
		private ElementGroup currentElementGroup;

		private List<BiomeEffectValue> biomeEffectValues = new List<BiomeEffectValue>();

		[SerializeField]
		private InstancingDisplayState currentDisplayState;

		[SerializeField]
		private bool areAnimationsRunning;

		[SerializeField]
		private List<InstanceableVisual> subInstanceables = new List<InstanceableVisual>();

		private Instanceable nonInstancedInstanceable;

		private MeshRenderer nonInstancedRenderer;

		private GameObject spawnedAdditionalGameObject;

		[SerializeField]
		private Transform parent;

		[SerializeField]
		private Vector3 parentInstanceablePosition = Vector3.zero;

		[SerializeField]
		private Vector3 parentInstanceableRot = Vector3.zero;

		public List<CustomInstanceInt> CustomInts = new List<CustomInstanceInt>();

		private int _003CSeed_003Ek__BackingField;

		private float _003CVariationAlpha_003Ek__BackingField;

		private float _003CHidingAlpha_003Ek__BackingField;

		private bool initialBiomeApplied;

		[SerializeField]
		private float displayProbability;

		private bool _003CIsVisible_003Ek__BackingField = true;

		private Biome _003CinstancedBiome_003Ek__BackingField;

		private Matrix4x4 _003CTransformMatrix_003Ek__BackingField;

		private int _003CCurrentLayer_003Ek__BackingField;

		[SerializeField]
		private TileState currentTileState;

		private static int highlightShaderPropertyId = Shader.PropertyToID("_Highlight");

		public Vector3 LocalPosition
		{
			get
			{
				if (!(parentInstanceablePosition == Vector3.zero))
				{
					return parentInstanceablePosition + Quaternion.Euler(parentInstanceableRot) * localPosition;
				}
				return localPosition;
			}
		}

		public Quaternion LocalRotation
		{
			get
			{
				if (!(parentInstanceableRot == Vector3.zero))
				{
					return Quaternion.Euler(parentInstanceableRot) * localRotation;
				}
				return localRotation;
			}
		}

		public Mesh Mesh => referenceInstanceable.GetMesh(SettingsRouter.MeshQualityLevel);

		public MeshRenderer MeshRenderer => referenceInstanceable.MeshRenderer;

		public List<CustomInstanceTexture> CustomTextures
		{
			get
			{
				List<CustomInstanceTexture> list = new List<CustomInstanceTexture>(referenceInstanceable.customTextures);
				if ((bool)instancedBiome && Enumerable.Count(instancedBiome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == ElementType) > 0)
				{
					list.AddRange(Enumerable.First(instancedBiome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == ElementType).textures);
				}
				return list;
			}
		}

		public Material InstancedMaterial => ElementType.instancingInfo.instancedMaterial;

		public RecyclableType RecyclableId => referenceInstanceable.RecyclableId;

		public Instanceable ReferenceInstanceable => referenceInstanceable;

		public int Seed
		{
			get
			{
				return _003CSeed_003Ek__BackingField;
			}
			private set
			{
				_003CSeed_003Ek__BackingField = value;
			}
		}

		public float VariationAlpha
		{
			get
			{
				return _003CVariationAlpha_003Ek__BackingField;
			}
			private set
			{
				_003CVariationAlpha_003Ek__BackingField = value;
			}
		}

		public float HidingAlpha
		{
			get
			{
				return _003CHidingAlpha_003Ek__BackingField;
			}
			private set
			{
				_003CHidingAlpha_003Ek__BackingField = value;
			}
		}

		public bool IsVisible
		{
			get
			{
				return _003CIsVisible_003Ek__BackingField;
			}
			private set
			{
				_003CIsVisible_003Ek__BackingField = value;
			}
		}

		public bool IsDecoration => ElementType.instancingInfo.isDecoration;

		public Biome instancedBiome
		{
			get
			{
				return _003CinstancedBiome_003Ek__BackingField;
			}
			private set
			{
				_003CinstancedBiome_003Ek__BackingField = value;
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

		public int CurrentLayer
		{
			get
			{
				return _003CCurrentLayer_003Ek__BackingField;
			}
			private set
			{
				_003CCurrentLayer_003Ek__BackingField = value;
			}
		}

		public InstanceableCategoryId InstanceableCategory => ElementType.instancingInfo.category;

		public List<InstanceableVisual> SubInstanceables => subInstanceables;

		public bool IgnoresPlacementAnimation => ElementType.instancingInfo.ignoresPlacementAnimation;

		public ElementType ElementType
		{
			get
			{
				if (!referenceElementVisual)
				{
					return elementType;
				}
				return referenceElementVisual.ElementType;
			}
		}

		public void SetElementType(ElementType elementType, ElementSubType elementSubType = null)
		{
			this.elementType = elementType;
			this.elementSubType = elementSubType;
		}

		public void SetInstanceable(Instanceable instanceable)
		{
			referenceInstanceable = instanceable;
		}

		public void Initialize(Transform parent, Vector3 localPosition)
		{
			this.parent = parent;
			this.localPosition = localPosition;
			localRotation = Quaternion.identity;
			localScale = Vector3.one * (useScaleMultipler ? scaleMultiplier : 1f);
			isInitialized = true;
		}

		public void Randomize(int seed)
		{
			Seed = seed;
			UnityEngine.Random.InitState(seed);
			VariationAlpha = UnityEngine.Random.value;
			HidingAlpha = UnityEngine.Random.value;
			if (ElementType.instancingInfo.randomizeRotation)
			{
				localRotation = Quaternion.Euler(0f, ElementType.instancingInfo.randomRotationIn60DegreeSteps ? ((float)UnityEngine.Random.Range(0, 6) * 60f) : (UnityEngine.Random.value * 360f), UnityEngine.Random.Range(ElementType.instancingInfo.minMaxTilt.x, ElementType.instancingInfo.minMaxTilt.y));
			}
			randomScaleAlpha.x = UnityEngine.Random.value;
			randomScaleAlpha.y = UnityEngine.Random.value;
			randomScaleAlpha.z = UnityEngine.Random.value;
			for (int i = 0; i < subInstanceables.Count; i++)
			{
				subInstanceables[i].SetParentInstanceableTransform(localPosition, localRotation.eulerAngles);
				subInstanceables[i].Randomize(seed + i * 10000);
			}
			if ((bool)referenceInstanceable)
			{
				RandomizeScale();
			}
			Randomizer.RandomizeSeed();
		}

		private void SetParentInstanceableTransform(Vector3 parentInstanceablePos, Vector3 parentInstanceableRot)
		{
			parentInstanceablePosition = parentInstanceablePos;
			this.parentInstanceableRot = parentInstanceableRot;
		}

		public void ApplyBiomeConfiguration(BiomeObjectConfiguration biomeConfiguration)
		{
			initialBiomeApplied = true;
			biomeEffectValues = new List<BiomeEffectValue>(biomeConfiguration.biomeEffectValues);
			if (ElementType.instancingInfo.updateVisualOnBiomeChanged && !biomeConfiguration.visual)
			{
				Debug.Log($"no visual for {parent} decoration element {RecyclableId}");
				return;
			}
			if (ElementType.instancingInfo.updateVisualOnBiomeChanged && (!referenceInstanceable || RecyclableId != biomeConfiguration.visual.RecyclableId))
			{
				AssignNewReferenceElementVisual(biomeConfiguration.visual);
			}
			if (biomeConfiguration.biomeValues.ContainsKey("displayProbability"))
			{
				float num = (float)biomeConfiguration.biomeValues["displayProbability"];
				IsVisible = num >= HidingAlpha;
				displayProbability = num;
				if (!IsVisible)
				{
					ChangeDisplayState(InstancingDisplayState.Hidden);
					return;
				}
			}
			affectingBiomes = Enumerable.ToList(Enumerable.Select(biomeConfiguration.biomeInfluence, (KeyValuePair<Biome, float> x) => new Debug_BiomeInfluence(x.Key, x.Value)));
			if (referenceInstanceable.instancingEnabled && SettingsRouter.InstancingEnabled && CurrentLayer == 10 && biomeConfiguration.biomeInfluence.Count > 0 && (!ElementType.instancingInfo.softBiomeTransitionsEnabled || biomeConfiguration.biomeInfluence.Count == 1))
			{
				if (ElementType.instancingInfo.softBiomeTransitionsEnabled)
				{
					currentBiome = Enumerable.First(biomeConfiguration.biomeInfluence.Keys);
				}
				else
				{
					UnityEngine.Random.InitState(Seed);
					currentBiome = Randomizer.SelectWeightedRandom(biomeConfiguration.biomeInfluence);
					Randomizer.RandomizeSeed();
				}
				viableForInstancing = true;
				if (currentTileState == TileState.placed && IsVisible)
				{
					ChangeDisplayState(InstancingDisplayState.Instanced);
				}
				else
				{
					ChangeDisplayState(InstancingDisplayState.Regular);
				}
			}
			else
			{
				viableForInstancing = false;
				currentBiome = null;
				ChangeDisplayState(InstancingDisplayState.Regular);
			}
		}

		private void AssignNewReferenceElementVisual(ElementVisual elementVisual)
		{
			referenceElementVisual = elementVisual;
			SetInstanceable(elementVisual.GetComponentInChildren<Instanceable>());
			RandomizeScale();
			if ((bool)spawnedAdditionalGameObject)
			{
				UnityEngine.Object.Destroy(spawnedAdditionalGameObject);
				spawnedAdditionalGameObject = null;
			}
			if ((bool)referenceInstanceable.spawnBasedOnSeed)
			{
				UnityEngine.Random.InitState(Seed);
				if (UnityEngine.Random.value <= referenceInstanceable.spawnBasedOnSeed.Probability)
				{
					Vector3 vector = localPosition + localRotation * referenceInstanceable.spawnBasedOnSeed.RandomLocalPositions[UnityEngine.Random.Range(0, referenceInstanceable.spawnBasedOnSeed.RandomLocalPositions.Length)];
					spawnedAdditionalGameObject = UnityEngine.Object.Instantiate(referenceInstanceable.spawnBasedOnSeed.ObjectToSpawn, parent);
					spawnedAdditionalGameObject.transform.localPosition = vector;
					spawnedAdditionalGameObject.transform.localRotation = Quaternion.Euler(referenceInstanceable.spawnBasedOnSeed.LocalRotation);
					spawnedAdditionalGameObject.layer = CurrentLayer;
				}
				Randomizer.RandomizeSeed();
			}
		}

		private void RandomizeScale()
		{
			Vector3 vector = (referenceInstanceable.useUniformScale ? new Vector3(randomScaleAlpha.x, randomScaleAlpha.x, randomScaleAlpha.x) : randomScaleAlpha);
			if ((bool)elementSubType && elementSubType.hasOverrideInstancingMinMaxScale)
			{
				localScale = new Vector3(Mathf.Lerp(elementSubType.overrideMinScale.x, elementSubType.overrideMaxScale.x, vector.x), Mathf.Lerp(elementSubType.overrideMinScale.y, elementSubType.overrideMaxScale.y, vector.y), Mathf.Lerp(elementSubType.overrideMinScale.z, elementSubType.overrideMaxScale.z, vector.z));
				if (useScaleMultipler)
				{
					localScale *= scaleMultiplier;
				}
			}
			else
			{
				localScale = new Vector3(Mathf.Lerp(referenceInstanceable.minScale.x, referenceInstanceable.maxScale.x, vector.x), Mathf.Lerp(referenceInstanceable.minScale.y, referenceInstanceable.maxScale.y, vector.y), Mathf.Lerp(referenceInstanceable.minScale.z, referenceInstanceable.maxScale.z, vector.z));
				if (useScaleMultipler)
				{
					localScale *= scaleMultiplier;
				}
			}
		}

		public void ChangeDisplayState(InstancingDisplayState targetDisplayState)
		{
			switch (currentDisplayState)
			{
			case InstancingDisplayState.Instanced:
				OverwritingSingleton<InstanceDrawer>.Instance.RemoveInstance(this, instancedType, currentElementGroup, instancedBiome, instanceIndex, highlighted);
				break;
			case InstancingDisplayState.Regular:
				if ((bool)nonInstancedInstanceable)
				{
					MasterObjectPool.Instance.StoreObject(nonInstancedInstanceable);
				}
				nonInstancedInstanceable = null;
				break;
			}
			if (targetDisplayState == InstancingDisplayState.Regular)
			{
				if (!referenceInstanceable || !initialBiomeApplied)
				{
					return;
				}
				nonInstancedInstanceable = MasterObjectPool.Instance.GetObject<Instanceable>(referenceInstanceable.RecyclableId);
				if (!nonInstancedInstanceable)
				{
					Debug.LogError($"couldn't find pool entry for {referenceInstanceable.RecyclableId} - {parent}");
				}
				nonInstancedInstanceable.transform.parent = parent;
				nonInstancedInstanceable.transform.localPosition = LocalPosition;
				nonInstancedInstanceable.transform.localScale = localScale;
				nonInstancedInstanceable.transform.localRotation = LocalRotation;
				nonInstancedRenderer = nonInstancedInstanceable.GetComponent<MeshRenderer>();
				nonInstancedRenderer.sharedMaterial = (viableForInstancing ? ElementType.instancingInfo.instancedMaterial : ElementType.instancingInfo.nonInstancedMaterial);
				ApplyBiomeEffectValues(biomeEffectValues);
				SetCustomTextures(nonInstancedRenderer.material);
				if (viableForInstancing)
				{
					nonInstancedRenderer.material.SetFloat("_BiomeCoordinate", currentBiome.biomeInstancingTextureCoordinate);
					foreach (CustomInstanceInt customInt in CustomInts)
					{
						nonInstancedRenderer.material.SetFloat(customInt.propertyName, customInt.value);
					}
				}
			}
			if (targetDisplayState == InstancingDisplayState.Instanced)
			{
				TransformMatrix = Matrix4x4.TRS(parent.TransformPoint(LocalPosition), parent.rotation * LocalRotation, localScale);
				instancedBiome = currentBiome;
				instanceIndex = OverwritingSingleton<InstanceDrawer>.Instance.AddInstance(this, currentElementGroup, instancedBiome, TransformMatrix, highlighted);
				instancedType = RecyclableId;
			}
			currentDisplayState = targetDisplayState;
			SetLayer(CurrentLayer);
		}

		public void Highlight(bool newHighlight)
		{
			if (!IsVisible)
			{
				return;
			}
			if (currentDisplayState == InstancingDisplayState.Instanced && highlighted != newHighlight)
			{
				OverwritingSingleton<InstanceDrawer>.Instance.RemoveInstance(this, instancedType, currentElementGroup, instancedBiome, instanceIndex, highlighted);
				instanceIndex = OverwritingSingleton<InstanceDrawer>.Instance.AddInstance(this, currentElementGroup, instancedBiome, TransformMatrix, newHighlight);
				highlighted = newHighlight;
			}
			else if (currentDisplayState == InstancingDisplayState.Regular)
			{
				if (nonInstancedRenderer.sharedMaterial.HasProperty(highlightShaderPropertyId))
				{
					nonInstancedRenderer.material.SetFloat(highlightShaderPropertyId, newHighlight ? 0.7f : 0f);
				}
				highlighted = newHighlight;
			}
		}

		public void SetLayer(int layer)
		{
			CurrentLayer = layer;
			if (currentDisplayState == InstancingDisplayState.Regular && (bool)nonInstancedInstanceable)
			{
				nonInstancedInstanceable.gameObject.layer = layer;
			}
			if ((bool)spawnedAdditionalGameObject)
			{
				spawnedAdditionalGameObject.layer = layer;
			}
			foreach (InstanceableVisual subInstanceable in subInstanceables)
			{
				subInstanceable.SetLayer(layer);
			}
		}

		public void ChangeTileState(TileState targetState)
		{
			currentTileState = targetState;
			switch (targetState)
			{
			case TileState.stacked:
				if (ElementType.instancingInfo.hideWhileStacked)
				{
					ChangeDisplayState(InstancingDisplayState.Hidden);
				}
				break;
			case TileState.stackPreview:
			case TileState.topStackPreview:
			case TileState.placementPreview:
				ChangeDisplayState((!IsVisible) ? InstancingDisplayState.Hidden : InstancingDisplayState.Regular);
				break;
			case TileState.placed:
				if (IsVisible && viableForInstancing && (IgnoresPlacementAnimation || !areAnimationsRunning))
				{
					ChangeDisplayState(InstancingDisplayState.Instanced);
				}
				else if (IsVisible)
				{
					ChangeDisplayState(InstancingDisplayState.Regular);
				}
				break;
			}
			foreach (InstanceableVisual subInstanceable in subInstanceables)
			{
				subInstanceable.ChangeTileState(targetState);
			}
		}

		private void SetCustomTextures(Material targetMaterial)
		{
			foreach (CustomInstanceTexture customTexture in CustomTextures)
			{
				targetMaterial.SetTexture(customTexture.propertyName, customTexture.texture);
			}
			if ((bool)currentBiome && Enumerable.Count(currentBiome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == ElementType) > 0)
			{
				CustomInstanceTexture[] textures = Enumerable.First(currentBiome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == ElementType).textures;
				foreach (CustomInstanceTexture customInstanceTexture in textures)
				{
					targetMaterial.SetTexture(customInstanceTexture.propertyName, customInstanceTexture.texture);
				}
			}
		}

		private void ApplyBiomeEffectValues(List<BiomeEffectValue> biomeEffectValuesToApply)
		{
			if (biomeEffectValuesToApply != null)
			{
				foreach (BiomeEffectValue item in biomeEffectValuesToApply)
				{
					if (item.value is Color color)
					{
						ChangeMaterialColor(nonInstancedRenderer, item.key, color);
					}
					else if (item.value is Texture2D newTexture)
					{
						ChangeMaterialTexture(nonInstancedRenderer, item.key, newTexture);
					}
					else if (item.value is float targetFloat)
					{
						ChangeMaterialFloat(nonInstancedRenderer, item.key, targetFloat);
					}
				}
			}
			if ((bool)currentBiome && currentBiome.biomeFloatOptions != null)
			{
				foreach (FloatOption biomeFloatOption in currentBiome.biomeFloatOptions)
				{
					ChangeMaterialFloat(nonInstancedRenderer, biomeFloatOption.propertyName, biomeFloatOption.value);
				}
			}
			if (referenceInstanceable.setSizeSeed)
			{
				ChangeMaterialFloat(nonInstancedRenderer, "_SizeSeed", localScale.x);
			}
		}

		private void ChangeMaterialColor(Renderer targetRenderer, string propertyName, Color color)
		{
			Material[] materials = targetRenderer.materials;
			Material[] array = materials;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetColor(propertyName, color);
			}
			targetRenderer.materials = materials;
		}

		private void ChangeMaterialTexture(Renderer targetRenderer, string propertyName, Texture2D newTexture)
		{
			Material[] materials = targetRenderer.materials;
			Material[] array = materials;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetTexture(propertyName, newTexture);
			}
			targetRenderer.materials = materials;
		}

		private void ChangeMaterialFloat(Renderer targetRenderer, string propertyName, float targetFloat)
		{
			Material[] materials = targetRenderer.materials;
			Material[] array = materials;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].SetFloat(propertyName, targetFloat);
			}
			targetRenderer.materials = materials;
		}

		public void SetAnimationsRunning(bool animationsRunning)
		{
			areAnimationsRunning = animationsRunning;
			if (areAnimationsRunning && currentDisplayState == InstancingDisplayState.Instanced)
			{
				ChangeDisplayState(InstancingDisplayState.Regular);
			}
			else if (!areAnimationsRunning && currentDisplayState == InstancingDisplayState.Regular && viableForInstancing)
			{
				ChangeDisplayState(InstancingDisplayState.Instanced);
			}
			foreach (InstanceableVisual subInstanceable in subInstanceables)
			{
				subInstanceable.SetAnimationsRunning(areAnimationsRunning);
			}
		}

		public void UpdateElementGroup(ElementGroup elementGroup)
		{
			if (currentElementGroup != elementGroup)
			{
				if (currentDisplayState == InstancingDisplayState.Instanced)
				{
					ChangeDisplayState(InstancingDisplayState.Hidden);
					currentElementGroup = elementGroup;
					ChangeDisplayState(InstancingDisplayState.Instanced);
				}
				else
				{
					currentElementGroup = elementGroup;
				}
			}
		}

		public void AddSubElement(Element subElement)
		{
			if (subInstanceables == null)
			{
				subInstanceables = new List<InstanceableVisual>();
			}
			InstanceableVisual instanceableVisual = new InstanceableVisual();
			instanceableVisual.SetElementType(subElement.ElementType);
			instanceableVisual.Initialize(parent, subElement.transform.localPosition);
			subInstanceables.Add(instanceableVisual);
		}

		private bool _003Cget_CustomTextures_003Eb__37_0(CustomElementTypeTextures x)
		{
			return x.elementType == ElementType;
		}

		private bool _003Cget_CustomTextures_003Eb__37_1(CustomElementTypeTextures x)
		{
			return x.elementType == ElementType;
		}

		private bool _003CSetCustomTextures_003Eb__99_0(CustomElementTypeTextures x)
		{
			return x.elementType == ElementType;
		}

		private bool _003CSetCustomTextures_003Eb__99_1(CustomElementTypeTextures x)
		{
			return x.elementType == ElementType;
		}
	}
}
