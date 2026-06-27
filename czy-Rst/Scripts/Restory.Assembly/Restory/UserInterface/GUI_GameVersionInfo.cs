using System.Text;
using Restory.Data.GameConfigs;
using TMPro;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface
{
	public class GUI_GameVersionInfo : MonoBehaviour
	{
		[SerializeField]
		private TextMeshProUGUI text;

		private GameConfig gameConfig;

		private VersionType gameVersionType;

		[Inject]
		private void Construct(GameConfig gameConfig)
		{
			this.gameConfig = gameConfig;
			UpdateGameVersion();
		}

		private void OnEnable()
		{
			if ((bool)gameConfig && gameVersionType != gameConfig.VersionType)
			{
				UpdateGameVersion();
			}
		}

		private void UpdateGameVersion()
		{
			gameVersionType = gameConfig.VersionType;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Version: ");
			switch (gameVersionType)
			{
			case VersionType.Demo:
				stringBuilder.Append("Demo ");
				break;
			case VersionType.Playtest:
				stringBuilder.Append("Playtest ");
				break;
			}
			stringBuilder.Append(Application.version);
			text.text = stringBuilder.ToString();
		}
	}
}
