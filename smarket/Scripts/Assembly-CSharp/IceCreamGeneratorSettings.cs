using UnityEngine;

[CreateAssetMenu(menuName = "DLC/Ice Cream/Generator Settings")]
public class IceCreamGeneratorSettings : ScriptableObject
{
	[SerializeField]
	private int m_MaxScoopCount;

	[SerializeField]
	[Range(0f, 1f)]
	private float m_ToppingChance;

	[SerializeField]
	[Range(0f, 1f)]
	private float m_RequestChance;

	public int MaxScoopCount => 0;

	public float ToppingChance => 0f;

	public float RequestChance => 0f;
}
