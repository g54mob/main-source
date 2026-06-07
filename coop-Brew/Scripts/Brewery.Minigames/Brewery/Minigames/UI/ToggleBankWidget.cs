using System;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public class ToggleBankWidget : IControlWidget, IDisposable
	{
		private readonly ControlDefinition def;

		private VisualElement root;

		private VisualElement bankContainer;

		private VisualElement[] fuseElements;

		private VisualElement[] fuseIndicators;

		private VisualElement targetDisplay;

		private VisualElement[] targetIndicators;

		private VisualElement cooldownOverlay;

		private bool[] pattern;

		private bool[] targetPattern;

		public ControlType WidgetType => default(ControlType);

		public float Value => 0f;

		public bool IsActive { get; private set; }

		public int ControlIndex { get; }

		public bool IsPatternCorrect { get; private set; }

		public bool[] Pattern => null;

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

		public event Action<int> OnFuseToggled
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

		public ToggleBankWidget(ControlDefinition def, int controlIndex)
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

		public void SetTargetPattern(bool[] target)
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

		public void SetPattern(bool[] newPattern)
		{
		}

		public void Dispose()
		{
		}

		private VisualElement BuildMeterDots()
		{
			return null;
		}

		private void UpdateFuseVisual(int index)
		{
		}

		private void UpdateTargetDisplay()
		{
		}

		private void CheckPattern()
		{
		}
	}
}
