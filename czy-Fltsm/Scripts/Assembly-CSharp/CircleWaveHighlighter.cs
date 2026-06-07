using UnityEngine;

public class CircleWaveHighlighter : MonoBehaviour
{
	public float _minimumTesselation = 8f;

	public float _maximumTesselation = 16f;

	protected Material _material;

	private void Start()
	{
		_material = GetComponentInChildren<MeshRenderer>().material;
	}

	public virtual void Initialize(float radius, Vector3 position, Color color)
	{
		_material = GetComponentInChildren<MeshRenderer>().material;
		SetRadius(radius);
		base.transform.position = position;
		_material.SetColor("_OutsideSwimmingCollor", color);
		_material.SetColor("_SelectionColor", color);
		_material.SetFloat("_SwimmingRange", GameManager.Settings.GameplaySettings.SwimmingRadius);
		_material.SetVector("_SwimmingCenter", Vector3.zero);
		_material.SetFloat("_OutsideSwimmingRangeOpacityMultiplier", 0f);
	}

	public void Initialize(float radius, float range, Vector3 position, Color colorInsideSwimmingRadius, Color colorOutsideSwimmingRange)
	{
		_material = GetComponentInChildren<MeshRenderer>().material;
		SetRadius(radius);
		base.transform.position = position;
		_material.SetColor("_SelectionColor", colorInsideSwimmingRadius);
		_material.SetFloat("_SwimmingRange", range);
		_material.SetVector("_SwimmingCenter", Construction.Townheart.transform.position);
		_material.SetFloat("_OutsideSwimmingRangeOpacityMultiplier", 0f);
		_material.SetColor("_OutsideSwimmingCollor", colorOutsideSwimmingRange);
	}

	public void SetRadius(float radius)
	{
		_material.SetFloat("_SelectionDistance", radius);
		base.transform.localScale = new Vector3(radius / 5f, radius / 5f, radius / 5f);
		float num = radius / (float)GameManager.Settings.GameplaySettings.MapRadius;
		float value = _minimumTesselation + num * (_maximumTesselation - _minimumTesselation);
		value = Mathf.Clamp(value, _minimumTesselation, _maximumTesselation);
		_material.SetFloat("_Tess", value);
	}

	public void SetColor(Color color)
	{
		_material.SetColor("_SelectionColor", color);
	}

	public void SetColor(Color mainColor, Color outsideRadiusColor)
	{
		_material.SetColor("_SelectionColor", mainColor);
		_material.SetColor("_OutsideSwimmingCollor", outsideRadiusColor);
	}
}
