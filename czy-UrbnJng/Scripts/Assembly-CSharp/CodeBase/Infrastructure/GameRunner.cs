using Infrastructure;
using UnityEngine;

namespace CodeBase.Infrastructure
{
	public class GameRunner : MonoBehaviour
	{
		public GameBootstrapper BootstrapperPrefab;

		private void Awake()
		{
			if (!(Object.FindObjectOfType<GameBootstrapper>() != null))
			{
				Object.Instantiate(BootstrapperPrefab);
			}
		}
	}
}
