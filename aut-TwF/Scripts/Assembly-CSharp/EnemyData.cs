using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

[CreateAssetMenu(fileName = "EnemyData_default", menuName = "Tower Factory/EnemyData")]
public class EnemyData : ScriptableObject, ISavable
{
	[SerializeField]
	[Savable("id", true, false)]
	private string id;

	[SerializeField]
	private Enemy enemyPrefab;

	[SerializeField]
	private LocalizedString enemyName;

	[SerializeField]
	private Sprite enemyIcon;

	[SerializeField]
	private bool boss;

	public string Id => id;

	public Enemy EnemyPrefab => enemyPrefab;

	public Sprite EnemyIcon => enemyIcon;

	public bool Boss => boss;

	public string EnemyName
	{
		get
		{
			if (enemyName != null && !enemyName.IsEmpty)
			{
				return enemyName.GetLocalizedString();
			}
			return "-";
		}
	}

	public void OnSave()
	{
	}

	public void OnPreLoad()
	{
	}

	public void OnLoad(Dictionary<string, object> data, bool hasLoadedSomething)
	{
	}
}
