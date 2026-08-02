using JUTPS.CameraSystems;
using JUTPS.WeaponSystem;
using JUTPSEditor.JUHeader;
using UnityEngine;

namespace JUTPS.ItemSystem
{
	public class HoldableItem : Item
	{
		public enum ItemSwitchPosition
		{
			Hips = 0,
			Back = 1
		}

		public enum ItemHoldingPose
		{
			PistolTwoHands = 0,
			PistolOneHand = 1,
			Rifle = 2,
			Free = 3
		}

		[HideInInspector]
		public GameObject Owner;

		[HideInInspector]
		public JUCharacterController TPSOwner;

		[HideInInspector]
		public WeaponAimRotationCenter WeaponRotationCenter;

		[HideInInspector]
		public JUCameraController CamPivot;

		[JUHeader("Use Setting")]
		public bool SingleUseItem;

		public bool ContinuousUseItem;

		public bool BlockFireMode;

		public GameObject ItemModelInBody;

		public float TimeToUse;

		[HideInInspector]
		public float CurrentTimeToUse;

		public bool CanUseItem = true;

		public bool IsUsingItem;

		[JUHeader("Wielding")]
		public int ItemWieldPositionID;

		public bool IsLeftHandItem;

		public bool ForceDualWielding;

		public HoldableItem DualItemToWielding;

		public ItemHoldingPose HoldPose;

		public ItemSwitchPosition PushItemFrom;

		[JUHeader("IK Settings")]
		public Transform OppositeHandPosition;

		public bool isBlockedToUse;

		public int GetWieldingPoseIndex()
		{
			return (int)HoldPose;
		}

		protected virtual void Start()
		{
			RefreshItemDependencies();
			CurrentTimeToUse = TimeToUse;
		}

		private void Awake()
		{
			RefreshItemDependencies();
		}

		public void RefreshItemDependencies()
		{
			if ((!(Owner == null) && !(TPSOwner == null)) || !(base.transform.GetComponentInParent<JUCharacterController>() != null))
			{
				return;
			}
			Owner = base.transform.GetComponentInParent<JUCharacterController>().gameObject;
			TPSOwner = Owner.GetComponent<JUCharacterController>();
			if (TPSOwner.anim == null)
			{
				TPSOwner.anim = TPSOwner.GetComponent<Animator>();
			}
			if (TPSOwner.anim.GetBoneTransform(HumanBodyBones.LeftHand) == null)
			{
				if (!IsInvoking("RefreshItemDependencies"))
				{
					Invoke("RefreshItemDependencies", 0.1f);
				}
			}
			else
			{
				IsLeftHandItem = ((TPSOwner.anim.GetBoneTransform(HumanBodyBones.LeftHand).transform == base.transform.parent) ? true : false);
				WeaponRotationCenter = ((TPSOwner != null) ? TPSOwner.PivotItemRotation.GetComponent<WeaponAimRotationCenter>() : null);
				CamPivot = TPSOwner.MyPivotCamera;
			}
		}

		public virtual void Update()
		{
			if (isBlockedToUse)
			{
				CanUseItem = false;
			}
			else if (!CanUseItem)
			{
				CurrentTimeToUse += Time.deltaTime;
				if (CurrentTimeToUse >= TimeToUse)
				{
					CanUseItem = true;
					CurrentTimeToUse = 0f;
				}
			}
		}

		public override void UseItem()
		{
			if (!isBlockedToUse)
			{
				IsUsingItem = true;
				CanUseItem = false;
				if (SingleUseItem)
				{
					ItemQuantity = 0;
				}
			}
		}

		public virtual void StopUseItem()
		{
			IsUsingItem = false;
			if (SingleUseItem && SingleUseItem)
			{
				ItemQuantity = 0;
			}
		}

		public virtual void StopUseItemDelayed(float delay)
		{
			if (IsInvoking("StopUseItem"))
			{
				CancelInvoke("StopUseItem");
			}
			else
			{
				Invoke("StopUseItem", delay);
			}
		}

		public override bool Weaved()
		{
			return true;
		}
	}
}
