using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Weapons;
using VampireSurvivors.UI;

namespace VampireSurvivors.App.Scripts.Objects.Enemies.DLC7;

public class LEMON_BOSS_CrimsonHeart : EnemyControllerBoss
{
	private const string VfxTextureName = "vfx";

	private List<VampireSurvivors.Objects.Characters.CharacterController> players;

	private List<Weapon> disabledWeapons;

	private bool abilityWasDisabled;

	private SpriteRenderer _disableRingSprite;

	private MultiTargetTween _disableRingTween;

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0045: Expected O, but got I4
		//IL_004e: Expected O, but got I4
		//IL_015d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Expected O, but got Unknown
		//IL_014f: Expected O, but got I4
		bool asRemote2 = default(bool);
		base.InitEnemy(enemyType, asRemote2);
		if (base.CanUseAbility())
		{
			GameManager core = GM.Core;
			List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters = core._mainCharacters;
			bool flag = mainCharacters._size <= 0;
			object obj = 0;
			object obj2 = 0;
			if (flag)
			{
				return;
			}
			while (true)
			{
				GameManager core2 = GM.Core;
				List<VampireSurvivors.Objects.Characters.CharacterController> mainCharacters2 = core2._mainCharacters;
				if ((nint)obj2 >= mainCharacters2._size)
				{
					break;
				}
				VampireSurvivors.Objects.Characters.CharacterController[] items = mainCharacters2._items;
				VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj2];
				if (!items[obj2].IsDisconnectedFromOnlinePlay)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B050");
					Weapon weapon = characterController._weaponsManager.SetWeaponActive(active: false);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9BCD0");
					GameEquipmentPanel panelForCharacter = GameEquipmentPanel.GetPanelForCharacter(items[obj2]);
					panelForCharacter.DisableWeaponIcon(weapon, disable: true);
					obj = 0;
				}
				obj2++;
				if ((nint)obj2 < mainCharacters._size)
				{
					continue;
				}
				return;
			}
			System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
			throw new NullReferenceException();
		}
		abilityWasDisabled = true;
	}

	private void InitDisableVFX()
	{
		//IL_00ce->IL0208: Incompatible stack heights: 1 vs 0
		//IL_0113->IL0208: Incompatible stack heights: 1 vs 0
		//IL_0135->IL0208: Incompatible stack heights: 1 vs 0
		//IL_0164->IL0208: Incompatible stack heights: 1 vs 0
		//IL_01c8->IL0208: Incompatible stack heights: 1 vs 0
		//IL_01f4->IL0208: Incompatible stack heights: 1 vs 0
		//IL_02c7->IL0242: Incompatible stack heights: 2 vs 0
		SpriteRenderer disableRingSprite = _disableRingSprite;
		if ((object)_disableRingSprite != null && ((UnityEngine.Object)disableRingSprite).m_CachedPtr != (IntPtr)0)
		{
			return;
		}
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			GameObject gameObject = base.gameObject;
			Vector2 pos = default(Vector2);
			SpriteRenderer component = RenderingExtensions.AddSprite(gameObject, pos, "vfx", "sPFX_ring_64");
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(component, 0f);
			Material material = MaterialManager.GetMaterial(MaterialType.Vfx);
			if ((object)spriteRenderer != null)
			{
				((Renderer)spriteRenderer).SetMaterial(material);
				_disableRingSprite = spriteRenderer;
				GameManager gameManager = _gameManager;
				if ((object)_gameManager != null && gameManager._playerOptions != null)
				{
					PlayerOptionsData config = gameManager._playerOptions.Config;
					if (config != null)
					{
						if (!config._003CFlashingVFXEnabled_003Ek__BackingField)
						{
							SpriteRenderer spriteRenderer2 = RenderingExtensions.SetAlpha(_disableRingSprite, 0f);
						}
						if ((object)_disableRingSprite != null)
						{
							Transform transform = _disableRingSprite.transform;
							if ((object)transform != null)
							{
								bool flag2 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Transform.SetParent_Injected(((UnityEngine.Object)transform).m_CachedPtr, (IntPtr)0, true);
								return;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	private void PlayDisableVFX()
	{
		//IL_0070: Expected I, but got O
		//IL_00e2: Expected O, but got I4
		if (_disableRingTween != null)
		{
			_disableRingTween.Kill();
		}
		TweenConfig tweenConfig = new TweenConfig();
		object[] array = new object[1];
		Transform transform = _disableRingSprite.transform;
		if ((object)transform != null)
		{
			nint num = (nint)array;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
			object obj = default(object);
			if (obj == null)
			{
				ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
				throw ex;
			}
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		tweenConfig.targets = array;
		tweenConfig.duration = 500f;
		tweenConfig.repeat = 2;
		tweenConfig.scale = (float?)(object)1;
		TweenCallback onStart = delegate
		{
			SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_disableRingSprite, 0f);
			if ((object)_disableRingSprite != null)
			{
				Transform transform2 = _disableRingSprite.transform;
				SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
				if ((object)_cachedTransform != null)
				{
					bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
					bool flag2 = (object)transform2 == null;
					bool flag3 = ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0;
					Vector3 value = default(Vector3);
					Transform.set_position_Injected(((UnityEngine.Object)transform2).m_CachedPtr, ref value);
					bool flag4 = (object)_disableRingSprite == null;
					_disableRingSprite.enabled = true;
					return;
				}
			}
			throw new NullReferenceException();
		};
		tweenConfig.onStart = onStart;
		TweenCallback onComplete = delegate
		{
			_disableRingSprite.enabled = false;
		};
		tweenConfig.onComplete = onComplete;
		MultiTargetTween disableRingTween = Tweens.Add(tweenConfig);
		_disableRingTween = disableRingTween;
	}

	public override void Despawn()
	{
		//IL_0034: Expected O, but got I4
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0130: Expected O, but got Unknown
		base.Despawn();
		if (abilityWasDisabled)
		{
			return;
		}
		List<VampireSurvivors.Objects.Characters.CharacterController> list = players;
		bool flag = list._size <= 0;
		object obj = 0;
		if (!flag)
		{
			Weapon effectedWeapon = default(Weapon);
			Weapon weapon2 = default(Weapon);
			do
			{
				List<VampireSurvivors.Objects.Characters.CharacterController> list2 = players;
				if ((nint)obj < list2._size)
				{
					VampireSurvivors.Objects.Characters.CharacterController[] items = list2._items;
					VampireSurvivors.Objects.Characters.CharacterController characterController = items[obj];
					if (!items[obj].IsDisconnectedFromOnlinePlay)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						Weapon weapon = characterController._weaponsManager.SetWeaponActive(active: true, effectedWeapon);
						GameEquipmentPanel panelForCharacter = GameEquipmentPanel.GetPanelForCharacter(items[obj]);
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
						panelForCharacter.DisableWeaponIcon(weapon2, disable: false);
					}
					obj++;
					continue;
				}
				System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
				return;
			}
			while ((nint)obj < list._size);
		}
		if (_disableRingTween != null)
		{
			_disableRingTween.Kill();
		}
	}

	public LEMON_BOSS_CrimsonHeart()
	{
		List<VampireSurvivors.Objects.Characters.CharacterController> list = new List<VampireSurvivors.Objects.Characters.CharacterController>();
		players = list;
		disabledWeapons = new List<Weapon>();
		base._002Ector();
	}

	private void _003CPlayDisableVFX_003Eb__8_0()
	{
		SpriteRenderer spriteRenderer = RenderingExtensions.SetScale(_disableRingSprite, 0f);
		if ((object)_disableRingSprite != null)
		{
			Transform transform = _disableRingSprite.transform;
			SpriteRenderer cachedTransform = (SpriteRenderer)(object)_cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
				bool flag2 = (object)transform == null;
				bool flag3 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Vector3 value = default(Vector3);
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
				bool flag4 = (object)_disableRingSprite == null;
				_disableRingSprite.enabled = true;
				return;
			}
		}
		throw new NullReferenceException();
	}

	private void _003CPlayDisableVFX_003Eb__8_1()
	{
		_disableRingSprite.enabled = false;
	}
}
