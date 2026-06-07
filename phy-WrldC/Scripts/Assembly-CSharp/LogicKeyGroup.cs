using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicKeyGroup : MonoBehaviour
{
	private TextMeshProUGUI keyText;

	private TextMeshProUGUI labelText;

	private GameObject keyImagePanel;

	private Image keyImage;

	private void Awake()
	{
		keyText = base.transform.FindComponent<TextMeshProUGUI>("KeyText", isRecursively: true);
		labelText = base.transform.FindComponent<TextMeshProUGUI>("LabelText", isRecursively: true);
		keyImage = base.transform.FindComponent<Image>("KeyImage", isRecursively: true);
		keyImagePanel = keyImage.transform.parent.gameObject;
	}

	public void Initialize(LogicKeyData logicKeyData)
	{
		labelText.SetText(logicKeyData.keyLabel);
		if (logicKeyData.keyCode != KeyCode.None)
		{
			Sprite sprite = Util.ConvertKeyCodeToSprite(logicKeyData.keyCode);
			bool flag = sprite == null;
			keyText.gameObject.SetActive(flag);
			keyImagePanel.SetActive(!flag);
			if (flag)
			{
				keyText.SetText(Util.ConvertKeyCodeToString(logicKeyData.keyCode));
			}
			else
			{
				keyImage.sprite = sprite;
			}
		}
		else if (logicKeyData.axisCode != AxisCode.None)
		{
			Sprite sprite2 = Util.ConvertAxisCodeToSprite(logicKeyData.axisCode);
			keyText.gameObject.SetActive(value: false);
			keyImagePanel.SetActive(value: true);
			keyImage.sprite = sprite2;
		}
	}
}
