using Localization;
using UnityEngine;
using UnityEngine.UI;

public class SetFont : ActiveComponent
{
	private string curFont = "";

	private Text _text;

	private void Start()
	{
		_text = base.gameObject.GetComponent<Text>();
		Object.Destroy(this);
	}

	private void Update()
	{
		if (TextResources.IsReady)
		{
			if (Logic.GetModel() != null && Logic.GetModel().globalSaves != null)
			{
				_text.font = Logic.GetFont("arial-unicode-ms");
			}
			Object.Destroy(this);
		}
	}
}
