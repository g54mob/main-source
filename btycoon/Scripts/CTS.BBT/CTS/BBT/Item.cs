using System;
using System.Collections.Generic;
using System.Linq;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.Pooling;
using CTS.Core.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT
{
	public abstract class Item : CTSBehaviour, IContextActor, IHoldable<Agent>, IPoolable, IPoolCallbackReceiver, IVisibleBBTObject, IBBTObject, IObject, IVisible
	{
		[Header("Grabbing Data")]
		[SerializeField]
		private EBone _targetBone = EBone.Hip;

		[SerializeField]
		private Vector3 _positionOffset;

		[SerializeField]
		private Vector3 _rotationOffset;

		[field: SerializeField]
		public ContextActorData ContextActorData { get; private set; }

		[field: Inject(false)]
		public RoomObject RoomObject { get; }

		public Action WasSeen { get; set; }

		[field: SerializeReference]
		[field: ArrayElementTitle]
		public GrabData[] ProceduralGrabData { get; private set; }

		PoolGuid IPoolable.PoolGuid { get; set; }

		[field: SerializeField]
		[field: Space]
		public float Weight { get; private set; }

		public bool IsHeld => (object)CurrentHolder != null;

		public ItemSlot InSlot { get; private set; }

		public Agent CurrentHolder { get; private set; }

		public Agent GrabbingAgent { get; set; }

		public Transform Transform => base.transform;

		public bool IsVisible { get; private set; } = true;

		public static event Action<Item> OnSelect;

		public event Action Destroyed;

		public void SetVisible(bool isVisible)
		{
			if (isVisible != IsVisible)
			{
				IsVisible = isVisible;
				if (isVisible)
				{
					OnVisible();
				}
				else
				{
					OnInvisible();
				}
			}
		}

		protected virtual void OnInvisible()
		{
		}

		protected virtual void OnVisible()
		{
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AddAnchorGrab()
		{
			List<GrabData> list = ProceduralGrabData.ToList();
			list.Add(new GrabDataAnchor());
			ProceduralGrabData = list.ToArray();
		}

		[Button(null, EButtonEnableMode.Always)]
		private void AddBoneGrab()
		{
			List<GrabData> list = ProceduralGrabData.ToList();
			list.Add(new GrabDataBone());
			ProceduralGrabData = list.ToArray();
		}

		protected virtual void OnDestroy()
		{
			if (base.gameObject.scene.isLoaded)
			{
				ClearSlot();
			}
		}

		void IPoolCallbackReceiver.OnPulled()
		{
			OnPulledFromPool();
		}

		void IPoolCallbackReceiver.OnPushed()
		{
			GrabbingAgent = null;
			OnPushedToPool();
		}

		protected virtual void OnPulledFromPool()
		{
		}

		protected virtual void OnPushedToPool()
		{
			ClearSlot();
			SetVisible(isVisible: true);
		}

		private void ClearSlot()
		{
			if ((bool)InSlot)
			{
				InSlot.SetUnused();
				if (InSlot is DrinkSlot)
				{
					InSlot.SetUsed(null);
				}
			}
			InSlot = null;
			if ((bool)CurrentHolder)
			{
				CurrentHolder.ObjectHolding.DropObject();
			}
		}

		public void Place(ItemSlot slot, bool move = true)
		{
			InSlot = slot;
			InSlot.SetUsed(this);
			if (move)
			{
				base.transform.SetParent(InSlot.transform);
				base.transform.SetPositionAndRotation(InSlot.transform);
			}
			base.gameObject.SetActive(value: true);
		}

		public void PlaceFreely(Transform p_anchor)
		{
			base.transform.SetPositionAndRotation(p_anchor);
			base.gameObject.SetActive(value: true);
		}

		public bool TryGrabHoldable(Agent p_parent)
		{
			if (!base.gameObject.activeInHierarchy || IsHeld)
			{
				return false;
			}
			OnGrab(p_parent);
			return true;
		}

		protected virtual void OnGrab(Agent p_parent)
		{
			if ((bool)InSlot)
			{
				InSlot.SetUnused();
				if (InSlot is DrinkSlot)
				{
					InSlot.SetUsed(null);
				}
			}
			InSlot = null;
			if (p_parent.SkeletonData.TryGetBone(_targetBone, out var boneTransform))
			{
				base.transform.SetParent(boneTransform);
			}
			else
			{
				base.transform.SetParent(p_parent.transform);
			}
			base.transform.SetLocalPositionAndRotation(_positionOffset, Quaternion.Euler(_rotationOffset));
			CurrentHolder = p_parent;
			if ((bool)CurrentHolder)
			{
				RoomObject.SetParent(CurrentHolder.RoomObject);
			}
		}

		public void DropHoldable()
		{
			if (IsHeld)
			{
				OnDropped();
			}
		}

		protected virtual void OnDropped()
		{
			if (base.gameObject.scene.isLoaded)
			{
				base.transform.SetParent(null);
				if ((bool)CurrentHolder)
				{
					RoomObject.SetParent(null);
					RoomObject.CurrentRoom = CurrentHolder.RoomObject.CurrentRoom;
				}
				CurrentHolder = null;
			}
		}

		private void OnSelectCall()
		{
			Item.OnSelect?.Invoke(this);
		}

		private void OnUnSelectCall()
		{
			Item.OnSelect?.Invoke(null);
		}

		public virtual void Clear()
		{
		}

		private void OnDrawGizmos()
		{
			Vector3 position = base.transform.position;
			Gizmos.color = new Color(0.15f, 0.55f, 0.13f, 0.55f);
			Gizmos.DrawSphere(position - _positionOffset, 0.05f);
			GrabData[] proceduralGrabData = ProceduralGrabData;
			foreach (GrabData grabData in proceduralGrabData)
			{
				if (!(grabData is GrabDataAnchor) && grabData is GrabDataBone grabDataBone)
				{
					Gizmos.color = new Color(1f, 0f, 0f, 0.49f);
					Gizmos.DrawSphere(position - grabDataBone.PositionOffset, 0.05f);
					if (grabDataBone.ElbowAnchor)
					{
						Gizmos.color = new Color(1f, 0f, 0.71f, 0.49f);
						Gizmos.DrawSphere(position + grabDataBone.ElbowPositionOffset, 0.05f);
					}
				}
			}
		}
	}
}
