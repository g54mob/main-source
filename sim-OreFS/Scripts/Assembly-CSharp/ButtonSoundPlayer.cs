using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonSoundPlayer : MonoBehaviour
{
	public MusicManager.ButtonSoundType buttonType;

	private Button btn;

	private void Awake()
	{
		btn = GetComponent<Button>();
	}

	private void OnEnable()
	{
		if (btn != null)
		{
			btn.onClick.AddListener(OnClick);
		}
	}

	private void OnDisable()
	{
		if (btn != null)
		{
			btn.onClick.RemoveListener(OnClick);
		}
	}

	private void OnClick()
	{
		if (!(MusicManager.Instance == null))
		{
			MusicManager.Instance.PlayButtonSound(buttonType);
		}
	}
}
