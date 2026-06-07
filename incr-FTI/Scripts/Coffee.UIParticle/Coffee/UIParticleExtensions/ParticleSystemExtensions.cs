using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIParticleExtensions
{
	public static class ParticleSystemExtensions
	{
		private static ParticleSystem.Particle[] s_TmpParticles = new ParticleSystem.Particle[2048];

		public static ParticleSystem.Particle[] GetParticleArray(int size)
		{
			if (s_TmpParticles.Length < size)
			{
				while (s_TmpParticles.Length < size)
				{
					size = Mathf.NextPowerOfTwo(size);
				}
				s_TmpParticles = new ParticleSystem.Particle[size];
			}
			return s_TmpParticles;
		}

		public static bool CanBakeMesh(this ParticleSystemRenderer self)
		{
			if (self.renderMode == ParticleSystemRenderMode.Mesh && self.mesh == null)
			{
				return false;
			}
			if (self.renderMode == ParticleSystemRenderMode.None)
			{
				return false;
			}
			return true;
		}

		public static ParticleSystemSimulationSpace GetActualSimulationSpace(this ParticleSystem self)
		{
			ParticleSystem.MainModule main = self.main;
			ParticleSystemSimulationSpace particleSystemSimulationSpace = main.simulationSpace;
			if (particleSystemSimulationSpace == ParticleSystemSimulationSpace.Custom && !main.customSimulationSpace)
			{
				particleSystemSimulationSpace = ParticleSystemSimulationSpace.Local;
			}
			return particleSystemSimulationSpace;
		}

		public static bool IsLocalSpace(this ParticleSystem self)
		{
			return self.GetActualSimulationSpace() == ParticleSystemSimulationSpace.Local;
		}

		public static bool IsWorldSpace(this ParticleSystem self)
		{
			return self.GetActualSimulationSpace() == ParticleSystemSimulationSpace.World;
		}

		public static void SortForRendering(this List<ParticleSystem> self, Transform transform, bool sortByMaterial)
		{
			self.Sort(delegate(ParticleSystem a, ParticleSystem b)
			{
				ParticleSystemRenderer component = a.GetComponent<ParticleSystemRenderer>();
				ParticleSystemRenderer component2 = b.GetComponent<ParticleSystemRenderer>();
				Material material = (component.sharedMaterial ? component.sharedMaterial : component.trailMaterial);
				Material material2 = (component2.sharedMaterial ? component2.sharedMaterial : component2.trailMaterial);
				if (!material && !material2)
				{
					return 0;
				}
				if (!material)
				{
					return -1;
				}
				if (!material2)
				{
					return 1;
				}
				if (sortByMaterial)
				{
					return material.GetInstanceID() - material2.GetInstanceID();
				}
				if (material.renderQueue != material2.renderQueue)
				{
					return material.renderQueue - material2.renderQueue;
				}
				if (component.sortingLayerID != component2.sortingLayerID)
				{
					return SortingLayer.GetLayerValueFromID(component.sortingLayerID) - SortingLayer.GetLayerValueFromID(component2.sortingLayerID);
				}
				if (component.sortingOrder != component2.sortingOrder)
				{
					return component.sortingOrder - component2.sortingOrder;
				}
				Transform transform2 = a.transform;
				Transform transform3 = b.transform;
				float num = transform.InverseTransformPoint(transform2.position).z + component.sortingFudge;
				float num2 = transform.InverseTransformPoint(transform3.position).z + component2.sortingFudge;
				return (!Mathf.Approximately(num, num2)) ? ((int)Mathf.Sign(num2 - num)) : ((int)Mathf.Sign(GetIndex(self, a) - GetIndex(self, b)));
			});
		}

		private static int GetIndex(IList<ParticleSystem> list, UnityEngine.Object ps)
		{
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].GetInstanceID() == ps.GetInstanceID())
				{
					return i;
				}
			}
			return 0;
		}

		public static Texture2D GetTextureForSprite(this ParticleSystem self)
		{
			if (!self)
			{
				return null;
			}
			ParticleSystem.TextureSheetAnimationModule textureSheetAnimation = self.textureSheetAnimation;
			if (!textureSheetAnimation.enabled || textureSheetAnimation.mode != ParticleSystemAnimationMode.Sprites)
			{
				return null;
			}
			for (int i = 0; i < textureSheetAnimation.spriteCount; i++)
			{
				Sprite sprite = textureSheetAnimation.GetSprite(i);
				if ((bool)sprite)
				{
					return sprite.GetActualTexture();
				}
			}
			return null;
		}

		public static void Exec(this List<ParticleSystem> self, Action<ParticleSystem> action)
		{
			self.RemoveAll((ParticleSystem p) => !p);
			self.ForEach(action);
		}
	}
}
