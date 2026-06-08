using System;
using Unity.Mathematics;

namespace Kitchen
{
	public class RotateAppliances : ApplianceInteractionSystem
	{
		private CPosition Position;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CPosition>(data.Target, out Position))
			{
				return false;
			}
			if (Has<CMustHaveWall>(data.Target))
			{
				return false;
			}
			if (Has<CFixedRotation>(data.Target))
			{
				return false;
			}
			if (!Has<CAppliance>(data.Target))
			{
				return false;
			}
			return true;
		}

		protected override void Perform(ref InteractionData data)
		{
			quaternion rotation = math.mul(quaternion.RotateY((float)Math.PI / 2f), Position.Rotation);
			SetComponent(data.Target, new CPosition
			{
				Position = Position.Position,
				Rotation = rotation
			});
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
