using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Michsky.DreamOS
{
	[ExecuteInEditMode]
	[DisallowMultipleComponent]
	[AddComponentMenu("DreamOS/Layout/Layout Group Fix")]
	public class LayoutGroupFix : MonoBehaviour
	{
		public enum RebuildMethod
		{
			ForceRebuild = 0,
			MarkRebuild = 1
		}

		[SerializeField]
		private bool fixOnEnable = true;

		[SerializeField]
		private bool fixWithDelay = true;

		[SerializeField]
		private RebuildMethod rebuildMethod;

		private float fixDelay = 0.025f;

		private void OnEnable()
		{
			if (!fixWithDelay && fixOnEnable && rebuildMethod == RebuildMethod.ForceRebuild)
			{
				ForceRebuild();
			}
			else if (!fixWithDelay && fixOnEnable && rebuildMethod == RebuildMethod.MarkRebuild)
			{
				MarkRebuild();
			}
			else if (fixWithDelay)
			{
				StartCoroutine(FixDelay());
			}
		}

		public void FixLayout()
		{
			if (!fixWithDelay && rebuildMethod == RebuildMethod.ForceRebuild)
			{
				ForceRebuild();
			}
			else if (!fixWithDelay && rebuildMethod == RebuildMethod.MarkRebuild)
			{
				MarkRebuild();
			}
			else
			{
				StartCoroutine(FixDelay());
			}
		}

		private void ForceRebuild()
		{
			LayoutRebuilder.ForceRebuildLayoutImmediate(GetComponent<RectTransform>());
		}

		private void MarkRebuild()
		{
			LayoutRebuilder.MarkLayoutForRebuild(GetComponent<RectTransform>());
		}

		private IEnumerator FixDelay()
		{
			yield return new WaitForSecondsRealtime(fixDelay);
			if (rebuildMethod == RebuildMethod.ForceRebuild)
			{
				ForceRebuild();
			}
			else if (rebuildMethod == RebuildMethod.MarkRebuild)
			{
				MarkRebuild();
			}
		}
	}
}
