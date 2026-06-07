using System;
using System.Collections;
using System.Collections.Generic;
using MalbersAnimations.Controller;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using MalbersAnimations.Weapons;
using UnityEngine;

namespace MalbersAnimations
{
	[AddComponentMenu("Malbers/Weapons/Weapon Manager [AC]")]
	public class MWeaponManager : MonoBehaviour, IAnimatorListener, IMAnimator, IMWeaponOwner, IMDamagerSet, IWeaponManager
	{
		public bool SmoothEquip;

		private List<int> animatorHashParams;

		protected MWeapon WeaponEquippedOnDisable;

		private bool ExitByState;

		public bool ExitByMode;

		protected bool JustChangedAction;

		private IEnumerator C_SmoothEquip;

		private IEnumerator C_SmoothUneEquip;

		private int LastAttackTriggerHash;

		public bool UseWeaponsOnlyWhileRiding = true;

		[Tooltip("Reference for the Character Controller (Using Animal Controller as Main Character)")]
		public MAnimal animal;

		[Tooltip("If the weapon is dropped from a holster it will be dropped from this point, relative to the WeaponManager")]
		public Transform DropPoint;

		[Tooltip("Mode ID used for Draw Unsheathe Weapons")]
		public ModeID DrawWeaponModeID;

		[Tooltip("Mode ID used for Store/Sheathe Weapons")]
		public ModeID StoreWeaponModeID;

		[Tooltip("Mode ID used for to attack with no weapons. If is Set ")]
		public ModeID UnarmedModeID;

		[Tooltip("Reference for the Combo Manager component")]
		public ComboManager comboManager;

		[Tooltip("Value to set the branch on the Combo Manager when the Main Attack is called")]
		public IntReference mainAttackBranch = new IntReference(0);

		[Tooltip("Value to set the branch on the Combo Manager when the Main Attack is called")]
		public IntReference secondAttackBranch = new IntReference(1);

		[Tooltip("Ignore the Left and Right hand Offsets")]
		public BoolReference IgnoreHandOffset = new BoolReference();

		[Tooltip("Ignore all Draw|Unsheathe animations for all weapons")]
		[SerializeField]
		protected BoolReference m_IgnoreDraw = new BoolReference(value: false);

		[Tooltip("Ignore all Store|sheathe animations for all weapons")]
		[SerializeField]
		protected BoolReference m_IgnoreStore = new BoolReference(value: false);

		[Tooltip("Disable these modes when a weapon is equipped")]
		public List<ModeID> DisableModes = new List<ModeID>();

		[Tooltip("Unequip Weapons If any of these modes are Activated")]
		public List<ModeID> ExitOnModes = new List<ModeID>();

		[Tooltip("Disable these States when a weapon is equipped")]
		public List<StateID> DisableStates = new List<StateID>();

		[Tooltip("Unequip Weapons If any of these modes are Activated")]
		public List<StateID> ExitOnState = new List<StateID>();

		[Tooltip("Unequip Weapons If any of these modes are Activated.Ignore Store|Sheathe animations")]
		public bool ExitFast;

		[Tooltip("Store current active weapon to its own holster. (Disable for Assasing Creed Mode)")]
		public bool StoreSelfHolster;

		public bool UseExternal = true;

		[Tooltip("If the Weapon sent on the EquipExternal Method is a Prefab... instantiate it")]
		public bool InstantiateOnEquip = true;

		[Tooltip("Destroy the Weapon when is unequipped")]
		public bool DestroyOnUnequip;

		[Tooltip("Override the Weapon Layer Mask when equipped. This will be ignored when is set to none")]
		public LayerReference OverrideWeaponLayer = new LayerReference(0);

		public bool UseHolsters;

		public List<Holster> holsters = new List<Holster>();

		public float HolsterTime = 0.2f;

		[Tooltip("Tranform Reference for the Left Hand. The weapon will be parented to this transform when is equipped")]
		[ContextMenuItem("Find Left Hand", "FindLHand")]
		[RequiredField]
		public Transform LeftHandEquipPoint;

		[Tooltip("Tranform Reference for the Right Hand. The weapon will be parented to this transform when is equipped")]
		[ContextMenuItem("Find Right Hand", "FindRHand")]
		[RequiredField]
		public Transform RightHandEquipPoint;

		[SerializeField]
		internal string m_CombatLayerPath = "Layers/Combat2";

		[SerializeField]
		internal string m_CombatLayerName = "Upper Body (AC Weapons)";

		public bool debug;

		[RequiredField]
		[SerializeField]
		private Animator anim;

		private Weapon_Action weaponAction;

		[Tooltip("If the weapon is on the Idle Action it will be stored after X seconds. If Zero, this feature will be ignored.")]
		public FloatReference StoreAfter = new FloatReference(0f);

		[SerializeField]
		[Tooltip("It sends to the Animator the Weapon ID")]
		private string m_WeaponType = "WeaponType";

		[SerializeField]
		[Tooltip("Animator Curve name to set the Aim IK Values on the Weapons")]
		private string m_IKAim = "IKAim";

		[SerializeField]
		[Tooltip("Animator Curve name to set the Auxiliar hand IK Values on the Weapons")]
		private string m_IKFreeHand = "IKFreeHand";

		[SerializeField]
		[Tooltip("Sends to the Animator the Weapon Hand Value. [True -> Left Hand] [False ->Right Hand]")]
		private string m_LeftHand = "LeftHand";

		[SerializeField]
		[Tooltip("Weapon Charge or power is the same parameter as the Animal Controller Mode Power")]
		private string m_WeaponPower = "ModePower";

		[SerializeField]
		[Tooltip("Sends to the Animator the a trigger to activate the next Weapon Action ")]
		private string m_ModeOn = "ModeOn";

		[SerializeField]
		[Tooltip("Sends to the Animator the Weapon Action ")]
		private string m_Mode = "Mode";

		internal int Hash_WType;

		internal int Hash_LeftHand;

		internal int hash_Mode;

		internal int hash_ModeOn;

		internal int Hash_WPower;

		internal int hash_ModeStatus;

		public int Hash_IKFreeHand;

		public int Hash_IKAim;

		public BoolEvent OnCombatMode = new BoolEvent();

		public BoolEvent OnCanAim = new BoolEvent();

		public GameObjectEvent OnEquipWeapon = new GameObjectEvent();

		public GameObjectEvent OnUnequipWeapon = new GameObjectEvent();

		public IntEvent OnWeaponAction = new IntEvent();

		public StringReference m_AimInput = new StringReference("Aim");

		public StringReference m_ReloadInput = new StringReference("Reload");

		public StringReference m_MainAttack = new StringReference("MainAttack");

		public StringReference m_SecondAttack = new StringReference("SecondAttack");

		public StringReference m_SpecialAttack = new StringReference("SpecialAttack");

		[Tooltip("An previous weapon will be destroyed if a new weapon is going to use the same holster. Enable this when using Malbers Inventory")]
		public bool DestroyOnDrop;

		protected bool combatMode;

		private WaitForSeconds StoreAfterTime;

		private Coroutine IStoreAfter;

		[SerializeField]
		[Tooltip("Start with an equipped Weapon")]
		private GameObjectReference startWeapon;

		protected MWeapon m_weapon;

		[Tooltip("Set the Aiming to true on the Weapon Manager")]
		public BoolReference aim = new BoolReference();

		protected int weaponType;

		[HideInInspector]
		public int Editor_Tabs1;

		[HideInInspector]
		public int Editor_Tabs2;

		public int WeaponAnimAction { get; set; }

		private bool ExitByAnim { get; set; }

		public float HorizontalAngle => Aimer.HorizontalAngle;

		public bool AimingSide => Aimer.AimingSide;

		public virtual bool Aim
		{
			get
			{
				return aim.Value;
			}
			protected set
			{
				if ((!Weapon || Weapon.CanAim) && WeaponAction != Weapon_Action.Store && (bool)aim != value)
				{
					aim.Value = value;
					if (Rider != null)
					{
						Rider.IsAiming = value;
					}
					SetAimLogic(value);
				}
			}
		}

		protected virtual bool HigherPriorityMode
		{
			get
			{
				if (WeaponMode != null && animal.IsPlayingMode)
				{
					return animal.ActiveMode.Priority > WeaponMode.Priority;
				}
				return false;
			}
		}

		public virtual Weapon_Action WeaponAction
		{
			get
			{
				return weaponAction;
			}
			set
			{
				weaponAction = value;
				Debugging($"[Weapon Action] -> [{value}] - [{(int)value}]", "yellow");
				JustChangedAction = true;
				this.Delay_Action(delegate
				{
					JustChangedAction = false;
				});
				switch (weaponAction)
				{
				case Weapon_Action.None:
					GrabReinsBothHands();
					break;
				case Weapon_Action.Idle:
					DoIdleWeaponAnims();
					AutoStoreWeapon();
					break;
				case Weapon_Action.Attack:
					DoWeaponAttackAnims();
					break;
				case Weapon_Action.Draw:
					TryDrawWeaponAnims();
					break;
				case Weapon_Action.Store:
					TryStoreWeaponAnims();
					break;
				case Weapon_Action.Aim:
					if (WeaponIsActive)
					{
						Weapon.IsAiming = true;
					}
					DoAimAnimations();
					break;
				case Weapon_Action.Reload:
					DoReloadAnimations();
					break;
				}
				OnWeaponAction.Invoke((int)weaponAction);
				if (StoreAfter.Value > 0f && base.enabled && base.gameObject.activeInHierarchy)
				{
					if (IStoreAfter != null)
					{
						StopCoroutine(IStoreAfter);
					}
					if (weaponAction == Weapon_Action.Idle)
					{
						IStoreAfter = StartCoroutine(C_StoreAfter());
					}
				}
				if (weaponAction == Weapon_Action.None)
				{
					GrabReinsBothHands();
				}
			}
		}

		public Transform IgnoreTransform { get; set; }

		public IRider Rider { get; protected set; }

		public IInputSource MInput { get; protected set; }

		public bool HasAnimal => animal != null;

		public bool IsRiding { get; set; }

		public bool MountingDismounting { get; set; }

		public bool DefaultStrafing { get; set; }

		public bool IsReloading => Weapon.IsReloading;

		public bool IsAttacking => WeaponAction == Weapon_Action.Attack;

		public int MainAttackBranch
		{
			get
			{
				return mainAttackBranch.Value;
			}
			set
			{
				mainAttackBranch.Value = value;
			}
		}

		public int SecondAttackBranch
		{
			get
			{
				return secondAttackBranch.Value;
			}
			set
			{
				secondAttackBranch.Value = value;
			}
		}

		public bool IgnoreDraw
		{
			get
			{
				return m_IgnoreDraw.Value;
			}
			set
			{
				m_IgnoreDraw.Value = value;
			}
		}

		public bool IgnoreStore
		{
			get
			{
				return m_IgnoreStore.Value;
			}
			set
			{
				m_IgnoreStore.Value = value;
			}
		}

		public int ComboBranch => comboManager.Branch;

		public Mode WeaponMode { get; protected set; }

		public Mode DrawMode { get; protected set; }

		public Mode StoreMode { get; protected set; }

		public Mode UnArmedMode { get; protected set; }

		public Action<int, bool> SetBoolParameter { get; set; } = delegate
		{
		};

		public Action<int, float> SetFloatParameter { get; set; } = delegate
		{
		};

		public Action<int, int> SetIntParameter { get; set; } = delegate
		{
		};

		public Action<int> SetTriggerParameter { get; set; } = delegate
		{
		};

		public int ActiveHolsterIndex { get; set; }

		public Holster ActiveHolster { get; set; }

		public Animator Anim
		{
			get
			{
				return anim;
			}
			set
			{
				anim = value;
			}
		}

		public AnimatorUpdateMode DefaultAnimUpdateMode { get; set; }

		public virtual bool Active
		{
			get
			{
				return base.enabled;
			}
			set
			{
				if (!value)
				{
					if (CombatMode)
					{
						Store_Weapon();
					}
					else
					{
						ResetCombat();
					}
				}
				base.enabled = value;
			}
		}

		public bool WeaponIsActive
		{
			get
			{
				if ((bool)Weapon && Weapon.Enabled && Weapon.IsEquiped && Active)
				{
					return !Paused;
				}
				return false;
			}
		}

		public bool Paused => Time.timeScale == 0f;

		public IAim Aimer { get; set; }

		public AimSide DefaultAimSide { get; set; }

		public float DeltaTime { get; set; }

		public virtual bool CombatMode
		{
			get
			{
				return combatMode;
			}
			set
			{
				combatMode = value;
				OnCombatMode.Invoke(value);
			}
		}

		public bool DrawWeapon { get; set; }

		public bool StoreWeapon { get; set; }

		public float IKAimWeight { get; set; }

		public float IK2HandsWeight { get; set; }

		public GameObject Owner => base.gameObject;

		public virtual GameObject StartWeapon
		{
			get
			{
				return startWeapon.Value;
			}
			set
			{
				startWeapon.Value = value;
			}
		}

		public virtual MWeapon Weapon
		{
			get
			{
				return m_weapon;
			}
			set
			{
				if (value == null)
				{
					if (m_weapon != null)
					{
						SetWeapon(new_Weapon: false);
					}
					m_weapon = value;
					return;
				}
				if (m_weapon != null)
				{
					SetWeapon(new_Weapon: false);
				}
				m_weapon = value;
				SetWeapon(new_Weapon: true);
				SetWeaponHand(value.IsLefttHanded);
			}
		}

		public Transform RightHand
		{
			get
			{
				return RightHandEquipPoint;
			}
			set
			{
				RightHandEquipPoint = value;
			}
		}

		public Transform LeftHand
		{
			get
			{
				return LeftHandEquipPoint;
			}
			set
			{
				LeftHandEquipPoint = value;
			}
		}

		public Vector3 AimDirection => Aimer.AimDirection;

		public LayerMask Layer
		{
			get
			{
				return Aimer.Layer;
			}
			set
			{
				Aimer.Layer = value;
			}
		}

		public QueryTriggerInteraction TriggerInteraction
		{
			get
			{
				return Aimer.TriggerInteraction;
			}
			set
			{
				Aimer.TriggerInteraction = value;
			}
		}

		public bool Weapon_is_RightHand => Weapon.IsRightHanded;

		public bool Weapon_is_LeftHand => !Weapon.IsRightHanded;

		public virtual int WeaponType
		{
			get
			{
				return weaponType;
			}
			set
			{
				TryAnimParameter(Hash_WType, weaponType = value);
			}
		}

		Transform IAnimatorListener.transform => base.transform;

		Transform IWeaponManager.transform => base.transform;

		public virtual void PrepareHolsters()
		{
			if (holsters != null && holsters.Count == 0)
			{
				return;
			}
			for (int i = 0; i < holsters.Count; i++)
			{
				holsters[i].Index = i;
			}
			foreach (Holster holster in holsters)
			{
				holster.PrepareWeapon();
			}
		}

		public virtual void SetIgnoreTransform(Transform t)
		{
			IgnoreTransform = t;
		}

		public virtual void ClearIgnoreTransform()
		{
			IgnoreTransform = null;
		}

		public virtual void Holster_SetActive(int ID)
		{
			Holster_SetActive(holsters.Find((Holster x) => x.GetID == ID));
		}

		public virtual void Holster_SetActive(Holster newHolster)
		{
			ActiveHolster = newHolster;
			ActiveHolsterIndex = ((ActiveHolster != null) ? ActiveHolster.Index : 0);
			if (ActiveHolster != null)
			{
				ActiveHolsterIndex = ActiveHolster.Index;
				Debugging($"Set Active Holster → [{ActiveHolster.ID.name}] → [{ActiveHolsterIndex}].");
			}
			else
			{
				Debug.LogWarning("The Current Default Holster does not exit on the Holster ID list", this);
			}
		}

		public virtual void Holster_Next()
		{
			ActiveHolsterIndex = (ActiveHolsterIndex + 1) % holsters.Count;
			ActiveHolster = holsters[ActiveHolsterIndex];
			Draw_Weapon();
		}

		public virtual void Holster_Previus()
		{
			ActiveHolsterIndex = (ActiveHolsterIndex - 1) % holsters.Count;
			ActiveHolster = holsters[ActiveHolsterIndex];
			Draw_Weapon();
		}

		protected bool IsWeaponAction(params Weapon_Action[] w_actions)
		{
			for (int i = 0; i < w_actions.Length; i++)
			{
				if (WeaponAction == w_actions[i])
				{
					return true;
				}
			}
			return false;
		}

		public virtual void Holster_Equip(HolsterID HolsterID)
		{
			Holster_Equip(HolsterID.ID);
		}

		public virtual void Holster_Clear(HolsterID HolsterID)
		{
			Holster_Clear(HolsterID.ID);
		}

		public virtual void Holster_Clear()
		{
			if (Weapon != null && Weapon.IsEquiped)
			{
				Holster_Clear(Weapon.Holster);
			}
		}

		public virtual void Drop_Weapon()
		{
			Holster_Clear();
		}

		protected virtual void Holster_Equip(HolsterID HolsterID, bool value)
		{
			if (value)
			{
				Holster_Equip(HolsterID.ID);
			}
		}

		public virtual void HolsterClearAll()
		{
			Holster_Clear_All();
		}

		public virtual void Holster_Clear_All()
		{
			if (!UseHolsters || !Active || Paused)
			{
				return;
			}
			foreach (Holster holster in holsters)
			{
				if ((bool)holster.Weapon && holster.Weapon.IsEquiped)
				{
					UnEquip_Fast();
				}
				Holster_AddWeapon(holster, null);
			}
		}

		public virtual void Holster_Clear(int HolsterID)
		{
			if (!UseHolsters || !Active || Paused || !IsWeaponAction(Weapon_Action.None, Weapon_Action.Idle))
			{
				return;
			}
			Holster holster = holsters.Find((Holster x) => x.GetID == HolsterID);
			if (holster != null)
			{
				if ((bool)holster.Weapon && holster.Weapon.IsEquiped)
				{
					UnEquip_Fast();
				}
				Holster_AddWeapon(holster, null);
			}
		}

		public virtual void Holster_Equip(int HolsterID)
		{
			if (!UseHolsters || !Active || Paused)
			{
				return;
			}
			Holster holster = holsters.Find((Holster x) => x.GetID == HolsterID);
			if ((holster != null && holster.Weapon == null) || ((bool)Weapon && (!Weapon.CanUnequip || (!StoreSelfHolster && Weapon.HolsterID == HolsterID))))
			{
				return;
			}
			Debugging($"Holster Equip [{HolsterID}]", "green");
			if (IgnoreDraw)
			{
				if (!CombatMode)
				{
					Holster_SetActive(holster);
					Weapon = ActiveHolster.Weapon;
					Equip_Fast();
				}
				else if ((int)Weapon.Holster != HolsterID)
				{
					UnEquip_Fast();
					Holster_SetActive(holster);
					Weapon = ActiveHolster.Weapon;
					Equip_Fast();
				}
				else
				{
					Weapon.StopAllCoroutines();
					if (StoreSelfHolster)
					{
						UnEquip_Fast();
					}
				}
			}
			else if (!CombatMode)
			{
				Holster_SetActive(holster);
				Draw_Weapon();
			}
			else if ((int)Weapon.Holster == HolsterID)
			{
				Store_Weapon();
			}
			else
			{
				StartCoroutine(SwapWeaponsHolster(HolsterID));
			}
		}

		public virtual void Holster_SetWeapon(GameObject WeaponGO)
		{
			if (!(WeaponGO == null))
			{
				Holster_SetWeapon(WeaponGO.GetComponent<MWeapon>());
			}
		}

		public virtual void Holster_SetWeapon(MWeapon Next_Weapon)
		{
			if (!(Next_Weapon != null))
			{
				return;
			}
			if (Next_Weapon.gameObject.IsPrefab())
			{
				Debugging("[Weapon " + Next_Weapon.name + " is a Prefab] → [Instantianting]", "green");
				Next_Weapon = UnityEngine.Object.Instantiate(Next_Weapon);
			}
			Holster holster = holsters.Find((Holster x) => (int)x.ID == Next_Weapon.HolsterID);
			if (holster != null)
			{
				Debugging("[Set Weapon on Holster] → [" + holster.ID.name + "] → [" + Next_Weapon.name + "]", "green");
				bool flag = false;
				if (holster.Weapon != null)
				{
					flag = holster.Weapon == Weapon;
					if (flag)
					{
						UnEquip_Fast();
					}
				}
				SetWeaponParent(Next_Weapon, holster.GetSlot(Next_Weapon.HolsterSlot));
				Next_Weapon.transform.SetLocalTransform(Next_Weapon.HolsterOffset);
				Holster_AddWeapon(holster, Next_Weapon);
				holster.Weapon.DisablePhysics();
				if (flag)
				{
					Weapon = Next_Weapon;
					Equip_Fast();
				}
			}
			else
			{
				UnEquip_Fast();
				Weapon = Next_Weapon;
				Equip_Fast();
			}
		}

		protected virtual void Holster_AddWeapon(Holster holster, MWeapon weap)
		{
			if ((bool)holster.Weapon)
			{
				if (holster.Weapon.IsCollectable != null)
				{
					if (DestroyOnDrop)
					{
						UnityEngine.Object.Destroy(holster.Weapon.gameObject);
					}
					else
					{
						if (DropPoint != null)
						{
							holster.Weapon.transform.position = DropPoint.position;
						}
						holster.Weapon.IsCollectable.Drop();
					}
				}
				else
				{
					UnityEngine.Object.Destroy(holster.Weapon.gameObject);
				}
			}
			holster.Weapon = weap;
			if (holster.Weapon != null)
			{
				if (holster.Weapon.IsCollectable != null)
				{
					holster.Weapon.IsCollectable?.OnPickDisablePhysics();
				}
				holster.OnWeaponInHolster.Invoke(weap);
				if (holster.AutoEquip.Value)
				{
					Equip_Fast(holster.Weapon);
				}
			}
			else
			{
				holster.OnWeaponInHolster.Invoke(null);
			}
		}

		public virtual void Equip_External(GameObject WeaponGo)
		{
			MWeapon next_Weapon = ((WeaponGo != null) ? WeaponGo.GetComponent<MWeapon>() : null);
			Equip_External(next_Weapon);
		}

		public virtual void Equip_External(MWeapon Next_Weapon)
		{
			if (!IsWeaponAction(Weapon_Action.None, Weapon_Action.Idle) || !Active || !UseExternal || Paused)
			{
				return;
			}
			StopAllCoroutines();
			if (Next_Weapon == null)
			{
				Store_Weapon();
				Debugging("Active Weapon is [Empty] or is not compatible. Store the Active Weapon");
			}
			else if (Weapon == null)
			{
				TryInstantiateWeapon(Next_Weapon);
				Draw_Weapon();
			}
			else if (Weapon.Equals(Next_Weapon))
			{
				if (!CombatMode)
				{
					Draw_Weapon();
					Debugging("Active weapon is the same as the NEXT Weapon and we are NOT in Combat so DRAW");
				}
				else
				{
					Store_Weapon();
					Debugging("Active weapon is the same as the NEXT Weapon and we ARE  in Combat so STORE");
				}
			}
			else
			{
				StartCoroutine(SwapWeaponsInventory(Next_Weapon));
				Debugging("Active weapon is DIFFERENT to the NEXT weapon so Switch: " + Next_Weapon.name);
			}
		}

		protected virtual void TryInstantiateWeapon(MWeapon Next_Weapon)
		{
			if (InstantiateOnEquip || Next_Weapon.gameObject.IsPrefab())
			{
				GameObject gameObject = UnityEngine.Object.Instantiate(Next_Weapon.gameObject, base.transform);
				gameObject.SetActive(value: false);
				Next_Weapon = gameObject.GetComponent<MWeapon>();
				Debugging(gameObject.name + " Instantiated");
			}
			Weapon = Next_Weapon;
		}

		protected virtual IEnumerator SwapWeaponsInventory(MWeapon nextWeapon)
		{
			Store_Weapon();
			while (WeaponAction == Weapon_Action.Store)
			{
				yield return null;
			}
			TryInstantiateWeapon(nextWeapon);
			Draw_Weapon();
		}

		public virtual void Equip_Fast(GameObject WeaponGo)
		{
			if (!(WeaponGo == null))
			{
				MWeapon component = WeaponGo.GetComponent<MWeapon>();
				Equip_Fast(component);
			}
		}

		public virtual void Equip_Fast(MWeapon Next_Weapon)
		{
			if (!IsWeaponAction(Weapon_Action.None, Weapon_Action.Idle) || !Active || Next_Weapon == null)
			{
				return;
			}
			StopAllCoroutines();
			if (Weapon == null)
			{
				if (UseExternal)
				{
					TryInstantiateWeapon(Next_Weapon);
				}
				Weapon = Next_Weapon;
				if (!UseExternal)
				{
					Holster_SetActive(Weapon.HolsterID);
				}
				Equip_Fast();
			}
			else if (!Weapon.Equals(Next_Weapon))
			{
				UnEquip_Fast();
				if (UseExternal)
				{
					TryInstantiateWeapon(Next_Weapon);
				}
				Weapon = Next_Weapon;
				Holster_SetActive(Weapon.HolsterID);
				Equip_Fast();
				Debugging("Active weapon is DIFFERENT to the NEXT weapon so Switch: " + Next_Weapon.name);
			}
		}

		public virtual void Draw_Weapon(int holster, int weaponType, bool isLeftHand)
		{
			ExitAim();
			ResetCombat();
			CustomWeaponAction(99, holster);
			WeaponType = weaponType;
			SetWeaponHand(isLeftHand);
			Debugging("Draw with No Active Weapon");
		}

		public virtual void Store_Weapon(int holster, bool isRightHand)
		{
			Holster_SetActive(holster);
			WeaponAction = Weapon_Action.Store;
			ResetCombat();
			Debugging("Store with No Active Weapon ");
		}

		public virtual void MainAttack()
		{
			MainAttack(MainAttackBranch);
		}

		public virtual void SecondAttack()
		{
			if (!Aim)
			{
				MainAttack(SecondAttackBranch);
			}
		}

		public virtual void MainAttack(int Branch)
		{
			if (Active && !MountingDismounting)
			{
				if ((bool)comboManager)
				{
					comboManager.SetBranch(Branch);
				}
				Attack();
			}
		}

		public virtual void MainAttackReleased()
		{
			if (WeaponIsActive)
			{
				Weapon.MainAttack_Released(this);
				if (HasAnimal && animal.ActiveMode == WeaponMode)
				{
					WeaponMode.ActivatebyInput(Input_Value: false);
				}
			}
		}

		public virtual void ComboBranchReset()
		{
			MainAttackBranch = 0;
			SecondAttackBranch = 1;
		}

		public virtual void SecondAttackReleased()
		{
			if (WeaponIsActive)
			{
				Weapon.SecondAttack_Released(this);
			}
		}

		public virtual void MainAttack(bool value)
		{
			if (value)
			{
				MainAttack();
			}
			else
			{
				MainAttackReleased();
			}
		}

		public virtual void SecondAttack(bool value)
		{
			if (value)
			{
				SecondAttack();
			}
			else
			{
				SecondAttackReleased();
			}
		}

		public virtual void ReloadWeapon()
		{
			if (!JustChangedAction && WeaponIsActive && WeaponAction != Weapon_Action.Reload)
			{
				Weapon.TryReload();
			}
		}

		protected virtual void Attack()
		{
			if (!Active || MountingDismounting || HigherPriorityMode)
			{
				return;
			}
			if (WeaponIsActive)
			{
				if (!Aimer.Active)
				{
					Aimer.CalculateAiming();
				}
				Weapon.MainAttack_Start(this);
			}
			else if ((!Weapon || Weapon.Enabled) && HasAnimal && !IsRiding)
			{
				if ((bool)comboManager && comboManager.ActiveCombo != null)
				{
					comboManager.Play();
				}
				else
				{
					UnArmedMode?.TryActivate(-99);
				}
			}
		}

		public virtual void WeaponCharged(float time)
		{
			if (Active && CombatMode && WeaponIsActive && Weapon.Input)
			{
				Weapon.Attack_Charge(this, time);
			}
		}

		protected virtual void Reload(bool value)
		{
			if (value)
			{
				ReloadWeapon();
			}
		}

		protected virtual void ReloadInterrupt()
		{
			if (WeaponIsActive && IsReloading)
			{
				Debugging("Reload Interrupt!!");
				Weapon.StopAllCoroutines();
				Weapon.IsReloading = false;
				Weapon.m_audio.Stop();
				CheckAim();
			}
		}

		public virtual void ResetInputSource()
		{
			ConnectInput(MInput, connect: false);
			ConnectInput(MInput, connect: true);
		}

		protected virtual void ConnectInput(IInputSource InputSource, bool connect)
		{
			if (connect)
			{
				foreach (Holster a in holsters)
				{
					Holster holster = a;
					if (holster.InputListener == null)
					{
						holster.InputListener = delegate(bool value)
						{
							Holster_Equip(a.ID, value);
						};
					}
					InputSource.ConnectInput(a.Input, a.InputListener);
				}
				InputSource.ConnectInput(m_AimInput, Aim_Set);
				InputSource.ConnectInput(m_ReloadInput, Reload);
				InputSource.ConnectInput(m_MainAttack, MainAttack);
				InputSource.ConnectInput(m_SecondAttack, SecondAttack);
				return;
			}
			foreach (Holster holster2 in holsters)
			{
				if (holster2.InputListener != null)
				{
					InputSource.DisconnectInput(holster2.Input, holster2.InputListener);
				}
			}
			InputSource.DisconnectInput(m_AimInput, Aim_Set);
			InputSource.DisconnectInput(m_ReloadInput, Reload);
			InputSource.DisconnectInput(m_MainAttack, MainAttack);
			InputSource.DisconnectInput(m_SecondAttack, SecondAttack);
		}

		protected void GetAttack1Input(bool inputValue)
		{
			if (inputValue)
			{
				MainAttack();
			}
			else
			{
				MainAttackReleased();
			}
		}

		protected void GetReloadInput(bool inputValue)
		{
			if (inputValue)
			{
				ReloadWeapon();
			}
		}

		public virtual bool OnAnimatorBehaviourMessage(string message, object value)
		{
			bool flag = (bool)Weapon && Weapon.OnAnimatorBehaviourMessage(message, value);
			return this.InvokeWithParams(message, value) || flag;
		}

		public void SetWeaponHand(bool value)
		{
			if (Hash_LeftHand != 0)
			{
				SetBoolParameter(Hash_LeftHand, value);
			}
		}

		public void SetAnimParameter(int hash, int value)
		{
			Anim.SetInteger(hash, value);
		}

		public void SetAnimParameter(int hash, float value)
		{
			Anim.SetFloat(hash, value);
		}

		public void SetAnimParameter(int hash, bool value)
		{
			Anim.SetBool(hash, value);
		}

		public void SetAnimParameter(int hash)
		{
			Anim.SetTrigger(hash);
		}

		private int TryGetAnimParameter(string param)
		{
			int num = Animator.StringToHash(param);
			if (!animatorHashParams.Contains(num))
			{
				return 0;
			}
			return num;
		}

		public virtual void TryAnimParameter(int Hash, float value)
		{
			if (Hash != 0)
			{
				SetFloatParameter(Hash, value);
			}
		}

		public virtual void TryAnimParameter(int Hash, int value)
		{
			if (Hash != 0)
			{
				SetIntParameter(Hash, value);
			}
		}

		public virtual void TryAnimParameter(int Hash, bool value)
		{
			if (Hash != 0)
			{
				SetBoolParameter(Hash, value);
			}
		}

		public virtual void TryAnimParameter(int Hash)
		{
			if (Hash != 0)
			{
				SetTriggerParameter(Hash);
			}
		}

		public virtual void WeaponSound(int SoundID)
		{
			Weapon?.PlaySound(SoundID);
		}

		protected virtual void Awake()
		{
			if (Anim == null)
			{
				Anim = this.FindComponent<Animator>();
			}
			Aimer = this.FindInterface<IAim>();
			Rider = this.FindInterface<IRider>();
			MInput = this.FindInterface<IInputSource>();
			DefaultAnimUpdateMode = Anim.updateMode;
			DefaultAimSide = Aimer.AimSide;
			StoreAfterTime = new WaitForSeconds(StoreAfter.Value);
			GetHashIDs();
			if (RightHandEquipPoint == null)
			{
				Debug.LogWarning("[" + base.name + "] - Right Hand Transform is Missing", base.gameObject);
			}
			if (LeftHandEquipPoint == null)
			{
				Debug.LogWarning("[" + base.name + "] - Left Hand Transform is Missing", base.gameObject);
			}
			if (UseHolsters)
			{
				ActiveHolster = holsters[0];
			}
			PrepareAnimalController();
		}

		public virtual void Restart()
		{
			OnDisable();
			OnEnable();
		}

		protected virtual void OnEnable()
		{
			SetBoolParameter = (Action<int, bool>)Delegate.Combine(SetBoolParameter, new Action<int, bool>(SetAnimParameter));
			SetIntParameter = (Action<int, int>)Delegate.Combine(SetIntParameter, new Action<int, int>(SetAnimParameter));
			SetFloatParameter = (Action<int, float>)Delegate.Combine(SetFloatParameter, new Action<int, float>(SetAnimParameter));
			SetTriggerParameter = (Action<int>)Delegate.Combine(SetTriggerParameter, new Action<int>(SetAnimParameter));
			if (HasAnimal)
			{
				animal.OnModeStart.AddListener(AnimalModeStart);
				animal.OnModeEnd.AddListener(AnimalModeEnd);
				animal.OnStateActivate.AddListener(AnimalStateActivate);
				DefaultStrafing = animal.Strafe;
			}
			if (Rider != null)
			{
				IRider rider = Rider;
				rider.RiderStatus = (Action<RiderAction>)Delegate.Combine(rider.RiderStatus, new Action<RiderAction>(GetRiderStatus));
				IsRiding = Rider.IsRiding;
				MountingDismounting = Rider.IsMounting || Rider.IsDismounting;
			}
			if (MInput != null)
			{
				ConnectInput(MInput, connect: true);
			}
			ResetWeaponManager();
			if (WeaponEquippedOnDisable != null)
			{
				Equip_Fast(WeaponEquippedOnDisable);
			}
		}

		protected virtual void OnDisable()
		{
			WeaponEquippedOnDisable = Weapon;
			if (CombatMode)
			{
				UnEquip_Fast();
			}
			if (HasAnimal)
			{
				animal.OnModeStart.RemoveListener(AnimalModeStart);
				animal.OnModeEnd.RemoveListener(AnimalModeEnd);
				animal.OnStateActivate.RemoveListener(AnimalStateActivate);
			}
			if (Rider != null)
			{
				IRider rider = Rider;
				rider.RiderStatus = (Action<RiderAction>)Delegate.Remove(rider.RiderStatus, new Action<RiderAction>(GetRiderStatus));
			}
			if (MInput != null)
			{
				ConnectInput(MInput, connect: false);
			}
			SetBoolParameter = (Action<int, bool>)Delegate.Remove(SetBoolParameter, new Action<int, bool>(SetAnimParameter));
			SetIntParameter = (Action<int, int>)Delegate.Remove(SetIntParameter, new Action<int, int>(SetAnimParameter));
			SetFloatParameter = (Action<int, float>)Delegate.Remove(SetFloatParameter, new Action<int, float>(SetAnimParameter));
			SetTriggerParameter = (Action<int>)Delegate.Remove(SetTriggerParameter, new Action<int>(SetAnimParameter));
			StopAllCoroutines();
			IStoreAfter = null;
			Debugging("Weapon Manager Disabled");
		}

		public virtual void ResetCombat()
		{
			WeaponType = 0;
			Weapon?.ResetWeapon();
			WeaponAction = Weapon_Action.None;
			Aim_Set(value: false);
			CombatMode = false;
			Aim = false;
			OnCanAim.Invoke(arg0: false);
			ExitAim();
			Debugging("Reset Combat");
		}

		public virtual void ResetWeaponManager()
		{
			if (UseHolsters)
			{
				PrepareHolsters();
			}
			SmoothEquip = true;
			if (startWeapon.Value != null)
			{
				if (!startWeapon.Value.TryGetComponent<MWeapon>(out var component))
				{
					Debug.LogWarning("The Start Weapon does not contain a MWeapon Component. Equiping weapon on start will be ignored.");
					return;
				}
				if (component.gameObject.IsPrefab())
				{
					Weapon = UnityEngine.Object.Instantiate(component);
					Weapon.name = Weapon.name.Replace("(Clone)", "");
					Debugging("[Start Weapon Instantiated - " + Weapon.name + "]", "orange");
				}
				else
				{
					Debugging("[Start Weapon Equiped]", "orange");
					Weapon = component;
				}
				if (!Weapon)
				{
					return;
				}
				this.Delay_Action(delegate
				{
					Holster_SetActive(Weapon.HolsterID);
					if (ActiveHolster != null)
					{
						Holster_AddWeapon(ActiveHolster, Weapon);
					}
					Equip_Fast();
					Weapon.IsCollectable?.Pick();
					AutoStoreWeapon();
				});
			}
			else
			{
				comboManager?.SetActiveCombo(UnarmedModeID);
			}
		}

		protected virtual void GetHashIDs()
		{
			animatorHashParams = new List<int>();
			AnimatorControllerParameter[] parameters = Anim.parameters;
			foreach (AnimatorControllerParameter animatorControllerParameter in parameters)
			{
				animatorHashParams.Add(animatorControllerParameter.nameHash);
			}
			Hash_LeftHand = TryGetAnimParameter(m_LeftHand);
			Hash_IKAim = TryGetAnimParameter(m_IKAim);
			Hash_IKFreeHand = TryGetAnimParameter(m_IKFreeHand);
			Hash_WType = TryGetAnimParameter(m_WeaponType);
			hash_Mode = TryGetAnimParameter(m_Mode);
			hash_ModeOn = TryGetAnimParameter(m_ModeOn);
			Hash_WPower = TryGetAnimParameter(m_WeaponPower);
		}

		protected virtual void PrepareAnimalController()
		{
			if (HasAnimal)
			{
				DrawMode = animal.Mode_Get(DrawWeaponModeID);
				StoreMode = animal.Mode_Get(StoreWeaponModeID);
				UnArmedMode = animal.Mode_Get(UnarmedModeID);
				animal.IsPreparingMode = false;
			}
			else
			{
				comboManager = null;
			}
		}

		private void FixedUpdate()
		{
			WeaponCharged(Time.fixedDeltaTime);
		}

		protected virtual void GetRiderStatus(RiderAction status)
		{
			bool flag = status == RiderAction.EndMount;
			MountingDismounting = status == RiderAction.StartMount || status == RiderAction.StartDismount;
			if (IsRiding != flag)
			{
				IsRiding = flag;
				Debugging($"Is Riding: {IsRiding}");
				if (CombatMode)
				{
					comboManager?.SetActiveCombo(IsRiding ? Weapon.RidingCombo : Weapon.GroundCombo);
					CheckReinHandsEquip();
				}
			}
			if (MountingDismounting)
			{
				Aim_Set(value: false);
			}
			if (CombatMode)
			{
				switch (status)
				{
				case RiderAction.StartMount:
				case RiderAction.EndMount:
					WeaponType = (Weapon.RidingArmPose ? ((int)Weapon.WeaponType) : 0);
					break;
				case RiderAction.EndDismount:
					WeaponType = (Weapon.GroundArmPose ? ((int)Weapon.WeaponType) : 0);
					comboManager?.SetActiveCombo(Weapon.GroundCombo);
					SetWeaponStance();
					if (Aim && Weapon.StrafeOnAim)
					{
						animal.Strafe = true;
					}
					break;
				}
			}
			if ((bool)Weapon)
			{
				Weapon.Owner = (IsRiding ? Rider.Mount : base.gameObject);
			}
		}

		private void CheckReinHandsEquip()
		{
			if (Rider != null && Weapon != null)
			{
				if (Weapon.IsRightHanded)
				{
					Rider.ReinRightHand(value: false);
				}
				else
				{
					Rider.ReinLeftHand(value: false);
				}
			}
		}

		public void GrabReinsBothHands()
		{
			if (Rider != null)
			{
				Rider.ReinLeftHand(value: true);
				Rider.ReinRightHand(value: true);
			}
		}

		public void ReleaseReinsFromHands()
		{
			if (Rider != null)
			{
				Rider.ReinLeftHand(value: false);
				Rider.ReinRightHand(value: false);
			}
		}

		public void FreeHandUse()
		{
			Weapon?.FreeHandUse();
			ReleaseReinsFromHands();
		}

		public void FreeHandRelease()
		{
			Weapon?.FreeHandRelease();
			CheckReinHandsEquip();
		}

		protected void LateUpdate()
		{
			if (WeaponIsActive)
			{
				Weapon.Weapon_LateUpdate(this);
			}
		}

		protected void OnAnimatorIK()
		{
			if (Anim.isHuman && !MountingDismounting && CombatMode && WeaponIsActive)
			{
				Do_Aim_IK();
				Do_2Hands_IK();
			}
		}

		protected virtual void Do_Aim_IK()
		{
			if ((bool)Weapon.AimIK)
			{
				if (Hash_IKAim != 0)
				{
					IKAimWeight = Anim.GetFloat(Hash_IKAim);
				}
				if (IKAimWeight != 0f)
				{
					Weapon.AimIK.ApplyOffsets(Anim, Aimer.AimOrigin.position, AimDirection, IKAimWeight);
				}
			}
		}

		protected virtual void Do_2Hands_IK()
		{
			if ((bool)Weapon.TwoHandIK && (bool)Weapon.IKHandPoint)
			{
				if (Hash_IKAim != 0)
				{
					IK2HandsWeight = Anim.GetFloat(Hash_IKFreeHand);
				}
				if (IK2HandsWeight != 0f)
				{
					AvatarIKGoal goal = ((!Weapon.IsRightHanded) ? AvatarIKGoal.RightHand : AvatarIKGoal.LeftHand);
					Anim.SetIKPosition(goal, Weapon.IKHandPoint.position);
					Anim.SetIKPositionWeight(goal, IK2HandsWeight);
					Anim.SetIKRotation(goal, Weapon.IKHandPoint.rotation);
					Anim.SetIKRotationWeight(goal, IK2HandsWeight);
				}
			}
		}

		public virtual void Aim_Set(bool value)
		{
			Aim = value;
		}

		public virtual void SetAimLogic(bool value)
		{
			aim.Value = value;
			if (Rider != null)
			{
				Rider.IsAiming = value;
			}
			Debugging($"Aim → [{value}]", "gray");
			if ((bool)Weapon)
			{
				Weapon.IsAiming = value;
			}
			if ((bool)aim)
			{
				if ((bool)Weapon)
				{
					Aimer.AimSide = Weapon.AimSide;
					if (!DefaultStrafing && HasAnimal && Weapon.StrafeOnAim)
					{
						animal.Strafe = true;
						DefaultStrafing = false;
					}
				}
				if (HasAnimal && WeaponMode != null && animal.IsPlayingMode && animal.ActiveMode.Priority > WeaponMode.Priority)
				{
					return;
				}
				if (WeaponAction == Weapon_Action.Reload)
				{
					ReloadInterrupt();
				}
				if (Weapon is MShootable { AutoReload: not false } mShootable)
				{
					Aimer.Active = true;
					if (mShootable.TryReload())
					{
						return;
					}
				}
				WeaponAction = Weapon_Action.Aim;
				Aimer.Active = true;
			}
			else
			{
				WeaponAction = (CombatMode ? Weapon_Action.Idle : Weapon_Action.None);
				ExitAim();
			}
		}

		public virtual void CheckAim()
		{
			if (WeaponAction != Weapon_Action.Reload)
			{
				WeaponAction = (Aim ? Weapon_Action.Aim : (CombatMode ? Weapon_Action.Idle : Weapon_Action.None));
			}
		}

		public virtual void ExitAim()
		{
			if (HasAnimal && (bool)Weapon && Weapon.StrafeOnAim && !DefaultStrafing && !ExitByMode)
			{
				animal.Strafe = false;
			}
			MInput?.ResetInput(m_AimInput.Value);
			Aimer.ExitAim();
		}

		protected virtual void DoIdleWeaponAnims()
		{
			if (!HasAnimal)
			{
				CustomWeaponAction(0, 0);
			}
			else if (WeaponMode != null && (bool)Weapon)
			{
				if (WeaponMode == animal.ActiveMode || animal.ModeAbility != 0)
				{
					animal.Mode_Stop();
				}
				WeaponMode.InputValue = false;
			}
		}

		protected virtual void DoAimAnimations()
		{
			if (!CombatMode || !Weapon.CanAim)
			{
				return;
			}
			if (HasAnimal)
			{
				if (!HigherPriorityMode)
				{
					WeaponMode.ForceActivate(97);
				}
			}
			else
			{
				CustomWeaponAction(Weapon.WeaponType.ID, 97);
			}
		}

		protected virtual void DoReloadAnimations()
		{
			if (!HigherPriorityMode && !Weapon.IsReloading)
			{
				if (HasAnimal)
				{
					WeaponMode.ForceActivate(96);
				}
				else
				{
					CustomWeaponAction(Weapon.WeaponType.ID, 96);
				}
			}
		}

		public virtual void TryDrawWeaponAnims()
		{
			if (HasAnimal)
			{
				if (DrawMode != null)
				{
					DrawMode.ForceActivate(Weapon.HolsterAnim);
				}
				else
				{
					Equip_Fast();
				}
			}
			else
			{
				CustomWeaponAction(99, Weapon.HolsterAnim);
			}
		}

		public virtual void TryStoreWeaponAnims()
		{
			if (HasAnimal)
			{
				StoreWeapon = true;
				if (StoreMode != null && Weapon != null)
				{
					StoreMode.ForceActivate(Weapon.HolsterAnim);
				}
				else
				{
					UnEquip_Fast();
				}
			}
			else
			{
				CustomWeaponAction(98, Weapon.HolsterAnim);
			}
		}

		protected virtual void CustomWeaponAction(int mode, int value)
		{
			SetTriggerParameter(hash_ModeOn);
			WeaponAnimAction = mode * 1000 + value;
			SetIntParameter(hash_Mode, WeaponAnimAction);
		}

		public virtual void SetWeaponCharge(float Charge)
		{
			float num = Charge * Weapon.ChargeCharMultiplier;
			if (HasAnimal)
			{
				animal.Mode_SetPower(num);
			}
			else
			{
				SetFloatParameter(Hash_WPower, num);
			}
		}

		protected virtual void AutoStoreWeapon()
		{
			if (!((float)StoreAfter <= 0f) && base.gameObject.activeInHierarchy && IStoreAfter != null)
			{
				StopCoroutine(IStoreAfter);
				IStoreAfter = StartCoroutine(C_StoreAfter());
			}
		}

		protected virtual void DoWeaponAttackAnims()
		{
			if (Weapon is MMelee mMelee)
			{
				if ((bool)comboManager && comboManager.ActiveCombo != null)
				{
					if (comboManager.TryPlay())
					{
						Debugging($"[Melee Attack] → [{Weapon.name} <AC>]. Combo[{comboManager.ActiveCombo.Name}] Branch: [{comboManager.Branch}]", "orange");
						Weapon.CanAttack = true;
					}
				}
				else
				{
					if (!Weapon.CanAttack)
					{
						return;
					}
					if (mMelee.RidingAttackAbilities == null)
					{
						Debug.LogWarning("The Weapon " + Weapon.name + " does not have Riding Attack Abilities", this);
						return;
					}
					if (mMelee.GroundAttackAbilities == null)
					{
						Debug.LogWarning("The Weapon " + Weapon.name + " does not have Riding Attack Abilities", this);
						return;
					}
					int num = UnityEngine.Random.Range(0, IsRiding ? mMelee.RidingAttackAbilities.Length : mMelee.GroundAttackAbilities.Length);
					num = (IsRiding ? mMelee.RidingAttackAbilities[num] : mMelee.GroundAttackAbilities[num]);
					if (HasAnimal)
					{
						if (IsRiding && mMelee.UseCameraSide)
						{
							num *= ((!Aimer.AimingSide) ? 1 : (-1));
							if (mMelee.InvertCameraSide)
							{
								num *= -1;
							}
						}
						if (WeaponMode.ForceActivate(num))
						{
							Debugging("[Melee Attack] → [" + Weapon.name + " <AC>] <NO Combo>", "orange");
							Weapon.CanAttack = false;
						}
						else
						{
							Action(100);
							Debugging("[Melee Attack] → [" + Weapon.name + " <AC>] <MODE FAILED>", "gray");
						}
					}
					else
					{
						CustomWeaponAction(weaponType, num);
					}
				}
			}
			else
			{
				if (!(Weapon is MShootable mShootable))
				{
					return;
				}
				if (HasAnimal)
				{
					if (mShootable.HasFireAnim.Value)
					{
						WeaponMode.ForceActivate(101);
					}
					Debugging("[Fire Projectile] [AC] → [" + Weapon.name + "]", "orange");
				}
				else
				{
					CustomWeaponAction(Weapon.WeaponType, 101);
				}
			}
		}

		protected virtual void AnimalStateActivate(int state)
		{
			if (CombatMode)
			{
				if (ExitOnState.Contains(animal.ActiveStateID))
				{
					ExitByState = true;
					if (ExitFast)
					{
						UnEquip_Fast();
					}
					else
					{
						Store_Weapon();
					}
				}
				else
				{
					ExitByState = false;
				}
			}
			if (ExitByState && UseHolsters && !ExitOnState.Contains(animal.ActiveStateID))
			{
				Weapon = ActiveHolster.Weapon;
				if (ExitFast)
				{
					Equip_Fast();
				}
				else
				{
					Draw_Weapon();
				}
				ExitByState = false;
			}
		}

		public void ExitByAnimation(bool value)
		{
			if (CombatMode && value)
			{
				if (Aim)
				{
					ExitByAnim = true;
					if (UseHolsters)
					{
						UnEquip_Fast();
					}
					else
					{
						Weapon.gameObject.SetActive(value: false);
					}
				}
			}
			else if (ExitByAnim)
			{
				ExitByAnim = false;
				if (UseHolsters)
				{
					Weapon = ActiveHolster.Weapon;
					Equip_Fast();
				}
				else if (Weapon != null)
				{
					Weapon.gameObject.SetActive(value: true);
				}
			}
		}

		protected virtual void AnimalModeStart(int ModeID, int ablility)
		{
			if (!CombatMode)
			{
				return;
			}
			if (ExitOnModes.Contains(animal.ActiveMode.ID))
			{
				ExitByMode = true;
				if (UseHolsters)
				{
					UnEquip_Fast();
				}
				else
				{
					Weapon.gameObject.SetActive(value: false);
				}
			}
			else
			{
				ExitByMode = false;
			}
		}

		protected virtual void AnimalModeEnd(int ModeID, int ablility)
		{
			if (animal.IsPreparingMode || JustChangedAction || WeaponMode == null)
			{
				return;
			}
			if (ExitByMode)
			{
				if (UseHolsters)
				{
					Weapon = ActiveHolster.Weapon;
					Equip_Fast();
				}
				else
				{
					Weapon.gameObject.SetActive(value: true);
				}
				if (animal.IsPlayingMode && animal.ActiveMode != WeaponMode)
				{
					CheckAim();
				}
				ExitByMode = false;
			}
			if ((int)WeaponMode.ID != ModeID)
			{
				CheckAim();
			}
			if (!animal.IsPlayingMode)
			{
				CheckAim();
			}
		}

		public virtual void Equip_Fast()
		{
			SmoothEquip = false;
			Equip_Weapon();
		}

		public virtual void Equip_Weapon()
		{
			if ((HasAnimal && ExitOnState.Contains(animal.ActiveStateID)) || !Active || Weapon == null)
			{
				return;
			}
			if (!Weapon.Enabled)
			{
				Debugging("The weapon is Disabled. It cannot be equipped");
				return;
			}
			Weapon.StopAllCoroutines();
			DrawWeapon = false;
			Debugging($"EQUIP → [{Weapon.name}] T:{Time.time:F2}", "orange");
			Equip_Weapon_Data_Ground_Riding();
			EquipWeapon_AnimalController();
			CombatMode = true;
			Weapon.Equip(this);
			OnEquipWeapon.Invoke(Weapon.gameObject);
			if ((int)OverrideWeaponLayer != 0)
			{
				Weapon.m_hitLayer = OverrideWeaponLayer;
			}
			if (Weapon is MShootable && (Weapon as MShootable).aimAction == MShootable.AimingAction.Automatic)
			{
				Aim_Set(value: true);
			}
			CheckAim();
			OnCanAim.Invoke(Weapon.CanAim);
			Weapon.PlaySound(WSound.Equip);
			CheckReinHandsEquip();
			ParentWeapon();
			if (UseHolsters)
			{
				TransformOffset offset = (Weapon.IsRightHanded ? Weapon.RightHandOffset : Weapon.LeftHandOffset);
				if (IgnoreHandOffset.Value)
				{
					TransformOffset transformOffset = new TransformOffset(0);
					transformOffset.Scale = Weapon.transform.localScale;
					offset = transformOffset;
				}
				if (SmoothEquip)
				{
					CheckCoroutines(offset);
					C_SmoothEquip = MTools.AlignTransformLocal(Weapon.transform, offset.Position, offset.Rotation, offset.Scale, HolsterTime);
					StartCoroutine(C_SmoothEquip);
				}
				else
				{
					Weapon.transform.SetLocalTransform(offset.Position, offset.Rotation, offset.Scale);
				}
				SmoothEquip = true;
			}
			else if (!IgnoreHandOffset.Value)
			{
				Weapon.ApplyOffset();
			}
			else
			{
				Weapon.transform.SetLocalPositionAndRotation(Vector3.zero, Quaternion.identity);
			}
			Weapon.gameObject.SetActive(value: true);
			if (IsRiding && Rider != null)
			{
				Weapon.Owner = Rider.Mount;
			}
		}

		private void CheckCoroutines(TransformOffset Offset)
		{
			if (C_SmoothEquip != null)
			{
				StopCoroutine(C_SmoothEquip);
				Weapon.transform.SetLocalTransform(Weapon.HolsterOffset);
			}
			if (C_SmoothUneEquip != null)
			{
				StopCoroutine(C_SmoothUneEquip);
				Offset.RestoreTransform(Weapon.transform);
			}
		}

		public virtual void Unequip_Weapon()
		{
			ResetCombat();
			if (Weapon == null)
			{
				return;
			}
			Debugging($"UNEQUIP → [{Weapon.name}] T:{Time.time:F2}", "orange");
			StoreWeapon = false;
			IKAimWeight = 0f;
			WeaponType = 0;
			OnUnequipWeapon.Invoke(Weapon.gameObject);
			if (UseHolsters)
			{
				if (Weapon.Holster != null)
				{
					SetWeaponParent(Weapon, ActiveHolster.GetSlot(Weapon.HolsterSlot));
					if (SmoothEquip)
					{
						TransformOffset offset = (Weapon.IsRightHanded ? Weapon.RightHandOffset : Weapon.LeftHandOffset);
						CheckCoroutines(offset);
						C_SmoothUneEquip = MTools.AlignTransform(Weapon.transform, Weapon.HolsterOffset, HolsterTime);
						StartCoroutine(C_SmoothUneEquip);
					}
					else
					{
						Weapon.transform.SetLocalTransform(Weapon.HolsterOffset);
					}
				}
				SmoothEquip = true;
			}
			else if (DestroyOnUnequip)
			{
				UnityEngine.Object.Destroy(Weapon.gameObject);
			}
			UnequipWeapon_AnimalController();
			Weapon = null;
			WeaponAction = Weapon_Action.None;
		}

		protected virtual void Equip_Weapon_Data_Ground_Riding()
		{
			if (!IsRiding)
			{
				WeaponType = (Weapon.GroundArmPose ? ((int)Weapon.WeaponType) : 0);
				comboManager?.SetActiveCombo(Weapon.GroundCombo);
			}
			else
			{
				WeaponType = (Weapon.RidingArmPose ? ((int)Weapon.WeaponType) : 0);
				comboManager?.SetActiveCombo(Weapon.RidingCombo);
			}
		}

		protected virtual void EquipWeapon_AnimalController()
		{
			if (HasAnimal)
			{
				SetWeaponStance();
				WeaponMode = animal.Mode_Get(Weapon.WeaponType);
				EnableModesAC(enable: false);
				if (WeaponMode != null)
				{
					WeaponMode.SetActive(value: true);
				}
				else
				{
					Debug.LogWarning("The Animal Controller does not have a mode for the Equipped Weapon!!");
					Weapon.Enabled = false;
				}
				if (Weapon.StrafeOnEquip)
				{
					animal.Strafe = true;
				}
			}
		}

		public virtual void UnequipWeapon_AnimalController()
		{
			if (!HasAnimal)
			{
				return;
			}
			if (Weapon.stance != null)
			{
				animal.Stance_RestoreDefault();
				animal.Stance_Reset();
			}
			if ((bool)comboManager)
			{
				comboManager.SetActiveCombo(UnarmedModeID);
			}
			EnableModesAC(enable: true);
			foreach (ModeID disableMode in DisableModes)
			{
				animal.Mode_Enable(disableMode);
			}
			if (WeaponMode != null)
			{
				if (WeaponMode.PlayingMode)
				{
					animal.Mode_Stop();
				}
				animal.Strafe = Weapon.StrafeOnUnequip;
				WeaponMode.SetActive(value: false);
				WeaponMode = null;
			}
		}

		private void SetWeaponStance()
		{
			if ((bool)Weapon.stance)
			{
				animal?.Stance_Set(Weapon.stance);
				animal.Stance_SetDefault(Weapon.stance);
			}
		}

		private void EnableModesAC(bool enable)
		{
			foreach (ModeID disableMode in DisableModes)
			{
				if (enable)
				{
					animal.Mode_Enable_Temporal(disableMode);
				}
				else
				{
					animal.Mode_Disable_Temporal(disableMode);
				}
			}
		}

		public void UnEquip()
		{
			UnEquip_Fast();
		}

		public virtual void UnEquip_Fast()
		{
			SmoothEquip = false;
			Unequip_Weapon();
		}

		public virtual void ParentWeapon()
		{
			if (Weapon.IsRightHanded && (bool)RightHandEquipPoint)
			{
				SetWeaponParent(Weapon, RightHandEquipPoint);
			}
			else if ((bool)LeftHandEquipPoint)
			{
				SetWeaponParent(Weapon, LeftHandEquipPoint);
			}
		}

		public virtual void SetWeaponParent(MWeapon weapon, Transform parent)
		{
			weapon.transform.parent = parent;
		}

		public virtual void Draw_Weapon()
		{
			if (!Active || (HasAnimal && ExitOnState.Contains(animal.ActiveStateID)))
			{
				return;
			}
			DrawWeapon = true;
			ExitAim();
			if (!UseExternal)
			{
				Weapon = ActiveHolster.Weapon;
			}
			if ((bool)Weapon)
			{
				if (Weapon.IgnoreDraw || IgnoreDraw)
				{
					Equip_Fast();
					return;
				}
				WeaponAction = Weapon_Action.Draw;
				CheckReinHandsEquip();
				Debugging("Draw → " + (Weapon.IsRightHanded ? "Right Hand" : "Left Hand") + " → [" + Weapon.Holster.name + " → " + Weapon.name + "]", "yellow");
			}
		}

		public virtual void Store_Weapon()
		{
			if (!(Weapon == null) && Weapon.CanUnequip)
			{
				ExitAim();
				Weapon.StopAllCoroutines();
				FreeHandRelease();
				if (Weapon.IgnoreStore || IgnoreStore)
				{
					UnEquip_Fast();
					return;
				}
				StoreWeapon = true;
				WeaponAction = Weapon_Action.Store;
				Weapon.StoringWeapon();
				Debugging("[Store → " + (Weapon.IsRightHanded ? "Right Hand" : "Left Hand") + "] → [" + Weapon.Holster.name + "] → [" + Weapon.name + "]", "cyan");
			}
		}

		public virtual void ActivateDamager(int value, int prof)
		{
			if ((bool)Weapon)
			{
				Weapon.ActivateDamager(value, prof);
			}
		}

		public virtual void DamagerAnimationStart(int hash)
		{
			LastAttackTriggerHash = hash;
		}

		public virtual void DamagerAnimationEnd(int hash)
		{
			if (!HasAnimal && LastAttackTriggerHash == hash)
			{
				WeaponAction = Weapon_Action.Idle;
			}
		}

		private IEnumerator SwapWeaponsHolster(int HolstertoSwap)
		{
			if ((bool)Weapon)
			{
				Store_Weapon();
				while (WeaponAction == Weapon_Action.Aim)
				{
					yield return null;
				}
				while (WeaponAction == Weapon_Action.Store)
				{
					yield return null;
				}
			}
			Holster_SetActive(HolstertoSwap);
			Draw_Weapon();
			yield return null;
		}

		protected virtual void FindRHand()
		{
			if (anim != null && anim.avatar.isHuman)
			{
				RightHandEquipPoint = anim.GetBoneTransform(HumanBodyBones.RightHand);
				MTools.SetDirty(this);
			}
		}

		protected virtual void FindLHand()
		{
			if (anim != null && anim.avatar.isHuman)
			{
				LeftHandEquipPoint = anim.GetBoneTransform(HumanBodyBones.LeftHand);
				MTools.SetDirty(this);
			}
		}

		public virtual void SetActive(bool value)
		{
			Active = value;
		}

		protected IEnumerator C_StoreAfter()
		{
			yield return StoreAfterTime;
			Store_Weapon();
		}

		protected virtual void SetWeapon(bool new_Weapon)
		{
			if (new_Weapon)
			{
				MWeapon weapon = m_weapon;
				weapon.WeaponAction = (Action<int>)Delegate.Combine(weapon.WeaponAction, new Action<int>(Action));
				m_weapon.OnCharged.AddListener(SetWeaponCharge);
			}
			else
			{
				MWeapon weapon2 = m_weapon;
				weapon2.WeaponAction = (Action<int>)Delegate.Remove(weapon2.WeaponAction, new Action<int>(Action));
				m_weapon.OnCharged.RemoveListener(SetWeaponCharge);
				m_weapon.IgnoreTransform = null;
			}
		}

		public virtual void Action(int value)
		{
			WeaponAction = (Weapon_Action)value;
		}

		public void Debugging(string value, string color = "white")
		{
		}
	}
}
