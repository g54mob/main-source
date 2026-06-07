using System;
using Data.FactoryFloor;
using UnityEngine;

namespace Logic.Factory
{
	[CreateAssetMenu(menuName = "Factory/Tools/CurrentEditingFactoryLayer", fileName = "CurrentEditingFactoryLayer", order = 0)]
	public class CurrentFactoryLayer : ScriptableObject
	{
		[SerializeField]
		private FactoryLayer _defaultEditingLayer;

		private FactoryLayer _currentFactoryLayer;

		public FactoryLayer Value
		{
			get
			{
				if (!(_currentFactoryLayer != null))
				{
					return _defaultEditingLayer;
				}
				return _currentFactoryLayer;
			}
		}

		public event Action<FactoryLayer> CurrentEditingFactoryLayerChanged;

		private void OnEnable()
		{
			_currentFactoryLayer = _defaultEditingLayer;
		}

		public void SetFactoryLayer(FactoryLayer factoryLayer)
		{
			_currentFactoryLayer = factoryLayer;
			this.CurrentEditingFactoryLayerChanged?.Invoke(factoryLayer);
		}
	}
}
