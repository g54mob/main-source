using UnityEngine;

public class AmbientComponent : MonoBehaviour
{
	public int rating;

	[SerializeField]
	private bool registerOnStart;

	private void Start()
	{
		if (GetComponent<ItemComponent>().GetInfo() != null)
		{
			rating = GetComponent<ItemComponent>().GetInfo().ambientRating;
			if (registerOnStart)
			{
				CafeShopManager.RegisterAmbientObject(this);
			}
		}
	}

	public void OnPlace()
	{
		CafeShopManager.RegisterAmbientObject(this);
	}

	public void OnRemove()
	{
		CafeShopManager.UnregisterAmbientObject(this);
	}
}
