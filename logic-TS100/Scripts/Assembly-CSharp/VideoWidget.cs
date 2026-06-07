using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class VideoWidget : MonoBehaviour
{
	private sealed class _0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D
	{
		internal int _0023_003DqEQE2SgWfrLvjkReL0LZ2Kw_003D_003D;

		internal VideoWidget _0023_003DqJQst_o6em6DrTJROR_QbxQ_003D_003D;

		public _0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D()
		{
			int num = 8;
			if (false)
			{
			}
			base._002Ector();
		}

		internal void _0023_003DqnQO8803WD5yBT0zOFBkgmA_003D_003D()
		{
			int num = 0;
			if (3 == 0)
			{
			}
			VideoWidget videoWidget = _0023_003DqJQst_o6em6DrTJROR_QbxQ_003D_003D;
			int num2 = 7;
			if (3 == 0)
			{
			}
			videoWidget._0023_003DqKIkxVPx92dyUwZwDDswJAw_003D_003D(_0023_003DqEQE2SgWfrLvjkReL0LZ2Kw_003D_003D);
		}
	}

	private static readonly Dictionary<KeyCode, int> _0023_003Dq78Vif1T_0024JkaNZXsnkAkhUA_003D_003D;

	public Button EnterButton;

	public Button[] DigitButtons;

	public LinkArrowWidget LinkArrowWidget;

	public RawImage VideoBuffer;

	private _0023_003DqyHYIvmk7OvZghA_0024P8Adskg_003D_003D _0023_003DqJJ_00249CyHjgQnVAptHgtKhI2QMb6HTN2rMN9XDDNNVLZo_003D;

	public VideoWidget()
	{
		int num = -1;
		if (5 == 0)
		{
		}
		base._002Ector();
	}

	static VideoWidget()
	{
		Dictionary<KeyCode, int> dictionary = new Dictionary<KeyCode, int>();
		Dictionary<KeyCode, int> dictionary2;
		if (5u != 0)
		{
			dictionary2 = dictionary;
		}
		dictionary2.Add(KeyCode.KeypadEnter, -1);
		dictionary2.Add(KeyCode.Return, -1);
		dictionary2.Add(KeyCode.Alpha0, 0);
		dictionary2.Add(KeyCode.Keypad0, 0);
		dictionary2.Add(KeyCode.Alpha1, 1);
		dictionary2.Add(KeyCode.Keypad1, 1);
		dictionary2.Add(KeyCode.Alpha2, 2);
		dictionary2.Add(KeyCode.Keypad2, 2);
		dictionary2.Add(KeyCode.Alpha3, 3);
		dictionary2.Add(KeyCode.Keypad3, 3);
		dictionary2.Add(KeyCode.Alpha4, 4);
		dictionary2.Add(KeyCode.Keypad4, 4);
		dictionary2.Add(KeyCode.Alpha5, 5);
		dictionary2.Add(KeyCode.Keypad5, 5);
		dictionary2.Add(KeyCode.Alpha6, 6);
		dictionary2.Add(KeyCode.Keypad6, 6);
		dictionary2.Add(KeyCode.Alpha7, 7);
		dictionary2.Add(KeyCode.Keypad7, 7);
		dictionary2.Add(KeyCode.Alpha8, 8);
		dictionary2.Add(KeyCode.Keypad8, 8);
		dictionary2.Add(KeyCode.Alpha9, 9);
		dictionary2.Add(KeyCode.Keypad9, 9);
		if (true)
		{
			_0023_003Dq78Vif1T_0024JkaNZXsnkAkhUA_003D_003D = dictionary2;
		}
	}

	internal _0023_003DqyHYIvmk7OvZghA_0024P8Adskg_003D_003D _0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()
	{
		int num = 2;
		if (6 == 0)
		{
		}
		return _0023_003DqJJ_00249CyHjgQnVAptHgtKhI2QMb6HTN2rMN9XDDNNVLZo_003D;
	}

	private void _0023_003DquqlzxVAX4hFCswnD0C2JdA_003D_003D(_0023_003DqyHYIvmk7OvZghA_0024P8Adskg_003D_003D _0023_003DqJTB99Z4UdqiKU0ub91V1ng_003D_003D)
	{
		if (3u != 0)
		{
			_0023_003DqJJ_00249CyHjgQnVAptHgtKhI2QMb6HTN2rMN9XDDNNVLZo_003D = _0023_003DqJTB99Z4UdqiKU0ub91V1ng_003D_003D;
		}
	}

	public void Initialize(_0023_003DqyHYIvmk7OvZghA_0024P8Adskg_003D_003D _0023_003DqDq89a6SkjpmpvdX0spoI0Q_003D_003D)
	{
		_0023_003DquqlzxVAX4hFCswnD0C2JdA_003D_003D(_0023_003DqDq89a6SkjpmpvdX0spoI0Q_003D_003D);
		VideoBuffer.texture = _0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003DqdDbqZX9u2dYLDArdQBPlsT_0024ge3_PmQKumxbLv0lkwbs_003D()._0023_003Dqf_tKOiiRzO6Ybpmp6U3nMA_003D_003D();
		VideoBuffer.gameObject.SetActive(true);
		EnterButton.onClick.AddListener(delegate
		{
			int num2 = 0;
			if (3 == 0)
			{
			}
			_0023_003DqKIkxVPx92dyUwZwDDswJAw_003D_003D(-1);
		});
		int num;
		if (uint.MaxValue != 0)
		{
			num = 0;
		}
		for (; num < DigitButtons.Length; num++)
		{
			_0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D obj = new _0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D();
			_0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D _0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D2;
			if (6u != 0)
			{
				_0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D2 = obj;
			}
			if (6u != 0)
			{
				_0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D2._0023_003DqJQst_o6em6DrTJROR_QbxQ_003D_003D = this;
			}
			_0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D2._0023_003DqEQE2SgWfrLvjkReL0LZ2Kw_003D_003D = num;
			DigitButtons[num].onClick.AddListener(_0023_003DqBExGykAow0q9H4rjypFWALUk63s6ie_0024ZpV2inmJ4OY0_003D2._0023_003DqnQO8803WD5yBT0zOFBkgmA_003D_003D);
		}
		Refresh();
	}

	public void Update()
	{
		Dictionary<KeyCode, int>.Enumerator enumerator = _0023_003Dq78Vif1T_0024JkaNZXsnkAkhUA_003D_003D.GetEnumerator();
		Dictionary<KeyCode, int>.Enumerator enumerator2;
		if (8u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			while (enumerator2.MoveNext())
			{
				KeyValuePair<KeyCode, int> current = enumerator2.Current;
				KeyValuePair<KeyCode, int> keyValuePair;
				if (true)
				{
					keyValuePair = current;
				}
				if (Input.GetKeyDown(keyValuePair.Key))
				{
					_0023_003DqKIkxVPx92dyUwZwDDswJAw_003D_003D(keyValuePair.Value);
				}
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		EnterButton.interactable = _0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003Dqj_0024EOPQFoNcaLyzzjEv3DLA_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D();
		DigitButtons._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003DqNkRmASb4wl6NVa8S2fIjeQ_003D_003D);
	}

	public void Refresh()
	{
		Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> dictionary = _0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003Dqj_0024EOPQFoNcaLyzzjEv3DLA_003D_003D._0023_003DqhvRsjbfRKGkkOW9eVsn65KnFdFVZhs0WJQ2B55ErgOs_003D(_0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D());
		Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> _0023_003Dq27_0024C2AWTN1JsSxo6FzmAuQ_003D_003D = default(Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D>);
		if (0 == 0)
		{
			_0023_003Dq27_0024C2AWTN1JsSxo6FzmAuQ_003D_003D = dictionary;
		}
		LinkArrowWidget.SetState(_0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003DqhQzrWsI7qGiDd7x8lZiJmRUBqF1ObFjFVgD9WZBtcXE_003D()._0023_003DqN_qCy57wgKYojVFvaxLO9A_003D_003D, _0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D(), (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1, _0023_003Dq27_0024C2AWTN1JsSxo6FzmAuQ_003D_003D._0023_003DqnjQULvNxRjwSYlkEXLE5cQ_003D_003D((_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1), _0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003Dqj_0024EOPQFoNcaLyzzjEv3DLA_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D());
		LinkArrowWidget.SetLabel(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977740));
	}

	private void _0023_003DqKIkxVPx92dyUwZwDDswJAw_003D_003D(int _0023_003Dqb73UNL4QtSK3K0m_0024WUVgng_003D_003D)
	{
		int num = 3;
		if (3 == 0)
		{
		}
		if (!_0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003Dqj_0024EOPQFoNcaLyzzjEv3DLA_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D())
		{
			return;
		}
		int num2 = 0;
		if (6 == 0)
		{
		}
		if (!_0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003DqhQzrWsI7qGiDd7x8lZiJmRUBqF1ObFjFVgD9WZBtcXE_003D()._0023_003DqN_qCy57wgKYojVFvaxLO9A_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			int num3 = 4;
			if (1 == 0)
			{
			}
			_0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003DqhQzrWsI7qGiDd7x8lZiJmRUBqF1ObFjFVgD9WZBtcXE_003D()._0023_003DqLy8oNSlCNjJQdUm_0024KwMm_Q_003D_003D(_0023_003Dqb73UNL4QtSK3K0m_0024WUVgng_003D_003D);
			Refresh();
		}
	}

	private void _0023_003Dq5dv_0xmP_POucv_0024vVdN6yOTXkK3_b5ufXHbOLxpfnPI_003D()
	{
		int num = 0;
		if (3 == 0)
		{
		}
		_0023_003DqKIkxVPx92dyUwZwDDswJAw_003D_003D(-1);
	}

	private void _0023_003DqNkRmASb4wl6NVa8S2fIjeQ_003D_003D(Button _0023_003DqYntBxRQ2SYADdJthga9tDA_003D_003D)
	{
		int num = 3;
		if (2 == 0)
		{
		}
		int num2 = 4;
		if (3 == 0)
		{
		}
		_0023_003DqYntBxRQ2SYADdJthga9tDA_003D_003D.interactable = _0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D()._0023_003Dqj_0024EOPQFoNcaLyzzjEv3DLA_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D();
	}
}
