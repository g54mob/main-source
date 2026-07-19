using UnityEngine;

public class BlockComponent : MonoBehaviour
{
	public Block data = new Block();

	private void Start()
	{
		if (data.hidden)
		{
			base.gameObject.layer = 10;
		}
	}
}
