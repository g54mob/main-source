using System;
using System.Collections.Generic;
using DG.Tweening;
using Restory.Utils;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace Restory.Gameplay.Equipment
{
	public class ShineEffectApplier : MonoBehaviour, IInitializable, IDisposable
	{
		[SerializeField]
		private string shinePropertyName = "_Shine";

		[SerializeField]
		private string positionShinePropertyName = "_Position_Shine";

		[SerializeField]
		private float initialShinePosition;

		[SerializeField]
		private float targetShinePosition = 1.5f;

		[SerializeField]
		private float effectDuration = 1f;

		[SerializeField]
		private List<EffectMaterialMapping> effectMaterialMappings = new List<EffectMaterialMapping>();

		private readonly Stack<List<Material>> sourceMaterialsPool = new Stack<List<Material>>();

		private readonly Dictionary<Renderer, List<Material>> rendererSourceMaterialsCache = new Dictionary<Renderer, List<Material>>();

		private readonly Dictionary<string, Material> appliedShineMaterialsCache = new Dictionary<string, Material>();

		private readonly Dictionary<string, Material> shineMaterials = new Dictionary<string, Material>();

		private readonly HashSet<Shader> effectShaders = new HashSet<Shader>();

		private TweenSequencesService tweenSequences;

		private int shinePropertyId;

		private int positionShinePropertyId;

		private Sequence effectSequence;

		public bool IsActive => effectSequence?.active ?? false;

		[Inject]
		private void Construct(TweenSequencesService tweenSequences)
		{
			this.tweenSequences = tweenSequences;
		}

		public void Initialize()
		{
			foreach (EffectMaterialMapping effectMaterialMapping in effectMaterialMappings)
			{
				if (!effectMaterialMapping.defaultMaterial || !effectMaterialMapping.effectMaterial)
				{
					Debug.LogError("effectMaterialMappings has empty entries");
					continue;
				}
				effectShaders.Add(effectMaterialMapping.effectMaterial.shader);
				if (!shineMaterials.TryAdd(effectMaterialMapping.defaultMaterial.name, effectMaterialMapping.effectMaterial))
				{
					Debug.LogError("shineMaterials has " + effectMaterialMapping.defaultMaterial.name + " already");
				}
			}
			shinePropertyId = Shader.PropertyToID(shinePropertyName);
			positionShinePropertyId = Shader.PropertyToID(positionShinePropertyName);
		}

		public void Dispose()
		{
			if (effectSequence != null)
			{
				tweenSequences.Kill(effectSequence);
				effectSequence = null;
			}
		}

		public void Apply(Renderer renderer)
		{
			if (effectSequence != null)
			{
				tweenSequences.Kill(effectSequence);
				effectSequence = null;
				RestoreSourceMaterials();
			}
			else
			{
				ClearShineEffectCache();
			}
			CacheEffectInstanceMaterials(renderer);
			PlayShineEffect();
		}

		public void Apply(IEnumerable<Renderer> renderers)
		{
			if (effectSequence != null)
			{
				tweenSequences.Kill(effectSequence);
				effectSequence = null;
				RestoreSourceMaterials();
			}
			else
			{
				ClearShineEffectCache();
			}
			foreach (Renderer renderer in renderers)
			{
				CacheEffectInstanceMaterials(renderer);
			}
			PlayShineEffect();
		}

		private void CacheEffectInstanceMaterials(Renderer renderer)
		{
			List<Material> value;
			using (CollectionPool<List<Material>, Material>.Get(out value))
			{
				List<Material> list = ((sourceMaterialsPool.Count > 0) ? sourceMaterialsPool.Pop() : new List<Material>());
				renderer.GetSharedMaterials(list);
				foreach (Material item in list)
				{
					string key = item.name.Replace(" (Instance)", "");
					Material value3;
					if (appliedShineMaterialsCache.TryGetValue(key, out var value2))
					{
						value.Add(value2);
					}
					else if (shineMaterials.TryGetValue(key, out value3))
					{
						Material material = UnityEngine.Object.Instantiate(value3);
						value.Add(material);
						appliedShineMaterialsCache.Add(key, material);
					}
					else if (effectShaders.Contains(item.shader))
					{
						Material material2 = UnityEngine.Object.Instantiate(item);
						value.Add(material2);
						appliedShineMaterialsCache.Add(key, material2);
					}
					else
					{
						value.Add(item);
					}
				}
				renderer.SetSharedMaterials(value);
				rendererSourceMaterialsCache[renderer] = list;
			}
		}

		private void PlayShineEffect()
		{
			if (effectSequence != null)
			{
				tweenSequences.Kill(effectSequence);
				effectSequence = null;
			}
			if (appliedShineMaterialsCache.Count == 0)
			{
				RestoreSourceMaterials();
				return;
			}
			foreach (Material value in appliedShineMaterialsCache.Values)
			{
				value.SetFloat(positionShinePropertyId, initialShinePosition);
				value.SetInt(shinePropertyId, 1);
			}
			effectSequence = tweenSequences.Create();
			foreach (Material value2 in appliedShineMaterialsCache.Values)
			{
				effectSequence.Join(value2.DOFloat(targetShinePosition, positionShinePropertyId, effectDuration));
			}
			effectSequence.SetEase(Ease.InQuad).OnComplete(RestoreSourceMaterials);
		}

		private void RestoreSourceMaterials()
		{
			foreach (KeyValuePair<Renderer, List<Material>> item in rendererSourceMaterialsCache)
			{
				item.Key.SetSharedMaterials(item.Value);
			}
			ClearShineEffectCache();
		}

		private void ClearShineEffectCache()
		{
			foreach (List<Material> value in rendererSourceMaterialsCache.Values)
			{
				value.Clear();
				sourceMaterialsPool.Push(value);
			}
			rendererSourceMaterialsCache.Clear();
			ClearAppliedShineMaterials();
		}

		private void ClearAppliedShineMaterials()
		{
			foreach (Material value in appliedShineMaterialsCache.Values)
			{
				if ((bool)value)
				{
					UnityEngine.Object.Destroy(value);
				}
			}
			appliedShineMaterialsCache.Clear();
		}
	}
}
