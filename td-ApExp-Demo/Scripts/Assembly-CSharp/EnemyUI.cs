using UnityEngine;

public class EnemyUI : MonoBehaviour
{
	public BarController healthBar;

	public Status sunder;

	public Status weaken;

	public Status armor;

	public void HideUI(bool hide)
	{
		sunder.HideIcon(hide);
		weaken.HideIcon(hide);
		armor.HideIcon(hide);
		if (hide || (!hide && UIManager.Instance.EnemyHealthbarsDisplay.isEnabled))
		{
			healthBar.HideBar(hide);
		}
	}
}
