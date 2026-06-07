using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblerDetailTile : MonoBehaviour
{
	public Text ProductLabel;

	public Transform ComponentPanel;

	public GameObject Checkmark;

	public GameObject PushOutButton;

	public List<RawImage> Components = new List<RawImage>();

	[NonSerialized]
	private ManufactureOrder _order;

	[NonSerialized]
	private ProductPrinter _printer;

	private int _doneMask;

	public bool CheckFinished()
	{
		if ((_order.Mask & _doneMask) == _doneMask)
		{
			for (int i = 0; i < Components.Count; i++)
			{
				RawImage rawImage = Components[i];
				if (!rawImage.gameObject.activeSelf)
				{
					break;
				}
				rawImage.color = Color.white;
			}
			Checkmark.SetActive(true);
			PushOutButton.SetActive(false);
			return true;
		}
		return false;
	}

	public void PushOut()
	{
		if (_printer != null)
		{
			lock (_printer.PushOut)
			{
				_printer.PushOut.Add(_order);
			}
		}
		base.gameObject.SetActive(false);
	}

	public void Set(ManufactureOrder order, ProductPrinter printer)
	{
		_order = order;
		_printer = printer;
		Checkmark.SetActive(false);
		PushOutButton.SetActive(true);
		ProductLabel.text = order.Target.GetIdentifyingName();
		int num = (_doneMask = order.CurrentProcess.InputMask & order.Target.HardwareInputMask);
		int num2 = 0;
		int num3 = 0;
		while (num > 0)
		{
			int num4 = 1 << num2;
			if ((num & num4) > 0)
			{
				SetComponent(num3, order.CurrentProcess.Parent.Components[num2]).color = (((num4 & order.Mask) > 0) ? Color.white : new Color(1f, 0f, 0f, 0.5f));
				num3++;
			}
			num2++;
			num &= ~num4;
		}
		for (int i = num3; i < Components.Count; i++)
		{
			Components[i].gameObject.SetActive(false);
		}
	}

	private RawImage SetComponent(int idx, HardwareComponent p)
	{
		RawImage rawImage;
		if (idx < Components.Count)
		{
			rawImage = Components[idx];
		}
		else
		{
			rawImage = UnityEngine.Object.Instantiate(Components[0]);
			rawImage.transform.SetParent(ComponentPanel, false);
			Components.Add(rawImage);
		}
		rawImage.gameObject.SetActive(true);
		int manAtlasWidth = MarketSimulation.Active.ManAtlasWidth;
		float num = 1f / (float)manAtlasWidth;
		float num2 = 1f / (float)MarketSimulation.Active.ManAtlasHeight;
		rawImage.texture = MarketSimulation.Active.ManufacturingIcons;
		int atlasIndex = p.AtlasIndex;
		rawImage.uvRect = new Rect((float)(atlasIndex % manAtlasWidth) * num, (float)(atlasIndex / manAtlasWidth) * num2, num, num2);
		rawImage.GetComponent<GUIToolTipper>().ToolTipValue = p.GetBaseName();
		return rawImage;
	}
}
