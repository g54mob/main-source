using System;
using System.Collections.Generic;
using Rhizomatic;

namespace GRP
{
	public class ProjectContainer : Thing
	{
		public ProjectConfig projectConfig;

		public Project project;

		public ProjectPage projectPage;

		public NavigatorContext navigatorContext;

		public Action<Project> onProjectChanged;

		public Action<ProjectSimPage> onSim;

		public Action onClose;

		private ProjectSaveHandler saveHandler;

		private List<Type> currentFrames;

		public void Setup(ProjectConfig projectConfig, NavigatorContext navigatorContext, ProjectSaveHandler saveHandler = null)
		{
		}

		public void Setup(ProjectConfig projectConfig, NavigatorContext navigatorContext, ProjectData data)
		{
		}

		public override void OnContextDispose()
		{
		}

		public void Save()
		{
		}

		public void Close()
		{
		}

		public Project CreateNewProject()
		{
			return null;
		}

		public void LoadProject(ProjectData data)
		{
		}

		public void New()
		{
		}

		public void SaveWith(ProjectSaveHandler saveHandler)
		{
		}

		public void StartSim()
		{
		}

		private void PopProjectPage()
		{
		}

		public int GetFramesCount()
		{
			return 0;
		}

		public T GetFrame<T>() where T : ProjectFramePage
		{
			return null;
		}

		public MissionFramePage AddFrameMission()
		{
			return null;
		}

		public SandboxFramePage AddFrameSandbox()
		{
			return null;
		}

		public ProjectEditorFramePage AddFrameEditor()
		{
			return null;
		}

		public MissionEditorFramePage AddFrameMissionEditor()
		{
			return null;
		}

		public KitFramePage AddFrameKit(Kit kit, bool lockFirstPiece = false)
		{
			return null;
		}

		public ProjectContainer RecoverFrames()
		{
			return null;
		}

		public ProjectContainer OpenPage()
		{
			return null;
		}

		public T AddFrame<T>(T framePage) where T : ProjectFramePage
		{
			return null;
		}

		public ProjectContainer ClearFrames()
		{
			return null;
		}

		public void OpenFilePage(Action<ProjectContainer> onOpen, ProjectView projectView = null)
		{
		}
	}
}
