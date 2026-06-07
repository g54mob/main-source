using MoreMountains.Tools;
using UnityEngine;

namespace MoreMountains.Feedbacks
{
	public struct MMSpringVector4Event
	{
		private static MMSpringVector4Event e;

		public MMChannelData ChannelData;

		public MMSpringComponentBase TargetSpring;

		public SpringCommands Command;

		public Vector4 MoveToValue;

		public Vector4 BumpAmount;

		public Vector4 MoveToRandomValueMin;

		public Vector4 MoveToRandomValueMax;

		public Vector4 BumpAmountRandomValueMin;

		public Vector4 BumpAmountRandomValueMax;

		public bool OverrideDamping;

		public Vector4 NewDamping;

		public bool OverrideFrequency;

		public Vector4 NewFrequency;

		public static void Trigger(SpringCommands command, MMSpringComponentBase targetSpring, MMChannelData channelData, Vector4 moveToValue = default(Vector4), Vector4 bumpAmount = default(Vector4), Vector4 moveToRandomValueMin = default(Vector4), Vector4 moveToRandomValueMax = default(Vector4), Vector4 bumpAmountRandomValueMin = default(Vector4), Vector4 bumpAmountRandomValueMax = default(Vector4), bool overrideDamping = false, Vector4 newDamping = default(Vector4), bool overrideFrequency = false, Vector4 newFrequency = default(Vector4))
		{
			e.ChannelData = channelData;
			e.TargetSpring = targetSpring;
			e.Command = command;
			e.MoveToValue = moveToValue;
			e.BumpAmount = bumpAmount;
			e.MoveToRandomValueMin = moveToRandomValueMin;
			e.MoveToRandomValueMax = moveToRandomValueMax;
			e.BumpAmountRandomValueMin = bumpAmountRandomValueMin;
			e.BumpAmountRandomValueMax = bumpAmountRandomValueMax;
			e.OverrideDamping = overrideDamping;
			e.NewDamping = newDamping;
			e.OverrideFrequency = overrideFrequency;
			e.NewFrequency = newFrequency;
			MMEventManager.TriggerEvent(e);
		}
	}
}
