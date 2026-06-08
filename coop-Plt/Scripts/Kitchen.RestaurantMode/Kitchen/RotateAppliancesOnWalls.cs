using UnityEngine;

namespace Kitchen
{
	public class RotateAppliancesOnWalls : ApplianceInteractionSystem
	{
		private CPosition Position;

		protected override bool IsPossible(ref InteractionData data)
		{
			if (!Require<CPosition>(data.Target, out Position))
			{
				return false;
			}
			if (!Has<CMustHaveWall>(data.Target))
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
			Orientation o = Position.Rotation.ToOrientation();
			CLayoutRoomTile tile = base.TileManager.GetTile(Position);
			for (int i = 1; i < 4; i++)
			{
				o = o.RotateCW();
				Vector3 vector = o.ToOffset();
				if (base.TileManager.GetRoom(Position + vector) != tile.RoomID && !tile.CanReach(o))
				{
					SetComponent(data.Target, new CPosition
					{
						Position = Position.Position,
						Rotation = o.ToRotation()
					});
					break;
				}
			}
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
