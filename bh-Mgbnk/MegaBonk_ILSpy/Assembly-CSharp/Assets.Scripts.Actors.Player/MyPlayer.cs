using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts.Camera;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Managers;
using Assets.Scripts.Player.Movement;
using Assets.Scripts.Saves___Serialization.Progression;
using Assets.Scripts.Saves___Serialization.Progression.Stats;
using Assets.Scripts.Saves___Serialization.SaveFiles;
using Assets.Scripts.Steam;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;

namespace Assets.Scripts.Actors.Player;

public class MyPlayer : MonoBehaviour
{
	public PlayerRenderer playerRenderer;

	public PlayerMovement playerMovement;

	public ParticleSystem levelupParticles;

	public AudioSource levelupSfx;

	public ECharacter character;

	public PlayerInput playerInput;

	public AuraAttacks playerConstantAttacks;

	public PlayerSfxs playerSfxs;

	public PlayerEffects playerEffects;

	public GameObject fogOfWar;

	public GameObject teleportEffect;

	public UnityEngine.Camera minimapCamera;

	public MinimapCamera minimapCameraScript;

	private bool inited;

	private float _003CbaseMovementSpeed_003Ek__BackingField;

	public PlayerInventory inventory;

	public static Action<PlayerInventory> A_PlayerInventoryInitialized;

	public static MyPlayer Instance;

	public static Action A_PrePlayerSpawn;

	public float height;

	public Transform feet;

	public Transform head;

	public bool hasStarted;

	public Vector3 spawnDir;

	public float width;

	private bool started;

	private float nextChangeTime;

	private bool isInvincible;

	private float damageCooldownOverAtTime;

	private float lastCalledTime;

	private Dictionary<GameObject, float> enemyCooldowns = new Dictionary<GameObject, float>();

	private float enemyAttackCooldown = 0.3f;

	private int enemyLayer;

	public static Action A_Collided;

	public static Action A_CollidedEnemy;

	private float movingDirectionBias;

	private float shootingDirectionBias;

	private float biasMoveSpeed = 0.015f;

	private Vector3 averageMovingDirection;

	private Vector3 averageMovingDirectionShooting;

	private float maxVectorSize = 4f;

	private float maxVectorSizeShooting = 3f;

	public Transform arrow;

	public Transform shootingArrow;

	public bool isTeleporting;

	private static float defaultBaseDamage = 8f;

	private float baseDamage = defaultBaseDamage;

	public float baseMovementSpeed
	{
		get
		{
			return _003CbaseMovementSpeed_003Ek__BackingField;
		}
		private set
		{
			_003CbaseMovementSpeed_003Ek__BackingField = value;
		}
	}

	public void Awake()
	{
		TryInit();
	}

	public unsafe void TryInit()
	{
		//IL_0426: Expected O, but got I4
		//IL_043c: Expected I, but got O
		//IL_0462: Expected O, but got I4
		//IL_0478: Expected I, but got O
		//IL_0164: Expected O, but got I4
		//IL_0172: Expected I, but got O
		//IL_01b8: Expected O, but got I4
		//IL_01c6: Expected I, but got O
		//IL_04ee: Expected O, but got I4
		//IL_04f7: Expected I, but got O
		//IL_050d: Expected I, but got O
		//IL_053b: Expected O, but got I4
		//IL_0544: Expected I, but got O
		//IL_055a: Expected I, but got O
		//IL_0585: Expected I, but got O
		//IL_0608: Expected O, but got I4
		//IL_0611: Expected I, but got O
		if (inited)
		{
			return;
		}
		inited = true;
		if (!(Instance == null))
		{
			GameObject obj = base.gameObject;
			UnityEngine.Object.Destroy(obj);
			return;
		}
		Instance = this;
		int num = LayerMask.NameToLayer("Enemy");
		enemyLayer = num;
		Action action = OnLevelUp;
		action._002Ector(this, (nint)__ldftn(MyPlayer.OnLevelUp));
		Delegate obj2 = Delegate.Combine(LevelupScreen.A_LevelUpClose, action);
		object obj4;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			LevelupScreen.A_LevelUpClose = null;
		}
		else
		{
			bool flag = (object)obj2.GetType() != typeof(Action);
			Delegate obj3 = null;
			if (!flag)
			{
				obj3 = obj2;
			}
			bool flag2 = (object)obj3 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num2 = (nint)typeof(Action);
			if (flag2)
			{
				goto IL_05b1;
			}
			LevelupScreen.A_LevelUpClose = (Action)obj3;
			bool flag3 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag3)
			{
				obj6 = obj2;
			}
			bool flag4 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num3 = (nint)typeof(Action);
			if (flag4)
			{
				goto IL_05bc;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> b = new Action<object, object, bool>(OnDamage);
		Delegate obj7 = Delegate.Combine(PlayerHealth.A_TakeDamage, b);
		Delegate obj8;
		nint num4;
		if ((object)obj7 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action2 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag5 = action2 == null;
			obj8 = obj7;
			obj4 = 0;
			num4 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj5 = null;
			if (flag5)
			{
				goto IL_04ae;
			}
			PlayerHealth.A_TakeDamage = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag6 = obj9 == null;
			obj8 = obj7;
			obj4 = 0;
			num4 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj5 = null;
			if (flag6)
			{
				goto IL_04be;
			}
		}
		Action action3 = DamageCooldownOver;
		Delegate obj10 = Delegate.Combine(PlayerHealth.A_CooldownOver, action3);
		if ((object)obj10 == null)
		{
			PlayerHealth.A_CooldownOver = null;
		}
		else
		{
			bool flag7 = (object)obj10.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag7)
			{
				obj11 = obj10;
			}
			bool flag8 = (object)obj11 == null;
			obj8 = action3;
			obj4 = 0;
			num4 = (nint)PlayerHealth.A_CooldownOver;
			obj5 = obj10;
			nint num5 = (nint)typeof(Action);
			if (flag8)
			{
				goto IL_05cc;
			}
			PlayerHealth.A_CooldownOver = (Action)obj11;
			bool flag9 = (object)obj10.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag9)
			{
				obj12 = obj10;
			}
			bool flag10 = (object)obj12 == null;
			obj8 = action3;
			obj4 = 0;
			num4 = (nint)PlayerHealth.A_CooldownOver;
			obj5 = obj10;
			nint num6 = (nint)typeof(Action);
			if (flag10)
			{
				goto IL_05dc;
			}
		}
		Action action4 = OnPlayerDied;
		Delegate obj13 = Delegate.Combine(PlayerHealth.A_Died, action4);
		if ((object)obj13 == null)
		{
			PlayerHealth.A_Died = null;
			return;
		}
		bool flag11 = (object)obj13.GetType() != typeof(Action);
		Delegate obj14 = null;
		if (!flag11)
		{
			obj14 = obj13;
		}
		bool flag12 = (object)obj14 == null;
		nint num7 = (nint)typeof(Action);
		if (!flag12)
		{
			PlayerHealth.A_Died = (Action)obj14;
			bool flag13 = (object)obj13.GetType() != typeof(Action);
			Delegate obj15 = null;
			if (!flag13)
			{
				obj15 = obj13;
			}
			if ((object)obj15 != null)
			{
				return;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj8 = action4;
		obj4 = 0;
		num4 = (nint)PlayerHealth.A_Died;
		obj5 = obj13;
		goto IL_05dc;
		IL_05cc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04be;
		IL_05b1:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_05dc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05cc;
		IL_04ae:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05bc;
		IL_05bc:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05b1;
		IL_04be:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_04ae;
	}

	private void Start()
	{
		bool flag = Instance != this;
	}

	public unsafe void Spawn(Vector3 position, Vector3 direction, bool useHeightOffset = false)
	{
		//IL_0135: Expected O, but got Ref
		//IL_003b: Expected O, but got Ref
		//IL_0073: Expected O, but got Ref
		//IL_008f: Expected O, but got Ref
		Action a_PrePlayerSpawn = A_PrePlayerSpawn;
		if (A_PrePlayerSpawn != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v55.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		TryInit();
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		character = CharacterMenu.selectedCharacter;
		float num = default(float);
		StartPlayer(CharacterMenu.selectedCharacter, (Vector3)(&num));
		playerInput.SetSpawnDirection((Vector3)(&num));
		CapsuleCollider component = GetComponent<CapsuleCollider>();
		float num2 = component.height;
		height = num2;
		Transform transform = base.transform;
		transform.position = (Vector3)(&num);
		Rigidbody component2 = GetComponent<Rigidbody>();
		component2.position = (Vector3)(&num);
		int layer = LayerMask.NameToLayer("Player");
		int layer2 = LayerMask.NameToLayer("Enemy");
		Physics.IgnoreLayerCollision(layer, layer2, ignore: false);
		Transform transform2 = fogOfWar.transform;
		transform2.parentInternal = null;
		fogOfWar.SetActive(value: true);
	}

	public unsafe void StartPlayer(ECharacter character, Vector3 direction)
	{
		//IL_005d: Expected O, but got Ref
		//IL_0089: Expected O, but got F4
		//IL_00a6: Expected O, but got Ref
		CharacterData characterData = DataManager.Instance.GetCharacterData(character);
		PlayerInventory playerInventory = MapController.GetPlayerInventory(characterData);
		inventory = playerInventory;
		CalculateBaseDamage();
		float num = default(float);
		playerRenderer.SetCharacter(characterData, inventory, (Vector3)(&num));
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: true);
		spawnDir = (Vector3)direction.x;
		_ = direction.z;
		RefreshSize(characterData, (Vector3)(&num));
		if (UiManager.Instance != null)
		{
			UiManager instance = UiManager.Instance;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180392260");
		}
		hasStarted = true;
		Action<PlayerInventory> a_PlayerInventoryInitialized = A_PlayerInventoryInitialized;
		if (A_PlayerInventoryInitialized != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v171 @ r9_v3 (System.Action`1<PlayerInventory>)+18] (should have been resolved before IL gen)");
		}
	}

	public unsafe void RefreshSize(CharacterData characterData, Vector3 direction, float sizeMultiplier = 1f)
	{
		//IL_00c8: Expected O, but got Ref
		//IL_010a: Expected O, but got Ref
		//IL_0156: Expected O, but got Ref
		//IL_017c: Expected O, but got Ref
		//IL_0196: Expected O, but got Ref
		CapsuleCollider component = GetComponent<CapsuleCollider>();
		PlayerInventory playerInventory = MapController.GetPlayerInventory(characterData);
		inventory = playerInventory;
		float num = sizeMultiplier * characterData.colliderWidth;
		width = num;
		float num2 = sizeMultiplier * characterData.colliderHeight;
		component.height = num2;
		float radius = sizeMultiplier * characterData.colliderWidth;
		component.radius = radius;
		Transform transform = feet.transform;
		Transform transform2 = base.transform;
		Vector3 position = transform2.position;
		float num3 = component.height;
		float num4 = default(float);
		transform.position = (Vector3)(&num4);
		Transform transform3 = head.transform;
		Transform transform4 = base.transform;
		Vector3 position2 = transform4.position;
		float num5 = component.height;
		transform3.position = (Vector3)(&num4);
		Transform transform5 = playerRenderer.transform;
		Transform transform6 = feet.transform;
		Vector3 position3 = transform6.position;
		transform5.position = (Vector3)(&num4);
		Transform transform7 = playerRenderer.transform;
		transform7.localScale = (Vector3)(&num4);
		this.playerMovement.ResetState(character, (Vector3)(&num4));
		PlayerMovement playerMovement = this.playerMovement;
		PlayerMovementValues movementValues = playerMovement.movementValues;
		_003CbaseMovementSpeed_003Ek__BackingField = movementValues._003CmaxRunSpeed_003Ek__BackingField;
	}

	private void FixedUpdate()
	{
		if (inventory != null)
		{
			inventory.PhysicsTick();
			UpdateSpawnDirectionBias();
			if (isInvincible && !(MyTime.time < damageCooldownOverAtTime))
			{
				int layer = LayerMask.NameToLayer("Player");
				int layer2 = LayerMask.NameToLayer("Enemy");
				Physics.IgnoreLayerCollision(layer, layer2, ignore: false);
				isInvincible = false;
			}
		}
	}

	private void Update()
	{
		if (inventory != null)
		{
			inventory.Update();
		}
	}

	private void LateUpdate()
	{
		if (inventory != null)
		{
			inventory.LateUpdate();
		}
	}

	private unsafe void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		//IL_0013: Invalid comparison between I4 and F4
		//IL_003f: Expected O, but got Ref
		if (0f < dc.knockback)
		{
			float num = default(float);
			playerMovement.RocketJump((Vector3)(&num));
			int layer = LayerMask.NameToLayer("Player");
			int layer2 = LayerMask.NameToLayer("Enemy");
			Physics.IgnoreLayerCollision(layer, layer2, ignore: true);
			float num2 = MyTime.time + 0.15f;
			isInvincible = true;
			damageCooldownOverAtTime = num2;
		}
	}

	private void DamageCooldownOver()
	{
		int layer = LayerMask.NameToLayer("Player");
		int layer2 = LayerMask.NameToLayer("Enemy");
		Physics.IgnoreLayerCollision(layer, layer2, ignore: false);
		isInvincible = false;
	}

	public void OnLevelUp()
	{
		if (lastCalledTime < MyTime.time)
		{
			lastCalledTime = MyTime.time;
			int characterLevel = inventory.GetCharacterLevel();
			float num = (float)characterLevel + defaultBaseDamage;
			baseDamage = num;
			GameObject gameObject = levelupParticles.gameObject;
			gameObject.SetActive(value: true);
			levelupParticles.Play();
			levelupSfx.Stop();
			levelupSfx.Play();
			CancelInvoke("StopLevelupParticles");
			Invoke("StopLevelupParticles", 2f);
		}
	}

	private void StopLevelupParticles()
	{
		levelupParticles.Stop();
		GameObject gameObject = levelupParticles.gameObject;
		gameObject.SetActive(value: false);
	}

	private unsafe void OnCollisionStay(Collision other)
	{
		//IL_027e: Expected O, but got Ref
		//IL_04a6: Expected O, but got Ref
		//IL_02c4: Expected O, but got Ref
		//IL_0445: Invalid comparison between F4 and O
		Action a_Collided = A_Collided;
		if (A_Collided != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v67.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
		}
		if (isTeleporting || MyTime.paused)
		{
			return;
		}
		if (other != null)
		{
			GameObject gameObject = other.gameObject;
			if ((object)gameObject != null)
			{
				int layer = gameObject.layer;
				if (layer != enemyLayer)
				{
					return;
				}
				GameObject key = other.gameObject;
				if (enemyCooldowns != null)
				{
					if (enemyCooldowns.ContainsKey(key))
					{
						GameObject key2 = other.gameObject;
						if (enemyCooldowns == null)
						{
							goto IL_0371;
						}
						float num = ((Dictionary<object, float>)(object)enemyCooldowns).get_Item((object)key2);
						if (num > MyTime.time)
						{
							return;
						}
					}
					Collider collider = other.collider;
					if ((object)EnemyManager.Instance != null)
					{
						if (!EnemyManager.Instance.GetEnemy(collider, out var enemy))
						{
							return;
						}
						GameObject key3 = other.gameObject;
						if (enemyCooldowns != null)
						{
							float value = MyTime.time + enemyAttackCooldown;
							((Dictionary<object, float>)(object)enemyCooldowns).set_Item((object)key3, value);
							Transform transform = base.transform;
							if ((object)transform != null)
							{
								Vector3 position = transform.position;
								ContactPoint contact = other.GetContact(0);
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822681E0");
								if ((object)GameManager.Instance != null)
								{
									PlayerInventory playerInventory = GameManager.Instance.GetPlayerInventory();
									if (playerInventory != null && playerInventory.playerHealth != null)
									{
										float num2 = default(float);
										playerInventory.playerHealth.DamagePlayer(enemy, (Vector3)(&num2));
										List<GameObject> list = new List<GameObject>();
										if (enemyCooldowns != null)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
											Dictionary<object, float>.Enumerator enumerator = default(Dictionary<object, float>.Enumerator);
											object obj = default(object);
											GameObject gameObject2 = default(GameObject);
											MyPlayer myPlayer;
											while (enumerator.MoveNext())
											{
												myPlayer = (MyPlayer)(&enumerator);
												if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)MyTime.time) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj))
												{
													if (list == null)
													{
														throw new NullReferenceException();
													}
													list.Add(gameObject2);
												}
											}
											((Dictionary<GameObject, float>.Enumerator*)(&enumerator))->Dispose();
											bool flag = list == null;
											myPlayer = (MyPlayer)(&enumerator);
											if (!flag)
											{
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
												List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
												while (true)
												{
													if (enumerator2.MoveNext())
													{
														if (enemyCooldowns == null)
														{
															break;
														}
														bool flag2 = enemyCooldowns.Remove(gameObject2);
														continue;
													}
													((List<GameObject>.Enumerator*)(&enumerator2))->Dispose();
													Action a_CollidedEnemy = A_CollidedEnemy;
													if (A_CollidedEnemy != null)
													{
														Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v172.invoke_impl (System.IntPtr) (should have been resolved before IL gen)");
													}
													return;
												}
												throw new NullReferenceException();
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
		goto IL_0371;
		IL_0371:
		throw new NullReferenceException();
	}

	private void OnGUI()
	{
	}

	private bool CanTakeDamage()
	{
		return !isTeleporting;
	}

	public void UpdateSpawnDirectionBias()
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0013: Expected O, but got Unknown
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Expected O, but got Unknown
		//IL_0442: Expected I, but got O
		//IL_046f: Expected O, but got I
		//IL_04a0: Expected O, but got F4
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Expected O, but got Unknown
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Expected O, but got Unknown
		//IL_04c3: Expected I, but got O
		//IL_04f0: Expected O, but got I
		//IL_0521: Expected O, but got F4
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_015b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Expected O, but got Unknown
		//IL_016a: Expected O, but got F4
		//IL_0420: Invalid comparison between I4 and F4
		//IL_018c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0191: Expected O, but got Unknown
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Expected O, but got Unknown
		//IL_03b1: Expected F4, but got I4
		//IL_01cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d0: Expected O, but got Unknown
		//IL_0241: Unknown result type (might be due to invalid IL or missing references)
		//IL_0246: Expected O, but got Unknown
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0251: Expected O, but got Unknown
		//IL_025b: Expected O, but got F4
		//IL_0294: Expected O, but got I4
		//IL_03bc: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c1: Expected O, but got Unknown
		//IL_02a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ad: Expected O, but got Unknown
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_0301: Expected O, but got F4
		//IL_0317: Expected O, but got I4
		//IL_0322: Unknown result type (might be due to invalid IL or missing references)
		//IL_0327: Expected O, but got Unknown
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_0335: Expected O, but got Unknown
		//IL_0362: Expected O, but got F4
		object obj2 = default(object);
		object obj = obj2 - 95;
		Vector3 velocity = playerMovement.GetVelocity();
		object obj3 = obj - 25;
		_ = velocity.x;
		_ = velocity.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		float num4 = default(float);
		float num11;
		if (!(4f > velocity.x))
		{
			Vector3 velocity2 = playerMovement.GetVelocity();
			object obj4 = obj - 25;
			object obj5 = obj + 7;
			_ = velocity2.x;
			_ = velocity2.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Vector3 v = (Vector3)(obj - 9);
			object obj6 = default(object);
			float num = (float)obj6 * 0.04f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v16+8]");
			float num2 = 0f * 0.04f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v249 @ rax_v16+4]");
			float num3 = 0f * 0.04f;
			Vector3 vector = VectorExtensions.XZVector(v);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Player.MyPlayer)+FC]");
			object obj7 = 0 + vector.z;
			averageMovingDirection = (Vector3)num4;
			Vector3 velocity3 = playerMovement.GetVelocity();
			object obj8 = obj - 25;
			object obj9 = obj + 7;
			_ = velocity3.x;
			_ = velocity3.z;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			Vector3 v2 = (Vector3)(obj - 9);
			object obj10 = default(object);
			float num5 = (float)obj10 * 0.14f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v20+8]");
			float num6 = 0f * 0.14f;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v381 @ rax_v20+4]");
			float num7 = 0f * 0.14f;
			Vector3 vector2 = VectorExtensions.XZVector(v2);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Player.MyPlayer)+108]");
			object obj11 = 0 + vector2.z;
			object obj12 = this + 244;
			averageMovingDirectionShooting = (Vector3)num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			bool flag = !(num7 > maxVectorSize);
			float num8 = 0.14f;
			object obj13 = 0;
			if (!flag)
			{
				object obj14 = this + 244;
				object obj15 = obj + 7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				float num9 = maxVectorSize;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rax_v26+4]");
				num7 = num9 * 0f;
				float num10 = maxVectorSize;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ rax_v26+8]");
				num8 = num10 * 0f;
				averageMovingDirection = (Vector3)num4;
				num6 = num4;
				obj13 = 0;
			}
			object obj16 = this + 256;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			bool flag2 = !(num7 > maxVectorSizeShooting);
			num11 = 1f;
			if (!flag2)
			{
				object obj17 = this + 256;
				object obj18 = obj + 7;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				float num12 = maxVectorSizeShooting;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v331 @ rax_v25+8]");
				float num13 = num12 * 0f;
				averageMovingDirectionShooting = (Vector3)num4;
				num11 = 1f;
			}
		}
		else
		{
			nint num14 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v205 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num15 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v206 @ rcx_v6 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			nint num16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Player.MyPlayer)+FC]");
			object obj19 = num16 - 0;
			float num17 = (float)obj19 * 0.02f;
			float num18 = num17;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Player.MyPlayer)+FC]");
			float num19 = num18 + 0f;
			averageMovingDirection = (Vector3)num4;
			nint num20 = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v254 @ rax_v11 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num21 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v255 @ rcx_v8 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
			nint num22 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Player.MyPlayer)+108]");
			object obj20 = num22 - 0;
			float num23 = (float)obj20 * 0.06f;
			float num24 = num23;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (Assets.Scripts.Actors.Player.MyPlayer)+108]");
			float num25 = num24 + 0f;
			averageMovingDirectionShooting = (Vector3)num4;
			num11 = -1f;
		}
		float num26 = num11 * biasMoveSpeed;
		float num27 = num26 + movingDirectionBias;
		if (!(0f > num27))
		{
			if (num27 > 1f)
			{
				num27 = 1f;
			}
		}
		else
		{
			num27 = 0f;
		}
		movingDirectionBias = num27;
	}

	public float GetSpawnDirectionBias()
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Expected O, but got Unknown
		//IL_001e: Invalid comparison between F4 and O
		//IL_00d2: Expected F4, but got I4
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Expected O, but got Unknown
		//IL_0084: Invalid comparison between I4 and F4
		//IL_00c7: Expected F4, but got I4
		object obj = this + 244;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
		object obj2 = default(object);
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)1f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
		{
			object obj3 = this + 244;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331860");
			float num = (float)obj2 - 1f;
			float num2 = maxVectorSize - 1f;
			float num3 = num / num2;
			if (!(0f > num3))
			{
				if (num3 > 0.4f)
				{
					return 0.4f;
				}
			}
			else
			{
				num3 = 0f;
			}
			return num3;
		}
		return 0f;
	}

	public unsafe Vector3 GetAverageMovingDirection()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)averageMovingDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Assets.Scripts.Actors.Player.MyPlayer)+FC]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public unsafe Vector3 GetAverageMovingDirectionTarget()
	{
		//IL_000f: Expected F4, but got O
		//IL_000a: Expected native int or pointer, but got O
		//IL_0024: Expected F4, but got I
		//IL_001f: Expected native int or pointer, but got O
		Vector3 vector = default(Vector3);
		((Vector3*)(nint)vector)->x = (float)averageMovingDirectionShooting;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rdx (Assets.Scripts.Actors.Player.MyPlayer)+108]");
		((Vector3*)(nint)vector)->z = 0f;
		return vector;
	}

	public bool IsDead()
	{
		//IL_0070: Expected I4, but got O
		PlayerInventory playerInventory = inventory;
		if (inventory != null && playerInventory.playerHealth != null)
		{
			return playerInventory.playerHealth.IsDead();
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private void OnPlayerDied()
	{
		int layer = LayerMask.NameToLayer("Player");
		int layer2 = LayerMask.NameToLayer("Enemy");
		Physics.IgnoreLayerCollision(layer, layer2, ignore: false);
		int stat = RunStats.GetStat(EMyStat.kills);
		Leaderboards.UploadScore(stat);
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ProgressionSaveFile progression = saveManager.progression;
		MapData mapData = MapController._003CcurrentMap_003Ek__BackingField;
		MapProgress mapProgress = progression.menuMeta.GetMapProgress(mapData.eMap);
		int stat2 = RunStats.GetStat(EMyStat.kills);
		mapProgress.SetKills(stat2);
	}

	public void TeleportPlayerNextStage()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172B71]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		teleportEffect.SetActive(value: true);
		isTeleporting = true;
		Invoke("TeleportEnd", 1f);
	}

	public unsafe void TeleportPlayerImmediate(Vector3 position, Vector3 dir, Vector3 cameraDir, float cameraPitch = 20f)
	{
		//IL_0010: Expected O, but got Ref
		//IL_0025: Expected O, but got Ref
		//IL_003d: Expected O, but got Ref
		float num = default(float);
		playerMovement.TeleportPlayer((Vector3)(&num));
		playerRenderer.ForceRotation((Vector3)(&num));
		float pitch = default(float);
		playerInput.SetSpawnDirection((Vector3)(&num), pitch);
	}

	private void TeleportEnd()
	{
		PlayerInventory playerInventory = inventory;
		playerInventory.statusEffects.RemoveAllStatusEffects();
		Transform transform = teleportEffect.transform;
		transform.parentInternal = null;
		GameObject gameObject = base.gameObject;
		gameObject.SetActive(value: false);
	}

	public void PauseInventory(bool b)
	{
		PlayerInventory playerInventory = inventory;
		playerInventory.pause = b;
	}

	public unsafe Vector3 GetFeetPosition()
	{
		//IL_0055: Expected I, but got O
		//IL_00f9: Expected native int or pointer, but got O
		//IL_0106: Expected native int or pointer, but got O
		//IL_0113: Expected native int or pointer, but got O
		Transform transform = base.transform;
		if ((object)transform != null)
		{
			Vector3 position = transform.position;
			nint num = (nint)typeof(Vector3);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ rax_v5 (Il2CppClass<UnityEngine.Vector3>)+B8]");
			nint num2 = 0;
			float num3 = height * 0.5f;
			float num4 = num3 * (float)Vector3.downVector;
			float num5 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+2C]");
			float num6 = num5 * 0f;
			float num7 = num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ rcx_v4 (Il2CppStaticFields<UnityEngine.Vector3>)+28]");
			float num8 = num7 * 0f;
			float x = num4 + position.x;
			float z = num6 + position.z;
			float y = num8 + position.y;
			Vector3 vector = default(Vector3);
			((Vector3*)(nint)vector)->x = x;
			((Vector3*)(nint)vector)->z = z;
			((Vector3*)(nint)vector)->y = y;
			return vector;
		}
		return (Vector3)new NullReferenceException();
	}

	private void CalculateBaseDamage()
	{
		int characterLevel = inventory.GetCharacterLevel();
		float num = (float)characterLevel + defaultBaseDamage;
		baseDamage = num;
	}

	public float GetBaseDamage()
	{
		return baseDamage;
	}

	private void OnDestroy()
	{
		//IL_03ae: Expected O, but got I4
		//IL_03bc: Expected I, but got O
		//IL_0404: Expected O, but got I4
		//IL_041a: Expected I, but got O
		//IL_05c3: Expected I, but got O
		//IL_0159: Expected O, but got I4
		//IL_0167: Expected I, but got O
		//IL_01ad: Expected O, but got I4
		//IL_01bb: Expected I, but got O
		//IL_0490: Expected O, but got I4
		//IL_0498: Expected I, but got O
		//IL_04ae: Expected I, but got O
		//IL_04dc: Expected O, but got I4
		//IL_04f2: Expected I, but got O
		//IL_0520: Expected O, but got I4
		//IL_0536: Expected I, but got O
		//IL_0564: Expected O, but got I4
		//IL_0572: Expected I, but got O
		if (!(Instance == this))
		{
			return;
		}
		Delegate obj = LevelupScreen.A_LevelUpClose;
		Action action = OnLevelUp;
		Delegate obj2 = Delegate.Remove(LevelupScreen.A_LevelUpClose, action);
		Action action2;
		object obj4;
		nint num;
		Delegate obj5;
		if ((object)obj2 == null)
		{
			LevelupScreen.A_LevelUpClose = null;
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
				num = (nint)typeof(Action);
				obj5 = obj2;
				goto IL_05d8;
			}
			LevelupScreen.A_LevelUpClose = (Action)obj3;
			bool flag2 = (object)obj2.GetType() != typeof(Action);
			Delegate obj6 = null;
			if (!flag2)
			{
				obj6 = obj2;
			}
			bool flag3 = (object)obj6 == null;
			obj4 = 0;
			obj5 = obj2;
			nint num2 = (nint)typeof(Action);
			if (flag3)
			{
				goto IL_058d;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> value = new Action<object, object, bool>(OnDamage);
		Delegate obj7 = Delegate.Remove(PlayerHealth.A_TakeDamage, value);
		Delegate obj8;
		nint num3;
		if ((object)obj7 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action3 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag4 = action3 == null;
			obj8 = obj7;
			obj4 = 0;
			num3 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj5 = null;
			if (flag4)
			{
				goto IL_0450;
			}
			PlayerHealth.A_TakeDamage = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			obj8 = obj7;
			obj4 = 0;
			num3 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj5 = null;
			if (flag5)
			{
				goto IL_0460;
			}
		}
		obj = PlayerHealth.A_CooldownOver;
		Action action4 = DamageCooldownOver;
		Delegate obj10 = Delegate.Remove(PlayerHealth.A_CooldownOver, action4);
		if ((object)obj10 == null)
		{
			PlayerHealth.A_CooldownOver = null;
		}
		else
		{
			bool flag6 = (object)obj10.GetType() != typeof(Action);
			Delegate obj11 = null;
			if (!flag6)
			{
				obj11 = obj10;
			}
			bool flag7 = (object)obj11 == null;
			obj8 = action4;
			obj4 = 0;
			num3 = (nint)obj;
			obj5 = obj10;
			nint num4 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0598;
			}
			PlayerHealth.A_CooldownOver = (Action)obj11;
			bool flag8 = (object)obj10.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag8)
			{
				obj12 = obj10;
			}
			bool flag9 = (object)obj12 == null;
			action2 = action4;
			obj4 = 0;
			obj5 = obj10;
			nint num5 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_05a8;
			}
		}
		obj = PlayerHealth.A_Died;
		Action action5 = OnPlayerDied;
		Delegate obj13 = Delegate.Remove(PlayerHealth.A_Died, action5);
		if ((object)obj13 == null)
		{
			PlayerHealth.A_Died = null;
			return;
		}
		bool flag10 = (object)obj13.GetType() != typeof(Action);
		Delegate obj14 = null;
		if (!flag10)
		{
			obj14 = obj13;
		}
		bool flag11 = (object)obj14 == null;
		action2 = action5;
		obj4 = 0;
		obj5 = obj13;
		nint num6 = (nint)typeof(Action);
		if (flag11)
		{
			goto IL_05c8;
		}
		PlayerHealth.A_Died = (Action)obj14;
		bool flag12 = (object)obj13.GetType() != typeof(Action);
		Delegate obj15 = null;
		if (!flag12)
		{
			obj15 = obj13;
		}
		bool flag13 = (object)obj15 == null;
		action2 = action5;
		obj4 = 0;
		num = (nint)typeof(Action);
		obj5 = obj13;
		if (!flag13)
		{
			return;
		}
		goto IL_05d8;
		IL_0450:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_058d;
		IL_058d:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_05d8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05c8;
		IL_05a8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		obj8 = action2;
		num3 = (nint)obj;
		goto IL_0598;
		IL_0460:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0450;
		IL_05c8:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_05a8;
		IL_0598:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0460;
	}
}
