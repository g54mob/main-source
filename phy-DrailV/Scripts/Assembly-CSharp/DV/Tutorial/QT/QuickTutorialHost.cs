using System;
using UnityEngine;

namespace DV.Tutorial.QT
{
	public class QuickTutorialHost : MonoBehaviour
	{
		private static QuickTutorialHost instance;

		private QuickTutorial tutorial;

		public static bool IsTutorialRunning => instance != null;

		public static bool TutorialAllowsUserControl
		{
			get
			{
				if (!(instance == null) && instance.tutorial != null)
				{
					return instance.tutorial.IsUserControlAllowed;
				}
				return true;
			}
		}

		public static bool MetaTutorialHackActive { get; set; }

		public event Action TutorialCompleted;

		public event Action TutorialFailed;

		public static bool StartTutorial(QuickTutorial tutorial)
		{
			if (instance != null)
			{
				Debug.LogError("There's already a running instance of QuickTutorialHost");
				return false;
			}
			GameObject gameObject = new GameObject("[QuickTutorialHost]");
			instance = gameObject.AddComponent<QuickTutorialHost>();
			if (instance.InternalStartTutorial(tutorial))
			{
				return true;
			}
			UnityEngine.Object.Destroy(gameObject);
			instance = null;
			return false;
		}

		public static void AbortTutorial()
		{
			if (instance == null)
			{
				Debug.LogError("Quick tutorial wasn't running!");
				return;
			}
			instance.tutorial.Fail();
			UnityEngine.Object.Destroy(instance.gameObject);
			instance = null;
		}

		private bool InternalStartTutorial(QuickTutorial tutorial)
		{
			this.tutorial = tutorial;
			return this.tutorial.Start(this);
		}

		private void Update()
		{
			if (tutorial != null)
			{
				if (tutorial.IsDone)
				{
					Debug.Log("Quick tutorial done!");
					tutorial = null;
					this.TutorialCompleted?.Invoke();
					UnityEngine.Object.Destroy(base.gameObject);
					instance = null;
				}
				else
				{
					tutorial.Update();
				}
			}
		}

		internal void NotifyFailed(QuickTutorialPhase phase)
		{
			Debug.LogError("QUICK TUTORIAL FAILED");
			if (tutorial != null)
			{
				if (!tutorial.IsFailed)
				{
					tutorial.Fail();
				}
				tutorial = null;
				this.TutorialFailed?.Invoke();
			}
			if (this != null)
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
			instance = null;
		}

		private void OnDestroy()
		{
			if (tutorial != null)
			{
				tutorial.Fail();
				tutorial = null;
			}
		}
	}
}
