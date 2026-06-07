using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public class LeverWidget : IControlWidget, IDisposable
	{
		private readonly ControlDefinition def;

		private VisualElement root;

		private VisualElement track;

		private VisualElement handle;

		private VisualElement targetZone;

		private VisualElement cooldownOverlay;

		private VisualElement[] miniMeterFills;

		private int[] miniMeterIndices;

		private bool isDragging;

		private float dragStartY;

		private float dragStartValue;

		private float trackHeight;

		private float lastClunkValue;

		private static readonly string[] MiniMeterNames;

		private static readonly string[] MiniMeterFillClasses;

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

		public LeverWidget(ControlDefinition def, int controlIndex)
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

		public void SetMeterValues(float[] allMeterValues)
		{
		}

		private VisualElement BuildMeterDots()
		{
			return null;
		}

		private VisualElement BuildMiniMeters()
		{
			return null;
		}

		private void UpdateHandlePosition()
		{
		}

		private float FindClosestClunk(float value)
		{
			return 0f;
		}
	}
}
