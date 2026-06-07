using UnityEngine;
using UnityEngine.UI;

public class SkillTreeLine : MonoBehaviour
{
	public SkillTreeIcon2 ParentIcon;

	private void Start()
	{
		SetLineVisibility();
	}

	private void Update()
	{
		SetLineVisibility();
	}

	private void SetLineVisibility()
	{
		if (GameController.GlobalInfo.LevelUpAttribute.IsEnabled)
		{
			GetComponent<Image>().enabled = true;
		}
		else
		{
			GetComponent<Image>().enabled = false;
		}
		if (ParentIcon.IsActivated())
		{
			GetComponent<Image>().color = new Color(1f, 1f, 1f);
		}
		else
		{
			GetComponent<Image>().color = new Color(0.25f, 0.25f, 0.25f);
		}
		if (!SkillTreePanel.DisplayAllNodes && !ParentIcon.IsActivated())
		{
			GetComponent<Image>().enabled = false;
		}
	}
}
