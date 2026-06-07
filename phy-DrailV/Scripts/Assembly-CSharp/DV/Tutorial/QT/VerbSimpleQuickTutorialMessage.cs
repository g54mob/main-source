namespace DV.Tutorial.QT
{
	public class VerbSimpleQuickTutorialMessage : AQuickTutorialMessage
	{
		public string message;

		public VerbSimpleQuickTutorialMessage(string message)
		{
			this.message = message;
		}

		public string Format(QTVerb verb)
		{
			if (verb != QTVerb.None)
			{
				return "<b><color=" + AQuickTutorialStep.GetVerbColor(verb) + ">" + AQuickTutorialStep.GetVerbLocalizedString(verb) + "</b></color> - " + message;
			}
			return message;
		}

		public static implicit operator string(VerbSimpleQuickTutorialMessage m)
		{
			return m.message;
		}

		public static implicit operator VerbSimpleQuickTutorialMessage(string s)
		{
			return new VerbSimpleQuickTutorialMessage(s);
		}
	}
}
