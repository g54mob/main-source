using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Tools;

namespace VampireSurvivors.Objects.Weapons;

public class ActiveAccessory : Accessory
{
	protected WeaponType HiddenWeaponTypeToAdd;

	protected Weapon HiddenWeaponLinked;

	protected bool _hasPet;

	protected string _petSprite;

	protected string _petAnimPrefix;

	protected int _petAnimFrameCount;

	protected float _petOffset;

	protected int _framesPerSecond;

	protected override void MakeLevelOne()
	{
		base.MakeLevelOne();
		GM.Core.SetSeenWeapon(((Equipment)this)._equipmentType);
		GameManager core = GM.Core;
		bool allowDuplicates = default(bool);
		Weapon hiddenWeaponLinked = core._weaponsFacade.AddHiddenWeapon(HiddenWeaponTypeToAdd, ((Equipment)this)._003COwner_003Ek__BackingField, removeFromStore: true, allowDuplicates);
		HiddenWeaponLinked = hiddenWeaponLinked;
		Weapon hiddenWeaponLinked2 = HiddenWeaponLinked;
		((Equipment)hiddenWeaponLinked2)._003CShowInRecap_003Ek__BackingField = false;
		if (_hasPet)
		{
			MakePetFollower();
		}
		AfterWeaponAdded();
	}

	public virtual void AfterWeaponAdded()
	{
	}

	public override bool LevelUp(bool skipFire = false)
	{
		//IL_0050: Expected I4, but got O
		if ((object)HiddenWeaponLinked != null)
		{
			bool flag = HiddenWeaponLinked.LevelUp();
			return base.LevelUp(false);
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override void Cleanup()
	{
		GameManager core = GM.Core;
		core._weaponsFacade.RemoveThisHiddenWeapon(HiddenWeaponLinked, ((Equipment)this)._003COwner_003Ek__BackingField);
	}

	private void MakePetFollower()
	{
		//IL_0237: Expected F4, but got I4
		GameObject gameObject = new GameObject();
		GameObject.Internal_CreateGameObject(gameObject, (string)null);
		if ((object)gameObject != null)
		{
			((UnityEngine.Object)gameObject).SetName("ActiveAccessoryPet");
			SpriteRenderer spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
			Sprite sprite = SpriteManager.GetSprite(_petSprite, "vfx");
			if ((object)spriteRenderer != null)
			{
				spriteRenderer.sprite = sprite;
				Camera main = Camera.main;
				Bounds bounds = CameraExtensions.OrthographicBounds(main);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v393 @ rax_v27 (UnityEngine.Bounds)+10]");
				float num = 0f * 2f;
				float num2 = num + num;
				float num3 = num2 * 100f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182CE69B0");
				int sortingOrder = default(int);
				spriteRenderer.sortingOrder = sortingOrder;
				SpriteAnimation spriteAnimation = gameObject.AddComponent<SpriteAnimation>();
				bool flag = default(bool);
				List<Sprite> animation = SpriteManager.GetAnimation(_petAnimPrefix, 0, _petAnimFrameCount, "vfx", flag);
				if ((object)spriteAnimation != null)
				{
					bool startRandomFrame = default(bool);
					Action onComplete = default(Action);
					bool autoSetAnimation = default(bool);
					spriteAnimation.AddAnimation("idle", animation, _framesPerSecond, flag, startRandomFrame, onComplete, autoSetAnimation);
					Transform transform = gameObject.transform;
					if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
					{
						Transform transform2 = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
						if ((object)transform2 != null)
						{
							bool flag2 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
							Transform.get_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, out Vector3 _);
							bool flag3 = (object)transform == null;
							bool flag4 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
							Vector3 value = default(Vector3);
							Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
							bool flag5 = (object)((Equipment)this)._003COwner_003Ek__BackingField == null;
							PetManager petManager = ((Equipment)this)._003COwner_003Ek__BackingField.PetManager;
							bool flag6 = (object)petManager == null;
							PetInstance petInstance = petManager.AddPet(this, HiddenWeaponLinked, spriteRenderer, flag ? 1 : 0);
							return;
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public ActiveAccessory()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A5030]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		HiddenWeaponTypeToAdd = WeaponType.LIGHTNING;
		_petSprite = "ProjectileBird2";
		_petAnimPrefix = "ProjectileBird";
		_petAnimFrameCount = 1;
		_petOffset = 0.24f;
		_framesPerSecond = 6;
		base._002Ector();
	}
}
