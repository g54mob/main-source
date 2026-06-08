using System.Collections.Generic;
using UnityEngine;

public class TileStackReplacer : MonoBehaviour
{
	[SerializeField]
	private TileStack tileStack;

	[SerializeField]
	private List<TileReplacementOption> replacementOptions;

	private void Update()
	{
		foreach (TileReplacementOption replacementOption in replacementOptions)
		{
			if (Input.GetKeyDown(replacementOption.hotkey))
			{
				tileStack.ReplaceStackedTile(replacementOption.stackIndex, replacementOption.replacementTile);
			}
		}
	}
}
