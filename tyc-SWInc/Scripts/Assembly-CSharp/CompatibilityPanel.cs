using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CompatibilityPanel : MonoBehaviour
{
	public RawImage Portrait;

	public Text NameLabel;

	public Text CompLabel;

	public Image PanelBack;

	public Gradient CompGrad;

	public GUIProgressBar Friendship;

	public Image[] FriendshipFaces;

	public void SetValues(Actor emp, Actor refEmp)
	{
		float num = refEmp.employee.Compatibility(emp.employee, false);
		float num2 = refEmp.employee.Compatibility(emp.employee);
		KeyValuePair<Texture2D, Rect> keyValuePair = emp.Snapshot();
		Portrait.texture = keyValuePair.Key;
		Portrait.uvRect = keyValuePair.Value;
		NameLabel.text = emp.employee.FullName;
		if (num.Appx(num2, 0.02f))
		{
			CompLabel.text = "Compatibility".Loc() + ": " + num2.ToPercent();
		}
		else
		{
			CompLabel.text = "Compatibility".Loc() + ": " + num.ToPercent() + " → " + num2.ToPercent();
		}
		Text compLabel = CompLabel;
		compLabel.text = compLabel.text + " (" + Team.GetCompatDesc(num2) + ")";
		PanelBack.color = CompGrad.Evaluate(Mathf.Clamp01(num2 / 2.5f));
		Friendship.Value = Employee.GetFriendship(emp.employee, refEmp.employee) / 2f;
		int num3 = 0;
		if (Friendship.Value >= 1f)
		{
			num3 = 2;
		}
		else if (Friendship.Value >= 0.5f)
		{
			num3 = 1;
		}
		FriendshipFaces[0].color = ((num3 == 0) ? HUD.GetThemeColor(0) : Color.white);
		FriendshipFaces[1].color = ((num3 == 1) ? HUD.GetThemeColor(0) : Color.white);
		FriendshipFaces[2].color = ((num3 == 2) ? HUD.GetThemeColor(0) : Color.white);
	}
}
