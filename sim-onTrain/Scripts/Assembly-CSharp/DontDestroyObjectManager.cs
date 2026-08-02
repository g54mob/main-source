using System.Linq;
using UnityEngine;

[DefaultExecutionOrder(-200)]
public class DontDestroyObjectManager : MonoBehaviour
{
	private void Awake()
	{
		if (Object.FindObjectsOfType<DontDestroyObjectManager>().Count() > 1)
		{
			Object.Destroy(base.gameObject);
		}
	}
}
