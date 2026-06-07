using System;
using System.Collections.Generic;
using System.Linq;
using DV.JObjectExtstensions;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace LocoSim.Implementations.Wheels
{
	public class PoweredWheelsManager : MonoBehaviour
	{
		private const string DEAD_WHEELS_INDICES_SAVE_KEY = "deadIndices";

		public PoweredWheel[] poweredWheels;

		public event Action<PoweredWheel> PoweredWheelKilled;

		public event Action<PoweredWheel> PoweredWheelSetOnFire;

		public event Action<PoweredWheel> PoweredWheelRepaired;

		private void Awake()
		{
			if (poweredWheels.Length > 255)
			{
				Debug.LogError($"There cannot be more than {byte.MaxValue} powered wheels on a single car! Related logic may not work correctly.");
			}
			for (byte b = 0; b < poweredWheels.Length; b++)
			{
				poweredWheels[b].index = b;
			}
		}

		public int[] GetUndamagedWheelIndexes()
		{
			return (from index in poweredWheels.Select((PoweredWheel pw, int index) => (!pw.IsBroken) ? index : (-1))
				where index >= 0
				select index).ToArray();
		}

		public void SetPoweredWheels(int[] wheelIndexes)
		{
			for (int i = 0; i < poweredWheels.Length; i++)
			{
				if (!poweredWheels[i].IsBroken)
				{
					poweredWheels[i].state = PoweredWheel.State.CUT_OUT;
				}
			}
			foreach (int num in wheelIndexes)
			{
				if (num < 0 || num >= poweredWheels.Length)
				{
					Debug.LogError($"Invalid wheel index {num} provided to SetWorkingWheels");
				}
				else if (poweredWheels[num].IsBroken)
				{
					Debug.LogError("Provided index of a broken wheel to SetWorkingWheels");
				}
				else
				{
					poweredWheels[num].state = PoweredWheel.State.IS_POWERED;
				}
			}
		}

		public void KillAllPoweredWheels()
		{
			PoweredWheel[] array = poweredWheels;
			foreach (PoweredWheel poweredWheel in array)
			{
				if (poweredWheel.state != PoweredWheel.State.BROKEN)
				{
					poweredWheel.state = PoweredWheel.State.BROKEN;
					this.PoweredWheelKilled?.Invoke(poweredWheel);
				}
			}
		}

		public void KillOnePoweredWheel(bool setOnFire = false, bool random = true, byte index = 0)
		{
			PoweredWheel poweredWheel = (random ? GetRandomPoweredWheel() : poweredWheels[index]);
			if (!(poweredWheel == null))
			{
				poweredWheel.state = PoweredWheel.State.BROKEN;
				this.PoweredWheelKilled?.Invoke(poweredWheel);
				if (setOnFire)
				{
					this.PoweredWheelSetOnFire?.Invoke(poweredWheel);
				}
			}
		}

		private PoweredWheel GetRandomPoweredWheel()
		{
			List<PoweredWheel> list = poweredWheels.Where((PoweredWheel pw) => pw.IsPowered).ToList();
			int count = list.Count;
			if (count == 0)
			{
				Debug.LogError("Unexpected state: KillOnePoweredWheel executed, but there are no working powered wheels. Ignoring request!");
				return null;
			}
			int index = UnityEngine.Random.Range(0, count);
			return list[index];
		}

		public void RepairAllPoweredWheels()
		{
			PoweredWheel[] array = poweredWheels;
			foreach (PoweredWheel poweredWheel in array)
			{
				RepairPoweredWheel(poweredWheel.index);
			}
		}

		public void RepairPoweredWheel(byte index)
		{
			PoweredWheel poweredWheel = poweredWheels[index];
			if (poweredWheel.IsBroken)
			{
				poweredWheel.state = PoweredWheel.State.CUT_OUT;
				this.PoweredWheelRepaired?.Invoke(poweredWheel);
			}
		}

		public JObject GetSaveStateData()
		{
			List<int> list = null;
			for (int i = 0; i < poweredWheels.Length; i++)
			{
				if (poweredWheels[i].IsBroken)
				{
					if (list == null)
					{
						list = new List<int>();
					}
					list.Add(i);
				}
			}
			if (list == null)
			{
				return null;
			}
			JObject jObject = new JObject();
			jObject.SetIntArray("deadIndices", list.ToArray());
			return jObject;
		}

		public void SetSaveStateData(JObject savedData)
		{
			int[] intArray = savedData.GetIntArray("deadIndices");
			if (intArray != null)
			{
				int num = poweredWheels.Length;
				int[] array = intArray;
				foreach (int num2 in array)
				{
					if (num2 >= num || num2 < 0)
					{
						Debug.LogError(string.Format("Unexpected state: {0}: {1} is out of range. Something is not right, ignoring request.", "deadWheelIndex", num2), this);
					}
					else
					{
						poweredWheels[num2].state = PoweredWheel.State.BROKEN;
					}
				}
			}
			else
			{
				Debug.LogError("Unexpected state: deadWheelsIndices are null, when savedData exists.", this);
			}
		}
	}
}
