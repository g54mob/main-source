using UnityEngine;

public class Gizmo : MonoBehaviour
{
	public enum Type
	{
		Cube = 0,
		Sphere = 1,
		Mesh = 2,
		WireCube = 3,
		WireSphere = 4,
		WireMesh = 5
	}

	[Tooltip("Enable the gizmo drawing.")]
	public bool Enabled = true;

	[Header("Properties")]
	[SerializeField]
	[Tooltip("Color of the gizmo.")]
	private Color _color = Color.red;

	[SerializeField]
	[Tooltip("Size of the gizmo.")]
	private Vector3 _size = Vector3.one;

	[SerializeField]
	[Tooltip("Type of the gizmo to draw.")]
	private Type _type;

	[SerializeField]
	[Tooltip("Mesh gizmo to draw.")]
	private Mesh _mesh;

	private Vector3 _position = Vector3.zero;

	private void OnDrawGizmos()
	{
		if (Enabled)
		{
			Gizmos.color = _color;
			switch (_type)
			{
			default:
				Gizmos.DrawCube(new Vector3(base.transform.position.x + _position.x, base.transform.position.y + _position.y, base.transform.position.z + _position.z), _size);
				break;
			case Type.Sphere:
				Gizmos.DrawSphere(new Vector3(base.transform.position.x + _position.x, base.transform.position.y + _position.y, base.transform.position.z + _position.z), _size.x);
				break;
			case Type.Mesh:
				Gizmos.DrawMesh(_mesh, new Vector3(base.transform.position.x + _position.x, base.transform.position.y + _position.y, base.transform.position.z + _position.z), base.transform.rotation, _size);
				break;
			case Type.WireCube:
				Gizmos.DrawWireCube(new Vector3(base.transform.position.x + _position.x, base.transform.position.y + _position.y, base.transform.position.z + _position.z), _size);
				break;
			case Type.WireSphere:
				Gizmos.DrawWireSphere(new Vector3(base.transform.position.x + _position.x, base.transform.position.y + _position.y, base.transform.position.z + _position.z), _size.x);
				break;
			case Type.WireMesh:
				Gizmos.DrawWireMesh(_mesh, new Vector3(base.transform.position.x + _position.x, base.transform.position.y + _position.y, base.transform.position.z + _position.z), base.transform.rotation, _size);
				break;
			}
		}
	}

	public void SetColor(Color newColor)
	{
		_color = newColor;
	}

	public void SetGizmoProperties(Type gizmoType, Vector3 gizmoSize)
	{
		_type = gizmoType;
		_size = gizmoSize;
	}
}
