using UnityEngine;

public class GridBehaviour : MonoBehaviour
{
	public Grid Grid;

	private void Start()
	{
		Grid.Initialize();
	}

	private void Update()
	{
	}

	private void OnDrawGizmos()
	{
		Grid.Draw();
	}
}
