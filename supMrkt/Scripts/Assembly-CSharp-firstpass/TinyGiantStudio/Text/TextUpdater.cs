using UnityEngine;

namespace TinyGiantStudio.Text
{
	[DisallowMultipleComponent]
	[ExecuteAlways]
	[HelpURL("https://ferdowsur.gitbook.io/modular-3d-text/text/text-updater")]
	public class TextUpdater : MonoBehaviour
	{
		private Modular3DText Text => null;

		[ExecuteAlways]
		private void OnEnable()
		{
		}

		private bool EmptyText(Modular3DText text)
		{
			return false;
		}
	}
}
