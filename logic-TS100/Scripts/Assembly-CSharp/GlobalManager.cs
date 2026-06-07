using System;
using System.Linq;
using UnityEngine;

public sealed class GlobalManager : MonoBehaviour
{
	private enum _0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D
	{

	}

	private static bool _0023_003Dq_Zdis8DpZVrI3feGjVyRxSAGpuiDJUK5TN4seqEGNTQ_003D;

	private static _0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D _0023_003DqTH7FmHaXiw737UAp8_0024_0024vf_0024bEucih5uN1Xs6P8Bk37_0024A_003D;

	private static Func<Resolution, int> _0023_003DqPylazNr_0024fQrO4GFgLq5_kQ_003D_003D;

	private static Func<Resolution, int> _0023_003DqXxxD8mDR_0024fRs22Y48FpWmQ_003D_003D;

	public GlobalManager()
	{
		int num = 7;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	public void Awake()
	{
		_0023_003DqnL5UurUxUxSsmS7twwncFQ_003D_003D._0023_003DqRY7TotBHDUR2PYPojEX15g_003D_003D();
	}

	public void Start()
	{
		Application.targetFrameRate = 30;
		QualitySettings.vSyncCount = 2;
		if (_0023_003DqKq_0024_BTg7MU1hGFwgqPsYjs2BzARdanirUNp_0024GDKGu_0024c_003D._0023_003DqMBebMthHWdmS2_pSM5_Mg9vNcAxC_XOCa6nqlzumueU_003D())
		{
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.BloomEffect.enabled = false;
		}
		int num = (Screen.fullScreen ? 2 : 0);
		if (8u != 0)
		{
			_0023_003DqTH7FmHaXiw737UAp8_0024_0024vf_0024bEucih5uN1Xs6P8Bk37_0024A_003D = (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)num;
		}
		_0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DqhnOkeWh8_5SoX5c_omy7vc6rxhEwjorAac5fjlo2X_k_003D();
		_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqaUY0KkgId1g_0024R3yng42Xmw_003D_003D();
		_0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqNFDuHAN_Tn__UXpmOQN4LA_003D_003D();
		Cursor.visible = false;
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003DqIUTIGYZ9u21W0_u0ztqeVA_003D_003D();
	}

	public void Update()
	{
		_0023_003DqgK0OQmXx_XVqKnomt5EO8pAUSt7d4BJRqCZMrYjKgRE_003D._0023_003DqTX5l35BFAkwcaSYLo9vSYg_003D_003D();
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect.ManualUpdate();
		if (!_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqXrELmpcvvieaI_0024_0024zqgFxgOQ5XKOL_UfnU44zZLtwgto_003D())
		{
			_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003DqiKEyOkUe3YtUAxxQHgQSapUKfg7Alj_0024YLloCbR6a3rw_003D();
		}
		if (_0023_003DqKq_0024_BTg7MU1hGFwgqPsYjs2BzARdanirUNp_0024GDKGu_0024c_003D._0023_003DqHTk2Qnal8KZpnzxz2ZGkm6NIGoJvbQItEYeSxkX3hM8_003D())
		{
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SharpenEffect.enabled = true;
			_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D num = _0023_003DqTH7FmHaXiw737UAp8_0024_0024vf_0024bEucih5uN1Xs6P8Bk37_0024A_003D;
			_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D _0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D2;
			if (5u != 0)
			{
				_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D2 = num;
			}
			switch (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D2)
			{
			case (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)0:
				Screen.SetResolution(1366, 768, true);
				if (5u != 0)
				{
					_0023_003DqTH7FmHaXiw737UAp8_0024_0024vf_0024bEucih5uN1Xs6P8Bk37_0024A_003D = (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)1;
				}
				break;
			case (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)1:
			{
				Resolution[] resolutions = Screen.resolutions;
				if (_0023_003DqPylazNr_0024fQrO4GFgLq5_kQ_003D_003D == null)
				{
					Func<Resolution, int> func = _0023_003Dq2MXfsirWYl3iJTSYtn1Gjg_003D_003D;
					if (6u != 0)
					{
						_0023_003DqPylazNr_0024fQrO4GFgLq5_kQ_003D_003D = func;
					}
				}
				IOrderedEnumerable<Resolution> source = resolutions.OrderByDescending(_0023_003DqPylazNr_0024fQrO4GFgLq5_kQ_003D_003D);
				if (_0023_003DqXxxD8mDR_0024fRs22Y48FpWmQ_003D_003D == null)
				{
					_0023_003DqXxxD8mDR_0024fRs22Y48FpWmQ_003D_003D = _0023_003DqTCfAtg5zHI5wHWkQpyRgqA_003D_003D;
				}
				Resolution resolution = source.OrderByDescending(_0023_003DqXxxD8mDR_0024fRs22Y48FpWmQ_003D_003D).First();
				Screen.SetResolution(resolution.width, resolution.height, true);
				_0023_003DqTH7FmHaXiw737UAp8_0024_0024vf_0024bEucih5uN1Xs6P8Bk37_0024A_003D = (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)2;
				break;
			}
			}
		}
		else
		{
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SharpenEffect.enabled = false;
			switch (_0023_003DqTH7FmHaXiw737UAp8_0024_0024vf_0024bEucih5uN1Xs6P8Bk37_0024A_003D)
			{
			case (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)2:
				Screen.SetResolution(1366, 768, true);
				_0023_003DqTH7FmHaXiw737UAp8_0024_0024vf_0024bEucih5uN1Xs6P8Bk37_0024A_003D = (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)1;
				break;
			case (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)1:
				Screen.SetResolution(1366, 768, false);
				_0023_003DqTH7FmHaXiw737UAp8_0024_0024vf_0024bEucih5uN1Xs6P8Bk37_0024A_003D = (_0023_003DqVqMz_v9sF2eFgCaLHDf9Jf4O842NpEaKRhwUbYXX3ZQ_003D)0;
				break;
			}
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqUAiX0RDHWl7aMOnS_0024sPsLA_003D_003D._0023_003DqXY1W9xzcsuDkP1TVkh3hpQ_003D_003D();
	}

	private void LateUpdate()
	{
		_0023_003DqlSpnuR1ZNETS_0024XX1LHmG0w_003D_003D._0023_003DqEZFRl6qttsQraDY_0024Ce5uJOTeR5IDTNxO9SQ_7JzFVFM_003D();
	}

	private static int _0023_003Dq2MXfsirWYl3iJTSYtn1Gjg_003D_003D(Resolution _0023_003Dqdb0Ag5bccxQdYwTy5L41dg_003D_003D)
	{
		return _0023_003Dqdb0Ag5bccxQdYwTy5L41dg_003D_003D.height;
	}

	private static int _0023_003DqTCfAtg5zHI5wHWkQpyRgqA_003D_003D(Resolution _0023_003DqTtWUMBEjVJQnZOrl3b2gBw_003D_003D)
	{
		return _0023_003DqTtWUMBEjVJQnZOrl3b2gBw_003D_003D.width;
	}
}
