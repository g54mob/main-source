using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using UnityEngine;

public static class _0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D
{
	public static readonly bool _0023_003DqhC3ZrGYOloDiao9QFHYAmJrayugw6ufeopuhWsWbHOs_003D;

	public static readonly bool _0023_003DquZhlSb0VFv_BBdN_00240sDv5w_003D_003D;

	public static readonly bool _0023_003DqZ1FpgMbWO74Y6B50_8NOIw_003D_003D;

	private static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<bool> _0023_003DqQhs_0024J6J8ZCq6A80rAcnPCJJTtr2JA0HQH5qtz_ccxkw_003D;

	private static global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<string> _0023_003DqBGh1FCTMzFM9r_B3Ws9fBA_003D_003D;

	static _0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D()
	{
		bool num = Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor;
		if (8u != 0)
		{
			_0023_003DqhC3ZrGYOloDiao9QFHYAmJrayugw6ufeopuhWsWbHOs_003D = num;
		}
		bool num2 = Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor;
		if (3u != 0)
		{
			_0023_003DquZhlSb0VFv_BBdN_00240sDv5w_003D_003D = num2;
		}
		bool num3 = Application.platform == RuntimePlatform.LinuxPlayer;
		if (3u != 0)
		{
			_0023_003DqZ1FpgMbWO74Y6B50_8NOIw_003D_003D = num3;
		}
	}

	[DllImport("user32.dll", EntryPoint = "GetKeyboardLayoutName")]
	private static extern long _0023_003DqVJHbnbksIfAWJVDgdckJ8BI6aNgHAvEdUn6MWjYyEOY_003D(StringBuilder _0023_003DqdBUWy_0024SGz1csDvFjnRYZMg_003D_003D);

	public static bool _0023_003DqeXeN32lwsczTSOoZh5cjUSCd6BbPEfCuer69tq2GDtU_003D()
	{
		if (!_0023_003DqQhs_0024J6J8ZCq6A80rAcnPCJJTtr2JA0HQH5qtz_ccxkw_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			if (_0023_003DqhC3ZrGYOloDiao9QFHYAmJrayugw6ufeopuhWsWbHOs_003D)
			{
				StringBuilder stringBuilder = new StringBuilder(9);
				StringBuilder stringBuilder2;
				if (7u != 0)
				{
					stringBuilder2 = stringBuilder;
				}
				_0023_003DqVJHbnbksIfAWJVDgdckJ8BI6aNgHAvEdUn6MWjYyEOY_003D(stringBuilder2);
				string text = stringBuilder2.ToString().ToLowerInvariant();
				string text2;
				if (8u != 0)
				{
					text2 = text;
				}
				global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<bool> obj = text2 == _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992641) || text2 == _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992660);
				if (5u != 0)
				{
					_0023_003DqQhs_0024J6J8ZCq6A80rAcnPCJJTtr2JA0HQH5qtz_ccxkw_003D = obj;
				}
			}
			else
			{
				_0023_003DqQhs_0024J6J8ZCq6A80rAcnPCJJTtr2JA0HQH5qtz_ccxkw_003D = false;
			}
		}
		return _0023_003DqQhs_0024J6J8ZCq6A80rAcnPCJJTtr2JA0HQH5qtz_ccxkw_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D();
	}

	public static string _0023_003DqaDRg45Ki5x3jGV_0024CmpWFMg_003D_003D()
	{
		if (_0023_003DqBGh1FCTMzFM9r_B3Ws9fBA_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			return _0023_003DqBGh1FCTMzFM9r_B3Ws9fBA_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D();
		}
		string text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992483);
		string text2;
		if (true)
		{
			text2 = text;
		}
		string text4 = default(string);
		if (File.Exists(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992491)))
		{
			string text3 = File.ReadAllText(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992491)).Trim();
			if (8u != 0)
			{
				text4 = text3;
			}
		}
		else if (_0023_003DquZhlSb0VFv_BBdN_00240sDv5w_003D_003D)
		{
			string text5 = _0023_003Dq3z5PaSAe3jJJ96panR3ZDQ_003D_003D(new string[6]
			{
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992451),
				_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992460),
				_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992470),
				_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqdcREVV2aE6IJQu4wzejupg_003D_003D,
				text2
			});
			if (3u != 0)
			{
				text4 = text5;
			}
		}
		else if (_0023_003DqhC3ZrGYOloDiao9QFHYAmJrayugw6ufeopuhWsWbHOs_003D)
		{
			string text6 = _0023_003Dq3z5PaSAe3jJJ96panR3ZDQ_003D_003D(new string[4]
			{
				Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
				_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992564),
				_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqdcREVV2aE6IJQu4wzejupg_003D_003D,
				text2
			});
			if (0 == 0)
			{
				text4 = text6;
			}
		}
		else
		{
			if (!_0023_003DqZ1FpgMbWO74Y6B50_8NOIw_003D_003D)
			{
				throw new Exception(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992891));
			}
			string environmentVariable = Environment.GetEnvironmentVariable(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992515));
			string text7;
			if (environmentVariable != null && environmentVariable.Length > 0 && Path.IsPathRooted(environmentVariable))
			{
				text7 = environmentVariable;
			}
			else
			{
				string environmentVariable2 = Environment.GetEnvironmentVariable(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992535));
				text7 = Path.Combine(Path.Combine(environmentVariable2, _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992542)), _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992879));
			}
			text4 = _0023_003Dq3z5PaSAe3jJJ96panR3ZDQ_003D_003D(new string[3]
			{
				text7,
				_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqdcREVV2aE6IJQu4wzejupg_003D_003D,
				text2
			});
		}
		Directory.CreateDirectory(text4);
		_0023_003DqBGh1FCTMzFM9r_B3Ws9fBA_003D_003D = text4;
		return text4;
	}

	public static string _0023_003DqvArrX2bLX5BFWr8cr7p2FXbjjkBtRpfNaLk9JvzX3AA_003D()
	{
		string text = Path.Combine(_0023_003DqaDRg45Ki5x3jGV_0024CmpWFMg_003D_003D(), _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992851));
		string text2;
		if (5u != 0)
		{
			text2 = text;
		}
		Directory.CreateDirectory(text2);
		return text2;
	}

	public static string _0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(string _0023_003DqFUI0nBfcSRZ0kQusLyNpkA_003D_003D, int _0023_003DqWkyQOMjlso4p_0024DzDlmBC6A_003D_003D)
	{
		string path = _0023_003DqvArrX2bLX5BFWr8cr7p2FXbjjkBtRpfNaLk9JvzX3AA_003D();
		string format = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992858);
		int num = 6;
		if (7 == 0)
		{
		}
		int num2 = 2;
		if (3 == 0)
		{
		}
		return Path.Combine(path, string.Format(format, _0023_003DqFUI0nBfcSRZ0kQusLyNpkA_003D_003D, _0023_003DqWkyQOMjlso4p_0024DzDlmBC6A_003D_003D));
	}

	public static string _0023_003DqnZZOBp_NyT8a0M6o1riWGa8GVe0Fc0hjzyYHLg5bbuM_003D(string _0023_003DqoeeMSt_DxBkIT7xI7nwMGg_003D_003D, int _0023_003DqBzG_0024w3w1mblwzv11ROK0QQ_003D_003D)
	{
		string[] array = File.ReadAllLines(_0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqoeeMSt_DxBkIT7xI7nwMGg_003D_003D, _0023_003DqBzG_0024w3w1mblwzv11ROK0QQ_003D_003D));
		string[] array2;
		if (6u != 0)
		{
			array2 = array;
		}
		int i;
		if (2u != 0)
		{
			i = 0;
		}
		for (; i < array2.Length; i++)
		{
			string obj = array2[i];
			string text;
			if (7u != 0)
			{
				text = obj;
			}
			int num = text.IndexOf(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992944));
			if (num >= 0 && text.Length >= num + 3)
			{
				return text.Substring(num + 2).Trim();
			}
		}
		return _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992949);
	}

	public static string _0023_003Dq3z5PaSAe3jJJ96panR3ZDQ_003D_003D(string[] _0023_003Dq0rhAAZC8mnfKArHUayq2Uw_003D_003D)
	{
		if (_0023_003Dq0rhAAZC8mnfKArHUayq2Uw_003D_003D.Length == 0)
		{
			return string.Empty;
		}
		string obj = _0023_003Dq0rhAAZC8mnfKArHUayq2Uw_003D_003D[0];
		string text = default(string);
		if (0 == 0)
		{
			text = obj;
		}
		int i = default(int);
		if (0 == 0)
		{
			i = 1;
		}
		for (; i < _0023_003Dq0rhAAZC8mnfKArHUayq2Uw_003D_003D.Length; i++)
		{
			string text2 = Path.Combine(text, _0023_003Dq0rhAAZC8mnfKArHUayq2Uw_003D_003D[i]);
			if (true)
			{
				text = text2;
			}
		}
		return text;
	}

	public static void _0023_003DqiOPvdrqG048GPF0fbocfQ1Zcw_9ax_0024K1UDa64sNTX08_003D()
	{
		_0023_003DqsCSLFGQxOw3sji9AQby5g6lgpgU2psLQqla1ooMgpwk_003D._0023_003DqJVa0LEPaLwn6WMNMXZrOuFWcQ9IH1t2hgd6mxFwLMCE_003D();
		if (_0023_003DquZhlSb0VFv_BBdN_00240sDv5w_003D_003D)
		{
			Process.Start(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992912), _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992923));
			if (5u != 0)
			{
			}
		}
		else if (_0023_003DqhC3ZrGYOloDiao9QFHYAmJrayugw6ufeopuhWsWbHOs_003D)
		{
			Process.Start(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992768), _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992723));
			if (2u != 0)
			{
			}
		}
		else if (_0023_003DqZ1FpgMbWO74Y6B50_8NOIw_003D_003D)
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqPYKW6Ju0_0024aOsdNCCJoIvkMaPgpXOjTcZ1NSCSGrfvsc_003D(_0023_003Dq3z5PaSAe3jJJ96panR3ZDQ_003D_003D(new string[2]
			{
				Directory.GetParent(Application.dataPath).FullName,
				_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992723)
			}));
		}
	}

	public static void _0023_003DqKSvs_i5TaZZX55RFt_0024xGbwqLlnmzMNd8aE7P8vMLhCk_003D()
	{
		if (_0023_003DquZhlSb0VFv_BBdN_00240sDv5w_003D_003D)
		{
			Process.Start(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992912), _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992818) + _0023_003DqvArrX2bLX5BFWr8cr7p2FXbjjkBtRpfNaLk9JvzX3AA_003D() + _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992818));
			if (5u != 0)
			{
			}
		}
		else if (_0023_003DqhC3ZrGYOloDiao9QFHYAmJrayugw6ufeopuhWsWbHOs_003D)
		{
			Process.Start(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992768), _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992826) + _0023_003DqvArrX2bLX5BFWr8cr7p2FXbjjkBtRpfNaLk9JvzX3AA_003D());
			if (0 == 0)
			{
			}
		}
		else if (_0023_003DqZ1FpgMbWO74Y6B50_8NOIw_003D_003D)
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqPYKW6Ju0_0024aOsdNCCJoIvkMaPgpXOjTcZ1NSCSGrfvsc_003D(_0023_003DqvArrX2bLX5BFWr8cr7p2FXbjjkBtRpfNaLk9JvzX3AA_003D());
		}
	}

	public static void _0023_003DqRDVHhnXxZA6gQLO_yxY12B6p5IT6PKwqd0i_0024vK2Tv5w_003D(string _0023_003Dqf2MDiGaUcZuhr10hJAKCmQ_003D_003D)
	{
		if (_0023_003DquZhlSb0VFv_BBdN_00240sDv5w_003D_003D)
		{
			string fileName = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992912);
			string text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992818);
			int num = 3;
			if (1 == 0)
			{
			}
			Process.Start(fileName, text + _0023_003Dqf2MDiGaUcZuhr10hJAKCmQ_003D_003D + _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992818));
			if (6u != 0)
			{
			}
		}
		else if (_0023_003DqhC3ZrGYOloDiao9QFHYAmJrayugw6ufeopuhWsWbHOs_003D)
		{
			string fileName2 = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992768);
			string text2 = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992779);
			int num2 = 2;
			if (2 == 0)
			{
			}
			Process.Start(fileName2, text2 + _0023_003Dqf2MDiGaUcZuhr10hJAKCmQ_003D_003D);
		}
		else if (_0023_003DqZ1FpgMbWO74Y6B50_8NOIw_003D_003D)
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqPYKW6Ju0_0024aOsdNCCJoIvkMaPgpXOjTcZ1NSCSGrfvsc_003D(_0023_003Dqf2MDiGaUcZuhr10hJAKCmQ_003D_003D);
		}
	}
}
