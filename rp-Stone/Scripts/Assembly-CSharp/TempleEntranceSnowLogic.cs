using UnityEngine;

public class TempleEntranceSnowLogic : MonoBehaviour
{
	private bool foregroundEnabled = true;

	private Decoration myDeco;

	private void Update()
	{
		if (foregroundEnabled && myDeco.PositionX - GameStates.Singleton.hero.PositionX <= 0)
		{
			foregroundEnabled = false;
			FullScreenSnow component = GameObject.Find("SnowLayer").GetComponent<FullScreenSnow>();
			if (component != null)
			{
				component.simulating = false;
			}
		}
	}

	private void Awake()
	{
		myDeco = GetComponent<Decoration>();
	}
}
