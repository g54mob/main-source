using System;
using UnityEngine.UIElements;

namespace Brewery.Minigames.UI
{
	public interface IControlWidget : IDisposable
	{
		ControlType WidgetType { get; }

		float Value { get; }

		bool IsActive { get; }

		event Action<IControlWidget, float> OnValueChanged;

		event Action<IControlWidget> OnActionTriggered;

		void BuildUI(VisualElement container);

		void SetActive(bool active);

		void SetCooldown(float remainingSeconds, float totalSeconds);

		void Tick(float deltaTime);

		void SetTarget(float targetMin, float targetMax);

		void SetMeterValues(float[] allMeterValues);

		void OnPointerDown(PointerDownEvent evt);

		void OnPointerMove(PointerMoveEvent evt);

		void OnPointerUp(PointerUpEvent evt);
	}
}
