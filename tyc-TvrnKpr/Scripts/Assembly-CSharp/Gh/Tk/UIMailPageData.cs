using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class UIMailPageData : UIDialogPageData
	{
		[FormerlySerializedAs("greeting")]
		public string greetingKey;

		[FormerlySerializedAs("farewell")]
		public string farewellKey;

		[FormerlySerializedAs("signature")]
		public string signatureKey;

		[FormerlySerializedAs("postScriptText")]
		public string postScriptTextKey;

		public string sealPrefab;
	}
}
