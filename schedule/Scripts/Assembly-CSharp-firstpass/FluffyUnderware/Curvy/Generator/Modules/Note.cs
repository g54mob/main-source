using UnityEngine;

namespace FluffyUnderware.Curvy.Generator.Modules
{
	[ModuleInfo("Note", ModuleName = "Note", Description = "Creates a note")]
	[HelpURL("https://curvyeditor.com/doclink/cgnote")]
	public class Note : CGModule, INoProcessing
	{
		[SerializeField]
		[TextArea(3, 10)]
		private string m_Note;

		public string NoteText
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		protected override void OnEnable()
		{
		}

		public override void Reset()
		{
		}
	}
}
