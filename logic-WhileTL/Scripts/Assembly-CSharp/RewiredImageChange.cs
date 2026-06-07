using UnityEngine;
using UnityEngine.UI;

public class RewiredImageChange : MonoBehaviour
{
	public bool anyControllerCheck = true;

	public Sprite PCSprite;

	public Sprite ControllerSprite;

	public Sprite PSSprite;

	public Sprite XboxSprite;

	private Image selfImg;

	private bool inited;

	private string lastTag = "";

	private void Awake()
	{
		if (Logic.IsSteamDeckRunning())
		{
			Object.DestroyImmediate(this);
			return;
		}
		PlatformDependendSelfDestroy component = base.gameObject.GetComponent<PlatformDependendSelfDestroy>();
		if (component != null)
		{
			Object.DestroyImmediate(component);
		}
		selfImg = GetComponent<Image>();
		if (selfImg == null)
		{
			Object.DestroyImmediate(this);
		}
		else if (Logic.GetModel() != null)
		{
			inited = true;
			Logic.GetModel().InputDeviceChanged.AddListener(CheckImage);
			CheckImage(Logic.GetModel().CurInputDevice);
		}
	}

	private void OnDestroy()
	{
		if (Logic.GetModel() != null && Logic.GetModel().InputDeviceChanged != null)
		{
			Logic.GetModel().InputDeviceChanged.RemoveListener(CheckImage);
		}
	}

	private void CheckImage(string deviceTag)
	{
		bool flag = deviceTag == "PC";
		lastTag = deviceTag;
		if (anyControllerCheck)
		{
			selfImg.sprite = (flag ? PCSprite : ControllerSprite);
			return;
		}
		switch (deviceTag)
		{
		case "PC":
			selfImg.sprite = PCSprite;
			break;
		case "XBOX":
			selfImg.sprite = XboxSprite;
			break;
		case "PS":
			selfImg.sprite = PSSprite;
			break;
		default:
			selfImg.sprite = ControllerSprite;
			break;
		}
	}

	private void Update()
	{
		if (!inited && Logic.GetModel() != null)
		{
			inited = true;
			Logic.GetModel().InputDeviceChanged.AddListener(CheckImage);
			CheckImage(Logic.GetModel().CurInputDevice);
		}
		if (Logic.GetModel() != null && Logic.GetModel().CurInputDevice != lastTag)
		{
			CheckImage(Logic.GetModel().CurInputDevice);
		}
	}
}
