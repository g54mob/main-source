using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDCanvasGroupVisualLevel : HUDVisualLevelModule
	{
		private CanvasGroup group;

		private bool initialized;

		private void Awake()
		{
			Initialize();
		}

		private void Initialize()
		{
			if (!initialized)
			{
				initialized = true;
				group = GetComponent<CanvasGroup>();
				if (!group)
				{
					Debug.LogError("Missing CanvasGroup, destroying self.");
					Object.Destroy(this);
				}
			}
		}

		public override float GetVisualLevel()
		{
			return group.alpha;
		}

		public override void SetVisualLevel(float level)
		{
			Initialize();
			group.alpha = level;
		}
	}
}
