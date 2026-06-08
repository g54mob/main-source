using System;

namespace XRL.World.Parts
{
	public abstract class IPartExtension<T> : IPart where T : IPart
	{
		[NonSerialized]
		public T ParentPart;

		public override void FinalizeRead(SerializationReader Reader)
		{
			if (!ParentObject.TryGetPart<T>(out ParentPart))
			{
				MetricsManager.LogAssemblyWarning(GetType(), "Lost parent part reference, removing " + GetType().GetName() + " from " + ParentObject.DebugName);
				ParentObject.RemovePart(this);
			}
		}
	}
}
