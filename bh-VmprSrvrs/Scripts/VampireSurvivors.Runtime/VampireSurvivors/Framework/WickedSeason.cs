using System.Collections.Generic;
using VampireSurvivors.Data;
using Zenject;

namespace VampireSurvivors.Framework
{
	public class WickedSeason
	{
		private SignalBus _signalBus;

		private bool _hasWickedSeason;

		private float _seasonTime;

		private float _seasonDuration;

		private int _seasonIndex;

		private float _curse;

		private float _growth;

		private float _luck;

		private float _greed;

		private readonly List<string> _wickedSeasonAttributes;

		private List<string> _seasonColors;

		private List<string> _seasonIcons;

		private readonly List<SfxType> _seasonSfx;

		public float SeasonDuration => 0f;

		public float Curse => 0f;

		public float Growth => 0f;

		public float Luck => 0f;

		public float Greed => 0f;

		public void Init(SignalBus signalBus)
		{
		}

		public void Update()
		{
		}
	}
}
