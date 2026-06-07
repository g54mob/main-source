using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

public class ServerWireRenderer : MonoBehaviour
{
	private List<Matrix4x4[]> _wireMats = new List<Matrix4x4[]>();

	private List<Vector4[]> _wireBlocks = new List<Vector4[]>();

	private List<Matrix4x4[]> _sphereMats = new List<Matrix4x4[]>();

	private List<Vector4[]> _sphereBlocks = new List<Vector4[]>();

	private int _wireCount;

	private int _sphereCount;

	private Vector3 _lastCamPos;

	private MaterialPropertyBlock _block;

	[NonSerialized]
	public bool ForceDirty;

	public Mesh WireMesh;

	public Mesh SphereMesh;

	public Material WireMaterial;

	public Material SphereMaterial;

	private void Awake()
	{
		_block = new MaterialPropertyBlock();
	}

	private void OnPreCull()
	{
		if (GameSettings.Instance.IsReferenceNull())
		{
			return;
		}
		Vector3 lastCamPos = CameraScript.Instance.LastCamPos;
		if (ForceDirty || lastCamPos != _lastCamPos)
		{
			ForceDirty = false;
			_sphereCount = (_wireCount = 0);
			_lastCamPos = lastCamPos;
			foreach (ServerGroup allServerGroup in GameSettings.Instance.GetAllServerGroups())
			{
				foreach (Server item in allServerGroup.Servers.OfType<Server>())
				{
					if (!item.furn.IsReferenceNull() && item.WiredTo != null && !item.WiredTo.furn.IsReferenceNull() && (ShouldRender(item) || ShouldRender(item.WiredTo)))
					{
						Vector3 start = item.transform.position + Vector3.up * item.furn.ActualHeight * 0.5f;
						Vector3 end = item.WiredTo.transform.position + Vector3.up * item.WiredTo.furn.ActualHeight * 0.5f;
						bool startS = true;
						bool endS = true;
						if (item.furn.Floor > GameSettings.Instance.ActiveFloor)
						{
							start = new Vector3(end.x, (float)(GameSettings.Instance.ActiveFloor * 2) + 2f, end.z);
							startS = false;
						}
						else if (item.WiredTo.furn.Floor > GameSettings.Instance.ActiveFloor)
						{
							end = new Vector3(start.x, (float)(GameSettings.Instance.ActiveFloor * 2) + 2f, start.z);
							endS = false;
						}
						AddWire(start, end, allServerGroup.WireColor, startS, endS);
					}
				}
			}
			AddWire(Vector3.zero, Vector3.one, Color.white);
		}
		bool flag = false;
		if (SelectorController.Instance.SelectedServer != null && !SelectorController.Instance.SelectedServer.furn.IsReferenceNull())
		{
			Server selectedServer = SelectorController.Instance.SelectedServer;
			Vector3 start2 = selectedServer.transform.position + Vector3.up * selectedServer.furn.ActualHeight * 0.5f;
			Vector3 end2 = HUD.Instance.GetMouseProj(1f).ToVector3(GameSettings.Instance.ActiveFloor * 2 + 1);
			SetWire(_wireCount - 1, _sphereCount - 2, start2, end2, selectedServer.Group.WireColor, true, false);
			flag = true;
		}
		if (_wireCount > 0 || flag)
		{
			DrawMeshes(WireMesh, WireMaterial, _wireMats, _wireBlocks, _wireCount - ((!flag) ? 1 : 0));
			DrawMeshes(SphereMesh, SphereMaterial, _sphereMats, _sphereBlocks, _sphereCount - ((!flag) ? 2 : 0));
		}
	}

	private bool ShouldRender(Server s)
	{
		if (s.furn.IsChildVisible())
		{
			return true;
		}
		if (s.furn.Floor <= GameSettings.Instance.ActiveFloor && (s.transform.position + Vector3.up).IsOnScreen())
		{
			return true;
		}
		return false;
	}

	private void DrawMeshes(Mesh mesh, Material mat, List<Matrix4x4[]> mats, List<Vector4[]> colors, int count)
	{
		int num = 0;
		while (count > 0)
		{
			if (SystemInfo.supportsInstancing)
			{
				_block.SetVectorArray("_Color", colors[num]);
				Graphics.DrawMeshInstanced(mesh, 0, mat, mats[num], Mathf.Min(count, mats[num].Length), _block, ShadowCastingMode.Off, false);
			}
			else
			{
				for (int i = 0; i < Mathf.Min(count, mats[num].Length); i++)
				{
					_block.SetVector("_Color", colors[num][i]);
					Graphics.DrawMesh(mesh, mats[num][i], mat, 0, CameraScript.Instance.mainCam, 0, _block, ShadowCastingMode.Off, false);
				}
			}
			count -= mats[num].Length;
			num++;
		}
	}

	private void SetWire(int wireIdx, int sphereIdx, Vector3 start, Vector3 end, Color block, bool startS = true, bool endS = true)
	{
		if (!(start == end))
		{
			Vector3 forward = end - start;
			AddObject(_wireMats, Matrix4x4.TRS(start, Quaternion.LookRotation(forward), new Vector3(1f, 1f, forward.magnitude)), wireIdx);
			AddObject(_wireBlocks, block, wireIdx);
			int num = sphereIdx;
			if (startS)
			{
				AddObject(_sphereMats, Matrix4x4.TRS(start, Quaternion.identity, Vector3.one), num);
				AddObject(_sphereBlocks, block, num);
				num++;
			}
			if (endS)
			{
				AddObject(_sphereMats, Matrix4x4.TRS(end, Quaternion.identity, Vector3.one), num);
				AddObject(_sphereBlocks, block, num);
			}
		}
	}

	private void AddWire(Vector3 start, Vector3 end, Color block, bool startS = true, bool endS = true)
	{
		if (!(start == end))
		{
			SetWire(_wireCount, _sphereCount, start, end, block, startS, endS);
			_wireCount++;
			if (startS)
			{
				_sphereCount++;
			}
			if (endS)
			{
				_sphereCount++;
			}
		}
	}

	private void AddObject<T>(List<T[]> l, T obj, int idx)
	{
		int num = idx / 1023;
		T[] array;
		if (num >= l.Count)
		{
			array = new T[1023];
			l.Add(array);
		}
		else
		{
			array = l[num];
		}
		int num2 = idx % 1023;
		array[num2] = obj;
	}
}
