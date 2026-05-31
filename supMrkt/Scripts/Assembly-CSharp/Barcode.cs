using Lean.Pool;
using TMPro;
using UnityEngine;

public class Barcode : MonoBehaviour, IPoolable
{
	[SerializeField]
	private TMP_Text m_Text;

	[SerializeField]
	private Camera m_Camera;

	[SerializeField]
	private Renderer m_Icon;

	private string m_Value;

	private static RTPool m_RTPool;

	[SerializeField]
	private Transform m_Graphics;

	[SerializeField]
	private float m_AnimationStartOffset;

	private Collider m_Collider;

	public string Value
	{
		get
		{
			return null;
		}
		set
		{
		}
	}

	public RenderTexture RenderTexture => null;

	[field: SerializeField]
	public Vector3 Extents { get; private set; }

	private void Awake()
	{
	}

	private void UpdateText()
	{
	}

	public void PlayStart()
	{
	}

	public void Capture()
	{
	}

	public void OnSpawn()
	{
	}

	public void OnDespawn()
	{
	}

	public void SetIcon(Sprite image)
	{
	}

	public void ToggleCollider(bool value)
	{
	}
}
