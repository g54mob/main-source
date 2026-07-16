using UnityEngine;

public class EmpLauncher : MonoBehaviour
{
	[SerializeField]
	private E2_1EMPLauncher parentClass;

	public void Launch()
	{
		parentClass.Shoot();
	}
}
