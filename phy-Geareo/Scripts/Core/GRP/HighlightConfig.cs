using UnityEngine;

namespace GRP
{
	public abstract class HighlightConfig : ScriptableObject
	{
		public Highlight GetHighlight()
		{
			return null;
		}

		protected abstract Highlight DoGetHighlight();
	}
}
