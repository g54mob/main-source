using System;
using NewGameplayScripts;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ShowPlantInfoUI : MonoBehaviour
	{
		[SerializeField]
		private Button button;

		private bool plantInfoShowing;

		public event EventHandler OnFirstShowUIButtonClick;

		private void Start()
		{
			button.onClick.AddListener(ShowPlantInfo);
			MovementSystem.Instance.OnStartMovingPlant += PlantInfoShow;
			MovementSystem.Instance.OnStopMovingPlant += PlantInfoHide;
			InputManager instance = InputManager.Instance;
			instance.OnInfoPlant = (Action)Delegate.Combine(instance.OnInfoPlant, new Action(ShowPlantInfo));
		}

		private void PlantInfoHide(object sender, EventArgs e)
		{
			plantInfoShowing = false;
		}

		private void PlantInfoShow(object sender, EventArgs e)
		{
			plantInfoShowing = true;
		}

		private void ShowPlantInfo()
		{
			if (!MovementSystem.Instance.IsMoving())
			{
				this.OnFirstShowUIButtonClick?.Invoke(this, EventArgs.Empty);
				if (plantInfoShowing)
				{
					MovementSystem.Instance.HidePlantInfo();
				}
				else
				{
					MovementSystem.Instance.ShowPlantInfo();
				}
			}
		}

		private void OnDestroy()
		{
			button.onClick.RemoveAllListeners();
			MovementSystem.Instance.OnStartMovingPlant -= PlantInfoShow;
			MovementSystem.Instance.OnStopMovingPlant -= PlantInfoHide;
			InputManager instance = InputManager.Instance;
			instance.OnInfoPlant = (Action)Delegate.Remove(instance.OnInfoPlant, new Action(ShowPlantInfo));
		}
	}
}
