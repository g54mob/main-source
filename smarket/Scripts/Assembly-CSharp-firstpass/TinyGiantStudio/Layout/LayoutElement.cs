using UnityEngine;

namespace TinyGiantStudio.Layout
{
	[DisallowMultipleComponent]
	[HelpURL("https://ferdowsur.gitbook.io/layout-system/layout-element")]
	public class LayoutElement : MonoBehaviour
	{
		[Tooltip("Ignores this element in layout group")]
		public bool ignoreElement;

		[Tooltip("This is overwritten on texts")]
		public bool autoCalculateSize;

		public float width;

		public float height;

		[HideInInspector]
		public float depth;

		public float xOffset;

		public float yOffset;

		public float zOffset;

		[Tooltip("Used in Grid layout.\nEnds current line and moves everything after it to next one.")]
		public bool lineBreak;

		public bool space;
	}
}
