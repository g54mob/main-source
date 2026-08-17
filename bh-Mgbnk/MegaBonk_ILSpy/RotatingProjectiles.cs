using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using Utility;

public class RotatingProjectiles : MonoBehaviour
{
	public GameObject prefab;

	public float baseProjectileRadius = 1f;

	public AudioSource audioSpawn;

	public AudioSource audioLoop;

	private float baseLoopVolume;

	private List<ParticleSystem> prefabs;

	private int amount;

	private float projectileRadius;

	private float rotationSpeed = 50f;

	private const int maxQuantity = 50;

	private float maxRotationSpeed = 450f;

	private Vector3[] rockPositions;

	private List<RaycastUtility.ConeSphere> debugSpheres;

	private Dictionary<int, Dictionary<Collider, float>> projectileEnemiesCooldowns;

	private float enemyHitCooldown;

	public WeaponBase weaponBase;

	private float fadeTimer;

	private float fadeTime;

	private bool isActive;

	private float startTime;

	private float endTime;

	private float duration;

	public float baseDistance;

	private Vector3 defaultScale;

	private Vector3 projectileScale;

	private float scaleMultiplier;

	private float distance;

	public void SetWeapon(WeaponBase weaponBase)
	{
		this.weaponBase = weaponBase;
		TryInit();
	}

	private void TryInit()
	{
		//IL_007b: Expected O, but got F4
		if (prefabs == null)
		{
			List<ParticleSystem> list = new List<ParticleSystem>();
			prefabs = list;
			ParticleSystem component = prefab.GetComponent<ParticleSystem>();
			prefabs.Add(component);
			Transform transform = prefab.transform;
			Vector3 localScale = transform.localScale;
			defaultScale = (Vector3)localScale.x;
			_ = localScale.z;
			projectileRadius = baseProjectileRadius;
			float volume = audioLoop.volume;
			baseLoopVolume = volume;
		}
	}

	private unsafe void Update()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_00ca: Invalid comparison between I4 and F4
		//IL_0115: Expected F4, but got I4
		//IL_0071: Invalid comparison between I4 and F4
		//IL_0323: Invalid comparison between I4 and F4
		//IL_00bc: Expected F4, but got I4
		//IL_0063: Expected F4, but got I4
		//IL_03ad: Invalid comparison between I4 and F4
		//IL_0187: Expected F4, but got I4
		//IL_02ac: Expected O, but got Ref
		//IL_01d0: Expected O, but got Ref
		//IL_03f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Expected O, but got Unknown
		//IL_0409: Expected O, but got Ref
		//IL_01f3: Expected O, but got Ref
		//IL_022f: Expected O, but got Ref
		//IL_0267: Expected F4, but got I4
		object obj2 = default(object);
		object obj = obj2 - 40;
		TryInit();
		if (fadeTime > fadeTimer)
		{
			float num = fadeTimer + MyTime.deltaTime;
			if (!(0f > num))
			{
				if (num > 1f)
				{
					num = 1f;
				}
			}
			else
			{
				num = 0f;
			}
			fadeTimer = num;
		}
		bool flag = !isActive;
		float num2 = fadeTimer / fadeTime;
		if (!flag)
		{
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
		}
		else
		{
			if (!(0f > num2))
			{
				if (num2 > 1f)
				{
					num2 = 1f;
				}
			}
			else
			{
				num2 = 0f;
			}
			float num3 = num2 * -1f;
			num2 = num3 + 1f;
		}
		float volume = num2 * baseLoopVolume;
		audioLoop.volume = volume;
		float num4 = num2 * (float)projectileScale;
		float num5 = endTime - startTime;
		float num6 = MyTime.time - startTime;
		float num7 = num6 / num5;
		if (!(0f > num7))
		{
			if (num7 > 1f)
			{
				num7 = 1f;
			}
		}
		else
		{
			num7 = 0f;
		}
		float num11 = default(float);
		if (amount > 0)
		{
			int num8 = 0;
			float num9 = num4;
			Vector3 forwardVector = default(Vector3);
			float num10 = default(float);
			bool flag2;
			do
			{
				ParticleSystem particleSystem = prefabs.get_Item(num8);
				Transform transform = particleSystem.transform;
				_ = Quaternion.Internal_FromEulerRad((Vector3)(&num9)).x;
				Quaternion quaternion = (Quaternion)(obj - 128);
				Vector3 vector = quaternion * (Vector3)(&forwardVector);
				transform.localPosition = (Vector3)(&num10);
				ParticleSystem particleSystem2 = prefabs.get_Item(num8);
				Transform transform2 = particleSystem2.transform;
				transform2.localScale = (Vector3)(&num11);
				num8++;
				flag2 = num8 < amount;
				num11 = num4;
				forwardVector = Vector3.forwardVector;
				num9 = 0f;
			}
			while (flag2);
		}
		Transform transform3 = base.transform;
		float angle = rotationSpeed * MyTime.deltaTime;
		transform3.Rotate((Vector3)(&num11), angle, Space.Self);
	}

	private bool CanHitbox()
	{
		//IL_0053: Invalid comparison between F4 and I4
		if (isActive)
		{
			return true;
		}
		bool flag = fadeTime < fadeTimer;
		float num = fadeTime - fadeTimer;
		bool flag2 = num == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		return flag4 & flag3;
	}

	private void FixedUpdate()
	{
		StepHitboxes();
	}

	private unsafe void StepHitboxes()
	{
		//IL_0238: Expected O, but got I4
		//IL_0138: Expected O, but got Ref
		//IL_0186: Unknown result type (might be due to invalid IL or missing references)
		//IL_018b: Expected O, but got Unknown
		//IL_01fc: Expected O, but got I4
		//IL_0204: Unknown result type (might be due to invalid IL or missing references)
		//IL_0209: Expected O, but got Unknown
		if (!isActive && !(fadeTime > fadeTimer))
		{
			return;
		}
		List<RaycastUtility.ConeSphere> list = debugSpheres;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ rcx_v3 (System.Collections.Generic.List`1<Utility.RaycastUtility+ConeSphere>)+1C]");
		_ = (nint)0 + (nint)1;
		_ = 0;
		List<ParticleSystem> list2 = prefabs;
		Collider[] buffer = null;
		int num = 0;
		Collider[] array = null;
		float x = default(float);
		while ((nint)array < list2._size)
		{
			ParticleSystem particleSystem = prefabs.get_Item(num);
			GameObject gameObject = particleSystem.gameObject;
			if (gameObject.activeInHierarchy)
			{
				ParticleSystem particleSystem2 = prefabs.get_Item(num);
				Transform transform = particleSystem2.transform;
				Vector3 position = transform.position;
				int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, (Vector3)(&x), projectileRadius, out buffer);
				bool flag = enemiesInRadiusSafe <= 0;
				Collider[] array2 = null;
				if (!flag)
				{
					do
					{
						bool flag2 = HitEnemy(num, buffer[(object)array2]);
						array2 = (Collider[])(array2 + 1);
					}
					while ((nint)array2 < enemiesInRadiusSafe);
				}
				Vector3[] array3 = rockPositions;
				ParticleSystem particleSystem3 = prefabs.get_Item(num);
				Transform transform2 = particleSystem3.transform;
				Vector3 position2 = transform2.position;
				object obj = num * 2;
				object obj2 = num + obj;
				_ = position2.x;
				_ = position2.z;
				x = position.x;
			}
			list2 = prefabs;
			num++;
			array = (Collider[])num;
		}
	}

	private unsafe bool HitEnemy(int projectileIndex, Collider collider)
	{
		//IL_0008: Expected O, but got Ref
		//IL_0504: Expected I4, but got O
		//IL_01b7: Expected O, but got I
		//IL_01ff: Expected O, but got I
		//IL_0299: Expected O, but got Ref
		//IL_02a7: Expected O, but got Ref
		//IL_02d8: Expected O, but got Ref
		//IL_030a: Expected O, but got I
		//IL_0348: Expected O, but got I
		//IL_0385: Expected O, but got Ref
		//IL_03c0: Expected O, but got I
		//IL_043b: Expected O, but got Ref
		//IL_044e: Expected O, but got Ref
		//IL_0491: Expected I4, but got F4
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (!(collider != null))
		{
			goto IL_04e8;
		}
		if (projectileEnemiesCooldowns != null)
		{
			if (!projectileEnemiesCooldowns.ContainsKey(projectileIndex))
			{
				Dictionary<Collider, float> value = new Dictionary<Collider, float>();
				if (projectileEnemiesCooldowns == null)
				{
					goto IL_04f6;
				}
				((Dictionary<int, object>)(object)projectileEnemiesCooldowns).Add(projectileIndex, (object)value);
			}
			if (projectileEnemiesCooldowns != null)
			{
				Dictionary<Collider, float> dictionary = projectileEnemiesCooldowns.get_Item(projectileIndex);
				if (dictionary != null)
				{
					if (dictionary.TryGetValue(collider, out System.Runtime.CompilerServices.Unsafe.As<object, float>(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref obj2, 119))))
					{
						float num = MyTime.time;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1+77]");
						float num2 = num - 0f;
						if (enemyHitCooldown > num2)
						{
							goto IL_04e8;
						}
					}
					if ((object)EnemyManager.Instance != null)
					{
						if (!EnemyManager.Instance.GetEnemy(collider, out System.Runtime.CompilerServices.Unsafe.As<object, Enemy>(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 41))))
						{
							goto IL_04e8;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
							if (((Enemy)0).IsDead())
							{
								goto IL_04e8;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
							if ((nint)0 != 0)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
								Vector3 centerPosition = ((Enemy)0).GetCenterPosition();
								if ((object)MyPlayer.Instance != null)
								{
									Transform transform = MyPlayer.Instance.transform;
									if ((object)transform != null)
									{
										Vector3 position = transform.position;
										float num3 = centerPosition.x - position.x;
										float num4 = centerPosition.y - position.y;
										float num5 = centerPosition.z - position.z;
										object obj3 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
										object obj4 = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
										Vector3 direction = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rax_v25+8]");
										_ = 0;
										WeaponBase obj5 = this.weaponBase;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
										float num6 = default(float);
										DamageContainer damageContainer = WeaponUtility.GetDamageContainer(obj5, null, (Enemy)0, direction, num6);
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
										if ((nint)0 != 0)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
											((Enemy)0).DamageFromPlayerWeapon(damageContainer);
											Transform transform2 = base.transform;
											if ((object)transform2 != null)
											{
												Vector3 position2 = transform2.position;
												if ((object)collider != null)
												{
													Vector3 position3 = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
													_ = position2.x;
													_ = position2.z;
													Vector3 vector = collider.ClosestPoint(position3);
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v8 @ rbp_v1-29]");
													bool hitEnemy = (UnityEngine.Object)0;
													WeaponBase weaponBase = this.weaponBase;
													if (this.weaponBase != null && (object)weaponBase.weaponData != null && (object)EffectManager.Instance != null)
													{
														Vector3 moveDir = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 25));
														Vector3 hitPos = (Vector3)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.SubtractByteOffset(ref obj2, 9));
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v656 @ rax_v25+8]");
														_ = 0;
														_ = vector.x;
														_ = vector.z;
														GameObject weaponHitEffect = default(GameObject);
														bool useSfx = default(bool);
														EffectManager.Instance.EnemyHitEffect(hitPos, moveDir, hitEnemy, (EWeapon)num6, weaponHitEffect, useSfx);
														if (projectileEnemiesCooldowns != null)
														{
															Dictionary<Collider, float> dictionary2 = projectileEnemiesCooldowns.get_Item(projectileIndex);
															if (dictionary2 != null)
															{
																((Dictionary<object, float>)(object)dictionary2).set_Item((object)collider, MyTime.time);
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
		goto IL_04f6;
		IL_04e8:
		return false;
		IL_04f6:
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnDrawGizmosSelected()
	{
	}

	public void Show()
	{
		fadeTimer = 0f;
		isActive = true;
		audioSpawn.Play();
		audioLoop.Play();
		startTime = MyTime.time;
		float num = MyTime.time + duration;
		endTime = num;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: true);
	}

	public void Hide()
	{
		fadeTimer = 0f;
		isActive = false;
	}

	public void SetAmount(int newAmount)
	{
		TryInit();
		int num;
		if (newAmount >= 50)
		{
			amount = 49;
			num = 0;
		}
		else
		{
			bool flag = newAmount >= 0;
			int num2 = newAmount;
			if (!flag)
			{
				num2 = 0;
			}
			amount = num2;
			bool flag2 = num2 <= 0;
			num = 0;
			if (flag2)
			{
				goto IL_0121;
			}
		}
		do
		{
			List<ParticleSystem> list = prefabs;
			if (num >= list._size)
			{
				Transform parent = base.transform;
				GameObject gameObject = UnityEngine.Object.Instantiate(prefab, parent);
				ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
				list.Add(component);
			}
			ParticleSystem particleSystem = prefabs.get_Item(num);
			GameObject gameObject2 = particleSystem.gameObject;
			gameObject2.SetActive(value: true);
			num++;
		}
		while (num < amount);
		goto IL_0121;
		IL_0121:
		List<ParticleSystem> list2 = prefabs;
		int num3 = 0;
		for (int num4 = 0; num4 < list2._size; num4 = num3)
		{
			if (num3 >= amount)
			{
				ParticleSystem particleSystem2 = prefabs.get_Item(num3);
				GameObject gameObject3 = particleSystem2.gameObject;
				gameObject3.SetActive(value: false);
			}
			list2 = prefabs;
			num3++;
		}
	}

	public void SetSize(float multiplier)
	{
		TryInit();
		scaleMultiplier = multiplier;
		float num = multiplier;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (RotatingProjectiles)+AC]");
		float num2 = num * 0f;
		float num3 = multiplier * baseProjectileRadius;
		float num4 = multiplier * 0.33f;
		projectileRadius = num3;
		float num5 = num3 + baseDistance;
		Vector3 vector = default(Vector3);
		projectileScale = vector;
		float num6 = num5 + num4;
		distance = num6;
	}

	public void SetSpeed(float speed)
	{
		//IL_0009: Invalid comparison between I4 and F4
		//IL_0018: Expected F4, but got I4
		bool flag = 0f > speed;
		float num = 0f;
		if (!flag)
		{
			num = maxRotationSpeed;
			if (!(speed > maxRotationSpeed))
			{
				rotationSpeed = speed;
				return;
			}
		}
		rotationSpeed = num;
	}

	public void SetDuration(float duration)
	{
		this.duration = duration;
	}

	public RotatingProjectiles()
	{
		Vector3[] array = new Vector3[50];
		rockPositions = array;
		List<RaycastUtility.ConeSphere> list = new List<RaycastUtility.ConeSphere>();
		list._002Ector();
		debugSpheres = list;
		Dictionary<int, Dictionary<Collider, float>> dictionary = new Dictionary<int, Dictionary<Collider, float>>();
		projectileEnemiesCooldowns = dictionary;
		enemyHitCooldown = 0.4f;
		fadeTime = 0.25f;
		baseDistance = 4f;
		scaleMultiplier = 1f;
		base._002Ector();
	}
}
