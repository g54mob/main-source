using System.Collections;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NSMedieval.UI
{
	public class HumanoidIconManager : MonoSingleton<HumanoidIconManager>
	{
		public delegate void HumanoidImageUpdated(HumanoidInstance humanoid);

		private const int IconWidth = 128;

		private const int IconHeight = 128;

		[SerializeField]
		private GameObject content;

		[SerializeField]
		private MeshRenderer iconBackgroundPlane;

		private Dictionary<int, Sprite> spriteCache;

		private Dictionary<int, HumanoidBodyPreview> idToView;

		private Dictionary<int, string> idToClothesId;

		private Coroutine contentHider;

		private RenderTexture renderTexture;

		public event HumanoidImageUpdated HumanoidImageUpdatedEvent;

		public Sprite GetCachedIcon(HumanoidInstance humanoidInstance)
		{
			if (!spriteCache.ContainsKey(humanoidInstance.UniqueId))
			{
				GenerateAndCacheIcon(humanoidInstance);
			}
			return spriteCache[humanoidInstance.UniqueId];
		}

		public Sprite GenerateAndCacheIcon(HumanoidInstance humanoidInstance)
		{
			if (!idToView.ContainsKey(humanoidInstance.UniqueId))
			{
				CreateViewClone(humanoidInstance);
			}
			return GenerateIconInternal(humanoidInstance);
		}

		public Sprite GenerateIcon(HumanoidInstance humanoidInstance)
		{
			if (!idToView.ContainsKey(humanoidInstance.UniqueId))
			{
				CreateViewClone(humanoidInstance);
			}
			return GenerateIconInternal(humanoidInstance, cache: false);
		}

		public void OnHumanoidRemoved(HumanoidInstance humanoid)
		{
			Remove(humanoid.UniqueId);
		}

		public void OnHumanoidScaleChanged(HumanoidInstance humanoid)
		{
			HumanoidBodyPreview humanoidBodyPreview = idToView[humanoid.UniqueId];
			if (!(humanoidBodyPreview == null))
			{
				CharacterInfoBase characterInfo = humanoid.GetCharacterInfo();
				float num = characterInfo.Height / Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.DefaultHeight[(int)characterInfo.BodyType];
				humanoidBodyPreview.transform.parent.parent.localScale = new Vector3(num, num, num);
				humanoidBodyPreview.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, characterInfo.GetBlendShapeWeight());
			}
		}

		public void OnItemEquipped(HumanoidInstance humanoid, EquipmentInstance item)
		{
			GetBodyPreview(humanoid).EquipItem(item.Blueprint);
		}

		public void OnItemDropped(HumanoidInstance humanoid, EquipmentInstance item)
		{
			GetBodyPreview(humanoid).DropItem(item.Blueprint);
		}

		public void Clear()
		{
			foreach (int key in idToView.Keys)
			{
				if (idToView[key] != null)
				{
					Object.Destroy(idToView[key].transform.parent.parent.gameObject);
				}
			}
			idToView.Clear();
			idToClothesId.Clear();
			spriteCache.Clear();
		}

		public void Remove(int id)
		{
			if (idToView.ContainsKey(id))
			{
				Object.Destroy(idToView[id].transform.parent.parent.gameObject);
				idToView.Remove(id);
				idToClothesId.Remove(id);
				spriteCache.Remove(id);
			}
		}

		public void ShowHumanoid(int humanoidId)
		{
			foreach (var (num2, humanoidBodyPreview2) in idToView)
			{
				if (humanoidBodyPreview2 == null)
				{
					continue;
				}
				GameObject gameObject = humanoidBodyPreview2.transform.parent.parent.gameObject;
				if (num2 == humanoidId)
				{
					humanoidBodyPreview2.ShowEntity();
					if (idToClothesId.TryGetValue(num2, out var value) && value != null)
					{
						Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(value);
						humanoidBodyPreview2.EquipItem(byID);
					}
					gameObject.SetActive(value: true);
				}
				else if (gameObject.activeSelf)
				{
					gameObject.SetActive(value: false);
				}
			}
		}

		protected override void Awake()
		{
			base.Awake();
			spriteCache = new Dictionary<int, Sprite>();
			idToView = new Dictionary<int, HumanoidBodyPreview>();
			idToClothesId = new Dictionary<int, string>();
		}

		private HumanoidBodyPreview GetBodyPreview(HumanoidInstance humanoid)
		{
			if (!idToView.ContainsKey(humanoid.UniqueId))
			{
				CreateViewClone(humanoid);
			}
			return idToView[humanoid.UniqueId];
		}

		private void Start()
		{
			renderTexture = new RenderTexture(128, 128, 16);
			MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent += OnLeavingScene;
			MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent += OnLeavingScene;
		}

		private Sprite GenerateIconInternal(HumanoidInstance humanoidInstance, bool cache = true)
		{
			int uniqueId = humanoidInstance.UniqueId;
			content.SetActive(value: true);
			if (contentHider != null)
			{
				StopCoroutine(contentHider);
			}
			contentHider = StartCoroutine(DeactivateContent());
			ShowHumanoid(uniqueId);
			Sprite obj = ((humanoidInstance.WorkerBehaviour == null) ? humanoidInstance.GetHeraldryBackground() : null);
			iconBackgroundPlane.material.SetTexture("_HeraldryBackground", obj?.texture);
			Sprite sprite = null;
			if (cache)
			{
				sprite = spriteCache.GetValueOrDefault(uniqueId);
			}
			if (sprite == null)
			{
				sprite = Sprite.Create(new Texture2D(128, 128), new Rect(0f, 0f, 128f, 128f), new Vector2(0f, 0f));
				if (cache)
				{
					spriteCache[uniqueId] = sprite;
				}
			}
			MonoSingleton<ScreenshotHandler>.Instance.CreateScreenshot(idToView[uniqueId], sprite.texture, renderTexture, 128, 128);
			this.HumanoidImageUpdatedEvent?.Invoke(humanoidInstance);
			return sprite;
		}

		private void CreateViewClone(HumanoidInstance humanoid)
		{
			idToClothesId[humanoid.UniqueId] = humanoid.WorkerBehaviour?.EquipItemOnSpawn;
			if (idToView.TryGetValue(humanoid.UniqueId, out var value))
			{
				Object.Destroy(value.transform.parent.parent.gameObject);
				idToView.Remove(humanoid.UniqueId);
			}
			CharacterInfoBase characterInfo = humanoid.GetCharacterInfo();
			value = Object.Instantiate(MonoRepository<HumanoidImageRepository, KeyGameObjectPair>.Instance.GetPrefab(characterInfo.GetPhysicalLookKey()), base.gameObject.transform.position, Quaternion.Euler(new Vector3(0f, 180f, 0f)), base.transform).GetComponentInChildren<HumanoidBodyPreview>();
			idToView[humanoid.UniqueId] = value;
			float num = characterInfo.Height / Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.DefaultHeight[(int)characterInfo.BodyType];
			value.transform.parent.parent.localScale = new Vector3(num, num, num);
			value.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(0, characterInfo.GetBlendShapeWeight());
			value.Setup(humanoid);
		}

		private void OnLeavingScene()
		{
			Clear();
		}

		private IEnumerator DeactivateContent()
		{
			yield return new WaitForSeconds(0.1f);
			content.SetActive(SceneManager.GetActiveScene().name == "HomeScene");
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (renderTexture != null)
			{
				renderTexture.Release();
				Object.DestroyImmediate(renderTexture);
				renderTexture = null;
			}
			if (spriteCache != null)
			{
				foreach (Sprite value in spriteCache.Values)
				{
					Object.DestroyImmediate(value.texture);
					Object.DestroyImmediate(value);
				}
				spriteCache.Clear();
				spriteCache = null;
			}
			if (MonoSingleton<LoadingController>.IsInstantiated())
			{
				MonoSingleton<LoadingController>.Instance.MainSceneLeavingEvent -= OnLeavingScene;
				MonoSingleton<LoadingController>.Instance.HomeSceneLeavingEvent -= OnLeavingScene;
			}
		}
	}
}
