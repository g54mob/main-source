using System;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class DebrisEffectSaveLoadFixComponent : EntityTickComponent
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
			if (owner.Visual == null || !(owner.Visual.GameObject != null))
			{
				return;
			}
			GameObject gameObject = owner.Visual.GameObject;
			ParticleEffectControlComponent component = gameObject.GetComponent<ParticleEffectControlComponent>();
			owner.OnVisualSet -= DisableEffects;
			ParticleSystem[] componentsInChildren = gameObject.GetComponentsInChildren<ParticleSystem>();
			foreach (ParticleSystem particleSystem in componentsInChildren)
			{
				bool flag = true;
				if (component != null && component.ContainsSpecificParticleSystem(particleSystem))
				{
					flag = false;
				}
				if (flag)
				{
					UnityEngine.Object.Destroy(particleSystem.gameObject);
				}
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
		}
	}
}
