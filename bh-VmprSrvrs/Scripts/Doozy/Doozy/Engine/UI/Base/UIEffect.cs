using System;
using UnityEngine;

namespace Doozy.Engine.UI.Base
{
	[Serializable]
	public class UIEffect
	{
		public const DynamicSorting DEFAULT_AUTO_SORT = DynamicSorting.InFront;

		public const UIEffectBehavior DEFAULT_BEHAVIOR = UIEffectBehavior.Play;

		public const int DEFAULT_SORTING_ORDER = 0;

		public const int DEFAULT_SORTING_STEPS = 1;

		public const ParticleSystemStopBehavior DEFAULT_STOP_BEHAVIOR = ParticleSystemStopBehavior.StopEmitting;

		public const string DEFAULT_SORTING_LAYER = "Default";

		public DynamicSorting AutoSort;

		public UIEffectBehavior Behavior;

		public int CustomSortingOrder;

		public int SortingSteps;

		public ParticleSystem ParticleSystem;

		public ParticleSystemStopBehavior StopBehavior;

		public string CustomSortingLayer;

		private Renderer[] m_renderers;

		public ParticleSystem.MainModule MainModule => default(ParticleSystem.MainModule);

		public Renderer[] Renderers => null;

		public string SortingLayerName => null;

		public int SortingOrder => 0;

		public void Clear()
		{
		}

		public void Emit(int count)
		{
		}

		public void Execute()
		{
		}

		public void Execute(string sortingLayer, int sortingOrder)
		{
		}

		public void OverrideSortingAndPlay(string overrideSortingLayer, int overrideSortingOrder)
		{
		}

		public void Play(string sortingLayer, int sortingOrder)
		{
		}

		public void Play()
		{
		}

		public void Reset()
		{
		}

		public bool SetSortingLayer(string sortingLayerName)
		{
			return false;
		}

		public void SetSortingOrder(int sortingOrder)
		{
		}

		public void Stop()
		{
		}

		public void Stop(ParticleSystemStopBehavior stopBehavior)
		{
		}

		public void UpdateSorting(string sortingLayer, int sortingOrder)
		{
		}
	}
}
