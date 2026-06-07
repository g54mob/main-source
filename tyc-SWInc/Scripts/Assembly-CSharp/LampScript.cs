using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour, IDistributee
{
	public PipLight[] Lights;

	public bool EnableShadows = true;

	private Furniture furn;

	private bool AtEdge;

	private float[] initialIntensities;

	private bool init;

	private bool currentState;

	public bool IsValid
	{
		get
		{
			return true;
		}
	}

	public void CalcEdge()
	{
		if (furn == null || (furn.Parent == null && furn.Map == null))
		{
			return;
		}
		object room;
		if (furn.Map == null)
		{
			IRoom parent = furn.Parent;
			room = parent;
		}
		else
		{
			IRoom parent = furn.NetworkParent;
			room = parent;
		}
		if (room == null)
		{
			room = GameSettings.Instance.sRoomManager.Outside;
		}
		IRoom room2 = (IRoom)room;
		AtEdge = false;
		Vector2 vector = new Vector2(base.transform.position.x, base.transform.position.z);
		List<WallEdge> edges = room2.Edges;
		if (edges == null)
		{
			return;
		}
		if (room2.Outdoors)
		{
			AtEdge = true;
			return;
		}
		for (int i = 0; i < edges.Count; i++)
		{
			int index = (i + 1) % edges.Count;
			Room room3 = edges[index].GetRoom(edges[i]);
			Vector2 res;
			if ((!(room3 != null) || room3.Outdoors) && Utilities.ProjectToLine(vector, edges[i].Pos, edges[index].Pos, out res) && (res - vector).sqrMagnitude < 2f)
			{
				AtEdge = true;
				break;
			}
		}
	}

	private bool BuildModeLighting()
	{
		if (HUD.Instance != null && HUD.Instance.BuildMode)
		{
			return HUD.Instance.SunSlider.value < 0.5f;
		}
		return false;
	}

	private bool InitNow()
	{
		if (!init)
		{
			if (GameSettings.Instance != null)
			{
				GameSettings.Instance.LampUpdateHandler.RegisterObject(this);
			}
			init = true;
			furn = GetComponent<Furniture>();
			if (!(furn != null))
			{
				base.enabled = false;
				return false;
			}
			furn.Lamp = this;
			furn.HasLamp = true;
			if (Lights == null || Lights.Length == 0)
			{
				Lights = GetComponentsInChildren<PipLight>();
				if (Lights.Length == 0)
				{
					base.enabled = false;
					return false;
				}
			}
			if (Lights != null)
			{
				EnableLights(furn.IsOn);
				initialIntensities = new float[Lights.Length];
				for (int i = 0; i < Lights.Length; i++)
				{
					initialIntensities[i] = Lights[i].intensity;
					Lights[i].cullingMask = -10035;
				}
			}
		}
		return true;
	}

	private void Start()
	{
		InitNow();
	}

	private void OnDestroy()
	{
		if (GameSettings.Instance != null)
		{
			GameSettings.Instance.LampUpdateHandler.UnregisterObject(this);
		}
	}

	private void EnableLights(bool enable)
	{
		currentState = enable;
		if (Lights != null)
		{
			for (int i = 0; i < Lights.Length; i++)
			{
				Lights[i].enabled = enable;
			}
		}
	}

	private void UpdateLightState(float intensity, bool shadows, float flicker)
	{
		if (Lights == null)
		{
			return;
		}
		bool flag = false;
		for (int i = 0; i < Lights.Length; i++)
		{
			PipLight pipLight = Lights[i];
			float intensity2 = pipLight.intensity;
			pipLight.intensity = initialIntensities[i] * intensity;
			if (flicker > 0f)
			{
				if (Options.Flickering)
				{
					if (flicker >= TimeHash01(furn.DID))
					{
						pipLight.intensity = 0f;
					}
					else if (intensity2 == 0f)
					{
						flag = true;
					}
				}
				else
				{
					pipLight.intensity = Mathf.Lerp(pipLight.intensity, 0f, flicker);
				}
			}
			if ((pipLight.shadowType == LightShadows.Hard) ^ shadows)
			{
				pipLight.shadowType = (shadows ? LightShadows.Hard : LightShadows.None);
			}
		}
		if (flag && furn.Floor == GameSettings.Instance.ActiveFloor)
		{
			UISoundFX.PlaySFX("LightFlicker", base.transform.position, furn.Parent != GameSettings.Instance.sRoomManager.CameraRoom);
		}
	}

	private static float TimeHash01(uint seed)
	{
		uint num = (uint)(TimeOfDay.Instance.TimeInMinutes * 1000f);
		uint num2 = seed;
		num2 ^= (uint)((int)num + -1640531527 + (int)(num2 << 6) + (int)(num2 >> 2));
		num2 ^= num2 >> 16;
		num2 *= 2146121005;
		num2 ^= num2 >> 15;
		num2 *= 2221713035u;
		num2 ^= num2 >> 16;
		return (float)(num2 >> 8) * 5.9604645E-08f;
	}

	public void DirtyLights()
	{
		for (int i = 0; i < Lights.Length; i++)
		{
			Lights[i].UpdateNextFrame = true;
		}
	}

	private bool IsAtriumVisible()
	{
		Room mainAtriumParent = furn.Parent.GetMainAtriumParent();
		if (mainAtriumParent != null)
		{
			int floor = mainAtriumParent.Floor;
			int num = floor + mainAtriumParent.AtriumChildren.Count;
			if (GameSettings.Instance.ActiveFloor >= floor)
			{
				return GameSettings.Instance.ActiveFloor <= num;
			}
			return false;
		}
		return false;
	}

	public void UpdateNow(float delta)
	{
		if (GameSettings.Instance.IsReferenceNull() || !InitNow() || !furn.Parent.IsAliveNotNull() || !base.enabled)
		{
			return;
		}
		if (furn.isTemporary)
		{
			for (int i = 0; i < Lights.Length; i++)
			{
				PipLight obj = Lights[i];
				obj.shadowType = LightShadows.Hard;
				obj.enabled = true;
			}
			return;
		}
		bool flag = BuildModeLighting();
		furn.ForceEmission = flag;
		Room room = furn.Parent.AtriumParent ?? furn.Parent;
		bool flag2 = furn.LightAlwaysOn || room.Floor == -1 || Cheats.ForceLights || (room.WindowDarkLevel * TimeOfDay.LightLevel < 0.75f && room.AnyOccupantsAtrium(true)) || ((room.Outdoors || furn.IsReversed) && TimeOfDay.LightLevel < 0.75f);
		if (furn.IsOn != flag2)
		{
			furn.IsOn = flag2;
		}
		if (currentState && !flag && !furn.IsOn)
		{
			EnableLights(false);
		}
		if (furn.IsOn || flag)
		{
			float x = ((flag || !furn.HasUpg) ? 1f : furn.upg.Quality);
			bool flag3 = (furn.Parent.Floor < 0 && GameSettings.Instance.ActiveFloor < 0) || (furn.Parent.Floor > -1 && (furn.Parent.Floor == GameSettings.Instance.ActiveFloor || IsAtriumVisible() || (!Options.OpaqueGlass && AtEdge && furn.Parent.Floor < GameSettings.Instance.ActiveFloor)));
			EnableLights(flag3);
			if (flag3)
			{
				UpdateLightState((GameSettings.Instance.ActiveFloor < 0) ? 1f : (0.5f + (1f - Mathf.Min(1f, Mathf.Max(0f, TimeOfDay.LightLevel - 0.3f) * 1.5f)) * 0.5f), EnableShadows && Options.MoreShadow, x.MapRange(0f, 0.33f, 1f, 0f, true));
			}
		}
	}

	public void UpdateNow2(float delta)
	{
	}

	public bool NeedUpdate(bool firstFunction)
	{
		return true;
	}
}
