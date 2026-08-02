using System.Collections.Generic;
using Rhizomatic;

namespace GRP
{
	public class ProjectConfig : Config
	{
		public EntityManagerConfig parts;

		public PartsContainerConfig partEntries;

		public ProjectPartConfig part;

		public ExhibitBuilderConfig exhibitBuilder;

		public SignalVisualConfig signalVisualConfig;

		public BookConfigEntry gearpedia;

		public HubConfig hub;

		public PartDefinitionConfig glueDefinition;

		public CatalogConfig editorCatalog;

		public CatalogConfig sandboxCatalog;

		public CreatedPartContainerConfig createdPart;

		public string defaultScene;

		public List<ProjectSceneItemConfig> scenes;

		public List<ToolConfig> tools;

		public ProjectSceneItemConfig GetScene(string key)
		{
			return null;
		}
	}
}
