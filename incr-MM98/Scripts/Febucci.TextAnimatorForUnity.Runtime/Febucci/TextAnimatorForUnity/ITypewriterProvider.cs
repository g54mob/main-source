namespace Febucci.TextAnimatorForUnity
{
	internal interface ITypewriterProvider
	{
		bool IsShowingText { get; }

		bool IsHidingText { get; }

		void ShowText(string text);

		void SkipTypewriter();

		void StartShowingText(bool restart = false);

		void StopShowingText();

		void StartDisappearingText();

		void StopDisappearingText();

		void SetTypewriterSpeed(float speed);

		void TriggerVisibleEvents();

		void TriggerRemainingEvents();
	}
}
