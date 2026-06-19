using System;
using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	public class RoomItemVisualEdit : MustCallDestroy
	{
		[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
		public class Config
		{
			public float LineThickness = 0.1f;

			public float LineElevation = 0.1f;

			public float TextureUVTile = 1f;

			public Material[] BoundsValidMaterial;

			public Material[] BoundsThinkingMaterial;

			public Material[] BoundsInvalidMaterial;

			public float SellInvalidItemAlpha = 0.5f;

			public bool ShowInteractionPoints = true;

			public GameObject InteractionPointPrefab;

			public Material InteractionPointValidMaterial;

			public Material InteractionPointInvalidMaterial;

			public GameObject RotationVisualPrefab;

			[InspectorHeader("Item Validation Visual Settings")]
			public float InvalidAlpha = 0.25f;

			public float ValidFadeInSpeed = 1f;

			public float InvalidFadeInSpeed = 1f;

			public float InitialFadeInSpeed = 0.25f;

			[InspectorHeader("Navigation Validation Visual Settings")]
			public float NavInvalidFadeSpeed = 1f;

			public float NavInvalidLineThickness = 0.2f;

			public Material[] NavInvalidMaterials;
		}

		private readonly Config _config;

		[DontSave]
		private readonly GameObject _gameObject;

		[DontSave]
		private readonly MeshFilter _meshFilter;

		[DontSave]
		private readonly MeshRenderer _meshRenderer;

		[DontSave]
		private List<GameObject> _interactionPoints;

		[DontSave]
		private GameObject _rotationVisual;

		[DontSave]
		private RoomItemVisualEditAnimator _animator;

		private bool _visible;

		private ConvexPolygon _cachedShape;

		private const float MIN_MITER_JOIN = (float)Math.PI / 12f;

		private const float MIN_BEVEL_NICE_JOIN = (float)Math.PI / 6f;

		public RoomItemVisualEdit(Config config, RoomItemVisual roomItemVisual, RoomItem roomItem)
		{
			_config = config;
			_gameObject = new GameObject("Edit Visual");
			_gameObject.transform.SetParent(roomItemVisual.GameObject.transform);
			_gameObject.transform.position = Vector3.zero;
			_gameObject.transform.rotation = Quaternion.identity;
			_meshFilter = _gameObject.AddComponent<MeshFilter>();
			_meshFilter.mesh = new Mesh();
			_meshRenderer = _gameObject.AddComponent<MeshRenderer>();
			if (config.ShowInteractionPoints)
			{
				_interactionPoints = new List<GameObject>();
				foreach (ObjectInteraction interaction in roomItem.Interactions)
				{
					GameObject gameObject = UnityEngine.Object.Instantiate(config.InteractionPointPrefab, _gameObject.transform, worldPositionStays: false);
					gameObject.transform.localPosition = interaction.StartPosition;
					gameObject.transform.localRotation = interaction.StartRotation;
					_interactionPoints.Add(gameObject);
				}
			}
			_animator = _gameObject.GetOrAddComponent<RoomItemVisualEditAnimator>();
			_animator.Initialise(_meshRenderer, _interactionPoints);
			if (config.RotationVisualPrefab != null)
			{
				_rotationVisual = UnityEngine.Object.Instantiate(config.RotationVisualPrefab, _gameObject.transform, worldPositionStays: false);
			}
		}

		public override void Destroy()
		{
			if (_interactionPoints != null)
			{
				_interactionPoints.ClearAndDestroy();
				_interactionPoints = null;
			}
			if (_rotationVisual != null)
			{
				UnityEngine.Object.Destroy(_rotationVisual);
			}
			UnityEngine.Object.Destroy(_gameObject);
			base.Destroy();
		}

		public void UpdateFrom(RoomItem roomItem, bool thinking)
		{
			Transform transform = _gameObject.transform;
			transform.localPosition = new Vector3(0f, 0f - transform.parent.position.y, 0f);
			transform.localRotation = Quaternion.identity;
			if (_cachedShape == null)
			{
				_cachedShape = roomItem.GetCombinedCollisionShape(worldSpace: false, includeSolid: true, includeNonSolid: true);
				if (_cachedShape != null)
				{
					List<UIVertex[]> list = new List<UIVertex[]>();
					List<Vector2> points = _cachedShape.Points;
					list.Add(CreateLineSegment(points[points.Count - 1], points[0]));
					for (int i = 1; i < points.Count; i++)
					{
						list.Add(CreateLineSegment(points[i - 1], points[i]));
					}
					list.Add(CreateLineSegment(points[points.Count - 1], points[0]));
					List<Vector3> list2 = new List<Vector3>();
					List<Vector3> list3 = new List<Vector3>();
					List<Vector2> list4 = new List<Vector2>();
					int[] triangles = Triangulator.Triangulate(_cachedShape.Points);
					Vector3 position = transform.parent.position;
					Quaternion rotation = transform.parent.rotation;
					foreach (Vector2 point in _cachedShape.Points)
					{
						list2.Add(new Vector3(point.x, _config.LineElevation, point.y));
						list3.Add(Vector3.up);
						Vector3 vector = rotation * new Vector3(point.x, 0f, point.y);
						list4.Add(new Vector2(vector.x + position.x, vector.z + position.z) * _config.TextureUVTile);
					}
					List<int> list5 = new List<int>();
					for (int j = 0; j < list.Count; j++)
					{
						int index = ((j < list.Count - 1) ? (j + 1) : 0);
						Vector3 vector2 = list[j][1].position - list[j][2].position;
						Vector3 vector3 = list[index][2].position - list[index][1].position;
						float num = Vector2.Angle(vector2, vector3) * ((float)Math.PI / 180f);
						float num2 = Mathf.Sign(Vector3.Cross(vector2.normalized, vector3.normalized).z);
						float num3 = _config.LineThickness / (2f * Mathf.Tan(num / 2f));
						Vector3 position2 = list[j][2].position - vector2.normalized * num3 * num2;
						Vector3 position3 = list[j][3].position + vector2.normalized * num3 * num2;
						if (num3 < vector2.magnitude / 2f && num3 < vector3.magnitude / 2f && num > (float)Math.PI / 12f)
						{
							list[j][2].position = position2;
							list[j][3].position = position3;
							list[index][0].position = position3;
							list[index][1].position = position2;
						}
						else
						{
							if (num3 < vector2.magnitude / 2f && num3 < vector3.magnitude / 2f && num > (float)Math.PI / 6f)
							{
								if (num2 < 0f)
								{
									list[j][2].position = position2;
									list[index][1].position = position2;
								}
								else
								{
									list[j][3].position = position3;
									list[index][0].position = position3;
								}
							}
							UIVertex[] quad = new UIVertex[4]
							{
								list[j][2],
								list[j][3],
								list[index][0],
								list[index][1]
							};
							AddQuad(quad, list2, list3, list4, list5);
						}
						AddQuad(list[j], list2, list3, list4, list5);
					}
					Mesh mesh = _meshFilter.mesh;
					mesh.SetVertices(list2);
					mesh.SetNormals(list3);
					mesh.SetUVs(0, list4);
					mesh.subMeshCount = 2;
					mesh.SetTriangles(triangles, 0);
					mesh.SetTriangles(list5, 1);
				}
			}
			Material[] array = (thinking ? _config.BoundsThinkingMaterial : (roomItem.IsValid ? _config.BoundsValidMaterial : _config.BoundsInvalidMaterial));
			_meshRenderer.materials = array;
			_animator.SetColors(array[0].color, array[1].color);
			if (_interactionPoints == null)
			{
				return;
			}
			int num4 = 0;
			bool isValid = roomItem.IsValid;
			foreach (ObjectInteraction interaction in roomItem.Interactions)
			{
				GameObject gameObject = _interactionPoints[num4];
				if (isValid)
				{
					GameObjectUtils.SetActive(gameObject, isActive: false);
				}
				else
				{
					Material sharedMaterial = (interaction.ValidStartPosition ? _config.InteractionPointValidMaterial : _config.InteractionPointInvalidMaterial);
					gameObject.GetComponentInChildren<MeshRenderer>().sharedMaterial = sharedMaterial;
					GameObjectUtils.SetActive(gameObject, isActive: true);
				}
				num4++;
			}
		}

		private UIVertex[] CreateLineSegment(Vector2 start, Vector2 end)
		{
			float x = Vector2.Distance(start, end) / _config.LineThickness;
			Vector2 vector = new Vector2(start.y - end.y, end.x - start.x).normalized * _config.LineThickness / 2f;
			return new UIVertex[4]
			{
				new UIVertex
				{
					position = start - vector,
					uv0 = new Vector2(0f, 0f)
				},
				new UIVertex
				{
					position = start + vector,
					uv0 = new Vector2(0f, 1f)
				},
				new UIVertex
				{
					position = end + vector,
					uv0 = new Vector2(x, 1f)
				},
				new UIVertex
				{
					position = end - vector,
					uv0 = new Vector2(x, 0f)
				}
			};
		}

		private void AddQuad(UIVertex[] quad, List<Vector3> vertices, List<Vector3> normals, List<Vector2> uv, List<int> tri)
		{
			int count = vertices.Count;
			for (int i = 0; i < quad.Length; i++)
			{
				UIVertex uIVertex = quad[i];
				vertices.Add(new Vector3(uIVertex.position.x, _config.LineElevation + 0.01f, uIVertex.position.y));
				normals.Add(Vector3.up);
				uv.Add(uIVertex.uv0);
			}
			tri.Add(count);
			tri.Add(count + 1);
			tri.Add(count + 2);
			tri.Add(count + 2);
			tri.Add(count + 3);
			tri.Add(count);
		}

		public void SetVisible(bool visible)
		{
			if (_visible != visible)
			{
				_visible = visible;
				GameObjectUtils.SetActive(_gameObject, isActive: true);
				_animator.SetVisible(visible);
			}
		}
	}
}
