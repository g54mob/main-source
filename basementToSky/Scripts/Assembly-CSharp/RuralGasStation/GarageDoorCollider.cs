using UnityEngine;

namespace RuralGasStation
{
	public class GarageDoorCollider : IDoorCollider
	{
		[SerializeField]
		private IDoor _door;

		public override void Handle()
		{
			_door.Handle();
		}
	}
}
