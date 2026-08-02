using UnityEngine;

namespace FIMSpace.FProceduralAnimation
{
	[DefaultExecutionOrder(-1)]
	[HelpURL("https://assetstore.unity.com/packages/tools/physics/ragdoll-animator-2-285638")]
	[AddComponentMenu("FImpossible Creations/Ragdoll Animator 2", 1)]
	public class RagdollAnimator2 : FimpossibleComponent, IRagdollAnimator2HandlerOwner
	{
		[SerializeField]
		private RagdollHandler handler = new RagdollHandler();

		public RagdollHandler Settings => handler;

		public RagdollHandler Actions => handler;

		public RagdollHandler Handler => handler;

		public RagdollHandler GetRagdollHandler => handler;

		public RagdollHandler.EAnimatingMode AnimatingMode => Handler.AnimatingMode;

		public Animator Mecanim => Handler.Mecanim;

		public float RagdollBlend
		{
			get
			{
				return handler.RagdollBlend;
			}
			set
			{
				handler.RagdollBlend = value;
			}
		}

		public bool IsInFallingOrSleepMode => Handler.IsFallingOrSleep;

		public Transform GetBaseTransform
		{
			get
			{
				if (handler.BaseTransform == null)
				{
					return base.transform;
				}
				return handler.BaseTransform;
			}
		}

		private void Reset()
		{
			handler.EnsureChainsHasParentHandler();
			handler.Mecanim = GetComponentInChildren<Animator>();
			if (!handler.Mecanim && (bool)base.transform.parent)
			{
				handler.Mecanim = base.transform.parent.GetComponent<Animator>();
			}
		}

		private void Start()
		{
			handler.Initialize(this, base.gameObject);
		}

		private void Update()
		{
			Handler.UpdateTick();
		}

		private void LateUpdate()
		{
			Handler.LateUpdateTick();
		}

		private void FixedUpdate()
		{
			Handler.FixedUpdateTick();
		}

		private void OnEnable()
		{
			handler.OnEnable();
		}

		private void OnDisable()
		{
			handler.OnDisable();
		}

		private void OnDestroy()
		{
			handler.OnCreatorDestroy();
		}

		public override void OnValidate()
		{
			UpdateAllAfterManualChanges();
			base.OnValidate();
		}

		public void UpdateAllAfterManualChanges()
		{
			if (handler.Chains.Count > 0)
			{
				if (handler.Chains[0].ParentHandler == null)
				{
					handler.EnsureChainsHasParentHandler();
				}
				if (handler.DummyWasGenerated)
				{
					handler.User_UpdateAllBonesParametersAfterManualChanges();
				}
				if (handler.WasInitialized)
				{
					handler.User_UpdateJointsPlayParameters(reset: true);
				}
			}
		}

		public void TryFindBonesAndDoFullSetup()
		{
			if (handler.Mecanim == null)
			{
				handler.Mecanim = GetComponentInChildren<Animator>();
				if (handler.Mecanim == null)
				{
					handler.Mecanim = GetComponentInParent<Animator>();
				}
			}
			handler.HelperOwnerTransform = GetBaseTransform;
			handler.TryFindBones();
			foreach (RagdollBonesChain chain in handler.Chains)
			{
				chain.AutoAdjustColliders(handler.IsHumanoid);
				chain.AutoAdjustPhysics();
			}
			handler.StoreReferenceTPose();
		}

		public void RA2Event_SwitchToFall()
		{
			this.User_SwitchFallState();
		}

		public void RA2Event_SwitchToStand()
		{
			this.User_SwitchFallState(standing: true);
		}

		public void RA2Event_TransitionStand()
		{
			this.User_TransitionToStandingMode();
		}

		public void RA2Event_TransitionStand(float duration)
		{
			this.User_TransitionToStandingMode(duration, 0f);
		}

		public void RA2Event_SwitchToSleep()
		{
			handler.User_SwitchFallState(RagdollHandler.EAnimatingMode.Sleep);
			handler.User_ResetOverrideBlends();
			handler.User_DisableMecanimAfter(2.5f);
		}

		public void RA2Event_SwitchToSleep(float disableMecanimAfter)
		{
			handler.User_SwitchFallState(RagdollHandler.EAnimatingMode.Sleep);
			handler.User_ResetOverrideBlends();
			handler.User_DisableMecanimAfter(disableMecanimAfter);
		}

		public void RA2Event_AddFullImpact(Vector3 impact)
		{
			handler.User_AddAllBonesImpact(impact);
		}

		public void RA2Event_AddLeftLegImpact(Vector3 impact)
		{
			handler.User_AddChainImpact(handler.GetChain(ERagdollChainType.LeftLeg), impact, 0f);
		}

		public void RA2Event_AddRightLegImpact(Vector3 impact)
		{
			handler.User_AddChainImpact(handler.GetChain(ERagdollChainType.RightLeg), impact, 0f);
		}

		public void RA2Event_AddLeftArmImpact(Vector3 impact)
		{
			handler.User_AddChainImpact(handler.GetChain(ERagdollChainType.LeftArm), impact, 0f);
		}

		public void RA2Event_AddRightArmImpact(Vector3 impact)
		{
			handler.User_AddChainImpact(handler.GetChain(ERagdollChainType.RightArm), impact, 0f);
		}

		public void RA2Event_AddCoreImpact(Vector3 impact)
		{
			handler.User_AddChainImpact(handler.GetChain(ERagdollChainType.Core), impact, 0f);
		}

		public void RA2Event_AddHeadImpact(Vector3 impact)
		{
			RagdollBonesChain chain = handler.GetChain(ERagdollChainType.Core);
			if (chain.BoneSetups.Count != 0)
			{
				RagdollChainBone bone = chain.GetBone(10000);
				if (bone != null)
				{
					handler.User_AddBoneImpact(bone, impact, 0f);
				}
			}
		}

		public void USER__ENTER_Settings_VARIABLE_FOR_MORE_METHODS()
		{
		}

		public void INFO__ENTER_Settings_VARIABLE_FOR_MORE_METHODS()
		{
		}
	}
}
