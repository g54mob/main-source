using System;
using UnityEngine;

namespace Assets.Scripts.Design.Tutorials
{
	public class TutorialScript : MonoBehaviour
	{
		public Tutorial CurrentTutorial { get; private set; }

		public DesignerScript Designer { get; private set; }

		public TutorialDatabase TutorialDB { get; private set; }

		public TutorialUIScript UI { get; private set; }

		public static TutorialScript Create(DesignerScript designer)
		{
			TutorialScript tutorialScript = designer.gameObject.AddComponent<TutorialScript>();
			tutorialScript.Initialize(designer);
			return tutorialScript;
		}

		public void EndTutorial()
		{
			try
			{
				Designer.Designer.UndoHistory.Enabled = true;
				UI.OnTutorialEnding(CurrentTutorial);
				if (CurrentTutorial != null)
				{
					CurrentTutorial.Info.IsDone = true;
					CurrentTutorial.EndTutorial();
					CurrentTutorial = null;
				}
				Designer.DesignerUI.Flyouts.Selected = Designer.DesignerUI.Flyouts.Tutorials;
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
		}

		public void MoveToNextStep()
		{
			CurrentTutorial?.MoveToNextStep();
		}

		public void MoveToPreviousStep()
		{
			CurrentTutorial?.MoveToPreviousStep();
		}

		public void RestartStep()
		{
			CurrentTutorial?.RestartStep();
		}

		public void StartTutorial(TutorialDatabase.TutorialInfo tutorialInfo)
		{
			StartTutorial(tutorialInfo.CreateTutorial(tutorialInfo));
		}

		public void StartTutorial(Tutorial tutorial)
		{
			try
			{
				if (CurrentTutorial != null && !CurrentTutorial.IsComplete)
				{
					EndTutorial();
				}
				CurrentTutorial = tutorial;
				Designer.Designer.UndoHistory.Enabled = false;
				tutorial.Initialize(this);
				UI.OnTutorialStarting(tutorial);
				tutorial.StartTutorial();
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
				Game.Instance.UserInterface.CreateMessageDialog("The tutorial failed to load.", "Tutorial Load Error");
				EndTutorial();
			}
		}

		protected virtual void FixedUpdate()
		{
			CurrentTutorial?.FixedUpdate();
		}

		protected void Initialize(DesignerScript designerScript)
		{
			Designer = designerScript;
			TutorialDB = new TutorialDatabase();
			UI = designerScript.DesignerUI.RootWidget.FindWidget("tutorial-ui").GetComponent<TutorialUIScript>();
			UI.Initialize(this);
		}

		protected virtual void LateUpdate()
		{
			CurrentTutorial?.LateUpdate();
		}

		protected virtual void Update()
		{
			CurrentTutorial?.Update();
		}
	}
}
