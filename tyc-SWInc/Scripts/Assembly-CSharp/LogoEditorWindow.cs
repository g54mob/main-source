using System;
using System.Collections.Generic;
using SINetworking;
using UnityEngine;
using UnityEngine.UI;

public class LogoEditorWindow : MonoBehaviour
{
	public GUIWindow Window;

	public Slider Thickness;

	public Slider Outline;

	public Slider ShSize;

	public Slider ShHor;

	public Slider ShVert;

	public Slider shOp;

	[NonSerialized]
	private List<CompanySignage> _active;

	[NonSerialized]
	private bool _initializing;

	private void Start()
	{
		Window.OnClose = delegate
		{
			if (NetworkManager.IsConnected)
			{
				_active.ForEachEnum(delegate(CompanySignage x)
				{
					if (x.Furn.IsAliveNotNull() && x.Furn.NetworkID != 0)
					{
						NetworkMessaging.SendUpdateCompanyBuildingSign(x.Furn.NetworkID, x.Thickness, x.Outline, x.ShadowSize, x.ShadowHor, x.ShadowVert, x.ShadowOpacity, NetworkMessaging.MessageTarget.EveryoneButMe, 0);
					}
				});
			}
		};
	}

	public void Show(List<CompanySignage> f)
	{
		_initializing = true;
		_active = f;
		Thickness.value = _active[0].Thickness;
		Outline.value = _active[0].Outline;
		ShSize.value = _active[0].ShadowSize;
		ShHor.value = _active[0].ShadowHor;
		ShVert.value = _active[0].ShadowVert;
		shOp.value = _active[0].ShadowOpacity;
		_initializing = false;
		Window.Show();
	}

	public void SliderChanged()
	{
		if (!_initializing)
		{
			for (int i = 0; i < _active.Count; i++)
			{
				CompanySignage companySignage = _active[i];
				companySignage.Thickness = Thickness.value;
				companySignage.Outline = Outline.value;
				companySignage.ShadowSize = ShSize.value;
				companySignage.ShadowHor = ShHor.value;
				companySignage.ShadowVert = ShVert.value;
				companySignage.ShadowOpacity = shOp.value;
				companySignage.Apply();
				companySignage.Furn.UpdateMaterials();
			}
		}
	}
}
