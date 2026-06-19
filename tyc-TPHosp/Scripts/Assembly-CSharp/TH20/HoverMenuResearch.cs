using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;

namespace TH20
{
	public class HoverMenuResearch : HoverMenuRoomItemBase
	{
		[SerializeField]
		private TMP_Text _title;

		[SerializeField]
		private TMP_Text _name;

		[SerializeField]
		private ProgressBarMaskable _progressBar;

		private ResearchProject _assignedProject;

		public override void Setup(RoomItem roomItem, Level level)
		{
			base.Setup(roomItem, level);
			ResearchProjectComponent component = _roomItem.GetComponent<ResearchProjectComponent>();
			_title.text = roomItem.LocalisedName;
			if (component.Project == null)
			{
				_assignedProject = null;
				_name.text = ScriptLocalization.Menu.Hover_Research_StartProject_CS;
				_progressBar.gameObject.SetActive(value: false);
			}
			else
			{
				_assignedProject = component.Project;
				_name.text = ScriptLocalization.Menu.Hover_Research_ProjectName_CS.Replace("{[NAME]}", _assignedProject.Definition.NameLocalised.Translation);
				UpdateProgress(_assignedProject);
			}
			ResearchManager researchManager = base.Level.ResearchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Combine(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
		}

		private void OnResearchProjectComplete(ResearchProject researchProject)
		{
			if (_assignedProject == researchProject)
			{
				CloseMenu();
			}
		}

		public override void Destroy()
		{
			ResearchManager researchManager = base.Level.ResearchManager;
			researchManager.OnResearchProjectComplete = (Action<ResearchProject>)Delegate.Remove(researchManager.OnResearchProjectComplete, new Action<ResearchProject>(OnResearchProjectComplete));
			base.Destroy();
		}

		protected override void Update()
		{
			base.Update();
			if (_assignedProject != null)
			{
				UpdateProgress(_assignedProject);
			}
		}

		private void UpdateProgress(ResearchProject project)
		{
			_progressBar.Progress = project.ResearchedPoints / project.Definition.ResearchPoints;
			_progressBar.LabelText = $"{(int)project.ResearchedPoints} / {(int)project.Definition.ResearchPoints}";
		}
	}
}
