using System;
using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;
using UnityEngine.SceneManagement;

namespace GRP
{
	public class Project : Thing<ProjectConfig>
	{
		public EntityManager<Part, PartConfig> parts;

		public Hub hub;

		public ProjectSettings settings;

		public ControlsViewer controlsViewer;

		public PaletteViewer paletteViewer;

		public PartDefinition glueDefinition;

		public Catalog editorCatalog;

		public Catalog sandboxCatalog;

		public Book gearpedia;

		public ProjectSceneLoader sceneLoader;

		public OrbitCameraViewable camera;

		public Selector<Part> selector;

		public ExpositorViewable expositor;

		public ProjectUndo undo;

		public State<float> timeScale;

		public NetGame netGame;

		public List<Tool> tools;

		public State<Tool> selectedTool;

		public BuildTool buildTool;

		public HandleTool handleTool;

		public string loadedVersion;

		public UndoSnapshot expositorPartSnapshot;

		public Action<Scene> onSceneReady;

		public StateSelector<int> selectionUnlockedCount;

		public State<bool> advanced => null;

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}

		public bool GetSnap()
		{
			return false;
		}

		public bool CanInteractPart()
		{
			return false;
		}

		public void ToggleExpositor(IExpositorUI target)
		{
		}

		public void ToggleHub()
		{
		}

		public void ToggleSettings()
		{
		}

		public void ToggleControl()
		{
		}

		public void TogglePalette()
		{
		}

		public void ToggleTool(Tool tool)
		{
		}

		public void SelectTool(Tool tool)
		{
		}

		public void DestroyPart(Part part)
		{
		}

		public void DestroyParts(IEnumerable<Part> parts)
		{
		}

		public void DestroyParts(IEnumerable<EntityData> partsData)
		{
		}

		public void DestroyParts(IEnumerable<Id> ids)
		{
		}

		public Part CreatePart(EntityData data)
		{
			return null;
		}

		public Part CreatePart(EntityData data, Id id)
		{
			return null;
		}

		public void CreateParts(EntityData[] partsData, int[] orders)
		{
		}

		public Part[] MergeParts(EntityData[] partsData)
		{
			return null;
		}

		public Part GetLastUnlocked()
		{
			return null;
		}

		public string GetProjectHash()
		{
			return null;
		}

		public void EnsureId(int count)
		{
		}

		public bool TryReadId(out Id id)
		{
			id = default(Id);
			return false;
		}

		public bool CanReadId(int count)
		{
			return false;
		}

		public void DeserializeSelector(SelectorData data)
		{
		}

		public void DeserializeHub(HubData data)
		{
		}

		public void DeserializeSettings(ProjectSettingsData data)
		{
		}

		public void DeserializePartsDiff(IEnumerable<EntityData> partsData)
		{
		}

		public ProjectData Serialize()
		{
			return null;
		}

		public void Deserialize(ProjectData data)
		{
		}
	}
}
