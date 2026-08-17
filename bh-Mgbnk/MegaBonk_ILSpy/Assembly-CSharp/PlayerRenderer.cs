using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Assets.Scripts._Data.Hats;
using Assets.Scripts.Actors;
using Assets.Scripts.Actors.Player;
using Assets.Scripts.Inventory__Items__Pickups;
using Assets.Scripts.Inventory__Items__Pickups.Stats;
using Assets.Scripts.Saves___Serialization.Progression.Challenges;
using Assets.Scripts.Saves___Serialization.SaveFiles.Configs;
using Assets.Scripts.Settings___Saves.SaveFiles.ConfigSaves;
using Assets.Scripts.Utility;
using Cpp2ILInjected;
using MK.Toon;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
	private sealed class _003C_003Ec__DisplayClass32_0
	{
		public ECharacter character;

		internal bool _003CSetHat_003Eb__0(HatOrientation x)
		{
			//IL_0053: Expected I4, but got O
			//IL_0031: Expected O, but got I4
			if (x != null)
			{
				object obj = x.character - character;
				return obj == null;
			}
			NullReferenceException ex = new NullReferenceException();
			return (byte)(int)ex != 0;
		}
	}

	public PlayerMovement playerMovement;

	public Animator animator;

	public Material damageFlash;

	private Material defaultMaterial;

	public SkinnedMeshRenderer renderer;

	private Transform hatTransform;

	private MeshRenderer hatRenderer;

	private MeshFilter hatFilter;

	public Transform hips;

	public Transform torso;

	private Quaternion desiredLookRotation;

	private float rotationSpeed;

	private float stoppedMovingAtTime;

	private float movingToIdleTimeout;

	private bool moving;

	private float resetMaterialTime;

	private GameObject rendererObject;

	public Action<CharacterData> A_CharacterSet;

	private CharacterData characterData;

	private SkinData skinData;

	public List<Renderer> subRenderers;

	protected Material[] activeMaterials;

	private List<Material> allMaterials;

	private Color defaultGoochDarkColor;

	private HatData currentHat;

	private bool isDamageFlash;

	private Material[] beforeDamageFlashMaterials;

	private bool shieldActive;

	private Outline outline;

	private Outline hatOutline;

	public Color shieldColor;

	public Color colorFreeze;

	public Color colorMud;

	public Color poisonColor;

	public Color colorNothing;

	private Vector3 smoothedNormal;

	private Vector3 lastValidMoveDirection;

	private float smoothingMultiplier;

	private void Awake()
	{
		//IL_01e8: Expected I, but got O
		//IL_01f1: Expected O, but got I4
		//IL_023c: Expected I, but got O
		//IL_0245: Expected O, but got I4
		//IL_02b7: Expected I, but got O
		//IL_02c0: Expected O, but got I4
		//IL_030b: Expected I, but got O
		//IL_0314: Expected O, but got I4
		//IL_03ae: Expected I, but got O
		//IL_03b7: Expected O, but got I4
		//IL_0402: Expected I, but got O
		//IL_040b: Expected O, but got I4
		//IL_042f: Expected I, but got O
		//IL_09c0: Expected O, but got I4
		//IL_09de: Expected I, but got O
		//IL_0a04: Expected O, but got I4
		//IL_0a22: Expected I, but got O
		//IL_0587: Expected I, but got O
		//IL_0590: Expected O, but got I4
		//IL_05db: Expected I, but got O
		//IL_05e4: Expected O, but got I4
		//IL_067e: Expected I, but got O
		//IL_0687: Expected O, but got I4
		//IL_06d2: Expected I, but got O
		//IL_06db: Expected O, but got I4
		//IL_06ff: Expected I, but got O
		//IL_0a88: Expected O, but got I4
		//IL_0aa6: Expected I, but got O
		//IL_0acc: Expected O, but got I4
		//IL_0aea: Expected I, but got O
		//IL_082f: Expected I, but got O
		//IL_0838: Expected O, but got I4
		//IL_0883: Expected I, but got O
		//IL_088c: Expected O, but got I4
		GameObject gameObject = new GameObject("PlayerHat");
		bool flag = (object)gameObject == null;
		GameObject gameObject2 = gameObject;
		Delegate obj = null;
		nint num2;
		nint num;
		Delegate obj4;
		if (!flag)
		{
			Transform transform = gameObject.transform;
			hatTransform = transform;
			bool flag2 = (object)hatTransform == null;
			gameObject2 = gameObject;
			obj = null;
			if (!flag2)
			{
				GameObject gameObject3 = hatTransform.gameObject;
				int layer = LayerMask.NameToLayer("Player");
				bool flag3 = (object)gameObject3 == null;
				gameObject2 = gameObject3;
				obj = null;
				if (!flag3)
				{
					gameObject3.layer = layer;
					gameObject2 = (GameObject)(object)hatTransform;
					Transform parentInternal = base.transform;
					bool flag4 = (object)hatTransform == null;
					obj = null;
					if (!flag4)
					{
						hatTransform.parentInternal = parentInternal;
						MeshRenderer meshRenderer = ComponentHolderProtocol.AddComponent<MeshRenderer>(hatTransform);
						hatRenderer = meshRenderer;
						MeshFilter meshFilter = ComponentHolderProtocol.AddComponent<MeshFilter>(hatTransform);
						hatFilter = meshFilter;
						bool flag5 = (object)hatTransform == null;
						obj = null;
						if (!flag5)
						{
							GameObject gameObject4 = hatTransform.gameObject;
							bool flag6 = (object)gameObject4 == null;
							obj = null;
							if (!flag6)
							{
								gameObject4.SetActive(value: false);
								Action<bool> b = OnPause;
								Delegate obj2 = Delegate.Combine(MyTime.A_Pause, b);
								object obj3;
								if ((object)obj2 == null)
								{
									MyTime.A_Pause = null;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									Action<bool> action = default(Action<bool>);
									bool flag7 = action == null;
									num = (nint)typeof(Action<bool>);
									obj3 = 0;
									obj4 = obj2;
									obj = null;
									if (flag7)
									{
										goto IL_0915;
									}
									MyTime.A_Pause = action;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									object obj5 = default(object);
									bool flag8 = obj5 == null;
									num = (nint)typeof(Action<bool>);
									obj3 = 0;
									obj4 = obj2;
									obj = null;
									if (flag8)
									{
										goto IL_0920;
									}
								}
								Action<PlayerHealth, DamageContainer, bool> b2 = new Action<object, object, bool>(OnDamage);
								Delegate obj6 = Delegate.Combine(PlayerHealth.A_TakeDamage, b2);
								if ((object)obj6 == null)
								{
									PlayerHealth.A_TakeDamage = null;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									Action<PlayerHealth, DamageContainer, bool> action2 = default(Action<PlayerHealth, DamageContainer, bool>);
									bool flag9 = action2 == null;
									num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj6;
									obj = null;
									if (flag9)
									{
										goto IL_0958;
									}
									PlayerHealth.A_TakeDamage = action2;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									object obj7 = default(object);
									bool flag10 = obj7 == null;
									num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj6;
									obj = null;
									if (flag10)
									{
										goto IL_0978;
									}
								}
								Action<PlayerHealth, float, bool> b3 = new Action<object, float, bool>(OnHeal);
								Delegate obj8 = Delegate.Combine(PlayerHealth.A_Heal, b3);
								if ((object)obj8 == null)
								{
									PlayerHealth.A_Heal = null;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									Action<PlayerHealth, float, bool> action3 = default(Action<PlayerHealth, float, bool>);
									bool flag11 = action3 == null;
									num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj8;
									obj = null;
									if (flag11)
									{
										goto IL_0988;
									}
									PlayerHealth.A_Heal = action3;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									object obj9 = default(object);
									bool flag12 = obj9 == null;
									num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj8;
									obj = null;
									if (flag12)
									{
										goto IL_0998;
									}
								}
								num2 = (nint)PlayerHealth.A_Died;
								Action action4 = OnDeath;
								Delegate obj10 = Delegate.Combine(PlayerHealth.A_Died, action4);
								if ((object)obj10 == null)
								{
									PlayerHealth.A_Died = null;
								}
								else
								{
									bool flag13 = (object)obj10.GetType() != typeof(Action);
									Delegate obj11 = null;
									if (!flag13)
									{
										obj11 = obj10;
									}
									bool flag14 = (object)obj11 == null;
									obj3 = 0;
									gameObject2 = (GameObject)(object)action4;
									obj = obj10;
									nint num3 = (nint)typeof(Action);
									if (flag14)
									{
										goto IL_0b40;
									}
									PlayerHealth.A_Died = (Action)obj11;
									bool flag15 = (object)obj10.GetType() != typeof(Action);
									Delegate obj12 = null;
									if (!flag15)
									{
										obj12 = obj10;
									}
									bool flag16 = (object)obj12 == null;
									obj3 = 0;
									gameObject2 = (GameObject)(object)action4;
									obj = obj10;
									nint num4 = (nint)typeof(Action);
									if (flag16)
									{
										goto IL_0b50;
									}
								}
								Action<EStatusEffect, bool> b4 = OnStatusEffectAdded;
								Delegate obj13 = Delegate.Combine(PlayerStatusEffects.A_StatusEffectAdded, b4);
								if ((object)obj13 == null)
								{
									PlayerStatusEffects.A_StatusEffectAdded = null;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									Action<EStatusEffect, bool> action5 = default(Action<EStatusEffect, bool>);
									bool flag17 = action5 == null;
									num2 = (nint)typeof(Action<EStatusEffect, bool>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj13;
									obj = null;
									if (flag17)
									{
										goto IL_0a30;
									}
									PlayerStatusEffects.A_StatusEffectAdded = action5;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									object obj14 = default(object);
									bool flag18 = obj14 == null;
									num2 = (nint)typeof(Action<EStatusEffect, bool>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj13;
									obj = null;
									if (flag18)
									{
										goto IL_0a40;
									}
								}
								Action<EStatusEffect> b5 = OnStatusEffectRemoved;
								Delegate obj15 = Delegate.Combine(PlayerStatusEffects.A_StatusEffectRemoved, b5);
								if ((object)obj15 == null)
								{
									PlayerStatusEffects.A_StatusEffectRemoved = null;
								}
								else
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									Action<EStatusEffect> action6 = default(Action<EStatusEffect>);
									bool flag19 = action6 == null;
									num2 = (nint)typeof(Action<EStatusEffect>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj15;
									obj = null;
									if (flag19)
									{
										goto IL_0a50;
									}
									PlayerStatusEffects.A_StatusEffectRemoved = action6;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									object obj16 = default(object);
									bool flag20 = obj16 == null;
									num2 = (nint)typeof(Action<EStatusEffect>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj15;
									obj = null;
									if (flag20)
									{
										goto IL_0a60;
									}
								}
								num2 = (nint)PlayerMovement.A_StartedWallClimb;
								Action action7 = ForceWalkAnimation;
								Delegate obj17 = Delegate.Combine(PlayerMovement.A_StartedWallClimb, action7);
								if ((object)obj17 == null)
								{
									PlayerMovement.A_StartedWallClimb = null;
								}
								else
								{
									bool flag21 = (object)obj17.GetType() != typeof(Action);
									Delegate obj18 = null;
									if (!flag21)
									{
										obj18 = obj17;
									}
									bool flag22 = (object)obj18 == null;
									obj3 = 0;
									gameObject2 = (GameObject)(object)action7;
									obj = obj17;
									nint num5 = (nint)typeof(Action);
									if (flag22)
									{
										goto IL_0b60;
									}
									PlayerMovement.A_StartedWallClimb = (Action)obj18;
									bool flag23 = (object)obj17.GetType() != typeof(Action);
									Delegate obj19 = null;
									if (!flag23)
									{
										obj19 = obj17;
									}
									bool flag24 = (object)obj19 == null;
									obj3 = 0;
									gameObject2 = (GameObject)(object)action7;
									obj = obj17;
									nint num6 = (nint)typeof(Action);
									if (flag24)
									{
										goto IL_0b70;
									}
								}
								Action<PlayerInventory> b6 = OnInventoryInit;
								Delegate obj20 = Delegate.Combine(MyPlayer.A_PlayerInventoryInitialized, b6);
								if ((object)obj20 == null)
								{
									MyPlayer.A_PlayerInventoryInitialized = null;
									return;
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
								Action<PlayerInventory> action8 = default(Action<PlayerInventory>);
								bool flag25 = action8 == null;
								num2 = (nint)typeof(Action<PlayerInventory>);
								obj3 = 0;
								gameObject2 = (GameObject)(object)obj20;
								obj = null;
								if (!flag25)
								{
									MyPlayer.A_PlayerInventoryInitialized = action8;
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
									object obj21 = default(object);
									bool flag26 = obj21 == null;
									num2 = (nint)typeof(Action<PlayerInventory>);
									obj3 = 0;
									gameObject2 = (GameObject)(object)obj20;
									obj = null;
									if (!flag26)
									{
										return;
									}
									Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
								}
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
								goto IL_0b70;
							}
						}
					}
				}
			}
		}
		throw new NullReferenceException();
		IL_0b70:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b60;
		IL_0b60:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a60;
		IL_0a50:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a40;
		IL_0a60:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a50;
		IL_0a40:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0a30;
		IL_0978:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0958;
		IL_0a30:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b50;
		IL_0998:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0988;
		IL_0988:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0978;
		IL_0b40:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0998;
		IL_0b50:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0b40;
		IL_0958:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num = num2;
		obj4 = (Delegate)(object)gameObject2;
		goto IL_0920;
		IL_0915:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0920:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0915;
	}

	private void OnDestroy()
	{
		//IL_0703: Expected I, but got O
		//IL_0714: Expected O, but got I4
		//IL_0087: Expected I, but got O
		//IL_0098: Expected O, but got I4
		//IL_0102: Expected I, but got O
		//IL_0113: Expected O, but got I4
		//IL_0156: Expected I, but got O
		//IL_0167: Expected O, but got I4
		//IL_01f9: Expected I, but got O
		//IL_020a: Expected O, but got I4
		//IL_024d: Expected I, but got O
		//IL_025e: Expected O, but got I4
		//IL_07ae: Expected I, but got O
		//IL_07bf: Expected O, but got I4
		//IL_07d5: Expected I, but got O
		//IL_07fb: Expected I, but got O
		//IL_080c: Expected O, but got I4
		//IL_0822: Expected I, but got O
		//IL_03c9: Expected I, but got O
		//IL_03da: Expected O, but got I4
		//IL_041d: Expected I, but got O
		//IL_042e: Expected O, but got I4
		//IL_04c0: Expected I, but got O
		//IL_04d1: Expected O, but got I4
		//IL_0514: Expected I, but got O
		//IL_0525: Expected O, but got I4
		//IL_0541: Expected I, but got O
		//IL_0890: Expected O, but got I4
		//IL_08a6: Expected I, but got O
		//IL_08d4: Expected O, but got I4
		//IL_08ea: Expected I, but got O
		//IL_0671: Expected I, but got O
		//IL_0682: Expected O, but got I4
		//IL_06c5: Expected I, but got O
		//IL_06d6: Expected O, but got I4
		Action<bool> value = OnPause;
		Delegate obj = Delegate.Remove(MyTime.A_Pause, value);
		nint num;
		Delegate obj2;
		object obj3;
		Delegate obj4;
		nint num2;
		if ((object)obj == null)
		{
			MyTime.A_Pause = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<bool> action = default(Action<bool>);
			if (action == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
				num = (nint)typeof(Action<bool>);
				obj2 = obj;
				obj3 = 0;
				obj4 = null;
				goto IL_0930;
			}
			MyTime.A_Pause = action;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj5 = default(object);
			bool flag = obj5 == null;
			num2 = (nint)typeof(Action<bool>);
			obj2 = obj;
			obj3 = 0;
			obj4 = null;
			if (flag)
			{
				goto IL_0723;
			}
		}
		Action<PlayerHealth, DamageContainer, bool> value2 = new Action<object, object, bool>(OnDamage);
		Delegate obj6 = Delegate.Remove(PlayerHealth.A_TakeDamage, value2);
		if ((object)obj6 == null)
		{
			PlayerHealth.A_TakeDamage = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, DamageContainer, bool> action2 = default(Action<PlayerHealth, DamageContainer, bool>);
			bool flag2 = action2 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag2)
			{
				goto IL_0756;
			}
			PlayerHealth.A_TakeDamage = action2;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj7 = default(object);
			bool flag3 = obj7 == null;
			num2 = (nint)typeof(Action<PlayerHealth, DamageContainer, bool>);
			obj2 = obj6;
			obj3 = 0;
			obj4 = null;
			if (flag3)
			{
				goto IL_0766;
			}
		}
		Action<PlayerHealth, float, bool> value3 = new Action<object, float, bool>(OnHeal);
		Delegate obj8 = Delegate.Remove(PlayerHealth.A_Heal, value3);
		if ((object)obj8 == null)
		{
			PlayerHealth.A_Heal = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<PlayerHealth, float, bool> action3 = default(Action<PlayerHealth, float, bool>);
			bool flag4 = action3 == null;
			num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag4)
			{
				goto IL_0776;
			}
			PlayerHealth.A_Heal = action3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj9 = default(object);
			bool flag5 = obj9 == null;
			num2 = (nint)typeof(Action<PlayerHealth, float, bool>);
			obj2 = obj8;
			obj3 = 0;
			obj4 = null;
			if (flag5)
			{
				goto IL_0786;
			}
		}
		Action action4 = OnDeath;
		Delegate obj10 = Delegate.Remove(PlayerHealth.A_Died, action4);
		if ((object)obj10 == null)
		{
			PlayerHealth.A_Died = null;
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
			num2 = (nint)PlayerHealth.A_Died;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj10;
			nint num3 = (nint)typeof(Action);
			if (flag7)
			{
				goto IL_0968;
			}
			PlayerHealth.A_Died = (Action)obj11;
			bool flag8 = (object)obj10.GetType() != typeof(Action);
			Delegate obj12 = null;
			if (!flag8)
			{
				obj12 = obj10;
			}
			bool flag9 = (object)obj12 == null;
			num = (nint)PlayerHealth.A_Died;
			obj2 = action4;
			obj3 = 0;
			obj4 = obj10;
			nint num4 = (nint)typeof(Action);
			if (flag9)
			{
				goto IL_0978;
			}
		}
		Action<EStatusEffect, bool> value4 = OnStatusEffectAdded;
		Delegate obj13 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectAdded, value4);
		if ((object)obj13 == null)
		{
			PlayerStatusEffects.A_StatusEffectAdded = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect, bool> action5 = default(Action<EStatusEffect, bool>);
			bool flag10 = action5 == null;
			num = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj13;
			obj3 = 0;
			obj4 = null;
			if (flag10)
			{
				goto IL_0830;
			}
			PlayerStatusEffects.A_StatusEffectAdded = action5;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj14 = default(object);
			bool flag11 = obj14 == null;
			num = (nint)typeof(Action<EStatusEffect, bool>);
			obj2 = obj13;
			obj3 = 0;
			obj4 = null;
			if (flag11)
			{
				goto IL_0840;
			}
		}
		Action<EStatusEffect> value5 = OnStatusEffectRemoved;
		Delegate obj15 = Delegate.Remove(PlayerStatusEffects.A_StatusEffectRemoved, value5);
		if ((object)obj15 == null)
		{
			PlayerStatusEffects.A_StatusEffectRemoved = null;
		}
		else
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			Action<EStatusEffect> action6 = default(Action<EStatusEffect>);
			bool flag12 = action6 == null;
			num = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj15;
			obj3 = 0;
			obj4 = null;
			if (flag12)
			{
				goto IL_0850;
			}
			PlayerStatusEffects.A_StatusEffectRemoved = action6;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
			object obj16 = default(object);
			bool flag13 = obj16 == null;
			num = (nint)typeof(Action<EStatusEffect>);
			obj2 = obj15;
			obj3 = 0;
			obj4 = null;
			if (flag13)
			{
				goto IL_0860;
			}
		}
		num = (nint)PlayerMovement.A_StartedWallClimb;
		Action action7 = ForceWalkAnimation;
		Delegate obj17 = Delegate.Remove(PlayerMovement.A_StartedWallClimb, action7);
		if ((object)obj17 == null)
		{
			PlayerMovement.A_StartedWallClimb = null;
		}
		else
		{
			bool flag14 = (object)obj17.GetType() != typeof(Action);
			Delegate obj18 = null;
			if (!flag14)
			{
				obj18 = obj17;
			}
			bool flag15 = (object)obj18 == null;
			obj2 = action7;
			obj3 = 0;
			obj4 = obj17;
			nint num5 = (nint)typeof(Action);
			if (flag15)
			{
				goto IL_0990;
			}
			PlayerMovement.A_StartedWallClimb = (Action)obj18;
			bool flag16 = (object)obj17.GetType() != typeof(Action);
			Delegate obj19 = null;
			if (!flag16)
			{
				obj19 = obj17;
			}
			bool flag17 = (object)obj19 == null;
			obj2 = action7;
			obj3 = 0;
			obj4 = obj17;
			nint num6 = (nint)typeof(Action);
			if (flag17)
			{
				goto IL_09a0;
			}
		}
		Action<PlayerInventory> value6 = OnInventoryInit;
		Delegate obj20 = Delegate.Remove(MyPlayer.A_PlayerInventoryInitialized, value6);
		if ((object)obj20 == null)
		{
			MyPlayer.A_PlayerInventoryInitialized = null;
			return;
		}
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		Action<PlayerInventory> action8 = default(Action<PlayerInventory>);
		bool flag18 = action8 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj20;
		obj3 = 0;
		obj4 = null;
		if (flag18)
		{
			goto IL_0920;
		}
		MyPlayer.A_PlayerInventoryInitialized = action8;
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
		object obj21 = default(object);
		bool flag19 = obj21 == null;
		num = (nint)typeof(Action<PlayerInventory>);
		obj2 = obj20;
		obj3 = 0;
		obj4 = null;
		if (!flag19)
		{
			return;
		}
		goto IL_0930;
		IL_0840:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0830;
		IL_0830:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0978;
		IL_0776:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0766;
		IL_0766:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0756;
		IL_0978:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		num2 = num;
		goto IL_0968;
		IL_0930:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0920;
		IL_0723:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		return;
		IL_0756:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0723;
		IL_0920:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_09a0;
		IL_0860:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0850;
		IL_09a0:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0990;
		IL_0990:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0860;
		IL_0850:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0840;
		IL_0968:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0786;
		IL_0786:
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B60");
		goto IL_0776;
	}

	private void OnInventoryInit(PlayerInventory inventory)
	{
		//IL_0020: Invalid comparison between F4 and I4
		//IL_0034: Invalid comparison between F4 and I4
		PlayerHealth playerHealth = inventory.playerHealth;
		bool flag = playerHealth.shield < 0f;
		bool flag2 = playerHealth.shield == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		if (shieldActive != flag5)
		{
			shieldActive = flag5;
			RefreshPlayerOutlines();
		}
	}

	public unsafe void SetCharacter(CharacterData characterData, PlayerInventory inventory, Vector3 spawnDir)
	{
		//IL_0541: Expected I, but got O
		//IL_0600: Invalid comparison between F4 and I4
		//IL_0629: Expected O, but got I4
		//IL_012f: Expected O, but got Ref
		//IL_0145: Expected O, but got Ref
		//IL_014e: Expected O, but got Ref
		//IL_064f: Expected F4, but got O
		//IL_0658: Expected F4, but got O
		//IL_069a: Expected O, but got F4
		//IL_06a9: Expected O, but got F4
		//IL_01f9: Expected O, but got Ref
		//IL_021f: Expected O, but got Ref
		//IL_02db: Expected O, but got I4
		//IL_02e4: Expected O, but got I4
		//IL_0478: Unknown result type (might be due to invalid IL or missing references)
		//IL_047d: Expected O, but got Unknown
		hatTransform.parentInternal = null;
		this.characterData = characterData;
		if (rendererObject != null)
		{
			UnityEngine.Object.Destroy(rendererObject);
			animator = null;
		}
		if (!(characterData != null))
		{
			return;
		}
		SaveManager saveManager = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config = saveManager.config;
		Preferences preferences = config.preferences;
		int savedIndex = preferences.characterSkins.get_Item(characterData.eCharacter);
		SkinData skin = DataManager.Instance.GetSkin(characterData.eCharacter, savedIndex);
		skinData = skin;
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v795 @ rax_v25 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		float num3 = spawnDir.x - (float)Vector3.zeroVector;
		object obj2 = default(object);
		object obj3 = default(object);
		object obj = obj2 - obj3;
		float num4 = spawnDir.z;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v796 @ rcx_v22 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num5 = num4 - 0f;
		object obj4 = obj * obj;
		float num6 = num3 * num3;
		float num7 = num5 * num5;
		float num8 = (float)obj4 + num6;
		float num9 = num8 + num7;
		bool flag = 9.9999994E-11f < num9;
		float num10 = 9.9999994E-11f - num9;
		bool flag2 = num10 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj5 = flag4 & flag3;
		float x = default(float);
		float num11;
		float num12;
		if (obj5 == null)
		{
			Transform transform = base.transform;
			Quaternion quaternion2 = Quaternion.LookRotation((Vector3)(&x));
			Vector3 vector = default(Vector3);
			transform.rotation = (Quaternion)(&vector);
			num11 = Quaternion.LookRotation((Vector3)(&x)).x;
			num12 = quaternion2.x;
			x = spawnDir.x;
		}
		else
		{
			num12 = (float)Vector3.zeroVector;
			num11 = (float)Quaternion.identityQuaternion;
			x = spawnDir.x;
		}
		desiredLookRotation = (Quaternion)num11;
		lastValidMoveDirection = (Vector3)spawnDir.x;
		_ = spawnDir.z;
		if (!(characterData.prefab != null))
		{
			return;
		}
		Transform parent = base.transform;
		GameObject gameObject = UnityEngine.Object.Instantiate(characterData.prefab, parent);
		rendererObject = gameObject;
		Transform transform2 = rendererObject.transform;
		transform2.localPosition = (Vector3)(&x);
		Transform transform3 = rendererObject.transform;
		transform3.localRotation = (Quaternion)(&num12);
		Animator component = rendererObject.GetComponent<Animator>();
		animator = component;
		SkinnedMeshRenderer componentInChildren = rendererObject.GetComponentInChildren<SkinnedMeshRenderer>();
		renderer = componentInChildren;
		SetSkin(skinData);
		int layer = rendererObject.layer;
		int num13 = LayerMask.NameToLayer("Player");
		if (layer != num13)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1803321E0");
		}
		Transform[] componentsInChildren = rendererObject.GetComponentsInChildren<Transform>();
		object obj6 = 0;
		object obj7 = 0;
		while ((nint)obj7 < componentsInChildren.Length)
		{
			GameObject gameObject2 = componentsInChildren[obj6].gameObject;
			string text = gameObject2.name;
			string text2 = text.ToLower();
			if (text2 == "torso")
			{
				torso = componentsInChildren[obj6];
			}
			GameObject gameObject3 = componentsInChildren[obj6].gameObject;
			string text3 = gameObject3.name;
			string text4 = text3.ToLower();
			if (text4 == "hips")
			{
				hips = componentsInChildren[obj6];
			}
			GameObject gameObject4 = componentsInChildren[obj6].gameObject;
			string text5 = gameObject4.name;
			string text6 = text5.ToLower();
			if (text6 == "root")
			{
				hips = componentsInChildren[obj6];
			}
			obj6++;
			obj7 = obj6;
		}
		SaveManager saveManager2 = SaveManager._003CInstance_003Ek__BackingField;
		ConfigSaveFile config2 = saveManager2.config;
		EHat characterHat = config2.preferences.GetCharacterHat(characterData.eCharacter);
		HatData hat = DataManager.Instance.GetHat(characterHat);
		SetHat(hat);
		Action<CharacterData> a_CharacterSet = A_CharacterSet;
		if (A_CharacterSet != null)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v695 @ rax_v66 (System.Action`1<CharacterData>)+18] (should have been resolved before IL gen)");
		}
	}

	private unsafe void CreateMaterials(int amount)
	{
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Expected I, but got Unknown
		//IL_00a1: Expected I, but got O
		//IL_0a5b: Expected I, but got O
		//IL_047c: Expected O, but got I
		//IL_04b6: Expected I, but got O
		//IL_0328: Expected O, but got I4
		//IL_0332: Expected I, but got O
		//IL_0120: Expected I, but got O
		//IL_0135: Expected I, but got O
		//IL_04cd: Expected O, but got I4
		//IL_04d6: Expected O, but got I4
		//IL_0170: Expected I, but got O
		//IL_0189: Expected I, but got O
		//IL_05d6: Expected I, but got O
		//IL_03c7: Expected O, but got I4
		//IL_03e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e6: Expected O, but got Unknown
		//IL_03f5: Expected I, but got O
		//IL_04e5: Expected I, but got O
		//IL_0365: Expected I, but got O
		//IL_03a3: Expected O, but got I
		//IL_03ab: Expected I, but got O
		//IL_0627: Expected I, but got O
		//IL_0634: Expected I, but got O
		//IL_0243: Expected O, but got I4
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0263: Expected I, but got Unknown
		//IL_0268: Expected I, but got O
		//IL_0201: Expected I, but got O
		//IL_0649: Expected I, but got O
		//IL_064e: Expected I, but got O
		//IL_065b: Expected I, but got O
		//IL_05a1: Expected O, but got I
		//IL_05aa: Unknown result type (might be due to invalid IL or missing references)
		//IL_05af: Expected O, but got Unknown
		//IL_05bf: Expected O, but got I
		//IL_0539: Expected I, but got O
		//IL_0549: Expected O, but got I
		//IL_057a: Expected O, but got I
		//IL_066e: Expected I, but got O
		//IL_06af: Expected O, but got I
		//IL_0704: Expected I, but got O
		//IL_0743: Expected O, but got I
		//IL_0798: Expected I, but got O
		//IL_07d7: Expected O, but got I
		//IL_082c: Expected I, but got O
		//IL_0875: Expected O, but got I
		//IL_089a: Expected I, but got O
		//IL_0919: Expected O, but got I
		//IL_0961: Expected O, but got I4
		//IL_099a: Expected O, but got I4
		if (allMaterials == null)
		{
			List<Material> list = new List<Material>();
			allMaterials = list;
		}
		Material[] array = new Material[amount];
		nint num = (nint)(this + 192);
		activeMaterials = array;
		List<Material> list2 = allMaterials;
		bool flag = allMaterials == null;
		Material material = (Material)(object)array;
		nint num3 = default(nint);
		nint num2 = num3;
		Material material2 = (Material)(object)array;
		nint num4 = num;
		if (!flag)
		{
			Material material6 = default(Material);
			object obj8 = default(object);
			object obj9 = default(object);
			Color color2 = default(Color);
			while (true)
			{
				if (list2._size < amount)
				{
					nint num5 = (nint)typeof(AlwaysManager);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v177 @ rax_v54 (Il2CppClass<AlwaysManager>)+B8]");
					num = 0;
					AlwaysManager instance = AlwaysManager.Instance;
					bool flag2 = (object)AlwaysManager.Instance == null;
					num3 = num2;
					material = material2;
					if (flag2)
					{
						break;
					}
					List<object> list3 = (List<object>)(object)allMaterials;
					Material material3 = new Material(instance.playerMaterialPreset);
					bool flag3 = allMaterials == null;
					num3 = unchecked((nint)null);
					material = instance.playerMaterialPreset;
					num = (nint)material3;
					if (flag3)
					{
						break;
					}
					int version = list3._version + 1;
					list3._version = version;
					num = (nint)list3._items;
					bool flag4 = list3._items == null;
					num3 = unchecked((nint)null);
					material = instance.playerMaterialPreset;
					if (flag4)
					{
						break;
					}
					int size = list3._size;
					int size2 = list3._size;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v7 (Il2CppStaticFields<AlwaysManager>)+18]");
					if ((nint)size2 >= (nint)0)
					{
						((List<object>)(object)allMaterials).AddWithResize((object)material3);
						num3 = 0;
						material = material3;
						num = (nint)allMaterials;
					}
					else
					{
						int size3 = list3._size + 1;
						list3._size = size3;
						object obj = list3._size * 8;
						object obj2 = (object)list3._items + obj;
						num = (nint)(obj2 + 32);
						num3 = unchecked((nint)null);
						material = material3;
					}
					list2 = allMaterials;
					if (allMaterials == null)
					{
						break;
					}
					num2 = num3;
					material2 = material;
					num4 = num;
					continue;
				}
				bool flag5 = amount <= 0;
				num3 = num2;
				int num6 = 0;
				if (!flag5)
				{
					while (true)
					{
						bool flag6 = allMaterials == null;
						material = material2;
						num = (nint)allMaterials;
						if (flag6)
						{
							break;
						}
						Material[] array2 = activeMaterials;
						Material material4 = allMaterials.get_Item(num6);
						bool flag7 = activeMaterials == null;
						num3 = 0;
						material = (Material)num6;
						num = (nint)allMaterials;
						if (flag7)
						{
							break;
						}
						if ((object)material4 != null)
						{
							nint num7 = (nint)array2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rdx_v13 (Il2CppClass<UnityEngine.Material[]>)+40]");
							Material material5 = ((List<Material>)(object)material4).get_Item(0);
							bool flag8 = (object)material5 == null;
							num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v696 @ rdx_v13 (Il2CppClass<UnityEngine.Material[]>)+40]");
							material = (Material)0;
							num = (nint)material4;
							if (flag8)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
								throw material6;
							}
						}
						object obj3 = num6 + 4;
						array2[num6] = material4;
						object obj4 = obj3 * 8;
						num4 = (nint)((object)activeMaterials + obj4);
						num6++;
						bool flag9 = num6 < amount;
						num2 = 0;
						num3 = 0;
						material2 = material4;
						if (flag9)
						{
							continue;
						}
						goto IL_0433;
					}
					break;
				}
				goto IL_0433;
				IL_0433:
				material = (Material)(object)activeMaterials;
				bool flag10 = activeMaterials == null;
				num3 = num2;
				num = num4;
				if (flag10)
				{
					break;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v18 (UnityEngine.Material)+18]");
				material = (Material)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v168 @ rdx_v18 (UnityEngine.Material)+18]");
				Material[] array3 = new Material[0];
				bool flag11 = array3 == null;
				num3 = num2;
				num = (nint)typeof(Material[]);
				if (flag11)
				{
					break;
				}
				object obj5 = 0;
				object obj6 = 0;
				while (true)
				{
					if ((nint)obj6 < array3.Length)
					{
						num = (nint)activeMaterials;
						bool flag12 = activeMaterials == null;
						num3 = num2;
						if (flag12)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v7 (Il2CppStaticFields<AlwaysManager>)+20+v156 @ rbx_v10*8]");
						if ((nint)0 != 0)
						{
							nint num8 = (nint)array3;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v911 @ rdx_v32 (Il2CppClass<UnityEngine.Material>)+40]");
							object obj7 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
							bool flag13 = obj8 == null;
							num3 = num2;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v7 (Il2CppStaticFields<AlwaysManager>)+20+v156 @ rbx_v10*8]");
							Material material7 = (Material)0;
							if (flag13)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
								throw obj9;
							}
						}
						object obj10 = obj5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v7 (Il2CppStaticFields<AlwaysManager>)+20+v156 @ rbx_v10*8]");
						array3[obj10] = (Material)0;
						obj5++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v7 (Il2CppStaticFields<AlwaysManager>)+20+v156 @ rbx_v10*8]");
						material = (Material)0;
						obj6 = obj5;
						continue;
					}
					num = (nint)renderer;
					bool flag14 = (object)renderer == null;
					num3 = num2;
					if (flag14)
					{
						break;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182287AC0");
					Material[] array4 = activeMaterials;
					bool flag15 = activeMaterials == null;
					num3 = unchecked((nint)null);
					material = (Material)(object)array3;
					num = unchecked((nint)null);
					if (flag15)
					{
						break;
					}
					num3 = unchecked((nint)null);
					nint num9 = unchecked((nint)null);
					material = (Material)(object)array3;
					num = unchecked((nint)null);
					while (true)
					{
						if (num >= array4.Length)
						{
							return;
						}
						Material[] array5 = activeMaterials;
						if (activeMaterials == null)
						{
							break;
						}
						num = (nint)Properties.iridescenceColor;
						if (Properties.iridescenceColor == null)
						{
							break;
						}
						AlwaysManager instance2 = AlwaysManager.Instance;
						Color color = colorNothing;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v950 @ rax_v30 (AlwaysManager)+190]");
						object obj11 = 0;
						material = array5[num9];
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v950 @ rax_v30 (AlwaysManager)+188] (should have been resolved before IL gen)");
						Material[] array6 = activeMaterials;
						bool flag16 = activeMaterials == null;
						num3 = (nint)(&color2);
						if (flag16)
						{
							break;
						}
						num = (nint)Properties.albedoColor;
						bool flag17 = Properties.albedoColor == null;
						num3 = (nint)(&color2);
						if (flag17)
						{
							break;
						}
						AlwaysManager instance3 = AlwaysManager.Instance;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v953 @ rax_v33 (AlwaysManager)+190]");
						obj11 = 0;
						material = array6[num9];
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v953 @ rax_v33 (AlwaysManager)+188] (should have been resolved before IL gen)");
						Material[] array7 = activeMaterials;
						bool flag18 = activeMaterials == null;
						num3 = (nint)(&color2);
						if (flag18)
						{
							break;
						}
						num = (nint)Properties.emissionColor;
						bool flag19 = Properties.emissionColor == null;
						num3 = (nint)(&color2);
						if (flag19)
						{
							break;
						}
						AlwaysManager instance4 = AlwaysManager.Instance;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v956 @ rax_v36 (AlwaysManager)+190]");
						obj11 = 0;
						material = array7[num9];
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v956 @ rax_v36 (AlwaysManager)+188] (should have been resolved before IL gen)");
						Material[] array8 = activeMaterials;
						bool flag20 = activeMaterials == null;
						num3 = (nint)(&color2);
						if (flag20)
						{
							break;
						}
						num = (nint)Properties.goochDarkColor;
						bool flag21 = Properties.goochDarkColor == null;
						num3 = (nint)(&color2);
						if (flag21)
						{
							break;
						}
						AlwaysManager instance5 = AlwaysManager.Instance;
						color = defaultGoochDarkColor;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v959 @ rax_v39 (AlwaysManager)+190]");
						obj11 = 0;
						material = array8[num9];
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v959 @ rax_v39 (AlwaysManager)+188] (should have been resolved before IL gen)");
						num = (nint)activeMaterials;
						bool flag22 = activeMaterials == null;
						num3 = (nint)(&color2);
						if (flag22)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v7 (Il2CppStaticFields<AlwaysManager>)+20+v158 @ rbx_v12 (Il2CppStaticFields<AlwaysManager>)*8]");
						bool flag23 = (nint)0 == 0;
						num3 = (nint)(&color2);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v7 (Il2CppStaticFields<AlwaysManager>)+20+v158 @ rbx_v12 (Il2CppStaticFields<AlwaysManager>)*8]");
						num = 0;
						if (flag23)
						{
							break;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v519 @ rcx_v7 (Il2CppStaticFields<AlwaysManager>)+20+v158 @ rbx_v12 (Il2CppStaticFields<AlwaysManager>)*8]");
						((Material)0).SetFloat("_IndirectFade", 1f);
						array4 = activeMaterials;
						num9++;
						bool flag24 = activeMaterials != null;
						float num10 = 1f;
						color2 = defaultGoochDarkColor;
						obj11 = 0;
						num3 = (nint)(&color2);
						material = (Material)(object)"_IndirectFade";
						num = num9;
						if (!flag24)
						{
							num10 = 1f;
							obj11 = 0;
							num3 = (nint)(&color2);
							material = (Material)(object)"_IndirectFade";
							num = num9;
							break;
						}
					}
					break;
				}
				break;
			}
		}
		throw new NullReferenceException();
	}

	public unsafe void SetSkin(SkinData skinData)
	{
		//IL_0049: Expected O, but got I4
		//IL_0052: Expected O, but got I4
		//IL_06da: Unknown result type (might be due to invalid IL or missing references)
		//IL_06df: Expected O, but got Unknown
		//IL_0287: Expected O, but got Ref
		//IL_02e4: Expected O, but got Ref
		//IL_01cf: Expected O, but got Ref
		//IL_03a6: Expected O, but got Ref
		//IL_061a: Expected O, but got I4
		//IL_0670: Expected O, but got I4
		//IL_04ed: Expected O, but got I4
		//IL_0518: Expected O, but got I4
		//IL_05a8: Expected O, but got Ref
		Material[] materials = skinData.materials;
		CreateMaterials(materials.Length);
		int graphicsShaderLevel = SystemInfo.graphicsShaderLevel;
		Material[] array = activeMaterials;
		object obj = 0;
		object obj2 = 0;
		float r2 = default(float);
		float num2 = default(float);
		while ((nint)obj2 < array.Length)
		{
			if (graphicsShaderLevel < 45)
			{
				Material[] materials2 = skinData.materials;
				Texture mainTexture = materials2[obj].mainTexture;
				if (mainTexture != null)
				{
					Material[] array2 = activeMaterials;
					Material[] materials3 = skinData.materials;
					Texture mainTexture2 = materials3[obj].mainTexture;
					array2[obj].SetTexture("_MainTex", mainTexture2);
				}
				Material[] array3 = activeMaterials;
				if (array3[obj].HasProperty("_Color"))
				{
					Material[] array4 = activeMaterials;
					Material[] materials4 = skinData.materials;
					Color color = materials4[obj].color;
					float r = color.r;
					array4[obj].SetColor("_Color", (Color)(&r2));
					r2 = color.r;
				}
			}
			else
			{
				Material[] array5 = activeMaterials;
				Material[] materials5 = skinData.materials;
				Texture mainTexture3 = materials5[obj].mainTexture;
				Properties.albedoMap.SetValue(array5[obj], mainTexture3);
				Material[] array6 = activeMaterials;
				Material[] materials6 = skinData.materials;
				Color color2 = materials6[obj].color;
				Properties.albedoColor.SetValue(array6[obj], (Color)(&r2));
				Material[] array7 = activeMaterials;
				Material[] materials7 = skinData.materials;
				Color color3 = materials7[obj].GetColor("_EmissionColor");
				Properties.emissionColor.SetValue(array7[obj], (Color)(&r2));
				Material[] array8 = activeMaterials;
				Material[] materials8 = skinData.materials;
				Texture texture = materials8[obj].GetTexture("_EmissionMap");
				Properties.emissionMap.SetValue(array8[obj], texture);
				Material[] array9 = activeMaterials;
				Material[] materials9 = skinData.materials;
				ColorProperty goochDarkColor = Properties.goochDarkColor;
				Color color4 = materials9[obj].GetColor("_GoochDarkColor");
				Properties.goochDarkColor.SetValue(array9[obj], (Color)(&r2));
				Material[] array10 = activeMaterials;
				Material[] materials10 = skinData.materials;
				float r = materials10[obj].GetFloat("_IndirectFade");
				array10[obj].SetFloat("_IndirectFade", r);
				Material[] materials11 = skinData.materials;
				int num = materials11[obj].GetInt("_RenderFace");
				if (num == 0)
				{
					Material[] array11 = activeMaterials;
					((EnumProperty<T>)(object)Properties.renderFace).SetValue(array11[obj], (T)null);
					Material[] array12 = activeMaterials;
					Properties.alphaClipping.SetValue(array12[obj], value: true);
					Material[] array13 = activeMaterials;
					Properties.alphaCutoff.SetValue(array13[obj], 0.8f);
					Material[] array14 = activeMaterials;
					((EnumProperty<T>)(object)Properties.outline).SetValue(array14[obj], (T)3);
					Material[] array15 = activeMaterials;
					((EnumProperty<T>)(object)Properties.vertexAnimation).SetValue(array15[obj], (T)1);
					Material[] array16 = activeMaterials;
					Properties.vertexAnimationIntensity.SetValue(array16[obj], 0.05f);
					Material[] array17 = activeMaterials;
					Properties.vertexAnimationStutter.SetValue(array17[obj], value: true);
					Material[] array18 = activeMaterials;
					Vector3Property vertexAnimationFrequency = Properties.vertexAnimationFrequency;
					r = (float)Vector3.oneVector * 6f;
					vertexAnimationFrequency.SetValue(array18[obj], (Vector3)(&num2));
					Material[] array19 = array17;
					r2 = color4.r;
				}
				else
				{
					bool flag = num != 1;
					Material[] array19 = (Material[])(object)goochDarkColor;
					r2 = color4.r;
					if (!flag)
					{
						Material[] array20 = activeMaterials;
						((EnumProperty<T>)(object)Properties.renderFace).SetValue(array20[obj], (T)2);
						Material[] array21 = activeMaterials;
						Properties.alphaClipping.SetValue(array21[obj], value: false);
						Material[] array22 = activeMaterials;
						((EnumProperty<T>)(object)Properties.outline).SetValue(array22[obj], (T)1);
						array19 = activeMaterials;
						EnumProperty<VertexAnimation> vertexAnimation = Properties.vertexAnimation;
						((EnumProperty<T>)(object)vertexAnimation).SetValue(array19[obj], (T)null);
						r2 = color4.r;
					}
				}
			}
			array = activeMaterials;
			obj++;
			obj2 = obj;
		}
	}

	public HatData GetCurrentHat()
	{
		return currentHat;
	}

	public unsafe void SetHat(HatData hatData)
	{
		//IL_008a: Expected O, but got I4
		//IL_0093: Expected O, but got I4
		//IL_019e: Expected O, but got Ref
		//IL_01b2: Expected O, but got Ref
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0164: Expected O, but got Unknown
		//IL_02bc: Expected O, but got Ref
		//IL_02c6: Expected O, but got Ref
		//IL_02df: Expected O, but got Ref
		//IL_02f3: Expected O, but got Ref
		_003C_003Ec__DisplayClass32_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass32_0();
		currentHat = hatData;
		CharacterData characterData = this.characterData;
		if (characterData.meshDefault != null)
		{
			CharacterData characterData2 = this.characterData;
			renderer.sharedMesh = characterData2.meshDefault;
		}
		Transform[] componentsInChildren = rendererObject.GetComponentsInChildren<Transform>();
		object obj = 0;
		object obj2 = 0;
		Quaternion identityQuaternion = default(Quaternion);
		Vector3 vector = default(Vector3);
		while ((nint)obj2 < componentsInChildren.Length)
		{
			GameObject gameObject = componentsInChildren[obj].gameObject;
			string text = gameObject.name;
			string text2 = text.ToLower();
			if (text2 != "head")
			{
				GameObject gameObject2 = componentsInChildren[obj].gameObject;
				string text3 = gameObject2.name;
				string text4 = text3.ToLower();
				if (text4 != "neck")
				{
					obj++;
					obj2 = obj;
					continue;
				}
			}
			hatTransform.parentInternal = componentsInChildren[obj];
			hatTransform.localPosition = (Vector3)(&identityQuaternion);
			hatTransform.localRotation = (Quaternion)(&vector);
			identityQuaternion = Quaternion.identityQuaternion;
			break;
		}
		if (hatData != null)
		{
			CharacterData characterData3 = this.characterData;
			CS_0024_003C_003E8__locals2.character = characterData3.eCharacter;
			GameObject gameObject3 = hatTransform.gameObject;
			gameObject3.SetActive(value: true);
			hatFilter.sharedMesh = hatData.mesh;
			((Renderer)hatRenderer).SetMaterial(hatData.material);
			Predicate<HatOrientation> match = (Predicate<object>)delegate(HatOrientation x)
			{
				//IL_0053: Expected I4, but got O
				//IL_0031: Expected O, but got I4
				if (x == null)
				{
					NullReferenceException ex = new NullReferenceException();
					return (byte)(int)ex != 0;
				}
				object obj3 = x.character - CS_0024_003C_003E8__locals2.character;
				return obj3 == null;
			};
			HatOrientation hatOrientation = hatData.orientations.Find(match);
			if (hatOrientation == null)
			{
				return;
			}
			hatTransform.localPosition = (Vector3)(&identityQuaternion);
			Vector3 vector2 = default(Vector3);
			Quaternion quaternion2 = Quaternion.Internal_FromEulerRad((Vector3)(&vector2));
			float num = default(float);
			hatTransform.localRotation = (Quaternion)(&num);
			float num2 = default(float);
			hatTransform.localScale = (Vector3)(&num2);
			SkinnedMeshRenderer skinnedMeshRenderer;
			Mesh sharedMesh;
			if (hatOrientation.meshForHat == EMeshForHat.Low)
			{
				CharacterData characterData4 = this.characterData;
				skinnedMeshRenderer = renderer;
				sharedMesh = characterData4.meshLow;
			}
			else
			{
				if (hatOrientation.meshForHat != EMeshForHat.Lowest)
				{
					return;
				}
				CharacterData characterData5 = this.characterData;
				skinnedMeshRenderer = renderer;
				sharedMesh = characterData5.meshLowest;
			}
			skinnedMeshRenderer.sharedMesh = sharedMesh;
		}
		else
		{
			GameObject gameObject4 = hatTransform.gameObject;
			gameObject4.SetActive(value: false);
		}
	}

	private void LateUpdate()
	{
	}

	private bool HasRenderer()
	{
		return rendererObject != null;
	}

	public void ResetMaterial()
	{
		if (isDamageFlash)
		{
			isDamageFlash = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182287AC0");
		}
	}

	public void ForceMoving(bool b)
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171F7D]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		animator.SetBool("moving", b);
	}

	private unsafe void Update()
	{
		//IL_0008: Expected O, but got Ref
		//IL_00b4: Invalid comparison between I4 and F4
		//IL_0e41: Expected I, but got O
		//IL_00ee: Expected O, but got I4
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Expected O, but got Unknown
		//IL_01c3: Expected O, but got Ref
		//IL_026b: Invalid comparison between F4 and I4
		//IL_03d4: Expected O, but got I4
		//IL_02a7: Invalid comparison between F4 and I4
		//IL_0e54: Expected I, but got O
		//IL_0f0d: Invalid comparison between F4 and I4
		//IL_0f36: Expected O, but got I4
		//IL_023d: Expected O, but got Ref
		//IL_0b10: Expected O, but got Ref
		//IL_0b10: Expected O, but got Ref
		//IL_0f64: Expected I, but got O
		//IL_03e3: Expected O, but got F4
		//IL_0b27: Expected O, but got Ref
		//IL_0b27: Expected O, but got Ref
		//IL_0c00: Expected F4, but got O
		//IL_0c10: Expected F4, but got I
		//IL_0c26: Expected O, but got I4
		//IL_0309: Invalid comparison between F4 and I4
		//IL_0345: Invalid comparison between F4 and I4
		//IL_0d50: Expected O, but got I
		//IL_062d: Expected O, but got I
		//IL_0cd6: Invalid comparison between I4 and F4
		//IL_06cb: Expected F4, but got I4
		//IL_0d77: Expected O, but got I
		//IL_0d87: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d8c: Expected O, but got Unknown
		//IL_0dcc: Expected O, but got I
		//IL_0fc1: Expected O, but got I
		//IL_0fde: Expected O, but got I
		//IL_1001: Invalid comparison between F4 and O
		//IL_03a1: Expected O, but got I4
		//IL_0488: Expected O, but got Ref
		//IL_0488: Expected O, but got Ref
		//IL_04a7: Expected O, but got I
		//IL_1023: Expected I, but got O
		//IL_105e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1063: Expected O, but got Unknown
		//IL_10ad: Invalid comparison between F4 and O
		//IL_10cc: Invalid comparison between F4 and I4
		//IL_10f5: Expected O, but got I4
		//IL_06ed: Expected O, but got I
		//IL_071b: Expected O, but got I
		//IL_0754: Unknown result type (might be due to invalid IL or missing references)
		//IL_0759: Expected O, but got Unknown
		//IL_0769: Unknown result type (might be due to invalid IL or missing references)
		//IL_076e: Expected O, but got Unknown
		//IL_07ce: Expected O, but got Ref
		//IL_07ce: Expected O, but got Ref
		//IL_07e1: Expected O, but got F4
		//IL_085e: Expected O, but got I4
		//IL_0882: Unknown result type (might be due to invalid IL or missing references)
		//IL_0887: Expected I4, but got Unknown
		//IL_07fd: Expected O, but got Ref
		//IL_0503: Expected O, but got I
		//IL_08fe: Expected O, but got I4
		//IL_091e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0923: Expected I4, but got Unknown
		//IL_0533: Expected O, but got I
		//IL_056b: Invalid comparison between I4 and F4
		//IL_05b6: Expected F4, but got I4
		//IL_0a11: Expected O, but got I4
		//IL_0a31: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a36: Expected I4, but got Unknown
		object obj2 = default(object);
		object obj = (object)(&obj2);
		_ = 0;
		_ = 0;
		if (activeMaterials == null)
		{
			return;
		}
		PlayerCamera instance = PlayerCamera.Instance;
		if (((object)PlayerCamera.Instance != null && instance.cameraState == PlayerCamera.ECameraState.Portal) || !(this.playerMovement != null) || !(animator != null))
		{
			return;
		}
		float speed = animator.speed;
		if (!(0f < speed))
		{
			return;
		}
		nint num = (nint)typeof(UnityEngine.Object);
		bool flag = rendererObject != null;
		object obj3 = (flag ? 1 : 0) ^ 1;
		object obj4 = obj3 | MyTime.paused;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1103 @ rcx_v14 (Il2CppClass<UnityEngine.Object>)+E4]");
		if ((nint)0 != 0)
		{
			return;
		}
		if ((isDamageFlash ? 1 : 0) != (nint)obj4 && !(MyTime.time < resetMaterialTime) && isDamageFlash)
		{
			isDamageFlash = false;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182287AC0");
		}
		Transform transform = base.transform;
		PlayerMovement playerMovement = this.playerMovement;
		Vector3 position = playerMovement.feet.position;
		float num2 = default(float);
		transform.position = (Vector3)(&num2);
		Vector3 wishDir = this.playerMovement.GetWishDir();
		float num3 = wishDir.x;
		float num4 = wishDir.z;
		float x = default(float);
		float num12 = default(float);
		object obj6;
		if (ChallengesTracker.HasChallengeModifier("no_movement"))
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInput playerInput = instance2.playerInput;
			Quaternion quaternion2 = Quaternion.Internal_FromEulerRad((Vector3)(&num2));
			Vector3 vector = (Quaternion)(&x) * (Vector3)(&num2);
			Vector3 vector3 = default(Vector3);
			Vector3 vector2 = (Quaternion)(&x) * (Vector3)(&vector3);
			float num5 = vector.x * playerInput.moveVertical;
			float num6 = playerInput.moveHorizontal * vector2.x;
			float num7 = vector.y * playerInput.moveVertical;
			float num8 = playerInput.moveHorizontal * vector2.y;
			float num9 = num6 + num5;
			float num10 = playerInput.moveHorizontal * vector2.z;
			float num11 = vector.z * playerInput.moveVertical;
			num12 = num8 + num7;
			float num13 = num10 + num11;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
			object obj5 = default(object);
			num3 = (float)obj5;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1233 @ rax_v130+8]");
			num4 = 0f;
			x = quaternion2.x;
			obj6 = 0;
		}
		PlayerMovement playerMovement2 = this.playerMovement;
		float x2 = playerMovement2.x;
		Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000180349935h\"");
		if (playerMovement2.x == 0f)
		{
			x2 = playerMovement2.y;
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 0000000180349935h\"");
			if (playerMovement2.y == 0f && playerMovement2.climbCancel >= playerMovement2.climbCancelTicks)
			{
				x2 = playerMovement2.x;
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018034995Bh\"");
				if (playerMovement2.x == 0f)
				{
					x2 = playerMovement2.y;
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"jp near ptr 000000018034995Bh\"");
					if (playerMovement2.y == 0f)
					{
						if (!moving)
						{
							float num14 = movingToIdleTimeout + stoppedMovingAtTime;
							x2 = MyTime.time;
							if (!(MyTime.time < num14))
							{
								animator.SetBool("moving", value: false);
								obj6 = 0;
							}
						}
						else
						{
							stoppedMovingAtTime = MyTime.time;
							moving = false;
						}
					}
				}
				goto IL_0e46;
			}
		}
		animator.SetBool("moving", value: true);
		moving = true;
		obj6 = 0;
		goto IL_0e46;
		IL_0e46:
		nint num15 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1448 @ rax_v34 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num16 = 0;
		object obj7 = default(object);
		float num17 = (float)obj7 - num12;
		float num18 = num3 - (float)Vector3.zeroVector;
		float num19 = num4;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1449 @ rcx_v27 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		float num20 = num19 - 0f;
		float num21 = num17 * num17;
		float num22 = num18 * num18;
		float num23 = num20 * num20;
		float num24 = num21 + num22;
		float num25 = num24 + num23;
		bool flag2 = 9.9999994E-11f < num25;
		float num26 = 9.9999994E-11f - num25;
		bool flag3 = num26 == 0f;
		bool flag4 = !flag2;
		bool flag5 = !flag3;
		object obj8 = flag5 & flag4;
		if (obj8 == null)
		{
			lastValidMoveDirection = (Vector3)num3;
		}
		nint num27 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1540 @ rax_v39 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num28 = 0;
		smoothingMultiplier = 1f;
		bool flag6 = PlayerMovement.Instance.IsGrinding();
		PlayerMovement playerMovement3 = this.playerMovement;
		Vector3 vector5 = default(Vector3);
		object obj9;
		if (!flag6)
		{
			if (playerMovement3.climbCancel >= playerMovement3.climbCancelTicks)
			{
				Transform transform2 = base.transform;
				float num29 = transform2.position.x + (float)Vector3.upVector;
				GameManager instance3 = GameManager.Instance;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822ACF50");
				Vector3 vector4 = default(Vector3);
				int layerMask = default(int);
				bool flag7 = Physics.Raycast((Vector3)(&vector4), (Vector3)(&vector5), out var hitInfo, 51f, layerMask);
				bool flag8 = !flag7;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rcx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
				obj9 = 0;
				num2 = num29;
				if (!flag8)
				{
					Collider collider = hitInfo.collider;
					GameObject gameObject = collider.gameObject;
					bool flag9 = gameObject.CompareTag("CameraIgnore");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1541 @ rcx_v29 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
					obj9 = 0;
					num2 = num29;
					if (!flag9)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182268200");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1676 @ rax_v97+8]");
						obj9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18231C560");
						object obj10 = default(object);
						float num30 = (float)obj10 - 1f;
						float num31 = num30 / 3f;
						if (!(0f > num31))
						{
							if (num31 > 1f)
							{
								num31 = 1f;
							}
						}
						else
						{
							num31 = 0f;
						}
						float num32 = num31 * 0.95f;
						float num33 = 1f - num32;
						smoothingMultiplier = num33;
						num2 = num29;
					}
				}
			}
			else
			{
				float num34 = (float)playerMovement3._003CwallNormal_003Ek__BackingField + (float)Vector3.upVector;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180331950");
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1598 @ rax_v82+8]");
				obj9 = 0;
				num2 = num34;
			}
		}
		else
		{
			Rail rail = playerMovement3.rail;
			float3 float5 = rail.splineContainer.EvaluateUpVector(playerMovement3.progress);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			PlayerMovement playerMovement4 = this.playerMovement;
			Rail rail2 = playerMovement4.rail;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v665 @ rax_v76+8]");
			obj9 = 0;
			float3 float6 = rail2.splineContainer.EvaluateTangent(playerMovement4.progress);
			float num35 = playerMovement4.railDirectionMultiplier * float6.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @18034A5F0");
			object obj11 = default(object);
			lastValidMoveDirection = (Vector3)obj11;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1673 @ rax_v78+8]");
			_ = 0;
			num2 = num35;
		}
		float deltaTime = Time.deltaTime;
		float num36 = deltaTime * 14f;
		float num37 = num36 * smoothingMultiplier;
		if (!(0f > num37))
		{
			if (num37 > 1f)
			{
				num37 = 1f;
			}
		}
		else
		{
			num37 = 0f;
		}
		Vector3 vector6 = lastValidMoveDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+170]");
		object obj12 = 0;
		object obj13 = obj9;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
		object obj14 = obj13 - 0;
		float num38 = (float)obj14 * num37;
		float num39 = num38;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
		float num40 = num39 + 0f;
		Vector3 vector7 = default(Vector3);
		smoothedNormal = vector7;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+174]");
		object obj15 = 0;
		object obj16 = (object)smoothedNormal * (object)smoothedNormal;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+164]");
		nint num41 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+164]");
		object obj17 = num41 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
		nint num42 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
		object obj18 = num42 * 0;
		object obj19 = obj17 + obj16;
		object obj20 = obj19 + obj18;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj20))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+170]");
			nint num43 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+164]");
			object obj21 = num43 * 0;
			object obj22 = (object)lastValidMoveDirection * (object)smoothedNormal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+174]");
			nint num44 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
			object obj23 = num44 * 0;
			object obj24 = obj21 + obj22;
			object obj25 = obj24 + obj23;
			object obj26 = obj25 * (object)smoothedNormal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+164]");
			object obj27 = obj25 * 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
			object obj28 = obj25 * 0;
			object obj29 = obj26 / obj20;
			object obj30 = obj27 / obj20;
			object obj31 = obj28 / obj20;
			vector6 = (Vector3)((object)vector6 - obj29);
			obj12 -= obj30;
			obj15 -= obj31;
		}
		nint num45 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1903 @ rax_v46 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num46 = 0;
		object obj32 = obj12 - obj7;
		object obj33 = vector6 - Vector3.zeroVector;
		object obj34 = obj15;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1904 @ rcx_v38 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj35 = obj34 - 0;
		object obj36 = obj32 * obj32;
		object obj37 = obj33 * obj33;
		object obj38 = obj35 * obj35;
		object obj39 = obj36 + obj37;
		object obj40 = obj39 + obj38;
		bool flag10 = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj40);
		float num47 = 9.9999994E-11f - (float)obj40;
		bool flag11 = num47 == 0f;
		bool flag12 = !flag10;
		bool flag13 = !flag11;
		object obj41 = flag13 & flag12;
		if (obj41 == null)
		{
			desiredLookRotation = (Quaternion)Quaternion.LookRotation((Vector3)(&num2), (Vector3)(&vector5)).x;
			Transform transform3 = base.transform;
			transform3.rotation = (Quaternion)(&x);
		}
		bool value;
		if (this.playerMovement.IsTouchingGround())
		{
			value = true;
		}
		else
		{
			PlayerMovement playerMovement5 = this.playerMovement;
			object obj42 = playerMovement5.climbCancel - playerMovement5.climbCancelTicks;
			int num48 = playerMovement5.climbCancel ^ playerMovement5.climbCancelTicks;
			int num49 = playerMovement5.climbCancel ^ obj42;
			int num50 = num48 & num49;
			bool flag14 = num50 < 0;
			bool flag15 = (nint)obj42 < 0;
			value = flag15 != flag14;
		}
		animator.SetBool("grounded", value);
		PlayerMovement playerMovement6 = this.playerMovement;
		object obj43 = playerMovement6.resetJumpCounter - 4;
		int num51 = playerMovement6.resetJumpCounter ^ 4;
		int num52 = playerMovement6.resetJumpCounter ^ obj43;
		int num53 = num51 & num52;
		bool flag16 = num53 < 0;
		bool flag17 = (nint)obj43 < 0;
		bool value2 = flag17 != flag16;
		animator.SetBool("jumping", value2);
		string text;
		bool value3;
		if (this.playerMovement.IsGrinding())
		{
			text = "grinding";
			value3 = true;
		}
		else
		{
			PlayerMovement playerMovement7 = this.playerMovement;
			if (playerMovement7._003CcrouchState_003Ek__BackingField <= PlayerMovement.CrouchState.None)
			{
				text = "grinding";
				value3 = false;
			}
			else
			{
				float num54 = playerMovement7.jumpedTime + playerMovement7.jumpAnimationCooldownSlide;
				if (!(MyTime.time > num54))
				{
					text = "grinding";
					value3 = false;
				}
				else
				{
					object obj44 = playerMovement7.resetJumpCounter - 4;
					int num55 = playerMovement7.resetJumpCounter ^ 4;
					int num56 = playerMovement7.resetJumpCounter ^ obj44;
					int num57 = num55 & num56;
					bool flag18 = num57 < 0;
					bool flag19 = (nint)obj44 < 0;
					value3 = flag19 == flag18;
					text = "grinding";
				}
			}
		}
		animator.SetBool(text, value3);
	}

	public unsafe void ForceRotation(Vector3 dir)
	{
		//IL_0169: Expected I, but got O
		//IL_01a0: Expected O, but got F4
		//IL_01c4: Expected O, but got I
		//IL_01d4: Expected O, but got I
		//IL_020c: Expected O, but got I
		//IL_0229: Expected O, but got I
		//IL_024c: Invalid comparison between F4 and O
		//IL_026e: Expected I, but got O
		//IL_02a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ae: Expected O, but got Unknown
		//IL_02f8: Invalid comparison between F4 and O
		//IL_0317: Invalid comparison between F4 and I4
		//IL_0340: Expected O, but got I4
		//IL_0045: Expected O, but got I
		//IL_0073: Expected O, but got I
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Expected O, but got Unknown
		//IL_00c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Expected O, but got Unknown
		//IL_0126: Expected O, but got Ref
		//IL_0126: Expected O, but got Ref
		//IL_0139: Expected O, but got F4
		//IL_0155: Expected O, but got Ref
		nint num = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v36 @ rax_v3 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num2 = 0;
		smoothedNormal = Vector3.upVector;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v37 @ r8_v1 (Il2CppStaticFields<UnityEngine.Vector3>)+20]");
		_ = 0;
		lastValidMoveDirection = (Vector3)dir.x;
		_ = dir.z;
		Vector3 vector = lastValidMoveDirection;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+170]");
		object obj = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+174]");
		object obj2 = 0;
		object obj3 = (object)smoothedNormal * (object)smoothedNormal;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+164]");
		nint num3 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+164]");
		object obj4 = num3 * 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
		nint num4 = 0;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
		object obj5 = num4 * 0;
		object obj6 = obj4 + obj3;
		object obj7 = obj6 + obj5;
		if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)Mathf.Epsilon) <= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj7))
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+170]");
			nint num5 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+164]");
			object obj8 = num5 * 0;
			object obj9 = (object)lastValidMoveDirection * (object)smoothedNormal;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+174]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
			object obj10 = num6 * 0;
			object obj11 = obj8 + obj9;
			object obj12 = obj11 + obj10;
			object obj13 = (object)smoothedNormal * obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+164]");
			object obj14 = 0 * obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ rcx (PlayerRenderer)+168]");
			object obj15 = 0 * obj12;
			object obj16 = obj13 / obj7;
			object obj17 = obj14 / obj7;
			object obj18 = obj15 / obj7;
			vector = (Vector3)((object)vector - obj16);
			obj -= obj17;
			obj2 -= obj18;
		}
		nint num7 = (nint)typeof(Vector3);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v128 @ rax_v9 (Il2CppClass<UnityEngine.Vector3>)+B8]");
		nint num8 = 0;
		object obj20 = default(object);
		object obj19 = obj - obj20;
		object obj21 = vector - Vector3.zeroVector;
		object obj22 = obj2;
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ rcx_v5 (Il2CppStaticFields<UnityEngine.Vector3>)+8]");
		object obj23 = obj22 - 0;
		object obj24 = obj19 * obj19;
		object obj25 = obj21 * obj21;
		object obj26 = obj23 * obj23;
		object obj27 = obj24 + obj25;
		object obj28 = obj27 + obj26;
		bool flag = System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref (object)9.9999994E-11f) < System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj28);
		float num9 = 9.9999994E-11f - (float)obj28;
		bool flag2 = num9 == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		object obj29 = flag4 & flag3;
		if (obj29 == null)
		{
			Vector3 vector2 = default(Vector3);
			object obj30 = default(object);
			desiredLookRotation = (Quaternion)Quaternion.LookRotation((Vector3)(&vector2), (Vector3)(&obj30)).x;
			Transform transform = base.transform;
			transform.rotation = (Quaternion)(&vector2);
		}
	}

	private void ForceWalkAnimation()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [183171F7F]");
		if ((nint)0 == 0)
		{
			_ = 1;
		}
		animator.Play("Walking");
	}

	private void OnPause(bool paused)
	{
		//IL_0045: Expected F4, but got I4
		if (animator != null)
		{
			float speed = ((!paused) ? 1f : 0f);
			animator.speed = speed;
		}
	}

	private void OnDamage(PlayerHealth ph, DamageContainer dc, bool shieldDamage)
	{
		//IL_0013: Invalid comparison between F4 and I4
		//IL_0027: Invalid comparison between F4 and I4
		if (!isDamageFlash)
		{
			bool flag = ph.shield < 0f;
			bool flag2 = ph.shield == 0f;
			bool flag3 = !flag;
			bool flag4 = !flag2;
			bool flag5 = flag4 & flag3;
			if (shieldActive != flag5)
			{
				shieldActive = flag5;
				RefreshPlayerOutlines();
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822873E0");
			Material[] array = default(Material[]);
			beforeDamageFlashMaterials = array;
			((Renderer)renderer).SetMaterial(damageFlash);
			float num = MyTime.time + 0.15f;
			isDamageFlash = true;
			resetMaterialTime = num;
		}
	}

	private void OnHeal(PlayerHealth ph, float amount, bool isShield)
	{
		//IL_000e: Invalid comparison between F4 and I4
		//IL_0022: Invalid comparison between F4 and I4
		bool flag = ph.shield < 0f;
		bool flag2 = ph.shield == 0f;
		bool flag3 = !flag;
		bool flag4 = !flag2;
		bool flag5 = flag4 & flag3;
		if (shieldActive != flag5)
		{
			shieldActive = flag5;
			RefreshPlayerOutlines();
		}
	}

	private void ChangeShield(bool on)
	{
		if (shieldActive != on)
		{
			shieldActive = on;
			RefreshPlayerOutlines();
		}
	}

	private unsafe void RefreshPlayerOutlines()
	{
		//IL_00f9: Expected O, but got Ref
		//IL_01ee: Expected O, but got Ref
		if (!shieldActive)
		{
			if (this.outline != null)
			{
				this.outline.enabled = false;
			}
			if (hatOutline != null)
			{
				hatOutline.enabled = false;
			}
			return;
		}
		Color color = default(Color);
		if (this.outline == null)
		{
			GameObject gameObject = renderer.gameObject;
			Outline outline = gameObject.AddComponent<Outline>();
			this.outline = outline;
			this.outline.OutlineColor = (Color)(&color);
			this.outline.OutlineWidth = 6f;
			this.outline.OutlineMode = Outline.Mode.OutlineVisible;
			color = shieldColor;
		}
		this.outline.enabled = true;
		GameObject gameObject2 = hatTransform.gameObject;
		if (gameObject2.activeInHierarchy)
		{
			if (hatOutline == null)
			{
				GameObject gameObject3 = hatRenderer.gameObject;
				Outline outline2 = gameObject3.AddComponent<Outline>();
				hatOutline = outline2;
				hatOutline.OutlineColor = (Color)(&color);
				hatOutline.OutlineWidth = 6f;
				hatOutline.OutlineMode = Outline.Mode.OutlineVisible;
			}
			hatOutline.enabled = true;
		}
	}

	public void SetMaterial(Material mat)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0066: Expected O, but got I4
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Expected O, but got Unknown
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Expected O, but got Unknown
		Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
		object obj = 0;
		object obj2 = 0;
		object obj6 = default(object);
		object obj7 = default(object);
		object obj8 = default(object);
		while ((nint)obj2 < componentsInChildren.Length)
		{
			ParticleSystem component = componentsInChildren[obj].GetComponent<ParticleSystem>();
			if (component == null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1822873E0");
				object obj3 = 0;
				while (true)
				{
					object obj4 = obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v78 @ rax_v13+18]");
					if ((nint)obj4 >= 0)
					{
						break;
					}
					if ((object)mat != null)
					{
						object obj5 = obj6;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180268B40");
						if (obj7 == null)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @180269410");
							throw obj8;
						}
					}
					obj3++;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @182287AC0");
			}
			obj++;
			obj2 = obj;
		}
	}

	public void SetIdle()
	{
		if (animator != null)
		{
			animator.SetBool("grounded", value: true);
			animator.SetBool("moving", value: false);
			CharacterData characterData = this.characterData;
			if (characterData.eCharacter == ECharacter.Calcium)
			{
				animator.SetBool("idle", value: true);
			}
		}
	}

	private void OnDeath()
	{
		animator.speed = 0f;
	}

	private void OnStatusEffectAdded(EStatusEffect effect, bool newEffect)
	{
		RefreshStatusEffectColor();
	}

	private void OnStatusEffectRemoved(EStatusEffect effect)
	{
		RefreshStatusEffectColor();
	}

	private unsafe void RefreshStatusEffectColor()
	{
		//IL_04c2: Expected O, but got I4
		//IL_040a: Expected O, but got I4
		//IL_04e8: Expected O, but got Ref
		//IL_04f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_04f6: Expected O, but got Unknown
		//IL_0430: Expected O, but got I4
		//IL_0352: Expected O, but got I4
		//IL_046c: Expected O, but got Ref
		//IL_0496: Unknown result type (might be due to invalid IL or missing references)
		//IL_049b: Expected O, but got Unknown
		//IL_0378: Expected O, but got I4
		//IL_0294: Expected O, but got I4
		//IL_03b4: Expected O, but got Ref
		//IL_03de: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e3: Expected O, but got Unknown
		//IL_02ba: Expected O, but got I4
		//IL_01dc: Expected O, but got I4
		//IL_02f6: Expected O, but got Ref
		//IL_0320: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Expected O, but got Unknown
		//IL_0335: Expected O, but got I
		//IL_0202: Expected O, but got I4
		//IL_023e: Expected O, but got Ref
		//IL_0166: Expected O, but got I4
		//IL_0268: Unknown result type (might be due to invalid IL or missing references)
		//IL_026d: Expected O, but got Unknown
		//IL_018b: Expected O, but got Ref
		//IL_01b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b5: Expected O, but got Unknown
		Color color = default(Color);
		if (!(MyPlayer.Instance != null))
		{
			Material[] array = activeMaterials;
			object obj = 0;
			while ((nint)obj < array.Length)
			{
				Properties.iridescenceColor.SetValue(array[obj], (Color)(&color));
				obj++;
			}
			return;
		}
		MyPlayer instance = MyPlayer.Instance;
		PlayerInventory inventory = instance.inventory;
		if (!inventory.statusEffects.HasStatusEffect(EStatusEffect.Freeze))
		{
			MyPlayer instance2 = MyPlayer.Instance;
			PlayerInventory inventory2 = instance2.inventory;
			if (!inventory2.statusEffects.HasStatusEffect(EStatusEffect.Slow))
			{
				MyPlayer instance3 = MyPlayer.Instance;
				PlayerInventory inventory3 = instance3.inventory;
				if (!inventory3.statusEffects.HasStatusEffect(EStatusEffect.Bleed))
				{
					MyPlayer instance4 = MyPlayer.Instance;
					PlayerInventory inventory4 = instance4.inventory;
					if (!inventory4.statusEffects.HasStatusEffect(EStatusEffect.Poison))
					{
						MyPlayer instance5 = MyPlayer.Instance;
						PlayerInventory inventory5 = instance5.inventory;
						if (!inventory5.statusEffects.HasStatusEffect(EStatusEffect.BossPoison))
						{
							Material[] array2 = activeMaterials;
							object obj2 = 0;
							while ((nint)obj2 < array2.Length)
							{
								Properties.iridescenceColor.SetValue(array2[obj2], (Color)(&color));
								array2[obj2].EnableKeyword("_MK_IRIDESCENCE_DEFAULT");
								obj2++;
								color = colorNothing;
							}
							return;
						}
					}
					Material[] array3 = activeMaterials;
					object obj3 = 0;
					while ((nint)obj3 < array3.Length)
					{
						((EnumProperty<T>)(object)Properties.iridescence).SetValue(array3[obj3], (T)1);
						array3[obj3].EnableKeyword("_MK_IRIDESCENCE_DEFAULT");
						Properties.iridescenceColor.SetValue(array3[obj3], (Color)(&color));
						Properties.iridescenceSize.SetValue(array3[obj3], 0.5f);
						obj3++;
						color = poisonColor;
					}
				}
				else
				{
					Material[] array4 = activeMaterials;
					object obj4 = 0;
					while ((nint)obj4 < array4.Length)
					{
						((EnumProperty<T>)(object)Properties.iridescence).SetValue(array4[obj4], (T)1);
						array4[obj4].EnableKeyword("_MK_IRIDESCENCE_DEFAULT");
						Properties.iridescenceColor.SetValue(array4[obj4], (Color)(&color));
						Properties.iridescenceSize.SetValue(array4[obj4], 0.18f);
						obj4++;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [18262ED40]");
						color = (Color)0;
					}
				}
			}
			else
			{
				Material[] array5 = activeMaterials;
				object obj5 = 0;
				while ((nint)obj5 < array5.Length)
				{
					((EnumProperty<T>)(object)Properties.iridescence).SetValue(array5[obj5], (T)1);
					array5[obj5].EnableKeyword("_MK_IRIDESCENCE_DEFAULT");
					Properties.iridescenceColor.SetValue(array5[obj5], (Color)(&color));
					Properties.iridescenceSize.SetValue(array5[obj5], 0.18f);
					obj5++;
					color = colorMud;
				}
			}
		}
		else
		{
			Material[] array6 = activeMaterials;
			object obj6 = 0;
			while ((nint)obj6 < array6.Length)
			{
				((EnumProperty<T>)(object)Properties.iridescence).SetValue(array6[obj6], (T)1);
				array6[obj6].EnableKeyword("_IRIDESCENCE_ON");
				Properties.iridescenceColor.SetValue(array6[obj6], (Color)(&color));
				Properties.iridescenceSize.SetValue(array6[obj6], 0.18f);
				obj6++;
				color = colorFreeze;
			}
		}
	}

	public unsafe void SetOutlineColor(Color color)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_003d: Expected O, but got Ref
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Expected O, but got Unknown
		Material[] array = activeMaterials;
		object obj = 0;
		object obj2 = 0;
		float num = default(float);
		while ((nint)obj2 < array.Length)
		{
			Properties.outlineColor.SetValue(array[obj], (Color)(&num));
			obj++;
			obj2 = obj;
		}
	}

	public unsafe void SetRim(Color color, float size)
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_003d: Expected O, but got I4
		//IL_005d: Expected O, but got Ref
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Expected O, but got Unknown
		Material[] array = activeMaterials;
		object obj = 0;
		object obj2 = 0;
		float r = default(float);
		while ((nint)obj2 < array.Length)
		{
			((EnumProperty<T>)(object)Properties.rim).SetValue(array[obj], (T)1);
			Properties.rimColor.SetValue(array[obj], (Color)(&r));
			Properties.rimSize.SetValue(array[obj], size);
			obj++;
			r = color.r;
			obj2 = obj;
		}
	}

	public void SetRimOff()
	{
		//IL_000e: Expected O, but got I4
		//IL_0017: Expected O, but got I4
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Expected O, but got Unknown
		Material[] array = activeMaterials;
		object obj = 0;
		object obj2 = 0;
		while ((nint)obj2 < array.Length)
		{
			((EnumProperty<T>)(object)Properties.rim).SetValue(array[obj], (T)null);
			obj++;
			obj2 = obj;
		}
	}

	public PlayerRenderer()
	{
		//IL_002e: Expected O, but got I4
		//IL_003d: Expected O, but got F4
		rotationSpeed = 15f;
		movingToIdleTimeout = 0.1f;
		List<Renderer> list = new List<Renderer>();
		subRenderers = list;
		Color color = MyColorUtility.StringToColor("#808080");
		smoothingMultiplier = 1f;
		colorNothing = (Color)0;
		defaultGoochDarkColor = (Color)color.r;
		_ = 0;
		base._002Ector();
	}
}
