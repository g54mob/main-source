using System;
using System.Collections.Generic;
using System.Linq;
using Dhs5.Utility.Settings;
using FMODUnity;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class VolumeOption
	{
		public enum EBus
		{
			MASTER = 0,
			AMB = 1,
			MUSIC = 2,
			SFX = 3,
			UI = 4
		}

		private const string MasterBus = "bus:/";

		[Header("Value range: 0-1")]
		[SerializeField]
		private EnumValues<EBus, PlayerPrefFloat> m_volumes;

		public PlayerPrefFloat Get(EBus bus)
		{
			return m_volumes[bus];
		}

		public void Update()
		{
			RuntimeManager.GetBus("bus:/").setVolume(m_volumes[EBus.MASTER].Value);
			foreach (KeyValuePair<EBus, PlayerPrefFloat> item in m_volumes.Skip(1))
			{
				RuntimeManager.GetBus(string.Format("{0}{1}", "bus:/", item.Key)).setVolume(item.Value);
			}
		}

		public void Load()
		{
			foreach (KeyValuePair<EBus, PlayerPrefFloat> volume in m_volumes)
			{
				volume.Value.Load();
			}
			Update();
		}

		public void Reset()
		{
			foreach (KeyValuePair<EBus, PlayerPrefFloat> volume in m_volumes)
			{
				volume.Value.Reset();
			}
			Update();
		}
	}
}
