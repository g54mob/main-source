using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Heraldry;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI;
using NSMedieval.UI.Utils;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace NSMedieval.Views.Resources
{
	public class HumanCarcassPileView : ResourcePileView
	{
		[SerializeField]
		private List<Transform> bodyParts;

		[SerializeField]
		private GameObject rootGameObject;

		[SerializeField]
		protected Transform meshPrefabParent;

		[SerializeField]
		private Transform bodyMeshTransform;

		[SerializeField]
		private Material defaultSkinnedMaterial;

		[SerializeField]
		protected MaterialMeshParameters materialMeshParameters;

		[SerializeField]
		private ApplyMeshFilterSkinnedMeshRenderer applyMeshFilterSkinnedMeshRenderer;

		[SerializeField]
		private List<BoneTransformPair> additionalBones = new List<BoneTransformPair>();

		[NonSerialized]
		private List<GameObject> additionalArmorEquipments = new List<GameObject>();

		[NonSerialized]
		private CreatureBase creatureInstance;

		private SkinnedMeshRenderer skinnedMeshRenderer;

		public HumanCarcassPileInstance HumanCarcassPileInstance => base.ResourcePileInstance as HumanCarcassPileInstance;

		public override void Setup(ResourcePileInstance pile)
		{
			HumanCarcassPileInstance humanCarcassPileInstance = (HumanCarcassPileInstance)pile;
			creatureInstance = humanCarcassPileInstance.BodyOwner;
			SetupSkinnedMesh();
			base.Setup(pile);
			humanCarcassPileInstance.InventorySavedEvent += OnInventorySaved;
			humanCarcassPileInstance.InventoryClearedEvent += OnInventoryCleared;
			SetupCarcassAppearance();
		}

		private void OnInventorySaved(HumanCarcassPileInstance humanCarcassPileInstance)
		{
			SetupCarcassAppearance();
		}

		private void OnInventoryCleared()
		{
			if (creatureInstance.GetInfo() is CharacterInfoBase characterInfoBase)
			{
				materialMeshParameters.UpdateParameters("default_humanoid");
				string defaultClothesAddress = ResourceUtils.GetDefaultClothesAddress(characterInfoBase.BodyType);
				ReplaceBodyTextures(defaultClothesAddress);
			}
		}

		public override void Dispose()
		{
			if (HumanCarcassPileInstance != null)
			{
				HumanCarcassPileInstance.InventorySavedEvent -= OnInventorySaved;
				HumanCarcassPileInstance.InventoryClearedEvent -= OnInventoryCleared;
			}
			base.Dispose();
			creatureInstance = null;
		}

		public override void OnLeavingMainScene()
		{
			base.OnLeavingMainScene();
			creatureInstance = null;
		}

		public override CreatureBase GetAsCreature()
		{
			return creatureInstance;
		}

		private void SetupSkinnedMesh()
		{
			string objectAddress = ((creatureInstance.GetInfo().BodyType == BodyType.Male) ? "male_carcass_pile" : "female_carcass_pile");
			GameObject byAddress = MonoRepository<MeshRepository, KeyGameObjectPair>.Instance.GetByAddress(objectAddress);
			if (byAddress == null)
			{
				return;
			}
			GameObject gameObject = UnityEngine.Object.Instantiate(byAddress, meshPrefabParent);
			gameObject.gameObject.name = objectAddress;
			GetComponent<RandomiseMapProps>()?.AssignProp(gameObject.gameObject);
			bodyParts = new List<Transform>();
			foreach (Transform item in gameObject.transform)
			{
				item.gameObject.SetActive(value: true);
				SkinnedMeshRenderer component = item.gameObject.GetComponent<SkinnedMeshRenderer>();
				if ((bool)component)
				{
					bodyMeshTransform = item;
					GetComponent<ApplyMeshFilterSkinnedMeshRenderer>()?.ApplySkinnedMeshRenderer(component);
					continue;
				}
				bodyParts.Add(item);
				foreach (Transform item2 in item)
				{
					MeshRenderer component2 = item2.GetComponent<MeshRenderer>();
					if (!(component2 == null))
					{
						component2.material = defaultSkinnedMaterial;
					}
				}
			}
			skinnedMeshRenderer = gameObject.GetComponentInChildren<SkinnedMeshRenderer>();
			skinnedMeshRenderer.material = defaultSkinnedMaterial;
			meshVariationHandler.AssignMeshes(skinnedMeshRenderer.sharedMesh);
			materialMeshParameters.AddMesh(skinnedMeshRenderer);
			applyMeshFilterSkinnedMeshRenderer.ApplySkinnedMeshRenderer(skinnedMeshRenderer);
			base.HideResource.SetSkinnedMeshRenderer(skinnedMeshRenderer);
		}

		public override InfoPanelData GetInfoPanelData()
		{
			InfoPanelHeader headerData = GetHeaderData();
			InfoPanelBody body = new InfoPanelBody("human_carcass_pile", headerData.ObjectName, string.Empty, GetInfoStats(), GetModifiers(), GetResourcesInfo(), GetDescriptions(), GetInfos(), HumanCarcassPileInstance.Inventory, GetLifeEventLog(), DecayModifierUtils.GetDecayModifiers(base.ResourcePileInstance));
			InfoPanelFooter footer = new InfoPanelFooter(GetInfoPanelActions());
			return new InfoPanelData(InfoPanelDataType.General, headerData, body, footer);
		}

		protected override List<InfoPanelAction> GetInfoPanelActions()
		{
			List<InfoPanelAction> infoPanelActions = base.GetInfoPanelActions();
			if (HumanCarcassPileInstance.Stripped)
			{
				return infoPanelActions;
			}
			int currentIndex = (HumanCarcassPileInstance.MarkedForStripping ? 1 : 0);
			KeyValuePair<SelectionInputActionData, Action>[] objectActions = new KeyValuePair<SelectionInputActionData, Action>[2]
			{
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("StripCarcass"), delegate
				{
					StripCarcass(stripCarcass: true);
				}),
				new KeyValuePair<SelectionInputActionData, Action>(Repository<ObjectActionDataRepository, SelectionInputActionData>.Instance.GetByID("Cancel"), delegate
				{
					StripCarcass(stripCarcass: false);
				})
			};
			infoPanelActions.Add(new InfoPanelAction(objectActions, currentIndex));
			return infoPanelActions;
		}

		private void StripCarcass(bool stripCarcass)
		{
			if (HumanCarcassPileInstance != null && !HumanCarcassPileInstance.HasDisposed)
			{
				HumanCarcassPileInstance.MarkForStripping(stripCarcass);
			}
		}

		protected override void PickPile()
		{
			if ((bool)base.HideResource)
			{
				base.HideResource.RemoveFromCache();
			}
			UnityEngine.Object.Destroy(rootGameObject);
		}

		private void SetupCarcassAppearance()
		{
			CharacterInfoBase characterInfoBase = creatureInstance.GetInfo() as CharacterInfoBase;
			float num = 1f;
			if (characterInfoBase != null)
			{
				num = characterInfoBase.Height / Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.DefaultHeight[(int)characterInfoBase.BodyType];
			}
			meshPrefabParent.transform.localScale = new Vector3(num, num, num);
			if (creatureInstance is HumanoidInstance { WorkerBehaviour: not null } humanoidInstance)
			{
				skinnedMeshRenderer.SetBlendShapeWeight(0, humanoidInstance.Info.GetBlendShapeWeight());
			}
			ShowBody();
		}

		private void ApplyBodyColors(MaterialPropertyBlock propertyBlock)
		{
			if (!(creatureInstance.GetInfo() is CharacterInfoBase characterInfoBase))
			{
				return;
			}
			foreach (KeyValuePair<string, string> bodyColor in characterInfoBase.PhysicalLook.BodyColors)
			{
				propertyBlock.SetColor(bodyColor.Key, GetColor(bodyColor.Value));
			}
		}

		private void ShowBody()
		{
			if (!(creatureInstance.GetInfo() is CharacterInfoBase characterInfoBase))
			{
				return;
			}
			List<MeshRenderer> list = new List<MeshRenderer>();
			if (skinnedMeshRenderer != null)
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(skinnedMeshRenderer);
				ApplyBodyColors(materialPropertyBlock);
				skinnedMeshRenderer.SetPropertyBlock(materialPropertyBlock);
			}
			foreach (Transform bodyPart in bodyParts)
			{
				for (int i = 0; i < bodyPart.childCount; i++)
				{
					Transform child = bodyPart.GetChild(i);
					child.gameObject.SetActive(characterInfoBase.PhysicalLook.WorkerBody.Contains(child.name));
					if (child.gameObject.activeInHierarchy && characterInfoBase.PhysicalLook.WorkerBody.Contains(child.name))
					{
						MeshRenderer component = child.gameObject.GetComponent<MeshRenderer>();
						if (component != null)
						{
							list.Add(component);
							MaterialPropertyBlock materialPropertyBlock2 = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(component);
							ApplyBodyColors(materialPropertyBlock2);
							component.SetPropertyBlock(materialPropertyBlock2);
						}
					}
				}
			}
			Equipment equipmentClothes = GetEquipmentClothes();
			if (equipmentClothes != null)
			{
				materialMeshParameters.UpdateParameters(equipmentClothes.Resource.Material);
				ReplaceBodyTextures(equipmentClothes.Resource.GetEquippedTexturePath(characterInfoBase.BodyType));
			}
			else
			{
				materialMeshParameters.UpdateParameters("default_humanoid");
				string defaultClothesAddress = ResourceUtils.GetDefaultClothesAddress(characterInfoBase.BodyType);
				ReplaceBodyTextures(defaultClothesAddress);
			}
			Equipment equipmentArmor = GetEquipmentArmor();
			if (equipmentArmor != null)
			{
				materialMeshParameters.UpdateParameters(equipmentArmor.Resource.Material);
				ReplaceBodyTextures(equipmentArmor.Resource.GetEquippedTexturePath(characterInfoBase.BodyType));
			}
			base.HideResource.SetupMeshes(list);
		}

		private Equipment GetEquipmentClothes()
		{
			foreach (ResourcePileInstance item in HumanCarcassPileInstance.Inventory)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(item.BlueprintId);
				if (!(byID == null) && byID.EquipmentSlots.HasFlag(EquipmentSlotType.Body))
				{
					return byID;
				}
			}
			return null;
		}

		private Equipment GetEquipmentArmor()
		{
			foreach (ResourcePileInstance item in HumanCarcassPileInstance.Inventory)
			{
				Equipment byID = Repository<EquipmentRepository, Equipment>.Instance.GetByID(item.BlueprintId);
				if (!(byID == null) && byID.EquipmentSlots.HasFlag(EquipmentSlotType.BodyArmor))
				{
					return byID;
				}
			}
			return null;
		}

		private void ReplaceBodyTextures(string texturePath)
		{
			Texture[] array = new Texture[2];
			if (AssetUtils.GetTexture(texturePath, out var texture))
			{
				array[0] = texture;
			}
			if (AssetUtils.GetTexture(texturePath + "_specular", out var texture2))
			{
				array[1] = texture2;
			}
			float reflection = ((array[1] == null) ? 0f : 0.4f);
			ReplaceTexture(bodyMeshTransform, array, reflection);
			foreach (Transform bodyPart in bodyParts)
			{
				for (int i = 0; i < bodyPart.childCount; i++)
				{
					Transform child = bodyPart.GetChild(i);
					if (child.gameObject.activeSelf)
					{
						ReplaceTexture(child, array, reflection);
					}
				}
			}
		}

		private void ReplaceTexture(Transform part, Texture[] textures, float reflection)
		{
			if (part == null || !(creatureInstance.GetInfo() is CharacterInfoBase characterInfoBase) || !(creatureInstance is HumanoidInstance humanoidInstance))
			{
				return;
			}
			Renderer component = part.gameObject.GetComponent<Renderer>();
			if (!(component == null) && part.gameObject.activeSelf)
			{
				MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(component);
				MonoSingleton<HeraldryManager>.Instance.SetHeraldryOnBlock(materialPropertyBlock, humanoidInstance.Faction);
				materialPropertyBlock.SetFloat("_Reflection", reflection);
				for (int i = 0; i < characterInfoBase.PhysicalLook.ShaderTextureParameters.Count; i++)
				{
					materialPropertyBlock.SetTexture(characterInfoBase.PhysicalLook.ShaderTextureParameters[i], (textures[i] != null) ? textures[i] : RuntimeUtilities.whiteTexture);
				}
				component.SetPropertyBlock(materialPropertyBlock);
			}
		}

		private Texture GetTexture(string itemId, BodyType bodyType)
		{
			return AssetUtils.GetTexture(bodyType.ToString().ToLower() + "_" + itemId);
		}

		private Color GetColor(string stringColor)
		{
			ColorUtility.TryParseHtmlString(stringColor, out var color);
			return color;
		}
	}
}
