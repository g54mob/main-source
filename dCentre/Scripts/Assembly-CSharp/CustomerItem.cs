using UnityEngine;

[CreateAssetMenu(fileName = "CustomerItem", menuName = "Scriptable Objects/CustomerItem")]
public class CustomerItem : ScriptableObject
{
	public int customerID;

	public string customerName;

	public Sprite logo;

	public int[] appTypes;

	public int difficulty;

	public int reputation;
}
