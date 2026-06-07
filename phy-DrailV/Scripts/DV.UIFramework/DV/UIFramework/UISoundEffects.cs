using UnityEngine;
using UnityEngine.UI;

namespace DV.UIFramework
{
	[DisallowMultipleComponent]
	public class UISoundEffects : MonoBehaviour
	{
		private const float DEBOUNCE_THRESHOLD = 1f / 30f;

		private AudioClip hoverSound;

		private AudioClip clickSound;

		private IHoverable hoverable;

		private IClickable clickable;

		private static float lastPlayTime = -1f;

		private void Start()
		{
			UIEffectsReferences componentInParent = GetComponentInParent<UIEffectsReferences>();
			if (!componentInParent)
			{
				Debug.LogWarning("'" + base.name + "' won't play hover/click sounds, couldn't find UIEffectsReferences in hierarchy", base.gameObject);
				Object.Destroy(this);
				return;
			}
			hoverable = GetComponent<IHoverable>();
			clickable = GetComponent<IClickable>();
			hoverSound = componentInParent.hoverSound;
			clickSound = componentInParent.clickSound;
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			SetupListeners(on: false);
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				if (hoverable != null)
				{
					hoverable.HoverChanged += OnHoverChanged;
				}
				if (clickable != null)
				{
					clickable.Clicked += OnClicked;
				}
				if (ShouldPlaySliderSound(hoverable, out var slider))
				{
					slider.onValueChanged.AddListener(OnSliderChanged);
				}
			}
			else
			{
				if (hoverable != null)
				{
					hoverable.HoverChanged -= OnHoverChanged;
				}
				if (clickable != null)
				{
					clickable.Clicked -= OnClicked;
				}
				if (ShouldPlaySliderSound(hoverable, out var slider2))
				{
					slider2.onValueChanged.RemoveListener(OnSliderChanged);
				}
			}
		}

		private bool ShouldPlaySliderSound(IHoverable hoverable, out Slider slider)
		{
			if (hoverable is SliderDV sliderDV && (sliderDV.useStepping || sliderDV.wholeNumbers))
			{
				slider = sliderDV;
				return true;
			}
			if (hoverable is Slider slider2 && slider2.wholeNumbers)
			{
				slider = slider2;
				return true;
			}
			slider = null;
			return false;
		}

		private void OnHoverChanged(IHoverable sender)
		{
			if (sender.IsHovered && Application.isFocused)
			{
				Play(hoverSound);
			}
		}

		private void OnClicked(IClickable sender)
		{
			Play(clickSound);
		}

		private void OnSliderChanged(float _)
		{
			Play(clickSound);
		}

		public static void Play(AudioClip clip)
		{
			if (!(Time.realtimeSinceStartup - lastPlayTime < 1f / 30f) && (bool)clip)
			{
				lastPlayTime = Time.realtimeSinceStartup;
				clip.Play2D(1f, playDuringPause: true);
			}
		}
	}
}
