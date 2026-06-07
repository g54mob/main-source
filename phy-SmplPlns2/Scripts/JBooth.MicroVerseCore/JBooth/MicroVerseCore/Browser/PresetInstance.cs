using UnityEngine;

namespace JBooth.MicroVerseCore.Browser
{
	public class PresetInstance : MonoBehaviour, IContentBrowserDropAction
	{
		public enum Category
		{
			None = 0,
			Sky = 1,
			Fog = 2,
			Water = 3
		}

		public enum DuplicateFoundAction
		{
			Hide = 0,
			Destroy = 1
		}

		public Category category;

		private DuplicateFoundAction duplicateFoundAction = DuplicateFoundAction.Destroy;

		public void Execute(out bool destroyAfterExecute)
		{
			destroyAfterExecute = false;
			PresetInstance[] array = Object.FindObjectsByType<PresetInstance>(FindObjectsSortMode.None);
			foreach (PresetInstance presetInstance in array)
			{
				if (presetInstance.category == category && presetInstance.isActiveAndEnabled && !(presetInstance.transform == base.transform))
				{
					switch (duplicateFoundAction)
					{
					case DuplicateFoundAction.Hide:
						presetInstance.transform.gameObject.SetActive(value: false);
						break;
					case DuplicateFoundAction.Destroy:
						Object.DestroyImmediate(presetInstance.gameObject);
						break;
					default:
						Debug.LogError($"Unsupported duplicate found action {duplicateFoundAction}");
						break;
					}
					destroyAfterExecute = false;
				}
			}
		}
	}
}
