using System;
using Cpp2ILInjected;
using DarkTonic.MasterAudio;
using SuperTiled2Unity;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Tilemaps;
using VampireSurvivors.Data;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Rapidus2_Weapon : TP_Rapidus_Weapon
{
	private bool _shouldCheckForSecret;

	protected override float _perLevelBonus => 0.8f;

	protected override int _maxCharges => 1;

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Expected I4, but got Unknown
		base.InitWeapon(characterController, weaponType);
		GameManager core = GM.Core;
		Stage stage = core._stage;
		bool shouldCheckForSecret;
		if (stage._stageType != StageType.TP_CASTLE)
		{
			shouldCheckForSecret = false;
		}
		else
		{
			PlayerOptions playerOptions = _playerOptions;
			PlayerOptionsData mainGameConfig = playerOptions._mainGameConfig;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A9B210");
			object obj = default(object);
			shouldCheckForSecret = (byte)(obj ^ 1) != 0;
		}
		_shouldCheckForSecret = shouldCheckForSecret;
	}

	public override void InternalUpdate()
	{
		//IL_0013: Invalid comparison between F4 and I4
		//IL_01ca: Expected I, but got O
		//IL_01d8: Expected I, but got O
		//IL_01e8: Expected O, but got I
		//IL_0268: Expected O, but got I4
		//IL_0224: Expected O, but got I
		//IL_025a: Expected O, but got I4
		//IL_040a: Expected F4, but got I4
		//IL_04a4->IL0423: Incompatible stack heights: 1 vs 0
		//IL_00d7->IL0459: Incompatible stack heights: 1 vs 0
		//IL_00fe->IL0423: Incompatible stack heights: 1 vs 0
		//IL_012d->IL0423: Incompatible stack heights: 1 vs 0
		//IL_014c->IL0423: Incompatible stack heights: 1 vs 0
		//IL_017d->IL0423: Incompatible stack heights: 1 vs 0
		//IL_04ed->IL0459: Incompatible stack heights: 1 vs 0
		//IL_02a6->IL0459: Incompatible stack heights: 1 vs 0
		//IL_031c->IL0423: Incompatible stack heights: 1 vs 0
		//IL_02f3->IL0459: Incompatible stack heights: 1 vs 0
		//IL_033e->IL0423: Incompatible stack heights: 1 vs 0
		//IL_036e->IL0459: Incompatible stack heights: 1 vs 0
		//IL_038d->IL0423: Incompatible stack heights: 1 vs 0
		//IL_0423->IL0459: Incompatible stack heights: 1 vs 0
		base.InternalUpdate();
		VampireSurvivors.Objects.Characters.CharacterController characterController = ((Equipment)this)._003COwner_003Ek__BackingField;
		TileBase tileAtPosition;
		Transform transform2;
		object obj3;
		if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
		{
			if (!(characterController._walked > 0f))
			{
				return;
			}
			int num = base.ActiveProjectileCount();
			if (num <= 0)
			{
				return;
			}
			if ((object)((Equipment)this)._003COwner_003Ek__BackingField != null)
			{
				Transform transform = ((Equipment)this)._003COwner_003Ek__BackingField.transform;
				if ((object)transform != null)
				{
					bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
					Transform.get_position_Injected(((UnityEngine.Object)transform).m_CachedPtr, out Vector3 _);
					if ((object)_pfxEmitterManager != null)
					{
						Vector2 vector = default(Vector2);
						_pfxEmitterManager.EmitParticleAt(vector, 3);
						if (!_shouldCheckForSecret)
						{
							return;
						}
						GameManager core = GM.Core;
						if ((object)GM.Core != null)
						{
							Stage stage = core._stage;
							if ((object)core._stage != null && (object)((Equipment)this)._003COwner_003Ek__BackingField != null)
							{
								float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
								if ((object)stage._tilingTileset != null)
								{
									tileAtPosition = stage._tilingTileset.GetTileAtPosition(vector);
									if ((object)tileAtPosition == null)
									{
										transform2 = null;
										goto IL_04d5;
									}
									nint num2 = (nint)tileAtPosition;
									nint num3 = (nint)typeof(SuperTile);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rdx_v18 (Il2CppClass<SuperTiled2Unity.SuperTile>)+130]");
									object obj = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ r8_v12 (Il2CppClass<UnityEngine.Tilemaps.TileBase>)+130]");
									nint num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v618 @ rdx_v18 (Il2CppClass<SuperTiled2Unity.SuperTile>)+130]");
									if (num4 >= 0)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v617 @ r8_v12 (Il2CppClass<UnityEngine.Tilemaps.TileBase>)+C8]");
										object obj2 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v673 @ rax_v51+FFFFFFF8+v619 @ rax_v47*8]");
										if (0 == (nint)typeof(SuperTile))
										{
											obj3 = 1;
											goto IL_04ae;
										}
									}
									obj3 = 0;
									goto IL_04ae;
								}
							}
						}
					}
				}
			}
		}
		goto IL_0423;
		IL_04d5:
		if ((object)transform2 == null || ((UnityEngine.Object)transform2).m_CachedPtr == (IntPtr)0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdi_v8 (UnityEngine.Transform)+18]");
		if ((nint)0 != 3324)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rdi_v8 (UnityEngine.Transform)+18]");
			if ((nint)0 != 3322)
			{
				return;
			}
		}
		PlayerOptions playerOptions = _playerOptions;
		if (_playerOptions != null && playerOptions._mainGameConfig != null)
		{
			if (!playerOptions._mainGameConfig.HasCollectedItem(ItemType.TP_RELIC_PILEOFSECRETS))
			{
				return;
			}
			if (_playerOptions != null)
			{
				PlayerOptionsData config = _playerOptions.Config;
				if (_playerOptions.UnlockSecret(SecretType.tp_ferryman, config))
				{
					float? volume = default(float?);
					float rate = default(float);
					float detune = default(float);
					bool loop = default(bool);
					PlaySoundResult playSoundResult = SoundManager.PlaySoundNonAlloc(SfxType.ThingFound, 0f, 10, 0f, volume, rate, detune, loop, 1f);
				}
				_shouldCheckForSecret = false;
				return;
			}
		}
		goto IL_0423;
		IL_0423:
		throw new NullReferenceException();
		IL_04ae:
		bool flag2 = obj3 == null;
		transform2 = null;
		if (!flag2)
		{
			transform2 = (Transform)(object)tileAtPosition;
		}
		goto IL_04d5;
	}
}
