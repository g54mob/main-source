using UnityEngine;

public class ScaledLineOr : Line
{
	public float ScaleXYK = 1f;

	private float _scaleK = 1f;

	private Vector3 _cachedSPosition;

	private Vector3 _cachedEPosition;

	private Vector3 pos1;

	private Vector3 pos2;

	private Vector3 lscale = Vector3.one;

	private Vector3 initialDir = new Vector3(0f, 0f, 1f);

	private Material _material;

	private bool WasUpdated()
	{
		if (S != null && E != null)
		{
			if (!(S.position != _cachedSPosition) && !(E.position != _cachedEPosition))
			{
				return _scaleK != ScaleXYK;
			}
			return true;
		}
		return false;
	}

	private void Update()
	{
		Refresh();
	}

	public override void Refresh()
	{
		if (WasUpdated())
		{
			Vector3 normalized = (E.position - S.position).normalized;
			pos1 = S.position + normalized * Offset;
			pos2 = E.position - normalized * Offset;
			Vector3 toDirection = pos2 - pos1;
			base.transform.rotation = Quaternion.FromToRotation(initialDir, toDirection);
			base.transform.position = pos1;
			float magnitude = toDirection.magnitude;
			lscale.Set(ScaleXYK * magnitude, ScaleXYK * magnitude, magnitude);
			base.transform.localScale = lscale;
		}
	}

	public override void SetMaterial(Material m)
	{
		_material = m;
		SetMaterial(base.gameObject, _material);
	}
}
