using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class FadeMeshWorldHeightComponent : MonoBehaviour
	{
		private const string _colorPropName = "_Color";

		[SerializeField]
		private float _startFadeOutHeight = 20f;

		[SerializeField]
		private float _endFadeOutHeight = 30f;

		[SerializeField]
		private Transform _targetTransform;

		private bool _isDithering;

		private float _alpha = -1f;

		private List<Material[]> _oldMaterials;

		private List<Material[]> _newMaterials;

		private const float cTolerance = 0.05f;

		private static List<FadeMeshWorldHeightComponent> _activeComponents = new List<FadeMeshWorldHeightComponent>();

		private void Awake()
		{
			_activeComponents.Add(this);
			CacheMaterials();
		}

		private void OnDestroy()
		{
			DestroyMaterials();
			_activeComponents.Remove(this);
		}

		public static void Update()
		{
			if (!(Camera.main != null))
			{
				return;
			}
			foreach (FadeMeshWorldHeightComponent activeComponent in _activeComponents)
			{
				activeComponent.UpdateInner();
			}
		}

		private void UpdateInner()
		{
			float num = Mathf.InverseLerp(_endFadeOutHeight, _startFadeOutHeight, _targetTransform.position.y);
			if (_alpha != num)
			{
				_alpha = num;
				if (base.enabled)
				{
					if (!_isDithering)
					{
						_isDithering = true;
						MeshUtils.SetGameObjectMaterials(base.gameObject, ref _newMaterials);
					}
					foreach (Material[] newMaterial in _newMaterials)
					{
						foreach (Material material in newMaterial)
						{
							if (material != null && material.HasProperty("_Color"))
							{
								Color color = material.color;
								color.a = _alpha;
								material.color = color;
							}
						}
					}
				}
			}
			if (base.enabled && _isDithering && 1f - _alpha < 0.05f)
			{
				_isDithering = false;
				MeshUtils.SetGameObjectMaterials(base.gameObject, ref _oldMaterials);
			}
		}

		private void CacheMaterials()
		{
			if (_oldMaterials != null)
			{
				return;
			}
			_oldMaterials = new List<Material[]>();
			_newMaterials = new List<Material[]>();
			MeshUtils.GetGameObjectMaterials(base.gameObject, ref _oldMaterials);
			foreach (Material[] oldMaterial in _oldMaterials)
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
				_newMaterials.Add(list.ToArray());
			}
		}

		private void DestroyMaterials()
		{
			if (_oldMaterials == null || _newMaterials == null)
			{
				return;
			}
			MeshUtils.SetGameObjectMaterials(base.gameObject, ref _oldMaterials);
			foreach (Material[] newMaterial in _newMaterials)
			{
				foreach (Material material in newMaterial)
				{
					if (material != null)
					{
						Object.Destroy(material);
					}
				}
			}
			_oldMaterials = null;
			_newMaterials = null;
		}
	}
}
