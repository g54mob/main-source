using Timberborn.Automation;
using Timberborn.BaseComponentSystem;
using Timberborn.Common;
using UnityEngine;

namespace Timberborn.AutomationBuildings
{
	internal class LeverModel : BaseComponent, IAwakableComponent, IStartableComponent, IAutomatorListener
	{
		private Lever _lever;

		private GameObject _onModel;

		private GameObject _offModel;

		public void Awake()
		{
			LeverModelSpec component = GetComponent<LeverModelSpec>();
			_onModel = base.GameObject.FindChild(component.OnModelName);
			_offModel = base.GameObject.FindChild(component.OffModelName);
			_lever = GetComponent<Lever>();
		}

		public void Start()
		{
			UpdateModels();
		}

		public void OnAutomatorStateChanged()
		{
			UpdateModels();
		}

		private void UpdateModels()
		{
			_onModel.SetActive(_lever.IsOn);
			_offModel.SetActive(!_lever.IsOn);
		}
	}
}
