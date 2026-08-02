using JUTPS.CharacterBrain;
using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.FX
{
	[AddComponentMenu("JU TPS/FX/Blood Screen")]
	[RequireComponent(typeof(Image))]
	public class BloodScreen : MonoBehaviour
	{
		public static BloodScreen instance;

		private JUCharacterBrain pl;

		private Image img;

		private float healthvalue;

		private Color currentColor;

		private bool isInitialized;

		private void OnEnable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.AddListener(Initialize);
		}

		private void OnDisable()
		{
			Singleton<TSNetworkObjetManager>.Instance.OnServerInitialize.RemoveListener(Initialize);
		}

		private void Initialize(TSPlayerController tsPlayer)
		{
			pl = ((tsPlayer != null) ? tsPlayer.GetComponent<JUCharacterBrain>() : null);
			img = GetComponent<Image>();
			instance = this;
		}

		private void Update()
		{
			if (!(pl == null) && pl.CharacterHealth != null)
			{
				healthvalue = Mathf.Lerp(healthvalue, pl.CharacterHealth.Health / pl.CharacterHealth.MaxHealth, 15f * Time.deltaTime);
				currentColor = Color.Lerp(Color.white, Color.clear, healthvalue);
				img.color = Color.Lerp(img.color, currentColor, 5f * Time.deltaTime);
			}
		}

		private void PlayerHasHited()
		{
			img.color = Color.white;
		}

		public static void PlayerTakingDamaged()
		{
			if (!(instance == null))
			{
				instance.PlayerHasHited();
			}
		}
	}
}
