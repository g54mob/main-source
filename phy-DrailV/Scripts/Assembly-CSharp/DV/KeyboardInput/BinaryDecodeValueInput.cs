using DV.CabControls;
using DV.CabControls.Spec;
using DV.HUD;
using DV.Interaction.Inputs;
using UnityEngine;

namespace DV.KeyboardInput
{
	public class BinaryDecodeValueInput : AKeyboardInput
	{
		public ActionReference action;

		public ControlSpec targetLeastSignificant;

		public ControlSpec targetMostSignificant;

		private ControlImplBase controlLeast;

		private ControlImplBase controlMost;

		public override bool FixedUpdateTick => false;

		private void Start()
		{
			controlLeast = targetLeastSignificant.GetComponent<ControlImplBase>();
			controlMost = targetMostSignificant.GetComponent<ControlImplBase>();
			if (!controlLeast)
			{
				Debug.LogError("Didn't find controlLeast on " + base.name);
			}
			if (!controlMost)
			{
				Debug.LogError("Didn't find controlMost on " + base.name);
			}
		}

		public override void SetupActions(InteriorControlsManager interiorControlsManager)
		{
			action.Initialize(interiorControlsManager);
		}

		public override void Tick(float deltaTime)
		{
			if (InputManager.NewPlayer.GetAnyDirButtonDown(action.id) && PlayerCanReach())
			{
				int num = 0;
				if (controlLeast.Value > 0.5f)
				{
					num++;
				}
				if (controlMost.Value > 0.5f)
				{
					num += 2;
				}
				int num2 = Mathf.RoundToInt(InputManager.NewPlayer.GetAxis(action.id));
				num = Mathf.Clamp(num + num2, 0, 3);
				bool flag = (num & 1) == 1;
				bool flag2 = ((num >> 1) & 1) == 1;
				if (controlLeast.Value > 0.5f != flag)
				{
					controlLeast.Use();
				}
				if (controlMost.Value > 0.5f != flag2)
				{
					controlMost.Use();
				}
			}
		}
	}
}
