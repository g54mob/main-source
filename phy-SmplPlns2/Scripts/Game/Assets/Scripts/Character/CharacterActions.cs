using System;
using Assets.Scripts.Input;
using Lightbug.CharacterControllerPro.Implementation;
using UnityEngine;

namespace Assets.Scripts.Character
{
	[Serializable]
	public struct CharacterActions
	{
		public BoolAction Crouch;

		public BoolAction Dance;

		public BoolAction Jump;

		public Vector2Action Movement;

		public FloatAction MoveX;

		public FloatAction MoveY;

		public BoolAction Run;

		public void InitializeActions()
		{
			Jump = default(BoolAction);
			Jump.Initialize();
			Run = default(BoolAction);
			Run.Initialize();
			Dance = default(BoolAction);
			Dance.Initialize();
			Crouch = default(BoolAction);
			Crouch.Initialize();
			MoveX = default(FloatAction);
			MoveY = default(FloatAction);
			Movement = default(Vector2Action);
		}

		public void Reset()
		{
			Jump.Reset();
			Run.Reset();
			Dance.Reset();
			Crouch.Reset();
			MoveX.Reset();
			MoveY.Reset();
			Movement.Reset();
		}

		public void SetValues(GameInputs gameInputs)
		{
			if (gameInputs != null)
			{
				Jump.value = gameInputs.Jump.GetButtonIfEnabled();
				Run.value = gameInputs.Run.GetButtonIfEnabled();
				Dance.value = gameInputs.Dance.GetButtonIfEnabled();
				Crouch.value = gameInputs.Crouch.GetButtonIfEnabled();
				MoveX.value = gameInputs.MoveX.GetAxisIfEnabled();
				MoveY.value = gameInputs.MoveY.GetAxisIfEnabled();
				Movement.value = new Vector2(MoveX.value, MoveY.value);
			}
		}

		public void SetValues(CharacterActions characterActions)
		{
			Jump.value = characterActions.Jump.value;
			Run.value = characterActions.Run.value;
			Dance.value = characterActions.Dance.value;
			Crouch.value = characterActions.Crouch.value;
			Movement.value = characterActions.Movement.value;
		}

		public void Update(float dt)
		{
			Jump.Update(dt);
			Run.Update(dt);
			Dance.Update(dt);
			Crouch.Update(dt);
		}
	}
}
