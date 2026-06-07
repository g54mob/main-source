using Assets.Scripts.Flight.UI;

namespace Assets.Scripts.GuiNew
{
	public interface IFadingMessage
	{
		bool CanFloat { get; }

		bool IsDead { get; }

		void Destroy(bool immediate);

		void ShowMessage(MessageManager.Message message);

		void Update(float deltaTime);
	}
}
