using Rhizomatic;
using UnityEngine;

namespace GRP
{
	[CreateAssetMenu(menuName = "GRP/Main/SelectablePartConfig", fileName = "SelectablePartConfig")]
	[AssetCreator(typeof(MainAssetCategory))]
	public class SelectablePartConfig : ScriptableObject
	{
		public HighlightConfig highlight;

		public HighlightConfig lockedHighlight;
	}
}
