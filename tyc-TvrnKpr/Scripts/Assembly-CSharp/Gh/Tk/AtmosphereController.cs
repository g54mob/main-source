using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class AtmosphereController : MonoBehaviour
	{
		public bool enableDebugLogs;

		private AtmosphereHeatMapGenerator _atmosphereHeatMapGenerator;

		internal GenericJobBasedTileSimulation[] _simulations;

		private GUIStyle _toolTipStyle;

		private bool _toolTipEnabled;

		private bool _gradientEnabled;

		public string CurrentEffect
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public event EventHandler<EventArgs<string>> OnGenerationCompleteEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public void Awake()
		{
		}

		internal void UnfreezeAllSimulations()
		{
		}

		public void Start()
		{
		}

		public void OnGUI()
		{
		}

		public void ResetHeatMap()
		{
		}

		public void ToggleTooltip()
		{
		}

		public void ToggleGradient()
		{
		}

		public bool IsGradientEnabled()
		{
			return false;
		}

		public void BroadcastOnGenerationComplete(string effectName)
		{
		}

		public void ShowEquilibriumValues(bool show)
		{
		}
	}
}
