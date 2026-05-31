using System.Collections;
using CTS;
using NaughtyAttributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_CreditsExcelText : MonoBehaviour
{
	[Foldout("Devs")]
	[SerializeField]
	private TMP_Text _textCredits;

	[Foldout("Devs")]
	[SerializeField]
	private CreditsDatabase _creditDataBase;

	[Foldout("Devs")]
	[SerializeField]
	private UI_ScrollCredit _scriptScroll;

	[Foldout("Devs")]
	[SerializeField]
	private GameObject _viewPort;

	[Foldout("Devs")]
	[SerializeField]
	private GameObject _prefabTeamGroup;

	[SerializeField]
	private VerticalLayoutGroup _verticalLayoutGroup;

	[Foldout("Devs")]
	[SerializeField]
	private GameObject _prefabPartenairesGroup;

	[Foldout("Devs")]
	[SerializeField]
	private UI_Credit_SOIconsTeam _iconTeams;

	[Foldout("Devs")]
	[SerializeField]
	private UI_Credit_SOPartenairesLogo _partenaireData;

	private CreditReadSheetManager _creditReadSheetManager;

	private GameObject _panelCredits;

	private bool _needTodisableThePanelCredits;

	private void Awake()
	{
		_creditReadSheetManager = GetComponent<CreditReadSheetManager>();
		if (_scriptScroll == null)
		{
			_scriptScroll = GetComponent<UI_ScrollCredit>();
		}
		if (_creditDataBase == null)
		{
			string path = _creditReadSheetManager.GiveRef();
			_creditDataBase = Resources.Load<CreditsDatabase>(path);
		}
		if (_textCredits.text != null)
		{
			_textCredits.text = null;
		}
	}

	public void GetCreditData(string currentPath, string name, string asset)
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	private void OnOffMask()
	{
		Mask component = _viewPort.GetComponent<Mask>();
		if (component.MaskEnabled())
		{
			component.enabled = false;
		}
		else
		{
			component.enabled = true;
		}
	}

	[Button("Update Text without import", EButtonEnableMode.Editor)]
	public void UpdateText()
	{
	}

	private IEnumerator Waitin()
	{
		yield return new WaitForSecondsRealtime(0.25f);
		if (_needTodisableThePanelCredits)
		{
			yield return new WaitForSecondsRealtime(1f);
			_panelCredits.SetActive(value: false);
		}
	}

	private void TextModification()
	{
		GameObject gameObject = _textCredits.gameObject;
		for (int i = 0; i < _creditDataBase._listHierarchy.Count; i++)
		{
			DataHierarchy dataHierarchy = _creditDataBase._listHierarchy[i];
			UI_Credit_WriteTeamGroup component = Object.Instantiate(_prefabTeamGroup, gameObject.transform).GetComponent<UI_Credit_WriteTeamGroup>();
			component.TeamText.text = dataHierarchy.HierarchyTeam.ToString();
			component.ImageJob.sprite = _iconTeams.IconTeams[i];
			foreach (DataHierarchy.DataHierarchyWorker item in dataHierarchy._CurrentWorker)
			{
				UI_Credit_JobAndWorker component2 = Object.Instantiate(component.PrefabNewWorker, component.ParentJobAndWorker.transform).GetComponent<UI_Credit_JobAndWorker>();
				component2.NameText.text = item.name;
				if (item.job != null)
				{
					if (item.job != "None")
					{
						component2.JobText.text = item.job;
					}
					else
					{
						component2.JobText.gameObject.SetActive(value: false);
						component2.NameText.alignment = TextAlignmentOptions.Center;
						component2.GetComponent<HorizontalLayoutGroup>().padding.left = 0;
					}
				}
				if (item.isSubtitle)
				{
					component2.NameText.text = component2.NameText.text.ToUpper();
					component2.NameText.fontStyle = FontStyles.Bold;
				}
			}
		}
		foreach (CreditDataPartenaineStruct dataPartenaire in _partenaireData.DataPartenaires)
		{
			UI_Credit_Partenairesgroup component3 = Object.Instantiate(_prefabPartenairesGroup, gameObject.transform).GetComponent<UI_Credit_Partenairesgroup>();
			UI_Credit_ImagePartenairesGroup component4 = component3.ParentImage.GetComponent<UI_Credit_ImagePartenairesGroup>();
			foreach (Sprite item2 in dataPartenaire.LogoPartenaire)
			{
				Image component5 = Object.Instantiate(component4.PrefabImage, component3.ParentImage.transform).GetComponent<Image>();
				component5.sprite = item2;
				component5.SetNativeSize();
				component5.rectTransform.sizeDelta /= 2f;
			}
			component3.PartenaireText.text = dataPartenaire.TextPartenaire;
			if (dataPartenaire.NeedColor)
			{
				string text = ColorUtility.ToHtmlStringRGB(dataPartenaire.Color);
				string text2 = "<color=#" + text + ">" + dataPartenaire.NameToColorWhite + "</color>";
				component3.PartenaireText.text += text2;
			}
		}
	}
}
