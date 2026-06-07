using System.Collections.Generic;
using Assets.Scripts.Craft.Parts.Events;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers.Weapons
{
	public class ProceduralMissileScript : PartModifierScript
	{
		private AudioSource _audio;

		private List<IMissileSubPart> _connectedParts = new List<IMissileSubPart>();

		private ProceduralMissileBuilder _missileBuilder;

		private GameObject _missileGameObject;

		[SerializeField]
		private Transform _particleFX;

		private bool _refreshPerformance;

		public ProceduralMissileData Data { get; set; }

		public static List<ProceduralMissileSubPartData> GetConnectedMissileFinsAndWings(PartData part)
		{
			List<ProceduralMissileSubPartData> list = new List<ProceduralMissileSubPartData>();
			foreach (PartConnection partConnection in part.PartConnections)
			{
				ProceduralMissileSubPartData modifier = partConnection.GetOtherPart(part).GetModifier<ProceduralMissileSubPartData>();
				if (modifier != null && (modifier.SubPartType == MissileSubPartType.Fin || modifier.SubPartType == MissileSubPartType.Wings))
				{
					list.Add(modifier);
				}
			}
			return list;
		}

		public void Adjust(bool repositionConnectedParts)
		{
			List<IMissileSubPart> connectedMissileParts = GetConnectedMissileParts(base.PartScript.Part);
			_missileBuilder.AdjustMissile(_missileGameObject, Data, repositionConnectedParts, connectedMissileParts);
		}

		public void Build()
		{
			if (_missileGameObject != null)
			{
				Object.Destroy(_missileGameObject);
			}
			_missileGameObject = new GameObject("Missile");
			_missileGameObject.transform.SetParent(base.transform);
			_missileGameObject.transform.localScale = Vector3.one;
			_missileGameObject.transform.localRotation = Quaternion.identity;
			_missileGameObject.transform.localPosition = Vector3.zero;
			base.PartScript.PartMaterialScript.ClearRenderers(destroy: true);
			List<IMissileSubPart> connectedMissileParts = GetConnectedMissileParts(base.PartScript.Part);
			_missileBuilder.BuildMissile(_missileGameObject, Data, connectedMissileParts);
			if (base.LoadContext == CraftLoadContext.Flight)
			{
				foreach (IMissileSubPart item in connectedMissileParts)
				{
					_connectedParts.Add(item);
				}
			}
			base.PartScript.PartMaterialScript.ApplyAllMaterials();
		}

		public override void BuildPreStartInitializationPlan(PreStartInitializationPlan plan)
		{
			base.BuildPreStartInitializationPlan(plan);
			plan.Register(this, OnPreStart);
		}

		public void CalculateFinPerformanceCharacteristics(out float totalFinSurfaceArea, out float centerOfLift)
		{
			float num = 0f;
			List<ProceduralMissileSubPartData> connectedMissileFinsAndWings = GetConnectedMissileFinsAndWings(base.PartScript.Part);
			float num2 = 0f;
			foreach (ProceduralMissileSubPartData item in connectedMissileFinsAndWings)
			{
				Vector3 vector = _missileGameObject.transform.InverseTransformPoint(item.Script.transform.position);
				float surfaceArea = item.SurfaceArea;
				num2 += vector.z * surfaceArea;
				num += surfaceArea;
			}
			float size = Data.Size;
			float num3 = Data.Size * Data.RadiusScale;
			totalFinSurfaceArea = num * num3 * size;
			if (num > 0f)
			{
				centerOfLift = Mathf.Clamp(num2 / num, -1f, 1f);
			}
			else
			{
				centerOfLift = -1f;
			}
		}

		public void OnActivated()
		{
		}

		public void QueuePerformanceRefresh()
		{
			_refreshPerformance = true;
		}

		protected void OnDestroy()
		{
			if (base.PartScript != null)
			{
				base.PartScript.PartConnectionChanged -= OnConnectionChanged;
			}
		}

		protected override void OnInitialize()
		{
			base.OnInitialize();
			base.PartScript.PartConnectionChanged += OnConnectionChanged;
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			base.RegisterUpdateMethods(in registrar);
			registrar.RegisterStart(FlightStart, CraftUpdateFlags.FlightDefault);
			registrar.RegisterUpdate(DesignerUpdate, CraftUpdateFlags.DesignerDefault);
		}

		private static List<IMissileSubPart> GetConnectedMissileParts(PartData part)
		{
			List<IMissileSubPart> list = new List<IMissileSubPart>();
			foreach (PartConnection partConnection in part.PartConnections)
			{
				IMissileSubPart modifierWithInterface = partConnection.GetOtherPart(part).PartScript.GetModifierWithInterface<IMissileSubPart>();
				if (modifierWithInterface != null)
				{
					list.Add(modifierWithInterface);
				}
			}
			return list;
		}

		private void DesignerUpdate(in CraftUpdateFrameData frame)
		{
			if (_refreshPerformance)
			{
				_refreshPerformance = false;
				Data.RefreshPerformance();
			}
		}

		private void FlightStart(in CraftUpdateFrameData frame)
		{
			Vector3 missileScale = Data.MissileScale;
			_particleFX.transform.localScale = Vector3.one * missileScale.x;
			_particleFX.transform.localPosition = new Vector3(0f, 0f, 0f - missileScale.z - missileScale.x * 0.5f);
			_audio = _particleFX.GetComponentInChildren<AudioSource>(includeInactive: true);
			if (_audio != null)
			{
				_audio.volume = 0.2f + 0.8f * Mathf.Clamp01(0.025f * Data.Size * Data.RadiusScale / Data.BurnTimePercentage);
				_audio.pitch = 1f / Mathf.Sqrt(Data.Size * Data.RadiusScale);
				if (Data.EngineData.Type == MissileEngineType.Jet)
				{
					_audio.clip = Resources.Load("Sound/Propulsion/EngineJet") as AudioClip;
					_audio.volume *= 0.5f;
				}
				else
				{
					_audio.clip = Resources.Load("Sound/Weapons/Missile") as AudioClip;
				}
				_audio.minDistance *= _audio.volume;
				_audio.maxDistance *= _audio.volume;
				_audio.volume *= 0.5f;
			}
		}

		private void OnConnectionChanged(object sender, PartConnectionChangedEventArgs e)
		{
			QueuePerformanceRefresh();
		}

		private UniTask OnPreStart(AircraftScript craftScript, CraftLoadContext loadContext, bool async)
		{
			_missileBuilder = new ProceduralMissileBuilder();
			Build();
			return UniTask.CompletedTask;
		}
	}
}
