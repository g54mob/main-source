using System;
using UnityEngine;

public class MindstoneInputProvider : MonoBehaviour
{
	public Action OnPostUpdate;

	private int left;

	private int leftBegin;

	private int leftEnd;

	private int right;

	private int rightBegin;

	private int rightEnd;

	private int up;

	private int upBegin;

	private int upEnd;

	private int down;

	private int downBegin;

	private int downEnd;

	private int primary;

	private int primaryBegin;

	private int primaryEnd;

	private int back;

	private int backBegin;

	private int backEnd;

	private int ability1;

	private int ability1Begin;

	private int ability1End;

	private int ability2;

	private int ability2Begin;

	private int ability2End;

	private int bumpLeft;

	private int bumpLeftBegin;

	private int bumpLeftEnd;

	private int bumpRight;

	private int bumpRightBegin;

	private int bumpRightEnd;

	private void Update()
	{
		Binding singleton = Binding.singleton;
		if (singleton.IsPressed(Binding.Action.Left))
		{
			left++;
		}
		if (singleton.IsDown(Binding.Action.Left))
		{
			leftBegin++;
		}
		if (singleton.IsUp(Binding.Action.Left))
		{
			leftEnd++;
		}
		if (singleton.IsPressed(Binding.Action.Right))
		{
			right++;
		}
		if (singleton.IsDown(Binding.Action.Right))
		{
			rightBegin++;
		}
		if (singleton.IsUp(Binding.Action.Right))
		{
			rightEnd++;
		}
		if (singleton.IsPressed(Binding.Action.Up))
		{
			up++;
		}
		if (singleton.IsDown(Binding.Action.Up))
		{
			upBegin++;
		}
		if (singleton.IsUp(Binding.Action.Up))
		{
			upEnd++;
		}
		if (singleton.IsPressed(Binding.Action.Down))
		{
			down++;
		}
		if (singleton.IsDown(Binding.Action.Down))
		{
			downBegin++;
		}
		if (singleton.IsUp(Binding.Action.Down))
		{
			downEnd++;
		}
		if (singleton.IsPressed(Binding.Action.Primary))
		{
			primary++;
		}
		if (singleton.IsDown(Binding.Action.Primary))
		{
			primaryBegin++;
		}
		if (singleton.IsUp(Binding.Action.Primary))
		{
			primaryEnd++;
		}
		if (Input.GetMouseButton(0))
		{
			primary++;
		}
		if (Input.GetMouseButtonDown(0))
		{
			primaryBegin++;
		}
		if (Input.GetMouseButtonUp(0))
		{
			primaryEnd++;
		}
		if (singleton.IsPressed(Binding.Action.Back))
		{
			back++;
		}
		if (singleton.IsDown(Binding.Action.Back))
		{
			backBegin++;
		}
		if (singleton.IsUp(Binding.Action.Back))
		{
			backEnd++;
		}
		if (singleton.IsPressed(Binding.Action.Ability1))
		{
			ability1++;
		}
		if (singleton.IsDown(Binding.Action.Ability1))
		{
			ability1Begin++;
		}
		if (singleton.IsUp(Binding.Action.Ability1))
		{
			ability1End++;
		}
		if (singleton.IsPressed(Binding.Action.Ability2))
		{
			ability2++;
		}
		if (singleton.IsDown(Binding.Action.Ability2))
		{
			ability2Begin++;
		}
		if (singleton.IsUp(Binding.Action.Ability2))
		{
			ability2End++;
		}
		if (singleton.IsPressed(Binding.Action.BumpL))
		{
			bumpLeft++;
		}
		if (singleton.IsDown(Binding.Action.BumpL))
		{
			bumpLeftBegin++;
		}
		if (singleton.IsUp(Binding.Action.BumpL))
		{
			bumpLeftEnd++;
		}
		if (singleton.IsPressed(Binding.Action.BumpR))
		{
			bumpRight++;
		}
		if (singleton.IsDown(Binding.Action.BumpR))
		{
			bumpRightBegin++;
		}
		if (singleton.IsUp(Binding.Action.BumpR))
		{
			bumpRightEnd++;
		}
		FirePostUpdate();
	}

	protected void FirePostUpdate()
	{
		if (OnPostUpdate != null)
		{
			OnPostUpdate();
		}
	}

	public void Clear()
	{
		left = (leftBegin = (leftEnd = 0));
		right = (rightBegin = (rightEnd = 0));
		up = (upBegin = (upEnd = 0));
		down = (downBegin = (downEnd = 0));
		primary = (primaryBegin = (primaryEnd = 0));
		back = (backBegin = (backEnd = 0));
		ability1 = (ability1Begin = (ability1End = 0));
		ability2 = (ability2Begin = (ability2End = 0));
		bumpLeft = (bumpLeftBegin = (bumpLeftEnd = 0));
		bumpRight = (bumpRightBegin = (bumpRightEnd = 0));
	}

	public bool IsLeft()
	{
		return left == 1;
	}

	public bool IsLeftBegin()
	{
		return leftBegin == 1;
	}

	public bool IsLeftEnd()
	{
		return leftEnd == 1;
	}

	public bool IsRight()
	{
		return right == 1;
	}

	public bool IsRightBegin()
	{
		return rightBegin == 1;
	}

	public bool IsRightEnd()
	{
		return rightEnd == 1;
	}

	public bool IsUp()
	{
		return up == 1;
	}

	public bool IsUpBegin()
	{
		return upBegin == 1;
	}

	public bool IsUpEnd()
	{
		return upEnd == 1;
	}

	public bool IsDown()
	{
		return down == 1;
	}

	public bool IsDownBegin()
	{
		return downBegin == 1;
	}

	public bool IsDownEnd()
	{
		return downEnd == 1;
	}

	public bool IsPrimary()
	{
		return primary == 1;
	}

	public bool IsPrimaryBegin()
	{
		return primaryBegin == 1;
	}

	public bool IsPrimaryEnd()
	{
		return primaryEnd == 1;
	}

	public bool IsBack()
	{
		return back == 1;
	}

	public bool IsBackBegin()
	{
		return backBegin == 1;
	}

	public bool IsBackEnd()
	{
		return backEnd == 1;
	}

	public bool IsAbility1()
	{
		return ability1 == 1;
	}

	public bool IsAbility1Begin()
	{
		return ability1Begin == 1;
	}

	public bool IsAbility1End()
	{
		return ability1End == 1;
	}

	public bool IsAbility2()
	{
		return ability2 == 1;
	}

	public bool IsAbility2Begin()
	{
		return ability2Begin == 1;
	}

	public bool IsAbility2End()
	{
		return ability2End == 1;
	}

	public bool IsBumpLeft()
	{
		return bumpLeft == 1;
	}

	public bool IsBumpLeftBegin()
	{
		return bumpLeftBegin == 1;
	}

	public bool IsBumpLeftEnd()
	{
		return bumpLeftEnd == 1;
	}

	public bool IsBumpRight()
	{
		return bumpRight == 1;
	}

	public bool IsBumpRightBegin()
	{
		return bumpRightBegin == 1;
	}

	public bool IsBumpRightEnd()
	{
		return bumpRightEnd == 1;
	}
}
