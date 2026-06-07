using System.Collections.Generic;
using UnityEngine;

public class LineOr : Line
{
	private const bool ADAPT_SEGMENTS_COUNT = true;

	private Vector3 _cachedSPosition;

	private Vector3 _cachedEPosition;

	public float Length;

	public GameObject go;

	private float _offsetDelta;

	private Vector3 pos1;

	private Vector3 pos2;

	private Vector3 line;

	private Vector3 dir;

	private Vector3 lscale = Vector3.one;

	private float iscale = 1f;

	private Vector3 sp;

	private Vector3 ep;

	private Vector3 initialDir = new Vector3(0f, 0f, 1f);

	private List<GameObject> _segments = new List<GameObject>();

	private Dictionary<string, GameObject> meshDict = new Dictionary<string, GameObject>();

	private Material _material;

	private void OnDestroy()
	{
		foreach (GameObject segment in _segments)
		{
			Object.Destroy(segment);
		}
		_segments.Clear();
	}

	private bool WasUpdated()
	{
		if (S != null && E != null)
		{
			if (!(S.position != _cachedSPosition))
			{
				return E.position != _cachedEPosition;
			}
			return true;
		}
		return false;
	}

	public override void Refresh()
	{
		if (!WasUpdated())
		{
			return;
		}
		sp = S.position;
		ep = E.position;
		_cachedSPosition = sp;
		_cachedEPosition = ep;
		Vector3 normalized = (ep - sp).normalized;
		pos1 = sp + normalized * (Offset + _offsetDelta);
		pos2 = ep - normalized * (Offset + _offsetDelta);
		Vector3 toDirection = (line = pos2 - pos1);
		float length = Length;
		float num = 1f / (line.magnitude / length);
		lscale.Set(num, num, num);
		iscale = 1f / num;
		dir = normalized;
		float num2 = Vector3.Distance(pos1 + line * num * Mathf.Floor(iscale), pos2) * 0.5f;
		pos1 = sp + normalized * (Offset + _offsetDelta + num2);
		pos2 = ep - normalized * (Offset + _offsetDelta + num2);
		Quaternion rotation = Quaternion.FromToRotation(initialDir, toDirection);
		Vector3 vector = Vector3.zero;
		if (iscale < 1f)
		{
			iscale = 1f;
			vector = sp - normalized * (1f - toDirection.magnitude) * 0.5f;
		}
		int num3 = (int)iscale;
		while (_segments.Count > num3)
		{
			int index = _segments.Count - 1;
			Object.Destroy(_segments[index]);
			_segments.RemoveAt(index);
		}
		for (int i = 0; i < num3; i++)
		{
			if (go != null)
			{
				Vector3 position = ((vector != Vector3.zero) ? vector : (pos1 + line * num * i));
				if (i > _segments.Count - 1)
				{
					string text = "LineSeg" + i;
					GameObject gameObject = Object.Instantiate(go, position, rotation);
					gameObject.name = text;
					gameObject.transform.SetParent(base.transform);
					_segments.Add(gameObject);
					SetMaterial(gameObject, _material);
				}
			}
		}
		for (int j = 0; j < _segments.Count; j++)
		{
			Vector3 position2 = ((vector != Vector3.zero) ? vector : (pos1 + line * num * j));
			GameObject obj = _segments[j];
			Vector3 localScale = Vector3.one * length;
			obj.transform.localScale = localScale;
			obj.transform.rotation = rotation;
			obj.transform.position = position2;
		}
	}

	private void Update()
	{
		Refresh();
	}

	public override void SetMaterial(Material m)
	{
		_material = m;
		for (int i = 0; i < _segments.Count; i++)
		{
			if (_segments[i] != null)
			{
				SetMaterial(_segments[i], _material);
			}
		}
	}
}
