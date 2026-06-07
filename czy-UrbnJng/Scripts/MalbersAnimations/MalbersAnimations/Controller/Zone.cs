using System.Collections.Generic;
using MalbersAnimations.Conditions;
using MalbersAnimations.Reactions;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Serialization;

namespace MalbersAnimations.Controller
{
	[AddComponentMenu("Malbers/Animal Controller/Zone")]
	public class Zone : MonoBehaviour, IZone
	{
		public bool debug;

		[Tooltip("As soon as the animal enters the zone it will execute the logic. If False then Call the Method Zone.Activate()")]
		public BoolReference automatic = new BoolReference();

		[Tooltip("How many characters can use this zone at the same time.\nNegative values: The zone has no character limit")]
		public IntReference Limit = new IntReference(-1);

		[Tooltip("Disable the Zone after it was used")]
		public BoolReference DisableAfterUsed = new BoolReference();

		[Tooltip("Check only colliders with this name")]
		public bool BoneOnly;

		[Range(0f, 360f)]
		[Tooltip("Limit the Activation of the Zone of an angle from the Animal")]
		public float Angle = 360f;

		[Range(0f, 1f)]
		[Tooltip("Probability to Activate the Zone")]
		public float Weight = 1f;

		[Tooltip("The Zone can be used in both sides")]
		public bool DoubleSide;

		[Tooltip("Flip the Angle")]
		public bool Flip;

		public bool ShowActionID = true;

		[FormerlySerializedAs("HeadName")]
		public string BoneName = "Head";

		[Tooltip("Choose between a Mode, State or Stance for the Zone")]
		public ZoneType zoneType;

		[Tooltip("Actions to do on a state when entering a zone")]
		public StateAction stateAction;

		[Tooltip("Actions to do on a state when exiting a zone")]
		public StateAction stateActionExit = StateAction.None;

		public StanceAction stanceActionEnter;

		public StanceAction stanceActionExit = StanceAction.Exit;

		[Tooltip("Layer to detect the Animal")]
		public LayerReference Layer = new LayerReference(1048576);

		[Tooltip("State Status. If is set to [-1] the Status will be ignored")]
		public IntReference stateStatus = new IntReference(0);

		[SerializeField]
		private List<Tag> tags;

		public ModeID modeID;

		public StateID stateID;

		public StanceID stanceID;

		public MAction ActionID;

		[SerializeField]
		private IntReference modeIndex = new IntReference(-99);

		[Tooltip("Value of the Ability Status")]
		public AbilityStatus m_abilityStatus;

		[Tooltip("Time of Ability Activation")]
		public float AbilityTime = 3f;

		[Tooltip("Amount of Force that will be applied to the Animal")]
		public FloatReference Force = new FloatReference(10f);

		[Tooltip("Aceleration to applied the Force when the Animal enters the zone")]
		[FormerlySerializedAs("EnterDrag")]
		public FloatReference EnterAceleration = new FloatReference(2f);

		[Tooltip("Exit Drag to decrease the Force when the Animal exits the zone")]
		public FloatReference ExitDrag = new FloatReference(4f);

		[Tooltip("Limit the Current Force the animal may have")]
		[FormerlySerializedAs("Bounce")]
		public FloatReference LimitForce = new FloatReference(8f);

		[Tooltip("Change if the Animal is Grounded when entering the Force Zone")]
		public BoolReference ForceGrounded = new BoolReference();

		[Tooltip("Can the Animal be controller while on the Air?")]
		public BoolReference ForceAirControl = new BoolReference(value: true);

		[Tooltip("Plays a mode no matter if another mode is already playing")]
		public bool ForceMode;

		[Tooltip("Extra conditions to check in case you want to activate the Zone")]
		public MConditions CheckConditions;

		public MAnimal JustExitAnimal;

		internal List<Collider> m_Colliders = new List<Collider>();

		[Tooltip("Value Assigned to the Mode Float Value when using the Mode Zone")]
		public float ModeFloat;

		public bool RemoveAnimalOnActive;

		[Tooltip("When Entering a Mode Zone, the 'Active Ability Index' of the animal mode will be changed to  the 'Active Ability Index' of the Zone.")]
		public bool PrepareModeZone = true;

		public AnimalEvent OnEnter = new AnimalEvent();

		public AnimalEvent OnExit = new AnimalEvent();

		public AnimalEvent OnZoneActivation = new AnimalEvent();

		public AnimalEvent OnZoneFailed = new AnimalEvent();

		[SubclassSelector]
		[SerializeReference]
		public Reaction EnterReaction;

		[SubclassSelector]
		[SerializeReference]
		public Reaction ExitReaction;

		[SubclassSelector]
		[SerializeReference]
		public Reaction ActivationReaction;

		[Tooltip("Collider for the Zone. If is not set, it will find the first collider attached to this gameobject")]
		[RequiredField]
		public Collider ZoneCollider;

		public static List<Zone> Zones;

		[HideInInspector]
		public int Editor_Tabs1;

		public int ModeAbilityIndex
		{
			get
			{
				if (modeID.ID != 4 || !(ActionID != null))
				{
					return modeIndex.Value;
				}
				return ActionID.ID;
			}
		}

		public int ZoneID { get; private set; }

		public HashSet<MAnimal> AnimalsInZone { get; internal set; }

		public HashSet<MAnimal> AnimalsUsingZone { get; internal set; }

		public Collider ZCollider => ZoneCollider;

		private int GetID => zoneType switch
		{
			ZoneType.Mode => modeID, 
			ZoneType.State => stateID, 
			ZoneType.Stance => stanceID, 
			ZoneType.Force => 100, 
			_ => 0, 
		};

		public bool IsMode => zoneType == ZoneType.Mode;

		public bool IsState => zoneType == ZoneType.State;

		public bool IsStance => zoneType == ZoneType.Stance;

		public bool IsReaction => zoneType == ZoneType.ReactionsOnly;

		public List<Tag> Tags
		{
			get
			{
				return tags;
			}
			set
			{
				tags = value;
			}
		}

		Transform IZone.transform => base.transform;

		private void Awake()
		{
			if (Zones == null)
			{
				Zones = new List<Zone>();
			}
		}

		private void OnEnable()
		{
			if (ZoneCollider == null)
			{
				ZoneCollider = GetComponent<Collider>();
			}
			if ((bool)ZoneCollider)
			{
				ZoneCollider.isTrigger = true;
				ZoneCollider.enabled = true;
			}
			Zones.Add(this);
			if (ZoneID == 0)
			{
				ZoneID = GetID;
			}
			AnimalsInZone = new HashSet<MAnimal>();
			AnimalsUsingZone = new HashSet<MAnimal>();
			if (zoneType == ZoneType.Mode && modeID.ID == 4 && ShowActionID)
			{
				if (ActionID != null)
				{
					modeIndex.Value = ActionID.ID;
					return;
				}
				Debug.LogError("The zone does not have an Action ID. Please add an ID", this);
				base.enabled = false;
			}
		}

		private void OnDisable()
		{
			Zones.Remove(this);
			foreach (MAnimal item in AnimalsInZone)
			{
				ResetStoredAnimal(item);
				OnExit.Invoke(item);
				ExitReaction?.React(item);
			}
			if ((bool)ZoneCollider)
			{
				ZoneCollider.enabled = false;
			}
			AnimalsInZone = new HashSet<MAnimal>();
			AnimalsUsingZone = new HashSet<MAnimal>();
			m_Colliders = new List<Collider>();
			JustExitAnimal = null;
		}

		public bool TrueConditions(Collider other)
		{
			if (!base.enabled)
			{
				return false;
			}
			if (Tags != null && Tags.Count > 0 && !other.gameObject.HasMalbersTagInParent(Tags.ToArray()))
			{
				return false;
			}
			if (ZoneCollider == null)
			{
				return false;
			}
			if (other == null)
			{
				return false;
			}
			if (BoneOnly && !other.name.ToLower().Contains(BoneName.ToLower()))
			{
				return false;
			}
			if (!MTools.Layer_in_LayerMask(other.gameObject.layer, Layer))
			{
				return false;
			}
			if (base.transform.IsChildOf(other.transform))
			{
				return false;
			}
			return true;
		}

		private void OnTriggerEnter(Collider other)
		{
			if (!TrueConditions(other))
			{
				return;
			}
			MAnimal mAnimal = other.FindComponent<MAnimal>();
			if (!mAnimal || mAnimal.Sleep || !mAnimal.enabled || mAnimal.RB.isKinematic || ((bool)automatic && mAnimal == JustExitAnimal) || m_Colliders.Contains(other))
			{
				return;
			}
			m_Colliders.Add(other);
			if (!AnimalsInZone.Contains(mAnimal))
			{
				if (mAnimal.InZone && mAnimal.Zone != this)
				{
					mAnimal.Zone.RemoveAnimal(mAnimal);
				}
				mAnimal.Zone = this;
				AnimalsInZone.Add(mAnimal);
				OnEnter.Invoke(mAnimal);
				EnterReaction?.React(mAnimal);
				Debugging("[Enter Animal] -> [" + mAnimal.name + "]", "yellow");
				if ((bool)automatic)
				{
					ActivateZone(mAnimal);
				}
				else
				{
					PrepareZone(mAnimal);
				}
			}
		}

		private void OnTriggerExit(Collider other)
		{
			if (!TrueConditions(other))
			{
				return;
			}
			MAnimal animal = other.GetComponentInParent<MAnimal>();
			if ((bool)animal && !animal.Sleep && animal.enabled)
			{
				if (m_Colliders != null && m_Colliders.Contains(other))
				{
					m_Colliders.Remove(other);
				}
				CheckMissingColliders();
				if (AnimalsInZone.Contains(animal) && !m_Colliders.Exists((Collider col) => col != null && col.transform.SameHierarchy(animal.transform)))
				{
					RemoveAnimal(animal);
				}
			}
		}

		public virtual void RemoveAnimal(MAnimal animal)
		{
			OnExit.Invoke(animal);
			ExitReaction?.React(animal);
			ResetStoredAnimal(animal);
			AnimalsInZone.Remove(animal);
			AnimalsUsingZone.Remove(animal);
			Debugging("[Exit Animal] -> [" + animal.name + "]", "yellow");
			if ((bool)automatic)
			{
				JustExitAnimal = animal;
				this.Delay_Action(delegate
				{
					JustExitAnimal = null;
				});
			}
		}

		private void CheckMissingColliders()
		{
			m_Colliders.RemoveAll((Collider x) => x == null || x.gameObject.IsDestroyed());
		}

		public void Debugging(string value, string color = "green")
		{
		}

		public virtual bool ActivateZone(MAnimal animal)
		{
			if (Weight != 1f)
			{
				float num = Random.Range(0f, 1f);
				if (num >= Weight)
				{
					if (debug)
					{
						Debug.Log($"<b>{base.name}</b> [Zone Failed to activate] -> <b>[{num:F2}]</b>", this);
					}
					return false;
				}
			}
			if ((int)Limit > 0)
			{
				if (AnimalsUsingZone.Count >= (int)Limit)
				{
					if (debug)
					{
						Debug.Log($"<b>{base.name}</b> [Zone Failed to activate Due to limits] -> <b>[{Limit.Value}]</b>", this);
					}
					OnZoneFailed.Invoke(animal);
					return false;
				}
				AnimalsUsingZone.Add(animal);
			}
			if (CheckConditions != null)
			{
				CheckConditions.SetTarget(animal);
				if (!CheckConditions.TryEvaluate())
				{
					return false;
				}
			}
			if (CheckAngle(animal))
			{
				bool flag = false;
				animal.Zone = this;
				switch (zoneType)
				{
				case ZoneType.Mode:
					flag = ActivateModeZone(animal);
					break;
				case ZoneType.State:
					flag = StateZone(animal, stateAction);
					break;
				case ZoneType.Stance:
					flag = StanceZone(animal, stanceActionEnter);
					break;
				case ZoneType.Force:
					flag = SetForceZone(animal, ON: true);
					break;
				case ZoneType.ReactionsOnly:
					flag = ActivationReaction != null && ActivationReaction.TryReact(animal);
					break;
				}
				if (flag)
				{
					Debugging("[Zone Activate] <b>[" + animal.name + "]</b>");
					OnZoneActive(animal);
					return true;
				}
			}
			return false;
		}

		public virtual void ActivateZone()
		{
			try
			{
				foreach (MAnimal item in AnimalsInZone)
				{
					ActivateZone(item);
				}
			}
			catch
			{
			}
		}

		protected bool CheckAngle(MAnimal animal)
		{
			int num = (Flip ? 1 : (-1));
			float num2 = Vector3.Angle(base.transform.forward * num, animal.Forward) * 2f;
			float num3 = num2;
			if (DoubleSide)
			{
				num3 = Vector3.Angle(-base.transform.forward * num, animal.Forward) * 2f;
			}
			float num4 = Vector3.Dot((animal.transform.position - base.transform.position).normalized, base.transform.forward) * -1f;
			if (Angle != 360f && (!(num2 < Angle) || !(num4 < 0f)))
			{
				if (num3 < Angle)
				{
					return num4 > 0f;
				}
				return false;
			}
			return true;
		}

		protected virtual void PrepareZone(MAnimal animal)
		{
			switch (zoneType)
			{
			case ZoneType.Mode:
				if (PrepareModeZone)
				{
					animal.Mode_Get(modeID)?.SetAbilityIndex(ModeAbilityIndex);
				}
				break;
			case ZoneType.State:
				if (!animal.State_Get(ZoneID))
				{
					OnZoneFailed.Invoke(animal);
				}
				break;
			case ZoneType.Stance:
			case ZoneType.Force:
				break;
			}
		}

		private bool StateZone(MAnimal animal, StateAction action)
		{
			bool result = false;
			switch (action)
			{
			case StateAction.Activate:
				if ((int)animal.ActiveStateID != ZoneID)
				{
					animal.State_Activate(ZoneID, stateStatus);
					result = true;
				}
				break;
			case StateAction.AllowExit:
				if ((int)animal.ActiveStateID == ZoneID)
				{
					animal.ActiveState.AllowExit();
					result = true;
				}
				break;
			case StateAction.ForceActivate:
				animal.State_Force(ZoneID, stateStatus);
				result = true;
				break;
			case StateAction.Enable:
				animal.State_Enable(ZoneID);
				result = true;
				break;
			case StateAction.Disable:
				animal.State_Disable(ZoneID);
				result = true;
				break;
			case StateAction.SetExitStatus:
				if (animal.ActiveStateID == stateID)
				{
					animal.State_SetExitStatus(stateStatus);
					result = true;
				}
				break;
			}
			return result;
		}

		private bool ActivateModeZone(MAnimal animal)
		{
			if (ForceMode)
			{
				if (animal.Mode_ForceActivate(ZoneID, ModeAbilityIndex, m_abilityStatus, AbilityTime))
				{
					animal.Mode_SetPower(ModeFloat);
					return true;
				}
				OnZoneFailed.Invoke(animal);
			}
			else
			{
				if (animal.Mode_TryActivate(ZoneID, ModeAbilityIndex, m_abilityStatus, AbilityTime))
				{
					animal.Mode_SetPower(ModeFloat);
					return true;
				}
				OnZoneFailed.Invoke(animal);
			}
			return false;
		}

		private bool StanceZone(MAnimal animal, StanceAction action)
		{
			Stance stance = animal.Stance_Get(stanceID);
			switch (action)
			{
			case StanceAction.Activate:
				if (stance == null)
				{
					OnZoneFailed.Invoke(animal);
					return false;
				}
				animal.Stance_Set(stanceID);
				break;
			case StanceAction.Exit:
				animal.Stance_Reset();
				break;
			case StanceAction.SetDefault:
				if (stance == null)
				{
					OnZoneFailed.Invoke(animal);
					return false;
				}
				animal.DefaultStanceID = stanceID;
				break;
			}
			return true;
		}

		private bool SetForceZone(MAnimal animal, bool ON)
		{
			if (ON)
			{
				Vector3 currentExternalForce = animal.CurrentExternalForce + animal.GravityStoredVelocity;
				if (currentExternalForce.magnitude > (float)LimitForce)
				{
					currentExternalForce = currentExternalForce.normalized * LimitForce;
				}
				animal.CurrentExternalForce = currentExternalForce;
				animal.ExternalForce = base.transform.up * Force;
				animal.ExternalForceAcel = EnterAceleration;
				if ((int)animal.ActiveState.ID == StateEnum.Fall)
				{
					(animal.ActiveState as Fall).FallCurrentDistance = 0f;
				}
				animal.GravityTime = 0f;
				animal.Grounded = ForceGrounded.Value;
				animal.ExternalForceAirControl = ForceAirControl.Value;
			}
			else
			{
				if ((int)animal.ActiveState.ID == StateEnum.Fall)
				{
					animal.UseGravity = true;
				}
				if ((float)ExitDrag > 0f)
				{
					animal.ExternalForceAcel = ExitDrag;
					animal.ExternalForce = Vector3.zero;
				}
			}
			return ON;
		}

		internal void OnZoneActive(MAnimal animal)
		{
			OnZoneActivation.Invoke(animal);
			ActivationReaction?.React(animal);
			if (RemoveAnimalOnActive)
			{
				ResetStoredAnimal(animal);
				AnimalsInZone.Remove(animal);
				AnimalsUsingZone.Remove(animal);
			}
			if (DisableAfterUsed.Value)
			{
				base.enabled = false;
			}
		}

		public void TargetArrived(GameObject go)
		{
			MAnimal animal = go.FindComponent<MAnimal>();
			ActivateZone(animal);
		}

		public virtual void ResetStoredAnimal(MAnimal animal)
		{
			if (!animal)
			{
				return;
			}
			if (animal.Zone != null && animal.Zone == this)
			{
				animal.Zone = null;
			}
			switch (zoneType)
			{
			case ZoneType.Mode:
			{
				Mode mode = animal.Mode_Get(ZoneID);
				if (mode != null && mode.AbilityIndex == ModeAbilityIndex)
				{
					mode.ResetAbilityIndex();
				}
				break;
			}
			case ZoneType.State:
				StateZone(animal, stateActionExit);
				break;
			case ZoneType.Stance:
				StanceZone(animal, stanceActionExit);
				break;
			case ZoneType.Force:
				SetForceZone(animal, ON: false);
				break;
			}
		}
	}
}
