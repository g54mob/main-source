using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class broker_search : Website
{
	[SerializeField]
	protected TMP_InputField searchInput;

	[SerializeField]
	protected Button searchButton;

	[SerializeField]
	protected GameObject noResults;

	[SerializeField]
	protected GameObject searchResult;

	[SerializeField]
	private TextMeshProUGUI bio;

	[SerializeField]
	private TextMeshProUGUI firm;

	[SerializeField]
	private GameObject website;

	[SerializeField]
	private Website launcher;

	[SerializeField]
	private GameObject cursorChanger;

	private static string lastSearch;

	protected override void Start()
	{
		base.Start();
		GetComponent<PlayerInput>().actions["Enter"].performed += delegate
		{
			if (searchInput.isFocused && searchInput.text.Length > 0)
			{
				Search();
			}
		};
		if (lastSearch != null)
		{
			Search(lastSearch);
		}
	}

	public void Search(string searchFirm)
	{
		bool flag = false;
		if (LevelManager.GetCurrLevel() != 8)
		{
			noResults.SetActive(!flag);
			searchResult.SetActive(flag);
			return;
		}
		PlaySearch();
		lastSearch = searchFirm;
		Trader result = Level8.GetTrader(searchFirm);
		flag = result != null;
		noResults.SetActive(!flag);
		searchResult.SetActive(flag);
		if (!flag)
		{
			return;
		}
		bio.text = result.bio;
		firm.text = result.firmName;
		bool flag2 = result.website.Length != 0;
		TextMeshProUGUI component = website.GetComponent<TextMeshProUGUI>();
		Button component2 = website.GetComponent<Button>();
		component2.interactable = flag2;
		if (!flag2)
		{
			component.text = "<i>None provided</i>";
			cursorChanger.SetActive(value: false);
			return;
		}
		cursorChanger.SetActive(value: true);
		component.text = result.website;
		component2.onClick.AddListener(delegate
		{
			launcher.LaunchInnerSite(result.website);
		});
	}

	public void Search()
	{
		Search(searchInput.text);
	}

	public void CheckEnableSubmit()
	{
		searchButton.interactable = searchInput.text.Length > 0;
	}
}
