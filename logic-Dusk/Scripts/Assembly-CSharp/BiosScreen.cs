using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BiosScreen : MonoBehaviour
{
	public MenuPanelUI menuPanel;

	public Image logo;

	public Image sigil;

	public Text bootSequenceLabel;

	public Text bodyLabel;

	public Color UnselectedText = Color.white;

	public Color SelectedText = Color.black;

	public BootScreen bootScreen;

	public List<UIMenuItem> rowItems;

	private int selectedIndex;

	private bool showingSigil;

	private float timerSigil;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public void Initialize()
	{
		rowItems[selectedIndex].backgroundImage.enabled = false;
		rowItems[selectedIndex].label.color = UnselectedText;
		selectedIndex = 0;
		rowItems[selectedIndex].backgroundImage.enabled = true;
		rowItems[selectedIndex].label.color = SelectedText;
	}

	private void OnDestroy()
	{
		if (logo != null)
		{
			logo.sprite = null;
			logo = null;
		}
		bootSequenceLabel = null;
		bodyLabel = null;
	}

	public void Update()
	{
		if (!showingSigil)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				PostScreen();
			}
			else if (Input.GetButtonDown("Down"))
			{
				rowItems[selectedIndex].backgroundImage.enabled = false;
				rowItems[selectedIndex].label.color = UnselectedText;
				selectedIndex++;
				if (selectedIndex >= rowItems.Count)
				{
					selectedIndex = 0;
				}
				rowItems[selectedIndex].backgroundImage.enabled = true;
				rowItems[selectedIndex].label.color = SelectedText;
			}
			else if (Input.GetButtonDown("Up"))
			{
				rowItems[selectedIndex].backgroundImage.enabled = false;
				rowItems[selectedIndex].label.color = UnselectedText;
				selectedIndex--;
				if (selectedIndex < 0)
				{
					selectedIndex = rowItems.Count - 1;
				}
				rowItems[selectedIndex].backgroundImage.enabled = true;
				rowItems[selectedIndex].label.color = SelectedText;
			}
			else if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
			{
				switch (selectedIndex)
				{
				case 0:
					Application.OpenURL("http://www.avirusnamedtom.com/");
					break;
				case 1:
					Application.OpenURL("https://youtu.be/WC8YKZgaehA?list=PLWHgLfDKHMzy_jZFDOu7nz1ZpeVoic8Mz");
					break;
				case 2:
					logo.enabled = false;
					sigil.enabled = true;
					showingSigil = true;
					timerSigil = 0.05f;
					Application.OpenURL("http://misfitsattic.com/0-)$(_]]@!!+@=");
					break;
				case 3:
					Application.OpenURL("http://www.misfits-attic.com");
					break;
				}
			}
		}
		else
		{
			timerSigil -= Time.deltaTime;
			if (timerSigil <= 0f)
			{
				logo.enabled = true;
				sigil.enabled = false;
				showingSigil = false;
			}
		}
	}

	private void PostScreen()
	{
		base.gameObject.SetActive(false);
		bootScreen.gameObject.SetActive(true);
		bootScreen.Initialize();
	}
}
