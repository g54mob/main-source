using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Michsky.UI.ModernUIPack
{
	public class SwitchManager : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler
	{
		public UnityEvent OnEvents;

		public UnityEvent OffEvents;

		public bool saveValue = true;

		public string switchTag = "Switch";

		public bool isOn = true;

		public bool invokeAtStart = true;

		public bool enableSwitchSounds;

		public bool useHoverSound = true;

		public bool useClickSound = true;

		public Animator switchAnimator;

		public Button switchButton;

		public AudioSource soundSource;

		public AudioClip hoverSound;

		public AudioClip clickSound;

		private void Start()
		{
			try
			{
				if (switchAnimator == null)
				{
					switchAnimator = base.gameObject.GetComponent<Animator>();
				}
				if (switchButton == null)
				{
					switchButton = base.gameObject.GetComponent<Button>();
					switchButton.onClick.AddListener(AnimateSwitch);
					if (enableSwitchSounds && useClickSound)
					{
						switchButton.onClick.AddListener(delegate
						{
							soundSource.PlayOneShot(clickSound);
						});
					}
				}
			}
			catch
			{
				Debug.LogError("Switch - Cannot initalize the switch due to missing variables.", this);
			}
			if (saveValue)
			{
				if (PlayerPrefs.GetString(switchTag + "Switch") == "")
				{
					if (isOn)
					{
						switchAnimator.Play("Switch On");
						isOn = true;
						PlayerPrefs.SetString(switchTag + "Switch", "true");
					}
					else
					{
						switchAnimator.Play("Switch Off");
						isOn = false;
						PlayerPrefs.SetString(switchTag + "Switch", "false");
					}
				}
				else if (PlayerPrefs.GetString(switchTag + "Switch") == "true")
				{
					switchAnimator.Play("Switch On");
					isOn = true;
				}
				else if (PlayerPrefs.GetString(switchTag + "Switch") == "false")
				{
					switchAnimator.Play("Switch Off");
					isOn = false;
				}
			}
			else if (isOn)
			{
				switchAnimator.Play("Switch On");
				isOn = true;
			}
			else
			{
				switchAnimator.Play("Switch Off");
				isOn = false;
			}
			if (invokeAtStart && isOn)
			{
				OnEvents.Invoke();
			}
			else if (invokeAtStart && !isOn)
			{
				OffEvents.Invoke();
			}
		}

		private void OnEnable()
		{
			if (switchAnimator == null)
			{
				switchAnimator = base.gameObject.GetComponent<Animator>();
			}
			if (saveValue)
			{
				if (PlayerPrefs.GetString(switchTag + "Switch") == "")
				{
					if (isOn)
					{
						switchAnimator.Play("Switch On");
						isOn = true;
						PlayerPrefs.SetString(switchTag + "Switch", "true");
					}
					else
					{
						switchAnimator.Play("Switch Off");
						isOn = false;
						PlayerPrefs.SetString(switchTag + "Switch", "false");
					}
				}
				else if (PlayerPrefs.GetString(switchTag + "Switch") == "true")
				{
					switchAnimator.Play("Switch On");
					isOn = true;
				}
				else if (PlayerPrefs.GetString(switchTag + "Switch") == "false")
				{
					switchAnimator.Play("Switch Off");
					isOn = false;
				}
			}
			else if (isOn)
			{
				switchAnimator.Play("Switch On");
				isOn = true;
			}
			else
			{
				switchAnimator.Play("Switch Off");
				isOn = false;
			}
		}

		public void AnimateSwitch()
		{
			if (isOn)
			{
				switchAnimator.Play("Switch Off");
				isOn = false;
				OffEvents.Invoke();
				if (saveValue)
				{
					PlayerPrefs.SetString(switchTag + "Switch", "false");
				}
			}
			else
			{
				switchAnimator.Play("Switch On");
				isOn = true;
				OnEvents.Invoke();
				if (saveValue)
				{
					PlayerPrefs.SetString(switchTag + "Switch", "true");
				}
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			if (enableSwitchSounds && useHoverSound && switchButton.interactable)
			{
				soundSource.PlayOneShot(hoverSound);
			}
		}

		private void _003CStart_003Eb__14_0()
		{
			soundSource.PlayOneShot(clickSound);
		}
	}
}
