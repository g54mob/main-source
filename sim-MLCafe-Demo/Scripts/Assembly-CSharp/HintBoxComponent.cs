using UnityEngine;

public class HintBoxComponent : MonoBehaviour
{
	public void CloseHintBox()
	{
		PopupMessageManager.GetPopHint().Hide();
	}
}
