using UnityEngine;

[SelectionBase]
public class EnvironmentGridBlocker : MonoBehaviour
{
	[SerializeField]
	private MeshRenderer renderer;

	[SerializeField]
	private bool hideRendererInPlayMode;

	private void Reset()
	{
	}

	private void Awake()
	{
	}
}
