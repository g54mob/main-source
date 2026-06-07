using UnityEngine;

public static class _0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D
{
	private static readonly KeyCode[] _0023_003DqMVGZFyBuL4xI18l_Smy3Rg_003D_003D;

	private static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<KeyCode> _0023_003DqWviNqBRNmanKIMM46SSXTw_003D_003D;

	private static float _0023_003Dq6Y3o14eSV66VKV8bDC_0024d8Q_003D_003D;

	private static bool _0023_003DqRqsZMlqj3LidONkNIXTgug_003D_003D;

	static _0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D()
	{
		KeyCode[] obj = new KeyCode[16]
		{
			KeyCode.UpArrow,
			KeyCode.DownArrow,
			KeyCode.LeftArrow,
			KeyCode.RightArrow,
			KeyCode.Backspace,
			KeyCode.Delete,
			KeyCode.Return,
			KeyCode.KeypadEnter,
			KeyCode.Home,
			KeyCode.End,
			KeyCode.PageUp,
			KeyCode.PageDown,
			KeyCode.V,
			KeyCode.Z,
			KeyCode.Y,
			KeyCode.F6
		};
		if (uint.MaxValue != 0)
		{
			_0023_003DqMVGZFyBuL4xI18l_Smy3Rg_003D_003D = obj;
		}
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<KeyCode> obj2 = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
		if (4u != 0)
		{
			_0023_003DqWviNqBRNmanKIMM46SSXTw_003D_003D = obj2;
		}
		if (8u != 0)
		{
			_0023_003Dq6Y3o14eSV66VKV8bDC_0024d8Q_003D_003D = 0f;
		}
		_0023_003DqRqsZMlqj3LidONkNIXTgug_003D_003D = false;
	}

	public static void _0023_003DqTX5l35BFAkwcaSYLo9vSYg_003D_003D()
	{
		if (8u != 0)
		{
			_0023_003DqRqsZMlqj3LidONkNIXTgug_003D_003D = false;
		}
		KeyCode[] array = _0023_003DqMVGZFyBuL4xI18l_Smy3Rg_003D_003D;
		KeyCode[] array2;
		if (4u != 0)
		{
			array2 = array;
		}
		int i;
		if (3u != 0)
		{
			i = 0;
		}
		for (; i < array2.Length; i++)
		{
			KeyCode keyCode = array2[i];
			if (Input.GetKeyDown(keyCode))
			{
				_0023_003DqWviNqBRNmanKIMM46SSXTw_003D_003D = keyCode;
				_0023_003Dq6Y3o14eSV66VKV8bDC_0024d8Q_003D_003D = 0.5f;
				_0023_003DqRqsZMlqj3LidONkNIXTgug_003D_003D = true;
			}
		}
		KeyCode[] array3 = _0023_003DqMVGZFyBuL4xI18l_Smy3Rg_003D_003D;
		foreach (KeyCode keyCode2 in array3)
		{
			if (Input.GetKeyUp(keyCode2) && _0023_003DqWviNqBRNmanKIMM46SSXTw_003D_003D._0023_003DqkuoyTclZnjTlFDx1VFzbvQ_003D_003D(keyCode2))
			{
				_0023_003DqWviNqBRNmanKIMM46SSXTw_003D_003D = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
			}
		}
		if (_0023_003DqWviNqBRNmanKIMM46SSXTw_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			_0023_003Dq6Y3o14eSV66VKV8bDC_0024d8Q_003D_003D -= Time.deltaTime;
			if (_0023_003Dq6Y3o14eSV66VKV8bDC_0024d8Q_003D_003D <= 0f)
			{
				_0023_003DqRqsZMlqj3LidONkNIXTgug_003D_003D = true;
				_0023_003Dq6Y3o14eSV66VKV8bDC_0024d8Q_003D_003D += 0.04f;
			}
		}
	}

	public static bool _0023_003DqF9nL20t9jqtbPAovqyUc4Q_003D_003D(KeyCode _0023_003DqxFEF4pRDWZ6buz7ogUpmdw_003D_003D)
	{
		int num = 0;
		if (1 == 0)
		{
		}
		return _0023_003DqWviNqBRNmanKIMM46SSXTw_003D_003D._0023_003DqkuoyTclZnjTlFDx1VFzbvQ_003D_003D(_0023_003DqxFEF4pRDWZ6buz7ogUpmdw_003D_003D) && _0023_003DqRqsZMlqj3LidONkNIXTgug_003D_003D;
	}

	public static bool _0023_003DqwIxajgIEZTbw14GNhftl9VmaWh3PWUlrg_0024PFtxAjKzc_003D()
	{
		if (_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DquZhlSb0VFv_BBdN_00240sDv5w_003D_003D)
		{
			return (Input.GetKey(KeyCode.LeftCommand) || Input.GetKey(KeyCode.RightCommand)) && !Input.GetKey(KeyCode.RightAlt);
		}
		return (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl)) && !Input.GetKey(KeyCode.RightAlt);
	}

	public static bool _0023_003Dq11Zq4p_0024aono1Gcvwp9mso8Io02_0024g5GbuP23hSS0aR_0024I_003D()
	{
		return Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
	}
}
