using GRP.Net;
using Newtonsoft.Json.Linq;

namespace GRP
{
	public class ProjectUndo
	{
		public Project project;

		public UndoController controller;

		public NetProjectSession netProject;

		public ProjectUndo(Project project)
		{
		}

		public void OnUndo(UndoStep step)
		{
		}

		public void OnRedo(UndoStep step)
		{
		}

		public UndoSnapshot CreateSnapshot()
		{
			return null;
		}

		public void AddSelectorStep(UndoSnapshot snapshot, string name)
		{
		}

		public JObject Diff(JObject current, JObject previous)
		{
			return null;
		}

		public UndoStep AddEditPartStep(UndoSnapshot snapshot, string name)
		{
			return null;
		}

		public void AddStepCreatePart(UndoSnapshot snapshot, string name, params Part[] parts)
		{
		}

		public void AddStepDeletePart(UndoSnapshot snapshot, string name)
		{
		}

		public UndoStep AddHubStep(UndoSnapshot snapshot, string name)
		{
			return null;
		}

		public UndoStep AddSettingsStep(UndoSnapshot snapshot, string name)
		{
			return null;
		}
	}
}
