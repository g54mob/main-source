using System;

namespace Lightbug.CharacterControllerPro.Implementation
{
	[Serializable]
	public struct CharacterActions
	{
		public BoolAction jump;

		public BoolAction run;

		public BoolAction interact;

		public BoolAction jetPack;

		public BoolAction dash;

		public BoolAction crouch;

		public FloatAction pitch;

		public FloatAction roll;

		public Vector2Action movement;

		public void Reset()
		{
			jump.Reset();
			run.Reset();
			interact.Reset();
			jetPack.Reset();
			dash.Reset();
			crouch.Reset();
			pitch.Reset();
			roll.Reset();
			movement.Reset();
		}

		public void InitializeActions()
		{
			jump = default(BoolAction);
			jump.Initialize();
			run = default(BoolAction);
			run.Initialize();
			interact = default(BoolAction);
			interact.Initialize();
			jetPack = default(BoolAction);
			jetPack.Initialize();
			dash = default(BoolAction);
			dash.Initialize();
			crouch = default(BoolAction);
			crouch.Initialize();
			pitch = default(FloatAction);
			roll = default(FloatAction);
			movement = default(Vector2Action);
		}

		public void SetValues(InputHandler inputHandler)
		{
			if (!(inputHandler == null))
			{
				jump.value = inputHandler.GetBool("Jump");
				run.value = inputHandler.GetBool("Run");
				interact.value = inputHandler.GetBool("Interact");
				jetPack.value = inputHandler.GetBool("Jet Pack");
				dash.value = inputHandler.GetBool("Dash");
				crouch.value = inputHandler.GetBool("Crouch");
				pitch.value = inputHandler.GetFloat("Pitch");
				roll.value = inputHandler.GetFloat("Roll");
				movement.value = inputHandler.GetVector2("Movement");
			}
		}

		public void SetValues(CharacterActions characterActions)
		{
			jump.value = characterActions.jump.value;
			run.value = characterActions.run.value;
			interact.value = characterActions.interact.value;
			jetPack.value = characterActions.jetPack.value;
			dash.value = characterActions.dash.value;
			crouch.value = characterActions.crouch.value;
			pitch.value = characterActions.pitch.value;
			roll.value = characterActions.roll.value;
			pitch.value = characterActions.pitch.value;
			roll.value = characterActions.roll.value;
			movement.value = characterActions.movement.value;
		}

		public void Update(float dt)
		{
			jump.Update(dt);
			run.Update(dt);
			interact.Update(dt);
			jetPack.Update(dt);
			dash.Update(dt);
			crouch.Update(dt);
		}
	}
}
