using MPUIKIT;
using TMPro;
using UnityEngine;

public class EnemyScreenMarkerUIHelper : MonoBehaviour
{
	public GameObject defaultMarkerParent;

	public MPImageBasic defaultRegularBackground;

	public MPImageBasic defaultEliteBackground;

	public MPImageBasic enemyIcon;

	public TextMeshProUGUI enemyNumber;

	public void SetElite(bool isElite)
	{
		if (defaultRegularBackground == null)
		{
			return;
		}
		defaultRegularBackground.enabled = !isElite;
		if (!(defaultEliteBackground == null))
		{
			defaultEliteBackground.enabled = isElite;
			if (!(enemyIcon == null) && isElite)
			{
				enemyIcon.color = Color.yellow;
			}
		}
	}
}
