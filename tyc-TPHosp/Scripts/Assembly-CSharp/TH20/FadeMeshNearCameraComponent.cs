using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FadeMeshNearCameraComponent : MonoBehaviour
	{
		[Serializable]
		private struct Cylinder
		{
			public float Radius;

			public float Height;

			public float OffsetY;

			public Vector2 Position;
		}

		private class MeshData
		{
			public GameObject GameObject;

			public List<Material[]> OldMaterials;

			public List<Material[]> NewMaterials;
		}

		private const string _colorPropName = "_Color";

		[SerializeField]
		private float _radius = 10f;

		[SerializeField]
		private float _height = 20f;

		[SerializeField]
		private float _offsetY;

		[SerializeField]
		private Vector2 _position = Vector3.zero;

		[SerializeField]
		private float _fadeRate = 10f;

		[SerializeField]
		private Cylinder[] _extra;

		[SerializeField]
		private GameObject[] _children;

		private static float ExpandRadius = 10f;

		private static float ExpandHeight = 15f;

		private bool _isDithering;

		private const float cTolerance = 0.05f;

		private static List<FadeMeshNearCameraComponent> _activeComponents = new List<FadeMeshNearCameraComponent>();

		private List<MeshData> _meshData = new List<MeshData>();

		private static Color ColorOff = new Color(1f, 0.46f, 0.11f);

		private static Color ColorOn = new Color(0.11f, 1f, 0.46f);

		public float Alpha { get; private set; } = 1f;

		private void Awake()
		{
			_activeComponents.Add(this);
			AddGameObject(base.gameObject);
			if (_children != null)
			{
				GameObject[] children = _children;
				foreach (GameObject go in children)
				{
					AddGameObject(go);
				}
			}
			CacheMaterials();
		}

		private void AddGameObject(GameObject go)
		{
			_meshData.Add(new MeshData
			{
				GameObject = go
			});
		}

		private void OnDestroy()
		{
			DestroyMaterials();
			_activeComponents.Remove(this);
		}

		public static void UpdateAll()
		{
			Camera main = Camera.main;
			if (!(main != null))
			{
				return;
			}
			Vector3 position = main.transform.position;
			Vector2 camPos = position.Xz();
			float y = position.y;
			float unscaledDeltaTime = GameTime.unscaledDeltaTime;
			foreach (FadeMeshNearCameraComponent activeComponent in _activeComponents)
			{
				activeComponent.UpdateInner(camPos, y, unscaledDeltaTime);
			}
		}

		private void UpdateInner(Vector2 camPos, float camHeight, float deltaTime)
		{
			float num = CalculateAlpha(camPos, camHeight);
			if (Alpha.CompareTo(num) != 0)
			{
				Alpha = MathUtils.InterpolateTo(Alpha, num, _fadeRate, deltaTime);
				if (base.enabled)
				{
					if (!_isDithering)
					{
						_isDithering = true;
						foreach (MeshData meshDatum in _meshData)
						{
							MeshUtils.SetGameObjectMaterials(meshDatum.GameObject, ref meshDatum.NewMaterials);
						}
					}
					foreach (MeshData meshDatum2 in _meshData)
					{
						foreach (Material[] newMaterial in meshDatum2.NewMaterials)
						{
							foreach (Material material in newMaterial)
							{
								if (material != null && material.HasProperty("_Color"))
								{
									Color color = material.color;
									color.a = Alpha;
									material.color = color;
								}
							}
						}
					}
				}
			}
			if (!base.enabled || !_isDithering || !(1f - Alpha < 0.05f))
			{
				return;
			}
			_isDithering = false;
			foreach (MeshData meshDatum3 in _meshData)
			{
				MeshUtils.SetGameObjectMaterials(meshDatum3.GameObject, ref meshDatum3.OldMaterials);
			}
		}

		private float CalculateAlpha(Vector2 camPos, float camHeight)
		{
			Transform obj = base.gameObject.transform;
			Vector2 vector = obj.position.Xz();
			float y = obj.rotation.eulerAngles.y;
			float num = CalcAlphaFromDistance(camPos, camHeight, vector + _position.RotateY(y), _radius, _height, _offsetY);
			if (_extra != null)
			{
				Cylinder[] extra = _extra;
				for (int i = 0; i < extra.Length; i++)
				{
					Cylinder cylinder = extra[i];
					num = Mathf.Min(num, CalcAlphaFromDistance(camPos, camHeight, vector + cylinder.Position.RotateY(y), cylinder.Radius, cylinder.Height, cylinder.OffsetY));
				}
			}
			return num;
		}

		private static float CalcAlphaFromDistance(Vector2 camPos, float camHeight, Vector2 cylinderPos, float cylinderRadius, float cylinderHeight, float cylinderOffsetY)
		{
			float result = 1f;
			if (camHeight > cylinderOffsetY - ExpandHeight && camHeight < cylinderOffsetY + cylinderHeight + ExpandHeight && Vector2.Distance(cylinderPos, camPos) < cylinderRadius + ExpandRadius)
			{
				result = 0f;
			}
			return result;
		}

		private void CacheMaterials()
		{
			foreach (MeshData meshDatum in _meshData)
			{
				if (meshDatum.OldMaterials != null)
				{
					continue;
				}
				meshDatum.OldMaterials = new List<Material[]>();
				meshDatum.NewMaterials = new List<Material[]>();
				MeshUtils.GetGameObjectMaterials(meshDatum.GameObject, ref meshDatum.OldMaterials);
				foreach (Material[] oldMaterial in meshDatum.OldMaterials)
				{
					List<Material> list = new List<Material>(oldMaterial.Length);
					Material[] array = oldMaterial;
					foreach (Material material in array)
					{
						if (material == null)
						{
							list.Add(null);
							continue;
						}
						Material material2 = new Material(material);
						if (TH20Standard.IsTH20Standard(material2))
						{
							TH20Standard.SetBlendMode(material2, TH20Standard.BlendMode.Dithered);
						}
						list.Add(material2);
					}
					meshDatum.NewMaterials.Add(list.ToArray());
				}
			}
		}

		private void DestroyMaterials()
		{
			foreach (MeshData meshDatum in _meshData)
			{
				if (meshDatum.OldMaterials == null || meshDatum.NewMaterials == null)
				{
					continue;
				}
				MeshUtils.SetGameObjectMaterials(meshDatum.GameObject, ref meshDatum.OldMaterials);
				foreach (Material[] newMaterial in meshDatum.NewMaterials)
				{
					foreach (Material material in newMaterial)
					{
						if (material != null)
						{
							UnityEngine.Object.Destroy(material);
						}
					}
				}
				meshDatum.OldMaterials = null;
				meshDatum.NewMaterials = null;
			}
		}

		private void DrawGizmo(bool selected)
		{
			Camera current = Camera.current;
			if (!(current != null))
			{
				return;
			}
			Vector3 position = current.transform.position;
			Vector2 camPos = position.Xz();
			float y = position.y;
			Transform transform = base.gameObject.transform;
			Vector3 position2 = transform.position;
			bool flag = CalculateAlpha(camPos, y) <= 0f;
			Color color = (flag ? ColorOff : ColorOn);
			if (!Application.isPlaying)
			{
				Renderer[] componentsInChildren = GetComponentsInChildren<Renderer>();
				if (componentsInChildren != null)
				{
					Renderer[] array = componentsInChildren;
					for (int i = 0; i < array.Length; i++)
					{
						array[i].enabled = !flag;
					}
				}
			}
			color.a = (selected ? 0.75f : 0.25f);
			Gizmos.matrix = Matrix4x4.identity;
			float y2 = transform.rotation.eulerAngles.y;
			DrawCylinder(selected, position2 + _position.RotateY(y2).as_xz_v3(), _radius, _height, _offsetY, color);
			if (_extra != null)
			{
				Cylinder[] extra = _extra;
				for (int i = 0; i < extra.Length; i++)
				{
					Cylinder cylinder = extra[i];
					DrawCylinder(selected, position2 + cylinder.Position.RotateY(y2).as_xz_v3(), cylinder.Radius, cylinder.Height, cylinder.OffsetY, color);
				}
			}
		}

		private static void DrawCylinder(bool selected, Vector3 pos, float radius, float height, float offsetY, Color color)
		{
			pos.y += offsetY;
			GizmosExtension.DebugCylinder(pos, pos + Vector3.up * height, radius, color);
			if (selected)
			{
				GizmosExtension.DebugCylinder(pos - Vector3.up * ExpandHeight, pos + Vector3.up * (height + ExpandHeight), radius + ExpandRadius, color * 0.5f);
			}
		}

		private void OnDrawGizmos()
		{
			DrawGizmo(selected: false);
		}

		private void OnDrawGizmosSelected()
		{
			DrawGizmo(selected: true);
		}
	}
}
