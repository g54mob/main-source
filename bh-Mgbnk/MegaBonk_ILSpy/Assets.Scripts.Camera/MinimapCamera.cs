using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Camera;

public class MinimapCamera : MonoBehaviour
{
	public Transform playerIcon;

	public Transform arrowPrefab;

	public GameObject enemyIconPrefab;

	public bool staticOrientation;

	private Vector3 staticRotation;

	public UnityEngine.Camera minimapCamera;

	private bool bossSpotted;

	private Transform bossSpawner;

	public static Action<float> A_RotationUpdated;

	private Quaternion lastRotation;

	private Color bossColor;

	private Color portalColor;

	private Dictionary<Transform, MinimapArrow> arrowDict;

	private Dictionary<Enemy, GameObject> enemyIconDictionary;

	private void Start()
	{
		//IL_03c4: Expected O, but got I4
		//IL_0431: Expected O, but got I4
		//IL_043f: Expected I, but got O
		//IL_04c0: Expected I, but got O
		//IL_016e: Expected I, but got O
		//IL_0177: Expected O, but got I4
		//IL_01c2: Expected I, but got O
		//IL_01cb: Expected O, but got I4
		//IL_023d: Expected I, but got O
		//IL_0246: Expected O, but got I4
		//IL_029a: Expected O, but got I4
		//IL_033d: Expected O, but got I4
		//IL_0391: Expected O, but got I4
		TryFindBossSpawner();
		Invoke("TryFindBossSpawner", 2f);
		Invoke("TryFindBossSpawner", 5f);
		Delegate obj = InteractableBossSpawner.A_BossSpawned;
		Action action = OnBossSpawnerInteract;
		Delegate obj2 = Delegate.Combine(InteractableBossSpawner.A_BossSpawned, action);
		Action action2;
		Delegate obj4;
		object obj5;
		if ((object)obj2 == null)
		{
			InteractableBossSpawner.A_BossSpawned = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = obj2;
				obj5 = 0;
				goto IL_04d5;
			}
			InteractableBossSpawner.A_BossSpawned = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = obj2;
			obj5 = 0;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_04e5;
			}
		}
		Action<bool> b = OnBossSpawnerCompleted;
		Delegate obj7 = Delegate.Combine(InteractableBossSpawner.A_BossDefeated, b);
		Delegate obj8;
		nint num2;
		if ((object)obj7 == null)
		{
			InteractableBossSpawner.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action3 = default(Action<bool>);
			bool flag4 = action3 == null;
			obj8 = obj7;
			obj4 = null;
			num2 = (nint)typeof(Action<bool>);
			obj5 = 0;
			if (flag4)
			{
				goto IL_044d;
			}
			InteractableBossSpawner.A_BossDefeated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			obj8 = obj7;
			obj4 = null;
			num2 = (nint)typeof(Action<bool>);
			obj5 = 0;
			if (flag5)
			{
				goto IL_045d;
			}
		}
		Action<Enemy> b2 = OnEnemySpawn;
		Delegate obj10 = Delegate.Combine(Enemy.A_TargetOfInterestSpawn, b2);
		if ((object)obj10 == null)
		{
			Enemy.A_TargetOfInterestSpawn = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action4 = default(Action<Enemy>);
			bool flag6 = action4 == null;
			obj8 = obj10;
			obj4 = null;
			num2 = (nint)typeof(Action<Enemy>);
			obj5 = 0;
			if (flag6)
			{
				goto IL_0495;
			}
			Enemy.A_TargetOfInterestSpawn = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			action2 = (Action)obj10;
			obj4 = null;
			obj = (Delegate)(object)typeof(Action<Enemy>);
			obj5 = 0;
			if (flag7)
			{
				goto IL_04a5;
			}
		}
		Action<Enemy> b3 = OnEnemyDied;
		Delegate obj12 = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b3);
		if ((object)obj12 == null)
		{
			Enemy.A_EnemyReleasedFromPool = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action5 = default(Action<Enemy>);
		bool flag8 = action5 == null;
		action2 = (Action)obj12;
		obj4 = null;
		obj = (Delegate)(object)typeof(Action<Enemy>);
		obj5 = 0;
		if (flag8)
		{
			goto IL_04c5;
		}
		Enemy.A_EnemyReleasedFromPool = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj13 = default(object);
		bool flag9 = obj13 == null;
		action2 = (Action)obj12;
		obj4 = null;
		obj = (Delegate)(object)typeof(Action<Enemy>);
		obj5 = 0;
		if (!flag9)
		{
			return;
		}
		goto IL_04d5;
		IL_044d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04e5;
		IL_04e5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04d5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04c5;
		IL_0495:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_045d;
		IL_04c5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04a5;
		IL_04a5:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj8 = action2;
		num2 = (nint)obj;
		goto IL_0495;
		IL_045d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_044d;
	}

	private void OnDestroy()
	{
		//IL_038b: Expected O, but got I4
		//IL_03fe: Expected O, but got I4
		//IL_0414: Expected I, but got O
		//IL_048d: Expected I, but got O
		//IL_0130: Expected I, but got O
		//IL_0141: Expected O, but got I4
		//IL_0184: Expected I, but got O
		//IL_0195: Expected O, but got I4
		//IL_01ff: Expected I, but got O
		//IL_0210: Expected O, but got I4
		//IL_0264: Expected O, but got I4
		//IL_0307: Expected O, but got I4
		//IL_035b: Expected O, but got I4
		Delegate obj = InteractableBossSpawner.A_BossSpawned;
		Action action = OnBossSpawnerInteract;
		Delegate obj2 = Delegate.Remove(InteractableBossSpawner.A_BossSpawned, action);
		Action action2;
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			InteractableBossSpawner.A_BossSpawned = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			if ((object)obj3 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				action2 = action;
				obj4 = 0;
				obj5 = obj2;
				goto IL_04aa;
			}
			InteractableBossSpawner.A_BossSpawned = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_04ba;
			}
		}
		Action<bool> value = OnBossSpawnerCompleted;
		Delegate obj7 = Delegate.Remove(InteractableBossSpawner.A_BossDefeated, value);
		nint num2;
		Delegate obj8;
		if ((object)obj7 == null)
		{
			InteractableBossSpawner.A_BossDefeated = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action3 = default(Action<bool>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag4)
			{
				goto IL_0422;
			}
			InteractableBossSpawner.A_BossDefeated = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<bool>);
			obj8 = obj7;
			obj4 = 0;
			obj5 = null;
			if (flag5)
			{
				goto IL_0432;
			}
		}
		Action<Enemy> value2 = OnEnemySpawn;
		Delegate obj10 = Delegate.Remove(Enemy.A_TargetOfInterestSpawn, value2);
		if ((object)obj10 == null)
		{
			Enemy.A_TargetOfInterestSpawn = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<Enemy> action4 = default(Action<Enemy>);
			bool flag6 = action4 == null;
			num2 = (nint)typeof(Action<Enemy>);
			obj8 = obj10;
			obj4 = 0;
			obj5 = null;
			if (flag6)
			{
				goto IL_046a;
			}
			Enemy.A_TargetOfInterestSpawn = action4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj11 = default(object);
			bool flag7 = obj11 == null;
			obj = (Delegate)(object)typeof(Action<Enemy>);
			action2 = (Action)obj10;
			obj4 = 0;
			obj5 = null;
			if (flag7)
			{
				goto IL_047a;
			}
		}
		Action<Enemy> value3 = OnEnemyDied;
		Delegate obj12 = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value3);
		if ((object)obj12 == null)
		{
			Enemy.A_EnemyReleasedFromPool = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action5 = default(Action<Enemy>);
		bool flag8 = action5 == null;
		obj = (Delegate)(object)typeof(Action<Enemy>);
		action2 = (Action)obj12;
		obj4 = 0;
		obj5 = null;
		if (flag8)
		{
			goto IL_049a;
		}
		Enemy.A_EnemyReleasedFromPool = action5;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj13 = default(object);
		bool flag9 = obj13 == null;
		obj = (Delegate)(object)typeof(Action<Enemy>);
		action2 = (Action)obj12;
		obj4 = 0;
		obj5 = null;
		if (!flag9)
		{
			return;
		}
		goto IL_04aa;
		IL_0422:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ba;
		IL_04ba:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_04aa:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_049a;
		IL_046a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0432;
		IL_049a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_047a;
		IL_047a:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = (nint)obj;
		obj8 = action2;
		goto IL_046a;
		IL_0432:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0422;
	}

	private unsafe void OnEnemySpawn(Enemy enemy)
	{
		//IL_001b: Expected O, but got Ref
		Transform target = enemy.transform;
		object obj = default(object);
		AddArrow(target, (Color)(&obj));
	}

	private void OnEnemyDied(Enemy enemy)
	{
		Transform key = enemy.transform;
		if (arrowDict.ContainsKey(key))
		{
			Transform transform = enemy.transform;
			RemoveArrow(transform);
		}
		if (enemyIconDictionary.ContainsKey(enemy) && enemyIconDictionary.ContainsKey(enemy))
		{
			GameObject obj = enemyIconDictionary.get_Item(enemy);
			UnityEngine.Object.Destroy(obj);
			bool flag = ((Dictionary<object, object>)(object)enemyIconDictionary).Remove((object)enemy);
		}
	}

	private void TryFindBossSpawner()
	{
		if (!(bossSpawner == null))
		{
			return;
		}
		InteractableBossSpawner interactableBossSpawner = UnityEngine.Object.FindAnyObjectByType<InteractableBossSpawner>();
		bool flag = interactableBossSpawner == null;
		InteractableBossSpawner interactableBossSpawner2 = interactableBossSpawner;
		if (flag)
		{
			InteractableBossSpawnerFinal interactableBossSpawnerFinal = UnityEngine.Object.FindAnyObjectByType<InteractableBossSpawnerFinal>();
			bool flag2 = interactableBossSpawnerFinal == null;
			interactableBossSpawner2 = (InteractableBossSpawner)(object)interactableBossSpawnerFinal;
			if (flag2)
			{
				InteractableCrypt interactableCrypt = UnityEngine.Object.FindAnyObjectByType<InteractableCrypt>();
				bool flag3 = interactableCrypt != null;
				bool flag4 = !flag3;
				interactableBossSpawner2 = (InteractableBossSpawner)(object)interactableCrypt;
				if (flag4)
				{
					return;
				}
			}
		}
		Transform transform = interactableBossSpawner2.transform;
		bossSpawner = transform;
	}

	private void Update()
	{
		//IL_014e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0153: Expected O, but got Unknown
		//IL_0197: Unknown result type (might be due to invalid IL or missing references)
		//IL_019c: Expected O, but got Unknown
		//IL_01d7: Expected O, but got I
		//IL_01ec: Expected O, but got I
		//IL_04b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04bd: Expected O, but got Unknown
		//IL_03ad: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b2: Expected O, but got Unknown
		//IL_042a: Expected O, but got F4
		//IL_0236: Unknown result type (might be due to invalid IL or missing references)
		//IL_023b: Expected O, but got Unknown
		//IL_027f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0284: Expected O, but got Unknown
		//IL_0306: Unknown result type (might be due to invalid IL or missing references)
		//IL_030b: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		GameManager instance = GameManager.Instance;
		if (!instance.isPlaying || !(MyPlayer.Instance != null))
		{
			return;
		}
		if (MyPlayer.Instance != null)
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory = instance2.inventory;
			if (inventory.playerHealth.IsDead())
			{
				Transform transform = base.transform;
				Transform parent = transform.parent;
				if (parent != null)
				{
					Transform transform2 = base.transform;
					transform2.parent = null;
				}
				return;
			}
		}
		Transform transform3 = playerIcon.transform;
		MyPlayer instance3 = MyPlayer.Instance;
		PlayerInput playerInput = instance3.playerInput;
		object obj = default(object);
		Vector3 euler = (Vector3)(obj - 48);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ rax_v20 (PlayerInput)+3C]");
		float num = 0f * ((float)Math.PI / 180f);
		_ = 1070141403;
		_ = 0;
		Quaternion quaternion = Quaternion.Internal_FromEulerRad(euler);
		Quaternion rotation = (Quaternion)(obj - 32);
		_ = quaternion.x;
		transform3.rotation = rotation;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803311C0");
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ rax_v24+20]");
		object obj2 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ rax_v25+18]");
		object obj3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ rax_v26+2C]");
		if ((nint)0 == 0)
		{
			Transform transform4 = base.transform;
			Vector3 euler2 = (Vector3)(obj - 48);
			float num2 = (float)staticRotation * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Camera.MinimapCamera)+40]");
			float num3 = 0f * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Camera.MinimapCamera)+44]");
			float num4 = 0f * ((float)Math.PI / 180f);
			Quaternion quaternion2 = Quaternion.Internal_FromEulerRad(euler2);
			Quaternion rotation2 = (Quaternion)(obj - 32);
			_ = quaternion2.x;
			transform4.rotation = rotation2;
			Action<float> a_RotationUpdated = A_RotationUpdated;
			if (A_RotationUpdated != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v694 @ rax_v38 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
		}
		else
		{
			Transform transform5 = base.transform;
			MyPlayer instance4 = MyPlayer.Instance;
			PlayerInput playerInput2 = instance4.playerInput;
			Vector3 euler3 = (Vector3)(obj - 48);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ rax_v44 (PlayerInput)+3C]");
			float num5 = 0f * ((float)Math.PI / 180f);
			_ = 1070141403;
			_ = 0;
			Quaternion quaternion3 = Quaternion.Internal_FromEulerRad(euler3);
			Quaternion rotation3 = (Quaternion)(obj - 32);
			_ = quaternion3.x;
			transform5.rotation = rotation3;
			Action<float> a_RotationUpdated2 = A_RotationUpdated;
			if (A_RotationUpdated != null)
			{
				MyPlayer instance5 = MyPlayer.Instance;
				PlayerMovement playerMovement = instance5.playerMovement;
				Transform transform6 = playerMovement.orientation.transform;
				Quaternion rotation4 = transform6.rotation;
				Quaternion rotation5 = (Quaternion)(obj - 48);
				_ = rotation4.x;
				Vector3 vector = Quaternion.Internal_ToEulerRad(rotation5);
				Vector3 euler4 = (Vector3)(obj - 48);
				float num6 = vector.x * 57.29578f;
				float num7 = vector.z * 57.29578f;
				float num8 = vector.y * 57.29578f;
				Vector3 vector2 = Quaternion.Internal_MakePositive(euler4);
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v81 @ rdi_v10 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
			}
		}
		TrySpotBossSpawner();
		UpdateArrows();
		UpdateEnemyMinimapIcons();
		Transform transform7 = base.transform;
		lastRotation = (Quaternion)transform7.rotation.x;
	}

	private unsafe void StaticOrientation()
	{
		//IL_005c: Expected O, but got Ref
		//IL_0012: Expected O, but got Ref
		Transform transform = base.transform;
		float num = default(float);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num));
		transform.rotation = (Quaternion)(&num);
		Action<float> a_RotationUpdated = A_RotationUpdated;
		if (A_RotationUpdated != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v67 @ rax_v7 (System.Action`1<System.Single>)+18] (should have been resolved before IL gen)");
		}
	}

	private unsafe void DynamicOrientation()
	{
		//IL_000e: Expected O, but got Ref
		//IL_0024: Expected O, but got Ref
		//IL_0090: Expected O, but got Ref
		//IL_00b7: Expected O, but got Ref
		//IL_00cb: Expected O, but got I
		//IL_00e8: Expected O, but got I
		//IL_00f8: Expected O, but got I
		Transform transform = base.transform;
		float num = default(float);
		Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&num));
		object obj = default(object);
		transform.rotation = (Quaternion)(&obj);
		Action<float> a_RotationUpdated = A_RotationUpdated;
		if (A_RotationUpdated != null)
		{
			MyPlayer instance = MyPlayer.Instance;
			PlayerMovement playerMovement = instance.playerMovement;
			Transform transform2 = playerMovement.orientation.transform;
			Quaternion rotation = transform2.rotation;
			float num2 = Quaternion.Internal_ToEulerRad((Quaternion)(&num)).y * 57.29578f;
			Vector3 vector = Quaternion.Internal_MakePositive((Vector3)(&num));
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v4 (System.Action`1<System.Single>)+28]");
			object obj2 = 0;
			float y = vector.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v4 (System.Action`1<System.Single>)+40]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v107 @ rbx_v4 (System.Action`1<System.Single>)+18]");
			object obj4 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v188 @ rax_v19 (should have been resolved before IL gen)");
		}
	}

	private unsafe void UpdateArrows()
	{
		//IL_00a2: Expected O, but got Ref
		//IL_00c2: Expected O, but got Ref
		//IL_0106: Expected O, but got I
		//IL_013e: Expected O, but got Ref
		//IL_0690: Expected I, but got O
		//IL_0537: Invalid comparison between I4 and F4
		//IL_02a9: Invalid comparison between F4 and I4
		//IL_02f3: Expected O, but got I
		//IL_0364: Expected O, but got Ref
		//IL_0392: Expected O, but got Ref
		//IL_03c1: Expected O, but got Ref
		//IL_048b: Expected O, but got Ref
		Dictionary<Transform, MinimapArrow>.ValueCollection values = arrowDict.Values;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180AEBE00");
		Dictionary<Transform, MinimapArrow>.ValueCollection.Enumerator enumerator = default(Dictionary<Transform, MinimapArrow>.ValueCollection.Enumerator);
		float num = default(float);
		Component component = default(Component);
		object obj = default(object);
		float num2 = default(float);
		object obj2 = default(object);
		object obj3 = default(object);
		float num14 = default(float);
		object obj4 = default(object);
		float num20 = default(float);
		while (true)
		{
			if (!enumerator.MoveNext())
			{
				enumerator.Dispose();
				return;
			}
			Component instance = MyPlayer.Instance;
			if ((object)MyPlayer.Instance != null)
			{
				Transform transform = MyPlayer.Instance.transform;
				if ((object)transform != null)
				{
					Vector3 position = transform.position;
					Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
					bool flag = (object)component == null;
					instance = (Component)(&obj);
					if (!flag)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ stack_-180 (UnityEngine.Component)+20]");
						if ((nint)0 != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ stack_-180 (UnityEngine.Component)+20]");
							Transform transform2 = ((Component)0).transform;
							if ((object)transform2 != null)
							{
								Vector3 position2 = transform2.position;
								Vector3 vector2 = VectorExtensions.XZVector((Vector3)(&num2));
								nint num3 = (nint)typeof(Math);
								float num4 = vector.x - vector2.x;
								float num5 = vector.y - vector2.y;
								float num6 = vector.z - vector2.z;
								float num7 = num6 * num6;
								float num8 = num5 * num5;
								float num9 = num4 * num4;
								float num10 = num9 + num8;
								float num11 = num10 + num7;
								Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ rcx_v22 (Il2CppClass<System.Math>)+E4]");
								if ((nint)0 <= (nint)0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm6,xmm1\"");
								}
								else
								{
									double num12 = Math.Sqrt(num11);
								}
								GameObject gameObject = component.gameObject;
								bool flag2 = (object)gameObject == null;
								instance = component;
								if (!flag2)
								{
									if (gameObject.activeInHierarchy)
									{
										if ((object)minimapCamera != null)
										{
											float orthographicSize = minimapCamera.orthographicSize;
											Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm6\"");
											float num13 = orthographicSize * 0.95f;
											if (!(num13 > 0f))
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ stack_-180 (UnityEngine.Component)+20]");
												if ((nint)0 != 0)
												{
													Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v318 @ stack_-180 (UnityEngine.Component)+20]");
													Transform transform3 = ((Component)0).transform;
													if ((object)transform3 != null)
													{
														Vector3 position3 = transform3.position;
														Transform transform4 = base.transform;
														if ((object)transform4 != null)
														{
															Vector3 position4 = transform4.position;
															Vector3 vector3 = VectorExtensions.XZVector((Vector3)(&obj2));
															Transform transform5 = component.transform;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180301660");
															Quaternion quaternion = Quaternion.Internal_FromEulerRad((Vector3)(&obj3));
															if ((object)transform5 != null)
															{
																transform5.rotation = (Quaternion)(&num14);
																Transform transform6 = component.transform;
																Transform transform7 = base.transform;
																if ((object)transform7 != null)
																{
																	Vector3 position5 = transform7.position;
																	Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
																	if ((object)minimapCamera == null)
																	{
																		break;
																	}
																	float orthographicSize2 = minimapCamera.orthographicSize;
																	float num15 = orthographicSize2 * (float)obj4;
																	float num16 = num15 * 0.8f;
																	float num17 = num16 + position5.x;
																	float num18 = (float)Vector3.downVector * 20f;
																	float num19 = num18 + num17;
																	transform6.position = (Vector3)(&num20);
																	continue;
																}
																throw new NullReferenceException();
															}
															throw new NullReferenceException();
														}
														throw new NullReferenceException();
													}
													throw new NullReferenceException();
												}
												throw new NullReferenceException();
											}
											GameObject gameObject2 = component.gameObject;
											if ((object)gameObject2 != null)
											{
												gameObject2.SetActive(value: false);
												enumerator.Dispose();
												return;
											}
											throw new NullReferenceException();
										}
										throw new NullReferenceException();
									}
									bool flag3 = (object)minimapCamera == null;
									instance = minimapCamera;
									if (!flag3)
									{
										float orthographicSize3 = minimapCamera.orthographicSize;
										Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm1,xmm6\"");
										float num21 = orthographicSize3 * 0.95f;
										if (0f > num21)
										{
											GameObject gameObject3 = component.gameObject;
											bool flag4 = (object)gameObject3 == null;
											instance = component;
											if (flag4)
											{
												throw new NullReferenceException();
											}
											gameObject3.SetActive(value: true);
										}
										continue;
									}
									throw new NullReferenceException();
								}
								throw new NullReferenceException();
							}
							throw new NullReferenceException();
						}
						throw new NullReferenceException();
					}
					throw new NullReferenceException();
				}
				throw new NullReferenceException();
			}
			throw new NullReferenceException();
		}
		throw new NullReferenceException();
	}

	private unsafe void UpdateEnemyMinimapIcons()
	{
		//IL_00d6: Expected O, but got I
		//IL_0117: Expected O, but got Ref
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
		Dictionary<object, object>.Enumerator enumerator = default(Dictionary<object, object>.Enumerator);
		UnityEngine.Object obj = default(UnityEngine.Object);
		UnityEngine.Object obj2 = default(UnityEngine.Object);
		float num = default(float);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				if (obj != null && obj2 != null)
				{
					if ((object)obj == null)
					{
						throw new NullReferenceException();
					}
					Transform transform = ((GameObject)obj).transform;
					if ((object)obj2 == null)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-38 (UnityEngine.Object)+30]");
					if ((nint)0 == 0)
					{
						throw new NullReferenceException();
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v117 @ stack_-38 (UnityEngine.Object)+30]");
					Transform transform2 = ((Component)0).transform;
					if ((object)transform2 == null)
					{
						break;
					}
					Vector3 position = transform2.position;
					transform.position = (Vector3)(&num);
				}
				continue;
			}
			((Dictionary<Enemy, GameObject>.Enumerator*)(&enumerator))->Dispose();
			return;
		}
		throw new NullReferenceException();
	}

	private unsafe void TrySpotBossSpawner()
	{
		//IL_0052: Expected O, but got Ref
		//IL_0085: Expected O, but got Ref
		//IL_01c4: Expected O, but got I4
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d1: Expected O, but got Unknown
		//IL_0222: Invalid comparison between F4 and I4
		//IL_0256: Expected O, but got Ref
		if (!(bossSpawner != null))
		{
			return;
		}
		Transform transform = MyPlayer.Instance.transform;
		Vector3 position = transform.position;
		float num = default(float);
		Vector3 vector = VectorExtensions.XZVector((Vector3)(&num));
		Transform transform2 = bossSpawner.transform;
		Vector3 position2 = transform2.position;
		Vector3 vector2 = VectorExtensions.XZVector((Vector3)(&num));
		if (!bossSpotted)
		{
			object obj = (object)minimapCamera ^ (object)minimapCamera;
			object obj2 = (object)minimapCamera & obj;
			bool flag = (nint)obj2 < 0;
			bool flag2 = (nint)minimapCamera < 0;
			bool flag3 = (object)minimapCamera == null;
			float num2 = vector.y - vector2.y;
			float num3 = vector.x - vector2.x;
			float num4 = vector.z - vector2.z;
			float num5 = num2 * num2;
			float num6 = num3 * num3;
			float num7 = num4 * num4;
			float num8 = num5 + num6;
			float num9 = num8 + num7;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"ucomisd xmm0,xmm1\"");
			bool flag4 = flag2 == flag;
			object obj3 = !flag3;
			object obj4 = flag4 & obj3;
			if (obj4 == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"sqrtpd xmm0,xmm1\"");
			}
			else
			{
				double num10 = Math.Sqrt(num9);
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"cvtsd2ss xmm6,xmm0\"");
			float orthographicSize = minimapCamera.orthographicSize;
			if (orthographicSize > 0f)
			{
				Transform target = bossSpawner.transform;
				object obj5 = default(object);
				AddArrow(target, (Color)(&obj5));
				bossSpotted = true;
			}
		}
	}

	public unsafe void AddArrow(Transform target, Color color)
	{
		//IL_0099: Expected O, but got Ref
		Transform transform = UnityEngine.Object.Instantiate(arrowPrefab);
		MinimapArrow component = transform.GetComponent<MinimapArrow>();
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B43]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		component.target = target;
		Material material = ((Renderer)component.arrowRenderer).GetMaterial();
		component.material = material;
		object obj = default(object);
		component.material.SetColor("_Color", (Color)(&obj));
		Transform transform2 = component.transform;
		transform2.parentInternal = null;
		GameObject gameObject = component.gameObject;
		gameObject.SetActive(value: true);
		((Dictionary<object, object>)(object)arrowDict).Add((object)target, (object)component);
	}

	public void RemoveArrow(Transform transform)
	{
		if (arrowDict.ContainsKey(transform))
		{
			MinimapArrow minimapArrow = arrowDict.get_Item(transform);
			GameObject obj = minimapArrow.gameObject;
			UnityEngine.Object.Destroy(obj);
			bool flag = ((Dictionary<object, object>)(object)arrowDict).Remove((object)transform);
		}
	}

	public unsafe void AddEnemyMinimapIcon(Enemy enemy, Material iconMaterial, float sizeMultiplier)
	{
		//IL_0093: Expected O, but got Ref
		GameObject gameObject = UnityEngine.Object.Instantiate(enemyIconPrefab);
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		((Renderer)component).SetMaterial(iconMaterial);
		Transform transform = gameObject.transform;
		transform.parentInternal = null;
		gameObject.SetActive(value: true);
		Transform transform2 = gameObject.transform;
		Vector3 localScale = transform2.localScale;
		object obj = default(object);
		transform2.localScale = (Vector3)(&obj);
		((Dictionary<object, object>)(object)enemyIconDictionary).Add((object)enemy, (object)gameObject);
	}

	public void RemoveEnemyMinimapIcon(Enemy enemy)
	{
		if (enemyIconDictionary.ContainsKey(enemy))
		{
			GameObject obj = enemyIconDictionary.get_Item(enemy);
			UnityEngine.Object.Destroy(obj);
			bool flag = ((Dictionary<object, object>)(object)enemyIconDictionary).Remove((object)enemy);
		}
	}

	private void OnBossSpawnerInteract()
	{
		Transform transform = bossSpawner.transform;
		RemoveArrow(transform);
	}

	private unsafe void OnBossSpawnerCompleted(bool openedPortal)
	{
		//IL_0036: Expected O, but got Ref
		if (openedPortal)
		{
			Transform target = bossSpawner.transform;
			object obj = default(object);
			AddArrow(target, (Color)(&obj));
		}
	}

	public MinimapCamera()
	{
		//IL_009e: Expected O, but got I4
		//IL_0022: Expected O, but got F4
		//IL_0044: Expected O, but got F4
		staticOrientation = true;
		_ = 0;
		staticRotation = (Vector3)1119092736;
		bossColor = (Color)MyColorUtility.StringToColor("#ff0000").r;
		portalColor = (Color)MyColorUtility.StringToColor("#00a2ff").r;
		arrowDict = new Dictionary<Transform, MinimapArrow>();
		enemyIconDictionary = new Dictionary<Enemy, GameObject>();
		base._002Ector();
	}
}
