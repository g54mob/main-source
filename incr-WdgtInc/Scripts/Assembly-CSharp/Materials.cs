using UnityEngine;

public class Materials : MonoBehaviour
{
	private static Materials _instance;

	[SerializeField]
	private Material _grayscale;

	[SerializeField]
	private Material _grayscale75;

	[SerializeField]
	private Material _default;

	public static Material Grayscale => _instance._grayscale;

	public static Material Grayscale75 => _instance._grayscale75;

	public static Material Default => _instance._default;

	private void Awake()
	{
		_instance = this;
	}
}
