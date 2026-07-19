using UnityEngine;

public class Grid : MonoBehaviour
{
	public static Material material;

	public Renderer top;

	public Renderer bottom;

	public Transform center;

	public static Grid instance { get; private set; }

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
		material = new Material(Resources.Load<Material>("Materials/Studio/grid"));
		top.material = material;
		bottom.material = material;
	}

	public void SetShape(string s)
	{
		if (!(s == "square"))
		{
			if (s == "hexagon")
			{
				material.mainTexture = Resources.Load<Texture>("Workspaces/Textures/hexagon");
				material.mainTextureScale = new Vector2(200f, 230f);
			}
		}
		else
		{
			material.mainTexture = Resources.Load<Texture>("Workspaces/Textures/square");
			material.mainTextureScale = new Vector2(400f, 400f);
			Global.elements["selector"].eulerAngles = Vector3.zero;
			Control.gridRotation = Vector3.zero;
		}
	}

	public void ShowGrid()
	{
		base.transform.gameObject.SetActive(value: true);
	}

	public void HideGrid()
	{
		base.transform.gameObject.SetActive(value: false);
	}

	public void SetOpacity(float opacity)
	{
		Color color = material.color;
		color.a = opacity;
		material.color = color;
	}

	public void SetColor(Color c)
	{
		Color color = material.color;
		color = c;
		color.a = material.color.a;
		material.color = color;
	}

	public static Vector3 Hex(Vector3 v)
	{
		Vector3 result = v;
		result.x = 1f * Mathf.Round(v.x / 1f);
		result.y = 1f * Mathf.Round(v.y / 1f);
		result.z = 0.866f * Mathf.Round(v.z / 0.866f);
		if (0.866f * Mathf.Round(v.z / 0.866f) % 1.732f != 0f)
		{
			if (Mathf.Floor(v.x - result.x) == -1f)
			{
				result.x -= 0.5f;
			}
			else
			{
				result.x += 0.5f;
			}
		}
		return result;
	}
}
