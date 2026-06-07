using Localization;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LocalizedText : MonoBehaviour
{
	public string ID;

	public string colorID;

	public bool selfDestroy = true;

	private Text _text;

	private bool _inited;

	private string curFont = "";

	private bool refreshText;

	public Text Text => _text;

	private void Awake()
	{
		Init();
	}

	public void Init()
	{
		if (_inited)
		{
			return;
		}
		_text = GetComponent<Text>();
		if (_text == null)
		{
			Object.Destroy(this);
			return;
		}
		if (string.IsNullOrEmpty(ID))
		{
			ID = _text.text;
		}
		TextResources.TextsUpdated.AddListener(delegate
		{
			SetText();
		});
		_inited = true;
		if (TextResources.IsReady)
		{
			SetText();
		}
	}

	private void Start()
	{
		if (selfDestroy)
		{
			SetText();
		}
	}

	private void Update()
	{
		if (TextResources.IsReady && refreshText && base.gameObject.activeInHierarchy && Logic.GetModel() != null && Logic.GetModel().globalSaves != null)
		{
			refreshText = false;
			UpdateText();
			if (selfDestroy)
			{
				Destroy();
			}
		}
	}

	private void LateUpdate()
	{
		if (TextResources.IsReady && refreshText && base.gameObject.activeInHierarchy && Logic.GetModel() != null && Logic.GetModel().globalSaves != null)
		{
			refreshText = false;
			UpdateText();
			if (selfDestroy)
			{
				Destroy();
			}
		}
	}

	private bool SetText()
	{
		if (_text == null)
		{
			return false;
		}
		refreshText = true;
		if (TextResources.IsReady)
		{
			return TextResources.IsKeyExists(ID);
		}
		return false;
	}

	private void UpdateText()
	{
		if (colorID == "")
		{
			colorID = "INITAL";
			_text.color = new Color(1f, 1f, 1f);
		}
		if (colorID != "INITAL")
		{
			_text.text = Logic.ColorTransform(colorID, TextResources.GetString(ID).Replace("\\n", "\n"));
		}
		else
		{
			_text.text = TextResources.GetString(ID).Replace("\\n", "\n");
		}
	}

	private void Destroy()
	{
		if (_inited)
		{
			TextResources.TextsUpdated.RemoveListener(delegate
			{
				SetText();
			});
		}
		if (selfDestroy)
		{
			Object.Destroy(this);
		}
	}
}
