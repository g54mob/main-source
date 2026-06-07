using System;
using UnityEngine.UI;

namespace VoxelBusters.CoreLibrary.NativePlugins.DemoKit
{
	public abstract class DemoActionPanelBase<TAction, TActionType> : DemoPanel where TAction : DemoActionBehaviour<TActionType> where TActionType : struct, IConvertible
	{
		private const string kLogCreateInstance = "Create instance by calling {0})";

		private ConsoleRect m_consoleRect;

		private TAction[] m_actions;

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}

		public override void Rebuild()
		{
		}

		protected virtual string GetCreateInstanceCodeSnippet()
		{
			return null;
		}

		protected TAction FindActionOfType(TActionType actionType)
		{
			return null;
		}

		protected void Log(string message, bool append = true)
		{
		}

		protected void LogMissingInstance(bool append = true)
		{
		}

		protected bool AssertPropertyIsValid(string property, string value)
		{
			return false;
		}

		protected bool AssertPropertyIsValid(string property, Func<bool> condition)
		{
			return false;
		}

		private void SetActionCallbacks()
		{
		}

		public void OnActionSelect(Selectable selectable)
		{
		}

		protected virtual void OnActionSelectInternal(TAction selectedAction)
		{
		}
	}
}
