using System;
using AYellowpaper.SerializedCollections;
using Data.FactoryFloor.Resources;
using UnityEngine;

namespace Data.Objectives
{
	[CreateAssetMenu(menuName = "UI/CurrencyUILibrary")]
	public class CurrencyUILibrary : ScriptableObject
	{
		[Serializable]
		public struct CurrencyUI
		{
			public Sprite Sprite;

			public Color Color;
		}

		public SerializedDictionary<NonShapeResourceDataSO, CurrencyUI> CurrencyUIs;
	}
}
