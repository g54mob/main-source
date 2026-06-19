#define PUG_ACHIEVEMENTS
using Unity.Entities;
using UnityEngine;

public class PetBase : EntityMonoBehaviour
{
	public ObjectNameTag nameTag;

	private IPetOwner _owner;

	private int _prevLevel;

	private int _inventoryAuxDataIndex;

	private int _currentSkin = -1;

	private bool _triggeredPetProdigyAchievement;

	private int prevVariation;

	protected override bool updateAnimOrientation => true;

	protected override bool updateAnimMovement => true;

	protected override bool updateAnimMovementSpeed => true;

	public int GetAuxDataIndex()
	{
		return _inventoryAuxDataIndex;
	}

	protected override float GetAnimSpeed()
	{
		return 1f;
	}

	public override void OnOccupied()
	{
		base.OnOccupied();
		_owner = null;
		_prevLevel = 0;
		_inventoryAuxDataIndex = 0;
		_currentSkin = -1;
		prevVariation = -1;
		_triggeredPetProdigyAchievement = false;
		if (EntityUtility.HasComponentData<OwnerReferenceCD>(base.entity, base.world))
		{
			Entity owner = EntityUtility.GetComponentData<OwnerReferenceCD>(base.entity, base.world).owner;
			EntityMonoBehaviour entityMono = Manager.memory.GetEntityMono(owner);
			if (entityMono is IPetOwner petOwner)
			{
				_owner = petOwner;
				petOwner.activePet = this;
				_inventoryAuxDataIndex = petOwner.GetPetAuxDataIndex();
				int petXp = petOwner.GetPetXp();
				_prevLevel = PetExtensions.GetLevelFromXP(petXp);
			}
			else
			{
				Debug.LogWarning($"{entityMono} does not implement IPetOwner but is set as owner of a pet. This pet will not function correctly.");
			}
		}
		nameTag.gameObject.SetActive(value: true);
	}

	protected override void OnHide()
	{
		base.OnHide();
		nameTag.gameObject.SetActive(value: false);
	}

	public override void ManagedLateUpdate()
	{
		base.ManagedLateUpdate();
		UpdateLevel();
		UpdateName();
		UpdateSkin();
	}

	private void UpdateLevel()
	{
		if (_owner != null && _owner.activePet == this && _inventoryAuxDataIndex == _owner.GetPetAuxDataIndex())
		{
			int levelFromXP = PetExtensions.GetLevelFromXP(_owner.GetPetXp());
			if (_prevLevel < levelFromXP)
			{
				Manager.ui.chatWindow.AddInfoText(new string[1] { levelFromXP.ToString() }, ChatWindow.MessageTextType.PetLeveledUp);
				Manager.effects.PlayPuff(PuffID.GainTalentEffect, base.RenderPosition + new Vector3(0f, 0.5f, 0f));
				AudioManager.Sfx(SfxID.successTone, base.RenderPosition, 0.25f, 1f, 0.1f);
				_prevLevel = levelFromXP;
			}
			if (!_triggeredPetProdigyAchievement && levelFromXP >= PetExtensions.maxLevel)
			{
				Manager.achievements.TriggerAchievement(AchievementID.PetMaxLevel);
				_triggeredPetProdigyAchievement = true;
			}
		}
	}

	private void UpdateName()
	{
		if ((_owner != null && _owner.ShouldHidePetName()) || EntityUtility.IsComponentEnabled<EntityDestroyedCD>(base.entity, Manager.ecs.ClientWorld) || !Manager.prefs.showCharacterNames)
		{
			nameTag.gameObject.SetActive(value: false);
			return;
		}
		string text = GetName();
		if (text != null)
		{
			nameTag.gameObject.SetActive(value: true);
			nameTag.text.Render(text);
		}
		else
		{
			nameTag.gameObject.SetActive(value: false);
		}
	}

	public string GetName()
	{
		if (InventoryHandler.TryGetExtraInventoryData<NameCD>(_inventoryAuxDataIndex, out var data))
		{
			return data.Value.ToString();
		}
		return null;
	}

	private void UpdateSkin()
	{
		if (EntityUtility.HasComponentData<PetCD>(base.entity, base.world) && InventoryHandler.TryGetExtraInventoryData<PetSkinCD>(EntityUtility.GetComponentData<PetCD>(base.entity, base.world).inventoryAuxDataIndex, out var data))
		{
			PetInfosTable.PetSkinInfo petSkinInfo = Manager.ui.petInfosTable.GetPetSkinInfo(base.objectData.objectID);
			if (petSkinInfo != null && petSkinInfo.skins.Count > data.skinIndex && spriteObjects.Count > 0 && data.skinIndex != _currentSkin)
			{
				spriteObjects[0].primaryGradientMapRef = petSkinInfo.skins[data.skinIndex].primaryGradientMap;
				spriteObjects[0].ApplyVisualChange();
				_currentSkin = data.skinIndex;
			}
		}
	}

	public override void OnFree()
	{
		base.OnFree();
		if (_owner != null && _owner.activePet == this)
		{
			_owner.activePet = null;
		}
		_owner = null;
	}
}
