using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class SwapSprite : MonoBehaviour
{
	[SerializeField]
	private SaveData.FarmType farmType;

	[SerializeField]
	private Sprite sprite;

	private void Start()
	{
		if (farmType == SaveData.ins.farmType)
		{
			GetComponent<SpriteRenderer>().sprite = sprite;
		}
	}
}
