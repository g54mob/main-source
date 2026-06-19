using UnityEngine;
using UnityEngine.Serialization;

public class MeshCheapOneColor : MonoBehaviour
{
	private static readonly int colorShaderID = Shader.PropertyToID("_TheColor");

	private MeshRenderer meshRenderer;

	private MaterialPropertyBlock propertyBlock;

	[SerializeField]
	[FormerlySerializedAs("color")]
	private Color _color = Color.red;

	public Color color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			propertyBlock.SetColor(colorShaderID, _color);
			meshRenderer.SetPropertyBlock(propertyBlock);
		}
	}

	private void Awake()
	{
		meshRenderer = GetComponent<MeshRenderer>();
		propertyBlock = new MaterialPropertyBlock();
		color = _color;
	}
}
