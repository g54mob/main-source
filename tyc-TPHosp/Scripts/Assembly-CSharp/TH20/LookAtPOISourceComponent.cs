using UnityEngine;

namespace TH20
{
	public abstract class LookAtPOISourceComponent : EntityComponent
	{
		public abstract Vector3 LookAtPosition();

		public abstract Room GetRoomIn();
	}
}
