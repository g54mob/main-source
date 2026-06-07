namespace Assets.Scripts.GuiNew
{
	public interface ITutorialMessage
	{
		void SetFade(float fade);

		void SetText(string text, bool showContinueButton);
	}
}
