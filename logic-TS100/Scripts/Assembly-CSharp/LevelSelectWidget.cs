using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public sealed class LevelSelectWidget : MonoBehaviour, _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D
{
	private sealed class _0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D
	{
		internal int _0023_003DqqlvK5N00aAGgiFOsSHqE6A_003D_003D;

		internal LevelSelectWidget _0023_003DqQyEyZx0Xqy0uRAjJR5Orpg_003D_003D;

		public _0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D()
		{
			int num = 4;
			if (false)
			{
			}
			base._002Ector();
		}

		internal void _0023_003DqhqshrYiIIX7UezLOtWyihA_003D_003D()
		{
			int num = 3;
			if (1 == 0)
			{
			}
			LevelSelectWidget levelSelectWidget = _0023_003DqQyEyZx0Xqy0uRAjJR5Orpg_003D_003D;
			int num2 = -1;
			if (8 == 0)
			{
			}
			levelSelectWidget._0023_003Dqn3Mnu1yO5plxWo1WC62QN6jxfwBNSa887tVJ6QIvEcM_003D(_0023_003DqqlvK5N00aAGgiFOsSHqE6A_003D_003D);
		}

		internal void _0023_003DqDlWhwZr2CgeFutQ9wd3ikQ_003D_003D()
		{
			int num = 0;
			if (false)
			{
			}
			LevelSelectWidget levelSelectWidget = _0023_003DqQyEyZx0Xqy0uRAjJR5Orpg_003D_003D;
			int num2 = 1;
			if (2 == 0)
			{
			}
			levelSelectWidget._0023_003DqdVCtfyv4Nt_0024cSl0LDY6nGSmPInsAp8EkFYh9T_3u3qk_003D(_0023_003DqqlvK5N00aAGgiFOsSHqE6A_003D_003D);
		}
	}

	private sealed class _0023_003DqJnpcc3dfxhHuLYL68R9zspMiYUrbVb0BGbNixu6Wjsk_003D
	{
		internal _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003Dq1_KMJmR8TKilyVn6DSS1K6d02G4cqD5A4TEjXXtHr_4_003D;

		internal LevelSelectWidget _0023_003Dq1qrkzF2pDv7fH1PviwZZeA_003D_003D;

		public _0023_003DqJnpcc3dfxhHuLYL68R9zspMiYUrbVb0BGbNixu6Wjsk_003D()
		{
			int num = 7;
			if (5 == 0)
			{
			}
			base._002Ector();
		}

		internal void _0023_003Dqig3uFb6hsSv_2d8EEDZUaw_003D_003D()
		{
			int num = 2;
			if (5 == 0)
			{
			}
			LevelSelectWidget levelSelectWidget = _0023_003Dq1qrkzF2pDv7fH1PviwZZeA_003D_003D;
			int num2 = 1;
			if (1 == 0)
			{
			}
			levelSelectWidget._0023_003DqeuINlxKw0zSSZ8s9lJF1AA4BD5e4ExM0EfVUi_0024x6MyA_003D(_0023_003Dq1_KMJmR8TKilyVn6DSS1K6d02G4cqD5A4TEjXXtHr_4_003D);
		}
	}

	private sealed class _0023_003DqvCPBfmC01UD8z572Fz3ew84Jj4N0mzHg5H4EGbnXxWs_003D
	{
		internal int _0023_003DqwXA4Vd_ntLqvXFPxl2KWdg_003D_003D;

		internal LevelSelectWidget _0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D;

		public _0023_003DqvCPBfmC01UD8z572Fz3ew84Jj4N0mzHg5H4EGbnXxWs_003D()
		{
			int num = 8;
			if (8 == 0)
			{
			}
			base._002Ector();
		}

		internal void _0023_003DqdqEl_00244IZ1w4Jrk20axD3EA_003D_003D()
		{
			int num = 0;
			if (6 == 0)
			{
			}
			LevelSelectWidget levelSelectWidget = _0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D;
			int num2 = 2;
			if (false)
			{
			}
			levelSelectWidget._0023_003Dqn3Mnu1yO5plxWo1WC62QN6jxfwBNSa887tVJ6QIvEcM_003D(_0023_003DqwXA4Vd_ntLqvXFPxl2KWdg_003D_003D);
		}

		internal void _0023_003DqWnB_0024A2H7Zp23fKovxQj3Ww_003D_003D()
		{
			int num = 5;
			if (8 == 0)
			{
			}
			LevelSelectWidget levelSelectWidget = _0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D;
			int num2 = 2;
			if (false)
			{
			}
			levelSelectWidget._0023_003DqdVCtfyv4Nt_0024cSl0LDY6nGSmPInsAp8EkFYh9T_3u3qk_003D(_0023_003DqwXA4Vd_ntLqvXFPxl2KWdg_003D_003D);
		}
	}

	public LevelButtonWidget PrefabLevelButtonWidget;

	public Text PuzzleInfoText;

	public RectTransform PuzzlePanel;

	public RectTransform SandboxPanel;

	public SlotButtonWidget[] PuzzleSlotButtons;

	public SlotButtonWidget[] SandboxSlotButtons;

	public Button[] OpenSaveDirectoryButtons;

	public Histogram CycleHistogram;

	public Histogram NodeHistogram;

	public Histogram InstructionHistogram;

	public Button LevelEditorButton;

	public Button BonusCampaignButton;

	public Button BonusCampaignDisabledButton;

	public Text BonusCampaignDisabledText;

	private _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D;

	private List<LevelButtonWidget> _0023_003DqNWH_00244esIFwB8KHyMAuQymw_003D_003D;

	private static Func<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D, bool> _0023_003Dqq6k00uqvw2ZyybK1Wm1MaQskjouXGRYK_Q4UbDo3BO4_003D;

	private static Func<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D, bool> _0023_003DqYMGpoWGpWyTrsLYEbo08yr_5Fo_0024gdwZAo8mHl_0024XgkN0_003D;

	public LevelSelectWidget()
	{
		int num = -1;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	private GameObject _0023_003DqPKRfSyC8nXIdEjXH6agvF0bNXbDbMe2fchoHa9aPnMc_003D()
	{
		int num = 0;
		if (4 == 0)
		{
		}
		return base.gameObject;
	}

	GameObject _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D._0023_003DqJaI64gkjCxAvXrUlNIDc_w_003D_003D()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qPKRfSyC8nXIdEjXH6agvF0bNXbDbMe2fchoHa9aPnMc=
		return this._0023_003DqPKRfSyC8nXIdEjXH6agvF0bNXbDbMe2fchoHa9aPnMc_003D();
	}

	private void _0023_003Dq193TyvxI31XHE8gfxkQWlFW6RpKGcDDHPNczwBJWaD8_003D()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqS_04_CA7V7vH0vlOi5KlTkdd_00247ZlWNe30bGhpiok1pQ_003D();
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003Dq_0024L7KW8_0024Gy9tVMtyRzif0h67e7yYzXIgMJSDwB21zbV8_003D();
		}
		else if (Input.GetKeyDown(KeyCode.F12) && _0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqwIxajgIEZTbw14GNhftl9VmaWh3PWUlrg_0024PFtxAjKzc_003D() && _0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003Dq11Zq4p_0024aono1Gcvwp9mso8Io02_0024g5GbuP23hSS0aR_0024I_003D())
		{
			bool _0023_003DqrNmNqoK48uW8_0024TxWZGHbOwlYlUA5FiS8QI_0024AZBQRWTU_003D = !_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqrNmNqoK48uW8_0024TxWZGHbOwlYlUA5FiS8QI_0024AZBQRWTU_003D;
			if (2u != 0)
			{
				_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqrNmNqoK48uW8_0024TxWZGHbOwlYlUA5FiS8QI_0024AZBQRWTU_003D = _0023_003DqrNmNqoK48uW8_0024TxWZGHbOwlYlUA5FiS8QI_0024AZBQRWTU_003D;
			}
			_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D);
		}
	}

	void _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D._0023_003DqV9WY5da_ySQ1wPlaJijNDg_003D_003D()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=q193TyvxI31XHE8gfxkQWlFW6RpKGcDDHPNczwBJWaD8=
		this._0023_003Dq193TyvxI31XHE8gfxkQWlFW6RpKGcDDHPNczwBJWaD8_003D();
	}

	public void Start()
	{
		OpenSaveDirectoryButtons._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003Dqp_dzv0leLwfGIMwWTjArBg_003D_003D);
		LevelEditorButton.onClick.AddListener(_0023_003Dq7WQYd048JbtFmUyVXlC2hhhm18pokRGVgI0NoxkTd2o_003D);
		BonusCampaignButton.onClick.AddListener(_0023_003Dq9npGUjzrjNXxlCYCwf4ynuAIDRkEYjEUtIk3CLT1dbk_003D);
		int i;
		if (7u != 0)
		{
			i = 0;
		}
		for (; i < PuzzleSlotButtons.Length; i++)
		{
			_0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D obj = new _0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D();
			_0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D _0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D2;
			if (5u != 0)
			{
				_0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D2 = obj;
			}
			if (6u != 0)
			{
				_0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D2._0023_003DqQyEyZx0Xqy0uRAjJR5Orpg_003D_003D = this;
			}
			_0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D2._0023_003DqqlvK5N00aAGgiFOsSHqE6A_003D_003D = i;
			PuzzleSlotButtons[i].SlotButton.onClick.AddListener(_0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D2._0023_003DqhqshrYiIIX7UezLOtWyihA_003D_003D);
			PuzzleSlotButtons[i].CopyButton.onClick.AddListener(_0023_003DqciNCvyCRD0yHhyemBgW8SbDOcM3e0FixuWVyyS1ZVNs_003D2._0023_003DqDlWhwZr2CgeFutQ9wd3ikQ_003D_003D);
		}
		for (int j = 0; j < SandboxSlotButtons.Length; j++)
		{
			_0023_003DqvCPBfmC01UD8z572Fz3ew84Jj4N0mzHg5H4EGbnXxWs_003D CS_0024_003C_003E8__locals6 = new _0023_003DqvCPBfmC01UD8z572Fz3ew84Jj4N0mzHg5H4EGbnXxWs_003D();
			CS_0024_003C_003E8__locals6._0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D = this;
			CS_0024_003C_003E8__locals6._0023_003DqwXA4Vd_ntLqvXFPxl2KWdg_003D_003D = j;
			SandboxSlotButtons[j].SlotButton.onClick.AddListener(delegate
			{
				int num = 0;
				if (6 == 0)
				{
				}
				LevelSelectWidget _0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D = CS_0024_003C_003E8__locals6._0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D;
				int num2 = 2;
				if (false)
				{
				}
				_0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D._0023_003Dqn3Mnu1yO5plxWo1WC62QN6jxfwBNSa887tVJ6QIvEcM_003D(CS_0024_003C_003E8__locals6._0023_003DqwXA4Vd_ntLqvXFPxl2KWdg_003D_003D);
			});
			SandboxSlotButtons[j].CopyButton.onClick.AddListener(delegate
			{
				int num3 = 5;
				if (8 == 0)
				{
				}
				LevelSelectWidget _0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D = CS_0024_003C_003E8__locals6._0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D;
				int num4 = 2;
				if (false)
				{
				}
				_0023_003DqznNg1jwVjf_0024ivZZYKPb8zA_003D_003D._0023_003DqdVCtfyv4Nt_0024cSl0LDY6nGSmPInsAp8EkFYh9T_3u3qk_003D(CS_0024_003C_003E8__locals6._0023_003DqwXA4Vd_ntLqvXFPxl2KWdg_003D_003D);
			});
		}
	}

	public void Initialize(global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D> _0023_003DqFIqUSWd_0024ExV4F_cSWNj1FQ_003D_003D)
	{
		if (_0023_003DqFIqUSWd_0024ExV4F_cSWNj1FQ_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D() && _0023_003DqFIqUSWd_0024ExV4F_cSWNj1FQ_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003Dq_00246oKMAip73sL7doz_CtwQQ_003D_003D)
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D> obj = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
			if (true)
			{
				_0023_003DqFIqUSWd_0024ExV4F_cSWNj1FQ_003D_003D = obj;
			}
		}
		IEnumerable<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D> source = _0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DqNSUh5VDqbL5EZK27KGtbO7DgwVXl381aNnI7LhXKYkU_003D();
		if (_0023_003Dqq6k00uqvw2ZyybK1Wm1MaQskjouXGRYK_Q4UbDo3BO4_003D == null)
		{
			Func<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D, bool> func = delegate(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqMd_0024_0024gu_0024f1GcDcHkpxXHSDA_003D_003D)
			{
				int num3 = 1;
				if (-1 == 0)
				{
				}
				int result;
				if (_0023_003DqMd_0024_0024gu_0024f1GcDcHkpxXHSDA_003D_003D._0023_003DqgIZeKHjpb3DWG3JGkCVDlA_003D_003D())
				{
					int num4 = 6;
					if (3 == 0)
					{
					}
					result = ((_0023_003DqMd_0024_0024gu_0024f1GcDcHkpxXHSDA_003D_003D._0023_003Dqwl6R8LkbULUWblsGhtQQbg_003D_003D == (_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003DqgNaolQmxqs1nuTZbHAY6nA_003D_003D)0) ? 1 : 0);
				}
				else
				{
					result = 0;
				}
				return (byte)result != 0;
			};
			if (3u != 0)
			{
				_0023_003Dqq6k00uqvw2ZyybK1Wm1MaQskjouXGRYK_Q4UbDo3BO4_003D = func;
			}
		}
		int num = source.Count(_0023_003Dqq6k00uqvw2ZyybK1Wm1MaQskjouXGRYK_Q4UbDo3BO4_003D);
		int num2;
		if (true)
		{
			num2 = num;
		}
		IEnumerable<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D> source2 = _0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DqNSUh5VDqbL5EZK27KGtbO7DgwVXl381aNnI7LhXKYkU_003D();
		if (_0023_003DqYMGpoWGpWyTrsLYEbo08yr_5Fo_0024gdwZAo8mHl_0024XgkN0_003D == null)
		{
			Func<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D, bool> func2 = _0023_003DqiC9IT3FUFFvKuRH_i0Ta4nZozNB3xOhVKkvOA09TFx8_003D;
			if (true)
			{
				_0023_003DqYMGpoWGpWyTrsLYEbo08yr_5Fo_0024gdwZAo8mHl_0024XgkN0_003D = func2;
			}
		}
		_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D = _0023_003DqFIqUSWd_0024ExV4F_cSWNj1FQ_003D_003D._0023_003DqJ75nbFW4ANt1NB_00241xA73Aw_003D_003D(source2.Where(_0023_003DqYMGpoWGpWyTrsLYEbo08yr_5Fo_0024gdwZAo8mHl_0024XgkN0_003D)._0023_003Dq_LoHFM9bEEhQdhJbd03LQA_003D_003D()._0023_003DqJ75nbFW4ANt1NB_00241xA73Aw_003D_003D(_0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DqNSUh5VDqbL5EZK27KGtbO7DgwVXl381aNnI7LhXKYkU_003D().First()));
		_0023_003DqNWH_00244esIFwB8KHyMAuQymw_003D_003D = new List<LevelButtonWidget>();
		foreach (_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D item in _0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DqNSUh5VDqbL5EZK27KGtbO7DgwVXl381aNnI7LhXKYkU_003D())
		{
			_0023_003DqJnpcc3dfxhHuLYL68R9zspMiYUrbVb0BGbNixu6Wjsk_003D _0023_003DqJnpcc3dfxhHuLYL68R9zspMiYUrbVb0BGbNixu6Wjsk_003D2 = new _0023_003DqJnpcc3dfxhHuLYL68R9zspMiYUrbVb0BGbNixu6Wjsk_003D();
			_0023_003DqJnpcc3dfxhHuLYL68R9zspMiYUrbVb0BGbNixu6Wjsk_003D2._0023_003Dq1qrkzF2pDv7fH1PviwZZeA_003D_003D = this;
			_0023_003DqJnpcc3dfxhHuLYL68R9zspMiYUrbVb0BGbNixu6Wjsk_003D2._0023_003Dq1_KMJmR8TKilyVn6DSS1K6d02G4cqD5A4TEjXXtHr_4_003D = item;
			LevelButtonWidget levelButtonWidget = PrefabLevelButtonWidget._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D(base.gameObject, new Vector2(450 + 182 * (_0023_003DqNWH_00244esIFwB8KHyMAuQymw_003D_003D.Count % 5), -104 - 134 * (_0023_003DqNWH_00244esIFwB8KHyMAuQymw_003D_003D.Count / 5)));
			_0023_003DqNWH_00244esIFwB8KHyMAuQymw_003D_003D.Add(levelButtonWidget);
			levelButtonWidget.Initialize(item);
			levelButtonWidget.ActiveButton.onClick.AddListener(_0023_003DqJnpcc3dfxhHuLYL68R9zspMiYUrbVb0BGbNixu6Wjsk_003D2._0023_003Dqig3uFb6hsSv_2d8EEDZUaw_003D_003D);
			levelButtonWidget.LockOrUnlock(num2);
			levelButtonWidget.IsSolved = item._0023_003DqgIZeKHjpb3DWG3JGkCVDlA_003D_003D();
		}
		if (num2 >= _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003Dq0zISDcYOlo0ft6zpQ3dM8zapkkyr0Tc4J6gwOxjZoEI_003D)
		{
			BonusCampaignButton.gameObject.SetActive(true);
			BonusCampaignDisabledButton.gameObject.SetActive(false);
		}
		else
		{
			BonusCampaignButton.gameObject.SetActive(false);
			BonusCampaignDisabledButton.gameObject.SetActive(true);
			BonusCampaignDisabledText.text = string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992381), _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003Dq0zISDcYOlo0ft6zpQ3dM8zapkkyr0Tc4J6gwOxjZoEI_003D - num2);
		}
		if (!_0023_003DqKq_0024_BTg7MU1hGFwgqPsYjs2BzARdanirUNp_0024GDKGu_0024c_003D._0023_003DqKHa5upgfDBwxZqf7GWOc_0024DHdGI8WZOAi4sUIZptZjOc_003D())
		{
			_0023_003DqKq_0024_BTg7MU1hGFwgqPsYjs2BzARdanirUNp_0024GDKGu_0024c_003D._0023_003DqM7BGUf6iLzv59LziLFKNF1Vr2xnLbNzpvBz2L_m5x3A_003D(true);
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003Dq5Xq2kSvyBdA_VXKXFgqt25HRsd1ua_6N4P_GbapbOac_003D();
		}
		Cursor.visible = true;
		_0023_003DqoNiJ97nq2WbhU6blDLQeTA_003D_003D();
	}

	private void _0023_003DqoNiJ97nq2WbhU6blDLQeTA_003D_003D()
	{
		_0023_003DqNWH_00244esIFwB8KHyMAuQymw_003D_003D.ForEach(_0023_003DqNmW5uEpmjZeHLvsAE5_cQw_003D_003D);
		PuzzleInfoText.text = string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693976608), _0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003DqtTvEXXGbpBW4Rhvpc7H3iw_003D_003D);
		if (_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dqwl6R8LkbULUWblsGhtQQbg_003D_003D == (_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003DqgNaolQmxqs1nuTZbHAY6nA_003D_003D)0)
		{
			PuzzlePanel.gameObject.SetActive(true);
			SandboxPanel.gameObject.SetActive(false);
			HashSet<int> hashSet = new HashSet<int>();
			HashSet<int> hashSet2;
			if (8u != 0)
			{
				hashSet2 = hashSet;
			}
			int num;
			if (true)
			{
				num = 0;
			}
			while (num < PuzzleSlotButtons.Length)
			{
				if (File.Exists(_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num)))
				{
					string text = _0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqnZZOBp_NyT8a0M6o1riWGa8GVe0Fc0hjzyYHLg5bbuM_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num);
					string text2;
					if (6u != 0)
					{
						text2 = text;
					}
					global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<Dictionary<_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D, int>> obj = _0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqddeKaXEeW_ew9LN7Ne9YnQ_003D_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num);
					global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<Dictionary<_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D, int>> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
					if (true)
					{
						_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = obj;
					}
					if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
					{
						PuzzleSlotButtons[num].SetSolved(text2, _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()[(_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)0], _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()[(_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)2], _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()[(_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)1]);
					}
					else
					{
						PuzzleSlotButtons[num].SetUnsolved(text2);
					}
					hashSet2.Add(num);
				}
				else
				{
					PuzzleSlotButtons[num].SetEmpty();
				}
				int num2 = num + 1;
				if (4u != 0)
				{
					num = num2;
				}
			}
			int num3;
			if (4u != 0)
			{
				num3 = 0;
			}
			while (num3 < PuzzleSlotButtons.Length)
			{
				PuzzleSlotButtons[num3].CopyEnabled = hashSet2.Contains(num3) && hashSet2.Count < PuzzleSlotButtons.Length;
				int num4 = num3 + 1;
				if (8u != 0)
				{
					num3 = num4;
				}
			}
			_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqngdJYRjTGOeX5kC33BlhV9CYVW9mQfQL_0024ct5ZgGXLe4_003D(CycleHistogram, _0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D, (_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)0);
			_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqngdJYRjTGOeX5kC33BlhV9CYVW9mQfQL_0024ct5ZgGXLe4_003D(NodeHistogram, _0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D, (_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)2);
			_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqngdJYRjTGOeX5kC33BlhV9CYVW9mQfQL_0024ct5ZgGXLe4_003D(InstructionHistogram, _0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D, (_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)1);
			return;
		}
		PuzzlePanel.gameObject.SetActive(false);
		SandboxPanel.gameObject.SetActive(true);
		HashSet<int> hashSet3 = new HashSet<int>();
		for (int i = 0; i < SandboxSlotButtons.Length; i++)
		{
			if (File.Exists(_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), i)))
			{
				string sandbox = _0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqnZZOBp_NyT8a0M6o1riWGa8GVe0Fc0hjzyYHLg5bbuM_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), i);
				SandboxSlotButtons[i].SetSandbox(sandbox);
				hashSet3.Add(i);
			}
			else
			{
				SandboxSlotButtons[i].SetEmpty();
			}
		}
		for (int j = 0; j < SandboxSlotButtons.Length; j++)
		{
			SandboxSlotButtons[j].CopyEnabled = hashSet3.Contains(j) && hashSet3.Count < SandboxSlotButtons.Length;
		}
	}

	private void _0023_003DqeuINlxKw0zSSZ8s9lJF1AA4BD5e4ExM0EfVUi_0024x6MyA_003D(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003Dqby9oL4HZYulYNdH6Q1PmRw_003D_003D)
	{
		if (true)
		{
			_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D = _0023_003Dqby9oL4HZYulYNdH6Q1PmRw_003D_003D;
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		_0023_003DqoNiJ97nq2WbhU6blDLQeTA_003D_003D();
	}

	private void _0023_003Dqn3Mnu1yO5plxWo1WC62QN6jxfwBNSa887tVJ6QIvEcM_003D(int _0023_003Dq4CtNCCBfpoPORYnSdfcIZg_003D_003D)
	{
		int num = 2;
		if (6 == 0)
		{
		}
		_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqVItL8TPkfvaBQS0HAP9isg_003D_003D = _0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D;
		int num2 = -1;
		if (3 == 0)
		{
		}
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq6Zw62nChD4luLafKIQN9QYCVPk0bVXdbmwkDY6UjCLE_003D(_0023_003DqVItL8TPkfvaBQS0HAP9isg_003D_003D, _0023_003Dq4CtNCCBfpoPORYnSdfcIZg_003D_003D);
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
	}

	private void _0023_003DqdVCtfyv4Nt_0024cSl0LDY6nGSmPInsAp8EkFYh9T_3u3qk_003D(int _0023_003Dq1uHU2tj0LVq3wYGYvSyOeQ_003D_003D)
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		int num;
		if (3u != 0)
		{
			num = 0;
		}
		while (File.Exists(_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num)))
		{
			int num2 = num + 1;
			if (0 == 0)
			{
				num = num2;
			}
		}
		File.Copy(_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003Dq1uHU2tj0LVq3wYGYvSyOeQ_003D_003D), _0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num));
		_0023_003DqoNiJ97nq2WbhU6blDLQeTA_003D_003D();
	}

	private void _0023_003DqyxMXKxpVgcs7eqSD0jUwjoUrZ2YsJ8CNjqKF7HgU9tJzWhAecVJ1Z9216EKomraY()
	{
		_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqKSvs_i5TaZZX55RFt_0024xGbwqLlnmzMNd8aE7P8vMLhCk_003D();
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
	}

	private void _0023_003Dq7WQYd048JbtFmUyVXlC2hhhm18pokRGVgI0NoxkTd2o_003D()
	{
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003DqfVw_WQ_0024k31EDb_9AgZNnQ2DF9m2yD7KbqojV9YlloqM_003D();
	}

	private void _0023_003Dq9npGUjzrjNXxlCYCwf4ynuAIDRkEYjEUtIk3CLT1dbk_003D()
	{
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003DqxYh_7Xrv6jPxD3QBTgCuazvdhClNlCtIFQtOiewEdBo_003D();
	}

	private void _0023_003Dqp_dzv0leLwfGIMwWTjArBg_003D_003D(Button _0023_003DqrH3_0024Lk6an7RU8Pdc7_Ku_0024w_003D_003D)
	{
		int num = 1;
		if (8 == 0)
		{
		}
		Button.ButtonClickedEvent onClick = _0023_003DqrH3_0024Lk6an7RU8Pdc7_Ku_0024w_003D_003D.onClick;
		int num2 = 4;
		if (7 == 0)
		{
		}
		onClick.AddListener(_0023_003DqyxMXKxpVgcs7eqSD0jUwjoUrZ2YsJ8CNjqKF7HgU9tJzWhAecVJ1Z9216EKomraY);
	}

	private static bool _0023_003DqCRCLPH8wZ17_0024jcEupz9A3BNIQzODl3wiWTV_3P5KxLU_003D(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqMd_0024_0024gu_0024f1GcDcHkpxXHSDA_003D_003D)
	{
		int num = 1;
		if (-1 == 0)
		{
		}
		int result;
		if (_0023_003DqMd_0024_0024gu_0024f1GcDcHkpxXHSDA_003D_003D._0023_003DqgIZeKHjpb3DWG3JGkCVDlA_003D_003D())
		{
			int num2 = 6;
			if (3 == 0)
			{
			}
			result = ((_0023_003DqMd_0024_0024gu_0024f1GcDcHkpxXHSDA_003D_003D._0023_003Dqwl6R8LkbULUWblsGhtQQbg_003D_003D == (_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003DqgNaolQmxqs1nuTZbHAY6nA_003D_003D)0) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private static bool _0023_003DqiC9IT3FUFFvKuRH_i0Ta4nZozNB3xOhVKkvOA09TFx8_003D(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqGOyP9_0024hHo1GKbHDZUXSiyQ_003D_003D)
	{
		int num = -1;
		if (6 == 0)
		{
		}
		return !_0023_003DqGOyP9_0024hHo1GKbHDZUXSiyQ_003D_003D._0023_003DqgIZeKHjpb3DWG3JGkCVDlA_003D_003D();
	}

	private void _0023_003DqNmW5uEpmjZeHLvsAE5_cQw_003D_003D(LevelButtonWidget _0023_003DqIz1BVZHBK4ir5WzbNzsugQ_003D_003D)
	{
		int num = 5;
		if (6 == 0)
		{
		}
		int num2 = 7;
		if (1 == 0)
		{
		}
		_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D obj = _0023_003DqW1ESyc9hN7pkvsAKy7QH3g_003D_003D;
		int num3 = 7;
		if (1 == 0)
		{
		}
		_0023_003DqIz1BVZHBK4ir5WzbNzsugQ_003D_003D.IsSelected = obj == _0023_003DqIz1BVZHBK4ir5WzbNzsugQ_003D_003D._0023_003DqZHPBTw0_0024vowWlmCAd2SbMQ_003D_003D();
	}
}
