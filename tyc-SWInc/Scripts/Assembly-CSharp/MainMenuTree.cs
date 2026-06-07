using UnityEngine;

public class MainMenuTree : MonoBehaviour
{
	public static Color TargetCol1;

	public static Color TargetCol2;

	private void Start()
	{
		TargetCol1 = Color.white;
		TargetCol2 = Color.white;
	}

	private void Update()
	{
		GetComponent<Renderer>().material.SetColor("_Color1", Color.Lerp(GetComponent<Renderer>().material.GetColor("_Color1"), TargetCol1, 4f * Time.deltaTime));
		GetComponent<Renderer>().material.SetColor("_Color2", Color.Lerp(GetComponent<Renderer>().material.GetColor("_Color2"), TargetCol2, 4f * Time.deltaTime));
	}
}
