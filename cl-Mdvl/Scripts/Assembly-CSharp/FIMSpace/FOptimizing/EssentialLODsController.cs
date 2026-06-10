using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace FIMSpace.FOptimizing
{
	[Serializable]
	public class EssentialLODsController : LODsControllerBase
	{
		public enum EEssType
		{
			Unknown = 0,
			Particle = 1,
			Light = 2,
			MonoBehaviour = 3,
			Renderer = 4,
			NavMeshAgent = 5,
			AudioSource = 6,
			Rigidbody = 7,
			LODGroup = 8
		}

		public List<LODI_ParticleSystem> LODs_Particle;

		public List<LODI_Light> LODs_Light;

		public List<LODI_MonoBehaviour> LODs_Mono;

		public List<LODI_Renderer> LODs_Renderer;

		public List<LODI_NavMeshAgent> LODs_NavMesh;

		public List<LODI_AudioSource> LODs_Audio;

		public List<LODI_Rigidbody> LODs_Rigidbody;

		public List<LODI_UnityLOD> LODs_LODGroup;

		[SerializeField]
		private LODI_ParticleSystem Ini_Particle;

		[SerializeField]
		private LODI_Light Ini_Light;

		[SerializeField]
		private LODI_MonoBehaviour Ini_Mono;

		[SerializeField]
		private LODI_Renderer Ini_Rend;

		[SerializeField]
		private LODI_NavMeshAgent Ini_Nav;

		[SerializeField]
		private LODI_AudioSource Ini_Audio;

		[SerializeField]
		private LODI_Rigidbody Ini_Rigidbody;

		[SerializeField]
		private LODI_UnityLOD Ini_LODGroup;

		[SerializeField]
		private EssentialOptimizer eOptimizer;

		public EEssType ControlerType;

		private List<ILODInstance> _iflod;

		public override ILODInstance InitialSettings
		{
			get
			{
				return ControlerType switch
				{
					EEssType.Particle => Ini_Particle, 
					EEssType.Light => Ini_Light, 
					EEssType.MonoBehaviour => Ini_Mono, 
					EEssType.Renderer => Ini_Rend, 
					EEssType.NavMeshAgent => Ini_Nav, 
					EEssType.AudioSource => Ini_Audio, 
					EEssType.Rigidbody => Ini_Rigidbody, 
					EEssType.LODGroup => Ini_LODGroup, 
					_ => null, 
				};
			}
			protected set
			{
				switch (ControlerType)
				{
				case EEssType.Particle:
					Ini_Particle = value as LODI_ParticleSystem;
					break;
				case EEssType.Light:
					Ini_Light = value as LODI_Light;
					break;
				case EEssType.MonoBehaviour:
					Ini_Mono = value as LODI_MonoBehaviour;
					break;
				case EEssType.Renderer:
					Ini_Rend = value as LODI_Renderer;
					break;
				case EEssType.NavMeshAgent:
					Ini_Nav = value as LODI_NavMeshAgent;
					break;
				case EEssType.AudioSource:
					Ini_Audio = value as LODI_AudioSource;
					break;
				case EEssType.Rigidbody:
					Ini_Rigidbody = value as LODI_Rigidbody;
					break;
				case EEssType.LODGroup:
					Ini_LODGroup = value as LODI_UnityLOD;
					break;
				}
			}
		}

		public EssentialLODsController(Optimizer_Base sourceOptimizer, Component toOptimize, int index, string header = "")
			: base(sourceOptimizer, toOptimize, index, header)
		{
			eOptimizer = sourceOptimizer as EssentialOptimizer;
			ControlerType = GetEssentialTypeAll(toOptimize);
		}

		public override void OnStart()
		{
			if (InitialSettings == null)
			{
				GenerateInitialSettings();
			}
			InitialSettings.SetSameValuesAsComponent(Component);
		}

		protected override void RefreshToOptimizeIndex()
		{
			for (int i = 0; i < eOptimizer.ToOptimize.Count; i++)
			{
				if (eOptimizer.ToOptimize[i] == this)
				{
					ToOptimizeIndex = i;
					break;
				}
			}
		}

		internal override ILODInstance GetCurrentLOD()
		{
			return GetIFLODList()[base.CurrentLODLevel];
		}

		internal override ILODInstance GetCullingLOD()
		{
			return GetIFLODList()[GetIFLODList().Count - 2];
		}

		internal override ILODInstance GetHiddenLOD()
		{
			return GetIFLODList()[GetIFLODList().Count - 1];
		}

		public List<ILODInstance> GetIFLODsForOptimizer2()
		{
			return GetIFLODList();
		}

		protected override List<ILODInstance> GetIFLODList()
		{
			if (_iflod != null && _iflod.Count == eOptimizer.LODLevels + 2)
			{
				return _iflod;
			}
			_iflod = new List<ILODInstance>();
			switch (ControlerType)
			{
			case EEssType.Particle:
			{
				for (int num2 = 0; num2 < LODs_Particle.Count; num2++)
				{
					_iflod.Add(LODs_Particle[num2]);
				}
				break;
			}
			case EEssType.Light:
			{
				for (int l = 0; l < LODs_Light.Count; l++)
				{
					_iflod.Add(LODs_Light[l]);
				}
				break;
			}
			case EEssType.MonoBehaviour:
			{
				for (int n = 0; n < LODs_Mono.Count; n++)
				{
					_iflod.Add(LODs_Mono[n]);
				}
				break;
			}
			case EEssType.Renderer:
			{
				for (int j = 0; j < LODs_Renderer.Count; j++)
				{
					_iflod.Add(LODs_Renderer[j]);
				}
				break;
			}
			case EEssType.NavMeshAgent:
			{
				for (int num = 0; num < LODs_NavMesh.Count; num++)
				{
					_iflod.Add(LODs_NavMesh[num]);
				}
				break;
			}
			case EEssType.AudioSource:
			{
				for (int m = 0; m < LODs_Audio.Count; m++)
				{
					_iflod.Add(LODs_Audio[m]);
				}
				break;
			}
			case EEssType.Rigidbody:
			{
				for (int k = 0; k < LODs_Rigidbody.Count; k++)
				{
					_iflod.Add(LODs_Rigidbody[k]);
				}
				break;
			}
			case EEssType.LODGroup:
			{
				for (int i = 0; i < LODs_LODGroup.Count; i++)
				{
					_iflod.Add(LODs_LODGroup[i]);
				}
				break;
			}
			}
			return _iflod;
		}

		protected override void GenerateNewLODSettings()
		{
			if (ControlerType == EEssType.Unknown)
			{
				Debug.Log("[Optimizers] Unknown to optimize type!");
				return;
			}
			switch (ControlerType)
			{
			case EEssType.Particle:
				LODs_Particle = new List<LODI_ParticleSystem>();
				break;
			case EEssType.Light:
				LODs_Light = new List<LODI_Light>();
				break;
			case EEssType.MonoBehaviour:
				LODs_Mono = new List<LODI_MonoBehaviour>();
				break;
			case EEssType.Renderer:
				LODs_Renderer = new List<LODI_Renderer>();
				break;
			case EEssType.NavMeshAgent:
				LODs_NavMesh = new List<LODI_NavMeshAgent>();
				break;
			case EEssType.AudioSource:
				LODs_Audio = new List<LODI_AudioSource>();
				break;
			case EEssType.Rigidbody:
				LODs_Rigidbody = new List<LODI_Rigidbody>();
				break;
			case EEssType.LODGroup:
				LODs_LODGroup = new List<LODI_UnityLOD>();
				break;
			}
		}

		private void GenerateInitialSettings()
		{
			switch (ControlerType)
			{
			case EEssType.Particle:
				Ini_Particle = new LODI_ParticleSystem();
				break;
			case EEssType.Light:
				Ini_Light = new LODI_Light();
				break;
			case EEssType.MonoBehaviour:
				Ini_Mono = new LODI_MonoBehaviour();
				break;
			case EEssType.Renderer:
				Ini_Rend = new LODI_Renderer();
				break;
			case EEssType.NavMeshAgent:
				Ini_Nav = new LODI_NavMeshAgent();
				break;
			case EEssType.AudioSource:
				Ini_Audio = new LODI_AudioSource();
				break;
			case EEssType.Rigidbody:
				Ini_Rigidbody = new LODI_Rigidbody();
				break;
			case EEssType.LODGroup:
				Ini_LODGroup = new LODI_UnityLOD();
				break;
			}
		}

		private ILODInstance GenerateInstance()
		{
			return ControlerType switch
			{
				EEssType.Particle => new LODI_ParticleSystem(), 
				EEssType.Light => new LODI_Light(), 
				EEssType.MonoBehaviour => new LODI_MonoBehaviour(), 
				EEssType.Renderer => new LODI_Renderer(), 
				EEssType.NavMeshAgent => new LODI_NavMeshAgent(), 
				EEssType.AudioSource => new LODI_AudioSource(), 
				EEssType.Rigidbody => new LODI_Rigidbody(), 
				EEssType.LODGroup => new LODI_UnityLOD(), 
				_ => null, 
			};
		}

		protected override void CheckAndGenerateLODParameters()
		{
			if (GetLODSettingsCount() != optimizer.LODLevels + 2)
			{
				switch (ControlerType)
				{
				case EEssType.Particle:
				{
					for (int num2 = 0; num2 < optimizer.LODLevels + 2; num2++)
					{
						LODs_Particle.Add(new LODI_ParticleSystem());
					}
					break;
				}
				case EEssType.Light:
				{
					for (int l = 0; l < optimizer.LODLevels + 2; l++)
					{
						LODs_Light.Add(new LODI_Light());
					}
					break;
				}
				case EEssType.MonoBehaviour:
				{
					for (int n = 0; n < optimizer.LODLevels + 2; n++)
					{
						LODs_Mono.Add(new LODI_MonoBehaviour());
					}
					break;
				}
				case EEssType.Renderer:
				{
					for (int j = 0; j < optimizer.LODLevels + 2; j++)
					{
						LODs_Renderer.Add(new LODI_Renderer());
					}
					break;
				}
				case EEssType.NavMeshAgent:
				{
					for (int num = 0; num < optimizer.LODLevels + 2; num++)
					{
						LODs_NavMesh.Add(new LODI_NavMeshAgent());
					}
					break;
				}
				case EEssType.AudioSource:
				{
					for (int m = 0; m < optimizer.LODLevels + 2; m++)
					{
						LODs_Audio.Add(new LODI_AudioSource());
					}
					break;
				}
				case EEssType.Rigidbody:
				{
					for (int k = 0; k < optimizer.LODLevels + 2; k++)
					{
						LODs_Rigidbody.Add(new LODI_Rigidbody());
					}
					break;
				}
				case EEssType.LODGroup:
				{
					for (int i = 0; i < optimizer.LODLevels + 2; i++)
					{
						LODs_LODGroup.Add(new LODI_UnityLOD());
					}
					break;
				}
				}
			}
			RefreshOptimizerLODCount();
		}

		internal override void ApplyLODLevelSettings(ILODInstance currentLOD)
		{
			if (currentLOD != null)
			{
				base.CurrentLODLevel = currentLOD.Index;
				if (IsTransitioningOrOther())
				{
					base.CurrentLODLevel = -1;
				}
				currentLOD.ApplySettingsToTheComponent(Component, InitialSettings);
			}
		}

		public void OnValidate()
		{
		}

		public override ILODInstance GetLODSetting(int lod)
		{
			return ControlerType switch
			{
				EEssType.Particle => LODs_Particle[lod], 
				EEssType.Light => LODs_Light[lod], 
				EEssType.MonoBehaviour => LODs_Mono[lod], 
				EEssType.Renderer => LODs_Renderer[lod], 
				EEssType.NavMeshAgent => LODs_NavMesh[lod], 
				EEssType.AudioSource => LODs_Audio[lod], 
				EEssType.Rigidbody => LODs_Rigidbody[lod], 
				EEssType.LODGroup => LODs_LODGroup[lod], 
				_ => null, 
			};
		}

		public override int GetLODSettingsCount()
		{
			switch (ControlerType)
			{
			case EEssType.Particle:
				if (LODs_Particle == null)
				{
					return 0;
				}
				return LODs_Particle.Count;
			case EEssType.Light:
				if (LODs_Light == null)
				{
					return 0;
				}
				return LODs_Light.Count;
			case EEssType.MonoBehaviour:
				if (LODs_Mono == null)
				{
					return 0;
				}
				return LODs_Mono.Count;
			case EEssType.Renderer:
				if (LODs_Renderer == null)
				{
					return 0;
				}
				return LODs_Renderer.Count;
			case EEssType.NavMeshAgent:
				if (LODs_NavMesh == null)
				{
					return 0;
				}
				return LODs_NavMesh.Count;
			case EEssType.AudioSource:
				if (LODs_Audio == null)
				{
					return 0;
				}
				return LODs_Audio.Count;
			case EEssType.Rigidbody:
				if (LODs_Rigidbody == null)
				{
					return 0;
				}
				return LODs_Rigidbody.Count;
			case EEssType.LODGroup:
				if (LODs_LODGroup == null)
				{
					return 0;
				}
				return LODs_LODGroup.Count;
			default:
				return 0;
			}
		}

		internal static EEssType GetEssentialType(Component target)
		{
			if (OptimUtils.ShouldBeIgnored(target))
			{
				return EEssType.Unknown;
			}
			if ((bool)(target as ParticleSystem))
			{
				return EEssType.Particle;
			}
			if ((bool)(target as Light))
			{
				return EEssType.Light;
			}
			if ((bool)(target as MonoBehaviour))
			{
				return EEssType.MonoBehaviour;
			}
			Renderer renderer = target as Renderer;
			if ((bool)renderer)
			{
				if ((bool)(renderer as ParticleSystemRenderer))
				{
					return EEssType.Unknown;
				}
				return EEssType.Renderer;
			}
			if ((bool)(target as NavMeshAgent))
			{
				return EEssType.NavMeshAgent;
			}
			if ((bool)(target as AudioSource))
			{
				return EEssType.AudioSource;
			}
			return EEssType.Unknown;
		}

		internal static EEssType GetEssentialTypeAll(Component target)
		{
			if (OptimUtils.ShouldBeIgnored(target))
			{
				return EEssType.Unknown;
			}
			EEssType essentialType = GetEssentialType(target);
			if (essentialType == EEssType.Unknown)
			{
				if ((bool)(target as Rigidbody))
				{
					return EEssType.Rigidbody;
				}
				if (Optimizer_Base._HandleUnityLOD && (bool)(target as LODGroup))
				{
					return EEssType.LODGroup;
				}
			}
			return essentialType;
		}
	}
}
