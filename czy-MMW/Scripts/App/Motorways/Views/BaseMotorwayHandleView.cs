using Client;
using Factory;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class BaseMotorwayHandleView : MonoBehaviour
	{
		private IScope _parentScope;

		private LocalizedTextUI _motorwayNumberLocText;

		private ThemedComponent _textThemeComponent;

		public virtual void Initialize(IScope parentScope, int motorwayNumber)
		{
			_parentScope = parentScope;
			_motorwayNumberLocText = GetComponentInChildren<LocalizedTextUI>();
			_textThemeComponent = _motorwayNumberLocText?.GetComponent<ThemedComponent>();
			if (Diagnostics.Verify(_motorwayNumberLocText != null, "No LocalizedTextUI in the UnbuiltMotorwayHandleView") && Diagnostics.Verify(_textThemeComponent != null, "No ThemedComponent on the  LocalizedTextUI in the UnbuiltMotorwayHandleView"))
			{
				_motorwayNumberLocText.HandleParentAllocated(parentScope);
				_motorwayNumberLocText.LocString = StandaloneLocString.CreateLocalizedNumberString(parentScope, motorwayNumber);
			}
		}

		public virtual TickResult Tick(TimeInterval tickTime, float stepAlpha)
		{
			return TickResult.StopTicking;
		}

		public virtual void ApplyTheme(ITheme newTheme)
		{
			_textThemeComponent.ApplyTheme(newTheme);
		}

		public virtual void InitializeTheme(IThemeDatabase themeDatabase)
		{
			_textThemeComponent.InitializeTheme(themeDatabase);
		}

		public virtual void ReleaseTheme(IThemeDatabase themeDatabase)
		{
			_textThemeComponent.ReleaseTheme(themeDatabase);
		}
	}
}
