using UnityEngine;

namespace NSMedieval.Repository
{
	public class Global : MonoBehaviour
	{
		private static Global Instance { get; set; }

		private void Awake()
		{
			if (Instance == null)
			{
				Instance = this;
				Object.DontDestroyOnLoad(base.gameObject);
			}
			else if (Instance != this)
			{
				Object.DestroyImmediate(base.gameObject);
			}
		}
	}
}
