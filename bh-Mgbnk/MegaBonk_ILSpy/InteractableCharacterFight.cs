using System;
using Actors.Enemies;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Managers;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableCharacterFight : BaseInteractable
{
	public CharacterData character;

	public EnemyData enemyData;

	private bool done;

	public LocalizedString interactString;

	public GameObject chargeFx;

	public GameObject explodeFx;

	public Material enemyMat2;

	public Enemy myEnemy;

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

	private void OnEnemyDied(Enemy enemy, DamageContainer dc)
	{
		//IL_005d: Expected O, but got I4
		//IL_0073: Expected I, but got O
		//IL_0083: Expected O, but got I
		//IL_00a5: Expected O, but got I4
		//IL_00c9: Expected O, but got I
		//IL_0124: Expected O, but got I4
		//IL_016b: Expected O, but got I4
		//IL_01a0: Expected O, but got I4
		//IL_01d7: Expected O, but got I4
		//IL_020b: Expected O, but got I4
		//IL_0214: Expected O, but got I4
		//IL_02b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Expected O, but got Unknown
		//IL_02d5: Expected O, but got I
		//IL_02fc: Expected O, but got I
		//IL_0305: Expected O, but got I4
		//IL_026d: Expected O, but got I
		//IL_028f: Expected O, but got I4
		//IL_029f: Expected O, but got I
		if (!(myEnemy == enemy))
		{
			return;
		}
		UnityEngine.Object obj = character;
		bool flag = (object)character == null;
		UnityEngine.Object obj2 = enemy;
		object obj3 = 0;
		if (!flag)
		{
			nint num = (nint)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v131 @ rax_v12 (Il2CppClass<UnityEngine.Object>)+1D0]");
			obj2 = (UnityEngine.Object)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v131 @ rax_v12 (Il2CppClass<UnityEngine.Object>)+1C8] (should have been resolved before IL gen)");
			object obj4 = default(object);
			bool flag2 = obj4 == null;
			obj3 = 0;
			if (!flag2)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v133 @ rax_v13+30]");
				bool flag3 = MyAchievements.TryUnlock((string)0);
				if (!(enemyMat2 != null))
				{
					return;
				}
				Enemy enemy2 = myEnemy;
				bool flag4 = (object)myEnemy == null;
				obj2 = null;
				obj3 = 0;
				obj = enemyMat2;
				if (!flag4)
				{
					obj = enemy2.renderer;
					bool flag5 = (object)enemy2.renderer == null;
					obj2 = null;
					obj3 = 0;
					if (!flag5)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822873E0");
						object obj5 = default(object);
						bool flag6 = obj5 == null;
						obj2 = null;
						obj3 = 0;
						if (!flag6)
						{
							obj = myEnemy;
							bool flag7 = (object)myEnemy == null;
							obj2 = null;
							obj3 = 0;
							if (!flag7)
							{
								Material[] array = new Material[1];
								bool flag8 = array == null;
								obj2 = (UnityEngine.Object)1;
								obj3 = 0;
								obj = (UnityEngine.Object)(object)typeof(Material[]);
								if (!flag8)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v19+20]");
									if ((nint)0 != 0)
									{
										object obj6 = array;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v363 @ rdx_v15+40]");
										obj2 = (UnityEngine.Object)0;
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
										object obj7 = default(object);
										bool flag9 = obj7 == null;
										obj3 = 0;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v19+20]");
										obj = (UnityEngine.Object)0;
										if (flag9)
										{
											Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
											object obj8 = default(object);
											throw obj8;
										}
									}
									obj = (UnityEngine.Object)(array + 32);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v19+20]");
									array[0] = (Material)0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v285 @ rcx_v6 (UnityEngine.Object)+30]");
									bool flag10 = (nint)0 == 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v152 @ rax_v19+20]");
									obj2 = (UnityEngine.Object)0;
									obj3 = 0;
									if (!flag10)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182287AC0");
										return;
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

	public override bool Interact()
	{
		//IL_00f1: Expected I4, but got O
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183172C3B]");
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

	private unsafe void SpawnEnemy()
	{
		//IL_0100: Expected I4, but got O
		//IL_0111: Expected O, but got Ref
		//IL_0151: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Expected O, but got Unknown
		//IL_019a: Expected I4, but got O
		//IL_01f4: Expected I4, but got O
		//IL_03dc: Expected I4, but got O
		//IL_0571: Unknown result type (might be due to invalid IL or missing references)
		//IL_0576: Expected O, but got Unknown
		//IL_05b6: Expected I4, but got O
		//IL_051e: Expected O, but got I
		GameObject gameObject = explodeFx;
		bool flag = (object)explodeFx == null;
		IntPtr intPtr = default(IntPtr);
		bool flag2 = (byte)(nint)intPtr != 0;
		EEnemyFlag eEnemyFlag;
		float num2;
		if (!flag)
		{
			explodeFx.SetActive(value: true);
			gameObject = explodeFx;
			bool flag3 = (object)explodeFx == null;
			flag2 = true;
			int num = 0;
			if (!flag3)
			{
				Transform transform = explodeFx.transform;
				bool flag4 = (object)transform == null;
				flag2 = false;
				num = 0;
				if (!flag4)
				{
					transform.parentInternal = null;
					gameObject = (GameObject)(object)enemyData;
					bool flag5 = (object)enemyData == null;
					flag2 = false;
					num = 0;
					if (!flag5)
					{
						Transform transform2 = base.transform;
						bool flag6 = (object)transform2 == null;
						flag2 = false;
						num = 0;
						gameObject = (GameObject)(object)this;
						if (!flag6)
						{
							Vector3 position = transform2.position;
							bool flag7 = (object)EnemyManager.Instance == null;
							flag2 = (byte)(int)transform2 != 0;
							num = 0;
							object obj = default(object);
							gameObject = (GameObject)(&obj);
							if (!flag7)
							{
								EnemyManager instance = EnemyManager.Instance;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v315 @ rcx_v6 (UnityEngine.GameObject)+18]");
								Vector3 pos = default(Vector3);
								float extraSizeMultiplier = default(float);
								Enemy enemy = instance.SpawnBoss(EEnemy.Skeleton, 0, EEnemyFlag.Boss, pos, extraSizeMultiplier);
								gameObject = (GameObject)(this + 144);
								myEnemy = enemy;
								Enemy enemy2 = myEnemy;
								bool flag8 = (object)myEnemy == null;
								eEnemyFlag = EEnemyFlag.Boss;
								num2 = 1f;
								flag2 = (byte)(int)enemy != 0;
								num = 0;
								if (!flag8)
								{
									enemy2.teleportTime = 0.25f;
									CharacterData characterData = character;
									bool flag9 = (object)character == null;
									eEnemyFlag = EEnemyFlag.Boss;
									num2 = 1f;
									flag2 = (byte)(int)enemy != 0;
									num = 0;
									if (!flag9)
									{
										if (MyAchievements.IsUnlocked(characterData.achievementRequirement))
										{
											bool flag10 = (object)myEnemy == null;
											eEnemyFlag = EEnemyFlag.Boss;
											num2 = 1f;
											flag2 = false;
											num = 0;
											gameObject = (GameObject)(object)myEnemy;
											if (flag10)
											{
												goto IL_063b;
											}
											myEnemy.SetSwarmMultiplierHp(1.5f);
										}
										bool flag11 = enemyMat2 != null;
										bool flag12 = !flag11;
										num = 0;
										if (flag12)
										{
											goto IL_05e5;
										}
										Enemy enemy3 = myEnemy;
										bool flag13 = (object)myEnemy == null;
										eEnemyFlag = EEnemyFlag.Boss;
										num2 = 1f;
										flag2 = false;
										num = 0;
										gameObject = (GameObject)(object)enemyMat2;
										if (!flag13)
										{
											bool flag14 = (object)enemy3.renderer == null;
											eEnemyFlag = EEnemyFlag.Boss;
											num2 = 1f;
											flag2 = false;
											num = 0;
											gameObject = (GameObject)(object)enemy3.renderer;
											if (!flag14)
											{
												Material sharedMaterial = enemy3.renderer.GetSharedMaterial();
												Material material = new Material(enemyMat2);
												Enemy enemy4 = myEnemy;
												bool flag15 = (object)myEnemy == null;
												eEnemyFlag = EEnemyFlag.Boss;
												num2 = 1f;
												flag2 = (byte)(int)enemyMat2 != 0;
												num = 0;
												gameObject = (GameObject)(object)material;
												if (!flag15)
												{
													Material[] array = new Material[2];
													bool flag16 = array == null;
													eEnemyFlag = EEnemyFlag.Boss;
													num2 = 1f;
													flag2 = true;
													num = 0;
													gameObject = (GameObject)(object)typeof(Material[]);
													if (!flag16)
													{
														if ((object)sharedMaterial != null)
														{
															object obj2 = array;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v600 @ rdx_v29+40]");
															flag2 = false;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
															object obj3 = default(object);
															bool flag17 = obj3 == null;
															eEnemyFlag = EEnemyFlag.Boss;
															num2 = 1f;
															num = 0;
															gameObject = (GameObject)(object)sharedMaterial;
															if (flag17)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
																Material material2 = default(Material);
																throw material2;
															}
														}
														array[0] = sharedMaterial;
														if ((object)material != null)
														{
															object obj4 = array;
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v625 @ rdx_v27+40]");
															object obj5 = 0;
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
															object obj6 = default(object);
															bool flag18 = obj6 == null;
															eEnemyFlag = EEnemyFlag.Boss;
															num2 = 1f;
															num = 0;
															Material material3 = material;
															if (flag18)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
																object obj7 = default(object);
																throw obj7;
															}
														}
														gameObject = (GameObject)(array + 40);
														array[1] = material;
														bool flag19 = (object)enemy4.renderer == null;
														eEnemyFlag = EEnemyFlag.Boss;
														num2 = 1f;
														flag2 = (byte)(int)material != 0;
														num = 0;
														if (!flag19)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182287AC0");
															num = 0;
															goto IL_05e5;
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
		goto IL_063b;
		IL_05e5:
		GameObject gameObject2 = base.gameObject;
		bool flag20 = (object)gameObject2 == null;
		eEnemyFlag = EEnemyFlag.Boss;
		num2 = 1f;
		flag2 = false;
		gameObject = (GameObject)(object)this;
		if (!flag20)
		{
			gameObject2.SetActive(value: false);
			return;
		}
		goto IL_063b;
		IL_063b:
		throw new NullReferenceException();
	}

	public override string GetInteractString()
	{
		if (interactString != null)
		{
			return interactString.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public InteractableCharacterFight()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
