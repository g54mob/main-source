using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Name/List Generator")]
public class ListNameGenerator : NameGenerator
{
	[SerializeField]
	private NameList _nameList;

	public override string ReturnName()
	{
		return _nameList.ReturnRandomName();
	}
}
