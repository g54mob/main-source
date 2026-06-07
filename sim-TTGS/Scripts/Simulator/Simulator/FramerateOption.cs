using System;
using System.Collections.ObjectModel;
using Dhs5.Utility.Settings;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public class FramerateOption
	{
		[SerializeField]
		private int[] m_framerateAvailable;

		[SerializeField]
		private PlayerPrefInt m_frameRate;

		public ReadOnlyCollection<int> GetAvailableFrameRates()
		{
			return new ReadOnlyCollection<int>(m_framerateAvailable);
		}

		public int Get()
		{
			return m_frameRate.Value;
		}

		public void Set(int value)
		{
			m_frameRate.Value = value;
			SetApplicationTargetFrameRate(value);
		}

		public void Load()
		{
			m_frameRate.Load();
			SetApplicationTargetFrameRate(m_frameRate.Value);
		}

		public void Reset()
		{
			m_frameRate.Reset();
			SetApplicationTargetFrameRate(m_frameRate.Value);
		}

		private void SetApplicationTargetFrameRate(int frameRate)
		{
			Application.targetFrameRate = frameRate;
		}
	}
}
