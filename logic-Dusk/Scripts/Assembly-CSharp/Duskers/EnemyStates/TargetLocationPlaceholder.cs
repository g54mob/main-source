using UnityEngine;

namespace Duskers.EnemyStates
{
	public class TargetLocationPlaceholder : ITargetLocation
	{
		private Vector3 _position;

		public Vector3 Position
		{
			get
			{
				return _position;
			}
		}

		public Room CurrentRoom { get; set; }

		public Corridor CurrentCorridor { get; set; }

		public TargetLocationPlaceholder(ITargetLocation targetLocation)
		{
			Update(targetLocation);
		}

		public void Update(ITargetLocation targetLocation)
		{
			if (targetLocation != null)
			{
				_position = targetLocation.Position;
				CurrentRoom = targetLocation.CurrentRoom;
				CurrentCorridor = targetLocation.CurrentCorridor;
			}
		}
	}
}
