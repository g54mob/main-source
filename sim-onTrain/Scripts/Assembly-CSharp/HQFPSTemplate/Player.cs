using UnityEngine;

namespace HQFPSTemplate
{
	public class Player : Humanoid
	{
		public Vector2 moveInput;

		public readonly Activity Pause = new Activity();

		public readonly Value<float> MoveCycle = new Value<float>();

		public readonly Message MoveCycleEnded = new Message();

		public readonly Value<RaycastInfo> RaycastInfo = new Value<RaycastInfo>(null);

		public readonly Value<Collider> ObjectInProximity = new Value<Collider>();

		public readonly Value<bool> ViewLocked = new Value<bool>();

		public readonly Value<float> Stamina = new Value<float>(100f);

		public readonly Value<Vector2> MoveInput = new Value<Vector2>(Vector2.zero);

		public readonly Value<Vector2> LookInput = new Value<Vector2>(Vector2.zero);

		public readonly Value<float> ScrollValue = new Value<float>(0f);

		public readonly Attempt DestroyEquippedItem = new Attempt();

		public readonly Attempt ChangeUseMode = new Attempt();

		public readonly Activity Swimming = new Activity();

		public readonly Activity OnLadder = new Activity();

		public readonly Activity Sliding = new Activity();

		[SerializeField]
		private PlayerCamera m_PlayerCamera;

		public PlayerCamera Camera => m_PlayerCamera;
	}
}
