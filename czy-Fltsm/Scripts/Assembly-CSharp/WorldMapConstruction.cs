using PajamaLlama.Math;
using UnityEngine;

[RequireComponent(typeof(PolygonMeshRenderer))]
public class WorldMapConstruction : MonoBehaviour
{
	[SerializeField]
	private PolygonMeshRenderer _footprintRenderer;

	[Tooltip("The amount of units between the construction outline and the construction collider")]
	[SerializeField]
	private float _outlinePadding;

	[SerializeField]
	private float _townheartScale = 1f;

	[SerializeField]
	private Vector3 _offset = new Vector3(0f, 0.5f, 0f);

	public Construction Construction { get; private set; }

	public Polygon Polygon { get; private set; }

	public void Initialize(Construction construction)
	{
		Construction = construction;
		if (Construction == Construction.Townheart)
		{
			InitializeTownheartPolygon(construction.Buildable.OutlinePolygon.Polygon2D);
		}
		else
		{
			InitializePolygon(construction.Buildable.OutlinePolygon.Polygon2D);
		}
		_footprintRenderer?.Initialize(Polygon.Polygon2D);
		_footprintRenderer.transform.position += _offset;
	}

	private void InitializeTownheartPolygon(Vector2[] vertices)
	{
		using ListPool<Vector2>.List vertices2 = Geometry2D.ScalePolygon(vertices, _townheartScale);
		Polygon = new Polygon(vertices2);
	}

	private void InitializePolygon(Vector2[] vertices)
	{
		using ListPool<Vector2>.List vertices2 = Geometry2D.AddPaddingToPolygon(vertices, _outlinePadding);
		Polygon = new Polygon(vertices2);
	}
}
