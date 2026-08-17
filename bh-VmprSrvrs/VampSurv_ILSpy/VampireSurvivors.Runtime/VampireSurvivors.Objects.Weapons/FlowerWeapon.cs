using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;
using VampireSurvivors.Framework;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Items;
using VampireSurvivors.Objects.Pickups;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class FlowerWeapon : Weapon
{
	private float _mul = 16.666666f;

	public override void CheckArcanas()
	{
		if (!_beginningArcana)
		{
			GameManager gameMan = _gameMan;
			List<WeaponType> list = gameMan._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v185 @ rax_v13 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
			if ((nint)0 > (nint)0)
			{
				GameManager gameMan2 = _gameMan;
				List<WeaponType> list2 = gameMan2._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
				object obj = default(object);
				if (obj != null)
				{
					int beginningAmount = _beginningAmount + 3;
					_beginningAmount = beginningAmount;
					WeaponData currentWeaponData = _currentWeaponData;
					_beginningArcana = true;
					int num = currentWeaponData._003Camount_003Ek__BackingField + 3;
					currentWeaponData._003Camount_003Ek__BackingField = num;
				}
			}
			if (!_beginningArcana)
			{
				GameManager gameMan3 = _gameMan;
				List<WeaponType> list3 = gameMan3._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v90 @ rax_v16 (System.Collections.Generic.List`1<VampireSurvivors.Data.WeaponType>)+18]");
				if ((nint)0 > (nint)0)
				{
					GameManager gameMan4 = _gameMan;
					List<WeaponType> list4 = gameMan4._arcanaManager.Beginning(((Equipment)this)._003COwner_003Ek__BackingField);
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180A969B0");
					object obj2 = default(object);
					if (obj2 == null)
					{
						int beginningAmount2 = _beginningAmount + 1;
						_beginningAmount = beginningAmount2;
						WeaponData currentWeaponData2 = _currentWeaponData;
						_beginningArcana = true;
						int num2 = currentWeaponData2._003Camount_003Ek__BackingField + 1;
						currentWeaponData2._003Camount_003Ek__BackingField = num2;
					}
				}
			}
		}
		GameManager core = GM.Core;
		ArcanaManager arcanaManager = core._arcanaManager;
		List<ArcanaType> list5 = arcanaManager._003CActiveArcanas_003Ek__BackingField;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180589550");
		object obj3 = default(object);
		if ((nint)obj3 > -1)
		{
			_explodeOnExpire = true;
		}
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		_secondaryOvarlapDamageType = WeaponType.CURSE;
		base.InitWeapon(characterController, weaponType);
		PhaserScene s_scene = ArcadePhysics.s_scene;
		ArcadePhysics physics = s_scene.physics;
		ArcadePhysicsCallback collideCallback = onBulletOverlapsBullet;
		ArcadePhysicsCallback processCallback = default(ArcadePhysicsCallback);
		CallbackContext callbackContext = default(CallbackContext);
		Collider collider = physics.add.collider(_projectilePool, _projectilePool, collideCallback, processCallback, callbackContext);
	}

	public override void InternalUpdate()
	{
		base.InternalUpdate();
		float deltaTime = PauseSystem.DeltaTime;
		float num = deltaTime * 1000f;
		float num2 = num + base._003CTotalTime_003Ek__BackingField;
		base._003CTotalTime_003Ek__BackingField = num2;
		float frameWalk = ((Equipment)this)._003COwner_003Ek__BackingField.FrameWalk;
		float deltaTime2 = PauseSystem.DeltaTime;
		float num3 = deltaTime2 * 1000f;
		float num4 = frameWalk * 100f;
		float num5 = num3 / _mul;
		float num6 = num5 * num4;
		float num7 = (base._003CTotalTime_003Ek__BackingField = num6 + base._003CTotalTime_003Ek__BackingField);
		float num8 = base.PInterval();
		if (!(num7 < deltaTime2))
		{
			float num9 = base.PInterval();
			float num10 = base._003CTotalTime_003Ek__BackingField - deltaTime2;
			base._003CTotalTime_003Ek__BackingField = num10;
			base.Fire();
		}
	}

	private bool onBulletOverlapsBullet(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0183: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				FlowerProjectile component = gameObject.GetComponent<FlowerProjectile>();
				if (second != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
					GameObject gameObject2 = default(GameObject);
					if ((object)gameObject2 != null)
					{
						FlowerProjectile component2 = gameObject2.GetComponent<FlowerProjectile>();
						if ((object)component2 != null)
						{
							if (component2.HasAlreadyHitObject(component))
							{
								goto IL_016f;
							}
							if ((object)component != null && ((Projectile)component)._objectsHit != null)
							{
								bool flag = ((HashSet<object>)(object)((Projectile)component)._objectsHit).AddIfNotPresent((object)component2);
								if (((Projectile)component2)._objectsHit != null)
								{
									bool flag2 = ((HashSet<object>)(object)((Projectile)component2)._objectsHit).AddIfNotPresent((object)component);
									component.SizeUp();
									component2.SizeUp();
									goto IL_016f;
								}
							}
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_016f:
		return false;
	}

	public override void ResetFiringTimer()
	{
		if (_firingTimer != null)
		{
			_firingTimer.Cancel();
		}
	}

	protected override bool OnBulletOverlapsEnemy(CallbackContext context, ArcadeColliderType second, ArcadeColliderType first)
	{
		//IL_0357: Expected I4, but got O
		if (first != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
			GameObject gameObject = default(GameObject);
			if ((object)gameObject != null)
			{
				EnemyController component = gameObject.GetComponent<EnemyController>();
				if ((object)component != null)
				{
					if (component._003CIsDead_003Ek__BackingField)
					{
						goto IL_0374;
					}
					if (second != null)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180002A60");
						GameObject gameObject2 = default(GameObject);
						if ((object)gameObject2 != null)
						{
							Projectile component2 = gameObject2.GetComponent<Projectile>();
							if ((object)component2 != null)
							{
								if (!component2.HasAlreadyHitObject(component))
								{
									float num = base.PPower();
									WeaponData currentWeaponData = _currentWeaponData;
									HitVfxType showHitVfx = ((_currentWeaponData == null) ? HitVfxType.Default : currentWeaponData._003ChitVFX_003Ek__BackingField);
									float knockback = base.Knockback;
									float value = default(float);
									component.GetDamaged(value, showHitVfx, knockback, WeaponType.VOID, hasKb: false);
									float num2 = base.PPower();
									float num3 = knockback + base._003CStatsInflictedDamage_003Ek__BackingField;
									base._003CStatsInflictedDamage_003Ek__BackingField = num3;
									if (component._003CIsDead_003Ek__BackingField && ((Equipment)this)._003CLevel_003Ek__BackingField >= 8)
									{
										List<float> critChancesArray = _critChancesArray;
										if (_critChancesArray != null)
										{
											int critIndex = _critIndex;
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v143 @ rcx_v13 (System.Collections.Generic.List`1<System.Single>)+18]");
											int num4 = (int)((nint)critIndex % (nint)0);
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18049FD20");
											int critIndex2 = _critIndex + 1;
											_critIndex = critIndex2;
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm0\"");
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"comisd xmm0,qword ptr [188A10698h]\"");
											if ((nint)_critChancesArray < 0)
											{
												goto IL_0374;
											}
											Transform transform = component.transform;
											if ((object)transform != null)
											{
												Vector3 position = transform.position;
												if ((object)_gameMan != null && (_gameMan.IsStageHost || !NetworkItems.IsNetworkItem(ItemType.LITTLEHEART)))
												{
													Vector2 pos = default(Vector2);
													Pickup pickup = PickupManager.CreatePickup(pos, ItemType.LITTLEHEART);
													if ((object)pickup != null)
													{
														pickup.GoToLowestHealthPlayer();
														pickup.Time = 1f;
														GameObject gameObject3 = pickup.gameObject;
														if ((object)gameObject3 != null)
														{
															LittleHeart component3 = gameObject3.GetComponent<LittleHeart>();
															if ((object)component3 != null)
															{
																component3._Volume = 0.1f;
																goto IL_0374;
															}
														}
													}
												}
											}
										}
										goto IL_0349;
									}
								}
								goto IL_0374;
							}
						}
					}
				}
			}
		}
		goto IL_0349;
		IL_0349:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_0374:
		return false;
	}
}
