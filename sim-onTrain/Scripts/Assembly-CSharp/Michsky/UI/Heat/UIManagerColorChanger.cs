using UnityEngine;

namespace Michsky.UI.Heat
{
	[AddComponentMenu("Heat UI/UI Manager/UI Manager Color Changer")]
	public class UIManagerColorChanger : MonoBehaviour
	{
		[Header("Resources")]
		public UIManager targetUIManager;

		[Header("Colors")]
		public Color accent = new Color32(0, 200, byte.MaxValue, byte.MaxValue);

		public Color accentMatch = new Color32(25, 35, 45, byte.MaxValue);

		public Color primary = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color secondary = new Color32(byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue);

		public Color negative = new Color32(byte.MaxValue, 75, 75, byte.MaxValue);

		public Color background = new Color32(25, 35, 45, byte.MaxValue);

		[Header("Settings")]
		[SerializeField]
		private bool applyOnStart;

		private void Start()
		{
			if (applyOnStart)
			{
				ApplyColors();
			}
		}

		public void ApplyColors()
		{
			if (targetUIManager == null)
			{
				Debug.LogError("Cannot apply the changes due to missing 'Target UI Manager'.", this);
				return;
			}
			targetUIManager.accentColor = accent;
			targetUIManager.accentColorInvert = accentMatch;
			targetUIManager.primaryColor = primary;
			targetUIManager.secondaryColor = secondary;
			targetUIManager.negativeColor = negative;
			targetUIManager.backgroundColor = background;
			if (!targetUIManager.enableDynamicUpdate)
			{
				targetUIManager.enableDynamicUpdate = true;
				Invoke("DisableDynamicUpdate", 1f);
			}
		}

		private void DisableDynamicUpdate()
		{
			targetUIManager.enableDynamicUpdate = false;
		}
	}
}
