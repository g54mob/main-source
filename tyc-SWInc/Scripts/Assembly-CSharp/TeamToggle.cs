using System;
using System.Collections.Generic;
using System.Text;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class TeamToggle : MonoBehaviour
{
	[NonSerialized]
	public SimulatedCompany Company;

	[NonSerialized]
	public NetworkPlayer Player;

	[NonSerialized]
	public Employee Compat;

	public RawImage PlayerThumb;

	public string Team;

	public Text MainLabel;

	public Text DetailLabel;

	public Toggle MainToggle;

	public Image Background;

	public Image Toggle;

	public Color DefaultColor;

	public GameObject Secondary;

	public GameObject Limit;

	public Team GetTeam()
	{
		if (Team == null)
		{
			return null;
		}
		return GameSettings.GetTeam(Team);
	}

	public bool Match(string search)
	{
		if (search != null)
		{
			if (Company != null)
			{
				if (Company.Name != null)
				{
					return Company.Name.ToLower().Contains(search);
				}
				return false;
			}
			if (Player != null)
			{
				if (Player.Name != null)
				{
					return Player.Name.ToLower().Contains(search);
				}
				return false;
			}
			if (Team != null)
			{
				return Team.ToLower().Contains(search);
			}
		}
		return false;
	}

	public void Init(string taskType)
	{
		bool flag = false;
		PlayerThumb.gameObject.SetActive(false);
		if (Player != null)
		{
			MainLabel.text = Player.Name;
			Text detailLabel = DetailLabel;
			Company playerCompany = Player.GetPlayerCompany();
			detailLabel.text = ((playerCompany != null) ? playerCompany.Name : null) ?? "";
			DetailLabel.color = Color.gray;
			Background.color = Color.white;
			Text mainLabel = MainLabel;
			Color color = (Toggle.color = DefaultColor);
			mainLabel.color = color;
			Secondary.SetActive(false);
			Limit.SetActive(false);
			Texture2D tex;
			if (Player.TryGetAvatar(out tex) && tex != null)
			{
				PlayerThumb.gameObject.SetActive(true);
				PlayerThumb.texture = tex;
			}
			return;
		}
		if (Company != null)
		{
			MainLabel.text = Company.Name;
			DetailLabel.text = "Subsidiary".Loc() + "\n" + Company.Money.Currency();
			DetailLabel.color = Color.gray;
			Background.color = Color.white;
			Text mainLabel2 = MainLabel;
			Color color = (Toggle.color = DefaultColor);
			mainLabel2.color = color;
			Secondary.SetActive(false);
			Limit.SetActive(false);
			PlayerThumb.gameObject.SetActive(true);
			PlayerThumb.texture = LogoController.Instance.LogoTexture;
			PlayerThumb.uvRect = LogoController.Instance.GetLogoRect(Company);
			return;
		}
		Team team = GameSettings.GetTeam(Team);
		MainLabel.text = team.Name;
		Background.color = team.TeamColor;
		Secondary.SetActive(taskType != null && team.SecondaryTasks.Contains(taskType));
		Limit.SetActive(team.MaxTasks > 0 && team.WorkItems.Count >= team.MaxTasks);
		flag = team.TeamColor.grayscale < 0.5f;
		if (flag)
		{
			Text detailLabel2 = DetailLabel;
			Text mainLabel3 = MainLabel;
			Color color2 = (Toggle.color = Color.white);
			Color color = (mainLabel3.color = color2);
			detailLabel2.color = color;
		}
		else
		{
			Text detailLabel3 = DetailLabel;
			Text mainLabel4 = MainLabel;
			Color color2 = (Toggle.color = DefaultColor);
			Color color = (mainLabel4.color = color2);
			detailLabel3.color = color;
		}
		Actor[] employees = team.GetEmployees();
		float num = 0f;
		float[] array = new float[4];
		StringBuilder stringBuilder = new StringBuilder();
		if (Compat != null && employees.Length != 0)
		{
			float minCompatibility = team.GetMinCompatibility(Compat);
			Color compatibilityColor = HireWindow.GetCompatibilityColor(minCompatibility, new Color[3]
			{
				HUD.GetPosNeg(false),
				new Color32(50, 50, 50, byte.MaxValue),
				HUD.GetPosNeg(true)
			});
			stringBuilder.AppendLine("<color=#" + ColorUtility.ToHtmlStringRGB(compatibilityColor) + ">Compatibility</color> " + minCompatibility.ToPercent());
		}
		List<string> list = new List<string>
		{
			"Employees".Loc(),
			"Tasks".Loc(),
			"Programmers".Loc(),
			"Designers".Loc(),
			"Artists".Loc(),
			"Service".Loc()
		};
		List<string> list2 = new List<string>
		{
			employees.Length.ToString(),
			team.WorkItems.Count.ToString(),
			employees.Count((Actor x) => x.employee.IsRole(Employee.RoleBit.Programmer)).ToString(),
			employees.Count((Actor x) => x.employee.IsRole(Employee.RoleBit.Designer)).ToString(),
			employees.Count((Actor x) => x.employee.IsRole(Employee.RoleBit.Artist)).ToString(),
			employees.Count((Actor x) => x.employee.IsRole(Employee.RoleBit.Service)).ToString()
		};
		for (int num2 = 1; num2 < 5; num2++)
		{
			Employee.EmployeeRole r = (Employee.EmployeeRole)num2;
			float num3 = (array[num2 - 1] = employees.SumSafe((Actor x) => x.employee.GetSkill(r)));
			if (num3 > num)
			{
				num = num3;
			}
		}
		if (num > 0f)
		{
			for (int num4 = 1; num4 < 5; num4++)
			{
				if (array[num4 - 1] / num > 0.8f)
				{
					list[num4 + 1] = (flag ? ("<color=#AAFFAAFF>" + list[num4 + 1] + "</color>") : ("<color=#11AA11FF>" + list[num4 + 1] + "</color>"));
				}
			}
		}
		for (int num5 = 0; num5 < list.Count; num5++)
		{
			if (num5 % 2 == 1)
			{
				stringBuilder.AppendLine("\t" + list[num5] + " " + list2[num5]);
			}
			else
			{
				stringBuilder.Append(list[num5] + " " + list2[num5]);
			}
		}
		DetailLabel.text = stringBuilder.ToString().TrimEnd();
	}
}
