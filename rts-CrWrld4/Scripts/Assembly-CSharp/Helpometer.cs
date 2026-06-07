using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Helpometer : MonoBehaviour
{
	public Transform pageContainer;

	public TextMeshProUGUI titleText;

	public ScrollRect scrollRect;

	private Dictionary<string, GameObject> pages;

	public GameObject[] unitButtons;

	public GameObject[] sectionHeaders;

	private string shownPage;

	public void ShowPage(string page)
	{
	}

	private IEnumerator ForceScrollUp()
	{
		return null;
	}

	public void Awake()
	{
	}

	public void OnEnable()
	{
	}

	public void OnDisable()
	{
	}
}
