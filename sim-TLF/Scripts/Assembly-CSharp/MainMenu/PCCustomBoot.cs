using System.Linq;
using Cysharp.Threading.Tasks;
using JSAM;
using Michsky.DreamOS;
using UnityEngine;

namespace MainMenu
{
	public class PCCustomBoot : MonoBehaviour
	{
		[SerializeField]
		private BootManager _bootManager;

		[SerializeField]
		private float _bootDelay = 2f;

		[SerializeField]
		private GameObject _desktop;

		private void Awake()
		{
			QualitySettings.vSyncCount = 0;
			Application.targetFrameRate = 60;
			_desktop.SetActive(value: false);
		}

		private void Start()
		{
			Cursor.visible = false;
			Sequence().Forget();
			Invoke("Boot", _bootDelay);
		}

		private void Boot()
		{
		}

		private async UniTask Sequence()
		{
			await UniTask.WaitForEndOfFrame();
			await UniTask.WaitForEndOfFrame();
			await UniTask.WaitForSeconds(0.15f);
			JSAM.AudioManager.PlaySound(MainMenuLibrarySounds.crtcomputermonitorstartup);
			await UniTask.WaitForSeconds(0.75f);
			JSAM.AudioManager.PlaySound(MainMenuLibrarySounds.Electromagnetic_Neon_Light_Loop_Mono_Elektrousi_03);
			JSAM.AudioManager.PlaySound(MainMenuLibrarySounds.AmigaDiskDriveButtonClick15);
			await UniTask.WaitForSeconds(0.5f);
			JSAM.AudioManager.PlaySound(MainMenuLibrarySounds.SLOWDOWNSPEEDUP_05);
			await UniTask.WaitForSeconds(0.2f);
			float length = JSAM.AudioManager.PlaySound(MainMenuLibrarySounds.Computer2).AudioFile.Files.FirstOrDefault().length;
			_bootManager.Boot();
			await UniTask.WaitForSeconds(length / 2f);
		}
	}
}
