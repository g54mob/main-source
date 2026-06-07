using UltimateReplay.Core;
using UnityEngine;

namespace UltimateReplay.Storage
{
	public struct ReplayInitialData : IReplaySerialize
	{
		private ReplayInitialDataFlags flags;

		public ReplayIdentity objectIdentity;

		public float timestamp;

		public Vector3 position;

		public Quaternion rotation;

		public Vector3 scale;

		public ReplayIdentity parentIdentity;

		public ReplayIdentity[] observedComponentIdentities;

		public ReplayInitialDataFlags InitialFlags => flags;

		public void UpdateDataFlags()
		{
			flags = ReplayInitialDataFlags.None;
			if (position != Vector3.zero)
			{
				flags |= ReplayInitialDataFlags.Position;
			}
			if (rotation != Quaternion.identity)
			{
				flags |= ReplayInitialDataFlags.Rotation;
			}
			if (scale != Vector3.one)
			{
				flags |= ReplayInitialDataFlags.Scale;
			}
			if (parentIdentity != null)
			{
				flags |= ReplayInitialDataFlags.Parent;
			}
		}

		public void OnReplaySerialize(ReplayState state)
		{
			state.Write(objectIdentity);
			state.Write(timestamp);
			flags = ReplayInitialDataFlags.None;
			UpdateDataFlags();
			state.Write((short)flags);
			if ((flags & ReplayInitialDataFlags.Position) != ReplayInitialDataFlags.None)
			{
				state.Write(position);
			}
			if ((flags & ReplayInitialDataFlags.Rotation) != ReplayInitialDataFlags.None)
			{
				state.Write(rotation);
			}
			if ((flags & ReplayInitialDataFlags.Scale) != ReplayInitialDataFlags.None)
			{
				state.Write(scale);
			}
			if ((flags & ReplayInitialDataFlags.Parent) != ReplayInitialDataFlags.None)
			{
				state.Write(parentIdentity);
			}
			int num = ((observedComponentIdentities != null) ? observedComponentIdentities.Length : 0);
			state.Write((short)num);
			for (int i = 0; i < num; i++)
			{
				state.Write(observedComponentIdentities[i]);
			}
		}

		public void OnReplayDeserialize(ReplayState state)
		{
			objectIdentity = state.ReadIdentity();
			timestamp = state.ReadFloat();
			flags = (ReplayInitialDataFlags)state.Read16();
			if ((flags & ReplayInitialDataFlags.Position) != ReplayInitialDataFlags.None)
			{
				position = state.ReadVec3();
			}
			if ((flags & ReplayInitialDataFlags.Rotation) != ReplayInitialDataFlags.None)
			{
				rotation = state.ReadQuat();
			}
			if ((flags & ReplayInitialDataFlags.Scale) != ReplayInitialDataFlags.None)
			{
				scale = state.ReadVec3();
			}
			if ((flags & ReplayInitialDataFlags.Parent) != ReplayInitialDataFlags.None)
			{
				parentIdentity = state.ReadIdentity();
			}
			int num = state.Read16();
			observedComponentIdentities = new ReplayIdentity[num];
			for (int i = 0; i < num; i++)
			{
				observedComponentIdentities[i] = state.ReadIdentity();
			}
		}
	}
}
