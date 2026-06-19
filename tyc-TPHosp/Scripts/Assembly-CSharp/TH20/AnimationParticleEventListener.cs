using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[fiInspectorOnly]
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class AnimationParticleEventListener : MonoBehaviour
	{
		[Serializable]
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class FXData
		{
			[Serializable]
			[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
			public class FX
			{
				public Transform Socket;

				public string SocketName;

				public ParticleSystem ParticleSystem;

				public Material Material;

				public bool HasDuration;

				public float DurationValue;
			}

			public string Name;

			public List<FX> FXList;
		}

		[InspectorTooltip("Particle FX")]
		public List<FXData> _FXData;

		private Transform GetSocket(FXData.FX fx)
		{
			if (fx.Socket != null)
			{
				return fx.Socket;
			}
			Transform transform = base.transform.FindChildRecursively(fx.SocketName, ignoreInputTransform: true);
			if (!(transform != null))
			{
				return base.transform;
			}
			return transform;
		}

		public void SpawnFX(AnimationEvent animationEvent)
		{
			SpawnFX(animationEvent.stringParameter);
		}

		public void SpawnFX(string fxName)
		{
			if (!DebugVars.AllowParticleFX.Value || _FXData == null)
			{
				return;
			}
			foreach (FXData fXDatum in _FXData)
			{
				if (!(fXDatum.Name == fxName))
				{
					continue;
				}
				foreach (FXData.FX fX in fXDatum.FXList)
				{
					Transform socket = GetSocket(fX);
					GameObject gameObject = UnityEngine.Object.Instantiate(fX.ParticleSystem.gameObject, socket, worldPositionStays: false);
					ParticleSystem component = gameObject.GetComponent<ParticleSystem>();
					ParticleSystem.MainModule main = component.main;
					if (fX.HasDuration)
					{
						main.duration = fX.DurationValue;
						main.loop = false;
					}
					if (fX.Material != null)
					{
						component.GetComponent<Renderer>().sharedMaterial = fX.Material;
					}
					component.Play();
					if (!main.loop)
					{
						UnityEngine.Object.Destroy(gameObject, main.duration * 2f);
					}
				}
			}
		}
	}
}
