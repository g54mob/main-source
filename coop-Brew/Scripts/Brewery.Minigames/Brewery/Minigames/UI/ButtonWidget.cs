using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public class ButtonWidget : IControlWidget, IDisposable
	{
		private readonly ControlDefinition def;

		private VisualElement root;

		private VisualElement buttonFace;

		private VisualElement readyGlow;

		private VisualElement lockoutOverlay;

		private Label lockoutTimer;

		private float lockoutRemaining;

		private float lockoutTotal;

		private float pressAnimTime;

		private const float PRESS_ANIM_DURATION = 0.15f;

		private const float PRESS_DEPTH = 4f;

		public ControlType WidgetType => default(ControlType);

		public float Value => 0f;

		public bool IsActive { get; private set; }

		public bool IsLockedOut { get; private set; }

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

		public ButtonWidget(ControlDefinition def, int controlIndex)
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

		public void Dispose()
		{
		}

		private VisualElement BuildMeterDots()
		{
			return null;
		}
	}
}
