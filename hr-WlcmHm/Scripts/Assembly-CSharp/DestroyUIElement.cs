using UnityEngine;

public class DestroyUIElement : MonoBehaviour
{
	public void DestroyUI()
	{
		Object.Destroy(base.gameObject);
	}
}
