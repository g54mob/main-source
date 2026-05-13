using UnityEngine;

public class Gallery : MonoBehaviour
{
	[SerializeField]
	private PlayerManager playerManager;

	private void Start()
	{
		playerManager.ArrangePlayer();
	}

	private void Update()
	{
	}
}
