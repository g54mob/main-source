using System;
using System.Collections.Generic;
using DV.Localization;
using DV.ThingTypes;
using UnityEngine;

namespace DV.Customization.Paint
{
	[CreateAssetMenu(fileName = "New Paint Theme", menuName = "DV/Customization/Paint Theme")]
	public class PaintTheme : ScriptableObject
	{
		[Serializable]
		public struct Substitution
		{
			public Material original;

			public Material substitute;
		}

		private static readonly Dictionary<string, PaintTheme> loadedThemes = new Dictionary<string, PaintTheme>();

		[SerializeField]
		private string assetName;

		[SerializeField]
		private string nameLocalizationKey;

		[SerializeField]
		private bool isStrippedSurface;

		[SerializeField]
		private Substitution[] substitutions = Array.Empty<Substitution>();

		[SerializeField]
		private TrainCarLivery[] forbiddenLiveries = Array.Empty<TrainCarLivery>();

		private Dictionary<Material, Substitution> substitutionDictionary;

		public string AssetName => assetName;

		public string LocalizedName => LocalizationAPI.L(nameLocalizationKey);

		public bool IsStrippedSurface => isStrippedSurface;

		public static bool TryLoad(string name, out PaintTheme theme)
		{
			name = name.ToLower();
			if (loadedThemes.TryGetValue(name, out theme))
			{
				return true;
			}
			theme = Resources.Load<PaintTheme>(name);
			loadedThemes.Add(name, theme);
			return theme != null;
		}

		private void OnBeforeAccessed()
		{
			if (substitutionDictionary == null)
			{
				substitutionDictionary = new Dictionary<Material, Substitution>();
				Substitution[] array = substitutions;
				for (int i = 0; i < array.Length; i++)
				{
					Substitution value = array[i];
					substitutionDictionary.Add(value.original, value);
				}
				if (forbiddenLiveries == null)
				{
					forbiddenLiveries = Array.Empty<TrainCarLivery>();
				}
			}
		}

		public bool HasSubstituteFor(Material original)
		{
			OnBeforeAccessed();
			return substitutionDictionary.ContainsKey(original);
		}

		public bool TryGetSubstitute(Material original, out Substitution substitution)
		{
			OnBeforeAccessed();
			return substitutionDictionary.TryGetValue(original, out substitution);
		}

		public bool Allows(TrainCarLivery livery)
		{
			OnBeforeAccessed();
			return Array.IndexOf(forbiddenLiveries, livery) == -1;
		}
	}
}
