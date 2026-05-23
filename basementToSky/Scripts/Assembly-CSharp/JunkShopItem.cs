using UnityEngine;
using UnityEngine.UI;

public class JunkShopItem : MonoBehaviour
{
	public GameObject furnitureGO;

	[SerializeField]
	private Image iconImage;

	public bool isUnlocked;

	private void Start()
	{
		iconImage.sprite = furnitureGO.GetComponent<Furniture>().mainImage;
	}

	private void Update()
	{
	}
}
