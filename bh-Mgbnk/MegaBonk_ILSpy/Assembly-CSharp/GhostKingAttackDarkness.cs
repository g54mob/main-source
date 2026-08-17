using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Combat;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks;
using Assets.Scripts.Game.Combat.EnemySpecialAttacks.Implementations;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using MilkShake;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class GhostKingAttackDarkness : EnemySpecialAttackPrefab
{
	public GameObject blastSphere;

	public AudioSource audioStart;

	public AudioSource audioCharge;

	public AudioSource audioBlast;

	public AudioSource audioLampSave;

	public ParticleSystem[] chargeParticles;

	public ParticleSystem blastParticles;

	public ShakePreset shakePreset;

	public static Action<float> A_LightIntensity;

	public static Action A_DarknessAttackSetEnemyTarget;

	public static Action A_Explode;

	private float timer;

	private float explodeAtTime;

	private float unchargeTime = 1.5f;

	private float sphereScaleBeforeBlast = 10f;

	private bool hasBlasted;

	private bool hasDamaged;

	private float blastToDamageDelay = 0.1f;

	private bool enemyDied;

	protected override void Init()
	{
		//IL_0042: Expected O, but got I4
		//IL_004b: Expected O, but got I4
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_0075: Expected O, but got Unknown
		EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
		timer = 0f;
		ParticleSystem[] array = chargeParticles;
		explodeAtTime = enemySpecialAttack.attackChargeTime;
		hasBlasted = false;
		enemyDied = false;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			array[obj].enableEmission = true;
			obj++;
			obj2 = obj;
		}
		audioStart.Play();
		audioCharge.Play();
		Action a_DarknessAttackSetEnemyTarget = A_DarknessAttackSetEnemyTarget;
		if (A_DarknessAttackSetEnemyTarget != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v207.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
	}

	private unsafe void FixedUpdate()
	{
		//IL_0045: Expected O, but got Ref
		//IL_006a: Expected O, but got I4
		//IL_0073: Expected O, but got I4
		//IL_007c: Expected O, but got I4
		//IL_00ca: Expected O, but got Ref
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Expected O, but got Unknown
		//IL_00ee: Expected O, but got I4
		//IL_03d2: Invalid comparison between I4 and F4
		//IL_0189: Invalid comparison between I4 and F4
		//IL_041d: Expected F4, but got I4
		//IL_01d4: Expected F4, but got I4
		//IL_0711: Expected I, but got O
		//IL_072f: Expected I, but got O
		//IL_091d: Invalid comparison between I4 and F4
		//IL_0233: Expected F4, but got I4
		//IL_0612: Unknown result type (might be due to invalid IL or missing references)
		//IL_0617: Expected O, but got Unknown
		//IL_0621: Unknown result type (might be due to invalid IL or missing references)
		//IL_0626: Expected O, but got Unknown
		//IL_073d: Invalid comparison between I4 and F4
		//IL_088d: Expected O, but got I4
		//IL_026f: Expected F4, but got I4
		//IL_0505: Expected O, but got I4
		//IL_050e: Expected O, but got I4
		//IL_0281: Expected O, but got Ref
		//IL_029b: Expected O, but got Ref
		//IL_0311: Expected O, but got F4
		//IL_0320: Expected O, but got F4
		//IL_0345: Invalid comparison between F4 and I4
		//IL_02c5: Expected O, but got Ref
		//IL_054a: Unknown result type (might be due to invalid IL or missing references)
		//IL_054f: Expected O, but got Unknown
		//IL_05df: Expected O, but got I4
		Transform transform = base.transform;
		Transform transform2 = base.enemy.transform;
		Vector3 position = transform2.position;
		float x = position.x;
		float x2 = default(float);
		transform.position = (Vector3)(&x2);
		ParticleSystem[] array = chargeParticles;
		x2 = position.x;
		object obj = 0;
		object obj2 = 0;
		object obj3 = 0;
		while ((nint)obj3 < array.Length)
		{
			Transform transform3 = array[obj2].transform;
			Vector3 feetPosition = base.enemy.GetFeetPosition();
			x = feetPosition.x;
			transform3.position = (Vector3)(&x2);
			obj2++;
			x2 = feetPosition.x;
			obj = 0;
			obj3 = obj2;
		}
		Enemy enemy = base.enemy;
		if (enemy.state == EEnemyState.Idle)
		{
			Action a_DarknessAttackSetEnemyTarget = A_DarknessAttackSetEnemyTarget;
			if (A_DarknessAttackSetEnemyTarget != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v637.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
			}
		}
		float num = (timer = ((!enemyDied) ? (timer + MyTime.fixedDeltaTime) : (timer - MyTime.fixedDeltaTime)));
		bool flag3;
		bool flag4;
		if (hasBlasted)
		{
			float num2 = num / unchargeTime;
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
			float num3 = Easing.InCubic(num2);
			Action<float> a_LightIntensity = A_LightIntensity;
			if (A_LightIntensity != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v803 @ rax_v53 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			Transform transform4 = blastSphere.transform;
			nint num4 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v872 @ rax_v57 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num5 = 0;
			nint num6 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v889 @ rax_v58 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num7 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v59 (Il2CppStaticFields<UnityEngine.Vector3>)+10]");
			float num8 = 0f * 500f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v192 @ rax_v59 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num9 = 0f * 500f;
			float num10 = num2 + num2;
			if (!(0f > num10))
			{
				if (num10 > 1f)
				{
					num10 = 1f;
				}
			}
			else
			{
				num10 = 0f;
			}
			if (!(0f > num10))
			{
				if (num10 > 1f)
				{
					num10 = 1f;
				}
			}
			else
			{
				num10 = 0f;
			}
			object obj4 = default(object);
			float num11 = num8 - (float)obj4;
			float num12 = num9;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num13 = num12 - 0f;
			float num14 = num11 * num10;
			float num15 = num14 + (float)obj4;
			float num16 = num13 * num10;
			float num17 = num16;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v165 @ rdx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+14]");
			float num18 = num17 + 0f;
			transform4.localScale = (Vector3)(&x2);
			bool flag = timer < blastToDamageDelay;
			IShakeParameters shakeParameters = (IShakeParameters)(&x2);
			if (!flag)
			{
				bool flag2 = hasDamaged;
				shakeParameters = (IShakeParameters)(&x2);
				if (!flag2)
				{
					BlastDamage();
					shakeParameters = null;
				}
			}
			float num19 = timer;
			float num20 = timer - unchargeTime;
			object obj5 = timer ^ unchargeTime;
			object obj6 = timer ^ num20;
			object obj7 = obj5 & obj6;
			flag3 = (nint)obj7 < 0;
			flag4 = num20 < 0f;
			float num21 = 1f;
		}
		else
		{
			EnemySpecialAttack enemySpecialAttack = base._003CspecialAttack_003Ek__BackingField;
			float num22 = num / enemySpecialAttack.attackChargeTime;
			if (!(0f > num22))
			{
				if (num22 > 1f)
				{
					num22 = 1f;
				}
			}
			else
			{
				num22 = 0f;
			}
			float t = 1f - num22;
			float num23 = Easing.InSine(t);
			Action<float> a_LightIntensity2 = A_LightIntensity;
			if (A_LightIntensity != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v834 @ rax_v30 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			float num24 = num22 * 1.25f;
			float pitch = num24 + 0.75f;
			audioCharge.pitch = pitch;
			float num25 = Easing.OutCubic(num22);
			float num26 = num25 * 0.3f;
			float volume = num26 + 0.3f;
			audioCharge.volume = volume;
			float num19 = timer;
			bool flag5 = timer < explodeAtTime;
			IShakeParameters shakeParameters = null;
			if (!flag5)
			{
				bool flag6 = hasBlasted;
				shakeParameters = null;
				if (!flag6)
				{
					ParticleSystem[] array2 = chargeParticles;
					hasBlasted = true;
					timer = 0f;
					object obj8 = 0;
					object obj9 = 0;
					while ((nint)obj9 < array2.Length)
					{
						array2[obj8].enableEmission = false;
						array2[obj8].Stop();
						obj8++;
						obj9 = obj8;
					}
					blastParticles.Play();
					GameObject gameObject = blastSphere.gameObject;
					gameObject.SetActive(value: true);
					audioCharge.Stop();
					audioBlast.Play();
					PlayerCamera instance = PlayerCamera.Instance;
					shakeParameters = shakePreset;
					ShakeInstance shakeInstance = instance.shaker.Shake(shakePreset, (int?)(object)0);
				}
			}
			if (!enemyDied)
			{
				return;
			}
			object obj10 = 0 - timer;
			object obj11 = timer & obj10;
			flag3 = (nint)obj11 < 0;
			flag4 = (nint)obj10 < 0;
			float num21 = 1f;
		}
		bool flag7 = flag4 == flag3;
		object obj12 = !flag7;
		if (obj12 == null)
		{
			Action<float> a_LightIntensity3 = A_LightIntensity;
			if (A_LightIntensity != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1193 @ rax_v20 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
			blastSphere.SetActive(value: false);
			GameObject gameObject2 = base.gameObject;
			gameObject2.SetActive(value: false);
			ReturnToPool();
		}
	}

	private void Blast()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_00de: Expected O, but got I4
		ParticleSystem[] array = chargeParticles;
		hasBlasted = true;
		timer = 0f;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			array[obj].enableEmission = false;
			array[obj].Stop();
			obj++;
			obj2 = obj;
		}
		blastParticles.Play();
		GameObject gameObject = blastSphere.gameObject;
		gameObject.SetActive(value: true);
		audioCharge.Stop();
		audioBlast.Play();
		PlayerCamera instance = PlayerCamera.Instance;
		ShakeInstance shakeInstance = instance.shaker.Shake(shakePreset, (int?)(object)0);
	}

	private unsafe void BlastDamage()
	{
		//IL_011b: Expected O, but got Ref
		//IL_0175: Expected O, but got I4
		//IL_0175: Expected O, but got Ref
		Action a_Explode = A_Explode;
		if (A_Explode != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v31.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		hasDamaged = true;
		if (!GraveyardBossRoom.isPlayerInsideLight)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerInventory inventory = instance.inventory;
			int combinedMaxHp = inventory.playerHealth.GetCombinedMaxHp();
			float hpRatio = enemy.GetHpRatio();
			float damage;
			if (0.75f > hpRatio)
			{
				MyPlayer instance2 = MyPlayer.Instance;
				PlayerInventory inventory2 = instance2.inventory;
				int combinedMaxHp2 = inventory2.playerHealth.GetCombinedMaxHp();
				float num = (float)combinedMaxHp2 + (float)combinedMaxHp2;
				damage = num;
			}
			else
			{
				damage = (float)combinedMaxHp * 0.75f;
			}
			Transform transform = MyPlayer.Instance.transform;
			Vector3 position = transform.position;
			Transform transform2 = enemy.transform;
			Vector3 position2 = transform2.position;
			float num2 = default(float);
			Vector3 vector = VectorExtensions.XZVector((Vector3)(&num2));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			MyPlayer instance3 = MyPlayer.Instance;
			PlayerInventory inventory3 = instance3.inventory;
			bool ignoreShield = default(bool);
			string damageSource = default(string);
			DcFlags flags = default(DcFlags);
			EDamageEffect damageEffect = default(EDamageEffect);
			inventory3.playerHealth.DamagePlayerExternal(damage, 10f, (Vector3)(&num2), ignoreShield, damageSource, flags, damageEffect, (Enemy)1);
		}
		else
		{
			audioLampSave.Play();
		}
	}

	private void FinishAttack()
	{
		//IL_005b: Expected I, but got O
		nint num = (nint)typeof(GhostKingAttackDarkness);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v27 @ rax_v2 (Il2CppClass<GhostKingAttackDarkness>)+B8]");
		nint num2 = 0;
		Action<float> a_LightIntensity = A_LightIntensity;
		if (A_LightIntensity != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v29 @ rax_v3 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
		blastSphere.SetActive(value: false);
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
		ReturnToPool();
	}

	protected override void OnEnemyDied(Enemy enemy)
	{
		//IL_003e: Expected O, but got I4
		//IL_0047: Expected O, but got I4
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0071: Expected O, but got Unknown
		if (enemy == base.enemy)
		{
			ParticleSystem[] array = chargeParticles;
			object obj = 0;
			object obj2 = 0;
			while ((nint)obj2 < array.Length)
			{
				array[obj].enableEmission = false;
				obj++;
				obj2 = obj;
			}
			enemyDied = true;
		}
	}
}
