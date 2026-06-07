using System.Text;
using UnityEngine;
using UnityEngine.UI;

public sealed class LevelButtonWidget : MonoBehaviour
{
	private static readonly string _0023_003DqRgxuUBMUSFQzIEuvIh_0024cYLA4CVXEhEInLqyNYEwaiRM_003D;

	public Button ActiveButton;

	public Image InactiveButton;

	public Text SegmentText;

	public Text NameText;

	public Text StatusText;

	public Text GarbageText;

	public Text RemainingText;

	public Button CompilationFailedButton;

	public Text FailedSegmentText;

	private bool _0023_003DqOhXWlhEpLIWJBbHjMKYxLQ_003D_003D;

	private bool _0023_003DqwtQ1AcTrULxUnjOGW_0024QUiA_003D_003D;

	private bool _0023_003DqSysaArKw_0024XKBg0T7DCtd1g_003D_003D;

	private _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003Dq8jXr9uoKdeaXO1ve943CmdUfVpBgUbKoYvo8_2mgqrs_003D;

	public bool IsSelected
	{
		set
		{
			if (0 == 0)
			{
				_0023_003DqwtQ1AcTrULxUnjOGW_0024QUiA_003D_003D = value;
			}
			_0023_003DqQMinJjEWiI2EOpcdCdgEmg_003D_003D();
		}
	}

	public bool IsSolved
	{
		set
		{
			if (uint.MaxValue != 0)
			{
				_0023_003DqSysaArKw_0024XKBg0T7DCtd1g_003D_003D = value;
			}
			_0023_003DqQMinJjEWiI2EOpcdCdgEmg_003D_003D();
		}
	}

	public LevelButtonWidget()
	{
		int num = 6;
		if (-1 == 0)
		{
		}
		base._002Ector();
	}

	static LevelButtonWidget()
	{
		string text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992152);
		if (8u != 0)
		{
			_0023_003DqRgxuUBMUSFQzIEuvIh_0024cYLA4CVXEhEInLqyNYEwaiRM_003D = text;
		}
	}

	internal _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqZHPBTw0_0024vowWlmCAd2SbMQ_003D_003D()
	{
		int num = 6;
		if (-1 == 0)
		{
		}
		return _0023_003Dq8jXr9uoKdeaXO1ve943CmdUfVpBgUbKoYvo8_2mgqrs_003D;
	}

	private void _0023_003DqjG5p4NWeVSyxADSKZbMLqg_003D_003D(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003Dq1Ic4MRV4hA7lVxVWNYnuSA_003D_003D)
	{
		if (4u != 0)
		{
			_0023_003Dq8jXr9uoKdeaXO1ve943CmdUfVpBgUbKoYvo8_2mgqrs_003D = _0023_003Dq1Ic4MRV4hA7lVxVWNYnuSA_003D_003D;
		}
	}

	public void Initialize(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D)
	{
		_0023_003DqjG5p4NWeVSyxADSKZbMLqg_003D_003D(_0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D);
		NameText.text = _0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D._0023_003DqtTvEXXGbpBW4Rhvpc7H3iw_003D_003D;
		if (_0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D._0023_003Dq541XKtzm2AP8onTkVvVCyw_003D_003D)
		{
			SegmentText.text = _0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D().Replace(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693994217), _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991999));
			FailedSegmentText.text = SegmentText.text;
		}
		else if (_0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D._0023_003Dq7zyJPxOnAvROCxKNdhUimw_003D_003D)
		{
			SegmentText.text = _0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D().Replace(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991947), _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991960));
		}
		else if (_0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D._0023_003Dqwl6R8LkbULUWblsGhtQQbg_003D_003D != 0)
		{
			SegmentText.text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992033);
		}
		else
		{
			SegmentText.text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992056) + _0023_003DqG8k9oV_97d1pIPsZlxn3LQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D();
		}
		Random.seed = _0023_003DqZHPBTw0_0024vowWlmCAd2SbMQ_003D_003D()._0023_003DqzB2lYd4FchoCH0wgXMdsAg_003D_003D;
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2;
		if (7u != 0)
		{
			stringBuilder2 = stringBuilder;
		}
		int i = default(int);
		if (0 == 0)
		{
			i = 0;
		}
		for (; i < 7; i++)
		{
			int j;
			if (6u != 0)
			{
				j = 0;
			}
			for (; j < 17; j++)
			{
				stringBuilder2.Append(_0023_003DqRgxuUBMUSFQzIEuvIh_0024cYLA4CVXEhEInLqyNYEwaiRM_003D[Random.Range(0, _0023_003DqRgxuUBMUSFQzIEuvIh_0024cYLA4CVXEhEInLqyNYEwaiRM_003D.Length)]);
			}
			stringBuilder2.AppendLine();
		}
		GarbageText.text = stringBuilder2.ToString();
	}

	public void LockOrUnlock(int _0023_003Dql8NPw04NHBqq82nNdmGJCCHQ2xX_uCe7Mm5I_0024ziRpyM_003D)
	{
		int num = _0023_003DqZHPBTw0_0024vowWlmCAd2SbMQ_003D_003D()._0023_003Dqmq0Vt8qo6uA8WcZ_002413gV6QnBSHyFc1z4n991krll2jY_003D() - _0023_003Dql8NPw04NHBqq82nNdmGJCCHQ2xX_uCe7Mm5I_0024ziRpyM_003D;
		int num2;
		if (2u != 0)
		{
			num2 = num;
		}
		RemainingText.text = string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992007), num2);
		bool num3 = num2 <= 0;
		if (6u != 0)
		{
			_0023_003DqOhXWlhEpLIWJBbHjMKYxLQ_003D_003D = num3;
		}
		_0023_003DqQMinJjEWiI2EOpcdCdgEmg_003D_003D();
	}

	public void UnlockUnconditionally()
	{
		if (6u != 0)
		{
			_0023_003DqOhXWlhEpLIWJBbHjMKYxLQ_003D_003D = true;
		}
		_0023_003DqQMinJjEWiI2EOpcdCdgEmg_003D_003D();
	}

	private void _0023_003DqQMinJjEWiI2EOpcdCdgEmg_003D_003D()
	{
		int num = -1;
		if (3 == 0)
		{
		}
		if (_0023_003DqZHPBTw0_0024vowWlmCAd2SbMQ_003D_003D()._0023_003Dq3sMbyREsG9KR2ADXQ_79JQ_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			int num2 = 5;
			if (-1 == 0)
			{
			}
			CompilationFailedButton.gameObject.SetActive(true);
			int num3 = 7;
			if (4 == 0)
			{
			}
			ActiveButton.gameObject.SetActive(false);
			InactiveButton.gameObject.SetActive(false);
			CompilationFailedButton.interactable = !_0023_003DqwtQ1AcTrULxUnjOGW_0024QUiA_003D_003D;
		}
		else
		{
			CompilationFailedButton.gameObject.SetActive(false);
			ActiveButton.gameObject.SetActive(_0023_003DqOhXWlhEpLIWJBbHjMKYxLQ_003D_003D);
			InactiveButton.gameObject.SetActive(!_0023_003DqOhXWlhEpLIWJBbHjMKYxLQ_003D_003D);
			ActiveButton.interactable = !_0023_003DqwtQ1AcTrULxUnjOGW_0024QUiA_003D_003D;
			StatusText.gameObject.SetActive(_0023_003DqSysaArKw_0024XKBg0T7DCtd1g_003D_003D || _0023_003DqZHPBTw0_0024vowWlmCAd2SbMQ_003D_003D()._0023_003Dqwl6R8LkbULUWblsGhtQQbg_003D_003D != (_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003DqgNaolQmxqs1nuTZbHAY6nA_003D_003D)0);
		}
	}
}
