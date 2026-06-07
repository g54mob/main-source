using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA.CharacterSystem
{
	public class DNAPanel : MonoBehaviour
	{
		public class DNAHolder : IComparable<DNAHolder>
		{
			public string name;

			public float value;

			public int index;

			public UMADnaBase dnaBase;

			public DNAHolder(string Name, float Value, int Index, UMADnaBase DNABase)
			{
			}

			public int CompareTo(DNAHolder other)
			{
				return 0;
			}
		}

		public List<string> Markers;

		public GameObject DnaEditor;

		public Vector3 InitialPos;

		public float YSpacing;

		public bool InvertMarkers;

		public List<GameObject> CreatedObjects;

		public RectTransform ContentArea;

		public void Initialize(DynamicCharacterAvatar Avatar)
		{
		}

		private bool IsThisCategory(string name)
		{
			return false;
		}
	}
}
