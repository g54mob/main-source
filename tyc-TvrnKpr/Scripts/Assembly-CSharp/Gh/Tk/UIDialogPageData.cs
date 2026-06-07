using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class UIDialogPageData : IPersistable
	{
		[FormerlySerializedAs("title")]
		public string titleKey;

		[FormerlySerializedAs("subTitle")]
		public string subTitleKey;

		[FormerlySerializedAs("text")]
		public string textKey;

		public string image;

		[FormerlySerializedAs("pastDecisionText")]
		public string pastDecisionTextKey;

		public int pageSeed;
	}
}
