using UnityEngine;

public class WishlistButton : MonoBehaviour
{
	public void Wishlist()
	{
		Application.OpenURL("steam://openurl/https://store.steampowered.com/app/2239150/Thronefall/");
	}
}
