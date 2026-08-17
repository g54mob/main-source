using System;
using UnityEngine;
using UnityEngine.UI;

public class CutoutMaskUI : Image
{
	public override Material materialForRendering
	{
		get
		{
			Material source = base.materialForRendering;
			Material material = new Material(source);
			if ((object)material != null)
			{
				int num = Shader.PropertyToID("_StencilComp");
				material.SetFloatImpl(num, 6f);
				return material;
			}
			return (Material)(object)new NullReferenceException();
		}
	}

	public CutoutMaskUI()
	{
		base.m_FillCenter = true;
		base.m_FillMethod = FillMethod.Radial360;
		base.m_FillAmount = 1f;
		base.m_FillClockwise = true;
		base.m_PixelsPerUnitMultiplier = 1f;
		base.m_CachedReferencePixelsPerUnit = 100f;
		((MaskableGraphic)this)._002Ector();
		((Graphic)this)._003CuseLegacyMeshGeneration_003Ek__BackingField = false;
	}
}
