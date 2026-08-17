using System;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Managers;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableDesertGrave : BaseInteractable
{
	public EnemyData enemyData;

	public LocalizedString interactString;

	public GameObject chargeFx;

	public GameObject explodeFx;

	private Enemy myEnemy;

	private bool done;

	public ShrineSpawnAnimation nextShrine;

	public float speedMultiplier = 1f;

	public float sizeMultiplier = 1f;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> b = OnEnemyDied;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyDied, b);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy, DamageContainer> value = OnEnemyDied;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyDied, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
		if (action != null)
		{
			Enemy.A_EnemyDied = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy, DamageContainer>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private unsafe void OnEnemyDied(Enemy enemy, DamageContainer dc)
	{
		//IL_0060: Expected O, but got I4
		//IL_0090: Expected O, but got I4
		//IL_0391: Expected O, but got I4
		//IL_00d0: Expected O, but got I4
		//IL_02dc: Expected I, but got O
		//IL_02ed: Expected O, but got I4
		//IL_011f: Expected O, but got I4
		//IL_0330: Expected I, but got O
		//IL_0341: Expected O, but got I4
		//IL_0145: Expected F4, but got I
		//IL_015b: Expected O, but got Ref
		//IL_0179: Expected I, but got O
		//IL_0181: Expected O, but got Ref
		//IL_01ad: Expected I, but got O
		//IL_01b5: Expected O, but got Ref
		//IL_03b5: Expected I, but got O
		//IL_0412: Expected O, but got I
		//IL_042b: Expected I, but got O
		//IL_0433: Expected O, but got Ref
		//IL_020f: Expected O, but got Ref
		//IL_021d: Expected I, but got O
		//IL_022e: Expected O, but got Ref
		if (!(myEnemy == enemy))
		{
			return;
		}
		myEnemy = null;
		UnityEngine.Object obj = nextShrine;
		bool flag = nextShrine != null;
		bool flag2 = !flag;
		Vector3 vector = (Vector3)0;
		Enemy enemy2 = enemy;
		if (!flag2)
		{
			bool flag3 = (object)nextShrine == null;
			vector = (Vector3)0;
			enemy2 = enemy;
			if (!flag3)
			{
				nextShrine.Activate();
				MyPlayer instance = MyPlayer.Instance;
				bool flag4 = (object)MyPlayer.Instance == null;
				vector = (Vector3)0;
				enemy2 = enemy;
				if (!flag4)
				{
					bool flag5 = (object)nextShrine == null;
					vector = (Vector3)0;
					enemy2 = enemy;
					if (!flag5)
					{
						obj = instance.minimapCameraScript;
						Transform target = nextShrine.transform;
						bool flag6 = (object)instance.minimapCameraScript == null;
						vector = (Vector3)0;
						enemy2 = enemy;
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED70]");
							float num = 0f;
							float num2 = default(float);
							instance.minimapCameraScript.AddArrow(target, (Color)(&num2));
							UiManager instance2 = UiManager.Instance;
							bool flag7 = (object)UiManager.Instance == null;
							nint num3 = unchecked((nint)null);
							vector = (Vector3)(&num2);
							enemy2 = enemy;
							if (!flag7)
							{
								bool flag8 = (object)nextShrine == null;
								num3 = unchecked((nint)null);
								vector = (Vector3)(&num2);
								enemy2 = enemy;
								if (!flag8)
								{
									obj = instance2.objectiveArrow;
									Transform transform = nextShrine.transform;
									nint num4 = (nint)typeof(Vector3);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v335 @ rcx_v38 (Il2CppClass<UnityEngine.Vector3>)+B8]");
									nint num5 = 0;
									num = (float)Vector3.upVector + (float)Vector3.upVector;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
									float num6 = 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+1C]");
									float num7 = num6 + 0f;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
									nint num8 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v319 @ rdx_v26 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
									object obj2 = num8 + 0;
									bool flag9 = (object)instance2.objectiveArrow == null;
									num3 = unchecked((nint)null);
									vector = (Vector3)(&num2);
									enemy2 = (Enemy)(object)transform;
									if (!flag9)
									{
										float timeout = default(float);
										float scaleMultiplier = default(float);
										instance2.objectiveArrow.SetTarget(transform, (Vector3)(&num2), 15f, timeout, scaleMultiplier);
										num7 = 60f;
										num3 = unchecked((nint)null);
										num = 0.5f;
										vector = (Vector3)(&num2);
										enemy2 = (Enemy)(object)transform;
										goto IL_0449;
									}
								}
							}
						}
					}
				}
			}
			goto IL_035e;
		}
		goto IL_0449;
		IL_035e:
		throw new NullReferenceException();
		IL_0449:
		MyPlayer instance3 = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			obj = instance3.minimapCameraScript;
			Transform transform2 = base.transform;
			if ((object)instance3.minimapCameraScript != null)
			{
				instance3.minimapCameraScript.RemoveArrow(transform2);
				Action<Enemy, DamageContainer> value = OnEnemyDied;
				Delegate obj3 = Delegate.Remove(Enemy.A_EnemyDied, value);
				if ((object)obj3 == null)
				{
					Enemy.A_EnemyDied = (Action<Enemy, DamageContainer>)obj3;
					return;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
				Action<Enemy, DamageContainer> action = default(Action<Enemy, DamageContainer>);
				bool flag10 = action == null;
				nint num3 = unchecked((nint)null);
				obj = (UnityEngine.Object)(object)obj3;
				vector = (Vector3)0;
				enemy2 = (Enemy)(object)typeof(Action<Enemy, DamageContainer>);
				if (!flag10)
				{
					Enemy.A_EnemyDied = action;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
					object obj4 = default(object);
					bool flag11 = obj4 == null;
					num3 = unchecked((nint)null);
					obj = (UnityEngine.Object)(object)obj3;
					vector = (Vector3)0;
					enemy2 = (Enemy)(object)typeof(Action<Enemy, DamageContainer>);
					if (!flag11)
					{
						return;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				return;
			}
		}
		goto IL_035e;
	}

	public override bool Interact()
	{
		//IL_00f1: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C4E]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		if (!done)
		{
			done = true;
			if ((object)chargeFx != null)
			{
				chargeFx.SetActive(value: true);
				if ((object)chargeFx != null)
				{
					Transform transform = chargeFx.transform;
					if ((object)transform != null)
					{
						transform.parentInternal = null;
						Invoke("SpawnEnemy", 1f);
						return true;
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private void SpawnEnemy()
	{
		explodeFx.SetActive(value: true);
		Transform transform = explodeFx.transform;
		transform.parentInternal = null;
		EnemyData enemyData = this.enemyData;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		Vector3 pos = default(Vector3);
		float extraSizeMultiplier = default(float);
		Enemy enemy = EnemyManager.Instance.SpawnBoss(enemyData.enemyName, 0, EEnemyFlag.Boss, pos, extraSizeMultiplier);
		myEnemy = enemy;
		Enemy enemy2 = myEnemy;
		enemy2.teleportTime = 0.25f;
		myEnemy.SetSwarmMultiplierHp(100f);
		Enemy enemy3 = myEnemy;
		enemy3.speedMultiplier = speedMultiplier;
		Enemy enemy4 = myEnemy;
		enemy4._003CextraKnockbackRes_003Ek__BackingField = 3f;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public override string GetInteractString()
	{
		if (interactString != null)
		{
			return interactString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public InteractableDesertGrave()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
