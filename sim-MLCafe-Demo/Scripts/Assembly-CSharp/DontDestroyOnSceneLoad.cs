using System.Linq;
using UnityEngine;

public class DontDestroyOnSceneLoad : MonoBehaviour
{
	[SerializeField]
	private new string tag;

	private void Awake()
	{
		if (Object.FindObjectsByType<DontDestroyOnSceneLoad>(FindObjectsSortMode.InstanceID).ToList().Exists((DontDestroyOnSceneLoad x) => x.tag == tag && x != this))
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Object.DontDestroyOnLoad(base.gameObject);
		}
	}
}
