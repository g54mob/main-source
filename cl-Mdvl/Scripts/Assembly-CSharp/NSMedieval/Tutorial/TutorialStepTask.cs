using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Tools;

namespace NSMedieval.Tutorial
{
	public sealed class TutorialStepTask
	{
		private readonly string name;

		private object[] args;

		private float percentComplete;

		private readonly Func<object[]> argsFunc;

		private bool isActive;

		public bool IsComplete => percentComplete >= 1f;

		public bool IsActive => isActive;

		public event Action<float> PercentCompleteChangeEvent;

		public event Action TaskCompleteEvent;

		public event Action TaskSetActiveChangeEvent;

		public TutorialStepTask(string name)
		{
			this.name = name;
			percentComplete = 0f;
		}

		public TutorialStepTask(string name, object[] args)
		{
			this.args = args;
			this.name = name;
			percentComplete = 0f;
		}

		public TutorialStepTask(string name, Func<object[]> argsFunc)
		{
			this.name = name;
			this.argsFunc = argsFunc;
			percentComplete = 0f;
		}

		public void UpdateCompletion(float completionPercentage)
		{
			percentComplete = completionPercentage;
			this.PercentCompleteChangeEvent?.Invoke(percentComplete);
			if (percentComplete >= 1f)
			{
				this.TaskCompleteEvent?.Invoke();
			}
		}

		public void SetActive(bool active)
		{
			if (active != isActive)
			{
				isActive = active;
				this.TaskSetActiveChangeEvent?.Invoke();
			}
		}

		public string GetName()
		{
			string text = TextFormatting.FormatKeyInputEvent(MonoSingleton<LocalizationController>.Instance.GetText(name));
			if (argsFunc != null)
			{
				args = argsFunc();
			}
			if (args == null || args.Length == 0)
			{
				return text;
			}
			return string.Format(text, args);
		}
	}
}
