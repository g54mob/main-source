using UnityEngine;

public class TestString : MonoBehaviour
{
	public string s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa";

	private string c = "a";

	public int delta = 200000;

	private void Start()
	{
	}

	private void Update()
	{
		Debug.Log(Time.realtimeSinceStartup);
		Debug.Log(Time.deltaTime);
		for (int i = 1; i <= delta; i++)
		{
			string text = ((char)(97 + Random.Range(0, 25))).ToString() ?? "";
			s.Replace(c + c, text + text);
			c = text;
		}
	}
}
