using UnityEngine;

[CreateAssetMenu(menuName = "SATM/RandomEvent")]
public class RandomEvent : ScriptableObject
{
	public string id;

	public int eventIndex;

	public bool oneTimeEvent;

	public int onlyOccurAfterThisDay = -1;

	public int onlyOccurBeforeThisDay = 999999;
}
