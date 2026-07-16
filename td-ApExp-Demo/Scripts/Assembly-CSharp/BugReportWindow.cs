using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class BugReportWindow : Menu
{
	public GameObject FormHolder;

	public TMP_InputField InputField;

	private static string FormUrl = "https://docs.google.com/forms/u/0/d/e/1FAIpQLSfaV583BV7ydJZk0zOjhdRIISeMzQyzK7ZKLBHWzzzUmxD-rg/formResponse";

	public void Submit()
	{
		StartCoroutine(Post(InputField.text));
	}

	private IEnumerator Post(string s1)
	{
		WWWForm wWWForm = new WWWForm();
		wWWForm.AddField("entry.1705799554", s1);
		UnityWebRequest unityWebRequest = UnityWebRequest.Post(FormUrl, wWWForm);
		yield return unityWebRequest.SendWebRequest();
	}
}
