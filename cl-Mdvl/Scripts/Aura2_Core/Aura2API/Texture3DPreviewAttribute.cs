using UnityEngine;

namespace Aura2API
{
	public class Texture3DPreviewAttribute : PropertyAttribute
	{
		public readonly bool showField;

		public Texture3DPreviewAttribute(bool showField = true)
		{
			this.showField = showField;
		}
	}
}
