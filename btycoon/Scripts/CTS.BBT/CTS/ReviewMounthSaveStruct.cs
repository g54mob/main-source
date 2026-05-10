using System;

namespace CTS
{
	[Serializable]
	public struct ReviewMounthSaveStruct
	{
		public ReviewPanelSaveStruct HumanReview;

		public ReviewPanelSaveStruct VampireReview;
	}
}
