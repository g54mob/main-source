using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Flight.WorldObjects.Vehicles.Land.Convoy
{
	public class RandomConvoyProviderScript : ConvoyProviderScript
	{
		[Serializable]
		private class ConvoySegment
		{
			[SerializeField]
			private string _convoySegmentName;

			[SerializeField]
			private int _maxNumber = 1;

			[SerializeField]
			private int _minNumber;

			[SerializeField]
			[Range(0f, 1f)]
			private float _skipChance;

			[SerializeField]
			private GameObject _vehiclePrefab;

			public int MaxNumber => _maxNumber;

			public int MinNumber => _minNumber;

			public float SkipChance => _skipChance;

			public GameObject VehiclePrefab => _vehiclePrefab;

			public override string ToString()
			{
				return _convoySegmentName ?? base.ToString();
			}
		}

		[SerializeField]
		private ConvoySegment[] _convoySegments;

		public bool AlwaysMaxSize { get; set; }

		public override GameObject[] GetConvoyPrefabs()
		{
			List<GameObject> list = new List<GameObject>();
			for (int i = 0; i < _convoySegments.Length; i++)
			{
				ConvoySegment convoySegment = _convoySegments[i];
				if (!(UnityEngine.Random.value < convoySegment.SkipChance) || AlwaysMaxSize)
				{
					int num = (AlwaysMaxSize ? convoySegment.MaxNumber : UnityEngine.Random.Range(convoySegment.MinNumber, convoySegment.MaxNumber + 1));
					for (int j = 0; j < num; j++)
					{
						list.Add(convoySegment.VehiclePrefab);
					}
				}
			}
			return list.ToArray();
		}
	}
}
