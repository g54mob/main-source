using System;
using System.Collections.Generic;
using UnityEngine;

namespace UMA
{
	[Serializable]
	public sealed class DNAEvaluationGraphPresetLibrary : ScriptableObject
	{
		[SerializeField]
		private List<DNAEvaluationGraph> _customGraphPresets;

		[SerializeField]
		private List<string> _customGraphTooltips;

		public static List<DNAEvaluationGraph> DefaultGraphPresets => null;

		public static List<string> DefaultGraphTooltips => null;

		public List<DNAEvaluationGraph> CustomGraphPresets => null;

		public List<string> CustomGraphTooltips => null;
	}
}
