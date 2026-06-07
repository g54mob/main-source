using System;
using System.Linq;
using UnityEngine;

public class CompanyWindow : MonoBehaviour
{
	public GUIWindow Window;

	public GUIListView CompanyList;

	public GameObject CompanyDetailWindow;

	[NonSerialized]
	private bool _isBound;

	public CompanyDetailWindow GetCompanyDetailWindow(Company company)
	{
		return WindowManager.FindWindowType<CompanyDetailWindow>().FirstOrDefault((CompanyDetailWindow x) => x.company == company);
	}

	public CompanyDetailWindow ToggleCompanyDetails(Company company)
	{
		CompanyDetailWindow companyDetailWindow = WindowManager.FindWindowType<CompanyDetailWindow>().FirstOrDefault((CompanyDetailWindow x) => x.company == company);
		if (companyDetailWindow != null)
		{
			companyDetailWindow.window.Toggle();
			return companyDetailWindow;
		}
		GameObject obj = UnityEngine.Object.Instantiate(CompanyDetailWindow);
		obj.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
		CompanyDetailWindow component = obj.GetComponent<CompanyDetailWindow>();
		component.company = company;
		return component;
	}

	public GUIWindow ShowCompanyDetails(Company company)
	{
		if (company.Bankrupt)
		{
			WindowManager.Instance.ShowMessageBox("Bankrupt".Loc(), false, DialogWindow.DialogType.Error);
			return null;
		}
		CompanyDetailWindow companyDetailWindow = WindowManager.FindWindowType<CompanyDetailWindow>().FirstOrDefault((CompanyDetailWindow x) => x.company == company);
		if (companyDetailWindow != null)
		{
			WindowManager.Focus(companyDetailWindow.window);
			return companyDetailWindow.window;
		}
		GameObject obj = UnityEngine.Object.Instantiate(CompanyDetailWindow);
		obj.transform.SetParent(WindowManager.Instance.Canvas.transform, false);
		CompanyDetailWindow component = obj.GetComponent<CompanyDetailWindow>();
		component.company = company;
		return component.window;
	}

	public void FocusCompany(Company company)
	{
		Bind();
		if (CompanyList.Items.IndexOf(company) >= 0)
		{
			int num = CompanyList.ActualItems.IndexOf(company);
			if (num < 0)
			{
				for (int i = 0; i < CompanyList.GUIColumns.Count; i++)
				{
					GUIColumn gUIColumn = CompanyList.GUIColumns[i];
					if (gUIColumn.FilterActive)
					{
						gUIColumn.ToggleFilter();
					}
				}
				num = CompanyList.ActualItems.IndexOf(company);
			}
			if (num >= 0)
			{
				CompanyList.Select(num);
				CompanyList.KeepIdxInView(num);
				Window.Show();
			}
		}
		else
		{
			WindowManager.Instance.ShowMessageBox("CompanyMissingWarning".Loc(), false, DialogWindow.DialogType.Error);
		}
	}

	private void Start()
	{
		Bind();
		CompanyList["CompanyPlayer"].ToggleActive(false, GameSettings.Instance.IsNetworkMode);
		CompanyList.OnDoubleClick = delegate
		{
			Company firstSelected = CompanyList.GetFirstSelected<Company>();
			if (firstSelected != null && !firstSelected.Bankrupt)
			{
				HUD.Instance.companyWindow.ShowCompanyDetails(firstSelected);
			}
		};
	}

	public void Bind()
	{
		if (!_isBound)
		{
			_isBound = true;
			CompanyList.Items = GameSettings.Instance.simulation.GetAllCompanies().Cast<object>().ToList();
			GameSettings.Instance.simulation.BindCompanyUpdate(CompanyList.Items);
		}
	}
}
