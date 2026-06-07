using UnityEngine;
using UnityEngine.UI;

public class KeyboardKey : ActiveComponent
{
	public string Key = "";

	private KeyboardController keyboard;

	private void Awake()
	{
		Transform parent = base.transform;
		while (parent.GetComponent<KeyboardController>() == null)
		{
			parent = parent.parent;
			if (parent == parent.parent)
			{
				break;
			}
		}
		keyboard = parent.GetComponent<KeyboardController>();
		base.gameObject.GetComponent<Button>().onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			keyboard.input.text += Key;
		});
		base.gameObject.GetComponentInChildren<Text>().text = Key;
	}
}
