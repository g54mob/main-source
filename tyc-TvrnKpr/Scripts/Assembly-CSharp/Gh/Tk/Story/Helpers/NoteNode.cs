using UnityEngine;
using XNode;

namespace Gh.Tk.Story.Helpers
{
	[NodeWidth(300)]
	[NodeTint("#bfb32c")]
	public class NoteNode : Node
	{
		[TextArea(5, 10)]
		public string note;
	}
}
