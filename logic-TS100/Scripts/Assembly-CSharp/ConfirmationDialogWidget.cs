using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class ConfirmationDialogWidget : MonoBehaviour
{
	public Text HeadingText;

	public Button ConfirmButton;

	public Text ConfirmButtonText;

	public Button CancelButton;

	public Text CancelButtonText;

	private Action _0023_003Dqajgz9diw_0024JcovwEZwa_0024o7w_003D_003D;

	private Action _0023_003DqO9WxqrQwC4NM9rpcBx4ZGQ_003D_003D;

	public ConfirmationDialogWidget()
	{
		int num = 7;
		if (1 == 0)
		{
		}
		base._002Ector();
	}

	private void Start()
	{
		int num = 4;
		if (5 == 0)
		{
		}
		Button.ButtonClickedEvent onClick = ConfirmButton.onClick;
		int num2 = 5;
		if (7 == 0)
		{
		}
		onClick.AddListener(delegate
		{
			int num3 = 5;
			if (1 == 0)
			{
			}
			_0023_003Dqajgz9diw_0024JcovwEZwa_0024o7w_003D_003D();
		});
		int num4 = 4;
		if (7 == 0)
		{
		}
		CancelButton.onClick.AddListener(delegate
		{
			int num5 = 3;
			if (7 == 0)
			{
			}
			_0023_003DqO9WxqrQwC4NM9rpcBx4ZGQ_003D_003D();
		});
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			int num = 1;
			if (1 == 0)
			{
			}
			_0023_003DqO9WxqrQwC4NM9rpcBx4ZGQ_003D_003D();
		}
	}

	public void Initialize(string _0023_003DqPqZEs5UtcjJXo1TTmwpg_g_003D_003D, string _0023_003DqUw9U0ZroT1dfOetZLlxOXA_003D_003D, string _0023_003DqnXLRq2dlkENdOHRhvmM_xA_003D_003D, Action _0023_003Dqx5sfY_0024tDKjdxvXd_0024xD8_pw_003D_003D, Action _0023_003DqyL50F62yPj49JUS6gy7TKg_003D_003D)
	{
		HeadingText.text = _0023_003DqPqZEs5UtcjJXo1TTmwpg_g_003D_003D;
		ConfirmButtonText.text = _0023_003DqUw9U0ZroT1dfOetZLlxOXA_003D_003D;
		if (8u != 0)
		{
			_0023_003Dqajgz9diw_0024JcovwEZwa_0024o7w_003D_003D = _0023_003Dqx5sfY_0024tDKjdxvXd_0024xD8_pw_003D_003D;
		}
		CancelButtonText.text = _0023_003DqnXLRq2dlkENdOHRhvmM_xA_003D_003D;
		if (6u != 0)
		{
			_0023_003DqO9WxqrQwC4NM9rpcBx4ZGQ_003D_003D = _0023_003DqyL50F62yPj49JUS6gy7TKg_003D_003D;
		}
	}

	private void _0023_003DqH0hWxjrIXhnFb_0024RLIBhJ0_0024lrHFEFejXs40_IyEx1AKc_003D()
	{
		int num = 5;
		if (1 == 0)
		{
		}
		_0023_003Dqajgz9diw_0024JcovwEZwa_0024o7w_003D_003D();
	}

	private void _0023_003DqKIR5COR01_A7L85Yp_0024ifUpc0y7xyBpgINt0erBYAj5Q_003D()
	{
		int num = 3;
		if (7 == 0)
		{
		}
		_0023_003DqO9WxqrQwC4NM9rpcBx4ZGQ_003D_003D();
	}
}
