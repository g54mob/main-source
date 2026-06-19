using UnityEngine;
using UnityEngine.UI;

namespace Aggro.Core
{
	public abstract class AggroSettingsCustomPageUI : MonoBehaviour
	{
		public abstract void Initialize(string category);

		public abstract GameObject InstantiateSettingUI(GameObject prefab);

		public abstract void Show(float timeBetweenSettings, float fadeInDuration, EasingFunction.Ease fadeInEase, Selectable backButton);
	}
}
