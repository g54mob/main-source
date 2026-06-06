using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public class ValveWheelWidget : IControlWidget, IDisposable
	{
		private readonly ControlDefinition def;

		private VisualElement root;

		private VisualElement valveBody;

		private VisualElement wheelFace;

		private VisualElement spoke;

		private VisualElement spokeCross;

		private VisualElement progressRing;

		private VisualElement cooldownOverlay;

		private Label percentLabel;

		private bool isDragging;

		private Vector2 wheelCenter;

		private float lastAngle;

		private float totalRotation;

		public ControlType WidgetType => default(ControlType);

		public float Value { get; private set; }

		public bool IsActive { get; private set; }

		public int ControlIndex { get; }

		public float CumulativeTurns { get; private set; }

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

		public ValveWheelWidget(ControlDefinition def, int controlIndex)
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

		private void UpdateVisuals()
		{
		}

		private float GetAngle(Vector2 pointerPos)
		{
			return 0f;
		}
	}
}
