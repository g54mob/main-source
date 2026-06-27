using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DistantLands.Cozy
{
	public class CozyBiomeModuleBase<TCozyBiomeModule> : CozyModule, ICozyBiomeModule where TCozyBiomeModule : CozyModule, ICozyBiomeModule
	{
		public List<CozyBiomeModuleBase<TCozyBiomeModule>> biomes = new List<CozyBiomeModuleBase<TCozyBiomeModule>>();

		public float weight;

		public float totalSystemWeight;

		protected CozyBiomeModuleBase<TCozyBiomeModule> parentModule;

		public string moduleName => typeof(TCozyBiomeModule).Name;

		public CozyBiomeModuleBase<TCozyBiomeModule> ParentModule
		{
			get
			{
				if (!parentModule && (bool)base.weatherSphere)
				{
					parentModule = base.weatherSphere.GetModule<CozyBiomeModuleBase<TCozyBiomeModule>>();
				}
				return parentModule;
			}
		}

		public bool isBiomeModule { get; set; }

		public override void InitializeModule()
		{
			if (base.weatherSphere == null)
			{
				Debug.LogError("The Cozy Weather Sphere instance is not found, please add it to your scene.");
			}
			isBiomeModule = GetComponent<CozyBiome>();
			if (isBiomeModule)
			{
				AddBiome();
				return;
			}
			base.InitializeModule();
			parentModule = this;
			AddBiome();
		}

		public virtual void AddBiome()
		{
			if ((bool)ParentModule)
			{
				ParentModule.biomes = (from x in Object.FindObjectsByType<CozyBiomeModuleBase<TCozyBiomeModule>>(FindObjectsSortMode.None)
					where x != ParentModule
					select x).ToList();
			}
		}

		public virtual void RemoveBiome()
		{
			if ((bool)ParentModule)
			{
				ParentModule.biomes.Remove(this);
			}
		}

		public virtual void UpdateBiomeModule()
		{
		}

		public virtual bool CheckBiome()
		{
			if (!ParentModule)
			{
				Debug.LogError("The " + moduleName + " biome module requires the " + moduleName + " module to be enabled on your weather sphere. Please add the the " + moduleName + " module before setting up your biome.");
				return false;
			}
			return true;
		}

		public virtual void ComputeBiomeWeights()
		{
			if (!isBiomeModule)
			{
				biomes.RemoveAll((CozyBiomeModuleBase<TCozyBiomeModule> x) => !x);
				biomes.Sort(SortBySystemPriority);
				totalSystemWeight = biomes.Sum((CozyBiomeModuleBase<TCozyBiomeModule> biome) => biome.system.targetWeight);
				weight = Mathf.Clamp01(1f - totalSystemWeight);
				List<IGrouping<int, CozyBiomeModuleBase<TCozyBiomeModule>>> list = (from x in biomes
					where x != this
					group x by x.system.priority).ToList();
				float num = 0f;
				for (int num2 = list.Count - 1; num2 >= 0; num2--)
				{
					NormalizeWeights(list[num2].ToList(), Mathf.Clamp01(1f - num), out var totalWeightOfGroup);
					num += totalWeightOfGroup;
				}
			}
		}

		public virtual void NormalizeWeights(List<CozyBiomeModuleBase<TCozyBiomeModule>> biomeGroup, float maximumWeight, out float totalWeightOfGroup)
		{
			float num = Mathf.Max(totalWeightOfGroup = Mathf.Min(biomeGroup.Sum((CozyBiomeModuleBase<TCozyBiomeModule> biome) => biome.system.targetWeight), maximumWeight), 1f);
			foreach (CozyBiomeModuleBase<TCozyBiomeModule> item in biomeGroup)
			{
				item.weight = maximumWeight * item.system.targetWeight / num;
			}
		}

		public virtual float ReportWeight()
		{
			return weight;
		}

		protected static int SortBySystemPriority(CozyModule first, CozyModule second)
		{
			return first.system.priority.CompareTo(second.system.priority);
		}
	}
}
