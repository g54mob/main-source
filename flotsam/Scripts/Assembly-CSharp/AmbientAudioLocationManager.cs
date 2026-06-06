using UnityEngine;

public class AmbientAudioLocationManager : MonoBehaviour
{
	[Tooltip("The height to position this player at.")]
	[SerializeField]
	private float _soundHeight;

	private void Update()
	{
		if (UIManager.State != UIState.Map)
		{
			Vector3 position = Camera.main.transform.position;
			base.transform.position = new Vector3(position.x, _soundHeight, position.z);
		}
	}
}
