using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using SettingScripts;
using Structs;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Profiling;
using UnityEngine;

namespace SimulationScripts
{
	public class MatterDecayProcessor : MonoBehaviour
	{
		[BurstCompile(FloatMode = FloatMode.Fast, OptimizeFor = OptimizeFor.Performance)]
		private struct DecayProcessJob : IJob
		{
			public MatterDecayOfArrays mdOA;

			public NativeList<PelletToUpdate> pelletsToUpdate;

			public float deltaTime;

			public void Execute()
			{
				using (new ProfilerMarker("Job").Auto())
				{
					NativeArray<bool> nativeArray = new NativeArray<bool>(mdOA.Length, Allocator.Temp);
					NativeArray<float> nativeArray2 = new NativeArray<float>(mdOA.Length, Allocator.Temp);
					using (new ProfilerMarker("Process").Auto())
					{
						for (int i = 0; i < mdOA.Count; i++)
						{
							mdOA.Process(i, deltaTime, out var remove, out var toRemove);
							nativeArray[i] = remove;
							nativeArray2[i] = toRemove;
						}
					}
					using (new ProfilerMarker("Compile").Auto())
					{
						for (int j = 0; j < mdOA.Count; j++)
						{
							if (nativeArray[j])
							{
								pelletsToUpdate.Add(new PelletToUpdate(j, nativeArray2[j]));
							}
						}
					}
				}
			}
		}

		private struct PelletToUpdate
		{
			public float amount;

			public int index;

			public PelletToUpdate(int index, float amount)
			{
				this.amount = amount;
				this.index = index;
			}
		}

		public static MatterDecayProcessor I;

		private List<MatterPellet> pellets = new List<MatterPellet>();

		private Dictionary<MatterPellet, int> pelletIndices = new Dictionary<MatterPellet, int>();

		private MatterDecayOfArrays mdOA;

		private NativeList<PelletToUpdate> pelletsToUpdate;

		private static readonly IntSetting DecayTPS = ScenarioIndependentSettings.Instance.decayTPS;

		private static int decayPeriod = DecayTPS.SubscribeTo<IntSetting, int>(UpdateDecayTPS);

		private int ticksProgress;

		private static void UpdateDecayTPS(int val)
		{
			decayPeriod = val;
		}

		private void Awake()
		{
			I = this;
			mdOA = new MatterDecayOfArrays(100);
			pelletsToUpdate = new NativeList<PelletToUpdate>(100, Allocator.Persistent);
		}

		private void OnDestroy()
		{
			mdOA.Dispose();
			pelletsToUpdate.Dispose();
		}

		private void FixedUpdate()
		{
			ticksProgress++;
			if (ticksProgress < decayPeriod)
			{
				return;
			}
			ticksProgress = 0;
			float deltaTime;
			using (new ProfilerMarker("Init").Auto())
			{
				deltaTime = Time.fixedDeltaTime * (float)decayPeriod;
				pelletsToUpdate.Clear();
			}
			using (new ProfilerMarker("Dispatch").Auto())
			{
				new DecayProcessJob
				{
					mdOA = mdOA,
					pelletsToUpdate = pelletsToUpdate,
					deltaTime = deltaTime
				}.Run();
			}
			using (new ProfilerMarker("Updates").Auto())
			{
				for (int i = 0; i < pelletsToUpdate.Length; i++)
				{
					pellets[pelletsToUpdate[i].index].RemoveAmount(pelletsToUpdate[i].amount);
				}
			}
		}

		public void UpdateAmount(MatterPellet pellet, float amount)
		{
			if (pelletIndices.TryGetValue(pellet, out var value))
			{
				mdOA._amount[value] = pellet.amount;
			}
		}

		public (int index, float decayAmount, float freshTimeRemaining) SetGetSelection(MatterPellet pellet)
		{
			if (!pelletIndices.TryGetValue(pellet, out var value))
			{
				return (index: -1, decayAmount: 0f, freshTimeRemaining: 0f);
			}
			return (index: value, decayAmount: mdOA._decayAmount[value], freshTimeRemaining: mdOA._freshTimeRemaining[value]);
		}

		public bool TryAddUnique(MatterPellet pellet)
		{
			if (mdOA.Disposed)
			{
				return false;
			}
			if (pelletIndices.ContainsKey(pellet))
			{
				return false;
			}
			if (mdOA.Count > mdOA.Length - 1)
			{
				mdOA.Upsize();
			}
			pelletIndices.Add(pellet, mdOA.Count);
			pellets.Add(pellet);
			pellet.AfterAmountChange.AddListener(UpdateAmount);
			mdOA._amount[mdOA.Count] = pellet.amount;
			mdOA._freshTimeRemaining[mdOA.Count] = pellet.material.freshTime;
			mdOA._decayAmount[mdOA.Count] = 0f;
			mdOA._decayRate[mdOA.Count] = pellet.material.decayRate;
			mdOA.Count++;
			return true;
		}

		public bool TryRemove(MatterPellet pellet)
		{
			if (mdOA.Disposed)
			{
				return false;
			}
			if (!pelletIndices.TryGetValue(pellet, out var value))
			{
				return false;
			}
			pellets.RemoveAtSwapBack(value);
			pelletIndices.Remove(pellet);
			if (pellets.Count > value)
			{
				pelletIndices[pellets[value]] = value;
			}
			pellet.AfterAmountChange.RemoveListener(UpdateAmount);
			mdOA._amount[value] = mdOA._amount[mdOA.Count - 1];
			mdOA._decayAmount[value] = mdOA._decayAmount[mdOA.Count - 1];
			mdOA._freshTimeRemaining[value] = mdOA._freshTimeRemaining[mdOA.Count - 1];
			mdOA._decayRate[value] = mdOA._decayRate[mdOA.Count - 1];
			mdOA.Count--;
			return true;
		}

		public JToken TryGetState(MatterPellet pellet)
		{
			if (!pelletIndices.TryGetValue(pellet, out var value))
			{
				return null;
			}
			return new JObject
			{
				["timeAlive"] = pellet.material.freshTime - mdOA._freshTimeRemaining[value],
				["rotAmount"] = mdOA._decayAmount[value]
			};
		}

		public bool TrySetState(MatterPellet pellet, JObject state)
		{
			if (!pelletIndices.TryGetValue(pellet, out var value))
			{
				return false;
			}
			mdOA._freshTimeRemaining[value] = pellet.material.freshTime - (float)state["timeAlive"];
			mdOA._decayAmount[value] = (float)state["rotAmount"];
			return true;
		}

		public void UpdateDecayParameters(MatterMaterial mat, float freshTimeDif)
		{
			for (int i = 0; i < mdOA.Count; i++)
			{
				if (!(pellets[i].material != mat))
				{
					mdOA._freshTimeRemaining[i] += freshTimeDif;
					mdOA._decayRate[i] = pellets[i].material.decayRate;
				}
			}
		}
	}
}
