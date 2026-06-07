using UnityEngine;
using UnityEngine.UI;

public sealed class MainMenuDialogWidget : MonoBehaviour
{
	public Button ViewDocumentationButton;

	public Button ToggleFullscreenButton;

	public Button ExitToDesktopButton;

	public MainMenuDialogWidget()
	{
		int num = -1;
		if (8 == 0)
		{
		}
		base._002Ector();
	}

	private void Start()
	{
		int num = 4;
		if (false)
		{
		}
		Button.ButtonClickedEvent onClick = ViewDocumentationButton.onClick;
		int num2 = 1;
		if (4 == 0)
		{
		}
		onClick.AddListener(delegate
		{
			if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect.State == (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)1)
			{
				_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
				_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqiOPvdrqG048GPF0fbocfQ1Zcw_9ax_0024K1UDa64sNTX08_003D();
			}
		});
		int num3 = 3;
		if (false)
		{
		}
		ToggleFullscreenButton.onClick.AddListener(_0023_003Dq1PUTTaid8KIGidhojZDDwcya8nDxEmFSWszjRSZO9u8_003D);
		ExitToDesktopButton.onClick.AddListener(_0023_003Dq3Hu1KTCzIZeSFWoV1QoiGOXNqiJEd7Y2MoLlViF2S2Y_003D);
	}

	private void Update()
	{
		if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect.State == (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)1 && Input.GetKeyDown(KeyCode.Escape))
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
		}
	}

	public void Initialize()
	{
	}

	private void _0023_003Dq_0024FKffiU4djKTiDfxYlEYPWJ_00243hDveWWFl3DD20hZqUP4nzRDTBrFrcPvEVKpyxnT()
	{
		if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect.State == (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)1)
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
			_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqiOPvdrqG048GPF0fbocfQ1Zcw_9ax_0024K1UDa64sNTX08_003D();
		}
	}

	private void _0023_003Dq1PUTTaid8KIGidhojZDDwcya8nDxEmFSWszjRSZO9u8_003D()
	{
		_0023_003DqKq_0024_BTg7MU1hGFwgqPsYjs2BzARdanirUNp_0024GDKGu_0024c_003D._0023_003DqMtBTDK_0024i5D5M3HLiF3kPDe7H3I3TOvj4FEQcGpW3V_o_003D(!_0023_003DqKq_0024_BTg7MU1hGFwgqPsYjs2BzARdanirUNp_0024GDKGu_0024c_003D._0023_003DqHTk2Qnal8KZpnzxz2ZGkm6NIGoJvbQItEYeSxkX3hM8_003D());
	}

	private void _0023_003Dq3Hu1KTCzIZeSFWoV1QoiGOXNqiJEd7Y2MoLlViF2S2Y_003D()
	{
		if (_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect.State == (_0023_003DqrZFcxScBWPdMP1Zk8vOliw_003D_003D)1)
		{
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.CrtEffect.TurnOff(_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003DqBItXJSCcn74wyreZ5lH3aQ_003D_003D);
		}
	}
}
