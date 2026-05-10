using UnityEngine;

namespace FluffyUnderware.DevTools
{
	[HelpURL("https://curvyeditor.com/doclink/dtinspectornode")]
	public class InspectorNote : DTVersionedMonoBehaviour
	{
		[SerializeField]
		[TextArea(5, 20)]
		private string m_Note;
	}
}
