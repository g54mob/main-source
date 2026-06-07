using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public sealed class TitleWidget : MonoBehaviour, _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D, IEventSystemHandler, IPointerClickHandler
{
	public static readonly string Text1;

	public static readonly string Text2;

	public static readonly string Text3;

	public static readonly string Text4;

	public Text Text;

	public Image Logo;

	private float _0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D;

	private bool _0023_003DqGAPRzdsVQurK8mfrkFGbkA_003D_003D;

	private bool _0023_003Dqoy_7KrMzeZ33boUhO4eCf3xism9d1qW0bF9QY2LEcus_003D;

	private static Func<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D, bool> _0023_003DqjYet__VKZUmJ1RHDqGMC3A_003D_003D;

	public TitleWidget()
	{
		int num = 5;
		if (5 == 0)
		{
		}
		base._002Ector();
	}

	static TitleWidget()
	{
		string text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694021927);
		if (6u != 0)
		{
			Text1 = text;
		}
		string text2 = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694021982);
		if (2u != 0)
		{
			Text2 = text2;
		}
		string text3 = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022336);
		if (3u != 0)
		{
			Text3 = text3;
		}
		Text4 = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022304);
	}

	private void _0023_003DqrwhM39lkaWvZ_0024KcZfJfhbbyhtRRATdqi5OfRqZeWBtGEv0UDTMTsgn6WEPnwyZcMenqhDL09xKHoEXENR_dGOA_003D_003D(PointerEventData _0023_003Dqg3RgtGKBZfEz5R9pc2dWHg_003D_003D)
	{
		if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqIdkwNwG6hDuD_00247ZBnU6PSg_003D_003D)
		{
			_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D);
		}
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData _0023_003Dqg3RgtGKBZfEz5R9pc2dWHg_003D_003D)
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qrwhM39lkaWvZ$KcZfJfhbbyhtRRATdqi5OfRqZeWBtGEv0UDTMTsgn6WEPnwyZcMenqhDL09xKHoEXENR_dGOA==
		this._0023_003DqrwhM39lkaWvZ_0024KcZfJfhbbyhtRRATdqi5OfRqZeWBtGEv0UDTMTsgn6WEPnwyZcMenqhDL09xKHoEXENR_dGOA_003D_003D(_0023_003Dqg3RgtGKBZfEz5R9pc2dWHg_003D_003D);
	}

	private GameObject _0023_003Dq4HHjq66Wry7PkVsr7x_PXzCYfMOX8rtQ82nqfKdyInU_003D()
	{
		int num = 0;
		if (2 == 0)
		{
		}
		return base.gameObject;
	}

	GameObject _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D._0023_003DqJaI64gkjCxAvXrUlNIDc_w_003D_003D()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=q4HHjq66Wry7PkVsr7x_PXzCYfMOX8rtQ82nqfKdyInU=
		return this._0023_003Dq4HHjq66Wry7PkVsr7x_PXzCYfMOX8rtQ82nqfKdyInU_003D();
	}

	private void _0023_003DqVBm_0024qLEzk3_Zd8jBegdZgUUcAMy97ejMKT3nicsb7jg_003D()
	{
		if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect.State == (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)3)
		{
			return;
		}
		float num = _0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D + Time.deltaTime;
		if (2u != 0)
		{
			_0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D = num;
		}
		Text.text = string.Empty;
		if ((double)_0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D > 1.0)
		{
			Text.text += Text1;
			Logo.gameObject.SetActive(true);
		}
		if ((double)_0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D > 2.0)
		{
			Text.text += string.Format(Text2, (!((double)_0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D > 2.5)) ? string.Empty : _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022179));
		}
		if ((double)_0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D > 3.0)
		{
			float num2 = Mathf.Clamp01((_0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D - 3f) / 2f);
			float num3;
			if (7u != 0)
			{
				num3 = num2;
			}
			int num4 = (int)(num3 * 4194304f);
			int num5;
			if (6u != 0)
			{
				num5 = num4;
			}
			Text.text += string.Format(Text3, num5);
		}
		if ((double)_0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D > 7.0)
		{
			if (_0023_003Dqoy_7KrMzeZ33boUhO4eCf3xism9d1qW0bF9QY2LEcus_003D)
			{
				_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D);
			}
			else
			{
				Text.text += Text4;
				if (!_0023_003DqGAPRzdsVQurK8mfrkFGbkA_003D_003D)
				{
					_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundError._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
					_0023_003DqGAPRzdsVQurK8mfrkFGbkA_003D_003D = true;
				}
			}
		}
		if ((double)_0023_003DqbFdjMuBC8Wk0b9FmO_wa1Q_003D_003D > 9.0)
		{
			_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D);
		}
	}

	void _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D._0023_003DqV9WY5da_ySQ1wPlaJijNDg_003D_003D()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qVBm$qLEzk3_Zd8jBegdZgUUcAMy97ejMKT3nicsb7jg=
		this._0023_003DqVBm_0024qLEzk3_Zd8jBegdZgUUcAMy97ejMKT3nicsb7jg_003D();
	}

	public void Initialize()
	{
		IEnumerable<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D> source = _0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DqNSUh5VDqbL5EZK27KGtbO7DgwVXl381aNnI7LhXKYkU_003D();
		if (_0023_003DqjYet__VKZUmJ1RHDqGMC3A_003D_003D == null)
		{
			Func<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D, bool> func = _0023_003DqFQyBuwEMVzgcduI5WCU1eF4nwGXX8xeBhximaYoiBHk_003D;
			if (8u != 0)
			{
				_0023_003DqjYet__VKZUmJ1RHDqGMC3A_003D_003D = func;
			}
		}
		bool num = source.All(_0023_003DqjYet__VKZUmJ1RHDqGMC3A_003D_003D);
		if (2u != 0)
		{
			_0023_003Dqoy_7KrMzeZ33boUhO4eCf3xism9d1qW0bF9QY2LEcus_003D = num;
		}
	}

	private static bool _0023_003DqFQyBuwEMVzgcduI5WCU1eF4nwGXX8xeBhximaYoiBHk_003D(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqbiNAZWwpZX1GZbzaq1X0Ow_003D_003D)
	{
		int num = 3;
		if (4 == 0)
		{
		}
		int result;
		if (_0023_003DqbiNAZWwpZX1GZbzaq1X0Ow_003D_003D._0023_003Dqwl6R8LkbULUWblsGhtQQbg_003D_003D == (_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003DqgNaolQmxqs1nuTZbHAY6nA_003D_003D)0)
		{
			int num2 = 6;
			if (7 == 0)
			{
			}
			result = (_0023_003DqbiNAZWwpZX1GZbzaq1X0Ow_003D_003D._0023_003DqgIZeKHjpb3DWG3JGkCVDlA_003D_003D() ? 1 : 0);
		}
		else
		{
			result = 1;
		}
		return (byte)result != 0;
	}
}
