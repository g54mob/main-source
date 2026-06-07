using System.Collections.Generic;
using Data.FactoryFloor.FactoryObjectBehaviours;
using Data.FactoryFloor.Resources;
using Logic.Factory;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.VFX;

namespace Presentation.FactoryFloor.FactoryObjectViews.OperatorViews
{
	public class SalvagerView : FactoryResourceHolderView<SalvagerBehaviour>
	{
		private static readonly int Active = Shader.PropertyToID("_Active");

		private static readonly int EmissionColor = Shader.PropertyToID("_EmissionColor");

		private static readonly int StartTime = Shader.PropertyToID("_StartTime");

		[SerializeField]
		private float _rotateMaxSpeed = 1f;

		[SerializeField]
		private float _rotateAcceleration = 1f;

		[SerializeField]
		private float _rotateDeceleration = 2f;

		[SerializeField]
		private Transform _rotationTransform;

		[SerializeField]
		private VisualEffect _activityVisualEffects;

		[Header("Colour")]
		[SerializeField]
		private List<MeshRenderer> _emissionRenderers = new List<MeshRenderer>();

		[SerializeField]
		private List<MeshRenderer> _sparkRenderers = new List<MeshRenderer>();

		[SerializeField]
		[ColorUsage(false, true)]
		private List<Color> _emissionByResourceIndex = new List<Color>();

		private readonly List<Material> _emissionMaterials = new List<Material>();

		private float _rotateVelocity;

		private bool _isActivity;

		private Material _sparkMaterial;

		protected override void Init()
		{
			base.Init();
			_behaviour.OnOutputResource.RegisterMainThread(base.PassResource);
			_behaviour.OnChangedResource += OnResourceChanged;
			_behaviour.OnActivityStart.RegisterMainThread(OnActivityStart);
			_behaviour.OnActivityEnd.RegisterMainThread(OnActivityEnd);
			_rotationTransform.localRotation = Quaternion.identity;
			InitalizeMaterials();
		}

		protected override void ResetFactoryObject()
		{
			ResetView();
			base.ResetFactoryObject();
		}

		private void ResetView()
		{
			if (_behaviour != null)
			{
				_behaviour.OnOutputResource.UnRegisterMainThread(base.PassResource);
				_behaviour.OnChangedResource -= OnResourceChanged;
				_behaviour.OnActivityStart.UnRegisterMainThread(OnActivityStart);
				_behaviour.OnActivityEnd.UnRegisterMainThread(OnActivityEnd);
			}
			_rotateVelocity = 0f;
			_rotationTransform.rotation = Quaternion.identity;
		}

		private void OnActivityStart()
		{
			_isActivity = true;
			_activityVisualEffects.enabled = true;
			_sparkMaterial.SetFloat(StartTime, Time.time);
			_sparkMaterial.SetFloat(Active, 1f);
		}

		private void OnActivityEnd()
		{
			_isActivity = false;
			_activityVisualEffects.enabled = false;
			_sparkMaterial.SetFloat(StartTime, Time.time);
			_sparkMaterial.SetFloat(Active, 0f);
		}

		private void Update()
		{
			if (!((float)FactoryUpdater.Instance.GetStepsPerSecond() <= 0f))
			{
				if (_isActivity)
				{
					_rotateVelocity += Time.deltaTime * _rotateAcceleration;
					_rotateVelocity = Mathf.Min(_rotateVelocity, _rotateMaxSpeed);
				}
				else
				{
					_rotateVelocity -= Time.deltaTime * _rotateDeceleration;
					_rotateVelocity = Mathf.Max(_rotateVelocity, 0f);
				}
				if (_rotateVelocity > Mathf.Epsilon)
				{
					_rotationTransform.transform.Rotate(Vector3.up, _rotateVelocity * Time.deltaTime, Space.Self);
				}
			}
		}

		private void OnResourceChanged(NonShapeResourceDataSO resourceData)
		{
			UpdateMaterialColour();
		}

		public void InitalizeMaterials()
		{
			List<Material> list = CollectionPool<List<Material>, Material>.Get();
			foreach (MeshRenderer emissionRenderer in _emissionRenderers)
			{
				list.Clear();
				emissionRenderer.GetSharedMaterials(list);
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].HasColor(EmissionColor))
					{
						Material item = (list[i] = Object.Instantiate(list[i]));
						_emissionMaterials.Add(item);
					}
				}
				emissionRenderer.SetSharedMaterials(list);
			}
			CollectionPool<List<Material>, Material>.Release(list);
			_sparkMaterial = Object.Instantiate(_sparkRenderers[0].sharedMaterial);
			foreach (MeshRenderer sparkRenderer in _sparkRenderers)
			{
				sparkRenderer.material = _sparkMaterial;
			}
			UpdateMaterialColour();
		}

		public void UpdateMaterialColour()
		{
			Color value = _emissionByResourceIndex[_behaviour.ChosenResourceDataIndex];
			foreach (Material emissionMaterial in _emissionMaterials)
			{
				emissionMaterial.SetColor(EmissionColor, value);
			}
			_sparkMaterial.SetColor(EmissionColor, value);
		}
	}
}
