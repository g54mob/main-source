using UnityEngine;

public class SkillTooltipManager : MonoBehaviour
{
	public SkillTooltip tooltip;

	public static SkillTooltipManager Instance { get; private set; }

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Instance = this;
		}
	}

	private void Start()
	{
		if (tooltip != null)
		{
			tooltip.Hide();
		}
	}

	public void ShowTooltip(Skill skillData, Transform position)
	{
		if (tooltip != null && skillData != null)
		{
			tooltip.SetData(skillData);
			tooltip.Show(position);
		}
	}

	public void HideTooltip()
	{
		if (tooltip != null)
		{
			tooltip.Hide();
		}
	}

	public void ShakeTooltip()
	{
		if (tooltip != null && tooltip.gameObject.activeSelf)
		{
			tooltip.Shake();
		}
	}
}
