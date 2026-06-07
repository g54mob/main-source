using System;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public interface IFuselageData
	{
		AttachPointData FrontAttachPoint { get; }

		bool IsHollow { get; }

		bool IsTransparent { get; }

		AttachPointData RearAttachPoint { get; }

		event Action OnMeshRegenerated;

		bool ShapeMatches(IFuselageData other, bool thisFront, bool otherFront);
	}
}
