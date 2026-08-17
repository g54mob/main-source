using TMPro;
using UnityEngine;

namespace Assets.Scripts.UI.DynamicWindows;

public class DWindow : DWindowBase
{
	public TextMeshProUGUI t_header;

	public TextMeshProUGUI t_content;

	public TextMeshProUGUI t_button;

	public void Set(string header, string content, string buttonText = "Okey")
	{
		t_header.text = header;
		t_content.text = content;
		t_button.text = buttonText;
		base.rebuildAfterFrames = 3;
	}

	public void Close()
	{
		GameObject obj = base.gameObject;
		Object.Destroy(obj);
	}

	public DWindow()
	{
		//IL_000f: Expected I4, but got I8
		base.rebuildAfterFrames = -1;
		((MonoBehaviour)this)._002Ector();
	}
}
