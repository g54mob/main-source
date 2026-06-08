using System.Collections.Generic;
using UnityEngine;

public class SightstoneCharacterDialog : DialogNineSlice
{
	public class StatEntry
	{
		public AsciiString titleLabel;

		public AsciiString valueLabel;

		private List<string> statStrings = new List<string>();

		public StatEntry()
		{
			titleLabel = new AsciiString();
			valueLabel = new AsciiString();
			titleLabel.color = ColorConstants.grey;
			valueLabel.color = ColorConstants.white;
			titleLabel.alignment = AsciiString.Alignment.Center;
			valueLabel.alignment = AsciiString.Alignment.Center;
		}

		public void SetTitle(string str)
		{
			titleLabel.SetValue(str);
		}

		public void ClearStats()
		{
			statStrings.Clear();
		}

		public void AddStat(float value)
		{
			string str = $"{value:F1}";
			AddStat(str);
		}

		public void AddStat(int value)
		{
			AddStat(value.ToString());
		}

		public void AddStat(string str)
		{
			statStrings.Add(str);
			if (statStrings.Count == 1)
			{
				valueLabel.SetValue(str);
			}
		}

		public int GetHeight()
		{
			return statStrings.Count + 1;
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			titleLabel.Draw(r, offsetX, offsetY);
			offsetY++;
			if (statStrings.Count == 1)
			{
				valueLabel.Draw(r, offsetX, offsetY);
				return;
			}
			for (int i = 0; i < statStrings.Count; i++)
			{
				valueLabel.SetValue(statStrings[i]);
				valueLabel.Draw(r, offsetX, offsetY + i);
			}
		}
	}

	public class StatRow
	{
		public int distanceBetweenEntries = 14;

		private List<StatEntry> entries = new List<StatEntry>();

		public void Clear()
		{
			entries.Clear();
		}

		public void AddStatEntry(StatEntry entry)
		{
			entries.Add(entry);
		}

		public int GetHeight()
		{
			int num = 0;
			for (int i = 0; i < entries.Count; i++)
			{
				int height = entries[i].GetHeight();
				if (height > num)
				{
					num = height;
				}
			}
			return num;
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			int num = offsetX - (entries.Count - 1) * distanceBetweenEntries / 2;
			for (int i = 0; i < entries.Count; i++)
			{
				entries[i].Draw(r, num, offsetY);
				num += distanceBetweenEntries;
			}
		}
	}

	public class StatBox
	{
		public int distanceBetweenRows = 1;

		public int positionY;

		private List<StatRow> rows = new List<StatRow>();

		public void Clear()
		{
			rows.Clear();
		}

		public void AddStatEntry(StatEntry entry, int rowIndex)
		{
			while (rows.Count - 1 < rowIndex)
			{
				StatRow item = new StatRow();
				rows.Add(item);
			}
			rows[rowIndex].AddStatEntry(entry);
		}

		public int GetHeight()
		{
			int num = 0;
			for (int i = 0; i < rows.Count; i++)
			{
				StatRow statRow = rows[i];
				num += statRow.GetHeight();
				if (i < rows.Count - 1)
				{
					num += distanceBetweenRows;
				}
			}
			return num;
		}

		public void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
		{
			int num = positionY + offsetY;
			for (int i = 0; i < rows.Count; i++)
			{
				StatRow statRow = rows[i];
				statRow.Draw(r, offsetX, num);
				num += statRow.GetHeight() + distanceBetweenRows;
			}
		}
	}

	public AsciiString title;

	public int iconPosX;

	public int iconPosY;

	public Separator separator;

	public AsciiTextBox description;

	public DialogButton closeButton;

	private AsciiSprite icon;

	private int initialHeight;

	private int initialPosY;

	private StatBox statBox = new StatBox();

	private bool trimTop;

	private bool trimIconBase;

	public override void UpdateTic()
	{
		base.UpdateTic();
		if (closeButton != null)
		{
			closeButton.UpdateTic();
		}
	}

	public void Setup(Character character)
	{
		title.SetValue(Te.xt(character.displayName));
		icon = null;
		if (!string.IsNullOrEmpty(character.iconPath))
		{
			icon = IconLoader.Singleton.GetSharedIcon(character.iconPath);
		}
		if (icon == null)
		{
			icon = character.MySprite;
		}
		int num = ((!(icon == null)) ? icon.height : 0) + 5;
		statBox.Clear();
		statBox.positionY = num;
		Enemy enemy = character as Enemy;
		if (enemy != null)
		{
			StatEntry statEntry = new StatEntry();
			statEntry.SetTitle(Te.xt("Hitpoints"));
			statEntry.AddStat(character.MaxHitpoints);
			statBox.AddStatEntry(statEntry, 0);
			StatEntry statEntry2 = new StatEntry();
			statEntry2.SetTitle(Te.xt("Damage"));
			statEntry2.AddStat((!(enemy.weapon == null)) ? ItemDetailsDialog.ComputeDamageDisplay(enemy.weapon) : 0);
			statBox.AddStatEntry(statEntry2, 0);
			if (enemy.MaxArmor > 0f)
			{
				StatEntry statEntry3 = new StatEntry();
				statEntry3.SetTitle(Te.xt("Armor"));
				statEntry3.AddStat(enemy.MaxArmor);
				statBox.AddStatEntry(statEntry3, 0);
			}
		}
		ItemData.Element element = character.GetElement();
		if (element != ItemData.Element.Stone)
		{
			StatEntry statEntry4 = new StatEntry();
			statEntry4.SetTitle(Te.xt("Element"));
			statEntry4.AddStat(Te.xt(ItemData.NameForElement(element)));
			statBox.AddStatEntry(statEntry4, 1);
			List<string> list = new List<string>();
			string item = ItemData.CounteredBy(element).ToString();
			list.Add(item);
			MultiplyDamageFromMagic[] components = character.GetComponents<MultiplyDamageFromMagic>();
			foreach (MultiplyDamageFromMagic multiplyDamageFromMagic in components)
			{
				if (!(multiplyDamageFromMagic.multiplier <= 1f))
				{
					list.Add(multiplyDamageFromMagic.singleTag);
					int num2 = 0;
					while (multiplyDamageFromMagic.multiTags != null && num2 < multiplyDamageFromMagic.multiTags.Length)
					{
						list.Add(multiplyDamageFromMagic.multiTags[num2]);
						num2++;
					}
				}
			}
			if (list.Count > 0)
			{
				StatEntry statEntry5 = new StatEntry();
				statEntry5.SetTitle(Te.xt("Weakness"));
				for (int j = 0; j < list.Count; j++)
				{
					string text = list[j];
					if (!string.IsNullOrEmpty(text) && !character.immuneTo.Contains(text))
					{
						statEntry5.AddStat(Te.xt("tid_immune_to_" + text));
					}
				}
				statBox.AddStatEntry(statEntry5, 1);
			}
		}
		StatEntry statEntry6 = null;
		for (int k = 0; k < character.immuneTo.Count; k++)
		{
			string text2 = character.immuneTo[k];
			if (!(text2 == "stun"))
			{
				if (statEntry6 == null)
				{
					statEntry6 = new StatEntry();
					statEntry6.SetTitle(Te.xt("Immune to"));
				}
				statEntry6.AddStat(Te.xt("tid_immune_to_" + text2));
			}
		}
		if (statEntry6 != null)
		{
			statBox.AddStatEntry(statEntry6, 1);
		}
		if (statBox.GetHeight() > 0)
		{
			num += statBox.GetHeight() + 1;
		}
		description.Text = Te.xt(character.flavorText);
		Height = num + description.lineCount + 4;
		if (description.lineCount == 0)
		{
			Height -= 3;
		}
		else
		{
			separator.PositionY = num;
			description.positionY = num + 2;
		}
		if (Height > 24)
		{
			Height -= 2;
			description.positionY--;
		}
		if (Height > 24)
		{
			Height--;
			description.positionY--;
			separator.PositionY--;
		}
		trimTop = false;
		if (Height > 24)
		{
			Height -= 2;
			trimTop = true;
		}
		trimIconBase = false;
		if (Height > 24)
		{
			Height--;
			trimIconBase = true;
		}
		PositionY = initialPosY - (Height - initialHeight) / 2;
		if (Height % 2 == 1 && GameStates.Singleton.asciiRenderer.height % 2 == 1)
		{
			PositionY++;
		}
	}

	public void Show()
	{
		base.SetState(State.In);
	}

	public void Hide()
	{
		base.SetState(State.Out);
	}

	private void HandleOnClickedOutside()
	{
		Hide();
	}

	private void Update()
	{
		if (base.CurrentState == State.Idle && Input.GetKeyDown(KeyCode.Escape))
		{
			Hide();
		}
	}

	public override void Draw(AsciiRenderProcedural r, int offsetX, int offsetY)
	{
		base.Draw(r, offsetX, offsetY);
		offsetX += PositionX + (Width >> 1);
		offsetY += PositionY;
		if (base.CurrentState == State.Idle)
		{
			if (closeButton != null)
			{
				closeButton.Draw(r, offsetX, offsetY);
			}
			if (trimTop)
			{
				offsetY--;
			}
			title.Draw(r, offsetX, offsetY);
			if (trimTop)
			{
				offsetY--;
			}
			if (icon != null)
			{
				int offsetX2 = offsetX + iconPosX + icon.pivotX - icon.width / 2;
				int offsetY2 = offsetY + iconPosY + icon.pivotY;
				icon.Draw(r, offsetX2, offsetY2);
			}
			if (trimIconBase)
			{
				offsetY--;
			}
			statBox.Draw(r, offsetX, offsetY);
			if (description.lineCount > 0)
			{
				separator.Draw(r, offsetX, offsetY);
				description.Draw(r, offsetX, offsetY);
			}
		}
	}

	private void HandleCloseButtonPressed(DialogButton button)
	{
		Hide();
	}

	protected override void Start()
	{
		base.Start();
		initialHeight = Height;
		initialPosY = PositionY;
		base.OnClickedOutside += HandleOnClickedOutside;
		if (closeButton != null)
		{
			closeButton.OnPressed += HandleCloseButtonPressed;
		}
	}

	private void OnDestroy()
	{
		base.OnClickedOutside -= HandleOnClickedOutside;
		if (closeButton != null)
		{
			closeButton.OnPressed -= HandleCloseButtonPressed;
		}
	}
}
