using System.Collections.Generic;
using DV.Utils;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class QuickTutorial
	{
		private List<QuickTutorialPhase> phases = new List<QuickTutorialPhase>();

		private int index;

		private List<AQuickTutorialCondition> startingChecks = new List<AQuickTutorialCondition>();

		private List<AQuickTutorialCondition> globalChecks = new List<AQuickTutorialCondition>();

		private List<ATutorialService> services = new List<ATutorialService>();

		public bool IsUserControlAllowed { get; private set; }

		public bool IsDone { get; private set; }

		public bool IsStarted { get; private set; }

		public bool IsFailed { get; private set; }

		public bool IsAborted { get; private set; }

		public QuickTutorialHost Host { get; private set; }

		public QuickTutorialPhase CurrentPhase
		{
			get
			{
				if (index < 0 || index >= phases.Count)
				{
					return null;
				}
				return phases[index];
			}
		}

		public AQuickTutorialStep CurrentStep => CurrentPhase?.CurrentStep;

		public QuickTutorial(bool userControlAllowed)
		{
			IsUserControlAllowed = userControlAllowed;
		}

		public void Add(QuickTutorialPhase phase)
		{
			phases.Add(phase);
		}

		public void Add(ATutorialService service)
		{
			services.Add(service);
		}

		public void AddStartingCheck(AQuickTutorialCondition condition)
		{
			startingChecks.Add(condition);
		}

		public void AddGlobalCheck(AQuickTutorialCondition condition)
		{
			globalChecks.Add(condition);
		}

		public bool Start(QuickTutorialHost host)
		{
			Debug.Log("<<< Starting tutorial with " + phases.Count + " phase(s) >>>");
			Host = host;
			IsStarted = true;
			IsFailed = false;
			IsAborted = false;
			foreach (AQuickTutorialCondition startingCheck in startingChecks)
			{
				startingCheck.Start();
				string text = startingCheck.Check();
				startingCheck.Deactivate();
				if (!string.IsNullOrEmpty(text))
				{
					IsFailed = true;
					Debug.LogError("Couldn't start tutorial because: " + text);
					SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt(text, pause: false, delegate
					{
						IsDone = true;
						host.NotifyFailed(null);
					});
					return false;
				}
			}
			foreach (ATutorialService service in services)
			{
				service.StartService(host, null);
			}
			foreach (AQuickTutorialCondition globalCheck in globalChecks)
			{
				globalCheck.Start();
			}
			index = 0;
			CurrentPhase.Start(host);
			if (CurrentPhase.IsDone)
			{
				OnPhaseDone();
			}
			return true;
		}

		private void OnPhaseDone()
		{
			if (IsDone)
			{
				return;
			}
			index++;
			if (index >= phases.Count)
			{
				IsDone = true;
				foreach (ATutorialService service in services)
				{
					service.StopService(fullyCompleted: true);
				}
				{
					foreach (AQuickTutorialCondition globalCheck in globalChecks)
					{
						globalCheck.Deactivate();
					}
					return;
				}
			}
			CurrentPhase.Start(Host);
		}

		public void Update()
		{
			if (IsFailed || IsDone)
			{
				return;
			}
			foreach (ATutorialService service in services)
			{
				service.UpdateService();
			}
			foreach (AQuickTutorialCondition globalCheck in globalChecks)
			{
				string text = globalCheck.Check();
				if (!string.IsNullOrEmpty(text))
				{
					Fail();
					Debug.LogError("Tutorial failed because: " + text);
					SingletonBehaviour<TutorialHelper>.Instance.ShowPrompt(text, pause: false, delegate
					{
						IsDone = true;
						Host.NotifyFailed(null);
					});
					return;
				}
			}
			if (CurrentPhase == null)
			{
				OnPhaseDone();
				return;
			}
			CurrentPhase.Update();
			if (CurrentPhase.IsDone)
			{
				OnPhaseDone();
			}
		}

		public void Fail()
		{
			if (CurrentPhase != null && !CurrentPhase.IsFailed)
			{
				CurrentPhase.Fail();
			}
			foreach (ATutorialService service in services)
			{
				service.StopService(fullyCompleted: false);
			}
			foreach (AQuickTutorialCondition globalCheck in globalChecks)
			{
				globalCheck.Deactivate();
			}
			IsFailed = true;
		}

		public T[] GetStepsOfType<T>() where T : AQuickTutorialStep
		{
			List<T> list = new List<T>();
			foreach (QuickTutorialPhase phase in phases)
			{
				phase.AppendStepsOfType(list);
			}
			return list.ToArray();
		}
	}
}
