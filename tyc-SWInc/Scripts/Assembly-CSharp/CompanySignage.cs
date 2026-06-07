using UnityEngine;

public class CompanySignage : MonoBehaviour
{
	public float Thickness;

	public float Outline;

	public float ShadowSize;

	public float ShadowHor;

	public float ShadowVert;

	public float ShadowOpacity;

	public bool JustLogo;

	public Furniture Furn;

	private void Start()
	{
		if (JustLogo)
		{
			RefreshLogo();
			return;
		}
		Company company = GameSettings.Instance.MyCompany;
		if (Furn.Map != null)
		{
			company = MarketSimulation.Active.GetPlayerCompany(Furn.Map.Player) ?? GameSettings.Instance.MyCompany;
		}
		if (company != null)
		{
			Furn.Colorable[0].sharedMaterial = GameSettings.Instance.GetCompanyBuildingName(company).Item2;
		}
		Apply();
		Furn.UpdateMaterials();
	}

	public void RefreshLogo()
	{
		MaterialPropertyBlock block = Furn.GetBlock();
		if (Furn.Map != null)
		{
			Company company = MarketSimulation.Active.GetPlayerCompany(Furn.Map.Player) ?? GameSettings.Instance.MyCompany;
			if (company != null)
			{
				block.SetVector("_Offset", LogoController.Instance.GetLogoRect(company, true).ToVector());
			}
		}
		else
		{
			float num = 1f / (float)(LogoController.Instance.LogoTexture.width / LogoController.Instance.GuaranteedPlayerRes);
			block.SetVector("_Offset", new Vector4(0f, 1f - num, num, num));
		}
		Furn.UpdateMaterials();
	}

	public void Apply()
	{
		if (!JustLogo)
		{
			MaterialPropertyBlock block = Furn.GetBlock();
			block.SetVector("_Prop1", new Vector4(Thickness, Outline));
			block.SetVector("_Prop2", new Vector4(ShadowSize, ShadowHor, ShadowVert, ShadowOpacity));
		}
	}

	public void CopyFrom(CompanySignage s)
	{
		if (s != null && !JustLogo)
		{
			Thickness = s.Thickness;
			Outline = s.Outline;
			ShadowSize = s.ShadowSize;
			ShadowHor = s.ShadowHor;
			ShadowVert = s.ShadowVert;
			ShadowOpacity = s.ShadowOpacity;
		}
	}

	public void Serialize(WriteDictionary d)
	{
		if (!JustLogo)
		{
			d["SignThickness"] = Thickness;
			d["SignOutline"] = Outline;
			d["SignShadowSize"] = ShadowSize;
			d["SignShadowHor"] = ShadowHor;
			d["SignShadowVert"] = ShadowVert;
			d["SignShadowOpacity"] = ShadowOpacity;
		}
	}

	public void Deserialize(WriteDictionary d)
	{
		if (!JustLogo)
		{
			Thickness = d.Get("SignThickness", Thickness);
			Outline = d.Get("SignOutline", Outline);
			ShadowSize = d.Get("SignShadowSize", ShadowSize);
			ShadowHor = d.Get("SignShadowHor", ShadowHor);
			ShadowVert = d.Get("SignShadowVert", ShadowVert);
			ShadowOpacity = d.Get("SignShadowOpacity", ShadowOpacity);
		}
	}
}
