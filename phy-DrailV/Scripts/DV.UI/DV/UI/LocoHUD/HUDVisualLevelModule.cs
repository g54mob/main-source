using System;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public abstract class HUDVisualLevelModule : MonoBehaviour
	{
		public virtual Func<int, bool> ShouldScrollCallback => delegate(int notches)
		{
			float visualLevel = GetVisualLevel();
			return (notches > 0 && visualLevel < 1f) || (notches < 0 && visualLevel > 0f);
		};

		public abstract void SetVisualLevel(float level);

		public abstract float GetVisualLevel();
	}
}
