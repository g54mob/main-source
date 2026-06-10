using TMPro;
using UnityEngine;

public class DemoVersionText : MonoBehaviour
{
	public TMP_Text versionText;

	private static DemoVersionText instance;

	private void Awake()
	{
		if (instance != null)
		{
			Object.Destroy(base.gameObject);
			return;
		}
		instance = this;
		Object.DontDestroyOnLoad(base.gameObject);
	}

	private void Start()
	{
		versionText.text = "V" + Application.version;
	}
}
