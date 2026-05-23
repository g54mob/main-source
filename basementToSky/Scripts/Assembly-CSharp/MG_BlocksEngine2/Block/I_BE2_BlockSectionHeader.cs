using UnityEngine;
using UnityEngine.UI;

namespace MG_BlocksEngine2.Block
{
	public interface I_BE2_BlockSectionHeader
	{
		RectTransform RectTransform { get; }

		I_BE2_BlockSectionHeaderItem[] ItemsArray { get; }

		I_BE2_BlockSectionHeaderInput[] InputsArray { get; }

		Vector2 Size { get; }

		Shadow Shadow { get; }

		void UpdateLayout();

		void UpdateItemsArray();

		void UpdateInputsArray();
	}
}
