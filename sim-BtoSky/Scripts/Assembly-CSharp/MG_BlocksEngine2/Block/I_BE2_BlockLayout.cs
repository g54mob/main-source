using UnityEngine;

namespace MG_BlocksEngine2.Block
{
	public interface I_BE2_BlockLayout
	{
		RectTransform RectTransform { get; set; }

		I_BE2_BlockSection[] SectionsArray { get; }

		BE2_OuterArea OuterArea { get; set; }

		Color Color { get; set; }

		Vector2 Size { get; }

		void UpdateLayout();
	}
}
