using DV.HUD;
using DV.Interaction.Inputs;
using DV.Simulation.Cars;
using DV.Simulation.Controllers;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class FireboxKeyboardInput : AKeyboardInput
	{
		public ActionReference lightFireAction;

		public ActionReference shovelCoalAction;

		private MagicShoveling shovelController;

		private FireboxSimController fireboxController;

		public override bool FixedUpdateTick => false;

		private void Start()
		{
			TrainCar trainCar = TrainCar.Resolve(base.gameObject);
			fireboxController = trainCar?.SimController.firebox;
			if (fireboxController == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find fireboxController, FireboxKeyboardInput won't function properly!");
			}
			shovelController = trainCar?.GetComponent<MagicShoveling>();
			if (shovelController == null)
			{
				Debug.LogError("[" + base.gameObject.GetPath() + "]: couldn't find MagicShoveling, FireboxKeyboardInput won't function properly!");
			}
		}

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			lightFireAction.Initialize(interiorControlsManager);
			shovelCoalAction.Initialize(interiorControlsManager);
		}

		public override void Tick(float deltaTime)
		{
			bool buttonDown = InputManager.NewPlayer.GetButtonDown(lightFireAction.id);
			bool buttonDown2 = InputManager.NewPlayer.GetButtonDown(shovelCoalAction.id);
			if ((buttonDown || buttonDown2) && PlayerCanReach())
			{
				if (buttonDown)
				{
					fireboxController.Ignite();
				}
				else if (buttonDown2)
				{
					shovelController.AddCoalToFirebox(1);
				}
			}
		}
	}
}
