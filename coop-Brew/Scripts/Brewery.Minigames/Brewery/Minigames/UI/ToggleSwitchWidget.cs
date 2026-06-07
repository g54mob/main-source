using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public class ToggleSwitchWidget : IControlWidget, IDisposable
	{
		private readonly ControlDefinition def;

		private VisualElement root;

		private VisualElement toggleTrack;

		private VisualElement thumb;

		private VisualElement cooldownOverlay;

		private Label stateLabel;

		private bool isOn;

		private float cooldownRemaining;

		public ControlType WidgetType => default(ControlType);

		public float Value => 0f;

		public bool IsActive { get; private set; }

		public bool IsOn => false;

		public int ControlIndex { get; }

		public event Action<IControlWidget, float> OnValueChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<IControlWidget> OnActionTriggered
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public ToggleSwitchWidget(ControlDefinition def, int controlIndex)
		{
		}

		public void BuildUI(VisualElement container)
		{
		}

		public void SetActive(bool active)
		{
		}

		public void SetCooldown(float remainingSeconds, float totalSeconds)
		{
		}

		public void SetTarget(float targetMin, float targetMax)
		{
		}

		public void SetMeterValues(float[] allMeterValues)
		{
		}

		public void Tick(float deltaTime)
		{
		}

		public void OnPointerDown(PointerDownEvent evt)
		{
		}

		public void OnPointerMove(PointerMoveEvent evt)
		{
		}

		public void OnPointerUp(PointerUpEvent evt)
		{
		}

		public void SetState(bool on)
		{
		}

		public void Dispose()
		{
		}

		private VisualElement BuildMeterDots()
		{
			return null;
		}

		private void UpdateVisualState()
		{
		}
	}
}
