using UnityEngine;
using UnityEngine.UI;

namespace JUTPS.WeaponSystem
{
	public class ScopeSystem : MonoBehaviour
	{
		public Image ScopeImage;

		public GameObject UIPanel;

		public JUCharacterController JUCharacter;

		private bool ScopeMode;

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
			if (JUCharacter == null && tsPlayer.gameObject != null)
			{
				JUCharacter = tsPlayer.gameObject.GetComponent<JUCharacterController>();
			}
		}

		private void Update()
		{
			if (JUCharacter == null)
			{
				return;
			}
			ScopeMode = false;
			if (JUCharacter.HoldableItemInUseRightHand != null && JUCharacter.HoldableItemInUseRightHand is Weapon)
			{
				Weapon weapon = (Weapon)JUCharacter.HoldableItemInUseRightHand;
				if (JUCharacter.IsAiming && weapon.AimMode == Weapon.WeaponAimMode.Scope)
				{
					ScopeImage.sprite = weapon.ScopeTexture;
					ScopeMode = true;
				}
			}
			ScopeImage.gameObject.SetActive(JUCharacter.IsAiming && ScopeMode);
			UIPanel.SetActive(!JUCharacter.IsAiming || !ScopeMode);
		}
	}
}
