using System.Diagnostics;

namespace WaveHarmonic.Crest
{
	[Conditional("UNITY_EDITOR")]
	internal sealed class HelpBox : Decorator
	{
		public enum MessageType
		{
			Info = 0,
			Warning = 1,
			Error = 2
		}

		public enum Visibility
		{
			Always = 0,
			PropertyEnabled = 1,
			PropertyDisabled = 2
		}

		public HelpBox(string message, MessageType messageType = MessageType.Info, Visibility visibility = Visibility.Always)
		{
		}
	}
}
