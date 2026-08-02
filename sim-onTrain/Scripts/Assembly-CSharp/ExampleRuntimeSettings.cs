using System.Collections.Generic;
using CritiasFoliage;
using UnityEngine;

public class ExampleRuntimeSettings : MonoBehaviour
{
	public FoliagePainter m_Painter;

	private List<FoliageTypeRuntime> m_CachedTypes;

	private FoliagePainterRuntime m_CachedRuntime;

	private void Awake()
	{
		if (m_Painter == null)
		{
			m_Painter = Object.FindObjectOfType<FoliagePainter>();
		}
	}

	private void OnGUI()
	{
		if (m_Painter == null)
		{
			Debug.LogError("Null painter, please set!");
			return;
		}
		if (m_CachedTypes == null)
		{
			m_CachedRuntime = m_Painter.GetRuntime;
			m_CachedTypes = m_CachedRuntime.GetFoliageTypes();
		}
		int num = -1;
		for (int i = 0; i < m_CachedTypes.Count; i++)
		{
			FoliageTypeRuntime foliageTypeRuntime = m_CachedTypes[i];
			float num2 = 80 * (i % 8);
			if (i % 8 == 0)
			{
				num++;
			}
			GUI.Label(new Rect(20 + num * 220, num2, 200f, 20f), "Name: " + foliageTypeRuntime.m_Name);
			float foliageTypeMaxDistance = m_CachedRuntime.GetFoliageTypeMaxDistance(foliageTypeRuntime.m_Hash);
			float num3 = GUI.HorizontalSlider(new Rect(20 + num * 220, num2 + 20f, 100f, 20f), foliageTypeMaxDistance, 0f, foliageTypeRuntime.m_IsGrassType ? 500f : 1000f);
			bool foliageTypeCastShadow = m_CachedRuntime.GetFoliageTypeCastShadow(foliageTypeRuntime.m_Hash);
			bool flag = GUI.Toggle(new Rect(20 + num * 220, num2 + 40f, 100f, 20f), foliageTypeCastShadow, "Shadow");
			if (Mathf.Abs(num3 - foliageTypeMaxDistance) > Mathf.Epsilon)
			{
				m_CachedRuntime.SetFoliageTypeMaxDistance(foliageTypeRuntime.m_Hash, num3);
			}
			if (flag != foliageTypeCastShadow)
			{
				m_CachedRuntime.SetFoliageTypeCastShadow(foliageTypeRuntime.m_Hash, flag);
			}
		}
	}
}
