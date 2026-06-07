using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NightPreviewElement : MonoBehaviour
{
	public TFUIEnemy enemyTFUIPrefab;

	public TextMeshProUGUI number;

	public List<TFUIEnemy> enemyTFUIs = new List<TFUIEnemy>();

	public void SetData(WaveInfo info)
	{
		foreach (TFUIEnemy enemyTFUI in enemyTFUIs)
		{
			enemyTFUI.gameObject.SetActive(value: false);
		}
		int num = info.enemies.Count - enemyTFUIs.Count;
		for (int i = 0; i < num; i++)
		{
			enemyTFUIs.Add(Object.Instantiate(enemyTFUIPrefab, base.transform));
		}
		info.enemies = info.enemies.OrderBy((WaveEnemyInfo o) => o.enemyCount).ToList();
		for (int num2 = 0; num2 < info.enemies.Count; num2++)
		{
			enemyTFUIs[num2].gameObject.SetActive(value: true);
			enemyTFUIs[num2].SetDataSimple(info.enemies[num2]);
		}
		number.text = info.waveNumber + ".";
		Canvas.ForceUpdateCanvases();
		GetComponent<HorizontalLayoutGroup>().SetLayoutHorizontal();
	}

	private void OnEnable()
	{
		Canvas.ForceUpdateCanvases();
		GetComponent<HorizontalLayoutGroup>().SetLayoutHorizontal();
	}
}
