using System;
using UnityEngine;

namespace TH20
{
	public class TornadoComponent : EntityComponent
	{
		protected override Type ValidEntityType()
		{
			return typeof(RoomItem);
		}

		internal override void RestoreComponentFromSave()
		{
			RoomItem owner = GetOwner<RoomItem>();
			if (owner.Visual != null && owner.Visual.GameObject != null)
			{
				DisableEffects();
			}
			else
			{
				owner.OnVisualSet += DisableEffects;
			}
		}

		public void DisableEffects()
		{
			RoomItem owner = GetOwner<RoomItem>();
			if (owner.Visual != null && owner.Visual.GameObject != null)
			{
				GameObject gameObject = owner.Visual.GameObject;
				owner.OnVisualSet -= DisableEffects;
				ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
				for (int i = 0; i < componentsInChildren.Length; i++)
				{
					UnityEngine.Object.Destroy(componentsInChildren[i].gameObject);
				}
				Animator[] componentsInChildren2 = gameObject.GetComponentsInChildren<Animator>();
				for (int i = 0; i < componentsInChildren2.Length; i++)
				{
					componentsInChildren2[i].Play(0, 0, 1f);
				}
				Animation[] componentsInChildren3 = gameObject.GetComponentsInChildren<Animation>();
				for (int i = 0; i < componentsInChildren3.Length; i++)
				{
					componentsInChildren3[i].Stop();
				}
				SmallTropicalTornado[] componentsInChildren4 = gameObject.GetComponentsInChildren<SmallTropicalTornado>();
				for (int i = 0; i < componentsInChildren4.Length; i++)
				{
					componentsInChildren4[i].gameObject.SetActive(value: false);
				}
			}
		}
	}
}
