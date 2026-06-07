using UnityEngine.Serialization;

namespace Gh.Tk
{
	public class CategoryIcon3DUIView : Button3DUIView
	{
		[FormerlySerializedAs("filterId")]
		public string categoryId;

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}
	}
}
