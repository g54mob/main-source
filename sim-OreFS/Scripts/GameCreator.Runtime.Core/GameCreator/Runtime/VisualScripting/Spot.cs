using System;
using GameCreator.Runtime.Common;

namespace GameCreator.Runtime.VisualScripting
{
	[Serializable]
	[Image(typeof(IconCircleOutline), ColorTheme.Type.Yellow)]
	public abstract class Spot : TPolymorphicItem<Spot>
	{
		public abstract override string Title { get; }

		public virtual void OnAwake(Hotspot hotspot)
		{
		}

		public virtual void OnStart(Hotspot hotspot)
		{
		}

		public virtual void OnEnable(Hotspot hotspot)
		{
		}

		public virtual void OnDisable(Hotspot hotspot)
		{
		}

		public virtual void OnUpdate(Hotspot hotspot)
		{
		}

		public virtual void OnGizmos(Hotspot hotspot)
		{
		}

		public virtual void OnDestroy(Hotspot hotspot)
		{
		}

		public virtual void OnPointerEnter(Hotspot hotspot)
		{
		}

		public virtual void OnPointerExit(Hotspot hotspot)
		{
		}
	}
}
