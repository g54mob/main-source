using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik
{
	public class InstanceDrawer : OverwritingSingleton<InstanceDrawer>
	{
		private sealed class _003C_003Ec__DisplayClass15_0
		{
			public Biome biome;

			public IInstanceable instanceable;

			internal bool _003CAddInstance_003Eb__0(BiomeInstanceOption x)
			{
				return x.biome == biome;
			}

			internal bool _003CAddInstance_003Eb__1(RecyclableInstanceOption x)
			{
				return x.type == instanceable.RecyclableId;
			}
		}

		private sealed class _003C_003Ec__DisplayClass16_0
		{
			public ElementType elementType;

			internal bool _003CAddInstance_003Eb__0(CustomElementTypeTextures x)
			{
				return x.elementType == elementType;
			}

			internal bool _003CAddInstance_003Eb__1(CustomElementTypeTextures x)
			{
				return x.elementType == elementType;
			}
		}

		private sealed class _003C_003Ec__DisplayClass19_0
		{
			public GPUInstanceData instanceData;

			internal bool _003CDrawInstanceCollection_003Eb__0(BiomeInstanceOption x)
			{
				return x.biome == instanceData.biome;
			}

			internal bool _003CDrawInstanceCollection_003Eb__1(BiomeInstanceOption x)
			{
				return x.biome == instanceData.biome;
			}

			internal bool _003CDrawInstanceCollection_003Eb__2(RecyclableInstanceOption x)
			{
				return x.type == instanceData.type;
			}

			internal bool _003CDrawInstanceCollection_003Eb__3(RecyclableInstanceOption x)
			{
				return x.type == instanceData.type;
			}
		}

		public Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>> instanceCollections = new Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>>();

		public Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>> highlightedInstanceCollections = new Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>>();

		public Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>> decorationCollection = new Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>>();

		[SerializeField]
		private bool drawInstances = true;

		[SerializeField]
		private bool drawHighlightedInstances = true;

		[SerializeField]
		private bool debuggingEnabled;

		[SerializeField]
		private List<GPUInstanceData> debug_instanceData = new List<GPUInstanceData>();

		[SerializeField]
		private List<GPUInstanceData> debug_highlightedInstanceData = new List<GPUInstanceData>();

		[SerializeField]
		private List<BiomeInstanceOption> activeBiomes;

		[SerializeField]
		private List<RecyclableInstanceOption> activeRecyclables;

		[SerializeField]
		private SettingsRouter settingsRouter;

		private bool instancesDrawnThisFrame;

		private static readonly int BiomeCoordinateProperty = Shader.PropertyToID("_BiomeCoordinate");

		private static readonly int HighlightProperty = Shader.PropertyToID("_Highlight");

		private static readonly int WindowGlowProperty = Shader.PropertyToID("WindowGlow");

		public Vector2Int AddInstance(IInstanceable instanceable, ElementGroup currentElementGroup, Biome biome, Matrix4x4 transformMatrix, bool isHighlighted = false)
		{
			_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals32 = new _003C_003Ec__DisplayClass15_0();
			CS_0024_003C_003E8__locals32.biome = biome;
			CS_0024_003C_003E8__locals32.instanceable = instanceable;
			Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>> dictionary = (CS_0024_003C_003E8__locals32.instanceable.IsDecoration ? decorationCollection : (isHighlighted ? highlightedInstanceCollections : instanceCollections));
			if (Enumerable.Count(activeBiomes, (BiomeInstanceOption x) => x.biome == CS_0024_003C_003E8__locals32.biome) == 0)
			{
				activeBiomes.Add(new BiomeInstanceOption
				{
					biome = CS_0024_003C_003E8__locals32.biome
				});
			}
			if (Enumerable.Count(activeRecyclables, (RecyclableInstanceOption x) => x.type == CS_0024_003C_003E8__locals32.instanceable.RecyclableId) == 0)
			{
				activeRecyclables.Add(new RecyclableInstanceOption
				{
					type = CS_0024_003C_003E8__locals32.instanceable.RecyclableId
				});
			}
			if (!dictionary.ContainsKey(CS_0024_003C_003E8__locals32.instanceable.RecyclableId))
			{
				dictionary.Add(CS_0024_003C_003E8__locals32.instanceable.RecyclableId, new Dictionary<Biome, GPUInstanceData>());
			}
			if (!dictionary[CS_0024_003C_003E8__locals32.instanceable.RecyclableId].ContainsKey(CS_0024_003C_003E8__locals32.biome))
			{
				GPUInstanceData gPUInstanceData = new GPUInstanceData();
				gPUInstanceData.floatOptions = new List<FloatOption>();
				gPUInstanceData.floatOptions.Add(new FloatOption
				{
					propertyName = "_BiomeCoordinate",
					value = CS_0024_003C_003E8__locals32.biome.biomeInstancingTextureCoordinate
				});
				gPUInstanceData.floatOptions.Add(new FloatOption
				{
					propertyName = "_Highlight",
					value = (isHighlighted ? 0.7f : 0f)
				});
				gPUInstanceData.floatOptions.Add(new FloatOption
				{
					propertyName = "WindowGlow",
					value = CS_0024_003C_003E8__locals32.biome.windowGlow
				});
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetFloat(BiomeCoordinateProperty, CS_0024_003C_003E8__locals32.biome.biomeInstancingTextureCoordinate);
				materialPropertyBlock.SetFloat(HighlightProperty, isHighlighted ? 0.7f : 0f);
				materialPropertyBlock.SetFloat(WindowGlowProperty, CS_0024_003C_003E8__locals32.biome.windowGlow);
				foreach (FloatOption biomeFloatOption in CS_0024_003C_003E8__locals32.biome.biomeFloatOptions)
				{
					materialPropertyBlock.SetFloat(biomeFloatOption.propertyName, biomeFloatOption.value);
					gPUInstanceData.floatOptions.Add(biomeFloatOption);
				}
				foreach (CustomInstanceTexture customTexture in CS_0024_003C_003E8__locals32.instanceable.CustomTextures)
				{
					materialPropertyBlock.SetTexture(customTexture.propertyName, customTexture.texture);
				}
				if (CS_0024_003C_003E8__locals32.instanceable is InstanceableVisual instanceableVisual)
				{
					foreach (CustomInstanceInt customInt in instanceableVisual.CustomInts)
					{
						materialPropertyBlock.SetFloat(customInt.propertyName, customInt.value);
						gPUInstanceData.floatOptions.Add(new FloatOption
						{
							propertyName = customInt.propertyName,
							value = customInt.value
						});
					}
				}
				gPUInstanceData.properties = materialPropertyBlock;
				gPUInstanceData.shadowCastingMode = CS_0024_003C_003E8__locals32.instanceable.MeshRenderer.shadowCastingMode;
				gPUInstanceData.receiveShadows = CS_0024_003C_003E8__locals32.instanceable.MeshRenderer.receiveShadows;
				gPUInstanceData.material = CS_0024_003C_003E8__locals32.instanceable.InstancedMaterial;
				gPUInstanceData.mesh = CS_0024_003C_003E8__locals32.instanceable.Mesh;
				if (CS_0024_003C_003E8__locals32.instanceable.Mesh == null)
				{
					Debug.LogError($"trying to create instanceData, but Mesh of {CS_0024_003C_003E8__locals32.instanceable.RecyclableId} is null!");
				}
				dictionary[CS_0024_003C_003E8__locals32.instanceable.RecyclableId].Add(CS_0024_003C_003E8__locals32.biome, gPUInstanceData);
				gPUInstanceData.SetInfo(CS_0024_003C_003E8__locals32.instanceable.RecyclableId, CS_0024_003C_003E8__locals32.biome, isHighlighted);
				if ((bool)CS_0024_003C_003E8__locals32.instanceable.ReferenceInstanceable)
				{
					gPUInstanceData.SetInfo(CS_0024_003C_003E8__locals32.instanceable.ReferenceInstanceable);
				}
				if (debuggingEnabled)
				{
					if (isHighlighted)
					{
						debug_highlightedInstanceData.Add(gPUInstanceData);
					}
					else
					{
						debug_instanceData.Add(gPUInstanceData);
					}
				}
			}
			return dictionary[CS_0024_003C_003E8__locals32.instanceable.RecyclableId][CS_0024_003C_003E8__locals32.biome].AddTransformMatrix(transformMatrix);
		}

		public Vector2Int AddInstance(RecyclableType recyclableType, Mesh mesh, ElementType elementType, bool isDecoration, Biome biome, Matrix4x4 transformMatrix, List<CustomInstanceTexture> customTextures, MeshRenderer meshRendererReference, bool isHighlighted = false)
		{
			_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals4 = new _003C_003Ec__DisplayClass16_0();
			CS_0024_003C_003E8__locals4.elementType = elementType;
			Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>> dictionary = (isDecoration ? decorationCollection : (isHighlighted ? highlightedInstanceCollections : instanceCollections));
			if (!dictionary.ContainsKey(recyclableType))
			{
				dictionary.Add(recyclableType, new Dictionary<Biome, GPUInstanceData>());
			}
			if (!dictionary[recyclableType].ContainsKey(biome))
			{
				GPUInstanceData gPUInstanceData = new GPUInstanceData();
				MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
				materialPropertyBlock.SetFloat("_BiomeCoordinate", biome.biomeInstancingTextureCoordinate);
				materialPropertyBlock.SetFloat("_Highlight", isHighlighted ? 0.7f : 0f);
				materialPropertyBlock.SetFloat("WindowGlow", biome.windowGlow);
				foreach (FloatOption biomeFloatOption in biome.biomeFloatOptions)
				{
					materialPropertyBlock.SetFloat(biomeFloatOption.propertyName, biomeFloatOption.value);
				}
				foreach (CustomInstanceTexture customTexture in customTextures)
				{
					materialPropertyBlock.SetTexture(customTexture.propertyName, customTexture.texture);
				}
				if (Enumerable.Count(biome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == CS_0024_003C_003E8__locals4.elementType) > 0)
				{
					CustomInstanceTexture[] textures = Enumerable.First(biome.customElementTypeTextures, (CustomElementTypeTextures x) => x.elementType == CS_0024_003C_003E8__locals4.elementType).textures;
					foreach (CustomInstanceTexture customInstanceTexture in textures)
					{
						materialPropertyBlock.SetTexture(customInstanceTexture.propertyName, customInstanceTexture.texture);
					}
				}
				gPUInstanceData.properties = materialPropertyBlock;
				gPUInstanceData.shadowCastingMode = meshRendererReference.shadowCastingMode;
				gPUInstanceData.receiveShadows = meshRendererReference.receiveShadows;
				gPUInstanceData.material = CS_0024_003C_003E8__locals4.elementType.instancingInfo.instancedMaterial;
				gPUInstanceData.mesh = mesh;
				dictionary[recyclableType].Add(biome, gPUInstanceData);
				gPUInstanceData.SetInfo(recyclableType, biome, isHighlighted);
				if (isHighlighted)
				{
					debug_highlightedInstanceData.Add(gPUInstanceData);
				}
				else
				{
					debug_instanceData.Add(gPUInstanceData);
				}
			}
			return dictionary[recyclableType][biome].AddTransformMatrix(transformMatrix);
		}

		public void LateUpdate()
		{
			if (settingsRouter.InstanceDrawerEnabled)
			{
				DrawAllInstances();
				instancesDrawnThisFrame = false;
			}
		}

		public void DrawAllInstances()
		{
			if (drawInstances)
			{
				DrawInstanceCollection(instanceCollections);
			}
			if (drawHighlightedInstances)
			{
				DrawInstanceCollection(highlightedInstanceCollections);
			}
			if (drawInstances && settingsRouter.DecorationEnabled)
			{
				DrawInstanceCollection(decorationCollection);
			}
			instancesDrawnThisFrame = true;
		}

		private void DrawInstanceCollection(Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>> instanceCollection)
		{
			foreach (Dictionary<Biome, GPUInstanceData> value in instanceCollection.Values)
			{
				using Dictionary<Biome, GPUInstanceData>.ValueCollection.Enumerator enumerator2 = value.Values.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals8 = new _003C_003Ec__DisplayClass19_0();
					CS_0024_003C_003E8__locals8.instanceData = enumerator2.Current;
					if (CS_0024_003C_003E8__locals8.instanceData.active && (!debuggingEnabled || (Enumerable.Count(activeBiomes, (BiomeInstanceOption x) => x.biome == CS_0024_003C_003E8__locals8.instanceData.biome) != 0 && Enumerable.First(activeBiomes, (BiomeInstanceOption x) => x.biome == CS_0024_003C_003E8__locals8.instanceData.biome).active && Enumerable.Count(activeRecyclables, (RecyclableInstanceOption x) => x.type == CS_0024_003C_003E8__locals8.instanceData.type) != 0 && Enumerable.First(activeRecyclables, (RecyclableInstanceOption x) => x.type == CS_0024_003C_003E8__locals8.instanceData.type).active)))
					{
						for (int num = 0; num <= CS_0024_003C_003E8__locals8.instanceData.CurrentGroupIndex; num++)
						{
							DrawInstanceGroup(CS_0024_003C_003E8__locals8.instanceData, num);
						}
					}
				}
			}
		}

		private static void DrawInstanceGroup(GPUInstanceData instanceDataCollection, int transformGroupIndex)
		{
			Graphics.DrawMeshInstanced(instanceDataCollection.Mesh, 0, instanceDataCollection.material, instanceDataCollection.transformGroups[transformGroupIndex], (transformGroupIndex == instanceDataCollection.CurrentGroupIndex) ? (instanceDataCollection.CurrentTransformIndex + 1) : 1022, instanceDataCollection.properties, instanceDataCollection.shadowCastingMode, instanceDataCollection.receiveShadows, 10);
		}

		public void AddTestInstance(RecyclableType recyclableType, ElementType elementType, ElementVisual meshReference, Biome biome, Vector3 position, Quaternion rotation, Vector3 scale)
		{
		}

		public void RemoveInstance(ElementVisual elementVisual, Biome instancedBiome, Vector2Int instanceIndex, bool highlightedInstance = false)
		{
			Dictionary<RecyclableType, Dictionary<Biome, GPUInstanceData>> obj = (elementVisual.IsDecoration ? decorationCollection : (highlightedInstance ? highlightedInstanceCollections : instanceCollections));
			RecyclableType recyclableId = ((IRecyclable)elementVisual).RecyclableId;
			obj[recyclableId][instancedBiome].RemoveTransform(instanceIndex);
		}

		public void RemoveInstance(IInstanceable instanceable, RecyclableType instancedType, ElementGroup currentElementGroup, Biome instancedBiome, Vector2Int instanceIndex, bool highlightedInstance = false)
		{
			(instanceable.IsDecoration ? decorationCollection : (highlightedInstance ? highlightedInstanceCollections : instanceCollections))[instancedType][instancedBiome].RemoveTransform(instanceIndex);
		}
	}
}
