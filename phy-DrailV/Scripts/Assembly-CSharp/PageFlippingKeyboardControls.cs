using DV.Interaction.Inputs;
using UnityEngine;

public class PageFlippingKeyboardControls : MonoBehaviour
{
	[Tooltip("Hold Left Shift")]
	public int flipMultiplePages = 3;

	private PageBook _pagebook;

	private PageBook pagebook
	{
		get
		{
			if (!_pagebook)
			{
				_pagebook = GetComponent<PageBook>();
			}
			return _pagebook;
		}
	}

	private void Update()
	{
		int num = (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.FlipPage) ? 1 : (InputManager.NewPlayer.GetNegativeButtonDown(InputManager.Actions.FlipPage) ? (-1) : 0));
		if (InputManager.NewPlayer.GetButton(InputManager.Actions.FlipMultiplePagesModifier))
		{
			num *= flipMultiplePages;
		}
		if (num != 0)
		{
			pagebook.FlipBy(num);
		}
	}
}
