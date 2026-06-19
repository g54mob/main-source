using UnityEngine;

public class ClickGeneratorExtraOutput : MonoBehaviour
{
	[SerializeField]
	private ClickGenerator _clickGenerator;

	[SerializeField]
	private ItemType _itemType;

	[SerializeField]
	private float _chance;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public void OnFinalHit()
	{
	}

	public void AddChance(float chance)
	{
	}
}
