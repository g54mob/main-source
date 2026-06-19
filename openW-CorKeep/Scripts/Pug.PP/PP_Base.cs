using UnityEngine;

public class PP_Base : MonoBehaviour
{
	public Shader shader;

	protected Material _material;

	protected Material material
	{
		get
		{
			if (_material == null)
			{
				_material = new Material(shader);
			}
			return _material;
		}
	}

	public virtual void Start()
	{
		if (!shader || !shader.isSupported)
		{
			base.enabled = false;
			if (!shader)
			{
				Debug.LogError("Shader of " + base.name + " has not been set!");
			}
			else
			{
				Debug.LogError("Shader " + shader.name + " is not supported!");
			}
		}
	}
}
