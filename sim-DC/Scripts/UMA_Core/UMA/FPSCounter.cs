using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UMA
{
	public class FPSCounter : MonoBehaviour
	{
		public Text Text;

		private Dictionary<int, string> CachedNumberStrings;

		private int[] _frameRateSamples;

		private int _cacheNumbersAmount;

		private int _averageFromAmount;

		private int _averageCounter;

		private int _currentAveraged;

		public float updateRate;

		public float updateTime;

		private void Awake()
		{
		}

		private void OnGUI()
		{
		}

		private void Update()
		{
		}
	}
}
