using Rhizomatic.ImUI;
using Rhizomatic.Reactive;

namespace GRP
{
	public class ProjectSettings : IExpositorUI, IExpositorEdit
	{
		[JsonDataState(null)]
		public State<bool> advanced;

		[JsonDataState(null)]
		public State<string> scene;

		[JsonDataState(null)]
		public State<float> handleGrid;

		[JsonDataState(null)]
		public State<float> moveGrid;

		[JsonDataState(null)]
		public State<float> rotateGrid;

		private Project project;

		private string[] scenes;

		private UndoSnapshot snapshot;

		public ProjectSettings(Project project)
		{
		}

		public void OnExpositorUI(ImUIBuilder ui)
		{
		}

		public void OnExpositorEditStart()
		{
		}

		public UndoStep OnExpositorEditEnd()
		{
			return null;
		}

		public ProjectSettingsData Serialize()
		{
			return null;
		}

		public void Deserialize(ProjectSettingsData data)
		{
		}
	}
}
