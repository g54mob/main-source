using System;
using Controllers;
using MessagePack;
using UnityEngine;
using UnityEngine.Serialization;

namespace Kitchen
{
	[Serializable]
	public class PlayerView : ResponsiveObjectView<PlayerView.ViewData, PlayerView.ResponseData>
	{
		[Serializable]
		[MessagePackObject(false)]
		public struct ViewData : IViewData, IViewResponseData, IViewData.ICheckForChanges<ViewData>, IRollUp
		{
			[Key(0)]
			public CInputData Inputs;

			[Key(1)]
			public float Speed;

			[Key(2)]
			public bool IsPaused;

			[Key(3)]
			public bool IsHolding;

			[Key(4)]
			public bool IsInteracting;

			[Key(5)]
			public int Process;

			[Key(6)]
			public int InputSource;

			[Key(7)]
			public int PlayerID;

			public bool IsChangedFrom(ViewData check)
			{
				if (!Inputs.IsChangedFrom(check.Inputs) && Mathf.Approximately(Speed, check.Speed) && IsPaused == check.IsPaused && IsHolding == check.IsHolding && IsInteracting == check.IsInteracting && Process == check.Process && InputSource == check.InputSource)
				{
					return PlayerID != check.PlayerID;
				}
				return true;
			}
		}

		[Serializable]
		[MessagePackObject(false)]
		public struct ResponseData : IResponseData, IViewResponseData, IRollUp
		{
			[Key(0)]
			public Vector3 Position;

			[Key(1)]
			public Quaternion Rotation;
		}

		[SerializeField]
		[Header("Configuration")]
		public float Speed = 3000f;

		[SerializeField]
		[Header("References")]
		private PlayerHoldingSubview HoldingSubview;

		[SerializeField]
		private PlayerEffectsComponent PlayerEffectsComponent;

		[SerializeField]
		[FormerlySerializedAs("PlayerWalkingComponent")]
		private PlayerMovementComponent PlayerMovementComp;

		[SerializeField]
		private PlayerIdentificationComponent PlayerIdentificationComponent;

		[Header("State")]
		private bool IsMyPlayer;

		private ViewData Data;

		private ResponseData PreviousResponse;

		protected override Interpolator<Vector3> PositionInterpolator { get; } = new RubberBandInterpolator<Vector3>(default(Vector3Interpolator));

		protected override Interpolator<Quaternion> RotationInterpolator { get; } = new RubberBandInterpolator<Quaternion>(default(QuaternionInterpolator));

		public override void Initialise()
		{
			base.Initialise();
			if ((bool)PlayerIdentificationComponent)
			{
				PlayerIdentificationComponent.Setup(this);
			}
		}

		public override void SetHeldItem(IObjectView held_item, int storage_index, bool is_tool)
		{
			HoldingSubview.SetHeldItem(held_item, storage_index, is_tool);
		}

		public override void SetPosition(UpdateViewPositionData pos)
		{
			if (!IsMyPlayer)
			{
				base.SetPosition(pos);
			}
			else if (pos.Force)
			{
				base.SetPosition(pos);
				Transform obj = base.transform;
				obj.localPosition = pos.Position;
				obj.localRotation = pos.Rotation;
				base.UpdatePosition();
			}
		}

		protected override void UpdatePosition()
		{
			if (!IsMyPlayer)
			{
				base.UpdatePosition();
			}
		}

		protected override void UpdateData(ViewData view_data)
		{
			IsMyPlayer = view_data.InputSource == InputSourceIdentifier.Identifier;
			Data = view_data;
			if ((bool)PlayerMovementComp)
			{
				PlayerMovementComp.UpdateData(Data.IsPaused);
			}
			if ((bool)PlayerIdentificationComponent)
			{
				PlayerIdentificationComponent.UpdateData(Data.PlayerID);
			}
			if ((bool)PlayerEffectsComponent)
			{
				PlayerEffectsComponent.UpdateData(view_data.Process, view_data.IsInteracting, view_data.IsHolding, view_data.IsPaused);
			}
		}

		private void Update()
		{
			if (!Data.IsPaused)
			{
				bool is_moving = false;
				if ((bool)PlayerMovementComp)
				{
					PlayerMovementComp.UpdateMovement(IsMyPlayer, Data.PlayerID, Data.Inputs, Data.Speed, Speed);
					is_moving = PlayerMovementComp.IsMoving;
				}
				if ((bool)PlayerEffectsComponent)
				{
					PlayerEffectsComponent.UpdateMoving(is_moving);
				}
			}
		}

		public override bool HasStateUpdate(out IResponseData state)
		{
			state = null;
			if (!IsMyPlayer)
			{
				return false;
			}
			Transform transform = base.transform;
			ResponseData responseData = new ResponseData
			{
				Position = PlayerMovementComp.GetCurrentPosition(),
				Rotation = transform.localRotation
			};
			if (responseData.Position.ApproximatelyEqual(PreviousResponse.Position) && !responseData.Rotation.IsChangedFrom(PreviousResponse.Rotation))
			{
				return false;
			}
			PreviousResponse = responseData;
			state = responseData;
			return true;
		}
	}
}
