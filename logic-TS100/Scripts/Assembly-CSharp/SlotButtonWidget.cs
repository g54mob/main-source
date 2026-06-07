using UnityEngine;
using UnityEngine.UI;

public sealed class SlotButtonWidget : MonoBehaviour
{
	private static readonly Color _0023_003DqWTVh_002465aOyDKfqZYmTVR_00243ufqNr28fhXyAoF5D_slJI_003D;

	private static readonly Color _0023_003DqVC1d1haqIrsKMfO_0024czOXmgWKKIZE_0024mZIOM4n6vCiCho_003D;

	public Button SlotButton;

	public Text SlotNameText;

	public Text SlotScoreText;

	public Text SlotEmptyText;

	public Button CopyButton;

	public Text CopyTextActive;

	public bool CopyEnabled
	{
		set
		{
			int num = 8;
			if (8 == 0)
			{
			}
			Button copyButton = CopyButton;
			int num2 = 8;
			if (1 == 0)
			{
			}
			copyButton.interactable = value;
			int num3 = 8;
			if (8 == 0)
			{
			}
			CopyTextActive.color = ((!value) ? _0023_003DqVC1d1haqIrsKMfO_0024czOXmgWKKIZE_0024mZIOM4n6vCiCho_003D : _0023_003DqWTVh_002465aOyDKfqZYmTVR_00243ufqNr28fhXyAoF5D_slJI_003D);
		}
	}

	public SlotButtonWidget()
	{
		int num = 7;
		if (3 == 0)
		{
		}
		base._002Ector();
	}

	static SlotButtonWidget()
	{
		Color color = new Color(0.8156863f, 0.8156863f, 0.8156863f);
		if (7u != 0)
		{
			_0023_003DqWTVh_002465aOyDKfqZYmTVR_00243ufqNr28fhXyAoF5D_slJI_003D = color;
		}
		Color color2 = new Color(0.32156864f, 0.32156864f, 0.32156864f);
		if (6u != 0)
		{
			_0023_003DqVC1d1haqIrsKMfO_0024czOXmgWKKIZE_0024mZIOM4n6vCiCho_003D = color2;
		}
	}

	public void SetEmpty()
	{
		int num = 4;
		if (false)
		{
		}
		SlotButton.interactable = true;
		int num2 = 5;
		if (-1 == 0)
		{
		}
		SlotNameText.gameObject.SetActive(false);
		int num3 = 0;
		if (7 == 0)
		{
		}
		SlotScoreText.gameObject.SetActive(false);
		SlotEmptyText.gameObject.SetActive(true);
		SlotEmptyText.color = _0023_003DqWTVh_002465aOyDKfqZYmTVR_00243ufqNr28fhXyAoF5D_slJI_003D;
	}

	public void SetDisabled()
	{
		int num = 7;
		if (-1 == 0)
		{
		}
		SlotButton.interactable = false;
		int num2 = 4;
		if (5 == 0)
		{
		}
		SlotNameText.gameObject.SetActive(false);
		int num3 = 4;
		if (3 == 0)
		{
		}
		SlotScoreText.gameObject.SetActive(false);
		SlotEmptyText.gameObject.SetActive(true);
		SlotEmptyText.color = _0023_003DqVC1d1haqIrsKMfO_0024czOXmgWKKIZE_0024mZIOM4n6vCiCho_003D;
	}

	public void SetUnsolved(string _0023_003DqEjwIjXxat3qQq6t3s6K6zw_003D_003D)
	{
		int num = 7;
		if (3 == 0)
		{
		}
		SlotButton.interactable = true;
		int num2 = 1;
		if (5 == 0)
		{
		}
		SlotNameText.gameObject.SetActive(true);
		int num3 = 2;
		if (6 == 0)
		{
		}
		SlotNameText.text = _0023_003DqEjwIjXxat3qQq6t3s6K6zw_003D_003D;
		SlotScoreText.gameObject.SetActive(true);
		SlotScoreText.text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022032);
		SlotEmptyText.gameObject.SetActive(false);
	}

	public void SetSolved(string _0023_003DqngfynbhoQKABu_iyNBPnEg_003D_003D, int _0023_003DqYFJyQ405sIqJ_Rb8rDRLMw_003D_003D, int _0023_003DqgjgEEp_S9FnaxEZgij8anw_003D_003D, int _0023_003DqLIk6qKquH4iy7ZJsRVgvkDGyHMpJRabPeXAKCA5x5qs_003D)
	{
		int num = 0;
		if (8 == 0)
		{
		}
		SlotButton.interactable = true;
		int num2 = -1;
		if (2 == 0)
		{
		}
		SlotNameText.gameObject.SetActive(true);
		int num3 = 4;
		if (3 == 0)
		{
		}
		SlotNameText.text = _0023_003DqngfynbhoQKABu_iyNBPnEg_003D_003D;
		SlotScoreText.gameObject.SetActive(true);
		SlotScoreText.text = string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022113), _0023_003DqYFJyQ405sIqJ_Rb8rDRLMw_003D_003D, _0023_003DqgjgEEp_S9FnaxEZgij8anw_003D_003D, _0023_003DqLIk6qKquH4iy7ZJsRVgvkDGyHMpJRabPeXAKCA5x5qs_003D);
		SlotEmptyText.gameObject.SetActive(false);
	}

	public void SetSandbox(string _0023_003DqGL96omg4Sh6ElVuDlM4D_0024g_003D_003D)
	{
		int num = 4;
		if (-1 == 0)
		{
		}
		SlotButton.interactable = true;
		int num2 = 2;
		if (5 == 0)
		{
		}
		SlotNameText.gameObject.SetActive(true);
		int num3 = 8;
		if (7 == 0)
		{
		}
		SlotNameText.text = _0023_003DqGL96omg4Sh6ElVuDlM4D_0024g_003D_003D;
		SlotScoreText.gameObject.SetActive(true);
		SlotScoreText.text = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1694022090);
		SlotEmptyText.gameObject.SetActive(false);
	}
}
