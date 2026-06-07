using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public sealed class Histogram : MonoBehaviour
{
	private static readonly int _0023_003Dqj_pbodLs_orsJEAjGg9SKrQGi8ytn2uok3H9DuZy54A_003D;

	public RectTransform Indicator;

	public Text IndicatorTextLeft;

	public Text IndicatorTextRight;

	public RectTransform[] Bars;

	public Text[] Labels;

	private static Action<RectTransform> _0023_003DqJR_DjPDe3z5ypgEofKhMbA_003D_003D;

	private static Action<Text> _0023_003Dqh19n3pC_27AcOOCPkSvxNw_003D_003D;

	public Histogram()
	{
		int num = 7;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	static Histogram()
	{
		if (8u != 0)
		{
			_0023_003Dqj_pbodLs_orsJEAjGg9SKrQGi8ytn2uok3H9DuZy54A_003D = 9;
		}
	}

	public void Reset()
	{
		int num = 2;
		if (3 == 0)
		{
		}
		_0023_003DqaZ9yVoTPxY332hkc7Of_yg_003D_003D();
	}

	private void _0023_003DqaZ9yVoTPxY332hkc7Of_yg_003D_003D()
	{
		Indicator.gameObject.SetActive(false);
		RectTransform[] bars = Bars;
		if (_0023_003DqJR_DjPDe3z5ypgEofKhMbA_003D_003D == null)
		{
			Action<RectTransform> action = delegate(RectTransform _0023_003Dq5WiHmvjAUigudA7kIJ_L8g_003D_003D)
			{
				int num = 0;
				if (2 == 0)
				{
				}
				_0023_003Dq5WiHmvjAUigudA7kIJ_L8g_003D_003D.gameObject.SetActive(false);
			};
			if (2u != 0)
			{
				_0023_003DqJR_DjPDe3z5ypgEofKhMbA_003D_003D = action;
			}
		}
		bars._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003DqJR_DjPDe3z5ypgEofKhMbA_003D_003D);
		Text[] labels = Labels;
		if (_0023_003Dqh19n3pC_27AcOOCPkSvxNw_003D_003D == null)
		{
			Action<Text> action2 = delegate(Text _0023_003Dq_0024X_0024unu4Qis_0024_0024y0gt_cG8Fw_003D_003D)
			{
				int num2 = 4;
				if (-1 == 0)
				{
				}
				_0023_003Dq_0024X_0024unu4Qis_0024_0024y0gt_cG8Fw_003D_003D.text = string.Empty;
			};
			if (true)
			{
				_0023_003Dqh19n3pC_27AcOOCPkSvxNw_003D_003D = action2;
			}
		}
		labels._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003Dqh19n3pC_27AcOOCPkSvxNw_003D_003D);
	}

	public void ConfigureHistogram(string _0023_003DqhQ2m6ikboog2pkXOA4jQxw_003D_003D, global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<int> _0023_003Dqi0PnNOadniV8s2t9wKEb3w_003D_003D)
	{
		try
		{
			string[] array = _0023_003DqhQ2m6ikboog2pkXOA4jQxw_003D_003D.Split(',');
			string[] array2;
			if (2u != 0)
			{
				array2 = array;
			}
			int num = int.Parse(array2[0]);
			int num2;
			if (8u != 0)
			{
				num2 = num;
			}
			int[] array3 = new int[array2.Length - 1];
			int[] array4;
			if (uint.MaxValue != 0)
			{
				array4 = array3;
			}
			int num3;
			if (7u != 0)
			{
				num3 = 1;
			}
			while (num3 < array2.Length)
			{
				array4[num3 - 1] = int.Parse(array2[num3]);
				int num4 = num3 + 1;
				if (uint.MaxValue != 0)
				{
					num3 = num4;
				}
			}
			if (array4.Length == Bars.Length * 2)
			{
				int num5;
				if (8u != 0)
				{
					num5 = 0;
				}
				while (num5 < Bars.Length)
				{
					array4[num5] = array4[num5 * 2] + array4[num5 * 2 + 1];
					int num6 = num5 + 1;
					if (8u != 0)
					{
						num5 = num6;
					}
				}
			}
			int num7 = array4.Max();
			for (int i = 0; i < Bars.Length; i++)
			{
				Bars[i].gameObject.SetActive(true);
				Bars[i].sizeDelta = new Vector2(8f, 12 * array4[i] / num7 * 6 + 6);
			}
			for (int j = 0; j < Labels.Length; j++)
			{
				int num8 = j * num2 / (Labels.Length - 1);
				Labels[j].text = ((num2 < 100000) ? num8._0023_003DqqsDhldGsWEKAcTChWQDx2lPaXQULMKr21v_0024NUCLhy0c_003D() : ((num8 / 1000)._0023_003DqqsDhldGsWEKAcTChWQDx2lPaXQULMKr21v_0024NUCLhy0c_003D() + _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991486)));
			}
			if (_0023_003Dqi0PnNOadniV8s2t9wKEb3w_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				int num9 = Mathf.Clamp(_0023_003Dqi0PnNOadniV8s2t9wKEb3w_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D() * Bars.Length / num2, 0, Bars.Length - 1);
				Indicator.anchoredPosition = new Vector2(17 + 8 * num9, -15f);
				Indicator.gameObject.SetActive(true);
				string text = _0023_003Dqi0PnNOadniV8s2t9wKEb3w_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqqsDhldGsWEKAcTChWQDx2lPaXQULMKr21v_0024NUCLhy0c_003D();
				bool flag = num9 > Bars.Length / 2;
				IndicatorTextLeft.text = ((!flag) ? string.Empty : text);
				IndicatorTextRight.text = ((!flag) ? text : string.Empty);
			}
		}
		catch (Exception)
		{
			_0023_003DqaZ9yVoTPxY332hkc7Of_yg_003D_003D();
		}
	}

	private static void _0023_003DqUFg_00248uRxlIOuTaqoo_3ZanomC1ylVsLQFV6FWTVeMWQ_003D(RectTransform _0023_003Dq5WiHmvjAUigudA7kIJ_L8g_003D_003D)
	{
		int num = 0;
		if (2 == 0)
		{
		}
		_0023_003Dq5WiHmvjAUigudA7kIJ_L8g_003D_003D.gameObject.SetActive(false);
	}

	private static void _0023_003Dq_MfzaVQtAyU7grWryHA2XwiEFpNg6X3l_0024IRjhP_W0_0024M_003D(Text _0023_003Dq_0024X_0024unu4Qis_0024_0024y0gt_cG8Fw_003D_003D)
	{
		int num = 4;
		if (-1 == 0)
		{
		}
		_0023_003Dq_0024X_0024unu4Qis_0024_0024y0gt_cG8Fw_003D_003D.text = string.Empty;
	}
}
