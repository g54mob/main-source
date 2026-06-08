using Sirenix.OdinInspector;
using UnityEngine.VFX;

namespace Kitchen
{
	public class VFXManager : SerializedMonoBehaviour
	{
		public VisualEffect Effect;

		private void OnEnable()
		{
			if (Effect == null)
			{
				FindEffect();
			}
		}

		private void FindEffect()
		{
			Effect = GetComponentInChildren<VisualEffect>(includeInactive: true);
		}

		public void OnDestroy()
		{
			if (VFXPool.Pool == null)
			{
				return;
			}
			if (Effect == null)
			{
				FindEffect();
				if (Effect == null)
				{
					return;
				}
			}
			Effect.enabled = false;
			VFXPool.Pool.CommitToPool(Effect.transform);
		}
	}
}
