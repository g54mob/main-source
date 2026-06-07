using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public sealed class LevelEditorWidget : MonoBehaviour, _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D
{
	private sealed class _0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D
	{
		internal int _0023_003DqFS7NGbe75tHlhBFyi9c2gA_003D_003D;

		internal LevelEditorWidget _0023_003Dq87P2NZp_0024NJIKwQpL5mmBtg_003D_003D;

		public _0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D()
		{
			int num = 5;
			if (5 == 0)
			{
			}
			base._002Ector();
		}

		internal void _0023_003Dqjwpclacy0grTNLJuqUAE9A_003D_003D()
		{
			int num = 2;
			if (5 == 0)
			{
			}
			LevelEditorWidget levelEditorWidget = _0023_003Dq87P2NZp_0024NJIKwQpL5mmBtg_003D_003D;
			int num2 = 5;
			if (false)
			{
			}
			levelEditorWidget._0023_003DqZbLtACjgPfs2gU8vcbv7XGKOpAIYPTF1w_sxrkO7PAY_003D(_0023_003DqFS7NGbe75tHlhBFyi9c2gA_003D_003D);
		}

		internal void _0023_003Dq9oVIP4Y9D4Whr2Br_7Wimg_003D_003D()
		{
			int num = -1;
			if (1 == 0)
			{
			}
			LevelEditorWidget levelEditorWidget = _0023_003Dq87P2NZp_0024NJIKwQpL5mmBtg_003D_003D;
			int num2 = 5;
			if (6 == 0)
			{
			}
			levelEditorWidget._0023_003Dq_dvfkBk3AJV8D_ZmOS5wrkD5KjhLQPFCAKCk3xm7qIw_003D(_0023_003DqFS7NGbe75tHlhBFyi9c2gA_003D_003D);
		}
	}

	private sealed class _0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D
	{
		internal _0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D _0023_003Dq0a60WAectVW5l3R3SBHlffwKm7RDk15hWVU_9BwLJL4_003D;

		internal LevelEditorWidget _0023_003DqveTNb_0024_0024zzsdoE_kbnIsM9g_003D_003D;

		public _0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D()
		{
			int num = 7;
			if (4 == 0)
			{
			}
			base._002Ector();
		}

		internal void _0023_003Dq3Z14BPsq11OqZXkIcPCLTQ_003D_003D()
		{
			int num = 2;
			if (8 == 0)
			{
			}
			LevelEditorWidget levelEditorWidget = _0023_003DqveTNb_0024_0024zzsdoE_kbnIsM9g_003D_003D;
			int num2 = 8;
			if (3 == 0)
			{
			}
			levelEditorWidget._0023_003Dqax7aHuRiF5mYIKmK2KBCRrUGQHzqEUxyq1IDMKfDGEs_003D(_0023_003Dq0a60WAectVW5l3R3SBHlffwKm7RDk15hWVU_9BwLJL4_003D);
		}

		internal void _0023_003Dqxc3bFHyXgznheZYAg1DzSw_003D_003D()
		{
			int num = 2;
			if (6 == 0)
			{
			}
			LevelEditorWidget levelEditorWidget = _0023_003DqveTNb_0024_0024zzsdoE_kbnIsM9g_003D_003D;
			int num2 = 4;
			if (1 == 0)
			{
			}
			levelEditorWidget._0023_003Dqax7aHuRiF5mYIKmK2KBCRrUGQHzqEUxyq1IDMKfDGEs_003D(_0023_003Dq0a60WAectVW5l3R3SBHlffwKm7RDk15hWVU_9BwLJL4_003D);
		}
	}

	private static readonly int _0023_003DqvepUhX_00246FfdA6YrxTF8srQ_003D_003D;

	public LevelButtonWidget PrefabLevelButtonWidget;

	public Text PuzzleInfoText;

	public SlotButtonWidget[] PuzzleSlotButtons;

	public AdvancedButton CreateButton;

	public AdvancedButton EditButton;

	public AdvancedButton CopyButton;

	public AdvancedButton DeleteButton;

	public AdvancedButton ExportButton;

	public AdvancedButton ImportButton;

	public AdvancedButton PreviousButton;

	public AdvancedButton NextButton;

	public RectTransform CompileErrorPanel;

	public Text CompileErrorText;

	public Button LevelSelectButton;

	public Button BonusCampaignButton;

	public Button BonusCampaignDisabledButton;

	public Text BonusCampaignDisabledText;

	private int _0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D;

	private global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D;

	private List<LevelButtonWidget> _0023_003DqO5C9bDKgG0R169Zmxj2qhQ_003D_003D;

	private static Action<LevelButtonWidget> _0023_003DqzLq9kum8b_HxowotWEAuXfEGkybl1VTzBABxucEGE30_003D;

	private static Action<SlotButtonWidget> _0023_003DqMJKOs_0024LQlrUtEWULIYzJ9ZCCewf8SJUgqdieJ3T8IeM_003D;

	private static Action<SlotButtonWidget> _0023_003DqU2vrtwjRyewX2h1R34qk7ePxjx2_00248SGSsSw98ZD1H98_003D;

	private static Action<SlotButtonWidget> _0023_003DqHNCgQJW8ghE5pgpWg4F1GGCJitSQbCJKPDnJB_rODyg_003D;

	private static Action<SlotButtonWidget> _0023_003DqAJcFIYr9aHxAqBbos8ZWFPQQMb9jAbvW5zrYBNetuBU_003D;

	private static Action<SlotButtonWidget> _0023_003Dq9AdZtM1kxjj4zR2wjmATpyJnMtotHpoNgW2V_x_fY4k_003D;

	private static Func<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D, bool> _0023_003DqQ_0024f0FbDVOn6AQsqimj94rBFaV_vrig2rfLdVNYMq_7Q_003D;

	private static Action _0023_003Dq_GeS4s9T8_0024Il_0024l92StwldZpr3K34jVSpsi3GvPjL3hI_003D;

	public LevelEditorWidget()
	{
		int num = 6;
		if (5 == 0)
		{
		}
		base._002Ector();
	}

	static LevelEditorWidget()
	{
		if (7u != 0)
		{
			_0023_003DqvepUhX_00246FfdA6YrxTF8srQ_003D_003D = 25;
		}
	}

	private GameObject _0023_003DqKaEFPv5gB9DHBwD4E2_7d0LTQt1Mr8u6rwZpoNoXgnY_003D()
	{
		int num = 5;
		if (1 == 0)
		{
		}
		return base.gameObject;
	}

	GameObject _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D._0023_003DqJaI64gkjCxAvXrUlNIDc_w_003D_003D()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qKaEFPv5gB9DHBwD4E2_7d0LTQt1Mr8u6rwZpoNoXgnY=
		return this._0023_003DqKaEFPv5gB9DHBwD4E2_7d0LTQt1Mr8u6rwZpoNoXgnY_003D();
	}

	private void _0023_003DqTQy7bi1_zZ3Pj9J_VhS_wAZy2kXq9Yjkef6nMaqgcoI_003D()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqS_04_CA7V7vH0vlOi5KlTkdd_00247ZlWNe30bGhpiok1pQ_003D();
		}
		else if (Input.GetKeyDown(KeyCode.F2))
		{
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003Dq_0024L7KW8_0024Gy9tVMtyRzif0h67e7yYzXIgMJSDwB21zbV8_003D();
		}
	}

	void _0023_003Dq9O0Z4K_01rHRJJXJhFkzhw_003D_003D._0023_003DqV9WY5da_ySQ1wPlaJijNDg_003D_003D()
	{
		//ILSpy generated this explicit interface implementation from .override directive in #=qTQy7bi1_zZ3Pj9J_VhS_wAZy2kXq9Yjkef6nMaqgcoI=
		this._0023_003DqTQy7bi1_zZ3Pj9J_VhS_wAZy2kXq9Yjkef6nMaqgcoI_003D();
	}

	public void Start()
	{
		int i = default(int);
		if (0 == 0)
		{
			i = 0;
		}
		for (; i < PuzzleSlotButtons.Length; i++)
		{
			_0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D obj = new _0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D();
			_0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D _0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D2;
			if (2u != 0)
			{
				_0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D2 = obj;
			}
			if (true)
			{
				_0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D2._0023_003Dq87P2NZp_0024NJIKwQpL5mmBtg_003D_003D = this;
			}
			_0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D2._0023_003DqFS7NGbe75tHlhBFyi9c2gA_003D_003D = i;
			PuzzleSlotButtons[i].SlotButton.onClick.AddListener(_0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D2._0023_003Dqjwpclacy0grTNLJuqUAE9A_003D_003D);
			PuzzleSlotButtons[i].CopyButton.onClick.AddListener(_0023_003Dq4LS1qdnn4RkPAcdUK05pZfFJ78TNjr3VNWdFxeCbkMc_003D2._0023_003Dq9oVIP4Y9D4Whr2Br_7Wimg_003D_003D);
		}
		CreateButton.Button.onClick.AddListener(delegate
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj2 = _0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D._0023_003DqmSWl_0024hrePCLVMFEA36b7Yw_003D_003D();
			if (8u != 0)
			{
				_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj2;
			}
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
			_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
		});
		EditButton.Button.onClick.AddListener(_0023_003DqvBAfG7N22b1i7drzkbzCkiuvt5gEHe0UU2V1oRHZvV0_003D);
		CopyButton.Button.onClick.AddListener(_0023_003DqPyJGLWjfoSfuUGxJfZuVIirLiAaumGaNb1mX8CvptGY_003D);
		DeleteButton.Button.onClick.AddListener(delegate
		{
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
			string _0023_003Dq4fjtdQDNO23fsnSnQXHcuA_003D_003D = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992347);
			string _0023_003Dqg3juCHVHG5XvxAark3Txzw_003D_003D = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992448);
			string _0023_003Dq6xWTsxOky8ZMIYPYX88KTw_003D_003D = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991202);
			Action _0023_003Dqmd5Op6zarjhr7TulUhYazA_003D_003D = delegate
			{
				_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqxMFtkN9_0024CNa2ZtYn4q6m0w_003D_003D();
				global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj2 = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
				if (6u != 0)
				{
					_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj2;
				}
				_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
				_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
			};
			if (_0023_003Dq_GeS4s9T8_0024Il_0024l92StwldZpr3K34jVSpsi3GvPjL3hI_003D == null)
			{
				Action action = delegate
				{
					_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
				};
				if (2u != 0)
				{
					_0023_003Dq_GeS4s9T8_0024Il_0024l92StwldZpr3K34jVSpsi3GvPjL3hI_003D = action;
				}
			}
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003Dq29w08ObQRA3q95hKxqdZ_0024QEtOkZ_dyi_yiZh_0024OKoU7Q_003D(_0023_003Dq4fjtdQDNO23fsnSnQXHcuA_003D_003D, _0023_003Dqg3juCHVHG5XvxAark3Txzw_003D_003D, _0023_003Dq6xWTsxOky8ZMIYPYX88KTw_003D_003D, _0023_003Dqmd5Op6zarjhr7TulUhYazA_003D_003D, _0023_003Dq_GeS4s9T8_0024Il_0024l92StwldZpr3K34jVSpsi3GvPjL3hI_003D);
		});
		ExportButton.Button.onClick.AddListener(delegate
		{
			int num = 7;
			if (1 == 0)
			{
			}
			_0023_003DqxQ3iG2XxQ7WbWM0L_0024xFf6mxiETxlQ_0024qVEEUTt0G0Jrc_003D._0023_003DqhpT9nV1XoIA7h82SItNKUA_003D_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqEMCkLeMW5M4pGXCfZq_iag_003D_003D());
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		});
		ImportButton.Button.onClick.AddListener(delegate
		{
			_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj2 = _0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D._0023_003DqTen4pVhlETQ8NDqeTIEyOw_003D_003D(_0023_003DqxQ3iG2XxQ7WbWM0L_0024xFf6mxiETxlQ_0024qVEEUTt0G0Jrc_003D._0023_003DqVHhQOWROIXIkcDe3AwMxPA_003D_003D());
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
			if (5u != 0)
			{
				_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = obj2;
			}
			if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
			{
				global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj3 = _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
				if (uint.MaxValue != 0)
				{
					_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj3;
				}
				_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
			}
		});
		PreviousButton.Button.onClick.AddListener(_0023_003DqtQHf18kAib6qp88o3dVj_PxuKatBk7rQjBtYzuri9Lc_003D);
		NextButton.Button.onClick.AddListener(_0023_003Dqr3ot6oLwwQUoCBmD1ZncI0B3KD1X0LIxfDPlKagUl3U_003D);
		LevelSelectButton.onClick.AddListener(delegate
		{
			_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D);
		});
		BonusCampaignButton.onClick.AddListener(delegate
		{
			_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003DqxYh_7Xrv6jPxD3QBTgCuazvdhClNlCtIFQtOiewEdBo_003D();
		});
	}

	public void Initialize(global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> _0023_003DqSNpIgMeYTMfJ3qEpnJbQYw_003D_003D)
	{
		List<LevelButtonWidget> list = new List<LevelButtonWidget>();
		if (7u != 0)
		{
			_0023_003DqO5C9bDKgG0R169Zmxj2qhQ_003D_003D = list;
		}
		if (2u != 0)
		{
			_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = _0023_003DqSNpIgMeYTMfJ3qEpnJbQYw_003D_003D;
		}
		_0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqKTqXdNum7DjegfVmd6DOOzJRMIvB0G_0024_NunD58RsSXU_003D();
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
	}

	public void OnApplicationFocus()
	{
		_0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqKTqXdNum7DjegfVmd6DOOzJRMIvB0G_0024_NunD58RsSXU_003D();
		int num = 6;
		if (-1 == 0)
		{
		}
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
	}

	private void _0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D()
	{
		if (_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D() && !_0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D()._0023_003Dq2YHKVbJtx0_0024m8twqOGhOTw_003D_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()))
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D().Where(_0023_003Dq8zkXbsqQG62xZz1a2yMdjg_003D_003D)._0023_003Dq_LoHFM9bEEhQdhJbd03LQA_003D_003D();
			if (uint.MaxValue != 0)
			{
				_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj;
			}
		}
		if (!_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj2 = _0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D()._0023_003Dq_LoHFM9bEEhQdhJbd03LQA_003D_003D();
			if (2u != 0)
			{
				_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj2;
			}
		}
		if (_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			int num;
			if (4u != 0)
			{
				num = 0;
			}
			while (num < _0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D().Length)
			{
				if (_0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D()[num] == _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D)
				{
					int num2 = num / _0023_003DqvepUhX_00246FfdA6YrxTF8srQ_003D_003D;
					if (2u != 0)
					{
						_0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D = num2;
					}
				}
				int num3 = num + 1;
				if (4u != 0)
				{
					num = num3;
				}
			}
		}
		int num4 = Mathf.CeilToInt((float)_0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D().Length / (float)_0023_003DqvepUhX_00246FfdA6YrxTF8srQ_003D_003D);
		int num5;
		if (8u != 0)
		{
			num5 = num4;
		}
		int num6 = Mathf.Clamp(_0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D, 0, num5);
		if (3u != 0)
		{
			_0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D = num6;
		}
		List<LevelButtonWidget> list = _0023_003DqO5C9bDKgG0R169Zmxj2qhQ_003D_003D;
		if (_0023_003DqzLq9kum8b_HxowotWEAuXfEGkybl1VTzBABxucEGE30_003D == null)
		{
			Action<LevelButtonWidget> action = _0023_003Dq0ZaEbjfOPxSugAruMVnvFQ_003D_003D;
			if (uint.MaxValue != 0)
			{
				_0023_003DqzLq9kum8b_HxowotWEAuXfEGkybl1VTzBABxucEGE30_003D = action;
			}
		}
		list.ForEach(_0023_003DqzLq9kum8b_HxowotWEAuXfEGkybl1VTzBABxucEGE30_003D);
		_0023_003DqO5C9bDKgG0R169Zmxj2qhQ_003D_003D.Clear();
		IEnumerator<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> enumerator = _0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D().Skip(_0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D * _0023_003DqvepUhX_00246FfdA6YrxTF8srQ_003D_003D).Take(_0023_003DqvepUhX_00246FfdA6YrxTF8srQ_003D_003D)
			.GetEnumerator();
		IEnumerator<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> enumerator2;
		if (3u != 0)
		{
			enumerator2 = enumerator;
		}
		try
		{
			while (enumerator2.MoveNext())
			{
				_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D current = enumerator2.Current;
				_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D _0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D2;
				if (6u != 0)
				{
					_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D2 = current;
				}
				_0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D _0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D2 = new _0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D();
				_0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D2._0023_003DqveTNb_0024_0024zzsdoE_kbnIsM9g_003D_003D = this;
				_0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D2._0023_003Dq0a60WAectVW5l3R3SBHlffwKm7RDk15hWVU_9BwLJL4_003D = _0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D2;
				LevelButtonWidget levelButtonWidget = PrefabLevelButtonWidget._0023_003DqtivOzK_lKBP3PRQc9NUCqIlfxzlOnTKElnTf1y9KsSQ_003D(base.gameObject, new Vector2(450 + 182 * (_0023_003DqO5C9bDKgG0R169Zmxj2qhQ_003D_003D.Count % 5), -104 - 134 * (_0023_003DqO5C9bDKgG0R169Zmxj2qhQ_003D_003D.Count / 5)));
				_0023_003DqO5C9bDKgG0R169Zmxj2qhQ_003D_003D.Add(levelButtonWidget);
				levelButtonWidget.Initialize(_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D2._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D());
				levelButtonWidget.ActiveButton.onClick.AddListener(_0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D2._0023_003Dq3Z14BPsq11OqZXkIcPCLTQ_003D_003D);
				levelButtonWidget.CompilationFailedButton.onClick.AddListener(_0023_003DqODg3rlE4OV_ATtag7me12IGg2b_0024coaJFLsjeHyD7qpE_003D2._0023_003Dqxc3bFHyXgznheZYAg1DzSw_003D_003D);
				levelButtonWidget.UnlockUnconditionally();
				levelButtonWidget.IsSelected = _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003DqkuoyTclZnjTlFDx1VFzbvQ_003D_003D(_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D2);
				levelButtonWidget.IsSolved = _0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D2._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003DqgIZeKHjpb3DWG3JGkCVDlA_003D_003D();
			}
		}
		finally
		{
			if (enumerator2 != null)
			{
				enumerator2.Dispose();
			}
		}
		PuzzleInfoText.text = ((!_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D()) ? _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992025) : string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693976608), _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003DqtTvEXXGbpBW4Rhvpc7H3iw_003D_003D));
		EditButton.Interactable = _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D();
		CopyButton.Interactable = _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D();
		DeleteButton.Interactable = _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D();
		ExportButton.Interactable = _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D();
		PreviousButton.Interactable = _0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D > 0;
		NextButton.Interactable = _0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D < num5 - 1;
		if (_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D() && _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003Dq3sMbyREsG9KR2ADXQ_79JQ_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			PuzzleInfoText.gameObject.SetActive(false);
			SlotButtonWidget[] puzzleSlotButtons = PuzzleSlotButtons;
			if (_0023_003DqMJKOs_0024LQlrUtEWULIYzJ9ZCCewf8SJUgqdieJ3T8IeM_003D == null)
			{
				_0023_003DqMJKOs_0024LQlrUtEWULIYzJ9ZCCewf8SJUgqdieJ3T8IeM_003D = _0023_003DqXx1CzK5Px7kTRKyOV03RLA_003D_003D;
			}
			puzzleSlotButtons._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003DqMJKOs_0024LQlrUtEWULIYzJ9ZCCewf8SJUgqdieJ3T8IeM_003D);
			CompileErrorPanel.gameObject.SetActive(true);
			CompileErrorText.text = _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003Dq3sMbyREsG9KR2ADXQ_79JQ_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D();
		}
		else if (_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			PuzzleInfoText.gameObject.SetActive(true);
			SlotButtonWidget[] puzzleSlotButtons2 = PuzzleSlotButtons;
			if (_0023_003DqU2vrtwjRyewX2h1R34qk7ePxjx2_00248SGSsSw98ZD1H98_003D == null)
			{
				_0023_003DqU2vrtwjRyewX2h1R34qk7ePxjx2_00248SGSsSw98ZD1H98_003D = delegate(SlotButtonWidget _0023_003Dqnq97DQAlgI89oZvS7cF2eQ_003D_003D)
				{
					int num10 = 2;
					if (-1 == 0)
					{
					}
					_0023_003Dqnq97DQAlgI89oZvS7cF2eQ_003D_003D.gameObject.SetActive(true);
				};
			}
			puzzleSlotButtons2._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003DqU2vrtwjRyewX2h1R34qk7ePxjx2_00248SGSsSw98ZD1H98_003D);
			CompileErrorPanel.gameObject.SetActive(false);
			HashSet<int> hashSet = new HashSet<int>();
			for (int num7 = 0; num7 < PuzzleSlotButtons.Length; num7++)
			{
				if (File.Exists(_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num7)))
				{
					string text = _0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqnZZOBp_NyT8a0M6o1riWGa8GVe0Fc0hjzyYHLg5bbuM_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num7);
					global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<Dictionary<_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D, int>> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = _0023_003Dqy7GMRnE4XLVH0pZDRa_0024PGQ_003D_003D._0023_003DqddeKaXEeW_ew9LN7Ne9YnQ_003D_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num7);
					if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
					{
						PuzzleSlotButtons[num7].SetSolved(text, _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()[(_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)0], _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()[(_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)2], _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()[(_0023_003DqDtTjN3pZ40uupUdT_khEcw_003D_003D)1]);
					}
					else
					{
						PuzzleSlotButtons[num7].SetUnsolved(text);
					}
					hashSet.Add(num7);
				}
				else
				{
					PuzzleSlotButtons[num7].SetEmpty();
				}
			}
			for (int num8 = 0; num8 < PuzzleSlotButtons.Length; num8++)
			{
				PuzzleSlotButtons[num8].CopyEnabled = hashSet.Contains(num8) && hashSet.Count < PuzzleSlotButtons.Length;
			}
		}
		else
		{
			PuzzleInfoText.gameObject.SetActive(true);
			SlotButtonWidget[] puzzleSlotButtons3 = PuzzleSlotButtons;
			if (_0023_003DqHNCgQJW8ghE5pgpWg4F1GGCJitSQbCJKPDnJB_rODyg_003D == null)
			{
				_0023_003DqHNCgQJW8ghE5pgpWg4F1GGCJitSQbCJKPDnJB_rODyg_003D = delegate(SlotButtonWidget _0023_003DqTfkAvaNroL3jYgvw8dwFtA_003D_003D)
				{
					int num11 = 4;
					if (3 == 0)
					{
					}
					_0023_003DqTfkAvaNroL3jYgvw8dwFtA_003D_003D.gameObject.SetActive(true);
				};
			}
			puzzleSlotButtons3._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003DqHNCgQJW8ghE5pgpWg4F1GGCJitSQbCJKPDnJB_rODyg_003D);
			CompileErrorPanel.gameObject.SetActive(false);
			SlotButtonWidget[] puzzleSlotButtons4 = PuzzleSlotButtons;
			if (_0023_003DqAJcFIYr9aHxAqBbos8ZWFPQQMb9jAbvW5zrYBNetuBU_003D == null)
			{
				_0023_003DqAJcFIYr9aHxAqBbos8ZWFPQQMb9jAbvW5zrYBNetuBU_003D = delegate(SlotButtonWidget _0023_003DqgMEuEAdYWxkkzC8P7rlAfw_003D_003D)
				{
					int num12 = 5;
					if (8 == 0)
					{
					}
					_0023_003DqgMEuEAdYWxkkzC8P7rlAfw_003D_003D.SetDisabled();
				};
			}
			puzzleSlotButtons4._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003DqAJcFIYr9aHxAqBbos8ZWFPQQMb9jAbvW5zrYBNetuBU_003D);
			SlotButtonWidget[] puzzleSlotButtons5 = PuzzleSlotButtons;
			if (_0023_003Dq9AdZtM1kxjj4zR2wjmATpyJnMtotHpoNgW2V_x_fY4k_003D == null)
			{
				_0023_003Dq9AdZtM1kxjj4zR2wjmATpyJnMtotHpoNgW2V_x_fY4k_003D = _0023_003Dq1VC9NpIes_sHUAcUXSQebg_003D_003D;
			}
			puzzleSlotButtons5._0023_003DqIovx0zgjiZWgUzRs7pO0pA_003D_003D(_0023_003Dq9AdZtM1kxjj4zR2wjmATpyJnMtotHpoNgW2V_x_fY4k_003D);
		}
		IEnumerable<_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D> source = _0023_003DqrBLsbxcMK_0024fCpnjHfkm1kw_003D_003D._0023_003DqNSUh5VDqbL5EZK27KGtbO7DgwVXl381aNnI7LhXKYkU_003D();
		if (_0023_003DqQ_0024f0FbDVOn6AQsqimj94rBFaV_vrig2rfLdVNYMq_7Q_003D == null)
		{
			_0023_003DqQ_0024f0FbDVOn6AQsqimj94rBFaV_vrig2rfLdVNYMq_7Q_003D = _0023_003Dqwy4JWmpwwn1xSIRRtBEG1w_003D_003D;
		}
		int num9 = source.Count(_0023_003DqQ_0024f0FbDVOn6AQsqimj94rBFaV_vrig2rfLdVNYMq_7Q_003D);
		if (num9 >= _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003Dq0zISDcYOlo0ft6zpQ3dM8zapkkyr0Tc4J6gwOxjZoEI_003D)
		{
			BonusCampaignButton.gameObject.SetActive(true);
			BonusCampaignDisabledButton.gameObject.SetActive(false);
		}
		else
		{
			BonusCampaignButton.gameObject.SetActive(false);
			BonusCampaignDisabledButton.gameObject.SetActive(true);
			BonusCampaignDisabledText.text = string.Format(_0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992381), _0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003Dq0zISDcYOlo0ft6zpQ3dM8zapkkyr0Tc4J6gwOxjZoEI_003D - num9);
		}
	}

	private void _0023_003Dqax7aHuRiF5mYIKmK2KBCRrUGQHzqEUxyq1IDMKfDGEs_003D(_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D _0023_003Dqkc95IxGINQLva5bQIatPTQ_003D_003D)
	{
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003Dqkc95IxGINQLva5bQIatPTQ_003D_003D;
		if (uint.MaxValue != 0)
		{
			_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj;
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
	}

	private void _0023_003DqZbLtACjgPfs2gU8vcbv7XGKOpAIYPTF1w_sxrkO7PAY_003D(int _0023_003DqFjUSTrgDR92DnsgDE1keVg_003D_003D)
	{
		int num = 3;
		if (6 == 0)
		{
		}
		_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003DqVItL8TPkfvaBQS0HAP9isg_003D_003D = _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D();
		int num2 = 0;
		if (6 == 0)
		{
		}
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq6Zw62nChD4luLafKIQN9QYCVPk0bVXdbmwkDY6UjCLE_003D(_0023_003DqVItL8TPkfvaBQS0HAP9isg_003D_003D, _0023_003DqFjUSTrgDR92DnsgDE1keVg_003D_003D);
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
	}

	private void _0023_003Dq_dvfkBk3AJV8D_ZmOS5wrkD5KjhLQPFCAKCk3xm7qIw_003D(int _0023_003DqEWbf0cw0lt3eVUCBi_LP3A_003D_003D)
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		int num;
		if (2u != 0)
		{
			num = 0;
		}
		while (File.Exists(_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num)))
		{
			int num2 = num + 1;
			if (2u != 0)
			{
				num = num2;
			}
		}
		File.Copy(_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), _0023_003DqEWbf0cw0lt3eVUCBi_LP3A_003D_003D), _0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqpwvT7Yh0t41Du7I1npvS_0024ixUh08eIV_PgDuShst3mkU_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqOJEQkYAOmGiRAtvUIThilQ_003D_003D()._0023_003Dq2olmwVwCDocp7sBD_zsu9g_003D_003D(), num));
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
	}

	private void _0023_003DqDmTvIe3N_0024TxzhssybDlY04_TZjJlY3uxwWlEtrVzPB0_003D()
	{
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D._0023_003DqmSWl_0024hrePCLVMFEA36b7Yw_003D_003D();
		if (8u != 0)
		{
			_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj;
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
	}

	private void _0023_003DqvBAfG7N22b1i7drzkbzCkiuvt5gEHe0UU2V1oRHZvV0_003D()
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		int num = 1;
		if (5 == 0)
		{
		}
		_0023_003Dqy0ZGQ7qalDKAYNAMKV2GGQ_003D_003D._0023_003DqRDVHhnXxZA6gQLO_yxY12B6p5IT6PKwqd0i_0024vK2Tv5w_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqgiPo9I4YvvAfgUmL__TuZw_003D_003D());
	}

	private void _0023_003DqPyJGLWjfoSfuUGxJfZuVIirLiAaumGaNb1mX8CvptGY_003D()
	{
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqNGvdB8GL00MOci55aRknjQ_003D_003D();
		if (uint.MaxValue != 0)
		{
			_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj;
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
	}

	private void _0023_003DqIcKVljSP0ApaZS42DlRQKS49ToZThbqS_6Lt_0024ZHLJWA_003D()
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		string _0023_003Dq4fjtdQDNO23fsnSnQXHcuA_003D_003D = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992347);
		string _0023_003Dqg3juCHVHG5XvxAark3Txzw_003D_003D = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693992448);
		string _0023_003Dq6xWTsxOky8ZMIYPYX88KTw_003D_003D = _0023_003DqjKMQFNwyWeEM9qJJ1Da_0024w1L_0024COnz_oY2g2uR73iAZjc_003D._0023_003DqfTKnxZ55Xawozllu3iuEZA_003D_003D(-1693991202);
		Action _0023_003Dqmd5Op6zarjhr7TulUhYazA_003D_003D = delegate
		{
			_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqxMFtkN9_0024CNa2ZtYn4q6m0w_003D_003D();
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
			if (6u != 0)
			{
				_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj;
			}
			_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
			_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
		};
		if (_0023_003Dq_GeS4s9T8_0024Il_0024l92StwldZpr3K34jVSpsi3GvPjL3hI_003D == null)
		{
			Action action = delegate
			{
				_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
			};
			if (2u != 0)
			{
				_0023_003Dq_GeS4s9T8_0024Il_0024l92StwldZpr3K34jVSpsi3GvPjL3hI_003D = action;
			}
		}
		_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003Dq29w08ObQRA3q95hKxqdZ_0024QEtOkZ_dyi_yiZh_0024OKoU7Q_003D(_0023_003Dq4fjtdQDNO23fsnSnQXHcuA_003D_003D, _0023_003Dqg3juCHVHG5XvxAark3Txzw_003D_003D, _0023_003Dq6xWTsxOky8ZMIYPYX88KTw_003D_003D, _0023_003Dqmd5Op6zarjhr7TulUhYazA_003D_003D, _0023_003Dq_GeS4s9T8_0024Il_0024l92StwldZpr3K34jVSpsi3GvPjL3hI_003D);
	}

	private void _0023_003DqGGhyrbvFru1hOU_0024HdxuyK_00242PB_l5PUrQYmJyEnx_0024kvw_003D()
	{
		int num = 7;
		if (1 == 0)
		{
		}
		_0023_003DqxQ3iG2XxQ7WbWM0L_0024xFf6mxiETxlQ_0024qVEEUTt0G0Jrc_003D._0023_003DqhpT9nV1XoIA7h82SItNKUA_003D_003D(_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqEMCkLeMW5M4pGXCfZq_iag_003D_003D());
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
	}

	private void _0023_003DqmCeTghKwMMHzKG_0024qKIhHrc4TuAWeDc585gsLaRWNpvQ_003D()
	{
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D._0023_003DqTen4pVhlETQ8NDqeTIEyOw_003D_003D(_0023_003DqxQ3iG2XxQ7WbWM0L_0024xFf6mxiETxlQ_0024qVEEUTt0G0Jrc_003D._0023_003DqVHhQOWROIXIkcDe3AwMxPA_003D_003D());
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
		if (5u != 0)
		{
			_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2 = obj;
		}
		if (_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2._0023_003Dq_t_dZz92eyc4wAaNtiaHQQ_003D_003D())
		{
			global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj2 = _0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D2;
			if (uint.MaxValue != 0)
			{
				_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj2;
			}
			_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
		}
	}

	private void _0023_003DqtQHf18kAib6qp88o3dVj_PxuKatBk7rQjBtYzuri9Lc_003D()
	{
		int num = _0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D - 1;
		if (7u != 0)
		{
			_0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D = num;
		}
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D().Skip(_0023_003DqvepUhX_00246FfdA6YrxTF8srQ_003D_003D * _0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D)._0023_003Dq_LoHFM9bEEhQdhJbd03LQA_003D_003D();
		if (6u != 0)
		{
			_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj;
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
	}

	private void _0023_003Dqr3ot6oLwwQUoCBmD1ZncI0B3KD1X0LIxfDPlKagUl3U_003D()
	{
		int num = _0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D + 1;
		if (5u != 0)
		{
			_0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D = num;
		}
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003DqpeSkM1O6nj9HA_0024BvhJltZZTgebQWhOf9WhcnmbVT0po_003D._0023_003DqkzbJA5XiH5ZVT8qgTsRxl8NHynvaOe3Vb2yqxO6zlcY_003D().Skip(_0023_003DqvepUhX_00246FfdA6YrxTF8srQ_003D_003D * _0023_003DqlFQP8rvUlgmutiRXpXHu4w_003D_003D)._0023_003Dq_LoHFM9bEEhQdhJbd03LQA_003D_003D();
		if (true)
		{
			_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj;
		}
		_0023_003Dq4inqwnaZy3EVsj_0024PWmheeQ_003D_003D._0023_003Dq4xQgULUtpGqS6lkQJJLfKQ_003D_003D.SoundClick._0023_003Dq7Eq_MQoPTaPgnsKtyS5iwQ_003D_003D();
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
	}

	private void _0023_003Dqw_0024JS_0024HJQKD_v4HXECfaKV1ajBX79qGzKg_wZ75I_0024WMI_003D()
	{
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003Dq_0024_R7En3tvhdkdQYD_sqSKjumPtTqp_0024fk4EII12G0BbQ_003D(_0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D);
	}

	private void _0023_003DqfGmmQ5pfUdVGRwbBOjQbwSiXApB04_00244muc_AEvPMcf4_003D()
	{
		_0023_003DqHHcYOzWpsCU_0024BtLsYZaaPw_003D_003D._0023_003DqxYh_7Xrv6jPxD3QBTgCuazvdhClNlCtIFQtOiewEdBo_003D();
	}

	private bool _0023_003Dq8zkXbsqQG62xZz1a2yMdjg_003D_003D(_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D _0023_003DqJ5XjMyiuryrFUzjvlbaNrQ_003D_003D)
	{
		int num = 8;
		if (2 == 0)
		{
		}
		string _0023_003DqyfFDE7My3LvOaux_0024HX5C0Q_003D_003D = _0023_003DqJ5XjMyiuryrFUzjvlbaNrQ_003D_003D._0023_003DqyfFDE7My3LvOaux_0024HX5C0Q_003D_003D;
		int num2 = 6;
		if (4 == 0)
		{
		}
		return _0023_003DqyfFDE7My3LvOaux_0024HX5C0Q_003D_003D == _0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqyfFDE7My3LvOaux_0024HX5C0Q_003D_003D;
	}

	private static void _0023_003Dq0ZaEbjfOPxSugAruMVnvFQ_003D_003D(LevelButtonWidget _0023_003DqgvtOgZ0zJF_SEaij0JBFqQ_003D_003D)
	{
		int num = 0;
		if (false)
		{
		}
		UnityEngine.Object.Destroy(_0023_003DqgvtOgZ0zJF_SEaij0JBFqQ_003D_003D.gameObject);
	}

	private static void _0023_003DqXx1CzK5Px7kTRKyOV03RLA_003D_003D(SlotButtonWidget _0023_003DqXht77CRRaJTZ1Xs9XkYfzg_003D_003D)
	{
		int num = -1;
		if (2 == 0)
		{
		}
		_0023_003DqXht77CRRaJTZ1Xs9XkYfzg_003D_003D.gameObject.SetActive(false);
	}

	private static void _0023_003DqbSeaRW1_0024wj_0024waC9fFM7fjQ_003D_003D(SlotButtonWidget _0023_003Dqnq97DQAlgI89oZvS7cF2eQ_003D_003D)
	{
		int num = 2;
		if (-1 == 0)
		{
		}
		_0023_003Dqnq97DQAlgI89oZvS7cF2eQ_003D_003D.gameObject.SetActive(true);
	}

	private static void _0023_003Dq1Z2fEs1Qu_ub8wwIo_0024e8sQ_003D_003D(SlotButtonWidget _0023_003DqTfkAvaNroL3jYgvw8dwFtA_003D_003D)
	{
		int num = 4;
		if (3 == 0)
		{
		}
		_0023_003DqTfkAvaNroL3jYgvw8dwFtA_003D_003D.gameObject.SetActive(true);
	}

	private static void _0023_003Dq6JUNEC7_xTGv2A1g97_00248mg_003D_003D(SlotButtonWidget _0023_003DqgMEuEAdYWxkkzC8P7rlAfw_003D_003D)
	{
		int num = 5;
		if (8 == 0)
		{
		}
		_0023_003DqgMEuEAdYWxkkzC8P7rlAfw_003D_003D.SetDisabled();
	}

	private static void _0023_003Dq1VC9NpIes_sHUAcUXSQebg_003D_003D(SlotButtonWidget _0023_003DqEZbum2vd8E_G1C2TKvF69w_003D_003D)
	{
		int num = 3;
		if (4 == 0)
		{
		}
		_0023_003DqEZbum2vd8E_G1C2TKvF69w_003D_003D.CopyEnabled = false;
	}

	private static bool _0023_003Dqwy4JWmpwwn1xSIRRtBEG1w_003D_003D(_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D _0023_003Dq_jE4SCRuf2Z17yuguUeHWQ_003D_003D)
	{
		int num = 1;
		if (5 == 0)
		{
		}
		int result;
		if (_0023_003Dq_jE4SCRuf2Z17yuguUeHWQ_003D_003D._0023_003DqgIZeKHjpb3DWG3JGkCVDlA_003D_003D())
		{
			int num2 = 8;
			if (4 == 0)
			{
			}
			result = ((_0023_003Dq_jE4SCRuf2Z17yuguUeHWQ_003D_003D._0023_003Dqwl6R8LkbULUWblsGhtQQbg_003D_003D == (_0023_003DqltIAkw2PAhwNzsdTgWusIg_003D_003D._0023_003DqgNaolQmxqs1nuTZbHAY6nA_003D_003D)0) ? 1 : 0);
		}
		else
		{
			result = 0;
		}
		return (byte)result != 0;
	}

	private void _0023_003DqvPs1DWc_0024HZT1vh06yG_bNmK3JSg_0024yHkQ5k9Knruo7jQ_003D()
	{
		_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D._0023_003Dq3qiF1s15nuW_0024Ut_eTdK5JQ_003D_003D()._0023_003DqxMFtkN9_0024CNa2ZtYn4q6m0w_003D_003D();
		global::_0023_003DqR8Z5w5CojvJHXAww9GCK5A_003D_003D<_0023_003DqrQbvk525DQekm7O70X6B1Q_003D_003D> obj = _0023_003DqKCpmYhU3Cw6rFrAWMAU1RA_003D_003D._0023_003DqSzEc316GHrb1MmRpC7aFWQ_003D_003D;
		if (6u != 0)
		{
			_0023_003DqnYlEWGSNrUmpKOVr9_0024wZww_003D_003D = obj;
		}
		_0023_003Dq2tgDMxTc4SBYEd0Gtmzt2g_003D_003D();
		_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
	}

	private static void _0023_003DqkacVWeRszkwOQqMmE0AAW2vOI4S50DYQeNy_0024qYPrMuE_003D()
	{
		_0023_003Dq7nyGom7d1ZRCml7g7GnGnw_003D_003D._0023_003DqkqQCP_0024wr4EPgPjTQnwoXKhN6kbIvgKlz5Uc_F7BrXMo_003D();
	}
}
