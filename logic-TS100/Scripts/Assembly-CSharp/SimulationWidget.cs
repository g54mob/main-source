using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public sealed class SimulationWidget : MonoBehaviour, _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D
{
	public ComputeTileWidget PrefabComputeTileWidget;

	public DamagedComputeTileWidget PrefabDamagedComputeTileWidget;

	public MemoryTileWidget PrefabMemoryTileWidget;

	public InputWidget PrefabInputWidget;

	public OutputWidget PrefabOutputWidget;

	public ConsoleWidget PrefabConsoleWidget;

	public VideoWidget PrefabVideoWidget;

	public ImageOutputWidget PrefabImageOutputWidget;

	public Button BackgroundHitbox;

	public Button StopButton;

	public Button PlayStepButton;

	public Button StepButton;

	public Button PauseButton;

	public Button PlayButton;

	public Button PlayFastButton;

	public RectTransform InformationPanel;

	public Text InformationText;

	public Text TitleText;

	private int _0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D;

	private bool _0023_003Dq5pjq6a4lmWQGo8hM_eQvBfzqVnU_0024JX58uaK4MQpbOVU_003D;

	private global::_0023_003DqjrwtmPX_V2ykHbKizqDj5UkPjjTi1ZDr8gOZBEBHY9s_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D> _0023_003DqP8Ylb_0024K_0024x83nuK6Wq_002499aw_003D_003D;

	private global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int[]> _0023_003Dq66ws5W31oeJfF6XZo9uSNg_003D_003D;

	private bool _0023_003Dq14u0ZSy0PzZ0zhs4CIqz69yUszhmSD0rsa320VyFpM4_003D;

	private _0023_003DqPyZu3ATELKn3PMEYHnXkLg_003D_003D _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D;

	private List<ComputeTileWidget> _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D;

	private List<DamagedComputeTileWidget> _0023_003Dq86Sg_HtJxZnUPq8uCS2vGBojWXamk9oCc3zw_xIIZlo_003D;

	private List<MemoryTileWidget> _0023_003DqhLKjq415dSONgMm757Le4vRKHqWv9t0hnItRvD3IbTs_003D;

	private List<InputWidget> _0023_003DqwxMUUQndXwrzWhTy8J12VA_003D_003D;

	private List<OutputWidget> _0023_003Dq7yxa04fdiM_0024rPdG49SSA3A_003D_003D;

	private List<ImageOutputWidget> _0023_003DqruzX1CridiR5QjGPwIYSC7UoaukTQq4uMOoM8bITbZg_003D;

	private List<ConsoleWidget> _0023_003DqUGQZ7LRNZo_0024QSpBNDs4RsA_003D_003D;

	private List<VideoWidget> _0023_003Dqhso4z5_HjfYxbGR_0024R89qBw_003D_003D;

	private _0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D _0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D;

	private float _0023_003DqUK9h3kqBdc0_wvRqEO_uRw_003D_003D;

	private global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<float> _0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D;

	private static Func<ComputeTileWidget, bool> _0023_003DqY__0024mWT_0024C4DoQVnFiX_0024awqqL7BsDw5IoF2Oqs8uKGtVE_003D;

	private static Func<ComputeTileWidget, bool> _0023_003DqRcbs_0024pwjsViun4vI1lb2IGThbmXbjAWlkitWa19yshI_003D;

	private static Action<ComputeTileWidget> _0023_003DqwQuTmcO6D2CEDg_qQWWTBE6IIfebpObM0kCDXCVtGIc_003D;

	private static Action<DamagedComputeTileWidget> _0023_003DqSo5YvX6rtb8y8niRPKGMDt8L8_0024Gf12g3_0024Dk_0024lX_0024ULXs_003D;

	private static Action<MemoryTileWidget> _0023_003DqPC4fwR5ZnkLbObHsPQFXjWWEavVmkUFNKbDuH5vCd_0024I_003D;

	private static Action<InputWidget> _0023_003DqLPZikcNyg7MhjDTwFiOx2sPC0SaOzV8U2aaU3cM6VBk_003D;

	private static Action<OutputWidget> _0023_003DqGhlO1E_0024GQhjHGEXQs3LAXQHgKYdSksxek8BY1DFkSFw_003D;

	private static Action<ConsoleWidget> _0023_003DqPzA9d37fUOHhNNW3A9xEJbazuSl6nhIcgY8OvDrVf24_003D;

	private static Action<VideoWidget> _0023_003DqFWwW3VFfRZCYt2pF_0024Q_AY00UgQGiFKYmpTE1Lhk4gsw_003D;

	private static Action<ConsoleWidget> _0023_003DqevNBNIu_0024fa8nvRc6p4t8eGBW_o66gEDFINy0wh1Ixjk_003D;

	private static Func<ComputeTileWidget, int> _0023_003DqHoWYip1Jf05ZQsXy2P0w9yxRZBGtPeXUw4H9_0024CXzhrw_003D;

	private static Func<ComputeTileWidget, global::_0023_003DqxC7QFsWSEOgogypo4aoxkA_003D_003D<string, int, global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int>>> _0023_003DqD8DnoFyeMOQQ6jYIhbfLMiJATcfYOkMQmHX_0024dIi2F6I_003D;

	public SimulationWidget()
	{
		int num = 8;
		if (false)
		{
		}
		base._002Ector();
	}

	private GameObject _0023_003Dqqv4nUZswCtCyIeX4lzF2lVhUcCVtOi6Z1wNK67Bz5Cg_003D()
	{
		int num = 0;
		if (false)
		{
		}
		return base.gameObject;
	}

	GameObject _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D._0023_003DqJaI64gkjCxAvXrUlNIDc_w_003D_003D()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qqv4nUZswCtCyIeX4lzF2lVhUcCVtOi6Z1wNK67Bz5Cg=
		return this._0023_003Dqqv4nUZswCtCyIeX4lzF2lVhUcCVtOi6Z1wNK67Bz5Cg_003D();
	}

	private void _0023_003Dq9BC99UpCwgo4_AdDKA2DBjkyx_0024EOchhKZ6KhjlqExHE_003D()
	{
		if (_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D == (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)2 || _0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D == (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)3)
		{
			float num = ((_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D != (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)2) ? 0.0002f : 0.02f);
			float num2;
			if (2u != 0)
			{
				num2 = num;
			}
			float num3 = _0023_003DqUK9h3kqBdc0_wvRqEO_uRw_003D_003D + Time.deltaTime;
			if (5u != 0)
			{
				_0023_003DqUK9h3kqBdc0_wvRqEO_uRw_003D_003D = num3;
			}
			Stopwatch stopwatch = Stopwatch.StartNew();
			Stopwatch stopwatch2;
			if (3u != 0)
			{
				stopwatch2 = stopwatch;
			}
			while (_0023_003DqUK9h3kqBdc0_wvRqEO_uRw_003D_003D >= num2)
			{
				float num4 = _0023_003DqUK9h3kqBdc0_wvRqEO_uRw_003D_003D - num2;
				if (5u != 0)
				{
					_0023_003DqUK9h3kqBdc0_wvRqEO_uRw_003D_003D = num4;
				}
				_0023_003DqMUXXlb7Bj52E016Ku_0024zqAw_003D_003D();
				if (_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D == (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1 || _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqEEK16_XJObeyTJUzsTL9pg_003D_003D() || stopwatch2.ElapsedMilliseconds > 20)
				{
					break;
				}
			}
			Refresh();
		}
		if (Input.GetKeyDown(KeyCode.Escape) && !_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.ImageBleed.gameObject.activeSelf && !_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.QuantumChat.gameObject.activeSelf)
		{
			if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D())
			{
				_0023_003Dq4Q9DFoRQTrm_EeIdA2wRAV7Cnq5vMkViJjKs8ONwfWI_003D();
			}
			else
			{
				List<ComputeTileWidget> source = _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D;
				if (_0023_003DqY__0024mWT_0024C4DoQVnFiX_0024awqqL7BsDw5IoF2Oqs8uKGtVE_003D == null)
				{
					Func<ComputeTileWidget, bool> func = delegate(ComputeTileWidget _0023_003DqXht77CRRaJTZ1Xs9XkYfzg_003D_003D)
					{
						int num5 = 3;
						if (8 == 0)
						{
						}
						return _0023_003DqXht77CRRaJTZ1Xs9XkYfzg_003D_003D.DesignCode.Focused;
					};
					if (true)
					{
						_0023_003DqY__0024mWT_0024C4DoQVnFiX_0024awqqL7BsDw5IoF2Oqs8uKGtVE_003D = func;
					}
				}
				if (!source.Any(_0023_003DqY__0024mWT_0024C4DoQVnFiX_0024awqqL7BsDw5IoF2Oqs8uKGtVE_003D))
				{
					_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqjUNV2WA6zRwzUvLnMZzaIeARIWwDSBJjwu80qFjpZMA_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D, _0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D);
					return;
				}
				_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqstWalp1v_2B26HzLG9wPxA_003D_003D();
			}
		}
		else if (Input.GetKeyDown(KeyCode.F1))
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqzPnzbDyZXyw4z2nJn6uhxufG4H4QvZhaP3dsEZ1ThBo_003D();
			return;
		}
		if (Input.GetKeyDown(KeyCode.F5) && PlayFastButton.interactable)
		{
			_0023_003DqzTN_Obi9I1EwnLFxVsJUAAsZCkeg5Y6ZAFcAwd9KVe4_003D();
		}
		else if (_0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqF9nL20t9jqtbPAovqyUc4Q_003D_003D(KeyCode.F6))
		{
			if (PlayStepButton.gameObject.activeSelf)
			{
				_0023_003DqO_E_0024xYq8dybzH9hLSFbjHWAUjjKkqKYPfqxzTLPxvMM_003D();
			}
			else if (StepButton.gameObject.activeSelf)
			{
				_0023_003DqXEvVkT_10VG8DfliIMoFPo_0024ybx_RQXWnM55tk7Awn6A_003D();
			}
			else if (PauseButton.gameObject.activeSelf)
			{
				_0023_003Dqj6BjQKHqjvWNNXTGgEhH3_0024uXRN3MhLokwPF5l40Cc84_003D();
			}
		}
		if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003Dq_0024AeKLgodGhrgMNHmCFsdDA_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqK1bjh6rUfnoZNogy2um3H37a6C1IKL8bmZmsg8HaYLI_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003Dq_0024AeKLgodGhrgMNHmCFsdDA_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D(), _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D, false, false, true);
			_0023_003Dq2nzQaR81pssRgjFoxSg8Lw_003D_003D();
			Refresh();
			return;
		}
		if (_0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqwIxajgIEZTbw14GNhftl9VmaWh3PWUlrg_0024PFtxAjKzc_003D() && _0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqF9nL20t9jqtbPAovqyUc4Q_003D_003D(KeyCode.Z))
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D> obj = _0023_003DqP8Ylb_0024K_0024x83nuK6Wq_002499aw_003D_003D._0023_003DqICYUEvGUIDBtP7C0iTQPmw_003D_003D();
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
			if (4u != 0)
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = obj;
			}
			_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003DqeD4A_Dac6VLN8T0c0ucLGg_003D_003D(delegate(_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D _0023_003DqbGYnfAapNXbNLzmLgOsQeA_003D_003D)
			{
				int num6 = 2;
				if (7 == 0)
				{
				}
				int num7 = 5;
				if (4 == 0)
				{
				}
				_0023_003DqZS5g8qoGYF_00241oKJSabtVXA_003D_003D(_0023_003DqbGYnfAapNXbNLzmLgOsQeA_003D_003D);
			});
		}
		else if (_0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqwIxajgIEZTbw14GNhftl9VmaWh3PWUlrg_0024PFtxAjKzc_003D() && _0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqF9nL20t9jqtbPAovqyUc4Q_003D_003D(KeyCode.Y))
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D> obj2 = _0023_003DqP8Ylb_0024K_0024x83nuK6Wq_002499aw_003D_003D._0023_003DqhTn2cWWQ_pB9DQc1_00245S_00241g_003D_003D();
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D3 = default(global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D>);
			if (0 == 0)
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D3 = obj2;
			}
			_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D3._0023_003DqeD4A_Dac6VLN8T0c0ucLGg_003D_003D(_0023_003Dq7tlrt9RDZBg0ztQx4LpmpDFehcp7R042dNa6WPBOLlk_003D);
		}
		if (_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D == (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)0 && _0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqwIxajgIEZTbw14GNhftl9VmaWh3PWUlrg_0024PFtxAjKzc_003D())
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D> obj3 = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4;
			if (2u != 0)
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4 = obj3;
			}
			if (_0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqF9nL20t9jqtbPAovqyUc4Q_003D_003D(KeyCode.LeftArrow))
			{
				global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D> obj4 = (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)2;
				if (0 == 0)
				{
					_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4 = obj4;
				}
			}
			if (_0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqF9nL20t9jqtbPAovqyUc4Q_003D_003D(KeyCode.RightArrow))
			{
				global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D> obj5 = (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)3;
				if (8u != 0)
				{
					_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4 = obj5;
				}
			}
			if (_0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqF9nL20t9jqtbPAovqyUc4Q_003D_003D(KeyCode.UpArrow))
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4 = (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0;
			}
			if (_0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqF9nL20t9jqtbPAovqyUc4Q_003D_003D(KeyCode.DownArrow))
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4 = (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1;
			}
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqA3vR1YBIz8dlWCRPiJMK7BgaDAMKe_SRDaoukstcVlI_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
				{
					foreach (ComputeTileWidget item in _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D)
					{
						if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqA3vR1YBIz8dlWCRPiJMK7BgaDAMKe_SRDaoukstcVlI_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D() != item.DesignCode)
						{
							continue;
						}
						Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> dictionary = _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqhvRsjbfRKGkkOW9eVsn65KnFdFVZhs0WJQ2B55ErgOs_003D(item._0023_003Dq7PfqCTV7lzc0jhlzstptycPP29noPuSrZMFA_iYSItM_003D());
						if (!dictionary.ContainsKey(_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()))
						{
							continue;
						}
						foreach (ComputeTileWidget item2 in _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D)
						{
							if (item2._0023_003Dq7PfqCTV7lzc0jhlzstptycPP29noPuSrZMFA_iYSItM_003D() == dictionary[_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()]._0023_003DqUIebbSuaawrtuMsvKzUEDQ_003D_003D)
							{
								_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq5z7kCOu_0024fCu89yUDVL2AnQ_003D_003D(item2.DesignCode);
								goto end_IL_03df;
							}
						}
						continue;
						end_IL_03df:
						break;
					}
				}
				else
				{
					if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqXqTzkZ4or0BnFKuOtYvRShjo7YXnDODHybPAlcH8Ino_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
					{
						List<ComputeTileWidget> source2 = _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D;
						if (_0023_003DqRcbs_0024pwjsViun4vI1lb2IGThbmXbjAWlkitWa19yshI_003D == null)
						{
							_0023_003DqRcbs_0024pwjsViun4vI1lb2IGThbmXbjAWlkitWa19yshI_003D = delegate(ComputeTileWidget _0023_003DqSb1wJtfIHUH2ftLKH7NeNA_003D_003D)
							{
								int num8 = 7;
								if (false)
								{
								}
								return _0023_003DqSb1wJtfIHUH2ftLKH7NeNA_003D_003D.DesignCode == _0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqXqTzkZ4or0BnFKuOtYvRShjo7YXnDODHybPAlcH8Ino_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D();
							};
						}
						if (source2.Any(_0023_003DqRcbs_0024pwjsViun4vI1lb2IGThbmXbjAWlkitWa19yshI_003D))
						{
							_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq5z7kCOu_0024fCu89yUDVL2AnQ_003D_003D(_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqXqTzkZ4or0BnFKuOtYvRShjo7YXnDODHybPAlcH8Ino_003D);
							goto IL_0459;
						}
					}
					_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq5z7kCOu_0024fCu89yUDVL2AnQ_003D_003D(_0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D[0].DesignCode);
				}
			}
		}
		goto IL_0459;
		IL_0459:
		if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqEEK16_XJObeyTJUzsTL9pg_003D_003D())
		{
			if (_0023_003Dq14u0ZSy0PzZ0zhs4CIqz69yUszhmSD0rsa320VyFpM4_003D)
			{
				return;
			}
			_0023_003Dq14u0ZSy0PzZ0zhs4CIqz69yUszhmSD0rsa320VyFpM4_003D = true;
			if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003DqGRWaTqqF9F_mqQKVziggRA_003D_003D && !_0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DquyZwUeaj92PIujIn_o0_0024tuNZ5mXsNDdcE7HDC2fNPEs_003D())
			{
				if (_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D != (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1)
				{
					_0023_003DqzyNp4RVxB4DUZnOuTlr17Q_003D_003D._0023_003DqLpkqFbWZurI0jfH9QDlRsw_003D_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqxA8yf1Gdk1qf8iQwTxbS2Q_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqRbNYUmaIHMBXVXYAvMK45w_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqQcd0_L0X74bm3x7N1fZNJQDmbe6cmX3L5vFuIgSGuX8_003D());
					_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003Dq7vLpEIAmAdV5CY4Ot__0024n6Q_003D_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D, _0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D, _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqxA8yf1Gdk1qf8iQwTxbS2Q_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqRbNYUmaIHMBXVXYAvMK45w_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqQcd0_L0X74bm3x7N1fZNJQDmbe6cmX3L5vFuIgSGuX8_003D());
					_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1;
					_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.ImageBleed.StartAnimation();
				}
			}
			else if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003DqNZZYHyzf2QMrXOmxwyJOtdY6KUCSja8_00246GDj8lJ9wOA_003D && !_0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003Dq1OD_0024e3YXUhBwhO3D9D8kQaSl_0024bVNtaVVxXIAw_oZaxY_003D())
			{
				if (_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D != (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1)
				{
					_0023_003DqzyNp4RVxB4DUZnOuTlr17Q_003D_003D._0023_003DqLpkqFbWZurI0jfH9QDlRsw_003D_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqxA8yf1Gdk1qf8iQwTxbS2Q_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqRbNYUmaIHMBXVXYAvMK45w_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqQcd0_L0X74bm3x7N1fZNJQDmbe6cmX3L5vFuIgSGuX8_003D());
					_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003Dq7vLpEIAmAdV5CY4Ot__0024n6Q_003D_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D, _0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D, _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqxA8yf1Gdk1qf8iQwTxbS2Q_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqRbNYUmaIHMBXVXYAvMK45w_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqQcd0_L0X74bm3x7N1fZNJQDmbe6cmX3L5vFuIgSGuX8_003D());
					_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1;
					_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.QuantumChat.StartAnimation();
				}
			}
			else if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003Dq_00246oKMAip73sL7doz_CtwQQ_003D_003D && !_0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DqnIvLJD3i1ya09_0024y4zVWF67lItM4wAmFuZASom0oo1xM_003D())
			{
				_0023_003DqsCSLFGQxOw3sji9AQby5g6lgpgU2psLQqla1ooMgpwk_003D._0023_003Dq2xxge1VoBuMb7e5d31I9Zn5SSgJ9sktyNZGxMmAQAsI_003D();
				_0023_003DqzyNp4RVxB4DUZnOuTlr17Q_003D_003D._0023_003DqLpkqFbWZurI0jfH9QDlRsw_003D_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqxA8yf1Gdk1qf8iQwTxbS2Q_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqRbNYUmaIHMBXVXYAvMK45w_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqQcd0_L0X74bm3x7N1fZNJQDmbe6cmX3L5vFuIgSGuX8_003D());
				_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003Dq7vLpEIAmAdV5CY4Ot__0024n6Q_003D_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D, _0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D, _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqxA8yf1Gdk1qf8iQwTxbS2Q_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqRbNYUmaIHMBXVXYAvMK45w_003D_003D(), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqQcd0_L0X74bm3x7N1fZNJQDmbe6cmX3L5vFuIgSGuX8_003D());
				_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqK1bjh6rUfnoZNogy2um3H37a6C1IKL8bmZmsg8HaYLI_003D(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694017228), _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D, false, true, false);
			}
			else
			{
				_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003Dqk_0024LEh_0024_as90CHbSGerdF0awgFBETT0t1oU1PojPA7sw_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D, _0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D, _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D, _0023_003Dq2nzQaR81pssRgjFoxSg8Lw_003D_003D);
			}
		}
		else
		{
			_0023_003Dq14u0ZSy0PzZ0zhs4CIqz69yUszhmSD0rsa320VyFpM4_003D = false;
		}
	}

	void _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D._0023_003DqV9WY5da_ySQ1wPlaJijNDg_003D_003D()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=q9BC99UpCwgo4_AdDKA2DBjkyx$EOchhKZ6KhjlqExHE=
		this._0023_003Dq9BC99UpCwgo4_AdDKA2DBjkyx_0024EOchhKZ6KhjlqExHE_003D();
	}

	public void Start()
	{
		int num = 1;
		if (false)
		{
		}
		Button.ButtonClickedEvent onClick = BackgroundHitbox.onClick;
		int num2 = 4;
		if (6 == 0)
		{
		}
		onClick.AddListener(delegate
		{
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqstWalp1v_2B26HzLG9wPxA_003D_003D();
		});
		int num3 = 7;
		if (-1 == 0)
		{
		}
		StopButton.onClick.AddListener(_0023_003Dq4Q9DFoRQTrm_EeIdA2wRAV7Cnq5vMkViJjKs8ONwfWI_003D);
		PlayStepButton.onClick.AddListener(delegate
		{
			int num4 = 2;
			if (false)
			{
			}
			_0023_003DqJs3ws8xoUU8YoTd0SRuisQ_003D_003D((_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1);
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
			int num5 = 8;
			if (5 == 0)
			{
			}
			Refresh();
		});
		StepButton.onClick.AddListener(delegate
		{
			int num6 = 3;
			if (4 == 0)
			{
			}
			_0023_003DqMUXXlb7Bj52E016Ku_0024zqAw_003D_003D();
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
			int num7 = 6;
			if (3 == 0)
			{
			}
			Refresh();
		});
		PauseButton.onClick.AddListener(delegate
		{
			if (4u != 0)
			{
				_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1;
			}
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
			Refresh();
		});
		PlayButton.onClick.AddListener(_0023_003DqzTN_Obi9I1EwnLFxVsJUAAsZCkeg5Y6ZAFcAwd9KVe4_003D);
		PlayFastButton.onClick.AddListener(_0023_003DqTFYe_KZHbySei0MTfaMg_UqfvPsfZckuJnbpX6319vM_003D);
	}

	public void Update()
	{
		if (!_0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			return;
		}
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<float> obj = _0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D() - Time.deltaTime;
		if (7u != 0)
		{
			_0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D = obj;
		}
		if (_0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D() <= 0f)
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<float> obj2 = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
			if (4u != 0)
			{
				_0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D = obj2;
			}
			_0023_003DqByl1Z_JidYN5aaovamp9Kg_003D_003D();
		}
	}

	public void Initialize(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqudxSbVyjFAOLMDpxXQ9GXQ_003D_003D, int _0023_003DqU1ni153VjVG1zitjhmtB0w_003D_003D)
	{
		_0023_003DqPyZu3ATELKn3PMEYHnXkLg_003D_003D obj = new _0023_003DqPyZu3ATELKn3PMEYHnXkLg_003D_003D(_0023_003DqudxSbVyjFAOLMDpxXQ9GXQ_003D_003D);
		if (2u != 0)
		{
			_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D = obj;
		}
		_0023_003DqzyNp4RVxB4DUZnOuTlr17Q_003D_003D._0023_003DqKs5EbNvrySJRrYobbWztOA_003D_003D(_0023_003DqudxSbVyjFAOLMDpxXQ9GXQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D());
		List<InputWidget> list = new List<InputWidget>();
		if (true)
		{
			_0023_003DqwxMUUQndXwrzWhTy8J12VA_003D_003D = list;
		}
		List<OutputWidget> list2 = new List<OutputWidget>();
		if (6u != 0)
		{
			_0023_003Dq7yxa04fdiM_0024rPdG49SSA3A_003D_003D = list2;
		}
		List<ImageOutputWidget> list3 = new List<ImageOutputWidget>();
		if (7u != 0)
		{
			_0023_003DqruzX1CridiR5QjGPwIYSC7UoaukTQq4uMOoM8bITbZg_003D = list3;
		}
		List<ConsoleWidget> list4 = new List<ConsoleWidget>();
		if (3u != 0)
		{
			_0023_003DqUGQZ7LRNZo_0024QSpBNDs4RsA_003D_003D = list4;
		}
		List<VideoWidget> list5 = new List<VideoWidget>();
		if (7u != 0)
		{
			_0023_003Dqhso4z5_HjfYxbGR_0024R89qBw_003D_003D = list5;
		}
		int num;
		if (2u != 0)
		{
			num = 23;
		}
		int i;
		if (5u != 0)
		{
			i = 0;
		}
		for (; i < _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003DqHBSbVLiSxkYOxfpKNrochw_003D_003D(); i++)
		{
			Vector2 _0023_003DqL2c4NZoVLM37wc0nu4W8Jw_003D_003D = new Vector2(num, -168f);
			if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i) is _0023_003DqLVkp4Q4_0024xh02LVztho1cIw_003D_003D)
			{
				InputWidget inputWidget = PrefabInputWidget._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D(base.gameObject, _0023_003DqL2c4NZoVLM37wc0nu4W8Jw_003D_003D);
				InputWidget inputWidget2;
				if (3u != 0)
				{
					inputWidget2 = inputWidget;
				}
				inputWidget2.Initialize((_0023_003DqLVkp4Q4_0024xh02LVztho1cIw_003D_003D)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i));
				_0023_003DqwxMUUQndXwrzWhTy8J12VA_003D_003D.Add(inputWidget2);
				int num2 = num + 48;
				if (8u != 0)
				{
					num = num2;
				}
			}
			else if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i) is _0023_003DqoZ_0024k6yAcVFoLTqCLaX3vcA_003D_003D)
			{
				OutputWidget outputWidget = PrefabOutputWidget._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D(base.gameObject, _0023_003DqL2c4NZoVLM37wc0nu4W8Jw_003D_003D);
				outputWidget.Initialize((_0023_003DqoZ_0024k6yAcVFoLTqCLaX3vcA_003D_003D)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i));
				_0023_003Dq7yxa04fdiM_0024rPdG49SSA3A_003D_003D.Add(outputWidget);
				num += 88;
			}
			else if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i) is _0023_003Dq2a1qieLqal2njAaYCy8vomPSm6ng2kgMDH5zRwWPbps_003D)
			{
				ImageOutputWidget imageOutputWidget = PrefabImageOutputWidget._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D(base.gameObject, _0023_003DqL2c4NZoVLM37wc0nu4W8Jw_003D_003D);
				imageOutputWidget.Initialize((_0023_003Dq2a1qieLqal2njAaYCy8vomPSm6ng2kgMDH5zRwWPbps_003D)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i));
				_0023_003DqruzX1CridiR5QjGPwIYSC7UoaukTQq4uMOoM8bITbZg_003D.Add(imageOutputWidget);
				num += 80;
			}
			else if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i) is _0023_003DqYNiuFWqj0JvWpXH3bg_Q5Q_003D_003D)
			{
				ConsoleWidget consoleWidget = PrefabConsoleWidget._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D(base.gameObject, _0023_003DqL2c4NZoVLM37wc0nu4W8Jw_003D_003D);
				consoleWidget.Initialize((_0023_003DqYNiuFWqj0JvWpXH3bg_Q5Q_003D_003D)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i));
				_0023_003DqUGQZ7LRNZo_0024QSpBNDs4RsA_003D_003D.Add(consoleWidget);
				num += 80;
			}
			else if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i) is _0023_003DqyHYIvmk7OvZghA_0024P8Adskg_003D_003D)
			{
				VideoWidget videoWidget = PrefabVideoWidget._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D(base.gameObject, _0023_003DqL2c4NZoVLM37wc0nu4W8Jw_003D_003D);
				videoWidget.Initialize((_0023_003DqyHYIvmk7OvZghA_0024P8Adskg_003D_003D)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(i));
				_0023_003Dqhso4z5_HjfYxbGR_0024R89qBw_003D_003D.Add(videoWidget);
				num += 316;
			}
		}
		_0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D = new List<ComputeTileWidget>();
		_0023_003Dq86Sg_HtJxZnUPq8uCS2vGBojWXamk9oCc3zw_xIIZlo_003D = new List<DamagedComputeTileWidget>();
		_0023_003DqhLKjq415dSONgMm757Le4vRKHqWv9t0hnItRvD3IbTs_003D = new List<MemoryTileWidget>();
		int num3 = 0;
		for (int j = 0; j < _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003DqHBSbVLiSxkYOxfpKNrochw_003D_003D(); j++)
		{
			if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(j) is _0023_003DqGrpUAWqqg7qf5XOY3Vn28Q_003D_003D)
			{
				ComputeTileWidget computeTileWidget = _0023_003DqVrXiDsAi2V_0024fw1Bak8WNsA_003D_003D._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D<ComputeTileWidget>(new Vector2(256 * (num3 % 4) + 352, -234 * (num3 / 4) - 48), PrefabComputeTileWidget, base.gameObject);
				computeTileWidget.Initialize((_0023_003DqGrpUAWqqg7qf5XOY3Vn28Q_003D_003D)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(j), delegate
				{
					if (!_0023_003Dq5pjq6a4lmWQGo8hM_eQvBfzqVnU_0024JX58uaK4MQpbOVU_003D)
					{
						global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<float> obj2 = 0.25f;
						if (2u != 0)
						{
							_0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D = obj2;
						}
						_0023_003DqtyPHydmJNF7ICaEqWOdLh8PISjYtTEdJEY9l847Nt5Q_003D();
						Refresh();
					}
				});
				_0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D.Add(computeTileWidget);
				num3++;
			}
			else if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(j) is _0023_003Dqoqa6MWHk5w6MYnXbTp0VDxKnx0iXNaZ1Jkw5IUR5YNI_003D)
			{
				DamagedComputeTileWidget damagedComputeTileWidget = _0023_003DqVrXiDsAi2V_0024fw1Bak8WNsA_003D_003D._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D<DamagedComputeTileWidget>(new Vector2(256 * (num3 % 4) + 352, -234 * (num3 / 4) - 48), PrefabDamagedComputeTileWidget, base.gameObject);
				damagedComputeTileWidget.Initialize((_0023_003Dqoqa6MWHk5w6MYnXbTp0VDxKnx0iXNaZ1Jkw5IUR5YNI_003D)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(j));
				_0023_003Dq86Sg_HtJxZnUPq8uCS2vGBojWXamk9oCc3zw_xIIZlo_003D.Add(damagedComputeTileWidget);
				num3++;
			}
			else if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(j) is _0023_003DqbOhN20XYidzXOZySKoR2rA_003D_003D)
			{
				MemoryTileWidget memoryTileWidget = _0023_003DqVrXiDsAi2V_0024fw1Bak8WNsA_003D_003D._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D<MemoryTileWidget>(new Vector2(256 * (num3 % 4) + 352, -234 * (num3 / 4) - 48), PrefabMemoryTileWidget, base.gameObject);
				memoryTileWidget.Initialize((_0023_003DqbOhN20XYidzXOZySKoR2rA_003D_003D)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnnOJIoNyeu1qbBL6ax7Yjw_003D_003D()._0023_003Dq0xnQHecoQm8H2l3y2OOWbg_003D_003D(j));
				_0023_003DqhLKjq415dSONgMm757Le4vRKHqWv9t0hnItRvD3IbTs_003D.Add(memoryTileWidget);
				num3++;
			}
		}
		Func<_0023_003Dqtwcilf_f_lmkle3X_0024Ya1_Q_003D_003D, global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D>> func = _0023_003DqWz9B6wgyriDVtrbxMrgweoZgeAeBCcsHsQTI3iWjTFc_003D;
		foreach (InputWidget item in _0023_003DqwxMUUQndXwrzWhTy8J12VA_003D_003D)
		{
			Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> dictionary = _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqhvRsjbfRKGkkOW9eVsn65KnFdFVZhs0WJQ2B55ErgOs_003D(item._0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D());
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = func(dictionary[(_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1]._0023_003DqUIebbSuaawrtuMsvKzUEDQ_003D_003D);
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				Vector2 _0023_003DqLd4zOGyiDsq0hR2n9p_hyg_003D_003D = _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqpJBh4mfFmc3FLBKsBuQOVQ_003D_003D()._0023_003DqniyKIh35avG7ONOXt9Crfzjb5b_0024x0pJ_0024a5FGvlOkJFo_003D() - item.gameObject._0023_003DqniyKIh35avG7ONOXt9Crfzjb5b_0024x0pJ_0024a5FGvlOkJFo_003D() + new Vector2(123f, 26f);
				item.LinkArrowWidget.gameObject._0023_003DqWqDED_0024ozo6_0024A0NmVHf8pIGgLUUyyarpR0xCyfH38p4Y_003D(_0023_003DqLd4zOGyiDsq0hR2n9p_hyg_003D_003D);
			}
			else
			{
				item.LinkArrowWidget.gameObject.SetActive(false);
			}
		}
		foreach (OutputWidget item2 in _0023_003Dq7yxa04fdiM_0024rPdG49SSA3A_003D_003D)
		{
			Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> dictionary2 = _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqhvRsjbfRKGkkOW9eVsn65KnFdFVZhs0WJQ2B55ErgOs_003D(item2._0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D());
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D3 = func(dictionary2[(_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0]._0023_003DqUIebbSuaawrtuMsvKzUEDQ_003D_003D);
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D3._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D3._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqcHHF_EEc9zlT14EU_hLpnJyRqyLpwkKtUchcyD4L_0024RE_003D().SetLabel(item2._0023_003DqZN3K8Ldw3JmjQrc0i6JBEg_003D_003D()._0023_003DqOQ2xBjbdEOzpFMfAF5JFog_003D_003D);
			}
		}
		foreach (ImageOutputWidget item3 in _0023_003DqruzX1CridiR5QjGPwIYSC7UoaukTQq4uMOoM8bITbZg_003D)
		{
			Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> dictionary3 = _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqhvRsjbfRKGkkOW9eVsn65KnFdFVZhs0WJQ2B55ErgOs_003D(item3._0023_003DqOXC_MjXw2RHY8M5ei_0024P4pvk5lkyndFiZyPbhegPMWB0_003D());
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4 = func(dictionary3[(_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0]._0023_003DqUIebbSuaawrtuMsvKzUEDQ_003D_003D);
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D4._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqcHHF_EEc9zlT14EU_hLpnJyRqyLpwkKtUchcyD4L_0024RE_003D().SetLabel(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694021875));
			}
		}
		foreach (ConsoleWidget item4 in _0023_003DqUGQZ7LRNZo_0024QSpBNDs4RsA_003D_003D)
		{
			Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> dictionary4 = _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqhvRsjbfRKGkkOW9eVsn65KnFdFVZhs0WJQ2B55ErgOs_003D(item4._0023_003Dq1aL5maMZQ122LSga86FBp9KoNVZknWDGtFF0_lgbSJA_003D());
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D5 = func(dictionary4[(_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1]._0023_003DqUIebbSuaawrtuMsvKzUEDQ_003D_003D);
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D5._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				Vector2 _0023_003DqLd4zOGyiDsq0hR2n9p_hyg_003D_003D2 = _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D5._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqpJBh4mfFmc3FLBKsBuQOVQ_003D_003D()._0023_003DqniyKIh35avG7ONOXt9Crfzjb5b_0024x0pJ_0024a5FGvlOkJFo_003D() - item4.gameObject._0023_003DqniyKIh35avG7ONOXt9Crfzjb5b_0024x0pJ_0024a5FGvlOkJFo_003D() + new Vector2(123f, 26f);
				item4.LinkArrowWidget.gameObject._0023_003DqWqDED_0024ozo6_0024A0NmVHf8pIGgLUUyyarpR0xCyfH38p4Y_003D(_0023_003DqLd4zOGyiDsq0hR2n9p_hyg_003D_003D2);
			}
			else
			{
				item4.LinkArrowWidget.gameObject.SetActive(false);
			}
			_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D5 = func(dictionary4[(_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0]._0023_003DqUIebbSuaawrtuMsvKzUEDQ_003D_003D);
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D5._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D5._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqcHHF_EEc9zlT14EU_hLpnJyRqyLpwkKtUchcyD4L_0024RE_003D().SetLabel(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977740));
			}
		}
		foreach (VideoWidget item5 in _0023_003Dqhso4z5_HjfYxbGR_0024R89qBw_003D_003D)
		{
			Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> dictionary5 = _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqhvRsjbfRKGkkOW9eVsn65KnFdFVZhs0WJQ2B55ErgOs_003D(item5._0023_003DqmFVcK_pPg6O4irAyX5cnzg_003D_003D());
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D6 = func(dictionary5[(_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1]._0023_003DqUIebbSuaawrtuMsvKzUEDQ_003D_003D);
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D6._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				Vector2 _0023_003DqLd4zOGyiDsq0hR2n9p_hyg_003D_003D3 = _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D6._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqpJBh4mfFmc3FLBKsBuQOVQ_003D_003D()._0023_003DqniyKIh35avG7ONOXt9Crfzjb5b_0024x0pJ_0024a5FGvlOkJFo_003D() - item5.gameObject._0023_003DqniyKIh35avG7ONOXt9Crfzjb5b_0024x0pJ_0024a5FGvlOkJFo_003D() + new Vector2(123f, 26f);
				item5.LinkArrowWidget.gameObject._0023_003DqWqDED_0024ozo6_0024A0NmVHf8pIGgLUUyyarpR0xCyfH38p4Y_003D(_0023_003DqLd4zOGyiDsq0hR2n9p_hyg_003D_003D3);
			}
			else
			{
				item5.LinkArrowWidget.gameObject.SetActive(false);
			}
			_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D6 = func(dictionary5[(_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)0]._0023_003DqUIebbSuaawrtuMsvKzUEDQ_003D_003D);
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D6._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D6._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqcHHF_EEc9zlT14EU_hLpnJyRqyLpwkKtUchcyD4L_0024RE_003D().SetLabel(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693977740));
			}
		}
		TitleText.text = string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693976608), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003DqtTvEXXGbpBW4Rhvpc7H3iw_003D_003D);
		_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)0;
		_0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D = _0023_003DqU1ni153VjVG1zitjhmtB0w_003D_003D;
		_0023_003DqaTsNfytcAZ5LCi05TxMgbA_003D_003D();
		_0023_003DqP8Ylb_0024K_0024x83nuK6Wq_002499aw_003D_003D = new global::_0023_003DqjrwtmPX_V2ykHbKizqDj5UkPjjTi1ZDr8gOZBEBHY9s_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D>(_0023_003DqV98wG9KrcZGama6ZMX_0024Tow_003D_003D());
		Refresh();
	}

	public void Refresh()
	{
		List<ComputeTileWidget> list = _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D;
		if (_0023_003DqwQuTmcO6D2CEDg_qQWWTBE6IIfebpObM0kCDXCVtGIc_003D == null)
		{
			Action<ComputeTileWidget> action = delegate(ComputeTileWidget _0023_003DqgvtOgZ0zJF_SEaij0JBFqQ_003D_003D)
			{
				int num2 = 1;
				if (3 == 0)
				{
				}
				_0023_003DqgvtOgZ0zJF_SEaij0JBFqQ_003D_003D.Refresh();
			};
			if (uint.MaxValue != 0)
			{
				_0023_003DqwQuTmcO6D2CEDg_qQWWTBE6IIfebpObM0kCDXCVtGIc_003D = action;
			}
		}
		list.ForEach(_0023_003DqwQuTmcO6D2CEDg_qQWWTBE6IIfebpObM0kCDXCVtGIc_003D);
		List<DamagedComputeTileWidget> list2 = _0023_003Dq86Sg_HtJxZnUPq8uCS2vGBojWXamk9oCc3zw_xIIZlo_003D;
		if (_0023_003DqSo5YvX6rtb8y8niRPKGMDt8L8_0024Gf12g3_0024Dk_0024lX_0024ULXs_003D == null)
		{
			Action<DamagedComputeTileWidget> action2 = delegate(DamagedComputeTileWidget _0023_003DqD0eE2GL7No1b2dUbOwmweA_003D_003D)
			{
				int num3 = 2;
				if (8 == 0)
				{
				}
				_0023_003DqD0eE2GL7No1b2dUbOwmweA_003D_003D.Refresh();
			};
			if (7u != 0)
			{
				_0023_003DqSo5YvX6rtb8y8niRPKGMDt8L8_0024Gf12g3_0024Dk_0024lX_0024ULXs_003D = action2;
			}
		}
		list2.ForEach(_0023_003DqSo5YvX6rtb8y8niRPKGMDt8L8_0024Gf12g3_0024Dk_0024lX_0024ULXs_003D);
		List<MemoryTileWidget> list3 = _0023_003DqhLKjq415dSONgMm757Le4vRKHqWv9t0hnItRvD3IbTs_003D;
		if (_0023_003DqPC4fwR5ZnkLbObHsPQFXjWWEavVmkUFNKbDuH5vCd_0024I_003D == null)
		{
			Action<MemoryTileWidget> action3 = _0023_003DqP4qbWmqx5ZciLEoblVUFpQ_003D_003D;
			if (7u != 0)
			{
				_0023_003DqPC4fwR5ZnkLbObHsPQFXjWWEavVmkUFNKbDuH5vCd_0024I_003D = action3;
			}
		}
		list3.ForEach(_0023_003DqPC4fwR5ZnkLbObHsPQFXjWWEavVmkUFNKbDuH5vCd_0024I_003D);
		List<InputWidget> list4 = _0023_003DqwxMUUQndXwrzWhTy8J12VA_003D_003D;
		if (_0023_003DqLPZikcNyg7MhjDTwFiOx2sPC0SaOzV8U2aaU3cM6VBk_003D == null)
		{
			Action<InputWidget> action4 = _0023_003DqISlfCVWfenzHTRmOd48qkA_003D_003D;
			if (8u != 0)
			{
				_0023_003DqLPZikcNyg7MhjDTwFiOx2sPC0SaOzV8U2aaU3cM6VBk_003D = action4;
			}
		}
		list4.ForEach(_0023_003DqLPZikcNyg7MhjDTwFiOx2sPC0SaOzV8U2aaU3cM6VBk_003D);
		List<OutputWidget> list5 = _0023_003Dq7yxa04fdiM_0024rPdG49SSA3A_003D_003D;
		if (_0023_003DqGhlO1E_0024GQhjHGEXQs3LAXQHgKYdSksxek8BY1DFkSFw_003D == null)
		{
			Action<OutputWidget> action5 = _0023_003DqOop5lsvMTQZfI1o4WXr9Wg_003D_003D;
			if (0 == 0)
			{
				_0023_003DqGhlO1E_0024GQhjHGEXQs3LAXQHgKYdSksxek8BY1DFkSFw_003D = action5;
			}
		}
		list5.ForEach(_0023_003DqGhlO1E_0024GQhjHGEXQs3LAXQHgKYdSksxek8BY1DFkSFw_003D);
		List<ConsoleWidget> list6 = _0023_003DqUGQZ7LRNZo_0024QSpBNDs4RsA_003D_003D;
		if (_0023_003DqPzA9d37fUOHhNNW3A9xEJbazuSl6nhIcgY8OvDrVf24_003D == null)
		{
			Action<ConsoleWidget> action6 = _0023_003DqsszXwA2fD9O47VXrOALpBQ_003D_003D;
			if (8u != 0)
			{
				_0023_003DqPzA9d37fUOHhNNW3A9xEJbazuSl6nhIcgY8OvDrVf24_003D = action6;
			}
		}
		list6.ForEach(_0023_003DqPzA9d37fUOHhNNW3A9xEJbazuSl6nhIcgY8OvDrVf24_003D);
		List<VideoWidget> list7 = _0023_003Dqhso4z5_HjfYxbGR_0024R89qBw_003D_003D;
		if (_0023_003DqFWwW3VFfRZCYt2pF_0024Q_AY00UgQGiFKYmpTE1Lhk4gsw_003D == null)
		{
			Action<VideoWidget> action7 = delegate(VideoWidget _0023_003DqeI24Qa4_0024iP4jUwY1rsEYeQ_003D_003D)
			{
				int num4 = 5;
				if (7 == 0)
				{
				}
				_0023_003DqeI24Qa4_0024iP4jUwY1rsEYeQ_003D_003D.Refresh();
			};
			if (5u != 0)
			{
				_0023_003DqFWwW3VFfRZCYt2pF_0024Q_AY00UgQGiFKYmpTE1Lhk4gsw_003D = action7;
			}
		}
		list7.ForEach(_0023_003DqFWwW3VFfRZCYt2pF_0024Q_AY00UgQGiFKYmpTE1Lhk4gsw_003D);
		StopButton.interactable = _0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D != (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)0;
		PlayStepButton.gameObject.SetActive(_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D == (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)0);
		StepButton.gameObject.SetActive(_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D == (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1);
		PauseButton.gameObject.SetActive(_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D == (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)2 || _0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D == (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)3);
		PlayButton.interactable = _0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D != (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)2;
		PlayFastButton.interactable = _0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D != (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)3;
		if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D())
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int num = 0; (float)num < _0023_003DqPyZu3ATELKn3PMEYHnXkLg_003D_003D._0023_003DqO5PiMlQjwKSOmR2TIGd3tw_003D_003D; num++)
			{
				if (num == _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqAYBYmTVc2WM0_0024_NRsByS6xva8YmrDXlA_etxiwLzwg4_003D.Count)
				{
					stringBuilder.AppendFormat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694021887), num + 1);
					break;
				}
				stringBuilder.AppendFormat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694021852), num + 1, _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqAYBYmTVc2WM0_0024_NRsByS6xva8YmrDXlA_etxiwLzwg4_003D[num]);
			}
			if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqEEK16_XJObeyTJUzsTL9pg_003D_003D())
			{
				stringBuilder.Append(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694021635));
				stringBuilder.Append(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694021663));
				stringBuilder.AppendFormat(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694021697), _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqAYBYmTVc2WM0_0024_NRsByS6xva8YmrDXlA_etxiwLzwg4_003D.Max());
			}
			else if ((float)_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqAYBYmTVc2WM0_0024_NRsByS6xva8YmrDXlA_etxiwLzwg4_003D.Count == _0023_003DqPyZu3ATELKn3PMEYHnXkLg_003D_003D._0023_003DqO5PiMlQjwKSOmR2TIGd3tw_003D_003D)
			{
				stringBuilder.Append(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022050));
			}
			InformationText.text = stringBuilder.ToString();
		}
		else
		{
			InformationText.text = _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003Dq1nCpWdVZfKh8PZq5Xfta_0024A_003D_003D;
		}
	}

	private void _0023_003DqJs3ws8xoUU8YoTd0SRuisQ_003D_003D(_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D _0023_003DqrfjA16E5b1pUlnzvt0KR4Q_003D_003D)
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqstWalp1v_2B26HzLG9wPxA_003D_003D();
		if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqUSbT_0024QYqyTYlZ7mHc5YlsdgRL8qYbPj20DvAwNccW5s_003D().Count() != 0)
		{
			return;
		}
		if (!_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D())
		{
			_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqQGXi_YFheH5245FCcFtyhw_003D_003D();
		}
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<ConsoleWidget> obj = _0023_003DqUGQZ7LRNZo_0024QSpBNDs4RsA_003D_003D._0023_003Dq_LoHFM9bEEhQdhJbd03LQA_003D_003D();
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<ConsoleWidget> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
		if (7u != 0)
		{
			_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = obj;
		}
		if (_0023_003DqevNBNIu_0024fa8nvRc6p4t8eGBW_o66gEDFINy0wh1Ixjk_003D == null)
		{
			Action<ConsoleWidget> action = _0023_003DqQQHlvKxGcKvoT2OegktVfNWWzMnAjqvxCd0Mhhn6aAg_003D;
			if (0 == 0)
			{
				_0023_003DqevNBNIu_0024fa8nvRc6p4t8eGBW_o66gEDFINy0wh1Ixjk_003D = action;
			}
		}
		_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003DqeD4A_Dac6VLN8T0c0ucLGg_003D_003D(_0023_003DqevNBNIu_0024fa8nvRc6p4t8eGBW_o66gEDFINy0wh1Ixjk_003D);
		if (4u != 0)
		{
			_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = _0023_003DqrfjA16E5b1pUlnzvt0KR4Q_003D_003D;
		}
		_0023_003DqUK9h3kqBdc0_wvRqEO_uRw_003D_003D = 0f;
		if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqkrTHoRGdP3qjAPQkwDsigM7IoyifvZw9uYXf8BcQJlg_003D())
		{
			_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003Dq0q9613L8dfF4EUw8QoBU_dCBIqja3qkcRl6lKFu0cWU_003D();
			_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1;
		}
	}

	private void _0023_003DqMUXXlb7Bj52E016Ku_0024zqAw_003D_003D()
	{
		_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqwKc0RGUAnswOmReVQsUrrA_003D_003D();
		if (_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqkrTHoRGdP3qjAPQkwDsigM7IoyifvZw9uYXf8BcQJlg_003D())
		{
			_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003Dq0q9613L8dfF4EUw8QoBU_dCBIqja3qkcRl6lKFu0cWU_003D();
			if (0 == 0)
			{
				_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1;
			}
		}
	}

	private void _0023_003Dq2nzQaR81pssRgjFoxSg8Lw_003D_003D()
	{
		_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqmK4w3LbdZf7KnVHNY6YvyA_003D_003D();
		if (5u != 0)
		{
			_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)0;
		}
		Refresh();
	}

	private void _0023_003DqByl1Z_JidYN5aaovamp9Kg_003D_003D()
	{
		List<ComputeTileWidget> source = _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D;
		if (_0023_003DqHoWYip1Jf05ZQsXy2P0w9yxRZBGtPeXUw4H9_0024CXzhrw_003D == null)
		{
			Func<ComputeTileWidget, int> func = _0023_003DqFJM1bSKNih9kjAfg00ONV_oQsElIXhr34j3xMbm8dnE_003D;
			if (4u != 0)
			{
				_0023_003DqHoWYip1Jf05ZQsXy2P0w9yxRZBGtPeXUw4H9_0024CXzhrw_003D = func;
			}
		}
		int[] array = source.Select(_0023_003DqHoWYip1Jf05ZQsXy2P0w9yxRZBGtPeXUw4H9_0024CXzhrw_003D).ToArray();
		int[] array2;
		if (7u != 0)
		{
			array2 = array;
		}
		if (_0023_003Dq66ws5W31oeJfF6XZo9uSNg_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D() && _0023_003Dq66ws5W31oeJfF6XZo9uSNg_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D().SequenceEqual(array2))
		{
			return;
		}
		List<string> list = new List<string>();
		List<string> list2;
		if (4u != 0)
		{
			list2 = list;
		}
		for (int i = 0; i < _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D.Count; i++)
		{
			list2.Add(string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022017), i));
			string[] array3 = _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D[i].DesignCode._0023_003DqHyyQLAPBn1C3UHO7mPuyrA_003D_003D().TrimEnd().Split('\n');
			foreach (string text in array3)
			{
				list2.Add(text.TrimEnd());
			}
			if (i < _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D.Count - 1)
			{
				list2.Add(string.Empty);
			}
		}
		_0023_003Dq66ws5W31oeJfF6XZo9uSNg_003D_003D = array2;
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqUAiX0RDHWl7aMOnS_0024sPsLA_003D_003D._0023_003DqpeBgnXJLDsntce_0024sIyOBkA_003D_003D(_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D), string.Join(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693976996), list2.ToArray()));
	}

	private void _0023_003DqaTsNfytcAZ5LCi05TxMgbA_003D_003D()
	{
		if (5u != 0)
		{
			_0023_003Dq5pjq6a4lmWQGo8hM_eQvBfzqVnU_0024JX58uaK4MQpbOVU_003D = true;
		}
		string text = _0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqAumCJ7ZRDw0Vy1wi9Fogjw_003D_003D);
		string path;
		if (4u != 0)
		{
			path = text;
		}
		if (File.Exists(path))
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int> obj = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
			if (2u != 0)
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = obj;
			}
			Dictionary<int, List<string>> dictionary = new Dictionary<int, List<string>>();
			Dictionary<int, List<string>> dictionary2;
			if (8u != 0)
			{
				dictionary2 = dictionary;
			}
			string[] array = File.ReadAllLines(path);
			foreach (string text2 in array)
			{
				if (text2.Length >= 2 && text2[0] == '@')
				{
					int result = 0;
					if (int.TryParse(text2.Substring(1), out result) && result >= 0 && result < _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D.Count)
					{
						_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = result;
						dictionary2[result] = new List<string>();
					}
				}
				else if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
				{
					string text3 = text2.TrimEnd();
					text3 = text3.Substring(0, Mathf.Min(text3.Length, 18));
					dictionary2[_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()].Add(text3);
				}
			}
			foreach (KeyValuePair<int, List<string>> item in dictionary2)
			{
				_0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D[item.Key].DesignCode.SetText(string.Join(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693976996), item.Value.Take(15).ToArray()).TrimEnd());
			}
		}
		else
		{
			foreach (KeyValuePair<int, string> item2 in _0023_003DqauGDzRTOiElGiYf9c2zLXQ_003D_003D._0023_003DqGPyQ1nhBNJu0hob5Qc01uQ_003D_003D._0023_003DqSUPF0isrZ1zCz1F00f8suQ_003D_003D)
			{
				_0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D[item2.Key].DesignCode.SetText(item2.Value);
			}
		}
		_0023_003Dq5pjq6a4lmWQGo8hM_eQvBfzqVnU_0024JX58uaK4MQpbOVU_003D = false;
	}

	private _0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D _0023_003DqV98wG9KrcZGama6ZMX_0024Tow_003D_003D()
	{
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int> obj = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int> _0023_003DqBYrNBktuycwjm981QjS_TA_003D_003D = default(global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int>);
		if (0 == 0)
		{
			_0023_003DqBYrNBktuycwjm981QjS_TA_003D_003D = obj;
		}
		int i;
		if (3u != 0)
		{
			i = 0;
		}
		for (; i < _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D.Count; i++)
		{
			if (_0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D[i].DesignCode.Focused)
			{
				global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int> obj2 = i;
				if (2u != 0)
				{
					_0023_003DqBYrNBktuycwjm981QjS_TA_003D_003D = obj2;
				}
				break;
			}
		}
		_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D _0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D2 = new _0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D();
		_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D2._0023_003DqBYrNBktuycwjm981QjS_TA_003D_003D = _0023_003DqBYrNBktuycwjm981QjS_TA_003D_003D;
		List<ComputeTileWidget> source = _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D;
		if (_0023_003DqD8DnoFyeMOQQ6jYIhbfLMiJATcfYOkMQmHX_0024dIi2F6I_003D == null)
		{
			_0023_003DqD8DnoFyeMOQQ6jYIhbfLMiJATcfYOkMQmHX_0024dIi2F6I_003D = delegate(ComputeTileWidget _0023_003DqIuR1eIxfLlJWJGeLE6YYbg_003D_003D)
			{
				int num = 7;
				if (5 == 0)
				{
				}
				return _0023_003DqIuR1eIxfLlJWJGeLE6YYbg_003D_003D.DesignCode.GetUndoState();
			};
		}
		_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D2._0023_003DqlNzCPhrId01KapUCZP3XHA_003D_003D = source.Select(_0023_003DqD8DnoFyeMOQQ6jYIhbfLMiJATcfYOkMQmHX_0024dIi2F6I_003D).ToArray();
		return _0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D2;
	}

	private void _0023_003DqtyPHydmJNF7ICaEqWOdLh8PISjYtTEdJEY9l847Nt5Q_003D()
	{
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D> obj = _0023_003DqV98wG9KrcZGama6ZMX_0024Tow_003D_003D();
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = default(global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D>);
		if (0 == 0)
		{
			_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = obj;
		}
		if (!_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			return;
		}
		bool flag;
		if (2u != 0)
		{
			flag = false;
		}
		int i;
		if (4u != 0)
		{
			i = 0;
		}
		for (; i < _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D.Count; i++)
		{
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqlNzCPhrId01KapUCZP3XHA_003D_003D[i]._0023_003DqfHOZClF3oBaXmG_7B_0024mC7Q_003D_003D != _0023_003DqP8Ylb_0024K_0024x83nuK6Wq_002499aw_003D_003D._0023_003DqipHpp_qRQfqB2trdtdrd_0024AiQ_o7kgis06s_0024xjIUwrP4_003D()._0023_003DqlNzCPhrId01KapUCZP3XHA_003D_003D[i]._0023_003DqfHOZClF3oBaXmG_7B_0024mC7Q_003D_003D)
			{
				flag = true;
				break;
			}
		}
		if (flag)
		{
			_0023_003DqP8Ylb_0024K_0024x83nuK6Wq_002499aw_003D_003D._0023_003Dq_00244IL_0024qZfMcf9VRhfi_M_0024lA_003D_003D(_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D());
		}
	}

	private void _0023_003DqZS5g8qoGYF_00241oKJSabtVXA_003D_003D(_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D _0023_003Dqy5o9Hh2iNRoJSgyIBN1NZw_003D_003D)
	{
		if (uint.MaxValue != 0)
		{
			_0023_003Dq5pjq6a4lmWQGo8hM_eQvBfzqVnU_0024JX58uaK4MQpbOVU_003D = true;
		}
		int num;
		if (6u != 0)
		{
			num = 0;
		}
		while (num < _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D.Count)
		{
			_0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D[num].DesignCode.ApplyUndoState(_0023_003Dqy5o9Hh2iNRoJSgyIBN1NZw_003D_003D._0023_003DqlNzCPhrId01KapUCZP3XHA_003D_003D[num]);
			if (_0023_003Dqy5o9Hh2iNRoJSgyIBN1NZw_003D_003D._0023_003DqBYrNBktuycwjm981QjS_TA_003D_003D._0023_003DqkuoyTclZnjTlFDx1VFzbvQ_003D_003D(num))
			{
				_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq5z7kCOu_0024fCu89yUDVL2AnQ_003D_003D(_0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D[num].DesignCode);
			}
			int num2 = num + 1;
			if (true)
			{
				num = num2;
			}
		}
		_0023_003Dq5pjq6a4lmWQGo8hM_eQvBfzqVnU_0024JX58uaK4MQpbOVU_003D = false;
		_0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D = 0.25f;
		Refresh();
	}

	private void _0023_003DqmsvZ9ldAFsVSKJDjzz_0024MfgqfSx75zPMC7B5b1VqWbSU_003D()
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqstWalp1v_2B26HzLG9wPxA_003D_003D();
	}

	private void _0023_003Dq4Q9DFoRQTrm_EeIdA2wRAV7Cnq5vMkViJjKs8ONwfWI_003D()
	{
		int num = 4;
		if (-1 == 0)
		{
		}
		_0023_003Dq2nzQaR81pssRgjFoxSg8Lw_003D_003D();
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		int num2 = -1;
		if (6 == 0)
		{
		}
		Refresh();
	}

	private void _0023_003DqO_E_0024xYq8dybzH9hLSFbjHWAUjjKkqKYPfqxzTLPxvMM_003D()
	{
		int num = 2;
		if (false)
		{
		}
		_0023_003DqJs3ws8xoUU8YoTd0SRuisQ_003D_003D((_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1);
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		int num2 = 8;
		if (5 == 0)
		{
		}
		Refresh();
	}

	private void _0023_003DqXEvVkT_10VG8DfliIMoFPo_0024ybx_RQXWnM55tk7Awn6A_003D()
	{
		int num = 3;
		if (4 == 0)
		{
		}
		_0023_003DqMUXXlb7Bj52E016Ku_0024zqAw_003D_003D();
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		int num2 = 6;
		if (3 == 0)
		{
		}
		Refresh();
	}

	private void _0023_003Dqj6BjQKHqjvWNNXTGgEhH3_0024uXRN3MhLokwPF5l40Cc84_003D()
	{
		if (4u != 0)
		{
			_0023_003DqZVylEItmcMXLIsq2sDIOcQ_003D_003D = (_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)1;
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		Refresh();
	}

	private void _0023_003DqzTN_Obi9I1EwnLFxVsJUAAsZCkeg5Y6ZAFcAwd9KVe4_003D()
	{
		int num = 0;
		if (6 == 0)
		{
		}
		_0023_003DqJs3ws8xoUU8YoTd0SRuisQ_003D_003D((_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)2);
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		int num2 = 4;
		if (false)
		{
		}
		Refresh();
	}

	private void _0023_003DqTFYe_KZHbySei0MTfaMg_UqfvPsfZckuJnbpX6319vM_003D()
	{
		int num = 7;
		if (false)
		{
		}
		_0023_003DqJs3ws8xoUU8YoTd0SRuisQ_003D_003D((_0023_003DqNpmfmRtFOn_0024Pcz1VxsqJVw_003D_003D)3);
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		int num2 = 7;
		if (8 == 0)
		{
		}
		Refresh();
	}

	private void _0023_003DqxNWfjUfN_0024YNLjH6oTAW5hg_003D_003D()
	{
		if (!_0023_003Dq5pjq6a4lmWQGo8hM_eQvBfzqVnU_0024JX58uaK4MQpbOVU_003D)
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<float> obj = 0.25f;
			if (2u != 0)
			{
				_0023_003Dqb7aZM9zeBhioqq_VsLgmOg_003D_003D = obj;
			}
			_0023_003DqtyPHydmJNF7ICaEqWOdLh8PISjYtTEdJEY9l847Nt5Q_003D();
			Refresh();
		}
	}

	private static bool _0023_003DqEFjVi_0024hXpHh5boQyW7NYAPuVJ9dmOa_00249w5TQB9z5XIY_003D(ComputeTileWidget _0023_003DqXht77CRRaJTZ1Xs9XkYfzg_003D_003D)
	{
		int num = 3;
		if (8 == 0)
		{
		}
		return _0023_003DqXht77CRRaJTZ1Xs9XkYfzg_003D_003D.DesignCode.Focused;
	}

	private void _0023_003DqEL_q7FXpDAkH2RMb4Mysij396CbCNGjTjftIEPNq_0024JM_003D(_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D _0023_003DqbGYnfAapNXbNLzmLgOsQeA_003D_003D)
	{
		int num = 2;
		if (7 == 0)
		{
		}
		int num2 = 5;
		if (4 == 0)
		{
		}
		_0023_003DqZS5g8qoGYF_00241oKJSabtVXA_003D_003D(_0023_003DqbGYnfAapNXbNLzmLgOsQeA_003D_003D);
	}

	private void _0023_003Dq7tlrt9RDZBg0ztQx4LpmpDFehcp7R042dNa6WPBOLlk_003D(_0023_003Dqa2EDscQ6T2iOyGnAf4zhjA_003D_003D _0023_003DqFwExA6FVVuYbh4JbEwGbvw_003D_003D)
	{
		int num = -1;
		if (false)
		{
		}
		int num2 = 8;
		if (2 == 0)
		{
		}
		_0023_003DqZS5g8qoGYF_00241oKJSabtVXA_003D_003D(_0023_003DqFwExA6FVVuYbh4JbEwGbvw_003D_003D);
	}

	private static bool _0023_003DqXTUVmmcBEBZTf0WNYtBVW__0024HOoOk1lks_33LZtUyIHI_003D(ComputeTileWidget _0023_003DqSb1wJtfIHUH2ftLKH7NeNA_003D_003D)
	{
		int num = 7;
		if (false)
		{
		}
		return _0023_003DqSb1wJtfIHUH2ftLKH7NeNA_003D_003D.DesignCode == _0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqXqTzkZ4or0BnFKuOtYvRShjo7YXnDODHybPAlcH8Ino_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D();
	}

	private global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D> _0023_003DqWz9B6wgyriDVtrbxMrgweoZgeAeBCcsHsQTI3iWjTFc_003D(_0023_003Dqtwcilf_f_lmkle3X_0024Ya1_Q_003D_003D _0023_003DqVBEoxQ9erdyc28Gqi39tqA_003D_003D)
	{
		List<ComputeTileWidget>.Enumerator enumerator = _0023_003Dqnhxw4dqsBonvamsgqTDqK5LTlWFM1wJ8nr25ixK_00241hs_003D.GetEnumerator();
		List<ComputeTileWidget>.Enumerator enumerator2;
		if (5u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			while (enumerator2.MoveNext())
			{
				ComputeTileWidget current = enumerator2.Current;
				ComputeTileWidget computeTileWidget;
				if (8u != 0)
				{
					computeTileWidget = current;
				}
				if (computeTileWidget._0023_003Dq7PfqCTV7lzc0jhlzstptycPP29noPuSrZMFA_iYSItM_003D() == _0023_003DqVBEoxQ9erdyc28Gqi39tqA_003D_003D)
				{
					global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D> result = computeTileWidget;
					if (2u != 0)
					{
						return result;
					}
					global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqOvQ05m5dcwemksLFKNt6sS3sqyQ05rETVYsWikuRggs_003D> result2;
					return result2;
				}
			}
		}
		finally
		{
			((IDisposable)enumerator2).Dispose();
		}
		foreach (MemoryTileWidget item in _0023_003DqhLKjq415dSONgMm757Le4vRKHqWv9t0hnItRvD3IbTs_003D)
		{
			if (item._0023_003Dq_0024ppkAxe4eQze2QczI0Jqmg_003D_003D() == _0023_003DqVBEoxQ9erdyc28Gqi39tqA_003D_003D)
			{
				return item;
			}
		}
		return _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
	}

	private static void _0023_003Dq4NSkUK_002491E70cupFK_PcFg_003D_003D(ComputeTileWidget _0023_003DqgvtOgZ0zJF_SEaij0JBFqQ_003D_003D)
	{
		int num = 1;
		if (3 == 0)
		{
		}
		_0023_003DqgvtOgZ0zJF_SEaij0JBFqQ_003D_003D.Refresh();
	}

	private static void _0023_003Dq_0024fAUeMG2CQpXEPb1KFVYOQ_003D_003D(DamagedComputeTileWidget _0023_003DqD0eE2GL7No1b2dUbOwmweA_003D_003D)
	{
		int num = 2;
		if (8 == 0)
		{
		}
		_0023_003DqD0eE2GL7No1b2dUbOwmweA_003D_003D.Refresh();
	}

	private static void _0023_003DqP4qbWmqx5ZciLEoblVUFpQ_003D_003D(MemoryTileWidget _0023_003Dqp5Wepry8wxPYAZnQ8t7Teg_003D_003D)
	{
		int num = 0;
		if (-1 == 0)
		{
		}
		_0023_003Dqp5Wepry8wxPYAZnQ8t7Teg_003D_003D.Refresh();
	}

	private static void _0023_003DqISlfCVWfenzHTRmOd48qkA_003D_003D(InputWidget _0023_003Dq7Jh47oUtvUIR9JV7BHecVg_003D_003D)
	{
		int num = 6;
		if (8 == 0)
		{
		}
		_0023_003Dq7Jh47oUtvUIR9JV7BHecVg_003D_003D.Refresh();
	}

	private static void _0023_003DqOop5lsvMTQZfI1o4WXr9Wg_003D_003D(OutputWidget _0023_003Dq0trpt7uEtIK_6omoNEy8hQ_003D_003D)
	{
		int num = 6;
		if (8 == 0)
		{
		}
		_0023_003Dq0trpt7uEtIK_6omoNEy8hQ_003D_003D.Refresh();
	}

	private static void _0023_003DqsszXwA2fD9O47VXrOALpBQ_003D_003D(ConsoleWidget _0023_003DqxMUFOQeGmwcvviaB5e9kog_003D_003D)
	{
		int num = 5;
		if (6 == 0)
		{
		}
		_0023_003DqxMUFOQeGmwcvviaB5e9kog_003D_003D.Refresh();
	}

	private static void _0023_003DqW_swDb_0024v5qB4rEv4f4Rj4A_003D_003D(VideoWidget _0023_003DqeI24Qa4_0024iP4jUwY1rsEYeQ_003D_003D)
	{
		int num = 5;
		if (7 == 0)
		{
		}
		_0023_003DqeI24Qa4_0024iP4jUwY1rsEYeQ_003D_003D.Refresh();
	}

	private static void _0023_003DqQQHlvKxGcKvoT2OegktVfNWWzMnAjqvxCd0Mhhn6aAg_003D(ConsoleWidget _0023_003DqU_0024MxnCE1UpwPW_pNB4t8fw_003D_003D)
	{
		int num = 5;
		if (-1 == 0)
		{
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq5z7kCOu_0024fCu89yUDVL2AnQ_003D_003D(_0023_003DqU_0024MxnCE1UpwPW_pNB4t8fw_003D_003D);
	}

	private static int _0023_003DqFJM1bSKNih9kjAfg00ONV_oQsElIXhr34j3xMbm8dnE_003D(ComputeTileWidget _0023_003Dq5gZh1zLd08ChnwRqscTISA_003D_003D)
	{
		int num = 0;
		if (false)
		{
		}
		return _0023_003Dq5gZh1zLd08ChnwRqscTISA_003D_003D.DesignCode._0023_003DqHyyQLAPBn1C3UHO7mPuyrA_003D_003D().GetHashCode();
	}

	private static global::_0023_003DqxC7QFsWSEOgogypo4aoxkA_003D_003D<string, int, global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int>> _0023_003DqaQS8jRcG_0024tOgS8iW8P9QDIQiVPnPsJAyLJBaBz_0024_0024Z0s_003D(ComputeTileWidget _0023_003DqIuR1eIxfLlJWJGeLE6YYbg_003D_003D)
	{
		int num = 7;
		if (5 == 0)
		{
		}
		return _0023_003DqIuR1eIxfLlJWJGeLE6YYbg_003D_003D.DesignCode.GetUndoState();
	}
}
