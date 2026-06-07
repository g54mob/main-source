using UnityEngine;

public class WorldVisualizer : MonoBehaviour
{
	[field: SerializeField]
	public WorldType Type { get; private set; }

	public void Activate()
	{
		base.gameObject.SetActive(value: true);
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
	}
}
