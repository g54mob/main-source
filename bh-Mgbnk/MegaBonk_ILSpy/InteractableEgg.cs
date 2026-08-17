using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning;
using Assets.Scripts.Managers;
using Assets.Scripts.MapGeneration;
using Assets.Scripts.Saves___Serialization.Progression.Achievements;
using Assets.Scripts.Saves___Serialization.Progression.Unlocks;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableEgg : BaseInteractable
{
	public class FrogContainer
	{
		public Transform target;

		public float lastFoundRandomPositionTime;

		public float lockDirectionUntilTime;

		public FrogContainer(Transform t)
		{
			target = t;
		}
	}

	public EnemyData frogEnemyData;

	public MyAchievement unlockAchievement;

	public LocalizedString localizationEgg;

	public MeshRenderer renderer;

	public Collider collider;

	public Material frogMinimapMaterial;

	private List<Enemy> frogEnemies;

	private Dictionary<Enemy, FrogContainer> frogTargets;

	public GameObject breakFx;

	private bool done;

	private float playerDistanceThreshold = 40f;

	private float edgeDistanceThreshold = 10f;

	private float lockDirectionTime = 10f;

	private float newRandomDirectionInterval = 8f;

	private void Awake()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> b = OnEnemyReleasedFromPool;
		Delegate obj = Delegate.Combine(Enemy.A_EnemyReleasedFromPool, b);
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	private new void OnDestroy()
	{
		//IL_00b2: Expected I, but got O
		//IL_008a: Expected I, but got O
		Action<Enemy> value = OnEnemyReleasedFromPool;
		Delegate obj = Delegate.Remove(Enemy.A_EnemyReleasedFromPool, value);
		if ((object)obj == null)
		{
			Enemy.A_EnemyReleasedFromPool = (Action<Enemy>)obj;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<Enemy> action = default(Action<Enemy>);
		if (action != null)
		{
			Enemy.A_EnemyReleasedFromPool = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj2 = default(object);
			bool flag = obj2 == null;
			nint num = (nint)typeof(Action<Enemy>);
			if (!flag)
			{
				return;
			}
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
			nint num = (nint)typeof(Action<Enemy>);
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
	}

	public unsafe override bool Interact()
	{
		//IL_0498: Expected I4, but got O
		//IL_0161: Expected O, but got Ref
		//IL_03bd: Expected O, but got Ref
		if (!done)
		{
			done = true;
			if ((object)breakFx != null)
			{
				breakFx.SetActive(value: true);
				if ((object)renderer != null)
				{
					renderer.enabled = false;
					if ((object)collider != null)
					{
						collider.enabled = false;
						List<Enemy> list = new List<Enemy>();
						frogEnemies = list;
						Dictionary<Enemy, FrogContainer> dictionary = new Dictionary<Enemy, FrogContainer>();
						frogTargets = dictionary;
						int num = 0;
						int num2 = 0;
						float num5 = default(float);
						bool forceSpawn = default(bool);
						EEnemyFlag flag = default(EEnemyFlag);
						bool canBeElite = default(bool);
						float extraSizeMultiplier = default(float);
						float x = default(float);
						while (true)
						{
							Transform transform = base.transform;
							if ((object)transform == null)
							{
								break;
							}
							Vector3 position = transform.position;
							Vector3 insideUnitSphere = UnityEngine.Random.insideUnitSphere;
							float num3 = insideUnitSphere.x + insideUnitSphere.x;
							float num4 = num3 + position.x;
							if ((object)EnemyManager.Instance == null)
							{
								break;
							}
							Enemy enemy = EnemyManager.Instance.SpawnEnemy(frogEnemyData, (Vector3)(&num5), 0, forceSpawn, flag, canBeElite, extraSizeMultiplier);
							if ((object)enemy == null)
							{
								break;
							}
							enemy.teleportTime = 0.05f;
							List<object> list2 = (List<object>)(object)frogEnemies;
							if (frogEnemies == null)
							{
								break;
							}
							int version = list2._version + 1;
							list2._version = version;
							object[] items = list2._items;
							if (list2._items == null)
							{
								break;
							}
							int size = list2._size;
							if (list2._size >= items.Length)
							{
								((List<object>)(object)frogEnemies).AddWithResize((object)enemy);
							}
							else
							{
								int size2 = list2._size + 1;
								list2._size = size2;
								items[size] = enemy;
							}
							int num6 = num2 + 1;
							string text = num.ToString();
							string text2 = "FrogTarget" + text;
							GameObject gameObject = new GameObject(text2);
							if ((object)gameObject == null)
							{
								break;
							}
							Transform transform2 = gameObject.transform;
							FrogContainer frogContainer = new FrogContainer(null);
							frogContainer.target = transform2;
							if (frogTargets == null)
							{
								break;
							}
							((Dictionary<object, object>)(object)frogTargets).Add((object)enemy, (object)frogContainer);
							enemy.FollowTarget(transform2);
							Transform transform3 = enemy.transform;
							if ((object)transform3 == null)
							{
								break;
							}
							Vector3 position2 = transform3.position;
							if ((object)transform2 == null)
							{
								break;
							}
							transform2.position = (Vector3)(&x);
							MyPlayer instance = MyPlayer.Instance;
							if ((object)MyPlayer.Instance == null || (object)instance.minimapCameraScript == null)
							{
								break;
							}
							instance.minimapCameraScript.AddEnemyMinimapIcon(enemy, frogMinimapMaterial, 0.8f);
							if ((object)EffectManager.Instance == null)
							{
								break;
							}
							EffectManager.Instance.AttachEnemyHpBar(enemy);
							num2++;
							bool flag2 = num2 < 3;
							x = position2.x;
							num = num6;
							num5 = num4;
							if (!flag2)
							{
								return true;
							}
						}
					}
				}
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
		return false;
	}

	private unsafe void Update()
	{
		//IL_0082: Invalid comparison between F4 and I4
		//IL_0090: Expected O, but got Ref
		//IL_07f2: Expected O, but got F4
		//IL_042f: Expected O, but got F4
		//IL_0157: Expected O, but got F4
		//IL_0467: Expected O, but got Ref
		//IL_049f: Expected O, but got F4
		//IL_01cd: Expected O, but got F4
		//IL_04fe: Expected O, but got Ref
		//IL_05df: Expected O, but got F4
		//IL_0547: Expected O, but got F4
		//IL_0226: Expected O, but got F4
		//IL_0636: Expected O, but got Ref
		//IL_099d: Expected O, but got F4
		//IL_0273: Expected O, but got F4
		//IL_0665: Expected O, but got F4
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected O, but got Unknown
		//IL_035b: Expected O, but got Ref
		//IL_02b0: Expected I, but got O
		//IL_036d: Expected O, but got F4
		//IL_0686: Expected F4, but got I4
		//IL_02f3: Expected O, but got F4
		//IL_03c9: Expected O, but got F4
		//IL_0420: Expected O, but got Ref
		if (frogEnemies == null)
		{
			return;
		}
		List<Enemy> list = frogEnemies;
		if (list._size <= 0)
		{
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @181126F30");
		float num2 = default(float);
		float num = num2;
		List<object>.Enumerator enumerator = default(List<object>.Enumerator);
		object obj2 = default(object);
		float num10 = default(float);
		float num11 = default(float);
		float num13 = default(float);
		float num14 = default(float);
		while (true)
		{
			if (enumerator.MoveNext())
			{
				bool flag = num2 == 0f;
				List<object>.Enumerator enumerator2 = (List<object>.Enumerator)(&enumerator);
				if (!flag)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v345 @ stack_-258 (System.Single)+A0]");
					if ((nint)0 == 0)
					{
						_ = 3;
					}
					Transform transform = ((Component)num2).transform;
					if ((object)transform != null)
					{
						Vector3 position = transform.position;
						if ((object)MyPlayer.Instance != null)
						{
							Transform transform2 = MyPlayer.Instance.transform;
							if ((object)transform2 != null)
							{
								Vector3 position2 = transform2.position;
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331420");
								if (!(position2.x > playerDistanceThreshold))
								{
									Transform transform3 = ((Component)num2).transform;
									if ((object)transform3 != null)
									{
										Vector3 position3 = transform3.position;
										if ((object)MyPlayer.Instance != null)
										{
											Transform transform4 = MyPlayer.Instance.transform;
											if ((object)transform4 != null)
											{
												Vector3 position4 = transform4.position;
												Transform transform5 = ((Component)num2).transform;
												if ((object)transform5 != null)
												{
													Vector3 position5 = transform5.position;
													Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
													if (frogTargets != null)
													{
														FrogContainer frogContainer = frogTargets.get_Item((Enemy)num2);
														if (frogContainer != null)
														{
															if (!(frogContainer.lockDirectionUntilTime > MyTime.time))
															{
																Transform transform6 = ((Component)num2).transform;
																if ((object)transform6 == null)
																{
																	throw new NullReferenceException();
																}
																Vector3 position6 = transform6.position;
																nint num3 = (nint)typeof(MapInfo);
																float num4 = (float)MapInfo.mapBoundsUpper - 10f;
																if (!(position6.x > num4))
																{
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2009 @ rcx_v91 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
																	nint num5 = 0;
																	Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2058 @ rax_v146 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+14]");
																	float num6 = 0f - 10f;
																	if (!(position6.z > num6))
																	{
																		float num7 = (float)MapInfo.mapBoundsLower + 10f;
																		if (!(num7 > position6.x))
																		{
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2009 @ rcx_v91 (Il2CppClass<Assets.Scripts.MapGeneration.MapInfo>)+B8]");
																			nint num8 = 0;
																			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2057 @ rax_v150 (Il2CppStaticFields<Assets.Scripts.MapGeneration.MapInfo>)+8]");
																			float num9 = 0f + 10f;
																			if (!(num9 > position6.z))
																			{
																				goto IL_0973;
																			}
																		}
																	}
																}
																if (frogTargets == null)
																{
																	break;
																}
																FrogContainer frogContainer2 = frogTargets.get_Item((Enemy)num2);
																float lockDirectionUntilTime = MyTime.time + lockDirectionTime;
																frogContainer2.lockDirectionUntilTime = lockDirectionUntilTime;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
															}
															else
															{
																Transform transform7 = ((Component)num2).transform;
																if ((object)transform7 == null)
																{
																	throw new NullReferenceException();
																}
																Vector3 position7 = transform7.position;
																object obj = MapInfo.mapCenter - position7.x;
																Vector3 vector = VectorExtensions.XZVector((Vector3)(&obj2));
																Transform transform8 = ((Component)num2).transform;
																if ((object)transform8 == null)
																{
																	throw new NullReferenceException();
																}
																Vector3 position8 = transform8.position;
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
																obj2 = obj;
															}
															goto IL_0973;
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
								Transform transform9 = ((Component)num2).transform;
								if ((object)transform9 != null)
								{
									Vector3 position9 = transform9.position;
									Vector3 vector2 = VectorExtensions.XZVector((Vector3)(&num10));
									if (frogTargets != null)
									{
										FrogContainer frogContainer3 = frogTargets.get_Item((Enemy)num2);
										if (frogContainer3 != null)
										{
											if ((object)frogContainer3.target != null)
											{
												Vector3 position10 = frogContainer3.target.position;
												Vector3 vector3 = VectorExtensions.XZVector((Vector3)(&num11));
												Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331420");
												if (!(2f > vector3.x))
												{
													if (frogTargets == null)
													{
														throw new NullReferenceException();
													}
													FrogContainer frogContainer4 = frogTargets.get_Item((Enemy)num2);
													if (frogContainer4 == null)
													{
														throw new NullReferenceException();
													}
													float num12 = frogContainer4.lastFoundRandomPositionTime + newRandomDirectionInterval;
													if (MyTime.time < num12)
													{
														continue;
													}
												}
												Vector3 randomSpawnPositionOnMap = SpawnPositions.GetRandomSpawnPositionOnMap();
												if (frogTargets != null)
												{
													FrogContainer frogContainer5 = frogTargets.get_Item((Enemy)num2);
													if (frogContainer5 != null)
													{
														if ((object)frogContainer5.target != null)
														{
															frogContainer5.target.position = (Vector3)(&num13);
															if (frogTargets != null)
															{
																FrogContainer frogContainer6 = frogTargets.get_Item((Enemy)num2);
																if (frogContainer6 != null)
																{
																	frogContainer6.lastFoundRandomPositionTime = MyTime.time;
																	num = 0f;
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
			((List<Enemy>.Enumerator*)(&enumerator))->Dispose();
			return;
			IL_0973:
			if (frogTargets != null)
			{
				FrogContainer frogContainer7 = frogTargets.get_Item((Enemy)num2);
				if (frogContainer7 != null)
				{
					if ((object)frogContainer7.target != null)
					{
						frogContainer7.target.position = (Vector3)(&num14);
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

	private unsafe void OnEnemyReleasedFromPool(Enemy enemy)
	{
		//IL_013c: Expected O, but got Ref
		if (frogEnemies == null || !((List<object>)(object)frogEnemies).Contains((object)enemy))
		{
			return;
		}
		bool flag = ((List<object>)(object)frogEnemies).Remove((object)enemy);
		List<Enemy> list = frogEnemies;
		if (list._size == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
			if (MyAchievements.IsUnlocked(unlockAchievement))
			{
				EffectManager instance = EffectManager.Instance;
				Vector3 headPosition = enemy.GetHeadPosition();
				object obj = default(object);
				EffectManager.Instance.SpawnChest(instance.openChestNormal, (Vector3)(&obj));
			}
			else
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
				MyAchievement myAchievement = unlockAchievement;
				bool flag2 = MyAchievements.TryUnlock(myAchievement.internalName);
			}
		}
	}

	public override string GetInteractString()
	{
		if (localizationEgg != null)
		{
			return localizationEgg.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	public override bool CanInteract()
	{
		return !done;
	}

	public InteractableEgg()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
