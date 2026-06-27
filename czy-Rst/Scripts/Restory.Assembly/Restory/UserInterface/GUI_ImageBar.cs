using Restory.UserInterface.GameplayMenu;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Restory.UserInterface
{
	public class GUI_ImageBar : MonoBehaviour, IProgressBar
	{
		public readonly UnityEvent OnStart = new UnityEvent();

		public readonly UnityEvent OnComplete = new UnityEvent();

		public readonly UnityEvent OnCanceled = new UnityEvent();

		public Image targetImage;

		[SerializeField]
		private float value = 1f;

		[SerializeField]
		private UnityEvent onBarUpdated = new UnityEvent();

		private float baseValue = 1f;

		private bool isReversed;

		private float timeSinceStart;

		public UnityEvent OnValueChanged => onBarUpdated;

		public float Value
		{
			get
			{
				return value;
			}
			private set
			{
				if (this.value != value)
				{
					this.value = value;
					onBarUpdated?.Invoke();
				}
			}
		}

		private void SetImageValue(float currentValue, float maxValue, bool isReversed)
		{
			targetImage.fillAmount = (isReversed ? (currentValue / maxValue) : ((maxValue - currentValue) / maxValue));
		}

		public void SetBaseValue(float baseValue_in, float currentValue, bool isReversed_in)
		{
			isReversed = isReversed_in;
			baseValue = baseValue_in;
			Value = currentValue;
			SetImageValue(value, baseValue, isReversed);
		}

		public void SetValue(float value_in)
		{
			Value = value_in;
			SetImageValue(value, baseValue, isReversed);
		}

		public void Tick(float deltaTime)
		{
			if (base.gameObject.activeSelf)
			{
				timeSinceStart += deltaTime;
				targetImage.enabled = timeSinceStart >= 0.2f;
				SetValue(value + Time.unscaledDeltaTime);
				if (value >= baseValue)
				{
					OnComplete.Invoke();
					Clean();
				}
			}
		}

		public void StartCountdown(Transform placeToTick)
		{
			base.gameObject.SetActive(value: true);
			base.transform.position = placeToTick.position;
			OnStart?.Invoke();
		}

		public void BreakCountdown()
		{
			Clean();
			OnCanceled?.Invoke();
		}

		public void Clean()
		{
			base.gameObject.SetActive(value: false);
			timeSinceStart = 0f;
			OnStart.RemoveAllListeners();
			OnCanceled.RemoveAllListeners();
			OnComplete.RemoveAllListeners();
		}
	}
}
