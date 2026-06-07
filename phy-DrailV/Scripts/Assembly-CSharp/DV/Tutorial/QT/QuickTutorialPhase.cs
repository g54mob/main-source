using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class QuickTutorialPhase
	{
		private List<AQuickTutorialStep> steps = new List<AQuickTutorialStep>();

		private List<AQuickTutorialCondition> checks = new List<AQuickTutorialCondition>();

		private List<AQuickTutorialCondition> repeatChecks = new List<AQuickTutorialCondition>();

		private List<ATutorialService> services = new List<ATutorialService>();

		private AQuickTutorialCondition phaseSkipCondition;

		private AQuickTutorialStep lastStep;

		private int index;

		private float stableStep;

		private bool stepVisualsShown;

		public bool IsDone { get; private set; }

		public bool IsStarted { get; private set; }

		public bool IsFailed { get; private set; }

		public bool IsEmpty
		{
			get
			{
				if (steps.Count == 0)
				{
					return checks.Count == 0;
				}
				return false;
			}
		}

		public QuickTutorialHost Host { get; private set; }

		public AQuickTutorialStep CurrentStep
		{
			get
			{
				if (index < 0 || index >= steps.Count)
				{
					return null;
				}
				return steps[index];
			}
		}

		public AQuickTutorialStep LastStep
		{
			get
			{
				if (steps.Count <= 0)
				{
					return null;
				}
				return steps[steps.Count - 1];
			}
		}

		public AQuickTutorialCondition PhaseSkipCondition
		{
			get
			{
				return phaseSkipCondition;
			}
			set
			{
				phaseSkipCondition = value;
			}
		}

		public void Add(AQuickTutorialStep step)
		{
			steps.Add(step);
		}

		public void Add(ATutorialService service)
		{
			services.Add(service);
		}

		public void AddStartingCheck(AQuickTutorialCondition condition)
		{
			checks.Add(condition);
		}

		public void AddRepeatCheck(AQuickTutorialCondition condition)
		{
			repeatChecks.Add(condition);
		}

		public void Start(QuickTutorialHost host)
		{
			Debug.Log("<<< Starting phase with " + steps.Count + " step(s) >>>");
			foreach (AQuickTutorialCondition check in checks)
			{
				check.Start();
			}
			foreach (ATutorialService service in services)
			{
				service.StartService(host, this);
			}
			if (phaseSkipCondition != null)
			{
				phaseSkipCondition.Start();
			}
			Host = host;
			index = 0;
			IsStarted = true;
			IsFailed = false;
			lastStep = CurrentStep;
			stableStep = 0f;
			CurrentStep.MakeCurrent(host);
		}

		public void Fail()
		{
			foreach (AQuickTutorialCondition check in checks)
			{
				check.Deactivate();
			}
			foreach (ATutorialService service in services)
			{
				service.StopService(fullyCompleted: false);
			}
			if (phaseSkipCondition != null)
			{
				phaseSkipCondition.Deactivate();
			}
			if (CurrentStep != null)
			{
				CurrentStep.Deactivate();
			}
			IsFailed = true;
		}

		private void CompletePhase()
		{
			IsDone = true;
			foreach (ATutorialService service in services)
			{
				service.StopService(fullyCompleted: true);
			}
			if (phaseSkipCondition != null)
			{
				phaseSkipCondition.Deactivate();
			}
			Host = null;
		}

		public void Update()
		{
			if (IsFailed)
			{
				return;
			}
			foreach (AQuickTutorialCondition check in checks)
			{
				string text = check.Check();
				if (!string.IsNullOrEmpty(text))
				{
					Fail();
					Debug.LogError("Failed tutorial because: " + text);
					SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt(text, pause: true, delegate
					{
						IsDone = true;
						Host.NotifyFailed(this);
					});
					return;
				}
			}
			foreach (ATutorialService service in services)
			{
				service.UpdateService();
			}
			if (phaseSkipCondition != null && phaseSkipCondition.CheckAsBool())
			{
				if (CurrentStep != null)
				{
					CurrentStep.Deactivate();
				}
				Debug.Log("<<< Phase complete >>>");
				CompletePhase();
			}
			else if (CurrentStep.Check())
			{
				CurrentStep.Deactivate();
				index++;
				if (index == steps.Count)
				{
					bool flag = false;
					foreach (AQuickTutorialCondition repeatCheck in repeatChecks)
					{
						if (!repeatCheck.CheckAsBool())
						{
							flag = true;
							break;
						}
					}
					if (flag)
					{
						Debug.Log("<<< Phase repeating >>>");
						index = 0;
						Debug.Log("<<< Moving to step " + (index + 1) + " >>>");
						CurrentStep.MakeCurrent(Host);
					}
					else
					{
						Debug.Log("<<< Phase complete >>>");
						CompletePhase();
					}
				}
				else
				{
					Debug.Log("<<< Moving to step " + (index + 1) + " >>>");
					CurrentStep.MakeCurrent(Host);
				}
			}
			else
			{
				for (int num = 0; num < index; num++)
				{
					if (steps[num].ShouldRecheck && !steps[num].Check())
					{
						CurrentStep.Deactivate();
						index = num;
						CurrentStep.MakeCurrent(Host);
						return;
					}
				}
			}
			if (lastStep == CurrentStep)
			{
				stableStep += Time.unscaledDeltaTime;
				if (!stepVisualsShown && stableStep > 0.25f)
				{
					stepVisualsShown = true;
					CurrentStep.ShowVisual();
				}
			}
			else
			{
				lastStep = CurrentStep;
				stableStep = 0f;
				stepVisualsShown = false;
			}
		}

		internal void AppendStepsOfType<T>(List<T> stepList) where T : AQuickTutorialStep
		{
			foreach (AQuickTutorialStep step in steps)
			{
				if (step is T item)
				{
					stepList.Add(item);
				}
			}
		}

		internal T GetNthStepOfType<T>(int n = 0) where T : AQuickTutorialStep
		{
			foreach (AQuickTutorialStep step in steps)
			{
				if (step is T result)
				{
					n--;
					if (n < 0)
					{
						return result;
					}
				}
			}
			return null;
		}
	}
}
