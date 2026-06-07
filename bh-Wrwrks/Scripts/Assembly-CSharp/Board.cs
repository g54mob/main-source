using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Board : MonoBehaviour
{
	public enum FitState
	{
		True = 0,
		False = 1,
		Upgrade = 2,
		Swap = 3
	}

	public struct SwapInfo
	{
		public bool canSwap;

		public int xTarget;

		public int yTarget;

		public int mTarget;

		public SwapInfo(bool c, int x, int y, int m)
		{
			canSwap = c;
			xTarget = x;
			yTarget = y;
			mTarget = m;
		}
	}

	public GameObject modFrameBG;

	public GameObject prevObj;

	public Dungeon dungeon = Dungeon.Instance;

	public List<Module> modules = new List<Module>();

	public List<Module> extraModules = new List<Module>();

	public List<SpriteRenderer> previews = new List<SpriteRenderer>();

	public ulong wireCount = 10uL;

	public bool previewing;

	private int previewIndex = -1;

	private Module upg;

	public GameObject errorMove;

	private Coroutine errorMove_hider;

	private bool moveErrorReset = true;

	public GameObject dupeError;

	private bool dupeErrorShown;

	private int dupeTimer;

	public GameObject bankError;

	private bool bankErrorShown;

	private int bankTimer;

	public GameObject StateUpgrade;

	public GameObject StateSell;

	public GameObject StateAlert;

	public List<Module> GetBoard()
	{
		List<Module> list = new List<Module>();
		foreach (Module module in modules)
		{
			if (module != null && !list.Contains(module))
			{
				list.Add(module);
			}
		}
		return list;
	}

	private List<Module> GetConnected(Module m)
	{
		List<Module> list = new List<Module>(m.inputs);
		list.AddRange(m.outputs);
		return list;
	}

	public List<Module> GetNetwork(Module start)
	{
		List<Module> list = new List<Module> { start };
		List<Module> connected = GetConnected(start);
		list.AddRange(connected);
		bool flag = connected.Count > 0;
		while (flag)
		{
			flag = false;
			_ = list.Count;
			List<Module> list2 = new List<Module>();
			foreach (Module item in list)
			{
				foreach (Module item2 in GetConnected(item))
				{
					if (!list.Contains(item2))
					{
						list2.Add(item2);
						flag = true;
					}
				}
			}
			list.AddRange(list2);
		}
		return new List<Module>(list.Distinct());
	}

	public List<Module> GetTribe(Module.Tribe tribe, bool bankInlucded = false)
	{
		List<Module> board = GetBoard();
		if (tribe == Module.Tribe.None)
		{
			return board;
		}
		List<Module> list = new List<Module>();
		foreach (Module item in board)
		{
			if (item.tribes.Contains(tribe))
			{
				list.Add(item);
			}
		}
		if (bankInlucded)
		{
			board = dungeon.bank.GetBank();
			foreach (Module item2 in board)
			{
				if (item2.tribes.Contains(tribe))
				{
					list.Add(item2);
				}
			}
		}
		return list;
	}

	public int GetNetworkCount(Module m, Module.Tribe t = Module.Tribe.None)
	{
		int num = 0;
		foreach (Module item in GetNetwork(m))
		{
			if (t == Module.Tribe.None)
			{
				num++;
			}
			else if (item.tribes.Contains(t))
			{
				num++;
			}
			if (item.name == Module.Name.Bluechip)
			{
				num += (item.UPGRADED ? 4 : 2);
			}
		}
		return num + dungeon.player.mainframe;
	}

	public List<Aura> GetBoardAuras()
	{
		List<Aura> list = new List<Aura>();
		List<Module> board = GetBoard();
		board.AddRange(dungeon.bank.GetBank());
		foreach (Module item in board)
		{
			list.AddRange(item.auras);
		}
		list.AddRange(dungeon.player.sentinel.auras);
		return list;
	}

	public int CountAuras(Aura.Type t)
	{
		List<Aura> boardAuras = GetBoardAuras();
		int num = 0;
		foreach (Aura item in boardAuras)
		{
			if (item.type == t)
			{
				num++;
			}
		}
		return num;
	}

	private void Awake()
	{
		Init();
	}

	public Vector3 GetModulePos(Module m, int index)
	{
		float num = 4.15625f;
		return m.size switch
		{
			Module.Size.Medium => new Vector3(-3.375f + (float)(index % 5 * 36) / 16f, num - (float)(index / 5) * 4.125f, 0f), 
			Module.Size.Large => new Vector3(-2.25f + (float)(index % 5 * 36) / 16f, num - (float)(index / 5) * 4.125f, 0f), 
			_ => new Vector3(-4.5f + (float)(index % 5 * 36) / 16f, num - (float)(index / 5) * 4.125f, 0f), 
		};
	}

	public void Init()
	{
		modules = new List<Module>
		{
			null, null, null, null, null, null, null, null, null, null,
			null, null, null, null, null
		};
		int num = 0;
		foreach (Module module in modules)
		{
			_ = module;
			SpriteRenderer component = Object.Instantiate(prevObj).GetComponent<SpriteRenderer>();
			component.transform.parent = modFrameBG.transform;
			component.transform.localPosition = GetModulePos(dungeon.player.sentinel, num);
			component.enabled = false;
			previews.Add(component);
			num++;
		}
	}

	public SwapInfo CanSwap(Module x, Module y, int targetInd)
	{
		SwapInfo result = new SwapInfo(c: false, -1, -1, -1);
		result.xTarget = y.index;
		result.yTarget = x.index;
		if (x.size == y.size)
		{
			if (x.size == Module.Size.Small)
			{
				result.canSwap = true;
				return result;
			}
			if (x.size == Module.Size.Medium)
			{
				if (targetInd == y.index)
				{
					result.canSwap = true;
					return result;
				}
				if (targetInd == y.index + 1 && (y.index + 1) % 5 != 0 && (y.index + 1) % 5 != 4 && modules[y.index + 2] == null)
				{
					result.canSwap = true;
					result.xTarget = targetInd;
					return result;
				}
				if (targetInd == y.index - 1 && y.index % 5 != 0 && modules[y.index - 1] == null)
				{
					result.canSwap = true;
					result.xTarget = targetInd;
					return result;
				}
				result.canSwap = true;
			}
			return result;
		}
		Module module = ((x.size == Module.Size.Small) ? x : y);
		Module module2 = ((x.size == Module.Size.Medium) ? x : y);
		int num = ((x.size == Module.Size.Small) ? y.index : x.index);
		int num2 = ((x.size == Module.Size.Small) ? x.index : y.index);
		if (module.index % 5 == 4)
		{
			if (modules[module.index - 1] == null)
			{
				result.canSwap = true;
				num = ((targetInd == num + 1) ? (num + 1) : num);
				num2 = module.index - 1;
			}
		}
		else if (module.index % 5 == 0)
		{
			if (modules[module.index + 1] == null)
			{
				result.canSwap = true;
				num = ((targetInd == num + 1) ? targetInd : num);
				num2 = module.index;
			}
		}
		else
		{
			bool flag = false;
			bool flag2 = false;
			if (modules[module.index + 1] == null)
			{
				flag = true;
			}
			if (modules[module.index - 1] == null)
			{
				flag2 = true;
			}
			if (flag || flag2)
			{
				result.canSwap = true;
				num = ((targetInd == num + 1) ? targetInd : num);
			}
			if (targetInd == num2 - 1 && flag2)
			{
				num2 = targetInd;
			}
			if (flag2 && !flag)
			{
				num2 = module.index - 1;
			}
		}
		if (module.index == module2.index - 1 && module.index / 5 == module2.index / 5)
		{
			if (targetInd == module2.index)
			{
				result.canSwap = true;
				if (module.index % 5 != 0)
				{
					if (modules[module.index - 1] == null)
					{
						num = targetInd;
						num2 = module.index - 1;
					}
					else
					{
						num = targetInd + 1;
						num2 = module.index;
					}
				}
				else
				{
					num = targetInd + 1;
					num2 = module.index;
				}
			}
			if (targetInd == module2.index + 1)
			{
				result.canSwap = true;
				num = targetInd;
				num2 = module.index;
			}
			if (targetInd == module.index)
			{
				result.canSwap = true;
				num = targetInd + 2;
				num2 = module.index;
			}
		}
		if (module.index == module2.index + 2 && module.index / 5 == module2.index / 5)
		{
			if (targetInd == module2.index)
			{
				result.canSwap = true;
				num = targetInd;
				num2 = module2.index + 1;
			}
			if (targetInd == module2.index + 1 && x == module2)
			{
				result.canSwap = true;
				num = module2.index;
				num2 = module2.index + 1;
			}
			if (targetInd == module2.index + 1 && x == module)
			{
				if (module.index % 5 == 4)
				{
					result.canSwap = true;
					num = module2.index;
					num2 = module2.index + 1;
				}
				else if (modules[module.index + 1] == null)
				{
					result.canSwap = true;
					num = module2.index + 1;
					num2 = module2.index + 2;
				}
				else
				{
					result.canSwap = true;
					num = module2.index;
					num2 = module2.index + 1;
				}
			}
		}
		bool flag3 = false;
		if (module.index / 5 == module2.index / 5)
		{
			flag3 = true;
			for (int i = module.index / 5 * 5; i < module.index / 5 * 5 + 5; i++)
			{
				if (modules[i] == null)
				{
					flag3 = false;
				}
			}
		}
		if (flag3)
		{
			int num3 = module.index / 5 * 5;
			if (modules[num3].size == Module.Size.Medium && modules[num3 + 2].size == Module.Size.Medium && modules[num3 + 4].size == Module.Size.Small && x == module && (targetInd == num3 || targetInd == num3 + 1))
			{
				result.canSwap = true;
				Vector3 localPosition = modules[num3 + 2].transform.localPosition;
				AddModule(modules[num3 + 2], num3 + 3, forcedSwap: true);
				StartCoroutine(swapAnim(modules[num3 + 3], modules[num3 + 3].transform.localPosition));
				modules[num3 + 3].transform.localPosition = localPosition;
				num = module2.index;
				num2 = module2.index + 1;
			}
			if (modules[num3].size == Module.Size.Small && modules[num3 + 1].size == Module.Size.Medium && modules[num3 + 3].size == Module.Size.Medium && x == module && (targetInd == num3 + 3 || targetInd == num3 + 4))
			{
				result.canSwap = true;
				Vector3 localPosition2 = modules[num3 + 1].transform.localPosition;
				AddModule(modules[num3 + 1], num3, forcedSwap: true);
				StartCoroutine(swapAnim(modules[num3], modules[num3].transform.localPosition));
				modules[num3].transform.localPosition = localPosition2;
				num = module2.index + 1;
				num2 = module2.index - 1;
			}
		}
		result.xTarget = ((module == x) ? num : num2);
		result.yTarget = ((module == y) ? num : num2);
		if (x == module2 && result.xTarget == module.index - 1 && result.xTarget != module2.index + 1 && result.canSwap)
		{
			result.yTarget = module2.index + 1;
		}
		if (x == module2 && result.xTarget == module.index && module.index == module2.index + 2 && module.index / 5 == module2.index / 5 && result.canSwap)
		{
			result.yTarget = module2.index + 1;
		}
		return result;
	}

	public SwapInfo CanSwapTriple(Module m, Module x, Module y, int targetInd)
	{
		SwapInfo result = new SwapInfo(c: false, m.index, m.index + 2, targetInd);
		if (x.size == y.size && x.size == Module.Size.Small)
		{
			result.canSwap = true;
			result.xTarget = m.index;
			result.yTarget = m.index + 1;
		}
		if (x.size == y.size && x.size == Module.Size.Medium)
		{
			if (m.index % 5 == 0)
			{
				if (modules[m.index + 2] == null && modules[m.index + 3] == null)
				{
					result.canSwap = true;
					result.xTarget = m.index;
					result.yTarget = m.index + 2;
				}
			}
			else if (m.index % 5 == 3)
			{
				if (modules[m.index - 1] == null && modules[m.index - 2] == null)
				{
					result.canSwap = true;
					result.yTarget = m.index;
					result.xTarget = m.index - 2;
				}
			}
			else if (modules[m.index - 1] == null && modules[m.index + 2] == null)
			{
				result.canSwap = true;
				result.xTarget = m.index - 1;
				result.yTarget = m.index + 1;
			}
		}
		if (x.size != y.size)
		{
			if (x.size == Module.Size.Small && y.size == Module.Size.Medium)
			{
				if (m.index % 5 == 3)
				{
					if (modules[m.index - 1] == null)
					{
						result.canSwap = true;
						result.xTarget = m.index - 1;
						result.yTarget = m.index;
					}
				}
				else if (modules[m.index + 2] == null)
				{
					result.canSwap = true;
					result.xTarget = m.index;
					result.yTarget = m.index + 1;
				}
			}
			if (x.size == Module.Size.Medium && y.size == Module.Size.Small)
			{
				if (m.index % 5 == 0)
				{
					if (modules[m.index + 2] == null)
					{
						result.canSwap = true;
						result.xTarget = m.index;
						result.yTarget = m.index + 2;
					}
				}
				else if (modules[m.index - 1] == null)
				{
					result.canSwap = true;
					result.xTarget = m.index - 1;
					result.yTarget = m.index + 1;
				}
			}
			if (x.index / 5 == y.index / 5 && y.index / 5 == m.index / 5)
			{
				int num = m.index / 5 * 5;
				if (m.index == num && x.size == Module.Size.Medium && y.size == Module.Size.Small && (targetInd == num + 4 || targetInd == num + 3))
				{
					result.canSwap = true;
					result.xTarget = m.index;
					result.yTarget = m.index + 2;
					result.mTarget = num + 3;
				}
				if (m.index == num + 3 && x.size == Module.Size.Small && y.size == Module.Size.Medium && targetInd == num)
				{
					result.canSwap = true;
					result.xTarget = num + 2;
					result.yTarget = num + 3;
					result.mTarget = num;
				}
			}
		}
		return result;
	}

	public void SwapMods(Module x, Module y, SwapInfo info)
	{
		int xTarget = info.xTarget;
		int yTarget = info.yTarget;
		Vector3 localPosition = new Vector3(y.transform.localPosition.x, y.transform.localPosition.y);
		AddModule(x, xTarget, forcedSwap: true);
		y.swapAnim = true;
		AddModule(y, yTarget, forcedSwap: true);
		StartCoroutine(swapAnim(y, y.transform.localPosition));
		y.transform.localPosition = localPosition;
		CheckAuras();
	}

	public void TripleSwap(Module mid, Module a, Module b, SwapInfo info)
	{
		Vector3 localPosition = new Vector3(a.transform.localPosition.x, a.transform.localPosition.y);
		Vector3 localPosition2 = new Vector3(b.transform.localPosition.x, b.transform.localPosition.y);
		_ = mid.index;
		a.swapAnim = true;
		b.swapAnim = true;
		AddModule(mid, info.mTarget, forcedSwap: true);
		AddModule(a, info.xTarget, forcedSwap: true);
		AddModule(b, info.yTarget, forcedSwap: true);
		StartCoroutine(swapAnim(a, a.transform.localPosition));
		a.transform.localPosition = localPosition;
		StartCoroutine(swapAnim(b, b.transform.localPosition));
		b.transform.localPosition = localPosition2;
		CheckAuras();
	}

	public IEnumerator swapAnim(Module m, Vector3 tar)
	{
		m.swapAnim = true;
		yield return null;
		m.SetElevated(elev: true);
		m.DragPlugs();
		yield return dungeon.animationManager.LerpTo(m.gameObject, tar, 5, 0.2f);
		m.EndDragPlugs();
		m.SetElevated(elev: false);
		m.swapAnim = false;
	}

	public bool ShowUpgradeTip(int x, Module mod)
	{
		if (modules[x] != null && !mod.UPGRADED && modules[x] != mod && modules[x].name == mod.name && !modules[x].UPGRADED)
		{
			if (mod.WIREMOD)
			{
				dungeon.tooltip.Set(modules[x], showUpgrade: true, noUpgrade: true);
				return false;
			}
			if (mod.PRIORITY)
			{
				Tooltip tooltip = dungeon.tooltip;
				Module specialPosMod = modules[x];
				tooltip.Set(mod, showUpgrade: true, noUpgrade: false, null, "", "", default(Vector3), force: false, "", specialPosMod);
			}
			else
			{
				dungeon.tooltip.Set(modules[x], showUpgrade: true);
			}
			return true;
		}
		return false;
	}

	public FitState CanFit(int x, Module mod, bool showUpg = true)
	{
		if (modules[x] != null && !mod.UPGRADED && modules[x] != mod && modules[x].name == mod.name && !modules[x].UPGRADED)
		{
			if (mod.WIREMOD)
			{
				if (showUpg)
				{
					dungeon.tooltip.Set(modules[x], showUpgrade: true, noUpgrade: true);
				}
				return FitState.False;
			}
			if (mod.PRIORITY)
			{
				if (showUpg)
				{
					Tooltip tooltip = dungeon.tooltip;
					Module specialPosMod = modules[x];
					tooltip.Set(mod, showUpgrade: true, noUpgrade: false, null, "", "", default(Vector3), force: false, "", specialPosMod);
				}
			}
			else if (showUpg)
			{
				dungeon.tooltip.Set(modules[x], showUpgrade: true);
			}
			return FitState.Upgrade;
		}
		switch (mod.size)
		{
		default:
			if (!(modules[x] == null))
			{
				return FitState.False;
			}
			return FitState.True;
		case Module.Size.Medium:
			if ((x + 1) % 5 == 0)
			{
				return FitState.False;
			}
			if ((!(modules[x] == null) && !(modules[x] == mod)) || (!(modules[x + 1] == null) && !(modules[x + 1] == mod)))
			{
				return FitState.False;
			}
			return FitState.True;
		case Module.Size.Large:
			if ((x + 2) % 5 == 0)
			{
				return FitState.False;
			}
			if ((x + 1) % 5 == 0)
			{
				return FitState.False;
			}
			if ((!(modules[x] == null) && !(modules[x] == mod)) || (!(modules[x + 1] == null) && !(modules[x + 1] == mod)) || (!(modules[x + 2] == null) && !(modules[x + 2] == mod)))
			{
				return FitState.False;
			}
			return FitState.True;
		}
	}

	public void AddModule(Module m, int x, bool forcedSwap = false, bool playSound = false)
	{
		if (CanFit(x, m) == FitState.False && !forcedSwap)
		{
			if (modules[x] != null)
			{
				Debug.LogError($"MOD SLOT FULL ({modules[x].name}). CANNOT PLACE {m.name}");
			}
			return;
		}
		bool flag = false;
		if (modules.Contains(m) || forcedSwap)
		{
			if (modules[m.index] == m)
			{
				modules[m.index] = null;
			}
			if (m.size == Module.Size.Medium && modules[m.index + 1] == m)
			{
				modules[m.index + 1] = null;
			}
			if (m.size == Module.Size.Large)
			{
				if (modules[m.index + 1] == m)
				{
					modules[m.index + 1] = null;
				}
				if (modules[m.index + 2] == m)
				{
					modules[m.index + 2] = null;
				}
			}
		}
		else
		{
			flag = true;
		}
		modules[x] = m;
		if (m.size == Module.Size.Medium)
		{
			modules[x + 1] = m;
		}
		if (m.size == Module.Size.Large)
		{
			modules[x + 1] = m;
			modules[x + 2] = m;
		}
		m.index = x;
		m.bankItem = false;
		m.transform.parent = base.transform;
		m.transform.localScale = Vector3.one;
		m.transform.localPosition = GetModulePos(m, x);
		if (flag)
		{
			m.InitOnBoard(playSound);
		}
		if (m.WEAPON)
		{
			dungeon.CheckWeapons();
		}
		m.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		m.transform.localScale = Vector3.one;
		UnhighlightAll();
		if (dungeon.state != Dungeon.State.Shop)
		{
			UnhighlightAllUpgrades();
		}
		if (dungeon.state == Dungeon.State.Shop)
		{
			dungeon.shop.HighlightUpgrades();
		}
		CheckAuras();
	}

	public void RemoveModule(Module m)
	{
		if (modules.Contains(m))
		{
			Plug[] plugs = m.plugs;
			for (int i = 0; i < plugs.Length; i++)
			{
				plugs[i].Disconnect();
			}
			modules[m.index] = null;
			if (m.size == Module.Size.Medium)
			{
				modules[m.index + 1] = null;
			}
			if (m.size == Module.Size.Large)
			{
				modules[m.index + 1] = null;
				modules[m.index + 2] = null;
			}
			m.index = -1;
			if (m.WEAPON)
			{
				dungeon.CheckWeapons();
			}
			CheckAuras();
		}
	}

	public void CheckAuras(bool recheck = false)
	{
		List<Aura> list = new List<Aura>(dungeon.player.sentinel.auras);
		List<Aura> list2 = new List<Aura>();
		foreach (Aura item in list)
		{
			list2.Add(item);
			item.Activate();
		}
		List<Module> list3 = new List<Module>();
		foreach (Module module in modules)
		{
			if (module == null || list3.Contains(module))
			{
				continue;
			}
			list3.Add(module);
			foreach (Aura item2 in new List<Aura>(module.auras))
			{
				list2.Add(item2);
				item2.Activate();
			}
		}
		list3.Clear();
		foreach (Module module2 in modules)
		{
			if (!(module2 == null) && !list3.Contains(module2))
			{
				list3.Add(module2);
				module2.RefreshForeignAuras();
			}
		}
		dungeon.player.sentinel.RefreshForeignAuras();
		if (recheck)
		{
			return;
		}
		List<Aura> boardAuras = GetBoardAuras();
		bool flag = false;
		foreach (Aura item3 in boardAuras)
		{
			if (!list2.Contains(item3))
			{
				flag = true;
			}
		}
		foreach (Aura item4 in list2)
		{
			if (!boardAuras.Contains(item4))
			{
				flag = true;
			}
		}
		if (flag)
		{
			CheckAuras(recheck: true);
		}
	}

	public void ShowPreviews(Module m, bool shopItem)
	{
		bool flag = false;
		foreach (Module module2 in modules)
		{
			if (!(module2 == null) && !(module2 == m) && module2.name == m.name && !module2.UPGRADED && !m.UPGRADED)
			{
				if (!flag)
				{
					UnhighlightShopUpgrades();
					UnhighlightAllUpgrades();
					flag = true;
				}
				module2.HighlightUpgrade();
				m.HighlightUpgrade();
			}
		}
		bool flag2 = false;
		Module[] array = dungeon.bank.modules;
		foreach (Module module in array)
		{
			if (!(module == null) && !(module == m) && module.name == m.name && !module.UPGRADED && !m.UPGRADED)
			{
				if (!flag)
				{
					UnhighlightShopUpgrades();
					UnhighlightAllUpgrades();
					flag = true;
				}
				module.HighlightUpgrade();
				m.HighlightUpgrade();
				if (!module.WIREMOD)
				{
					flag2 = true;
				}
			}
		}
		if (!flag)
		{
			if (m.upgradeHighlight.enabled)
			{
				UnhighlightShopUpgrades();
				UnhighlightAllUpgrades();
				foreach (Module module3 in dungeon.shop.modules)
				{
					if (!(module3 == null) && !(module3 == m) && module3.name == m.name)
					{
						module3.HighlightUpgrade();
					}
				}
			}
			else
			{
				UnhighlightShopUpgrades();
				UnhighlightAllUpgrades();
			}
		}
		if (flag2 && dungeon.toggleStateButton.bg.sprite == dungeon.bankIcon)
		{
			dungeon.board.ShowStateUpgrade();
		}
		foreach (SpriteRenderer preview in previews)
		{
			preview.enabled = true;
		}
		StateAlert.SetActive(value: true);
		StateAlert.GetComponentInChildren<Animator>().StartAnim();
		if (!shopItem)
		{
			dungeon.shop.ShowSell(m);
		}
	}

	public void HidePreviews(bool shopItem)
	{
		foreach (SpriteRenderer preview in previews)
		{
			preview.enabled = false;
		}
		if (!shopItem)
		{
			dungeon.shop.HideSell();
		}
		StateAlert.GetComponentInChildren<Animator>().StopAnim();
		StateAlert.SetActive(value: false);
		StartCoroutine(HIGHWAITER(shopItem));
	}

	private IEnumerator HIGHWAITER(bool shopItem)
	{
		yield return Dungeon.Wait(1);
		UnhighlightAllUpgrades();
		if (shopItem || dungeon.state == Dungeon.State.Shop)
		{
			dungeon.shop.HighlightUpgrades();
		}
	}

	public List<Module> GetWeapons()
	{
		List<Module> list = new List<Module>();
		foreach (Module module in modules)
		{
			if (!(module == null) && module.WEAPON && !list.Contains(module))
			{
				list.Add(module);
			}
		}
		return list;
	}

	public List<Module> GetModules()
	{
		List<Module> list = new List<Module>();
		foreach (Module module in modules)
		{
			if (!(module == null) && module.MODULE && !list.Contains(module))
			{
				list.Add(module);
			}
		}
		return list;
	}

	public void UnhighlightAll()
	{
		foreach (Module item in GetBoard())
		{
			if (item != null)
			{
				if (upg == item)
				{
					upg = null;
				}
				else
				{
					item.Unhighlight();
				}
			}
		}
	}

	public void UnhighlightShopUpgrades()
	{
		foreach (Module module in dungeon.shop.modules)
		{
			module.UnhighlightUpgrade();
		}
	}

	public void UnhighlightAllUpgrades()
	{
		foreach (Module module2 in modules)
		{
			if (module2 != null)
			{
				module2.UnhighlightUpgrade();
			}
		}
		Module[] array = dungeon.bank.modules;
		foreach (Module module in array)
		{
			if (module != null)
			{
				module.UnhighlightUpgrade();
			}
		}
		HideStateUpgrade();
	}

	public void TriggerModules(Trigger.Type type, Module sourceModule = null)
	{
		List<Module> list = new List<Module>();
		List<Module> list2 = new List<Module>(modules);
		list2.AddRange(extraModules);
		dungeon.player.Trigger(type, sourceModule);
		foreach (Module item in list2)
		{
			if (!(item == null) && !list.Contains(item))
			{
				list.Add(item);
				item.Trigger(type, sourceModule);
			}
		}
	}

	public Module CreateExtraModule(Module.Name n, int index = -1)
	{
		Module module = null;
		module = Object.Instantiate(dungeon.moduleObjects[(int)n]).GetComponent<Module>();
		if (module.shopPrice == 0)
		{
			module.shopPrice = Database.GetModData(module).price;
		}
		module.tribes = new List<Module.Tribe>(Database.GetModData(module).tribe);
		module.index = index;
		module.transform.localPosition = new Vector3(-20f, 20f);
		module.transform.localScale = Vector3.zero;
		module.transform.parent = base.transform;
		extraModules.Add(module);
		if (module.WEAPON)
		{
			dungeon.CheckWeapons();
		}
		CheckAuras();
		dungeon.audioManager.PlayModSound(module);
		return module;
	}

	public Module CreateModuleSmall(Module.Name n, int index = -1)
	{
		bool flag = false;
		if (!modules.Contains(null))
		{
			Module[] array = dungeon.bank.modules;
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					flag = true;
				}
			}
			if (!flag)
			{
				return null;
			}
		}
		Module module = null;
		int num = 0;
		using (List<Module>.Enumerator enumerator = modules.GetEnumerator())
		{
			while (enumerator.MoveNext() && !(enumerator.Current == null))
			{
				num++;
			}
		}
		if (index != -1)
		{
			num = index;
		}
		module = Object.Instantiate(dungeon.moduleObjects[(int)n]).GetComponent<Module>();
		if (!Dungeon.Instance.saveData.collection.Contains(module.name))
		{
			Dungeon.Instance.saveData.collection.Add(module.name);
		}
		if (flag)
		{
			dungeon.bank.AutoAdd(module);
			dungeon.audioManager.PlayModSound(module);
		}
		else
		{
			AddModule(module, num, forcedSwap: false, playSound: true);
		}
		dungeon.animationManager.BounceZoom(module.gameObject, 0.115f, 3, modWire: true);
		return module;
	}

	internal void EndPreview()
	{
		if (previewing)
		{
			previewing = false;
			UnhighlightAll();
			previewIndex = -1;
		}
	}

	internal void StartPreview(int i, Module module)
	{
		if (i == previewIndex)
		{
			return;
		}
		UnhighlightAll();
		dungeon.tooltip.Hide(force: true);
		if (CanFit(i, module, showUpg: false) != FitState.True && i != module.index)
		{
			previewIndex = i;
			UnhighlightAll();
			return;
		}
		previewing = true;
		previewIndex = i;
		foreach (Aura aura in module.auras)
		{
			aura.Highlight(i, anim: true);
		}
	}

	public void UpgradeModule(Module m, bool silent = false, bool load = false, bool bank = false)
	{
		if (!(m == null))
		{
			UpgradeModule(m.index, silent, manual: false, load, bank);
		}
	}

	public void UpgradeModule(int i, bool silent = false, bool manual = false, bool loaded = false, bool bank = false)
	{
		Module module = (bank ? dungeon.bank.modules[i] : modules[i]);
		if (!(module == null) && !module.UPGRADED)
		{
			module.UPGRADED = true;
			dungeon.animationManager.BounceZoom(module.gameObject, 0.0625f, 4, modWire: true);
			StartCoroutine(bounce(dungeon.tooltip.gameObject));
			if (!silent)
			{
				dungeon.audioManager.PlaySound(AudioManager.Sound.Upgrade);
			}
			module.InitUpgrade(loaded);
			dungeon.tooltip.Hide(force: true);
			if (!loaded && !(dungeon.state != Dungeon.State.Bank && bank))
			{
				dungeon.tooltip.Set(module);
			}
			CheckAuras();
			UnhighlightAllUpgrades();
			if (dungeon.state == Dungeon.State.Shop)
			{
				dungeon.shop.HighlightUpgrades();
			}
			module.Unhighlight();
			upg = modules[i];
			if (!bank)
			{
				module.HightlightAnim("#FFA214");
			}
			module.ShowUpgradePips();
			if (manual)
			{
				dungeon.tooltip.ResetStats();
			}
		}
	}

	public static IEnumerator bounce(GameObject m, int f = 3)
	{
		for (int i = 0; i < f; i++)
		{
			m.transform.localPosition += new Vector3(0f, 0.0625f);
			yield return Dungeon.Wait(1);
		}
		for (int i = 0; i < f; i++)
		{
			m.transform.localPosition -= new Vector3(0f, 0.0625f);
			yield return Dungeon.Wait(1);
		}
	}

	public void CombatError(Module m)
	{
		if (m.index % 5 == 0)
		{
			errorMove.transform.position = m.transform.position + new Vector3(2.25f, -3f);
		}
		else
		{
			errorMove.transform.position = m.transform.position + new Vector3(0f, -3f);
		}
		if (errorMove_hider != null)
		{
			StopCoroutine(errorMove_hider);
		}
		else
		{
			dungeon.animationManager.LerpZoom(errorMove, Vector3.one, 6f, 0.1f);
		}
		errorMove_hider = StartCoroutine(errorHider());
		if (moveErrorReset)
		{
			StartCoroutine(bounce(errorMove.gameObject));
			dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Error);
			StartCoroutine(errorTimer());
			moveErrorReset = false;
		}
	}

	private IEnumerator errorTimer()
	{
		moveErrorReset = false;
		yield return Dungeon.Wait(60);
		moveErrorReset = true;
	}

	public IEnumerator errorHider()
	{
		yield return Dungeon.Wait(20);
		yield return Dungeon.WaitCancellable(40);
		dungeon.animationManager.LerpZoom(errorMove, Vector3.zero, 4f);
		errorMove_hider = null;
	}

	public void ShowDupeError(Module m)
	{
		if (dupeErrorShown)
		{
			StartCoroutine(bounce(dupeError.gameObject, 2));
			dupeTimer = 90;
		}
		else
		{
			Vector3 pos = ((m.index % 5 != 0) ? (m.transform.position + new Vector3(0f, -3f)) : (m.transform.position + new Vector3(2.25f, -3f)));
			StartCoroutine(DupePopup(pos));
		}
	}

	private IEnumerator DupePopup(Vector3 pos)
	{
		dupeError.transform.localScale = Vector3.zero;
		dupeError.transform.position = pos;
		dungeon.animationManager.LerpZoom(dupeError, Vector3.one, 6f, 0.1f);
		dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Error);
		dupeErrorShown = true;
		dupeTimer = 90;
		while (dupeTimer > 0)
		{
			dupeTimer--;
			yield return Dungeon.WaitUI(1);
		}
		yield return dungeon.animationManager.LerpZoom(dupeError, Vector3.zero, 4f);
		dupeError.transform.position = new Vector3(0f, 15f);
		dupeErrorShown = false;
	}

	public void ShowBankError()
	{
		if (bankErrorShown)
		{
			StartCoroutine(bounce(bankError.gameObject, 2));
			bankTimer = 90;
		}
		else
		{
			Vector3 pos = dungeon.toggleStateButton.transform.position + new Vector3(0f, 1.5f);
			StartCoroutine(bankPopup(pos));
		}
	}

	private IEnumerator bankPopup(Vector3 pos)
	{
		bankError.transform.localScale = Vector3.zero;
		bankError.transform.position = pos;
		dungeon.animationManager.LerpZoom(bankError, Vector3.one, 6f, 0.1f);
		dungeon.audioManager.PlaySound(AudioManager.Sound.UI_Error);
		bankErrorShown = true;
		bankTimer = 90;
		while (bankTimer > 0)
		{
			bankTimer--;
			yield return Dungeon.WaitUI(1);
		}
		yield return dungeon.animationManager.LerpZoom(bankError, Vector3.zero, 4f);
		bankError.transform.position = new Vector3(0f, 15f);
		bankErrorShown = false;
	}

	public void ShowStateUpgrade()
	{
		StateUpgrade.SetActive(value: true);
		StateUpgrade.GetComponentInChildren<Animator>().StopAnim();
		StateUpgrade.GetComponentInChildren<Animator>().StartAnim();
	}

	public void HideStateUpgrade()
	{
		if (StateUpgrade.activeInHierarchy)
		{
			StateUpgrade.GetComponentInChildren<Animator>().StopAnim();
		}
		StateUpgrade.SetActive(value: false);
	}

	public SwapInfo CanSwapFromBank(Module x, Module y, int targetInd)
	{
		SwapInfo result = new SwapInfo(c: false, y.index, x.index, -1);
		if (x.size == y.size && x.size == Module.Size.Small)
		{
			result.canSwap = true;
			result.xTarget = y.index;
			result.yTarget = x.index;
			return result;
		}
		if (x.size == y.size && x.size == Module.Size.Medium)
		{
			result.canSwap = true;
			result.xTarget = ((targetInd % 5 != 4) ? targetInd : (targetInd - 1));
			result.yTarget = x.index;
			return result;
		}
		if (x.size == Module.Size.Small && y.size == Module.Size.Medium)
		{
			if (x.index % 5 != 4 && dungeon.bank.modules[x.index + 1] == null)
			{
				result.canSwap = true;
				result.xTarget = targetInd;
				result.yTarget = x.index;
				return result;
			}
			if (x.index % 5 != 0 && dungeon.bank.modules[x.index - 1] == null)
			{
				result.canSwap = true;
				result.xTarget = targetInd;
				result.yTarget = x.index - 1;
				return result;
			}
		}
		if (x.size == Module.Size.Medium && y.size == Module.Size.Small)
		{
			if (targetInd == y.index - 1)
			{
				result.canSwap = true;
				result.xTarget = y.index - 1;
				result.yTarget = x.index + 1;
				return result;
			}
			if (y.index % 5 != 4 && dungeon.board.modules[y.index + 1] == null)
			{
				result.canSwap = true;
				result.xTarget = y.index;
				result.yTarget = x.index + Mathf.Abs(targetInd - y.index);
				return result;
			}
			if (y.index % 5 != 0 && dungeon.board.modules[y.index - 1] == null)
			{
				result.canSwap = true;
				result.xTarget = y.index - 1;
				result.yTarget = x.index + Mathf.Abs(targetInd - y.index);
				return result;
			}
		}
		return result;
	}

	public void SwapBankToBoard(Module x, Module y, SwapInfo info)
	{
		int xTarget = info.xTarget;
		int yTarget = info.yTarget;
		y.transform.parent = dungeon.bank.transform;
		x.transform.parent = dungeon.board.transform;
		Vector3 localPosition = new Vector3(y.transform.localPosition.x, y.transform.localPosition.y);
		dungeon.bank.RemoveModule(x.index);
		dungeon.board.RemoveModule(y);
		AddModule(x, xTarget);
		y.swapAnim = true;
		dungeon.bank.AddModule(y, yTarget);
		StartCoroutine(dungeon.board.swapAnim(y, y.transform.localPosition));
		y.transform.localPosition = localPosition;
		dungeon.board.CheckAuras();
	}

	public SwapInfo CanSwapTripleFromBank(Module m, Module x, Module y, int targetInd)
	{
		SwapInfo result = new SwapInfo(c: false, m.index, m.index + 2, targetInd);
		if (x.size == y.size && x.size == Module.Size.Small)
		{
			result.canSwap = true;
			result.xTarget = m.index;
			result.yTarget = m.index + 1;
		}
		if (x.size == y.size && x.size == Module.Size.Medium)
		{
			if (m.index % 5 == 0)
			{
				if (dungeon.bank.modules[m.index + 2] == null && dungeon.bank.modules[m.index + 3] == null)
				{
					result.canSwap = true;
					result.xTarget = m.index;
					result.yTarget = m.index + 2;
				}
			}
			else if (m.index % 5 == 3)
			{
				if (dungeon.bank.modules[m.index - 1] == null && dungeon.bank.modules[m.index - 2] == null)
				{
					result.canSwap = true;
					result.yTarget = m.index;
					result.xTarget = m.index - 2;
				}
			}
			else if (dungeon.bank.modules[m.index - 1] == null && dungeon.bank.modules[m.index + 2] == null)
			{
				result.canSwap = true;
				result.xTarget = m.index - 1;
				result.yTarget = m.index + 1;
			}
		}
		if (x.size != y.size)
		{
			if (x.size == Module.Size.Small && y.size == Module.Size.Medium)
			{
				if (m.index % 5 == 3)
				{
					if (dungeon.bank.modules[m.index - 1] == null)
					{
						result.canSwap = true;
						result.xTarget = m.index - 1;
						result.yTarget = m.index;
					}
				}
				else if (dungeon.bank.modules[m.index + 2] == null)
				{
					result.canSwap = true;
					result.xTarget = m.index;
					result.yTarget = m.index + 1;
				}
			}
			if (x.size == Module.Size.Medium && y.size == Module.Size.Small)
			{
				if (m.index % 5 == 0)
				{
					if (dungeon.bank.modules[m.index + 2] == null)
					{
						result.canSwap = true;
						result.xTarget = m.index;
						result.yTarget = m.index + 2;
					}
				}
				else if (dungeon.bank.modules[m.index - 1] == null)
				{
					result.canSwap = true;
					result.xTarget = m.index - 1;
					result.yTarget = m.index + 1;
				}
			}
		}
		return result;
	}

	public void TripleSwapFromBank(Module mid, Module a, Module b, SwapInfo info)
	{
		dungeon.bank.RemoveModule(mid.index);
		RemoveModule(a);
		RemoveModule(b);
		a.transform.parent = dungeon.bank.transform;
		b.transform.parent = dungeon.bank.transform;
		mid.transform.parent = dungeon.board.transform;
		Vector3 localPosition = new Vector3(a.transform.localPosition.x, a.transform.localPosition.y);
		Vector3 localPosition2 = new Vector3(b.transform.localPosition.x, b.transform.localPosition.y);
		_ = mid.index;
		a.swapAnim = true;
		b.swapAnim = true;
		AddModule(mid, info.mTarget);
		dungeon.bank.AddModule(a, info.xTarget);
		dungeon.bank.AddModule(b, info.yTarget);
		StartCoroutine(dungeon.board.swapAnim(a, a.transform.localPosition));
		a.transform.localPosition = localPosition;
		StartCoroutine(dungeon.board.swapAnim(b, b.transform.localPosition));
		b.transform.localPosition = localPosition2;
		dungeon.board.CheckAuras();
	}
}
