using UnityEngine;

public class TiePointHighlight : MonoBehaviour
{
	public QuickOutline outline;

	private static TiePointHighlight inst;

	public GameObject[] meshObj;

	private int counter;

	private void Awake()
	{
	}

	public static void Hide()
	{
	}

	public static void SetPoint(Vector3 pos)
	{
	}

	private void OnRenderObject()
	{
	}
}
