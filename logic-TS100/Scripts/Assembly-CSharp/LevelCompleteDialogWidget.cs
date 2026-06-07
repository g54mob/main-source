using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class LevelCompleteDialogWidget : MonoBehaviour
{
	public Text MessageText;

	public Button KeepPlayingButton;

	public Button ReturnButton;

	public Histogram CycleHistogram;

	public Histogram NodeHistogram;

	public Histogram InstructionHistogram;

	private _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqYAvt2Iyg_0024aEWbcac2wiqXQ_003D_003D;

	private int _0023_003Dq9Mfdpsy5K21roat_0024Ljs3_0024g_003D_003D;

	private int _0023_003DqnUbZy_acOwexM2YNYQG1Ng_003D_003D;

	private int _0023_003Dq_r2b1aRBBa1gpg__0024YPx5Fg_003D_003D;

	private int _0023_003DqWph9aL3G0NKCFgLGQP_0024CP02dLuhpXBvs1SC02naL9qA_003D;

	private Action _0023_003Dqf6xWqxl_0024mkbkwGkNU_0024PTu68P5m3_0024iCv6UTCZqYr1tnU_003D;

	public LevelCompleteDialogWidget()
	{
		int num = -1;
		if (3 == 0)
		{
		}
		base._002Ector();
	}

	private void Start()
	{
		int num = 2;
		if (2 == 0)
		{
		}
		Button.ButtonClickedEvent onClick = KeepPlayingButton.onClick;
		int num2 = 1;
		if (-1 == 0)
		{
		}
		onClick.AddListener(delegate
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
			int num3 = 3;
			if (1 == 0)
			{
			}
			_0023_003Dqf6xWqxl_0024mkbkwGkNU_0024PTu68P5m3_0024iCv6UTCZqYr1tnU_003D();
		});
		int num4 = 6;
		if (1 == 0)
		{
		}
		ReturnButton.onClick.AddListener(_0023_003DqAjfxi1VRf7zIB4nt9S1G0y3b8Dm5oGfhZLkLIkjmSnU_003D);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			int num = 4;
			if (false)
			{
			}
			_0023_003DqAjfxi1VRf7zIB4nt9S1G0y3b8Dm5oGfhZLkLIkjmSnU_003D();
		}
		else if (Input.GetKeyDown(KeyCode.Escape))
		{
			int num2 = 3;
			if (5 == 0)
			{
			}
			_0023_003DqeIOQeWFeT_0024h_flcNCSB_K4RRv8CUvm1aqHh_tK5SEUM_003D();
		}
	}

	public void Initialize(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqwCm1td4fae2FlFDsetUzCg_003D_003D, int _0023_003DqXBJbC7fCea_0024RW_4E7Wez7g_003D_003D, _0023_003DqPyZu3ATELKn3PMEYHnXkLg_003D_003D _0023_003DqB_0024D6KGg3Hrw8DULf8MRtRA_003D_003D, Action _0023_003DqH1wYPY91zrN7wVyvUTS8SkDTs0b1jt_puvwoaiHqnHk_003D)
	{
		if (4u != 0)
		{
			_0023_003DqYAvt2Iyg_0024aEWbcac2wiqXQ_003D_003D = _0023_003DqwCm1td4fae2FlFDsetUzCg_003D_003D;
		}
		if (3u != 0)
		{
			_0023_003Dq9Mfdpsy5K21roat_0024Ljs3_0024g_003D_003D = _0023_003DqXBJbC7fCea_0024RW_4E7Wez7g_003D_003D;
		}
		int num = _0023_003DqB_0024D6KGg3Hrw8DULf8MRtRA_003D_003D._0023_003DqRbNYUmaIHMBXVXYAvMK45w_003D_003D();
		if (7u != 0)
		{
			_0023_003Dq_r2b1aRBBa1gpg__0024YPx5Fg_003D_003D = num;
		}
		_0023_003DqnUbZy_acOwexM2YNYQG1Ng_003D_003D = _0023_003DqB_0024D6KGg3Hrw8DULf8MRtRA_003D_003D._0023_003DqxA8yf1Gdk1qf8iQwTxbS2Q_003D_003D();
		_0023_003DqWph9aL3G0NKCFgLGQP_0024CP02dLuhpXBvs1SC02naL9qA_003D = _0023_003DqB_0024D6KGg3Hrw8DULf8MRtRA_003D_003D._0023_003DqQcd0_L0X74bm3x7N1fZNJQDmbe6cmX3L5vFuIgSGuX8_003D();
		_0023_003Dqf6xWqxl_0024mkbkwGkNU_0024PTu68P5m3_0024iCv6UTCZqYr1tnU_003D = _0023_003DqH1wYPY91zrN7wVyvUTS8SkDTs0b1jt_puvwoaiHqnHk_003D;
		MessageText.text = string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693976608), _0023_003DqwCm1td4fae2FlFDsetUzCg_003D_003D._0023_003DqtTvEXXGbpBW4Rhvpc7H3iw_003D_003D);
		_0023_003DqzyNp4RVxB4DUZnOuTlr17Q_003D_003D._0023_003DqLpkqFbWZurI0jfH9QDlRsw_003D_003D(_0023_003DqwCm1td4fae2FlFDsetUzCg_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqnUbZy_acOwexM2YNYQG1Ng_003D_003D, _0023_003Dq_r2b1aRBBa1gpg__0024YPx5Fg_003D_003D, _0023_003DqWph9aL3G0NKCFgLGQP_0024CP02dLuhpXBvs1SC02naL9qA_003D);
		_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003Dq7vLpEIAmAdV5CY4Ot__0024n6Q_003D_003D(_0023_003DqYAvt2Iyg_0024aEWbcac2wiqXQ_003D_003D, _0023_003Dq9Mfdpsy5K21roat_0024Ljs3_0024g_003D_003D, _0023_003DqnUbZy_acOwexM2YNYQG1Ng_003D_003D, _0023_003Dq_r2b1aRBBa1gpg__0024YPx5Fg_003D_003D, _0023_003DqWph9aL3G0NKCFgLGQP_0024CP02dLuhpXBvs1SC02naL9qA_003D);
		_0023_003DqsCSLFGQxOw3sji9AQby5g6lgpgU2psLQqla1ooMgpwk_003D._0023_003DqVM1y_cBgp8FQQDFiWBgu0Q_003D_003D(_0023_003DqYAvt2Iyg_0024aEWbcac2wiqXQ_003D_003D, _0023_003DqB_0024D6KGg3Hrw8DULf8MRtRA_003D_003D);
		_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqngdJYRjTGOeX5kC33BlhV9CYVW9mQfQL_0024ct5ZgGXLe4_003D(CycleHistogram, _0023_003DqwCm1td4fae2FlFDsetUzCg_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqXBJbC7fCea_0024RW_4E7Wez7g_003D_003D, (_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)0);
		_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqngdJYRjTGOeX5kC33BlhV9CYVW9mQfQL_0024ct5ZgGXLe4_003D(NodeHistogram, _0023_003DqwCm1td4fae2FlFDsetUzCg_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqXBJbC7fCea_0024RW_4E7Wez7g_003D_003D, (_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)2);
		_0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqngdJYRjTGOeX5kC33BlhV9CYVW9mQfQL_0024ct5ZgGXLe4_003D(InstructionHistogram, _0023_003DqwCm1td4fae2FlFDsetUzCg_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqXBJbC7fCea_0024RW_4E7Wez7g_003D_003D, (_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)1);
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundHappy._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
	}

	private void _0023_003DqeIOQeWFeT_0024h_flcNCSB_K4RRv8CUvm1aqHh_tK5SEUM_003D()
	{
		_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
		int num = 3;
		if (1 == 0)
		{
		}
		_0023_003Dqf6xWqxl_0024mkbkwGkNU_0024PTu68P5m3_0024iCv6UTCZqYr1tnU_003D();
	}

	private void _0023_003DqAjfxi1VRf7zIB4nt9S1G0y3b8Dm5oGfhZLkLIkjmSnU_003D()
	{
		int num = -1;
		if (7 == 0)
		{
		}
		_0023_003DqzyNp4RVxB4DUZnOuTlr17Q_003D_003D._0023_003Dqo_VV3V8qM7_0024APeU9bob_00245w_003D_003D(_0023_003DqYAvt2Iyg_0024aEWbcac2wiqXQ_003D_003D._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D());
		_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
		int num2 = 1;
		if (5 == 0)
		{
		}
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqYAvt2Iyg_0024aEWbcac2wiqXQ_003D_003D);
	}
}
