using System;
using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS.BBT
{
	[Serializable]
	public abstract class ContextualAction : IPerformable<Agent>
	{
		private static HashSet<Type> unauthorizedActions = new HashSet<Type>();

		[SerializeField]
		private bool _useTranslatedText;

		private bool _needToChangeLanguage = true;

		[field: SerializeField]
		[field: HideInInspector]
		public string Name { get; protected set; }

		[field: SerializeField]
		public string DisplayName { get; set; }

		[field: SerializeField]
		public bool Display { get; set; }

		[field: SerializeField]
		public LocalizedString CurrentDisplayText { get; private set; }

		public virtual bool IsWorkerAction { get; } = true;

		public static event Action<string> ContextualActionExecuting;

		public static void LockAction<T>() where T : ContextualAction
		{
			unauthorizedActions.Add(typeof(T));
		}

		public static void UnlockAction<T>() where T : ContextualAction
		{
			unauthorizedActions.Remove(typeof(T));
		}

		[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSplashScreen)]
		private static void Initialization()
		{
			unauthorizedActions.Clear();
		}

		public bool IsAuthorized()
		{
			return !unauthorizedActions.Contains(GetType());
		}

		protected ContextualAction()
		{
			Name = GetType().Name.Remove(0, 16);
		}

		private void LanguageChanged(Locale obj)
		{
			_needToChangeLanguage = true;
		}

		~ContextualAction()
		{
			LocalizationSettings.SelectedLocaleChanged -= LanguageChanged;
		}

		public virtual string GetDisplayName()
		{
			if (_useTranslatedText && _needToChangeLanguage)
			{
				LocalizationSettings.SelectedLocaleChanged += LanguageChanged;
				DisplayName = CurrentDisplayText.GetLocalizedString();
				_needToChangeLanguage = false;
			}
			if (DisplayName == "")
			{
				return Name;
			}
			return DisplayName;
		}

		public abstract void Setup();

		public abstract void SetActor(IContextActor p_actor);

		public virtual bool CanBeExecutedWithoutWorker()
		{
			return true;
		}

		public abstract bool CanBePerformed(Worker p_worker);

		public virtual bool ShowAlways()
		{
			return Display;
		}

		protected abstract void Execution(Worker p_worker);

		public void Execute(Worker p_worker)
		{
			if (CanBePerformed(p_worker))
			{
				ContextualAction.ContextualActionExecuting?.Invoke(GetDisplayName());
				Execution(p_worker);
				Setup();
			}
		}

		public bool CanBePerformedBy(Agent obj)
		{
			if (!(obj is Worker p_worker))
			{
				return false;
			}
			return CanBePerformed(p_worker);
		}
	}
	public abstract class ContextualAction<T> : ContextualAction where T : class, IContextActor
	{
		protected T contextActor;

		public override void SetActor(IContextActor p_actor)
		{
			contextActor = p_actor as T;
		}
	}
}
