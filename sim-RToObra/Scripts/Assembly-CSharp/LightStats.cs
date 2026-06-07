using System.Collections.Generic;
using UnityEngine;

public class LightStats : MonoBehaviour
{
	public class LightcasterDynamic
	{
		public int dynamicLayerIndex;

		public Vector3 center;

		public List<Vector3> positions = new List<Vector3>();
	}

	public Vis vis;

	public List<Light> standardLights = new List<Light>();

	public List<LightcasterDynamic> lightcasterDynamics = new List<LightcasterDynamic>();

	private void Start()
	{
		DebugMenu.Add("Show/Vis Stats", KeyCode.L);
	}

	private static void DrawPlus(DebugDrawer dd, Color color, Vector3 pos, float size)
	{
		Matrix4x4 matrix4x = Matrix4x4.TRS(pos, Quaternion.identity, size * Vector3.one);
		dd.DrawLine(color, matrix4x.MultiplyPoint(-Vector3.forward), matrix4x.MultiplyPoint(Vector3.forward));
		dd.DrawLine(color, matrix4x.MultiplyPoint(-Vector3.up), matrix4x.MultiplyPoint(Vector3.up));
		dd.DrawLine(color, matrix4x.MultiplyPoint(-Vector3.right), matrix4x.MultiplyPoint(Vector3.right));
	}

	private void Update()
	{
		if (DebugMenu.IsOn("Show/Vis Stats"))
		{
			if (vis == null)
			{
				Init();
			}
			Draw();
		}
	}

	private void Draw()
	{
		int realTotal = standardLights.Count;
		int realActive = 0;
		foreach (Light standardLight in standardLights)
		{
			if (standardLight.isActiveAndEnabled)
			{
				realActive++;
			}
		}
		int bakedTotal = lightcasterDynamics.Count;
		int bakedActive = 0;
		foreach (LightcasterDynamic lightcasterDynamic in lightcasterDynamics)
		{
			if (Lightcaster.instance.GetDynamicLayerAlpha(lightcasterDynamic.dynamicLayerIndex) > 0.001f)
			{
				bakedActive++;
			}
		}
		int bothTotal = realTotal + bakedTotal;
		int bothActive = realActive + bakedActive;
		Color activeColor = new Color(1f, 0.5f, 0.1f);
		Color inactiveColor = new Color(0.7f, 0.8f, 1f);
		DebugDrawer.World(delegate(DebugDrawer dd)
		{
			foreach (Light standardLight2 in standardLights)
			{
				Matrix4x4 m = Matrix4x4.TRS(standardLight2.transform.position, Quaternion.identity, 0.25f * Vector3.one);
				Color color = ((!standardLight2.isActiveAndEnabled) ? inactiveColor : activeColor);
				dd.DrawSphere(color, m);
			}
			Lightcaster instance = Lightcaster.instance;
			foreach (LightcasterDynamic lightcasterDynamic2 in lightcasterDynamics)
			{
				Color color2 = ((!(instance.GetDynamicLayerAlpha(lightcasterDynamic2.dynamicLayerIndex) > 0.001f)) ? inactiveColor : activeColor);
				foreach (Vector3 position in lightcasterDynamic2.positions)
				{
					dd.DrawLine(new Color(color2.r, color2.g, color2.b, 0.5f), position, lightcasterDynamic2.center);
					Matrix4x4 matrix4x = Matrix4x4.TRS(position, Quaternion.identity, 0.4f * Vector3.one);
					dd.DrawLine(color2, matrix4x.MultiplyPoint(-Vector3.forward), matrix4x.MultiplyPoint(Vector3.forward));
					dd.DrawLine(color2, matrix4x.MultiplyPoint(-Vector3.up), matrix4x.MultiplyPoint(Vector3.up));
					dd.DrawLine(color2, matrix4x.MultiplyPoint(-Vector3.right), matrix4x.MultiplyPoint(Vector3.right));
				}
			}
		});
		vis.DrawDebug();
		DebugDrawer.Screen(delegate(DebugDrawer dd)
		{
			int num = 8;
			int num2 = num + 4;
			int num3 = 10;
			int num4 = 360 - num2;
			Color color = new Color(0.8f, 0.6f, 0.8f, 1f);
			Color color2 = new Color(0.2f, 0.9f, 0.9f, 1f);
			dd.DrawText(color, "  LIGHTS    REAL    BAKED", new Vector3(num3, num4, 0f), num, true);
			num4 -= num2;
			dd.DrawText(color, string.Format(" {0}/{1}  {2}/{3}  {4}/{5} ", Pad3(bothActive), Pad3(bothTotal), Pad3(realActive), Pad3(realTotal), Pad3(bakedActive), Pad3(bakedTotal)), new Vector3(num3, num4, 0f), num, true);
			num4 -= 2 * num2;
			dd.DrawText(color2, "REGIONS", new Vector3(num3, num4, 0f), num, true);
			num4 -= num2;
			for (int i = 0; i < vis.visRegions.Count; i++)
			{
				ulong num5 = 0uL;
				ulong num6 = 0uL;
				if (i < 64)
				{
					num5 = (ulong)(1L << i);
				}
				else
				{
					num6 = (ulong)(1L << i - 64);
				}
				if ((vis.visibleMask0 & num5) == num5 && (vis.visibleMask1 & num6) == num6)
				{
					string text = Util.GetObjectPath(vis.visRegions[i].gameObject).Replace("|", "/");
					int num7 = text.IndexOf("/ship/");
					if (num7 >= 0)
					{
						text = text.Substring(num7 + "/ship/".Length);
						num7 = text.IndexOf("/");
						if (num7 >= 0)
						{
							text = text.Substring(num7 + 1);
						}
					}
					dd.DrawText(color2, text, new Vector3(num3, num4, 0f), num, true);
					num4 -= num2;
				}
			}
		});
	}

	private static string Pad3(int i)
	{
		return i.ToString().PadLeft(3, ' ');
	}

	private void Init()
	{
		vis = Object.FindObjectOfType<Vis>();
		standardLights = new List<Light>();
		Lightcaster instance = Lightcaster.instance;
		lightcasterDynamics = new List<LightcasterDynamic>();
		for (int i = 0; i < instance.dynamicLayerAlphas.Count; i++)
		{
			lightcasterDynamics.Add(new LightcasterDynamic
			{
				dynamicLayerIndex = i
			});
		}
		foreach (Light item in Util.IterateAllInScene<Light>(base.gameObject.scene))
		{
			LightcastLight component = item.GetComponent<LightcastLight>();
			if (component != null && component.dynamicLayerIndex >= 0 && component.dynamicLayerIndex < lightcasterDynamics.Count)
			{
				lightcasterDynamics[component.dynamicLayerIndex].positions.Add(component.transform.position);
				for (int j = 1; j < component.poses.Count; j++)
				{
					lightcasterDynamics[component.dynamicLayerIndex].positions.Add(component.transform.position + new Vector3(0f, -0.2f * (float)j, 0f));
				}
			}
			else
			{
				standardLights.Add(item);
			}
		}
		foreach (LightcasterDynamic lightcasterDynamic in lightcasterDynamics)
		{
			lightcasterDynamic.center = Vector3.zero;
			if (lightcasterDynamic.positions.Count <= 0)
			{
				continue;
			}
			foreach (Vector3 position in lightcasterDynamic.positions)
			{
				lightcasterDynamic.center += position;
			}
			lightcasterDynamic.center /= (float)lightcasterDynamic.positions.Count;
		}
	}
}
