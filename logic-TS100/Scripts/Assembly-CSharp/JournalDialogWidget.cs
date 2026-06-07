using System;
using UnityEngine;
using UnityEngine.UI;

public sealed class JournalDialogWidget : MonoBehaviour
{
	private static readonly float _0023_003DqnUZmfKcToQsId0_MOgxVuQ_003D_003D;

	private static readonly float _0023_003DqiXXteqwPBzYr2gc6vVkOxQ_003D_003D;

	public Text HeadingText;

	public Text JournalText;

	public Text CreatorText;

	public Button CloseButton;

	private bool _0023_003Dq6_0024nrAye7LYQfiuQ00WONIA_003D_003D;

	private bool _0023_003DqstP0NnLHYJe9btypF0k6Dw_003D_003D;

	private bool _0023_003Dq8wIDHP1Mjl9chi0eYLNMGQ_003D_003D;

	private float _0023_003DqnU10YDBTK4TyIwuX92e2pQ_003D_003D;

	private bool _0023_003Dq8N0ySqQOb0lKbTXQ2p1ALA_003D_003D;

	private static Action _0023_003DqkLtO9oYNl8Er8yEi_0024AzUiw_003D_003D;

	private static Func<string, string> _0023_003DqpAhv1g1tTt61Iv4oTu5viQ_003D_003D;

	public JournalDialogWidget()
	{
		int num = 3;
		if (6 == 0)
		{
		}
		base._002Ector();
	}

	static JournalDialogWidget()
	{
		if (4u != 0)
		{
			_0023_003DqnUZmfKcToQsId0_MOgxVuQ_003D_003D = 0.6f;
		}
		if (true)
		{
			_0023_003DqiXXteqwPBzYr2gc6vVkOxQ_003D_003D = 2f;
		}
	}

	private void Start()
	{
		int num = 5;
		if (false)
		{
		}
		Button.ButtonClickedEvent onClick = CloseButton.onClick;
		int num2 = 5;
		if (5 == 0)
		{
		}
		onClick.AddListener(delegate
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
			int num3 = 7;
			if (6 == 0)
			{
			}
			if (_0023_003DqstP0NnLHYJe9btypF0k6Dw_003D_003D)
			{
				_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D);
			}
		});
	}

	private void Update()
	{
		if (!_0023_003Dq6_0024nrAye7LYQfiuQ00WONIA_003D_003D && (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return)))
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
			return;
		}
		float num = _0023_003DqnU10YDBTK4TyIwuX92e2pQ_003D_003D + Time.deltaTime;
		if (5u != 0)
		{
			_0023_003DqnU10YDBTK4TyIwuX92e2pQ_003D_003D = num;
		}
		JournalText.gameObject.SetActive(_0023_003Dq8wIDHP1Mjl9chi0eYLNMGQ_003D_003D || _0023_003DqnU10YDBTK4TyIwuX92e2pQ_003D_003D > _0023_003DqnUZmfKcToQsId0_MOgxVuQ_003D_003D);
		if (!_0023_003Dq6_0024nrAye7LYQfiuQ00WONIA_003D_003D || !(_0023_003DqnU10YDBTK4TyIwuX92e2pQ_003D_003D >= _0023_003DqiXXteqwPBzYr2gc6vVkOxQ_003D_003D) || _0023_003Dq8N0ySqQOb0lKbTXQ2p1ALA_003D_003D)
		{
			return;
		}
		if (5u != 0)
		{
			_0023_003Dq8N0ySqQOb0lKbTXQ2p1ALA_003D_003D = true;
		}
		CrtEffect crtEffect = _0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect;
		if (_0023_003DqkLtO9oYNl8Er8yEi_0024AzUiw_003D_003D == null)
		{
			Action action = _0023_003DquGmSfRDVxF2PXtANMwgtuQ_003D_003D;
			if (0 == 0)
			{
				_0023_003DqkLtO9oYNl8Er8yEi_0024AzUiw_003D_003D = action;
			}
		}
		crtEffect.TurnOff(_0023_003DqkLtO9oYNl8Er8yEi_0024AzUiw_003D_003D);
	}

	public void Initialize(string _0023_003DqHk2YNid_0024yGnQA8c3arhymA_003D_003D, global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<string> _0023_003Dq12qznMrhu5faEIChObjW1g_003D_003D, bool _0023_003DqO6lTCsbuA2qsDnbXlHi21Q_003D_003D, bool _0023_003Dq9y6Ft8y5RKpSXWqS1xok6w_003D_003D, bool _0023_003DqJac6rfNbp9QZpDEvP6BuIw_003D_003D)
	{
		JournalText.text = _0023_003DqHk2YNid_0024yGnQA8c3arhymA_003D_003D;
		Text creatorText = CreatorText;
		if (_0023_003DqpAhv1g1tTt61Iv4oTu5viQ_003D_003D == null)
		{
			Func<string, string> func = delegate(string _0023_003DqoqpCwNvR_w2tm2RWgY6k1A_003D_003D)
			{
				string format = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992162);
				int num = 3;
				if (-1 == 0)
				{
				}
				return string.Format(format, _0023_003DqoqpCwNvR_w2tm2RWgY6k1A_003D_003D);
			};
			if (3u != 0)
			{
				_0023_003DqpAhv1g1tTt61Iv4oTu5viQ_003D_003D = func;
			}
		}
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<string> obj = _0023_003Dq12qznMrhu5faEIChObjW1g_003D_003D._0023_003Dq51NPfrMoOkUarvlId_0024HmZA_003D_003D(_0023_003DqpAhv1g1tTt61Iv4oTu5viQ_003D_003D);
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<string> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
		if (6u != 0)
		{
			_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = obj;
		}
		creatorText.text = _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003DqJ75nbFW4ANt1NB_00241xA73Aw_003D_003D(string.Empty);
		if (0 == 0)
		{
			_0023_003Dq6_0024nrAye7LYQfiuQ00WONIA_003D_003D = _0023_003DqO6lTCsbuA2qsDnbXlHi21Q_003D_003D;
		}
		_0023_003DqstP0NnLHYJe9btypF0k6Dw_003D_003D = _0023_003Dq9y6Ft8y5RKpSXWqS1xok6w_003D_003D;
		_0023_003Dq8wIDHP1Mjl9chi0eYLNMGQ_003D_003D = _0023_003DqJac6rfNbp9QZpDEvP6BuIw_003D_003D;
		CloseButton.interactable = !_0023_003Dq6_0024nrAye7LYQfiuQ00WONIA_003D_003D;
		if (_0023_003DqJac6rfNbp9QZpDEvP6BuIw_003D_003D)
		{
			HeadingText.text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991757);
			JournalText.gameObject.SetActive(true);
		}
		else
		{
			HeadingText.text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992115);
			JournalText.gameObject.SetActive(false);
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundDrive._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		}
	}

	private void _0023_003DqouZQaNYU2uTVK86O_0024Du8WbhqFrVDl88LLSyKrmamu4U_003D()
	{
		_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
		int num = 7;
		if (6 == 0)
		{
		}
		if (_0023_003DqstP0NnLHYJe9btypF0k6Dw_003D_003D)
		{
			_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D);
		}
	}

	private static void _0023_003DquGmSfRDVxF2PXtANMwgtuQ_003D_003D()
	{
		_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003DqIUTIGYZ9u21W0_u0ztqeVA_003D_003D();
	}

	private static string _0023_003Dqd6H0shduia_R3_0024_WxdQEk2OOh4cmiRZb3fID11aaSPg_003D(string _0023_003DqoqpCwNvR_w2tm2RWgY6k1A_003D_003D)
	{
		string format = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992162);
		int num = 3;
		if (-1 == 0)
		{
		}
		return string.Format(format, _0023_003DqoqpCwNvR_w2tm2RWgY6k1A_003D_003D);
	}
}
