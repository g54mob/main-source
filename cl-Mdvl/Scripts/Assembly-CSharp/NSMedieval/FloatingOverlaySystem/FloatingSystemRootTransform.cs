using System.Collections.Generic;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	public class FloatingSystemRootTransform : MonoBehaviour
	{
		public Dictionary<FloatingElementHolderType, FloatingElementHolder> Holders { get; } = new Dictionary<FloatingElementHolderType, FloatingElementHolder>();

		public void AddHolder(FloatingElementHolder holder)
		{
			Holders.TryAdd(holder.Type, holder);
		}

		private void OnDestroy()
		{
			if (MonoSingleton<FloatingOverlayManager>.IsApplicationIsQuitting())
			{
				return;
			}
			if (MonoSingleton<FloatingOverlayManager>.IsInstantiated())
			{
				MonoSingleton<FloatingOverlayManager>.Instance.RootTransformDestroyed(base.transform);
			}
			foreach (KeyValuePair<FloatingElementHolderType, FloatingElementHolder> holder in Holders)
			{
				if (!(holder.Value == null) && !holder.Value.HasDisposed && !(holder.Value.gameObject == null))
				{
					Object.Destroy(holder.Value.gameObject);
				}
			}
			Holders.Clear();
		}
	}
}
