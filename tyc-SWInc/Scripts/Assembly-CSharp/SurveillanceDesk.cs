using System;
using UnityEngine;

public class SurveillanceDesk : MonoBehaviour
{
	private const float CCTVCycleRate = 15f;

	public Furniture Furn;

	public MeshRenderer[] Monitors;

	public Material CCTVMat;

	public Material OffMat;

	[NonSerialized]
	private Furniture[] _activeCCs = new Furniture[4];

	[NonSerialized]
	private float _countdown;

	[NonSerialized]
	private int _lastPick;

	public Furniture[] GetCCTVs()
	{
		return _activeCCs;
	}

	public void AssignTex(int slot, int texIdx)
	{
		MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
		float num = CCTVRenderer.Instance.CCTVTexture.width / CCTVRenderer.Instance.CCTVTextureTemp.width;
		MeshRenderer obj = Monitors[slot];
		obj.GetPropertyBlock(materialPropertyBlock);
		float x = (float)texIdx % num / num;
		float y = Mathf.Floor((float)texIdx / num) / num;
		materialPropertyBlock.SetVector("_Offset", new Vector4(x, y, 1f / num, 1f / num));
		obj.SetPropertyBlock(materialPropertyBlock);
	}

	public int FreeSlots()
	{
		int num = 0;
		for (int i = 0; i < _activeCCs.Length; i++)
		{
			if (_activeCCs[i] == null)
			{
				num++;
			}
		}
		return num;
	}

	public int GetFreeSlot()
	{
		for (int i = 0; i < _activeCCs.Length; i++)
		{
			if (_activeCCs[i] == null)
			{
				return i;
			}
		}
		return -1;
	}

	public void AssignSlot(int idx, Furniture cc)
	{
		if (_activeCCs[idx] != null)
		{
			_activeCCs[idx].IsOn = false;
			CCTVRenderer.Instance.RemoveCCTV(this, _activeCCs[idx]);
			if (_activeCCs[idx].CCGroup != null)
			{
				_activeCCs[idx].CCGroup.FreeCCTVs.Add(_activeCCs[idx]);
			}
		}
		_activeCCs[idx] = cc;
		if (cc != null)
		{
			Monitors[idx].sharedMaterial = CCTVMat;
			_activeCCs[idx].IsOn = true;
		}
		else if (this != null)
		{
			Monitors[idx].sharedMaterial = OffMat;
		}
	}

	public void ClearSlots()
	{
		for (int i = 0; i < 4; i++)
		{
			AssignSlot(i, null);
		}
	}

	private void Start()
	{
		_countdown = UnityEngine.Random.value * 15f * 0.5f;
	}

	private void FixedUpdate()
	{
		if (!Furn.IsOn || Furn.CCGroup == null)
		{
			return;
		}
		_countdown += Time.deltaTime * GameSettings.GameSpeed;
		if (_countdown >= 15f)
		{
			_countdown = 0f;
			Furniture furniture = Furn.CCGroup.FreeCCTVs.Where((Furniture x) => !x.upg.Broken).MinInstance((Furniture x) => Furn.CCGroup.CCTVs.GetOrDefault(x, 0));
			if (furniture != null)
			{
				Furn.CCGroup.CCTVs[furniture] = SDateTime.Now().ToInt();
				AssignSlot(_lastPick, furniture);
				_lastPick = (_lastPick + 1) % 4;
			}
		}
	}

	public void OnStateChange(bool ison)
	{
		if (ison)
		{
			if (Furn.CCGroup != null)
			{
				Furn.CCGroup.AssignCCs(this);
			}
		}
		else
		{
			ClearSlots();
		}
	}
}
