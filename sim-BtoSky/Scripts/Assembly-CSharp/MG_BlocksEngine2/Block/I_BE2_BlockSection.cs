using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public interface I_BE2_BlockSection
	{
		RectTransform RectTransform { get; }

		I_BE2_BlockSectionHeader Header { get; }

		I_BE2_BlockSectionBody Body { get; }

		Vector2 Size { get; }

		I_BE2_Block Block { get; set; }

		void UpdateLayout();
	}
}
