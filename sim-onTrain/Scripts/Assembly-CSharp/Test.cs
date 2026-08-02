using Mirror;
using UnityEngine;

public class Test : NetworkBehaviour
{
	private void Update()
	{
		Debug.DrawLine(base.transform.position, base.transform.position + base.transform.forward * 5f, Color.red);
	}

	public override bool Weaved()
	{
		return true;
	}
}
