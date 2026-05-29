using UnityEngine;

public class wfplavn : MonoBehaviour
{
	public pl pl;

	private void Start()
	{
		pl.plavn = 10f;
		Object.Destroy(base.gameObject);
	}
}
