using UnityEngine;
using UnityEngine.UI;

public class ReaderUI : MonoBehaviour
{
	public Text entryTextLabel;

	private void Awake()
	{
		entryTextLabel.color = GlobalSettings.Constants.LOG_DEFAULT_COLOR;
	}
}
