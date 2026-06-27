namespace Restory.Gameplay.Elements
{
	public interface IAnimatedElementGroup
	{
		void Init();

		void Activate();

		void Deactivate(bool isDeviceCheck);
	}
}
