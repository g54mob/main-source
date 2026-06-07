using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bank : MonoBehaviour
{
	public List<SpriteRenderer> previews = new List<SpriteRenderer>();

	public Module[] modules = new Module[5];

	private Dungeon dungeon => Dungeon.Instance;

	public List<Module> GetBank()
	{
		List<Module> list = new List<Module>();
		Module[] array = modules;
		foreach (Module module in array)
		{
			if (module != null && !list.Contains(module))
			{
				list.Add(module);
			}
		}
		return list;
	}

	public void ShowPreviews()
	{
		foreach (SpriteRenderer preview in previews)
		{
			preview.enabled = true;
		}
	}

	public void HidePreviews()
	{
		foreach (SpriteRenderer preview in previews)
		{
			preview.enabled = false;
		}
	}

	public Vector3 GetModulePos(Module m, int x)
	{
		float num = ((m.size == Module.Size.Medium) ? (-3.375f) : (-4.5f));
		return new Vector3(num + (float)(x % 5) * 2.25f, -7f / 32f, -1f - (float)(x / 5) * 4.125f);
	}

	public bool CanFitAuto(Module m)
	{
		int num = 0;
		Module[] array = modules;
		for (int i = 0; i < array.Length; i++)
		{
			if (array[i] == null)
			{
				num++;
			}
		}
		if (m.size == Module.Size.Small && num >= 1)
		{
			return true;
		}
		if (m.size == Module.Size.Medium && num >= 2)
		{
			return true;
		}
		dungeon.board.ShowBankError();
		return false;
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

	public Board.FitState CanFit(Module mod, int x)
	{
		if (modules[x] != null && !mod.UPGRADED && modules[x] != mod && modules[x].name == mod.name && !modules[x].UPGRADED)
		{
			if (mod.WIREMOD)
			{
				dungeon.tooltip.Set(modules[x], showUpgrade: true, noUpgrade: true);
				return Board.FitState.False;
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
			return Board.FitState.Upgrade;
		}
		switch (mod.size)
		{
		default:
			if (!(modules[x] == null))
			{
				return Board.FitState.False;
			}
			return Board.FitState.True;
		case Module.Size.Medium:
			if ((x + 1) % 5 == 0)
			{
				return Board.FitState.False;
			}
			if ((!(modules[x] == null) && !(modules[x] == mod)) || (!(modules[x + 1] == null) && !(modules[x + 1] == mod)))
			{
				return Board.FitState.False;
			}
			return Board.FitState.True;
		case Module.Size.Large:
			if ((x + 2) % 5 == 0)
			{
				return Board.FitState.False;
			}
			if ((x + 1) % 5 == 0)
			{
				return Board.FitState.False;
			}
			if ((!(modules[x] == null) && !(modules[x] == mod)) || (!(modules[x + 1] == null) && !(modules[x + 1] == mod)) || (!(modules[x + 2] == null) && !(modules[x + 2] == mod)))
			{
				return Board.FitState.False;
			}
			return Board.FitState.True;
		}
	}

	public void RemoveModule(int x)
	{
		if (x > modules.Length - 1)
		{
			Debug.LogWarning("Out of Index");
			return;
		}
		if (modules[x] == null)
		{
			Debug.LogWarning("Bank mod not found");
			return;
		}
		Module module = null;
		if (modules[x] != null)
		{
			module = modules[x];
			modules[x] = null;
		}
		if (module.size == Module.Size.Medium)
		{
			modules[x + 1] = null;
		}
		dungeon.board.CheckAuras();
	}

	public void AddModule(Module m, int x, bool forcedSwap = false)
	{
		bool flag = false;
		if (CanFit(m, x) == Board.FitState.False && !forcedSwap)
		{
			if (modules[x] != null)
			{
				Debug.LogError($"MOD SLOT FULL ({modules[x].name}). CANNOT PLACE {m.name}");
			}
			return;
		}
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
		m.index = x;
		m.bankItem = true;
		m.transform.parent = base.transform;
		m.transform.localScale = Vector3.one;
		m.transform.localPosition = GetModulePos(m, x);
		if (flag)
		{
			m.InitOnBoard();
		}
		m.transform.localEulerAngles = new Vector3(0f, 0f, 0f);
		m.transform.localScale = Vector3.one;
		dungeon.board.UnhighlightAll();
		if (dungeon.state != Dungeon.State.Shop)
		{
			dungeon.board.UnhighlightAllUpgrades();
		}
		if (dungeon.state == Dungeon.State.Shop)
		{
			dungeon.shop.HighlightUpgrades();
		}
		dungeon.board.CheckAuras();
	}

	public void AutoAdd(Module m)
	{
		if (m.size == Module.Size.Small)
		{
			for (int i = 0; i < modules.Length; i++)
			{
				if (modules[i] == null)
				{
					dungeon.audioManager.PlaySound(AudioManager.Sound.Shop);
					AddModule(m, i);
					return;
				}
			}
			Debug.LogError("CANT FIT IN BANK " + m.name);
		}
		else
		{
			if (m.size != Module.Size.Medium)
			{
				return;
			}
			for (int j = 0; j < modules.Length - 1; j++)
			{
				if (modules[j] == null && modules[j + 1] == null)
				{
					dungeon.audioManager.PlaySound(AudioManager.Sound.Shop);
					AddModule(m, j);
					return;
				}
			}
			List<Module> bank = GetBank();
			int num = 0;
			foreach (Module item in bank)
			{
				AddModule(item, num, forcedSwap: true);
				num += ((item.size == Module.Size.Small) ? 1 : 2);
			}
			dungeon.audioManager.PlaySound(AudioManager.Sound.Shop);
			AddModule(m, num);
		}
	}

	public Board.SwapInfo CanSwap(Module x, Module y, int targetInd)
	{
		List<Module> list = ((!y.bankItem) ? dungeon.board.modules : new List<Module>(modules));
		Board.SwapInfo result = new Board.SwapInfo(c: false, -1, -1, -1);
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
				if (targetInd == y.index + 1 && (y.index + 1) % 5 != 0 && (y.index + 1) % 5 != 4 && list[y.index + 2] == null)
				{
					result.canSwap = true;
					result.xTarget = targetInd;
					return result;
				}
				if (targetInd == y.index - 1 && y.index % 5 != 0 && list[y.index - 1] == null)
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
			if (list[module.index - 1] == null)
			{
				result.canSwap = true;
				num = ((targetInd == num + 1) ? (num + 1) : num);
				num2 = module.index - 1;
			}
		}
		else if (module.index % 5 == 0)
		{
			if (list[module.index + 1] == null)
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
			if (list[module.index + 1] == null)
			{
				flag = true;
			}
			if (list[module.index - 1] == null)
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
					if (list[module.index - 1] == null)
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
				else if (list[module.index + 1] == null)
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
				if (list[i] == null)
				{
					flag3 = false;
				}
			}
		}
		if (flag3)
		{
			int num3 = module.index / 5 * 5;
			if (list[num3].size == Module.Size.Medium && list[num3 + 2].size == Module.Size.Medium && list[num3 + 4].size == Module.Size.Small && x == module && (targetInd == num3 || targetInd == num3 + 1))
			{
				result.canSwap = true;
				Vector3 localPosition = list[num3 + 2].transform.localPosition;
				AddModule(list[num3 + 2], num3 + 3, forcedSwap: true);
				StartCoroutine(dungeon.board.swapAnim(list[num3 + 3], list[num3 + 3].transform.localPosition));
				list[num3 + 3].transform.localPosition = localPosition;
				num = module2.index;
				num2 = module2.index + 1;
			}
			if (list[num3].size == Module.Size.Small && list[num3 + 1].size == Module.Size.Medium && list[num3 + 3].size == Module.Size.Medium && x == module && (targetInd == num3 + 3 || targetInd == num3 + 4))
			{
				result.canSwap = true;
				Vector3 localPosition2 = list[num3 + 1].transform.localPosition;
				Module module3 = list[num3 + 1];
				AddModule(list[num3 + 1], num3, forcedSwap: true);
				StartCoroutine(dungeon.board.swapAnim(module3, module3.transform.localPosition));
				module3.transform.localPosition = localPosition2;
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

	public void SwapMods(Module x, Module y, Board.SwapInfo info)
	{
		int xTarget = info.xTarget;
		int yTarget = info.yTarget;
		Vector3 localPosition = new Vector3(y.transform.localPosition.x, y.transform.localPosition.y);
		AddModule(x, xTarget, forcedSwap: true);
		y.swapAnim = true;
		AddModule(y, yTarget, forcedSwap: true);
		StartCoroutine(dungeon.board.swapAnim(y, y.transform.localPosition));
		y.transform.localPosition = localPosition;
		dungeon.board.CheckAuras();
	}

	public Board.SwapInfo CanSwapTriple(Module m, Module x, Module y, int targetInd)
	{
		Board.SwapInfo result = new Board.SwapInfo(c: false, m.index, m.index + 2, targetInd);
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

	public void TripleSwap(Module mid, Module a, Module b, Board.SwapInfo info)
	{
		Vector3 localPosition = new Vector3(a.transform.localPosition.x, a.transform.localPosition.y);
		Vector3 localPosition2 = new Vector3(b.transform.localPosition.x, b.transform.localPosition.y);
		_ = mid.index;
		a.swapAnim = true;
		b.swapAnim = true;
		AddModule(mid, info.mTarget, forcedSwap: true);
		AddModule(a, info.xTarget, forcedSwap: true);
		AddModule(b, info.yTarget, forcedSwap: true);
		StartCoroutine(dungeon.board.swapAnim(a, a.transform.localPosition));
		a.transform.localPosition = localPosition;
		StartCoroutine(dungeon.board.swapAnim(b, b.transform.localPosition));
		b.transform.localPosition = localPosition2;
		dungeon.board.CheckAuras();
	}

	public Board.SwapInfo CanSwapFromBoard(Module x, Module y, int targetInd)
	{
		Board.SwapInfo result = new Board.SwapInfo(c: false, y.index, x.index, -1);
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
			if (x.index % 5 != 4 && dungeon.board.modules[x.index + 1] == null)
			{
				result.canSwap = true;
				result.xTarget = targetInd;
				result.yTarget = x.index;
				return result;
			}
			if (x.index % 5 != 0 && dungeon.board.modules[x.index - 1] == null)
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
			if (y.index % 5 != 4 && dungeon.bank.modules[y.index + 1] == null)
			{
				result.canSwap = true;
				result.xTarget = y.index;
				result.yTarget = x.index + Mathf.Abs(targetInd - y.index);
				return result;
			}
			if (y.index % 5 != 0 && dungeon.bank.modules[y.index - 1] == null)
			{
				result.canSwap = true;
				result.xTarget = y.index - 1;
				result.yTarget = x.index + Mathf.Abs(targetInd - y.index);
				return result;
			}
		}
		return result;
	}

	public void SwapBoardToBank(Module x, Module y, Board.SwapInfo info)
	{
		int xTarget = info.xTarget;
		int yTarget = info.yTarget;
		y.transform.parent = dungeon.board.transform;
		x.transform.parent = dungeon.bank.transform;
		Vector3 localPosition = new Vector3(y.transform.localPosition.x, y.transform.localPosition.y);
		dungeon.board.RemoveModule(x);
		dungeon.bank.RemoveModule(y.index);
		AddModule(x, xTarget);
		y.swapAnim = true;
		dungeon.board.AddModule(y, yTarget);
		StartCoroutine(dungeon.board.swapAnim(y, y.transform.localPosition));
		y.transform.localPosition = localPosition;
		dungeon.board.CheckAuras();
	}

	public Board.SwapInfo CanSwapTripleFromBoard(Module m, Module x, Module y, int targetInd)
	{
		Board.SwapInfo result = new Board.SwapInfo(c: false, m.index, m.index + 2, targetInd);
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
				if (dungeon.board.modules[m.index + 2] == null && dungeon.board.modules[m.index + 3] == null)
				{
					result.canSwap = true;
					result.xTarget = m.index;
					result.yTarget = m.index + 2;
				}
			}
			else if (m.index % 5 == 3)
			{
				if (dungeon.board.modules[m.index - 1] == null && dungeon.board.modules[m.index - 2] == null)
				{
					result.canSwap = true;
					result.yTarget = m.index;
					result.xTarget = m.index - 2;
				}
			}
			else if (dungeon.board.modules[m.index - 1] == null && dungeon.board.modules[m.index + 2] == null)
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
					if (dungeon.board.modules[m.index - 1] == null)
					{
						result.canSwap = true;
						result.xTarget = m.index - 1;
						result.yTarget = m.index;
					}
				}
				else if (dungeon.board.modules[m.index + 2] == null)
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
					if (dungeon.board.modules[m.index + 2] == null)
					{
						result.canSwap = true;
						result.xTarget = m.index;
						result.yTarget = m.index + 2;
					}
				}
				else if (dungeon.board.modules[m.index - 1] == null)
				{
					result.canSwap = true;
					result.xTarget = m.index - 1;
					result.yTarget = m.index + 1;
				}
			}
		}
		return result;
	}

	public void TripleSwapFromBoard(Module mid, Module a, Module b, Board.SwapInfo info)
	{
		dungeon.board.RemoveModule(mid);
		RemoveModule(a.index);
		RemoveModule(b.index);
		a.transform.parent = dungeon.board.transform;
		b.transform.parent = dungeon.board.transform;
		mid.transform.parent = dungeon.bank.transform;
		Vector3 localPosition = new Vector3(a.transform.localPosition.x, a.transform.localPosition.y);
		Vector3 localPosition2 = new Vector3(b.transform.localPosition.x, b.transform.localPosition.y);
		_ = mid.index;
		a.swapAnim = true;
		b.swapAnim = true;
		AddModule(mid, info.mTarget);
		dungeon.board.AddModule(a, info.xTarget);
		dungeon.board.AddModule(b, info.yTarget);
		StartCoroutine(dungeon.board.swapAnim(a, a.transform.localPosition));
		a.transform.localPosition = localPosition;
		StartCoroutine(dungeon.board.swapAnim(b, b.transform.localPosition));
		b.transform.localPosition = localPosition2;
		dungeon.board.CheckAuras();
	}
}
