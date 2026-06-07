using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class AttitudeBallBehaviour : PartModifierScript
	{
		private Material _material;

		private Material[] _materials;

		private int _matrixId;

		private Transform _scalar;

		private AttitudeBallData.BallType _type;

		public AttitudeBallData Modifier { get; set; }

		protected virtual void OnDestroy()
		{
			Modifier.OnScaleChanged -= OnScaleChanged;
			if (_materials != null)
			{
				for (int i = 0; i < _materials.Length; i++)
				{
					Object.Destroy(_materials[i]);
					_materials[i] = null;
				}
				_material = null;
			}
		}

		protected override void RegisterUpdateMethods(in PartModifierUpdateRegistrar registrar)
		{
			registrar.RegisterStart(OnStart);
			registrar.RegisterLateUpdate(OnLateUpdate, CraftUpdateFlags.FlightLocalUnpaused);
		}

		private void OnLateUpdate(in CraftUpdateFrameData frame)
		{
			Vector3 rotation = base.PartScript.Aircraft.Rotation;
			if ((_type & AttitudeBallData.BallType.Pitch) == 0)
			{
				rotation.x = 0f;
			}
			if ((_type & AttitudeBallData.BallType.Heading) == 0)
			{
				rotation.y = 0f;
			}
			if ((_type & AttitudeBallData.BallType.Roll) == 0)
			{
				rotation.z = 0f;
			}
			_material.SetMatrix(_matrixId, Matrix4x4.Rotate(Quaternion.Euler(rotation)));
		}

		private void OnScaleChanged(float scale)
		{
			if (_scalar != null)
			{
				_scalar.localScale = Vector3.one * scale;
			}
		}

		private void OnStart(in CraftUpdateFrameData frame)
		{
			Modifier.OnScaleChanged += OnScaleChanged;
			_scalar = base.transform.Find("Scalar");
			OnScaleChanged(Modifier.Scale);
			_type = Modifier.RotationType;
			Transform transform = base.transform.Find(Modifier.MeshPath);
			if (transform != null && transform.TryGetComponent<MeshRenderer>(out var component))
			{
				_materials = component.materials;
				for (int i = 0; i < _materials.Length; i++)
				{
					if (_materials[i].shader.name.Contains("AttitudeBall"))
					{
						_material = _materials[i];
					}
				}
			}
			if (_material == null)
			{
				Debug.LogError("AttitudeBallBehaviour cannot find material");
				base.enabled = false;
			}
			else
			{
				_matrixId = Shader.PropertyToID("_SphereTexMatrix");
				_material.SetMatrix(_matrixId, Matrix4x4.identity);
			}
		}
	}
}
