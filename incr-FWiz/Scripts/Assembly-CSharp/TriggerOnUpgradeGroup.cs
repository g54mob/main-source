using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerOnUpgradeGroup : MonoBehaviour
{
	[Serializable]
	public class TriggerOnUpgradeGroupItem
	{
		[SerializeField]
		private UpgradeDef _upgrade;

		public bool OnlyTriggerOnInitialUpgrade;

		public UnityEvent Trigger;

		public void Initiate()
		{
		}

		public void Destroy()
		{
		}

		private void OnUpgrade(int levelsDelta)
		{
		}
	}

	[SerializeField]
	private List<TriggerOnUpgradeGroupItem> Triggers;

	private bool _initiated;

	private void Start()
	{
	}

	private void Initiate()
	{
	}

	private void OnDestroy()
	{
	}
}
