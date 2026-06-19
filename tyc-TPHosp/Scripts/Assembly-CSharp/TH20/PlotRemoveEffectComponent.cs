using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature)]
	public class PlotRemoveEffectComponent : MonoBehaviour
	{
		private const float AnimSpeed = 64f;

		private const float FlyDistance = 24f;

		private float _time;

		private Vector3 _origin;

		private List<Material[]> _oldMaterials = new List<Material[]>();

		private List<Material[]> _newMaterials = new List<Material[]>();

		private void Awake()
		{
			OverrideMaterials();
		}

		private void OnDestroy()
		{
			RestoreMaterials();
		}

		private void Update()
		{
			_time += GameTime.unscaledDeltaTime;
			Vector3 position = base.gameObject.transform.position;
			float num = (position.x - _origin.x + position.z - _origin.z) / 64f;
			float num2 = Mathf.Clamp(_time - num, 0f, 1f);
			num2 *= num2;
			float num3 = 1f - Mathf.Cos(num2 * (float)Math.PI);
			base.gameObject.transform.position = new Vector3(position.x, num3 * 24f, position.z);
			float a = 1f - num3;
			foreach (Material[] newMaterial in _newMaterials)
			{
				foreach (Material material in newMaterial)
				{
					if (material != null)
					{
						Color color = material.color;
						color.a = a;
						material.color = color;
					}
				}
			}
			if (num3 >= 1f)
			{
				UnityEngine.Object.DestroyImmediate(base.gameObject);
			}
		}

		public void Initialise(Vector3 origin)
		{
			_origin = origin;
		}

		private void OverrideMaterials()
		{
			MeshUtils.GetGameObjectMaterials(base.gameObject, ref _oldMaterials);
			foreach (Material[] oldMaterial in _oldMaterials)
			{
				List<Material> list = new List<Material>(oldMaterial.Length);
				Material[] array = oldMaterial;
				foreach (Material material in array)
				{
					Material material2 = ((material != null) ? new Material(material) : null);
					if (material2 != null)
					{
						if (TH20Standard.IsTH20Standard(material2))
						{
							TH20Standard.SetBlendMode(material2, TH20Standard.BlendMode.Dithered);
						}
						Color color = material2.color;
						color.a = 1f;
						material2.color = color;
					}
					list.Add(material2);
				}
				_newMaterials.Add(list.ToArray());
			}
			MeshUtils.SetGameObjectMaterials(base.gameObject, ref _newMaterials);
		}

		private void RestoreMaterials()
		{
			if (_oldMaterials == null || _newMaterials == null)
			{
				return;
			}
			MeshUtils.SetGameObjectMaterials(base.gameObject, ref _oldMaterials);
			foreach (Material[] newMaterial in _newMaterials)
			{
				for (int i = 0; i < newMaterial.Length; i++)
				{
					UnityEngine.Object.Destroy(newMaterial[i]);
				}
			}
		}
	}
}
