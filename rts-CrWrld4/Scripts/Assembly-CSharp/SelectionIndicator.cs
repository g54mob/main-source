using UnityEngine;

public class SelectionIndicator : MonoBehaviour
{
	public enum STATE
	{
		GOOD = 0,
		BAD = 1
	}

	public Material goodMaterial;

	public Material badMaterial;

	public Material squadMaterial;

	private RectangleBorder border;

	private Renderer matRenderer;

	private STATE _state;

	private bool _squadMember;

	public STATE state
	{
		get
		{
			return default(STATE);
		}
		set
		{
		}
	}

	public bool squadMember
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	private void Awake()
	{
	}

	public void Init(float width, float height)
	{
	}
}
