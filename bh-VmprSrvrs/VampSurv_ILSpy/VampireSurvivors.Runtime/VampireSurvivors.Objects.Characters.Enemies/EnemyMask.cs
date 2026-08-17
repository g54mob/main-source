using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;
using VampireSurvivors.App.Tools;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Enemies;
using VampireSurvivors.Framework;
using VampireSurvivors.Graphics;
using VampireSurvivors.Objects.Pickups;

namespace VampireSurvivors.Objects.Characters.Enemies;

public class EnemyMask : EnemyController
{
	private SpriteRenderer _maskSprite;

	protected unsafe override void Awake()
	{
		base.Awake();
		object cachedTransform = _cachedTransform;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		bool flag = (nint)0 == 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v34 @ rdi_v1 (System.Object)+10]");
		float ret;
		Transform.get_position_Injected((IntPtr)0, out *(Vector3*)(&ret));
		GameObject gameObject = base.gameObject;
		float y = default(float);
		string spriteName = default(string);
		SpriteRenderer maskSprite = RenderingExtensions.AddSprite(gameObject, ret, y, null, spriteName);
		_maskSprite = maskSprite;
	}

	public override void InitEnemy(EnemyType enemyType, bool asRemote)
	{
		//IL_0047->IL0162: Incompatible stack heights: 1 vs 0
		//IL_0070->IL0162: Incompatible stack heights: 1 vs 0
		//IL_009f->IL0162: Incompatible stack heights: 1 vs 0
		//IL_0236->IL0162: Incompatible stack heights: 1 vs 0
		//IL_00d3->IL0162: Incompatible stack heights: 1 vs 0
		base.InitEnemy(enemyType, asRemote);
		if ((object)_EnemyRenderer != null)
		{
			Transform transform = _EnemyRenderer.transform;
			bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
			SetMaskSprite();
			base.SetFlipX(flip: false);
			bool flag2 = !_hpXLevel;
			base._003CIsTeleportOnCull_003Ek__BackingField = true;
			if (flag2)
			{
				goto IL_0201;
			}
			EnemyData currentEnemyData = _currentEnemyData;
			if (_currentEnemyData != null)
			{
				GameSessionData gameSessionData = _gameSessionData;
				if (_gameSessionData != null)
				{
					CharacterController activeCharacter = gameSessionData._activeCharacter;
					if ((object)gameSessionData._activeCharacter != null)
					{
						GameManager gameManager = _gameManager;
						if ((object)_gameManager != null)
						{
							Stage stage = gameManager._stage;
							if ((object)gameManager._stage != null)
							{
								float num = (float)activeCharacter._level * currentEnemyData._003CmaxHp_003Ek__BackingField;
								float num2 = num * GameManager.EnemyHealthMultiplier;
								float num3 = num2 * stage._003CEnemyHealthMultiplier_003Ek__BackingField;
								float maxHp = num3 + 1000f;
								_maxHp = maxHp;
								goto IL_0201;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0201:
		_hp = _maxHp;
		SpriteRenderer spriteRenderer = RenderingExtensions.SetAlpha(_maskSprite, 1f);
		SpriteRenderer spriteRenderer2 = RenderingExtensions.SetTint(_maskSprite, 16777215u);
	}

	protected override void OnUpdate()
	{
		base.OnUpdate();
		Cpp2ILHelpers.NoteDecompilerIssue("Invalid instruction: 11 Invalid \"Jump target not found in method: 0x1877323E0\"");
	}

	private unsafe void MaskUpdate()
	{
		//IL_02ab: Expected O, but got I4
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Expected I4, but got Unknown
		//IL_017b->IL0101: Incompatible stack heights: 1 vs 0
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Quaternion value = default(Quaternion);
			Transform.set_localRotation_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, ref value);
			Transform cachedTransform2 = _cachedTransform;
			if ((object)_cachedTransform != null)
			{
				bool flag2 = ((UnityEngine.Object)cachedTransform2).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)cachedTransform2).m_CachedPtr, out Vector3 ret);
				Transform enemyRenderer = (Transform)(object)_EnemyRenderer;
				bool flag3 = (object)_EnemyRenderer == null;
				bool flag4 = ((UnityEngine.Object)enemyRenderer).m_CachedPtr == (IntPtr)0;
				bool flag5 = SpriteRenderer.get_flipX_Injected(((UnityEngine.Object)enemyRenderer).m_CachedPtr);
				Transform cachedTransform3 = _cachedTransform;
				bool flag6 = (object)_cachedTransform == null;
				bool flag7 = ((UnityEngine.Object)cachedTransform3).m_CachedPtr == (IntPtr)0;
				Transform.get_localScale_Injected(((UnityEngine.Object)cachedTransform3).m_CachedPtr, out *(Vector3*)(&value));
				bool flag8 = (object)_maskSprite == null;
				Transform transform = _maskSprite.transform;
				object enemyRenderer2 = _EnemyRenderer;
				bool flag9 = (object)_EnemyRenderer == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rsi_v25 (System.Object)+10]");
				bool flag10 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v508 @ rsi_v25 (System.Object)+10]");
				object obj = Renderer.get_sortingOrder_Injected((IntPtr)0);
				bool flag11 = (object)_maskSprite == null;
				int sortingOrder = obj + 1;
				_maskSprite.sortingOrder = sortingOrder;
				if (flag5)
				{
				}
				bool flag12 = (object)transform == null;
				bool flag13 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				bool flag14 = (object)_EnemyRenderer == null;
				Transform transform2 = _EnemyRenderer.transform;
				bool flag15 = (object)transform2 == null;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1211 @ rax_v79 (UnityEngine.Transform)+10]");
				bool flag16 = (nint)0 == 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1211 @ rax_v79 (UnityEngine.Transform)+10]");
				Transform.get_localScale_Injected((IntPtr)0, out ret);
				bool flag17 = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
				Transform.set_localScale_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref *(Vector3*)(&value));
				bool flag18 = (object)_maskSprite == null;
				_maskSprite.flipX = flag5;
				return;
			}
		}
		throw new NullReferenceException();
	}

	protected override void ProcessWiggle()
	{
	}

	protected override void Die()
	{
		//IL_0061: Expected O, but got I4
		//IL_013e->IL00be: Incompatible stack heights: 1 vs 0
		//IL_015b->IL00be: Incompatible stack heights: 1 vs 0
		base.Die();
		Transform cachedTransform = _cachedTransform;
		if ((object)_cachedTransform != null)
		{
			bool flag = ((UnityEngine.Object)cachedTransform).m_CachedPtr == (IntPtr)0;
			Transform.get_position_Injected(((UnityEngine.Object)cachedTransform).m_CachedPtr, out Vector3 _);
			if ((object)_gameManager != null)
			{
				Vector2 pos = default(Vector2);
				float value = default(float);
				ItemType relicType = default(ItemType);
				bool validatePickups = default(bool);
				Pickup pickup = _gameManager.MakeStagePickup(pos, ItemType.RELIC_GOLDENEGG, WeaponType.VOID, value, relicType, validatePickups);
				SpriteRenderer spriteRenderer = RenderingExtensions.SetTint(_EnemyRenderer, 16777215u);
				SetTintFill(isEnabled: false, (HitVfxType?)(object)0);
				TweenerCore<Color, Color, ColorOptions> tweenerCore = DOTweenModuleSprite.DOFade(_maskSprite, 0f, 0.5f);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [1899A55C2]");
				if ((nint)0 == 0)
				{
					_ = 1;
				}
				if (tweenerCore != null)
				{
					return;
				}
			}
		}
		throw new NullReferenceException();
	}

	private void SetMaskSprite()
	{
		//IL_0019: Expected O, but got I8
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Expected O, but got Unknown
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Expected O, but got Unknown
		//IL_044f: Expected O, but got I4
		//IL_03e8->IL0433: Incompatible stack heights: 1 vs 0
		bool flag = _enemyType == EnemyType.MOON_MASK1;
		if (flag)
		{
			goto IL_00b7;
		}
		object obj = (long)_enemyType + 4294967097L;
		string spriteName;
		if (!flag)
		{
			object obj2 = obj - 1;
			if (!flag)
			{
				object obj3 = obj2 - 1;
				if (!flag)
				{
					if ((nint)obj3 != 1)
					{
						goto IL_00b7;
					}
					spriteName = "mask5";
				}
				else
				{
					spriteName = "mask4";
				}
			}
			else
			{
				spriteName = "mask2";
			}
		}
		else
		{
			spriteName = "mask1";
		}
		goto IL_03e8;
		IL_00b7:
		List<string> list = new List<string>();
		int version = list._version + 1;
		list._version = version;
		string[] items = list._items;
		if (list._size >= items.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask1");
		}
		else
		{
			int num = list._size + 1;
			list._size = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version2 = list._version + 1;
		list._version = version2;
		string[] items2 = list._items;
		if (list._size >= items2.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask2");
		}
		else
		{
			int num2 = list._size + 1;
			list._size = num2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version3 = list._version + 1;
		list._version = version3;
		string[] items3 = list._items;
		if (list._size >= items3.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask3");
		}
		else
		{
			int num3 = list._size + 1;
			list._size = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version4 = list._version + 1;
		list._version = version4;
		string[] items4 = list._items;
		if (list._size >= items4.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask4");
		}
		else
		{
			int num4 = list._size + 1;
			list._size = num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		int version5 = list._version + 1;
		list._version = version5;
		string[] items5 = list._items;
		if (list._size >= items5.Length)
		{
			((List<object>)(object)list).AddWithResize((object)"mask5");
		}
		else
		{
			int num5 = list._size + 1;
			list._size = num5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
		}
		object obj4 = UnityEngine.Random.RandomRangeInt(0, list._size);
		bool flag2 = (nint)obj4 >= list._size;
		string[] items6 = list._items;
		spriteName = items6[obj4];
		goto IL_03e8;
		IL_03e8:
		Sprite sprite = SpriteManager.GetSprite(spriteName, "enemies2");
		_maskSprite.sprite = sprite;
	}
}
