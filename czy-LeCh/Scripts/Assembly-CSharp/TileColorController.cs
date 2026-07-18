using UnityEngine;

public class TileColorController : MonoBehaviour
{
	private void Start()
	{
		GetComponent<Renderer>().material = BackgroundController.Instance.GetTileMaterial();
	}
}
