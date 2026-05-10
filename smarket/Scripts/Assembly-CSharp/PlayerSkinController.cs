using UnityEngine;

public class PlayerSkinController : MonoBehaviour
{
	private bool m_IsLocal;

	[SerializeField]
	private PlayerSkin[] m_Skins;

	public bool IsLocal
	{
		get
		{
			return false;
		}
		set
		{
		}
	}

	public PlayerSkin ActiveSkin { get; private set; }

	public void SetSkinIndex(int index)
	{
	}

	public void SetVisibility(bool isVisible)
	{
	}
}
