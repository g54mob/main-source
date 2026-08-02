using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;

namespace GRP
{
	public class RenamePage : Page
	{
		[InputFieldCrew]
		[TextCrew]
		public State<string> name;

		[GameObjectCrew]
		public State<bool> hasError;

		[TextCrew]
		public State<string> error;

		public State<string> path;

		private string currentName;

		public RenamePage(string path)
		{
		}

		[CrewMethod]
		public void Ok()
		{
		}

		public bool CheckError(out string message)
		{
			message = null;
			return false;
		}

		[CrewMethod]
		public void Back()
		{
		}
	}
}
