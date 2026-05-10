using CTS;

namespace ES3Types
{
	public class ES3UserType_AgentTagsArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_AgentTagsArray()
			: base(typeof(AgentTags[]), ES3UserType_AgentTags.Instance)
		{
			Instance = this;
		}
	}
}
