using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LogoController : MonoBehaviour
{
	public static LogoController Instance;

	public RenderTexture LogoTexture;

	public Material InWorldMat;

	public int GuaranteedPlayerRes = 256;

	private Material _blitMat;

	[NonSerialized]
	private Dictionary<Company, ValueTuple<Rect, Vector2Int>> _logoPos = new Dictionary<Company, ValueTuple<Rect, Vector2Int>>();

	[NonSerialized]
	private List<Company> _logoQueue = new List<Company>();

	private List<Vector2Int> _freeSpots = new List<Vector2Int>();

	private int _logoSize = -1;

	private float _playerFactor;

	[NonSerialized]
	private List<Company> _removed = new List<Company>();

	[NonSerialized]
	private List<Company> _added = new List<Company>();

	private void Awake()
	{
		Instance = this;
		_blitMat = new Material(Shader.Find("Hidden/SDFAtlasBlit"));
		_blitMat.SetTexture("_BackTex", LogoTexture);
		_playerFactor = (float)(GuaranteedPlayerRes * GuaranteedPlayerRes) / (float)(LogoTexture.width * LogoTexture.width);
		_playerFactor = 1f + _playerFactor * (1f + _playerFactor * (1f + _playerFactor * (1f + _playerFactor)));
	}

	private void OnDestroy()
	{
		if (Instance == this)
		{
			Instance = null;
		}
	}

	public void DirtyLogo(Company c)
	{
		if (!_logoQueue.Contains(c))
		{
			_logoQueue.Add(c);
		}
	}

	public Rect GetLogoRect(Company c, bool reverse = false)
	{
		ValueTuple<Rect, Vector2Int> value;
		if (c != null && _logoPos.TryGetValue(c, out value))
		{
			if (!reverse)
			{
				return value.Item1;
			}
			return ReverseUV(value.Item1);
		}
		Rect res;
		CheckLogoQueue(c, out res, reverse);
		return res;
	}

	public bool TryGetLogoRect(Company c, out Rect res, bool reverse = false)
	{
		ValueTuple<Rect, Vector2Int> value;
		if (c != null && _logoPos.TryGetValue(c, out value))
		{
			res = (reverse ? ReverseUV(value.Item1) : value.Item1);
			return true;
		}
		return CheckLogoQueue(c, out res, reverse);
	}

	private Rect ReverseUV(Rect r)
	{
		return new Rect(r.xMin, 1f - r.yMin - r.height, r.width, r.height);
	}

	private bool CheckLogoQueue(Company c, out Rect res, bool reverse = false)
	{
		res = Rect.zero;
		if (_logoQueue.Contains(c))
		{
			if (c == GameSettings.Instance.MyCompany)
			{
				float num = (float)GuaranteedPlayerRes / (float)LogoTexture.width;
				res = new Rect(0f, 0f, num, num);
			}
			else if (_freeSpots.Count > 0)
			{
				Vector2Int item = _freeSpots[0];
				_freeSpots.RemoveAt(0);
				float num2 = 1f / (float)_logoSize;
				res = new Rect((float)item.x * num2, (float)item.y * num2, num2, num2);
				_logoPos[c] = new ValueTuple<Rect, Vector2Int>(res, item);
			}
			else
			{
				_logoPos[c] = new ValueTuple<Rect, Vector2Int>(new Rect(0f, 0f, 1f, 1f), new Vector2Int(-1, -1));
				Debug.Log("Couldn't find free spot for company logo in atlas");
			}
			if (reverse)
			{
				res = ReverseUV(res);
			}
			return true;
		}
		return false;
	}

	private int GetLogoSize(int companies)
	{
		return Mathf.Max(LogoTexture.width / GuaranteedPlayerRes, Mathf.NextPowerOfTwo(Mathf.CeilToInt(Mathf.Sqrt((float)(companies - 1) * _playerFactor))));
	}

	public void Update()
	{
		if (GameSettings.Instance.IsReferenceNull() || GameSettings.Instance.PreSimActive || !SelectorController.Instance.DoneLoading)
		{
			return;
		}
		if (_logoSize < 0)
		{
			List<Company> list = MarketSimulation.Active.GetAllCompanies().ToList();
			_logoSize = GetLogoSize(list.Count);
			_logoQueue.Clear();
			_logoQueue.AddRange(list);
			_freeSpots.Clear();
			_logoPos.Clear();
			int num = GuaranteedPlayerRes / (LogoTexture.width / _logoSize);
			for (int i = 0; i < _logoSize; i++)
			{
				for (int j = 0; j < _logoSize; j++)
				{
					if (i >= num || j >= num)
					{
						_freeSpots.Add(new Vector2Int(i, j));
					}
				}
			}
			RenderTexture active = RenderTexture.active;
			RenderTexture.active = LogoTexture;
			GL.Clear(false, true, Color.clear);
			RenderTexture.active = active;
		}
		if (_logoQueue.Count > 0)
		{
			Company company = _logoQueue.Last();
			_logoQueue.RemoveAt(_logoQueue.Count - 1);
			int num2 = _logoSize;
			Vector2Int item;
			ValueTuple<Rect, Vector2Int> value;
			if (company == GameSettings.Instance.MyCompany)
			{
				num2 = LogoTexture.width / GuaranteedPlayerRes;
				item = Vector2Int.zero;
			}
			else if (_logoPos.TryGetValue(company, out value) && value.Item2.x >= 0)
			{
				item = value.Item2;
			}
			else
			{
				if (_freeSpots.Count <= 0)
				{
					_logoPos[company] = new ValueTuple<Rect, Vector2Int>(new Rect(0f, 0f, 1f, 1f), new Vector2Int(-1, -1));
					Debug.Log("Couldn't find free spot for company logo in atlas");
					return;
				}
				item = _freeSpots[0];
				_freeSpots.RemoveAt(0);
			}
			if (company.Logo == null)
			{
				company.GenerateLogo();
			}
			SDFCreator.ISDFNode iSDFNode = SDFCreator.LoadSDFTree(company.Logo);
			RenderTexture temporary = RenderTexture.GetTemporary(LogoTexture.width / num2, LogoTexture.width / num2, 0, RenderTextureFormat.ARGB32);
			iSDFNode.Execute(temporary.width, temporary, Matrix4x4.identity);
			_blitMat.SetVector("_Offset", new Vector4(item.x, item.y, num2, num2));
			Graphics.Blit(temporary, LogoTexture, _blitMat);
			float num3 = 1f / (float)num2;
			Rect rect = new Rect((float)item.x * num3, (float)item.y * num3, num3, num3);
			GlobalSearchPanel.SearchItem searchItem;
			if (GlobalSearchPanel.Instance.TryGetSearchItem(company, out searchItem))
			{
				searchItem.SetThumbnail(LogoTexture, rect);
			}
			_logoPos[company] = new ValueTuple<Rect, Vector2Int>(rect, item);
			RenderTexture.ReleaseTemporary(temporary);
			return;
		}
		foreach (KeyValuePair<Company, ValueTuple<Rect, Vector2Int>> logoPo in _logoPos)
		{
			if (MarketSimulation.Active.GetCompany(logoPo.Key.ID) == null)
			{
				_removed.Add(logoPo.Key);
			}
		}
		foreach (Company allCompany in MarketSimulation.Active.GetAllCompanies())
		{
			if (!_logoPos.ContainsKey(allCompany))
			{
				_added.Add(allCompany);
			}
		}
		if (_removed.Count <= 0 && _added.Count <= 0)
		{
			return;
		}
		int logoSize = GetLogoSize(MarketSimulation.Active.GetAllCompanies().Count());
		if (_logoSize != logoSize)
		{
			_logoSize = -1;
		}
		else
		{
			for (int k = 0; k < _removed.Count; k++)
			{
				Company key = _removed[k];
				Vector2Int item2 = _logoPos[key].Item2;
				if (item2.x >= 0)
				{
					_logoPos.Remove(key);
					_freeSpots.Add(item2);
				}
			}
			for (int l = 0; l < _added.Count; l++)
			{
				Company item3 = _added[l];
				_logoQueue.Add(item3);
			}
		}
		_removed.Clear();
		_added.Clear();
	}
}
