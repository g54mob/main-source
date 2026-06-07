using UnityEngine;
using UnityEngine.UI;

namespace EpicToonFX
{
	public class ETFXButtonScript : MonoBehaviour
	{
		public GameObject Button;

		private Text MyButtonText;

		private string projectileParticleName;

		private ETFXFireProjectile effectScript;

		private ETFXProjectileScript projectileScript;

		public float buttonsX;

		public float buttonsY;

		public float buttonsSizeX;

		public float buttonsSizeY;

		public float buttonsDistance;

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void getProjectileNames()
		{
		}

		public bool overButton()
		{
			return false;
		}
	}
}
