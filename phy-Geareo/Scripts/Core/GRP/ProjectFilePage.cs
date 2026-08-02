using System;
using System.Collections.Generic;
using Rhizomatic;
using Rhizomatic.Reactive;
using Rhizomatic.UI;
using UnityEngine;

namespace GRP
{
	public class ProjectFilePage : Page
	{
		[InputFieldCrew]
		public State<string> name;

		[RawImageCrew]
		public Texture2D thumbnail;

		[ListLoaderCrew]
		public StateSelector<List<Viewable>> items;

		public State<string> path;

		[TextCrew]
		public StateSelector<string> displayPath;

		[GameObjectCrew]
		public State<bool> showAlert;

		[GameObjectCrew]
		public bool showDetails;

		[TextCrew]
		public State<string> alert;

		public ProjectViewable projectView;

		public ProjectContainer projectContainer;

		public Project project;

		public Action<ProjectContainer> onOpen;

		public ProjectFilePage(Texture2D texture, ProjectContainer projectContainer, Action<ProjectContainer> onOpen)
		{
		}

		public override void OnContext()
		{
		}

		public override void OnContextDispose()
		{
		}

		public void OpenFolder(ProjectFolderDefinition folder)
		{
		}

		public void OpenFile(ProjectFileDefinition manifest)
		{
		}

		public List<Viewable> GetAllSaved()
		{
			return null;
		}

		public bool CheckAlert(out string message)
		{
			message = null;
			return false;
		}

		public static Texture2D ScreenShot(RenderTexture rt)
		{
			return null;
		}

		[CrewMethod]
		public void Save()
		{
		}

		public void DoSave(ProjectData data, string path, string name, Texture2D thumbnail, bool forceOverride)
		{
		}

		[CrewMethod]
		public void Close()
		{
		}

		[CrewMethod]
		public void Back()
		{
		}

		[CrewMethod]
		public void CreateNewFolder()
		{
		}

		[CrewMethod]
		public void OpenFileInExplorer()
		{
		}

		[CrewMethod]
		public void ImportBuiltinProjects()
		{
		}

		[CrewMethod]
		public void OpenSteamWorkshop()
		{
		}
	}
}
