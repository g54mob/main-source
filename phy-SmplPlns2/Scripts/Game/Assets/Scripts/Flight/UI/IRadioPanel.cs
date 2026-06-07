namespace Assets.Scripts.Flight.UI
{
	public interface IRadioPanel
	{
		void CreateMessage(string message, string source, string profileImage, string audioFile = null, bool immediate = false);
	}
}
