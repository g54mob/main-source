using Assets.Scripts.Flight.Combat;

namespace Assets.Scripts.Flight.UI.Targeting
{
	public interface ITargetBox
	{
		TrackedTarget TrackedTarget { get; }

		void Destroy();

		void SetActive(bool active);
	}
}
