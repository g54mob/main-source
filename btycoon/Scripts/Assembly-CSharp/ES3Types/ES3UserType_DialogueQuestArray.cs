using CTS;

namespace ES3Types
{
	public class ES3UserType_DialogueQuestArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_DialogueQuestArray()
			: base(typeof(DialogueQuest[]), ES3UserType_DialogueQuest.Instance)
		{
			Instance = this;
		}
	}
}
