using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using SPACE_UTIL;

namespace  SPACE_IP
{
	public class IPKeyboardHeliInput : IPBaseHeliInputs
	{
		protected override void HandleInput()
		{
			this.horizontal = 0f;
			if (INPUT.K.HeldDown(KeyCode.D)) this.horizontal = +1f;
			if (INPUT.K.HeldDown(KeyCode.A)) this.horizontal = -1f;

			this.vertical = 0f;
			if (INPUT.K.HeldDown(KeyCode.W)) this.vertical = +1f;
			if (INPUT.K.HeldDown(KeyCode.S)) this.vertical = -1f;

			this.cyclicInput = new Vector2(this.horizontal, this.vertical);

			this.pedalInput = 0f;
			if (INPUT.K.HeldDown(KeyCode.LeftArrow)) this.pedalInput = +1f;
			if (INPUT.K.HeldDown(KeyCode.RightArrow)) this.pedalInput = -1f;

			this.collectiveInput = 0f;
			if (INPUT.K.HeldDown(KeyCode.UpArrow)) this.collectiveInput = +1f;
			if (INPUT.K.HeldDown(KeyCode.DownArrow)) this.collectiveInput = -1f;

			this.throttleInput = 0f;
			if (INPUT.K.HeldDown(KeyCode.Equals)) this.throttleInput = +1f;
			if (INPUT.K.HeldDown(KeyCode.Minus)) this.throttleInput = -1f;
		}
	}
}