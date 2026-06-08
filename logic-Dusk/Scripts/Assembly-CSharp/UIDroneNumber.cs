using UnityEngine;
using UnityEngine.UI;

public class UIDroneNumber : MonoBehaviour
{
	public Image borderImage;

	public Text droneNumberLabel;

	private void OnDestroy()
	{
		borderImage = null;
		droneNumberLabel = null;
	}
}
