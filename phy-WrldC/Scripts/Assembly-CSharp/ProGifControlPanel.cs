using System;
using UnityEngine;
using UnityEngine.UI;

public class ProGifControlPanel : MonoBehaviour
{
	private string PP_GIFDurationKey = "ProGIF_Duration";

	private string PP_GIFFpsKey = "ProGIF_FPS";

	private string PP_GIFAspectRatioOptionKey = "ProGIF_AspectRatioOption";

	private string PP_GIFRotationOptionKey = "ProGIF_RotationOption";

	public GameObject containerGO;

	public Text text_Title;

	public Slider slider_Duration;

	public Slider slider_FPS;

	public Text text_Duration;

	public Text text_FPS;

	public Dropdown dropdown_AspectRatio;

	public Dropdown dropdown_Rotation;

	public Action _OnStartRecord;

	public Action<float> _OnRecordProgress;

	public Action _OnRecordDurationMax;

	public static ProGifControlPanel Create(GameObject prefab, Transform parentT)
	{
		ProGifControlPanel proGifControlPanel = ProGifManager.InstantiatePrefab<ProGifControlPanel>(prefab);
		if (proGifControlPanel == null)
		{
			return null;
		}
		proGifControlPanel.transform.SetParent(parentT);
		proGifControlPanel.transform.rotation = parentT.rotation;
		proGifControlPanel.transform.localScale = Vector3.one;
		proGifControlPanel.transform.localPosition = Vector3.zero;
		proGifControlPanel.GetComponent<RectTransform>().offsetMax = new Vector2(0f, 0f);
		proGifControlPanel.GetComponent<RectTransform>().offsetMin = new Vector2(0f, 0f);
		return proGifControlPanel;
	}

	public void Setup(Action onStartRecord = null, Action<float> onRecordProgress = null, Action onRecordDurationMax = null)
	{
		_OnStartRecord = onStartRecord;
		_OnRecordProgress = onRecordProgress;
		_OnRecordDurationMax = onRecordDurationMax;
		int num = PlayerPrefs.GetInt(PP_GIFDurationKey, 3);
		int num2 = PlayerPrefs.GetInt(PP_GIFFpsKey, 15);
		int value = PlayerPrefs.GetInt(PP_GIFAspectRatioOptionKey, 0);
		int value2 = PlayerPrefs.GetInt(PP_GIFRotationOptionKey, 0);
		slider_Duration.value = num;
		slider_FPS.value = num2;
		_SetDurationText(num);
		text_Title.text = "GIF Setting";
		dropdown_AspectRatio.value = value;
		dropdown_Rotation.value = value2;
		_Show();
	}

	public void OnDropdownAspectRatioChange(Dropdown dropdown)
	{
	}

	private void _SetDurationText(int duration)
	{
		text_Duration.text = "Duration: " + duration + "s";
	}

	private void _SetFpsText(int fps)
	{
		text_FPS.text = "FPS: " + fps;
	}

	public void OnSliderDurationChange(Slider slider)
	{
		_SetDurationText((int)slider.value);
	}

	public void OnSliderFpsChange(Slider slider)
	{
		_SetFpsText((int)slider.value);
	}

	public void OnButtonRecordClicked()
	{
		Close(delegate
		{
			if (dropdown_AspectRatio.value != 0)
			{
				ProGifManager.Instance.SetRecordSettings(_GetAspectRatio(dropdown_AspectRatio.value), 360, 360, slider_Duration.value, (int)slider_FPS.value, 0, 25);
			}
			else
			{
				ProGifManager.Instance.SetRecordSettings(autoAspect: true, 360, 360, slider_Duration.value, (int)slider_FPS.value, 0, 25);
			}
			ProGifManager.Instance.StartRecord(Camera.main, _OnRecordProgress, _OnRecordDurationMax);
			ProGifManager.Instance.SetGifRotation(_GetRotation(dropdown_Rotation.value));
			if (_OnStartRecord != null)
			{
				_OnStartRecord();
			}
		});
	}

	private Vector2 _GetAspectRatio(int option)
	{
		Vector2 result = Vector2.zero;
		switch (option)
		{
		case 0:
			result = Vector2.zero;
			break;
		case 1:
			result = new Vector2(9f, 16f);
			break;
		case 2:
			result = new Vector2(2f, 3f);
			break;
		case 3:
			result = new Vector2(3f, 4f);
			break;
		case 4:
			result = new Vector2(1f, 1f);
			break;
		}
		return result;
	}

	private ImageRotator.Rotation _GetRotation(int option)
	{
		ImageRotator.Rotation result = ImageRotator.Rotation.None;
		switch (option)
		{
		case 1:
			result = ImageRotator.Rotation.Left;
			break;
		case 2:
			result = ImageRotator.Rotation.Right;
			break;
		case 3:
			result = ImageRotator.Rotation.HalfCircle;
			break;
		}
		return result;
	}

	private void _Show()
	{
		base.gameObject.SetActive(value: true);
		SDemoAnimation.Instance.Scale(containerGO, Vector3.zero, Vector3.one, 0.5f);
		SDemoAnimation.Instance.Move(containerGO, new Vector3(0f, -1920f, 0f), Vector3.zero, 0.5f);
		SDemoAnimation.Instance.Rotate(containerGO, new Vector3(0f, 0f, 900f), Vector3.zero, 0.5f);
	}

	public void OnCloseButtonClicked()
	{
		Close(null);
	}

	public void Close(Action onClosed)
	{
		if (PlayerPrefs.GetInt(PP_GIFDurationKey, 0) != (int)slider_Duration.value)
		{
			PlayerPrefs.SetInt(PP_GIFDurationKey, (int)slider_Duration.value);
		}
		if (PlayerPrefs.GetInt(PP_GIFFpsKey, 0) != (int)slider_FPS.value)
		{
			PlayerPrefs.SetInt(PP_GIFFpsKey, (int)slider_FPS.value);
		}
		if (PlayerPrefs.GetInt(PP_GIFAspectRatioOptionKey, 0) != dropdown_AspectRatio.value)
		{
			PlayerPrefs.SetInt(PP_GIFAspectRatioOptionKey, dropdown_AspectRatio.value);
		}
		if (PlayerPrefs.GetInt(PP_GIFRotationOptionKey, 0) != dropdown_Rotation.value)
		{
			PlayerPrefs.SetInt(PP_GIFRotationOptionKey, dropdown_Rotation.value);
		}
		_Close(onClosed);
	}

	private void _Close(Action onClosed)
	{
		SDemoAnimation.Instance.Scale(containerGO, Vector3.one, Vector3.zero, 0.3f, SDemoAnimation.LoopType.None, delegate
		{
			if (onClosed != null)
			{
				onClosed();
			}
			UnityEngine.Object.Destroy(base.gameObject);
		});
	}
}
