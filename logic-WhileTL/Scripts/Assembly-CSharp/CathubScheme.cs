using UnityEngine;

public class CathubScheme
{
	public string json = string.Empty;

	public Vector3? penPosition;

	public Vector2 pivot = Vector2.one * 0.5f;

	public Vector3 zoom = Vector3.one;

	public bool IsValid()
	{
		return json.Length > 0;
	}

	public CathubScheme(SchemeBlock sch, Vector3 penPosition, Vector3 zoom, Vector2 pivot)
	{
		sch.ClearToSave();
		json = Logic.SerializeObject(sch);
		this.penPosition = penPosition;
		this.pivot = pivot;
		this.zoom = zoom;
	}

	public CathubScheme(string json)
	{
		this.json = json;
	}

	public CathubScheme()
	{
		zoom = Vector3.one * Logic.GetStaticData().Settings.DefaultMobileZoom;
	}
}
