using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Dorfromantik.UI
{
	public class UiUtilityDebugger : ScriptableObject
	{
		[SerializeField]
		public List<HorizontalOrVerticalLayoutGroup> horizontalOrVerticalLayoutGroupsToRebuild;

		public void RebuildHorizontalOrVerticalLayoutGroupAndCanvas()
		{
			List<HorizontalOrVerticalLayoutGroup> list = horizontalOrVerticalLayoutGroupsToRebuild;
			if (list != null && list.Count > 0)
			{
				UiUtility.RebuildHorizontalOrVerticalLayoutGroupsAndCanvas(horizontalOrVerticalLayoutGroupsToRebuild);
			}
		}
	}
}
