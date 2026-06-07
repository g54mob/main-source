using UnityEngine;

namespace Assets.Scripts.Craft.Parts.Modifiers
{
	public class ResizableShapeScript : PartModifierScript
	{
		private MeshCollider _meshCollider;

		private Vector3? _previousPartScale;

		private ResizableShapeData _resizableShape;

		private SphereCollider _sphereCollider;

		public void ApplyPhysics()
		{
			if (_sphereCollider != null)
			{
				_sphereCollider.material.bounciness = _resizableShape.Bounciness;
				_sphereCollider.material.dynamicFriction = _resizableShape.Friction;
				_sphereCollider.material.staticFriction = _resizableShape.Friction;
				_sphereCollider.material.bounceCombine = PhysicsMaterialCombine.Maximum;
			}
			if (_meshCollider != null)
			{
				_meshCollider.material.bounciness = _resizableShape.Bounciness;
				_meshCollider.material.dynamicFriction = _resizableShape.Friction;
				_meshCollider.material.staticFriction = _resizableShape.Friction;
				_meshCollider.material.bounceCombine = PhysicsMaterialCombine.Maximum;
			}
		}

		public void CheckScale()
		{
			if (!(_previousPartScale != base.PartScript.Part.PartScale) || _sphereCollider == null || _meshCollider == null)
			{
				return;
			}
			_previousPartScale = base.PartScript.Part.PartScale;
			if (_previousPartScale.HasValue)
			{
				Vector3 value = _previousPartScale.Value;
				if (!Mathf.Approximately(value.x, value.y) || !Mathf.Approximately(value.x, value.z))
				{
					_meshCollider.enabled = true;
					_sphereCollider.enabled = false;
				}
				else
				{
					_sphereCollider.enabled = true;
					_meshCollider.enabled = false;
				}
			}
		}

		public void Initialize(ResizableShapeData modifier)
		{
			_resizableShape = modifier;
			_meshCollider = GetComponentInChildren<MeshCollider>();
			_sphereCollider = GetComponentInChildren<SphereCollider>();
			_resizableShape.ApplySize(reposition: false);
			if (base.PartScript.LoadContext == CraftLoadContext.Flight)
			{
				ApplyPhysics();
			}
			CheckScale();
		}
	}
}
