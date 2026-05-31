using UnityEngine;

[CreateAssetMenu(fileName = "IceCreamTopping", menuName = "DLC/Ice Cream/IceCreamTopping")]
public class IceCreamTopping : ScriptableObject
{
	[SerializeField]
	private GameObject m_Prefab;

	[SerializeField]
	private int m_Index;

	public int Index => 0;

	public GameObject CreateGraphics()
	{
		return null;
	}
}
