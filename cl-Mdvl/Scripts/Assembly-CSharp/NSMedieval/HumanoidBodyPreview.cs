using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Heraldry;
using NSMedieval.Manager;
using NSMedieval.Model;
using NSMedieval.Repository;
using NSMedieval.State;
using NSMedieval.Types;
using NSMedieval.UI.Utils;
using NSMedieval.Utils;
using NSMedieval.Views.Resources;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace NSMedieval
{
	public abstract class HumanoidBodyPreview : MonoBehaviour
	{
		[SerializeField]
		private MaterialMeshParameters materialMeshParameters;

		[SerializeField]
		private Animator anim;

		[SerializeField]
		private Material bodyMaterial;

		[SerializeField]
		private Transform rightHandSocket;

		[SerializeField]
		private Transform leftHandSocket;

		[SerializeField]
		private List<Transform> bodyParts;

		[SerializeField]
		private Transform headSocket;

		[SerializeField]
		private Transform neckPosition;

		[SerializeField]
		private Transform backPosition;

		[SerializeField]
		private List<BoneTransformPair> additionalBones = new List<BoneTransformPair>();

		private Dictionary<EquipmentSlotType, List<GameObject>> additionalEqupiments = new Dictionary<EquipmentSlotType, List<GameObject>>
		{
			{
				EquipmentSlotType.BodyArmor,
				new List<GameObject>()
			},
			{
				EquipmentSlotType.Head,
				new List<GameObject>()
			},
			{
				EquipmentSlotType.LeftHand,
				new List<GameObject>()
			},
			{
				EquipmentSlotType.RightHand,
				new List<GameObject>()
			}
		};

		private List<GameObject> equpiedSkinnedMeshHead = new List<GameObject>();

		[SerializeField]
		private Transform carryBodySocket;

		private readonly Transform[] weaponTransform = new Transform[2];

		private readonly Equipment[] weaponBlueprint = new Equipment[2];

		private bool isWeaponsVisible;

		private HumanAppearance appearance;

		private Material replacementMaterial;

		[SerializeField]
		private Transform lute;

		[SerializeField]
		private Transform book;

		[SerializeField]
		private Transform thurifer;

		[SerializeField]
		private Transform drum;

		[SerializeField]
		private Transform mallet;

		[SerializeField]
		private Transform whip;

		[SerializeField]
		private Transform sword;

		[SerializeField]
		private Transform bow;

		public Transform CarryBodySocket => carryBodySocket;

		public Transform RightHandSocket => rightHandSocket;

		public Transform LeftHandSocket => leftHandSocket;

		public Transform HeadSocket => headSocket;

		public List<Transform> BodyParts => bodyParts;

		public Transform NeckPosition => neckPosition;

		public bool IsWeaponVisible => isWeaponsVisible;

		protected string AppearanceId { get; set; }

		[field: NonSerialized]
		public HumanoidInstance HumanoidInstance { get; protected set; }

		protected HumanAppearance Appearance
		{
			get
			{
				if (appearance == null)
				{
					appearance = Repository<HumanAppearanceRepository, HumanAppearance>.Instance.GetByID(AppearanceId);
				}
				return appearance;
			}
		}

		public event Action<Transform> OnItemEquippedEvent;

		public abstract CharacterInfoBase GetInfo();

		public abstract void Setup(CreatureBase humanoidInstance);

		public abstract FactionInstance GetFaction();

		public void ShowEntity()
		{
			ShowBody();
			ReplaceBodyTextures(ResourceUtils.GetDefaultClothesAddress(GetInfo().BodyType));
			if (headSocket.childCount > 0)
			{
				UnityEngine.Object.Destroy(headSocket.GetChild(0).gameObject);
				for (int i = 0; i < bodyParts.Count; i++)
				{
					bodyParts[i].gameObject.SetActive(value: true);
				}
			}
			if (GetInventory()?.GetEquipments() == null)
			{
				return;
			}
			foreach (EquipmentInstance equipment in GetInventory().GetEquipments())
			{
				EquipItem(equipment.Blueprint);
			}
		}

		public void SetSkinColor(string color)
		{
			GetInfo().PhysicalLook.BodyColors[GetInfo().PhysicalLook.ShaderParameters[0]] = color;
		}

		public void SetHairColor(string color)
		{
			GetInfo().PhysicalLook.BodyColors[GetInfo().PhysicalLook.ShaderParameters[1]] = color;
		}

		public void RandomizeAppearance(System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			WorkerPhysicalLook workerPhysicalLook = new WorkerPhysicalLook();
			workerPhysicalLook.Initialize();
			GetInfo().SetPhysicalLook(workerPhysicalLook);
			string hairColor = string.Empty;
			string skinColor = string.Empty;
			if (Appearance != null)
			{
				if (Appearance.HairColor != null && Appearance.HairColor.Count > 0)
				{
					hairColor = Appearance.HairColor.PickRandom(rnd);
				}
				if (Appearance.SkinColor != null && Appearance.SkinColor.Count > 0)
				{
					skinColor = Appearance.SkinColor.PickRandom(rnd);
				}
			}
			SetHairColor(hairColor);
			SetSkinColor(skinColor);
			foreach (Transform bodyPart in BodyParts)
			{
				SetRandomBodyPart(bodyPart, Appearance, rnd);
			}
		}

		private void ApplyBodyColors(MaterialPropertyBlock propertyBlock)
		{
			foreach (KeyValuePair<string, string> bodyColor in GetInfo().PhysicalLook.BodyColors)
			{
				propertyBlock.SetColor(bodyColor.Key, GetColor(bodyColor.Value));
			}
		}

		public void ShowBody()
		{
			Renderer component = base.gameObject.GetComponent<Renderer>();
			component.material = bodyMaterial;
			MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(component);
			ApplyBodyColors(materialPropertyBlock);
			component.SetPropertyBlock(materialPropertyBlock);
			foreach (Transform bodyPart in bodyParts)
			{
				for (int i = 0; i < bodyPart.childCount; i++)
				{
					Transform child = bodyPart.GetChild(i);
					child.gameObject.SetActive(GetInfo().PhysicalLook.WorkerBody.Contains(child.name));
					Renderer component2 = child.gameObject.GetComponent<Renderer>();
					if (child.gameObject.activeInHierarchy && !(component2 == null))
					{
						MaterialPropertyBlock materialPropertyBlock2 = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(component2);
						ApplyBodyColors(materialPropertyBlock2);
						component2.SetPropertyBlock(materialPropertyBlock2);
					}
				}
			}
		}

		public void DropItem(Equipment item)
		{
			if (item == null)
			{
				return;
			}
			if ((item.EquipmentSlots & (EquipmentSlotType.RightHand | EquipmentSlotType.LeftHand)) != EquipmentSlotType.None)
			{
				DestroyWeaponObjects(item.EquipmentSlots);
				DeleteAdditionalEquipment(item.EquipmentSlots);
			}
			else
			{
				if ((item.EquipmentSlots & (EquipmentSlotType.Head | EquipmentSlotType.Body | EquipmentSlotType.BodyArmor)) == 0)
				{
					return;
				}
				if ((item.EquipmentSlots & EquipmentSlotType.Head) != EquipmentSlotType.None)
				{
					List<Transform> list = new List<Transform>();
					for (int i = 0; i < headSocket.childCount; i++)
					{
						list.Add(headSocket.GetChild(i));
					}
					foreach (Transform item2 in list)
					{
						if (item2 != null)
						{
							UnityEngine.Object.Destroy(item2.gameObject);
						}
					}
					for (int j = 0; j < bodyParts.Count; j++)
					{
						bodyParts[j].gameObject.SetActive(value: true);
					}
					SetHeadMask();
					DeleteAdditionalEquipment(EquipmentSlotType.Head);
					if (equpiedSkinnedMeshHead.Count <= 0)
					{
						return;
					}
					foreach (GameObject item3 in equpiedSkinnedMeshHead)
					{
						UnityEngine.Object.Destroy(item3);
					}
					equpiedSkinnedMeshHead.Clear();
					return;
				}
				string text = ResourceUtils.GetDefaultClothesAddress(GetInfo().BodyType);
				string text2 = ((GetInventory()?.GetItem(EquipmentSlotType.Body) == null) ? text : (GetInventory()?.GetItem(EquipmentSlotType.Body).Blueprint?.Resource?.GetEquippedTexturePath(GetInfo().BodyType) ?? text));
				string materialId = "default_humanoid";
				if ((item.EquipmentSlots & EquipmentSlotType.BodyArmor) != EquipmentSlotType.None)
				{
					EquipmentInstance equipmentInstance = GetInventory()?.GetItem(EquipmentSlotType.Body);
					if (equipmentInstance != null)
					{
						materialId = equipmentInstance.Blueprint?.Resource?.Material;
						text = text2;
					}
					DeleteAdditionalEquipment(EquipmentSlotType.BodyArmor);
				}
				if ((item.EquipmentSlots & EquipmentSlotType.Body) == 0 || GetInventory().GetItem(EquipmentSlotType.BodyArmor) == null)
				{
					ReplaceBodyTextures(text);
					materialMeshParameters.UpdateParameters(materialId);
				}
			}
		}

		public void EquipItem(Equipment item)
		{
			if (!(item == null))
			{
				if ((item.EquipmentSlots & (EquipmentSlotType.RightHand | EquipmentSlotType.LeftHand)) != EquipmentSlotType.None)
				{
					GenerateWeaponObject(item);
					AdditionalEquipment(item, item.EquipmentSlots);
					anim.RebindKeepState();
				}
				else if ((item.EquipmentSlots & EquipmentSlotType.BodyArmor) != EquipmentSlotType.None || ((item.EquipmentSlots & EquipmentSlotType.Body) != EquipmentSlotType.None && GetInventory()?.GetItem(EquipmentSlotType.BodyArmor) == null))
				{
					materialMeshParameters.UpdateParameters(item.Resource.Material);
					ReplaceBodyTextures(item.Resource.GetEquippedTexturePath(GetInfo().BodyType));
					AdditionalEquipment(item, EquipmentSlotType.BodyArmor);
				}
				else if ((item.EquipmentSlots & EquipmentSlotType.Head) != EquipmentSlotType.None)
				{
					UpdateHeadLook(item, shouldShow: true);
					AdditionalEquipment(item, EquipmentSlotType.Head);
				}
			}
		}

		public Transform GetEquipmentTransform(EquipmentSlotType slots)
		{
			if (slots == (EquipmentSlotType.RightHand | EquipmentSlotType.LeftHand))
			{
				Transform transform = leftHandSocket.FindChildWithTag("HumanoidEquipment");
				if (transform != null)
				{
					return transform;
				}
				transform = rightHandSocket.FindChildWithTag("HumanoidEquipment");
				if (transform != null)
				{
					return transform;
				}
			}
			if ((slots & EquipmentSlotType.LeftHand) != EquipmentSlotType.None)
			{
				return leftHandSocket.FindChildWithTag("HumanoidEquipment") ?? leftHandSocket;
			}
			if ((slots & EquipmentSlotType.RightHand) != EquipmentSlotType.None)
			{
				return rightHandSocket.FindChildWithTag("HumanoidEquipment") ?? rightHandSocket;
			}
			if ((slots & EquipmentSlotType.Head) != EquipmentSlotType.None)
			{
				return headSocket.FindChildWithTag("HumanoidEquipment") ?? headSocket;
			}
			return base.transform;
		}

		public void ReplaceBodyTextures(string texturePath)
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
			ReplaceTexture(base.transform, array, reflection);
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

		public void AdditionalEquipment(Equipment item, EquipmentSlotType slot)
		{
			slot = CheckForTwoHandedWeapon(slot);
			if (item.AdditionalPrefabs == null || item.AdditionalPrefabs.Count <= 0 || additionalBones.Count <= 0)
			{
				return;
			}
			Renderer renderer = null;
			if ((item.EquipmentSlots & (EquipmentSlotType.RightHand | EquipmentSlotType.LeftHand)) != EquipmentSlotType.None)
			{
				renderer = GetWeaponRenderer(item);
			}
			else if ((item.EquipmentSlots & (EquipmentSlotType.Body | EquipmentSlotType.BodyArmor)) != EquipmentSlotType.None)
			{
				renderer = base.gameObject.GetComponent<Renderer>();
			}
			foreach (BoneEquipmentPair additionalPrefab in item.AdditionalPrefabs)
			{
				BoneType key = additionalPrefab.Key;
				string value = additionalPrefab.Value;
				if (!(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(value) != null))
				{
					continue;
				}
				GameObject gameObject = UnityEngine.Object.Instantiate(MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(value), additionalBones[(int)key].boneTransform);
				gameObject.name = "_ime_" + value;
				if (renderer != null)
				{
					Renderer component = gameObject.transform.gameObject.GetComponent<Renderer>();
					if (component != null && gameObject.transform.gameObject.activeSelf)
					{
						component.material.CopyPropertiesFromMaterial(renderer.sharedMaterial);
						MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(renderer);
						component.SetPropertyBlock(materialPropertyBlock);
					}
				}
				additionalEqupiments[slot].Add(gameObject);
			}
		}

		private Renderer GetWeaponRenderer(Equipment item)
		{
			int num = ((item.CarryHand != EquipmentSlotType.RightHand) ? 1 : 0);
			return weaponTransform[num].gameObject.GetComponentInChildren<Renderer>();
		}

		protected virtual void OnDestroy()
		{
			if (replacementMaterial != null)
			{
				UnityEngine.Object.DestroyImmediate(replacementMaterial);
			}
		}

		private void DeleteAdditionalEquipment(EquipmentSlotType slot)
		{
			slot = CheckForTwoHandedWeapon(slot);
			foreach (GameObject item in additionalEqupiments[slot])
			{
				UnityEngine.Object.Destroy(item);
			}
			additionalEqupiments[slot].Clear();
			additionalEqupiments[slot].TrimExcess();
		}

		private static EquipmentSlotType CheckForTwoHandedWeapon(EquipmentSlotType slot)
		{
			if ((slot & (EquipmentSlotType.RightHand | EquipmentSlotType.LeftHand)) != EquipmentSlotType.None)
			{
				slot = EquipmentSlotType.RightHand;
			}
			return slot;
		}

		public void UpdateHeadLook(Equipment item, bool shouldShow)
		{
			if (!shouldShow)
			{
				return;
			}
			string iD = item.GetID();
			if (headSocket.childCount > 0)
			{
				for (int num = headSocket.childCount - 1; num >= 0; num--)
				{
					UnityEngine.Object.Destroy(headSocket.GetChild(num).gameObject);
				}
			}
			GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(item.Resource.EquippedPrefabID);
			if (byAddress == null)
			{
				Log.Error("No prefab found for " + item.GetID(), "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HumanoidBodyPreview.cs");
				return;
			}
			byAddress.name = item.Resource.GetID();
			GameObject gameObject = UnityEngine.Object.Instantiate(byAddress);
			EquipmentView component = gameObject.GetComponent<EquipmentView>();
			if (component != null)
			{
				component.Setup(item.Resource);
			}
			if (gameObject.GetComponent<SkinnedMeshAdding>() != null)
			{
				SkinnedMeshAdding component2 = gameObject.GetComponent<SkinnedMeshAdding>();
				Transform parent = (component2.newArmature = GetComponent<SkinnedMeshRenderer>().rootBone);
				gameObject.transform.SetParent(parent);
				ResetTransforms(gameObject);
				component2.Rebind();
				equpiedSkinnedMeshHead.Add(gameObject);
			}
			else
			{
				gameObject.transform.SetParent(headSocket);
				ResetTransforms(gameObject);
			}
			int layer = headSocket.gameObject.layer;
			SetLayerRecursively(gameObject, layer);
			bodyParts[0].gameObject.SetActive(!Repository<EquipmentRepository, Equipment>.Instance.GetByID(iD).HideHair);
			ShowHideFacialHair(iD);
			this.OnItemEquippedEvent?.Invoke(gameObject.transform);
			SetHeadMask(iD);
			if (Repository<EquipmentRepository, Equipment>.Instance.GetByID(iD).HideHead)
			{
				foreach (Transform bodyPart in bodyParts)
				{
					bodyPart.gameObject.SetActive(value: false);
				}
				return;
			}
			bodyParts[1].gameObject.SetActive(value: true);
		}

		private void SetLayerRecursively(GameObject obj, int newLayer)
		{
			obj.layer = newLayer;
			foreach (Transform item in obj.transform)
			{
				SetLayerRecursively(item.gameObject, newLayer);
			}
		}

		private void SetHeadMask(string itemId = "")
		{
			foreach (Transform item in bodyParts[1])
			{
				if (item.gameObject.activeSelf)
				{
					SkinnedMeshRenderer component = item.gameObject.GetComponent<SkinnedMeshRenderer>();
					MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(component);
					materialPropertyBlock.SetFloat("_HeadMaskAmount", (itemId == string.Empty) ? 0f : Repository<EquipmentRepository, Equipment>.Instance.GetByID(itemId).HeadMaskAmount);
					component.SetPropertyBlock(materialPropertyBlock);
				}
			}
		}

		private void ShowHideFacialHair(string itemId)
		{
			if (bodyParts.Count > 2 && ((bool)bodyParts[2].gameObject || (bool)bodyParts[3].gameObject))
			{
				bool active = !Repository<EquipmentRepository, Equipment>.Instance.GetByID(itemId).HideFacialHair;
				bodyParts[2].gameObject.SetActive(active);
				bodyParts[3].gameObject.SetActive(active);
			}
		}

		private void ResetTransforms(GameObject helm)
		{
			helm.transform.localPosition = Vector3.zero;
			helm.transform.localRotation = Quaternion.identity;
			helm.transform.localScale = Vector3.one;
		}

		public virtual void ShowWeapons()
		{
			if (weaponTransform[0] != null)
			{
				weaponTransform[0].gameObject.SetActive(value: true);
			}
			if (weaponTransform[1] != null)
			{
				weaponTransform[1].gameObject.SetActive(value: true);
			}
			isWeaponsVisible = true;
		}

		public virtual void HideWeapons()
		{
			if (weaponTransform[0] != null)
			{
				weaponTransform[0].gameObject.SetActive(value: false);
			}
			if (weaponTransform[1] != null)
			{
				weaponTransform[1].gameObject.SetActive(value: false);
			}
			isWeaponsVisible = false;
		}

		public void SetShieldOnBack(bool putOnBack)
		{
			if (!isWeaponsVisible)
			{
				return;
			}
			Equipment equipment = null;
			int num = -1;
			for (int i = 0; i < weaponBlueprint.Length; i++)
			{
				Equipment equipment2 = weaponBlueprint[i];
				if (!(equipment2 == null) && equipment2.ArmorType == ArmorType.Shield)
				{
					equipment = equipment2;
					num = i;
				}
			}
			if (!(equipment == null))
			{
				Transform transform = weaponTransform[num];
				transform.parent = null;
				if (putOnBack)
				{
					transform.parent = backPosition;
				}
				else
				{
					transform.parent = GetHandSocket(equipment);
				}
				transform.localRotation = Quaternion.identity;
				transform.localPosition = Vector3.zero;
			}
		}

		public Transform GetWeaponTransform(int hand)
		{
			return weaponTransform[hand];
		}

		protected void SetRandomBodyPart(Transform part, HumanAppearance appearance, System.Random rnd = null)
		{
			if (rnd == null)
			{
				rnd = new System.Random();
			}
			List<string> allowedParts = GetAllowedParts(part, appearance);
			GetInfo().PhysicalLook.WorkerBody.Add(allowedParts.PickRandom(rnd));
		}

		protected virtual void Awake()
		{
			if (backPosition == null)
			{
				Log.Warning("Back position bone not found. Using neck instead", "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HumanoidBodyPreview.cs");
				backPosition = neckPosition;
			}
		}

		public List<string> GetAllowedParts(Transform part, HumanAppearance appearance)
		{
			string groupName = part.name;
			List<string> list = new List<string>();
			for (int i = 0; i < part.childCount; i++)
			{
				string text = part.GetChild(i).name;
				if (appearance == null || appearance.IsBodyPartAllowed(text, groupName))
				{
					list.Add(text);
				}
			}
			return list;
		}

		public List<string> GetPossibleParts()
		{
			List<string> list = new List<string>();
			foreach (Transform bodyPart in BodyParts)
			{
				list.AddRange(GetAllowedParts(bodyPart, Appearance));
			}
			return list;
		}

		protected abstract InventoryInstance GetInventory();

		protected virtual void GenerateWeaponObject(Equipment item, FactionInstance factionInstance = null)
		{
			int handIndex = GetHandIndex(item);
			bool active = true;
			if (weaponTransform[handIndex] != null)
			{
				active = weaponTransform[handIndex].gameObject.activeSelf;
				DestroyWeaponObjects(item.CarryHand);
			}
			weaponBlueprint[handIndex] = item;
			GameObject byAddress = MonoRepository<PrefabRepository, KeyGameObjectPair>.Instance.GetByAddress(item.Resource.EquippedPrefabID);
			if (byAddress == null)
			{
				Log.Error("No prefab found for " + item.GetID(), "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HumanoidBodyPreview.cs");
				return;
			}
			float num = GetInfo().Height / Repository<GenerationSettingsRepository, GenerationSettings>.Instance.Settings.DefaultHeight[(int)GetInfo().BodyType];
			Transform handSocket = GetHandSocket(item);
			GameObject gameObject = UnityEngine.Object.Instantiate(byAddress, handSocket);
			gameObject.name = item.Resource.EquippedPrefabID ?? "";
			gameObject.transform.localScale = new Vector3(num, num, num);
			gameObject.gameObject.layer = handSocket.gameObject.layer;
			weaponTransform[handIndex] = gameObject.transform;
			EquipmentView component = gameObject.GetComponent<EquipmentView>();
			if (component != null)
			{
				component.Setup(item.Resource);
			}
			SetHeraldryMaterialOnEquipment(gameObject, factionInstance);
			gameObject.SetActive(active);
			this.OnItemEquippedEvent?.Invoke(gameObject.transform);
		}

		private int GetHandIndex(Equipment item)
		{
			if (item.CarryHand != EquipmentSlotType.RightHand)
			{
				return 1;
			}
			return 0;
		}

		private Transform GetHandSocket(Equipment item)
		{
			if (item.CarryHand != EquipmentSlotType.RightHand)
			{
				return leftHandSocket;
			}
			return rightHandSocket;
		}

		private void SetHeraldryMaterialOnEquipment(GameObject weaponInstance, FactionInstance factionInstance)
		{
			MeshRenderer[] componentsInChildren = weaponInstance.GetComponentsInChildren<MeshRenderer>();
			MonoSingleton<HeraldryManager>.Instance.TrySetHeraldry(componentsInChildren, factionInstance);
		}

		private void DestroyWeaponObjects(EquipmentSlotType slot)
		{
			if (slot.HasFlag(EquipmentSlotType.RightHand | EquipmentSlotType.LeftHand))
			{
				for (int i = 0; i < weaponTransform.Length; i++)
				{
					RemoveFromSlot(i);
				}
			}
			else
			{
				int slotIndex = ((!slot.HasFlag(EquipmentSlotType.RightHand)) ? 1 : 0);
				RemoveFromSlot(slotIndex);
			}
			void RemoveFromSlot(int num)
			{
				if (weaponTransform[num] != null)
				{
					bool isEnabled;
					FVLogDebugInterpolationHandler messageBuilder = new FVLogDebugInterpolationHandler(8, 1, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\MainMenu\\HumanoidBodyPreview.cs");
					if (isEnabled)
					{
						messageBuilder.AppendLiteral("Destroy ");
						messageBuilder.AppendFormatted(weaponTransform[num].gameObject.name);
					}
					Log.Debug(messageBuilder);
					UnityEngine.Object.Destroy(weaponTransform[num].gameObject);
					weaponBlueprint[num] = null;
					weaponTransform[num] = null;
				}
			}
		}

		private void ReplaceTexture(Transform part, Texture[] textures, float reflection)
		{
			Renderer component = part.gameObject.GetComponent<Renderer>();
			if (!(component != null) || !part.gameObject.activeSelf)
			{
				return;
			}
			MaterialPropertyBlock materialPropertyBlock = MonoSingleton<MaterialPropertyBlockManager>.Instance.GetMaterialPropertyBlock(component);
			MonoSingleton<HeraldryManager>.Instance.SetHeraldryOnBlock(materialPropertyBlock, GetFaction());
			materialPropertyBlock.SetFloat("_Reflection", reflection);
			for (int i = 0; i < GetInfo().PhysicalLook.ShaderTextureParameters.Count; i++)
			{
				if (textures[i] != null)
				{
					materialPropertyBlock.SetTexture(GetInfo().PhysicalLook.ShaderTextureParameters[i], textures[i]);
				}
				else
				{
					materialPropertyBlock.SetTexture(GetInfo().PhysicalLook.ShaderTextureParameters[i], RuntimeUtilities.whiteTexture);
				}
			}
			component.SetPropertyBlock(materialPropertyBlock);
		}

		protected void GetRandomStyle(Transform part)
		{
			GetInfo().PhysicalLook.WorkerBody.Add(part.GetChild(UnityEngine.Random.Range(0, part.childCount)).name);
		}

		private string GetRandomColor(List<string> colors)
		{
			return colors[UnityEngine.Random.Range(0, colors.Count)];
		}

		private Color GetColor(string stringColor)
		{
			ColorUtility.TryParseHtmlString(stringColor, out var color);
			return color;
		}

		public void SetLuteEnabled(bool enabled)
		{
			if (!(lute == null))
			{
				lute.gameObject.SetActive(enabled);
			}
		}

		public void SetPriestPropsEnabled(bool enabled)
		{
			if (!(book == null))
			{
				book.gameObject.SetActive(enabled);
				thurifer.gameObject.SetActive(enabled);
			}
		}

		public void SetLibrarianPropsEnabled(bool enabled)
		{
			if (!(book == null))
			{
				book.gameObject.SetActive(enabled);
			}
		}

		public void SetDrumsEnabled(bool enabled)
		{
			if (!(drum == null) && !(mallet == null))
			{
				drum.gameObject.SetActive(enabled);
				mallet.gameObject.SetActive(enabled);
			}
		}

		public void SetWardenPropsEnabled(bool enabled)
		{
			if (!(whip == null))
			{
				whip.gameObject.SetActive(enabled);
			}
		}

		public void SetMeleePropEnabled(bool enabled)
		{
			if (!(sword == null))
			{
				sword.gameObject.SetActive(enabled);
			}
		}

		public void SetRangedPropEnabled(bool enabled)
		{
			if (!(bow == null))
			{
				bow.gameObject.SetActive(enabled);
			}
		}
	}
}
