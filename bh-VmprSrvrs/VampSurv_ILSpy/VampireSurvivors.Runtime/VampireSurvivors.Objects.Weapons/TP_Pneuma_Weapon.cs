using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;
using VampireSurvivors.Data;
using VampireSurvivors.Framework.Phaser;
using VampireSurvivors.Framework.PhaserTweens;
using VampireSurvivors.Objects.Characters;
using VampireSurvivors.Objects.Pools;
using VampireSurvivors.Objects.Projectiles;

namespace VampireSurvivors.Objects.Weapons;

public class TP_Pneuma_Weapon : Weapon
{
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public SpikeData spikeData;

		public PhaserSprite spikeSprite;

		internal void _003CaddSpikeSprite_003Eb__0()
		{
			SpikeData spikeData = this.spikeData;
			spikeData.active = false;
			PhaserSprite phaserSprite = spikeSprite.setVisible(visible: false);
		}
	}

	private List<SpikeData> spikeData;

	private BulletPool _waveProjectile;

	private float _spikePosLeniency;

	public override void Fire(bool skipTriggers = false)
	{
		base.Fire(skipTriggers);
		float2 position = ((Equipment)this)._003COwner_003Ek__BackingField.position;
		Vector2 pos = default(Vector2);
		BulletPool pool = default(BulletPool);
		Projectile projectile = base.FireOneProjectile(pos, 0, _targetTransform, pool);
	}

	public override void InitWeapon(VampireSurvivors.Objects.Characters.CharacterController characterController, WeaponType weaponType)
	{
		base.InitWeapon(characterController, weaponType);
		_explosionType = WeaponType.FIREEXPLOSION;
		if (_waveProjectile == null)
		{
			Projectile projectilePrefab = _projectileFactory.GetProjectilePrefab(WeaponType.TP_WIND2);
			BulletPool waveProjectile = new BulletPool(projectilePrefab);
			_waveProjectile = waveProjectile;
		}
	}

	private SpikeData nextSpikeData()
	{
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Expected O, but got Unknown
		//IL_03bd->IL030a: Incompatible stack heights: 1 vs 0
		//IL_01d8->IL030a: Incompatible stack heights: 1 vs 0
		//IL_0215->IL030a: Incompatible stack heights: 1 vs 0
		//IL_0250->IL030a: Incompatible stack heights: 1 vs 0
		//IL_029f->IL030a: Incompatible stack heights: 1 vs 0
		//IL_030a->IL0161: Incompatible stack heights: 1 vs 0
		//IL_02db->IL0161: Incompatible stack heights: 1 vs 0
		List<SpikeData> list = this.spikeData;
		if (this.spikeData != null)
		{
			List<SpikeData> list2 = this.spikeData;
			Transform transform = null;
			Transform transform2 = null;
			object obj = default(object);
			Vector2 pos = default(Vector2);
			SpikeData spikeData2 = default(SpikeData);
			while (true)
			{
				if ((nint)transform2 < list._size)
				{
					if ((nint)transform < list2._size)
					{
						SpikeData[] items = list2._items;
						if (list2._items == null)
						{
							break;
						}
						if ((nint)transform < items.Length)
						{
							SpikeData spikeData = items[(object)transform];
							if (items[(object)transform] == null)
							{
								break;
							}
							if (spikeData.active)
							{
								transform = (Transform)(transform + 1);
								transform2 = transform;
								continue;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							if (obj == null)
							{
								break;
							}
							_ = 1;
							if (this.spikeData == null)
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800031A0");
							goto IL_0161;
						}
					}
					else
					{
						System.ThrowHelper.ThrowArgumentOutOfRange_IndexException();
					}
					throw new IndexOutOfRangeException();
				}
				PhaserWorld instance = PhaserWorld.Instance;
				Transform transform3 = base.transform;
				if ((object)transform3 == null)
				{
					break;
				}
				bool flag = ((UnityEngine.Object)transform3).m_CachedPtr == (IntPtr)0;
				Transform.get_position_Injected(((UnityEngine.Object)transform3).m_CachedPtr, out Vector3 _);
				if ((object)instance == null)
				{
					break;
				}
				PhaserSprite phaserSprite = instance.AddPhaserSprite(pos, "vfx", "SpearTip");
				if ((object)phaserSprite == null)
				{
					break;
				}
				PhaserSprite phaserSprite2 = phaserSprite.setVisible(visible: false);
				spikeData2 = new SpikeData();
				if (spikeData2 == null)
				{
					break;
				}
				spikeData2.spikeSprite = phaserSprite;
				List<object> list3 = (List<object>)(object)this.spikeData;
				if (this.spikeData == null)
				{
					break;
				}
				int version = list3._version + 1;
				list3._version = version;
				object[] items2 = list3._items;
				if (list3._items == null)
				{
					break;
				}
				if (list3._size >= items2.Length)
				{
					((List<object>)(object)this.spikeData).AddWithResize((object)spikeData2);
				}
				else
				{
					int size = list3._size + 1;
					list3._size = size;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
				}
				goto IL_0161;
				IL_0161:
				return spikeData2;
			}
		}
		throw new NullReferenceException();
	}

	public void addSpikeSprite(float2 pos, float angle, float scale, float alpha)
	{
		//IL_00fb: Expected O, but got I4
		//IL_0597: Expected I4, but got I8
		//IL_059b: Expected O, but got I4
		//IL_02ed: Expected I, but got O
		//IL_0357: Expected O, but got I4
		//IL_0373: Expected O, but got I4
		//IL_042a: Expected I, but got O
		//IL_0494: Expected O, but got I4
		//IL_04be: Expected O, but got I4
		//IL_0242->IL052b: Incompatible stack heights: 1 vs 0
		//IL_02be->IL052b: Incompatible stack heights: 1 vs 0
		//IL_0332->IL052b: Incompatible stack heights: 1 vs 0
		//IL_0310->IL0310: Incompatible stack heights: 2 vs 1
		//IL_03a2->IL052b: Incompatible stack heights: 1 vs 0
		//IL_03fb->IL052b: Incompatible stack heights: 1 vs 0
		//IL_046f->IL052b: Incompatible stack heights: 1 vs 0
		//IL_044d->IL044d: Incompatible stack heights: 2 vs 1
		//IL_0513->IL052b: Incompatible stack heights: 1 vs 0
		//IL_052a->IL052a: Incompatible stack heights: 1 vs 0
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals25 = new _003C_003Ec__DisplayClass6_0();
		SpikeData spikeData = nextSpikeData();
		if (CS_0024_003C_003E8__locals25 != null)
		{
			CS_0024_003C_003E8__locals25.spikeData = spikeData;
			if (CS_0024_003C_003E8__locals25.spikeData == null)
			{
				return;
			}
			SpikeData spikeData2 = CS_0024_003C_003E8__locals25.spikeData;
			CS_0024_003C_003E8__locals25.spikeSprite = spikeData2.spikeSprite;
			float minInclusive = _spikePosLeniency ^ -0f;
			float num = UnityEngine.Random.Range(minInclusive, _spikePosLeniency);
			float minInclusive2 = _spikePosLeniency ^ -0f;
			float num2 = UnityEngine.Random.Range(minInclusive2, _spikePosLeniency);
			object obj = default(object);
			float num3 = (float)obj + num2;
			if ((object)CS_0024_003C_003E8__locals25.spikeSprite != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18697BFC0");
				if ((object)CS_0024_003C_003E8__locals25.spikeSprite != null)
				{
					PhaserSprite phaserSprite = CS_0024_003C_003E8__locals25.spikeSprite.setScale(0f, (float?)(object)0);
					if ((object)CS_0024_003C_003E8__locals25.spikeSprite != null)
					{
						PhaserSprite phaserSprite2 = CS_0024_003C_003E8__locals25.spikeSprite.setVisible(visible: true);
						if ((object)CS_0024_003C_003E8__locals25.spikeSprite != null)
						{
							PhaserSprite phaserSprite3 = CS_0024_003C_003E8__locals25.spikeSprite.setTint(3468102u);
							PhaserSprite spikeSprite = CS_0024_003C_003E8__locals25.spikeSprite;
							if ((object)CS_0024_003C_003E8__locals25.spikeSprite != null && (object)spikeSprite._spriteRenderer != null)
							{
								Transform transform = spikeSprite._spriteRenderer.transform;
								object obj2 = UnityEngine.Random.RandomRangeInt(-10, 10);
								float num4 = (float)obj2 + angle;
								float num5 = num4 * ((float)Math.PI / 180f);
								Vector3 euler = default(Vector3);
								Quaternion.Internal_FromEulerRad_Injected(ref euler, out Quaternion _);
								bool flag = ((UnityEngine.Object)transform).m_CachedPtr == (IntPtr)0;
								Quaternion value = default(Quaternion);
								Transform.set_rotation_Injected(((UnityEngine.Object)transform).m_CachedPtr, ref value);
								SpikeData spikeData3 = CS_0024_003C_003E8__locals25.spikeData;
								if (spikeData3.spikeTweenIn != null)
								{
									spikeData3.spikeTweenIn.Kill();
								}
								SpikeData spikeData4 = CS_0024_003C_003E8__locals25.spikeData;
								if (CS_0024_003C_003E8__locals25.spikeData != null)
								{
									if (spikeData4.spikeTweenOut != null)
									{
										spikeData4.spikeTweenOut.Kill();
									}
									SpikeData spikeData5 = CS_0024_003C_003E8__locals25.spikeData;
									TweenConfig tweenConfig = new TweenConfig();
									object[] array = new object[1];
									if (array != null)
									{
										if ((object)CS_0024_003C_003E8__locals25.spikeSprite != null)
										{
											nint num6 = (nint)array;
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
											object obj3 = default(object);
											bool flag2 = obj3 == null;
										}
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
										if (tweenConfig != null)
										{
											tweenConfig.targets = array;
											tweenConfig.alpha = (float?)(object)1;
											tweenConfig.duration = 100f;
											tweenConfig.scale = (float?)(object)1;
											MultiTargetTween spikeTweenIn = Tweens.Add(tweenConfig);
											if (CS_0024_003C_003E8__locals25.spikeData != null)
											{
												spikeData5.spikeTweenIn = spikeTweenIn;
												SpikeData spikeData6 = CS_0024_003C_003E8__locals25.spikeData;
												TweenConfig tweenConfig2 = new TweenConfig();
												object[] array2 = new object[1];
												if (array2 != null)
												{
													if ((object)CS_0024_003C_003E8__locals25.spikeSprite != null)
													{
														nint num7 = (nint)array2;
														Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180B02C70");
														object obj4 = default(object);
														bool flag3 = obj4 == null;
													}
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1800022B0");
													if (tweenConfig2 != null)
													{
														tweenConfig2.targets = array2;
														tweenConfig2.alpha = (float?)(object)1;
														tweenConfig2.duration = 100f;
														tweenConfig2.delay = 200f;
														tweenConfig2.scale = (float?)(object)1;
														TweenCallback onComplete = delegate
														{
															SpikeData spikeData7 = CS_0024_003C_003E8__locals25.spikeData;
															spikeData7.active = false;
															PhaserSprite phaserSprite4 = CS_0024_003C_003E8__locals25.spikeSprite.setVisible(visible: false);
														};
														tweenConfig2.onComplete = onComplete;
														MultiTargetTween spikeTweenOut = Tweens.Add(tweenConfig2);
														if (CS_0024_003C_003E8__locals25.spikeData != null)
														{
															spikeData6.spikeTweenOut = spikeTweenOut;
															return;
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
	}

	public unsafe override void Cleanup()
	{
		//IL_0013: Expected O, but got I4
		//IL_001b: Expected O, but got Ref
		base.Cleanup();
		List<SpikeData>.Enumerator enumerator = default(List<SpikeData>.Enumerator);
		if (enumerator.MoveNext())
		{
			object obj = 0;
			List<SpikeData>.Enumerator enumerator2 = (List<SpikeData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public unsafe override void SetVisible(bool visible)
	{
		//IL_0019: Expected O, but got I4
		//IL_0021: Expected O, but got Ref
		_isVisible = visible;
		List<SpikeData>.Enumerator enumerator = default(List<SpikeData>.Enumerator);
		if (!visible && enumerator.MoveNext())
		{
			object obj = 0;
			List<SpikeData>.Enumerator enumerator2 = (List<SpikeData>.Enumerator)(&enumerator);
			throw new NullReferenceException();
		}
	}

	public TP_Pneuma_Weapon()
	{
		List<SpikeData> list = new List<SpikeData>();
		spikeData = list;
		_spikePosLeniency = 0.049999997f;
		base._002Ector();
	}
}
