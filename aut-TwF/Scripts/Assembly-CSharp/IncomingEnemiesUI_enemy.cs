using UnityEngine;
using UnityEngine.UI;

public class IncomingEnemiesUI_enemy : MonoBehaviour
{
	[SerializeField]
	private Image enemyImage;

	[SerializeField]
	private Image backgroundImage;

	[SerializeField]
	private Color defaultBackgroundColor;

	[SerializeField]
	private Color bossBackgroundColor;

	private EnemyData enemyData;

	private int cycle;

	public EnemyData EnemyData => enemyData;

	public int Cycle => cycle;

	public void SetEnemy(EnemyData enemyData, int cycle)
	{
		this.cycle = cycle;
		this.enemyData = enemyData;
		enemyImage.sprite = enemyData.EnemyIcon;
		backgroundImage.color = (enemyData.Boss ? bossBackgroundColor : defaultBackgroundColor);
	}
}
