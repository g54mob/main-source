using System;
using System.Collections.Generic;
using System.Linq;
using ScriptHelpers;
using SimulationScripts;
using SimulationScripts.BibiteScripts;
using UnityEngine;
using Utility;

namespace ManagementScripts
{
	public class BibiteTracker : MonoBehaviour, ISaveableBin
	{
		public static BibiteTracker instance;

		public List<BibiteBody> bibites = new List<BibiteBody>();

		public List<EggHatching> eggs = new List<EggHatching>();

		public readonly FloatRollingQuantileEstimator deathAgesQuantiles = new FloatRollingQuantileEstimator(3, 20, 0.05f);

		public int nBirth;

		public int nDeath;

		public SaveableBinStack saveableStack;

		public BibiteGenes[] allGenes => bibites.Select((BibiteBody b) => b.gene).Union(eggs.Select((EggHatching e) => e.eggGene)).ToArray();

		public NEATBrain[] allBrains => bibites.Select((BibiteBody b) => b.brain).Union(eggs.Select((EggHatching e) => e.eggBrain)).ToArray();

		private void Awake()
		{
			instance = this;
			saveableStack = new SaveableBinStack
			{
				stack = new List<ISaveableBin> { deathAgesQuantiles }
			};
		}

		public DataPoint3 GetCountData(bool peek)
		{
			return new DataPoint3(bibites.Count + eggs.Count, PlantCounter.Count, MeatCounter.Count);
		}

		public DataPoint4 GetBiomassData(bool peek)
		{
			return new DataPoint4(bibites.Sum((BibiteBody b) => b.totalEnergy) + eggs.Sum((EggHatching e) => e.energy), (float)PlantCounter.Biomass, (float)MeatCounter.Biomass, ZoneManager.instance.freeBiomass);
		}

		public DataPoint6 GetBrainSizeData(bool peek)
		{
			if (allBrains.Length < 1)
			{
				return new DataPoint6(0f, 0f, 0f, 0f, 0f, 0f);
			}
			int num = int.MaxValue;
			int num2 = 0;
			int num3 = 0;
			int num4 = int.MaxValue;
			int num5 = 0;
			int num6 = 0;
			NEATBrain[] array = allBrains;
			foreach (NEATBrain obj in array)
			{
				int nActiveNodes = obj.nActiveNodes;
				int nSynaps = obj.nSynaps;
				num2 += nActiveNodes;
				if (nActiveNodes < num)
				{
					num = nActiveNodes;
				}
				if (nActiveNodes > num3)
				{
					num3 = nActiveNodes;
				}
				num5 += nSynaps;
				if (nSynaps < num4)
				{
					num4 = nSynaps;
				}
				if (nSynaps > num6)
				{
					num6 = nSynaps;
				}
			}
			int num7 = bibites.Count + eggs.Count;
			return new DataPoint6(num, (float)num2 / (float)num7, num3, num4, (float)num5 / (float)num7, num6);
		}

		public GenesBuckets GetCurrentGenesBuckets(bool peek)
		{
			return new GenesBuckets(allGenes);
		}

		public DataPoint4 GetAgeData(bool peek)
		{
			float num = 0f;
			if (bibites.Count < 1)
			{
				return new DataPoint4(0f, 0f, 0f, 0f);
			}
			float[] array = bibites.Select((BibiteBody b) => b.age).ToArray();
			Array.Sort(array);
			int num2 = array.Length;
			for (int num3 = 0; num3 < num2; num3++)
			{
				float num4 = array[num3];
				num += num4;
			}
			return new DataPoint4(array[num2 / 4], array[num2 / 2], array[3 * num2 / 4], array[num2 - 1]);
		}

		public DataPoint4 GetAgeOfDeathData(bool peek)
		{
			DataPoint4 result = new DataPoint4(deathAgesQuantiles.GetQuantile(0.25f), deathAgesQuantiles.GetQuantile(0.5f), deathAgesQuantiles.GetQuantile(0.75f), deathAgesQuantiles.GetQuantile(1f));
			if (!peek)
			{
				deathAgesQuantiles.IncrementRollCounter();
			}
			return result;
		}

		public DataPoint6 GetEggLaidData(bool peek)
		{
			if (bibites.Count < 1)
			{
				return new DataPoint6(0f, 0f, 0f, 0f, 0f, 0f);
			}
			int[] array = bibites.Select((BibiteBody b) => b.eggLayer.nEggsLaid).ToArray();
			Array.Sort(array);
			int num = array.Length;
			float num2 = array.Sum((int v) => v);
			return new DataPoint6(array[num / 2], array[7 * num / 10], array[8 * num / 10], array[9 * num / 10], array[num - 1], num2 / (float)num);
		}

		public DataPoint2 GetBirthDeathCount(bool peek)
		{
			DataPoint2 result = new DataPoint2(nBirth, nDeath);
			if (!peek)
			{
				nBirth = (nDeath = 0);
			}
			return result;
		}

		public void BibiteBirth(BibiteBody bibite)
		{
			bibites.Add(bibite);
			nBirth++;
		}

		public void BibiteDeath(BibiteBody bibite)
		{
			if (bibites.Contains(bibite))
			{
				bibites.Remove(bibite);
				nDeath++;
				deathAgesQuantiles.Add(bibite.age);
			}
		}

		public int BytesSpace()
		{
			return 8 + saveableStack.BytesSpace();
		}

		public byte[] SaveStateBin(byte[] bytes = null, int offset = 0)
		{
			if (bytes == null)
			{
				bytes = new byte[BytesSpace()];
				offset = 0;
			}
			Buffer.BlockCopy(BitConverter.GetBytes(nBirth), 0, bytes, offset, 4);
			Buffer.BlockCopy(BitConverter.GetBytes(nDeath), 0, bytes, offset + 4, 4);
			return saveableStack.SaveStateBin(bytes, offset + 8);
		}

		public void LoadStateBin(byte[] bytes, Utility.Version version, int offset = 0, int nBytes = -1)
		{
			if (nBytes < 1)
			{
				nBytes = bytes.Length;
			}
			if (nBytes != 0)
			{
				if (version >= new Utility.Version(0, 6, 0, 9))
				{
					nBirth = BitConverter.ToInt32(bytes, offset);
					nDeath = BitConverter.ToInt32(bytes, offset + 4);
					offset += 8;
				}
				saveableStack.LoadStateBin(bytes, version, offset, nBytes);
			}
		}
	}
}
