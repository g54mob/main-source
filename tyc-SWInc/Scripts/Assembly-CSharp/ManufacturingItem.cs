using System;
using UnityEngine;
using UnityEngine.UI;

public class ManufacturingItem : MonoBehaviour
{
	public RectTransform RTransform;

	public Text Label;

	public Text Amount;

	public Text TimeLabel;

	public Text CostLabel;

	public RawImage Img;

	public Image TimeSprite;

	public Gradient AmountGradient;

	[NonSerialized]
	public ManufacturingPanel.PseudoProcess Process;

	[NonSerialized]
	public IManufacturable Category;

	public Button Clicker;

	public Image TopCircle;

	public Image TopLine;

	public Color AssemblerColor;

	public Color PrinterColor;

	public void Init(ManufacturingPanel.PseudoProcess p, IManufacturable c, float maxTime, bool interactable)
	{
		base.name = c.ToString() + " " + (p.Final ? "Final" : p.Component.Name);
		Process = p;
		Category = c;
		Label.text = (p.Final ? "FinalAssembly".Loc() : p.Component.GetBaseName());
		Img.texture = MarketSimulation.Active.ManufacturingIcons;
		int num = (p.Final ? c.GetManufacturing().FinalTime : p.Component.Time);
		TimeSprite.fillAmount = Mathf.Clamp01((float)num / maxTime);
		num *= GameSettings.DaysPerMonth;
		int num2 = num / 60;
		num %= 60;
		TimeLabel.text = ((num2 > 0) ? ("Hour".LocPlural(num2) + "AndSeperator".Loc() + "Minute".LocPlural(num)) : "Minute".LocPlural(num));
		int manAtlasWidth = MarketSimulation.Active.ManAtlasWidth;
		float num3 = 1f / (float)manAtlasWidth;
		float num4 = 1f / (float)MarketSimulation.Active.ManAtlasHeight;
		int num5 = (p.Final ? MarketSimulation.Active.GetManufacturingIndex("Final") : p.Component.AtlasIndex);
		Img.uvRect = new Rect((float)(num5 % manAtlasWidth) * num3, (float)(num5 / manAtlasWidth) * num4, num3, num4);
		if (!Process.Final && (Process.Inputs.Count == 0 || (interactable && Process.Inputs.All((ManufacturingPanel.PseudoProcess x) => x.Optional))))
		{
			CostLabel.text = "Cost".Loc() + ": " + Process.Component.Price.Currency();
			if (!interactable)
			{
				Image topCircle = TopCircle;
				Color color = (TopLine.color = PrinterColor);
				topCircle.color = color;
			}
		}
		else
		{
			CostLabel.gameObject.SetActive(false);
			if (!interactable)
			{
				Image topCircle2 = TopCircle;
				Color color = (TopLine.color = AssemblerColor);
				topCircle2.color = color;
			}
		}
	}

	public void InitializeAction(Action<object> onClick, bool assembly)
	{
		if (assembly && Process.Inputs.Count == 0)
		{
			Clicker.interactable = false;
			return;
		}
		if (!assembly && (Process.Final || Process.Inputs.Any((ManufacturingPanel.PseudoProcess x) => !x.Optional)))
		{
			Clicker.interactable = false;
			return;
		}
		object obj = (Process.Final ? ((object)Category) : ((object)Process.Component));
		Clicker.onClick.AddListener(delegate
		{
			onClick(obj);
		});
	}

	public void RefreshCounts(int mult)
	{
		bool flag = Process.Inputs.Count > 0;
		string text = (flag ? "Assemblers" : "Printers").Loc().FontColor(((flag ? AssemblerColor : PrinterColor) * 0.5f).Alpha(1f)).FontBold();
		Amount.text = text + ": " + (Process.Has + "/" + Process.Optimal * mult).FontColor(AmountGradient.Evaluate(Process.GetOptimalValue(mult)));
	}
}
