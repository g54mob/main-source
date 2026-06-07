using System.Linq;
using System.Xml.Linq;
using Assets.Scripts.Levels.LevelScripts.FlightTutorial;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Flight.UI;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class TutorialStepRequirement : ContractRequirement
	{
		private bool _checkTutorialId;

		private string _text;

		private string _tutorialId;

		public FlightTutorialState State { get; private set; }

		public bool TutorialCompleted { get; private set; }

		public IFlightTutorialPanel TutorialPanel => base.FlightContext.FlightTutorialPanel;

		public bool TutorialStarted { get; private set; }

		public TutorialStepRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			_text = xml.GetStringAttribute("stepText");
			_tutorialId = xml.GetStringAttribute("tutorialId");
		}

		public override void OnFlightStart(IFlightContext flightContext)
		{
			base.OnFlightStart(flightContext);
			_checkTutorialId = true;
			TutorialStarted = false;
			TutorialCompleted = false;
		}

		public override void OnFlightUpdate(ICraftNode craftNode, bool parentsPassing)
		{
			base.OnFlightUpdate(craftNode, parentsPassing);
			if (base.IsActive && State != null)
			{
				State.PauseIfNecessary();
			}
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (_checkTutorialId)
			{
				_checkTutorialId = false;
				if (!string.IsNullOrEmpty(_tutorialId))
				{
					ICraftScript craftScript = base.FlightContext.CraftNode.CraftScript;
					if (craftScript != null && craftScript.Data.Assembly.Parts.Where((PartData x) => x.Config.TutorialId == _tutorialId).Any())
					{
						StartTutorial();
					}
					else
					{
						MarkAsComplete();
					}
				}
				else
				{
					StartTutorial();
				}
			}
			if (State != null)
			{
				State.EnsureBegin();
				if (_text != null)
				{
					State.SetStepText(_text);
				}
			}
			return State != null;
		}

		protected override void OnStatusChanged()
		{
			base.OnStatusChanged();
			if (base.Status == RequirementStatus.Complete)
			{
				if (State != null)
				{
					TutorialCompleted = true;
					State.TutorialPanel.OnClosed = null;
					State.TutorialPanel.CloseTutorial();
					State = null;
				}
			}
			else if (base.Status != RequirementStatus.Active && base.Status != RequirementStatus.Pass && State != null)
			{
				TutorialPanel.Visible = false;
			}
		}

		private void StartTutorial()
		{
			TutorialStarted = true;
			State = new FlightTutorialState(base.FlightContext.CraftNode.CraftScript, null);
			State.ClearInstructionText = false;
			State.PauseImmediatelyAfterFailing = false;
			State.TutorialPanel = TutorialPanel as FlightTutorialPanelScript;
			State.TutorialPanel.Visible = true;
			State.TutorialPanel.CanClose = true;
			State.TutorialPanel.OnClosed = delegate
			{
				MarkAsComplete();
			};
		}
	}
}
