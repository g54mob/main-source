using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public class RotaryDialWidget : IControlWidget, IDisposable
	{
		private readonly ControlDefinition def;

		private readonly int detents;

		private VisualElement root;

		private VisualElement dialFace;

		private VisualElement indicator;

		private VisualElement cooldownOverlay;

		private Label valueLabel;

		private VisualElement[] detentMarkers;

		private bool isDragging;

		private Vector2 dialCenter;

		private float dragStartAngle;

		private float dragStartValue;

		private const float MIN_ANGLE = -135f;

		private const float MAX_ANGLE = 135f;

		public ControlType WidgetType => default(ControlType);

		public float Value { get; private set; }

		public bool IsActive { get; private set; }

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

		public RotaryDialWidget(ControlDefinition def, int controlIndex)
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

		private void UpdateIndicatorRotation()
		{
		}

		private float GetAngleFromPointer(Vector2 pointerPos)
		{
			return 0f;
		}
	}
}
