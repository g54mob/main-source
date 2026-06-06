namespace MalbersAnimations
{
	public interface ICollectable : IObjectCore
	{
		bool InCoolDown { get; }

		bool IsPicked { get; set; }

		bool Collectable { get; set; }

		void Drop();

		void Pick();

		void OnDropEnablePhysics();

		void OnPickDisablePhysics();
	}
}
