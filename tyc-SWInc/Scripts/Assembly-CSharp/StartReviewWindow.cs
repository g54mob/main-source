using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class StartReviewWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Text MainLabel;

	public Text MoneyLabel;

	public Slider MainSlider;

	public Toggle SubsidiaryToggle;

	public Toggle OutsourceToggle;

	public Toggle ClientToggle;

	public Transform ArtPanel;

	public Transform CodePanel;

	public GameObject ArtLabel;

	public GameObject CodeLabel;

	public Toggle TogglePrefab;

	[NonSerialized]
	private Dictionary<KeyValuePair<string, string>, Toggle> _activeToggles = new Dictionary<KeyValuePair<string, string>, Toggle>();

	[NonSerialized]
	private List<Toggle> _togglePool = new List<Toggle>();

	[NonSerialized]
	private SoftwareAlpha _target;

	private Toggle GetToggle(string label)
	{
		Toggle toggle = null;
		if (_togglePool.Count > 0)
		{
			toggle = _togglePool.Pop();
			toggle.gameObject.SetActive(true);
		}
		else
		{
			toggle = UnityEngine.Object.Instantiate(TogglePrefab);
			toggle.onValueChanged.AddListener(delegate
			{
				RefreshLabels();
			});
		}
		toggle.GetComponentInChildren<Text>().text = label;
		toggle.isOn = true;
		return toggle;
	}

	public void Show(SoftwareAlpha target)
	{
		_target = target;
		HashSet<KeyValuePair<string, string>> hashSet = new HashSet<KeyValuePair<string, string>>();
		foreach (KeyValuePair<KeyValuePair<string, string>, Toggle> activeToggle in _activeToggles)
		{
			activeToggle.Value.gameObject.SetActive(false);
			_togglePool.Add(activeToggle.Value);
		}
		_activeToggles.Clear();
		CodeLabel.SetActive(false);
		ArtLabel.SetActive(false);
		for (int i = 0; i < target.Features.Length; i++)
		{
			FeatureBase feature = target.Features[i].Feature;
			if (feature.CodeArtRatio > 0f)
			{
				hashSet.Add(new KeyValuePair<string, string>("Code", feature.Spec));
				CodeLabel.SetActive(true);
			}
			if (feature.CodeArtRatio < 1f)
			{
				hashSet.Add(new KeyValuePair<string, string>("Art", feature.Spec));
				ArtLabel.SetActive(true);
			}
		}
		foreach (KeyValuePair<string, string> item in hashSet)
		{
			Toggle toggle = GetToggle(item.Value.LocTry());
			toggle.transform.SetParent(item.Key.Equals("Code") ? CodePanel : ArtPanel, false);
			_activeToggles[item] = toggle;
		}
		MainLabel.text = "ReviewOf".Loc(target.SoftwareName);
		SubsidiaryToggle.interactable = GameSettings.Instance.MyCompany.Subsidiaries.Count > 0;
		ClientToggle.interactable = target.contract != null || target.ActiveDeal != null;
		if (ClientToggle.interactable)
		{
			ClientToggle.isOn = true;
			SubsidiaryToggle.isOn = false;
			OutsourceToggle.isOn = false;
		}
		else if (SubsidiaryToggle.interactable)
		{
			SubsidiaryToggle.isOn = true;
			OutsourceToggle.isOn = false;
			ClientToggle.isOn = false;
		}
		else
		{
			OutsourceToggle.isOn = true;
			ClientToggle.isOn = false;
			SubsidiaryToggle.isOn = false;
		}
		MainSlider.value = 10f;
		Window.Show();
		RefreshLabels();
	}

	private HashSet<KeyValuePair<string, string>> GetSpecs()
	{
		return (from x in _activeToggles
			where x.Value.isOn
			select x.Key).ToHashSet();
	}

	public void RefreshLabels()
	{
		HashSet<KeyValuePair<string, string>> specs = GetSpecs();
		int num = ReviewWork.GetReviewsPerReviewer(_target, specs) * GetReviewers(specs);
		float num2 = (OutsourceToggle.isOn ? ReviewWork.StandardCost : 0f);
		MoneyLabel.text = string.Format("{0}: {1} x {2} = {3}", "Cost".Loc(), num, num2.Currency(), ((float)num * num2).Currency());
	}

	private int GetReviewers(HashSet<KeyValuePair<string, string>> specs)
	{
		return Mathf.RoundToInt((float)ReviewWork.GetOptimalReviews(_target, specs) / 10f * MainSlider.value);
	}

	public void Finish()
	{
		if (_target.Done)
		{
			Window.Close();
			return;
		}
		HashSet<KeyValuePair<string, string>> specs = GetSpecs();
		if (specs.Count <= 0)
		{
			return;
		}
		if (SubsidiaryToggle.isOn)
		{
			List<SimulatedCompany> subs = GameSettings.Instance.MyCompany.GetSubsidiaries().OfType<SimulatedCompany>().ToList();
			WindowManager.Instance.MultiWindow.Show("Review", subs.Select((SimulatedCompany x) => x.Name), delegate(int x)
			{
				ReviewWork item3 = new ReviewWork(_target, subs[x], GetReviewers(specs), specs);
				GameSettings.Instance.MyCompany.AddWorkItem(item3);
			}, false);
		}
		else if (ClientToggle.isOn)
		{
			ReviewWork item = new ReviewWork(_target, (_target.ActiveDeal != null) ? _target.ActiveDeal.CompanyName : _target.contract.Company, true, GetReviewers(specs), specs);
			GameSettings.Instance.MyCompany.AddWorkItem(item);
		}
		else
		{
			ReviewWork item2 = new ReviewWork(_target, MarketSimulation.Active.RNG["ContractCompany"].GenerateName(Utilities.RNG), false, GetReviewers(specs), specs);
			GameSettings.Instance.MyCompany.AddWorkItem(item2);
		}
		Window.Close();
	}
}
