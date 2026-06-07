using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public sealed class InputWidget : MonoBehaviour
{
	public Image Highlight;

	public Text Heading;

	public Text Values;

	public LinkArrowWidget LinkArrowWidget;

	private _0023_003DqLVkp4Q4_0024xh02LVztho1cIw_003D_003D _0023_003DqubDGs_4EzQQIGUaOGrYxUMZ2_IRqN1f_0024DxAi6G9NEVw_003D;

	public InputWidget()
	{
		int num = 7;
		if (4 == 0)
		{
		}
		base._002Ector();
	}

	internal _0023_003DqLVkp4Q4_0024xh02LVztho1cIw_003D_003D _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()
	{
		int num = 4;
		if (7 == 0)
		{
		}
		return _0023_003DqubDGs_4EzQQIGUaOGrYxUMZ2_IRqN1f_0024DxAi6G9NEVw_003D;
	}

	private void _0023_003DqAcW6XJieK5M3834jLP0Jcg_003D_003D(_0023_003DqLVkp4Q4_0024xh02LVztho1cIw_003D_003D _0023_003Dq_0024mkviPqnrPaflcaxn6Mufw_003D_003D)
	{
		if (7u != 0)
		{
			_0023_003DqubDGs_4EzQQIGUaOGrYxUMZ2_IRqN1f_0024DxAi6G9NEVw_003D = _0023_003Dq_0024mkviPqnrPaflcaxn6Mufw_003D_003D;
		}
	}

	public void Initialize(_0023_003DqLVkp4Q4_0024xh02LVztho1cIw_003D_003D _0023_003DqRx5XiwLPP7dg9uSR4TuOhA_003D_003D)
	{
		int num = 0;
		if (7 == 0)
		{
		}
		int num2 = 1;
		if (-1 == 0)
		{
		}
		_0023_003DqAcW6XJieK5M3834jLP0Jcg_003D_003D(_0023_003DqRx5XiwLPP7dg9uSR4TuOhA_003D_003D);
		int num3 = 3;
		if (1 == 0)
		{
		}
		Heading.text = _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqTUwEdcRBKBxI3iw2fEFvSg_003D_003D;
		Refresh();
	}

	public void Refresh()
	{
		StringBuilder stringBuilder = new StringBuilder();
		StringBuilder stringBuilder2;
		if (uint.MaxValue != 0)
		{
			stringBuilder2 = stringBuilder;
		}
		int i;
		if (7u != 0)
		{
			i = 0;
		}
		for (; i < _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqZ76hLDUNCY4QramqKTowPg_003D_003D().Length; i++)
		{
			bool num = _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqCr_Hgy46uIazxqKTAwU2Ug_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D() && i == _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqDp2VMzzCTnYLKRKhX0Ce_ofydRFywRGDD1Wtlqgqwro_003D();
			bool flag;
			if (true)
			{
				flag = num;
			}
			stringBuilder2.AppendFormat((!flag) ? _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991686) : _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991714), _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqZ76hLDUNCY4QramqKTowPg_003D_003D()[i]);
		}
		Values.text = stringBuilder2.ToString();
		if (_0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqCr_Hgy46uIazxqKTAwU2Ug_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D() && _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqDp2VMzzCTnYLKRKhX0Ce_ofydRFywRGDD1Wtlqgqwro_003D() < _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqZ76hLDUNCY4QramqKTowPg_003D_003D().Length)
		{
			Highlight.gameObject.SetActive(true);
			Highlight.rectTransform.anchoredPosition = new Vector2(0f, -12 * _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqDp2VMzzCTnYLKRKhX0Ce_ofydRFywRGDD1Wtlqgqwro_003D() - 12);
		}
		else
		{
			Highlight.gameObject.SetActive(false);
		}
		Dictionary<_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D, _0023_003Dq9nRaTPzGXI0p18KvemjmP0Kfyluec4yZtfKs52VZg48_003D> _0023_003Dq27_0024C2AWTN1JsSxo6FzmAuQ_003D_003D = _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqCr_Hgy46uIazxqKTAwU2Ug_003D_003D._0023_003DqhvRsjbfRKGkkOW9eVsn65KnFdFVZhs0WJQ2B55ErgOs_003D(_0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D());
		LinkArrowWidget.SetState(_0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqMMkNxPNmqhRx0aIdJKwrVnsRQgOHt3KEHDbWRTHL4xs_003D()._0023_003DqN_qCy57wgKYojVFvaxLO9A_003D_003D, _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D(), (_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1, _0023_003Dq27_0024C2AWTN1JsSxo6FzmAuQ_003D_003D._0023_003DqnjQULvNxRjwSYlkEXLE5cQ_003D_003D((_0023_003DqyfOE6A6l_3nzMkhWmYHJYg_003D_003D)1), _0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqCr_Hgy46uIazxqKTAwU2Ug_003D_003D._0023_003DqnQSEwxLpbk8gGUwimtA4hg_003D_003D());
		LinkArrowWidget.SetLabel(_0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqTUwEdcRBKBxI3iw2fEFvSg_003D_003D);
		LinkArrowWidget.SetIdle(_0023_003Dqil6I7_CYpd3LQuOjBDq2Uw_003D_003D()._0023_003DqbaV1ak67N_2ayq3LtcrPjw_003D_003D());
	}
}
