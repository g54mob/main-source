using System;
using System.Collections.Generic;
using Assets.Scripts.Actors.Enemies;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Game.Spawning.New;
using Assets.Scripts.Inventory__Items__Pickups.Items;
using Assets.Scripts.Managers;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Localization;

public class InteractableCrypt : BaseInteractable
{
	public LocalizedString stringOpen;

	public LocalizedString stringFailed;

	private Enemy bossEnemy;

	private bool isDone;

	public unsafe override bool Interact()
	{
		//IL_0245: Expected I4, but got O
		//IL_0223: Expected O, but got Ref
		//IL_0223: Expected O, but got Ref
		if (isDone)
		{
			return false;
		}
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null && inventory.itemInventory != null)
			{
				int amount = inventory.itemInventory.GetAmount(EItem.CryptKey);
				if (amount >= 4)
				{
					isDone = true;
					MyPlayer instance2 = MyPlayer.Instance;
					if ((object)MyPlayer.Instance != null)
					{
						instance2.isTeleporting = true;
						Action action = Teleport;
						if ((object)TransitionUI.Instance != null)
						{
							TransitionUI.Instance.StartTransition(action, 0.25f, 0f);
							if ((object)AudioManager.Instance != null)
							{
								AudioManager.Instance.PlayDungeonDoorEnter();
								MyPlayer instance3 = MyPlayer.Instance;
								if ((object)MyPlayer.Instance != null)
								{
									Transform transform = base.transform;
									if ((object)instance3.minimapCameraScript != null)
									{
										instance3.minimapCameraScript.RemoveArrow(transform);
										return true;
									}
								}
							}
						}
					}
				}
				else
				{
					AlwaysUi instance4 = AlwaysUi.Instance;
					if ((object)AlwaysUi.Instance != null && stringFailed != null)
					{
						string localizedString = stringFailed.GetLocalizedString();
						int width = Screen.width;
						int height = Screen.height;
						if ((object)instance4.UiTextPopup != null)
						{
							object obj = default(object);
							object obj2 = default(object);
							float desiredScale = default(float);
							instance4.UiTextPopup.SetText(localizedString, (Vector3)(&obj), (Color)(&obj2), desiredScale);
							return false;
						}
					}
				}
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	private unsafe void Teleport()
	{
		//IL_014e: Expected O, but got Ref
		//IL_016e: Expected O, but got F4
		//IL_018a: Expected O, but got F4
		//IL_01a6: Expected O, but got F4
		//IL_01fe: Expected I, but got O
		//IL_022f: Expected O, but got I
		//IL_0266: Expected O, but got I
		//IL_0290: Expected O, but got I
		//IL_0337: Expected O, but got I4
		//IL_0353: Expected O, but got Ref
		//IL_037c: Expected O, but got Ref
		//IL_037c: Expected O, but got Ref
		//IL_037c: Expected O, but got Ref
		//IL_0439: Invalid comparison between F4 and I4
		//IL_045b: Expected O, but got F4
		RsgController instance = RsgController.Instance;
		if ((object)RsgController.Instance != null)
		{
			int newSeed = MapGenerationController.mapSeed + 1;
			RsgController.Instance.Generate(newSeed, RsgController.EDungeonType.BossDungeon, out var traversalTime);
			RsgController instance2 = RsgController.Instance;
			bool flag = (object)RsgController.Instance == null;
			instance = (RsgController)(object)typeof(RsgController);
			if (!flag)
			{
				GraveyardBossRoom roomBoss = instance2.roomBoss;
				bool flag2 = (object)instance2.roomBoss == null;
				instance = (RsgController)(object)typeof(RsgController);
				if (!flag2)
				{
					bool flag3 = (object)roomBoss.playerTeleportTransform == null;
					instance = (RsgController)(object)typeof(RsgController);
					if (!flag3)
					{
						RsgController instance3 = RsgController.Instance;
						InteractableCryptLeave interactableCryptLeave = instance3._003CrsgEnd_003Ek__BackingField;
						Vector3 position = roomBoss.playerTeleportTransform.position;
						Vector3 forward = roomBoss.playerTeleportTransform.forward;
						Vector3 forward2 = roomBoss.playerTeleportTransform.forward;
						bool flag4 = (object)instance3._003CrsgEnd_003Ek__BackingField == null;
						float num = default(float);
						instance = (RsgController)(&num);
						if (!flag4)
						{
							interactableCryptLeave.teleportPosition = (Vector3)position.x;
							_ = position.z;
							interactableCryptLeave.teleportDir = (Vector3)forward.x;
							_ = forward.z;
							interactableCryptLeave.teleportDirCamera = (Vector3)forward2.x;
							_ = forward2.z;
							bool flag5 = (object)GameManager.Instance == null;
							instance = (RsgController)(object)GameManager.Instance;
							if (!flag5)
							{
								GameManager.Instance.StartDungeon(traversalTime);
								instance = (RsgController)(object)MyPlayer.Instance;
								if ((object)MyPlayer.Instance != null)
								{
									_ = 0;
									nint num2 = (nint)typeof(RsgController);
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v532 @ rax_v26 (Il2CppClass<RsgController>)+B8]");
									nint num3 = 0;
									RsgController instance4 = RsgController.Instance;
									bool flag6 = (object)RsgController.Instance == null;
									instance = (RsgController)num3;
									if (!flag6)
									{
										RsgStart rsgStart = instance4._003CrsgStart_003Ek__BackingField;
										bool flag7 = (object)instance4._003CrsgStart_003Ek__BackingField == null;
										instance = (RsgController)num3;
										if (!flag7)
										{
											bool flag8 = (object)rsgStart.spawnTransform == null;
											instance = (RsgController)num3;
											if (!flag8)
											{
												Vector3 forward3 = rsgStart.spawnTransform.forward;
												instance = RsgController.Instance;
												if ((object)RsgController.Instance != null)
												{
													instance = (RsgController)(object)instance._003CrsgStart_003Ek__BackingField;
													if ((object)instance._003CrsgStart_003Ek__BackingField != null && instance.combineColliderMesh)
													{
														Vector3 position2 = ((Transform)instance.combineColliderMesh).position;
														bool flag9 = (object)MyPlayer.Instance == null;
														object obj = default(object);
														instance = (RsgController)(&obj);
														if (!flag9)
														{
															float num4 = default(float);
															float num5 = default(float);
															float cameraPitch = default(float);
															MyPlayer.Instance.TeleportPlayerImmediate((Vector3)(&num), (Vector3)(&num4), (Vector3)(&num5), cameraPitch);
															instance = (RsgController)(object)EnemyManager.Instance;
															if ((object)EnemyManager.Instance != null && (object)instance.navmeshSurface != null)
															{
																Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180D598D0");
																Dictionary<uint, Enemy>.Enumerator enumerator = default(Dictionary<uint, Enemy>.Enumerator);
																UnityEngine.Object obj2 = default(UnityEngine.Object);
																while (enumerator.MoveNext())
																{
																	if (obj2 != null)
																	{
																		if ((object)obj2 == null)
																		{
																			throw new NullReferenceException();
																		}
																		if (!((Enemy)obj2).IsDead())
																		{
																			((Enemy)obj2).ReleaseToPoolNextFrame();
																		}
																	}
																}
																enumerator.Dispose();
																MyTime.finalSwarmTimer = 0f;
																MyTime.stageTimer = 0f;
																instance = (RsgController)(object)EnemyManager.Instance;
																if ((object)EnemyManager.Instance != null && instance.generationDelay != 0f)
																{
																	((SummonerController)instance.generationDelay).StopFinalSwarm();
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
			}
		}
		throw new NullReferenceException();
	}

	private void Update()
	{
	}

	public override string GetInteractString()
	{
		if (stringOpen != null)
		{
			return stringOpen.GetLocalizedString();
		}
		return (string)(object)new NullReferenceException();
	}

	private bool IsOpen()
	{
		//IL_00e2: Expected I4, but got O
		//IL_007b: Expected O, but got I4
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0096: Expected I4, but got Unknown
		MyPlayer instance = MyPlayer.Instance;
		if ((object)MyPlayer.Instance != null)
		{
			PlayerInventory inventory = instance.inventory;
			if (instance.inventory != null && inventory.itemInventory != null)
			{
				int amount = inventory.itemInventory.GetAmount(EItem.CryptKey);
				object obj = amount - 4;
				int num = amount ^ 4;
				int num2 = amount ^ obj;
				int num3 = num & num2;
				bool flag = num3 < 0;
				bool flag2 = (nint)obj < 0;
				return flag2 == flag;
			}
		}
		NullReferenceException ex = new NullReferenceException();
		return (byte)(int)ex != 0;
	}

	public override bool CanInteract()
	{
		return !isDone;
	}

	public InteractableCrypt()
	{
		showOutline = true;
		((MonoBehaviour)this)._002Ector();
	}
}
