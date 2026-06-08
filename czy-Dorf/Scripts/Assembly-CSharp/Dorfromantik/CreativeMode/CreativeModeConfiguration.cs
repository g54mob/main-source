using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Dorfromantik.CreativeMode
{
	public class CreativeModeConfiguration : ScriptableObject
	{
		private sealed class _003C_003Ec__DisplayClass17_0
		{
			public GroupTypeId groupType;

			internal bool _003CSetGroupTypeProbability_003Eb__0(GroupTypeProbability x)
			{
				return x.groupType == groupType;
			}
		}

		private sealed class _003C_003Ec__DisplayClass19_0
		{
			public GroupTypeId groupType;

			internal bool _003CGetGroupTypeProbability_003Eb__0(GroupTypeProbability x)
			{
				return x.groupType == groupType;
			}
		}

		public List<GroupTypeProbability> groupTypeProbabilities = new List<GroupTypeProbability>
		{
			new GroupTypeProbability(GroupTypeId.Village, 1f),
			new GroupTypeProbability(GroupTypeId.Forest, 1f),
			new GroupTypeProbability(GroupTypeId.Agriculture, 1f),
			new GroupTypeProbability(GroupTypeId.TrainTracks, 0.65f),
			new GroupTypeProbability(GroupTypeId.Water, 0.8f)
		};

		public List<BiomeId> excludedBiomes = new List<BiomeId>();

		public bool usingConstantQuestProbability = true;

		public float constantQuestProbability = 0.2f;

		public int creativeModeWorldBorder;

		public event Action<bool> OnGroupTypeProbabilitiesUpdated;

		public event Action<bool> OnExcludedBiomesUpdated;

		public event Action OnReset;

		public static List<BiomeId> BiomeIdListFromString(string inputString)
		{
			List<BiomeId> list = new List<BiomeId>();
			for (int i = 0; i < inputString.Length; i++)
			{
				if (int.TryParse(inputString[i].ToString(), out var result) && Enum.IsDefined(typeof(BiomeId), (BiomeId)result))
				{
					list.Add((BiomeId)result);
				}
			}
			return list;
		}

		public void LoadFrom(string excludedBiomeString)
		{
			excludedBiomes = new List<BiomeId>();
			for (int i = 0; i < excludedBiomeString.Length; i++)
			{
				if (int.TryParse(excludedBiomeString[i].ToString(), out var result) && Enum.IsDefined(typeof(BiomeId), (BiomeId)result))
				{
					excludedBiomes.Add((BiomeId)result);
				}
			}
			this.OnReset?.Invoke();
		}

		public void LoadFrom(List<GroupTypeProbability> loadedGroupTypeProbabilities, List<BiomeId> loadedExcludedBiomes)
		{
			groupTypeProbabilities.Clear();
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.Village, 1f));
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.Forest, 1f));
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.Agriculture, 1f));
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.TrainTracks, 0.65f));
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.Water, 0.8f));
			if (loadedGroupTypeProbabilities != null)
			{
				groupTypeProbabilities = new List<GroupTypeProbability>(loadedGroupTypeProbabilities);
				this.OnGroupTypeProbabilitiesUpdated?.Invoke(obj: true);
			}
			excludedBiomes = loadedExcludedBiomes ?? new List<BiomeId>();
			this.OnReset?.Invoke();
		}

		public void SetGroupTypeProbability(GroupTypeId groupType, float newProbability)
		{
			_003C_003Ec__DisplayClass17_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass17_0();
			CS_0024_003C_003E8__locals2.groupType = groupType;
			Enumerable.First(groupTypeProbabilities, (GroupTypeProbability x) => x.groupType == CS_0024_003C_003E8__locals2.groupType).probability = newProbability;
			this.OnGroupTypeProbabilitiesUpdated?.Invoke(obj: false);
		}

		public void Reset()
		{
			groupTypeProbabilities.Clear();
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.Village, 1f));
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.Forest, 1f));
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.Agriculture, 1f));
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.TrainTracks, 0.65f));
			groupTypeProbabilities.Add(new GroupTypeProbability(GroupTypeId.Water, 0.8f));
			excludedBiomes.Clear();
			this.OnGroupTypeProbabilitiesUpdated?.Invoke(obj: true);
			this.OnReset?.Invoke();
		}

		public float GetGroupTypeProbability(GroupTypeId groupType)
		{
			_003C_003Ec__DisplayClass19_0 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass19_0();
			CS_0024_003C_003E8__locals2.groupType = groupType;
			return Enumerable.First(groupTypeProbabilities, (GroupTypeProbability x) => x.groupType == CS_0024_003C_003E8__locals2.groupType).probability;
		}

		public void SetExcludedBiomes(List<BiomeId> excludedBiomes)
		{
			this.excludedBiomes = excludedBiomes;
			this.OnExcludedBiomesUpdated?.Invoke(obj: false);
		}

		public void SetWorldBorder(int bounds)
		{
			creativeModeWorldBorder = bounds;
		}
	}
}
