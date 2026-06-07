using UnityEngine;

namespace ModApi.Craft.Parts
{
	public class EnabledScript : MonoBehaviour
	{
		[SerializeField]
		private bool _enabledOnlyInDesigner = true;

		public bool EnabledOnlyInDesigner => _enabledOnlyInDesigner;

		public bool EnabledOnlyInFlight => !_enabledOnlyInDesigner;

		public static void ProcessGameObject(GameObject gameObject)
		{
			EnabledScript[] componentsInChildren = gameObject.GetComponentsInChildren<EnabledScript>(includeInactive: true);
			bool inDesignerScene = Game.InDesignerScene;
			EnabledScript[] array = componentsInChildren;
			foreach (EnabledScript enabledScript in array)
			{
				enabledScript.gameObject.SetActive(enabledScript.EnabledOnlyInDesigner == inDesignerScene);
				if (!enabledScript.gameObject.activeInHierarchy && !inDesignerScene)
				{
					Object.Destroy(enabledScript.gameObject);
				}
			}
		}
	}
}
