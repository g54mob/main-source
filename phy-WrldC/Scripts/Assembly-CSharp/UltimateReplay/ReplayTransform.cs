using UnityEngine;

namespace UltimateReplay
{
	[DisallowMultipleComponent]
	public class ReplayTransform : ReplayBehaviour
	{
		public enum ReplayTransformRecordSpace
		{
			None = 0,
			Local = 1,
			World = 2
		}

		private ReplayTransformFlags targetFlags;

		private Vector3 lastPosition = Vector3.zero;

		private Vector3 targetPosition = Vector3.zero;

		private Quaternion lastRotation = Quaternion.identity;

		private Quaternion targetRotation = Quaternion.identity;

		private Vector3 lastScale = Vector3.one;

		private Vector3 targetScale = Vector3.one;

		public ReplayTransformRecordSpace recordPosition = ReplayTransformRecordSpace.Local;

		public ReplayTransformRecordSpace recordRotation = ReplayTransformRecordSpace.Local;

		public bool recordScale;

		public bool interpolate = true;

		public bool lowPrecision;

		public override void OnEnable()
		{
			base.OnEnable();
			if (recordPosition == ReplayTransformRecordSpace.Local)
			{
				lastPosition = (targetPosition = base.transform.localPosition);
			}
			else
			{
				lastPosition = (targetPosition = base.transform.position);
			}
			if (recordRotation == ReplayTransformRecordSpace.Local)
			{
				lastRotation = (targetRotation = base.transform.localRotation);
			}
			else
			{
				lastRotation = (targetRotation = base.transform.rotation);
			}
			lastScale = (targetScale = base.transform.localScale);
		}

		public override void OnReplaySpawned(Vector3 position, Quaternion rotation)
		{
			lastPosition = (targetPosition = position);
			lastRotation = (targetRotation = rotation);
			lastScale = (targetScale = base.transform.localScale);
		}

		public override void OnReplayReset()
		{
			lastPosition = targetPosition;
			lastRotation = targetRotation;
			lastScale = targetScale;
		}

		public override void OnReplayUpdate()
		{
			Vector3 vector = targetPosition;
			Quaternion quaternion = targetRotation;
			Vector3 localScale = targetScale;
			if (interpolate)
			{
				vector = Vector3.Lerp(lastPosition, targetPosition, ReplayTime.Delta);
				quaternion = Quaternion.Lerp(lastRotation, targetRotation, ReplayTime.Delta);
				localScale = Vector3.Lerp(lastScale, targetScale, ReplayTime.Delta);
			}
			if ((targetFlags & ReplayTransformFlags.Position) != 0)
			{
				if ((targetFlags & ReplayTransformFlags.LocalPosition) != 0)
				{
					base.transform.localPosition = vector;
				}
				else
				{
					base.transform.position = vector;
				}
			}
			if ((targetFlags & ReplayTransformFlags.Rotation) != 0)
			{
				if ((targetFlags & ReplayTransformFlags.LocalRotation) != 0)
				{
					base.transform.localRotation = quaternion;
				}
				else if (recordRotation == ReplayTransformRecordSpace.World)
				{
					base.transform.rotation = quaternion;
				}
			}
			if ((targetFlags & ReplayTransformFlags.Scale) != 0)
			{
				base.transform.localScale = localScale;
			}
		}

		public override void OnReplaySerialize(ReplayState state)
		{
			ReplayTransformFlags replayTransformFlags = (ReplayTransformFlags)0;
			if (recordPosition != ReplayTransformRecordSpace.None)
			{
				replayTransformFlags |= ReplayTransformFlags.Position;
				if (recordPosition == ReplayTransformRecordSpace.Local)
				{
					replayTransformFlags |= ReplayTransformFlags.LocalPosition;
				}
			}
			if (recordRotation != ReplayTransformRecordSpace.None)
			{
				replayTransformFlags |= ReplayTransformFlags.Rotation;
				if (recordRotation == ReplayTransformRecordSpace.Local)
				{
					replayTransformFlags |= ReplayTransformFlags.LocalRotation;
				}
			}
			if (recordScale)
			{
				replayTransformFlags |= ReplayTransformFlags.Scale;
			}
			if (replayTransformFlags == (ReplayTransformFlags)0)
			{
				return;
			}
			if (lowPrecision)
			{
				replayTransformFlags |= ReplayTransformFlags.LowPrecision;
			}
			state.Write((short)replayTransformFlags);
			if (!lowPrecision)
			{
				if ((replayTransformFlags & ReplayTransformFlags.Position) != 0)
				{
					if ((replayTransformFlags & ReplayTransformFlags.LocalPosition) != 0)
					{
						state.Write(base.transform.localPosition);
					}
					else
					{
						state.Write(base.transform.position);
					}
				}
				if ((replayTransformFlags & ReplayTransformFlags.Rotation) != 0)
				{
					if ((replayTransformFlags & ReplayTransformFlags.LocalRotation) != 0)
					{
						state.Write(base.transform.localRotation);
					}
					else
					{
						state.Write(base.transform.rotation);
					}
				}
				if ((replayTransformFlags & ReplayTransformFlags.Scale) != 0)
				{
					state.Write(base.transform.localScale);
				}
				return;
			}
			if ((replayTransformFlags & ReplayTransformFlags.Position) != 0)
			{
				if ((replayTransformFlags & ReplayTransformFlags.LocalPosition) != 0)
				{
					state.WriteLowPrecision(base.transform.localPosition);
				}
				else
				{
					state.WriteLowPrecision(base.transform.position);
				}
			}
			if ((replayTransformFlags & ReplayTransformFlags.Rotation) != 0)
			{
				if ((replayTransformFlags & ReplayTransformFlags.LocalRotation) != 0)
				{
					state.WriteLowPrecision(base.transform.localRotation);
				}
				else
				{
					state.WriteLowPrecision(base.transform.rotation);
				}
			}
			if ((replayTransformFlags & ReplayTransformFlags.Scale) != 0)
			{
				state.WriteLowPrecision(base.transform.localScale);
			}
		}

		public override void OnReplayDeserialize(ReplayState state)
		{
			OnReplayReset();
			targetFlags = (ReplayTransformFlags)state.Read16();
			if ((targetFlags & ReplayTransformFlags.LowPrecision) == 0)
			{
				if ((targetFlags & ReplayTransformFlags.Position) != 0)
				{
					targetPosition = state.ReadVec3();
				}
				if ((targetFlags & ReplayTransformFlags.Rotation) != 0)
				{
					targetRotation = state.ReadQuat();
				}
				if ((targetFlags & ReplayTransformFlags.Scale) != 0)
				{
					targetScale = state.ReadVec3();
				}
			}
			else
			{
				if ((targetFlags & ReplayTransformFlags.Position) != 0)
				{
					targetPosition = state.ReadVec3LowPrecision();
				}
				if ((targetFlags & ReplayTransformFlags.Rotation) != 0)
				{
					targetRotation = state.ReadQuatLowPrecision();
				}
				if ((targetFlags & ReplayTransformFlags.Scale) != 0)
				{
					targetScale = state.ReadVec3LowPrecision();
				}
			}
		}
	}
}
