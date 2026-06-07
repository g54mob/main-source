using UnityEngine;

public class MVerseMouseIndicator : MonoBehaviour
{
	private MVersePlayerPrefab playerPrefab;

	private LineRenderer lineRenderer;

	private Light lineLight;

	public static MVerseMouseIndicator Create()
	{
		return null;
	}

	public void Awake()
	{
	}

	public void Init(MVersePlayerPrefab playerPrefab, Color color)
	{
	}

	public void SetLocationX(short cellX)
	{
	}

	public void SetLocationZ(short cellZ)
	{
	}

	public void SetVisible(bool vis)
	{
	}

	public void SetColor(Color color)
	{
	}

	public void DestroyMouseIndicator()
	{
	}
}
