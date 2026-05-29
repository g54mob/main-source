using UnityEngine;
using UnityEngine.UI;

public class OfflineProgressSplashScreen : MonoBehaviour
{
	public GameObject screen;

	public Text offlineProgressText;

	public Text patchText;

	public Text subTitle;

	public Scrollbar patchScrollar;

	public Scrollbar offlineProgressScrollbar;

	public string message;

	private void Start()
	{
		message = "";
		patchScrollar.value = 1f;
		offlineProgressScrollbar.value = 1f;
	}

	public void closeScreen()
	{
		screen.transform.localPosition = new Vector3(-2000f, -2000f);
		screen.GetComponent<CanvasRenderer>().SetAlpha(0f);
		offlineProgressText.text = "";
		patchText.text = "";
	}

	public void openScreen()
	{
		screen.transform.localPosition = new Vector3(0f, 0f);
		screen.GetComponent<CanvasRenderer>().SetAlpha(1f);
		offlineProgressText.text = message;
		TextAsset textAsset = Resources.Load("PatchNotes") as TextAsset;
		patchText.text = textAsset.text;
		TextAsset textAsset2 = Resources.Load("SplashSubtitle") as TextAsset;
		char[] separator = new char[1] { '\n' };
		string[] array = textAsset2.text.Split(separator);
		int num = Random.Range(0, array.Length);
		patchScrollar.value = 1f;
		offlineProgressScrollbar.value = 1f;
		subTitle.text = array[num];
	}

	public void displayProgress()
	{
		offlineProgressText.text = message;
		offlineProgressScrollbar.value = 1f;
	}

	public void addMessage(string text)
	{
		message += text;
	}
}
