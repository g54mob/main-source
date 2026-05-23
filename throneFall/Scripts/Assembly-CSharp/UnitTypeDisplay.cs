using MPUIKIT;
using UnityEngine;

public class UnitTypeDisplay : MonoBehaviour
{
	public GameObject displayParent;

	public bool ranged;

	public MPImageBasic icon;

	public Hp hp;

	private CommandUnits commandingUnits;

	private Color originalColor;

	public void SetSelected(bool _selected)
	{
		if (_selected)
		{
			icon.color = Color.white;
		}
		else
		{
			icon.color = originalColor;
		}
	}

	private void Start()
	{
		commandingUnits = CommandUnits.instance;
		if (ranged)
		{
			originalColor = ColorAndLightManager.currentColorscheme.allyRangedIndicatorColor;
		}
		else
		{
			originalColor = ColorAndLightManager.currentColorscheme.allyMeleeIndicatorColor;
		}
		icon.color = originalColor;
	}

	private void Update()
	{
		if (!hp.Alive)
		{
			if (displayParent.activeSelf)
			{
				displayParent.SetActive(value: false);
			}
		}
		else if (displayParent.activeSelf != commandingUnits.ShouldShowUnitTypes)
		{
			displayParent.SetActive(commandingUnits.ShouldShowUnitTypes);
		}
	}
}
