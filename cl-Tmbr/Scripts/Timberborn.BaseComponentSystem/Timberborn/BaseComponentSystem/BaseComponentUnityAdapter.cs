using Timberborn.Common;
using UnityEngine;

namespace Timberborn.BaseComponentSystem
{
	internal class BaseComponentUnityAdapter : MonoBehaviour
	{
		private ComponentCache _componentCache;

		private bool _activated;

		public bool StartIsEnabled { get; private set; }

		private void Awake()
		{
			_componentCache = GetComponent<ComponentCache>();
		}

		private void Start()
		{
			StartIsEnabled = true;
			int count = _componentCache.AllComponents.Count;
			ReadOnlyList<object> allComponents = _componentCache.AllComponents;
			for (int i = 0; i < count; i++)
			{
				if (allComponents[i] is IStartableComponent startableComponent && startableComponent is BaseComponent { Enabled: not false, Started: false } baseComponent)
				{
					startableComponent.Start();
					baseComponent.Started = true;
				}
			}
		}

		private void OnEnable()
		{
			if (!_activated)
			{
				_activated = true;
				_componentCache.SetActive();
			}
		}
	}
}
