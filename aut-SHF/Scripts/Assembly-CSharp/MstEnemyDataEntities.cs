using System;

[Serializable]
public class MstEnemyDataEntities
{
	public eEnemy id;

	public int sortNum;

	public string name;

	public string desc;

	public string collectionDesc;

	public string flavorText;

	public float radius;

	public int exp;

	public eEnemyType enemyType;

	public bool isHidden;

	public string iconPath;

	public string largeImagePath;
}
