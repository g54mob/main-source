using System;
using System.Runtime.CompilerServices;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat.EnemyDebuffs;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Managers;
using Assets.Scripts.Menu.Shop;
using Cpp2ILInjected;
using UnityEngine;

public class ProjectilePoisonFlask : ProjectileBase
{
	public Rigidbody rb;

	private float defaultProjectileRadius;

	private float maxProjectileSpeed;

	protected static Collider[] enemyCollidersBuffer;

	public float explosionRadius;

	public EffectPlayer effect;

	private Vector3 explosionSizeDefault;

	protected override bool TryInit(int projectileIndex)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Expected O, but got Unknown
		//IL_0918: Expected I, but got O
		//IL_0955: Expected O, but got I
		//IL_0972: Expected O, but got I
		//IL_09bc: Invalid comparison between F4 and O
		//IL_062b: Expected I, but got O
		//IL_0609: Expected I4, but got O
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Expected O, but got Unknown
		//IL_0089: Expected O, but got F4
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_01f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fa: Expected O, but got Unknown
		//IL_02da: Unknown result type (might be due to invalid IL or missing references)
		//IL_02df: Expected O, but got Unknown
		//IL_0359: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Expected O, but got Unknown
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Expected O, but got Unknown
		//IL_076e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0773: Expected O, but got Unknown
		//IL_0461: Unknown result type (might be due to invalid IL or missing references)
		//IL_0466: Expected O, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0474: Expected O, but got Unknown
		//IL_050e: Invalid comparison between F4 and I4
		//IL_0554: Invalid comparison between I4 and F4
		//IL_053d: Expected O, but got I
		//IL_057b: Expected F4, but got I4
		//IL_0900: Expected O, but got I
		//IL_05bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_05c1: Expected O, but got Unknown
		object obj2 = default(object);
		object obj = obj2 - 95;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v59 @ rax_v4 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		object obj3 = explosionSizeDefault - Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectilePoisonFlask)+8C]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+4]");
		object obj4 = num3 - 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (ProjectilePoisonFlask)+90]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v66 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj5 = num4 - 0;
		object obj6 = obj4 * obj4;
		object obj7 = obj3 * obj3;
		object obj8 = obj5 * obj5;
		object obj9 = obj6 + obj7;
		object obj10 = obj9 + obj8;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) > System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj10))
		{
			if ((object)effect != null)
			{
				Transform transform = effect.transform;
				if ((object)transform != null)
				{
					Vector3 localScale = transform.localScale;
					explosionSizeDefault = (Vector3)localScale.x;
					_ = localScale.z;
					goto IL_060e;
				}
			}
			goto IL_05fb;
		}
		goto IL_060e;
		IL_05fb:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
		IL_060e:
		Transform transform2 = base.transform;
		nint num5 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rcx_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num6 = 0;
		if ((object)transform2 != null)
		{
			_ = Vector3.oneVector;
			Vector3 localScale2 = (Vector3)(obj - 121);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v236 @ rdx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			_ = 0;
			transform2.localScale = localScale2;
			projectileRadius = defaultProjectileRadius;
			Transform transform3 = base.transform;
			if ((object)MyPlayer.Instance != null)
			{
				Transform transform4 = MyPlayer.Instance.transform;
				if ((object)transform4 != null)
				{
					Vector3 position = transform4.position;
					if ((object)transform3 != null)
					{
						Vector3 position2 = (Vector3)(obj - 121);
						_ = position.x;
						_ = position.z;
						transform3.position = position2;
						if ((object)MyPlayer.Instance != null)
						{
							Transform transform5 = MyPlayer.Instance.transform;
							if ((object)transform5 != null)
							{
								Vector3 position3 = transform5.position;
								if ((object)rb != null)
								{
									Vector3 position4 = (Vector3)(obj - 121);
									_ = position3.x;
									_ = position3.z;
									rb.MovePosition(position4);
									Transform transform6 = base.transform;
									if ((object)transform6 != null)
									{
										Vector3 position5 = transform6.position;
										float weaponRange = WeaponUtility.GetWeaponRange(base.weaponBase);
										WeaponBase weaponBase = base.weaponBase;
										if (base.weaponBase != null)
										{
											WeaponData weaponData = weaponBase.weaponData;
											if ((object)weaponBase.weaponData != null)
											{
												_ = position5.x;
												Vector3 position6 = (Vector3)(obj - 121);
												_ = position5.z;
												GameObject exceptObject = default(GameObject);
												Enemy enemy = EnemyTargeting.GetEnemy(position6, weaponRange, projectileIndex, weaponData.useVision, exceptObject);
												if (!(enemy != null))
												{
													return false;
												}
												float num7 = projectileSpeed;
												float y = Physics.gravity.y;
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED80]");
												object obj11 = y & 0;
												Transform transform7 = base.transform;
												if ((object)transform7 != null)
												{
													Vector3 position7 = transform7.position;
													if ((object)enemy != null)
													{
														_ = position7.y;
														_ = position7.z;
														Vector3 centerPosition = enemy.GetCenterPosition();
														EnemyMovementRb enemyMovement = enemy.enemyMovement;
														if ((object)enemy.enemyMovement != null && (object)enemyMovement.rb != null)
														{
															if (projectileSpeed > maxProjectileSpeed)
															{
																num7 = maxProjectileSpeed;
															}
															Vector3 velocity = enemyMovement.rb.velocity;
															object obj12 = obj - 121;
															float num8 = centerPosition.x - position7.x;
															float num9 = centerPosition.y - position7.y;
															float num10 = centerPosition.z;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
															float num11 = num10 - 0f;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
															float num12 = num11 / num7;
															float num13 = num12 * velocity.y;
															float num14 = num13 + centerPosition.y;
															float num15 = num14;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+7F]");
															float num16 = num15 - 0f;
															_ = 0;
															float num17 = num12 * velocity.x;
															object obj13 = obj - 121;
															float num18 = num12 * velocity.z;
															float num19 = num17 + centerPosition.x;
															float num20 = num18 + centerPosition.z;
															float num21 = num19 - position7.x;
															float num22 = num20;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+67]");
															float num23 = num22 - 0f;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
															object obj14 = obj - 121;
															object obj15 = obj - 105;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
															float num24 = num16 + num16;
															float num25 = num7 * num7;
															float num26 = (float)obj11 * num23;
															float num27 = num24 * num25;
															float num28 = num26 * num23;
															float num29 = num25 * num25;
															float num30 = num27 + num28;
															float num31 = num30 * (float)obj11;
															float num32 = num29 - num31;
															object obj16;
															object obj17 = default(object);
															object obj18;
															float num33;
															if (num32 < 0f)
															{
																obj16 = obj17;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ rax_v41+8]");
																obj18 = 0;
																num33 = 0.17453292f;
															}
															else
															{
																float num34;
																if (!(0f > num32))
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtss xmm8,xmm1\"");
																	num34 = 0f;
																}
																else
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180300EA0");
																	num34 = num32;
																}
																float num35 = num34 + num25;
																num32 = (float)obj11 * num23;
																float num36 = num35 / num32;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301A80");
																float num37 = num25 - num34;
																float num38 = (float)obj11 * num23;
																float num39 = num37 / num38;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301A80");
																obj16 = obj17;
																bool flag = !(num36 > num39);
																num33 = num36;
																if (!flag)
																{
																	num33 = num39;
																}
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v697 @ rax_v41+8]");
																obj18 = 0;
															}
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE090");
															float num40 = num33 * num7;
															float num41 = (float)obj16 * num40;
															float num42 = (float)obj18 * num40;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802FE830");
															if ((object)rb != null)
															{
																float num43 = num33 * num7;
																Vector3 velocity2 = (Vector3)(obj - 121);
																rb.velocity = velocity2;
																return true;
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
		}
		goto IL_05fb;
	}

	private float GetSpeed()
	{
		float result = projectileSpeed;
		if (projectileSpeed > maxProjectileSpeed)
		{
			result = maxProjectileSpeed;
		}
		return result;
	}

	protected unsafe override void StepMovement()
	{
		//IL_0008: Expected O, but got Ref
		//IL_0041: Expected O, but got Ref
		//IL_007d: Expected O, but got I4
		//IL_00da: Expected O, but got Ref
		//IL_00e8: Expected O, but got Ref
		//IL_0128: Expected O, but got Ref
		//IL_02e0: Expected I, but got O
		//IL_02ee: Expected O, but got Ref
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Expected O, but got Unknown
		//IL_01be: Expected O, but got Ref
		//IL_01cc: Expected O, but got Ref
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		//IL_024e: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		//IL_026f: Expected O, but got Unknown
		//IL_0287: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		Transform transform = base.transform;
		Vector3 position = transform.position;
		_ = position.x;
		_ = position.z;
		Vector3 position2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		int num = Physics.OverlapSphereNonAlloc(position2, projectileRadius, enemyCollidersBuffer);
		bool flag = num <= 0;
		bool flag2 = false;
		object obj3 = 0;
		if (!flag)
		{
			bool flag4;
			do
			{
				Collider[] array = enemyCollidersBuffer;
				nint num2 = (nint)typeof(Vector3);
				Vector3 normal = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v549 @ rax_v20 (Il2CppClass<UnityEngine.Vector3>)+B8]");
				nint num3 = 0;
				_ = Vector3.zeroVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v550 @ rax_v21 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
				_ = 0;
				bool flag3 = base.CheckCollision(array[obj3], normal);
				flag2 = flag3;
				if (flag3)
				{
					break;
				}
				obj3++;
				flag4 = (nint)obj3 < num;
				flag2 = flag3;
			}
			while (flag4);
		}
		Vector3 movementDirection = GetMovementDirection();
		object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		object obj5 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
		_ = movementDirection.x;
		_ = movementDirection.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
		Vector3 velocity = rb.velocity;
		object obj6 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
		_ = velocity.x;
		_ = velocity.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		float fixedDeltaTime = Time.fixedDeltaTime;
		float num4 = fixedDeltaTime * velocity.x;
		projectileSpeed = num4;
		if (!flag2)
		{
			Transform transform2 = base.transform;
			Vector3 position3 = transform2.position;
			GameManager instance = GameManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
			Vector3 vector = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
			Vector3 origin = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v137 @ rax_v30+8]");
			_ = 0;
			_ = position3.x;
			_ = position3.z;
			float maxDistance = default(float);
			int layerMask = default(int);
			QueryTriggerInteraction queryTriggerInteraction = default(QueryTriggerInteraction);
			int num5 = Physics.SphereCastNonAlloc(origin, projectileRadius, vector, ProjectileBase.raycastBuffer, maxDistance, layerMask, queryTriggerInteraction);
			if (num5 > 0)
			{
				RaycastHit raycastHit = (RaycastHit)(ProjectileBase.raycastBuffer + 32);
				Collider collider = ((RaycastHit*)raycastHit)->collider;
				object obj7 = ProjectileBase.raycastBuffer + 32;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
				Vector3 normal2 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v658 @ rax_v47+8]");
				_ = 0;
				bool flag5 = base.CheckCollision(collider, normal2);
			}
		}
	}

	protected override bool HitEnemy(Collider collider, Vector3 normal)
	{
		ExplodeFlask();
		return true;
	}

	protected override void HitOther(Collider collider, Vector3 normal)
	{
		ExplodeFlask();
	}

	private float GetExplosionRadius()
	{
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		return attackSizeMultiplier * explosionRadius;
	}

	private float GetPoisonDuration()
	{
		return WeaponUtility.GetDuration(weaponBase);
	}

	private int GetNumPoisonStacks()
	{
		//IL_0067: Expected I4, but got O
		//IL_0059: Expected I4, but got F8
		if (weaponBase != null)
		{
			float value = weaponBase.GetValue(EStat.DamageMultiplier);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtss2sd xmm0,xmm6\"");
			double num = Math.Floor(0.0);
			return (int)num;
		}
		NullReferenceException ex = new NullReferenceException();
		return (int)ex;
	}

	private unsafe void ExplodeFlask()
	{
		//IL_0008: Expected O, but got Ref
		//IL_006d: Expected O, but got Ref
		//IL_00f6: Expected O, but got Ref
		//IL_016d: Expected O, but got Ref
		//IL_019b: Expected O, but got I4
		//IL_040a: Expected O, but got I
		//IL_01d6: Expected O, but got I
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_0204: Expected O, but got I
		//IL_0254: Expected O, but got Ref
		//IL_0254: Expected O, but got I
		//IL_0272: Expected O, but got I
		//IL_029c: Expected O, but got I4
		//IL_0306: Expected O, but got I
		//IL_02cc: Expected I4, but got F4
		//IL_02cc: Expected O, but got I
		//IL_02d5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02da: Expected O, but got Unknown
		//IL_034b: Expected O, but got Ref
		//IL_034b: Expected O, but got I
		//IL_0396: Expected I4, but got F4
		//IL_0396: Expected O, but got Ref
		//IL_0396: Expected O, but got Ref
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		Transform transform = effect.transform;
		transform.parentInternal = null;
		Transform transform2 = effect.transform;
		Transform transform3 = base.transform;
		Vector3 position = transform3.position;
		float num = default(float);
		transform2.position = (Vector3)(&num);
		GameObject gameObject = effect.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = effect.gameObject;
		gameObject2.SetActive(value: true);
		Transform transform4 = effect.transform;
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		transform4.localScale = (Vector3)(&num);
		effect.Play();
		Transform transform5 = base.transform;
		Vector3 position2 = transform5.position;
		float attackSizeMultiplier2 = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float range = attackSizeMultiplier2 * explosionRadius;
		int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&num), range, out System.Runtime.CompilerServices.Unsafe.As<object, Collider[]>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 80)));
		if (enemiesInRadiusSafe > 0)
		{
			object obj3 = 0;
			num = position2.x;
			float num2 = default(float);
			float x = default(float);
			float num3 = default(float);
			float num4 = default(float);
			float num5 = default(float);
			do
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+50]");
				object obj4 = 0;
				ref Enemy enemy = ref System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 64));
				EnemyManager instance = EnemyManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ r10_v5+20+v127 @ r12_v6*8]");
				if (instance.GetEnemy((Collider)0, out enemy))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
					Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
					Transform transform6 = MyPlayer.Instance.transform;
					Vector3 position3 = transform6.position;
					WeaponBase obj5 = weaponBase;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
					DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj5, this, (Enemy)0, (Vector3)(&num), num2);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
					((Enemy)0).DamageFromPlayerWeapon(damageContainer);
					int numPoisonStacks = GetNumPoisonStacks();
					bool flag = numPoisonStacks <= 0;
					object obj6 = 0;
					if (!flag)
					{
						do
						{
							float poisonDuration = GetPoisonDuration();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
							((Enemy)0).AddDebuff(EDebuff.Poison, damageContainer, poisonDuration, (int)num2);
							obj6++;
						}
						while ((nint)obj6 < numPoisonStacks);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v6 @ rbp_v1+40]");
					object obj7 = 0;
					Transform transform7 = MyPlayer.Instance.transform;
					Vector3 position4 = transform7.position;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v251 @ rax_v48+50]");
					range = ((Collider)0).ClosestPoint((Vector3)(&x)).x;
					attackSizeMultiplier2 = GetMovementDirection().x;
					weaponAttack.ProjectileHit((Vector3)(&num3), (Vector3)(&num4), hitEnemy: true, (byte)(int)num2 != 0);
					x = position4.x;
					num = num5;
				}
				obj3++;
			}
			while ((nint)obj3 < enemiesInRadiusSafe);
		}
		ProjectileDone();
	}

	protected override void MyFixedUpdate()
	{
	}

	protected override void MyUpdate()
	{
	}

	protected override void FindMovementDirection()
	{
	}

	protected unsafe override Vector3 GetMovementDirection()
	{
		//IL_004a: Expected F4, but got O
		//IL_0045: Expected native int or pointer, but got O
		//IL_005f: Expected F4, but got I
		//IL_005a: Expected native int or pointer, but got O
		if ((object)rb != null)
		{
			Vector3 velocity = rb.velocity;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Vector3 vector = default(Vector3);
			object obj = default(object);
			((Vector3*)(nint)vector)->x = (float)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v35 @ rax_v4+8]");
			((Vector3*)(nint)vector)->z = 0f;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	public ProjectilePoisonFlask()
	{
		//IL_0040: Expected I, but got O
		defaultProjectileRadius = 0.6f;
		maxProjectileSpeed = 40f;
		explosionRadius = 5f;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v42 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		explosionSizeDefault = Vector3.zeroVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rcx_v3 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		_ = 0;
		base._002Ector();
	}

	static ProjectilePoisonFlask()
	{
		Collider[] array = new Collider[EnemyManager.maxNumEnemiesPooled];
		enemyCollidersBuffer = array;
	}
}
