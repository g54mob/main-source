using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles;
using Assets.Scripts.Objects.Pooling;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Inventory__Items__Pickups.Weapons.Attacks;

public class WeaponAttack : MonoBehaviour
{
	private sealed class _003CStartAttack_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public WeaponAttack _003C_003E4__this;

		private float _003Ctimer_003E5__2;

		private int _003Cquantity_003E5__3;

		private float _003CburstInterval_003E5__4;

		private int _003Ci_003E5__5;

		object IEnumerator<object>.Current => _003C_003E2__current;

		object IEnumerator.Current => _003C_003E2__current;

		public _003CStartAttack_003Ed__22(int _003C_003E1__state)
		{
			((IDisposable)this).Dispose();
			this._003C_003E1__state = _003C_003E1__state;
		}

		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			//IL_0014: Expected I4, but got I8
			//IL_0146: Expected I4, but got I8
			//IL_014f: Expected F4, but got I4
			//IL_0158: Expected F4, but got I4
			//IL_02aa: Expected I4, but got O
			//IL_020f: Invalid comparison between F4 and I4
			//IL_0107: Expected F4, but got I4
			//IL_0110: Expected F4, but got I4
			//IL_019c: Invalid comparison between F4 and I4
			WeaponAttack weaponAttack = _003C_003E4__this;
			float num;
			float num2;
			if (_003C_003E1__state == 0)
			{
				_003C_003E1__state = -1;
				_003Ctimer_003E5__2 = 0f;
				if ((object)_003C_003E4__this == null)
				{
					goto IL_029c;
				}
				int attackQuantity = WeaponUtility.GetAttackQuantity(weaponAttack.weaponBase);
				_003Cquantity_003E5__3 = attackQuantity;
				float burstInterval = WeaponUtility.GetBurstInterval(weaponAttack.weaponBase);
				_003CburstInterval_003E5__4 = burstInterval;
				if (weaponAttack.muzzle != null)
				{
					if ((object)weaponAttack.muzzle == null)
					{
						goto IL_029c;
					}
					weaponAttack.muzzle.Set(_003Cquantity_003E5__3, _003CburstInterval_003E5__4);
				}
				_003Ci_003E5__5 = 0;
				num = 0f;
				num2 = 0f;
				goto IL_02d7;
			}
			if (_003C_003E1__state != 1)
			{
				goto IL_02f7;
			}
			_003C_003E1__state = -1;
			num = 0f;
			num2 = 0f;
			goto IL_0305;
			IL_0305:
			while (_003CburstInterval_003E5__4 > _003Ctimer_003E5__2)
			{
				if ((object)_003C_003E4__this != null)
				{
					float burstInterval2 = WeaponUtility.GetBurstInterval(weaponAttack.weaponBase);
					if (burstInterval2 > 0f)
					{
						float num3 = _003Ctimer_003E5__2 + MyTime.deltaTime;
						_003Ctimer_003E5__2 = num3;
						_003C_003E2__current = waitEndOfFrame;
						_003C_003E1__state = 1;
						return true;
					}
					continue;
				}
				goto IL_029c;
			}
			if ((object)_003C_003E4__this == null)
			{
				goto IL_029c;
			}
			_003C_003E4__this.SpawnProjectile(_003Ci_003E5__5);
			num++;
			_003Ctimer_003E5__2 = num2;
			if (!(num < (float)weaponAttack.maxNumProjectilesWithoutInterval))
			{
				goto IL_0245;
			}
			int num4 = _003Ci_003E5__5 + 1;
			_003Ci_003E5__5 = num4;
			goto IL_02d7;
			IL_0245:
			weaponAttack.attackDone = true;
			float duration = WeaponUtility.GetDuration(weaponAttack.weaponBase);
			float num5 = duration + MyTime.time;
			float expirationTime = num5 + 0.5f;
			weaponAttack.expirationTime = expirationTime;
			goto IL_02f7;
			IL_029c:
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
			IL_02d7:
			if (_003Ci_003E5__5 >= _003Cquantity_003E5__3)
			{
				goto IL_0245;
			}
			goto IL_0305;
			IL_02f7:
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		void IEnumerator.Reset()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			NotSupportedException ex = new NotSupportedException();
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1802696E0");
			throw ex;
		}
	}

	public GameObject prefabProjectile;

	public GameObject prefabMuzzle;

	public GameObject prefabHit;

	public WeaponBase weaponBase;

	protected MyPlayer player;

	private bool attackDone;

	public float projectileSizeMultiplier;

	public Action A_SpawnedProjectile;

	public static Action<ProjectileBase> A_SpawnedProjectileSuccessfully;

	private float expirationTime;

	private bool isAttacking;

	private int maxNumProjectilesWithoutInterval;

	private float timer;

	private int attackQuantity;

	private int attackQuantityCurrent;

	private float burstInterval;

	private static readonly WaitForEndOfFrame waitEndOfFrame;

	private EnemyScanContainer lastCheckSphere;

	private EnemyScanContainer reuseContainer;

	public bool lastWasSkip;

	private float muzzleCooldown;

	private AttackMuzzle muzzle;

	public void SetAttack(WeaponBase weaponBase, MyPlayer player)
	{
		attackDone = false;
		this.weaponBase = weaponBase;
		this.player = player;
		isAttacking = true;
		attackQuantityCurrent = 0;
		int num = WeaponUtility.GetAttackQuantity(this.weaponBase);
		attackQuantity = num;
		timer = (burstInterval = WeaponUtility.GetBurstInterval(this.weaponBase));
		if (muzzle != null)
		{
			muzzle.Set(attackQuantity, burstInterval);
		}
	}

	private void StartAttackNoCoroutine()
	{
		isAttacking = true;
		attackQuantityCurrent = 0;
		int num = WeaponUtility.GetAttackQuantity(weaponBase);
		attackQuantity = num;
		timer = (burstInterval = WeaponUtility.GetBurstInterval(weaponBase));
		if (muzzle != null)
		{
			muzzle.Set(attackQuantity, burstInterval);
		}
	}

	private void FixedUpdate()
	{
		//IL_013b: Invalid comparison between I4 and F4
		if (!isAttacking || attackQuantityCurrent >= attackQuantity)
		{
			return;
		}
		float num = (timer += MyTime.fixedDeltaTime);
		if (0f < burstInterval)
		{
			if (!(num < burstInterval))
			{
				timer = 0f;
				SpawnProjectile(attackQuantityCurrent);
				int num2 = attackQuantityCurrent + 1;
				attackQuantityCurrent = num2;
			}
			if (attackQuantityCurrent < attackQuantity)
			{
				return;
			}
		}
		else if (attackQuantityCurrent < attackQuantity)
		{
			while (attackQuantityCurrent < maxNumProjectilesWithoutInterval)
			{
				SpawnProjectile(attackQuantityCurrent);
				if (++attackQuantityCurrent >= attackQuantity)
				{
					break;
				}
			}
		}
		StopAttackNoCoroutine();
	}

	private void FixedUpdateAttack()
	{
		//IL_013b: Invalid comparison between I4 and F4
		if (!isAttacking || attackQuantityCurrent >= attackQuantity)
		{
			return;
		}
		float num = (timer += MyTime.fixedDeltaTime);
		if (0f < burstInterval)
		{
			if (!(num < burstInterval))
			{
				timer = 0f;
				SpawnProjectile(attackQuantityCurrent);
				int num2 = attackQuantityCurrent + 1;
				attackQuantityCurrent = num2;
			}
			if (attackQuantityCurrent < attackQuantity)
			{
				return;
			}
		}
		else if (attackQuantityCurrent < attackQuantity)
		{
			while (attackQuantityCurrent < maxNumProjectilesWithoutInterval)
			{
				SpawnProjectile(attackQuantityCurrent);
				if (++attackQuantityCurrent >= attackQuantity)
				{
					break;
				}
			}
		}
		StopAttackNoCoroutine();
	}

	private void StopAttackNoCoroutine()
	{
		isAttacking = false;
		attackDone = true;
		float duration = WeaponUtility.GetDuration(weaponBase);
		float num = duration + MyTime.time;
		float num2 = num + 0.5f;
		expirationTime = num2;
	}

	private IEnumerator StartAttack()
	{
		_003CStartAttack_003Ed__22 obj = new _003CStartAttack_003Ed__22(0);
		obj._003C_003E1__state = 0;
		obj._003C_003E4__this = this;
		return obj;
	}

	protected unsafe virtual void SpawnProjectile(int projectileIndex)
	{
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Expected O, but got Unknown
		//IL_0116: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Expected O, but got Unknown
		//IL_0324: Unknown result type (might be due to invalid IL or missing references)
		//IL_0329: Expected O, but got Unknown
		//IL_0166: Unknown result type (might be due to invalid IL or missing references)
		//IL_016b: Expected Ref, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Expected O, but got Unknown
		//IL_0393: Unknown result type (might be due to invalid IL or missing references)
		//IL_0398: Expected O, but got Unknown
		//IL_0407: Expected I, but got O
		//IL_0428: Unknown result type (might be due to invalid IL or missing references)
		//IL_042d: Expected O, but got Unknown
		//IL_044a: Expected O, but got I
		//IL_0467: Expected O, but got I
		//IL_04b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bb: Expected O, but got Unknown
		_ = 0;
		float weaponRange = WeaponUtility.GetWeaponRange(this.weaponBase);
		WeaponBase weaponBase = this.weaponBase;
		WeaponData weaponData = weaponBase.weaponData;
		object obj = default(object);
		if (weaponData.onlySpawnWhenCloseEnemies)
		{
			Transform transform = base.transform;
			Vector3 position = transform.position;
			Vector3 position2 = (Vector3)(obj - 64);
			_ = position.x;
			_ = position.z;
			reuseContainer.Set(position2, MyTime.time, weaponRange);
			if (!reuseContainer.IsEqual(lastCheckSphere))
			{
				EnemyScanContainer enemyScanContainer = reuseContainer;
				_ = enemyScanContainer.position;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v181 @ rax_v49 (Assets.Scripts.Inventory__Items__Pickups.Weapons.EnemyScanContainer)+20]");
				_ = 0;
				float range = enemyScanContainer.range;
				Vector3 position3 = (Vector3)(obj - 64);
				lastCheckSphere.Set(position3, enemyScanContainer.time, enemyScanContainer.range);
				Transform transform2 = base.transform;
				Vector3 position4 = transform2.position;
				ref Collider[] buffer = ref *(Collider[]*)(obj + 48);
				_ = position4.x;
				_ = position4.z;
				Vector3 pos = (Vector3)(obj - 64);
				int enemiesInRadiusSafe = EnemyTargeting.GetEnemiesInRadiusSafe(this, pos, weaponRange, out buffer);
				bool flag = enemiesInRadiusSafe == 0;
				lastWasSkip = flag;
				if (enemiesInRadiusSafe == 0)
				{
					return;
				}
			}
			else
			{
				bool flag2 = lastWasSkip;
				float range = weaponRange;
				if (flag2)
				{
					return;
				}
			}
		}
		ProjectileBase projectile = PoolManager.Instance.GetProjectile(this);
		if (projectile != null)
		{
			GameObject gameObject = projectile.gameObject;
			gameObject.SetActive(value: true);
			Transform transform3 = projectile.transform;
			Transform transform4 = prefabProjectile.transform;
			Vector3 localScale = transform4.localScale;
			float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(this.weaponBase);
			float num = attackSizeMultiplier * projectileSizeMultiplier;
			float num2 = num - projectileSizeMultiplier;
			float num3 = num2 + 1f;
			float num4 = num3 * localScale.x;
			float num5 = num3 * localScale.y;
			float num6 = num3 * localScale.z;
			Vector3 localScale2 = (Vector3)(obj - 64);
			transform3.localScale = localScale2;
			Transform transform5 = projectile.transform;
			MyPlayer myPlayer = player;
			PlayerMovement playerMovement = myPlayer.playerMovement;
			Quaternion rotation = playerMovement.orientation.rotation;
			Quaternion rotation2 = (Quaternion)(obj - 64);
			_ = rotation.x;
			transform5.rotation = rotation2;
			Transform transform6 = projectile.transform;
			Transform transform7 = player.transform;
			Vector3 position5 = transform7.position;
			WeaponBase weaponBase2 = this.weaponBase;
			WeaponData weaponData2 = weaponBase2.weaponData;
			nint num7 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v193 @ rax_v30 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v19 (WeaponData)+C4]");
			object obj2 = 0 * Vector3.upVector;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v19 (WeaponData)+C4]");
			nint num9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
			object obj3 = num9 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v174 @ rdx_v19 (WeaponData)+C4]");
			nint num10 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v210 @ rcx_v28 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
			object obj4 = num10 * 0;
			float num11 = (float)obj2 + position5.x;
			float num12 = (float)obj3 + position5.y;
			float num13 = (float)obj4 + position5.z;
			Vector3 position6 = (Vector3)(obj - 64);
			transform6.position = position6;
			projectile.Set(this.weaponBase, this, projectileIndex);
			Action a_SpawnedProjectile = A_SpawnedProjectile;
			if (A_SpawnedProjectile != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v632.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
	}

	public float GetSize()
	{
		float attackSizeMultiplier = WeaponUtility.GetAttackSizeMultiplier(weaponBase);
		float num = attackSizeMultiplier * projectileSizeMultiplier;
		float num2 = num - projectileSizeMultiplier;
		return num2 + 1f;
	}

	public void ProjectileDone(ProjectileBase projectile)
	{
		GameObject gameObject = projectile.gameObject;
		gameObject.SetActive(value: false);
		GameObject projectile2 = projectile.gameObject;
		PoolManager.Instance.ReturnProjectile(this, projectile2);
	}

	public unsafe void ProjectileHit(Vector3 hitPos, Vector3 moveDir, bool hitEnemy, bool useSfx)
	{
		//IL_004a: Expected O, but got Ref
		//IL_004a: Expected O, but got Ref
		if (prefabHit != null)
		{
			object obj = default(object);
			object obj2 = default(object);
			EWeapon eWeapon = default(EWeapon);
			GameObject weaponHitEffect = default(GameObject);
			bool useSfx2 = default(bool);
			EffectManager.Instance.EnemyHitEffect((Vector3)(&obj), (Vector3)(&obj2), hitEnemy, eWeapon, weaponHitEffect, useSfx2);
		}
	}

	public unsafe void SuccessfullySpawnedProjectile(ProjectileBase projectile)
	{
		//IL_00a2: Expected F4, but got I4
		//IL_01b0: Expected O, but got Ref
		//IL_01b0: Expected O, but got Ref
		//IL_02dc: Expected O, but got Ref
		//IL_032e: Expected O, but got Ref
		if (prefabMuzzle != null)
		{
			WeaponBase weaponBase = this.weaponBase;
			WeaponData weaponData = weaponBase.weaponData;
			if (!FxUtility.muzzleCooldowns.ContainsKey(weaponData.eWeapon))
			{
				WeaponBase weaponBase2 = this.weaponBase;
				WeaponData weaponData2 = weaponBase2.weaponData;
				((Dictionary<System.Int32Enum, float>)(object)FxUtility.muzzleCooldowns).Add((System.Int32Enum)weaponData2.eWeapon, 0f);
				float num = 0f;
			}
			WeaponBase weaponBase3 = this.weaponBase;
			WeaponData weaponData3 = weaponBase3.weaponData;
			float num2 = ((Dictionary<System.Int32Enum, float>)(object)FxUtility.muzzleCooldowns).get_Item((System.Int32Enum)weaponData3.eWeapon);
			if (!(MyTime.time < num2))
			{
				WeaponBase weaponBase4 = this.weaponBase;
				WeaponData weaponData4 = weaponBase4.weaponData;
				float num = MyTime.time + muzzleCooldown;
				((Dictionary<System.Int32Enum, float>)(object)FxUtility.muzzleCooldowns).set_Item((System.Int32Enum)weaponData4.eWeapon, num);
				object obj = default(object);
				object obj2 = default(object);
				if (!(muzzle != null))
				{
					Transform transform = projectile.transform;
					Vector3 position = transform.position;
					Transform transform2 = projectile.transform;
					Quaternion rotation = transform2.rotation;
					GameObject gameObject = UnityEngine.Object.Instantiate(prefabMuzzle, (Vector3)(&obj), (Quaternion)(&obj2));
					AttackMuzzle component = gameObject.GetComponent<AttackMuzzle>();
					muzzle = component;
					int quantity = WeaponUtility.GetAttackQuantity(this.weaponBase);
					num2 = WeaponUtility.GetBurstInterval(this.weaponBase);
					muzzle.Set(quantity, num2);
					num = num2;
				}
				else
				{
					GameObject gameObject2 = muzzle.gameObject;
					if (!gameObject2.activeSelf)
					{
						GameObject gameObject3 = muzzle.gameObject;
						gameObject3.SetActive(value: true);
					}
					Transform transform3 = muzzle.transform;
					Transform transform4 = projectile.transform;
					Vector3 position2 = transform4.position;
					transform3.position = (Vector3)(&obj);
					Transform transform5 = muzzle.transform;
					Transform transform6 = projectile.transform;
					num2 = transform6.rotation.x;
					transform5.rotation = (Quaternion)(&obj2);
				}
				muzzle.Play();
			}
		}
		Action<ProjectileBase> a_SpawnedProjectileSuccessfully = A_SpawnedProjectileSuccessfully;
		if (A_SpawnedProjectileSuccessfully != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v195 @ r9_v2 (System.Action`1<Assets.Scripts.Inventory__Items__Pickups.Weapons.Projectiles.ProjectileBase>)+18] (should have been resolved before IL gen)");
		}
	}

	private void Update()
	{
		if (attackDone && !(MyTime.time < expirationTime))
		{
			if (muzzle != null)
			{
				GameObject gameObject = muzzle.gameObject;
				gameObject.SetActive(value: false);
			}
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
			PoolManager.Instance.ReturnAttack(this);
		}
	}

	private void AttackTimeout()
	{
		if (muzzle != null)
		{
			GameObject gameObject = muzzle.gameObject;
			gameObject.SetActive(value: false);
		}
		GameObject gameObject2 = base.gameObject;
		gameObject2.SetActive(value: false);
		PoolManager.Instance.ReturnAttack(this);
	}

	private unsafe Vector3 GetProjectilePosition()
	{
		//IL_009a: Expected I, but got O
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Expected O, but got Unknown
		//IL_00dd: Expected O, but got I
		//IL_00fa: Expected O, but got I
		//IL_013e: Expected native int or pointer, but got O
		//IL_014b: Expected native int or pointer, but got O
		//IL_0158: Expected native int or pointer, but got O
		if ((object)player != null)
		{
			Transform transform = player.transform;
			if ((object)transform != null)
			{
				Vector3 position = transform.position;
				WeaponBase weaponBase = this.weaponBase;
				if (this.weaponBase != null)
				{
					WeaponData weaponData = weaponBase.weaponData;
					if ((object)weaponBase.weaponData != null)
					{
						nint num = (nint)typeof(Vector3);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v142 @ rax_v7 (Il2CppClass<UnityEngine.Vector3>)+B8]");
						nint num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v4 (WeaponData)+C4]");
						object obj = 0 * Vector3.upVector;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v4 (WeaponData)+C4]");
						nint num3 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
						object obj2 = num3 * 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v43 @ rdx_v4 (WeaponData)+C4]");
						nint num4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v126 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
						object obj3 = num4 * 0;
						float x = (float)obj + position.x;
						float y = (float)obj2 + position.y;
						float z = (float)obj3 + position.z;
						Vector3 vector = default(Vector3);
						((Vector3*)(nint)vector)->x = x;
						((Vector3*)(nint)vector)->y = y;
						((Vector3*)(nint)vector)->z = z;
						return vector;
					}
				}
			}
		}
		return (Vector3)new NullReferenceException();
	}

	private unsafe Quaternion GetProjectileRotation()
	{
		//IL_0099: Expected native int or pointer, but got O
		MyPlayer myPlayer = player;
		if ((object)player != null)
		{
			PlayerMovement playerMovement = myPlayer.playerMovement;
			if ((object)myPlayer.playerMovement != null && (object)playerMovement.orientation != null)
			{
				Quaternion quaternion = default(Quaternion);
				((Quaternion*)(nint)quaternion)->x = playerMovement.orientation.rotation.x;
				return quaternion;
			}
		}
		return (Quaternion)new NullReferenceException();
	}

	public unsafe WeaponAttack()
	{
		//IL_0072: Expected O, but got Ref
		//IL_004b: Expected O, but got Ref
		projectileSizeMultiplier = 1f;
		maxNumProjectilesWithoutInterval = 80;
		Vector3 vector = default(Vector3);
		EnemyScanContainer enemyScanContainer = new EnemyScanContainer((Vector3)(&vector), -1f, -1f);
		lastCheckSphere = enemyScanContainer;
		EnemyScanContainer enemyScanContainer2 = new EnemyScanContainer((Vector3)(&vector), -1f, -1f);
		reuseContainer = enemyScanContainer2;
		muzzleCooldown = 0.1f;
		base._002Ector();
	}

	static WeaponAttack()
	{
		WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
		waitEndOfFrame = waitForEndOfFrame;
	}
}
