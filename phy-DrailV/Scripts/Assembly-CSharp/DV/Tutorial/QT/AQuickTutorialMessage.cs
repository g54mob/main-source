namespace DV.Tutorial.QT
{
	public abstract class AQuickTutorialMessage
	{
		public static implicit operator AQuickTutorialMessage(string s)
		{
			return new VerbSimpleQuickTutorialMessage(s);
		}

		public string GetMessage(QTVerb verb)
		{
			if (this is VerbSimpleQuickTutorialMessage verbSimpleQuickTutorialMessage)
			{
				return verbSimpleQuickTutorialMessage.Format(verb);
			}
			if (this is ControlIconQuickTutorialMessage controlIconQuickTutorialMessage)
			{
				return controlIconQuickTutorialMessage.Format(verb);
			}
			return "Type " + GetType().Name + " not found!";
		}
	}
}
